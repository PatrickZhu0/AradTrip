using System;

namespace Protocol
{
	// Token: 0x02000ACB RID: 2763
	public class RoomSlotInfo : IProtocolStream
	{
		// Token: 0x0600777D RID: 30589 RVA: 0x00159250 File Offset: 0x00157650
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.group);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerVipLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerAwake);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.readyStatus);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x0600777E RID: 30590 RVA: 0x00159320 File Offset: 0x00157720
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.group);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerVipLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerAwake);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.readyStatus);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x0600777F RID: 30591 RVA: 0x00159414 File Offset: 0x00157814
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.group);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSeasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerVipLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerAwake);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_int8(buffer, ref pos_, this.readyStatus);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007780 RID: 30592 RVA: 0x001594E8 File Offset: 0x001578E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.group);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSeasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerVipLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerAwake);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.readyStatus);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007781 RID: 30593 RVA: 0x001595DC File Offset: 0x001579DC
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 2;
			num += 4;
			num++;
			num++;
			num++;
			num += this.avatar.getLen();
			num++;
			num++;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04003828 RID: 14376
		public byte group;

		// Token: 0x04003829 RID: 14377
		public byte index;

		// Token: 0x0400382A RID: 14378
		public ulong playerId;

		// Token: 0x0400382B RID: 14379
		public string playerName;

		// Token: 0x0400382C RID: 14380
		public ushort playerLevel;

		// Token: 0x0400382D RID: 14381
		public uint playerSeasonLevel;

		// Token: 0x0400382E RID: 14382
		public byte playerVipLevel;

		// Token: 0x0400382F RID: 14383
		public byte playerOccu;

		// Token: 0x04003830 RID: 14384
		public byte playerAwake;

		// Token: 0x04003831 RID: 14385
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04003832 RID: 14386
		public byte status;

		// Token: 0x04003833 RID: 14387
		public byte readyStatus;

		// Token: 0x04003834 RID: 14388
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
