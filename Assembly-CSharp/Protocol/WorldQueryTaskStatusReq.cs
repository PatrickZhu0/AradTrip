using System;

namespace Protocol
{
	// Token: 0x02000C3B RID: 3131
	[Protocol]
	public class WorldQueryTaskStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008272 RID: 33394 RVA: 0x0016F7F0 File Offset: 0x0016DBF0
		public uint GetMsgID()
		{
			return 601786U;
		}

		// Token: 0x06008273 RID: 33395 RVA: 0x0016F7F7 File Offset: 0x0016DBF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008274 RID: 33396 RVA: 0x0016F7FF File Offset: 0x0016DBFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008275 RID: 33397 RVA: 0x0016F808 File Offset: 0x0016DC08
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008276 RID: 33398 RVA: 0x0016F80A File Offset: 0x0016DC0A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008277 RID: 33399 RVA: 0x0016F80C File Offset: 0x0016DC0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008278 RID: 33400 RVA: 0x0016F80E File Offset: 0x0016DC0E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008279 RID: 33401 RVA: 0x0016F810 File Offset: 0x0016DC10
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E4E RID: 15950
		public const uint MsgID = 601786U;

		// Token: 0x04003E4F RID: 15951
		public uint Sequence;
	}
}
