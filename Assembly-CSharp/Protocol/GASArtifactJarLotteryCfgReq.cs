using System;

namespace Protocol
{
	// Token: 0x0200096D RID: 2413
	[Protocol]
	public class GASArtifactJarLotteryCfgReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D33 RID: 27955 RVA: 0x0013D4E0 File Offset: 0x0013B8E0
		public uint GetMsgID()
		{
			return 700905U;
		}

		// Token: 0x06006D34 RID: 27956 RVA: 0x0013D4E7 File Offset: 0x0013B8E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D35 RID: 27957 RVA: 0x0013D4EF File Offset: 0x0013B8EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D36 RID: 27958 RVA: 0x0013D4F8 File Offset: 0x0013B8F8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D37 RID: 27959 RVA: 0x0013D4FA File Offset: 0x0013B8FA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D38 RID: 27960 RVA: 0x0013D4FC File Offset: 0x0013B8FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D39 RID: 27961 RVA: 0x0013D4FE File Offset: 0x0013B8FE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D3A RID: 27962 RVA: 0x0013D500 File Offset: 0x0013B900
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003171 RID: 12657
		public const uint MsgID = 700905U;

		// Token: 0x04003172 RID: 12658
		public uint Sequence;
	}
}
