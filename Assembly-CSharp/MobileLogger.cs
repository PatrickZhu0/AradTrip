using System;

// Token: 0x0200022B RID: 555
public class MobileLogger
{
	// Token: 0x06001292 RID: 4754 RVA: 0x00063EC6 File Offset: 0x000622C6
	public void AddMessage(string InMessage)
	{
		this.Message = InMessage;
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x00063ECF File Offset: 0x000622CF
	public void Clear()
	{
		this.Message = string.Empty;
	}

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06001294 RID: 4756 RVA: 0x00063EDC File Offset: 0x000622DC
	public string message
	{
		get
		{
			return this.Message;
		}
	}

	// Token: 0x04000C4E RID: 3150
	private string Message = string.Empty;
}
