using System;

// Token: 0x02004B74 RID: 19316
public class EnumMapIDAttribute : Attribute
{
	// Token: 0x0601C6AB RID: 116395 RVA: 0x0089E6E1 File Offset: 0x0089CAE1
	public EnumMapIDAttribute(int id)
	{
		this.id = id;
	}

	// Token: 0x040138B8 RID: 80056
	public int id;
}
