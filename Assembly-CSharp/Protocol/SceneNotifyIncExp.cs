using System;

namespace Protocol
{
	// Token: 0x02000B1C RID: 2844
	[Protocol]
	public class SceneNotifyIncExp : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A0B RID: 31243 RVA: 0x0015EC70 File Offset: 0x0015D070
		public uint GetMsgID()
		{
			return 500632U;
		}

		// Token: 0x06007A0C RID: 31244 RVA: 0x0015EC77 File Offset: 0x0015D077
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A0D RID: 31245 RVA: 0x0015EC7F File Offset: 0x0015D07F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A0E RID: 31246 RVA: 0x0015EC88 File Offset: 0x0015D088
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
			BaseDLL.encode_uint32(buffer, ref pos_, this.incExp);
		}

		// Token: 0x06007A0F RID: 31247 RVA: 0x0015ECB4 File Offset: 0x0015D0B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.incExp);
		}

		// Token: 0x06007A10 RID: 31248 RVA: 0x0015ECE0 File Offset: 0x0015D0E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
			BaseDLL.encode_uint32(buffer, ref pos_, this.incExp);
		}

		// Token: 0x06007A11 RID: 31249 RVA: 0x0015ED0C File Offset: 0x0015D10C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.incExp);
		}

		// Token: 0x06007A12 RID: 31250 RVA: 0x0015ED38 File Offset: 0x0015D138
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400398D RID: 14733
		public const uint MsgID = 500632U;

		// Token: 0x0400398E RID: 14734
		public uint Sequence;

		// Token: 0x0400398F RID: 14735
		public byte reason;

		// Token: 0x04003990 RID: 14736
		public uint value;

		// Token: 0x04003991 RID: 14737
		public uint incExp;
	}
}
