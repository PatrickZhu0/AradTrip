using System;

namespace Protocol
{
	// Token: 0x0200081A RID: 2074
	public class GuildBuilding : IProtocolStream
	{
		// Token: 0x06006289 RID: 25225 RVA: 0x00126DB6 File Offset: 0x001251B6
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x0600628A RID: 25226 RVA: 0x00126DD4 File Offset: 0x001251D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x0600628B RID: 25227 RVA: 0x00126DF2 File Offset: 0x001251F2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x0600628C RID: 25228 RVA: 0x00126E10 File Offset: 0x00125210
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x0600628D RID: 25229 RVA: 0x00126E30 File Offset: 0x00125230
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002C14 RID: 11284
		public byte type;

		// Token: 0x04002C15 RID: 11285
		public byte level;
	}
}
