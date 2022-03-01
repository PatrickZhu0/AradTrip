using System;

namespace Protocol
{
	// Token: 0x02000850 RID: 2128
	[Protocol]
	public class WorldGuildTableFinish : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006442 RID: 25666 RVA: 0x0012B7A4 File Offset: 0x00129BA4
		public uint GetMsgID()
		{
			return 601940U;
		}

		// Token: 0x06006443 RID: 25667 RVA: 0x0012B7AB File Offset: 0x00129BAB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006444 RID: 25668 RVA: 0x0012B7B3 File Offset: 0x00129BB3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006445 RID: 25669 RVA: 0x0012B7BC File Offset: 0x00129BBC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006446 RID: 25670 RVA: 0x0012B7BE File Offset: 0x00129BBE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006447 RID: 25671 RVA: 0x0012B7C0 File Offset: 0x00129BC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006448 RID: 25672 RVA: 0x0012B7C2 File Offset: 0x00129BC2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006449 RID: 25673 RVA: 0x0012B7C4 File Offset: 0x00129BC4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CEF RID: 11503
		public const uint MsgID = 601940U;

		// Token: 0x04002CF0 RID: 11504
		public uint Sequence;
	}
}
