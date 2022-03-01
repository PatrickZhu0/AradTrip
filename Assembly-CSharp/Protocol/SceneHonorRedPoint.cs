using System;

namespace Protocol
{
	// Token: 0x020008B1 RID: 2225
	[Protocol]
	public class SceneHonorRedPoint : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006784 RID: 26500 RVA: 0x001316E1 File Offset: 0x0012FAE1
		public uint GetMsgID()
		{
			return 509903U;
		}

		// Token: 0x06006785 RID: 26501 RVA: 0x001316E8 File Offset: 0x0012FAE8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006786 RID: 26502 RVA: 0x001316F0 File Offset: 0x0012FAF0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006787 RID: 26503 RVA: 0x001316F9 File Offset: 0x0012FAF9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006788 RID: 26504 RVA: 0x001316FB File Offset: 0x0012FAFB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006789 RID: 26505 RVA: 0x001316FD File Offset: 0x0012FAFD
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600678A RID: 26506 RVA: 0x001316FF File Offset: 0x0012FAFF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600678B RID: 26507 RVA: 0x00131704 File Offset: 0x0012FB04
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002E4A RID: 11850
		public const uint MsgID = 509903U;

		// Token: 0x04002E4B RID: 11851
		public uint Sequence;
	}
}
