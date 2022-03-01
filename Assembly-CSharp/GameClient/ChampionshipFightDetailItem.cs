using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E8 RID: 5352
	public class ChampionshipFightDetailItem : MonoBehaviour
	{
		// Token: 0x0600CFA7 RID: 53159 RVA: 0x00333DE1 File Offset: 0x003321E1
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CFA8 RID: 53160 RVA: 0x00333DE9 File Offset: 0x003321E9
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CFA9 RID: 53161 RVA: 0x00333DF8 File Offset: 0x003321F8
		private void BindUiEvents()
		{
			if (this.liveButtonWithCd != null)
			{
				this.liveButtonWithCd.ResetButtonListener();
				this.liveButtonWithCd.SetButtonListener(new Action(this.OnLiveButtonClick));
			}
			if (this.recordButtonWithCd != null)
			{
				this.recordButtonWithCd.ResetButtonListener();
				this.recordButtonWithCd.SetButtonListener(new Action(this.OnRecordButtonClick));
			}
		}

		// Token: 0x0600CFAA RID: 53162 RVA: 0x00333E6B File Offset: 0x0033226B
		private void UnBindUiEvents()
		{
			if (this.liveButtonWithCd != null)
			{
				this.liveButtonWithCd.ResetButtonListener();
			}
			if (this.recordButtonWithCd != null)
			{
				this.recordButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600CFAB RID: 53163 RVA: 0x00333EA5 File Offset: 0x003322A5
		private void ClearData()
		{
			this._fightGroupId = 0;
			this._fightDetailRecordDataModel = null;
			this._firstPlayerGuid = 0UL;
			this._fightRaceFightStatus = ChampionshipFightStatus.None;
		}

		// Token: 0x0600CFAC RID: 53164 RVA: 0x00333EC4 File Offset: 0x003322C4
		public void Init(int fightGroupId, ChampionshipFightDetailRecordDataModel fightDetailRecordDataModel, ulong firstPlayerGuid = 0UL, ulong secondPlayerGuid = 0UL, ChampionshipFightStatus raceFightStatus = ChampionshipFightStatus.None)
		{
			this._fightGroupId = fightGroupId;
			this._fightDetailRecordDataModel = fightDetailRecordDataModel;
			this._firstPlayerGuid = firstPlayerGuid;
			this._secondPlayerGuid = secondPlayerGuid;
			this._fightRaceFightStatus = raceFightStatus;
			if (fightGroupId <= 0)
			{
				return;
			}
			if (this._fightDetailRecordDataModel == null)
			{
				return;
			}
			string championshipFightRaceStr = ChampionshipUtility.GetChampionshipFightRaceStr((int)this._fightDetailRecordDataModel.FightOrder);
			if (this.fightNumberLabel != null)
			{
				this.fightNumberLabel.text = championshipFightRaceStr;
			}
			this.UpdateContent();
		}

		// Token: 0x0600CFAD RID: 53165 RVA: 0x00333F40 File Offset: 0x00332340
		private void UpdateContent()
		{
			CommonUtility.UpdateGameObjectVisible(this.commonBgFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.specialBgFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.fightingGo, false);
			CommonUtility.UpdateTextVisible(this.timeLabel, false);
			CommonUtility.UpdateGameObjectVisible(this.notFinishResultRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.finishResultRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.startRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.unStartRoot, false);
			ChampionshipFightStatus championshipFightStatus;
			if (!this._fightDetailRecordDataModel.IsStartFlag)
			{
				championshipFightStatus = ChampionshipFightStatus.NotStart;
			}
			else if (!this._fightDetailRecordDataModel.IsEndFlag)
			{
				championshipFightStatus = ChampionshipFightStatus.BeFighting;
			}
			else
			{
				championshipFightStatus = ChampionshipFightStatus.AlreadyFinished;
			}
			if (championshipFightStatus == ChampionshipFightStatus.BeFighting)
			{
				CommonUtility.UpdateGameObjectVisible(this.specialBgFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.fightingGo, true);
				CommonUtility.UpdateGameObjectVisible(this.notFinishResultRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.startRoot, true);
				CommonUtility.UpdateButtonWithCdVisible(this.recordButtonWithCd, false);
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.liveButtonWithCd, true);
				this.UpdateWatchNumberLabel();
			}
			else if (championshipFightStatus == ChampionshipFightStatus.AlreadyFinished)
			{
				CommonUtility.UpdateGameObjectVisible(this.commonBgFlag, true);
				if (this.timeLabel != null)
				{
					CommonUtility.UpdateTextVisible(this.timeLabel, true);
					this.timeLabel.text = TR.Value("Championship_Fight_Against_Already_Finished");
				}
				CommonUtility.UpdateGameObjectVisible(this.finishResultRoot, true);
				this.UpdateFightResultView();
				CommonUtility.UpdateGameObjectVisible(this.startRoot, true);
				CommonUtility.UpdateButtonWithCdVisible(this.liveButtonWithCd, false);
				if (this.recordButtonWithCd != null)
				{
					CommonUtility.UpdateButtonWithCdVisible(this.recordButtonWithCd, true);
					if (this._fightDetailRecordDataModel.RaceId <= 0UL)
					{
						this.recordButtonWithCd.UpdateButtonState(false);
						CommonUtility.UpdateUIGrayVisible(this.recordButtonGray, true);
					}
					else
					{
						this.recordButtonWithCd.UpdateButtonState(true);
						CommonUtility.UpdateUIGrayVisible(this.recordButtonGray, false);
					}
				}
				this.UpdateWatchNumberLabel();
			}
			else
			{
				if (this.timeLabel != null)
				{
					CommonUtility.UpdateTextVisible(this.timeLabel, true);
					if (this._fightRaceFightStatus == ChampionshipFightStatus.AlreadyFinished)
					{
						this.timeLabel.text = TR.Value("Championship_Fight_Race_Not_Fighting_Format");
					}
					else
					{
						string championshipFightStartTimeByIndex = ChampionshipUtility.GetChampionshipFightStartTimeByIndex(this._fightDetailRecordDataModel.FightOrder);
						this.timeLabel.text = TR.Value("Championship_Fight_Against_Start_Time_Format", championshipFightStartTimeByIndex);
					}
				}
				CommonUtility.UpdateGameObjectVisible(this.notFinishResultRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.unStartRoot, true);
			}
		}

		// Token: 0x0600CFAE RID: 53166 RVA: 0x0033419C File Offset: 0x0033259C
		private void UpdateFightResultView()
		{
			CommonUtility.UpdateGameObjectVisible(this.leftWinFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.leftLoseFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.rightWinFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.rightLoseFlag, false);
			if (this._fightDetailRecordDataModel.WinnerGuid == this._firstPlayerGuid)
			{
				CommonUtility.UpdateGameObjectVisible(this.leftWinFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.rightLoseFlag, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.leftLoseFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.rightWinFlag, true);
			}
		}

		// Token: 0x0600CFAF RID: 53167 RVA: 0x00334224 File Offset: 0x00332624
		private void UpdateWatchNumberLabel()
		{
			if (this.watchNumberLabel == null)
			{
				return;
			}
			string text = TR.Value("Championship_Fight_Against_Viewer_Format", this._fightDetailRecordDataModel.WatchNumber);
			this.watchNumberLabel.text = text;
		}

		// Token: 0x0600CFB0 RID: 53168 RVA: 0x0033426C File Offset: 0x0033266C
		private void OnLiveButtonClick()
		{
			if (this._fightGroupId <= 0)
			{
				return;
			}
			if (this._fightDetailRecordDataModel == null)
			{
				return;
			}
			if (!ChampionshipUtility.IsSelfPlayerCanWatchFightRace())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Fight_Live_Not_Watch"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionObserveReq(this._fightDetailRecordDataModel.RaceId);
		}

		// Token: 0x0600CFB1 RID: 53169 RVA: 0x003342C4 File Offset: 0x003326C4
		private void OnRecordButtonClick()
		{
			if (this._fightGroupId <= 0)
			{
				return;
			}
			if (this._fightDetailRecordDataModel == null)
			{
				return;
			}
			if (this._fightGroupId <= 0 || this._fightDetailRecordDataModel == null || this._fightDetailRecordDataModel.RaceId <= 0UL)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Fight_Against_No_Record_Label"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (!ChampionshipUtility.IsSelfPlayerCanWatchFightRace())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Fight_Record_Not_Watch"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CommonUtility.PlayReplay(this._fightDetailRecordDataModel.RaceId, false, new UnityAction(this.ReplayReplayAction));
		}

		// Token: 0x0600CFB2 RID: 53170 RVA: 0x0033435E File Offset: 0x0033275E
		private void ReplayReplayAction()
		{
			ChampionshipUtility.OnCloseChampionshipFightDetailFrame();
		}

		// Token: 0x0400796E RID: 31086
		private int _fightGroupId;

		// Token: 0x0400796F RID: 31087
		private ulong _firstPlayerGuid;

		// Token: 0x04007970 RID: 31088
		private ulong _secondPlayerGuid;

		// Token: 0x04007971 RID: 31089
		private ChampionshipFightStatus _fightRaceFightStatus;

		// Token: 0x04007972 RID: 31090
		private ChampionshipFightDetailRecordDataModel _fightDetailRecordDataModel;

		// Token: 0x04007973 RID: 31091
		[Space(10f)]
		[Header("FightNumberTitle")]
		[Space(10f)]
		[SerializeField]
		private Text fightNumberLabel;

		// Token: 0x04007974 RID: 31092
		[Space(10f)]
		[Header("SpecialFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject commonBgFlag;

		// Token: 0x04007975 RID: 31093
		[SerializeField]
		private GameObject specialBgFlag;

		// Token: 0x04007976 RID: 31094
		[Space(10f)]
		[Header("FightRace")]
		[Space(10f)]
		[SerializeField]
		private Text timeLabel;

		// Token: 0x04007977 RID: 31095
		[SerializeField]
		private GameObject fightingGo;

		// Token: 0x04007978 RID: 31096
		[Space(10f)]
		[Header("FightResult")]
		[Space(10f)]
		[SerializeField]
		private GameObject notFinishResultRoot;

		// Token: 0x04007979 RID: 31097
		[SerializeField]
		private GameObject finishResultRoot;

		// Token: 0x0400797A RID: 31098
		[SerializeField]
		private GameObject leftWinFlag;

		// Token: 0x0400797B RID: 31099
		[SerializeField]
		private GameObject leftLoseFlag;

		// Token: 0x0400797C RID: 31100
		[SerializeField]
		private GameObject rightWinFlag;

		// Token: 0x0400797D RID: 31101
		[SerializeField]
		private GameObject rightLoseFlag;

		// Token: 0x0400797E RID: 31102
		[Space(10f)]
		[Header("FightButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject unStartRoot;

		// Token: 0x0400797F RID: 31103
		[SerializeField]
		private GameObject startRoot;

		// Token: 0x04007980 RID: 31104
		[SerializeField]
		private ComButtonWithCd liveButtonWithCd;

		// Token: 0x04007981 RID: 31105
		[SerializeField]
		private ComButtonWithCd recordButtonWithCd;

		// Token: 0x04007982 RID: 31106
		[SerializeField]
		private UIGray recordButtonGray;

		// Token: 0x04007983 RID: 31107
		[SerializeField]
		private Text watchNumberLabel;
	}
}
