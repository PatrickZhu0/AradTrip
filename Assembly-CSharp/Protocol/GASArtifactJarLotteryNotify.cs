using System;

namespace Protocol
{
	// Token: 0x0200096C RID: 2412
	[Protocol]
	public class GASArtifactJarLotteryNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D2A RID: 27946 RVA: 0x0013D4A5 File Offset: 0x0013B8A5
		public uint GetMsgID()
		{
			return 700904U;
		}

		// Token: 0x06006D2B RID: 27947 RVA: 0x0013D4AC File Offset: 0x0013B8AC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D2C RID: 27948 RVA: 0x0013D4B4 File Offset: 0x0013B8B4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D2D RID: 27949 RVA: 0x0013D4BD File Offset: 0x0013B8BD
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D2E RID: 27950 RVA: 0x0013D4BF File Offset: 0x0013B8BF
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D2F RID: 27951 RVA: 0x0013D4C1 File Offset: 0x0013B8C1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D30 RID: 27952 RVA: 0x0013D4C3 File Offset: 0x0013B8C3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D31 RID: 27953 RVA: 0x0013D4C8 File Offset: 0x0013B8C8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400316F RID: 12655
		public const uint MsgID = 700904U;

		// Token: 0x04003170 RID: 12656
		public uint Sequence;
	}
}
