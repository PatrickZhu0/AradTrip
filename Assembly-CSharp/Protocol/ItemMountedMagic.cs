using System;

namespace Protocol
{
	// Token: 0x020008C9 RID: 2249
	public class ItemMountedMagic : IProtocolStream
	{
		// Token: 0x060067AB RID: 26539 RVA: 0x00131C2C File Offset: 0x0013002C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060067AC RID: 26540 RVA: 0x00131C4A File Offset: 0x0013004A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x060067AD RID: 26541 RVA: 0x00131C68 File Offset: 0x00130068
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.magicCardId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060067AE RID: 26542 RVA: 0x00131C86 File Offset: 0x00130086
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.magicCardId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x060067AF RID: 26543 RVA: 0x00131CA4 File Offset: 0x001300A4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002EBF RID: 11967
		public uint magicCardId;

		// Token: 0x04002EC0 RID: 11968
		public byte level;
	}
}
