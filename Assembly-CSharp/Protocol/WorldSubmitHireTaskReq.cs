using System;

namespace Protocol
{
	// Token: 0x02000C43 RID: 3139
	[Protocol]
	public class WorldSubmitHireTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082B4 RID: 33460 RVA: 0x00170151 File Offset: 0x0016E551
		public uint GetMsgID()
		{
			return 601792U;
		}

		// Token: 0x060082B5 RID: 33461 RVA: 0x00170158 File Offset: 0x0016E558
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082B6 RID: 33462 RVA: 0x00170160 File Offset: 0x0016E560
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082B7 RID: 33463 RVA: 0x00170169 File Offset: 0x0016E569
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060082B8 RID: 33464 RVA: 0x00170179 File Offset: 0x0016E579
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060082B9 RID: 33465 RVA: 0x00170189 File Offset: 0x0016E589
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060082BA RID: 33466 RVA: 0x00170199 File Offset: 0x0016E599
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060082BB RID: 33467 RVA: 0x001701AC File Offset: 0x0016E5AC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003E66 RID: 15974
		public const uint MsgID = 601792U;

		// Token: 0x04003E67 RID: 15975
		public uint Sequence;

		// Token: 0x04003E68 RID: 15976
		public uint taskId;
	}
}
