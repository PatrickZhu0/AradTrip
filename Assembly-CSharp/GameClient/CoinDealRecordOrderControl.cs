using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200158F RID: 5519
	public class CoinDealRecordOrderControl : MonoBehaviour
	{
		// Token: 0x0600D809 RID: 55305 RVA: 0x0035FC97 File Offset: 0x0035E097
		private void Awake()
		{
		}

		// Token: 0x0600D80A RID: 55306 RVA: 0x0035FC99 File Offset: 0x0035E099
		private void OnDestroy()
		{
			this._recordDetailDataModel = null;
		}

		// Token: 0x0600D80B RID: 55307 RVA: 0x0035FCA4 File Offset: 0x0035E0A4
		public void InitControl(CoinDealRecordDetailDataModel recordDetailDataModel)
		{
			this._recordDetailDataModel = recordDetailDataModel;
			if (this._recordDetailDataModel == null)
			{
				return;
			}
			if (this.timeStampLabel != null)
			{
				string timeFormatByYearMonthDayHourAndMinuteWithCommonFormat = TimeUtility.GetTimeFormatByYearMonthDayHourAndMinuteWithCommonFormat(this._recordDetailDataModel.TimeStamp);
				this.timeStampLabel.text = timeFormatByYearMonthDayHourAndMinuteWithCommonFormat;
			}
			if (this.totalNumberLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._recordDetailDataModel.TotalNumber);
				this.totalNumberLabel.text = text;
			}
			if (this.creditTicketIcon != null)
			{
				ItemTable creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
				if (creditTicketItemTable != null && !string.IsNullOrEmpty(creditTicketItemTable.Icon))
				{
					ETCImageLoader.LoadSprite(ref this.creditTicketIcon, creditTicketItemTable.Icon, true);
				}
			}
		}

		// Token: 0x04007ECD RID: 32461
		private CoinDealRecordDetailDataModel _recordDetailDataModel;

		// Token: 0x04007ECE RID: 32462
		[Space(10f)]
		[Header("Record")]
		[Space(10f)]
		[SerializeField]
		private Text timeStampLabel;

		// Token: 0x04007ECF RID: 32463
		[SerializeField]
		private Text totalNumberLabel;

		// Token: 0x04007ED0 RID: 32464
		[SerializeField]
		private Image creditTicketIcon;
	}
}
