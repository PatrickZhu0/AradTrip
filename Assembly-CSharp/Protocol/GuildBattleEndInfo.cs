using System;

namespace Protocol
{
	// Token: 0x02000825 RID: 2085
	public class GuildBattleEndInfo : IProtocolStream
	{
		// Token: 0x060062CB RID: 25291 RVA: 0x00129130 File Offset: 0x00127530
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.terrName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildLeaderName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.guildServerName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062CC RID: 25292 RVA: 0x001291CC File Offset: 0x001275CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.terrName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildLeaderName = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.guildServerName = StringHelper.BytesToString(array4);
		}

		// Token: 0x060062CD RID: 25293 RVA: 0x00129314 File Offset: 0x00127714
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.terrName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildLeaderName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.guildServerName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060062CE RID: 25294 RVA: 0x001293BC File Offset: 0x001277BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.terrName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildLeaderName = StringHelper.BytesToString(array3);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.guildServerName = StringHelper.BytesToString(array4);
		}

		// Token: 0x060062CF RID: 25295 RVA: 0x00129504 File Offset: 0x00127904
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.terrName);
			num += 2 + array.Length;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.guildLeaderName);
			num += 2 + array3.Length;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.guildServerName);
			return num + (2 + array4.Length);
		}

		// Token: 0x04002C62 RID: 11362
		public byte terrId;

		// Token: 0x04002C63 RID: 11363
		public string terrName;

		// Token: 0x04002C64 RID: 11364
		public ulong guildId;

		// Token: 0x04002C65 RID: 11365
		public string guildName;

		// Token: 0x04002C66 RID: 11366
		public string guildLeaderName;

		// Token: 0x04002C67 RID: 11367
		public string guildServerName;
	}
}
