using System;

namespace Protocol
{
	// Token: 0x02000CA8 RID: 3240
	[Protocol]
	public class QueryAddonPayMsg : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600859F RID: 34207 RVA: 0x00176900 File Offset: 0x00174D00
		public uint GetMsgID()
		{
			return 501716U;
		}

		// Token: 0x060085A0 RID: 34208 RVA: 0x00176907 File Offset: 0x00174D07
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085A1 RID: 34209 RVA: 0x0017690F File Offset: 0x00174D0F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085A2 RID: 34210 RVA: 0x00176918 File Offset: 0x00174D18
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085A3 RID: 34211 RVA: 0x0017691A File Offset: 0x00174D1A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085A4 RID: 34212 RVA: 0x0017691C File Offset: 0x00174D1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085A5 RID: 34213 RVA: 0x0017691E File Offset: 0x00174D1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085A6 RID: 34214 RVA: 0x00176920 File Offset: 0x00174D20
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04004006 RID: 16390
		public const uint MsgID = 501716U;

		// Token: 0x04004007 RID: 16391
		public uint Sequence;
	}
}
