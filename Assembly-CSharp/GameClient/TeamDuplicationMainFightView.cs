using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C59 RID: 7257
	public class TeamDuplicationMainFightView : MonoBehaviour
	{
		// Token: 0x06011D22 RID: 72994 RVA: 0x0053713A File Offset: 0x0053553A
		private void OnDestroy()
		{
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011D23 RID: 72995 RVA: 0x00537143 File Offset: 0x00535543
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011D24 RID: 72996 RVA: 0x00537151 File Offset: 0x00535551
		private void InitData()
		{
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
		}

		// Token: 0x06011D25 RID: 72997 RVA: 0x00537160 File Offset: 0x00535560
		private void InitView()
		{
			this.InitTitleLabel();
			if (this.fightCommonControl != null)
			{
				this.fightCommonControl.Init(this._isIn65LevelTeamDuplication);
			}
			if (this.headControl != null)
			{
				this.headControl.Init();
			}
			if (this.teamCaptainPanelControl != null)
			{
				this.teamCaptainPanelControl.Init();
			}
		}

		// Token: 0x06011D26 RID: 72998 RVA: 0x005371D0 File Offset: 0x005355D0
		private void InitTitleLabel()
		{
			if (this.titleLabel == null)
			{
				return;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				this.titleLabel.text = TR.Value("team_duplication_team_name_with_65_level");
			}
			else if (TeamDuplicationUtility.IsTeamDuplicationTeamDifficultyHardLevel())
			{
				this.titleLabel.text = TR.Value("team_duplication_hard_level_format");
			}
			else
			{
				this.titleLabel.text = TR.Value("team_duplication_normal_Level_format");
			}
		}

		// Token: 0x0400B99B RID: 47515
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B99C RID: 47516
		[Space(15f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B99D RID: 47517
		[Space(15f)]
		[Header("FightControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationFightCommonControl fightCommonControl;

		// Token: 0x0400B99E RID: 47518
		[Space(15f)]
		[Header("commonControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationHeadControl headControl;

		// Token: 0x0400B99F RID: 47519
		[SerializeField]
		private TeamDuplicationTeamCaptainPanelControl teamCaptainPanelControl;
	}
}
