using System;

namespace Protocol
{
	// Token: 0x02000AE7 RID: 2791
	[Protocol]
	public class WorldChangeRoomOwnerRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600786A RID: 30826 RVA: 0x0015C2D8 File Offset: 0x0015A6D8
		public uint GetMsgID()
		{
			return 607826U;
		}

		// Token: 0x0600786B RID: 30827 RVA: 0x0015C2DF File Offset: 0x0015A6DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600786C RID: 30828 RVA: 0x0015C2E7 File Offset: 0x0015A6E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600786D RID: 30829 RVA: 0x0015C2F0 File Offset: 0x0015A6F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600786E RID: 30830 RVA: 0x0015C300 File Offset: 0x0015A700
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600786F RID: 30831 RVA: 0x0015C310 File Offset: 0x0015A710
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007870 RID: 30832 RVA: 0x0015C320 File Offset: 0x0015A720
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007871 RID: 30833 RVA: 0x0015C330 File Offset: 0x0015A730
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038D6 RID: 14550
		public const uint MsgID = 607826U;

		// Token: 0x040038D7 RID: 14551
		public uint Sequence;

		// Token: 0x040038D8 RID: 14552
		public uint result;
	}
}
