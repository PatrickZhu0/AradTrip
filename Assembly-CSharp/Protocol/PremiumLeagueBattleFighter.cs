using System;

namespace Protocol
{
	// Token: 0x02000A65 RID: 2661
	public class PremiumLeagueBattleFighter : IProtocolStream
	{
		// Token: 0x060074C2 RID: 29890 RVA: 0x001522C8 File Offset: 0x001506C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x060074C3 RID: 29891 RVA: 0x00152310 File Offset: 0x00150710
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x060074C4 RID: 29892 RVA: 0x0015237C File Offset: 0x0015077C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x060074C5 RID: 29893 RVA: 0x001523C4 File Offset: 0x001507C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x060074C6 RID: 29894 RVA: 0x00152430 File Offset: 0x00150830
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x0400364F RID: 13903
		public ulong id;

		// Token: 0x04003650 RID: 13904
		public string name;

		// Token: 0x04003651 RID: 13905
		public byte occu;
	}
}
