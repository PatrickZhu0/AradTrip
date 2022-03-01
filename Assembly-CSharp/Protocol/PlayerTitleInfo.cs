using System;

namespace Protocol
{
	// Token: 0x02000A1B RID: 2587
	public class PlayerTitleInfo : IProtocolStream
	{
		// Token: 0x060072AC RID: 29356 RVA: 0x0014BCB0 File Offset: 0x0014A0B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duetime);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.style);
		}

		// Token: 0x060072AD RID: 29357 RVA: 0x0014BD30 File Offset: 0x0014A130
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duetime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.style);
		}

		// Token: 0x060072AE RID: 29358 RVA: 0x0014BDD4 File Offset: 0x0014A1D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duetime);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.style);
		}

		// Token: 0x060072AF RID: 29359 RVA: 0x0014BE54 File Offset: 0x0014A254
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duetime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.style);
		}

		// Token: 0x060072B0 RID: 29360 RVA: 0x0014BEF8 File Offset: 0x0014A2F8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num++;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x040034AF RID: 13487
		public ulong guid;

		// Token: 0x040034B0 RID: 13488
		public uint createTime;

		// Token: 0x040034B1 RID: 13489
		public uint titleId;

		// Token: 0x040034B2 RID: 13490
		public byte type;

		// Token: 0x040034B3 RID: 13491
		public uint duetime;

		// Token: 0x040034B4 RID: 13492
		public string name;

		// Token: 0x040034B5 RID: 13493
		public byte style;
	}
}
