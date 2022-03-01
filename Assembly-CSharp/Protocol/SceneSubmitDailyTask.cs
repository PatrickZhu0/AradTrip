using System;

namespace Protocol
{
	// Token: 0x02000C5C RID: 3164
	[Protocol]
	public class SceneSubmitDailyTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008347 RID: 33607 RVA: 0x00171300 File Offset: 0x0016F700
		public uint GetMsgID()
		{
			return 501124U;
		}

		// Token: 0x06008348 RID: 33608 RVA: 0x00171307 File Offset: 0x0016F707
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008349 RID: 33609 RVA: 0x0017130F File Offset: 0x0016F70F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600834A RID: 33610 RVA: 0x00171318 File Offset: 0x0016F718
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600834B RID: 33611 RVA: 0x00171328 File Offset: 0x0016F728
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x0600834C RID: 33612 RVA: 0x00171338 File Offset: 0x0016F738
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600834D RID: 33613 RVA: 0x00171348 File Offset: 0x0016F748
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x0600834E RID: 33614 RVA: 0x00171358 File Offset: 0x0016F758
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ECE RID: 16078
		public const uint MsgID = 501124U;

		// Token: 0x04003ECF RID: 16079
		public uint Sequence;

		// Token: 0x04003ED0 RID: 16080
		public uint taskId;
	}
}
