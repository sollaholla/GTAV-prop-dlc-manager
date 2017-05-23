namespace CustomPropsHelperApp
{
	partial class DragDropPresetForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DragDropPresetForm));
			this.label1 = new System.Windows.Forms.Label();
			this.presetDataGrid = new System.Windows.Forms.DataGridView();
			this.doneButton = new System.Windows.Forms.Button();
			this.propModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textureDictionary = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lodDist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flags = new System.Windows.Forms.DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.presetDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(396, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Set the Preset For All Specified Files";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// presetDataGrid
			// 
			this.presetDataGrid.AllowDrop = true;
			this.presetDataGrid.AllowUserToAddRows = false;
			this.presetDataGrid.AllowUserToDeleteRows = false;
			this.presetDataGrid.AllowUserToResizeRows = false;
			this.presetDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.presetDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.presetDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.presetDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.propModel,
            this.textureDictionary,
            this.lodDist,
            this.flags});
			this.presetDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.presetDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.presetDataGrid.Location = new System.Drawing.Point(0, 25);
			this.presetDataGrid.Name = "presetDataGrid";
			this.presetDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.presetDataGrid.RowHeadersVisible = false;
			this.presetDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.presetDataGrid.Size = new System.Drawing.Size(396, 43);
			this.presetDataGrid.TabIndex = 1;
			// 
			// doneButton
			// 
			this.doneButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.doneButton.Location = new System.Drawing.Point(321, 1);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 2;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			// 
			// propModel
			// 
			this.propModel.HeaderText = "Prop Name";
			this.propModel.Name = "propModel";
			this.propModel.ReadOnly = true;
			this.propModel.Visible = false;
			// 
			// textureDictionary
			// 
			this.textureDictionary.FillWeight = 109.1371F;
			this.textureDictionary.HeaderText = "Texture Dict";
			this.textureDictionary.Name = "textureDictionary";
			this.textureDictionary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.textureDictionary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.textureDictionary.ToolTipText = "Leave this blank if you wish to use the prop name as the texture dictionary.";
			// 
			// lodDist
			// 
			this.lodDist.FillWeight = 109.1371F;
			this.lodDist.HeaderText = "LOD Distance";
			this.lodDist.Name = "lodDist";
			// 
			// flags
			// 
			this.flags.FillWeight = 109.1371F;
			this.flags.HeaderText = "Flags";
			this.flags.Items.AddRange(new object[] {
            "Dynamic",
            "Static"});
			this.flags.Name = "flags";
			// 
			// DragDropPresetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 68);
			this.Controls.Add(this.doneButton);
			this.Controls.Add(this.presetDataGrid);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DragDropPresetForm";
			this.Text = "Set Preset";
			((System.ComponentModel.ISupportInitialize)(this.presetDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.DataGridView presetDataGrid;
		public System.Windows.Forms.Button doneButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn propModel;
		private System.Windows.Forms.DataGridViewTextBoxColumn textureDictionary;
		private System.Windows.Forms.DataGridViewTextBoxColumn lodDist;
		private System.Windows.Forms.DataGridViewComboBoxColumn flags;
	}
}