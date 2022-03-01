using System;

namespace Protocol
{
	// Token: 0x02000A38 RID: 2616
	[Protocol]
	public class TakeOpActTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600735D RID: 29533 RVA: 0x0014F182 File Offset: 0x0014D582
		public uint GetMsgID()
		{
			return 501148U;
		}

		// Token: 0x0600735E RID: 29534 RVA: 0x0014F189 File Offset: 0x0014D589
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600735F RID: 29535 RVA: 0x0014F191 File Offset: 0x0014D591
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007360 RID: 29536 RVA: 0x0014F19A File Offset: 0x0014D59A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskDataId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x06007361 RID: 29537 RVA: 0x0014F1C6 File Offset: 0x0014D5C6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskDataId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007362 RID: 29538 RVA: 0x0014F1F2 File Offset: 0x0014D5F2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskDataId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x06007363 RID: 29539 RVA: 0x0014F21E File Offset: 0x0014D61E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskDataId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007364 RID: 29540 RVA: 0x0014F24C File Offset: 0x0014D64C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400358C RID: 13708
		public const uint MsgID = 501148U;

		// Token: 0x0400358D RID: 13709
		public uint Sequence;

		// Token: 0x0400358E RID: 13710
		public uint activityDataId;

		// Token: 0x0400358F RID: 13711
		public uint taskDataId;

		// Token: 0x04003590 RID: 13712
		public ulong param;
	}
}
