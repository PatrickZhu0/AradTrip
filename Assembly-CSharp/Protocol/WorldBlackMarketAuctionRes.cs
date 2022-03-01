using System;

namespace Protocol
{
	// Token: 0x02000975 RID: 2421
	[Protocol]
	public class WorldBlackMarketAuctionRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D75 RID: 28021 RVA: 0x0013DFE7 File Offset: 0x0013C3E7
		public uint GetMsgID()
		{
			return 609005U;
		}

		// Token: 0x06006D76 RID: 28022 RVA: 0x0013DFEE File Offset: 0x0013C3EE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D77 RID: 28023 RVA: 0x0013DFF6 File Offset: 0x0013C3F6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D78 RID: 28024 RVA: 0x0013DFFF File Offset: 0x0013C3FF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.item.encode(buffer, ref pos_);
		}

		// Token: 0x06006D79 RID: 28025 RVA: 0x0013E01C File Offset: 0x0013C41C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.item.decode(buffer, ref pos_);
		}

		// Token: 0x06006D7A RID: 28026 RVA: 0x0013E039 File Offset: 0x0013C439
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.item.encode(buffer, ref pos_);
		}

		// Token: 0x06006D7B RID: 28027 RVA: 0x0013E056 File Offset: 0x0013C456
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.item.decode(buffer, ref pos_);
		}

		// Token: 0x06006D7C RID: 28028 RVA: 0x0013E074 File Offset: 0x0013C474
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.item.getLen();
		}

		// Token: 0x04003192 RID: 12690
		public const uint MsgID = 609005U;

		// Token: 0x04003193 RID: 12691
		public uint Sequence;

		// Token: 0x04003194 RID: 12692
		public uint code;

		// Token: 0x04003195 RID: 12693
		public BlackMarketAuctionInfo item = new BlackMarketAuctionInfo();
	}
}
