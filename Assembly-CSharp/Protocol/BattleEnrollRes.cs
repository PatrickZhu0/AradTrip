using System;

namespace Protocol
{
	// Token: 0x020006F8 RID: 1784
	[Protocol]
	public class BattleEnrollRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A34 RID: 23092 RVA: 0x001129DC File Offset: 0x00110DDC
		public uint GetMsgID()
		{
			return 2200006U;
		}

		// Token: 0x06005A35 RID: 23093 RVA: 0x001129E3 File Offset: 0x00110DE3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A36 RID: 23094 RVA: 0x001129EB File Offset: 0x00110DEB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A37 RID: 23095 RVA: 0x001129F4 File Offset: 0x00110DF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isMatch);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005A38 RID: 23096 RVA: 0x00112A12 File Offset: 0x00110E12
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isMatch);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005A39 RID: 23097 RVA: 0x00112A30 File Offset: 0x00110E30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isMatch);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005A3A RID: 23098 RVA: 0x00112A4E File Offset: 0x00110E4E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isMatch);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005A3B RID: 23099 RVA: 0x00112A6C File Offset: 0x00110E6C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002499 RID: 9369
		public const uint MsgID = 2200006U;

		// Token: 0x0400249A RID: 9370
		public uint Sequence;

		// Token: 0x0400249B RID: 9371
		public uint isMatch;

		// Token: 0x0400249C RID: 9372
		public uint retCode;
	}
}
