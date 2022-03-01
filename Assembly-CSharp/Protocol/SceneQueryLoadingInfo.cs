using System;

namespace Protocol
{
	// Token: 0x02000B11 RID: 2833
	[Protocol]
	public class SceneQueryLoadingInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079B1 RID: 31153 RVA: 0x0015E00C File Offset: 0x0015C40C
		public uint GetMsgID()
		{
			return 500118U;
		}

		// Token: 0x060079B2 RID: 31154 RVA: 0x0015E013 File Offset: 0x0015C413
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079B3 RID: 31155 RVA: 0x0015E01B File Offset: 0x0015C41B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079B4 RID: 31156 RVA: 0x0015E024 File Offset: 0x0015C424
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060079B5 RID: 31157 RVA: 0x0015E026 File Offset: 0x0015C426
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060079B6 RID: 31158 RVA: 0x0015E028 File Offset: 0x0015C428
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060079B7 RID: 31159 RVA: 0x0015E02A File Offset: 0x0015C42A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060079B8 RID: 31160 RVA: 0x0015E02C File Offset: 0x0015C42C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003966 RID: 14694
		public const uint MsgID = 500118U;

		// Token: 0x04003967 RID: 14695
		public uint Sequence;
	}
}
