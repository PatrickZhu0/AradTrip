using System;
using YIMEngine;

// Token: 0x02004AB4 RID: 19124
public abstract class IMMessage
{
	// Token: 0x1700256A RID: 9578
	// (get) Token: 0x0601BC1D RID: 113693 RVA: 0x00883165 File Offset: 0x00881565
	// (set) Token: 0x0601BC1C RID: 113692 RVA: 0x0088315C File Offset: 0x0088155C
	public MessageBodyType MessageType
	{
		get
		{
			return this.messageType;
		}
		set
		{
			this.messageType = value;
		}
	}

	// Token: 0x1700256B RID: 9579
	// (get) Token: 0x0601BC1F RID: 113695 RVA: 0x00883176 File Offset: 0x00881576
	// (set) Token: 0x0601BC1E RID: 113694 RVA: 0x0088316D File Offset: 0x0088156D
	public string SenderID
	{
		get
		{
			return this.senderID;
		}
		set
		{
			this.senderID = value;
		}
	}

	// Token: 0x1700256C RID: 9580
	// (get) Token: 0x0601BC21 RID: 113697 RVA: 0x00883187 File Offset: 0x00881587
	// (set) Token: 0x0601BC20 RID: 113696 RVA: 0x0088317E File Offset: 0x0088157E
	public string ReciverID
	{
		get
		{
			return this.reciverID;
		}
		set
		{
			this.reciverID = value;
		}
	}

	// Token: 0x1700256D RID: 9581
	// (get) Token: 0x0601BC23 RID: 113699 RVA: 0x00883198 File Offset: 0x00881598
	// (set) Token: 0x0601BC22 RID: 113698 RVA: 0x0088318F File Offset: 0x0088158F
	public ChatType ChatType
	{
		get
		{
			return this.chatType;
		}
		set
		{
			this.chatType = value;
		}
	}

	// Token: 0x1700256E RID: 9582
	// (get) Token: 0x0601BC25 RID: 113701 RVA: 0x008831A9 File Offset: 0x008815A9
	// (set) Token: 0x0601BC24 RID: 113700 RVA: 0x008831A0 File Offset: 0x008815A0
	public bool IsReceiveFromServer
	{
		get
		{
			return this.isReceiveFromServer;
		}
		set
		{
			this.isReceiveFromServer = value;
		}
	}

	// Token: 0x1700256F RID: 9583
	// (get) Token: 0x0601BC27 RID: 113703 RVA: 0x008831BA File Offset: 0x008815BA
	// (set) Token: 0x0601BC26 RID: 113702 RVA: 0x008831B1 File Offset: 0x008815B1
	public SendStatus SendStatus
	{
		get
		{
			return this.sendStatus;
		}
		set
		{
			this.sendStatus = value;
		}
	}

	// Token: 0x17002570 RID: 9584
	// (get) Token: 0x0601BC29 RID: 113705 RVA: 0x008831CB File Offset: 0x008815CB
	// (set) Token: 0x0601BC28 RID: 113704 RVA: 0x008831C2 File Offset: 0x008815C2
	public uint SendTime
	{
		get
		{
			return this.sendTime;
		}
		set
		{
			this.sendTime = value;
		}
	}

	// Token: 0x17002571 RID: 9585
	// (get) Token: 0x0601BC2B RID: 113707 RVA: 0x008831DC File Offset: 0x008815DC
	// (set) Token: 0x0601BC2A RID: 113706 RVA: 0x008831D3 File Offset: 0x008815D3
	public ulong RequestID
	{
		get
		{
			return this.requestID;
		}
		set
		{
			this.requestID = value;
		}
	}

	// Token: 0x17002572 RID: 9586
	// (get) Token: 0x0601BC2D RID: 113709 RVA: 0x008831ED File Offset: 0x008815ED
	// (set) Token: 0x0601BC2C RID: 113708 RVA: 0x008831E4 File Offset: 0x008815E4
	public uint Distance
	{
		get
		{
			return this.distance;
		}
		set
		{
			this.distance = value;
		}
	}

	// Token: 0x0401359D RID: 79261
	private MessageBodyType messageType;

	// Token: 0x0401359E RID: 79262
	private string senderID;

	// Token: 0x0401359F RID: 79263
	private string reciverID;

	// Token: 0x040135A0 RID: 79264
	private ChatType chatType;

	// Token: 0x040135A1 RID: 79265
	private bool isReceiveFromServer;

	// Token: 0x040135A2 RID: 79266
	private SendStatus sendStatus;

	// Token: 0x040135A3 RID: 79267
	private uint sendTime;

	// Token: 0x040135A4 RID: 79268
	private ulong requestID;

	// Token: 0x040135A5 RID: 79269
	private uint distance;
}
