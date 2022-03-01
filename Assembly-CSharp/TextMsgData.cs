using System;

// Token: 0x02001555 RID: 5461
public class TextMsgData : MessageData
{
	// Token: 0x0600D561 RID: 54625 RVA: 0x00355562 File Offset: 0x00353962
	public TextMsgData(string msg = "")
	{
		this.MsgString = msg;
	}

	// Token: 0x17001C08 RID: 7176
	// (get) Token: 0x0600D562 RID: 54626 RVA: 0x00355571 File Offset: 0x00353971
	// (set) Token: 0x0600D563 RID: 54627 RVA: 0x00355579 File Offset: 0x00353979
	public string MsgString { get; private set; }
}
