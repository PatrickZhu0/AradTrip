using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F9 RID: 6393
	public class LevelFightItem : ActivityItemBase
	{
		// Token: 0x0600F92B RID: 63787 RVA: 0x0043F53E File Offset: 0x0043D93E
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mTextDesc.SafeSetText(data.Desc);
			this._InitAwards(data.AwardDataList);
		}

		// Token: 0x0600F92C RID: 63788 RVA: 0x0043F55D File Offset: 0x0043D95D
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mTextDesc.SafeSetText(data.Desc);
		}

		// Token: 0x0600F92D RID: 63789 RVA: 0x0043F570 File Offset: 0x0043D970
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

		// Token: 0x0600F92E RID: 63790 RVA: 0x0043F5C8 File Offset: 0x0043D9C8
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
					if (LevelFightItem.<>f__mg$cache0 == null)
					{
						LevelFightItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, LevelFightItem.<>f__mg$cache0);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					this.mComItems.Add(comItem);
				}
			}
			this.mAwardsScrollRect.enabled = (awardDataList.Count > this.mScrollCount);
		}

		// Token: 0x04009ADD RID: 39645
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009ADE RID: 39646
		[SerializeField]
		private GameObject mAwardRoot;

		// Token: 0x04009ADF RID: 39647
		[SerializeField]
		private Text mTextDesc;

		// Token: 0x04009AE0 RID: 39648
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009AE1 RID: 39649
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(95f, 95f);

		// Token: 0x04009AE2 RID: 39650
		private const int DEFAULT_LIST_SIZE = 4;

		// Token: 0x04009AE3 RID: 39651
		private readonly List<ComItem> mComItems = new List<ComItem>(4);

		// Token: 0x04009AE4 RID: 39652
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
