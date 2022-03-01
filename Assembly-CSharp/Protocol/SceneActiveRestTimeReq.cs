using System;

namespace Protocol
{
	// Token: 0x0200067E RID: 1662
	[Protocol]
	public class SceneActiveRestTimeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005699 RID: 22169 RVA: 0x0010943C File Offset: 0x0010783C
		public uint GetMsgID()
		{
			return 501138U;
		}

		// Token: 0x0600569A RID: 22170 RVA: 0x00109443 File Offset: 0x00107843
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600569B RID: 22171 RVA: 0x0010944B File Offset: 0x0010784B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600569C RID: 22172 RVA: 0x00109454 File Offset: 0x00107854
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600569D RID: 22173 RVA: 0x00109456 File Offset: 0x00107856
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600569E RID: 22174 RVA: 0x00109458 File Offset: 0x00107858
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600569F RID: 22175 RVA: 0x0010945A File Offset: 0x0010785A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060056A0 RID: 22176 RVA: 0x0010945C File Offset: 0x0010785C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002267 RID: 8807
		public const uint MsgID = 501138U;

		// Token: 0x04002268 RID: 8808
		public uint Sequence;
	}
}
