using System;

namespace Protocol
{
	// Token: 0x020006C7 RID: 1735
	[Protocol]
	public class WorldAuctionQueryItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058AE RID: 22702 RVA: 0x0010E368 File Offset: 0x0010C768
		public uint GetMsgID()
		{
			return 603916U;
		}

		// Token: 0x060058AF RID: 22703 RVA: 0x0010E36F File Offset: 0x0010C76F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058B0 RID: 22704 RVA: 0x0010E377 File Offset: 0x0010C777
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058B1 RID: 22705 RVA: 0x0010E380 File Offset: 0x0010C780
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060058B2 RID: 22706 RVA: 0x0010E390 File Offset: 0x0010C790
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060058B3 RID: 22707 RVA: 0x0010E3A0 File Offset: 0x0010C7A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060058B4 RID: 22708 RVA: 0x0010E3B0 File Offset: 0x0010C7B0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060058B5 RID: 22709 RVA: 0x0010E3C0 File Offset: 0x0010C7C0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400239B RID: 9115
		public const uint MsgID = 603916U;

		// Token: 0x0400239C RID: 9116
		public uint Sequence;

		// Token: 0x0400239D RID: 9117
		public ulong id;
	}
}
