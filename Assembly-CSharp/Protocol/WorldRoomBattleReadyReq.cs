using System;

namespace Protocol
{
	// Token: 0x02000AF4 RID: 2804
	[Protocol]
	public class WorldRoomBattleReadyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078DF RID: 30943 RVA: 0x0015CAB0 File Offset: 0x0015AEB0
		public uint GetMsgID()
		{
			return 607839U;
		}

		// Token: 0x060078E0 RID: 30944 RVA: 0x0015CAB7 File Offset: 0x0015AEB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078E1 RID: 30945 RVA: 0x0015CABF File Offset: 0x0015AEBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078E2 RID: 30946 RVA: 0x0015CAC8 File Offset: 0x0015AEC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slotStatus);
		}

		// Token: 0x060078E3 RID: 30947 RVA: 0x0015CAD8 File Offset: 0x0015AED8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotStatus);
		}

		// Token: 0x060078E4 RID: 30948 RVA: 0x0015CAE8 File Offset: 0x0015AEE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slotStatus);
		}

		// Token: 0x060078E5 RID: 30949 RVA: 0x0015CAF8 File Offset: 0x0015AEF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotStatus);
		}

		// Token: 0x060078E6 RID: 30950 RVA: 0x0015CB08 File Offset: 0x0015AF08
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003905 RID: 14597
		public const uint MsgID = 607839U;

		// Token: 0x04003906 RID: 14598
		public uint Sequence;

		// Token: 0x04003907 RID: 14599
		public byte slotStatus;
	}
}
