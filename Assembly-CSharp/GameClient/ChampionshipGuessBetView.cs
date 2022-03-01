using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014F3 RID: 5363
	public class ChampionshipGuessBetView : MonoBehaviour
	{
		// Token: 0x0600D021 RID: 53281 RVA: 0x00335BF5 File Offset: 0x00333FF5
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D022 RID: 53282 RVA: 0x00335BFD File Offset: 0x00333FFD
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D023 RID: 53283 RVA: 0x00335C0C File Offset: 0x0033400C
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.allInButton != null)
			{
				this.allInButton.onClick.RemoveAllListeners();
				this.allInButton.onClick.AddListener(new UnityAction(this.OnAllInButtonClick));
			}
			if (this.getItemButton != null)
			{
				this.getItemButton.onClick.RemoveAllListeners();
				this.getItemButton.onClick.AddListener(new UnityAction(this.OnGetItemButtonClick));
			}
			if (this.okBetButton != null)
			{
				this.okBetButton.onClick.RemoveAllListeners();
				this.okBetButton.onClick.AddListener(new UnityAction(this.OnOkBetButtonClick));
			}
			if (this.betButtonItemList != null)
			{
				this.betButtonItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.betButtonItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.betButtonItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.keyBoardButton != null)
			{
				this.keyBoardButton.onClick.RemoveAllListeners();
				this.keyBoardButton.onClick.AddListener(new UnityAction(this.OnKeyBoardButtonClick));
			}
		}

		// Token: 0x0600D024 RID: 53284 RVA: 0x00335DB4 File Offset: 0x003341B4
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.allInButton != null)
			{
				this.allInButton.onClick.RemoveAllListeners();
			}
			if (this.getItemButton != null)
			{
				this.getItemButton.onClick.RemoveAllListeners();
			}
			if (this.okBetButton != null)
			{
				this.okBetButton.onClick.RemoveAllListeners();
			}
			if (this.betButtonItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.betButtonItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.betButtonItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.keyBoardButton != null)
			{
				this.keyBoardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D025 RID: 53285 RVA: 0x00335EC8 File Offset: 0x003342C8
		private void ClearData()
		{
			this._projectId = 0U;
			this._guessOptionId = 0UL;
			this._finalBetValue = 0U;
			this._betButtonValueList = null;
			this._guessCostItemId = 0;
			this._guessItemTotalValue = 0;
			this._guessProjectDataModel = null;
			this._guessCostItemIdStr = null;
			this._defaultGuessBetMaxLimitNumber = 0U;
			this._canGuessBetMaxNumber = 0U;
			this._alreadyGuessBetNumber = 0U;
		}

		// Token: 0x0600D026 RID: 53286 RVA: 0x00335F24 File Offset: 0x00334324
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipAlreadyBetNumberMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipAlreadyBetNumberMessage));
		}

		// Token: 0x0600D027 RID: 53287 RVA: 0x00335F84 File Offset: 0x00334384
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipAlreadyBetNumberMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipAlreadyBetNumberMessage));
		}

		// Token: 0x0600D028 RID: 53288 RVA: 0x00335FE4 File Offset: 0x003343E4
		public void InitView(uint projectId, ulong guessOptionId)
		{
			this._finalBetValue = 0U;
			this._guessCostItemId = 330000271;
			this._projectId = projectId;
			this._guessOptionId = guessOptionId;
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionGambleAlreadyBetReq(this._projectId, this._guessOptionId);
			this._defaultGuessBetMaxLimitNumber = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessBetMaxLimitNumber();
			this._canGuessBetMaxNumber = 0U;
			this._alreadyGuessBetNumber = 0U;
			this._guessProjectDataModel = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectId(this._projectId);
			this._guessCostItemNameStr = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessCostItemNameStr();
			this._guessCostItemIdStr = CounterKeys.COUNTER_CHAMPIONSHIP_GUESS_ITEM;
			this.InitCommonLabel();
			this.InitGuessBetContent();
			this.InitCommonView();
			this.InitBetItemList();
		}

		// Token: 0x0600D029 RID: 53289 RVA: 0x0033608C File Offset: 0x0033448C
		private void InitCommonLabel()
		{
			this.UpdateGuessBetMaxLimitLabel();
			if (this.getItemTitleLabel != null)
			{
				string arg = ">>";
				string text = TR.Value("Championship_Guess_Bet_Get_Item_Format", this._guessCostItemNameStr, arg);
				this.getItemTitleLabel.text = text;
			}
		}

		// Token: 0x0600D02A RID: 53290 RVA: 0x003360D4 File Offset: 0x003344D4
		private void UpdateGuessBetMaxLimitLabel()
		{
			if (this.guessBetMaxLimitLabel != null)
			{
				string text = TR.Value("Championship_Guess_Bet_Limit_Money_Label_Format", this._defaultGuessBetMaxLimitNumber, this._guessCostItemNameStr, this._alreadyGuessBetNumber);
				this.guessBetMaxLimitLabel.text = text;
			}
		}

		// Token: 0x0600D02B RID: 53291 RVA: 0x00336128 File Offset: 0x00334528
		private void InitGuessBetContent()
		{
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			string text = string.Empty;
			string text2 = string.Empty;
			GambleType projectType = this._guessProjectDataModel.ProjectType;
			if (projectType == GambleType.GT_CHAMPION)
			{
				text = TR.Value("Championship_Guess_Record_First_Winner_Title_Format");
				string topPlayerNameByPlayerGuid = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(this._guessOptionId);
				text2 = TR.Value("Championship_Guess_Bet_First_Winner_Content_Format", topPlayerNameByPlayerGuid);
			}
			else if (projectType == GambleType.GT_1V1)
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				ChampionshipUtility.GetChampionshipFightRaceTwoPlayerName(this._guessProjectDataModel, out empty, out empty2);
				text = TR.Value("Championship_Guess_Record_Fight_Winner_Title_Normal_Format", empty, empty2);
				bool flag = ChampionshipUtility.IsFirstPlayerInFightGroup(this._guessProjectDataModel, this._guessOptionId);
				string topPlayerNameByPlayerGuid2 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(this._guessOptionId);
				string format = TR.Value("Championship_Guess_Bet_Fight_Winner_Result_First_Winner_Format");
				if (!flag)
				{
					format = TR.Value("Championship_Guess_Bet_Fight_Winner_Result_Second_Winner_Format");
				}
				text2 = string.Format(format, topPlayerNameByPlayerGuid2);
			}
			else if (projectType == GambleType.GT_BATTLE_COUNT)
			{
				text = TR.Value("Championship_Guess_Record_Fight_Race_Number_Title_Format");
				string championshipGuessFightRaceNumberStr = ChampionshipUtility.GetChampionshipGuessFightRaceNumberStr(this._guessOptionId);
				text2 = TR.Value("Championship_Guess_Bet_Fight_Race_Number_Content_Format", championshipGuessFightRaceNumberStr);
			}
			else if (projectType == GambleType.GT_CHAMPION_BATTLE_SCORE)
			{
				text = TR.Value("Championship_Guess_Record_Total_Score_Title_Format");
				string championshipGuessFinalScoreStr = ChampionshipUtility.GetChampionshipGuessFinalScoreStr(this._guessOptionId);
				text2 = TR.Value("Championship_Guess_Bet_Total_Score_Content_Format", championshipGuessFinalScoreStr);
			}
			if (this.guessContentLabel != null)
			{
				this.guessContentLabel.text = text;
			}
			if (this.guessBetLabel != null)
			{
				this.guessBetLabel.text = text2;
			}
		}

		// Token: 0x0600D02C RID: 53292 RVA: 0x003362A0 File Offset: 0x003346A0
		private void InitCommonView()
		{
			if (this.betTitleLabel != null)
			{
				this.betTitleLabel.text = TR.Value("Championship_Guess_Bet_Title_Label");
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._guessCostItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.guessCostItemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.guessCostItemIcon, tableItem.Icon, true);
				}
				if (this.ownerGuessItemTitleLabel != null)
				{
					this.ownerGuessItemTitleLabel.text = TR.Value("Championship_Guess_Bet_Owner_Item_Format", this._guessCostItemNameStr);
				}
			}
			this.UpdateGuessCostItemTotalCount();
			this.UpdateFinalBetValue();
		}

		// Token: 0x0600D02D RID: 53293 RVA: 0x00336350 File Offset: 0x00334750
		private void InitBetItemList()
		{
			this._betButtonValueList = ChampionshipUtility.GetGuessBetTabList();
			int elementAmount = 0;
			if (this._betButtonValueList != null)
			{
				elementAmount = this._betButtonValueList.Count;
			}
			if (this.betButtonItemList != null)
			{
				this.betButtonItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D02E RID: 53294 RVA: 0x003363A0 File Offset: 0x003347A0
		private void UpdateFinalBetValue()
		{
			if (this._finalBetValue > this._canGuessBetMaxNumber)
			{
				this._finalBetValue = this._canGuessBetMaxNumber;
			}
			if (this.finalBetValueLabel != null)
			{
				this.finalBetValueLabel.text = this._finalBetValue.ToString();
			}
		}

		// Token: 0x0600D02F RID: 53295 RVA: 0x003363F8 File Offset: 0x003347F8
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._betButtonValueList == null || this._betButtonValueList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._betButtonValueList.Count)
			{
				return;
			}
			int num = this._betButtonValueList[item.m_index];
			ChampionshipGuessBetValueItem component = item.GetComponent<ChampionshipGuessBetValueItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, new OnChampionshipGuessBetClickAction(this.OnGuessBetValueItemAction));
			}
		}

		// Token: 0x0600D030 RID: 53296 RVA: 0x00336494 File Offset: 0x00334894
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipGuessBetValueItem component = item.GetComponent<ChampionshipGuessBetValueItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D031 RID: 53297 RVA: 0x003364C8 File Offset: 0x003348C8
		private void OnGuessBetValueItemAction(int betValue)
		{
			if (betValue > this._guessItemTotalValue)
			{
				string msgContent = TR.Value("Championship_Guess_Bet_Owner_Item_Not_Enough", this._guessCostItemNameStr);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this._finalBetValue = (uint)betValue;
			this.UpdateFinalBetValue();
		}

		// Token: 0x0600D032 RID: 53298 RVA: 0x00336508 File Offset: 0x00334908
		private void OnReceiveChampionshipAlreadyBetNumberMessage(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null || uiEvent.Param3 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			ulong num2 = (ulong)uiEvent.Param2;
			if (num != this._projectId)
			{
				return;
			}
			if (num2 != this._guessOptionId)
			{
				return;
			}
			uint num3 = (uint)uiEvent.Param3;
			this._alreadyGuessBetNumber = num3;
			if (num3 >= this._defaultGuessBetMaxLimitNumber)
			{
				this._canGuessBetMaxNumber = 0U;
				CommonUtility.UpdateButtonState(this.okBetButton, this.okBetButtonGray, false);
			}
			else
			{
				this._canGuessBetMaxNumber = this._defaultGuessBetMaxLimitNumber - num3;
				CommonUtility.UpdateButtonState(this.okBetButton, this.okBetButtonGray, true);
			}
			this.UpdateGuessBetMaxLimitLabel();
		}

		// Token: 0x0600D033 RID: 53299 RVA: 0x003365D4 File Offset: 0x003349D4
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._guessCostItemIdStr))
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (!string.Equals(a, this._guessCostItemIdStr))
			{
				return;
			}
			this.UpdateGuessCostItemTotalCount();
		}

		// Token: 0x0600D034 RID: 53300 RVA: 0x00336628 File Offset: 0x00334A28
		private void UpdateGuessCostItemTotalCount()
		{
			this._guessItemTotalValue = CommonUtility.GetCounterValueByCounterStr(this._guessCostItemIdStr);
			if (this.guessCostItemTotalValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)this._guessItemTotalValue));
				this.guessCostItemTotalValueLabel.text = text;
			}
		}

		// Token: 0x0600D035 RID: 53301 RVA: 0x00336670 File Offset: 0x00334A70
		private void OnKeyBoardButtonClick()
		{
			Vector3 vector;
			vector..ctor(400f, 120f, 0f);
			CommonUtility.OnOpenCommonKeyBoardFrame(vector, (ulong)this._finalBetValue, (ulong)((long)this._guessItemTotalValue));
		}

		// Token: 0x0600D036 RID: 53302 RVA: 0x003366A8 File Offset: 0x00334AA8
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				Logger.LogErrorFormat("OnReceiveKeyBoardInput Error", new object[0]);
				return;
			}
			ulong num = (ulong)uiEvent.Param2;
			if (num >= (ulong)this._guessItemTotalValue)
			{
				this._finalBetValue = (uint)this._guessItemTotalValue;
			}
			else
			{
				this._finalBetValue = (uint)num;
			}
			this.UpdateFinalBetValue();
		}

		// Token: 0x0600D037 RID: 53303 RVA: 0x0033671A File Offset: 0x00334B1A
		private void OnAllInButtonClick()
		{
			this._finalBetValue = (uint)this._guessItemTotalValue;
			this.UpdateFinalBetValue();
		}

		// Token: 0x0600D038 RID: 53304 RVA: 0x00336730 File Offset: 0x00334B30
		private void OnOkBetButtonClick()
		{
			if ((long)this._guessItemTotalValue < (long)((ulong)this._finalBetValue))
			{
				string msgContent = TR.Value("Championship_Guess_Bet_Owner_Item_Not_Enough", this._guessCostItemNameStr);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._finalBetValue <= 0U)
			{
				return;
			}
			if (this._projectId > 0U && this._guessOptionId > 0UL)
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionBetReq(this._projectId, this._guessOptionId, this._finalBetValue);
			}
			ChampionshipUtility.OnCloseChampionshipGuessBetFrame();
		}

		// Token: 0x0600D039 RID: 53305 RVA: 0x003367B1 File Offset: 0x00334BB1
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipGuessBetFrame();
		}

		// Token: 0x0600D03A RID: 53306 RVA: 0x003367B8 File Offset: 0x00334BB8
		private void OnGetItemButtonClick()
		{
			int iItemLinkID = 330000271;
			ItemComeLink.OnLink(iItemLinkID, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x040079CA RID: 31178
		private uint _projectId;

		// Token: 0x040079CB RID: 31179
		private ulong _guessOptionId;

		// Token: 0x040079CC RID: 31180
		private uint _defaultGuessBetMaxLimitNumber;

		// Token: 0x040079CD RID: 31181
		private uint _alreadyGuessBetNumber;

		// Token: 0x040079CE RID: 31182
		private uint _canGuessBetMaxNumber;

		// Token: 0x040079CF RID: 31183
		private string _guessCostItemIdStr;

		// Token: 0x040079D0 RID: 31184
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x040079D1 RID: 31185
		private int _guessCostItemId;

		// Token: 0x040079D2 RID: 31186
		private int _guessItemTotalValue;

		// Token: 0x040079D3 RID: 31187
		private List<int> _betButtonValueList;

		// Token: 0x040079D4 RID: 31188
		private uint _finalBetValue;

		// Token: 0x040079D5 RID: 31189
		private string _guessCostItemNameStr;

		// Token: 0x040079D6 RID: 31190
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text betTitleLabel;

		// Token: 0x040079D7 RID: 31191
		[SerializeField]
		private Button closeButton;

		// Token: 0x040079D8 RID: 31192
		[Space(10f)]
		[Header("Guess")]
		[Space(10f)]
		[SerializeField]
		private Text guessContentLabel;

		// Token: 0x040079D9 RID: 31193
		[SerializeField]
		private Text guessBetLabel;

		// Token: 0x040079DA RID: 31194
		[SerializeField]
		private Text guessBetMaxLimitLabel;

		// Token: 0x040079DB RID: 31195
		[Space(20f)]
		[Header("Bet")]
		[Space(20f)]
		[SerializeField]
		private Text finalBetValueLabel;

		// Token: 0x040079DC RID: 31196
		[SerializeField]
		private Button keyBoardButton;

		// Token: 0x040079DD RID: 31197
		[Space(10f)]
		[Header("Money")]
		[Space(10f)]
		[SerializeField]
		private Text ownerGuessItemTitleLabel;

		// Token: 0x040079DE RID: 31198
		[SerializeField]
		private Image guessCostItemIcon;

		// Token: 0x040079DF RID: 31199
		[SerializeField]
		private Text guessCostItemTotalValueLabel;

		// Token: 0x040079E0 RID: 31200
		[Space(10f)]
		[Header("BetButtonList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx betButtonItemList;

		// Token: 0x040079E1 RID: 31201
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button allInButton;

		// Token: 0x040079E2 RID: 31202
		[SerializeField]
		private Button getItemButton;

		// Token: 0x040079E3 RID: 31203
		[SerializeField]
		private Button okBetButton;

		// Token: 0x040079E4 RID: 31204
		[SerializeField]
		private UIGray okBetButtonGray;

		// Token: 0x040079E5 RID: 31205
		[SerializeField]
		private Text getItemTitleLabel;
	}
}
