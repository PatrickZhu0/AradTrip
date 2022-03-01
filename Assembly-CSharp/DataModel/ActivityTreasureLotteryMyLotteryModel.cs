using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace DataModel
{
	// Token: 0x02001CD3 RID: 7379
	public sealed class ActivityTreasureLotteryMyLotteryModel : ActivityTreasureLotteryModelBase, IActivityTreasureLotteryMyLotteryModel, IActivityTreasureLotteryModelBase
	{
		// Token: 0x06012182 RID: 74114 RVA: 0x0054BC04 File Offset: 0x0054A004
		public ActivityTreasureLotteryMyLotteryModel(GambingMineInfo info) : base((int)info.itemDataId, info.gambingItemNum, info.gambingItemId, (int)info.sortId)
		{
			this.BoughtNum = (int)info.mineGambingInfo.investCopies;
			this.GroupId = (int)info.groupId;
			this.Status = (GambingMineStatus)info.mineGambingInfo.status;
			this.RestNum = (int)(info.totalCopies - info.soldCopies);
			this.MyInvestment = (int)info.mineGambingInfo.investMoney;
			this.TotalNum = (int)info.totalCopies;
			this.WinnerInvestment = (int)info.gainersGambingInfo.investMoney;
			this.WinnerServer = info.gainersGambingInfo.participantServerName;
			this.WinnerName = info.gainersGambingInfo.participantName;
			this.WinRate = info.mineGambingInfo.gambingRate;
			this.AllPlayerInvestInfo = new List<GambingParticipantInfo>();
			this.AllPlayerInvestInfo.AddRange(info.participantsGambingInfo);
			this.CurrencyName = string.Empty;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)info.mineGambingInfo.investMoneyId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.CurrencyName = tableItem.Name;
			}
			else
			{
				Logger.LogError("错误的moneyId :" + info.mineGambingInfo.investMoneyId);
			}
		}

		// Token: 0x17001DDF RID: 7647
		// (get) Token: 0x06012183 RID: 74115 RVA: 0x0054BD4E File Offset: 0x0054A14E
		// (set) Token: 0x06012184 RID: 74116 RVA: 0x0054BD56 File Offset: 0x0054A156
		public int BoughtNum { get; private set; }

		// Token: 0x17001DE0 RID: 7648
		// (get) Token: 0x06012185 RID: 74117 RVA: 0x0054BD5F File Offset: 0x0054A15F
		// (set) Token: 0x06012186 RID: 74118 RVA: 0x0054BD67 File Offset: 0x0054A167
		public string CurrencyName { get; private set; }

		// Token: 0x17001DE1 RID: 7649
		// (get) Token: 0x06012187 RID: 74119 RVA: 0x0054BD70 File Offset: 0x0054A170
		// (set) Token: 0x06012188 RID: 74120 RVA: 0x0054BD78 File Offset: 0x0054A178
		public int GroupId { get; private set; }

		// Token: 0x17001DE2 RID: 7650
		// (get) Token: 0x06012189 RID: 74121 RVA: 0x0054BD81 File Offset: 0x0054A181
		// (set) Token: 0x0601218A RID: 74122 RVA: 0x0054BD89 File Offset: 0x0054A189
		public GambingMineStatus Status { get; private set; }

		// Token: 0x17001DE3 RID: 7651
		// (get) Token: 0x0601218B RID: 74123 RVA: 0x0054BD92 File Offset: 0x0054A192
		// (set) Token: 0x0601218C RID: 74124 RVA: 0x0054BD9A File Offset: 0x0054A19A
		public int RestNum { get; private set; }

		// Token: 0x17001DE4 RID: 7652
		// (get) Token: 0x0601218D RID: 74125 RVA: 0x0054BDA3 File Offset: 0x0054A1A3
		// (set) Token: 0x0601218E RID: 74126 RVA: 0x0054BDAB File Offset: 0x0054A1AB
		public int MyInvestment { get; private set; }

		// Token: 0x17001DE5 RID: 7653
		// (get) Token: 0x0601218F RID: 74127 RVA: 0x0054BDB4 File Offset: 0x0054A1B4
		// (set) Token: 0x06012190 RID: 74128 RVA: 0x0054BDBC File Offset: 0x0054A1BC
		public int TotalNum { get; private set; }

		// Token: 0x17001DE6 RID: 7654
		// (get) Token: 0x06012191 RID: 74129 RVA: 0x0054BDC5 File Offset: 0x0054A1C5
		// (set) Token: 0x06012192 RID: 74130 RVA: 0x0054BDCD File Offset: 0x0054A1CD
		public int WinnerInvestment { get; private set; }

		// Token: 0x17001DE7 RID: 7655
		// (get) Token: 0x06012193 RID: 74131 RVA: 0x0054BDD6 File Offset: 0x0054A1D6
		// (set) Token: 0x06012194 RID: 74132 RVA: 0x0054BDDE File Offset: 0x0054A1DE
		public string WinnerName { get; private set; }

		// Token: 0x17001DE8 RID: 7656
		// (get) Token: 0x06012195 RID: 74133 RVA: 0x0054BDE7 File Offset: 0x0054A1E7
		// (set) Token: 0x06012196 RID: 74134 RVA: 0x0054BDEF File Offset: 0x0054A1EF
		public string WinnerServer { get; private set; }

		// Token: 0x17001DE9 RID: 7657
		// (get) Token: 0x06012197 RID: 74135 RVA: 0x0054BDF8 File Offset: 0x0054A1F8
		// (set) Token: 0x06012198 RID: 74136 RVA: 0x0054BE00 File Offset: 0x0054A200
		public string WinRate { get; private set; }

		// Token: 0x17001DEA RID: 7658
		// (get) Token: 0x06012199 RID: 74137 RVA: 0x0054BE09 File Offset: 0x0054A209
		// (set) Token: 0x0601219A RID: 74138 RVA: 0x0054BE11 File Offset: 0x0054A211
		public List<GambingParticipantInfo> AllPlayerInvestInfo { get; private set; }
	}
}
