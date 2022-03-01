using System;

namespace Protocol
{
	// Token: 0x020006E9 RID: 1769
	public class SockAddr : IProtocolStream
	{
		// Token: 0x060059BF RID: 22975 RVA: 0x00110934 File Offset: 0x0010ED34
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.ip);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.port);
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x0011096C File Offset: 0x0010ED6C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.ip = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.port);
		}

		// Token: 0x060059C1 RID: 22977 RVA: 0x001109C8 File Offset: 0x0010EDC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.ip);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.port);
		}

		// Token: 0x060059C2 RID: 22978 RVA: 0x00110A04 File Offset: 0x0010EE04
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.ip = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.port);
		}

		// Token: 0x060059C3 RID: 22979 RVA: 0x00110A60 File Offset: 0x0010EE60
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.ip);
			num += 2 + array.Length;
			return num + 2;
		}

		// Token: 0x0400243F RID: 9279
		public string ip;

		// Token: 0x04002440 RID: 9280
		public ushort port;
	}
}
