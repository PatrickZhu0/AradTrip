using System;

namespace Protocol
{
	// Token: 0x020007BA RID: 1978
	public class ZjslDungeonBuff : IProtocolStream
	{
		// Token: 0x06006007 RID: 24583 RVA: 0x0011FB8D File Offset: 0x0011DF8D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffTarget);
		}

		// Token: 0x06006008 RID: 24584 RVA: 0x0011FBB9 File Offset: 0x0011DFB9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffTarget);
		}

		// Token: 0x06006009 RID: 24585 RVA: 0x0011FBE5 File Offset: 0x0011DFE5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffTarget);
		}

		// Token: 0x0600600A RID: 24586 RVA: 0x0011FC11 File Offset: 0x0011E011
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffTarget);
		}

		// Token: 0x0600600B RID: 24587 RVA: 0x0011FC40 File Offset: 0x0011E040
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040027CA RID: 10186
		public uint buffId;

		// Token: 0x040027CB RID: 10187
		public uint buffLvl;

		// Token: 0x040027CC RID: 10188
		public uint buffTarget;
	}
}
