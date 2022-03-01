using System;

namespace Protocol
{
	// Token: 0x020009CD RID: 2509
	[Protocol]
	public class GateNotifyAllowLogin : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600705D RID: 28765 RVA: 0x001453D8 File Offset: 0x001437D8
		public uint GetMsgID()
		{
			return 300317U;
		}

		// Token: 0x0600705E RID: 28766 RVA: 0x001453DF File Offset: 0x001437DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600705F RID: 28767 RVA: 0x001453E7 File Offset: 0x001437E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007060 RID: 28768 RVA: 0x001453F0 File Offset: 0x001437F0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007061 RID: 28769 RVA: 0x001453F2 File Offset: 0x001437F2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007062 RID: 28770 RVA: 0x001453F4 File Offset: 0x001437F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007063 RID: 28771 RVA: 0x001453F6 File Offset: 0x001437F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007064 RID: 28772 RVA: 0x001453F8 File Offset: 0x001437F8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003334 RID: 13108
		public const uint MsgID = 300317U;

		// Token: 0x04003335 RID: 13109
		public uint Sequence;
	}
}
