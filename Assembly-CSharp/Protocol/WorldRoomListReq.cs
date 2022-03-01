using System;

namespace Protocol
{
	// Token: 0x02000ADA RID: 2778
	[Protocol]
	public class WorldRoomListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077F5 RID: 30709 RVA: 0x0015B61D File Offset: 0x00159A1D
		public uint GetMsgID()
		{
			return 607811U;
		}

		// Token: 0x060077F6 RID: 30710 RVA: 0x0015B624 File Offset: 0x00159A24
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077F7 RID: 30711 RVA: 0x0015B62C File Offset: 0x00159A2C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077F8 RID: 30712 RVA: 0x0015B638 File Offset: 0x00159A38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPassword);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x060077F9 RID: 30713 RVA: 0x0015B6A8 File Offset: 0x00159AA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPassword);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x060077FA RID: 30714 RVA: 0x0015B718 File Offset: 0x00159B18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitPlayerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.limitPlayerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_int8(buffer, ref pos_, this.isPassword);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.count);
		}

		// Token: 0x060077FB RID: 30715 RVA: 0x0015B788 File Offset: 0x00159B88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitPlayerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.limitPlayerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPassword);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.count);
		}

		// Token: 0x060077FC RID: 30716 RVA: 0x0015B7F8 File Offset: 0x00159BF8
		public int getLen()
		{
			int num = 0;
			num += 2;
			num += 4;
			num++;
			num++;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400389D RID: 14493
		public const uint MsgID = 607811U;

		// Token: 0x0400389E RID: 14494
		public uint Sequence;

		// Token: 0x0400389F RID: 14495
		public ushort limitPlayerLevel;

		// Token: 0x040038A0 RID: 14496
		public uint limitPlayerSeasonLevel;

		// Token: 0x040038A1 RID: 14497
		public byte roomStatus;

		// Token: 0x040038A2 RID: 14498
		public byte roomType;

		// Token: 0x040038A3 RID: 14499
		public byte isPassword;

		// Token: 0x040038A4 RID: 14500
		public uint startIndex;

		// Token: 0x040038A5 RID: 14501
		public uint count;
	}
}
