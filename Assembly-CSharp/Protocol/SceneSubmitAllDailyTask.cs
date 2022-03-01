using System;

namespace Protocol
{
	// Token: 0x02000C60 RID: 3168
	[Protocol]
	public class SceneSubmitAllDailyTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600836B RID: 33643 RVA: 0x0017174D File Offset: 0x0016FB4D
		public uint GetMsgID()
		{
			return 501132U;
		}

		// Token: 0x0600836C RID: 33644 RVA: 0x00171754 File Offset: 0x0016FB54
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600836D RID: 33645 RVA: 0x0017175C File Offset: 0x0016FB5C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600836E RID: 33646 RVA: 0x00171765 File Offset: 0x0016FB65
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600836F RID: 33647 RVA: 0x00171767 File Offset: 0x0016FB67
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008370 RID: 33648 RVA: 0x00171769 File Offset: 0x0016FB69
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008371 RID: 33649 RVA: 0x0017176B File Offset: 0x0016FB6B
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008372 RID: 33650 RVA: 0x00171770 File Offset: 0x0016FB70
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003EDA RID: 16090
		public const uint MsgID = 501132U;

		// Token: 0x04003EDB RID: 16091
		public uint Sequence;
	}
}
