using System;

namespace Protocol
{
	// Token: 0x02000A32 RID: 2610
	public class OpActTaskParam : IProtocolStream
	{
		// Token: 0x0600732D RID: 29485 RVA: 0x0014E840 File Offset: 0x0014CC40
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x0600732E RID: 29486 RVA: 0x0014E878 File Offset: 0x0014CC78
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x0600732F RID: 29487 RVA: 0x0014E8D4 File Offset: 0x0014CCD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06007330 RID: 29488 RVA: 0x0014E910 File Offset: 0x0014CD10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06007331 RID: 29489 RVA: 0x0014E96C File Offset: 0x0014CD6C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.key);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x0400357A RID: 13690
		public string key;

		// Token: 0x0400357B RID: 13691
		public uint value;
	}
}
