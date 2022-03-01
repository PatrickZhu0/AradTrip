using System;

namespace Protocol
{
	// Token: 0x02000822 RID: 2082
	public class GuildDonateLog : IProtocolStream
	{
		// Token: 0x060062B9 RID: 25273 RVA: 0x00128968 File Offset: 0x00126D68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contri);
		}

		// Token: 0x060062BA RID: 25274 RVA: 0x001289CC File Offset: 0x00126DCC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contri);
		}

		// Token: 0x060062BB RID: 25275 RVA: 0x00128A54 File Offset: 0x00126E54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contri);
		}

		// Token: 0x060062BC RID: 25276 RVA: 0x00128AB8 File Offset: 0x00126EB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contri);
		}

		// Token: 0x060062BD RID: 25277 RVA: 0x00128B40 File Offset: 0x00126F40
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04002C50 RID: 11344
		public ulong id;

		// Token: 0x04002C51 RID: 11345
		public string name;

		// Token: 0x04002C52 RID: 11346
		public byte type;

		// Token: 0x04002C53 RID: 11347
		public byte num;

		// Token: 0x04002C54 RID: 11348
		public uint contri;
	}
}
