using System;

namespace Protocol
{
	// Token: 0x02000913 RID: 2323
	[Protocol]
	public class CWMallBatchBuyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A1B RID: 27163 RVA: 0x00137F88 File Offset: 0x00136388
		public uint GetMsgID()
		{
			return 602812U;
		}

		// Token: 0x06006A1C RID: 27164 RVA: 0x00137F8F File Offset: 0x0013638F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A1D RID: 27165 RVA: 0x00137F97 File Offset: 0x00136397
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A1E RID: 27166 RVA: 0x00137FA0 File Offset: 0x001363A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A1F RID: 27167 RVA: 0x00137FE8 File Offset: 0x001363E8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A20 RID: 27168 RVA: 0x00138044 File Offset: 0x00136444
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A21 RID: 27169 RVA: 0x0013808C File Offset: 0x0013648C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A22 RID: 27170 RVA: 0x001380E8 File Offset: 0x001364E8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04003020 RID: 12320
		public const uint MsgID = 602812U;

		// Token: 0x04003021 RID: 12321
		public uint Sequence;

		// Token: 0x04003022 RID: 12322
		public ItemReward[] items = new ItemReward[0];
	}
}
