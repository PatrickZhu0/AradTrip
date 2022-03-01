using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200006B RID: 107
	internal class DiamondsActiveControl : MonoBehaviour
	{
		// Token: 0x06000250 RID: 592 RVA: 0x00012340 File Offset: 0x00010740
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MonthCardChanged, new ClientEventSystem.UIEventHandler(this._HandleUpdate));
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			ComCommonBind component = base.GetComponent<ComCommonBind>();
			if (component != null)
			{
				this.btnBuyAgain = component.GetCom<Button>("btnBuyAgain");
				if (this.btnBuyAgain != null)
				{
					this.btnBuyAgain.onClick.AddListener(new UnityAction(this._onBtnBuyAgainButtonClick));
				}
				this.btnRewardLockers = component.GetCom<Button>("BtnRewardLockers");
				if (this.btnRewardLockers != null)
				{
					this.btnRewardLockers.onClick.AddListener(new UnityAction(this._onBtnOpenRewardLockers));
				}
				this.btnRewardLockersGray = component.GetCom<UIGray>("BtnRewardLockersGray");
				this.monthCardDesc = component.GetCom<Text>("MonthCardDesc");
				this.lockerRedPointGo = component.GetGameObject("MonthCardLockerRedPoint");
				this.btnEffectRoot = component.GetGameObject("btnEffectRoot");
				this.btnAnim = component.GetCom<DOTweenAnimation>("btnAnim");
			}
			this._Update();
			this._RefreshMonthCardContents();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardUpdate));
			DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqMonthCardRewardLockersItems();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00012512 File Offset: 0x00010912
		private void _onBtnBuyAgainButtonClick()
		{
			ActiveChargeFrame.CloseMe();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00012530 File Offset: 0x00010930
		private void _onBtnOpenRewardLockers()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MonthCardRewardLockersFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00012544 File Offset: 0x00010944
		private void _HandleUpdate(UIEvent uiEvent)
		{
			this._Update();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0001254C File Offset: 0x0001094C
		private void _Update()
		{
			ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(2500);
			bool flag = false;
			if (childActiveData != null && childActiveData.status != 1 && childActiveData.status != 0)
			{
				flag = true;
			}
			if (this.VipShowList != null)
			{
				for (int i = 0; i < this.VipShowList.Count; i++)
				{
					this.VipShowList[i].CustomActive(flag);
				}
			}
			if (this.VipHideList != null)
			{
				for (int j = 0; j < this.VipHideList.Count; j++)
				{
					this.VipHideList[j].CustomActive(!flag);
				}
			}
			this._RefreshBtnRewardLockersStatus();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00012605 File Offset: 0x00010A05
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0001260D File Offset: 0x00010A0D
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00012615 File Offset: 0x00010A15
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this._Update();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0001261D File Offset: 0x00010A1D
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00012628 File Offset: 0x00010A28
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MonthCardChanged, new ClientEventSystem.UIEventHandler(this._HandleUpdate));
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			if (this.btnBuyAgain != null)
			{
				this.btnBuyAgain.onClick.RemoveListener(new UnityAction(this._onBtnBuyAgainButtonClick));
			}
			if (this.btnRewardLockers != null)
			{
				this.btnRewardLockers.onClick.RemoveListener(new UnityAction(this._onBtnOpenRewardLockers));
			}
			this.btnRewardLockersGray = null;
			this.monthCardDesc = null;
			this.lockerRedPointGo = null;
			this.btnEffectRoot = null;
			this.btnAnim = null;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MonthCardRewardLockersFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MonthCardRewardLockersFrame>(null, false);
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardUpdate));
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0001279C File Offset: 0x00010B9C
		private void _RefreshBtnRewardLockersStatus()
		{
			bool flag = DataManager<MonthCardRewardLockersDataManager>.GetInstance().IsMonthCardRewardLockersEmpty();
			bool flag2 = !flag;
			if (this.btnRewardLockers)
			{
				this.btnRewardLockers.enabled = flag2;
			}
			if (this.btnRewardLockersGray)
			{
				this.btnRewardLockersGray.enabled = !flag2;
			}
			bool flag3 = DataManager<MonthCardRewardLockersDataManager>.GetInstance().IsRedPointShow();
			if (this.lockerRedPointGo)
			{
				this.lockerRedPointGo.CustomActive(flag3);
			}
			if (this.btnEffectRoot)
			{
				this.btnEffectRoot.CustomActive(flag3);
			}
			if (this.btnAnim)
			{
				if (flag3)
				{
					this.btnAnim.DORestart(false);
				}
				else
				{
					this.btnAnim.DOPause();
				}
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0001286C File Offset: 0x00010C6C
		private void _RefreshMonthCardContents()
		{
			CommonHelpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonHelpTable>(this.mComHelpNewTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("CommonHelpTable is null and helpId is {0}", new object[]
				{
					this.mComHelpNewTableId
				});
				return;
			}
			string descs = tableItem.Descs;
			if (string.IsNullOrEmpty(descs))
			{
				return;
			}
			if (this.monthCardDesc)
			{
				this.monthCardDesc.text = descs.Replace("\\n", "\n");
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000128F7 File Offset: 0x00010CF7
		private void _OnMonthCardRewardUpdate(UIEvent uiEvent)
		{
			this._RefreshBtnRewardLockersStatus();
		}

		// Token: 0x0400024D RID: 589
		public List<GameObject> VipShowList;

		// Token: 0x0400024E RID: 590
		public List<GameObject> VipHideList;

		// Token: 0x0400024F RID: 591
		public int mComHelpNewTableId = 6200;

		// Token: 0x04000250 RID: 592
		private Button btnBuyAgain;

		// Token: 0x04000251 RID: 593
		private Button btnRewardLockers;

		// Token: 0x04000252 RID: 594
		private UIGray btnRewardLockersGray;

		// Token: 0x04000253 RID: 595
		private Text monthCardDesc;

		// Token: 0x04000254 RID: 596
		private GameObject lockerRedPointGo;

		// Token: 0x04000255 RID: 597
		private GameObject btnEffectRoot;

		// Token: 0x04000256 RID: 598
		private DOTweenAnimation btnAnim;
	}
}
