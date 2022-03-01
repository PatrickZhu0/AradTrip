using System;

// Token: 0x02000DE6 RID: 3558
public class UIControlArrayAttribute : Attribute
{
	// Token: 0x06008F57 RID: 36695 RVA: 0x001A8960 File Offset: 0x001A6D60
	public UIControlArrayAttribute(string controlName, int baseNum = 0)
	{
		this.controlName = controlName;
		this.baseNum = baseNum;
	}

	// Token: 0x04004722 RID: 18210
	public string controlName;

	// Token: 0x04004723 RID: 18211
	public int baseNum;
}
