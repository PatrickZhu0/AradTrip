using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018EE RID: 6382
	public class EveryChallengeItem : ActivityItemBase
	{
		// Token: 0x0600F8F6 RID: 63734 RVA: 0x0043D945 File Offset: 0x0043BD45
		private void Awake()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this._OnItemClick));
			}
		}

		// Token: 0x0600F8F7 RID: 63735 RVA: 0x0043D985 File Offset: 0x0043BD85
		private void OnDestroy()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this._OnItemClick));
			}
		}

		// Token: 0x0600F8F8 RID: 63736 RVA: 0x0043D9B8 File Offset: 0x0043BDB8
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
			if (this.mGoNotReach != null)
			{
				this.mGoNotReach.CustomActive(false);
			}
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				if (this.mGoNotReach != null)
				{
					this.mGoNotReach.CustomActive(true);
				}
				break;
			case OpActTaskState.OATS_FINISHED:
				if (this.mGoReceive != null)
				{
					this.mGoReceive.CustomActive(true);
				}
				break;
			case OpActTaskState.OATS_OVER:
				if (this.mGoHaveToReceive != null)
				{
					this.mGoHaveToReceive.CustomActive(true);
				}
				break;
			}
		}

		// Token: 0x0600F8F9 RID: 63737 RVA: 0x0043DAB8 File Offset: 0x0043BEB8
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (data.AwardDataList != null && data.AwardDataList.Count > 0)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (itemData != null)
				{
					if (this.mName != null)
					{
						this.mName.text = itemData.GetColorName(string.Empty, false);
					}
					if (this.mItemBackground != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
					}
					if (this.mItemIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
					}
					if (this.mItemBtn != null)
					{
						this.mItemBtn.onClick.RemoveAllListeners();
						this.mItemBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
					if (this.mItemCount != null)
					{
						if (opTaskReward.num > 1U)
						{
							this.mItemCount.CustomActive(true);
							this.mItemCount.text = opTaskReward.num.ToString();
						}
						else
						{
							this.mItemCount.CustomActive(false);
						}
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
			if (this.mLevelDesc != null)
			{
				this.mLevelDesc.text = string.Format("角色等级：{0}/{1}", DataManager<PlayerBaseData>.GetInstance().Level, data.TotalNum);
			}
		}

		// Token: 0x04009A79 RID: 39545
		[SerializeField]
		private Text mName;

		// Token: 0x04009A7A RID: 39546
		[SerializeField]
		private Text mLevelDesc;

		// Token: 0x04009A7B RID: 39547
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009A7C RID: 39548
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009A7D RID: 39549
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009A7E RID: 39550
		[SerializeField]
		private Button mItemBtn;

		// Token: 0x04009A7F RID: 39551
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009A80 RID: 39552
		[SerializeField]
		private GameObject mGoReceive;

		// Token: 0x04009A81 RID: 39553
		[SerializeField]
		private GameObject mGoHaveToReceive;

		// Token: 0x04009A82 RID: 39554
		[SerializeField]
		private GameObject mGoNotReach;

		// Token: 0x04009A83 RID: 39555
		[SerializeField]
		private GameObject mGoLimitTime;
	}
}
