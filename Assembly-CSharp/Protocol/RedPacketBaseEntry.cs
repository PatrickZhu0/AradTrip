using System;

namespace Protocol
{
	// Token: 0x02000A77 RID: 2679
	public class RedPacketBaseEntry : IProtocolStream
	{
		// Token: 0x0600754C RID: 30028 RVA: 0x00153434 File Offset: 0x00151834
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.ownerName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.opened);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalMoney);
			BaseDLL.encode_int8(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.remainNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildTimeStamp);
		}

		// Token: 0x0600754D RID: 30029 RVA: 0x00153508 File Offset: 0x00151908
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
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.ownerName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opened);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalMoney);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.totalNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.remainNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildTimeStamp);
		}

		// Token: 0x0600754E RID: 30030 RVA: 0x0015362C File Offset: 0x00151A2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.ownerName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.opened);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalMoney);
			BaseDLL.encode_int8(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.remainNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildTimeStamp);
		}

		// Token: 0x0600754F RID: 30031 RVA: 0x00153704 File Offset: 0x00151B04
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
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.ownerName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opened);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalMoney);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.totalNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.remainNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildTimeStamp);
		}

		// Token: 0x06007550 RID: 30032 RVA: 0x00153828 File Offset: 0x00151C28
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.ownerName);
			num += 2 + array2.Length;
			num++;
			num++;
			num++;
			num += 2;
			num += 4;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04003697 RID: 13975
		public ulong id;

		// Token: 0x04003698 RID: 13976
		public string name;

		// Token: 0x04003699 RID: 13977
		public ulong ownerId;

		// Token: 0x0400369A RID: 13978
		public string ownerName;

		// Token: 0x0400369B RID: 13979
		public byte status;

		// Token: 0x0400369C RID: 13980
		public byte opened;

		// Token: 0x0400369D RID: 13981
		public byte type;

		// Token: 0x0400369E RID: 13982
		public ushort reason;

		// Token: 0x0400369F RID: 13983
		public uint totalMoney;

		// Token: 0x040036A0 RID: 13984
		public byte totalNum;

		// Token: 0x040036A1 RID: 13985
		public byte remainNum;

		// Token: 0x040036A2 RID: 13986
		public uint guildTimeStamp;
	}
}
