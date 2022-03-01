using System;

namespace Protocol
{
	// Token: 0x0200066E RID: 1646
	public class DropItem : IProtocolStream
	{
		// Token: 0x06005612 RID: 22034 RVA: 0x00107D30 File Offset: 0x00106130
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x06005613 RID: 22035 RVA: 0x00107D6A File Offset: 0x0010616A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x06005614 RID: 22036 RVA: 0x00107DA4 File Offset: 0x001061A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x06005615 RID: 22037 RVA: 0x00107DDE File Offset: 0x001061DE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x06005616 RID: 22038 RVA: 0x00107E18 File Offset: 0x00106218
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x04002221 RID: 8737
		public uint itemId;

		// Token: 0x04002222 RID: 8738
		public uint num;

		// Token: 0x04002223 RID: 8739
		public byte strenth;

		// Token: 0x04002224 RID: 8740
		public byte equipType;
	}
}
