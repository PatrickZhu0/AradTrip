using System;

namespace Protocol
{
	// Token: 0x02000A02 RID: 2562
	[Protocol]
	public class SceneWudaoRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071DA RID: 29146 RVA: 0x0014A9CC File Offset: 0x00148DCC
		public uint GetMsgID()
		{
			return 506708U;
		}

		// Token: 0x060071DB RID: 29147 RVA: 0x0014A9D3 File Offset: 0x00148DD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071DC RID: 29148 RVA: 0x0014A9DB File Offset: 0x00148DDB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071DD RID: 29149 RVA: 0x0014A9E4 File Offset: 0x00148DE4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071DE RID: 29150 RVA: 0x0014A9E6 File Offset: 0x00148DE6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071DF RID: 29151 RVA: 0x0014A9E8 File Offset: 0x00148DE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071E0 RID: 29152 RVA: 0x0014A9EA File Offset: 0x00148DEA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071E1 RID: 29153 RVA: 0x0014A9EC File Offset: 0x00148DEC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003459 RID: 13401
		public const uint MsgID = 506708U;

		// Token: 0x0400345A RID: 13402
		public uint Sequence;
	}
}
