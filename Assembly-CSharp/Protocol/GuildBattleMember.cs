using System;

namespace Protocol
{
	// Token: 0x0200081C RID: 2076
	public class GuildBattleMember : IProtocolStream
	{
		// Token: 0x06006295 RID: 25237 RVA: 0x001270E8 File Offset: 0x001254E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winStreak);
			BaseDLL.encode_uint16(buffer, ref pos_, this.gotScore);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalScore);
		}

		// Token: 0x06006296 RID: 25238 RVA: 0x00127184 File Offset: 0x00125584
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
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.serverName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildName = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winStreak);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.gotScore);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalScore);
		}

		// Token: 0x06006297 RID: 25239 RVA: 0x0012729C File Offset: 0x0012569C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winStreak);
			BaseDLL.encode_uint16(buffer, ref pos_, this.gotScore);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalScore);
		}

		// Token: 0x06006298 RID: 25240 RVA: 0x00127340 File Offset: 0x00125740
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
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.serverName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildName = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winStreak);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.gotScore);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalScore);
		}

		// Token: 0x06006299 RID: 25241 RVA: 0x00127458 File Offset: 0x00125858
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.serverName);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array3.Length;
			num++;
			num += 2;
			return num + 2;
		}

		// Token: 0x04002C1D RID: 11293
		public ulong id;

		// Token: 0x04002C1E RID: 11294
		public string name;

		// Token: 0x04002C1F RID: 11295
		public string serverName;

		// Token: 0x04002C20 RID: 11296
		public string guildName;

		// Token: 0x04002C21 RID: 11297
		public byte winStreak;

		// Token: 0x04002C22 RID: 11298
		public ushort gotScore;

		// Token: 0x04002C23 RID: 11299
		public ushort totalScore;
	}
}
