using System;

namespace Protocol
{
	// Token: 0x020008A6 RID: 2214
	[Protocol]
	public class SceneHeadFrameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006733 RID: 26419 RVA: 0x00130C80 File Offset: 0x0012F080
		public uint GetMsgID()
		{
			return 509101U;
		}

		// Token: 0x06006734 RID: 26420 RVA: 0x00130C87 File Offset: 0x0012F087
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006735 RID: 26421 RVA: 0x00130C8F File Offset: 0x0012F08F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006736 RID: 26422 RVA: 0x00130C98 File Offset: 0x0012F098
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006737 RID: 26423 RVA: 0x00130C9A File Offset: 0x0012F09A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006738 RID: 26424 RVA: 0x00130C9C File Offset: 0x0012F09C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006739 RID: 26425 RVA: 0x00130C9E File Offset: 0x0012F09E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600673A RID: 26426 RVA: 0x00130CA0 File Offset: 0x0012F0A0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002E21 RID: 11809
		public const uint MsgID = 509101U;

		// Token: 0x04002E22 RID: 11810
		public uint Sequence;
	}
}
