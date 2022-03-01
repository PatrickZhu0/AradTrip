using System;

namespace Protocol
{
	// Token: 0x02000CBB RID: 3259
	[Protocol]
	public class WorldSetPlayerRemarkRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600864A RID: 34378 RVA: 0x001776DC File Offset: 0x00175ADC
		public uint GetMsgID()
		{
			return 601738U;
		}

		// Token: 0x0600864B RID: 34379 RVA: 0x001776E3 File Offset: 0x00175AE3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600864C RID: 34380 RVA: 0x001776EB File Offset: 0x00175AEB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600864D RID: 34381 RVA: 0x001776F4 File Offset: 0x00175AF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600864E RID: 34382 RVA: 0x00177704 File Offset: 0x00175B04
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600864F RID: 34383 RVA: 0x00177714 File Offset: 0x00175B14
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008650 RID: 34384 RVA: 0x00177724 File Offset: 0x00175B24
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06008651 RID: 34385 RVA: 0x00177734 File Offset: 0x00175B34
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04004045 RID: 16453
		public const uint MsgID = 601738U;

		// Token: 0x04004046 RID: 16454
		public uint Sequence;

		// Token: 0x04004047 RID: 16455
		public uint code;
	}
}
