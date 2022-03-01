using System;

namespace Protocol
{
	// Token: 0x02000A49 RID: 2633
	[Protocol]
	public class SceneOpActivityAcceptTaskRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073F0 RID: 29680 RVA: 0x001504C8 File Offset: 0x0014E8C8
		public uint GetMsgID()
		{
			return 507411U;
		}

		// Token: 0x060073F1 RID: 29681 RVA: 0x001504CF File Offset: 0x0014E8CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073F2 RID: 29682 RVA: 0x001504D7 File Offset: 0x0014E8D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073F3 RID: 29683 RVA: 0x001504E0 File Offset: 0x0014E8E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060073F4 RID: 29684 RVA: 0x0015050C File Offset: 0x0014E90C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060073F5 RID: 29685 RVA: 0x00150538 File Offset: 0x0014E938
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x060073F6 RID: 29686 RVA: 0x00150564 File Offset: 0x0014E964
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x060073F7 RID: 29687 RVA: 0x00150590 File Offset: 0x0014E990
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035CD RID: 13773
		public const uint MsgID = 507411U;

		// Token: 0x040035CE RID: 13774
		public uint Sequence;

		// Token: 0x040035CF RID: 13775
		public uint opActId;

		// Token: 0x040035D0 RID: 13776
		public uint taskId;

		// Token: 0x040035D1 RID: 13777
		public uint retCode;
	}
}
