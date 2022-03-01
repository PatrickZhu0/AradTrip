using System;

namespace Protocol
{
	// Token: 0x020006C0 RID: 1728
	[Protocol]
	public class WorldAuctionListQueryRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600586F RID: 22639 RVA: 0x0010D934 File Offset: 0x0010BD34
		public uint GetMsgID()
		{
			return 603902U;
		}

		// Token: 0x06005870 RID: 22640 RVA: 0x0010D93B File Offset: 0x0010BD3B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005871 RID: 22641 RVA: 0x0010D943 File Offset: 0x0010BD43
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005872 RID: 22642 RVA: 0x0010D94C File Offset: 0x0010BD4C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxPage);
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
		}

		// Token: 0x06005873 RID: 22643 RVA: 0x0010D9D8 File Offset: 0x0010BDD8
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxPage);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
		}

		// Token: 0x06005874 RID: 22644 RVA: 0x0010DA78 File Offset: 0x0010BE78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.curPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxPage);
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
		}

		// Token: 0x06005875 RID: 22645 RVA: 0x0010DB04 File Offset: 0x0010BF04
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxPage);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
		}

		// Token: 0x06005876 RID: 22646 RVA: 0x0010DBA4 File Offset: 0x0010BFA4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			num += 4;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x04002373 RID: 9075
		public const uint MsgID = 603902U;

		// Token: 0x04002374 RID: 9076
		public uint Sequence;

		// Token: 0x04002375 RID: 9077
		public byte type;

		// Token: 0x04002376 RID: 9078
		public AuctionBaseInfo[] data = new AuctionBaseInfo[0];

		// Token: 0x04002377 RID: 9079
		public uint curPage;

		// Token: 0x04002378 RID: 9080
		public uint maxPage;

		// Token: 0x04002379 RID: 9081
		public byte goodState;

		// Token: 0x0400237A RID: 9082
		public byte attent;
	}
}
