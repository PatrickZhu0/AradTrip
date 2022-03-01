using System;

namespace Protocol
{
	// Token: 0x02000B4B RID: 2891
	public class ShortcutKeyInfo : IProtocolStream
	{
		// Token: 0x06007B6A RID: 31594 RVA: 0x00160F74 File Offset: 0x0015F374
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.setType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.setValue);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007B6B RID: 31595 RVA: 0x00160FAC File Offset: 0x0015F3AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.setType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.setValue = StringHelper.BytesToString(array);
		}

		// Token: 0x06007B6C RID: 31596 RVA: 0x00161008 File Offset: 0x0015F408
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.setType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.setValue);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007B6D RID: 31597 RVA: 0x00161044 File Offset: 0x0015F444
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.setType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.setValue = StringHelper.BytesToString(array);
		}

		// Token: 0x06007B6E RID: 31598 RVA: 0x001610A0 File Offset: 0x0015F4A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.setValue);
			return num + (2 + array.Length);
		}

		// Token: 0x04003A6D RID: 14957
		public uint setType;

		// Token: 0x04003A6E RID: 14958
		public string setValue;
	}
}
