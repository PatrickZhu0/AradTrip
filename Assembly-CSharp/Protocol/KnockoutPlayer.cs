using System;

namespace Protocol
{
	// Token: 0x02000769 RID: 1897
	public class KnockoutPlayer : IProtocolStream
	{
		// Token: 0x06005DD0 RID: 24016 RVA: 0x00119784 File Offset: 0x00117B84
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06005DD1 RID: 24017 RVA: 0x001197F4 File Offset: 0x00117BF4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06005DD2 RID: 24018 RVA: 0x001198B4 File Offset: 0x00117CB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06005DD3 RID: 24019 RVA: 0x0011992C File Offset: 0x00117D2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06005DD4 RID: 24020 RVA: 0x001199EC File Offset: 0x00117DEC
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.server);
			num += 2 + array2.Length;
			return num + 4;
		}

		// Token: 0x04002674 RID: 9844
		public ulong roleID;

		// Token: 0x04002675 RID: 9845
		public string name;

		// Token: 0x04002676 RID: 9846
		public byte occu;

		// Token: 0x04002677 RID: 9847
		public string server;

		// Token: 0x04002678 RID: 9848
		public uint score;
	}
}
