using System;

namespace Protocol
{
	// Token: 0x02000848 RID: 2120
	[Protocol]
	public class WorldGuildDismissReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063FA RID: 25594 RVA: 0x0012B454 File Offset: 0x00129854
		public uint GetMsgID()
		{
			return 601932U;
		}

		// Token: 0x060063FB RID: 25595 RVA: 0x0012B45B File Offset: 0x0012985B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063FC RID: 25596 RVA: 0x0012B463 File Offset: 0x00129863
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063FD RID: 25597 RVA: 0x0012B46C File Offset: 0x0012986C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063FE RID: 25598 RVA: 0x0012B46E File Offset: 0x0012986E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063FF RID: 25599 RVA: 0x0012B470 File Offset: 0x00129870
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006400 RID: 25600 RVA: 0x0012B472 File Offset: 0x00129872
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006401 RID: 25601 RVA: 0x0012B474 File Offset: 0x00129874
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CD9 RID: 11481
		public const uint MsgID = 601932U;

		// Token: 0x04002CDA RID: 11482
		public uint Sequence;
	}
}
