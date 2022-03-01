using System;

namespace Protocol
{
	// Token: 0x020006C6 RID: 1734
	[Protocol]
	public class WorldAuctionNotifyRefresh : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058A5 RID: 22693 RVA: 0x0010E27C File Offset: 0x0010C67C
		public uint GetMsgID()
		{
			return 603911U;
		}

		// Token: 0x060058A6 RID: 22694 RVA: 0x0010E283 File Offset: 0x0010C683
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x0010E28B File Offset: 0x0010C68B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058A8 RID: 22696 RVA: 0x0010E294 File Offset: 0x0010C694
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctGuid);
		}

		// Token: 0x060058A9 RID: 22697 RVA: 0x0010E2C0 File Offset: 0x0010C6C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctGuid);
		}

		// Token: 0x060058AA RID: 22698 RVA: 0x0010E2EC File Offset: 0x0010C6EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.auctGuid);
		}

		// Token: 0x060058AB RID: 22699 RVA: 0x0010E318 File Offset: 0x0010C718
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auctGuid);
		}

		// Token: 0x060058AC RID: 22700 RVA: 0x0010E344 File Offset: 0x0010C744
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			return num + 8;
		}

		// Token: 0x04002396 RID: 9110
		public const uint MsgID = 603911U;

		// Token: 0x04002397 RID: 9111
		public uint Sequence;

		// Token: 0x04002398 RID: 9112
		public byte type;

		// Token: 0x04002399 RID: 9113
		public byte reason;

		// Token: 0x0400239A RID: 9114
		public ulong auctGuid;
	}
}
