using System;

namespace Protocol
{
	// Token: 0x02000C8D RID: 3213
	public class GuildTitle : IProtocolStream
	{
		// Token: 0x060084B5 RID: 33973 RVA: 0x00174108 File Offset: 0x00172508
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
		}

		// Token: 0x060084B6 RID: 33974 RVA: 0x00174140 File Offset: 0x00172540
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
		}

		// Token: 0x060084B7 RID: 33975 RVA: 0x0017419C File Offset: 0x0017259C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
		}

		// Token: 0x060084B8 RID: 33976 RVA: 0x001741D8 File Offset: 0x001725D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
		}

		// Token: 0x060084B9 RID: 33977 RVA: 0x00174234 File Offset: 0x00172634
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x04003F8D RID: 16269
		public string name;

		// Token: 0x04003F8E RID: 16270
		public byte post;
	}
}
