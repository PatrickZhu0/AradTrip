using System;

namespace Protocol
{
	// Token: 0x020008CB RID: 2251
	public class OpenJarResult : IProtocolStream
	{
		// Token: 0x060067B7 RID: 26551 RVA: 0x00131EB8 File Offset: 0x001302B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarItemId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060067B8 RID: 26552 RVA: 0x00131ED6 File Offset: 0x001302D6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarItemId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060067B9 RID: 26553 RVA: 0x00131EF4 File Offset: 0x001302F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarItemId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060067BA RID: 26554 RVA: 0x00131F12 File Offset: 0x00130312
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarItemId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060067BB RID: 26555 RVA: 0x00131F30 File Offset: 0x00130330
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002EC8 RID: 11976
		public uint jarItemId;

		// Token: 0x04002EC9 RID: 11977
		public ulong itemUid;
	}
}
