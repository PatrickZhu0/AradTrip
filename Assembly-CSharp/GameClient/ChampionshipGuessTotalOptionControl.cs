using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014FD RID: 5373
	public class ChampionshipGuessTotalOptionControl : MonoBehaviour
	{
		// Token: 0x0600D092 RID: 53394 RVA: 0x003379C8 File Offset: 0x00335DC8
		public void UpdateTotalOptionControl(ulong firstValue, ulong secondValue, uint firstBetRateValue = 0U, uint secondBetRateValue = 0U)
		{
			this._firstGuessValue = firstValue;
			this._secondGuessValue = secondValue;
			this._firstBetRateValue = firstBetRateValue;
			this._secondBetRateValue = secondBetRateValue;
			ulong num = this._firstGuessValue + this._secondGuessValue;
			string championshipGuessCostItemNameStr = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessCostItemNameStr();
			if (this.totalValueLabel != null)
			{
				string text = TR.Value("Championship_Guess_Bet_Pool_Total_Value", num, championshipGuessCostItemNameStr);
				this.totalValueLabel.text = text;
			}
			if (this.firstValueLabel != null)
			{
				string text2 = TR.Value("Championship_Guess_Bet_Total_Item_Format", this._firstGuessValue, championshipGuessCostItemNameStr);
				this.firstValueLabel.text = text2;
			}
			if (this.secondValueLabel != null)
			{
				string text3 = TR.Value("Championship_Guess_Bet_Total_Item_Format", this._secondGuessValue, championshipGuessCostItemNameStr);
				this.secondValueLabel.text = text3;
			}
			if (this.bgRtf != null && this.firstRtf != null && this.secondRtf != null)
			{
				float x = this.bgRtf.sizeDelta.x;
				float num2;
				float num3;
				if (num == 0UL || this._firstGuessValue == this._secondGuessValue)
				{
					num2 = x / 2f;
					num3 = x - num2;
				}
				else
				{
					num2 = (float)((double)x * (this._firstGuessValue * 1.0) / (double)(num * 1f));
					num3 = x - num2;
				}
				this.firstRtf.sizeDelta = new Vector2(num2, this.firstRtf.sizeDelta.y);
				this.secondRtf.sizeDelta = new Vector2(num3, this.secondRtf.sizeDelta.y);
			}
			this.UpdateBetRateValue();
		}

		// Token: 0x0600D093 RID: 53395 RVA: 0x00337BA8 File Offset: 0x00335FA8
		private void UpdateBetRateValue()
		{
			if (this._firstBetRateValue == 0U)
			{
				CommonUtility.UpdateTextVisible(this.firstBetRateValueLabel, false);
				CommonUtility.UpdateTextVisible(this.firstBetRateValueNormalLabel, false);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.firstBetRateValueLabel, true);
				CommonUtility.UpdateTextVisible(this.firstBetRateValueNormalLabel, true);
				string betRateValueStr = ChampionshipUtility.GetBetRateValueStr(this._firstBetRateValue);
				if (this.firstBetRateValueLabel != null)
				{
					string text = TR.Value("Championship_Guess_Bet_Rate_Format", betRateValueStr);
					this.firstBetRateValueLabel.text = text;
				}
				if (this.firstBetRateValueNormalLabel != null)
				{
					this.firstBetRateValueNormalLabel.text = betRateValueStr;
				}
			}
			if (this._secondBetRateValue == 0U)
			{
				CommonUtility.UpdateTextVisible(this.secondBetRateValueLabel, false);
				CommonUtility.UpdateTextVisible(this.secondBetRateValueNormalLevel, false);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.secondBetRateValueLabel, true);
				CommonUtility.UpdateTextVisible(this.secondBetRateValueNormalLevel, true);
				string betRateValueStr2 = ChampionshipUtility.GetBetRateValueStr(this._secondBetRateValue);
				if (this.secondBetRateValueLabel != null)
				{
					string text2 = TR.Value("Championship_Guess_Bet_Rate_Format", betRateValueStr2);
					this.secondBetRateValueLabel.text = text2;
				}
				if (this.secondBetRateValueNormalLevel != null)
				{
					this.secondBetRateValueNormalLevel.text = betRateValueStr2;
				}
			}
		}

		// Token: 0x04007A13 RID: 31251
		private ulong _firstGuessValue;

		// Token: 0x04007A14 RID: 31252
		private ulong _secondGuessValue;

		// Token: 0x04007A15 RID: 31253
		private uint _firstBetRateValue;

		// Token: 0x04007A16 RID: 31254
		private uint _secondBetRateValue;

		// Token: 0x04007A17 RID: 31255
		[Space(10f)]
		[Header("Bg")]
		[Space(10f)]
		[SerializeField]
		private RectTransform bgRtf;

		// Token: 0x04007A18 RID: 31256
		[SerializeField]
		private RectTransform firstRtf;

		// Token: 0x04007A19 RID: 31257
		[SerializeField]
		private RectTransform secondRtf;

		// Token: 0x04007A1A RID: 31258
		[Space(10f)]
		[Header("ValueLabel")]
		[Space(10f)]
		[SerializeField]
		private Text firstValueLabel;

		// Token: 0x04007A1B RID: 31259
		[SerializeField]
		private Text secondValueLabel;

		// Token: 0x04007A1C RID: 31260
		[SerializeField]
		private Text totalValueLabel;

		// Token: 0x04007A1D RID: 31261
		[Space(10f)]
		[Header("BetRateLabel")]
		[Space(10f)]
		[SerializeField]
		private Text firstBetRateValueLabel;

		// Token: 0x04007A1E RID: 31262
		[SerializeField]
		private Text secondBetRateValueLabel;

		// Token: 0x04007A1F RID: 31263
		[SerializeField]
		private Text firstBetRateValueNormalLabel;

		// Token: 0x04007A20 RID: 31264
		[SerializeField]
		private Text secondBetRateValueNormalLevel;
	}
}
