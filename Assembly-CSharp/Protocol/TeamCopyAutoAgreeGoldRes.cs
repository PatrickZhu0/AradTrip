using System;

namespace Protocol
{
	// Token: 0x02000BED RID: 3053
	[Protocol]
	public class TeamCopyAutoAgreeGoldRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FF3 RID: 32755 RVA: 0x0016A740 File Offset: 0x00168B40
		public uint GetMsgID()
		{
			return 1100051U;
		}

		// Token: 0x06007FF4 RID: 32756 RVA: 0x0016A747 File Offset: 0x00168B47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FF5 RID: 32757 RVA: 0x0016A74F File Offset: 0x00168B4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FF6 RID: 32758 RVA: 0x0016A758 File Offset: 0x00168B58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAutoAgree);
		}

		// Token: 0x06007FF7 RID: 32759 RVA: 0x0016A776 File Offset: 0x00168B76
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAutoAgree);
		}

		// Token: 0x06007FF8 RID: 32760 RVA: 0x0016A794 File Offset: 0x00168B94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAutoAgree);
		}

		// Token: 0x06007FF9 RID: 32761 RVA: 0x0016A7B2 File Offset: 0x00168BB2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAutoAgree);
		}

		// Token: 0x06007FFA RID: 32762 RVA: 0x0016A7D0 File Offset: 0x00168BD0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D0F RID: 15631
		public const uint MsgID = 1100051U;

		// Token: 0x04003D10 RID: 15632
		public uint Sequence;

		// Token: 0x04003D11 RID: 15633
		public uint retCode;

		// Token: 0x04003D12 RID: 15634
		public uint isAutoAgree;
	}
}
