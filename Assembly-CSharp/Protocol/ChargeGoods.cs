using System;

namespace Protocol
{
	// Token: 0x02000C2D RID: 3117
	public class ChargeGoods : IProtocolStream
	{
		// Token: 0x06008203 RID: 33283 RVA: 0x0016E51C File Offset: 0x0016C91C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.desc);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.tags);
			BaseDLL.encode_uint16(buffer, ref pos_, this.money);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_uint16(buffer, ref pos_, this.firstAddNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.unfirstAddNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isFirstCharge);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainDays);
			BaseDLL.encode_int8(buffer, ref pos_, this.remainTimes);
		}

		// Token: 0x06008204 RID: 33284 RVA: 0x0016E5FC File Offset: 0x0016C9FC
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
			this.desc = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tags);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.money);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.firstAddNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.unfirstAddNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isFirstCharge);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.icon = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainDays);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.remainTimes);
		}

		// Token: 0x06008205 RID: 33285 RVA: 0x0016E72C File Offset: 0x0016CB2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.desc);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.tags);
			BaseDLL.encode_uint16(buffer, ref pos_, this.money);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_uint16(buffer, ref pos_, this.firstAddNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.unfirstAddNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isFirstCharge);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainDays);
			BaseDLL.encode_int8(buffer, ref pos_, this.remainTimes);
		}

		// Token: 0x06008206 RID: 33286 RVA: 0x0016E814 File Offset: 0x0016CC14
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
			this.desc = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tags);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.money);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.firstAddNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.unfirstAddNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isFirstCharge);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.icon = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainDays);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.remainTimes);
		}

		// Token: 0x06008207 RID: 33287 RVA: 0x0016E944 File Offset: 0x0016CD44
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.desc);
			num += 2 + array.Length;
			num += 4;
			num += 2;
			num += 2;
			num += 4;
			num += 2;
			num += 2;
			num += 2;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.icon);
			num += 2 + array2.Length;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003E11 RID: 15889
		public byte id;

		// Token: 0x04003E12 RID: 15890
		public string desc;

		// Token: 0x04003E13 RID: 15891
		public uint tags;

		// Token: 0x04003E14 RID: 15892
		public ushort money;

		// Token: 0x04003E15 RID: 15893
		public ushort vipScore;

		// Token: 0x04003E16 RID: 15894
		public uint itemId;

		// Token: 0x04003E17 RID: 15895
		public ushort num;

		// Token: 0x04003E18 RID: 15896
		public ushort firstAddNum;

		// Token: 0x04003E19 RID: 15897
		public ushort unfirstAddNum;

		// Token: 0x04003E1A RID: 15898
		public byte isFirstCharge;

		// Token: 0x04003E1B RID: 15899
		public string icon;

		// Token: 0x04003E1C RID: 15900
		public uint remainDays;

		// Token: 0x04003E1D RID: 15901
		public byte remainTimes;
	}
}
