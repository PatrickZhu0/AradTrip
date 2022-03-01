using System;

namespace Protocol
{
	// Token: 0x02000AE0 RID: 2784
	[Protocol]
	public class WorldQuitRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600782B RID: 30763 RVA: 0x0015BFE6 File Offset: 0x0015A3E6
		public uint GetMsgID()
		{
			return 607817U;
		}

		// Token: 0x0600782C RID: 30764 RVA: 0x0015BFED File Offset: 0x0015A3ED
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600782D RID: 30765 RVA: 0x0015BFF5 File Offset: 0x0015A3F5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600782E RID: 30766 RVA: 0x0015BFFE File Offset: 0x0015A3FE
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600782F RID: 30767 RVA: 0x0015C000 File Offset: 0x0015A400
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007830 RID: 30768 RVA: 0x0015C002 File Offset: 0x0015A402
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007831 RID: 30769 RVA: 0x0015C004 File Offset: 0x0015A404
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007832 RID: 30770 RVA: 0x0015C008 File Offset: 0x0015A408
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040038C2 RID: 14530
		public const uint MsgID = 607817U;

		// Token: 0x040038C3 RID: 14531
		public uint Sequence;
	}
}
