using System;

namespace Protocol
{
	// Token: 0x02000C44 RID: 3140
	[Protocol]
	public class WorldSubmitHireTaskRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082BD RID: 33469 RVA: 0x001701C8 File Offset: 0x0016E5C8
		public uint GetMsgID()
		{
			return 601793U;
		}

		// Token: 0x060082BE RID: 33470 RVA: 0x001701CF File Offset: 0x0016E5CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082BF RID: 33471 RVA: 0x001701D7 File Offset: 0x0016E5D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082C0 RID: 33472 RVA: 0x001701E0 File Offset: 0x0016E5E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x060082C1 RID: 33473 RVA: 0x001701FE File Offset: 0x0016E5FE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x060082C2 RID: 33474 RVA: 0x0017021C File Offset: 0x0016E61C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x060082C3 RID: 33475 RVA: 0x0017023A File Offset: 0x0016E63A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x060082C4 RID: 33476 RVA: 0x00170258 File Offset: 0x0016E658
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003E69 RID: 15977
		public const uint MsgID = 601793U;

		// Token: 0x04003E6A RID: 15978
		public uint Sequence;

		// Token: 0x04003E6B RID: 15979
		public uint taskId;

		// Token: 0x04003E6C RID: 15980
		public uint errorCode;
	}
}
