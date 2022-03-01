using System;

namespace Protocol
{
	// Token: 0x0200075C RID: 1884
	public class RankRole : IProtocolStream
	{
		// Token: 0x06005D64 RID: 23908 RVA: 0x00118738 File Offset: 0x00116B38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005D65 RID: 23909 RVA: 0x0011879C File Offset: 0x00116B9C
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
		}

		// Token: 0x06005D66 RID: 23910 RVA: 0x00118850 File Offset: 0x00116C50
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005D67 RID: 23911 RVA: 0x001188B8 File Offset: 0x00116CB8
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
		}

		// Token: 0x06005D68 RID: 23912 RVA: 0x0011896C File Offset: 0x00116D6C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.server);
			return num + (2 + array2.Length);
		}

		// Token: 0x04002647 RID: 9799
		public ulong roleID;

		// Token: 0x04002648 RID: 9800
		public string name;

		// Token: 0x04002649 RID: 9801
		public uint score;

		// Token: 0x0400264A RID: 9802
		public string server;
	}
}
