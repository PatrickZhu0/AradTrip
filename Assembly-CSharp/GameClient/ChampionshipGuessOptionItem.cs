using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001504 RID: 5380
	public class ChampionshipGuessOptionItem : MonoBehaviour
	{
		// Token: 0x0600D0DA RID: 53466 RVA: 0x00338B3A File Offset: 0x00336F3A
		private void Awake()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
				this.betButton.onClick.AddListener(new UnityAction(this.OnBetButtonClick));
			}
		}

		// Token: 0x0600D0DB RID: 53467 RVA: 0x00338B79 File Offset: 0x00336F79
		private void OnDestroy()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
			}
			this.ClearData();
		}

		// Token: 0x0600D0DC RID: 53468 RVA: 0x00338BA2 File Offset: 0x00336FA2
		private void ClearData()
		{
			this._guessOptionId = 0UL;
			this._guessProjectId = 0U;
			this._guessProjectDataModel = null;
			this._guessOptionDataModel = null;
		}

		// Token: 0x0600D0DD RID: 53469 RVA: 0x00338BC1 File Offset: 0x00336FC1
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0DE RID: 53470 RVA: 0x00338BDE File Offset: 0x00336FDE
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0DF RID: 53471 RVA: 0x00338BFC File Offset: 0x00336FFC
		public void InitItem(ChampionshipGuessProjectDataModel guessProjectDataModel, ChampionshipGuessOptionDataModel guessOptionDataModel)
		{
			this._guessProjectDataModel = guessProjectDataModel;
			this._guessOptionDataModel = guessOptionDataModel;
			if (this._guessProjectDataModel == null || this._guessOptionDataModel == null)
			{
				return;
			}
			this._guessProjectId = this._guessProjectDataModel.ProjectId;
			this._guessOptionId = this._guessOptionDataModel.OptionId;
			this.InitView();
		}

		// Token: 0x0600D0E0 RID: 53472 RVA: 0x00338C56 File Offset: 0x00337056
		private void InitView()
		{
			this.InitBaseView();
			this.UpdateItemValue();
			this.UpdateBetButtonState();
		}

		// Token: 0x0600D0E1 RID: 53473 RVA: 0x00338C6C File Offset: 0x0033706C
		private void InitBaseView()
		{
			if (this.optionContentLabel == null)
			{
				return;
			}
			string text = string.Empty;
			if (this._guessProjectDataModel.ProjectType == GambleType.GT_BATTLE_COUNT)
			{
				text = ChampionshipUtility.GetChampionshipGuessFightRaceNumberStr(this._guessOptionId);
			}
			else if (this._guessProjectDataModel.ProjectType == GambleType.GT_CHAMPION_BATTLE_SCORE)
			{
				text = ChampionshipUtility.GetChampionshipGuessFinalScoreStr(this._guessOptionId);
			}
			this.optionContentLabel.text = text;
		}

		// Token: 0x0600D0E2 RID: 53474 RVA: 0x00338CDC File Offset: 0x003370DC
		public void OnItemUpdate()
		{
			if (this._guessProjectDataModel == null || this._guessOptionDataModel == null)
			{
				return;
			}
			this.UpdateItemValue();
			this.UpdateBetButtonState();
		}

		// Token: 0x0600D0E3 RID: 53475 RVA: 0x00338D04 File Offset: 0x00337104
		private void UpdateItemValue()
		{
			if (this.optionBetTotalValueLabel != null)
			{
				ulong guessNumber = this._guessOptionDataModel.GuessNumber;
				string championshipGuessCostItemNameStr = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessCostItemNameStr();
				string text = TR.Value("Championship_Guess_Bet_Total_Item_Format", guessNumber, championshipGuessCostItemNameStr);
				this.optionBetTotalValueLabel.text = text;
			}
			if (this.optionBetTotalValueNormalLabel != null)
			{
				ulong guessNumber2 = this._guessOptionDataModel.GuessNumber;
				this.optionBetTotalValueNormalLabel.text = guessNumber2.ToString();
			}
			string betRateValueStr = ChampionshipUtility.GetBetRateValueStr(this._guessOptionDataModel.Odds);
			if (this.optionOddsValueLabel != null)
			{
				string text2 = TR.Value("Championship_Guess_Bet_Rate_Format", betRateValueStr);
				this.optionOddsValueLabel.text = text2;
			}
			if (this.optionOddsValueNormalLabel != null)
			{
				this.optionOddsValueNormalLabel.text = betRateValueStr;
			}
		}

		// Token: 0x0600D0E4 RID: 53476 RVA: 0x00338DE8 File Offset: 0x003371E8
		private void UpdateBetButtonState()
		{
			bool flag = ChampionshipUtility.IsGuessProjectStillInBetTime(this._guessProjectDataModel);
			CommonUtility.UpdateButtonState(this.betButton, this.betButtonGray, flag);
			if (this.betTitleLabel != null)
			{
				if (flag)
				{
					this.betTitleLabel.text = TR.Value("Championship_Guess_Title");
				}
				else
				{
					this.betTitleLabel.text = TR.Value("Championship_Guess_Finish_Title_Label");
				}
			}
		}

		// Token: 0x0600D0E5 RID: 53477 RVA: 0x00338E59 File Offset: 0x00337259
		public void RecycleItem()
		{
			this._guessProjectDataModel = null;
			this._guessOptionDataModel = null;
		}

		// Token: 0x0600D0E6 RID: 53478 RVA: 0x00338E6C File Offset: 0x0033726C
		private void OnReceiveChampionshipBetResMessage(UIEvent uiEvent)
		{
			if (this._guessProjectDataModel == null || this._guessOptionDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			ulong num2 = (ulong)uiEvent.Param2;
			if (num != this._guessProjectId)
			{
				return;
			}
			if (num2 != this._guessOptionId)
			{
				return;
			}
			this.UpdateItemValue();
		}

		// Token: 0x0600D0E7 RID: 53479 RVA: 0x00338EE8 File Offset: 0x003372E8
		private void OnBetButtonClick()
		{
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			if (!ChampionshipUtility.IsGuessProjectStillInBetTime(this._guessProjectDataModel))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Guess_Bet_Is_Not_In_Time"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ChampionshipUtility.OnOpenChampionshipGuessBetFrame(this._guessProjectId, this._guessOptionId);
		}

		// Token: 0x04007A48 RID: 31304
		private uint _guessProjectId;

		// Token: 0x04007A49 RID: 31305
		private ulong _guessOptionId;

		// Token: 0x04007A4A RID: 31306
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A4B RID: 31307
		private ChampionshipGuessOptionDataModel _guessOptionDataModel;

		// Token: 0x04007A4C RID: 31308
		[Space(10f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private Text optionContentLabel;

		// Token: 0x04007A4D RID: 31309
		[Space(10f)]
		[Header("LabelOnlyShowValue")]
		[SerializeField]
		private Text optionBetTotalValueNormalLabel;

		// Token: 0x04007A4E RID: 31310
		[SerializeField]
		private Text optionOddsValueNormalLabel;

		// Token: 0x04007A4F RID: 31311
		[Space(10f)]
		[Header("LabelShowBetFormat")]
		[SerializeField]
		private Text optionBetTotalValueLabel;

		// Token: 0x04007A50 RID: 31312
		[SerializeField]
		private Text optionOddsValueLabel;

		// Token: 0x04007A51 RID: 31313
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button betButton;

		// Token: 0x04007A52 RID: 31314
		[SerializeField]
		private UIGray betButtonGray;

		// Token: 0x04007A53 RID: 31315
		[SerializeField]
		private Text betTitleLabel;
	}
}
