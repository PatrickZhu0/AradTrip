using System;
using YIMEngine;

// Token: 0x02004AB8 RID: 19128
public class TextMessage : IMMessage
{
	// Token: 0x0601BC3D RID: 113725 RVA: 0x00883474 File Offset: 0x00881874
	public TextMessage(string sender, string reciver, ChatType chatType, string content, bool isFromServer)
	{
		base.MessageType = MessageBodyType.TXT;
		base.SenderID = sender;
		base.ReciverID = reciver;
		base.ChatType = chatType;
		this.content = content;
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

	// Token: 0x17002578 RID: 9592
	// (get) Token: 0x0601BC3E RID: 113726 RVA: 0x008834CD File Offset: 0x008818CD
	public string Content
	{
		get
		{
			return this.content;
		}
	}

	// Token: 0x040135B5 RID: 79285
	private string content;
}
