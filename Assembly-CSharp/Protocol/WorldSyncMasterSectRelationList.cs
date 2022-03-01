using System;

namespace Protocol
{
	// Token: 0x02000CB1 RID: 3249
	[Protocol]
	public class WorldSyncMasterSectRelationList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085F0 RID: 34288 RVA: 0x00176FDC File Offset: 0x001753DC
		public uint GetMsgID()
		{
			return 601745U;
		}

		// Token: 0x060085F1 RID: 34289 RVA: 0x00176FE3 File Offset: 0x001753E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085F2 RID: 34290 RVA: 0x00176FEB File Offset: 0x001753EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085F3 RID: 34291 RVA: 0x00176FF4 File Offset: 0x001753F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085F4 RID: 34292 RVA: 0x00176FF6 File Offset: 0x001753F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085F5 RID: 34293 RVA: 0x00176FF8 File Offset: 0x001753F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085F6 RID: 34294 RVA: 0x00176FFA File Offset: 0x001753FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085F7 RID: 34295 RVA: 0x00176FFC File Offset: 0x001753FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04004023 RID: 16419
		public const uint MsgID = 601745U;

		// Token: 0x04004024 RID: 16420
		public uint Sequence;
	}
}
