using System;

// Token: 0x02001556 RID: 5462
public class RichMsgData : MessageData
{
	// Token: 0x0600D564 RID: 54628 RVA: 0x00355582 File Offset: 0x00353982
	public RichMsgData(string msg = "", string filePath = "", int duration = 0, string fileUrl = "")
	{
		this.MsgString = msg;
		this.FilePath = filePath;
		this.Duration = duration;
		this.FileUrl = fileUrl;
	}

	// Token: 0x17001C09 RID: 7177
	// (get) Token: 0x0600D565 RID: 54629 RVA: 0x003555A7 File Offset: 0x003539A7
	// (set) Token: 0x0600D566 RID: 54630 RVA: 0x003555AF File Offset: 0x003539AF
	public string MsgString { get; private set; }

	// Token: 0x17001C0A RID: 7178
	// (get) Token: 0x0600D567 RID: 54631 RVA: 0x003555B8 File Offset: 0x003539B8
	// (set) Token: 0x0600D568 RID: 54632 RVA: 0x003555C0 File Offset: 0x003539C0
	public string FilePath { get; private set; }

	// Token: 0x17001C0B RID: 7179
	// (get) Token: 0x0600D569 RID: 54633 RVA: 0x003555C9 File Offset: 0x003539C9
	// (set) Token: 0x0600D56A RID: 54634 RVA: 0x003555D1 File Offset: 0x003539D1
	public string FileUrl { get; private set; }

	// Token: 0x17001C0C RID: 7180
	// (get) Token: 0x0600D56B RID: 54635 RVA: 0x003555DA File Offset: 0x003539DA
	// (set) Token: 0x0600D56C RID: 54636 RVA: 0x003555E2 File Offset: 0x003539E2
	public int Duration { get; private set; }
}
