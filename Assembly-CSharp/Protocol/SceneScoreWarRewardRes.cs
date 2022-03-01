using System;

namespace Protocol
{
	// Token: 0x02000B1F RID: 2847
	[Protocol]
	public class SceneScoreWarRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A1D RID: 31261 RVA: 0x0015EDD0 File Offset: 0x0015D1D0
		public uint GetMsgID()
		{
			return 508104U;
		}

		// Token: 0x06007A1E RID: 31262 RVA: 0x0015EDD7 File Offset: 0x0015D1D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A1F RID: 31263 RVA: 0x0015EDDF File Offset: 0x0015D1DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A20 RID: 31264 RVA: 0x0015EDE8 File Offset: 0x0015D1E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007A21 RID: 31265 RVA: 0x0015EDF8 File Offset: 0x0015D1F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007A22 RID: 31266 RVA: 0x0015EE08 File Offset: 0x0015D208
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007A23 RID: 31267 RVA: 0x0015EE18 File Offset: 0x0015D218
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007A24 RID: 31268 RVA: 0x0015EE28 File Offset: 0x0015D228
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400399B RID: 14747
		public const uint MsgID = 508104U;

		// Token: 0x0400399C RID: 14748
		public uint Sequence;

		// Token: 0x0400399D RID: 14749
		public uint result;
	}
}
