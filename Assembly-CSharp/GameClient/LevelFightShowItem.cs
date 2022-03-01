using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FA RID: 6394
	public class LevelFightShowItem : ActivityItemBase
	{
		// Token: 0x0600F930 RID: 63792 RVA: 0x0043F6C1 File Offset: 0x0043DAC1
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this._InitAwards(data.AwardDataList);
			this._UpdateText(data as LevelFightActivityRankDataModel);
		}

		// Token: 0x0600F931 RID: 63793 RVA: 0x0043F6DB File Offset: 0x0043DADB
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this._UpdateText(data as LevelFightActivityRankDataModel);
		}

		// Token: 0x0600F932 RID: 63794 RVA: 0x0043F6EC File Offset: 0x0043DAEC
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = 0; i < this.mComItems.Count; i++)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F933 RID: 63795 RVA: 0x0043F744 File Offset: 0x0043DB44
		private void _UpdateText(LevelFightActivityRankDataModel rankData)
		{
			if (rankData == null)
			{
				return;
			}
			if (rankData.Rank <= 3U)
			{
				this.mTextDesc.CustomActive(false);
				uint rank = rankData.Rank;
				if (rank != 1U)
				{
					if (rank != 2U)
					{
						if (rank == 3U)
						{
							this.mRank1.CustomActive(false);
							this.mRank2.CustomActive(false);
							this.mRank3.CustomActive(true);
						}
					}
					else
					{
						this.mRank1.CustomActive(false);
						this.mRank2.CustomActive(true);
						this.mRank3.CustomActive(false);
					}
				}
				else
				{
					this.mRank1.CustomActive(true);
					this.mRank2.CustomActive(false);
					this.mRank3.CustomActive(false);
				}
			}
			else
			{
				this.mRank1.CustomActive(false);
				this.mRank2.CustomActive(false);
				this.mRank3.CustomActive(false);
				this.mTextDesc.CustomActive(true);
				this.mTextDesc.SafeSetText(string.Format(TR.Value("activity_level_fight_show_rank"), rankData.Rank));
			}
			this.mTextName.SafeSetText(rankData.Name);
		}

		// Token: 0x0600F934 RID: 63796 RVA: 0x0043F878 File Offset: 0x0043DC78
		private void _InitAwards(List<OpTaskReward> awardDataList)
		{
			if (awardDataList == null)
			{
				return;
			}
			for (int i = 0; i < awardDataList.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mAwardRoot);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)awardDataList[i].id, 100, 0);
					itemData.Count = (int)awardDataList[i].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (LevelFightShowItem.<>f__mg$cache0 == null)
					{
						LevelFightShowItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, LevelFightShowItem.<>f__mg$cache0);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					this.mComItems.Add(comItem);
				}
			}
			if (awardDataList.Count > this.mScrollCount)
			{
				this.mAwardsScrollRect.enabled = true;
			}
			else
			{
				this.mAwardsScrollRect.enabled = false;
			}
		}

		// Token: 0x04009AE5 RID: 39653
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009AE6 RID: 39654
		[SerializeField]
		private GameObject mAwardRoot;

		// Token: 0x04009AE7 RID: 39655
		[SerializeField]
		private GameObject mRank1;

		// Token: 0x04009AE8 RID: 39656
		[SerializeField]
		private GameObject mRank2;

		// Token: 0x04009AE9 RID: 39657
		[SerializeField]
		private GameObject mRank3;

		// Token: 0x04009AEA RID: 39658
		[SerializeField]
		private Text mTextDesc;

		// Token: 0x04009AEB RID: 39659
		[SerializeField]
		private Text mTextName;

		// Token: 0x04009AEC RID: 39660
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009AED RID: 39661
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(95f, 95f);

		// Token: 0x04009AEE RID: 39662
		private const int DEFAULT_LIST_SIZE = 4;

		// Token: 0x04009AEF RID: 39663
		private readonly List<ComItem> mComItems = new List<ComItem>(4);

		// Token: 0x04009AF0 RID: 39664
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
