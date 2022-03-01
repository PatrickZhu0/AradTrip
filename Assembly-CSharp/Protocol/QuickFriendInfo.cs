using System;

namespace Protocol
{
	// Token: 0x02000C86 RID: 3206
	public class QuickFriendInfo : IProtocolStream
	{
		// Token: 0x0600847F RID: 33919 RVA: 0x00173288 File Offset: 0x00171688
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLv);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLv);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.masterNote);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06008480 RID: 33920 RVA: 0x00173374 File Offset: 0x00171774
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
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLv);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLv);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.masterNote = StringHelper.BytesToString(array2);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06008481 RID: 33921 RVA: 0x001734E0 File Offset: 0x001718E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLv);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLv);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.masterNote);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06008482 RID: 33922 RVA: 0x001735D4 File Offset: 0x001719D4
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
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLv);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLv);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.masterNote = StringHelper.BytesToString(array2);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06008483 RID: 33923 RVA: 0x00173740 File Offset: 0x00171B40
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			num += 2;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.masterNote);
			num += 2 + array2.Length;
			num += this.avatar.getLen();
			num++;
			num++;
			num++;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.declaration);
			num += 2 + array3.Length;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04003F62 RID: 16226
		public ulong playerId;

		// Token: 0x04003F63 RID: 16227
		public string name;

		// Token: 0x04003F64 RID: 16228
		public byte occu;

		// Token: 0x04003F65 RID: 16229
		public uint seasonLv;

		// Token: 0x04003F66 RID: 16230
		public ushort level;

		// Token: 0x04003F67 RID: 16231
		public byte vipLv;

		// Token: 0x04003F68 RID: 16232
		public string masterNote;

		// Token: 0x04003F69 RID: 16233
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04003F6A RID: 16234
		public byte activeTimeType;

		// Token: 0x04003F6B RID: 16235
		public byte masterType;

		// Token: 0x04003F6C RID: 16236
		public byte regionId;

		// Token: 0x04003F6D RID: 16237
		public string declaration;

		// Token: 0x04003F6E RID: 16238
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
