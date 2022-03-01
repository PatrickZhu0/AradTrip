using System;

namespace Protocol
{
	// Token: 0x02000823 RID: 2083
	public class GuildLeaderInfo : IProtocolStream
	{
		// Token: 0x060062BF RID: 25279 RVA: 0x00128B94 File Offset: 0x00126F94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.popularoty);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060062C0 RID: 25280 RVA: 0x00128C04 File Offset: 0x00127004
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.popularoty);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060062C1 RID: 25281 RVA: 0x00128C98 File Offset: 0x00127098
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.popularoty);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060062C2 RID: 25282 RVA: 0x00128D08 File Offset: 0x00127108
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.popularoty);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060062C3 RID: 25283 RVA: 0x00128D9C File Offset: 0x0012719C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += this.avatar.getLen();
			num += 4;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002C55 RID: 11349
		public ulong id;

		// Token: 0x04002C56 RID: 11350
		public string name;

		// Token: 0x04002C57 RID: 11351
		public byte occu;

		// Token: 0x04002C58 RID: 11352
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04002C59 RID: 11353
		public uint popularoty;

		// Token: 0x04002C5A RID: 11354
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
