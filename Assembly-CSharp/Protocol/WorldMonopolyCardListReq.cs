using System;

namespace Protocol
{
	// Token: 0x02000A12 RID: 2578
	[Protocol]
	public class WorldMonopolyCardListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007267 RID: 29287 RVA: 0x0014B66C File Offset: 0x00149A6C
		public uint GetMsgID()
		{
			return 610209U;
		}

		// Token: 0x06007268 RID: 29288 RVA: 0x0014B673 File Offset: 0x00149A73
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007269 RID: 29289 RVA: 0x0014B67B File Offset: 0x00149A7B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600726A RID: 29290 RVA: 0x0014B684 File Offset: 0x00149A84
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600726B RID: 29291 RVA: 0x0014B686 File Offset: 0x00149A86
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600726C RID: 29292 RVA: 0x0014B688 File Offset: 0x00149A88
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600726D RID: 29293 RVA: 0x0014B68A File Offset: 0x00149A8A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600726E RID: 29294 RVA: 0x0014B68C File Offset: 0x00149A8C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003493 RID: 13459
		public const uint MsgID = 610209U;

		// Token: 0x04003494 RID: 13460
		public uint Sequence;
	}
}
