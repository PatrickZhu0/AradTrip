using System;

namespace Protocol
{
	// Token: 0x02000884 RID: 2180
	public class GuildDungeonDamage : IProtocolStream
	{
		// Token: 0x06006610 RID: 26128 RVA: 0x0012EC0C File Offset: 0x0012D00C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
			BaseDLL.encode_uint64(buffer, ref pos_, this.damageVal);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006611 RID: 26129 RVA: 0x0012EC60 File Offset: 0x0012D060
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.damageVal);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x06006612 RID: 26130 RVA: 0x0012ECD8 File Offset: 0x0012D0D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
			BaseDLL.encode_uint64(buffer, ref pos_, this.damageVal);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006613 RID: 26131 RVA: 0x0012ED30 File Offset: 0x0012D130
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.damageVal);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x06006614 RID: 26132 RVA: 0x0012EDA8 File Offset: 0x0012D1A8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			return num + (2 + array.Length);
		}

		// Token: 0x04002DAD RID: 11693
		public uint rank;

		// Token: 0x04002DAE RID: 11694
		public ulong damageVal;

		// Token: 0x04002DAF RID: 11695
		public ulong playerId;

		// Token: 0x04002DB0 RID: 11696
		public string playerName;
	}
}
