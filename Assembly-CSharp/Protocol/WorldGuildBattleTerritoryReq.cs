using System;

namespace Protocol
{
	// Token: 0x0200085C RID: 2140
	[Protocol]
	public class WorldGuildBattleTerritoryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064AE RID: 25774 RVA: 0x0012C08A File Offset: 0x0012A48A
		public uint GetMsgID()
		{
			return 601951U;
		}

		// Token: 0x060064AF RID: 25775 RVA: 0x0012C091 File Offset: 0x0012A491
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064B0 RID: 25776 RVA: 0x0012C099 File Offset: 0x0012A499
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064B1 RID: 25777 RVA: 0x0012C0A2 File Offset: 0x0012A4A2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
		}

		// Token: 0x060064B2 RID: 25778 RVA: 0x0012C0B2 File Offset: 0x0012A4B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
		}

		// Token: 0x060064B3 RID: 25779 RVA: 0x0012C0C2 File Offset: 0x0012A4C2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
		}

		// Token: 0x060064B4 RID: 25780 RVA: 0x0012C0D2 File Offset: 0x0012A4D2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
		}

		// Token: 0x060064B5 RID: 25781 RVA: 0x0012C0E4 File Offset: 0x0012A4E4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002D19 RID: 11545
		public const uint MsgID = 601951U;

		// Token: 0x04002D1A RID: 11546
		public uint Sequence;

		// Token: 0x04002D1B RID: 11547
		public byte terrId;
	}
}
