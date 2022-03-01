using System;

namespace Protocol
{
	// Token: 0x02000736 RID: 1846
	[Protocol]
	public class ShooterHistoryRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C32 RID: 23602 RVA: 0x00116879 File Offset: 0x00114C79
		public uint GetMsgID()
		{
			return 708305U;
		}

		// Token: 0x06005C33 RID: 23603 RVA: 0x00116880 File Offset: 0x00114C80
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C34 RID: 23604 RVA: 0x00116888 File Offset: 0x00114C88
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C35 RID: 23605 RVA: 0x00116891 File Offset: 0x00114C91
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06005C36 RID: 23606 RVA: 0x001168A1 File Offset: 0x00114CA1
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06005C37 RID: 23607 RVA: 0x001168B1 File Offset: 0x00114CB1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06005C38 RID: 23608 RVA: 0x001168C1 File Offset: 0x00114CC1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06005C39 RID: 23609 RVA: 0x001168D4 File Offset: 0x00114CD4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040025A3 RID: 9635
		public const uint MsgID = 708305U;

		// Token: 0x040025A4 RID: 9636
		public uint Sequence;

		// Token: 0x040025A5 RID: 9637
		public uint id;
	}
}
