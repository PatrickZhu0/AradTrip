using System;

namespace Protocol
{
	// Token: 0x020006D8 RID: 1752
	[Protocol]
	public class WorldAuctionGetTreasTransactionRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005944 RID: 22852 RVA: 0x0010F5FC File Offset: 0x0010D9FC
		public uint GetMsgID()
		{
			return 603925U;
		}

		// Token: 0x06005945 RID: 22853 RVA: 0x0010F603 File Offset: 0x0010DA03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005946 RID: 22854 RVA: 0x0010F60B File Offset: 0x0010DA0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005947 RID: 22855 RVA: 0x0010F614 File Offset: 0x0010DA14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sales.Length);
			for (int i = 0; i < this.sales.Length; i++)
			{
				this.sales[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buys.Length);
			for (int j = 0; j < this.buys.Length; j++)
			{
				this.buys[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005948 RID: 22856 RVA: 0x0010F694 File Offset: 0x0010DA94
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sales = new AuctionTransaction[(int)num];
			for (int i = 0; i < this.sales.Length; i++)
			{
				this.sales[i] = new AuctionTransaction();
				this.sales[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buys = new AuctionTransaction[(int)num2];
			for (int j = 0; j < this.buys.Length; j++)
			{
				this.buys[j] = new AuctionTransaction();
				this.buys[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005949 RID: 22857 RVA: 0x0010F73C File Offset: 0x0010DB3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sales.Length);
			for (int i = 0; i < this.sales.Length; i++)
			{
				this.sales[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buys.Length);
			for (int j = 0; j < this.buys.Length; j++)
			{
				this.buys[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600594A RID: 22858 RVA: 0x0010F7BC File Offset: 0x0010DBBC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sales = new AuctionTransaction[(int)num];
			for (int i = 0; i < this.sales.Length; i++)
			{
				this.sales[i] = new AuctionTransaction();
				this.sales[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buys = new AuctionTransaction[(int)num2];
			for (int j = 0; j < this.buys.Length; j++)
			{
				this.buys[j] = new AuctionTransaction();
				this.buys[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600594B RID: 22859 RVA: 0x0010F864 File Offset: 0x0010DC64
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.sales.Length; i++)
			{
				num += this.sales[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.buys.Length; j++)
			{
				num += this.buys[j].getLen();
			}
			return num;
		}

		// Token: 0x040023ED RID: 9197
		public const uint MsgID = 603925U;

		// Token: 0x040023EE RID: 9198
		public uint Sequence;

		// Token: 0x040023EF RID: 9199
		public AuctionTransaction[] sales = new AuctionTransaction[0];

		// Token: 0x040023F0 RID: 9200
		public AuctionTransaction[] buys = new AuctionTransaction[0];
	}
}
