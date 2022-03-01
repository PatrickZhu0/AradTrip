using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C51 RID: 7249
	public class TeamDuplicationFightSettingDifficultyView : MonoBehaviour
	{
		// Token: 0x06011CC9 RID: 72905 RVA: 0x00535AD3 File Offset: 0x00533ED3
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011CCA RID: 72906 RVA: 0x00535ADB File Offset: 0x00533EDB
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011CCB RID: 72907 RVA: 0x00535AEC File Offset: 0x00533EEC
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
				this.cancelButton.onClick.AddListener(new UnityAction(this.OnCancelButtonClick));
			}
			if (this.settingFinishButton != null)
			{
				this.settingFinishButton.onClick.RemoveAllListeners();
				this.settingFinishButton.onClick.AddListener(new UnityAction(this.OnSettingFinishButtonClick));
			}
		}

		// Token: 0x06011CCC RID: 72908 RVA: 0x00535BB0 File Offset: 0x00533FB0
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
			}
			if (this.settingFinishButton != null)
			{
				this.settingFinishButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011CCD RID: 72909 RVA: 0x00535C20 File Offset: 0x00534020
		private void ClearData()
		{
			this._teamConfigDataModelList = null;
		}

		// Token: 0x06011CCE RID: 72910 RVA: 0x00535C29 File Offset: 0x00534029
		private void OnEnable()
		{
		}

		// Token: 0x06011CCF RID: 72911 RVA: 0x00535C2B File Offset: 0x0053402B
		private void OnDisable()
		{
		}

		// Token: 0x06011CD0 RID: 72912 RVA: 0x00535C2D File Offset: 0x0053402D
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011CD1 RID: 72913 RVA: 0x00535C3C File Offset: 0x0053403C
		private void InitData()
		{
			if (this._teamConfigDataModelList == null)
			{
				this._teamConfigDataModelList = new List<TeamDuplicationTeamDifficultyConfigDataModel>();
			}
			this._teamConfigDataModelList.Clear();
			List<TeamDuplicationTeamDifficultyConfigDataModel> teamConfigDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamConfigDataModelList();
			for (int i = 0; i < teamConfigDataModelList.Count; i++)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = teamConfigDataModelList[i];
				if (teamDuplicationTeamDifficultyConfigDataModel != null)
				{
					TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel2 = new TeamDuplicationTeamDifficultyConfigDataModel();
					teamDuplicationTeamDifficultyConfigDataModel2.Difficulty = teamDuplicationTeamDifficultyConfigDataModel.Difficulty;
					teamDuplicationTeamDifficultyConfigDataModel2.TeamId = teamDuplicationTeamDifficultyConfigDataModel.TeamId;
					this._teamConfigDataModelList.Add(teamDuplicationTeamDifficultyConfigDataModel2);
				}
			}
		}

		// Token: 0x06011CD2 RID: 72914 RVA: 0x00535CC9 File Offset: 0x005340C9
		private void InitView()
		{
			this.InitTitle();
			this.InitTaskDifficultyItemList();
		}

		// Token: 0x06011CD3 RID: 72915 RVA: 0x00535CD8 File Offset: 0x005340D8
		private void InitTitle()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_setting_title");
			}
			if (this.taskSelectedDetailText != null)
			{
				this.taskSelectedDetailText.text = TR.Value("team_duplication_setting_compare_troop_task");
			}
		}

		// Token: 0x06011CD4 RID: 72916 RVA: 0x00535D34 File Offset: 0x00534134
		private void InitTaskDifficultyItemList()
		{
			if (this.taskDifficultyItemList == null)
			{
				return;
			}
			if (this._teamConfigDataModelList == null)
			{
				return;
			}
			for (int i = 0; i < this.taskDifficultyItemList.Count; i++)
			{
				TeamDuplicationFightSettingTaskDifficultyItem teamDuplicationFightSettingTaskDifficultyItem = this.taskDifficultyItemList[i];
				if (!(teamDuplicationFightSettingTaskDifficultyItem == null))
				{
					if (i < this._teamConfigDataModelList.Count)
					{
						TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = this._teamConfigDataModelList[i];
						if (teamDuplicationTeamDifficultyConfigDataModel != null)
						{
							teamDuplicationFightSettingTaskDifficultyItem.Init(i + TeamCopyGrade.TEAM_COPY_GRADE_A, teamDuplicationTeamDifficultyConfigDataModel.TeamId, new OnTeamDuplicationFightSettingDifficultyButtonAction(this.OnFightSettingDifficultyButtonAction));
						}
					}
				}
			}
		}

		// Token: 0x06011CD5 RID: 72917 RVA: 0x00535DDC File Offset: 0x005341DC
		private void OnFightSettingDifficultyButtonAction(int taskDifficultyIndex, int teamIndex)
		{
			if (this._teamConfigDataModelList == null || this._teamConfigDataModelList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._teamConfigDataModelList.Count; i++)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = this._teamConfigDataModelList[i];
				if (teamDuplicationTeamDifficultyConfigDataModel != null)
				{
					if (teamDuplicationTeamDifficultyConfigDataModel.Difficulty == (TeamCopyGrade)taskDifficultyIndex)
					{
						teamDuplicationTeamDifficultyConfigDataModel.TeamId = teamIndex;
					}
				}
			}
			if (teamIndex == 0)
			{
				return;
			}
			for (int j = 0; j < this._teamConfigDataModelList.Count; j++)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel2 = this._teamConfigDataModelList[j];
				if (teamDuplicationTeamDifficultyConfigDataModel2 != null)
				{
					if (teamDuplicationTeamDifficultyConfigDataModel2.Difficulty != (TeamCopyGrade)taskDifficultyIndex)
					{
						if (teamDuplicationTeamDifficultyConfigDataModel2.TeamId == teamIndex)
						{
							teamDuplicationTeamDifficultyConfigDataModel2.TeamId = 0;
							if (j < this.taskDifficultyItemList.Count)
							{
								TeamDuplicationFightSettingTaskDifficultyItem teamDuplicationFightSettingTaskDifficultyItem = this.taskDifficultyItemList[j];
								if (teamDuplicationFightSettingTaskDifficultyItem != null)
								{
									teamDuplicationFightSettingTaskDifficultyItem.SetSelectedTeamItem(0);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06011CD6 RID: 72918 RVA: 0x00535EE8 File Offset: 0x005342E8
		private void OnSettingFinishButtonClick()
		{
			for (int i = 0; i < this._teamConfigDataModelList.Count; i++)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = this._teamConfigDataModelList[i];
				if (teamDuplicationTeamDifficultyConfigDataModel != null)
				{
					if (teamDuplicationTeamDifficultyConfigDataModel.TeamId == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_setting_not_finished"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().UpdateTeamConfigDataModelList(this._teamConfigDataModelList);
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_setting_guide_model_ok"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			TeamDuplicationUtility.OnCloseTeamDuplicationFightPreSettingFrame();
			this.CloseFrame();
		}

		// Token: 0x06011CD7 RID: 72919 RVA: 0x00535F72 File Offset: 0x00534372
		private void OnCancelButtonClick()
		{
			this.CloseFrame();
		}

		// Token: 0x06011CD8 RID: 72920 RVA: 0x00535F7A File Offset: 0x0053437A
		private void OnCloseButtonClick()
		{
			this.CloseFrame();
		}

		// Token: 0x06011CD9 RID: 72921 RVA: 0x00535F82 File Offset: 0x00534382
		private void CloseFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightSettingDifficultyFrame();
		}

		// Token: 0x0400B966 RID: 47462
		private List<TeamDuplicationTeamDifficultyConfigDataModel> _teamConfigDataModelList;

		// Token: 0x0400B967 RID: 47463
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B968 RID: 47464
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B969 RID: 47465
		[Space(15f)]
		[Header("Bottom")]
		[Space(10f)]
		[SerializeField]
		private Text taskSelectedDetailText;

		// Token: 0x0400B96A RID: 47466
		[SerializeField]
		private Button cancelButton;

		// Token: 0x0400B96B RID: 47467
		[SerializeField]
		private Button settingFinishButton;

		// Token: 0x0400B96C RID: 47468
		[Space(15f)]
		[Header("guideMode")]
		[Space(10f)]
		[SerializeField]
		private List<TeamDuplicationFightSettingTaskDifficultyItem> taskDifficultyItemList;
	}
}
