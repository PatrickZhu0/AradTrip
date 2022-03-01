using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014F1 RID: 5361
	public class ChampionshipFightRaceStatusControl : MonoBehaviour
	{
		// Token: 0x0600D00C RID: 53260 RVA: 0x00335613 File Offset: 0x00333A13
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D00D RID: 53261 RVA: 0x0033561B File Offset: 0x00333A1B
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D00E RID: 53262 RVA: 0x0033562C File Offset: 0x00333A2C
		private void BindUiEvents()
		{
			if (this.liveButton != null)
			{
				this.liveButton.onClick.RemoveAllListeners();
				this.liveButton.onClick.AddListener(new UnityAction(this.OnLiveButtonClick));
			}
			if (this.recordButton != null)
			{
				this.recordButton.onClick.RemoveAllListeners();
				this.recordButton.onClick.AddListener(new UnityAction(this.OnRecordButtonClick));
			}
		}

		// Token: 0x0600D00F RID: 53263 RVA: 0x003356B4 File Offset: 0x00333AB4
		private void UnBindUiEvents()
		{
			if (this.liveButton != null)
			{
				this.liveButton.onClick.RemoveAllListeners();
			}
			if (this.recordButton != null)
			{
				this.recordButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D010 RID: 53264 RVA: 0x00335703 File Offset: 0x00333B03
		private void ClearData()
		{
			this._fightRaceDataModel = null;
		}

		// Token: 0x0600D011 RID: 53265 RVA: 0x0033570C File Offset: 0x00333B0C
		public void Init(ChampionshipFightRaceDataModel fightRaceDataModel)
		{
			if (fightRaceDataModel == null)
			{
				return;
			}
			this._fightRaceDataModel = fightRaceDataModel;
			this.UpdateView();
		}

		// Token: 0x0600D012 RID: 53266 RVA: 0x00335722 File Offset: 0x00333B22
		private void UpdateView()
		{
			this.UpdateStatusLabel();
			this.UpdateScoreValue();
			this.UpdateButtonStatus();
			this.UpdateFightResult();
		}

		// Token: 0x0600D013 RID: 53267 RVA: 0x0033573C File Offset: 0x00333B3C
		private void UpdateStatusLabel()
		{
			if (this.commonFightTimeLabel != null && this.commonFightStatusLabel != null)
			{
				string timeFormatByHourMinute = TimeUtility.GetTimeFormatByHourMinute((uint)this._fightRaceDataModel.StartTime);
				string text = string.Empty;
				string text2 = string.Empty;
				if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.BeFighting)
				{
					text = TR.Value("Championship_Fight_Race_Common_Fighting_Time_Label", timeFormatByHourMinute);
					text2 = TR.Value("Championship_Fight_Race_Common_Fighting_Status_Format");
				}
				else if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.AlreadyFinished)
				{
					text = TR.Value("Championship_Fight_Race_Common_Other_Status_Time_Label", timeFormatByHourMinute);
					text2 = TR.Value("Championship_Fight_Race_Common_Finish_Status_Format");
				}
				else
				{
					text = TR.Value("Championship_Fight_Race_Common_Other_Status_Time_Label", timeFormatByHourMinute);
					text2 = TR.Value("Championship_Fight_Race_Common_Begin_Status_Format");
				}
				this.commonFightTimeLabel.text = text;
				this.commonFightStatusLabel.text = text2;
			}
			if (this.fightStatusLabel != null)
			{
				string text3 = TR.Value("Championship_Fight_Against_Not_Starting");
				if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.AlreadyFinished)
				{
					text3 = TR.Value("Championship_Fight_Against_Already_Finished");
				}
				else if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.BeFighting)
				{
					text3 = TR.Value("Championship_Fight_Against_Fighting");
				}
				this.fightStatusLabel.text = text3;
			}
		}

		// Token: 0x0600D014 RID: 53268 RVA: 0x00335878 File Offset: 0x00333C78
		private void UpdateScoreValue()
		{
			if (this.fightScoreLabel != null)
			{
				if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.NotStart)
				{
					this.fightScoreLabel.text = TR.Value("Championship_Fight_Against_Not_Start_Flag");
				}
				else
				{
					this.fightScoreLabel.text = TR.Value("Championship_Fight_Against_Score_Format", this._fightRaceDataModel.FirstPlayerScore, this._fightRaceDataModel.SecondPlayerScore);
				}
			}
			if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.NotStart)
			{
				CommonUtility.UpdateTextVisible(this.firstPlayerScoreLabel, false);
				CommonUtility.UpdateTextVisible(this.secondPlayerScoreLabel, false);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.firstPlayerScoreLabel, true);
				CommonUtility.UpdateTextVisible(this.secondPlayerScoreLabel, true);
				if (this.firstPlayerScoreLabel != null)
				{
					this.firstPlayerScoreLabel.text = this._fightRaceDataModel.FirstPlayerScore.ToString();
				}
				if (this.secondPlayerScoreLabel != null)
				{
					this.secondPlayerScoreLabel.text = this._fightRaceDataModel.SecondPlayerScore.ToString();
				}
			}
		}

		// Token: 0x0600D015 RID: 53269 RVA: 0x003359A0 File Offset: 0x00333DA0
		private void UpdateButtonStatus()
		{
			if (this.startRoot == null || this.unStartRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.startRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.unStartRoot, false);
			if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.BeFighting)
			{
				CommonUtility.UpdateGameObjectVisible(this.startRoot, true);
				CommonUtility.UpdateButtonVisible(this.liveButton, true);
				CommonUtility.UpdateButtonVisible(this.recordButton, false);
			}
			else if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.AlreadyFinished)
			{
				CommonUtility.UpdateGameObjectVisible(this.startRoot, true);
				CommonUtility.UpdateButtonVisible(this.recordButton, true);
				CommonUtility.UpdateButtonVisible(this.liveButton, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.unStartRoot, true);
			}
		}

		// Token: 0x0600D016 RID: 53270 RVA: 0x00335A68 File Offset: 0x00333E68
		private void UpdateFightResult()
		{
			CommonUtility.UpdateGameObjectVisible(this.firstWinFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.firstLoseFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.secondWinFlag, false);
			CommonUtility.UpdateGameObjectVisible(this.secondLoseFlag, false);
			if (this._fightRaceDataModel.FightStatus != ChampionshipFightStatus.AlreadyFinished)
			{
				return;
			}
			if (this._fightRaceDataModel.FirstPlayerScore == this._fightRaceDataModel.SecondPlayerScore)
			{
				return;
			}
			if (this._fightRaceDataModel.FirstPlayerScore > this._fightRaceDataModel.SecondPlayerScore)
			{
				CommonUtility.UpdateGameObjectVisible(this.firstWinFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.secondLoseFlag, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.firstLoseFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.secondWinFlag, true);
			}
		}

		// Token: 0x0600D017 RID: 53271 RVA: 0x00335B23 File Offset: 0x00333F23
		private void OnLiveButtonClick()
		{
			this.OnOpenFightDetailFrame();
		}

		// Token: 0x0600D018 RID: 53272 RVA: 0x00335B2B File Offset: 0x00333F2B
		private void OnRecordButtonClick()
		{
			this.OnOpenFightDetailFrame();
		}

		// Token: 0x0600D019 RID: 53273 RVA: 0x00335B33 File Offset: 0x00333F33
		private void OnOpenFightDetailFrame()
		{
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			if (this._fightRaceDataModel.FightGroupId <= 0)
			{
				return;
			}
			ChampionshipUtility.OnOpenChampionshipFightDetailFrame(this._fightRaceDataModel.FightGroupId);
		}

		// Token: 0x040079BA RID: 31162
		private ChampionshipFightRaceDataModel _fightRaceDataModel;

		// Token: 0x040079BB RID: 31163
		[Space(10f)]
		[Header("CommonStatus")]
		[Space(10f)]
		[Space(10f)]
		[SerializeField]
		private Text commonFightTimeLabel;

		// Token: 0x040079BC RID: 31164
		[SerializeField]
		private Text commonFightStatusLabel;

		// Token: 0x040079BD RID: 31165
		[Space(10f)]
		[Header("Status")]
		[Space(10f)]
		[SerializeField]
		private Text fightStatusLabel;

		// Token: 0x040079BE RID: 31166
		[Space(10f)]
		[Header("PlayerScore")]
		[Space(10f)]
		[SerializeField]
		private Text fightScoreLabel;

		// Token: 0x040079BF RID: 31167
		[SerializeField]
		private Text firstPlayerScoreLabel;

		// Token: 0x040079C0 RID: 31168
		[SerializeField]
		private Text secondPlayerScoreLabel;

		// Token: 0x040079C1 RID: 31169
		[Space(10f)]
		[Header("FightButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject unStartRoot;

		// Token: 0x040079C2 RID: 31170
		[SerializeField]
		private GameObject startRoot;

		// Token: 0x040079C3 RID: 31171
		[SerializeField]
		private Button liveButton;

		// Token: 0x040079C4 RID: 31172
		[SerializeField]
		private Button recordButton;

		// Token: 0x040079C5 RID: 31173
		[Space(10f)]
		[Header("FinishFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject firstWinFlag;

		// Token: 0x040079C6 RID: 31174
		[SerializeField]
		private GameObject firstLoseFlag;

		// Token: 0x040079C7 RID: 31175
		[SerializeField]
		private GameObject secondWinFlag;

		// Token: 0x040079C8 RID: 31176
		[SerializeField]
		private GameObject secondLoseFlag;
	}
}
