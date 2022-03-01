using System;

namespace Protocol
{
	// Token: 0x0200068E RID: 1678
	[Protocol]
	public class SceneSecretCoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005726 RID: 22310 RVA: 0x0010A1B8 File Offset: 0x001085B8
		public uint GetMsgID()
		{
			return 501167U;
		}

		// Token: 0x06005727 RID: 22311 RVA: 0x0010A1BF File Offset: 0x001085BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005728 RID: 22312 RVA: 0x0010A1C7 File Offset: 0x001085C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005729 RID: 22313 RVA: 0x0010A1D0 File Offset: 0x001085D0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600572A RID: 22314 RVA: 0x0010A1D2 File Offset: 0x001085D2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600572B RID: 22315 RVA: 0x0010A1D4 File Offset: 0x001085D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600572C RID: 22316 RVA: 0x0010A1D6 File Offset: 0x001085D6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600572D RID: 22317 RVA: 0x0010A1D8 File Offset: 0x001085D8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400229B RID: 8859
		public const uint MsgID = 501167U;

		// Token: 0x0400229C RID: 8860
		public uint Sequence;
	}
}
