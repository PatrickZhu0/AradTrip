using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001682 RID: 5762
	public class HorseGamblingExchangeView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C56 RID: 7254
		// (get) Token: 0x0600E284 RID: 57988 RVA: 0x003A2FDB File Offset: 0x003A13DB
		// (set) Token: 0x0600E285 RID: 57989 RVA: 0x003A2FE3 File Offset: 0x003A13E3
		public int ExchangeCount { get; private set; }

		// Token: 0x17001C57 RID: 7255
		// (get) Token: 0x0600E286 RID: 57990 RVA: 0x003A2FEC File Offset: 0x003A13EC
		public int GoldItemId
		{
			get
			{
				return this.mGoldItemId;
			}
		}

		// Token: 0x17001C58 RID: 7256
		// (get) Token: 0x0600E287 RID: 57991 RVA: 0x003A2FF4 File Offset: 0x003A13F4
		public int ExchangeRate
		{
			get
			{
				return this.mExchangeRate;
			}
		}

		// Token: 0x0600E288 RID: 57992 RVA: 0x003A2FFC File Offset: 0x003A13FC
		public void Init(UnityAction onConfirm, UnityAction onCancel)
		{
			this.mButtonConfirm.SafeAddOnClickListener(onConfirm);
			this.mButtonCancel.SafeAddOnClickListener(onCancel);
			this.ExchangeCount = 0;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
			this.mButtonCountInput.SafeAddOnClickListener(new UnityAction(this.OnKeyBoardClick));
			this.mButtonMax.SafeAddOnClickListener(new UnityAction(this.OnMaxClick));
			this.mButtonConfirm.interactable = true;
		}

		// Token: 0x0600E289 RID: 57993 RVA: 0x003A3080 File Offset: 0x003A1480
		public void Dispose()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
			this.mButtonCountInput.SafeRemoveOnClickListener(new UnityAction(this.OnKeyBoardClick));
			this.mButtonMax.SafeRemoveOnClickListener(new UnityAction(this.OnMaxClick));
			this.mButtonConfirm.interactable = false;
		}

		// Token: 0x0600E28A RID: 57994 RVA: 0x003A30E2 File Offset: 0x003A14E2
		public void SetConfirmEnable(bool value)
		{
			this.mButtonConfirm.interactable = value;
		}

		// Token: 0x0600E28B RID: 57995 RVA: 0x003A30F0 File Offset: 0x003A14F0
		private void OnKeyBoardClick()
		{
			this.mIsFirstNum = true;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, this.mKeyBoardOffsetX, string.Empty);
		}

		// Token: 0x0600E28C RID: 57996 RVA: 0x003A3118 File Offset: 0x003A1518
		private void OnMaxClick()
		{
			int num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mGoldItemId, false) / this.mExchangeRate;
			if (num > this.mMaxBuyBulletCount)
			{
				num = this.mMaxBuyBulletCount;
				SystemNotifyManager.SystemNotify(9931, string.Empty);
			}
			this.SetBuyCount(num);
		}

		// Token: 0x0600E28D RID: 57997 RVA: 0x003A3168 File Offset: 0x003A1568
		private void OnChangeNum(UIEvent uiEvent)
		{
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			if (changeNumType == ChangeNumType.BackSpace)
			{
				if (this.ExchangeCount < 10)
				{
					this.SetBuyCount(0);
					this.mIsFirstNum = true;
				}
				else
				{
					this.SetBuyCount(this.ExchangeCount / 10);
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
						this.ExchangeCount = num;
						this.mIsFirstNum = false;
					}
					else
					{
						this.ExchangeCount = 0;
					}
				}
				else
				{
					this.ExchangeCount = this.ExchangeCount * 10 + num;
				}
				int num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mGoldItemId, false) / this.mExchangeRate;
				if (this.ExchangeCount >= num2)
				{
					this.ExchangeCount = num2;
				}
				if (this.ExchangeCount > this.mMaxBuyBulletCount)
				{
					this.ExchangeCount = this.mMaxBuyBulletCount;
					SystemNotifyManager.SystemNotify(9931, string.Empty);
				}
				this.SetBuyCount(this.ExchangeCount);
				if (num2 == 0)
				{
					SystemNotifyManager.SystemNotify(9929, string.Empty);
				}
			}
		}

		// Token: 0x0600E28E RID: 57998 RVA: 0x003A32A9 File Offset: 0x003A16A9
		private void SetBuyCount(int count)
		{
			this.mTextCostCount.SafeSetText(Utility.GetShowPrice((ulong)((long)(count * this.mExchangeRate)), false));
			this.mTextExchangeCount.SafeSetText(count.ToString());
			this.ExchangeCount = count;
		}

		// Token: 0x04008787 RID: 34695
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04008788 RID: 34696
		[SerializeField]
		private Button mButtonCountInput;

		// Token: 0x04008789 RID: 34697
		[SerializeField]
		private Button mButtonMax;

		// Token: 0x0400878A RID: 34698
		[SerializeField]
		private Text mTextCostCount;

		// Token: 0x0400878B RID: 34699
		[SerializeField]
		private Button mButtonConfirm;

		// Token: 0x0400878C RID: 34700
		[SerializeField]
		private Button mButtonCancel;

		// Token: 0x0400878D RID: 34701
		[SerializeField]
		private int mBulletItemId;

		// Token: 0x0400878E RID: 34702
		[SerializeField]
		private int mGoldItemId;

		// Token: 0x0400878F RID: 34703
		[SerializeField]
		private int mExchangeRate = 100;

		// Token: 0x04008790 RID: 34704
		[SerializeField]
		private float mKeyBoardOffsetX = 100f;

		// Token: 0x04008791 RID: 34705
		[SerializeField]
		private int mMaxBuyBulletCount = 50000;

		// Token: 0x04008792 RID: 34706
		private bool mIsFirstNum;
	}
}
