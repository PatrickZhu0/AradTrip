using System;

namespace Protocol
{
	// Token: 0x02000BD3 RID: 3027
	public class TeamCopyApplyProperty : IProtocolStream
	{
		// Token: 0x06007F0F RID: 32527 RVA: 0x00168A00 File Offset: 0x00166E00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06007F10 RID: 32528 RVA: 0x00168A9C File Offset: 0x00166E9C
		public void decode(byte[] buffer, ref int pos_)
		{
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06007F11 RID: 32529 RVA: 0x00168B5C File Offset: 0x00166F5C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06007F12 RID: 32530 RVA: 0x00168BF8 File Offset: 0x00166FF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06007F13 RID: 32531 RVA: 0x00168CB8 File Offset: 0x001670B8
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003CA9 RID: 15529
		public ulong playerId;

		// Token: 0x04003CAA RID: 15530
		public string playerName;

		// Token: 0x04003CAB RID: 15531
		public uint playerOccu;

		// Token: 0x04003CAC RID: 15532
		public uint playerAwaken;

		// Token: 0x04003CAD RID: 15533
		public uint playerLevel;

		// Token: 0x04003CAE RID: 15534
		public uint equipScore;

		// Token: 0x04003CAF RID: 15535
		public uint isGold;

		// Token: 0x04003CB0 RID: 15536
		public ulong guildId;

		// Token: 0x04003CB1 RID: 15537
		public uint zoneId;
	}
}
