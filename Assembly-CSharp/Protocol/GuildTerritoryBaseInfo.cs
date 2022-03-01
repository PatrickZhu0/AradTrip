using System;

namespace Protocol
{
	// Token: 0x0200081E RID: 2078
	public class GuildTerritoryBaseInfo : IProtocolStream
	{
		// Token: 0x060062A1 RID: 25249 RVA: 0x001275F0 File Offset: 0x001259F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollSize);
		}

		// Token: 0x060062A2 RID: 25250 RVA: 0x00127654 File Offset: 0x00125A54
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
			this.serverName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollSize);
		}

		// Token: 0x060062A3 RID: 25251 RVA: 0x00127708 File Offset: 0x00125B08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollSize);
		}

		// Token: 0x060062A4 RID: 25252 RVA: 0x00127770 File Offset: 0x00125B70
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
			this.serverName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.guildName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollSize);
		}

		// Token: 0x060062A5 RID: 25253 RVA: 0x00127824 File Offset: 0x00125C24
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.serverName);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array2.Length;
			return num + 4;
		}

		// Token: 0x04002C28 RID: 11304
		public byte terrId;

		// Token: 0x04002C29 RID: 11305
		public string serverName;

		// Token: 0x04002C2A RID: 11306
		public string guildName;

		// Token: 0x04002C2B RID: 11307
		public uint enrollSize;
	}
}
