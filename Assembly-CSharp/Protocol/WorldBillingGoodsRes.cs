using System;

namespace Protocol
{
	// Token: 0x02000C30 RID: 3120
	[Protocol]
	public class WorldBillingGoodsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008218 RID: 33304 RVA: 0x0016EF2C File Offset: 0x0016D32C
		public uint GetMsgID()
		{
			return 604008U;
		}

		// Token: 0x06008219 RID: 33305 RVA: 0x0016EF33 File Offset: 0x0016D333
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600821A RID: 33306 RVA: 0x0016EF3B File Offset: 0x0016D33B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600821B RID: 33307 RVA: 0x0016EF44 File Offset: 0x0016D344
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.goods.Length);
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600821C RID: 33308 RVA: 0x0016EF8C File Offset: 0x0016D38C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.goods = new ChargeGoods[(int)num];
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i] = new ChargeGoods();
				this.goods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600821D RID: 33309 RVA: 0x0016EFE8 File Offset: 0x0016D3E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.goods.Length);
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600821E RID: 33310 RVA: 0x0016F030 File Offset: 0x0016D430
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.goods = new ChargeGoods[(int)num];
			for (int i = 0; i < this.goods.Length; i++)
			{
				this.goods[i] = new ChargeGoods();
				this.goods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600821F RID: 33311 RVA: 0x0016F08C File Offset: 0x0016D48C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.goods.Length; i++)
			{
				num += this.goods[i].getLen();
			}
			return num;
		}

		// Token: 0x04003E2B RID: 15915
		public const uint MsgID = 604008U;

		// Token: 0x04003E2C RID: 15916
		public uint Sequence;

		// Token: 0x04003E2D RID: 15917
		public ChargeGoods[] goods = new ChargeGoods[0];
	}
}
