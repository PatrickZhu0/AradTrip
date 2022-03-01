using System;

namespace Protocol
{
	// Token: 0x02000C73 RID: 3187
	[Protocol]
	public class WorldReportMasterDailyTaskRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008413 RID: 33811 RVA: 0x001729A4 File Offset: 0x00170DA4
		public uint GetMsgID()
		{
			return 601762U;
		}

		// Token: 0x06008414 RID: 33812 RVA: 0x001729AB File Offset: 0x00170DAB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008415 RID: 33813 RVA: 0x001729B3 File Offset: 0x00170DB3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008416 RID: 33814 RVA: 0x001729BC File Offset: 0x00170DBC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008417 RID: 33815 RVA: 0x001729CC File Offset: 0x00170DCC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06008418 RID: 33816 RVA: 0x001729DC File Offset: 0x00170DDC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008419 RID: 33817 RVA: 0x001729EC File Offset: 0x00170DEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600841A RID: 33818 RVA: 0x001729FC File Offset: 0x00170DFC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003F1C RID: 16156
		public const uint MsgID = 601762U;

		// Token: 0x04003F1D RID: 16157
		public uint Sequence;

		// Token: 0x04003F1E RID: 16158
		public uint code;
	}
}
