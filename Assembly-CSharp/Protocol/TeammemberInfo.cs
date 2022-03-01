using System;

namespace Protocol
{
	// Token: 0x02000B7D RID: 2941
	public class TeammemberInfo : IProtocolStream
	{
		// Token: 0x06007CC3 RID: 31939 RVA: 0x00163BB4 File Offset: 0x00161FB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusMask);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainTimes);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.resistMagic);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007CC4 RID: 31940 RVA: 0x00163C68 File Offset: 0x00162068
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
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusMask);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainTimes);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resistMagic);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007CC5 RID: 31941 RVA: 0x00163D40 File Offset: 0x00162140
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.statusMask);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainTimes);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.resistMagic);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007CC6 RID: 31942 RVA: 0x00163DF8 File Offset: 0x001621F8
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
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statusMask);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainTimes);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resistMagic);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007CC7 RID: 31943 RVA: 0x00163ED0 File Offset: 0x001622D0
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num++;
			num++;
			num += this.avatar.getLen();
			num += 4;
			num += 8;
			num++;
			num += 4;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04003B24 RID: 15140
		public ulong id;

		// Token: 0x04003B25 RID: 15141
		public string name;

		// Token: 0x04003B26 RID: 15142
		public ushort level;

		// Token: 0x04003B27 RID: 15143
		public byte occu;

		// Token: 0x04003B28 RID: 15144
		public byte statusMask;

		// Token: 0x04003B29 RID: 15145
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04003B2A RID: 15146
		public uint remainTimes;

		// Token: 0x04003B2B RID: 15147
		public ulong guildId;

		// Token: 0x04003B2C RID: 15148
		public byte vipLevel;

		// Token: 0x04003B2D RID: 15149
		public uint resistMagic;

		// Token: 0x04003B2E RID: 15150
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
