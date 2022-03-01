using System;

namespace Protocol
{
	// Token: 0x020009BB RID: 2491
	public class LoginPushInfo : IProtocolStream
	{
		// Token: 0x06006FB8 RID: 28600 RVA: 0x001422FC File Offset: 0x001406FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.unlockLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.iconPath);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.linkInfo);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.loadingIconPath);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sortNum);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.openInterval);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.closeInterval);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isShowTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSetNative);
		}

		// Token: 0x06006FB9 RID: 28601 RVA: 0x00142418 File Offset: 0x00140818
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.unlockLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.iconPath = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.linkInfo = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.loadingIconPath = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sortNum);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.openInterval = StringHelper.BytesToString(array5);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array6 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[n]);
			}
			this.closeInterval = StringHelper.BytesToString(array6);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShowTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSetNative);
		}

		// Token: 0x06006FBA RID: 28602 RVA: 0x0014263C File Offset: 0x00140A3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.unlockLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.iconPath);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.linkInfo);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.loadingIconPath);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sortNum);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.openInterval);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.closeInterval);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isShowTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSetNative);
		}

		// Token: 0x06006FBB RID: 28603 RVA: 0x0014276C File Offset: 0x00140B6C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.unlockLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.iconPath = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.linkInfo = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.loadingIconPath = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sortNum);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.openInterval = StringHelper.BytesToString(array5);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array6 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[n]);
			}
			this.closeInterval = StringHelper.BytesToString(array6);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShowTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSetNative);
		}

		// Token: 0x06006FBC RID: 28604 RVA: 0x00142990 File Offset: 0x00140D90
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.iconPath);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.linkInfo);
			num += 2 + array3.Length;
			num += 4;
			num += 4;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.loadingIconPath);
			num += 2 + array4.Length;
			num++;
			byte[] array5 = StringHelper.StringToUTF8Bytes(this.openInterval);
			num += 2 + array5.Length;
			byte[] array6 = StringHelper.StringToUTF8Bytes(this.closeInterval);
			num += 2 + array6.Length;
			num++;
			return num + 1;
		}

		// Token: 0x040032BC RID: 12988
		public byte id;

		// Token: 0x040032BD RID: 12989
		public string name;

		// Token: 0x040032BE RID: 12990
		public ushort unlockLevel;

		// Token: 0x040032BF RID: 12991
		public string iconPath;

		// Token: 0x040032C0 RID: 12992
		public string linkInfo;

		// Token: 0x040032C1 RID: 12993
		public uint startTime;

		// Token: 0x040032C2 RID: 12994
		public uint endTime;

		// Token: 0x040032C3 RID: 12995
		public string loadingIconPath;

		// Token: 0x040032C4 RID: 12996
		public byte sortNum;

		// Token: 0x040032C5 RID: 12997
		public string openInterval;

		// Token: 0x040032C6 RID: 12998
		public string closeInterval;

		// Token: 0x040032C7 RID: 12999
		public byte isShowTime;

		// Token: 0x040032C8 RID: 13000
		public byte isSetNative;
	}
}
