using System;

namespace Protocol
{
	// Token: 0x0200090D RID: 2317
	[Protocol]
	public class SyncWorldMallGiftPackActivityState : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069E5 RID: 27109 RVA: 0x00137889 File Offset: 0x00135C89
		public uint GetMsgID()
		{
			return 602817U;
		}

		// Token: 0x060069E6 RID: 27110 RVA: 0x00137890 File Offset: 0x00135C90
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069E7 RID: 27111 RVA: 0x00137898 File Offset: 0x00135C98
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069E8 RID: 27112 RVA: 0x001378A1 File Offset: 0x00135CA1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x060069E9 RID: 27113 RVA: 0x001378B1 File Offset: 0x00135CB1
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x060069EA RID: 27114 RVA: 0x001378C1 File Offset: 0x00135CC1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x060069EB RID: 27115 RVA: 0x001378D1 File Offset: 0x00135CD1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x060069EC RID: 27116 RVA: 0x001378E4 File Offset: 0x00135CE4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003002 RID: 12290
		public const uint MsgID = 602817U;

		// Token: 0x04003003 RID: 12291
		public uint Sequence;

		// Token: 0x04003004 RID: 12292
		public byte state;
	}
}
