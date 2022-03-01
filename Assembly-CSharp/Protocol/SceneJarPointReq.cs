using System;

namespace Protocol
{
	// Token: 0x02000903 RID: 2307
	[Protocol]
	public class SceneJarPointReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600698B RID: 27019 RVA: 0x00137037 File Offset: 0x00135437
		public uint GetMsgID()
		{
			return 500960U;
		}

		// Token: 0x0600698C RID: 27020 RVA: 0x0013703E File Offset: 0x0013543E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600698D RID: 27021 RVA: 0x00137046 File Offset: 0x00135446
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600698E RID: 27022 RVA: 0x0013704F File Offset: 0x0013544F
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600698F RID: 27023 RVA: 0x00137051 File Offset: 0x00135451
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006990 RID: 27024 RVA: 0x00137053 File Offset: 0x00135453
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006991 RID: 27025 RVA: 0x00137055 File Offset: 0x00135455
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006992 RID: 27026 RVA: 0x00137058 File Offset: 0x00135458
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002FD9 RID: 12249
		public const uint MsgID = 500960U;

		// Token: 0x04002FDA RID: 12250
		public uint Sequence;
	}
}
