using System;

namespace Protocol
{
	// Token: 0x02000949 RID: 2377
	[Protocol]
	public class PayingGambleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BF5 RID: 27637 RVA: 0x0013AF83 File Offset: 0x00139383
		public uint GetMsgID()
		{
			return 707902U;
		}

		// Token: 0x06006BF6 RID: 27638 RVA: 0x0013AF8A File Offset: 0x0013938A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BF7 RID: 27639 RVA: 0x0013AF92 File Offset: 0x00139392
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BF8 RID: 27640 RVA: 0x0013AF9C File Offset: 0x0013939C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costCurrencyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costCurrencyNum);
			this.itemInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006BF9 RID: 27641 RVA: 0x0013B00C File Offset: 0x0013940C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costCurrencyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costCurrencyNum);
			this.itemInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006BFA RID: 27642 RVA: 0x0013B07C File Offset: 0x0013947C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.investCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costCurrencyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costCurrencyNum);
			this.itemInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006BFB RID: 27643 RVA: 0x0013B0EC File Offset: 0x001394EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.investCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costCurrencyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costCurrencyNum);
			this.itemInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006BFC RID: 27644 RVA: 0x0013B15C File Offset: 0x0013955C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += 4;
			return num + this.itemInfo.getLen();
		}

		// Token: 0x040030E2 RID: 12514
		public const uint MsgID = 707902U;

		// Token: 0x040030E3 RID: 12515
		public uint Sequence;

		// Token: 0x040030E4 RID: 12516
		public uint retCode;

		// Token: 0x040030E5 RID: 12517
		public uint gambingItemId;

		// Token: 0x040030E6 RID: 12518
		public ushort groupId;

		// Token: 0x040030E7 RID: 12519
		public uint investCopies;

		// Token: 0x040030E8 RID: 12520
		public uint costCurrencyId;

		// Token: 0x040030E9 RID: 12521
		public uint costCurrencyNum;

		// Token: 0x040030EA RID: 12522
		public GambingItemInfo itemInfo = new GambingItemInfo();
	}
}
