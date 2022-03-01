using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001512 RID: 5394
	public class ChampionshipScoreFightRecordItem : MonoBehaviour
	{
		// Token: 0x0600D17E RID: 53630 RVA: 0x0033ADB3 File Offset: 0x003391B3
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D17F RID: 53631 RVA: 0x0033ADBB File Offset: 0x003391BB
		private void ClearData()
		{
			this.Reset();
		}

		// Token: 0x0600D180 RID: 53632 RVA: 0x0033ADC3 File Offset: 0x003391C3
		public void Init(ChampionshipScoreFightRecordDataModel scoreFightRecordDataModel)
		{
			this._scoreFightRecordDataModel = scoreFightRecordDataModel;
			if (this._scoreFightRecordDataModel == null)
			{
				return;
			}
			this.InitItem();
		}

		// Token: 0x0600D181 RID: 53633 RVA: 0x0033ADE0 File Offset: 0x003391E0
		private void InitItem()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			if (this._scoreFightRecordDataModel.IsNullTurnFlag)
			{
				text = TR.Value("Championship_Fight_Record_Null_Turn_Text", this._scoreFightRecordDataModel.FirstPlayerName);
				text2 = TR.Value("Championship_Fight_Record_Score_Change_First_Format", this._scoreFightRecordDataModel.FirstPlayerName, "+3");
			}
			else if (this._scoreFightRecordDataModel.IsWin)
			{
				text = TR.Value("Championship_Fight_Record_Win_Text", this._scoreFightRecordDataModel.FirstPlayerName, this._scoreFightRecordDataModel.SecondPlayerName);
				text2 = TR.Value("Championship_Fight_Record_Score_Change_First_Format", this._scoreFightRecordDataModel.FirstPlayerName, "+3");
				text3 = TR.Value("Championship_Fight_Record_Score_Change_Second_Format", this._scoreFightRecordDataModel.SecondPlayerName, "+0");
			}
			else
			{
				text = TR.Value("Championship_Fight_Record_Flat_Text", this._scoreFightRecordDataModel.FirstPlayerName, this._scoreFightRecordDataModel.SecondPlayerName);
				text2 = TR.Value("Championship_Fight_Record_Score_Change_First_Format", this._scoreFightRecordDataModel.FirstPlayerName, "+1");
				text3 = TR.Value("Championship_Fight_Record_Score_Change_Second_Format", this._scoreFightRecordDataModel.SecondPlayerName, "+1");
			}
			if (this.titleLabel != null)
			{
				this.titleLabel.text = text;
			}
			if (this.firstLabel != null)
			{
				this.firstLabel.text = text2;
			}
			if (this.secondLabel != null)
			{
				this.secondLabel.text = text3;
			}
		}

		// Token: 0x0600D182 RID: 53634 RVA: 0x0033AF5F File Offset: 0x0033935F
		public void RecycleItem()
		{
			this.Reset();
		}

		// Token: 0x0600D183 RID: 53635 RVA: 0x0033AF67 File Offset: 0x00339367
		public void Reset()
		{
			this._scoreFightRecordDataModel = null;
		}

		// Token: 0x04007A99 RID: 31385
		private ChampionshipScoreFightRecordDataModel _scoreFightRecordDataModel;

		// Token: 0x04007A9A RID: 31386
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007A9B RID: 31387
		[SerializeField]
		private Text firstLabel;

		// Token: 0x04007A9C RID: 31388
		[SerializeField]
		private Text secondLabel;
	}
}
