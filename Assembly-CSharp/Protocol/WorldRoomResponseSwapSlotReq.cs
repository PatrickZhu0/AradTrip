using System;

namespace Protocol
{
	// Token: 0x02000AEE RID: 2798
	[Protocol]
	public class WorldRoomResponseSwapSlotReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078A9 RID: 30889 RVA: 0x0015C7F8 File Offset: 0x0015ABF8
		public uint GetMsgID()
		{
			return 607833U;
		}

		// Token: 0x060078AA RID: 30890 RVA: 0x0015C7FF File Offset: 0x0015ABFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078AB RID: 30891 RVA: 0x0015C807 File Offset: 0x0015AC07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078AC RID: 30892 RVA: 0x0015C810 File Offset: 0x0015AC10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotIndex);
		}

		// Token: 0x060078AD RID: 30893 RVA: 0x0015C83C File Offset: 0x0015AC3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotIndex);
		}

		// Token: 0x060078AE RID: 30894 RVA: 0x0015C868 File Offset: 0x0015AC68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotIndex);
		}

		// Token: 0x060078AF RID: 30895 RVA: 0x0015C894 File Offset: 0x0015AC94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotIndex);
		}

		// Token: 0x060078B0 RID: 30896 RVA: 0x0015C8C0 File Offset: 0x0015ACC0
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x040038F3 RID: 14579
		public const uint MsgID = 607833U;

		// Token: 0x040038F4 RID: 14580
		public uint Sequence;

		// Token: 0x040038F5 RID: 14581
		public byte isAccept;

		// Token: 0x040038F6 RID: 14582
		public byte slotGroup;

		// Token: 0x040038F7 RID: 14583
		public byte slotIndex;
	}
}
