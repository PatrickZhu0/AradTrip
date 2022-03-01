using System;

namespace Protocol
{
	// Token: 0x02000676 RID: 1654
	[Protocol]
	public class SceneActiveTaskSubmit : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005651 RID: 22097 RVA: 0x00108DE9 File Offset: 0x001071E9
		public uint GetMsgID()
		{
			return 501130U;
		}

		// Token: 0x06005652 RID: 22098 RVA: 0x00108DF0 File Offset: 0x001071F0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005653 RID: 22099 RVA: 0x00108DF8 File Offset: 0x001071F8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005654 RID: 22100 RVA: 0x00108E01 File Offset: 0x00107201
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
		}

		// Token: 0x06005655 RID: 22101 RVA: 0x00108E1F File Offset: 0x0010721F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
		}

		// Token: 0x06005656 RID: 22102 RVA: 0x00108E3D File Offset: 0x0010723D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
		}

		// Token: 0x06005657 RID: 22103 RVA: 0x00108E5B File Offset: 0x0010725B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
		}

		// Token: 0x06005658 RID: 22104 RVA: 0x00108E7C File Offset: 0x0010727C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002249 RID: 8777
		public const uint MsgID = 501130U;

		// Token: 0x0400224A RID: 8778
		public uint Sequence;

		// Token: 0x0400224B RID: 8779
		public uint taskId;

		// Token: 0x0400224C RID: 8780
		public uint param1;
	}
}
