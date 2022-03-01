using System;

namespace Protocol
{
	// Token: 0x02000ADB RID: 2779
	[Protocol]
	public class WorldRoomListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077FE RID: 30718 RVA: 0x0015B837 File Offset: 0x00159C37
		public uint GetMsgID()
		{
			return 607812U;
		}

		// Token: 0x060077FF RID: 30719 RVA: 0x0015B83E File Offset: 0x00159C3E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007800 RID: 30720 RVA: 0x0015B846 File Offset: 0x00159C46
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007801 RID: 30721 RVA: 0x0015B84F File Offset: 0x00159C4F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.roomList.encode(buffer, ref pos_);
		}

		// Token: 0x06007802 RID: 30722 RVA: 0x0015B86C File Offset: 0x00159C6C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.roomList.decode(buffer, ref pos_);
		}

		// Token: 0x06007803 RID: 30723 RVA: 0x0015B889 File Offset: 0x00159C89
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.roomList.encode(buffer, ref pos_);
		}

		// Token: 0x06007804 RID: 30724 RVA: 0x0015B8A6 File Offset: 0x00159CA6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.roomList.decode(buffer, ref pos_);
		}

		// Token: 0x06007805 RID: 30725 RVA: 0x0015B8C4 File Offset: 0x00159CC4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.roomList.getLen();
		}

		// Token: 0x040038A6 RID: 14502
		public const uint MsgID = 607812U;

		// Token: 0x040038A7 RID: 14503
		public uint Sequence;

		// Token: 0x040038A8 RID: 14504
		public uint result;

		// Token: 0x040038A9 RID: 14505
		public RoomListInfo roomList = new RoomListInfo();
	}
}
