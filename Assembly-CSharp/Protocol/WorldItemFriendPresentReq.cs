using System;

namespace Protocol
{
	// Token: 0x020009A2 RID: 2466
	[Protocol]
	public class WorldItemFriendPresentReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F01 RID: 28417 RVA: 0x00141005 File Offset: 0x0013F405
		public uint GetMsgID()
		{
			return 609703U;
		}

		// Token: 0x06006F02 RID: 28418 RVA: 0x0014100C File Offset: 0x0013F40C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F03 RID: 28419 RVA: 0x00141014 File Offset: 0x0013F414
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F04 RID: 28420 RVA: 0x0014101D File Offset: 0x0013F41D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendId);
		}

		// Token: 0x06006F05 RID: 28421 RVA: 0x00141049 File Offset: 0x0013F449
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendId);
		}

		// Token: 0x06006F06 RID: 28422 RVA: 0x00141075 File Offset: 0x0013F475
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendId);
		}

		// Token: 0x06006F07 RID: 28423 RVA: 0x001410A1 File Offset: 0x0013F4A1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendId);
		}

		// Token: 0x06006F08 RID: 28424 RVA: 0x001410D0 File Offset: 0x0013F4D0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400325B RID: 12891
		public const uint MsgID = 609703U;

		// Token: 0x0400325C RID: 12892
		public uint Sequence;

		// Token: 0x0400325D RID: 12893
		public ulong itemId;

		// Token: 0x0400325E RID: 12894
		public uint itemTypeId;

		// Token: 0x0400325F RID: 12895
		public ulong friendId;
	}
}
