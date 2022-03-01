using System;

namespace Protocol
{
	// Token: 0x020008D3 RID: 2259
	public class GambingGroupRecordData : IProtocolStream
	{
		// Token: 0x060067E7 RID: 26599 RVA: 0x00134000 File Offset: 0x00132400
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.gainerENPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.gainerPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.gainerServerName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.gainerId);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.gainerName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCurrencyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCurrencyNum);
		}

		// Token: 0x060067E8 RID: 26600 RVA: 0x001340B8 File Offset: 0x001324B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.gainerENPlatform = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.gainerPlatform = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.gainerServerName = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.gainerId);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.gainerName = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCurrencyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCurrencyNum);
		}

		// Token: 0x060067E9 RID: 26601 RVA: 0x0013421C File Offset: 0x0013261C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.gainerENPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.gainerPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.gainerServerName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.gainerId);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.gainerName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCurrencyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCurrencyNum);
		}

		// Token: 0x060067EA RID: 26602 RVA: 0x001342E0 File Offset: 0x001326E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.gainerENPlatform = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.gainerPlatform = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.gainerServerName = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.gainerId);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.gainerName = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCurrencyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCurrencyNum);
		}

		// Token: 0x060067EB RID: 26603 RVA: 0x00134444 File Offset: 0x00132844
		public int getLen()
		{
			int num = 0;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.gainerENPlatform);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.gainerPlatform);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.gainerServerName);
			num += 2 + array3.Length;
			num += 8;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.gainerName);
			num += 2 + array4.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002F1E RID: 12062
		public ushort groupId;

		// Token: 0x04002F1F RID: 12063
		public string gainerENPlatform;

		// Token: 0x04002F20 RID: 12064
		public string gainerPlatform;

		// Token: 0x04002F21 RID: 12065
		public string gainerServerName;

		// Token: 0x04002F22 RID: 12066
		public ulong gainerId;

		// Token: 0x04002F23 RID: 12067
		public string gainerName;

		// Token: 0x04002F24 RID: 12068
		public uint investCurrencyId;

		// Token: 0x04002F25 RID: 12069
		public uint investCurrencyNum;
	}
}
