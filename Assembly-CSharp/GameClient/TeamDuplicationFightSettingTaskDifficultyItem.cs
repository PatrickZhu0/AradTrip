using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C91 RID: 7313
	public class TeamDuplicationFightSettingTaskDifficultyItem : MonoBehaviour
	{
		// Token: 0x06011EE5 RID: 73445 RVA: 0x0053E799 File Offset: 0x0053CB99
		private void Awake()
		{
		}

		// Token: 0x06011EE6 RID: 73446 RVA: 0x0053E79B File Offset: 0x0053CB9B
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011EE7 RID: 73447 RVA: 0x0053E7A3 File Offset: 0x0053CBA3
		private void ClearData()
		{
			this._teamCopyGrade = TeamCopyGrade.TEAM_COPY_GRADE_TEAM;
			this._selectedTeamIndex = 0;
			this._fightSettingDifficultyButtonAction = null;
		}

		// Token: 0x06011EE8 RID: 73448 RVA: 0x0053E7BA File Offset: 0x0053CBBA
		public void Init(TeamCopyGrade teamCopyGrade, int selectedTeamIndex, OnTeamDuplicationFightSettingDifficultyButtonAction fightSettingDifficultyButtonAction)
		{
			this._teamCopyGrade = teamCopyGrade;
			this._selectedTeamIndex = selectedTeamIndex;
			this._fightSettingDifficultyButtonAction = fightSettingDifficultyButtonAction;
			this.InitItem();
		}

		// Token: 0x06011EE9 RID: 73449 RVA: 0x0053E7D7 File Offset: 0x0053CBD7
		private void InitItem()
		{
			this.InitTaskInfo();
			this.InitTeamItemList();
		}

		// Token: 0x06011EEA RID: 73450 RVA: 0x0053E7E8 File Offset: 0x0053CBE8
		private void InitTaskInfo()
		{
			if (this.taskDifficultyLabel == null)
			{
				return;
			}
			string text = string.Empty;
			if (this._teamCopyGrade == TeamCopyGrade.TEAM_COPY_GRADE_A)
			{
				text = TR.Value("team_duplication_setting_difficulty_A");
			}
			else if (this._teamCopyGrade == TeamCopyGrade.TEAM_COPY_GRADE_B)
			{
				text = TR.Value("team_duplication_setting_difficulty_B");
			}
			else if (this._teamCopyGrade == TeamCopyGrade.TEAM_COPY_GRADE_C)
			{
				text = TR.Value("team_duplication_setting_difficulty_C");
			}
			else
			{
				text = TR.Value("team_duplication_setting_difficulty_D");
			}
			this.taskDifficultyLabel.text = text;
		}

		// Token: 0x06011EEB RID: 73451 RVA: 0x0053E878 File Offset: 0x0053CC78
		private void InitTeamItemList()
		{
			if (this.fightSettingTeamItemList == null || this.fightSettingTeamItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.fightSettingTeamItemList.Count; i++)
			{
				TeamDuplicationFightSettingTeamItem teamDuplicationFightSettingTeamItem = this.fightSettingTeamItemList[i];
				if (!(teamDuplicationFightSettingTeamItem == null))
				{
					int num = i + 1;
					bool isSelected = this._selectedTeamIndex == num;
					teamDuplicationFightSettingTeamItem.Init(num, isSelected, new OnTeamDuplicationFightSettingTeamButtonAction(this.OnTeamDuplicationFightSettingTeamItemAction));
				}
			}
		}

		// Token: 0x06011EEC RID: 73452 RVA: 0x0053E8FE File Offset: 0x0053CCFE
		private void OnTeamDuplicationFightSettingTeamItemAction(int teamIndex)
		{
			this._selectedTeamIndex = teamIndex;
			this.UpdateTeamItemList();
			if (this._fightSettingDifficultyButtonAction != null)
			{
				this._fightSettingDifficultyButtonAction((int)this._teamCopyGrade, this._selectedTeamIndex);
			}
		}

		// Token: 0x06011EED RID: 73453 RVA: 0x0053E930 File Offset: 0x0053CD30
		private void UpdateTeamItemList()
		{
			if (this.fightSettingTeamItemList == null || this.fightSettingTeamItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.fightSettingTeamItemList.Count; i++)
			{
				TeamDuplicationFightSettingTeamItem teamDuplicationFightSettingTeamItem = this.fightSettingTeamItemList[i];
				if (!(teamDuplicationFightSettingTeamItem == null))
				{
					if (teamDuplicationFightSettingTeamItem.GetTeamIndex() == this._selectedTeamIndex)
					{
						teamDuplicationFightSettingTeamItem.SetTeamItem(true);
					}
					else
					{
						teamDuplicationFightSettingTeamItem.SetTeamItem(false);
					}
				}
			}
		}

		// Token: 0x06011EEE RID: 73454 RVA: 0x0053E9B8 File Offset: 0x0053CDB8
		public void SetSelectedTeamItem(int selectedTeamIndex)
		{
			this._selectedTeamIndex = selectedTeamIndex;
			this.UpdateTeamItemList();
		}

		// Token: 0x06011EEF RID: 73455 RVA: 0x0053E9C7 File Offset: 0x0053CDC7
		public int GetTaskDifficultyIndex()
		{
			return (int)this._teamCopyGrade;
		}

		// Token: 0x0400BADC RID: 47836
		private TeamCopyGrade _teamCopyGrade;

		// Token: 0x0400BADD RID: 47837
		private int _selectedTeamIndex;

		// Token: 0x0400BADE RID: 47838
		private OnTeamDuplicationFightSettingDifficultyButtonAction _fightSettingDifficultyButtonAction;

		// Token: 0x0400BADF RID: 47839
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text taskDifficultyLabel;

		// Token: 0x0400BAE0 RID: 47840
		[SerializeField]
		private List<TeamDuplicationFightSettingTeamItem> fightSettingTeamItemList = new List<TeamDuplicationFightSettingTeamItem>();
	}
}
