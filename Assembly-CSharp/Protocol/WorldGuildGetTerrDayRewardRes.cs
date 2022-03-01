using System;

namespace Protocol
{
	// Token: 0x0200087E RID: 2174
	[Protocol]
	public class WorldGuildGetTerrDayRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065E0 RID: 26080 RVA: 0x0012E514 File Offset: 0x0012C914
		public uint GetMsgID()
		{
			return 601995U;
		}

		// Token: 0x060065E1 RID: 26081 RVA: 0x0012E51B File Offset: 0x0012C91B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065E2 RID: 26082 RVA: 0x0012E523 File Offset: 0x0012C923
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065E3 RID: 26083 RVA: 0x0012E52C File Offset: 0x0012C92C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060065E4 RID: 26084 RVA: 0x0012E53C File Offset: 0x0012C93C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060065E5 RID: 26085 RVA: 0x0012E54C File Offset: 0x0012C94C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060065E6 RID: 26086 RVA: 0x0012E55C File Offset: 0x0012C95C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060065E7 RID: 26087 RVA: 0x0012E56C File Offset: 0x0012C96C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D99 RID: 11673
		public const uint MsgID = 601995U;

		// Token: 0x04002D9A RID: 11674
		public uint Sequence;

		// Token: 0x04002D9B RID: 11675
		public uint result;
	}
}
