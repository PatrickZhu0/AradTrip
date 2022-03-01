using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001502 RID: 5378
	public class ChampionshipFunnyGuessControl : MonoBehaviour
	{
		// Token: 0x0600D0BE RID: 53438 RVA: 0x00338184 File Offset: 0x00336584
		private void Awake()
		{
			if (this.guessItemList != null)
			{
				this.guessItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.guessItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.guessItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
		}

		// Token: 0x0600D0BF RID: 53439 RVA: 0x003381FC File Offset: 0x003365FC
		private void OnDestroy()
		{
			if (this.guessItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.guessItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.guessItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
			this.ClearData();
		}

		// Token: 0x0600D0C0 RID: 53440 RVA: 0x0033826E File Offset: 0x0033666E
		private void ClearData()
		{
			this._guessProjectDataModel = null;
			this._guessProjectId = 0U;
		}

		// Token: 0x0600D0C1 RID: 53441 RVA: 0x0033827E File Offset: 0x0033667E
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0C2 RID: 53442 RVA: 0x0033829B File Offset: 0x0033669B
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0C3 RID: 53443 RVA: 0x003382B8 File Offset: 0x003366B8
		public void InitControl(ChampionshipGuessProjectDataModel guessProjectDataModel)
		{
			this._guessProjectDataModel = guessProjectDataModel;
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			this._guessProjectId = this._guessProjectDataModel.ProjectId;
			this.InitContent();
		}

		// Token: 0x0600D0C4 RID: 53444 RVA: 0x003382E4 File Offset: 0x003366E4
		private void InitContent()
		{
			string text = TR.Value("Championship_Guess_Funny_Guess_Final_Score");
			if (this._guessProjectDataModel.ProjectType == GambleType.GT_BATTLE_COUNT)
			{
				text = TR.Value("Championship_Guess_Funny_Guess_Game_Number");
			}
			if (this.guessTitleLabel != null)
			{
				this.guessTitleLabel.text = text;
			}
			string timeFormatByMonthDayHourMinute = TimeUtility.GetTimeFormatByMonthDayHourMinute(this._guessProjectDataModel.EndTime);
			string text2 = TR.Value("Championship_Guess_Bet_End_Time_Format", timeFormatByMonthDayHourMinute);
			if (this.guessTimeLabel != null)
			{
				this.guessTimeLabel.text = text2;
			}
			this.InitGuessItemList();
			this.UpdateTotalBetValue();
		}

		// Token: 0x0600D0C5 RID: 53445 RVA: 0x0033837B File Offset: 0x0033677B
		public void UpdateControl()
		{
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			this.UpdateTotalBetValue();
			this.UpdateGuessItemList();
		}

		// Token: 0x0600D0C6 RID: 53446 RVA: 0x00338398 File Offset: 0x00336798
		private void InitGuessItemList()
		{
			int elementAmount = 0;
			if (this._guessProjectDataModel.GuessOptionIdList != null)
			{
				elementAmount = this._guessProjectDataModel.GuessOptionIdList.Count;
			}
			if (this.guessItemList != null)
			{
				this.guessItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D0C7 RID: 53447 RVA: 0x003383E8 File Offset: 0x003367E8
		private void UpdateTotalBetValue()
		{
			ulong num = 0UL;
			Dictionary<ulong, ChampionshipGuessOptionDataModel> guessOptionDataModelDictionary = this._guessProjectDataModel.GuessOptionDataModelDictionary;
			if (guessOptionDataModelDictionary != null && guessOptionDataModelDictionary.Count > 0)
			{
				foreach (KeyValuePair<ulong, ChampionshipGuessOptionDataModel> keyValuePair in guessOptionDataModelDictionary)
				{
					ChampionshipGuessOptionDataModel value = keyValuePair.Value;
					if (value != null)
					{
						num += value.GuessNumber;
					}
				}
			}
			string text = TR.Value("Championship_Guess_Bet_Total_Item_Format", num, DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessCostItemNameStr());
			if (this.totalBetValueLabel != null)
			{
				this.totalBetValueLabel.text = text;
			}
		}

		// Token: 0x0600D0C8 RID: 53448 RVA: 0x00338488 File Offset: 0x00336888
		private void UpdateGuessItemList()
		{
			if (this.guessItemList != null)
			{
				this.guessItemList.UpdateElement();
			}
		}

		// Token: 0x0600D0C9 RID: 53449 RVA: 0x003384A8 File Offset: 0x003368A8
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._guessProjectDataModel == null || this._guessProjectDataModel.GuessOptionIdList == null || this._guessProjectDataModel.GuessOptionIdList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._guessProjectDataModel.GuessOptionIdList.Count)
			{
				return;
			}
			ChampionshipGuessOptionItem component = item.GetComponent<ChampionshipGuessOptionItem>();
			if (component != null)
			{
				ulong key = this._guessProjectDataModel.GuessOptionIdList[item.m_index];
				ChampionshipGuessOptionDataModel guessOptionDataModel = null;
				if (this._guessProjectDataModel.GuessOptionDataModelDictionary != null && this._guessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(key))
				{
					guessOptionDataModel = this._guessProjectDataModel.GuessOptionDataModelDictionary[key];
				}
				component.InitItem(this._guessProjectDataModel, guessOptionDataModel);
			}
		}

		// Token: 0x0600D0CA RID: 53450 RVA: 0x00338590 File Offset: 0x00336990
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipGuessOptionItem component = item.GetComponent<ChampionshipGuessOptionItem>();
			if (component != null)
			{
				component.OnItemUpdate();
			}
		}

		// Token: 0x0600D0CB RID: 53451 RVA: 0x003385C4 File Offset: 0x003369C4
		private void OnReceiveChampionshipBetResMessage(UIEvent uiEvent)
		{
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			if (this._guessProjectDataModel.GuessOptionIdList == null || this._guessProjectDataModel.GuessOptionIdList.Count <= 0)
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
			bool flag = false;
			for (int i = 0; i < this._guessProjectDataModel.GuessOptionIdList.Count; i++)
			{
				ulong num3 = this._guessProjectDataModel.GuessOptionIdList[i];
				if (num2 == num3)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			this.UpdateTotalBetValue();
		}

		// Token: 0x04007A33 RID: 31283
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A34 RID: 31284
		private uint _guessProjectId;

		// Token: 0x04007A35 RID: 31285
		[Space(10f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private Text guessTitleLabel;

		// Token: 0x04007A36 RID: 31286
		[SerializeField]
		private Text guessTimeLabel;

		// Token: 0x04007A37 RID: 31287
		[SerializeField]
		private Text totalBetValueLabel;

		// Token: 0x04007A38 RID: 31288
		[Space(10f)]
		[Header("FunnyGuessItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx guessItemList;
	}
}
