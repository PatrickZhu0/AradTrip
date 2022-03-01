using System;

namespace Protocol
{
	// Token: 0x02000881 RID: 2177
	public class GuildDungeonClearGateTime : IProtocolStream
	{
		// Token: 0x060065F8 RID: 26104 RVA: 0x0012E694 File Offset: 0x0012CA94
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.spendTime);
		}

		// Token: 0x060065F9 RID: 26105 RVA: 0x0012E6CC File Offset: 0x0012CACC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.guildName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.spendTime);
		}

		// Token: 0x060065FA RID: 26106 RVA: 0x0012E728 File Offset: 0x0012CB28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.spendTime);
		}

		// Token: 0x060065FB RID: 26107 RVA: 0x0012E764 File Offset: 0x0012CB64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.guildName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.spendTime);
		}

		// Token: 0x060065FC RID: 26108 RVA: 0x0012E7C0 File Offset: 0x0012CBC0
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array.Length;
			return num + 8;
		}

		// Token: 0x04002DA1 RID: 11681
		public string guildName;

		// Token: 0x04002DA2 RID: 11682
		public ulong spendTime;
	}
}
