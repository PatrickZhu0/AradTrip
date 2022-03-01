using System;

namespace Protocol
{
	// Token: 0x020007FE RID: 2046
	[Protocol]
	public class UnionGoldConsignmentOwnerOrderRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006235 RID: 25141 RVA: 0x00125860 File Offset: 0x00123C60
		public uint GetMsgID()
		{
			return 1210106U;
		}

		// Token: 0x06006236 RID: 25142 RVA: 0x00125867 File Offset: 0x00123C67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006237 RID: 25143 RVA: 0x0012586F File Offset: 0x00123C6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006238 RID: 25144 RVA: 0x00125878 File Offset: 0x00123C78
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyAccNum);
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

		// Token: 0x06006239 RID: 25145 RVA: 0x00125914 File Offset: 0x00123D14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyAccNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellOrderList = new GoldConsignmentOrder[(int)num];
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i] = new GoldConsignmentOrder();
				this.sellOrderList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyOrderList = new GoldConsignmentOrder[(int)num2];
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j] = new GoldConsignmentOrder();
				this.buyOrderList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600623A RID: 25146 RVA: 0x001259D8 File Offset: 0x00123DD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sellAccNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyAccNum);
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

		// Token: 0x0600623B RID: 25147 RVA: 0x00125A74 File Offset: 0x00123E74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sellAccNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyAccNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.sellOrderList = new GoldConsignmentOrder[(int)num];
			for (int i = 0; i < this.sellOrderList.Length; i++)
			{
				this.sellOrderList[i] = new GoldConsignmentOrder();
				this.sellOrderList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.buyOrderList = new GoldConsignmentOrder[(int)num2];
			for (int j = 0; j < this.buyOrderList.Length; j++)
			{
				this.buyOrderList[j] = new GoldConsignmentOrder();
				this.buyOrderList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600623C RID: 25148 RVA: 0x00125B38 File Offset: 0x00123F38
		public int getLen()
		{
			int num = 0;
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

		// Token: 0x04002B5B RID: 11099
		public const uint MsgID = 1210106U;

		// Token: 0x04002B5C RID: 11100
		public uint Sequence;

		// Token: 0x04002B5D RID: 11101
		public uint sellAccNum;

		// Token: 0x04002B5E RID: 11102
		public uint buyAccNum;

		// Token: 0x04002B5F RID: 11103
		public GoldConsignmentOrder[] sellOrderList = new GoldConsignmentOrder[0];

		// Token: 0x04002B60 RID: 11104
		public GoldConsignmentOrder[] buyOrderList = new GoldConsignmentOrder[0];
	}
}
