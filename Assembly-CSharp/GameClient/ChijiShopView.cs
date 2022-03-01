using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200111D RID: 4381
	public class ChijiShopView : MonoBehaviour
	{
		// Token: 0x0600A62B RID: 42539 RVA: 0x002274B3 File Offset: 0x002258B3
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600A62C RID: 42540 RVA: 0x002274BB File Offset: 0x002258BB
		private void OnDestroy()
		{
			this.chijiShopType = ChijiShopType.None;
			this.UnBindUiEvents();
			DataManager<ChijiShopDataManager>.GetInstance().ResetChijiShopData();
		}

		// Token: 0x0600A62D RID: 42541 RVA: 0x002274D4 File Offset: 0x002258D4
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClicked));
			}
			if (this.backgroundButton != null)
			{
				this.backgroundButton.onClick.RemoveAllListeners();
				this.backgroundButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClicked));
			}
			if (this.itemBuyToggle != null)
			{
				this.itemBuyToggle.onValueChanged.RemoveAllListeners();
				this.itemBuyToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnItemBuyToggleClick));
			}
			if (this.itemSellToggle != null)
			{
				this.itemSellToggle.onValueChanged.RemoveAllListeners();
				this.itemSellToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnItemSellToggleClick));
			}
			if (this.shopRefreshButton != null)
			{
				this.shopRefreshButton.onClick.RemoveAllListeners();
				this.shopRefreshButton.onClick.AddListener(new UnityAction(this.OnShopRefreshButtonClicked));
			}
		}

		// Token: 0x0600A62E RID: 42542 RVA: 0x00227614 File Offset: 0x00225A14
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.backgroundButton != null)
			{
				this.backgroundButton.onClick.RemoveAllListeners();
			}
			if (this.itemBuyToggle != null)
			{
				this.itemBuyToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.itemSellToggle != null)
			{
				this.itemSellToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.shopRefreshButton != null)
			{
				this.shopRefreshButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600A62F RID: 42543 RVA: 0x002276C6 File Offset: 0x00225AC6
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600A630 RID: 42544 RVA: 0x002276CE File Offset: 0x00225ACE
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600A631 RID: 42545 RVA: 0x002276D8 File Offset: 0x00225AD8
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCounterValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this.OnReceiveItemSellSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveSceneShopQuerySucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopQuerySucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveSceneShopRefreshSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopRefreshSucceed));
		}

		// Token: 0x0600A632 RID: 42546 RVA: 0x00227754 File Offset: 0x00225B54
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCounterValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this.OnReceiveItemSellSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveSceneShopQuerySucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopQuerySucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveSceneShopRefreshSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopRefreshSucceed));
		}

		// Token: 0x0600A633 RID: 42547 RVA: 0x002277CD File Offset: 0x00225BCD
		public void InitShopView()
		{
			DataManager<ChijiShopDataManager>.GetInstance().ResetChijiShopData();
			DataManager<ChijiShopDataManager>.GetInstance().OnSendSceneShopQueryReq(0);
			this.chijiShopType = ChijiShopType.Buy;
			this.InitGloryCoinInfo();
			this.UpdateOwnerGloryCoinValue();
			this.InitShopToggle();
			this.UpdateShopContent();
		}

		// Token: 0x0600A634 RID: 42548 RVA: 0x00227803 File Offset: 0x00225C03
		public void OnEnableShopView()
		{
			this.UpdateOwnerGloryCoinValue();
			this.UpdateShopContent();
		}

		// Token: 0x0600A635 RID: 42549 RVA: 0x00227811 File Offset: 0x00225C11
		private void UpdateShopContent()
		{
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				CommonUtility.UpdateGameObjectVisible(this.shopRefreshContentRoot, false);
				this.UpdateShopItemController();
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.shopRefreshContentRoot, true);
				this.UpdateChijiShopBuyContent();
			}
		}

		// Token: 0x0600A636 RID: 42550 RVA: 0x00227848 File Offset: 0x00225C48
		private void InitGloryCoinInfo()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(402000005, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.gloryCoinIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.gloryCoinIcon, tableItem.Icon, true);
				}
				if (this.shopRefreshCostItemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.shopRefreshCostItemIcon, tableItem.Icon, true);
				}
			}
		}

		// Token: 0x0600A637 RID: 42551 RVA: 0x002278C0 File Offset: 0x00225CC0
		private void UpdateOwnerGloryCoinValue()
		{
			int currentOwnerGloryCoinNumber = ChijiShopUtility.GetCurrentOwnerGloryCoinNumber();
			if (this.gloryCoinNumberValue != null)
			{
				this.gloryCoinNumberValue.text = currentOwnerGloryCoinNumber.ToString();
			}
		}

		// Token: 0x0600A638 RID: 42552 RVA: 0x002278FC File Offset: 0x00225CFC
		private void InitShopToggle()
		{
			if (this.itemBuyToggle != null)
			{
				this.itemBuyToggle.isOn = false;
				this.itemBuyToggle.isOn = true;
			}
		}

		// Token: 0x0600A639 RID: 42553 RVA: 0x00227927 File Offset: 0x00225D27
		private void OnItemBuyToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this.chijiShopType == ChijiShopType.Buy)
			{
				return;
			}
			this.chijiShopType = ChijiShopType.Buy;
			this.UpdateShopContent();
		}

		// Token: 0x0600A63A RID: 42554 RVA: 0x00227949 File Offset: 0x00225D49
		private void OnItemSellToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			this.chijiShopType = ChijiShopType.Sell;
			this.UpdateShopContent();
		}

		// Token: 0x0600A63B RID: 42555 RVA: 0x0022796C File Offset: 0x00225D6C
		private void UpdateShopItemController()
		{
			if (this.chijiShopItemController == null)
			{
				return;
			}
			this.chijiShopItemController.InitShopItemController(this.chijiShopType);
		}

		// Token: 0x0600A63C RID: 42556 RVA: 0x00227991 File Offset: 0x00225D91
		private void UpdateShopItemControllerByGloryCoinChanged()
		{
			if (this.chijiShopItemController == null)
			{
				return;
			}
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			this.chijiShopItemController.UpdateShopItemContentByGloryCoinChanged();
		}

		// Token: 0x0600A63D RID: 42557 RVA: 0x002279C0 File Offset: 0x00225DC0
		private void UpdateChijiShopBuyContent()
		{
			this.UpdateShopAutoRefreshRoot();
			this.UpdateShopAutoRefreshContent();
			if (this.shopRefreshCostItemValueText != null)
			{
				this.shopRefreshCostItemValueText.text = DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshCostValue.ToString();
			}
			this.UpdateRefreshButtonState();
			this.UpdateShopItemController();
		}

		// Token: 0x0600A63E RID: 42558 RVA: 0x00227A18 File Offset: 0x00225E18
		private void UpdateRefreshButtonState()
		{
			if (this.chijiShopType != ChijiShopType.Buy)
			{
				return;
			}
			if (ChijiShopUtility.GetCurrentOwnerGloryCoinNumber() >= DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshCostValue)
			{
				CommonUtility.UpdateButtonState(this.shopRefreshButton, this.shopRefreshButtonGray, true);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.shopRefreshButton, this.shopRefreshButtonGray, false);
			}
		}

		// Token: 0x0600A63F RID: 42559 RVA: 0x00227A6E File Offset: 0x00225E6E
		private void OnReceiveSceneShopQuerySucceed(UIEvent uiEvent)
		{
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			this.UpdateChijiShopBuyContent();
		}

		// Token: 0x0600A640 RID: 42560 RVA: 0x00227A83 File Offset: 0x00225E83
		private void OnReceiveSceneShopRefreshSucceed(UIEvent uiEvent)
		{
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			this.UpdateChijiShopBuyContent();
		}

		// Token: 0x0600A641 RID: 42561 RVA: 0x00227A98 File Offset: 0x00225E98
		private void OnCounterValueChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (!string.Equals(a, "chi_ji_shop_coin"))
			{
				return;
			}
			this.UpdateShopViewByOwnerGloryCoinChanged();
		}

		// Token: 0x0600A642 RID: 42562 RVA: 0x00227ADC File Offset: 0x00225EDC
		private void OnReceiveItemSellSucceed(UIEvent uiEvent)
		{
			if (this.chijiShopType != ChijiShopType.Sell)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			EPackageType epackageType = (EPackageType)uiEvent.Param1;
			if (epackageType != EPackageType.Equip)
			{
				return;
			}
			this.UpdateShopItemController();
		}

		// Token: 0x0600A643 RID: 42563 RVA: 0x00227B22 File Offset: 0x00225F22
		private void UpdateShopViewByOwnerGloryCoinChanged()
		{
			this.UpdateOwnerGloryCoinValue();
			this.UpdateRefreshButtonState();
			this.UpdateShopItemControllerByGloryCoinChanged();
		}

		// Token: 0x0600A644 RID: 42564 RVA: 0x00227B36 File Offset: 0x00225F36
		private void OnShopRefreshButtonClicked()
		{
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			if (!ChijiShopUtility.IsCanRefreshChijiShopByGloryCoin())
			{
				return;
			}
			DataManager<ChijiShopDataManager>.GetInstance().OnSendSceneShopRefreshReq(DataManager<ChijiShopDataManager>.GetInstance().ChijiShopId);
		}

		// Token: 0x0600A645 RID: 42565 RVA: 0x00227B64 File Offset: 0x00225F64
		private void OnCloseButtonClicked()
		{
			CommonUtility.UpdateGameObjectVisible(base.gameObject, false);
		}

		// Token: 0x0600A646 RID: 42566 RVA: 0x00227B74 File Offset: 0x00225F74
		private void Update()
		{
			if (this.chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			if (DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp <= 0)
			{
				return;
			}
			this.timeInterval += Time.deltaTime;
			if (this.timeInterval >= 1f)
			{
				this.UpdateShopAutoRefreshContent();
			}
		}

		// Token: 0x0600A647 RID: 42567 RVA: 0x00227BC7 File Offset: 0x00225FC7
		private void UpdateShopAutoRefreshContent()
		{
			this.UpdateShopRefreshTimeLabel();
			if (ChijiShopUtility.IsChijiShopRefreshTimeUp())
			{
				DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp = 0;
				DataManager<ChijiShopDataManager>.GetInstance().OnSendSceneShopQueryReq(0);
			}
		}

		// Token: 0x0600A648 RID: 42568 RVA: 0x00227BEF File Offset: 0x00225FEF
		private void UpdateShopAutoRefreshRoot()
		{
			if (ChijiShopUtility.IsChijiShopCanAutoRefresh())
			{
				CommonUtility.UpdateGameObjectVisible(this.autoRefreshRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.autoRefreshRoot, false);
			}
		}

		// Token: 0x0600A649 RID: 42569 RVA: 0x00227C18 File Offset: 0x00226018
		private void UpdateShopRefreshTimeLabel()
		{
			this.timeInterval = 0f;
			if (this.shopRefreshLeftTimeLabel == null)
			{
				return;
			}
			string countDownTimeByMinuteSecondFormat = CountDownTimeUtility.GetCountDownTimeByMinuteSecondFormat((uint)DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp, DataManager<TimeManager>.GetInstance().GetServerTime());
			this.shopRefreshLeftTimeLabel.text = countDownTimeByMinuteSecondFormat;
		}

		// Token: 0x04005CF0 RID: 23792
		private ChijiShopType chijiShopType;

		// Token: 0x04005CF1 RID: 23793
		private float timeInterval;

		// Token: 0x04005CF2 RID: 23794
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04005CF3 RID: 23795
		[SerializeField]
		private Button backgroundButton;

		// Token: 0x04005CF4 RID: 23796
		[Space(10f)]
		[Header("GloryCoin")]
		[Space(10f)]
		[SerializeField]
		private Image gloryCoinIcon;

		// Token: 0x04005CF5 RID: 23797
		[SerializeField]
		private Text gloryCoinNumberValue;

		// Token: 0x04005CF6 RID: 23798
		[Space(10f)]
		[Header("ToggleControl")]
		[Space(10f)]
		[SerializeField]
		private Toggle itemBuyToggle;

		// Token: 0x04005CF7 RID: 23799
		[SerializeField]
		private Toggle itemSellToggle;

		// Token: 0x04005CF8 RID: 23800
		[Space(10f)]
		[Header("ShopRefreshContent")]
		[Space(10f)]
		[SerializeField]
		private GameObject shopRefreshContentRoot;

		// Token: 0x04005CF9 RID: 23801
		[Space(10f)]
		[Header("ShopAutoRefresh")]
		[Space(10f)]
		[SerializeField]
		private GameObject autoRefreshRoot;

		// Token: 0x04005CFA RID: 23802
		[SerializeField]
		private Text shopRefreshLeftTimeLabel;

		// Token: 0x04005CFB RID: 23803
		[Space(10f)]
		[Header("ShopRefreshContent")]
		[Space(10f)]
		[SerializeField]
		private Button shopRefreshButton;

		// Token: 0x04005CFC RID: 23804
		[SerializeField]
		private UIGray shopRefreshButtonGray;

		// Token: 0x04005CFD RID: 23805
		[SerializeField]
		private Image shopRefreshCostItemIcon;

		// Token: 0x04005CFE RID: 23806
		[SerializeField]
		private Text shopRefreshCostItemValueText;

		// Token: 0x04005CFF RID: 23807
		[Space(10f)]
		[Header("ShopItemController")]
		[Space(10f)]
		[SerializeField]
		private ChijiShopItemController chijiShopItemController;
	}
}
