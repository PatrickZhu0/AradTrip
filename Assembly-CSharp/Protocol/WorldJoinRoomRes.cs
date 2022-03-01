using System;

namespace Protocol
{
	// Token: 0x02000ADF RID: 2783
	[Protocol]
	public class WorldJoinRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007822 RID: 30754 RVA: 0x0015BF2F File Offset: 0x0015A32F
		public uint GetMsgID()
		{
			return 607816U;
		}

		// Token: 0x06007823 RID: 30755 RVA: 0x0015BF36 File Offset: 0x0015A336
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007824 RID: 30756 RVA: 0x0015BF3E File Offset: 0x0015A33E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007825 RID: 30757 RVA: 0x0015BF47 File Offset: 0x0015A347
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007826 RID: 30758 RVA: 0x0015BF64 File Offset: 0x0015A364
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007827 RID: 30759 RVA: 0x0015BF81 File Offset: 0x0015A381
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007828 RID: 30760 RVA: 0x0015BF9E File Offset: 0x0015A39E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007829 RID: 30761 RVA: 0x0015BFBC File Offset: 0x0015A3BC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x040038BE RID: 14526
		public const uint MsgID = 607816U;

		// Token: 0x040038BF RID: 14527
		public uint Sequence;

		// Token: 0x040038C0 RID: 14528
		public uint result;

		// Token: 0x040038C1 RID: 14529
		public RoomInfo info = new RoomInfo();
	}
}
