using System;

namespace Protocol
{
	// Token: 0x02000A67 RID: 2663
	[Protocol]
	public class WorldPremiumLeagueSyncStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074CE RID: 29902 RVA: 0x00152695 File Offset: 0x00150A95
		public uint GetMsgID()
		{
			return 607701U;
		}

		// Token: 0x060074CF RID: 29903 RVA: 0x0015269C File Offset: 0x00150A9C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074D0 RID: 29904 RVA: 0x001526A4 File Offset: 0x00150AA4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074D1 RID: 29905 RVA: 0x001526AD File Offset: 0x00150AAD
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060074D2 RID: 29906 RVA: 0x001526BC File Offset: 0x00150ABC
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060074D3 RID: 29907 RVA: 0x001526CB File Offset: 0x00150ACB
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060074D4 RID: 29908 RVA: 0x001526DA File Offset: 0x00150ADA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060074D5 RID: 29909 RVA: 0x001526EC File Offset: 0x00150AEC
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003659 RID: 13913
		public const uint MsgID = 607701U;

		// Token: 0x0400365A RID: 13914
		public uint Sequence;

		// Token: 0x0400365B RID: 13915
		public PremiumLeagueStatusInfo info = new PremiumLeagueStatusInfo();
	}
}
