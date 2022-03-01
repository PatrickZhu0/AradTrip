using System;

namespace Protocol
{
	// Token: 0x02000926 RID: 2342
	[Protocol]
	public class SceneFashionMergeRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AC3 RID: 27331 RVA: 0x001392D0 File Offset: 0x001376D0
		public uint GetMsgID()
		{
			return 501019U;
		}

		// Token: 0x06006AC4 RID: 27332 RVA: 0x001392D7 File Offset: 0x001376D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AC5 RID: 27333 RVA: 0x001392DF File Offset: 0x001376DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AC6 RID: 27334 RVA: 0x001392E8 File Offset: 0x001376E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.handleType);
		}

		// Token: 0x06006AC7 RID: 27335 RVA: 0x001392F8 File Offset: 0x001376F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.handleType);
		}

		// Token: 0x06006AC8 RID: 27336 RVA: 0x00139308 File Offset: 0x00137708
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.handleType);
		}

		// Token: 0x06006AC9 RID: 27337 RVA: 0x00139318 File Offset: 0x00137718
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.handleType);
		}

		// Token: 0x06006ACA RID: 27338 RVA: 0x00139328 File Offset: 0x00137728
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400306E RID: 12398
		public const uint MsgID = 501019U;

		// Token: 0x0400306F RID: 12399
		public uint Sequence;

		// Token: 0x04003070 RID: 12400
		public uint handleType;
	}
}
