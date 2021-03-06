﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CustomPropsHelperApp.Models;
using CustomPropsHelperApp.Utils;

namespace CustomPropsHelperApp
{
	public partial class Form1 : Form
	{
		public const string Header = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>";

		private bool _reading;

		public Form1()
		{
			Map = new CMapTypes();
			InitializeComponent();

			var deleteButton = new DataGridViewButtonColumn
			{
				Name = "dataGridViewDeleteButton",
				HeaderText = "",
				UseColumnTextForButtonValue = true,
				Text = "Delete"
			};
			dataGridView1.Columns.Add(deleteButton);
		}

		public CMapTypes Map { get; private set; }

		private void openXmlToolStripMenuItem_Click(object sender, EventArgs e)
		{

			OpenFileDialog diag = new OpenFileDialog { SupportMultiDottedExtensions = true, Filter = @"YTYP.XML files (*ytyp.xml)|*ytyp.xml", FileName = "def_props.ytyp.xml" };
			if (diag.ShowDialog(this) != DialogResult.OK)
				return;

			string path = diag.FileName;
			try
			{
				_reading = true;
				dataGridView1.Rows.Clear();
				dataGridView1.ClearSelection();
				dataGridView1.CurrentCell = dataGridView1[0, 0];
				dataGridView1.CurrentCell.Selected = false;
				XmlSerializer ser = new XmlSerializer(typeof(CMapTypes));
				using (StreamReader reader = new StreamReader(path))
				{
					Map = (CMapTypes)ser.Deserialize(reader);
					reader.Close();
				}
				foreach (var archetype in Map.archetypes)
				{
					CreateRowFromArchetype(archetype, dataGridView1);
				}
				cMapNameTextBox.Text = Map.name;
				_reading = false;
			}
			catch (Exception exception)
			{
				string val = string.Empty;
				if (File.Exists("Error.log"))
					val = File.ReadAllText("Error.log") + "\n";
				File.WriteAllText("ErrorLog.log", val + $@"[ERROR] [{DateTime.UtcNow:hh:mm:ss}]" + exception.Message + Environment.NewLine + exception.StackTrace);
				throw;
			}
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Collect all information that was previously changed!
			CollectData(false);

			// Then serialize the data.
			Serialize();
		}

		private void exportIPLFormatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Collect all information that was previously changed!
			CollectData(true);

			// Then serialize the data.
			Serialize();
		}

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(@"Error happened " + e.Context);

			if (e.Context == DataGridViewDataErrorContexts.Commit)
			{
				MessageBox.Show(@"Commit error");
			}
			if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
			{
				MessageBox.Show(@"Cell change");
			}
			if (e.Context == DataGridViewDataErrorContexts.Parsing)
			{
				MessageBox.Show(@"parsing error");
			}
			if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
			{
				MessageBox.Show(@"leave control error");
			}

