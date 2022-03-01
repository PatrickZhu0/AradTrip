using System;

namespace Protocol
{
	// Token: 0x020008D6 RID: 2262
	public class GiftPackSyncInfo : IProtocolStream
	{
		// Token: 0x060067F9 RID: 26617 RVA: 0x00134BB4 File Offset: 0x00132FB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.filterType);
			BaseDLL.encode_int32(buffer, ref pos_, this.filterCount);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gifts.Length);
			for (int i = 0; i < this.gifts.Length; i++)
			{
				this.gifts[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.uiType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.description);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060067FA RID: 26618 RVA: 0x00134C50 File Offset: 0x00133050
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.filterType);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.filterCount);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gifts = new GiftSyncInfo[(int)num];
			for (int i = 0; i < this.gifts.Length; i++)
			{
				this.gifts[i] = new GiftSyncInfo();
				this.gifts[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.uiType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
			}
			this.description = StringHelper.BytesToString(array);
		}

		// Token: 0x060067FB RID: 26619 RVA: 0x00134D28 File Offset: 0x00133128
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.filterType);
			BaseDLL.encode_int32(buffer, ref pos_, this.filterCount);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gifts.Length);
			for (int i = 0; i < this.gifts.Length; i++)
			{
				this.gifts[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.uiType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.description);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060067FC RID: 26620 RVA: 0x00134DC8 File Offset: 0x001331C8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.filterType);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.filterCount);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gifts = new GiftSyncInfo[(int)num];
			for (int i = 0; i < this.gifts.Length; i++)
			{
				this.gifts[i] = new GiftSyncInfo();
				this.gifts[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.uiType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
			}
			this.description = StringHelper.BytesToString(array);
		}

		// Token: 0x060067FD RID: 26621 RVA: 0x00134EA0 File Offset: 0x001332A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.gifts.Length; i++)
			{
				num += this.gifts[i].getLen();
			}
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.description);
			return num + (2 + array.Length);
		}

		// Token: 0x04002F35 RID: 12085
		public uint id;

		// Token: 0x04002F36 RID: 12086
		public uint filterType;

		// Token: 0x04002F37 RID: 12087
		public int filterCount;

		// Token: 0x04002F38 RID: 12088
		public GiftSyncInfo[] gifts = new GiftSyncInfo[0];

		// Token: 0x04002F39 RID: 12089
		public byte uiType;

		// Token: 0x04002F3A RID: 12090
		public string description;
	}
}
