using System;

namespace Protocol
{
	// Token: 0x02000B0A RID: 2826
	[Protocol]
	public class SceneClearRedPoint : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007972 RID: 31090 RVA: 0x0015D93C File Offset: 0x0015BD3C
		public uint GetMsgID()
		{
			return 500617U;
		}

		// Token: 0x06007973 RID: 31091 RVA: 0x0015D943 File Offset: 0x0015BD43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007974 RID: 31092 RVA: 0x0015D94B File Offset: 0x0015BD4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007975 RID: 31093 RVA: 0x0015D954 File Offset: 0x0015BD54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.flag);
		}

		// Token: 0x06007976 RID: 31094 RVA: 0x0015D964 File Offset: 0x0015BD64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.flag);
		}

		// Token: 0x06007977 RID: 31095 RVA: 0x0015D974 File Offset: 0x0015BD74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.flag);
		}

		// Token: 0x06007978 RID: 31096 RVA: 0x0015D984 File Offset: 0x0015BD84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.flag);
		}

		// Token: 0x06007979 RID: 31097 RVA: 0x0015D994 File Offset: 0x0015BD94
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003951 RID: 14673
		public const uint MsgID = 500617U;

		// Token: 0x04003952 RID: 14674
		public uint Sequence;

		// Token: 0x04003953 RID: 14675
		public uint flag;
	}
}
