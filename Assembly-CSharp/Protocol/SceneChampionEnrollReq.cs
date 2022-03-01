using System;

namespace Protocol
{
	// Token: 0x02000747 RID: 1863
	[Protocol]
	public class SceneChampionEnrollReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CAD RID: 23725 RVA: 0x00117719 File Offset: 0x00115B19
		public uint GetMsgID()
		{
			return 509802U;
		}

		// Token: 0x06005CAE RID: 23726 RVA: 0x00117720 File Offset: 0x00115B20
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CAF RID: 23727 RVA: 0x00117728 File Offset: 0x00115B28
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CB0 RID: 23728 RVA: 0x00117731 File Offset: 0x00115B31
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CB1 RID: 23729 RVA: 0x00117733 File Offset: 0x00115B33
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CB2 RID: 23730 RVA: 0x00117735 File Offset: 0x00115B35
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CB3 RID: 23731 RVA: 0x00117737 File Offset: 0x00115B37
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CB4 RID: 23732 RVA: 0x0011773C File Offset: 0x00115B3C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040025FD RID: 9725
		public const uint MsgID = 509802U;

		// Token: 0x040025FE RID: 9726
		public uint Sequence;
	}
}
