using System;

namespace Protocol
{
	// Token: 0x020006CC RID: 1740
	[Protocol]
	public class WorldAuctionItemNumRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060058DB RID: 22747 RVA: 0x0010E642 File Offset: 0x0010CA42
		public uint GetMsgID()
		{
			return 603921U;
		}

		// Token: 0x060058DC RID: 22748 RVA: 0x0010E649 File Offset: 0x0010CA49
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060058DD RID: 22749 RVA: 0x0010E651 File Offset: 0x0010CA51
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060058DE RID: 22750 RVA: 0x0010E65C File Offset: 0x0010CA5C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060058DF RID: 22751 RVA: 0x0010E6B0 File Offset: 0x0010CAB0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new AuctionItemBaseInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new AuctionItemBaseInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060058E0 RID: 22752 RVA: 0x0010E718 File Offset: 0x0010CB18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060058E1 RID: 22753 RVA: 0x0010E76C File Offset: 0x0010CB6C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new AuctionItemBaseInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new AuctionItemBaseInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060058E2 RID: 22754 RVA: 0x0010E7D4 File Offset: 0x0010CBD4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x040023AC RID: 9132
		public const uint MsgID = 603921U;

		// Token: 0x040023AD RID: 9133
		public uint Sequence;

		// Token: 0x040023AE RID: 9134
		public byte goodState;

		// Token: 0x040023AF RID: 9135
		public AuctionItemBaseInfo[] items = new AuctionItemBaseInfo[0];
	}
}
