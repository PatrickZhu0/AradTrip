using System;
using YIMEngine;

// Token: 0x02004ABB RID: 19131
public class FileMessage : IMMessage
{
	// Token: 0x0601BC46 RID: 113734 RVA: 0x008835C4 File Offset: 0x008819C4
	public FileMessage(string sender, string reciver, ChatType chatType, string extra, FileType fileType, bool isFromServer)
	{
		base.MessageType = MessageBodyType.File;
		base.SenderID = sender;
		base.ReciverID = reciver;
		base.ChatType = chatType;
		this.extraParam = extra;
		this.fileType = fileType;
		base.IsReceiveFromServer = isFromServer;
		if (isFromServer)
		{
			base.SendStatus = SendStatus.Sended;
		}
		else
		{
			base.SendStatus = SendStatus.NotStartSend;
		}
	}

	// Token: 0x1700257E RID: 9598
	// (get) Token: 0x0601BC47 RID: 113735 RVA: 0x00883625 File Offset: 0x00881A25
	public string ExtraParam
	{
		get
		{
			return this.extraParam;
		}
	}

	// Token: 0x1700257F RID: 9599
	// (get) Token: 0x0601BC48 RID: 113736 RVA: 0x0088362D File Offset: 0x00881A2D
	public FileType FileType
	{
		get
		{
			return this.fileType;
		}
	}

	// Token: 0x17002580 RID: 9600
	// (get) Token: 0x0601BC4A RID: 113738 RVA: 0x0088363E File Offset: 0x00881A3E
	// (set) Token: 0x0601BC49 RID: 113737 RVA: 0x00883635 File Offset: 0x00881A35
	public string FileName
	{
		get
		{
			return this.fileName;
		}
		set
		{
			this.fileName = value;
		}
	}

	// Token: 0x17002581 RID: 9601
	// (get) Token: 0x0601BC4C RID: 113740 RVA: 0x0088364F File Offset: 0x00881A4F
	// (set) Token: 0x0601BC4B RID: 113739 RVA: 0x00883646 File Offset: 0x00881A46
	public int FileSize
	{
		get
		{
			return this.fileSize;
		}
		set
		{
			this.fileSize = value;
		}
	}

	// Token: 0x17002582 RID: 9602
	// (get) Token: 0x0601BC4E RID: 113742 RVA: 0x00883660 File Offset: 0x00881A60
	// (set) Token: 0x0601BC4D RID: 113741 RVA: 0x00883657 File Offset: 0x00881A57
	public string Extension
	{
		get
		{
			return this.strExtension;
		}
		set
		{
			this.strExtension = value;
		}
	}

	// Token: 0x040135BA RID: 79290
	private FileType fileType;

	// Token: 0x040135BB RID: 79291
	private string fileName;

	// Token: 0x040135BC RID: 79292
	private int fileSize;

	// Token: 0x040135BD RID: 79293
	private string extraParam;

	// Token: 0x040135BE RID: 79294
	private string strExtension;
}
