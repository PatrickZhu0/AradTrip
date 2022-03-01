using System;

namespace Protocol
{
	// Token: 0x02000CA1 RID: 3233
	[Protocol]
	public class AddonPayData : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008560 RID: 34144 RVA: 0x0017613C File Offset: 0x0017453C
		public uint GetMsgID()
		{
			return 501708U;
		}

		// Token: 0x06008561 RID: 34145 RVA: 0x00176143 File Offset: 0x00174543
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008562 RID: 34146 RVA: 0x0017614B File Offset: 0x0017454B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008563 RID: 34147 RVA: 0x00176154 File Offset: 0x00174554
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.relationType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overdueTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payItemNum);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008564 RID: 34148 RVA: 0x00176218 File Offset: 0x00174618
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.relationType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overdueTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payItemNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.words = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008565 RID: 34149 RVA: 0x0017632C File Offset: 0x0017472C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.relationType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.overdueTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.payItemNum);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008566 RID: 34150 RVA: 0x001763F8 File Offset: 0x001747F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.relationType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.overdueTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.payItemNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.words = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008567 RID: 34151 RVA: 0x0017650C File Offset: 0x0017490C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.words);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003FE9 RID: 16361
		public const uint MsgID = 501708U;

		// Token: 0x04003FEA RID: 16362
		public uint Sequence;

		// Token: 0x04003FEB RID: 16363
		public ulong id;

		// Token: 0x04003FEC RID: 16364
		public byte type;

		// Token: 0x04003FED RID: 16365
		public byte relationType;

		// Token: 0x04003FEE RID: 16366
		public string name;

		// Token: 0x04003FEF RID: 16367
		public byte occu;

		// Token: 0x04003FF0 RID: 16368
		public uint level;

		// Token: 0x04003FF1 RID: 16369
		public uint overdueTime;

		// Token: 0x04003FF2 RID: 16370
		public byte status;

		// Token: 0x04003FF3 RID: 16371
		public uint payItemId;

		// Token: 0x04003FF4 RID: 16372
		public uint payItemNum;

		// Token: 0x04003FF5 RID: 16373
		public string words;
	}
}
