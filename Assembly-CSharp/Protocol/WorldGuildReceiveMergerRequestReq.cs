using System;

namespace Protocol
{
	// Token: 0x0200089F RID: 2207
	[Protocol]
	public class WorldGuildReceiveMergerRequestReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066F4 RID: 26356 RVA: 0x001307D8 File Offset: 0x0012EBD8
		public uint GetMsgID()
		{
			return 601981U;
		}

		// Token: 0x060066F5 RID: 26357 RVA: 0x001307DF File Offset: 0x0012EBDF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066F6 RID: 26358 RVA: 0x001307E7 File Offset: 0x0012EBE7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066F7 RID: 26359 RVA: 0x001307F0 File Offset: 0x0012EBF0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060066F8 RID: 26360 RVA: 0x001307F2 File Offset: 0x0012EBF2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060066F9 RID: 26361 RVA: 0x001307F4 File Offset: 0x0012EBF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060066FA RID: 26362 RVA: 0x001307F6 File Offset: 0x0012EBF6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060066FB RID: 26363 RVA: 0x001307F8 File Offset: 0x0012EBF8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002E0B RID: 11787
		public const uint MsgID = 601981U;

		// Token: 0x04002E0C RID: 11788
		public uint Sequence;
	}
}
