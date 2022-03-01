using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001697 RID: 5783
	public class HorseGamblingSupplyView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C80 RID: 7296
		// (get) Token: 0x0600E317 RID: 58135 RVA: 0x003A5B25 File Offset: 0x003A3F25
		public int BulletId
		{
			get
			{
				return this.mBulletItemId;
			}
		}

		// Token: 0x17001C81 RID: 7297
		// (get) Token: 0x0600E318 RID: 58136 RVA: 0x003A5B2D File Offset: 0x003A3F2D
		// (set) Token: 0x0600E319 RID: 58137 RVA: 0x003A5B35 File Offset: 0x003A3F35
		public int SupplyCount { get; private set; }

		// Token: 0x0600E31A RID: 58138 RVA: 0x003A5B40 File Offset: 0x003A3F40
		public void Init(string name, string icon, float odds, int leftSupply, UnityAction onConfirmClick, UnityAction onClose)
		{
			this.mTextName.SafeSetText(name);
			if (!string.IsNullOrEmpty(icon))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, icon, true);
			}
			this.mTextOdds.SafeSetText(string.Format(TR.Value("horse_gambling_supply_view_odds"), odds));
			this.mTextSupplyTip.SafeSetText(string.Format(TR.Value("horse_gambling_left_supply"), leftSupply));
			this.mButtonMax.SafeAddOnClickListener(new UnityAction(this.OnMaxClick));
			this.mButtonCountInput.SafeAddOnClickListener(new UnityAction(this.OnKeyBoardClick));
			this.mButtonConfirm.SafeAddOnClickListener(onConfirmClick);
			this.mButtonClose.SafeAddOnClickListener(onClose);
			this.SupplyCount = 0;
			this.mLeftSupplyCount = leftSupply;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600E31B RID: 58139 RVA: 0x003A5C28 File Offset: 0x003A4028
		public void Dispose()
		{
			this.mButtonMax.SafeRemoveOnClickListener(new UnityAction(this.OnMaxClick));
			this.mButtonCountInput.SafeRemoveOnClickListener(new UnityAction(this.OnKeyBoardClick));
			this.mButtonConfirm.SafeRemoveAllListener();
			this.mButtonClose.SafeRemoveAllListener();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600E31C RID: 58140 RVA: 0x003A5C94 File Offset: 0x003A4094
		public void UpdateStakeNum(int leftSupply)
		{
			this.mTextSupplyTip.SafeSetText(string.Format(TR.Value("horse_gambling_left_supply"), leftSupply));
		}

		// Token: 0x0600E31D RID: 58141 RVA: 0x003A5CB6 File Offset: 0x003A40B6
		public void SetConfirmEnable(bool value)
		{
			this.mButtonConfirm.interactable = value;
		}

		// Token: 0x0600E31E RID: 58142 RVA: 0x003A5CC4 File Offset: 0x003A40C4
		private void OnChangeNum(UIEvent uiEvent)
		{
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			if (changeNumType == ChangeNumType.BackSpace)
			{
				if (this.SupplyCount < 10)
				{
					this.OnMinClick();
					this.mIsFirstNum = true;
				}
				else
				{
					this.SetSupplyCount(this.SupplyCount / 10);
				}
			}
			else if (changeNumType == ChangeNumType.Add)
			{
				int num = (int)uiEvent.Param2;
				if (num < 0 || num > 9)
				{
					Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
					return;
				}
				if (this.mIsFirstNum)
				{
					if (num != 0)
					{
						this.SupplyCount = num;
						this.mIsFirstNum = false;
					}
					else
					{
						this.SupplyCount = 0;
					}
				}
				else
				{
					this.SupplyCount = this.SupplyCount * 10 + num;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBulletItemId, false);
				if (this.SupplyCount > this.mLeftSupplyCount)
				{
					SystemNotifyManager.SystemNotify(9930, string.Empty);
				}
				else if (ownedItemCount == 0)
				{
					SystemNotifyManager.SystemNotify(9928, string.Empty);
				}
				int num2 = Mathf.Min(ownedItemCount, this.mLeftSupplyCount);
				if (this.SupplyCount >= num2)
				{
					this.SupplyCount = num2;
				}
				this.SetSupplyCount(this.SupplyCount);
			}
		}

		// Token: 0x0600E31F RID: 58143 RVA: 0x003A5E03 File Offset: 0x003A4203
		private void OnKeyBoardClick()
		{
			this.mIsFirstNum = true;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, this.mKeyBoardOffsetX, string.Empty);
		}

		// Token: 0x0600E320 RID: 58144 RVA: 0x003A5E28 File Offset: 0x003A4228
		private void OnMaxClick()
		{
			this.SetSupplyCount(Mathf.Min(DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBulletItemId, false), this.mLeftSupplyCount));
		}

		// Token: 0x0600E321 RID: 58145 RVA: 0x003A5E4C File Offset: 0x003A424C
		private void OnMinClick()
		{
			this.SetSupplyCount(0);
		}

		// Token: 0x0600E322 RID: 58146 RVA: 0x003A5E55 File Offset: 0x003A4255
		private void SetSupplyCount(int count)
		{
			this.mTextSupplyCount.SafeSetText(count.ToString());
			this.SupplyCount = count;
		}

		// Token: 0x04008808 RID: 34824
		[SerializeField]
		private Text mTextName;

		// Token: 0x04008809 RID: 34825
		[SerializeField]
		private Image mImageIcon;

		// Token: 0x0400880A RID: 34826
		[SerializeField]
		private Text mTextOdds;

		// Token: 0x0400880B RID: 34827
		[SerializeField]
		private Text mTextSupplyTip;

		// Token: 0x0400880C RID: 34828
		[SerializeField]
		private Text mTextSupplyCount;

		// Token: 0x0400880D RID: 34829
		[SerializeField]
		private Button mButtonMax;

		// Token: 0x0400880E RID: 34830
		[SerializeField]
		private Button mButtonCountInput;

		// Token: 0x0400880F RID: 34831
		[SerializeField]
		private Button mButtonConfirm;

		// Token: 0x04008810 RID: 34832
		[SerializeField]
		private Button mButtonClose;

		// Token: 0x04008811 RID: 34833
		[SerializeField]
		private int mBulletItemId;

		// Token: 0x04008812 RID: 34834
		[SerializeField]
		private float mKeyBoardOffsetX = 100f;

		// Token: 0x04008814 RID: 34836
		private bool mIsFirstNum;

		// Token: 0x04008815 RID: 34837
		private int mLeftSupplyCount;
	}
}
