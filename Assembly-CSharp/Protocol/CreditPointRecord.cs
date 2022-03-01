using System;

namespace Protocol
{
	// Token: 0x02000804 RID: 2052
	public class CreditPointRecord : IProtocolStream
	{
		// Token: 0x06006268 RID: 25192 RVA: 0x00125EA0 File Offset: 0x001242A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.getTimeL);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.transferNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.orderList.Length);
			for (int i = 0; i < this.orderList.Length; i++)
			{
				this.orderList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006269 RID: 25193 RVA: 0x00125F10 File Offset: 0x00124310
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getTimeL);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.transferNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.orderList = new CreditPointOrder[(int)num];
			for (int i = 0; i < this.orderList.Length; i++)
			{
				this.orderList[i] = new CreditPointOrder();
				this.orderList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600626A RID: 25194 RVA: 0x00125F94 File Offset: 0x00124394
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.getTimeL);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.transferNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.orderList.Length);
			for (int i = 0; i < this.orderList.Length; i++)
			{
				this.orderList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600626B RID: 25195 RVA: 0x00126004 File Offset: 0x00124404
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getTimeL);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.transferNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.orderList = new CreditPointOrder[(int)num];
			for (int i = 0; i < this.orderList.Length; i++)
			{
				this.orderList[i] = new CreditPointOrder();
				this.orderList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600626C RID: 25196 RVA: 0x00126088 File Offset: 0x00124488
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.orderList.Length; i++)
			{
				num += this.orderList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002B71 RID: 11121
		public uint getTimeL;

		// Token: 0x04002B72 RID: 11122
		public uint totalNum;

		// Token: 0x04002B73 RID: 11123
		public uint transferNum;

		// Token: 0x04002B74 RID: 11124
		public CreditPointOrder[] orderList = new CreditPointOrder[0];
	}
}
