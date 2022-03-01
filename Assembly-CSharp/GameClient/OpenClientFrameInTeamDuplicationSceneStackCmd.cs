using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020010F4 RID: 4340
	public class OpenClientFrameInTeamDuplicationSceneStackCmd : BaseClientFrameStackCmd, IClientFrameStackCmd
	{
		// Token: 0x0600A455 RID: 42069 RVA: 0x0021C960 File Offset: 0x0021AD60
		public OpenClientFrameInTeamDuplicationSceneStackCmd(TeamCopyType teamCopyType) : base(eClientFrameStackCmd.OpenFrame)
		{
			this._teamCopyType = teamCopyType;
		}

		// Token: 0x0600A456 RID: 42070 RVA: 0x0021C970 File Offset: 0x0021AD70
		public bool Do()
		{
			bool result;
			try
			{
				if (this._teamCopyType == TeamCopyType.TC_TYPE_TWO)
				{
					bool flag = TeamDuplicationUtility.IsInFightSceneOf65LevelTeamDuplication();
					if (flag)
					{
						TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
						if (teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamType == TeamCopyType.TC_TYPE_TWO && teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_BATTLE)
						{
							TeamDuplicationUtility.OnOpenTeamDuplicationGridMapFrame();
						}
					}
				}
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x04005BDE RID: 23518
		private TeamCopyType _teamCopyType;
	}
}
