using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190A RID: 6410
	public class SpecialExchangeItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F9A2 RID: 63906 RVA: 0x00443EE8 File Offset: 0x004422E8
		public void Init(int id, BossExchangeTaskModel taskData, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mId = id;
			this.mOnItemClick = onItemClick;
			this.mData = taskData;
			this.mExchangeBtn.SafeRemoveAllListener();
			this.mExchangeBtn.SafeAddOnClickListener(new UnityAction(this.OnExchangeBtnClick));
			this.InitItem();
			this.UpdateData(this.mData);
			DataManager<ActivityDataManager>.GetInstance().RegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.UpdateAccounterNum));
			DataManager<ActivityDataManager>.GetInstance().OnRequsetBossAccountData(this.mData);
		}

		// Token: 0x0600F9A3 RID: 63907 RVA: 0x00443F64 File Offset: 0x00442364
		public void UpdateData(BossExchangeTaskModel taskData)
		{
			this.mData = taskData;
			this.UpdateConsumeItem();
			if (this.mData.AccountTotalSubmitLimit == 0)
			{
				this.mExchangeCountDesc.SafeSetText(string.Format(TR.Value("activity_boss_exchange_item_count_role2"), this.mData.RemainCount, this.mData.TaskCycleCount));
				this.UpdateExchangeBtnState(this.mData.RemainCount > 0 && this.bIsConsumeEnough);
			}
			else
			{
				this.UpdateExchangeBtnState(this.mAccountNumLeft > 0 && this.bIsConsumeEnough);
			}
		}

		// Token: 0x0600F9A4 RID: 63908 RVA: 0x00444008 File Offset: 0x00442408
		private void OnExchangeBtnClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
			DataManager<ActivityDataManager>.GetInstance().OnRequsetBossAccountData(this.mData);
		}

		// Token: 0x0600F9A5 RID: 63909 RVA: 0x0044403C File Offset: 0x0044243C
		private void InitItem()
		{
			if (this.mData.ExchangeItems == null)
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair in this.mData.ExchangeItems)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(key, 100, 0);
				if (itemData != null)
				{
					itemData.Count = value;
					if (this.mItemBackground != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
					}
					if (this.mItemIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
					}
					if (this.mItemName != null)
					{
						this.mItemName.text = itemData.GetColorName(string.Empty, false);
					}
					if (this.mItemCount != null)
					{
						if (value > 1)
						{
							this.mItemCount.text = value.ToString();
						}
						else
						{
							this.mItemCount.text = string.Empty;
						}
					}
					if (this.mLimitTimeGo != null)
					{
						int num;
						bool flag;
						itemData.GetTimeLeft(out num, out flag);
						if (flag && num > 0)
						{
							this.mLimitTimeGo.CustomActive(true);
						}
						else
						{
							this.mLimitTimeGo.CustomActive(false);
						}
					}
					if (this.mItemIconBtn != null)
					{
						this.mItemIconBtn.onClick.RemoveAllListeners();
						this.mItemIconBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
					break;
				}
			}
		}

		// Token: 0x0600F9A6 RID: 63910 RVA: 0x00444250 File Offset: 0x00442650
		private void UpdateConsumeItem()
		{
			if (this.mData.NeedItems == null)
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair in this.mData.NeedItems)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(key, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(key);
					this.mExchangeConsumeName.SafeSetText(string.Format("{0}:", tableItem.Name));
					this.mExchangeConsumeDesc.SafeSetText(string.Format("{0}", value));
					if (this.mExchangeIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mExchangeIcon, tableItem.Icon, true);
					}
					this.bIsConsumeEnough = (itemCountInPackage >= value);
					break;
				}
			}
		}

		// Token: 0x0600F9A7 RID: 63911 RVA: 0x0044436C File Offset: 0x0044276C
		private void UpdateExchangeBtnState(bool isFlag)
		{
			if (this.mExchangeBtn != null)
			{
				this.mExchangeBtn.enabled = isFlag;
			}
			if (this.mExchangeGray != null)
			{
				this.mExchangeGray.enabled = !isFlag;
			}
		}

		// Token: 0x0600F9A8 RID: 63912 RVA: 0x004443AC File Offset: 0x004427AC
		private void UpdateAccounterNum(UIEvent uiEvent)
		{
			if ((ulong)((uint)uiEvent.Param1) == (ulong)((long)this.mData.Id) && (uint)uiEvent.Param2 == 4003U && this.mData.AccountTotalSubmitLimit > 0)
			{
				int num = (int)uiEvent.Param3;
				int num2 = this.mData.AccountTotalSubmitLimit - num;
				if (num2 < 0)
				{
					num2 = 0;
				}
				this.mAccountNumLeft = num2;
				this.mExchangeCountDesc.SafeSetText(TR.Value("activity_boss_exchange_item_count_account2", num2, this.mData.AccountTotalSubmitLimit));
				this.UpdateExchangeBtnState(num2 > 0 && this.bIsConsumeEnough);
			}
		}

		// Token: 0x0600F9A9 RID: 63913 RVA: 0x00444467 File Offset: 0x00442867
		public void Dispose()
		{
			this.mOnItemClick = null;
			DataManager<ActivityDataManager>.GetInstance().UnRegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.UpdateAccounterNum));
		}

		// Token: 0x0600F9AA RID: 63914 RVA: 0x00444486 File Offset: 0x00442886
		public void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x04009BB1 RID: 39857
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009BB2 RID: 39858
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009BB3 RID: 39859
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x04009BB4 RID: 39860
		[SerializeField]
		private Text mItemName;

		// Token: 0x04009BB5 RID: 39861
		[SerializeField]
		private Text mExchangeConsumeDesc;

		// Token: 0x04009BB6 RID: 39862
		[SerializeField]
		private Text mExchangeConsumeName;

		// Token: 0x04009BB7 RID: 39863
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009BB8 RID: 39864
		[SerializeField]
		private Button mExchangeBtn;

		// Token: 0x04009BB9 RID: 39865
		[SerializeField]
		private UIGray mExchangeGray;

		// Token: 0x04009BBA RID: 39866
		[SerializeField]
		private Text mExchangeCountDesc;

		// Token: 0x04009BBB RID: 39867
		[SerializeField]
		private GameObject mLimitTimeGo;

		// Token: 0x04009BBC RID: 39868
		[SerializeField]
		private Image mExchangeIcon;

		// Token: 0x04009BBD RID: 39869
		private int mId;

		// Token: 0x04009BBE RID: 39870
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009BBF RID: 39871
		private BossExchangeTaskModel mData;

		// Token: 0x04009BC0 RID: 39872
		private int mAccountNumLeft;

		// Token: 0x04009BC1 RID: 39873
		private bool bIsConsumeEnough;
	}
}
