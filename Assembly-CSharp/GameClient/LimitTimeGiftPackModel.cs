using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF0 RID: 7408
	public struct LimitTimeGiftPackModel : ILimitTimeNote
	{
		// Token: 0x0601230F RID: 74511 RVA: 0x0054DC18 File Offset: 0x0054C018
		public LimitTimeGiftPackModel(OpActivityData msg, List<MallItemInfo> itemInfos, MallTypeTable.eMallType mallType, string itemPath, string logoPath = null, string noteBgPath = null, string notePrefabPath = null)
		{
			this = default(LimitTimeGiftPackModel);
			this.Id = msg.dataId;
			this.Name = msg.name;
			this.RuleDesc = msg.ruleDesc;
			this.LogoDesc = msg.logoDesc;
			this.State = (OpActivityState)msg.state;
			this.Desc = msg.desc;
			this.LogoPath = logoPath;
			this.ItemPath = itemPath;
			this.DetailDatas = new List<LimitTimeGiftPackDetailModel>();
			if (itemInfos != null)
			{
				for (int i = 0; i < itemInfos.Count; i++)
				{
					this.DetailDatas.Add(new LimitTimeGiftPackDetailModel(itemInfos[i]));
				}
			}
			this.StartTime = msg.startTime;
			this.EndTime = msg.endTime;
			this.NoteBgPath = noteBgPath;
			this.NotePrefabPath = notePrefabPath;
			this.mMallType = mallType;
		}

		// Token: 0x17001EB8 RID: 7864
		// (get) Token: 0x06012310 RID: 74512 RVA: 0x0054DCF2 File Offset: 0x0054C0F2
		// (set) Token: 0x06012311 RID: 74513 RVA: 0x0054DCFA File Offset: 0x0054C0FA
		public uint Id { get; private set; }

		// Token: 0x17001EB9 RID: 7865
		// (get) Token: 0x06012312 RID: 74514 RVA: 0x0054DD03 File Offset: 0x0054C103
		// (set) Token: 0x06012313 RID: 74515 RVA: 0x0054DD0B File Offset: 0x0054C10B
		public uint StartTime { get; private set; }

		// Token: 0x17001EBA RID: 7866
		// (get) Token: 0x06012314 RID: 74516 RVA: 0x0054DD14 File Offset: 0x0054C114
		// (set) Token: 0x06012315 RID: 74517 RVA: 0x0054DD1C File Offset: 0x0054C11C
		public uint EndTime { get; private set; }

		// Token: 0x17001EBB RID: 7867
		// (get) Token: 0x06012316 RID: 74518 RVA: 0x0054DD25 File Offset: 0x0054C125
		// (set) Token: 0x06012317 RID: 74519 RVA: 0x0054DD2D File Offset: 0x0054C12D
		public string RuleDesc { get; private set; }

		// Token: 0x17001EBC RID: 7868
		// (get) Token: 0x06012318 RID: 74520 RVA: 0x0054DD36 File Offset: 0x0054C136
		// (set) Token: 0x06012319 RID: 74521 RVA: 0x0054DD3E File Offset: 0x0054C13E
		public string LogoDesc { get; private set; }

		// Token: 0x17001EBD RID: 7869
		// (get) Token: 0x0601231A RID: 74522 RVA: 0x0054DD47 File Offset: 0x0054C147
		// (set) Token: 0x0601231B RID: 74523 RVA: 0x0054DD4F File Offset: 0x0054C14F
		public string Desc { get; private set; }

		// Token: 0x17001EBE RID: 7870
		// (get) Token: 0x0601231C RID: 74524 RVA: 0x0054DD58 File Offset: 0x0054C158
		// (set) Token: 0x0601231D RID: 74525 RVA: 0x0054DD60 File Offset: 0x0054C160
		public string LogoPath { get; private set; }

		// Token: 0x17001EBF RID: 7871
		// (get) Token: 0x0601231E RID: 74526 RVA: 0x0054DD69 File Offset: 0x0054C169
		// (set) Token: 0x0601231F RID: 74527 RVA: 0x0054DD71 File Offset: 0x0054C171
		public string NoteBgPath { get; private set; }

		// Token: 0x17001EC0 RID: 7872
		// (get) Token: 0x06012320 RID: 74528 RVA: 0x0054DD7A File Offset: 0x0054C17A
		// (set) Token: 0x06012321 RID: 74529 RVA: 0x0054DD82 File Offset: 0x0054C182
		public string NotePrefabPath { get; private set; }

		// Token: 0x17001EC1 RID: 7873
		// (get) Token: 0x06012322 RID: 74530 RVA: 0x0054DD8B File Offset: 0x0054C18B
		// (set) Token: 0x06012323 RID: 74531 RVA: 0x0054DD93 File Offset: 0x0054C193
		public string ItemPath { get; private set; }

		// Token: 0x17001EC2 RID: 7874
		// (get) Token: 0x06012324 RID: 74532 RVA: 0x0054DD9C File Offset: 0x0054C19C
		// (set) Token: 0x06012325 RID: 74533 RVA: 0x0054DDA4 File Offset: 0x0054C1A4
		public OpActivityState State { get; private set; }

		// Token: 0x17001EC3 RID: 7875
		// (get) Token: 0x06012326 RID: 74534 RVA: 0x0054DDAD File Offset: 0x0054C1AD
		// (set) Token: 0x06012327 RID: 74535 RVA: 0x0054DDB5 File Offset: 0x0054C1B5
		public string Name { get; private set; }

		// Token: 0x17001EC4 RID: 7876
		// (get) Token: 0x06012328 RID: 74536 RVA: 0x0054DDBE File Offset: 0x0054C1BE
		// (set) Token: 0x06012329 RID: 74537 RVA: 0x0054DDC6 File Offset: 0x0054C1C6
		public List<LimitTimeGiftPackDetailModel> DetailDatas { get; private set; }

		// Token: 0x0601232A RID: 74538 RVA: 0x0054DDD0 File Offset: 0x0054C1D0
		public void UpdateItem(int itemId)
		{
			bool flag = false;
			MallItemInfo giftPackData = DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(this.mMallType, (uint)itemId);
			for (int i = 0; i < this.DetailDatas.Count; i++)
			{
				if ((ulong)this.DetailDatas[i].Id == (ulong)((long)itemId))
				{
					if (giftPackData != null)
					{
						this.DetailDatas[i] = new LimitTimeGiftPackDetailModel(giftPackData);
					}
					else
					{
						this.DetailDatas.RemoveAt(i);
					}
					flag = true;
					break;
				}
			}
			if (giftPackData != null && !flag && this.DetailDatas != null)
			{
				this.DetailDatas.Add(new LimitTimeGiftPackDetailModel(giftPackData));
			}
		}

		// Token: 0x0400BD5C RID: 48476
		private readonly MallTypeTable.eMallType mMallType;
	}
}
