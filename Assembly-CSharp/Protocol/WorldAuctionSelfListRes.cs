using System;

namespace Protocol
{
	// Token: 0x020006C2 RID: 1730
	[Protocol]
	public class WorldAuctionSelfListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005881 RID: 22657 RVA: 0x0010DC80 File Offset: 0x0010C080
		public uint GetMsgID()
		{
			return 603905U;
		}

		// Token: 0x06005882 RID: 22658 RVA: 0x0010DC87 File Offset: 0x0010C087
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005883 RID: 22659 RVA: 0x0010DC8F File Offset: 0x0010C08F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005884 RID: 22660 RVA: 0x0010DC98 File Offset: 0x0010C098
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005885 RID: 22661 RVA: 0x0010DCEC File Offset: 0x0010C0EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new AuctionBaseInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005886 RID: 22662 RVA: 0x0010DD54 File Offset: 0x0010C154
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005887 RID: 22663 RVA: 0x0010DDA8 File Offset: 0x0010C1A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new AuctionBaseInfo[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new AuctionBaseInfo();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005888 RID: 22664 RVA: 0x0010DE10 File Offset: 0x0010C210
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			return num;
		}

		// Token: 0x0400237E RID: 9086
		public const uint MsgID = 603905U;

		// Token: 0x0400237F RID: 9087
		public uint Sequence;

		// Token: 0x04002380 RID: 9088
		public byte type;

		// Token: 0x04002381 RID: 9089
		public AuctionBaseInfo[] data = new AuctionBaseInfo[0];
	}
}
