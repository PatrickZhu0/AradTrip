using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200137D RID: 4989
	public class ActivityChargeFinancialPlan : MonoBehaviour
	{
		// Token: 0x0600C18B RID: 49547 RVA: 0x002E2051 File Offset: 0x002E0451
		private void Awake()
		{
			this.InitUiTextInfo();
			this.InitRewardItem();
			this.BindUiEventSystem();
		}

		// Token: 0x0600C18C RID: 49548 RVA: 0x002E2065 File Offset: 0x002E0465
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.DestroyRewardItem();
		}

		// Token: 0x0600C18D RID: 49549 RVA: 0x002E2073 File Offset: 0x002E0473
		private void InitRewardItem()
		{
			this.InitBuyRewardItem();
			this.InitReceivedRewardItem();
		}

		// Token: 0x0600C18E RID: 49550 RVA: 0x002E2084 File Offset: 0x002E0484
		private void InitReceivedRewardItem()
		{
			if (this.receiveRewardItemRoot == null)
			{
				return;
			}
			if (this._receivedComRewardItem != null)
			{
				return;
			}
			int buyRewardItemId = DataManager<FinancialPlanDataManager>.GetInstance().BuyRewardItemId;
			if (this._receivedComRewardItem == null)
			{
				this._receivedComRewardItem = ComItemManager.Create(this.receiveRewardItemRoot.gameObject);
			}
			if (this._receivedComRewardItem != null)
			{
				ItemData item = ItemDataManager.CreateItemDataFromTable(buyRewardItemId, 100, 0);
				this._receivedComRewardItem.Setup(item, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x0600C18F RID: 49551 RVA: 0x002E211C File Offset: 0x002E051C
		private void InitBuyRewardItem()
		{
			if (this.buyItemRoot == null)
			{
				return;
			}
			if (this._buyComRewardItem != null)
			{
				return;
			}
			int buyRewardItemId = DataManager<FinancialPlanDataManager>.GetInstance().BuyRewardItemId;
			if (this._buyComRewardItem == null)
			{
				this._buyComRewardItem = ComItemManager.Create(this.buyItemRoot.gameObject);
			}
			if (this._buyComRewardItem != null)
			{
				ItemData item = ItemDataManager.CreateItemDataFromTable(buyRewardItemId, 100, 0);
				this._buyComRewardItem.Setup(item, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x0600C190 RID: 49552 RVA: 0x002E21B4 File Offset: 0x002E05B4
		private void DestroyRewardItem()
		{
			if (this._buyComRewardItem != null)
			{
				ComItemManager.Destroy(this._buyComRewardItem);
				this._buyComRewardItem = null;
			}
			if (this._receivedComRewardItem != null)
			{
				ComItemManager.Destroy(this._receivedComRewardItem);
				this._receivedComRewardItem = null;
			}
		}

		// Token: 0x0600C191 RID: 49553 RVA: 0x002E2208 File Offset: 0x002E0608
		private void InitUiTextInfo()
		{
			this.receivedRewardLabelText.text = TR.Value("financial_plan_received_text");
			this.buyDesText.text = TR.Value("financial_plan_buy_received");
			this.buyText.text = TR.Value("financial_plan_buy");
			this.buyRewardNumberText.text = string.Format("{0}", DataManager<FinancialPlanDataManager>.GetInstance().BuyReceivedItemNumber);
			this.otherRoleOwnedText.text = TR.Value("financial_plan_other_role_owned");
			this.roleLimitText.text = TR.Value("financial_plan_role_limit");
			this.playDescriptionText.text = TR.Value("financial_plan_introducation");
			this.rewardDescriptionText.text = string.Format(TR.Value("financial_plan_reward_content"), DataManager<FinancialPlanDataManager>.GetInstance().TotalRewardNumber);
		}

		// Token: 0x0600C192 RID: 49554 RVA: 0x002E22E0 File Offset: 0x002E06E0
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyFinancialPlan));
			}
			if (this.rewardScrollList != null)
			{
				this.rewardScrollList.Initialize();
				ComUIListScript comUIListScript = this.rewardScrollList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
				ComUIListScript comUIListScript2 = this.rewardScrollList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
			}
		}

		// Token: 0x0600C193 RID: 49555 RVA: 0x002E2388 File Offset: 0x002E0788
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			if (this.rewardScrollList != null)
			{
				ComUIListScript comUIListScript = this.rewardScrollList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
				ComUIListScript comUIListScript2 = this.rewardScrollList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
			}
		}

		// Token: 0x0600C194 RID: 49556 RVA: 0x002E2417 File Offset: 0x002E0817
		private void OnEnable()
		{
			DataManager<FinancialPlanDataManager>.GetInstance().ResetRedPointTip();
			this.BindEvents();
			this.UpdateFinancialPlanContent();
		}

		// Token: 0x0600C195 RID: 49557 RVA: 0x002E242F File Offset: 0x002E082F
		private void OnDisable()
		{
			this.UnBindEvents();
			DataManager<FinancialPlanDataManager>.GetInstance().PreReceivedRewardIndex = -1;
		}

		// Token: 0x0600C196 RID: 49558 RVA: 0x002E2444 File Offset: 0x002E0844
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanBuyRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanBuyRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanReceivedRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanReceivedRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanLevelSync, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanLevelSync));
		}

		// Token: 0x0600C197 RID: 49559 RVA: 0x002E24A4 File Offset: 0x002E08A4
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanBuyRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanBuyRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanReceivedRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanReceivedRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanLevelSync, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanLevelSync));
		}

		// Token: 0x0600C198 RID: 49560 RVA: 0x002E2502 File Offset: 0x002E0902
		private void OnFinancialPlanBuyRes(UIEvent eventData)
		{
			this.UpdateRewardBoughtStatus();
			this.UpdateRewardItemList();
		}

		// Token: 0x0600C199 RID: 49561 RVA: 0x002E2510 File Offset: 0x002E0910
		private void OnFinancialPlanReceivedRes(UIEvent eventData)
		{
			this.UpdateRewardReceivedNumber();
			this.UpdateRewardItemList();
		}

		// Token: 0x0600C19A RID: 49562 RVA: 0x002E251E File Offset: 0x002E091E
		private void OnFinancialPlanLevelSync(UIEvent eventData)
		{
			this.UpdateRewardItemList();
		}

		// Token: 0x0600C19B RID: 49563 RVA: 0x002E2526 File Offset: 0x002E0926
		private void UpdateFinancialPlanContent()
		{
			this.UpdateRewardReceivedNumber();
			this.UpdateRewardBoughtStatus();
			DataManager<FinancialPlanDataManager>.GetInstance().UpdateShowRewardState();
			this.UpdateRewardItemList();
		}

		// Token: 0x0600C19C RID: 49564 RVA: 0x002E2544 File Offset: 0x002E0944
		private void UpdateRewardReceivedNumber()
		{
			this.receivedRewardRateText.text = string.Format(TR.Value("financial_plan_received_reward"), DataManager<FinancialPlanDataManager>.GetInstance().CurrentRewardNumber, DataManager<FinancialPlanDataManager>.GetInstance().TotalRewardNumber);
		}

		// Token: 0x0600C19D RID: 49565 RVA: 0x002E2580 File Offset: 0x002E0980
		private void UpdateRewardBoughtStatus()
		{
			if (!DataManager<FinancialPlanDataManager>.GetInstance().IsCanBuyFinancialPlan)
			{
				this.unBuyContent.CustomActive(false);
				this.receivedContent.CustomActive(false);
				this.unReceivedContent.CustomActive(true);
			}
			else if (!DataManager<FinancialPlanDataManager>.GetInstance().IsAlreadyBuyFinancialPlan)
			{
				this.unBuyContent.CustomActive(true);
				this.receivedContent.CustomActive(false);
				this.unReceivedContent.CustomActive(false);
			}
			else
			{
				this.unBuyContent.CustomActive(false);
				this.receivedContent.CustomActive(true);
				this.unReceivedContent.CustomActive(false);
			}
		}

		// Token: 0x0600C19E RID: 49566 RVA: 0x002E2624 File Offset: 0x002E0A24
		private void UpdateRewardItemList()
		{
			if (this.rewardScrollList == null)
			{
				return;
			}
			this.rewardScrollList.SetElementAmount(0);
			this.rewardScrollList.ResetContentPosition();
			this.rewardScrollList.SetElementAmount(DataManager<FinancialPlanDataManager>.GetInstance().GetRewardModelCount());
			this.MoveScrollListToFirstReward();
		}

		// Token: 0x0600C19F RID: 49567 RVA: 0x002E2678 File Offset: 0x002E0A78
		private void MoveScrollListToFirstReward()
		{
			int firstReceivedRewardModelIndex = DataManager<FinancialPlanDataManager>.GetInstance().GetFirstReceivedRewardModelIndex();
			if (firstReceivedRewardModelIndex <= 1)
			{
				this.rewardScrollList.MoveElementInScrollArea(0, true);
			}
			else if (firstReceivedRewardModelIndex >= DataManager<FinancialPlanDataManager>.GetInstance().GetRewardModelCount() - 2)
			{
				this.rewardScrollList.MoveElementInScrollArea(DataManager<FinancialPlanDataManager>.GetInstance().GetRewardModelCount() - 1, true);
			}
			else
			{
				this.rewardScrollList.MoveElementInScrollArea(firstReceivedRewardModelIndex + 1, true);
			}
		}

		// Token: 0x0600C1A0 RID: 49568 RVA: 0x002E26E8 File Offset: 0x002E0AE8
		protected virtual void OnItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ActivityFinancialRewardItem component = item.GetComponent<ActivityFinancialRewardItem>();
			FinancialPlanRewardModel rewardModelByIndex = DataManager<FinancialPlanDataManager>.GetInstance().GetRewardModelByIndex(item.m_index);
			if (rewardModelByIndex != null && component != null)
			{
				component.Init(rewardModelByIndex);
			}
		}

		// Token: 0x0600C1A1 RID: 49569 RVA: 0x002E2733 File Offset: 0x002E0B33
		protected virtual void OnItemSelected(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
		}

		// Token: 0x0600C1A2 RID: 49570 RVA: 0x002E2742 File Offset: 0x002E0B42
		private void OnBuyFinancialPlan()
		{
			DataManager<FinancialPlanDataManager>.GetInstance().SendBuyFinancialPlanReq();
		}

		// Token: 0x0600C1A3 RID: 49571 RVA: 0x002E274E File Offset: 0x002E0B4E
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x04006D8E RID: 28046
		[SerializeField]
		private Text buyText;

		// Token: 0x04006D8F RID: 28047
		[SerializeField]
		private Text buyDesText;

		// Token: 0x04006D90 RID: 28048
		[SerializeField]
		private Text buyRewardNumberText;

		// Token: 0x04006D91 RID: 28049
		[SerializeField]
		private GameObject buyItemRoot;

		// Token: 0x04006D92 RID: 28050
		[SerializeField]
		private Text roleLimitText;

		// Token: 0x04006D93 RID: 28051
		[SerializeField]
		private Button buyButton;

		// Token: 0x04006D94 RID: 28052
		[SerializeField]
		private Text receivedRewardLabelText;

		// Token: 0x04006D95 RID: 28053
		[SerializeField]
		private Text receivedRewardRateText;

		// Token: 0x04006D96 RID: 28054
		[SerializeField]
		private GameObject receiveRewardItemRoot;

		// Token: 0x04006D97 RID: 28055
		[SerializeField]
		private Text otherRoleOwnedText;

		// Token: 0x04006D98 RID: 28056
		[SerializeField]
		private ComUIListScript rewardScrollList;

		// Token: 0x04006D99 RID: 28057
		[SerializeField]
		private Text playDescriptionText;

		// Token: 0x04006D9A RID: 28058
		[SerializeField]
		private Text rewardDescriptionText;

		// Token: 0x04006D9B RID: 28059
		[SerializeField]
		private GameObject unBuyContent;

		// Token: 0x04006D9C RID: 28060
		[SerializeField]
		private GameObject receivedContent;

		// Token: 0x04006D9D RID: 28061
		[SerializeField]
		private GameObject unReceivedContent;

		// Token: 0x04006D9E RID: 28062
		private ComItem _buyComRewardItem;

		// Token: 0x04006D9F RID: 28063
		private ComItem _receivedComRewardItem;
	}
}
