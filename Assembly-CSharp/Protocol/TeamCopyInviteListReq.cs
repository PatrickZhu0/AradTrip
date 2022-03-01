using System;

namespace Protocol
{
	// Token: 0x02000BEE RID: 3054
	[Protocol]
	public class TeamCopyInviteListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FFC RID: 32764 RVA: 0x0016A7F0 File Offset: 0x00168BF0
		public uint GetMsgID()
		{
			return 1100052U;
		}

		// Token: 0x06007FFD RID: 32765 RVA: 0x0016A7F7 File Offset: 0x00168BF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FFE RID: 32766 RVA: 0x0016A7FF File Offset: 0x00168BFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FFF RID: 32767 RVA: 0x0016A808 File Offset: 0x00168C08
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008000 RID: 32768 RVA: 0x0016A80A File Offset: 0x00168C0A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008001 RID: 32769 RVA: 0x0016A80C File Offset: 0x00168C0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008002 RID: 32770 RVA: 0x0016A80E File Offset: 0x00168C0E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008003 RID: 32771 RVA: 0x0016A810 File Offset: 0x00168C10
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003D13 RID: 15635
		public const uint MsgID = 1100052U;

		// Token: 0x04003D14 RID: 15636
		public uint Sequence;
	}
}
