using System;

namespace Protocol
{
	// Token: 0x0200087A RID: 2170
	[Protocol]
	public class WorldGuildEmblemUpRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065BC RID: 26044 RVA: 0x0012E308 File Offset: 0x0012C708
		public uint GetMsgID()
		{
			return 601991U;
		}

		// Token: 0x060065BD RID: 26045 RVA: 0x0012E30F File Offset: 0x0012C70F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065BE RID: 26046 RVA: 0x0012E317 File Offset: 0x0012C717
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065BF RID: 26047 RVA: 0x0012E320 File Offset: 0x0012C720
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
		}

		// Token: 0x060065C0 RID: 26048 RVA: 0x0012E33E File Offset: 0x0012C73E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
		}

		// Token: 0x060065C1 RID: 26049 RVA: 0x0012E35C File Offset: 0x0012C75C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
		}

		// Token: 0x060065C2 RID: 26050 RVA: 0x0012E37A File Offset: 0x0012C77A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
		}

		// Token: 0x060065C3 RID: 26051 RVA: 0x0012E398 File Offset: 0x0012C798
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D8C RID: 11660
		public const uint MsgID = 601991U;

		// Token: 0x04002D8D RID: 11661
		public uint Sequence;

		// Token: 0x04002D8E RID: 11662
		public uint result;

		// Token: 0x04002D8F RID: 11663
		public uint emblemLevel;
	}
}
