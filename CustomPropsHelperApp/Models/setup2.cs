﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1586.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class SSetupData
{

	private string deviceNameField = string.Empty;

	private string datFileField = string.Empty;

	private string timeStampField = string.Empty;

	private string nameHashField = string.Empty;

	private string contentChangeSetsField = string.Empty;

	private string startupScriptField = string.Empty;

	private string typeField = string.Empty;

	private string dependencyPackHashField = string.Empty;

	private string requiredVersionField = string.Empty;

	private SSetupDataContentChangeSetGroupsItem[] contentChangeSetGroupsField = new SSetupDataContentChangeSetGroupsItem[] { };

	private SSetupDataScriptCallstackSize[] scriptCallstackSizeField = new SSetupDataScriptCallstackSize[] { };

	private SSetupDataOrder[] orderField = new SSetupDataOrder[] { };

	private SSetupDataMinorOrder[] minorOrderField = new SSetupDataMinorOrder[] { };

	private SSetupDataIsLevelPack[] isLevelPackField = new SSetupDataIsLevelPack[] { };

	private SSetupDataSubPackCount[] subPackCountField = new SSetupDataSubPackCount[] { };

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 1, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string deviceName {
		get {
			return this.deviceNameField;
		}
		set {
			this.deviceNameField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 2, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string datFile {
		get {
			return this.datFileField;
		}
		set {
			this.datFileField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 3, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string timeStamp {
		get {
			return this.timeStampField;
		}
		set {
			this.timeStampField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 4, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string nameHash {
		get {
			return this.nameHashField;
		}
		set {
			this.nameHashField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 5, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string contentChangeSets {
		get {
			return this.contentChangeSetsField;
		}
		set {
			this.contentChangeSetsField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlArrayAttribute(Order = 6, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	[System.Xml.Serialization.XmlArrayItemAttribute("Item", typeof(SSetupDataContentChangeSetGroupsItem), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
	public SSetupDataContentChangeSetGroupsItem[] contentChangeSetGroups {
		get {
			return this.contentChangeSetGroupsField;
		}
		set {
			this.contentChangeSetGroupsField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 7, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string startupScript {
		get {
			return this.startupScriptField;
		}
		set {
			this.startupScriptField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("scriptCallstackSize", Order = 8, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataScriptCallstackSize[] scriptCallstackSize {
		get {
			return this.scriptCallstackSizeField;
		}
		set {
			this.scriptCallstackSizeField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 9, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string type {
		get {
			return this.typeField;
		}
		set {
			this.typeField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("order", Order = 10, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataOrder[] order {
		get {
			return this.orderField;
		}
		set {
			this.orderField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("minorOrder", Order = 11, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataMinorOrder[] minorOrder {
		get {
			return this.minorOrderField;
		}
		set {
			this.minorOrderField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("isLevelPack", Order = 12, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataIsLevelPack[] isLevelPack {
		get {
			return this.isLevelPackField;
		}
		set {
			this.isLevelPackField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 13, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string dependencyPackHash {
		get {
			return this.dependencyPackHashField;
		}
		set {
			this.dependencyPackHashField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 14, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string requiredVersion {
		get {
			return this.requiredVersionField;
		}
		set {
			this.requiredVersionField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("subPackCount", Order = 15, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataSubPackCount[] subPackCount {
		get {
			return this.subPackCountField;
		}
		set {
			this.subPackCountField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataContentChangeSetGroupsItem
{

	private string nameHashField = string.Empty;

	private SSetupDataContentChangeSetGroupsItemContentChangeSets[] contentChangeSetsField = new SSetupDataContentChangeSetGroupsItemContentChangeSets[] { };

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 1, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string NameHash {
		get {
			return this.nameHashField;
		}
		set {
			this.nameHashField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("ContentChangeSets", Order = 2, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public SSetupDataContentChangeSetGroupsItemContentChangeSets[] ContentChangeSets {
		get {
			return this.contentChangeSetsField;
		}
		set {
			this.contentChangeSetsField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataContentChangeSetGroupsItemContentChangeSets
{

	private string itemField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 1, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string Item {
		get {
			return this.itemField;
		}
		set {
			this.itemField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataScriptCallstackSize
{

	private string valueField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string value {
		get {
			return this.valueField;
		}
		set {
			this.valueField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataOrder
{

	private string valueField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string value {
		get {
			return this.valueField;
		}
		set {
			this.valueField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataMinorOrder
{

	private string valueField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string value {
		get {
			return this.valueField;
		}
		set {
			this.valueField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataIsLevelPack
{

	private string valueField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string value {
		get {
			return this.valueField;
		}
		set {
			this.valueField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class SSetupDataSubPackCount
{

	private string valueField = string.Empty;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string value {
		get {
			return this.valueField;
		}
		set {
			this.valueField = value;
		}
	}
}

