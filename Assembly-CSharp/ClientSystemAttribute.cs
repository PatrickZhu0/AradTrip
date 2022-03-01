using System;

// Token: 0x02000DEA RID: 3562
public class ClientSystemAttribute : Attribute
{
	// Token: 0x06008F5F RID: 36703 RVA: 0x001A8A2A File Offset: 0x001A6E2A
	public ClientSystemAttribute(string name, string stage = "")
	{
		this.name = name;
		this.stage = stage;
	}

	// Token: 0x0400472D RID: 18221
	public string name;

	// Token: 0x0400472E RID: 18222
	public string stage;
}
