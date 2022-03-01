using System;

namespace Protocol
{
	// Token: 0x020008D8 RID: 2264
	[Protocol]
	public class SceneSyncItemProp : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006808 RID: 26632 RVA: 0x00134F44 File Offset: 0x00133344
		public uint GetMsgID()
		{
			return 500906U;
		}

		// Token: 0x06006809 RID: 26633 RVA: 0x00134F4B File Offset: 0x0013334B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600680A RID: 26634 RVA: 0x00134F53 File Offset: 0x00133353
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600680B RID: 26635 RVA: 0x00134F5C File Offset: 0x0013335C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600680C RID: 26636 RVA: 0x00134F5E File Offset: 0x0013335E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600680D RID: 26637 RVA: 0x00134F60 File Offset: 0x00133360
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600680E RID: 26638 RVA: 0x00134F62 File Offset: 0x00133362
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x00134F64 File Offset: 0x00133364
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F3D RID: 12093
		public const uint MsgID = 500906U;

		// Token: 0x04002F3E RID: 12094
		public uint Sequence;
	}
}
