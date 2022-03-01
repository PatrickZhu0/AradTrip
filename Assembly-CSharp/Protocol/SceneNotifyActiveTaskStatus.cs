using System;

namespace Protocol
{
	// Token: 0x02000673 RID: 1651
	[Protocol]
	public class SceneNotifyActiveTaskStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005636 RID: 22070 RVA: 0x00108931 File Offset: 0x00106D31
		public uint GetMsgID()
		{
			return 501127U;
		}

		// Token: 0x06005637 RID: 22071 RVA: 0x00108938 File Offset: 0x00106D38
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005638 RID: 22072 RVA: 0x00108940 File Offset: 0x00106D40
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005639 RID: 22073 RVA: 0x00108949 File Offset: 0x00106D49
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x0600563A RID: 22074 RVA: 0x00108967 File Offset: 0x00106D67
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x0600563B RID: 22075 RVA: 0x00108985 File Offset: 0x00106D85
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x0600563C RID: 22076 RVA: 0x001089A3 File Offset: 0x00106DA3
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x0600563D RID: 22077 RVA: 0x001089C4 File Offset: 0x00106DC4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400223D RID: 8765
		public const uint MsgID = 501127U;

		// Token: 0x0400223E RID: 8766
		public uint Sequence;

		// Token: 0x0400223F RID: 8767
		public uint taskId;

		// Token: 0x04002240 RID: 8768
		public byte status;
	}
}
