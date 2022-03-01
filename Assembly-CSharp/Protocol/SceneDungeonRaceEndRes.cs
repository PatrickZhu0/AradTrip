using System;

namespace Protocol
{
	// Token: 0x020007C5 RID: 1989
	[Protocol]
	public class SceneDungeonRaceEndRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600605E RID: 24670 RVA: 0x00121AFC File Offset: 0x0011FEFC
		public uint GetMsgID()
		{
			return 506812U;
		}

		// Token: 0x0600605F RID: 24671 RVA: 0x00121B03 File Offset: 0x0011FF03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006060 RID: 24672 RVA: 0x00121B0B File Offset: 0x0011FF0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006061 RID: 24673 RVA: 0x00121B14 File Offset: 0x0011FF14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.killMonsterTotalExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.raceEndExp);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRaceEndDrop);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceEndDropBaseMulti);
			this.addition.encode(buffer, ref pos_);
			this.teamReward.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRaceEndChest);
			BaseDLL.encode_uint32(buffer, ref pos_, this.monthcartGoldReward);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldTitleGoldReward);
			BaseDLL.encode_int8(buffer, ref pos_, this.fatigueBurnType);
			BaseDLL.encode_int8(buffer, ref pos_, this.chestDoubleFlag);
			this.veteranReturnReward.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rollReward.Length);
			for (int i = 0; i < this.rollReward.Length; i++)
			{
				this.rollReward[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rollSingleReward.Length);
			for (int j = 0; j < this.rollSingleReward.Length; j++)
			{
				this.rollSingleReward[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006062 RID: 24674 RVA: 0x00121C64 File Offset: 0x00120064
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.killMonsterTotalExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.raceEndExp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRaceEndDrop);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceEndDropBaseMulti);
			this.addition.decode(buffer, ref pos_);
			this.teamReward.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRaceEndChest);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monthcartGoldReward);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldTitleGoldReward);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.fatigueBurnType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.chestDoubleFlag);
			this.veteranReturnReward.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rollReward = new RollItemInfo[(int)num];
			for (int i = 0; i < this.rollReward.Length; i++)
			{
				this.rollReward[i] = new RollItemInfo();
				this.rollReward[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.rollSingleReward = new ItemReward[(int)num2];
			for (int j = 0; j < this.rollSingleReward.Length; j++)
			{
				this.rollSingleReward[j] = new ItemReward();
				this.rollSingleReward[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006063 RID: 24675 RVA: 0x00121DDC File Offset: 0x001201DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.killMonsterTotalExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.raceEndExp);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRaceEndDrop);
			BaseDLL.encode_int8(buffer, ref pos_, this.raceEndDropBaseMulti);
			this.addition.encode(buffer, ref pos_);
			this.teamReward.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRaceEndChest);
			BaseDLL.encode_uint32(buffer, ref pos_, this.monthcartGoldReward);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldTitleGoldReward);
			BaseDLL.encode_int8(buffer, ref pos_, this.fatigueBurnType);
			BaseDLL.encode_int8(buffer, ref pos_, this.chestDoubleFlag);
			this.veteranReturnReward.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rollReward.Length);
			for (int i = 0; i < this.rollReward.Length; i++)
			{
				this.rollReward[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rollSingleReward.Length);
			for (int j = 0; j < this.rollSingleReward.Length; j++)
			{
				this.rollSingleReward[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006064 RID: 24676 RVA: 0x00121F2C File Offset: 0x0012032C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.killMonsterTotalExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.raceEndExp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRaceEndDrop);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.raceEndDropBaseMulti);
			this.addition.decode(buffer, ref pos_);
			this.teamReward.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRaceEndChest);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monthcartGoldReward);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldTitleGoldReward);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.fatigueBurnType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.chestDoubleFlag);
			this.veteranReturnReward.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rollReward = new RollItemInfo[(int)num];
			for (int i = 0; i < this.rollReward.Length; i++)
			{
				this.rollReward[i] = new RollItemInfo();
				this.rollReward[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.rollSingleReward = new ItemReward[(int)num2];
			for (int j = 0; j < this.rollSingleReward.Length; j++)
			{
				this.rollSingleReward[j] = new ItemReward();
				this.rollSingleReward[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006065 RID: 24677 RVA: 0x001220A4 File Offset: 0x001204A4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num += this.addition.getLen();
			num += this.teamReward.getLen();
			num++;
			num += 4;
			num += 4;
			num++;
			num++;
			num += this.veteranReturnReward.getLen();
			num += 2;
			for (int i = 0; i < this.rollReward.Length; i++)
			{
				num += this.rollReward[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.rollSingleReward.Length; j++)
			{
				num += this.rollSingleReward[j].getLen();
			}
			return num;
		}

		// Token: 0x0400281D RID: 10269
		public const uint MsgID = 506812U;

		// Token: 0x0400281E RID: 10270
		public uint Sequence;

		// Token: 0x0400281F RID: 10271
		public uint result;

		// Token: 0x04002820 RID: 10272
		public byte score;

		// Token: 0x04002821 RID: 10273
		public uint usedTime;

		// Token: 0x04002822 RID: 10274
		public uint killMonsterTotalExp;

		// Token: 0x04002823 RID: 10275
		public uint raceEndExp;

		// Token: 0x04002824 RID: 10276
		public byte hasRaceEndDrop;

		// Token: 0x04002825 RID: 10277
		public byte raceEndDropBaseMulti;

		// Token: 0x04002826 RID: 10278
		public DungeonAdditionInfo addition = new DungeonAdditionInfo();

		// Token: 0x04002827 RID: 10279
		public ItemReward teamReward = new ItemReward();

		// Token: 0x04002828 RID: 10280
		public byte hasRaceEndChest;

		// Token: 0x04002829 RID: 10281
		public uint monthcartGoldReward;

		// Token: 0x0400282A RID: 10282
		public uint goldTitleGoldReward;

		// Token: 0x0400282B RID: 10283
		public byte fatigueBurnType;

		// Token: 0x0400282C RID: 10284
		public byte chestDoubleFlag;

		// Token: 0x0400282D RID: 10285
		public ItemReward veteranReturnReward = new ItemReward();

		// Token: 0x0400282E RID: 10286
		public RollItemInfo[] rollReward = new RollItemInfo[0];

		// Token: 0x0400282F RID: 10287
		public ItemReward[] rollSingleReward = new ItemReward[0];
	}
}
