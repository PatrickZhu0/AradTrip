using System;

namespace Protocol
{
	// Token: 0x02000895 RID: 2197
	[Protocol]
	public class WorldGuildAuctionItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600669A RID: 26266 RVA: 0x0012FF01 File Offset: 0x0012E301
		public uint GetMsgID()
		{
			return 608514U;
		}

		// Token: 0x0600669B RID: 26267 RVA: 0x0012FF08 File Offset: 0x0012E308
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600669C RID: 26268 RVA: 0x0012FF10 File Offset: 0x0012E310
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600669D RID: 26269 RVA: 0x0012FF1C File Offset: 0x0012E31C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.auctionItemList.Length);
			for (int i = 0; i < this.auctionItemList.Length; i++)
			{
				this.auctionItemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600669E RID: 26270 RVA: 0x0012FF70 File Offset: 0x0012E370
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.auctionItemList = new GuildAuctionItem[(int)num];
			for (int i = 0; i < this.auctionItemList.Length; i++)
			{
				this.auctionItemList[i] = new GuildAuctionItem();
				this.auctionItemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600669F RID: 26271 RVA: 0x0012FFD8 File Offset: 0x0012E3D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.auctionItemList.Length);
			for (int i = 0; i < this.auctionItemList.Length; i++)
			{
				this.auctionItemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060066A0 RID: 26272 RVA: 0x0013002C File Offset: 0x0012E42C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.auctionItemList = new GuildAuctionItem[(int)num];
			for (int i = 0; i < this.auctionItemList.Length; i++)
			{
				this.auctionItemList[i] = new GuildAuctionItem();
				this.auctionItemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060066A1 RID: 26273 RVA: 0x00130094 File Offset: 0x0012E494
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.auctionItemList.Length; i++)
			{
				num += this.auctionItemList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DE5 RID: 11749
		public const uint MsgID = 608514U;

		// Token: 0x04002DE6 RID: 11750
		public uint Sequence;

		// Token: 0x04002DE7 RID: 11751
		public uint type;

		// Token: 0x04002DE8 RID: 11752
		public GuildAuctionItem[] auctionItemList = new GuildAuctionItem[0];
	}
}
