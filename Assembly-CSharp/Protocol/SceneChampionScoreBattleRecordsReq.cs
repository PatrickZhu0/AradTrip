using System;

namespace Protocol
{
	// Token: 0x02000766 RID: 1894
	[Protocol]
	public class SceneChampionScoreBattleRecordsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DB8 RID: 23992 RVA: 0x001192E4 File Offset: 0x001176E4
		public uint GetMsgID()
		{
			return 509829U;
		}

		// Token: 0x06005DB9 RID: 23993 RVA: 0x001192EB File Offset: 0x001176EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DBA RID: 23994 RVA: 0x001192F3 File Offset: 0x001176F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DBB RID: 23995 RVA: 0x001192FC File Offset: 0x001176FC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005DBC RID: 23996 RVA: 0x001192FE File Offset: 0x001176FE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005DBD RID: 23997 RVA: 0x00119300 File Offset: 0x00117700
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005DBE RID: 23998 RVA: 0x00119302 File Offset: 0x00117702
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005DBF RID: 23999 RVA: 0x00119304 File Offset: 0x00117704
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400266A RID: 9834
		public const uint MsgID = 509829U;

		// Token: 0x0400266B RID: 9835
		public uint Sequence;
	}
}
