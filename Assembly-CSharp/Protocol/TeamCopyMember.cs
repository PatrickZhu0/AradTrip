using System;

namespace Protocol
{
	// Token: 0x02000BBA RID: 3002
	public class TeamCopyMember : IProtocolStream
	{
		// Token: 0x06007E43 RID: 32323 RVA: 0x001662B4 File Offset: 0x001646B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seatId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ticketIsEnough);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007E44 RID: 32324 RVA: 0x00166378 File Offset: 0x00164778
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerAwaken);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seatId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ticketIsEnough);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007E45 RID: 32325 RVA: 0x00166460 File Offset: 0x00164860
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.post);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seatId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ticketIsEnough);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x06007E46 RID: 32326 RVA: 0x00166528 File Offset: 0x00164928
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerAwaken);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seatId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ticketIsEnough);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06007E47 RID: 32327 RVA: 0x00166610 File Offset: 0x00164A10
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003C33 RID: 15411
		public uint accId;

		// Token: 0x04003C34 RID: 15412
		public ulong playerId;

		// Token: 0x04003C35 RID: 15413
		public string playerName;

		// Token: 0x04003C36 RID: 15414
		public uint playerOccu;

		// Token: 0x04003C37 RID: 15415
		public uint playerAwaken;

		// Token: 0x04003C38 RID: 15416
		public uint playerLvl;

		// Token: 0x04003C39 RID: 15417
		public uint post;

		// Token: 0x04003C3A RID: 15418
		public uint equipScore;

		// Token: 0x04003C3B RID: 15419
		public uint seatId;

		// Token: 0x04003C3C RID: 15420
		public uint ticketIsEnough;

		// Token: 0x04003C3D RID: 15421
		public uint zoneId;

		// Token: 0x04003C3E RID: 15422
		public ulong expireTime;
	}
}
