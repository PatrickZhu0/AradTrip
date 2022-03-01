using System;

namespace Protocol
{
	// Token: 0x020006DE RID: 1758
	[Protocol]
	public class WorldAuctionQueryItemPriceListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600597A RID: 22906 RVA: 0x0010FF00 File Offset: 0x0010E300
		public uint GetMsgID()
		{
			return 603932U;
		}

		// Token: 0x0600597B RID: 22907 RVA: 0x0010FF07 File Offset: 0x0010E307
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600597C RID: 22908 RVA: 0x0010FF0F File Offset: 0x0010E30F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600597D RID: 22909 RVA: 0x0010FF18 File Offset: 0x0010E318
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.auctionState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actionItems.Length);
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600597E RID: 22910 RVA: 0x0010FF98 File Offset: 0x0010E398
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.auctionState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.actionItems = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i] = new AuctionBaseInfo();
				this.actionItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600597F RID: 22911 RVA: 0x0011002C File Offset: 0x0010E42C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.auctionState);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actionItems.Length);
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005980 RID: 22912 RVA: 0x001100AC File Offset: 0x0010E4AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.auctionState);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.actionItems = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				this.actionItems[i] = new AuctionBaseInfo();
				this.actionItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005981 RID: 22913 RVA: 0x00110140 File Offset: 0x0010E540
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.actionItems.Length; i++)
			{
				num += this.actionItems[i].getLen();
			}
			return num;
		}

		// Token: 0x04002407 RID: 9223
		public const uint MsgID = 603932U;

		// Token: 0x04002408 RID: 9224
		public uint Sequence;

		// Token: 0x04002409 RID: 9225
		public byte type;

		// Token: 0x0400240A RID: 9226
		public byte auctionState;

		// Token: 0x0400240B RID: 9227
		public uint itemTypeId;

		// Token: 0x0400240C RID: 9228
		public uint strengthen;

		// Token: 0x0400240D RID: 9229
		public AuctionBaseInfo[] actionItems = new AuctionBaseInfo[0];
	}
}
