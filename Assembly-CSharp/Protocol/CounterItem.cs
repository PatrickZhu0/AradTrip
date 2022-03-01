using System;

namespace Protocol
{
	// Token: 0x020006F1 RID: 1777
	public class CounterItem : IProtocolStream
	{
		// Token: 0x060059F8 RID: 23032 RVA: 0x00111DC8 File Offset: 0x001101C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.currencyId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x060059F9 RID: 23033 RVA: 0x00111E10 File Offset: 0x00110210
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currencyId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x060059FA RID: 23034 RVA: 0x00111E7C File Offset: 0x0011027C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.currencyId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x060059FB RID: 23035 RVA: 0x00111EC4 File Offset: 0x001102C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currencyId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x060059FC RID: 23036 RVA: 0x00111F30 File Offset: 0x00110330
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04002478 RID: 9336
		public uint currencyId;

		// Token: 0x04002479 RID: 9337
		public string name;

		// Token: 0x0400247A RID: 9338
		public uint value;
	}
}
