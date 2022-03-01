using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014F8 RID: 5368
	public class ChampionshipGuessRecordItem : MonoBehaviour
	{
		// Token: 0x0600D05B RID: 53339 RVA: 0x00336D4F File Offset: 0x0033514F
		private void Awake()
		{
		}

		// Token: 0x0600D05C RID: 53340 RVA: 0x00336D51 File Offset: 0x00335151
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D05D RID: 53341 RVA: 0x00336D59 File Offset: 0x00335159
		private void ClearData()
		{
			this._guessRecordDataModel = null;
		}

		// Token: 0x0600D05E RID: 53342 RVA: 0x00336D62 File Offset: 0x00335162
		public void InitItem(ChampionshipGuessRecordDataModel guessRecordDataModel)
		{
			this._guessRecordDataModel = guessRecordDataModel;
			if (this._guessRecordDataModel == null)
			{
				return;
			}
			this.InitContent();
			this.InitResult();
		}

		// Token: 0x0600D05F RID: 53343 RVA: 0x00336D84 File Offset: 0x00335184
		private void InitContent()
		{
			if (this.guessRecordTitleLabel != null)
			{
				this.guessRecordTitleLabel.text = this._guessRecordDataModel.GuessRecordTitleStr;
			}
			if (this.guessRecordBetLabel != null)
			{
				this.guessRecordBetLabel.text = this._guessRecordDataModel.GuessRecordContentStr;
			}
			if (this.guessRecordResultLabel != null)
			{
				this.guessRecordResultLabel.text = this._guessRecordDataModel.GuessRecordResultStr;
			}
		}

		// Token: 0x0600D060 RID: 53344 RVA: 0x00336E08 File Offset: 0x00335208
		private void InitResult()
		{
			CommonUtility.UpdateGameObjectVisible(this.bingGoRoot, false);
			CommonUtility.UpdateTextVisible(this.UnBingGoResultLabel, false);
			CommonUtility.UpdateTextVisible(this.UnOpenResultLabel, false);
			if (this._guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.BingGo)
			{
				CommonUtility.UpdateGameObjectVisible(this.bingGoRoot, true);
				string text = TR.Value("Championship_Guess_Record_Win_Value_Item_Format", this._guessRecordDataModel.GuessReward);
				if (this.bingGoValueLabel != null)
				{
					this.bingGoValueLabel.text = text;
				}
			}
			else if (this._guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.UnBingGo)
			{
				CommonUtility.UpdateTextVisible(this.UnBingGoResultLabel, true);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.UnOpenResultLabel, true);
			}
		}

		// Token: 0x0600D061 RID: 53345 RVA: 0x00336EC1 File Offset: 0x003352C1
		public void RecycleItem()
		{
			this._guessRecordDataModel = null;
		}

		// Token: 0x040079F3 RID: 31219
		private ChampionshipGuessRecordDataModel _guessRecordDataModel;

		// Token: 0x040079F4 RID: 31220
		[Space(10f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private Text guessRecordTitleLabel;

		// Token: 0x040079F5 RID: 31221
		[SerializeField]
		private Text guessRecordBetLabel;

		// Token: 0x040079F6 RID: 31222
		[SerializeField]
		private Text guessRecordResultLabel;

		// Token: 0x040079F7 RID: 31223
		[Space(10f)]
		[Header("BingGo")]
		[Space(10f)]
		[SerializeField]
		private GameObject bingGoRoot;

		// Token: 0x040079F8 RID: 31224
		[SerializeField]
		private Text bingGoTitleLabel;

		// Token: 0x040079F9 RID: 31225
		[SerializeField]
		private Text bingGoValueLabel;

		// Token: 0x040079FA RID: 31226
		[Space(10f)]
		[Header("Other")]
		[Space(10f)]
		[SerializeField]
		private Text UnBingGoResultLabel;

		// Token: 0x040079FB RID: 31227
		[SerializeField]
		private Text UnOpenResultLabel;
	}
}
