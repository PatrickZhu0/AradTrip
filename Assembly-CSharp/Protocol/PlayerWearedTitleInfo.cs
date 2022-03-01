using System;

namespace Protocol
{
	// Token: 0x02000A1C RID: 2588
	public class PlayerWearedTitleInfo : IProtocolStream
	{
		// Token: 0x060072B2 RID: 29362 RVA: 0x0014BF3C File Offset: 0x0014A33C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.style);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060072B3 RID: 29363 RVA: 0x0014BF84 File Offset: 0x0014A384
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.style);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x060072B4 RID: 29364 RVA: 0x0014BFF0 File Offset: 0x0014A3F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.style);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060072B5 RID: 29365 RVA: 0x0014C038 File Offset: 0x0014A438
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.style);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x060072B6 RID: 29366 RVA: 0x0014C0A4 File Offset: 0x0014A4A4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			return num + (2 + array.Length);
		}

		// Token: 0x040034B6 RID: 13494
		public uint titleId;

		// Token: 0x040034B7 RID: 13495
		public byte style;

		// Token: 0x040034B8 RID: 13496
		public string name;
	}
}
