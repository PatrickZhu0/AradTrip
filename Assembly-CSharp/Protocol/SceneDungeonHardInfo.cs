using System;

namespace Protocol
{
	// Token: 0x020007AE RID: 1966
	public class SceneDungeonHardInfo : IProtocolStream
	{
		// Token: 0x06005FB6 RID: 24502 RVA: 0x0011E4CE File Offset: 0x0011C8CE
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.unlockedHardType);
		}

		// Token: 0x06005FB7 RID: 24503 RVA: 0x0011E4EC File Offset: 0x0011C8EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.unlockedHardType);
		}

		// Token: 0x06005FB8 RID: 24504 RVA: 0x0011E50A File Offset: 0x0011C90A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.unlockedHardType);
		}

		// Token: 0x06005FB9 RID: 24505 RVA: 0x0011E528 File Offset: 0x0011C928
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.unlockedHardType);
		}

		// Token: 0x06005FBA RID: 24506 RVA: 0x0011E548 File Offset: 0x0011C948
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x040027A1 RID: 10145
		public uint id;

		// Token: 0x040027A2 RID: 10146
		public byte unlockedHardType;
	}
}
