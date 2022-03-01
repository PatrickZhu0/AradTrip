using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200158E RID: 5518
	public class CoinDealRecordDetailItem : MonoBehaviour
	{
		// Token: 0x0600D7FD RID: 55293 RVA: 0x0035F90E File Offset: 0x0035DD0E
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D7FE RID: 55294 RVA: 0x0035F916 File Offset: 0x0035DD16
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D7FF RID: 55295 RVA: 0x0035F924 File Offset: 0x0035DD24
		private void BindUiEvents()
		{
			if (this.unFoldButton != null)
			{
				this.unFoldButton.onClick.RemoveAllListeners();
				this.unFoldButton.onClick.AddListener(new UnityAction(this.OnUnFoldButtonClick));
			}
		}

		// Token: 0x0600D800 RID: 55296 RVA: 0x0035F963 File Offset: 0x0035DD63
		private void UnBindUiEvents()
		{
			if (this.unFoldButton != null)
			{
				this.unFoldButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D801 RID: 55297 RVA: 0x0035F986 File Offset: 0x0035DD86
		private void ClearData()
		{
			this._recordDetailDataModel = null;
			this._recordOrderControl = null;
		}

		// Token: 0x0600D802 RID: 55298 RVA: 0x0035F998 File Offset: 0x0035DD98
		public void InitItem(CoinDealRecordDetailDataModel recordDetailDataModel)
		{
			this._recordDetailDataModel = recordDetailDataModel;
			if (this._recordDetailDataModel == null)
			{
				return;
			}
			if (this._recordDetailDataModel.IsParent)
			{
				CommonUtility.UpdateGameObjectVisible(this.recordOrderRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.recordDetailRoot, true);
				this.InitRecordDetailItem();
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.recordDetailRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.recordOrderRoot, true);
				this.InitRecordOrderItem();
			}
		}

		// Token: 0x0600D803 RID: 55299 RVA: 0x0035FA0C File Offset: 0x0035DE0C
		private void InitRecordDetailItem()
		{
			if (this.timeStampLabel != null)
			{
				string timeFormatByMonthDayWithCommonFormat = TimeUtility.GetTimeFormatByMonthDayWithCommonFormat(this._recordDetailDataModel.TimeStamp);
				this.timeStampLabel.text = timeFormatByMonthDayWithCommonFormat;
			}
			if (this.totalNumberLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._recordDetailDataModel.TotalNumber);
				this.totalNumberLabel.text = text;
			}
			if (this.transferNumberLabel != null)
			{
				string text2 = Utility.ToThousandsSeparator((ulong)this._recordDetailDataModel.TransferNumber);
				this.transferNumberLabel.text = text2;
			}
			ItemTable creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
			if (creditTicketItemTable != null && !string.IsNullOrEmpty(creditTicketItemTable.Icon))
			{
				if (this.creditTicketIconOne != null)
				{
					ETCImageLoader.LoadSprite(ref this.creditTicketIconOne, creditTicketItemTable.Icon, true);
				}
				if (this.creditTicketIconTwo != null)
				{
					ETCImageLoader.LoadSprite(ref this.creditTicketIconTwo, creditTicketItemTable.Icon, true);
				}
			}
			if (this._recordDetailDataModel.IsOwnerChild)
			{
				CommonUtility.UpdateButtonVisible(this.unFoldButton, true);
				this.UpdateUnFoldButtonState();
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.unFoldButton, false);
			}
		}

		// Token: 0x0600D804 RID: 55300 RVA: 0x0035FB44 File Offset: 0x0035DF44
		private void UpdateUnFoldButtonState()
		{
			if (!this._recordDetailDataModel.IsParent)
			{
				return;
			}
			if (this._recordDetailDataModel.IsAlreadyUnFold)
			{
				CommonUtility.UpdateGameObjectVisible(this.upFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.downFlag, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.upFlag, false);
				CommonUtility.UpdateGameObjectVisible(this.downFlag, true);
			}
		}

		// Token: 0x0600D805 RID: 55301 RVA: 0x0035FBA8 File Offset: 0x0035DFA8
		private void InitRecordOrderItem()
		{
			if (this.recordOrderRoot == null)
			{
				return;
			}
			if (this._recordOrderControl == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.recordOrderRoot);
				if (gameObject != null)
				{
					this._recordOrderControl = gameObject.GetComponent<CoinDealRecordOrderControl>();
				}
			}
			if (this._recordOrderControl != null)
			{
				this._recordOrderControl.InitControl(this._recordDetailDataModel);
			}
		}

		// Token: 0x0600D806 RID: 55302 RVA: 0x0035FC1E File Offset: 0x0035E01E
		public void RecycleItem()
		{
			this._recordDetailDataModel = null;
		}

		// Token: 0x0600D807 RID: 55303 RVA: 0x0035FC28 File Offset: 0x0035E028
		private void OnUnFoldButtonClick()
		{
			if (this._recordDetailDataModel == null)
			{
				return;
			}
			if (!this._recordDetailDataModel.IsParent)
			{
				return;
			}
			if (!this._recordDetailDataModel.IsOwnerChild)
			{
				return;
			}
			this._recordDetailDataModel.IsAlreadyUnFold = !this._recordDetailDataModel.IsAlreadyUnFold;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealCreditPointRecordUpdateMessage, null, null, null, null);
		}

		// Token: 0x04007EC1 RID: 32449
		private CoinDealRecordDetailDataModel _recordDetailDataModel;

		// Token: 0x04007EC2 RID: 32450
		private CoinDealRecordOrderControl _recordOrderControl;

		// Token: 0x04007EC3 RID: 32451
		[Space(10f)]
		[Header("Record")]
		[Space(10f)]
		[SerializeField]
		private Text timeStampLabel;

		// Token: 0x04007EC4 RID: 32452
		[SerializeField]
		private Text totalNumberLabel;

		// Token: 0x04007EC5 RID: 32453
		[SerializeField]
		private Text transferNumberLabel;

		// Token: 0x04007EC6 RID: 32454
		[SerializeField]
		private GameObject recordDetailRoot;

		// Token: 0x04007EC7 RID: 32455
		[Space(10f)]
		[Header("CreditTicketIcon")]
		[Space(10f)]
		[SerializeField]
		private Image creditTicketIconOne;

		// Token: 0x04007EC8 RID: 32456
		[SerializeField]
		private Image creditTicketIconTwo;

		// Token: 0x04007EC9 RID: 32457
		[Space(10f)]
		[Header("unFold")]
		[Space(10f)]
		[SerializeField]
		private Button unFoldButton;

		// Token: 0x04007ECA RID: 32458
		[SerializeField]
		private GameObject upFlag;

		// Token: 0x04007ECB RID: 32459
		[SerializeField]
		private GameObject downFlag;

		// Token: 0x04007ECC RID: 32460
		[Space(10f)]
		[Header("Order")]
		[Space(10f)]
		[SerializeField]
		private GameObject recordOrderRoot;
	}
}
