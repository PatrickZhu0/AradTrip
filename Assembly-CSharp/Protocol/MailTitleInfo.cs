using System;

namespace Protocol
{
	// Token: 0x020009DE RID: 2526
	public class MailTitleInfo : IProtocolStream
	{
		// Token: 0x060070EA RID: 28906 RVA: 0x00146208 File Offset: 0x00144608
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.sender);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.date);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deadline);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasItem);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.title);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x060070EB RID: 28907 RVA: 0x001462B0 File Offset: 0x001446B0
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
			this.sender = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.date);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deadline);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasItem);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.title = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x060070EC RID: 28908 RVA: 0x001463A8 File Offset: 0x001447A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.sender);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.date);
			BaseDLL.encode_uint32(buffer, ref pos_, this.deadline);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasItem);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.title);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x060070ED RID: 28909 RVA: 0x00146458 File Offset: 0x00144858
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
			this.sender = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.date);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.deadline);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasItem);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.title = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x060070EE RID: 28910 RVA: 0x00146550 File Offset: 0x00144950
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.sender);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num++;
			num++;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.title);
			num += 2 + array2.Length;
			return num + 4;
		}

		// Token: 0x04003371 RID: 13169
		public ulong id;

		// Token: 0x04003372 RID: 13170
		public string sender;

		// Token: 0x04003373 RID: 13171
		public uint date;

		// Token: 0x04003374 RID: 13172
		public uint deadline;

		// Token: 0x04003375 RID: 13173
		public byte type;

		// Token: 0x04003376 RID: 13174
		public byte status;

		// Token: 0x04003377 RID: 13175
		public byte hasItem;

		// Token: 0x04003378 RID: 13176
		public string title;

		// Token: 0x04003379 RID: 13177
		public uint itemId;
	}
}
