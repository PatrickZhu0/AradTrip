using System;

namespace Protocol
{
	// Token: 0x020007B8 RID: 1976
	public class DungeonBuff : IProtocolStream
	{
		// Token: 0x06005FFB RID: 24571 RVA: 0x0011F8E2 File Offset: 0x0011DCE2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
		}

		// Token: 0x06005FFC RID: 24572 RVA: 0x0011F900 File Offset: 0x0011DD00
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
		}

		// Token: 0x06005FFD RID: 24573 RVA: 0x0011F91E File Offset: 0x0011DD1E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
		}

		// Token: 0x06005FFE RID: 24574 RVA: 0x0011F93C File Offset: 0x0011DD3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
		}

		// Token: 0x06005FFF RID: 24575 RVA: 0x0011F95C File Offset: 0x0011DD5C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040027C5 RID: 10181
		public uint buffId;

		// Token: 0x040027C6 RID: 10182
		public uint buffLvl;
	}
}
