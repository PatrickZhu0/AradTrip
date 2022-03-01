using System;

namespace Protocol
{
	// Token: 0x02000C55 RID: 3157
	public class MissionPair : IProtocolStream
	{
		// Token: 0x0600830E RID: 33550 RVA: 0x00170848 File Offset: 0x0016EC48
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600830F RID: 33551 RVA: 0x00170890 File Offset: 0x0016EC90
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.value = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008310 RID: 33552 RVA: 0x00170928 File Offset: 0x0016ED28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008311 RID: 33553 RVA: 0x00170974 File Offset: 0x0016ED74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.value = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008312 RID: 33554 RVA: 0x00170A0C File Offset: 0x0016EE0C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.key);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.value);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003EB3 RID: 16051
		public string key;

		// Token: 0x04003EB4 RID: 16052
		public string value;
	}
}
