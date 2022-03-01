using System;

namespace Protocol
{
	// Token: 0x02000776 RID: 1910
	[Protocol]
	public class UnionChampionNullTrunNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E36 RID: 24118 RVA: 0x0011A949 File Offset: 0x00118D49
		public uint GetMsgID()
		{
			return 1209816U;
		}

		// Token: 0x06005E37 RID: 24119 RVA: 0x0011A950 File Offset: 0x00118D50
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E38 RID: 24120 RVA: 0x0011A958 File Offset: 0x00118D58
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E39 RID: 24121 RVA: 0x0011A961 File Offset: 0x00118D61
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E3A RID: 24122 RVA: 0x0011A963 File Offset: 0x00118D63
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E3B RID: 24123 RVA: 0x0011A965 File Offset: 0x00118D65
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E3C RID: 24124 RVA: 0x0011A967 File Offset: 0x00118D67
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E3D RID: 24125 RVA: 0x0011A96C File Offset: 0x00118D6C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040026A3 RID: 9891
		public const uint MsgID = 1209816U;

		// Token: 0x040026A4 RID: 9892
		public uint Sequence;
	}
}
