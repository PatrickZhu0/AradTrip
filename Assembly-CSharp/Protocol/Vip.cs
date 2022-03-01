using System;

namespace Protocol
{
	// Token: 0x02000C16 RID: 3094
	public class Vip : IProtocolStream
	{
		// Token: 0x0600814F RID: 33103 RVA: 0x0016D634 File Offset: 0x0016BA34
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
		}

		// Token: 0x06008150 RID: 33104 RVA: 0x0016D652 File Offset: 0x0016BA52
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
		}

		// Token: 0x06008151 RID: 33105 RVA: 0x0016D670 File Offset: 0x0016BA70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
		}

		// Token: 0x06008152 RID: 33106 RVA: 0x0016D68E File Offset: 0x0016BA8E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
		}

		// Token: 0x06008153 RID: 33107 RVA: 0x0016D6AC File Offset: 0x0016BAAC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04003DC0 RID: 15808
		public byte level;

		// Token: 0x04003DC1 RID: 15809
		public uint exp;
	}
}
