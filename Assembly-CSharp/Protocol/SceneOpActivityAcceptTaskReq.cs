using System;

namespace Protocol
{
	// Token: 0x02000A48 RID: 2632
	[Protocol]
	public class SceneOpActivityAcceptTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073E7 RID: 29671 RVA: 0x00150415 File Offset: 0x0014E815
		public uint GetMsgID()
		{
			return 507410U;
		}

		// Token: 0x060073E8 RID: 29672 RVA: 0x0015041C File Offset: 0x0014E81C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073E9 RID: 29673 RVA: 0x00150424 File Offset: 0x0014E824
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073EA RID: 29674 RVA: 0x0015042D File Offset: 0x0014E82D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060073EB RID: 29675 RVA: 0x0015044B File Offset: 0x0014E84B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060073EC RID: 29676 RVA: 0x00150469 File Offset: 0x0014E869
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x060073ED RID: 29677 RVA: 0x00150487 File Offset: 0x0014E887
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x060073EE RID: 29678 RVA: 0x001504A8 File Offset: 0x0014E8A8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035C9 RID: 13769
		public const uint MsgID = 507410U;

		// Token: 0x040035CA RID: 13770
		public uint Sequence;

		// Token: 0x040035CB RID: 13771
		public uint opActId;

		// Token: 0x040035CC RID: 13772
		public uint taskId;
	}
}
