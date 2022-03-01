using System;

namespace Protocol
{
	// Token: 0x02000868 RID: 2152
	[Protocol]
	public class WorldGuildBattleInspireInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600651A RID: 25882 RVA: 0x0012D066 File Offset: 0x0012B466
		public uint GetMsgID()
		{
			return 601963U;
		}

		// Token: 0x0600651B RID: 25883 RVA: 0x0012D06D File Offset: 0x0012B46D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600651C RID: 25884 RVA: 0x0012D075 File Offset: 0x0012B475
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600651D RID: 25885 RVA: 0x0012D07E File Offset: 0x0012B47E
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600651E RID: 25886 RVA: 0x0012D080 File Offset: 0x0012B480
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600651F RID: 25887 RVA: 0x0012D082 File Offset: 0x0012B482
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006520 RID: 25888 RVA: 0x0012D084 File Offset: 0x0012B484
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006521 RID: 25889 RVA: 0x0012D088 File Offset: 0x0012B488
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D52 RID: 11602
		public const uint MsgID = 601963U;

		// Token: 0x04002D53 RID: 11603
		public uint Sequence;
	}
}
