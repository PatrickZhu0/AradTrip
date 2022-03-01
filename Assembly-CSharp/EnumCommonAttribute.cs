using System;

// Token: 0x02000DEB RID: 3563
public class EnumCommonAttribute : Attribute
{
	// Token: 0x06008F60 RID: 36704 RVA: 0x001A8A40 File Offset: 0x001A6E40
	public EnumCommonAttribute(string content)
	{
		this.contents = content.Split(new char[]
		{
			'|'
		});
	}

	// Token: 0x06008F61 RID: 36705 RVA: 0x001A8A5F File Offset: 0x001A6E5F
	public string GetValueByIndex(int iIndex)
	{
		if (iIndex >= 0 && iIndex < this.contents.Length)
		{
			return this.contents[iIndex];
		}
		return string.Empty;
	}

	// Token: 0x0400472F RID: 18223
	public string[] contents;
}
