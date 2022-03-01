using System;

namespace Protocol
{
	// Token: 0x02000ACC RID: 2764
	public class RoomSimpleInfo : IProtocolStream
	{
		// Token: 0x06007783 RID: 30595 RVA: 0x0015964C File Offset: 0x00157A4C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.roomStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerMaxSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPassword);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.ownerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownerSeasonLevel);
		}

		// Token: 0x06007784 RID: 30596 RVA: 0x0015972C File Offset: 0x00157B2C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerLevel);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerMaxSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPassword);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ownerOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownerSeasonLevel);
		}

		// Token: 0x06007785 RID: 30597 RVA: 0x00159830 File Offset: 0x00157C30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.roomStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLimitPlayerSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerMaxSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPassword);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.ownerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownerSeasonLevel);
		}

		// Token: 0x06007786 RID: 30598 RVA: 0x00159914 File Offset: 0x00157D14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerLevel);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLimitPlayerSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerMaxSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPassword);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ownerOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownerSeasonLevel);
		}

		// Token: 0x06007787 RID: 30599 RVA: 0x00159A18 File Offset: 0x00157E18
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			num++;
			num += 2;
			num++;
			num += 4;
			num++;
			num++;
			num++;
			num += 8;
			num++;
			return num + 4;
		}

		// Token: 0x04003835 RID: 14389
		public uint id;

		// Token: 0x04003836 RID: 14390
		public string name;

		// Token: 0x04003837 RID: 14391
		public byte roomStatus;

		// Token: 0x04003838 RID: 14392
		public byte roomType;

		// Token: 0x04003839 RID: 14393
		public byte isLimitPlayerLevel;

		// Token: 0x0400383A RID: 14394
		public ushort limitPlayerLevel;

		// Token: 0x0400383B RID: 14395
		public byte isLimitPlayerSeasonLevel;

		// Token: 0x0400383C RID: 14396
		public uint limitPlayerSeasonLevel;

		// Token: 0x0400383D RID: 14397
		public byte playerSize;

		// Token: 0x0400383E RID: 14398
		public byte playerMaxSize;

		// Token: 0x0400383F RID: 14399
		public byte isPassword;

		// Token: 0x04003840 RID: 14400
		public ulong ownerId;

		// Token: 0x04003841 RID: 14401
		public byte ownerOccu;

		// Token: 0x04003842 RID: 14402
		public uint ownerSeasonLevel;
	}
}
