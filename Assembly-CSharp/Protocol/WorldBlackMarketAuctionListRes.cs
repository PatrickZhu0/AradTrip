using System;

namespace Protocol
{
	// Token: 0x02000973 RID: 2419
	[Protocol]
	public class WorldBlackMarketAuctionListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D63 RID: 28003 RVA: 0x0013DD48 File Offset: 0x0013C148
		public uint GetMsgID()
		{
			return 609003U;
		}

		// Token: 0x06006D64 RID: 28004 RVA: 0x0013DD4F File Offset: 0x0013C14F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D65 RID: 28005 RVA: 0x0013DD57 File Offset: 0x0013C157
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D66 RID: 28006 RVA: 0x0013DD60 File Offset: 0x0013C160
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D67 RID: 28007 RVA: 0x0013DDA8 File Offset: 0x0013C1A8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new BlackMarketAuctionInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new BlackMarketAuctionInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D68 RID: 28008 RVA: 0x0013DE04 File Offset: 0x0013C204
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D69 RID: 28009 RVA: 0x0013DE4C File Offset: 0x0013C24C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new BlackMarketAuctionInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new BlackMarketAuctionInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D6A RID: 28010 RVA: 0x0013DEA8 File Offset: 0x0013C2A8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x0400318A RID: 12682
		public const uint MsgID = 609003U;

		// Token: 0x0400318B RID: 12683
		public uint Sequence;

		// Token: 0x0400318C RID: 12684
		public BlackMarketAuctionInfo[] items = new BlackMarketAuctionInfo[0];
	}
}
