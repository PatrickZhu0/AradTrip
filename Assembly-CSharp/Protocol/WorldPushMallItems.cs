using System;

namespace Protocol
{
	// Token: 0x0200091D RID: 2333
	[Protocol]
	public class WorldPushMallItems : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A72 RID: 27250 RVA: 0x001388EE File Offset: 0x00136CEE
		public uint GetMsgID()
		{
			return 602826U;
		}

		// Token: 0x06006A73 RID: 27251 RVA: 0x001388F5 File Offset: 0x00136CF5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A74 RID: 27252 RVA: 0x001388FD File Offset: 0x00136CFD
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A75 RID: 27253 RVA: 0x00138908 File Offset: 0x00136D08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mallItems.Length);
			for (int i = 0; i < this.mallItems.Length; i++)
			{
				this.mallItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A76 RID: 27254 RVA: 0x00138950 File Offset: 0x00136D50
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mallItems = new MallItemInfo[(int)num];
			for (int i = 0; i < this.mallItems.Length; i++)
			{
				this.mallItems[i] = new MallItemInfo();
				this.mallItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A77 RID: 27255 RVA: 0x001389AC File Offset: 0x00136DAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mallItems.Length);
			for (int i = 0; i < this.mallItems.Length; i++)
			{
				this.mallItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A78 RID: 27256 RVA: 0x001389F4 File Offset: 0x00136DF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mallItems = new MallItemInfo[(int)num];
			for (int i = 0; i < this.mallItems.Length; i++)
			{
				this.mallItems[i] = new MallItemInfo();
				this.mallItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A79 RID: 27257 RVA: 0x00138A50 File Offset: 0x00136E50
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.mallItems.Length; i++)
			{
				num += this.mallItems[i].getLen();
			}
			return num;
		}

		// Token: 0x04003041 RID: 12353
		public const uint MsgID = 602826U;

		// Token: 0x04003042 RID: 12354
		public uint Sequence;

		// Token: 0x04003043 RID: 12355
		public MallItemInfo[] mallItems = new MallItemInfo[0];
	}
}
