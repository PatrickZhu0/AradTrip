using System;

// Token: 0x02000DE5 RID: 3557
public class UIControlAttribute : Attribute
{
	// Token: 0x06008F56 RID: 36694 RVA: 0x001A8943 File Offset: 0x001A6D43
	public UIControlAttribute(string controlName, Type componentType = null, int baseNum = 0)
	{
		this.controlName = controlName;
		this.componentType = componentType;
		this.baseNum = baseNum;
	}

	// Token: 0x0400471F RID: 18207
	public string controlName;

	// Token: 0x04004720 RID: 18208
	public Type componentType;

	// Token: 0x04004721 RID: 18209
	public int baseNum;
}
