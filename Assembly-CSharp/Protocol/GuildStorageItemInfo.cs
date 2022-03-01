using System;

namespace Protocol
{
	// Token: 0x02000826 RID: 2086
	public class GuildStorageItemInfo : IProtocolStream
	{
		// Token: 0x060062D1 RID: 25297 RVA: 0x00129578 File Offset: 0x00127978
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.str);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x060062D2 RID: 25298 RVA: 0x001295CC File Offset: 0x001279CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.str);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x060062D3 RID: 25299 RVA: 0x00129620 File Offset: 0x00127A20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.str);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x060062D4 RID: 25300 RVA: 0x00129674 File Offset: 0x00127A74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.str);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x060062D5 RID: 25301 RVA: 0x001296C8 File Offset: 0x00127AC8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 2;
			num++;
			return num + 1;
		}

		// Token: 0x04002C68 RID: 11368
		public ulong uid;

		// Token: 0x04002C69 RID: 11369
		public uint dataId;

		// Token: 0x04002C6A RID: 11370
		public ushort num;

		// Token: 0x04002C6B RID: 11371
		public byte str;

		// Token: 0x04002C6C RID: 11372
		public byte equipType;
	}
}
