using System;

namespace Protocol
{
	// Token: 0x02000C2F RID: 3119
	[Protocol]
	public class WorldBillingGoodsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600820F RID: 33295 RVA: 0x0016EEE5 File Offset: 0x0016D2E5
		public uint GetMsgID()
		{
			return 604007U;
		}

		// Token: 0x06008210 RID: 33296 RVA: 0x0016EEEC File Offset: 0x0016D2EC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008211 RID: 33297 RVA: 0x0016EEF4 File Offset: 0x0016D2F4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008212 RID: 33298 RVA: 0x0016EEFD File Offset: 0x0016D2FD
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008213 RID: 33299 RVA: 0x0016EEFF File Offset: 0x0016D2FF
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008214 RID: 33300 RVA: 0x0016EF01 File Offset: 0x0016D301
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008215 RID: 33301 RVA: 0x0016EF03 File Offset: 0x0016D303
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008216 RID: 33302 RVA: 0x0016EF08 File Offset: 0x0016D308
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E29 RID: 15913
		public const uint MsgID = 604007U;

		// Token: 0x04003E2A RID: 15914
		public uint Sequence;
	}
}
