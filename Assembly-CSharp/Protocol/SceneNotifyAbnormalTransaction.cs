using System;

namespace Protocol
{
	// Token: 0x020006D3 RID: 1747
	[Protocol]
	public class SceneNotifyAbnormalTransaction : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600591A RID: 22810 RVA: 0x0010EED9 File Offset: 0x0010D2D9
		public uint GetMsgID()
		{
			return 503905U;
		}

		// Token: 0x0600591B RID: 22811 RVA: 0x0010EEE0 File Offset: 0x0010D2E0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600591C RID: 22812 RVA: 0x0010EEE8 File Offset: 0x0010D2E8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600591D RID: 22813 RVA: 0x0010EEF1 File Offset: 0x0010D2F1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.bNotify);
		}

		// Token: 0x0600591E RID: 22814 RVA: 0x0010EF01 File Offset: 0x0010D301
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bNotify);
		}

		// Token: 0x0600591F RID: 22815 RVA: 0x0010EF11 File Offset: 0x0010D311
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.bNotify);
		}

		// Token: 0x06005920 RID: 22816 RVA: 0x0010EF21 File Offset: 0x0010D321
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bNotify);
		}

		// Token: 0x06005921 RID: 22817 RVA: 0x0010EF34 File Offset: 0x0010D334
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040023CD RID: 9165
		public const uint MsgID = 503905U;

		// Token: 0x040023CE RID: 9166
		public uint Sequence;

		// Token: 0x040023CF RID: 9167
		public byte bNotify;
	}
}
