using System.Collections.Generic;
using System.Xml.Serialization;

namespace CustomPropsHelperApp.Models
{
	// Using 'object' for values that are unknown.

	// I think there's a better way to make xml attributes using XmlArray or XmlArrayItem
	// but I'm not familiar with that so I'm using my own structure for it instead.

	public class CMapTypes
	{
		public object extensions = new object();
		public List<Item> archetypes = new List<Item>();
		public string name = string.Empty;
		public object dependencies = new object();
		public object compositeEntityTypes = new object();

		public class Item
		{
			[XmlAttribute("type")]
			public string type = "CBaseArchetypeDef";
			public XmlVal<double> lodDist = new XmlVal<double> {value=100.0};
			public XmlVal<int> flags = new XmlVal<int> {value = 12713984};
			public XmlVal<int> specialAttribute = new XmlVal<int> {value = 0};
			public XmlV3 bbMin = new XmlV3 { x = 0, y = 0, z = 0 };
			public XmlV3 bbMax = new XmlV3 { x = 0, y = 0, z = 0 };
			public XmlV3 bsCentre = new XmlV3 { x = 0, y = 0, z = 0 };
			public XmlVal<double> bsRadius = new XmlVal<double> {value = 0};
			public XmlVal<double> hdTextureDist = new XmlVal<double> {value = 100};
			public string name = string.Empty;
			public string textureDictionary = string.Empty;
			public string clipDictionary = string.Empty;
			public string drawableDictionary = string.Empty;
			public string physicsDictionary = string.Empty;
			public string assetType = "ASSET_TYPE_DRAWABLE";
			public string assetName = string.Empty;
			public object extensions = new object();
		}
	}

	public struct XmlVal<T>
	{
		[XmlAttribute("value")]
		public T value;
	}

	public struct XmlV3
	{
		[XmlAttribute("x")]
		public double x;
		[XmlAttribute("y")]
		public double y;
		[XmlAttribute("z")]
		public double z;
	}
}
