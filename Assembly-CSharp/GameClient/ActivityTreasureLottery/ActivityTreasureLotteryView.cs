using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E8 RID: 5096
	public class ActivityTreasureLotteryView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001BE3 RID: 7139
		// (get) Token: 0x0600C58E RID: 50574 RVA: 0x002FA17D File Offset: 0x002F857D
		public int SelectId
		{
			get
			{
				return this.mMainView.SelectId;
			}
		}

		// Token: 0x17001BE4 RID: 7140
		// (get) Token: 0x0600C58F RID: 50575 RVA: 0x002FA18A File Offset: 0x002F858A
		public uint BuyCount
		{
			get
			{
				return this.mMainView.BuyCount;
			}
		}

		// Token: 0x17001BE5 RID: 7141
		// (get) Token: 0x0600C590 RID: 50576 RVA: 0x002FA197 File Offset: 0x002F8597
		public uint LeftCount
		{
			get
			{
				return this.mMainView.LeftCount;
			}
		}

		// Token: 0x17001BE6 RID: 7142
		// (get) Token: 0x0600C591 RID: 50577 RVA: 0x002FA1A4 File Offset: 0x002F85A4
		// (set) Token: 0x0600C592 RID: 50578 RVA: 0x002FA1AC File Offset: 0x002F85AC
		public EActivityTreasureLotteryView CurrentSubView { get; private set; }

		// Token: 0x17001BE7 RID: 7143
		// (set) Token: 0x0600C593 RID: 50579 RVA: 0x002FA1B8 File Offset: 0x002F85B8
		public UnityAction OnButtonCloseCallBack
		{
			set
			{
				if (this.mButtonClose != null)
				{
					if (this.mOnButtonCloseCallBack != null)
					{
						this.mButtonClose.onClick.RemoveListener(this.mOnButtonCloseCallBack);
					}
					if (value != null)
					{
						this.mOnButtonCloseCallBack = value;
						this.mButtonClose.onClick.AddListener(this.mOnButtonCloseCallBack);
					}
				}
			}
		}

		// Token: 0x17001BE8 RID: 7144
		// (set) Token: 0x0600C594 RID: 50580 RVA: 0x002FA21A File Offset: 0x002F861A
		public UnityAction OnButtonBuyCallBack
		{
			set
			{
				this.mMainView.OnButtonBuyCallBack = value;
			}
		}

		// Token: 0x17001BE9 RID: 7145
		// (set) Token: 0x0600C595 RID: 50581 RVA: 0x002FA228 File Offset: 0x002F8628
		public UnityAction OnButtonBuyAllCallBack
		{
			set
			{
				this.mMainView.OnButtonBuyAllCallBack = value;
			}
		}

		// Token: 0x0600C596 RID: 50582 RVA: 0x002FA236 File Offset: 0x002F8636
		public void Init(IActivityTreasureLotteryDataMananger dataManager, string mainViewItemPrefabPath, UnityAction onChangeSubView, EActivityTreasureLotteryView viewType = EActivityTreasureLotteryView.ActivityView)
		{
			this.mDataManager = dataManager;
			this.mMainViewPrefabPath = mainViewItemPrefabPath;
			this.mOnChangeSubView = onChangeSubView;
			this.BindEvents();
			this.ShowSubView(viewType);
		}

		// Token: 0x0600C597 RID: 50583 RVA: 0x002FA25B File Offset: 0x002F865B
		public void Dispose()
		{
			this.UnBindEvents();
			this.DisposePreView();
			this.mDataManager = null;
			this.mOnChangeSubView = null;
		}

		// Token: 0x0600C598 RID: 50584 RVA: 0x002FA277 File Offset: 0x002F8677
		public void UpdateData()
		{
			if (this.mCurrentView != null)
			{
				this.mCurrentView.UpdateData();
			}
		}

		// Token: 0x0600C599 RID: 50585 RVA: 0x002FA290 File Offset: 0x002F8690
		public void ShowSubView(EActivityTreasureLotteryView viewType)
		{
			if (this.mToggleRank == null || this.mToggleMyLottery == null || this.mToggleMain == null)
			{
				return;
			}
			if (viewType != EActivityTreasureLotteryView.ActivityView)
			{
				if (viewType != EActivityTreasureLotteryView.HistoryView)
				{
					if (viewType == EActivityTreasureLotteryView.MyLotteryView)
					{
						this.mToggleRank.isOn = false;
						this.mToggleMyLottery.isOn = true;
						this.mToggleMain.isOn = false;
					}
				}
				else
				{
					this.mToggleRank.isOn = true;
					this.mToggleMyLottery.isOn = false;
					this.mToggleMain.isOn = false;
				}
			}
			else
			{
				this.mToggleRank.isOn = false;
				this.mToggleMyLottery.isOn = false;
				this.mToggleMain.isOn = true;
			}
		}

		// Token: 0x0600C59A RID: 50586 RVA: 0x002FA365 File Offset: 0x002F8765
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0600C59B RID: 50587 RVA: 0x002FA370 File Offset: 0x002F8770
		private void BindEvents()
		{
			if (this.mToggleRank != null)
			{
				this.mToggleRank.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleHistory));
			}
			if (this.mToggleMain != null)
			{
				this.mToggleMain.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleMain));
			}
			if (this.mToggleMyLottery != null)
			{
				this.mToggleMyLottery.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleMyLottery));
			}
		}

		// Token: 0x0600C59C RID: 50588 RVA: 0x002FA404 File Offset: 0x002F8804
		private void UnBindEvents()
		{
			if (this.mToggleRank != null)
			{
				this.mToggleRank.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleHistory));
			}
			if (this.mToggleMain != null)
			{
				this.mToggleMain.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleMain));
			}
			if (this.mToggleMyLottery != null)
			{
				this.mToggleMyLottery.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleMyLottery));
			}
		}

		// Token: 0x0600C59D RID: 50589 RVA: 0x002FA498 File Offset: 0x002F8898
		private void OnToggleMain(bool value)
		{
			if (value)
			{
				this.DisposePreView();
				if (this.mMainView != null)
				{
					this.mMainView.Init(this.mDataManager, this.mMainViewPrefabPath, this.mScrollList);
					this.CurrentSubView = EActivityTreasureLotteryView.ActivityView;
					this.mCurrentView = this.mMainView;
					this.mOnChangeSubView.Invoke();
				}
			}
		}

		// Token: 0x0600C59E RID: 50590 RVA: 0x002FA500 File Offset: 0x002F8900
		private void OnToggleMyLottery(bool value)
		{
			if (value)
			{
				this.DisposePreView();
				if (this.mMyLotteryView != null)
				{
					this.mMyLotteryView.Init(this.mDataManager, this.mMainViewPrefabPath, this.mScrollList);
					this.CurrentSubView = EActivityTreasureLotteryView.MyLotteryView;
					this.mCurrentView = this.mMyLotteryView;
					this.mOnChangeSubView.Invoke();
				}
			}
		}

		// Token: 0x0600C59F RID: 50591 RVA: 0x002FA568 File Offset: 0x002F8968
		private void OnToggleHistory(bool value)
		{
			if (value)
			{
				this.DisposePreView();
				if (this.mHistroyView != null)
				{
					this.mHistroyView.Init(this.mDataManager, this.mMainViewPrefabPath, this.mScrollList);
					this.CurrentSubView = EActivityTreasureLotteryView.HistoryView;
					this.mCurrentView = this.mHistroyView;
					this.mOnChangeSubView.Invoke();
				}
			}
		}

		// Token: 0x0600C5A0 RID: 50592 RVA: 0x002FA5CD File Offset: 0x002F89CD
		private void DisposePreView()
		{
			if (this.mCurrentView != null)
			{
				this.mCurrentView.Dispose();
				this.mCurrentView = null;
			}
		}

		// Token: 0x0600C5A1 RID: 50593 RVA: 0x002FA5EC File Offset: 0x002F89EC
		private void Update()
		{
			if (this.mDataManager != null)
			{
				ETreasureLotterState state = this.mDataManager.GetState();
				if (state != ETreasureLotterState.Prepare)
				{
					if (state == ETreasureLotterState.Open)
					{
						this.mTextTimeLeft.SafeSetText(TR.Value("activity_treasure_lottery_time_end") + this.mDataManager.GetRemainTime());
					}
				}
				else
				{
					this.mTextTimeLeft.SafeSetText(TR.Value("activity_treasure_lottery_time_begin") + this.mDataManager.GetRemainTime());
				}
			}
		}

		// Token: 0x040070E1 RID: 28897
		private UnityAction mOnButtonCloseCallBack;

		// Token: 0x040070E2 RID: 28898
		[SerializeField]
		private ActivityTreasureLotteryActivityView mMainView;

		// Token: 0x040070E3 RID: 28899
		[SerializeField]
		private ActivityTreasureLotteryHistroyView mHistroyView;

		// Token: 0x040070E4 RID: 28900
		[SerializeField]
		private ActivityTreasureLotteryMyLotteryView mMyLotteryView;

		// Token: 0x040070E5 RID: 28901
		[SerializeField]
		private Text mTextTimeLeft;

		// Token: 0x040070E6 RID: 28902
		[SerializeField]
		private Toggle mToggleMain;

		// Token: 0x040070E7 RID: 28903
		[SerializeField]
		private Toggle mToggleMyLottery;

		// Token: 0x040070E8 RID: 28904
		[SerializeField]
		private Toggle mToggleRank;

		// Token: 0x040070E9 RID: 28905
		[SerializeField]
		private Button mButtonClose;

		// Token: 0x040070EA RID: 28906
		[SerializeField]
		private ComUIListScript mScrollList;

		// Token: 0x040070EB RID: 28907
		private IActivityTreasureLotteryActivityViewBase mCurrentView;

		// Token: 0x040070EC RID: 28908
		private IActivityTreasureLotteryDataMananger mDataManager;

		// Token: 0x040070ED RID: 28909
		private string mMainViewPrefabPath;

		// Token: 0x040070EE RID: 28910
		private string mMyLotteryViewPrefabPath;

		// Token: 0x040070EF RID: 28911
		private UnityAction mOnChangeSubView;
	}
}
