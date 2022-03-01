using System;

namespace Protocol
{
	// Token: 0x020007F6 RID: 2038
	[Protocol]
	public class UnionGoldConsignmentOrderPageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061F3 RID: 25075 RVA: 0x00124918 File Offset: 0x00122D18
		public uint GetMsgID()
		{
			return 1210102U;
		}

		// Token: 0x060061F4 RID: 25076 RVA: 0x0012491F File Offset: 0x00122D1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061F5 RID: 25077 RVA: 0x00124927 File Offset: 0x00122D27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061F6 RID: 25078 RVA: 0x00124930 File Offset: 0x00122D30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.startCloseTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endCloseTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startCloseStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.todayAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recentAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.estimateIncome);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isHasUnitAbnormalOrder);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sellOrderList.Length);
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyOrderList.Length);
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060061F7 RID: 25079 RVA: 0x00124A3C File Offset: 0x00122E3C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startCloseTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endCloseTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startCloseStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.todayAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recentAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.estimateIncome);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isHasUnitAbnormalOrder);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellOrderList = new OrderGradeInfo[(int)num];
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i] = new OrderGradeInfo();
				this.sellOrderList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyOrderList = new OrderGradeInfo[(int)num2];
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j] = new OrderGradeInfo();
				this.buyOrderList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060061F8 RID: 25080 RVA: 0x00124B70 File Offset: 0x00122F70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.startCloseTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endCloseTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startCloseStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.todayAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.recentAveragePrice);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.estimateIncome);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isHasUnitAbnormalOrder);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.sellOrderList.Length);
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buyOrderList.Length);
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060061F9 RID: 25081 RVA: 0x00124C7C File Offset: 0x0012307C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startCloseTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endCloseTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startCloseStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.todayAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.recentAveragePrice);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.estimateIncome);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isHasUnitAbnormalOrder);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellOrderList = new OrderGradeInfo[(int)num];
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i] = new OrderGradeInfo();
				this.sellOrderList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyOrderList = new OrderGradeInfo[(int)num2];
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j] = new OrderGradeInfo();
				this.buyOrderList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060061FA RID: 25082 RVA: 0x00124DB0 File Offset: 0x001231B0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				num += this.sellOrderList[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				num += this.buyOrderList[j].getLen();
			}
			return num;
		}

		// Token: 0x04002B2B RID: 11051
		public const uint MsgID = 1210102U;

		// Token: 0x04002B2C RID: 11052
		public uint Sequence;

		// Token: 0x04002B2D RID: 11053
		public uint startCloseTime;

		// Token: 0x04002B2E RID: 11054
		public uint endCloseTime;

		// Token: 0x04002B2F RID: 11055
		public uint startCloseStamp;

		// Token: 0x04002B30 RID: 11056
		public uint lastAveragePrice;

		// Token: 0x04002B31 RID: 11057
		public uint todayAveragePrice;

		// Token: 0x04002B32 RID: 11058
		public uint recentAveragePrice;

		// Token: 0x04002B33 RID: 11059
		public uint sellAccNum;

		// Token: 0x04002B34 RID: 11060
		public uint buyAccNum;

		// Token: 0x04002B35 RID: 11061
		public uint estimateIncome;

		// Token: 0x04002B36 RID: 11062
		public uint isHasUnitAbnormalOrder;

		// Token: 0x04002B37 RID: 11063
		public OrderGradeInfo[] sellOrderList = new OrderGradeInfo[0];

		// Token: 0x04002B38 RID: 11064
		public OrderGradeInfo[] buyOrderList = new OrderGradeInfo[0];
	}
}
