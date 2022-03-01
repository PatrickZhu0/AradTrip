using System;

namespace Protocol
{
	// Token: 0x02000916 RID: 2326
	public class MallGiftDetail : IProtocolStream
	{
		// Token: 0x06006A36 RID: 27190 RVA: 0x00138364 File Offset: 0x00136764
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A37 RID: 27191 RVA: 0x00138382 File Offset: 0x00136782
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A38 RID: 27192 RVA: 0x001383A0 File Offset: 0x001367A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006A39 RID: 27193 RVA: 0x001383BE File Offset: 0x001367BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006A3A RID: 27194 RVA: 0x001383DC File Offset: 0x001367DC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 2;
		}

		// Token: 0x0400302A RID: 12330
		public uint itemId;

		// Token: 0x0400302B RID: 12331
		public ushort num;
	}
}
