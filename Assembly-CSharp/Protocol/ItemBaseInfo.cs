using System;

namespace Protocol
{
	// Token: 0x02000C8B RID: 3211
	public class ItemBaseInfo : IProtocolStream
	{
		// Token: 0x060084A9 RID: 33961 RVA: 0x00173E40 File Offset: 0x00172240
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
		}

		// Token: 0x060084AA RID: 33962 RVA: 0x00173EB0 File Offset: 0x001722B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
		}

		// Token: 0x060084AB RID: 33963 RVA: 0x00173F20 File Offset: 0x00172320
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
		}

		// Token: 0x060084AC RID: 33964 RVA: 0x00173F90 File Offset: 0x00172390
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
		}

		// Token: 0x060084AD RID: 33965 RVA: 0x00174000 File Offset: 0x00172400
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num++;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04003F83 RID: 16259
		public ulong id;

		// Token: 0x04003F84 RID: 16260
		public uint typeId;

		// Token: 0x04003F85 RID: 16261
		public uint pos;

		// Token: 0x04003F86 RID: 16262
		public byte strengthen;

		// Token: 0x04003F87 RID: 16263
		public byte equipType;

		// Token: 0x04003F88 RID: 16264
		public byte enhanceType;

		// Token: 0x04003F89 RID: 16265
		public uint equipScore;
	}
}
