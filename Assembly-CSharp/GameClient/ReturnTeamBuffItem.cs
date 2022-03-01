using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001908 RID: 6408
	public class ReturnTeamBuffItem : ActivityItemBase
	{
		// Token: 0x0600F995 RID: 63893 RVA: 0x00443728 File Offset: 0x00441B28
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				this.mTextDesc.SafeSetText(data.Desc);
				this._InitAwards(data.AwardDataList);
			}
			this.mButtonChallenge.SafeRemoveAllListener();
			this.mButtonChallenge.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonChallengeTeam.SafeRemoveAllListener();
			this.mButtonChallengeTeam.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F996 RID: 63894 RVA: 0x0044379E File Offset: 0x00441B9E
		protected override void _OnItemClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick((int)this.mId, this.goFrameParam, 0UL);
			}
		}

		// Token: 0x0600F997 RID: 63895 RVA: 0x004437C4 File Offset: 0x00441BC4
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				this.mTextDesc.SafeSetText(data.Desc);
				int id = (int)data.ParamNums[0];
				AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				this.mTextTitle.SafeSetText(tableItem.Name);
				this.mButtonChallenge.CustomActive(false);
				this.mButtonChallengeTeam.CustomActive(false);
				if (data.ParamNums.Count > 1)
				{
					if (data.ParamNums[1] == 0U)
					{
						this.mButtonChallenge.CustomActive(true);
						this.goFrameParam = 0;
					}
					if (data.ParamNums[1] == 1U)
					{
						this.mButtonChallengeTeam.CustomActive(true);
						this.goFrameParam = 1;
					}
				}
			}
		}

		// Token: 0x0600F998 RID: 63896 RVA: 0x00443898 File Offset: 0x00441C98
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
			this.mButtonChallenge.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonChallengeTeam.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F999 RID: 63897 RVA: 0x00443920 File Offset: 0x00441D20
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
					if (ReturnTeamBuffItem.<>f__mg$cache0 == null)
					{
						ReturnTeamBuffItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, ReturnTeamBuffItem.<>f__mg$cache0);
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

		// Token: 0x04009B99 RID: 39833
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009B9A RID: 39834
		[SerializeField]
		private GameObject mAwardRoot;

		// Token: 0x04009B9B RID: 39835
		[SerializeField]
		private Text mTextDesc;

		// Token: 0x04009B9C RID: 39836
		[SerializeField]
		private Text mTextTitle;

		// Token: 0x04009B9D RID: 39837
		[SerializeField]
		private Button mButtonChallenge;

		// Token: 0x04009B9E RID: 39838
		[SerializeField]
		private Button mButtonChallengeTeam;

		// Token: 0x04009B9F RID: 39839
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009BA0 RID: 39840
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(95f, 95f);

		// Token: 0x04009BA1 RID: 39841
		private const int DEFAULT_LIST_SIZE = 4;

		// Token: 0x04009BA2 RID: 39842
		private readonly List<ComItem> mComItems = new List<ComItem>(4);

		// Token: 0x04009BA3 RID: 39843
		private int goFrameParam;

		// Token: 0x04009BA4 RID: 39844
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
