using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200137E RID: 4990
	public class ActivityFinancialRewardItem : MonoBehaviour
	{
		// Token: 0x0600C1A5 RID: 49573 RVA: 0x002E2779 File Offset: 0x002E0B79
		private void Start()
		{
			if (this.receivedButton != null)
			{
				this.receivedButton.onClick.RemoveAllListeners();
				this.receivedButton.onClick.AddListener(new UnityAction(this.OnReceiveButtonClick));
			}
		}

		// Token: 0x0600C1A6 RID: 49574 RVA: 0x002E27B8 File Offset: 0x002E0BB8
		private void OnDestroy()
		{
			if (this.receivedButton != null)
			{
				this.receivedButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600C1A7 RID: 49575 RVA: 0x002E27DB File Offset: 0x002E0BDB
		public void Init(FinancialPlanRewardModel curData)
		{
			this.dataItem = curData;
			this.InitRewardItemContent();
		}

		// Token: 0x0600C1A8 RID: 49576 RVA: 0x002E27EC File Offset: 0x002E0BEC
		private void InitRewardItemContent()
		{
			this.levelNeedReachedText.text = string.Format(TR.Value("financial_plan_level_limit"), this.dataItem.LevelLimit);
			this.unBuyText.text = TR.Value("financial_plan_not_buy_text");
			this.unFinishedText.text = TR.Value("financial_plan_unfinished_text");
			this.unReceivedText.text = TR.Value("financial_plan_cannot_received");
			this.InitRewardItemLevelLimit();
			this.InitRewardItemList();
			this.InitRewardItemState();
		}

		// Token: 0x0600C1A9 RID: 49577 RVA: 0x002E2874 File Offset: 0x002E0C74
		private void UpdateLevelInfo(bool flag)
		{
			if (this.levelRoot != null)
			{
				this.levelRoot.CustomActive(flag);
			}
			if (this.buyReceivedText != null)
			{
				this.buyReceivedText.gameObject.CustomActive(!flag);
			}
		}

		// Token: 0x0600C1AA RID: 49578 RVA: 0x002E28C4 File Offset: 0x002E0CC4
		private void InitRewardItemLevelLimit()
		{
			int levelLimit = this.dataItem.LevelLimit;
			this.UpdateLevelInfo(true);
			if (levelLimit == 0)
			{
				this.UpdateLevelInfo(false);
			}
			else if (levelLimit < 10)
			{
				this.oneNumberImg.CustomActive(true);
				this.firstNumberImg.CustomActive(false);
				this.secondNumberImg.CustomActive(false);
				string path = this.numberPathPrefix + levelLimit;
				ETCImageLoader.LoadSprite(ref this.oneNumberImg, path, true);
			}
			else
			{
				this.oneNumberImg.CustomActive(false);
				this.firstNumberImg.CustomActive(true);
				this.secondNumberImg.CustomActive(true);
				string path2 = this.numberPathPrefix + levelLimit / 10;
				string path3 = this.numberPathPrefix + levelLimit % 10;
				ETCImageLoader.LoadSprite(ref this.firstNumberImg, path2, true);
				ETCImageLoader.LoadSprite(ref this.secondNumberImg, path3, true);
			}
		}

		// Token: 0x0600C1AB RID: 49579 RVA: 0x002E29B4 File Offset: 0x002E0DB4
		private void InitRewardItemList()
		{
			if (this.rewardItemRoot == null)
			{
				return;
			}
			if (this.dataItem.RewardItemList.Count > 0)
			{
				int itemID = this.dataItem.RewardItemList[0].ItemID;
				int count = this.dataItem.RewardItemList[0].Count;
				if (this._comRewardItem == null)
				{
					this._comRewardItem = ComItemManager.Create(this.rewardItemRoot.gameObject);
				}
				this._comRewardItem.CustomActive(true);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
				itemData.Count = count;
				this._comRewardItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			}
			else if (this._comRewardItem != null)
			{
				this._comRewardItem.CustomActive(false);
			}
		}

		// Token: 0x0600C1AC RID: 49580 RVA: 0x002E2A98 File Offset: 0x002E0E98
		private void InitRewardItemState()
		{
			switch (this.dataItem.ShowRewardState)
			{
			case FinancialPlanState.UnBuy:
				this.unBuyText.CustomActive(true);
				this.unFinishedText.CustomActive(false);
				this.receivedButton.CustomActive(false);
				this.receivedFlag.CustomActive(false);
				this.unReceivedText.CustomActive(false);
				break;
			case FinancialPlanState.UnAcommpolished:
				this.unBuyText.CustomActive(false);
				this.unFinishedText.CustomActive(true);
				this.receivedButton.CustomActive(false);
				this.receivedFlag.CustomActive(false);
				this.unReceivedText.CustomActive(false);
				break;
			case FinancialPlanState.Finished:
				this.unBuyText.CustomActive(false);
				this.unFinishedText.CustomActive(false);
				this.receivedButton.CustomActive(true);
				this.receivedFlag.CustomActive(false);
				this.unReceivedText.CustomActive(false);
				break;
			case FinancialPlanState.Received:
				this.unBuyText.CustomActive(false);
				this.unFinishedText.CustomActive(false);
				this.receivedButton.CustomActive(false);
				this.receivedFlag.CustomActive(true);
				this.unReceivedText.CustomActive(false);
				break;
			case FinancialPlanState.UnReceived:
				this.unBuyText.CustomActive(false);
				this.unFinishedText.CustomActive(false);
				this.receivedButton.CustomActive(false);
				this.receivedFlag.CustomActive(false);
				this.unReceivedText.CustomActive(true);
				break;
			default:
				this.unBuyText.CustomActive(false);
				this.unFinishedText.CustomActive(false);
				this.receivedButton.CustomActive(false);
				this.receivedFlag.CustomActive(false);
				this.unReceivedText.CustomActive(false);
				break;
			}
		}

		// Token: 0x0600C1AD RID: 49581 RVA: 0x002E2C56 File Offset: 0x002E1056
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C1AE RID: 49582 RVA: 0x002E2C6E File Offset: 0x002E106E
		private void OnReceiveButtonClick()
		{
			if (this.dataItem != null)
			{
				DataManager<FinancialPlanDataManager>.GetInstance().PreReceivedRewardIndex = this.dataItem.Index;
				DataManager<FinancialPlanDataManager>.GetInstance().SendReceivedRewardItemReq(this.dataItem.Id);
			}
		}

		// Token: 0x04006DA0 RID: 28064
		private readonly string numberPathPrefix = "UI/Image/Packed/p_UI_Fuli.png:UI_Fuli_Qiandao_Teshuzi_0";

		// Token: 0x04006DA1 RID: 28065
		private FinancialPlanRewardModel dataItem;

		// Token: 0x04006DA2 RID: 28066
		[SerializeField]
		private Text levelNeedReachedText;

		// Token: 0x04006DA3 RID: 28067
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x04006DA4 RID: 28068
		[SerializeField]
		private Image oneNumberImg;

		// Token: 0x04006DA5 RID: 28069
		[SerializeField]
		private Image firstNumberImg;

		// Token: 0x04006DA6 RID: 28070
		[SerializeField]
		private Image secondNumberImg;

		// Token: 0x04006DA7 RID: 28071
		[SerializeField]
		private Button receivedButton;

		// Token: 0x04006DA8 RID: 28072
		[SerializeField]
		private GameObject receivedFlag;

		// Token: 0x04006DA9 RID: 28073
		[SerializeField]
		private Text unBuyText;

		// Token: 0x04006DAA RID: 28074
		[SerializeField]
		private Text unFinishedText;

		// Token: 0x04006DAB RID: 28075
		[SerializeField]
		private Text unReceivedText;

		// Token: 0x04006DAC RID: 28076
		[Space(10f)]
		[Header("BuyReceivedContent")]
		[Space(10f)]
		[SerializeField]
		private GameObject levelRoot;

		// Token: 0x04006DAD RID: 28077
		[SerializeField]
		private GameObject buyReceivedText;

		// Token: 0x04006DAE RID: 28078
		private ComItem _comRewardItem;
	}
}
