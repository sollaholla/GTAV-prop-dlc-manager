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
public class ChangeSetItem
{
	private string changeSetNameField = string.Empty;

	private string mapChangeSetDataField = string.Empty;

	private string filesToInvalidateField = string.Empty;

	private string filesToDisableField = string.Empty;

	private string txdToLoadField = string.Empty;

	private string txdToUnloadField = string.Empty;

	private string residentResourcesField = string.Empty;

	private string unregisterResourcesField = string.Empty;

	private ItemFilesToEnableDlc[] filesToEnableField = new ItemFilesToEnableDlc[] { };

	private ItemRequiresLoadingScreen[] requiresLoadingScreenField = new ItemRequiresLoadingScreen[] { };
	
	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=1, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string changeSetName {
		get {
			return this.changeSetNameField;
		}
		set {
			this.changeSetNameField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=2, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string mapChangeSetData {
		get {
			return this.mapChangeSetDataField;
		}
		set {
			this.mapChangeSetDataField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=3, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string filesToInvalidate {
		get {
			return this.filesToInvalidateField;
		}
		set {
			this.filesToInvalidateField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=4, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string filesToDisable {
		get {
			return this.filesToDisableField;
		}
		set {
			this.filesToDisableField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlArrayAttribute(Order = 5, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	[System.Xml.Serialization.XmlArrayItemAttribute("Item", typeof(ItemFilesToEnableDlc), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public ItemFilesToEnableDlc[] filesToEnable {
		get {
			return this.filesToEnableField;
		}
		set {
			this.filesToEnableField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=6, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string txdToLoad {
		get {
			return this.txdToLoadField;
		}
		set {
			this.txdToLoadField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=7, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string txdToUnload {
		get {
			return this.txdToUnloadField;
		}
		set {
			this.txdToUnloadField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=8, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string residentResources {
		get {
			return this.residentResourcesField;
		}
		set {
			this.residentResourcesField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order=9, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string unregisterResources {
		get {
			return this.unregisterResourcesField;
		}
		set {
			this.unregisterResourcesField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute("requiresLoadingScreen", Order = 10, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public ItemRequiresLoadingScreen[] requiresLoadingScreen {
		get {
			return this.requiresLoadingScreenField;
		}
		set {
			this.requiresLoadingScreenField = value;
		}
	}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Item {
    
    private string filenameField = string.Empty;
    
    private string fileTypeField = string.Empty;

    private ItemOverlay[] overlayField = new ItemOverlay[] {};

	private ItemDisabled[] disabledField = new ItemDisabled[] { };

	private ItemPersistent[] persistentField = new ItemPersistent[] { };
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string filename {
        get {
            return this.filenameField;
        }
        set {
            this.filenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fileType {
        get {
            return this.fileTypeField;
        }
        set {
            this.fileTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute( "overlay", Order = 3, Form =System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ItemOverlay[] overlay {
        get {
            return this.overlayField;
        }
        set {
            this.overlayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("disabled", Order = 4, Form =System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ItemDisabled[] disabled {
        get {
            return this.disabledField;
        }
        set {
            this.disabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("persistent", Order = 5, Form =System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ItemPersistent[] persistent {
        get {
            return this.persistentField;
        }
        set {
            this.persistentField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1586.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemOverlay {
    
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemDisabled {
    
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemPersistent {
    
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemFilesToEnableDlc {
    
    private string valueField = string.Empty;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ItemRequiresLoadingScreen {
    
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class CDataFileMgr__ContentsOfDataFileXml {
    
    private string disabledFilesField = string.Empty;
    
    private string includedXmlFilesField = string.Empty;
    
    private string includedDataFilesField = string.Empty;
    
    private string patchFilesField = string.Empty;
    
    private Item[] dataFilesField = new Item[] {};
    
    private ChangeSetItem[] contentChangeSetsField = new ChangeSetItem[] {};
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string disabledFiles {
        get {
            return this.disabledFilesField;
        }
        set {
            this.disabledFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string includedXmlFiles {
        get {
            return this.includedXmlFilesField;
        }
        set {
            this.includedXmlFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string includedDataFiles {
        get {
            return this.includedDataFilesField;
        }
        set {
            this.includedDataFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Order = 4, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Item", typeof(Item), IsNullable=false)]
    public Item[] dataFiles {
        get {
            return this.dataFilesField;
        }
        set {
            this.dataFilesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Order = 5, Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Item", typeof(ChangeSetItem), IsNullable=false)]
    public ChangeSetItem[] contentChangeSets {
        get {
            return this.contentChangeSetsField;
        }
        set {
            this.contentChangeSetsField = value;
        }
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlElementAttribute(Order = 6, Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
	public string patchFiles {
		get {
			return this.patchFilesField;
		}
		set {
			this.patchFilesField = value;
		}
	}
}
