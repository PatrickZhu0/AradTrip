using System;

namespace Protocol
{
	// Token: 0x02000B1E RID: 2846
	[Protocol]
	public class SceneScoreWarRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A14 RID: 31252 RVA: 0x0015ED5C File Offset: 0x0015D15C
		public uint GetMsgID()
		{
			return 508103U;
		}

		// Token: 0x06007A15 RID: 31253 RVA: 0x0015ED63 File Offset: 0x0015D163
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A16 RID: 31254 RVA: 0x0015ED6B File Offset: 0x0015D16B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A17 RID: 31255 RVA: 0x0015ED74 File Offset: 0x0015D174
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x06007A18 RID: 31256 RVA: 0x0015ED84 File Offset: 0x0015D184
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x06007A19 RID: 31257 RVA: 0x0015ED94 File Offset: 0x0015D194
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x06007A1A RID: 31258 RVA: 0x0015EDA4 File Offset: 0x0015D1A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x06007A1B RID: 31259 RVA: 0x0015EDB4 File Offset: 0x0015D1B4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003998 RID: 14744
		public const uint MsgID = 508103U;

		// Token: 0x04003999 RID: 14745
		public uint Sequence;

		// Token: 0x0400399A RID: 14746
		public byte rewardId;
	}
}
