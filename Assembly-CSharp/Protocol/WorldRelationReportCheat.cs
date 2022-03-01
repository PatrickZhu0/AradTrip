using System;

namespace Protocol
{
	// Token: 0x02000CAA RID: 3242
	[Protocol]
	public class WorldRelationReportCheat : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085B1 RID: 34225 RVA: 0x00176A74 File Offset: 0x00174E74
		public uint GetMsgID()
		{
			return 601736U;
		}

		// Token: 0x060085B2 RID: 34226 RVA: 0x00176A7B File Offset: 0x00174E7B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085B3 RID: 34227 RVA: 0x00176A83 File Offset: 0x00174E83
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085B4 RID: 34228 RVA: 0x00176A8C File Offset: 0x00174E8C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085B5 RID: 34229 RVA: 0x00176A8E File Offset: 0x00174E8E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085B6 RID: 34230 RVA: 0x00176A90 File Offset: 0x00174E90
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085B7 RID: 34231 RVA: 0x00176A92 File Offset: 0x00174E92
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085B8 RID: 34232 RVA: 0x00176A94 File Offset: 0x00174E94
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400400B RID: 16395
		public const uint MsgID = 601736U;

		// Token: 0x0400400C RID: 16396
		public uint Sequence;
	}
}
