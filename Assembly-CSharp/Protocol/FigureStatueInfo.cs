using System;

namespace Protocol
{
	// Token: 0x02000824 RID: 2084
	public class FigureStatueInfo : IProtocolStream
	{
		// Token: 0x060062C5 RID: 25285 RVA: 0x00128DFC File Offset: 0x001271FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.statueType);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062C6 RID: 25286 RVA: 0x00128E88 File Offset: 0x00127288
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statueType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
		}

		// Token: 0x060062C7 RID: 25287 RVA: 0x00128F64 File Offset: 0x00127364
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.statueType);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062C8 RID: 25288 RVA: 0x00128FF4 File Offset: 0x001273F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.statueType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
		}

		// Token: 0x060062C9 RID: 25289 RVA: 0x001290D0 File Offset: 0x001274D0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += this.avatar.getLen();
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.guildName);
			return num + (2 + array2.Length);
		}

		// Token: 0x04002C5B RID: 11355
		public uint accId;

		// Token: 0x04002C5C RID: 11356
		public ulong roleId;

		// Token: 0x04002C5D RID: 11357
		public string name;

		// Token: 0x04002C5E RID: 11358
		public byte occu;

		// Token: 0x04002C5F RID: 11359
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04002C60 RID: 11360
		public byte statueType;

		// Token: 0x04002C61 RID: 11361
		public string guildName;
	}
}
