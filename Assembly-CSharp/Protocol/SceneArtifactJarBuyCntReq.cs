using System;

namespace Protocol
{
	// Token: 0x02000966 RID: 2406
	[Protocol]
	public class SceneArtifactJarBuyCntReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006CFA RID: 27898 RVA: 0x0013CD10 File Offset: 0x0013B110
		public uint GetMsgID()
		{
			return 501046U;
		}

		// Token: 0x06006CFB RID: 27899 RVA: 0x0013CD17 File Offset: 0x0013B117
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006CFC RID: 27900 RVA: 0x0013CD1F File Offset: 0x0013B11F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006CFD RID: 27901 RVA: 0x0013CD28 File Offset: 0x0013B128
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006CFE RID: 27902 RVA: 0x0013CD2A File Offset: 0x0013B12A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006CFF RID: 27903 RVA: 0x0013CD2C File Offset: 0x0013B12C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D00 RID: 27904 RVA: 0x0013CD2E File Offset: 0x0013B12E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D01 RID: 27905 RVA: 0x0013CD30 File Offset: 0x0013B130
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400315C RID: 12636
		public const uint MsgID = 501046U;

		// Token: 0x0400315D RID: 12637
		public uint Sequence;
	}
}
