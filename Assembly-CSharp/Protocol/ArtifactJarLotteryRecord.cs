using System;

namespace Protocol
{
	// Token: 0x0200096A RID: 2410
	public class ArtifactJarLotteryRecord : IProtocolStream
	{
		// Token: 0x06006D1B RID: 27931 RVA: 0x0013D044 File Offset: 0x0013B444
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.recordTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x06006D1C RID: 27932 RVA: 0x0013D0A8 File Offset: 0x0013B4A8
		public void decode(byte[] buffer, ref int pos_)
		{
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
			this.playerName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.recordTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x06006D1D RID: 27933 RVA: 0x0013D15C File Offset: 0x0013B55C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.recordTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
		}

		// Token: 0x06006D1E RID: 27934 RVA: 0x0013D1C4 File Offset: 0x0013B5C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
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
			this.playerName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.recordTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
		}

		// Token: 0x06006D1F RID: 27935 RVA: 0x0013D278 File Offset: 0x0013B678
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.serverName);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array2.Length;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003167 RID: 12647
		public string serverName;

		// Token: 0x04003168 RID: 12648
		public string playerName;

		// Token: 0x04003169 RID: 12649
		public ulong recordTime;

		// Token: 0x0400316A RID: 12650
		public uint itemId;
	}
}
