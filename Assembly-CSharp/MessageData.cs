using System;

// Token: 0x02001553 RID: 5459
public class MessageData
{
	// Token: 0x17001C01 RID: 7169
	// (get) Token: 0x0600D552 RID: 54610 RVA: 0x003554CE File Offset: 0x003538CE
	// (set) Token: 0x0600D553 RID: 54611 RVA: 0x003554D6 File Offset: 0x003538D6
	public uint YunvaId { get; set; }

	// Token: 0x17001C02 RID: 7170
	// (get) Token: 0x0600D554 RID: 54612 RVA: 0x003554DF File Offset: 0x003538DF
	// (set) Token: 0x0600D555 RID: 54613 RVA: 0x003554E7 File Offset: 0x003538E7
	public string ChatRoomId { get; set; }

	// Token: 0x17001C03 RID: 7171
	// (get) Token: 0x0600D556 RID: 54614 RVA: 0x003554F0 File Offset: 0x003538F0
	// (set) Token: 0x0600D557 RID: 54615 RVA: 0x003554F8 File Offset: 0x003538F8
	public ulong time { get; set; }

	// Token: 0x17001C04 RID: 7172
	// (get) Token: 0x0600D558 RID: 54616 RVA: 0x00355501 File Offset: 0x00353901
	// (set) Token: 0x0600D559 RID: 54617 RVA: 0x00355509 File Offset: 0x00353909
	public string ExpandString { get; set; }
}
