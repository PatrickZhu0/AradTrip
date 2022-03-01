using System;

namespace Protocol
{
	// Token: 0x020006E3 RID: 1763
	[Protocol]
	public class WorldAuctionQueryItemTransListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059A4 RID: 22948 RVA: 0x001105C0 File Offset: 0x0010E9C0
		public uint GetMsgID()
		{
			return 603936U;
		}

		// Token: 0x060059A5 RID: 22949 RVA: 0x001105C7 File Offset: 0x0010E9C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059A6 RID: 22950 RVA: 0x001105CF File Offset: 0x0010E9CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059A7 RID: 22951 RVA: 0x001105D8 File Offset: 0x0010E9D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadBuffId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.transList.Length);
			for (int i = 0; i < this.transList.Length; i++)
			{
				this.transList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060059A8 RID: 22952 RVA: 0x00110664 File Offset: 0x0010EA64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadBuffId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.transList = new AuctionTransaction[(int)num];
			for (int i = 0; i < this.transList.Length; i++)
			{
				this.transList[i] = new AuctionTransaction();
				this.transList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060059A9 RID: 22953 RVA: 0x00110704 File Offset: 0x0010EB04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.enhanceType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beadBuffId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.transList.Length);
			for (int i = 0; i < this.transList.Length; i++)
			{
				this.transList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060059AA RID: 22954 RVA: 0x00110790 File Offset: 0x0010EB90
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enhanceType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beadBuffId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.transList = new AuctionTransaction[(int)num];
			for (int i = 0; i < this.transList.Length; i++)
			{
				this.transList[i] = new AuctionTransaction();
				this.transList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060059AB RID: 22955 RVA: 0x00110830 File Offset: 0x0010EC30
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 2;
			for (int i = 0; i < this.transList.Length; i++)
			{
				num += this.transList[i].getLen();
			}
			return num;
		}

		// Token: 0x0400241D RID: 9245
		public const uint MsgID = 603936U;

		// Token: 0x0400241E RID: 9246
		public uint Sequence;

		// Token: 0x0400241F RID: 9247
		public uint code;

		// Token: 0x04002420 RID: 9248
		public uint itemTypeId;

		// Token: 0x04002421 RID: 9249
		public uint strengthen;

		// Token: 0x04002422 RID: 9250
		public byte enhanceType;

		// Token: 0x04002423 RID: 9251
		public uint beadBuffId;

		// Token: 0x04002424 RID: 9252
		public AuctionTransaction[] transList = new AuctionTransaction[0];
	}
}
