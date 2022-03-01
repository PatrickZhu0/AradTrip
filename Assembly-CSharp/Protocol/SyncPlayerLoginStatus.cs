using System;

namespace Protocol
{
	// Token: 0x020009D4 RID: 2516
	[Protocol]
	public class SyncPlayerLoginStatus : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600709C RID: 28828 RVA: 0x00145A28 File Offset: 0x00143E28
		public uint GetMsgID()
		{
			return 600308U;
		}

		// Token: 0x0600709D RID: 28829 RVA: 0x00145A2F File Offset: 0x00143E2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600709E RID: 28830 RVA: 0x00145A37 File Offset: 0x00143E37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600709F RID: 28831 RVA: 0x00145A40 File Offset: 0x00143E40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.playerLoginStatus);
		}

		// Token: 0x060070A0 RID: 28832 RVA: 0x00145A50 File Offset: 0x00143E50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerLoginStatus);
		}

		// Token: 0x060070A1 RID: 28833 RVA: 0x00145A60 File Offset: 0x00143E60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.playerLoginStatus);
		}

		// Token: 0x060070A2 RID: 28834 RVA: 0x00145A70 File Offset: 0x00143E70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerLoginStatus);
		}

		// Token: 0x060070A3 RID: 28835 RVA: 0x00145A80 File Offset: 0x00143E80
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x0400334B RID: 13131
		public const uint MsgID = 600308U;

		// Token: 0x0400334C RID: 13132
		public uint Sequence;

		// Token: 0x0400334D RID: 13133
		public byte playerLoginStatus;
	}
}
