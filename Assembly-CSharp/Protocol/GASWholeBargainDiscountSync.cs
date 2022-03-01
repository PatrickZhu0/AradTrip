using System;

namespace Protocol
{
	// Token: 0x0200068B RID: 1675
	[Protocol]
	public class GASWholeBargainDiscountSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600570B RID: 22283 RVA: 0x00109FE4 File Offset: 0x001083E4
		public uint GetMsgID()
		{
			return 707406U;
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x00109FEB File Offset: 0x001083EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600570D RID: 22285 RVA: 0x00109FF3 File Offset: 0x001083F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600570E RID: 22286 RVA: 0x00109FFC File Offset: 0x001083FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.discount);
		}

		// Token: 0x0600570F RID: 22287 RVA: 0x0010A00C File Offset: 0x0010840C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discount);
		}

		// Token: 0x06005710 RID: 22288 RVA: 0x0010A01C File Offset: 0x0010841C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.discount);
		}

		// Token: 0x06005711 RID: 22289 RVA: 0x0010A02C File Offset: 0x0010842C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discount);
		}

		// Token: 0x06005712 RID: 22290 RVA: 0x0010A03C File Offset: 0x0010843C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002290 RID: 8848
		public const uint MsgID = 707406U;

		// Token: 0x04002291 RID: 8849
		public uint Sequence;

		// Token: 0x04002292 RID: 8850
		public uint discount;
	}
}
