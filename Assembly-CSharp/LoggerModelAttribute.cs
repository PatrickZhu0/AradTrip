using System;

// Token: 0x0200014A RID: 330
public class LoggerModelAttribute : Attribute
{
	// Token: 0x06000982 RID: 2434 RVA: 0x00032168 File Offset: 0x00030568
	public LoggerModelAttribute(string name)
	{
		this.mName = name;
	}

	// Token: 0x04000736 RID: 1846
	public string mName;
}
