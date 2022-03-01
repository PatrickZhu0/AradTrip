using System;

namespace Protocol
{
	// Token: 0x02000B52 RID: 2898
	[Protocol]
	public class WorldAccountShopItemQueryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BA0 RID: 31648 RVA: 0x00161D01 File Offset: 0x00160101
		public uint GetMsgID()
		{
			return 608802U;
		}

		// Token: 0x06007BA1 RID: 31649 RVA: 0x00161D08 File Offset: 0x00160108
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BA2 RID: 31650 RVA: 0x00161D10 File Offset: 0x00160110
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BA3 RID: 31651 RVA: 0x00161D1C File Offset: 0x0016011C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shopItems.Length);
			for (int i = 0; i < this.shopItems.Length; i++)
			{
				this.shopItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.nextGroupOnSaleTime);
		}

		// Token: 0x06007BA4 RID: 31652 RVA: 0x00161D8C File Offset: 0x0016018C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.queryIndex.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shopItems = new AccountShopItemInfo[(int)num];
			for (int i = 0; i < this.shopItems.Length; i++)
			{
				this.shopItems[i] = new AccountShopItemInfo();
				this.shopItems[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.nextGroupOnSaleTime);
		}

		// Token: 0x06007BA5 RID: 31653 RVA: 0x00161E10 File Offset: 0x00160210
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.queryIndex.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shopItems.Length);
			for (int i = 0; i < this.shopItems.Length; i++)
			{
				this.shopItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.nextGroupOnSaleTime);
		}

		// Token: 0x06007BA6 RID: 31654 RVA: 0x00161E80 File Offset: 0x00160280
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.queryIndex.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shopItems = new AccountShopItemInfo[(int)num];
			for (int i = 0; i < this.shopItems.Length; i++)
			{
				this.shopItems[i] = new AccountShopItemInfo();
				this.shopItems[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.nextGroupOnSaleTime);
		}

		// Token: 0x06007BA7 RID: 31655 RVA: 0x00161F04 File Offset: 0x00160304
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += this.queryIndex.getLen();
			num += 2;
			for (int i = 0; i < this.shopItems.Length; i++)
			{
				num += this.shopItems[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x04003A92 RID: 14994
		public const uint MsgID = 608802U;

		// Token: 0x04003A93 RID: 14995
		public uint Sequence;

		// Token: 0x04003A94 RID: 14996
		public uint resCode;

		// Token: 0x04003A95 RID: 14997
		public AccountShopQueryIndex queryIndex = new AccountShopQueryIndex();

		// Token: 0x04003A96 RID: 14998
		public AccountShopItemInfo[] shopItems = new AccountShopItemInfo[0];

		// Token: 0x04003A97 RID: 14999
		public uint nextGroupOnSaleTime;
	}
}
