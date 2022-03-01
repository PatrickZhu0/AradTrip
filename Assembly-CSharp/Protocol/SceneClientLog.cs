using System;

namespace Protocol
{
	// Token: 0x020006F2 RID: 1778
	[Protocol]
	public class SceneClientLog : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059FE RID: 23038 RVA: 0x00111F64 File Offset: 0x00110364
		public uint GetMsgID()
		{
			return 500631U;
		}

		// Token: 0x060059FF RID: 23039 RVA: 0x00111F6B File Offset: 0x0011036B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A00 RID: 23040 RVA: 0x00111F73 File Offset: 0x00110373
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A01 RID: 23041 RVA: 0x00111F7C File Offset: 0x0011037C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.param1);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.param2);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.param3);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005A02 RID: 23042 RVA: 0x00111FFC File Offset: 0x001103FC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.param1 = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.param2 = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.param3 = StringHelper.BytesToString(array4);
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x00112128 File Offset: 0x00110528
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.param1);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.param2);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.param3);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005A04 RID: 23044 RVA: 0x001121B4 File Offset: 0x001105B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.param1 = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.param2 = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.param3 = StringHelper.BytesToString(array4);
		}

		// Token: 0x06005A05 RID: 23045 RVA: 0x001122E0 File Offset: 0x001106E0
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.param1);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.param2);
			num += 2 + array3.Length;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.param3);
			return num + (2 + array4.Length);
		}

		// Token: 0x0400247B RID: 9339
		public const uint MsgID = 500631U;

		// Token: 0x0400247C RID: 9340
		public uint Sequence;

		// Token: 0x0400247D RID: 9341
		public string name;

		// Token: 0x0400247E RID: 9342
		public string param1;

		// Token: 0x0400247F RID: 9343
		public string param2;

		// Token: 0x04002480 RID: 9344
		public string param3;
	}
}
