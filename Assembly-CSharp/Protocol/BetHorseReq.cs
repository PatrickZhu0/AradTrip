using System;

namespace Protocol
{
	// Token: 0x02000731 RID: 1841
	[Protocol]
	public class BetHorseReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C08 RID: 23560 RVA: 0x001161DC File Offset: 0x001145DC
		public uint GetMsgID()
		{
			return 708301U;
		}

		// Token: 0x06005C09 RID: 23561 RVA: 0x001161E3 File Offset: 0x001145E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C0A RID: 23562 RVA: 0x001161EB File Offset: 0x001145EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C0B RID: 23563 RVA: 0x001161F4 File Offset: 0x001145F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C0C RID: 23564 RVA: 0x001161F6 File Offset: 0x001145F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C0D RID: 23565 RVA: 0x001161F8 File Offset: 0x001145F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C0E RID: 23566 RVA: 0x001161FA File Offset: 0x001145FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C0F RID: 23567 RVA: 0x001161FC File Offset: 0x001145FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002592 RID: 9618
		public const uint MsgID = 708301U;

		// Token: 0x04002593 RID: 9619
		public uint Sequence;
	}
}
