using System;
using GameClient;
using Protocol;

namespace DataModel
{
	// Token: 0x02001CD2 RID: 7378
	public sealed class ActivityTreasureLotteryModel : ActivityTreasureLotteryModelBase, IActivityTreasureLotteryModel, IActivityTreasureLotteryModelBase
	{
		// Token: 0x0601216B RID: 74091 RVA: 0x0054BA58 File Offset: 0x00549E58
		public ActivityTreasureLotteryModel(GambingItemInfo itemInfo) : base((int)itemInfo.itemDataId, itemInfo.gambingItemNum, itemInfo.gambingItemId, (int)itemInfo.sortId)
		{
			this.TotalNum = (int)itemInfo.totalCopiesOfCurGroup;
			this.LeftNum = itemInfo.totalCopiesOfCurGroup - itemInfo.soldCopiesInCurGroup;
			this.TotalGroup = (int)itemInfo.totalGroups;
			this.State = (GambingItemStatus)itemInfo.statusOfCurGroup;
			this.UnitPrice = (int)itemInfo.unitPrice;
			this.MoneyId = (int)itemInfo.costMoneyId;
			this.BoughtNum = (int)itemInfo.mineGambingInfo.investCopies;
			this._sellBeginTime = itemInfo.sellBeginTime;
			this.LeftGroupNum = (int)itemInfo.restGroups;
			if (this.State == GambingItemStatus.GIS_SELLING || this.State == GambingItemStatus.GIS_PREPARE)
			{
				this.LeftGroupNum++;
			}
			this.GroupId = itemInfo.curGroupId;
			this.Compensation = itemInfo.rewardsPerCopy;
		}

		// Token: 0x17001DD3 RID: 7635
		// (get) Token: 0x0601216C RID: 74092 RVA: 0x0054BB39 File Offset: 0x00549F39
		// (set) Token: 0x0601216D RID: 74093 RVA: 0x0054BB41 File Offset: 0x00549F41
		public int TotalNum { get; private set; }

		// Token: 0x17001DD4 RID: 7636
		// (get) Token: 0x0601216E RID: 74094 RVA: 0x0054BB4A File Offset: 0x00549F4A
		// (set) Token: 0x0601216F RID: 74095 RVA: 0x0054BB52 File Offset: 0x00549F52
		public int LeftGroupNum { get; private set; }

		// Token: 0x17001DD5 RID: 7637
		// (get) Token: 0x06012170 RID: 74096 RVA: 0x0054BB5B File Offset: 0x00549F5B
		// (set) Token: 0x06012171 RID: 74097 RVA: 0x0054BB63 File Offset: 0x00549F63
		public ushort GroupId { get; private set; }

		// Token: 0x17001DD6 RID: 7638
		// (get) Token: 0x06012172 RID: 74098 RVA: 0x0054BB6C File Offset: 0x00549F6C
		// (set) Token: 0x06012173 RID: 74099 RVA: 0x0054BB74 File Offset: 0x00549F74
		public int TotalGroup { get; private set; }

		// Token: 0x17001DD7 RID: 7639
		// (get) Token: 0x06012174 RID: 74100 RVA: 0x0054BB7D File Offset: 0x00549F7D
		// (set) Token: 0x06012175 RID: 74101 RVA: 0x0054BB85 File Offset: 0x00549F85
		public uint LeftNum { get; private set; }

		// Token: 0x17001DD8 RID: 7640
		// (get) Token: 0x06012176 RID: 74102 RVA: 0x0054BB8E File Offset: 0x00549F8E
		// (set) Token: 0x06012177 RID: 74103 RVA: 0x0054BB96 File Offset: 0x00549F96
		public GambingItemStatus State { get; private set; }

		// Token: 0x17001DD9 RID: 7641
		// (get) Token: 0x06012178 RID: 74104 RVA: 0x0054BB9F File Offset: 0x00549F9F
		// (set) Token: 0x06012179 RID: 74105 RVA: 0x0054BBA7 File Offset: 0x00549FA7
		public int BoughtNum { get; private set; }

		// Token: 0x17001DDA RID: 7642
		// (get) Token: 0x0601217A RID: 74106 RVA: 0x0054BBB0 File Offset: 0x00549FB0
		// (set) Token: 0x0601217B RID: 74107 RVA: 0x0054BBB8 File Offset: 0x00549FB8
		public int UnitPrice { get; private set; }

		// Token: 0x17001DDB RID: 7643
		// (get) Token: 0x0601217C RID: 74108 RVA: 0x0054BBC1 File Offset: 0x00549FC1
		// (set) Token: 0x0601217D RID: 74109 RVA: 0x0054BBC9 File Offset: 0x00549FC9
		public int MoneyId { get; private set; }

		// Token: 0x17001DDC RID: 7644
		// (get) Token: 0x0601217E RID: 74110 RVA: 0x0054BBD2 File Offset: 0x00549FD2
		// (set) Token: 0x0601217F RID: 74111 RVA: 0x0054BBDA File Offset: 0x00549FDA
		public ItemReward[] Compensation { get; private set; }

		// Token: 0x17001DDD RID: 7645
		// (get) Token: 0x06012180 RID: 74112 RVA: 0x0054BBE3 File Offset: 0x00549FE3
		public string TimeRemainStr
		{
			get
			{
				return Function.SetShowTime((int)this._sellBeginTime);
			}
		}

		// Token: 0x17001DDE RID: 7646
		// (get) Token: 0x06012181 RID: 74113 RVA: 0x0054BBF0 File Offset: 0x00549FF0
		public int TimeRemain
		{
			get
			{
				return (int)(this._sellBeginTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			}
		}

		// Token: 0x0400BCB6 RID: 48310
		private uint _sellBeginTime;
	}
}
