using System;

namespace Protocol
{
	// Token: 0x02000894 RID: 2196
	public class GuildAuctionItem : IProtocolStream
	{
		// Token: 0x06006694 RID: 26260 RVA: 0x0012FBCC File Offset: 0x0012DFCC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bidRoleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bidPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fixPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemList.Length);
			for (int i = 0; i < this.itemList.Length; i++)
			{
				this.itemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006695 RID: 26261 RVA: 0x0012FC74 File Offset: 0x0012E074
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bidRoleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bidPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fixPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemList = new ItemReward[(int)num];
			for (int i = 0; i < this.itemList.Length; i++)
			{
				this.itemList[i] = new ItemReward();
				this.itemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006696 RID: 26262 RVA: 0x0012FD30 File Offset: 0x0012E130
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bidRoleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bidPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fixPrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.state);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemList.Length);
			for (int i = 0; i < this.itemList.Length; i++)
			{
				this.itemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006697 RID: 26263 RVA: 0x0012FDD8 File Offset: 0x0012E1D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bidRoleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bidPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fixPrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.state);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemList = new ItemReward[(int)num];
			for (int i = 0; i < this.itemList.Length; i++)
			{
				this.itemList[i] = new ItemReward();
				this.itemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006698 RID: 26264 RVA: 0x0012FE94 File Offset: 0x0012E294
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.itemList.Length; i++)
			{
				num += this.itemList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DDD RID: 11741
		public ulong guid;

		// Token: 0x04002DDE RID: 11742
		public ulong bidRoleId;

		// Token: 0x04002DDF RID: 11743
		public uint curPrice;

		// Token: 0x04002DE0 RID: 11744
		public uint bidPrice;

		// Token: 0x04002DE1 RID: 11745
		public uint fixPrice;

		// Token: 0x04002DE2 RID: 11746
		public uint endTime;

		// Token: 0x04002DE3 RID: 11747
		public uint state;

		// Token: 0x04002DE4 RID: 11748
		public ItemReward[] itemList = new ItemReward[0];
	}
}
