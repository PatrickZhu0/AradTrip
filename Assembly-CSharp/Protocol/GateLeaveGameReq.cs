using System;

namespace Protocol
{
	// Token: 0x020009C6 RID: 2502
	[Protocol]
	public class GateLeaveGameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600701E RID: 28702 RVA: 0x00144C68 File Offset: 0x00143068
		public uint GetMsgID()
		{
			return 300401U;
		}

		// Token: 0x0600701F RID: 28703 RVA: 0x00144C6F File Offset: 0x0014306F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007020 RID: 28704 RVA: 0x00144C77 File Offset: 0x00143077
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007021 RID: 28705 RVA: 0x00144C80 File Offset: 0x00143080
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007022 RID: 28706 RVA: 0x00144C82 File Offset: 0x00143082
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007023 RID: 28707 RVA: 0x00144C84 File Offset: 0x00143084
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007024 RID: 28708 RVA: 0x00144C86 File Offset: 0x00143086
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007025 RID: 28709 RVA: 0x00144C88 File Offset: 0x00143088
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003318 RID: 13080
		public const uint MsgID = 300401U;

		// Token: 0x04003319 RID: 13081
		public uint Sequence;
	}
}
