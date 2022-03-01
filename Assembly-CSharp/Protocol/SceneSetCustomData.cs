using System;

namespace Protocol
{
	// Token: 0x02000B0B RID: 2827
	[Protocol]
	public class SceneSetCustomData : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600797B RID: 31099 RVA: 0x0015D9B0 File Offset: 0x0015BDB0
		public uint GetMsgID()
		{
			return 500620U;
		}

		// Token: 0x0600797C RID: 31100 RVA: 0x0015D9B7 File Offset: 0x0015BDB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600797D RID: 31101 RVA: 0x0015D9BF File Offset: 0x0015BDBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600797E RID: 31102 RVA: 0x0015D9C8 File Offset: 0x0015BDC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.data);
		}

		// Token: 0x0600797F RID: 31103 RVA: 0x0015D9D8 File Offset: 0x0015BDD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data);
		}

		// Token: 0x06007980 RID: 31104 RVA: 0x0015D9E8 File Offset: 0x0015BDE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.data);
		}

		// Token: 0x06007981 RID: 31105 RVA: 0x0015D9F8 File Offset: 0x0015BDF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data);
		}

		// Token: 0x06007982 RID: 31106 RVA: 0x0015DA08 File Offset: 0x0015BE08
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003954 RID: 14676
		public const uint MsgID = 500620U;

		// Token: 0x04003955 RID: 14677
		public uint Sequence;

		// Token: 0x04003956 RID: 14678
		public uint data;
	}
}
