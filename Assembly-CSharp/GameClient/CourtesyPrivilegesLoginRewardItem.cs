using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001820 RID: 6176
	public class CourtesyPrivilegesLoginRewardItem : ActivityItemBase
	{
		// Token: 0x0600F344 RID: 62276 RVA: 0x0041C253 File Offset: 0x0041A653
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F345 RID: 62277 RVA: 0x0041C270 File Offset: 0x0041A670
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F346 RID: 62278 RVA: 0x0041C28D File Offset: 0x0041A68D
		private void OnCounterChanged(UIEvent uIEvent)
		{
			this.UpdateData(this.limitTimeActivityTaskDataModel);
		}

		// Token: 0x0600F347 RID: 62279 RVA: 0x0041C29C File Offset: 0x0041A69C
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (this.mTaskName != null)
			{
				this.mTaskName.text = data.Desc;
			}
			if (data.AwardDataList.Count == 1)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				if (opTaskReward != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					if (itemData != null)
					{
						if (this.mItemBackground != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
						}
						if (this.mItemIcon != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
						}
						if (opTaskReward.num > 1U)
						{
							if (this.mItemCount != null)
							{
								this.mItemCount.text = opTaskReward.num.ToString();
							}
						}
						else if (this.mItemCount != null)
						{
							this.mItemCount.text = string.Empty;
						}
						if (this.mItemIconBtn != null)
						{
							this.mItemIconBtn.SafeRemoveAllListener();
							this.mItemIconBtn.SafeAddOnClickListener(delegate
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
							});
						}
						if (this.mGoLimitTime != null)
						{
							int num;
							bool flag;
							itemData.GetTimeLeft(out num, out flag);
							if ((flag && num > 0) || itemData.IsTimeLimit)
							{
								this.mGoLimitTime.CustomActive(true);
							}
							else
							{
								this.mGoLimitTime.CustomActive(false);
							}
						}
					}
				}
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.SafeRemoveAllListener();
				this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			}
		}

		// Token: 0x0600F348 RID: 62280 RVA: 0x0041C494 File Offset: 0x0041A894
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.limitTimeActivityTaskDataModel = data;
			this.mHasReceiveGo.CustomActive(false);
			this.mNotReachItemGo.CustomActive(false);
			this.mReceiveBtn.CustomActive(false);
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD);
			if (count == 1)
			{
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mNotReachItemGo.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mHasReceiveGo.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mNotReachItemGo.CustomActive(true);
			}
		}

		// Token: 0x0600F349 RID: 62281 RVA: 0x0041C554 File Offset: 0x0041A954
		public void OnSetArrowIsShow(bool isFlag)
		{
			if (this.mArrowItemGo != null)
			{
				this.mArrowItemGo.CustomActive(isFlag);
			}
		}

		// Token: 0x040095C7 RID: 38343
		[SerializeField]
		private Text mTaskName;

		// Token: 0x040095C8 RID: 38344
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x040095C9 RID: 38345
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x040095CA RID: 38346
		[SerializeField]
		private Text mItemCount;

		// Token: 0x040095CB RID: 38347
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x040095CC RID: 38348
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x040095CD RID: 38349
		[SerializeField]
		private UIGray mReceiveGray;

		// Token: 0x040095CE RID: 38350
		[SerializeField]
		private GameObject mArrowItemGo;

		// Token: 0x040095CF RID: 38351
		[SerializeField]
		private GameObject mHasReceiveGo;

		// Token: 0x040095D0 RID: 38352
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x040095D1 RID: 38353
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x040095D2 RID: 38354
		private ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel;
	}
}
