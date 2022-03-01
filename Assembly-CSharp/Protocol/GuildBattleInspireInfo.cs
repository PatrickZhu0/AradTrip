using System;

namespace Protocol
{
	// Token: 0x0200081F RID: 2079
	public class GuildBattleInspireInfo : IProtocolStream
	{
		// Token: 0x060062A7 RID: 25255 RVA: 0x0012786C File Offset: 0x00125C6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.inspireNum);
		}

		// Token: 0x060062A8 RID: 25256 RVA: 0x001278B4 File Offset: 0x00125CB4
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inspireNum);
		}

		// Token: 0x060062A9 RID: 25257 RVA: 0x00127920 File Offset: 0x00125D20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.inspireNum);
		}

		// Token: 0x060062AA RID: 25258 RVA: 0x00127968 File Offset: 0x00125D68
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inspireNum);
		}

		// Token: 0x060062AB RID: 25259 RVA: 0x001279D4 File Offset: 0x00125DD4
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04002C2C RID: 11308
		public ulong playerId;

		// Token: 0x04002C2D RID: 11309
		public string playerName;

		// Token: 0x04002C2E RID: 11310
		public uint inspireNum;
	}
}
