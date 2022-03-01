using System;

namespace Protocol
{
	// Token: 0x020008D7 RID: 2263
	[Protocol]
	public class SceneSynItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x060067FF RID: 26623 RVA: 0x00134F09 File Offset: 0x00133309
		public uint GetMsgID()
		{
			return 500905U;
		}

		// Token: 0x06006800 RID: 26624 RVA: 0x00134F10 File Offset: 0x00133310
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006801 RID: 26625 RVA: 0x00134F18 File Offset: 0x00133318
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006802 RID: 26626 RVA: 0x00134F21 File Offset: 0x00133321
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006803 RID: 26627 RVA: 0x00134F23 File Offset: 0x00133323
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006804 RID: 26628 RVA: 0x00134F25 File Offset: 0x00133325
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006805 RID: 26629 RVA: 0x00134F27 File Offset: 0x00133327
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006806 RID: 26630 RVA: 0x00134F2C File Offset: 0x0013332C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F3B RID: 12091
		public const uint MsgID = 500905U;

		// Token: 0x04002F3C RID: 12092
		public uint Sequence;
	}
}
