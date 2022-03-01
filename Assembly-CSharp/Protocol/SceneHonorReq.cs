using System;

namespace Protocol
{
	// Token: 0x020008AD RID: 2221
	[Protocol]
	public class SceneHonorReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006766 RID: 26470 RVA: 0x001310AE File Offset: 0x0012F4AE
		public uint GetMsgID()
		{
			return 509901U;
		}

		// Token: 0x06006767 RID: 26471 RVA: 0x001310B5 File Offset: 0x0012F4B5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006768 RID: 26472 RVA: 0x001310BD File Offset: 0x0012F4BD
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006769 RID: 26473 RVA: 0x001310C6 File Offset: 0x0012F4C6
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600676A RID: 26474 RVA: 0x001310C8 File Offset: 0x0012F4C8
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600676B RID: 26475 RVA: 0x001310CA File Offset: 0x0012F4CA
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600676C RID: 26476 RVA: 0x001310CC File Offset: 0x0012F4CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600676D RID: 26477 RVA: 0x001310D0 File Offset: 0x0012F4D0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002E39 RID: 11833
		public const uint MsgID = 509901U;

		// Token: 0x04002E3A RID: 11834
		public uint Sequence;
	}
}
