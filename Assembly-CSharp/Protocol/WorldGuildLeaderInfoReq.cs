using System;

namespace Protocol
{
	// Token: 0x0200084A RID: 2122
	[Protocol]
	public class WorldGuildLeaderInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600640C RID: 25612 RVA: 0x0012B4C4 File Offset: 0x001298C4
		public uint GetMsgID()
		{
			return 601934U;
		}

		// Token: 0x0600640D RID: 25613 RVA: 0x0012B4CB File Offset: 0x001298CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600640E RID: 25614 RVA: 0x0012B4D3 File Offset: 0x001298D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600640F RID: 25615 RVA: 0x0012B4DC File Offset: 0x001298DC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006410 RID: 25616 RVA: 0x0012B4DE File Offset: 0x001298DE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006411 RID: 25617 RVA: 0x0012B4E0 File Offset: 0x001298E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006412 RID: 25618 RVA: 0x0012B4E2 File Offset: 0x001298E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006413 RID: 25619 RVA: 0x0012B4E4 File Offset: 0x001298E4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CDD RID: 11485
		public const uint MsgID = 601934U;

		// Token: 0x04002CDE RID: 11486
		public uint Sequence;
	}
}
