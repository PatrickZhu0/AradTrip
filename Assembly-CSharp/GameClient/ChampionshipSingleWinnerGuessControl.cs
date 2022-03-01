using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001503 RID: 5379
	public class ChampionshipSingleWinnerGuessControl : MonoBehaviour
	{
		// Token: 0x0600D0CD RID: 53453 RVA: 0x003386A0 File Offset: 0x00336AA0
		private void Awake()
		{
		}

		// Token: 0x0600D0CE RID: 53454 RVA: 0x003386A2 File Offset: 0x00336AA2
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D0CF RID: 53455 RVA: 0x003386AA File Offset: 0x00336AAA
		private void ClearData()
		{
			this._guessProjectDataModel = null;
			this._fightRaceDataModel = null;
			this._firstOptionDataModel = null;
			this._secondOptionDataModel = null;
			this._currentFirstPlayerGuid = 0UL;
			this._currentSecondPlayerGuid = 0UL;
			this._currentScheduleId = 0;
		}

		// Token: 0x0600D0D0 RID: 53456 RVA: 0x003386DF File Offset: 0x00336ADF
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0D1 RID: 53457 RVA: 0x003386FC File Offset: 0x00336AFC
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipBetResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipBetResMessage));
		}

		// Token: 0x0600D0D2 RID: 53458 RVA: 0x0033871C File Offset: 0x00336B1C
		public void InitControl(ChampionshipGuessProjectDataModel guessProjectDataModel)
		{
			this._guessProjectDataModel = guessProjectDataModel;
			CommonUtility.UpdateGameObjectVisible(this.guessRoot, false);
			this._firstOptionDataModel = null;
			this._secondOptionDataModel = null;
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			this._fightRaceDataModel = ChampionshipUtility.GetFightRaceDataModelByFightRaceId(this._guessProjectDataModel.FightRaceId);
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			if (this._guessProjectDataModel.GuessOptionIdList == null || this._guessProjectDataModel.GuessOptionIdList.Count != 2)
			{
				return;
			}
			if (this._guessProjectDataModel.GuessOptionDataModelDictionary == null || this._guessProjectDataModel.GuessOptionDataModelDictionary.Count <= 0)
			{
				return;
			}
			ulong firstPlayerGuid = this._fightRaceDataModel.FirstPlayerGuid;
			if (this._guessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(firstPlayerGuid))
			{
				this._firstOptionDataModel = this._guessProjectDataModel.GuessOptionDataModelDictionary[firstPlayerGuid];
			}
			ulong secondPlayerGuid = this._fightRaceDataModel.SecondPlayerGuid;
			if (this._guessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(secondPlayerGuid))
			{
				this._secondOptionDataModel = this._guessProjectDataModel.GuessOptionDataModelDictionary[secondPlayerGuid];
			}
			if (this._firstOptionDataModel == null || this._secondOptionDataModel == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.guessRoot, true);
			this.InitFightScheduleData();
			this.InitFightRaceStatusData();
			this.InitFirstPlayer();
			this.InitSecondPlayer();
			this.UpdateTotalBetValue();
		}

		// Token: 0x0600D0D3 RID: 53459 RVA: 0x0033887C File Offset: 0x00336C7C
		private void InitFightScheduleData()
		{
			if (this._currentScheduleId == this._guessProjectDataModel.ScheduleId)
			{
				return;
			}
			this._currentScheduleId = this._guessProjectDataModel.ScheduleId;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(this._currentScheduleId, string.Empty, string.Empty);
			if (tableItem != null && this.scheduleIconImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.scheduleIconImage, tableItem.ScheduleIconPath, true);
				this.scheduleIconImage.SetNativeSize();
			}
		}

		// Token: 0x0600D0D4 RID: 53460 RVA: 0x00338901 File Offset: 0x00336D01
		private void InitFightRaceStatusData()
		{
			if (this.fightRaceStatusControl != null)
			{
				this.fightRaceStatusControl.Init(this._fightRaceDataModel);
			}
		}

		// Token: 0x0600D0D5 RID: 53461 RVA: 0x00338928 File Offset: 0x00336D28
		private void InitFirstPlayer()
		{
			if (this.firstPlayerItem != null && this._currentFirstPlayerGuid != this._firstOptionDataModel.OptionId)
			{
				this._currentFirstPlayerGuid = this._firstOptionDataModel.OptionId;
				ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._currentFirstPlayerGuid);
				this.firstPlayerItem.Init(topPlayerDataModelByPlayerGuid);
			}
			if (this.firstOptionItem != null)
			{
				this.firstOptionItem.InitItem(this._guessProjectDataModel, this._firstOptionDataModel);
			}
		}

		// Token: 0x0600D0D6 RID: 53462 RVA: 0x003389B0 File Offset: 0x00336DB0
		private void InitSecondPlayer()
		{
			if (this.secondPlayerItem != null && this._currentSecondPlayerGuid != this._secondOptionDataModel.OptionId)
			{
				this._currentSecondPlayerGuid = this._secondOptionDataModel.OptionId;
				ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._secondOptionDataModel.OptionId);
				this.secondPlayerItem.Init(topPlayerDataModelByPlayerGuid);
			}
			if (this.secondOptionItem != null)
			{
				this.secondOptionItem.InitItem(this._guessProjectDataModel, this._secondOptionDataModel);
			}
		}

		// Token: 0x0600D0D7 RID: 53463 RVA: 0x00338A3C File Offset: 0x00336E3C
		private void OnReceiveChampionshipBetResMessage(UIEvent uiEvent)
		{
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			if (this._firstOptionDataModel == null || this._secondOptionDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			ulong num2 = (ulong)uiEvent.Param2;
			if (num != this._guessProjectDataModel.ProjectId)
			{
				return;
			}
			if (this._firstOptionDataModel.OptionId != num2 && this._secondOptionDataModel.OptionId != num2)
			{
				return;
			}
			this.UpdateTotalBetValue();
		}

		// Token: 0x0600D0D8 RID: 53464 RVA: 0x00338ADC File Offset: 0x00336EDC
		private void UpdateTotalBetValue()
		{
			if (this.totalOptionControl == null)
			{
				return;
			}
			this.totalOptionControl.UpdateTotalOptionControl(this._firstOptionDataModel.GuessNumber, this._secondOptionDataModel.GuessNumber, this._firstOptionDataModel.Odds, this._secondOptionDataModel.Odds);
		}

		// Token: 0x04007A39 RID: 31289
		private int _currentScheduleId;

		// Token: 0x04007A3A RID: 31290
		private ulong _currentFirstPlayerGuid;

		// Token: 0x04007A3B RID: 31291
		private ulong _currentSecondPlayerGuid;

		// Token: 0x04007A3C RID: 31292
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A3D RID: 31293
		private ChampionshipFightRaceDataModel _fightRaceDataModel;

		// Token: 0x04007A3E RID: 31294
		private ChampionshipGuessOptionDataModel _firstOptionDataModel;

		// Token: 0x04007A3F RID: 31295
		private ChampionshipGuessOptionDataModel _secondOptionDataModel;

		// Token: 0x04007A40 RID: 31296
		[Space(10f)]
		[Header("root")]
		[Space(10f)]
		[SerializeField]
		private GameObject guessRoot;

		// Token: 0x04007A41 RID: 31297
		[Space(10f)]
		[Header("FirstPlayer")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem firstPlayerItem;

		// Token: 0x04007A42 RID: 31298
		[SerializeField]
		private ChampionshipGuessOptionItem firstOptionItem;

		// Token: 0x04007A43 RID: 31299
		[Space(10f)]
		[Header("SecondPlayer")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem secondPlayerItem;

		// Token: 0x04007A44 RID: 31300
		[SerializeField]
		private ChampionshipGuessOptionItem secondOptionItem;

		// Token: 0x04007A45 RID: 31301
		[Space(10f)]
		[Header("TotalBetControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipGuessTotalOptionControl totalOptionControl;

		// Token: 0x04007A46 RID: 31302
		[Space(10f)]
		[Header("FightRace")]
		[Space(10f)]
		[SerializeField]
		private Image scheduleIconImage;

		// Token: 0x04007A47 RID: 31303
		[SerializeField]
		private ChampionshipFightRaceStatusControl fightRaceStatusControl;
	}
}
