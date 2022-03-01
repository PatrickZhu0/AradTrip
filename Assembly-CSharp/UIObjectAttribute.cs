using System;

// Token: 0x02000DE4 RID: 3556
public class UIObjectAttribute : Attribute
{
	// Token: 0x06008F55 RID: 36693 RVA: 0x001A8934 File Offset: 0x001A6D34
	public UIObjectAttribute(string objectName)
	{
		this.objectName = objectName;
	}

	// Token: 0x0400471E RID: 18206
	public string objectName;
}
