using System;

namespace Protocol
{
	// Token: 0x020008D0 RID: 2256
	public class GambingParticipantInfo : IProtocolStream
	{
		// Token: 0x060067D5 RID: 26581 RVA: 0x001330D4 File Offset: 0x001314D4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.participantId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.participantENPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.participantPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.participantServerName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.participantName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investMoneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investMoney);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.gambingRate);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x060067D6 RID: 26582 RVA: 0x001331D4 File Offset: 0x001315D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.participantId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.participantENPlatform = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.participantPlatform = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.participantServerName = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.participantName = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investMoneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investMoney);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.gambingRate = StringHelper.BytesToString(array5);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x060067D7 RID: 26583 RVA: 0x001333AC File Offset: 0x001317AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.participantId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.participantENPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.participantPlatform);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.participantServerName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.participantName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investMoneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investMoney);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.gambingRate);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x060067D8 RID: 26584 RVA: 0x001334B8 File Offset: 0x001318B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.participantId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.participantENPlatform = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.participantPlatform = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.participantServerName = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.participantName = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investMoneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investMoney);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.gambingRate = StringHelper.BytesToString(array5);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x060067D9 RID: 26585 RVA: 0x00133690 File Offset: 0x00131A90
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.participantENPlatform);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.participantPlatform);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.participantServerName);
			num += 2 + array3.Length;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.participantName);
			num += 2 + array4.Length;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += 4;
			byte[] array5 = StringHelper.StringToUTF8Bytes(this.gambingRate);
			num += 2 + array5.Length;
			return num + 1;
		}

		// Token: 0x04002EF9 RID: 12025
		public ulong participantId;

		// Token: 0x04002EFA RID: 12026
		public string participantENPlatform;

		// Token: 0x04002EFB RID: 12027
		public string participantPlatform;

		// Token: 0x04002EFC RID: 12028
		public string participantServerName;

		// Token: 0x04002EFD RID: 12029
		public string participantName;

		// Token: 0x04002EFE RID: 12030
		public uint gambingItemId;

		// Token: 0x04002EFF RID: 12031
		public ushort groupId;

		// Token: 0x04002F00 RID: 12032
		public uint investCopies;

		// Token: 0x04002F01 RID: 12033
		public uint investMoneyId;

		// Token: 0x04002F02 RID: 12034
		public uint investMoney;

		// Token: 0x04002F03 RID: 12035
		public string gambingRate;

		// Token: 0x04002F04 RID: 12036
		public byte status;
	}
}
