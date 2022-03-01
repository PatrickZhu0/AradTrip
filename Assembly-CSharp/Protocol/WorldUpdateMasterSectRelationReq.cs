using System;

namespace Protocol
{
	// Token: 0x02000CB2 RID: 3250
	[Protocol]
	public class WorldUpdateMasterSectRelationReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085F9 RID: 34297 RVA: 0x00177014 File Offset: 0x00175414
		public uint GetMsgID()
		{
			return 601746U;
		}

		// Token: 0x060085FA RID: 34298 RVA: 0x0017701B File Offset: 0x0017541B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085FB RID: 34299 RVA: 0x00177023 File Offset: 0x00175423
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085FC RID: 34300 RVA: 0x0017702C File Offset: 0x0017542C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085FD RID: 34301 RVA: 0x0017702E File Offset: 0x0017542E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085FE RID: 34302 RVA: 0x00177030 File Offset: 0x00175430
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085FF RID: 34303 RVA: 0x00177032 File Offset: 0x00175432
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008600 RID: 34304 RVA: 0x00177034 File Offset: 0x00175434
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04004025 RID: 16421
		public const uint MsgID = 601746U;

		// Token: 0x04004026 RID: 16422
		public uint Sequence;
	}
}