			if ((e.Exception) is ConstraintException)
			{
				DataGridView view = (DataGridView)sender;
				view.Rows[e.RowIndex].ErrorText = "an error";
				view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

				e.ThrowException = false;
			}
		}

		private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//If this is header row or new row, do nothing
			if (e.RowIndex < 0 || e.RowIndex == dataGridView1.NewRowIndex)
				return;

			//If formatting your desired column, set the value
			var dataGridViewColumn = dataGridView1.Columns["dataGridViewDeleteButton"];
			if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
			{
				e.Value = "Delete";
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//if click is on new row or header row
			if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
				return;

			//Check if click is on specific column 
			var dataGridViewColumn = dataGridView1.Columns["dataGridViewDeleteButton"];
			if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
			{
				//Put some logic here, for example to remove row from your binding list.
				dataGridView1.Rows.RemoveAt(e.RowIndex);
				Map.archetypes.RemoveAt(e.RowIndex);
			}
		}

		private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (_reading)
				return;

			if (e.RowIndex == -1 || e.RowCount == 0)
				return;

			// Add a new archtype to the map.
			var item = new CMapTypes.Item();
			Map.archetypes.Add(item);

			// Initialize the row with default values.
			var row = dataGridView1.Rows[e.RowIndex - 1];
			row.Cells["propModel"].Value = string.Empty;
			row.Cells["textureDictionary"].Value = string.Empty;
			row.Cells["lodDist"].Value = "100.0";
			row.Cells["flags"].Value = ((DataGridViewComboBoxCell)row.Cells["flags"]).Items[0];

			SetArchetypeDataFromRow(row, ref item);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dataGridView1_DragEnter(object sender, DragEventArgs e)
		{
			string[] files = (string[])e?.Data?.GetData(DataFormats.FileDrop, false);

			if (files == null)
				return;

			if (files.Length == 1 && files[0].EndsWith(".txt"))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}

			foreach (var file in files)
			{
				var ext = Path.GetExtension(file);
				if (ext != ".ydr")
				{
					e.Effect = DragDropEffects.None;
					return;
				}
			}

			e.Effect = DragDropEffects.Copy;
		}

		private void dataGridView1_DragDrop(object sender, DragEventArgs e)
		{
			_reading = true;
			Cursor.Current = Cursors.Default;
			string[] files = (string[])e?.Data?.GetData(DataFormats.FileDrop, false);

			if (files == null)
				return;

			DragDropPresetForm ddpf = new DragDropPresetForm { Owner = this };
			var row = ddpf.presetDataGrid.Rows[ddpf.presetDataGrid.Rows.Add(1)];

			if (ddpf.ShowDialog() != DialogResult.OK)
				return;

			if (files.Length == 1 && files[0].EndsWith(".txt"))
			{
				var path = files[0];
				var lines = File.ReadAllLines(path);
				foreach (var entry in lines)
				{
					var item = new CMapTypes.Item();
					Map.archetypes.Add(item);
					SetArchetypeDataFromRow(row, ref item);
					item.name = entry;
					item.textureDictionary = item.name;
					CreateRowFromArchetype(item, dataGridView1);
				}

				return;
			}

			foreach (var entry in files)
			{
				var item = new CMapTypes.Item();
				Map.archetypes.Add(item);
				SetArchetypeDataFromRow(row, ref item);
				item.name = Path.GetFileNameWithoutExtension(entry);
				item.textureDictionary = string.IsNullOrEmpty(row.Cells["textureDictionary"].EditedFormattedValue.ToString())
					? item.name
					: row.Cells["textureDictionary"].EditedFormattedValue.ToString();
				CreateRowFromArchetype(item, dataGridView1);
			}

			ddpf.Close();
			_reading = false;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Point position = Location;
			Form1 newForm = new Form1
			{
				StartPosition = FormStartPosition.Manual,
				Location = position
			};
			newForm.Show();
			newForm.Closed += (o, args) =>
			{
				Application.Exit();
			};
			Dispose(false);
		}

		private void buildRPFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cMapNameTextBox.Text))
				MessageBox.Show(@"You must have a CMap Name specified!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			FolderBrowserDialog fbd = new FolderBrowserDialog { Description = @"Select an Output Directory." };
			if (fbd.ShowDialog() != DialogResult.OK)
				return;

			string dlcname = Prompt.ShowDialog("Enter the name of your dlc 'folder'.", "DLC Name");

			if (string.IsNullOrEmpty(dlcname) || dlcname.Any(ch => !char.IsLetterOrDigit(ch) || dlcname.Contains(' ')))
			{
				MessageBox.Show(@"Name not valid. Letters or numbers only.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			dlcname = dlcname.ToLower();




			XmlDocument dummydoc = new XmlDocument();
			XmlNode descNode =
				dummydoc.CreateCDataSection("NOTE: If you don't want to lose default files, use mods folder." +
											"\nThis installation changes **dlclist.xml**");

			var assemblypath = fbd.SelectedPath + "\\assembly.xml";
			package assembly = new package
			{
				version = "2.1",
				id = "{" + Guid.NewGuid() + "}",
				target = "Five",
				metadata = new[]
				{
					new packageMetadata
					{
						name = "Custom Props DLC Installer",
						version = new[]
						{
							new packageMetadataVersion
							{
								major = "0",
								minor = "0"
							}
						},
						author = new[]
						{
							new packageMetadataAuthor
							{
								displayName = "Sollaholla"
							}
						},
						description = descNode
					}
				},
				colors = new[]
				{
					new packageColors
					{
						headerBackground = new[]
						{
							new packageColorsHeaderBackground
							{
								useBlackTextColor = "true",
								Value = "$00FFFFFF"
							}
						},
						iconBackground = "$00FFFFFF"
					}
				},
				content = new[]
				{
					new packageContent
					{
						archive = new[]
						{
							new archive
							{
								path = $"update\\x64\\dlcpacks\\{dlcname}\\dlc.rpf",
								createIfNotExist = "True",
								type = "RPF7",
								add = new[]
								{
									new archiveAdd
									{
										source = "content.xml",
										Value = "content.xml"
									},
									new archiveAdd
									{
										source = "setup2.xml",
										Value = "setup2.xml"
									}
								},
								addedArchives = new[]
								{
									new archive
									{
										path = $"x64\\levels\\gta5\\props\\{cMapNameTextBox.Text}.rpf",
										createIfNotExist = "True",
										type = "RPF7"
									}
								}
							},
							new archive
							{
								path = "update\\update.rpf",
								createIfNotExist = "False",
								type = "RPF7",
								xml = new[]
								{
									new packageContentXml
									{
										path = "common\\data\\dlclist.xml",
										add = new[]
										{
											new xmlAdd
											{
												xpath = "/SMandatoryPacksData/Paths",
												item = new[]
												{
													new xmlItem
													{
														Value = $"dlcpacks:\\{dlcname}\\"
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			};
			DefaultObjectSerialize(assemblypath, assembly);


			string properChangeSetName = $"{dlcname}_autogen".ToUpper();
			// Create the content.xml for our dlc.
			CDataFileMgr__ContentsOfDataFileXml cdatafilemgr = new CDataFileMgr__ContentsOfDataFileXml();
			string filePrefix = "dlc_" + dlcname;
			cdatafilemgr.dataFiles = new[]
			{
				new Item
				{
					filename = $"{filePrefix}:/%PLATFORM%/levels/gta5/props/{cMapNameTextBox.Text}.rpf",
					fileType = "RPF_FILE",
					overlay = new[] { new ItemOverlay {value = "false"} },
					disabled = new[] { new ItemDisabled { value = "true"} },
					persistent = new[] {new ItemPersistent { value = "true"} }
				},
				new Item
				{
					filename = $"{filePrefix}:/%PLATFORM%/levels/gta5/props/{GetPropDefName(".ityp")}",
					fileType = "DLC_ITYP_REQUEST",
					overlay = new[] { new ItemOverlay {value = "false"} },
					disabled = new[] { new ItemDisabled { value = "true"} },
					persistent = new[] {new ItemPersistent { value = "true"} }
				}
			};
			cdatafilemgr.contentChangeSets = new[]
			{
				new ChangeSetItem
				{
					changeSetName = properChangeSetName,
					filesToEnable = new []
					{
						new ItemFilesToEnableDlc
						{
							Value = $"{filePrefix}:/%PLATFORM%/levels/gta5/props/{cMapNameTextBox.Text}.rpf"
						},
						new ItemFilesToEnableDlc
						{
							Value = $"{filePrefix}:/%PLATFORM%/levels/gta5/props/{GetPropDefName(".ityp")}"
						}
					},
					requiresLoadingScreen = new [] { new ItemRequiresLoadingScreen {value = "false"} }
				}
			};
			var contentXmlPath = fbd.SelectedPath + "\\content.xml";
			DefaultObjectSerialize(contentXmlPath, cdatafilemgr);



			// Create the setup2.xml
			SSetupData ssetupdata = new SSetupData
			{
				deviceName = filePrefix,
				datFile = "content.xml",
				timeStamp = $"{DateTime.UtcNow:g}",
				nameHash = dlcname,
				contentChangeSetGroups = new[]
				{
					new SSetupDataContentChangeSetGroupsItem
					{
						NameHash = "GROUP_STARTUP",
						ContentChangeSets = new[]
						{
							new SSetupDataContentChangeSetGroupsItemContentChangeSets
							{
								Item = properChangeSetName
							}
						}
					}
				},
				scriptCallstackSize = new[] { new SSetupDataScriptCallstackSize { value = "0" } },
				type = "EXTRACONTENT_COMPAT_PACK",
				order = new[] { new SSetupDataOrder { value = "25" } },
				minorOrder = new[] { new SSetupDataMinorOrder { value = "0" } },
				isLevelPack = new[] { new SSetupDataIsLevelPack { value = "false" } },
				subPackCount = new[] { new SSetupDataSubPackCount { value = "0" } }
			};
			var setup2XmlPath = fbd.SelectedPath + "\\setup2.xml";
			DefaultObjectSerialize(setup2XmlPath, ssetupdata);



			// Create our .oiv archive.
			if (File.Exists(fbd.SelectedPath + "\\PropInstall.oiv"))
				File.Delete(fbd.SelectedPath + "\\PropInstall.oiv");
			using (ZipArchive zip = ZipFile.Open(fbd.SelectedPath + "\\PropInstall.oiv", ZipArchiveMode.Create))
			{
				var oivContentFolder = fbd.SelectedPath + "\\content";
				zip.CreateEntryFromFolder(Directory.CreateDirectory(oivContentFolder).FullName, "content");

				zip.CreateEntryFromFile(assemblypath, "assembly.xml");
				zip.CreateEntryFromFile(contentXmlPath, "content\\content.xml");
				zip.CreateEntryFromFile(setup2XmlPath, "content\\setup2.xml");

				if (File.Exists(assemblypath))
					File.Delete(assemblypath);
				if (File.Exists(contentXmlPath))
					File.Delete(contentXmlPath);
				if (File.Exists(setup2XmlPath))
					File.Delete(setup2XmlPath);

				if (Directory.Exists(oivContentFolder))
					Directory.Delete(oivContentFolder);
			}

			MessageBox.Show(@"Created DLC Installer", @"DLC Directory Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DefaultObjectSerialize<T>(string fileName, T obj)
		{
			var serializer = new XmlSerializer(typeof(T));
			var writer = new StreamWriter(fileName);
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");
			serializer.Serialize(writer, obj, ns);
			writer.Close();
		}

		private void CreateRowFromArchetype(CMapTypes.Item archetype, DataGridView gridView)
		{
			var row = gridView.Rows[gridView.Rows.Add(1)];
			row.Cells["propModel"].Value = archetype.name;
			row.Cells["textureDictionary"].Value = archetype.textureDictionary;
			row.Cells["lodDist"].Value = archetype.lodDist.value;

			int flagType;
			switch (archetype.flags.value)
			{
				case 12713984:
					flagType = 0;
					break;
				case 32:
					flagType = 1;
					break;
				default:
					flagType = -1;
					break;
			}

			var dataGridViewComboBoxCell = (DataGridViewComboBoxCell)row.Cells["flags"];
			row.Cells["flags"].Value = flagType != -1
				? dataGridViewComboBoxCell.Items[flagType]
				: dataGridViewComboBoxCell.Items[dataGridViewComboBoxCell.Items.Add(archetype.flags.value.ToString())];
		}

		private void SetArchetypeDataFromRow(DataGridViewRow row, ref CMapTypes.Item item)
		{
			// Model name.
			item.name = (string)row.Cells["propModel"].EditedFormattedValue;
			item.assetName = item.name;

			// Dictionaries.
			item.textureDictionary = string.IsNullOrEmpty(row.Cells["textureDictionary"].EditedFormattedValue.ToString())
				? item.name
				: row.Cells["textureDictionary"].EditedFormattedValue.ToString();
			item.physicsDictionary = cMapNameTextBox.Text;

			// Lod distance.
			var lodDistCellValue = row.Cells["lodDist"].EditedFormattedValue;
			var lodValueString = lodDistCellValue.ToString();
			double dVal;
			if (double.TryParse(lodValueString, out dVal))
			{
				item.lodDist.value = dVal;
			}

			// Collision flag.
			var flagCell = (DataGridViewComboBoxCell)row.Cells["flags"];
			var flagValueString = flagCell.EditedFormattedValue.ToString();
			switch (flagValueString)
			{
				case "Dynamic":
					item.flags.value = 12713984;
					break;
				case "Static":
					item.flags.value = 32;
					break;
				default:
					int f;
					if (int.TryParse(flagValueString, out f))
						item.flags.value = f;
					break;
			}

			// Set the physics dictionary.
			item.physicsDictionary = cMapNameTextBox.Text;

			// Bounds.
			item.bbMin = new XmlV3 { x = -100, y = -100, z = -100 };
			item.bbMax = new XmlV3 { x = 100, y = 100, z = 100 };
		}

		private void SetArchetypeDataFromRow2(DataGridViewRow row, ref CMapTypes.Item item)
		{
			// Model name.
			item.name = (string)row.Cells["propModel"].EditedFormattedValue;
			item.name = item.name.ToLower();
			item.assetName = item.name;

			// Texture type.
			item.textureDictionary = string.Empty;

			// Lod distance.
			var lodDistCellValue = row.Cells["lodDist"].EditedFormattedValue;
			var lodValueString = lodDistCellValue.ToString();
			double dVal;
			if (double.TryParse(lodValueString, out dVal))
			{
				item.lodDist.value = dVal;
			}

			// Collision flag.
			var flagCell = (DataGridViewComboBoxCell)row.Cells["flags"];
			var flagValueString = flagCell.EditedFormattedValue.ToString();
			switch (flagValueString)
			{
				case "Dynamic":
					item.flags.value = 12713984;
					break;
				case "Static":
					item.flags.value = 32;
					break;
				default:
					int f;
					if (int.TryParse(flagValueString, out f))
						item.flags.value = f;
					break;
			}

			// Set the physics dictionary.
			item.physicsDictionary = item.name;

			// Bounds.
			item.bbMin = new XmlV3 { x = -3000, y = -3000, z = -3000 };
			item.bbMax = new XmlV3 { x = 3000, y = 3000, z = 3000 };
		}

		private void CollectData(bool iplFormat)
		{
			for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
			{
				var row = dataGridView1.Rows[i];
				var item = Map.archetypes[i];
				if (!iplFormat)
				{
					SetArchetypeDataFromRow(row, ref item);
					continue;
				}
				SetArchetypeDataFromRow2(row, ref item);
			}
		}

		private void Serialize()
		{
			SaveFileDialog diag = new SaveFileDialog { SupportMultiDottedExtensions = true, Filter = @"YTYP.XML files (*ytyp.xml)|*ytyp.xml", FileName = GetPropDefName(".ytyp.xml") };
			if (diag.ShowDialog(this) != DialogResult.OK)
				return;

			Map.name = cMapNameTextBox.Text;
			string path = diag.FileName;

			Cursor.Current = Cursors.WaitCursor;

			XmlSerializer s = new XmlSerializer(typeof(CMapTypes));
			using (FileStream fs = new FileStream(path, FileMode.Create))
			{
				XmlWriterSettings settings = new XmlWriterSettings
				{
					Encoding = Encoding.UTF8,
					NewLineChars = Environment.NewLine,
					ConformanceLevel = ConformanceLevel.Document,
					Indent = true
				};
				XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
				ns.Add("", "");
				using (XmlWriter writer = XmlWriter.Create(fs, settings))
				{
					s.Serialize(writer, Map, ns);
				}
				fs.Close();
			}
			Cursor.Current = Cursors.Default;
		}

		private string GetPropDefName(string extension)
		{
			return "def_" + cMapNameTextBox.Text + extension;
		}
	}
}
