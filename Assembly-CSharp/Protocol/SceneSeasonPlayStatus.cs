using System;

namespace Protocol
{
	// Token: 0x02000A08 RID: 2568
	[Protocol]
	public class SceneSeasonPlayStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600720D RID: 29197 RVA: 0x0014AF98 File Offset: 0x00149398
		public uint GetMsgID()
		{
			return 506712U;
		}

		// Token: 0x0600720E RID: 29198 RVA: 0x0014AF9F File Offset: 0x0014939F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600720F RID: 29199 RVA: 0x0014AFA7 File Offset: 0x001493A7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007210 RID: 29200 RVA: 0x0014AFB0 File Offset: 0x001493B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonId);
		}

		// Token: 0x06007211 RID: 29201 RVA: 0x0014AFC0 File Offset: 0x001493C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonId);
		}

		// Token: 0x06007212 RID: 29202 RVA: 0x0014AFD0 File Offset: 0x001493D0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonId);
		}

		// Token: 0x06007213 RID: 29203 RVA: 0x0014AFE0 File Offset: 0x001493E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonId);
		}

		// Token: 0x06007214 RID: 29204 RVA: 0x0014AFF0 File Offset: 0x001493F0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400346C RID: 13420
		public const uint MsgID = 506712U;

		// Token: 0x0400346D RID: 13421
		public uint Sequence;

		// Token: 0x0400346E RID: 13422
		public uint seasonId;
	}
}
