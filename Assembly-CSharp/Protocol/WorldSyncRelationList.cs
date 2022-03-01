using System;

namespace Protocol
{
	// Token: 0x02000C82 RID: 3202
	[Protocol]
	public class WorldSyncRelationList : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600845B RID: 33883 RVA: 0x00172FDC File Offset: 0x001713DC
		public uint GetMsgID()
		{
			return 601708U;
		}

		// Token: 0x0600845C RID: 33884 RVA: 0x00172FE3 File Offset: 0x001713E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600845D RID: 33885 RVA: 0x00172FEB File Offset: 0x001713EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600845E RID: 33886 RVA: 0x00172FF4 File Offset: 0x001713F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600845F RID: 33887 RVA: 0x00172FF6 File Offset: 0x001713F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008460 RID: 33888 RVA: 0x00172FF8 File Offset: 0x001713F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008461 RID: 33889 RVA: 0x00172FFA File Offset: 0x001713FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008462 RID: 33890 RVA: 0x00172FFC File Offset: 0x001713FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003F56 RID: 16214
		public const uint MsgID = 601708U;

		// Token: 0x04003F57 RID: 16215
		public uint Sequence;
	}
}
