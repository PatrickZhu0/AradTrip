using System;

namespace Protocol
{
	// Token: 0x02000C02 RID: 3074
	[Protocol]
	public class TeamCopyForceEndRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080AD RID: 32941 RVA: 0x0016BF1C File Offset: 0x0016A31C
		public uint GetMsgID()
		{
			return 1100071U;
		}

		// Token: 0x060080AE RID: 32942 RVA: 0x0016BF23 File Offset: 0x0016A323
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080AF RID: 32943 RVA: 0x0016BF2B File Offset: 0x0016A32B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080B0 RID: 32944 RVA: 0x0016BF34 File Offset: 0x0016A334
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060080B1 RID: 32945 RVA: 0x0016BF44 File Offset: 0x0016A344
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060080B2 RID: 32946 RVA: 0x0016BF54 File Offset: 0x0016A354
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060080B3 RID: 32947 RVA: 0x0016BF64 File Offset: 0x0016A364
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060080B4 RID: 32948 RVA: 0x0016BF74 File Offset: 0x0016A374
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D6C RID: 15724
		public const uint MsgID = 1100071U;

		// Token: 0x04003D6D RID: 15725
		public uint Sequence;

		// Token: 0x04003D6E RID: 15726
		public uint retCode;
	}
}
