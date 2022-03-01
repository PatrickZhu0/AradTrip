using System;

namespace Protocol
{
	// Token: 0x02000AEC RID: 2796
	[Protocol]
	public class WorldRoomSwapSlotReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007897 RID: 30871 RVA: 0x0015C65C File Offset: 0x0015AA5C
		public uint GetMsgID()
		{
			return 607831U;
		}

		// Token: 0x06007898 RID: 30872 RVA: 0x0015C663 File Offset: 0x0015AA63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007899 RID: 30873 RVA: 0x0015C66B File Offset: 0x0015AA6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600789A RID: 30874 RVA: 0x0015C674 File Offset: 0x0015AA74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x0600789B RID: 30875 RVA: 0x0015C6A0 File Offset: 0x0015AAA0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x0600789C RID: 30876 RVA: 0x0015C6CC File Offset: 0x0015AACC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
		}

		// Token: 0x0600789D RID: 30877 RVA: 0x0015C6F8 File Offset: 0x0015AAF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
		}

		// Token: 0x0600789E RID: 30878 RVA: 0x0015C724 File Offset: 0x0015AB24
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x040038EA RID: 14570
		public const uint MsgID = 607831U;

		// Token: 0x040038EB RID: 14571
		public uint Sequence;

		// Token: 0x040038EC RID: 14572
		public uint roomId;

		// Token: 0x040038ED RID: 14573
		public byte slotGroup;

		// Token: 0x040038EE RID: 14574
		public byte index;
	}
}
