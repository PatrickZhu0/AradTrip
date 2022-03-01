using System;

namespace Protocol
{
	// Token: 0x020009A0 RID: 2464
	[Protocol]
	public class WorldGetItemFriendPresentInfosReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EEF RID: 28399 RVA: 0x00140D34 File Offset: 0x0013F134
		public uint GetMsgID()
		{
			return 609701U;
		}

		// Token: 0x06006EF0 RID: 28400 RVA: 0x00140D3B File Offset: 0x0013F13B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EF1 RID: 28401 RVA: 0x00140D43 File Offset: 0x0013F143
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EF2 RID: 28402 RVA: 0x00140D4C File Offset: 0x0013F14C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
		}

		// Token: 0x06006EF3 RID: 28403 RVA: 0x00140D5C File Offset: 0x0013F15C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
		}

		// Token: 0x06006EF4 RID: 28404 RVA: 0x00140D6C File Offset: 0x0013F16C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
		}

		// Token: 0x06006EF5 RID: 28405 RVA: 0x00140D7C File Offset: 0x0013F17C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
		}

		// Token: 0x06006EF6 RID: 28406 RVA: 0x00140D8C File Offset: 0x0013F18C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003252 RID: 12882
		public const uint MsgID = 609701U;

		// Token: 0x04003253 RID: 12883
		public uint Sequence;

		// Token: 0x04003254 RID: 12884
		public uint dataId;
	}
}
