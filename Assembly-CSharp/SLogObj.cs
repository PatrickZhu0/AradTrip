using System;
using System.Collections.Generic;

// Token: 0x0200022E RID: 558
public class SLogObj
{
	// Token: 0x0600129D RID: 4765 RVA: 0x00063F49 File Offset: 0x00062349
	public void Close()
	{
	}

	// Token: 0x0600129E RID: 4766 RVA: 0x00063F4B File Offset: 0x0006234B
	public void Flush()
	{
	}

	// Token: 0x0600129F RID: 4767 RVA: 0x00063F4D File Offset: 0x0006234D
	public void Log(string str)
	{
	}

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x060012A0 RID: 4768 RVA: 0x00063F4F File Offset: 0x0006234F
	// (set) Token: 0x060012A1 RID: 4769 RVA: 0x00063F57 File Offset: 0x00062357
	public string TargetPath
	{
		get
		{
			return this.targetPath;
		}
		set
		{
			this.targetPath = value;
			this.filePath = null;
		}
	}

	// Token: 0x04000C56 RID: 3158
	private string filePath;

	// Token: 0x04000C57 RID: 3159
	private List<string> sLogTxt = new List<string>();

	// Token: 0x04000C58 RID: 3160
	private string targetPath;
}
