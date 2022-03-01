using System;

namespace Protocol
{
	// Token: 0x020007FB RID: 2043
	[Protocol]
	public class UnionGoldConsignmentDealRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600621D RID: 25117 RVA: 0x001253B8 File Offset: 0x001237B8
		public uint GetMsgID()
		{
			return 1210104U;
		}

		// Token: 0x0600621E RID: 25118 RVA: 0x001253BF File Offset: 0x001237BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600621F RID: 25119 RVA: 0x001253C7 File Offset: 0x001237C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006220 RID: 25120 RVA: 0x001253D0 File Offset: 0x001237D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sellRecord.Length);
			for (int i = 0; i < this.sellRecord.Length; i++)
			{
				this.sellRecord[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyRecord.Length);
			for (int j = 0; j < this.buyRecord.Length; j++)
			{
				this.buyRecord[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006221 RID: 25121 RVA: 0x00125450 File Offset: 0x00123850
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellRecord = new GoldConsignmentTradeRecord[(int)num];
			for (int i = 0; i < this.sellRecord.Length; i++)
			{
				this.sellRecord[i] = new GoldConsignmentTradeRecord();
				this.sellRecord[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyRecord = new GoldConsignmentTradeRecord[(int)num2];
			for (int j = 0; j < this.buyRecord.Length; j++)
			{
				this.buyRecord[j] = new GoldConsignmentTradeRecord();
				this.buyRecord[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006222 RID: 25122 RVA: 0x001254F8 File Offset: 0x001238F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sellRecord.Length);
			for (int i = 0; i < this.sellRecord.Length; i++)
			{
				this.sellRecord[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyRecord.Length);
			for (int j = 0; j < this.buyRecord.Length; j++)
			{
				this.buyRecord[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006223 RID: 25123 RVA: 0x00125578 File Offset: 0x00123978
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellRecord = new GoldConsignmentTradeRecord[(int)num];
			for (int i = 0; i < this.sellRecord.Length; i++)
			{
				this.sellRecord[i] = new GoldConsignmentTradeRecord();
				this.sellRecord[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyRecord = new GoldConsignmentTradeRecord[(int)num2];
			for (int j = 0; j < this.buyRecord.Length; j++)
			{
				this.buyRecord[j] = new GoldConsignmentTradeRecord();
				this.buyRecord[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006224 RID: 25124 RVA: 0x00125620 File Offset: 0x00123A20
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.sellRecord.Length; i++)
			{
				num += this.sellRecord[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.buyRecord.Length; j++)
			{
				num += this.buyRecord[j].getLen();
			}
			return num;
		}

		// Token: 0x04002B50 RID: 11088
		public const uint MsgID = 1210104U;

		// Token: 0x04002B51 RID: 11089
		public uint Sequence;

		// Token: 0x04002B52 RID: 11090
		public GoldConsignmentTradeRecord[] sellRecord = new GoldConsignmentTradeRecord[0];

		// Token: 0x04002B53 RID: 11091
		public GoldConsignmentTradeRecord[] buyRecord = new GoldConsignmentTradeRecord[0];
	}
}
