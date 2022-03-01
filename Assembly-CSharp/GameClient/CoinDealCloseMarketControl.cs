using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001581 RID: 5505
	public class CoinDealCloseMarketControl : MonoBehaviour
	{
		// Token: 0x0600D746 RID: 55110 RVA: 0x0035CE1D File Offset: 0x0035B21D
		private void Awake()
		{
		}

		// Token: 0x0600D747 RID: 55111 RVA: 0x0035CE1F File Offset: 0x0035B21F
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D748 RID: 55112 RVA: 0x0035CE27 File Offset: 0x0035B227
		private void ClearData()
		{
			this._closeMarketTimeController = null;
			this._isCloseMarketFlag = false;
			this._closeMarketTimeInterval = 0f;
		}

		// Token: 0x0600D749 RID: 55113 RVA: 0x0035CE42 File Offset: 0x0035B242
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealCloseMarketTimeUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCloseMarketTimeUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealRefreshCloseMarketControlMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRefreshCloseMarketControlMessage));
		}

		// Token: 0x0600D74A RID: 55114 RVA: 0x0035CE7A File Offset: 0x0035B27A
		private void OnDisable()
		{
			this.CancelCloseMarketTimeCountTimeController();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealCloseMarketTimeUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCloseMarketTimeUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealRefreshCloseMarketControlMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRefreshCloseMarketControlMessage));
		}

		// Token: 0x0600D74B RID: 55115 RVA: 0x0035CEB8 File Offset: 0x0035B2B8
		public void InitControl(GoldConsignmentOrderType orderType)
		{
			this._orderType = orderType;
			this._closeMarketTimeInterval = 1f;
			this.ResetDealButtonWithCd();
			this.UpdateCoinDealCloseMarketState();
			this.UpdateCloseMarketValueLabel();
		}

		// Token: 0x0600D74C RID: 55116 RVA: 0x0035CEDE File Offset: 0x0035B2DE
		public void OnEnableControl()
		{
			this._closeMarketTimeInterval = 1f;
			this.ResetDealButtonWithCd();
			this.UpdateCoinDealCloseMarketState();
			this.UpdateCloseMarketValueLabel();
		}

		// Token: 0x0600D74D RID: 55117 RVA: 0x0035CEFD File Offset: 0x0035B2FD
		public void UpdateControl()
		{
			this.ResetDealButtonWithCd();
			this.UpdateCoinDealCloseMarketState();
		}

		// Token: 0x0600D74E RID: 55118 RVA: 0x0035CF0C File Offset: 0x0035B30C
		private void UpdateCloseMarketValueLabel()
		{
			if (this.closeMarketTitleLabel == null)
			{
				return;
			}
			string coinDealCloseMarketStr = CoinDealUtility.GetCoinDealCloseMarketStr();
			this.closeMarketTitleLabel.text = coinDealCloseMarketStr;
		}

		// Token: 0x0600D74F RID: 55119 RVA: 0x0035CF40 File Offset: 0x0035B340
		private void UpdateCoinDealCloseMarketState()
		{
			this._isCloseMarketFlag = CoinDealUtility.IsInCloseMarketIntervalTime();
			if (this._isCloseMarketFlag)
			{
				this.UpdateDealButtonView(false);
				CommonUtility.UpdateGameObjectVisible(this.closeMarketRoot, true);
				int closeMarketEndTimeStamp = DataManager<CoinDealDataManager>.GetInstance().CloseMarketEndTimeStamp;
				if (this._closeMarketTimeController == null && this.closeMarketRoot != null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.closeMarketRoot);
					if (gameObject != null)
					{
						this._closeMarketTimeController = gameObject.GetComponent<CountDownTimeController>();
					}
				}
				if (this._closeMarketTimeController != null)
				{
					this._closeMarketTimeController.SetCountDownTimeController((uint)closeMarketEndTimeStamp, new OnCountDownTimeCallback(this.OnCloseMarketFinishedAction));
				}
			}
			else
			{
				this.SetDealButtonNormalState();
			}
		}

		// Token: 0x0600D750 RID: 55120 RVA: 0x0035CFFB File Offset: 0x0035B3FB
		public void OnCloseMarketFinishedAction()
		{
		}

		// Token: 0x0600D751 RID: 55121 RVA: 0x0035CFFD File Offset: 0x0035B3FD
		private void SetDealButtonNormalState()
		{
			this.CancelCloseMarketTimeCountTimeController();
			CommonUtility.UpdateGameObjectVisible(this.closeMarketRoot, false);
			this.UpdateDealButtonView(true);
		}

		// Token: 0x0600D752 RID: 55122 RVA: 0x0035D018 File Offset: 0x0035B418
		private void UpdateDealButtonView(bool flag)
		{
			CommonUtility.UpdateButtonState(this.dealButton, this.dealButtonGray, flag);
			if (this.dealButtonText != null)
			{
				string text = TR.Value("Coin_Deal_Close_Time_Tip_Label");
				if (flag)
				{
					if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
					{
						text = TR.Value("Coin_Deal_Buy_Button_Label");
					}
					else
					{
						text = TR.Value("Coin_Deal_Sell_Button_Label");
					}
				}
				this.dealButtonText.text = text;
			}
		}

		// Token: 0x0600D753 RID: 55123 RVA: 0x0035D08C File Offset: 0x0035B48C
		private void CancelCloseMarketTimeCountTimeController()
		{
			if (this._closeMarketTimeController != null)
			{
				this._closeMarketTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x0600D754 RID: 55124 RVA: 0x0035D0AA File Offset: 0x0035B4AA
		private void OnReceiveCoinDealCloseMarketTimeUpdateMessage(UIEvent uiEvent)
		{
			this._closeMarketTimeInterval = 1f;
			this.ResetDealButtonWithCd();
			this.UpdateCoinDealCloseMarketState();
			this.UpdateCloseMarketValueLabel();
		}

		// Token: 0x0600D755 RID: 55125 RVA: 0x0035D0CC File Offset: 0x0035B4CC
		private void OnReceiveCoinDealRefreshCloseMarketControlMessage(UIEvent uiEvent)
		{
			bool flag = CoinDealUtility.IsInCloseMarketIntervalTime();
			if (flag != this._isCloseMarketFlag)
			{
				this.ResetDealButtonWithCd();
				this.UpdateCoinDealCloseMarketState();
			}
		}

		// Token: 0x0600D756 RID: 55126 RVA: 0x0035D0F7 File Offset: 0x0035B4F7
		private void ResetDealButtonWithCd()
		{
			if (this.dealButtonWithCd != null)
			{
				this.dealButtonWithCd.Reset();
			}
		}

		// Token: 0x04007E5A RID: 32346
		private GoldConsignmentOrderType _orderType;

		// Token: 0x04007E5B RID: 32347
		private CountDownTimeController _closeMarketTimeController;

		// Token: 0x04007E5C RID: 32348
		private bool _isCloseMarketFlag;

		// Token: 0x04007E5D RID: 32349
		private float _closeMarketTimeInterval = 1f;

		// Token: 0x04007E5E RID: 32350
		[Space(10f)]
		[Header("CloseMarketRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject closeMarketRoot;

		// Token: 0x04007E5F RID: 32351
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd dealButtonWithCd;

		// Token: 0x04007E60 RID: 32352
		[SerializeField]
		private Button dealButton;

		// Token: 0x04007E61 RID: 32353
		[SerializeField]
		private UIGray dealButtonGray;

		// Token: 0x04007E62 RID: 32354
		[SerializeField]
		private Text dealButtonText;

		// Token: 0x04007E63 RID: 32355
		[Space(10f)]
		[Header("CloseMarketLabel")]
		[Space(10f)]
		[SerializeField]
		private Text closeMarketTitleLabel;
	}
}
