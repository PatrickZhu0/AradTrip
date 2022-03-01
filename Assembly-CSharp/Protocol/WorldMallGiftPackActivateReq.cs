using System;

namespace Protocol
{
	// Token: 0x0200090B RID: 2315
	[Protocol]
	public class WorldMallGiftPackActivateReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069D3 RID: 27091 RVA: 0x00137630 File Offset: 0x00135A30
		public uint GetMsgID()
		{
			return 602814U;
		}

		// Token: 0x060069D4 RID: 27092 RVA: 0x00137637 File Offset: 0x00135A37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069D5 RID: 27093 RVA: 0x0013763F File Offset: 0x00135A3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069D6 RID: 27094 RVA: 0x00137648 File Offset: 0x00135A48
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.giftPackActCond);
		}

		// Token: 0x060069D7 RID: 27095 RVA: 0x00137658 File Offset: 0x00135A58
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.giftPackActCond);
		}

		// Token: 0x060069D8 RID: 27096 RVA: 0x00137668 File Offset: 0x00135A68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.giftPackActCond);
		}

		// Token: 0x060069D9 RID: 27097 RVA: 0x00137678 File Offset: 0x00135A78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.giftPackActCond);
		}

		// Token: 0x060069DA RID: 27098 RVA: 0x00137688 File Offset: 0x00135A88
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002FFB RID: 12283
		public const uint MsgID = 602814U;

		// Token: 0x04002FFC RID: 12284
		public uint Sequence;

		// Token: 0x04002FFD RID: 12285
		public byte giftPackActCond;
	}
}
