using System;

namespace Protocol
{
	// Token: 0x02000ADC RID: 2780
	[Protocol]
	public class WorldUpdateRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007807 RID: 30727 RVA: 0x0015B8EE File Offset: 0x00159CEE
		public uint GetMsgID()
		{
			return 607813U;
		}

		// Token: 0x06007808 RID: 30728 RVA: 0x0015B8F5 File Offset: 0x00159CF5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007809 RID: 30729 RVA: 0x0015B8FD File Offset: 0x00159CFD
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600780A RID: 30730 RVA: 0x0015B908 File Offset: 0x00159D08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
		}

		// Token: 0x0600780B RID: 30731 RVA: 0x0015B9A4 File Offset: 0x00159DA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
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
			this.password = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerLevel);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
		}

		// Token: 0x0600780C RID: 30732 RVA: 0x0015BA90 File Offset: 0x00159E90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
		}

		// Token: 0x0600780D RID: 30733 RVA: 0x0015BB30 File Offset: 0x00159F30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
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
			this.password = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerLevel);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
		}

		// Token: 0x0600780E RID: 30734 RVA: 0x0015BC1C File Offset: 0x0015A01C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.password);
			num += 2 + array2.Length;
			num++;
			num += 2;
			num++;
			return num + 4;
		}

		// Token: 0x040038AA RID: 14506
		public const uint MsgID = 607813U;

		// Token: 0x040038AB RID: 14507
		public uint Sequence;

		// Token: 0x040038AC RID: 14508
		public uint roomId;

		// Token: 0x040038AD RID: 14509
		public byte roomType;

		// Token: 0x040038AE RID: 14510
		public string name;

		// Token: 0x040038AF RID: 14511
		public string password;

		// Token: 0x040038B0 RID: 14512
		public byte isLimitPlayerLevel;

		// Token: 0x040038B1 RID: 14513
		public ushort limitPlayerLevel;

		// Token: 0x040038B2 RID: 14514
		public byte isLimitPlayerSeasonLevel;

		// Token: 0x040038B3 RID: 14515
		public uint limitPlayerSeasonLevel;
	}
}
