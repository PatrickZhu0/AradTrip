using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200158D RID: 5517
	public class CoinDealRecordDetailView : MonoBehaviour
	{
		// Token: 0x0600D7EB RID: 55275 RVA: 0x0035F43E File Offset: 0x0035D83E
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D7EC RID: 55276 RVA: 0x0035F446 File Offset: 0x0035D846
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D7ED RID: 55277 RVA: 0x0035F454 File Offset: 0x0035D854
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.recordDetailItemListEx != null)
			{
				this.recordDetailItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.recordDetailItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.recordDetailItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600D7EE RID: 55278 RVA: 0x0035F508 File Offset: 0x0035D908
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.recordDetailItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.recordDetailItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.recordDetailItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600D7EF RID: 55279 RVA: 0x0035F595 File Offset: 0x0035D995
		private void ClearData()
		{
			this.ResetRecordDetailDataModelList();
		}

		// Token: 0x0600D7F0 RID: 55280 RVA: 0x0035F59D File Offset: 0x0035D99D
		private void ResetRecordDetailDataModelList()
		{
			if (this._recordDetailDataModelList != null)
			{
				this._recordDetailDataModelList.Clear();
			}
		}

		// Token: 0x0600D7F1 RID: 55281 RVA: 0x0035F5B5 File Offset: 0x0035D9B5
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealCreditPointRecordDetailMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCreditPointRecordDetailMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealCreditPointRecordUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCreditPointRecordDetailMessage));
		}

		// Token: 0x0600D7F2 RID: 55282 RVA: 0x0035F5ED File Offset: 0x0035D9ED
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealCreditPointRecordDetailMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCreditPointRecordDetailMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealCreditPointRecordUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealCreditPointRecordDetailMessage));
		}

		// Token: 0x0600D7F3 RID: 55283 RVA: 0x0035F625 File Offset: 0x0035DA25
		public void InitView()
		{
			DataManager<CoinDealDataManager>.GetInstance().OnSendSceneCreditPointRecordReq();
			this.InitBaseView();
			this.UpdateRecordDetailView();
		}

		// Token: 0x0600D7F4 RID: 55284 RVA: 0x0035F640 File Offset: 0x0035DA40
		private void InitBaseView()
		{
			if (this.recordDetailTitleLabel != null)
			{
				this.recordDetailTitleLabel.text = TR.Value("Coin_Deal_Credit_Ticket_Record_Title_Label");
			}
			if (this.recordDetailTipLabel != null)
			{
				int coinDealCreditTicketExchangeDayNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealCreditTicketExchangeDayNumber();
				int creditTicketMaxNumberInMonthTransfer = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketMaxNumberInMonthTransfer();
				int coinDealCreditTicketExchangeRate = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealCreditTicketExchangeRate();
				int num = creditTicketMaxNumberInMonthTransfer;
				if (coinDealCreditTicketExchangeRate > 0)
				{
					num = creditTicketMaxNumberInMonthTransfer / coinDealCreditTicketExchangeRate;
				}
				string text = TR.Value("Coin_Deal_Credit_Ticket_Record_Tip_Label_Format", coinDealCreditTicketExchangeDayNumber, creditTicketMaxNumberInMonthTransfer, num);
				this.recordDetailTipLabel.text = text;
			}
		}

		// Token: 0x0600D7F5 RID: 55285 RVA: 0x0035F6DD File Offset: 0x0035DADD
		private void UpdateRecordDetailView()
		{
			this.UpdateRecordDetailDataModelList();
			this.SetRecordDetailItemListEx();
		}

		// Token: 0x0600D7F6 RID: 55286 RVA: 0x0035F6EC File Offset: 0x0035DAEC
		private void UpdateRecordDetailDataModelList()
		{
			this.ResetRecordDetailDataModelList();
			List<CoinDealRecordDetailDataModel> coinDealRecordDetailDataModelList = DataManager<CoinDealDataManager>.GetInstance().CoinDealRecordDetailDataModelList;
			if (coinDealRecordDetailDataModelList != null && coinDealRecordDetailDataModelList.Count > 0)
			{
				for (int i = 0; i < coinDealRecordDetailDataModelList.Count; i++)
				{
					CoinDealRecordDetailDataModel coinDealRecordDetailDataModel = coinDealRecordDetailDataModelList[i];
					if (coinDealRecordDetailDataModel != null)
					{
						this._recordDetailDataModelList.Add(coinDealRecordDetailDataModel);
						if (coinDealRecordDetailDataModel.IsParent)
						{
							if (coinDealRecordDetailDataModel.IsAlreadyUnFold)
							{
								if (coinDealRecordDetailDataModel.ChildRecordDetailDataModelList != null && coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Count > 0)
								{
									for (int j = 0; j < coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Count; j++)
									{
										CoinDealRecordDetailDataModel coinDealRecordDetailDataModel2 = coinDealRecordDetailDataModel.ChildRecordDetailDataModelList[j];
										if (coinDealRecordDetailDataModel2 != null)
										{
											this._recordDetailDataModelList.Add(coinDealRecordDetailDataModel2);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600D7F7 RID: 55287 RVA: 0x0035F7D4 File Offset: 0x0035DBD4
		private void SetRecordDetailItemListEx()
		{
			if (this.recordDetailItemListEx == null)
			{
				return;
			}
			int elementAmount = 0;
			if (this._recordDetailDataModelList != null)
			{
				elementAmount = this._recordDetailDataModelList.Count;
			}
			this.recordDetailItemListEx.StopListMovement();
			this.recordDetailItemListEx.SetElementAmount(elementAmount);
		}

		// Token: 0x0600D7F8 RID: 55288 RVA: 0x0035F824 File Offset: 0x0035DC24
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.recordDetailItemListEx == null)
			{
				return;
			}
			if (this._recordDetailDataModelList == null || this._recordDetailDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._recordDetailDataModelList.Count)
			{
				return;
			}
			CoinDealRecordDetailItem component = item.GetComponent<CoinDealRecordDetailItem>();
			CoinDealRecordDetailDataModel coinDealRecordDetailDataModel = this._recordDetailDataModelList[item.m_index];
			if (component != null && coinDealRecordDetailDataModel != null)
			{
				component.InitItem(coinDealRecordDetailDataModel);
			}
		}

		// Token: 0x0600D7F9 RID: 55289 RVA: 0x0035F8C4 File Offset: 0x0035DCC4
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealRecordDetailItem component = item.GetComponent<CoinDealRecordDetailItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D7FA RID: 55290 RVA: 0x0035F8F7 File Offset: 0x0035DCF7
		private void OnReceiveCoinDealCreditPointRecordDetailMessage(UIEvent uiEvent)
		{
			this.UpdateRecordDetailView();
		}

		// Token: 0x0600D7FB RID: 55291 RVA: 0x0035F8FF File Offset: 0x0035DCFF
		private void OnCloseButtonClick()
		{
			CoinDealUtility.OnCloseCoinDealRecordDetailFrame();
		}

		// Token: 0x04007EBC RID: 32444
		private List<CoinDealRecordDetailDataModel> _recordDetailDataModelList = new List<CoinDealRecordDetailDataModel>();

		// Token: 0x04007EBD RID: 32445
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text recordDetailTitleLabel;

		// Token: 0x04007EBE RID: 32446
		[SerializeField]
		private Text recordDetailTipLabel;

		// Token: 0x04007EBF RID: 32447
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007EC0 RID: 32448
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx recordDetailItemListEx;
	}
}
