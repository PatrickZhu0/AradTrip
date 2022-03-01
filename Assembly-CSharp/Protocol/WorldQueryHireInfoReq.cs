using System;

namespace Protocol
{
	// Token: 0x02000C37 RID: 3127
	[Protocol]
	public class WorldQueryHireInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600824E RID: 33358 RVA: 0x0016F41C File Offset: 0x0016D81C
		public uint GetMsgID()
		{
			return 601782U;
		}

		// Token: 0x0600824F RID: 33359 RVA: 0x0016F423 File Offset: 0x0016D823
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008250 RID: 33360 RVA: 0x0016F42B File Offset: 0x0016D82B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008251 RID: 33361 RVA: 0x0016F434 File Offset: 0x0016D834
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008252 RID: 33362 RVA: 0x0016F436 File Offset: 0x0016D836
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008253 RID: 33363 RVA: 0x0016F438 File Offset: 0x0016D838
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008254 RID: 33364 RVA: 0x0016F43A File Offset: 0x0016D83A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008255 RID: 33365 RVA: 0x0016F43C File Offset: 0x0016D83C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E40 RID: 15936
		public const uint MsgID = 601782U;

		// Token: 0x04003E41 RID: 15937
		public uint Sequence;
	}
}
