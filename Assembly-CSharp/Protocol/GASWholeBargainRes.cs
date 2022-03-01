using System;

namespace Protocol
{
	// Token: 0x0200068D RID: 1677
	[Protocol]
	public class GASWholeBargainRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600571D RID: 22301 RVA: 0x0010A090 File Offset: 0x00108490
		public uint GetMsgID()
		{
			return 707408U;
		}

		// Token: 0x0600571E RID: 22302 RVA: 0x0010A097 File Offset: 0x00108497
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600571F RID: 22303 RVA: 0x0010A09F File Offset: 0x0010849F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005720 RID: 22304 RVA: 0x0010A0A8 File Offset: 0x001084A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerJoinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discount);
		}

		// Token: 0x06005721 RID: 22305 RVA: 0x0010A0E2 File Offset: 0x001084E2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerJoinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discount);
		}

		// Token: 0x06005722 RID: 22306 RVA: 0x0010A11C File Offset: 0x0010851C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerJoinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.discount);
		}

		// Token: 0x06005723 RID: 22307 RVA: 0x0010A156 File Offset: 0x00108556
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerJoinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discount);
		}

		// Token: 0x06005724 RID: 22308 RVA: 0x0010A190 File Offset: 0x00108590
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002295 RID: 8853
		public const uint MsgID = 707408U;

		// Token: 0x04002296 RID: 8854
		public uint Sequence;

		// Token: 0x04002297 RID: 8855
		public uint playerJoinNum;

		// Token: 0x04002298 RID: 8856
		public uint joinNum;

		// Token: 0x04002299 RID: 8857
		public uint maxNum;

		// Token: 0x0400229A RID: 8858
		public uint discount;
	}
}
