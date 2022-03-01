using System;

// Token: 0x02000DEC RID: 3564
public class UIPropertyAttribute : Attribute
{
	// Token: 0x06008F62 RID: 36706 RVA: 0x001A8A84 File Offset: 0x001A6E84
	public UIPropertyAttribute(string name, string formatString, bool bPostive = true)
	{
		this.name = name;
		this.formatString = formatString;
		this.bPostive = bPostive;
	}

	// Token: 0x04004730 RID: 18224
	public string name;

	// Token: 0x04004731 RID: 18225
	public string formatString;

	// Token: 0x04004732 RID: 18226
	public bool bPostive;
}
