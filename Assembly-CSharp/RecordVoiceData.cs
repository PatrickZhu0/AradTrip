using System;

// Token: 0x02001554 RID: 5460
public class RecordVoiceData : MessageData
{
	// Token: 0x0600D55A RID: 54618 RVA: 0x00355512 File Offset: 0x00353912
	public RecordVoiceData(string filePath = "", int duration = 0, string fileUrl = "")
	{
		this.FilePath = filePath;
		this.Duration = duration;
		this.FileUrl = fileUrl;
	}

	// Token: 0x17001C05 RID: 7173
	// (get) Token: 0x0600D55B RID: 54619 RVA: 0x0035552F File Offset: 0x0035392F
	// (set) Token: 0x0600D55C RID: 54620 RVA: 0x00355537 File Offset: 0x00353937
	public string FilePath { get; private set; }

	// Token: 0x17001C06 RID: 7174
	// (get) Token: 0x0600D55D RID: 54621 RVA: 0x00355540 File Offset: 0x00353940
	// (set) Token: 0x0600D55E RID: 54622 RVA: 0x00355548 File Offset: 0x00353948
	public string FileUrl { get; private set; }

	// Token: 0x17001C07 RID: 7175
	// (get) Token: 0x0600D55F RID: 54623 RVA: 0x00355551 File Offset: 0x00353951
	// (set) Token: 0x0600D560 RID: 54624 RVA: 0x00355559 File Offset: 0x00353959
	public int Duration { get; private set; }
}
