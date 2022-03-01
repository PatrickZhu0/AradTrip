using System;

namespace Protocol
{
	// Token: 0x02000C00 RID: 3072
	[Protocol]
	public class TeamCopyForceEndFlag : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600809B RID: 32923 RVA: 0x0016BEAC File Offset: 0x0016A2AC
		public uint GetMsgID()
		{
			return 1100069U;
		}

		// Token: 0x0600809C RID: 32924 RVA: 0x0016BEB3 File Offset: 0x0016A2B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600809D RID: 32925 RVA: 0x0016BEBB File Offset: 0x0016A2BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600809E RID: 32926 RVA: 0x0016BEC4 File Offset: 0x0016A2C4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600809F RID: 32927 RVA: 0x0016BEC6 File Offset: 0x0016A2C6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060080A0 RID: 32928 RVA: 0x0016BEC8 File Offset: 0x0016A2C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060080A1 RID: 32929 RVA: 0x0016BECA File Offset: 0x0016A2CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060080A2 RID: 32930 RVA: 0x0016BECC File Offset: 0x0016A2CC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003D68 RID: 15720
		public const uint MsgID = 1100069U;

		// Token: 0x04003D69 RID: 15721
		public uint Sequence;
	}
}
