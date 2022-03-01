using System;

namespace Protocol
{
	// Token: 0x0200076B RID: 1899
	public class ChampionGroup : IProtocolStream
	{
		// Token: 0x06005DDF RID: 24031 RVA: 0x00119BEC File Offset: 0x00117FEC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleB);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreA);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreB);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06005DE0 RID: 24032 RVA: 0x00119C50 File Offset: 0x00118050
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleB);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreA);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreB);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06005DE1 RID: 24033 RVA: 0x00119CB4 File Offset: 0x001180B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleA);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleB);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreA);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreB);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
		}

		// Token: 0x06005DE2 RID: 24034 RVA: 0x00119D18 File Offset: 0x00118118
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleA);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleB);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreA);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreB);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06005DE3 RID: 24035 RVA: 0x00119D7C File Offset: 0x0011817C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400267C RID: 9852
		public uint groupID;

		// Token: 0x0400267D RID: 9853
		public ulong roleA;

		// Token: 0x0400267E RID: 9854
		public ulong roleB;

		// Token: 0x0400267F RID: 9855
		public uint scoreA;

		// Token: 0x04002680 RID: 9856
		public uint scoreB;

		// Token: 0x04002681 RID: 9857
		public byte status;
	}
}
