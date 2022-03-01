using System;

namespace Protocol
{
	// Token: 0x020009A3 RID: 2467
	[Protocol]
	public class WorldItemFriendPresentRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F0A RID: 28426 RVA: 0x001410FF File Offset: 0x0013F4FF
		public uint GetMsgID()
		{
			return 609704U;
		}

		// Token: 0x06006F0B RID: 28427 RVA: 0x00141106 File Offset: 0x0013F506
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F0C RID: 28428 RVA: 0x0014110E File Offset: 0x0013F50E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F0D RID: 28429 RVA: 0x00141117 File Offset: 0x0013F517
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			this.presentInfos.encode(buffer, ref pos_);
		}

		// Token: 0x06006F0E RID: 28430 RVA: 0x00141150 File Offset: 0x0013F550
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			this.presentInfos.decode(buffer, ref pos_);
		}

		// Token: 0x06006F0F RID: 28431 RVA: 0x00141189 File Offset: 0x0013F589
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			this.presentInfos.encode(buffer, ref pos_);
		}

		// Token: 0x06006F10 RID: 28432 RVA: 0x001411C2 File Offset: 0x0013F5C2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			this.presentInfos.decode(buffer, ref pos_);
		}

		// Token: 0x06006F11 RID: 28433 RVA: 0x001411FC File Offset: 0x0013F5FC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 4;
			return num + this.presentInfos.getLen();
		}

		// Token: 0x04003260 RID: 12896
		public const uint MsgID = 609704U;

		// Token: 0x04003261 RID: 12897
		public uint Sequence;

		// Token: 0x04003262 RID: 12898
		public uint retCode;

		// Token: 0x04003263 RID: 12899
		public ulong itemId;

		// Token: 0x04003264 RID: 12900
		public uint itemTypeId;

		// Token: 0x04003265 RID: 12901
		public FriendPresentInfo presentInfos = new FriendPresentInfo();
	}
}
