using System;
using YIMEngine;

// Token: 0x02004ABA RID: 19130
public class CustomMessage : IMMessage
{
	// Token: 0x0601BC44 RID: 113732 RVA: 0x00883560 File Offset: 0x00881960
	public CustomMessage(string sender, string reciver, ChatType chatType, byte[] content, bool isFromServer)
	{
		base.MessageType = MessageBodyType.CustomMesssage;
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

	// Token: 0x1700257D RID: 9597
	// (get) Token: 0x0601BC45 RID: 113733 RVA: 0x008835B9 File Offset: 0x008819B9
	public byte[] Content
	{
		get
		{
			return this.content;
		}
	}

	// Token: 0x040135B9 RID: 79289
	private byte[] content;
}
