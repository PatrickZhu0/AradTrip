using System;

namespace Protocol
{
	// Token: 0x02000887 RID: 2183
	public class GuildDungeonBuff : IProtocolStream
	{
		// Token: 0x06006628 RID: 26152 RVA: 0x0012EFCC File Offset: 0x0012D3CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
		}

		// Token: 0x06006629 RID: 26153 RVA: 0x0012EFEA File Offset: 0x0012D3EA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
		}

		// Token: 0x0600662A RID: 26154 RVA: 0x0012F008 File Offset: 0x0012D408
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffLvl);
		}

		// Token: 0x0600662B RID: 26155 RVA: 0x0012F026 File Offset: 0x0012D426
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffLvl);
		}

		// Token: 0x0600662C RID: 26156 RVA: 0x0012F044 File Offset: 0x0012D444
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002DB6 RID: 11702
		public uint buffId;

		// Token: 0x04002DB7 RID: 11703
		public uint buffLvl;
	}
}
