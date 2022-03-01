using System;

namespace Protocol
{
	// Token: 0x02000958 RID: 2392
	[Protocol]
	public class SceneFashionChangeActiveMergeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C7C RID: 27772 RVA: 0x0013BF4C File Offset: 0x0013A34C
		public uint GetMsgID()
		{
			return 501029U;
		}

		// Token: 0x06006C7D RID: 27773 RVA: 0x0013BF53 File Offset: 0x0013A353
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C7E RID: 27774 RVA: 0x0013BF5B File Offset: 0x0013A35B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C7F RID: 27775 RVA: 0x0013BF64 File Offset: 0x0013A364
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.fashionId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ticketId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.choiceComFashionId);
		}

		// Token: 0x06006C80 RID: 27776 RVA: 0x0013BF90 File Offset: 0x0013A390
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.fashionId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ticketId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.choiceComFashionId);
		}

		// Token: 0x06006C81 RID: 27777 RVA: 0x0013BFBC File Offset: 0x0013A3BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.fashionId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ticketId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.choiceComFashionId);
		}

		// Token: 0x06006C82 RID: 27778 RVA: 0x0013BFE8 File Offset: 0x0013A3E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.fashionId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ticketId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.choiceComFashionId);
		}

		// Token: 0x06006C83 RID: 27779 RVA: 0x0013C014 File Offset: 0x0013A414
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003115 RID: 12565
		public const uint MsgID = 501029U;

		// Token: 0x04003116 RID: 12566
		public uint Sequence;

		// Token: 0x04003117 RID: 12567
		public ulong fashionId;

		// Token: 0x04003118 RID: 12568
		public ulong ticketId;

		// Token: 0x04003119 RID: 12569
		public uint choiceComFashionId;
	}
}
