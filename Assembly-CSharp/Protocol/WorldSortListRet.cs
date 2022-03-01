using System;

namespace Protocol
{
	// Token: 0x02000B6A RID: 2922
	[Protocol]
	public class WorldSortListRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C5D RID: 31837 RVA: 0x0016330C File Offset: 0x0016170C
		public uint GetMsgID()
		{
			return 602602U;
		}

		// Token: 0x06007C5E RID: 31838 RVA: 0x00163313 File Offset: 0x00161713
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C5F RID: 31839 RVA: 0x0016331B File Offset: 0x0016171B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C60 RID: 31840 RVA: 0x00163324 File Offset: 0x00161724
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007C61 RID: 31841 RVA: 0x00163326 File Offset: 0x00161726
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007C62 RID: 31842 RVA: 0x00163328 File Offset: 0x00161728
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007C63 RID: 31843 RVA: 0x0016332A File Offset: 0x0016172A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007C64 RID: 31844 RVA: 0x0016332C File Offset: 0x0016172C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003AE8 RID: 15080
		public const uint MsgID = 602602U;

		// Token: 0x04003AE9 RID: 15081
		public uint Sequence;
	}
}
