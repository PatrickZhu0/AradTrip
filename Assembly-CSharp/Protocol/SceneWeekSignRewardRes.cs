using System;

namespace Protocol
{
	// Token: 0x02000A44 RID: 2628
	[Protocol]
	public class SceneWeekSignRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073C6 RID: 29638 RVA: 0x0014FE94 File Offset: 0x0014E294
		public uint GetMsgID()
		{
			return 507409U;
		}

		// Token: 0x060073C7 RID: 29639 RVA: 0x0014FE9B File Offset: 0x0014E29B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073C8 RID: 29640 RVA: 0x0014FEA3 File Offset: 0x0014E2A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073C9 RID: 29641 RVA: 0x0014FEAC File Offset: 0x0014E2AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060073CA RID: 29642 RVA: 0x0014FEBC File Offset: 0x0014E2BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060073CB RID: 29643 RVA: 0x0014FECC File Offset: 0x0014E2CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060073CC RID: 29644 RVA: 0x0014FEDC File Offset: 0x0014E2DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060073CD RID: 29645 RVA: 0x0014FEEC File Offset: 0x0014E2EC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040035BA RID: 13754
		public const uint MsgID = 507409U;

		// Token: 0x040035BB RID: 13755
		public uint Sequence;

		// Token: 0x040035BC RID: 13756
		public uint retCode;
	}
}
