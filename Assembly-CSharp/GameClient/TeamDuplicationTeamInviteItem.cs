using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C9D RID: 7325
	public class TeamDuplicationTeamInviteItem : MonoBehaviour
	{
		// Token: 0x06011F67 RID: 73575 RVA: 0x005404DE File Offset: 0x0053E8DE
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F68 RID: 73576 RVA: 0x005404E6 File Offset: 0x0053E8E6
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06011F69 RID: 73577 RVA: 0x005404F0 File Offset: 0x0053E8F0
		private void BindUiEvents()
		{
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetButtonListener();
				this.refuseButton.SetButtonListener(new Action(this.OnRefuseButtonClick));
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetButtonListener();
				this.agreeButton.SetButtonListener(new Action(this.OnAgreeButtonClick));
			}
			if (this.detailButton != null)
			{
				this.detailButton.onClick.RemoveAllListeners();
				this.detailButton.onClick.AddListener(new UnityAction(this.OnDetailButtonClick));
			}
		}

		// Token: 0x06011F6A RID: 73578 RVA: 0x005405A0 File Offset: 0x0053E9A0
		private void UnBindUiEvents()
		{
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetButtonListener();
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetButtonListener();
			}
			if (this.detailButton != null)
			{
				this.detailButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011F6B RID: 73579 RVA: 0x00540606 File Offset: 0x0053EA06
		public void Init(TeamDuplicationTeamInviteDataModel teamInviteDataModel)
		{
			this._teamInviteDataModel = teamInviteDataModel;
			if (this._teamInviteDataModel == null)
			{
				Logger.LogErrorFormat("TeamDuplicationTeamInviteItem teamInviteDataModel is null", new object[0]);
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F6C RID: 73580 RVA: 0x00540634 File Offset: 0x0053EA34
		private void InitItem()
		{
			if (this.teamLeaderHeadImage != null)
			{
				string text = string.Empty;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this._teamInviteDataModel.TeamLeaderProfessionId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						text = tableItem2.IconPath;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					ETCImageLoader.LoadSprite(ref this.teamLeaderHeadImage, text, true);
				}
			}
			if (this.teamLeaderHeadFrame != null)
			{
				string headPortraitFramePath = HeadPortraitFrameDataManager.GetHeadPortraitFramePath(this._teamInviteDataModel.HeadFrameId);
				if (this.teamLeaderHeadFrame != null && !string.IsNullOrEmpty(headPortraitFramePath))
				{
					ETCImageLoader.LoadSprite(ref this.teamLeaderHeadFrame, headPortraitFramePath, true);
				}
			}
			if (this.teamLeaderLevel != null)
			{
				this.teamLeaderLevel.text = string.Format(TR.Value("team_duplication_team_leader_level_format"), this._teamInviteDataModel.TeamLeaderLevel);
			}
			if (this.teamLeaderName != null)
			{
				this.teamLeaderName.text = this._teamInviteDataModel.TeamLeaderName;
			}
			if (this.teamBaseDescription != null)
			{
				CommonUtility.UpdateTextVisible(this.teamBaseDescription, true);
				if (this._teamInviteDataModel.TeamType == TeamCopyType.TC_TYPE_TWO)
				{
					string arg = TR.Value("team_duplication_team_name_with_65_level");
					string text2 = TR.Value("team_duplication_invite_in_normal_level_team_with_65_level", arg);
					this.teamBaseDescription.text = text2;
				}
				else if (this._teamInviteDataModel.TeamDifficultyLevel == 2U)
				{
					this.teamBaseDescription.text = TR.Value("team_duplication_invite_in_hard_level_team");
				}
				else
				{
					this.teamBaseDescription.text = TR.Value("team_duplication_invite_in_normal_level_team");
				}
			}
			if (this._teamInviteDataModel.TeamModel == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD)
			{
				CommonUtility.UpdateTextVisible(this.teamGoldDescription, true);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.teamGoldDescription, false);
			}
		}

		// Token: 0x06011F6D RID: 73581 RVA: 0x00540835 File Offset: 0x0053EC35
		private void OnRefuseButtonClick()
		{
			this.OnSendTeamCopyInviteChoiceReq(false);
		}

		// Token: 0x06011F6E RID: 73582 RVA: 0x0054083E File Offset: 0x0053EC3E
		private void OnAgreeButtonClick()
		{
			this.OnSendTeamCopyInviteChoiceReq(true);
		}

		// Token: 0x06011F6F RID: 73583 RVA: 0x00540847 File Offset: 0x0053EC47
		private void OnDetailButtonClick()
		{
			if (this._teamInviteDataModel == null)
			{
				return;
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamRoomFrame((int)this._teamInviteDataModel.TeamId);
		}

		// Token: 0x06011F70 RID: 73584 RVA: 0x00540868 File Offset: 0x0053EC68
		private void OnSendTeamCopyInviteChoiceReq(bool isAgree)
		{
			if (this._teamInviteDataModel == null)
			{
				return;
			}
			List<uint> teamInviteTeamIdList = this.GetTeamInviteTeamIdList();
			if (teamInviteTeamIdList == null || teamInviteTeamIdList.Count <= 0)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyInviteChoiceReq(isAgree, teamInviteTeamIdList);
		}

		// Token: 0x06011F71 RID: 73585 RVA: 0x005408A8 File Offset: 0x0053ECA8
		private List<uint> GetTeamInviteTeamIdList()
		{
			if (this._teamInviteDataModel == null)
			{
				return null;
			}
			return new List<uint>
			{
				this._teamInviteDataModel.TeamId
			};
		}

		// Token: 0x06011F72 RID: 73586 RVA: 0x005408DA File Offset: 0x0053ECDA
		public void Reset()
		{
			this._teamInviteDataModel = null;
		}

		// Token: 0x0400BB39 RID: 47929
		private TeamDuplicationTeamInviteDataModel _teamInviteDataModel;

		// Token: 0x0400BB3A RID: 47930
		[Space(15f)]
		[Header("TeamInviteData")]
		[Space(10f)]
		[SerializeField]
		private Image teamLeaderHeadFrame;

		// Token: 0x0400BB3B RID: 47931
		[SerializeField]
		private Image teamLeaderHeadImage;

		// Token: 0x0400BB3C RID: 47932
		[SerializeField]
		private Text teamLeaderLevel;

		// Token: 0x0400BB3D RID: 47933
		[SerializeField]
		private Text teamLeaderName;

		// Token: 0x0400BB3E RID: 47934
		[Space(15f)]
		[Header("TeamInviteTypeLabel")]
		[Space(10f)]
		[SerializeField]
		private Text teamBaseDescription;

		// Token: 0x0400BB3F RID: 47935
		[SerializeField]
		private Text teamGoldDescription;

		// Token: 0x0400BB40 RID: 47936
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd refuseButton;

		// Token: 0x0400BB41 RID: 47937
		[SerializeField]
		private ComButtonWithCd agreeButton;

		// Token: 0x0400BB42 RID: 47938
		[Space(10f)]
		[Header("DetailButton")]
		[Space(5f)]
		[SerializeField]
		private Button detailButton;
	}
}
