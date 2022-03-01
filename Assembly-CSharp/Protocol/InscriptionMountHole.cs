using System;

namespace Protocol
{
	// Token: 0x020008C6 RID: 2246
	public class InscriptionMountHole : IProtocolStream
	{
		// Token: 0x06006799 RID: 26521 RVA: 0x001319EC File Offset: 0x0012FDEC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x0600679A RID: 26522 RVA: 0x00131A18 File Offset: 0x0012FE18
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x0600679B RID: 26523 RVA: 0x00131A44 File Offset: 0x0012FE44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x0600679C RID: 26524 RVA: 0x00131A70 File Offset: 0x0012FE70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x0600679D RID: 26525 RVA: 0x00131A9C File Offset: 0x0012FE9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002EB7 RID: 11959
		public uint index;

		// Token: 0x04002EB8 RID: 11960
		public uint type;

		// Token: 0x04002EB9 RID: 11961
		public uint inscriptionId;
	}
}
