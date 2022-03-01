using System;
using YIMEngine;

// Token: 0x02004AB9 RID: 19129
public class GiftMessage : IMMessage
{
	// Token: 0x0601BC3F RID: 113727 RVA: 0x008834D8 File Offset: 0x008818D8
	public GiftMessage(string sender, string reciver, int giftID, int giftCount, ExtraGifParam param, bool isFromServer)
	{
		base.MessageType = MessageBodyType.Gift;
		base.SenderID = sender;
		base.ReciverID = reciver;
		base.ChatType = ChatType.RoomChat;
		this.iGiftCount = giftCount;
		this.iGiftID = giftID;
		this.strParam = param;
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

	// Token: 0x17002579 RID: 9593
	// (get) Token: 0x0601BC40 RID: 113728 RVA: 0x00883540 File Offset: 0x00881940
	public int GiftCount
	{
		get
		{
			return this.iGiftCount;
		}
	}

	// Token: 0x1700257A RID: 9594
	// (get) Token: 0x0601BC41 RID: 113729 RVA: 0x00883548 File Offset: 0x00881948
	public int GiftID
	{
		get
		{
			return this.iGiftID;
		}
	}

	// Token: 0x1700257B RID: 9595
	// (get) Token: 0x0601BC42 RID: 113730 RVA: 0x00883550 File Offset: 0x00881950
	public ExtraGifParam ExtraParam
	{
		get
		{
			return this.strParam;
		}
	}

	// Token: 0x1700257C RID: 9596
	// (get) Token: 0x0601BC43 RID: 113731 RVA: 0x00883558 File Offset: 0x00881958
	public string AnchorID
	{
		get
		{
			return base.ReciverID;
		}
	}

	// Token: 0x040135B6 RID: 79286
	private int iGiftCount;

	// Token: 0x040135B7 RID: 79287
	private int iGiftID;

	// Token: 0x040135B8 RID: 79288
	private ExtraGifParam strParam;
}
