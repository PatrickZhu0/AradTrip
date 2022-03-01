using System;

namespace Protocol
{
	// Token: 0x020007AF RID: 1967
	public class DungeonStaticValue : IProtocolStream
	{
		// Token: 0x06005FBC RID: 24508 RVA: 0x0011E574 File Offset: 0x0011C974
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.values.Length);
			for (int i = 0; i < this.values.Length; i++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.values[i]);
			}
		}

		// Token: 0x06005FBD RID: 24509 RVA: 0x0011E5BC File Offset: 0x0011C9BC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.values = new int[(int)num];
			for (int i = 0; i < this.values.Length; i++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.values[i]);
			}
		}

		// Token: 0x06005FBE RID: 24510 RVA: 0x0011E610 File Offset: 0x0011CA10
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.values.Length);
			for (int i = 0; i < this.values.Length; i++)
			{
				BaseDLL.encode_int32(buffer, ref pos_, this.values[i]);
			}
		}

		// Token: 0x06005FBF RID: 24511 RVA: 0x0011E658 File Offset: 0x0011CA58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.values = new int[(int)num];
			for (int i = 0; i < this.values.Length; i++)
			{
				BaseDLL.decode_int32(buffer, ref pos_, ref this.values[i]);
			}
		}

		// Token: 0x06005FC0 RID: 24512 RVA: 0x0011E6AC File Offset: 0x0011CAAC
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.values.Length);
		}

		// Token: 0x040027A3 RID: 10147
		public int[] values = new int[0];
	}
}
