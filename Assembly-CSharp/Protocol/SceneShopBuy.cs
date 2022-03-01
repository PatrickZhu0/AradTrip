using System;

namespace Protocol
{
	// Token: 0x020008EE RID: 2286
	[Protocol]
	public class SceneShopBuy : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068CE RID: 26830 RVA: 0x00135F28 File Offset: 0x00134328
		public uint GetMsgID()
		{
			return 500924U;
		}

		// Token: 0x060068CF RID: 26831 RVA: 0x00135F2F File Offset: 0x0013432F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068D0 RID: 26832 RVA: 0x00135F37 File Offset: 0x00134337
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068D1 RID: 26833 RVA: 0x00135F40 File Offset: 0x00134340
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.costExtraItems.Length);
			for (int i = 0; i < this.costExtraItems.Length; i++)
			{
				this.costExtraItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060068D2 RID: 26834 RVA: 0x00135FB0 File Offset: 0x001343B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.costExtraItems = new ItemInfo[(int)num];
			for (int i = 0; i < this.costExtraItems.Length; i++)
			{
				this.costExtraItems[i] = new ItemInfo();
				this.costExtraItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060068D3 RID: 26835 RVA: 0x00136034 File Offset: 0x00134434
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.shopId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.costExtraItems.Length);
			for (int i = 0; i < this.costExtraItems.Length; i++)
			{
				this.costExtraItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060068D4 RID: 26836 RVA: 0x001360A4 File Offset: 0x001344A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.shopId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.costExtraItems = new ItemInfo[(int)num];
			for (int i = 0; i < this.costExtraItems.Length; i++)
			{
				this.costExtraItems[i] = new ItemInfo();
				this.costExtraItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060068D5 RID: 26837 RVA: 0x00136128 File Offset: 0x00134528
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 2;
			num += 2;
			for (int i = 0; i < this.costExtraItems.Length; i++)
			{
				num += this.costExtraItems[i].getLen();
			}
			return num;
		}

		// Token: 0x04002F89 RID: 12169
		public const uint MsgID = 500924U;

		// Token: 0x04002F8A RID: 12170
		public uint Sequence;

		// Token: 0x04002F8B RID: 12171
		public byte shopId;

		// Token: 0x04002F8C RID: 12172
		public uint shopItemId;

		// Token: 0x04002F8D RID: 12173
		public ushort num;

		// Token: 0x04002F8E RID: 12174
		public ItemInfo[] costExtraItems = new ItemInfo[0];
	}
}
