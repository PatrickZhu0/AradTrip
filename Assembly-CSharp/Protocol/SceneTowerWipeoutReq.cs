using System;

namespace Protocol
{
	// Token: 0x020007D3 RID: 2003
	[Protocol]
	public class SceneTowerWipeoutReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060D6 RID: 24790 RVA: 0x001231C5 File Offset: 0x001215C5
		public uint GetMsgID()
		{
			return 507201U;
		}

		// Token: 0x060060D7 RID: 24791 RVA: 0x001231CC File Offset: 0x001215CC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060D8 RID: 24792 RVA: 0x001231D4 File Offset: 0x001215D4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060D9 RID: 24793 RVA: 0x001231DD File Offset: 0x001215DD
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060060DA RID: 24794 RVA: 0x001231DF File Offset: 0x001215DF
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060060DB RID: 24795 RVA: 0x001231E1 File Offset: 0x001215E1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060060DC RID: 24796 RVA: 0x001231E3 File Offset: 0x001215E3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060060DD RID: 24797 RVA: 0x001231E8 File Offset: 0x001215E8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002865 RID: 10341
		public const uint MsgID = 507201U;

		// Token: 0x04002866 RID: 10342
		public uint Sequence;
	}
}
