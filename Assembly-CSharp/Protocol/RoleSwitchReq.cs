using System;

namespace Protocol
{
	// Token: 0x020009CF RID: 2511
	[Protocol]
	public class RoleSwitchReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600706F RID: 28783 RVA: 0x00145448 File Offset: 0x00143848
		public uint GetMsgID()
		{
			return 300319U;
		}

		// Token: 0x06007070 RID: 28784 RVA: 0x0014544F File Offset: 0x0014384F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007071 RID: 28785 RVA: 0x00145457 File Offset: 0x00143857
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007072 RID: 28786 RVA: 0x00145460 File Offset: 0x00143860
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007073 RID: 28787 RVA: 0x00145462 File Offset: 0x00143862
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007074 RID: 28788 RVA: 0x00145464 File Offset: 0x00143864
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007075 RID: 28789 RVA: 0x00145466 File Offset: 0x00143866
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007076 RID: 28790 RVA: 0x00145468 File Offset: 0x00143868
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003338 RID: 13112
		public const uint MsgID = 300319U;

		// Token: 0x04003339 RID: 13113
		public uint Sequence;
	}
}
