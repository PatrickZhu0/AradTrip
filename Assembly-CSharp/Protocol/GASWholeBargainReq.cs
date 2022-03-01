using System;

namespace Protocol
{
	// Token: 0x0200068C RID: 1676
	[Protocol]
	public class GASWholeBargainReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005714 RID: 22292 RVA: 0x0010A058 File Offset: 0x00108458
		public uint GetMsgID()
		{
			return 707407U;
		}

		// Token: 0x06005715 RID: 22293 RVA: 0x0010A05F File Offset: 0x0010845F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005716 RID: 22294 RVA: 0x0010A067 File Offset: 0x00108467
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005717 RID: 22295 RVA: 0x0010A070 File Offset: 0x00108470
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005718 RID: 22296 RVA: 0x0010A072 File Offset: 0x00108472
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x0010A074 File Offset: 0x00108474
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600571A RID: 22298 RVA: 0x0010A076 File Offset: 0x00108476
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600571B RID: 22299 RVA: 0x0010A078 File Offset: 0x00108478
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002293 RID: 8851
		public const uint MsgID = 707407U;

		// Token: 0x04002294 RID: 8852
		public uint Sequence;
	}
}
