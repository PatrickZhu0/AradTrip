using System;

namespace Protocol
{
	// Token: 0x020008B0 RID: 2224
	[Protocol]
	public class SceneHonorRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600677B RID: 26491 RVA: 0x0013139D File Offset: 0x0012F79D
		public uint GetMsgID()
		{
			return 509902U;
		}

		// Token: 0x0600677C RID: 26492 RVA: 0x001313A4 File Offset: 0x0012F7A4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600677D RID: 26493 RVA: 0x001313AC File Offset: 0x0012F7AC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600677E RID: 26494 RVA: 0x001313B8 File Offset: 0x0012F7B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.honorLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.honorExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastWeekRank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.historyRank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.highestHonorLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isUseCard);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rankTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.historyHonorInfoList.Length);
			for (int i = 0; i < this.historyHonorInfoList.Length; i++)
			{
				this.historyHonorInfoList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600677F RID: 26495 RVA: 0x00131460 File Offset: 0x0012F860
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.honorLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.honorExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastWeekRank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.historyRank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.highestHonorLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isUseCard);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rankTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.historyHonorInfoList = new HistoryHonorInfo[(int)num];
			for (int i = 0; i < this.historyHonorInfoList.Length; i++)
			{
				this.historyHonorInfoList[i] = new HistoryHonorInfo();
				this.historyHonorInfoList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006780 RID: 26496 RVA: 0x0013151C File Offset: 0x0012F91C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.honorLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.honorExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastWeekRank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.historyRank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.highestHonorLvl);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isUseCard);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rankTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.historyHonorInfoList.Length);
			for (int i = 0; i < this.historyHonorInfoList.Length; i++)
			{
				this.historyHonorInfoList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006781 RID: 26497 RVA: 0x001315C4 File Offset: 0x0012F9C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.honorLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.honorExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastWeekRank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.historyRank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.highestHonorLvl);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isUseCard);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rankTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.historyHonorInfoList = new HistoryHonorInfo[(int)num];
			for (int i = 0; i < this.historyHonorInfoList.Length; i++)
			{
				this.historyHonorInfoList[i] = new HistoryHonorInfo();
				this.historyHonorInfoList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006782 RID: 26498 RVA: 0x00131680 File Offset: 0x0012FA80
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
			num += 2;
			for (int i = 0; i < this.historyHonorInfoList.Length; i++)
			{
				num += this.historyHonorInfoList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002E40 RID: 11840
		public const uint MsgID = 509902U;

		// Token: 0x04002E41 RID: 11841
		public uint Sequence;

		// Token: 0x04002E42 RID: 11842
		public uint honorLvl;

		// Token: 0x04002E43 RID: 11843
		public uint honorExp;

		// Token: 0x04002E44 RID: 11844
		public uint lastWeekRank;

		// Token: 0x04002E45 RID: 11845
		public uint historyRank;

		// Token: 0x04002E46 RID: 11846
		public uint highestHonorLvl;

		// Token: 0x04002E47 RID: 11847
		public uint isUseCard;

		// Token: 0x04002E48 RID: 11848
		public uint rankTime;

		// Token: 0x04002E49 RID: 11849
		public HistoryHonorInfo[] historyHonorInfoList = new HistoryHonorInfo[0];
	}
}
