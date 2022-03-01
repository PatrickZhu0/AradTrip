using System;

namespace Protocol
{
	// Token: 0x02000CB0 RID: 3248
	[Protocol]
	public class WorldSyncMasterSectRelationData : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085E7 RID: 34279 RVA: 0x00176FA4 File Offset: 0x001753A4
		public uint GetMsgID()
		{
			return 601744U;
		}

		// Token: 0x060085E8 RID: 34280 RVA: 0x00176FAB File Offset: 0x001753AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085E9 RID: 34281 RVA: 0x00176FB3 File Offset: 0x001753B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085EA RID: 34282 RVA: 0x00176FBC File Offset: 0x001753BC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085EB RID: 34283 RVA: 0x00176FBE File Offset: 0x001753BE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085EC RID: 34284 RVA: 0x00176FC0 File Offset: 0x001753C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085ED RID: 34285 RVA: 0x00176FC2 File Offset: 0x001753C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085EE RID: 34286 RVA: 0x00176FC4 File Offset: 0x001753C4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04004021 RID: 16417
		public const uint MsgID = 601744U;

		// Token: 0x04004022 RID: 16418
		public uint Sequence;
	}
}
