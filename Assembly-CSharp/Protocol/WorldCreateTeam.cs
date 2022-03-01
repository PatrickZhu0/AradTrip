using System;

namespace Protocol
{
	// Token: 0x02000B79 RID: 2937
	[Protocol]
	public class WorldCreateTeam : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007CA2 RID: 31906 RVA: 0x00163872 File Offset: 0x00161C72
		public uint GetMsgID()
		{
			return 601610U;
		}

		// Token: 0x06007CA3 RID: 31907 RVA: 0x00163879 File Offset: 0x00161C79
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007CA4 RID: 31908 RVA: 0x00163881 File Offset: 0x00161C81
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007CA5 RID: 31909 RVA: 0x0016388A File Offset: 0x00161C8A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
		}

		// Token: 0x06007CA6 RID: 31910 RVA: 0x0016389A File Offset: 0x00161C9A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007CA7 RID: 31911 RVA: 0x001638AA File Offset: 0x00161CAA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
		}

		// Token: 0x06007CA8 RID: 31912 RVA: 0x001638BA File Offset: 0x00161CBA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007CA9 RID: 31913 RVA: 0x001638CC File Offset: 0x00161CCC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003B15 RID: 15125
		public const uint MsgID = 601610U;

		// Token: 0x04003B16 RID: 15126
		public uint Sequence;

		// Token: 0x04003B17 RID: 15127
		public uint target;
	}
}
