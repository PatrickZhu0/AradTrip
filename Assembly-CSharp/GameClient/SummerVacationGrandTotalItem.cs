using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190F RID: 6415
	public class SummerVacationGrandTotalItem : ActivityItemBase
	{
		// Token: 0x0600F9C0 RID: 63936 RVA: 0x00444BE4 File Offset: 0x00442FE4
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (this.mItemDesTxt != null)
			{
				this.mItemDesTxt.text = data.Desc;
			}
			if (this.mItemCountTxt != null)
			{
				this.mItemCountTxt.text = string.Format(TR.Value("limitactivity_shuqigrandtotal_accounttip"), data.DoneNum, data.TotalNum);
			}
			if (this.mReciveBtn != null)
			{
				this.mReciveBtn.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			}
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					if (this.mRewardRoot != null)
					{
						ComItem comItem = ComItemManager.Create(this.mRewardRoot.gameObject);
						if (comItem != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
							itemData.Count = (int)data.AwardDataList[i].num;
							itemData.EquipType = (EEquipType)data.AwardDataList[i].equipType;
							itemData.StrengthenLevel = (int)data.AwardDataList[i].strenth;
							ComItem comItem2 = comItem;
							ItemData item = itemData;
							if (SummerVacationGrandTotalItem.<>f__mg$cache0 == null)
							{
								SummerVacationGrandTotalItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem2.Setup(item, SummerVacationGrandTotalItem.<>f__mg$cache0);
							this.mComItems.Add(comItem);
							(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						}
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
		}

		// Token: 0x0600F9C1 RID: 63937 RVA: 0x00444D98 File Offset: 0x00443198
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_UNFINISH)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					if (state == OpActTaskState.OATS_OVER)
					{
						this.OnlyShowSelfHaveRecive();
					}
				}
				else
				{
					this.OnlyShowRecive();
				}
			}
			else
			{
				this.OnlyShowUnFinishTask();
			}
		}

		// Token: 0x0600F9C2 RID: 63938 RVA: 0x00444DE8 File Offset: 0x004431E8
		public override void Dispose()
		{
			base.Dispose();
			if (this.mReciveBtn != null)
			{
				this.mReciveBtn.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			}
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F9C3 RID: 63939 RVA: 0x00444E69 File Offset: 0x00443269
		private void OnlyShowRecive()
		{
			this.mReciveBtn.CustomActive(true);
			this.mUnFinishBtn.CustomActive(false);
			this.mHaveReciveGo.CustomActive(false);
			this.mOtherReceiveGo.CustomActive(false);
		}

		// Token: 0x0600F9C4 RID: 63940 RVA: 0x00444E9B File Offset: 0x0044329B
		private void OnlyShowUnFinishTask()
		{
			this.mUnFinishBtn.CustomActive(true);
			this.mReciveBtn.CustomActive(false);
			this.mHaveReciveGo.CustomActive(false);
			this.mOtherReceiveGo.CustomActive(false);
		}

		// Token: 0x0600F9C5 RID: 63941 RVA: 0x00444ECD File Offset: 0x004432CD
		public void OnlyShowSelfHaveRecive()
		{
			this.mHaveReciveGo.CustomActive(true);
			this.mUnFinishBtn.CustomActive(false);
			this.mReciveBtn.CustomActive(false);
			this.mOtherReceiveGo.CustomActive(false);
		}

		// Token: 0x0600F9C6 RID: 63942 RVA: 0x00444EFF File Offset: 0x004432FF
		public void OnlyShowOtherHaveRecive()
		{
			this.mOtherReceiveGo.CustomActive(true);
			this.mHaveReciveGo.CustomActive(false);
			this.mUnFinishBtn.CustomActive(false);
			this.mReciveBtn.CustomActive(false);
		}

		// Token: 0x04009BDD RID: 39901
		[SerializeField]
		private Text mItemDesTxt;

		// Token: 0x04009BDE RID: 39902
		[SerializeField]
		private Text mItemCountTxt;

		// Token: 0x04009BDF RID: 39903
		[SerializeField]
		private Button mReciveBtn;

		// Token: 0x04009BE0 RID: 39904
		[SerializeField]
		private Button mUnFinishBtn;

		// Token: 0x04009BE1 RID: 39905
		[SerializeField]
		private GameObject mHaveReciveGo;

		// Token: 0x04009BE2 RID: 39906
		[SerializeField]
		private GameObject mOtherReceiveGo;

		// Token: 0x04009BE3 RID: 39907
		[SerializeField]
		private GameObject mRewardRoot;

		// Token: 0x04009BE4 RID: 39908
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009BE5 RID: 39909
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009BE6 RID: 39910
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009BE7 RID: 39911
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009BE8 RID: 39912
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
