using System;

namespace Protocol
{
	// Token: 0x020007F9 RID: 2041
	[Protocol]
	public class UnionGoldConsignmentDealRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600620E RID: 25102 RVA: 0x001251EC File Offset: 0x001235EC
		public uint GetMsgID()
		{
			return 1210103U;
		}

		// Token: 0x0600620F RID: 25103 RVA: 0x001251F3 File Offset: 0x001235F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006210 RID: 25104 RVA: 0x001251FB File Offset: 0x001235FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006211 RID: 25105 RVA: 0x00125204 File Offset: 0x00123604
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006212 RID: 25106 RVA: 0x00125206 File Offset: 0x00123606
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006213 RID: 25107 RVA: 0x00125208 File Offset: 0x00123608
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006214 RID: 25108 RVA: 0x0012520A File Offset: 0x0012360A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006215 RID: 25109 RVA: 0x0012520C File Offset: 0x0012360C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002B49 RID: 11081
		public const uint MsgID = 1210103U;

		// Token: 0x04002B4A RID: 11082
		public uint Sequence;
	}
}
