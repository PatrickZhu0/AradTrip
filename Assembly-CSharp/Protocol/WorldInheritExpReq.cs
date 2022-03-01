using System;

namespace Protocol
{
	// Token: 0x0200069C RID: 1692
	[Protocol]
	public class WorldInheritExpReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600578F RID: 22415 RVA: 0x0010B05C File Offset: 0x0010945C
		public uint GetMsgID()
		{
			return 608607U;
		}

		// Token: 0x06005790 RID: 22416 RVA: 0x0010B063 File Offset: 0x00109463
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005791 RID: 22417 RVA: 0x0010B06B File Offset: 0x0010946B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005792 RID: 22418 RVA: 0x0010B074 File Offset: 0x00109474
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005793 RID: 22419 RVA: 0x0010B076 File Offset: 0x00109476
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005794 RID: 22420 RVA: 0x0010B078 File Offset: 0x00109478
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005795 RID: 22421 RVA: 0x0010B07A File Offset: 0x0010947A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005796 RID: 22422 RVA: 0x0010B07C File Offset: 0x0010947C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040022D1 RID: 8913
		public const uint MsgID = 608607U;

		// Token: 0x040022D2 RID: 8914
		public uint Sequence;
	}
}
