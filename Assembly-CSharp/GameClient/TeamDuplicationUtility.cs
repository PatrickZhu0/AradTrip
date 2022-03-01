using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200133B RID: 4923
	public static class TeamDuplicationUtility
	{
		// Token: 0x0600BE75 RID: 48757 RVA: 0x002CC05C File Offset: 0x002CA45C
		public static void OnOpenTeamDuplicationChatFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationChatFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE76 RID: 48758 RVA: 0x002CC075 File Offset: 0x002CA475
		public static void OnCloseTeamDuplicationChatFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChatFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChatFrame>(null, false);
			}
		}

		// Token: 0x0600BE77 RID: 48759 RVA: 0x002CC093 File Offset: 0x002CA493
		public static void OnOpenTeamDuplicationSkillFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationSkillFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE78 RID: 48760 RVA: 0x002CC0AC File Offset: 0x002CA4AC
		private static void OnCloseTeamDuplicationSkillFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillTreeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillTreeFrame>(null, false);
			}
		}

		// Token: 0x0600BE79 RID: 48761 RVA: 0x002CC0CA File Offset: 0x002CA4CA
		public static void OnOpenTeamDuplicationPackageNewFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationPackageNewFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE7A RID: 48762 RVA: 0x002CC0E3 File Offset: 0x002CA4E3
		private static void OnCloseTeamDuplicationPackageNewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PackageNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PackageNewFrame>(null, false);
			}
		}

		// Token: 0x0600BE7B RID: 48763 RVA: 0x002CC101 File Offset: 0x002CA501
		public static void OnCloseTeamDuplicationMainBuildFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationMainBuildFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationMainBuildFrame>(null, false);
			}
		}

		// Token: 0x0600BE7C RID: 48764 RVA: 0x002CC11F File Offset: 0x002CA51F
		public static void OnOpenTeamDuplicationMainBuildFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationMainBuildFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationMainBuildFrame>(FrameLayer.Bottom, null, string.Empty);
		}

		// Token: 0x0600BE7D RID: 48765 RVA: 0x002CC138 File Offset: 0x002CA538
		public static void OnCloseTeamDuplicationTeamListFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamListFrame>(null, false);
			}
		}

		// Token: 0x0600BE7E RID: 48766 RVA: 0x002CC156 File Offset: 0x002CA556
		public static void OnOpenTeamDuplicationTeamListFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamListFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE7F RID: 48767 RVA: 0x002CC16F File Offset: 0x002CA56F
		public static void OnCloseTeamDuplicationTeamBuildFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamBuildFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamBuildFrame>(null, false);
			}
		}

		// Token: 0x0600BE80 RID: 48768 RVA: 0x002CC18D File Offset: 0x002CA58D
		public static void OnOpenTeamDuplicationTeamBuildFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamBuildFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamBuildFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE81 RID: 48769 RVA: 0x002CC1A6 File Offset: 0x002CA5A6
		public static void OnCloseTeamDuplicationTeamSettingFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamSettingFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamSettingFrame>(null, false);
			}
		}

		// Token: 0x0600BE82 RID: 48770 RVA: 0x002CC1C4 File Offset: 0x002CA5C4
		public static void OnOpenTeamDuplicationTeamSettingFrame(TeamDuplicationTeamBuildDataModel teamBuildDataModel)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamSettingFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamSettingFrame>(FrameLayer.Middle, teamBuildDataModel, string.Empty);
		}

		// Token: 0x0600BE83 RID: 48771 RVA: 0x002CC1DD File Offset: 0x002CA5DD
		public static void OnCloseTeamDuplicationTeamPermissionFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamPermissionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamPermissionFrame>(null, false);
			}
		}

		// Token: 0x0600BE84 RID: 48772 RVA: 0x002CC1FC File Offset: 0x002CA5FC
		public static void OnOpenTeamDuplicationTeamPermissionFrame(TeamDuplicationPlayerDataModel ownerPlayerDataModel, TeamDuplicationPlayerDataModel selectedPlayerDataModel, Vector2 clickScreenPosition)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamPermissionFrame();
			TeamDuplicationPermissionDataModel teamDuplicationPermissionDataModel = new TeamDuplicationPermissionDataModel();
			teamDuplicationPermissionDataModel.OwnerPlayerDataModel = ownerPlayerDataModel;
			teamDuplicationPermissionDataModel.SelectedPlayerDataModel = selectedPlayerDataModel;
			teamDuplicationPermissionDataModel.ClickScreenPosition = clickScreenPosition;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamPermissionFrame>(FrameLayer.Middle, teamDuplicationPermissionDataModel, string.Empty);
		}

		// Token: 0x0600BE85 RID: 48773 RVA: 0x002CC23B File Offset: 0x002CA63B
		public static void OnCloseTeamDuplicationTeamRoomFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamRoomFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamRoomFrame>(null, false);
			}
		}

		// Token: 0x0600BE86 RID: 48774 RVA: 0x002CC259 File Offset: 0x002CA659
		public static void OnOpenTeamDuplicationTeamRoomFrame(int teamId = 0)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamRoomFrame>(FrameLayer.Middle, teamId, string.Empty);
		}

		// Token: 0x0600BE87 RID: 48775 RVA: 0x002CC277 File Offset: 0x002CA677
		public static void OnCloseTeamDuplicationTeamInviteListFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationTeamInviteListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationTeamInviteListFrame>(null, false);
			}
		}

		// Token: 0x0600BE88 RID: 48776 RVA: 0x002CC295 File Offset: 0x002CA695
		private static void SetTeamDuplicationOwnerTeamInviteFlag()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewInvite)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewInvite = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, null, null, null, null);
		}

		// Token: 0x0600BE89 RID: 48777 RVA: 0x002CC2C4 File Offset: 0x002CA6C4
		public static void OnOpenTeamDuplicationTeamInviteListFrame()
		{
			TeamDuplicationUtility.SetTeamDuplicationOwnerTeamInviteFlag();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamInviteListFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamInviteListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE8A RID: 48778 RVA: 0x002CC2E2 File Offset: 0x002CA6E2
		public static void OnCloseTeamDuplicationFindTeamMateFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFindTeamMateFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFindTeamMateFrame>(null, false);
			}
		}

		// Token: 0x0600BE8B RID: 48779 RVA: 0x002CC300 File Offset: 0x002CA700
		public static void OnOpenTeamDuplicationFindTeamMateFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFindTeamMateFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFindTeamMateFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE8C RID: 48780 RVA: 0x002CC319 File Offset: 0x002CA719
		public static void OnCloseTeamDuplicationRequesterListFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationRequesterListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationRequesterListFrame>(null, false);
			}
		}

		// Token: 0x0600BE8D RID: 48781 RVA: 0x002CC337 File Offset: 0x002CA737
		private static void SetTeamDuplicationOwnerNewRequesterFlag()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewRequester)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewRequester = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, null, null, null, null);
		}

		// Token: 0x0600BE8E RID: 48782 RVA: 0x002CC366 File Offset: 0x002CA766
		public static void OnOpenTeamDuplicationRequesterListFrame()
		{
			TeamDuplicationUtility.SetTeamDuplicationOwnerNewRequesterFlag();
			TeamDuplicationUtility.OnCloseTeamDuplicationRequesterListFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationRequesterListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE8F RID: 48783 RVA: 0x002CC384 File Offset: 0x002CA784
		public static void OnCloseTeamDuplicationMainFightFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationMainFightFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationMainFightFrame>(null, false);
			}
		}

		// Token: 0x0600BE90 RID: 48784 RVA: 0x002CC3A2 File Offset: 0x002CA7A2
		public static void OnOpenTeamDuplicationMainFightFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationMainFightFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationMainFightFrame>(FrameLayer.Bottom, null, string.Empty);
		}

		// Token: 0x0600BE91 RID: 48785 RVA: 0x002CC3BB File Offset: 0x002CA7BB
		public static void OnCloseTeamDuplicationFightPreSettingFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightPreSettingFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightPreSettingFrame>(null, false);
			}
		}

		// Token: 0x0600BE92 RID: 48786 RVA: 0x002CC3D9 File Offset: 0x002CA7D9
		public static void OnOpenTeamDuplicationFightPreSettingFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightPreSettingFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightPreSettingFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE93 RID: 48787 RVA: 0x002CC3F2 File Offset: 0x002CA7F2
		public static void OnCloseTeamDuplicationFightSettingDifficultyFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightSettingDifficultyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightSettingDifficultyFrame>(null, false);
			}
		}

		// Token: 0x0600BE94 RID: 48788 RVA: 0x002CC410 File Offset: 0x002CA810
		public static void OnOpenTeamDuplicationFightSettingDifficultyFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightSettingDifficultyFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightSettingDifficultyFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE95 RID: 48789 RVA: 0x002CC429 File Offset: 0x002CA829
		public static void OnCloseTeamDuplicationFightCountDownFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightCountDownFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightCountDownFrame>(null, false);
			}
		}

		// Token: 0x0600BE96 RID: 48790 RVA: 0x002CC447 File Offset: 0x002CA847
		public static void OnOpenTeamDuplicationFightCountDownFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightCountDownFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightCountDownFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE97 RID: 48791 RVA: 0x002CC460 File Offset: 0x002CA860
		public static void OnOpenTeamDuplicationFightStartVoteFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStartVoteFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightStartVoteFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE98 RID: 48792 RVA: 0x002CC479 File Offset: 0x002CA879
		public static void OnCloseTeamDuplicationFightStartVoteFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightStartVoteFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightStartVoteFrame>(null, false);
			}
		}

		// Token: 0x0600BE99 RID: 48793 RVA: 0x002CC497 File Offset: 0x002CA897
		public static void OnOpenTeamDuplicationFightEndVoteFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightEndVoteFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightEndVoteFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BE9A RID: 48794 RVA: 0x002CC4B0 File Offset: 0x002CA8B0
		public static void OnCloseTeamDuplicationFightEndVoteFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightEndVoteFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightEndVoteFrame>(null, false);
			}
		}

		// Token: 0x0600BE9B RID: 48795 RVA: 0x002CC4D0 File Offset: 0x002CA8D0
		public static void OnOpenTeamDuplicationFightStageBeginDescriptionFrame(int stageId)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStageBeginDescriptionFrame();
			TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = new TeamDuplicationFightStageDescriptionDataModel();
			teamDuplicationFightStageDescriptionDataModel.StageId = stageId;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightStageBeginDescriptionFrame>(FrameLayer.Middle, teamDuplicationFightStageDescriptionDataModel, string.Empty);
		}

		// Token: 0x0600BE9C RID: 48796 RVA: 0x002CC501 File Offset: 0x002CA901
		public static void OnCloseTeamDuplicationFightStageBeginDescriptionFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightStageBeginDescriptionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightStageBeginDescriptionFrame>(null, false);
			}
		}

		// Token: 0x0600BE9D RID: 48797 RVA: 0x002CC520 File Offset: 0x002CA920
		public static void OnOpenTeamDuplicationFightStageEndDescriptionFrame(int stageId, bool isIn65LevelTeamDuplication = false, TC2PassType passType = TC2PassType.TC_2_PASS_TYPE_COMMON)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStageEndDescriptionFrame();
			TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = new TeamDuplicationFightStageDescriptionDataModel();
			teamDuplicationFightStageDescriptionDataModel.StageId = stageId;
			teamDuplicationFightStageDescriptionDataModel.IsIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			teamDuplicationFightStageDescriptionDataModel.PassTypeIn65LevelTeamDuplication = passType;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightStageEndDescriptionFrame>(FrameLayer.Middle, teamDuplicationFightStageDescriptionDataModel, string.Empty);
		}

		// Token: 0x0600BE9E RID: 48798 RVA: 0x002CC55F File Offset: 0x002CA95F
		public static void OnCloseTeamDuplicationFightStageEndDescriptionFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightStageEndDescriptionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightStageEndDescriptionFrame>(null, false);
			}
		}

		// Token: 0x0600BE9F RID: 48799 RVA: 0x002CC580 File Offset: 0x002CA980
		public static void OnOpenTeamDuplicationMiddleStageRewardFrame(int stageId, bool isIn65LevelTeamDuplication = false, TC2PassType passType = TC2PassType.TC_2_PASS_TYPE_COMMON)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationMiddleStageRewardFrame();
			TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = new TeamDuplicationFightStageDescriptionDataModel();
			teamDuplicationFightStageDescriptionDataModel.StageId = stageId;
			teamDuplicationFightStageDescriptionDataModel.IsIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			teamDuplicationFightStageDescriptionDataModel.PassTypeIn65LevelTeamDuplication = passType;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationMiddleStageRewardFrame>(FrameLayer.Middle, teamDuplicationFightStageDescriptionDataModel, string.Empty);
		}

		// Token: 0x0600BEA0 RID: 48800 RVA: 0x002CC5BF File Offset: 0x002CA9BF
		public static void OnCloseTeamDuplicationMiddleStageRewardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationMiddleStageRewardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationMiddleStageRewardFrame>(null, false);
			}
		}

		// Token: 0x0600BEA1 RID: 48801 RVA: 0x002CC5DD File Offset: 0x002CA9DD
		public static void OnOpenTeamDuplicationGameResultFrame(bool isSucceed = false)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGameResultFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationGameResultFrame>(FrameLayer.Middle, isSucceed, string.Empty);
		}

		// Token: 0x0600BEA2 RID: 48802 RVA: 0x002CC5FB File Offset: 0x002CA9FB
		public static void OnCloseTeamDuplicationGameResultFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationGameResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationGameResultFrame>(null, false);
			}
		}

		// Token: 0x0600BEA3 RID: 48803 RVA: 0x002CC619 File Offset: 0x002CAA19
		public static void OnOpenTeamDuplicationFinalStageCardFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFinalStageCardFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFinalStageCardFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BEA4 RID: 48804 RVA: 0x002CC632 File Offset: 0x002CAA32
		public static void OnCloseTeamDuplicationFinalStageCardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFinalStageCardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFinalStageCardFrame>(null, false);
			}
		}

		// Token: 0x0600BEA5 RID: 48805 RVA: 0x002CC650 File Offset: 0x002CAA50
		public static void OnOpenTeamDuplicationFinalCardFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFinalCardFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFinalCardFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BEA6 RID: 48806 RVA: 0x002CC669 File Offset: 0x002CAA69
		public static void OnCloseTeamDuplicationFinalCardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFinalCardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFinalCardFrame>(null, false);
			}
		}

		// Token: 0x0600BEA7 RID: 48807 RVA: 0x002CC687 File Offset: 0x002CAA87
		public static void OnCloseRelationFrameByLeaveTeam()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationChatFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
		}

		// Token: 0x0600BEA8 RID: 48808 RVA: 0x002CC693 File Offset: 0x002CAA93
		public static void OnCloseRelationFrameByOwnerTeam()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamListFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamInviteListFrame();
		}

		// Token: 0x0600BEA9 RID: 48809 RVA: 0x002CC69F File Offset: 0x002CAA9F
		public static void OnCloseRelationFrameBySwitchBuildSceneInTeamDuplication()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamPermissionFrame();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActorShowGroup>(null, false);
			TeamDuplicationUtility.OnCloseTeamDuplicationChatFrame();
		}

		// Token: 0x0600BEAA RID: 48810 RVA: 0x002CC6BC File Offset: 0x002CAABC
		public static void OnCloseRelationFrameBySwitchFightSceneInTeamDuplication()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamPermissionFrame();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActorShowGroup>(null, false);
			TeamDuplicationUtility.OnCloseTeamDuplicationChatFrame();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillTreeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillTreeFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PackageNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PackageNewFrame>(null, false);
			}
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			ShopNewUtility.OnCloseShopNewFrame();
			ShopNewUtility.OnCloseShowNewPurchaseItemFrame();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<RelationFrameNew>(null, false);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOkCancelNewFrame>(null, false);
		}

		// Token: 0x0600BEAB RID: 48811 RVA: 0x002CC74D File Offset: 0x002CAB4D
		public static void OnForceCloseRelationFrameInTeamDuplication()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenPetEggFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenPetEggFrame>(null, false);
			}
		}

		// Token: 0x0600BEAC RID: 48812 RVA: 0x002CC76B File Offset: 0x002CAB6B
		public static void OnCloseTeamDuplicationFightSceneLeaveTipFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightSceneLeaveTipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightSceneLeaveTipFrame>(null, false);
			}
		}

		// Token: 0x0600BEAD RID: 48813 RVA: 0x002CC789 File Offset: 0x002CAB89
		public static void OnOpenTeamDuplicationFightSceneLeaveTipFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightSceneLeaveTipFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightSceneLeaveTipFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BEAE RID: 48814 RVA: 0x002CC7A2 File Offset: 0x002CABA2
		public static void OnCloseTeamDuplicationFightStagePanelFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationFightStagePanelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationFightStagePanelFrame>(null, false);
			}
		}

		// Token: 0x0600BEAF RID: 48815 RVA: 0x002CC7C0 File Offset: 0x002CABC0
		public static void OnOpenTeamDuplicationFightStagePanelFrame(int fightStageId)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStagePanelFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationFightStagePanelFrame>(FrameLayer.Middle, fightStageId, string.Empty);
		}

		// Token: 0x0600BEB0 RID: 48816 RVA: 0x002CC7DE File Offset: 0x002CABDE
		public static void OnCloseTeamDuplicationGridMapFightBeginFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationGridMapFightBeginFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationGridMapFightBeginFrame>(null, false);
			}
		}

		// Token: 0x0600BEB1 RID: 48817 RVA: 0x002CC7FC File Offset: 0x002CABFC
		public static void OnOpenTeamDuplicationGridMapFightBeginFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFightBeginFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationGridMapFightBeginFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BEB2 RID: 48818 RVA: 0x002CC815 File Offset: 0x002CAC15
		public static void OnCloseTeamDuplicationGridMapFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationGridMapFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationGridMapFrame>(null, true);
			}
		}

		// Token: 0x0600BEB3 RID: 48819 RVA: 0x002CC833 File Offset: 0x002CAC33
		public static void OnOpenTeamDuplicationGridMapFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationGridMapFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BEB4 RID: 48820 RVA: 0x002CC84C File Offset: 0x002CAC4C
		public static void OnCloseTeamDuplicationGridItemTipFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationGridItemTipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamDuplicationGridItemTipFrame>(null, false);
			}
		}

		// Token: 0x0600BEB5 RID: 48821 RVA: 0x002CC86A File Offset: 0x002CAC6A
		public static void OnOpenTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipDataModel gridItemTipDataModel)
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationGridItemTipFrame>(FrameLayer.Middle, gridItemTipDataModel, string.Empty);
		}

		// Token: 0x0600BEB6 RID: 48822 RVA: 0x002CC883 File Offset: 0x002CAC83
		public static void OnCloseRelationFrameOf65LevelTeamDuplication()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFrame();
		}

		// Token: 0x0600BEB7 RID: 48823 RVA: 0x002CC890 File Offset: 0x002CAC90
		public static void ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType tipStatusType, TileInsData tileInsData, TileResData tileResData, uint gridObjectId = 0U, uint targetMonsterId = 0U, bool isDisableOfCaptainCd = false)
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationGridItemTipFrame(new TeamDuplicationGridItemTipDataModel
			{
				TileInsData = tileInsData,
				TileResData = tileResData,
				GridItemTipStatusType = tipStatusType,
				GridObjectId = gridObjectId,
				TargetMonsterId = targetMonsterId,
				IsDisableByCaptainCd = isDisableOfCaptainCd
			});
		}

		// Token: 0x0600BEB8 RID: 48824 RVA: 0x002CC8D8 File Offset: 0x002CACD8
		public static bool IsNeedReconnectToTeamDuplicationScene()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId <= 0)
			{
				return false;
			}
			int teamDuplicationReconnectSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId;
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(teamDuplicationReconnectSceneId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight);
		}

		// Token: 0x0600BEB9 RID: 48825 RVA: 0x002CC940 File Offset: 0x002CAD40
		public static void OpenReconnectToTeamDuplicationSceneTip(Action onReconnectToSceneAction, Action onCancelAction)
		{
			string contentLabel = TR.Value("team_duplication_Reconnect_to_scene");
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnLeftButtonClickCallBack = onCancelAction,
				OnRightButtonClickCallBack = onReconnectToSceneAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BEBA RID: 48826 RVA: 0x002CC9A4 File Offset: 0x002CADA4
		public static void ReconnectToTeamDuplicationScene()
		{
			if ((ulong)DataManager<TimeManager>.GetInstance().GetServerTime() > DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectExpireTime)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_reconnect_failed_by_pass_time"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationReconnectData();
				return;
			}
			int teamDuplicationReconnectSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId;
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationReconnectData();
			bool flag = TeamDuplicationUtility.IsTeamDuplicationSceneIdWithNormalLevel(teamDuplicationReconnectSceneId);
			bool flag2 = TeamDuplicationUtility.IsTeamDuplicationSceneIdWith65Level(teamDuplicationReconnectSceneId);
			if (flag || flag2)
			{
				TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationReconnectSceneId);
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamDataReq(0, teamDuplicationReconnectSceneId);
			}
		}

		// Token: 0x0600BEBB RID: 48827 RVA: 0x002CCA28 File Offset: 0x002CAE28
		public static bool IsTeamDuplicationSceneIdWithNormalLevel(int sceneId)
		{
			return sceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWithNormalLevel || sceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWithNormalLevel;
		}

		// Token: 0x0600BEBC RID: 48828 RVA: 0x002CCA4D File Offset: 0x002CAE4D
		public static bool IsTeamDuplicationSceneIdWith65Level(int sceneId)
		{
			return sceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWith65Level || sceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level;
		}

		// Token: 0x0600BEBD RID: 48829 RVA: 0x002CCA74 File Offset: 0x002CAE74
		public static void SwitchToTeamDuplicationBirthCityScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SceneParams data = new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = tableItem.BirthCity,
				targetDoorID = 0
			};
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(data, false));
		}

		// Token: 0x0600BEBE RID: 48830 RVA: 0x002CCAFC File Offset: 0x002CAEFC
		public static void BackToTeamDuplicationBuildScene()
		{
			int teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWithNormalLevel;
			if (TeamDuplicationUtility.IsIn65LevelTeamDuplication())
			{
				teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWith65Level;
			}
			TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationSceneId);
		}

		// Token: 0x0600BEBF RID: 48831 RVA: 0x002CCB30 File Offset: 0x002CAF30
		public static void EnterToTeamDuplicationSceneFromTown(bool isNormalTeamDuplication)
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId <= 0 || (ulong)DataManager<TimeManager>.GetInstance().GetServerTime() > DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectExpireTime)
			{
				if (isNormalTeamDuplication)
				{
					bool flag = TeamDuplicationUtility.IsOwnerTeamIn65Level();
					if (flag)
					{
						string arg = TR.Value("team_duplication_team_name_with_65_level");
						string msgContent = TR.Value("Team_Duplication_Can_Not_Change_Scene_For_Owner_Team", arg);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
				else
				{
					bool flag2 = TeamDuplicationUtility.IsOwnerTeamInNormalLevel();
					if (flag2)
					{
						string arg2 = TR.Value("team_duplication_team_name_with_normal_level");
						string msgContent2 = TR.Value("Team_Duplication_Can_Not_Change_Scene_For_Owner_Team", arg2);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent2, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
				TeamDuplicationUtility.EnterInTeamDuplicationBuildScene(isNormalTeamDuplication);
				ChallengeUtility.OnCloseChallengeMapFrame();
				return;
			}
			int teamDuplicationReconnectSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId;
			if (isNormalTeamDuplication)
			{
				if (teamDuplicationReconnectSceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWithNormalLevel)
				{
					TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationReconnectSceneId);
					DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamDataReq(0, teamDuplicationReconnectSceneId);
					DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationReconnectData();
					ChallengeUtility.OnCloseChallengeMapFrame();
				}
				else if (teamDuplicationReconnectSceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level)
				{
					string arg3 = TR.Value("team_duplication_team_name_with_65_level");
					string text = TR.Value("team_duplication_team_reconnect_tip_label", arg3);
					string contentStr = text;
					if (TeamDuplicationUtility.<>f__mg$cache0 == null)
					{
						TeamDuplicationUtility.<>f__mg$cache0 = new Action(TeamDuplicationUtility.OnReconnectTeamDuplicationClick);
					}
					TeamDuplicationUtility.OnOpenReconnectTeamDuplicationTipFrame(contentStr, TeamDuplicationUtility.<>f__mg$cache0);
				}
				else
				{
					TeamDuplicationUtility.EnterInTeamDuplicationBuildScene(true);
					ChallengeUtility.OnCloseChallengeMapFrame();
				}
			}
			else if (teamDuplicationReconnectSceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level)
			{
				TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationReconnectSceneId);
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamDataReq(0, teamDuplicationReconnectSceneId);
				DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationReconnectData();
				ChallengeUtility.OnCloseChallengeMapFrame();
			}
			else if (teamDuplicationReconnectSceneId == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWithNormalLevel)
			{
				string arg4 = TR.Value("team_duplication_team_name_with_normal_level");
				string text2 = TR.Value("team_duplication_team_reconnect_tip_label", arg4);
				string contentStr2 = text2;
				if (TeamDuplicationUtility.<>f__mg$cache1 == null)
				{
					TeamDuplicationUtility.<>f__mg$cache1 = new Action(TeamDuplicationUtility.OnReconnectTeamDuplicationClick);
				}
				TeamDuplicationUtility.OnOpenReconnectTeamDuplicationTipFrame(contentStr2, TeamDuplicationUtility.<>f__mg$cache1);
			}
			else
			{
				TeamDuplicationUtility.EnterInTeamDuplicationBuildScene(false);
				ChallengeUtility.OnCloseChallengeMapFrame();
			}
		}

		// Token: 0x0600BEC0 RID: 48832 RVA: 0x002CCD40 File Offset: 0x002CB140
		private static void OnOpenReconnectTeamDuplicationTipFrame(string contentStr, Action onOkAction)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure_2"),
				OnRightButtonClickCallBack = onOkAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BEC1 RID: 48833 RVA: 0x002CCD90 File Offset: 0x002CB190
		private static void OnReconnectTeamDuplicationClick()
		{
			int teamDuplicationReconnectSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectSceneId;
			if (teamDuplicationReconnectSceneId <= 0 || (ulong)DataManager<TimeManager>.GetInstance().GetServerTime() > DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationReconnectExpireTime)
			{
				string msgContent = TR.Value("team_duplication_team_reconnect_failed");
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationReconnectSceneId);
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamDataReq(0, teamDuplicationReconnectSceneId);
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationReconnectData();
			ChallengeUtility.OnCloseChallengeMapFrame();
		}

		// Token: 0x0600BEC2 RID: 48834 RVA: 0x002CCE00 File Offset: 0x002CB200
		public static void EnterInTeamDuplicationBuildScene(bool isNormalTeamDuplication = true)
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().IsEnterTeamDuplicationBuildSceneFromTown = true;
			int teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWithNormalLevel;
			if (!isNormalTeamDuplication)
			{
				teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWith65Level;
			}
			TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationSceneId);
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamDataReq(0, teamDuplicationSceneId);
		}

		// Token: 0x0600BEC3 RID: 48835 RVA: 0x002CCE68 File Offset: 0x002CB268
		public static void SwitchToTeamDuplicationFightScene()
		{
			int teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWithNormalLevel;
			if (TeamDuplicationUtility.IsIn65LevelTeamDuplication())
			{
				teamDuplicationSceneId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level;
			}
			TeamDuplicationUtility.SwitchToTeamDuplicationScene(teamDuplicationSceneId);
		}

		// Token: 0x0600BEC4 RID: 48836 RVA: 0x002CCE9C File Offset: 0x002CB29C
		private static void SwitchToTeamDuplicationScene(int teamDuplicationSceneId)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					clientSystemTownFrame.SetForbidFadeIn(true);
				}
			}
			SceneParams data = new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = teamDuplicationSceneId,
				targetDoorID = 0
			};
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(data, false));
		}

		// Token: 0x0600BEC5 RID: 48837 RVA: 0x002CCF5C File Offset: 0x002CB35C
		public static bool IsTeamDuplicationInFightScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight;
		}

		// Token: 0x0600BEC6 RID: 48838 RVA: 0x002CCFB4 File Offset: 0x002CB3B4
		public static bool IsTeamDuplicationInBuildScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid;
		}

		// Token: 0x0600BEC7 RID: 48839 RVA: 0x002CD00C File Offset: 0x002CB40C
		public static void SwitchTeamDuplicationToBuildSceneByQuitTeam()
		{
			if (TeamDuplicationUtility.IsTeamDuplicationInBuildScene())
			{
				return;
			}
			if (TeamDuplicationUtility.IsTeamDuplicationInFightScene())
			{
				TeamDuplicationUtility.BackToTeamDuplicationBuildScene();
			}
		}

		// Token: 0x0600BEC8 RID: 48840 RVA: 0x002CD028 File Offset: 0x002CB428
		public static void SwitchTeamDuplicationToFightSceneByAgreeBattle()
		{
			if (TeamDuplicationUtility.IsTeamDuplicationInFightScene())
			{
				return;
			}
			if (TeamDuplicationUtility.IsTeamDuplicationInBuildScene())
			{
				TeamDuplicationUtility.OnCloseRelationFrameBySwitchFightSceneInTeamDuplication();
				DataManager<TeamDuplicationDataManager>.GetInstance().FightVoteAgreeBySwitchFightScene = true;
				TeamDuplicationUtility.SwitchToTeamDuplicationFightScene();
			}
		}

		// Token: 0x0600BEC9 RID: 48841 RVA: 0x002CD054 File Offset: 0x002CB454
		public static int GetTeamDuplicationEquipmentScore()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return 0;
			}
			return teamDuplicationTeamDataModel.TeamEquipScore;
		}

		// Token: 0x0600BECA RID: 48842 RVA: 0x002CD07C File Offset: 0x002CB47C
		public static TeamDuplicationPlayerInformationDataModel CreateTeamDuplicationPlayerInformationDataModel()
		{
			return new TeamDuplicationPlayerInformationDataModel();
		}

		// Token: 0x0600BECB RID: 48843 RVA: 0x002CD090 File Offset: 0x002CB490
		public static bool IsSelfPlayerIsTeamLeaderInTeamDuplication()
		{
			TeamDuplicationPlayerDataModel ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
			return ownerPlayerDataModel != null && ownerPlayerDataModel.IsTeamLeader;
		}

		// Token: 0x0600BECC RID: 48844 RVA: 0x002CD0BC File Offset: 0x002CB4BC
		public static bool IsTeamDuplicationTeamDifficultyHardLevel()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			return teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamDifficultyLevel == 2U;
		}

		// Token: 0x0600BECD RID: 48845 RVA: 0x002CD0EC File Offset: 0x002CB4EC
		public static bool IsSelfPlayerIsCaptainInTeamDuplication()
		{
			TeamDuplicationPlayerDataModel ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
			return ownerPlayerDataModel != null && ownerPlayerDataModel.IsCaptain;
		}

		// Token: 0x0600BECE RID: 48846 RVA: 0x002CD118 File Offset: 0x002CB518
		public static bool IsSelfPlayerIsCaptainOrTeamLeaderInTroop()
		{
			TeamDuplicationPlayerDataModel ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
			return ownerPlayerDataModel != null && (ownerPlayerDataModel.IsTeamLeader || ownerPlayerDataModel.IsCaptain);
		}

		// Token: 0x0600BECF RID: 48847 RVA: 0x002CD14C File Offset: 0x002CB54C
		public static ulong GetTeamLeaderPlayerGuid()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return 0UL;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null && teamDuplicationCaptainDataModel.PlayerList.Count > 0)
				{
					for (int j = 0; j < teamDuplicationCaptainDataModel.PlayerList.Count; j++)
					{
						TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModel.PlayerList[j];
						if (teamDuplicationPlayerDataModel != null && teamDuplicationPlayerDataModel.IsTeamLeader)
						{
							return teamDuplicationPlayerDataModel.Guid;
						}
					}
				}
			}
			return 0UL;
		}

		// Token: 0x0600BED0 RID: 48848 RVA: 0x002CD21C File Offset: 0x002CB61C
		public static ulong GetTeamLeaderPlayerAccId()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return 0UL;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null && teamDuplicationCaptainDataModel.PlayerList.Count > 0)
				{
					for (int j = 0; j < teamDuplicationCaptainDataModel.PlayerList.Count; j++)
					{
						TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModel.PlayerList[j];
						if (teamDuplicationPlayerDataModel != null && teamDuplicationPlayerDataModel.IsTeamLeader)
						{
							return teamDuplicationPlayerDataModel.AccId;
						}
					}
				}
			}
			return 0UL;
		}

		// Token: 0x0600BED1 RID: 48849 RVA: 0x002CD2EC File Offset: 0x002CB6EC
		public static TeamDuplicationPlayerDataModel CreatePlayerDataModel(TeamCopyMember teamCopyMember)
		{
			return new TeamDuplicationPlayerDataModel
			{
				AccId = (ulong)teamCopyMember.accId,
				Guid = teamCopyMember.playerId,
				Name = teamCopyMember.playerName,
				ProfessionId = (int)teamCopyMember.playerOccu,
				PlayerAwakeState = (int)teamCopyMember.playerAwaken,
				Level = (int)teamCopyMember.playerLvl,
				EquipmentScore = (int)teamCopyMember.equipScore,
				SeatId = (int)teamCopyMember.seatId,
				TicketIsEnough = (teamCopyMember.ticketIsEnough != 0U),
				ZoneId = (int)teamCopyMember.zoneId,
				ExpireTime = teamCopyMember.expireTime,
				IsTeamLeader = ((teamCopyMember.post & 8U) != 0U),
				IsCaptain = ((teamCopyMember.post & 4U) != 0U),
				IsGoldOwner = ((teamCopyMember.post & 2U) != 0U)
			};
		}

		// Token: 0x0600BED2 RID: 48850 RVA: 0x002CD3C8 File Offset: 0x002CB7C8
		public static List<ComControlData> GetTeamPropertyDataListByType(TeamCopyTeamModel teamModel, TeamDuplicationTeamPropertyType troopPropertyType, bool isIn65LevelTeamDuplication = false)
		{
			List<ComControlData> list = new List<ComControlData>();
			int num = 1;
			if (isIn65LevelTeamDuplication)
			{
				num = 2;
			}
			int num2 = 1;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<TeamDuplicationSetTable>();
			if (table == null)
			{
				return list;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				TeamDuplicationSetTable teamDuplicationSetTable = keyValuePair.Value as TeamDuplicationSetTable;
				if (teamDuplicationSetTable != null)
				{
					if (teamDuplicationSetTable.TeamType == (int)teamModel && teamDuplicationSetTable.Type == (int)troopPropertyType && teamDuplicationSetTable.TeamRelation == num)
					{
						list.Add(new ComControlData
						{
							Id = num2,
							Name = teamDuplicationSetTable.Number.ToString(),
							Index = teamDuplicationSetTable.Number
						});
						num2++;
					}
				}
			}
			if (list.Count > 1)
			{
				list.Sort((ComControlData x, ComControlData y) => x.Index.CompareTo(y.Index));
			}
			return list;
		}

		// Token: 0x0600BED3 RID: 48851 RVA: 0x002CD4D3 File Offset: 0x002CB8D3
		private static TeamDuplicationPlayerType GetPlayerType(uint post)
		{
			if ((post & 8U) > 0U)
			{
				return TeamDuplicationPlayerType.TeamLeader;
			}
			if ((post & 4U) > 0U)
			{
				return TeamDuplicationPlayerType.Captain;
			}
			return TeamDuplicationPlayerType.Player;
		}

		// Token: 0x0600BED4 RID: 48852 RVA: 0x002CD4EC File Offset: 0x002CB8EC
		public static bool IsInSameTroopOfTwoPlayer(ulong ownerGuid, ulong selectedGuid)
		{
			if (ownerGuid == 0UL || selectedGuid == 0UL || ownerGuid == selectedGuid)
			{
				return false;
			}
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByPlayerGuid = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByPlayerGuid(ownerGuid);
			if (teamDuplicationCaptainDataModelByPlayerGuid == null || teamDuplicationCaptainDataModelByPlayerGuid.PlayerList == null || teamDuplicationCaptainDataModelByPlayerGuid.PlayerList.Count <= 1)
			{
				return false;
			}
			for (int i = 0; i < teamDuplicationCaptainDataModelByPlayerGuid.PlayerList.Count; i++)
			{
				TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModelByPlayerGuid.PlayerList[i];
				if (teamDuplicationPlayerDataModel != null && teamDuplicationPlayerDataModel.Guid == selectedGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BED5 RID: 48853 RVA: 0x002CD57C File Offset: 0x002CB97C
		public static int GetTeamDuplicationCaptainIdByPlayerGuid(ulong guid)
		{
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByPlayerGuid = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByPlayerGuid(guid);
			if (teamDuplicationCaptainDataModelByPlayerGuid == null)
			{
				return 0;
			}
			return teamDuplicationCaptainDataModelByPlayerGuid.CaptainId;
		}

		// Token: 0x0600BED6 RID: 48854 RVA: 0x002CD5A0 File Offset: 0x002CB9A0
		public static TeamDuplicationCaptainDataModel GetTeamDuplicationCaptainDataModelByPlayerGuid(ulong guid)
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null && teamDuplicationCaptainDataModel.PlayerList.Count > 0)
				{
					for (int j = 0; j < teamDuplicationCaptainDataModel.PlayerList.Count; j++)
					{
						TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModel.PlayerList[j];
						if (teamDuplicationPlayerDataModel != null && teamDuplicationPlayerDataModel.Guid == guid)
						{
							return teamDuplicationCaptainDataModel;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600BED7 RID: 48855 RVA: 0x002CD668 File Offset: 0x002CBA68
		public static int GetTeamDuplicationCaptainPlayerNumberByPlayerGuid(ulong guid)
		{
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByPlayerGuid = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByPlayerGuid(guid);
			if (teamDuplicationCaptainDataModelByPlayerGuid == null || teamDuplicationCaptainDataModelByPlayerGuid.PlayerList == null || teamDuplicationCaptainDataModelByPlayerGuid.PlayerList.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < teamDuplicationCaptainDataModelByPlayerGuid.PlayerList.Count; i++)
			{
				TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModelByPlayerGuid.PlayerList[i];
				if (teamDuplicationPlayerDataModel != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600BED8 RID: 48856 RVA: 0x002CD6D8 File Offset: 0x002CBAD8
		public static TeamDuplicationCaptainDataModel GetTeamDuplicationCaptainDataModelByCaptainId(int captainId)
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel != null)
				{
					if (teamDuplicationCaptainDataModel.CaptainId == captainId)
					{
						return teamDuplicationCaptainDataModel;
					}
				}
			}
			return null;
		}

		// Token: 0x0600BED9 RID: 48857 RVA: 0x002CD758 File Offset: 0x002CBB58
		public static uint GetTeamDuplicationCaptainPlayerNumberByCaptainId(int captainId)
		{
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByCaptainId = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByCaptainId(captainId);
			if (teamDuplicationCaptainDataModelByCaptainId == null || teamDuplicationCaptainDataModelByCaptainId.PlayerList == null || teamDuplicationCaptainDataModelByCaptainId.PlayerList.Count <= 0)
			{
				return 0U;
			}
			uint num = 0U;
			for (int i = 0; i < teamDuplicationCaptainDataModelByCaptainId.PlayerList.Count; i++)
			{
				TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModelByCaptainId.PlayerList[i];
				if (teamDuplicationPlayerDataModel != null)
				{
					num += 1U;
				}
			}
			return num;
		}

		// Token: 0x0600BEDA RID: 48858 RVA: 0x002CD7C8 File Offset: 0x002CBBC8
		public static int GetTeamDuplicationCaptainTotalEquipmentScore(int captainId)
		{
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByCaptainId = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByCaptainId(captainId);
			int num = 0;
			if (teamDuplicationCaptainDataModelByCaptainId == null || teamDuplicationCaptainDataModelByCaptainId.PlayerList == null || teamDuplicationCaptainDataModelByCaptainId.PlayerList.Count <= 0)
			{
				return num;
			}
			for (int i = 0; i < teamDuplicationCaptainDataModelByCaptainId.PlayerList.Count; i++)
			{
				TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModelByCaptainId.PlayerList[i];
				if (teamDuplicationPlayerDataModel != null)
				{
					num += teamDuplicationPlayerDataModel.EquipmentScore;
				}
			}
			return num;
		}

		// Token: 0x0600BEDB RID: 48859 RVA: 0x002CD83C File Offset: 0x002CBC3C
		public static void SetTeamDuplicationDefaultCaptainDifficultySetting()
		{
			List<TeamDuplicationTeamDifficultyConfigDataModel> list = new List<TeamDuplicationTeamDifficultyConfigDataModel>();
			for (int i = 0; i < DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumber; i++)
			{
				list.Add(new TeamDuplicationTeamDifficultyConfigDataModel
				{
					Difficulty = i + TeamCopyGrade.TEAM_COPY_GRADE_A,
					TeamId = i + 1
				});
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().InitTeamConfigDataModelList();
			DataManager<TeamDuplicationDataManager>.GetInstance().UpdateTeamConfigDataModelList(list);
		}

		// Token: 0x0600BEDC RID: 48860 RVA: 0x002CD89E File Offset: 0x002CBC9E
		public static TeamDuplicationPlayerDataModel GetOwnerPlayerDataModel()
		{
			return TeamDuplicationUtility.GetPlayerDataModelByGuid(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x0600BEDD RID: 48861 RVA: 0x002CD8B0 File Offset: 0x002CBCB0
		public static TeamDuplicationPlayerDataModel GetPlayerDataModelByGuid(ulong playerGuid)
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null && teamDuplicationCaptainDataModel.PlayerList.Count > 0)
				{
					for (int j = 0; j < teamDuplicationCaptainDataModel.PlayerList.Count; j++)
					{
						TeamDuplicationPlayerDataModel teamDuplicationPlayerDataModel = teamDuplicationCaptainDataModel.PlayerList[j];
						if (teamDuplicationPlayerDataModel != null && teamDuplicationPlayerDataModel.Guid == playerGuid)
						{
							return teamDuplicationPlayerDataModel;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600BEDE RID: 48862 RVA: 0x002CD97C File Offset: 0x002CBD7C
		public static bool IsEveryTroopOwnerPlayer()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return false;
			}
			TeamCopyType teamType = teamDuplicationTeamDataModel.TeamType;
			if (teamType == TeamCopyType.TC_TYPE_ONE)
			{
				if (teamDuplicationTeamDataModel.CaptainDataModelList.Count < 4)
				{
					return false;
				}
			}
			else if (teamDuplicationTeamDataModel.CaptainDataModelList.Count < 2)
			{
				return false;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				if (teamType != TeamCopyType.TC_TYPE_TWO || i < 2)
				{
					TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
					if (teamDuplicationCaptainDataModel == null)
					{
						return false;
					}
					if (teamDuplicationCaptainDataModel.PlayerList == null)
					{
						return false;
					}
					if (teamDuplicationCaptainDataModel.PlayerList.Count <= 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600BEDF RID: 48863 RVA: 0x002CDA58 File Offset: 0x002CBE58
		public static bool IsTeamTroopIsFull()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null || teamDuplicationTeamDataModel.CaptainDataModelList == null || teamDuplicationTeamDataModel.CaptainDataModelList.Count <= 0)
			{
				return false;
			}
			if (teamDuplicationTeamDataModel.CaptainDataModelList.Count < 4)
			{
				return false;
			}
			for (int i = 0; i < teamDuplicationTeamDataModel.CaptainDataModelList.Count; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = teamDuplicationTeamDataModel.CaptainDataModelList[i];
				if (teamDuplicationCaptainDataModel == null)
				{
					return false;
				}
				if (teamDuplicationCaptainDataModel.PlayerList == null)
				{
					return false;
				}
				for (int j = 0; j < teamDuplicationCaptainDataModel.PlayerList.Count; j++)
				{
					if (teamDuplicationCaptainDataModel.PlayerList[j] == null)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600BEE0 RID: 48864 RVA: 0x002CDB18 File Offset: 0x002CBF18
		public static List<ComControlData> GetTeamDuplicationTeamTypeDataList()
		{
			return new List<ComControlData>
			{
				new ComControlData
				{
					Id = 0,
					Name = TR.Value("team_duplication_troop_all_team_name")
				},
				new ComControlData
				{
					Id = 1,
					Name = TR.Value("team_duplication_troop_challenge_model_name")
				},
				new ComControlData
				{
					Id = 2,
					Name = TR.Value("team_duplication_troop_gold_team_name")
				}
			};
		}

		// Token: 0x0600BEE1 RID: 48865 RVA: 0x002CDB98 File Offset: 0x002CBF98
		public static string GetCaptainStatusDescription(int captainStatus)
		{
			if (captainStatus == 2)
			{
				return TR.Value("team_duplication_captain_status_battle");
			}
			if (captainStatus != 1)
			{
				return TR.Value("team_duplication_captain_status_init");
			}
			return TR.Value("team_duplication_captain_status_prepare");
		}

		// Token: 0x0600BEE2 RID: 48866 RVA: 0x002CDBDC File Offset: 0x002CBFDC
		public static bool IsOwnerTeamDuplicationDataModel(TeamCopyTeamDataRes teamDataRes)
		{
			if (teamDataRes == null)
			{
				return false;
			}
			if (teamDataRes.squadList == null || teamDataRes.squadList.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < teamDataRes.squadList.Length; i++)
			{
				SquadData squadData = teamDataRes.squadList[i];
				if (squadData != null)
				{
					if (squadData.teamMemberList != null && squadData.teamMemberList.Length > 0)
					{
						for (int j = 0; j < squadData.teamMemberList.Length; j++)
						{
							TeamCopyMember teamCopyMember = squadData.teamMemberList[j];
							if (teamCopyMember != null && teamCopyMember.playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BEE3 RID: 48867 RVA: 0x002CDC98 File Offset: 0x002CC098
		public static void UpdateTeamDataModelByTeamCopyTeamDataRes(TeamDuplicationTeamDataModel teamDataModel, TeamCopyTeamDataRes teamDataRes)
		{
			if (teamDataModel == null || teamDataRes == null)
			{
				return;
			}
			teamDataModel.TeamId = (int)teamDataRes.teamId;
			teamDataModel.TeamName = teamDataRes.teamName;
			teamDataModel.TotalCommission = (int)teamDataRes.totalCommission;
			teamDataModel.BonusCommission = (int)teamDataRes.bonusCommission;
			teamDataModel.AutoAgreeGold = (teamDataRes.autoAgreeGold != 0U);
			teamDataModel.TeamModel = (int)teamDataRes.teamModel;
			teamDataModel.TeamType = (TeamCopyType)teamDataRes.teamType;
			teamDataModel.TeamStatus = (TeamCopyTeamStatus)teamDataRes.status;
			teamDataModel.TeamDifficultyLevel = teamDataRes.teamGrade;
			teamDataModel.TeamEquipScore = (int)teamDataRes.equipScore;
			teamDataModel.VoiceTalkRoomId = teamDataRes.voiceRoomId;
			int teamDuplicationCaptainNumber = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumber;
			for (int i = 0; i < teamDuplicationCaptainNumber; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = new TeamDuplicationCaptainDataModel();
				teamDuplicationCaptainDataModel.CaptainId = i + 1;
				for (int j = 0; j < DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerNumberInCaptain; j++)
				{
					teamDuplicationCaptainDataModel.PlayerList.Add(null);
				}
				teamDataModel.CaptainDataModelList.Add(teamDuplicationCaptainDataModel);
			}
			if (teamDataRes.squadList != null && teamDataRes.squadList.Length > 0)
			{
				for (int k = 0; k < teamDataRes.squadList.Length; k++)
				{
					SquadData squadData = teamDataRes.squadList[k];
					if (squadData != null)
					{
						TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel2 = null;
						for (int l = 0; l < teamDataModel.CaptainDataModelList.Count; l++)
						{
							TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel3 = teamDataModel.CaptainDataModelList[l];
							if (teamDuplicationCaptainDataModel3 != null && teamDuplicationCaptainDataModel3.CaptainId == (int)squadData.squadId)
							{
								teamDuplicationCaptainDataModel2 = teamDuplicationCaptainDataModel3;
								break;
							}
						}
						if (teamDuplicationCaptainDataModel2 != null)
						{
							teamDuplicationCaptainDataModel2.CaptainStatus = (int)squadData.squadStatus;
							if (squadData.teamMemberList != null && squadData.teamMemberList.Length > 0)
							{
								for (int m = 0; m < squadData.teamMemberList.Length; m++)
								{
									TeamCopyMember teamCopyMember = squadData.teamMemberList[m];
									if (teamCopyMember != null)
									{
										int captainIndexBySeatId = TeamDuplicationUtility.GetCaptainIndexBySeatId((int)teamCopyMember.seatId);
										int playerIndexBySeatId = TeamDuplicationUtility.GetPlayerIndexBySeatId((int)teamCopyMember.seatId);
										if (captainIndexBySeatId == teamDuplicationCaptainDataModel2.CaptainId && playerIndexBySeatId >= 1 && playerIndexBySeatId <= DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerNumberInCaptain)
										{
											TeamDuplicationPlayerDataModel value = TeamDuplicationUtility.CreatePlayerDataModel(teamCopyMember);
											teamDuplicationCaptainDataModel2.PlayerList[playerIndexBySeatId - 1] = value;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BEE4 RID: 48868 RVA: 0x002CDF04 File Offset: 0x002CC304
		public static void UpdateTeamDataModelByTeamCopyTeamDetailRes(TeamDuplicationTeamDataModel teamDataModel, TeamCopyTeamDetailRes teamCopyTeamDetailRes)
		{
			if (teamDataModel == null || teamCopyTeamDetailRes == null)
			{
				return;
			}
			teamDataModel.TeamId = (int)teamCopyTeamDetailRes.teamId;
			teamDataModel.TeamName = teamCopyTeamDetailRes.teamName;
			teamDataModel.TotalCommission = (int)teamCopyTeamDetailRes.totalCommission;
			teamDataModel.BonusCommission = (int)teamCopyTeamDetailRes.bonusCommission;
			teamDataModel.TeamModel = (int)teamCopyTeamDetailRes.teamModel;
			teamDataModel.TeamType = (TeamCopyType)teamCopyTeamDetailRes.teamType;
			int teamDuplicationCaptainNumber = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumber;
			for (int i = 0; i < teamDuplicationCaptainNumber; i++)
			{
				TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = new TeamDuplicationCaptainDataModel();
				teamDuplicationCaptainDataModel.CaptainId = i + 1;
				for (int j = 0; j < DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerNumberInCaptain; j++)
				{
					teamDuplicationCaptainDataModel.PlayerList.Add(null);
				}
				teamDataModel.CaptainDataModelList.Add(teamDuplicationCaptainDataModel);
			}
			if (teamCopyTeamDetailRes.squadList != null && teamCopyTeamDetailRes.squadList.Length > 0)
			{
				for (int k = 0; k < teamCopyTeamDetailRes.squadList.Length; k++)
				{
					SquadData squadData = teamCopyTeamDetailRes.squadList[k];
					if (squadData != null)
					{
						TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel2 = null;
						for (int l = 0; l < teamDataModel.CaptainDataModelList.Count; l++)
						{
							TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel3 = teamDataModel.CaptainDataModelList[l];
							if (teamDuplicationCaptainDataModel3 != null && teamDuplicationCaptainDataModel3.CaptainId == (int)squadData.squadId)
							{
								teamDuplicationCaptainDataModel2 = teamDuplicationCaptainDataModel3;
								break;
							}
						}
						if (teamDuplicationCaptainDataModel2 != null)
						{
							teamDuplicationCaptainDataModel2.CaptainStatus = (int)squadData.squadStatus;
							if (squadData.teamMemberList != null && squadData.teamMemberList.Length > 0)
							{
								for (int m = 0; m < squadData.teamMemberList.Length; m++)
								{
									TeamCopyMember teamCopyMember = squadData.teamMemberList[m];
									if (teamCopyMember != null)
									{
										int captainIndexBySeatId = TeamDuplicationUtility.GetCaptainIndexBySeatId((int)teamCopyMember.seatId);
										int playerIndexBySeatId = TeamDuplicationUtility.GetPlayerIndexBySeatId((int)teamCopyMember.seatId);
										if (captainIndexBySeatId == teamDuplicationCaptainDataModel2.CaptainId && playerIndexBySeatId >= 1 && playerIndexBySeatId <= DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerNumberInCaptain)
										{
											TeamDuplicationPlayerDataModel value = TeamDuplicationUtility.CreatePlayerDataModel(teamCopyMember);
											teamDuplicationCaptainDataModel2.PlayerList[playerIndexBySeatId - 1] = value;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BEE5 RID: 48869 RVA: 0x002CE12C File Offset: 0x002CC52C
		public static bool IsOwnerTeamInNormalLevel()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				return false;
			}
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			return teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamType == TeamCopyType.TC_TYPE_ONE;
		}

		// Token: 0x0600BEE6 RID: 48870 RVA: 0x002CE16C File Offset: 0x002CC56C
		public static bool IsOwnerTeamIn65Level()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				return false;
			}
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			return teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamType == TeamCopyType.TC_TYPE_TWO;
		}

		// Token: 0x0600BEE7 RID: 48871 RVA: 0x002CE1AC File Offset: 0x002CC5AC
		private static int GetCaptainIndexBySeatId(int seatId)
		{
			return (seatId - 1) / 3 + 1;
		}

		// Token: 0x0600BEE8 RID: 48872 RVA: 0x002CE1C4 File Offset: 0x002CC5C4
		private static int GetPlayerIndexBySeatId(int seatId)
		{
			return (seatId - 1) % 3 + 1;
		}

		// Token: 0x0600BEE9 RID: 48873 RVA: 0x002CE1DC File Offset: 0x002CC5DC
		public static TeamCopyTeamStatus GetTeamDuplicationTeamStatus()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE;
			}
			return teamDuplicationTeamDataModel.TeamStatus;
		}

		// Token: 0x0600BEEA RID: 48874 RVA: 0x002CE204 File Offset: 0x002CC604
		public static bool IsTeamDuplicationPlayerInFightingStatus(TeamDuplicationPlayerDataModel playerDataModel)
		{
			if (playerDataModel == null)
			{
				return false;
			}
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByPlayerGuid = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByPlayerGuid(playerDataModel.Guid);
			return teamDuplicationCaptainDataModelByPlayerGuid != null && teamDuplicationCaptainDataModelByPlayerGuid.CaptainStatus == 2;
		}

		// Token: 0x0600BEEB RID: 48875 RVA: 0x002CE23C File Offset: 0x002CC63C
		public static void UpdateTeamDuplicationPlayerExpireTimeByGuid(ulong playerGuid, ulong expireTime)
		{
			TeamDuplicationPlayerDataModel playerDataModelByGuid = TeamDuplicationUtility.GetPlayerDataModelByGuid(playerGuid);
			if (playerDataModelByGuid != null)
			{
				playerDataModelByGuid.ExpireTime = expireTime;
			}
		}

		// Token: 0x0600BEEC RID: 48876 RVA: 0x002CE260 File Offset: 0x002CC660
		public static bool IsTeamDuplicationInFightingStatus()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			return teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_BATTLE;
		}

		// Token: 0x0600BEED RID: 48877 RVA: 0x002CE290 File Offset: 0x002CC690
		public static bool IsFightNumberAlreadyReachLimit()
		{
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			return playerInformationDataModel == null || playerInformationDataModel.DayAlreadyFightNumber >= playerInformationDataModel.DayTotalFightNumber || playerInformationDataModel.WeekAlreadyFightNumber >= playerInformationDataModel.WeekTotalFightNumber;
		}

		// Token: 0x0600BEEE RID: 48878 RVA: 0x002CE2D7 File Offset: 0x002CC6D7
		public static bool IsJoinInTeamDuplicationGoldIsNotEnough(int needGoldValue)
		{
			return DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner && DataManager<PlayerBaseData>.GetInstance().Gold < (ulong)((long)needGoldValue);
		}

		// Token: 0x0600BEEF RID: 48879 RVA: 0x002CE300 File Offset: 0x002CC700
		public static void UpdateTeamDuplicationTeamInviteDataModel(TCInviteInfo tcInviteInfo, TeamDuplicationTeamInviteDataModel teamInviteDataModel)
		{
			if (tcInviteInfo == null || teamInviteDataModel == null)
			{
				return;
			}
			teamInviteDataModel.TeamId = tcInviteInfo.teamId;
			teamInviteDataModel.TeamModel = (TeamCopyTeamModel)tcInviteInfo.teamModel;
			teamInviteDataModel.TeamType = (TeamCopyType)tcInviteInfo.teamType;
			teamInviteDataModel.TeamDifficultyLevel = tcInviteInfo.teamGrade;
			teamInviteDataModel.TeamLeaderName = tcInviteInfo.name;
			teamInviteDataModel.TeamLeaderLevel = (int)tcInviteInfo.level;
			teamInviteDataModel.TeamLeaderProfessionId = (int)tcInviteInfo.occu;
			teamInviteDataModel.TeamLeaderAwakeState = (int)tcInviteInfo.awaken;
		}

		// Token: 0x0600BEF0 RID: 48880 RVA: 0x002CE37C File Offset: 0x002CC77C
		public static void UpdateTeamDuplicationRequesterDataModel(TeamCopyApplyProperty applyProperty, TeamDuplicationRequesterDataModel requesterDataModel)
		{
			if (applyProperty == null || requesterDataModel == null)
			{
				return;
			}
			requesterDataModel.PlayerGuid = applyProperty.playerId;
			requesterDataModel.Name = applyProperty.playerName;
			requesterDataModel.Level = (int)applyProperty.playerLevel;
			requesterDataModel.ProfessionId = (int)applyProperty.playerOccu;
			requesterDataModel.PlayerAwakeState = (int)applyProperty.playerAwaken;
			requesterDataModel.EquipmentScore = (int)applyProperty.equipScore;
			requesterDataModel.ZoneId = (int)applyProperty.zoneId;
			requesterDataModel.IsGold = (applyProperty.isGold != 0U);
			requesterDataModel.IsFriend = RelationUtility.IsRelationFriend(applyProperty.playerId);
			requesterDataModel.GuildId = applyProperty.guildId;
			requesterDataModel.IsGuild = RelationUtility.IsRelationSameGuild(applyProperty.guildId);
		}

		// Token: 0x0600BEF1 RID: 48881 RVA: 0x002CE42C File Offset: 0x002CC82C
		public static void OnForwardFightSceneAndAgreeFight(string tipContent, Action onQuitAndReturn)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onQuitAndReturn
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BEF2 RID: 48882 RVA: 0x002CE47C File Offset: 0x002CC87C
		public static bool IsPlayerAlreadyAgreeFightStartVote(ulong playerGuid)
		{
			List<ulong> fightStartVoteAgreeList = DataManager<TeamDuplicationDataManager>.GetInstance().GetFightStartVoteAgreeList();
			if (fightStartVoteAgreeList == null || fightStartVoteAgreeList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < fightStartVoteAgreeList.Count; i++)
			{
				if (playerGuid == fightStartVoteAgreeList[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BEF3 RID: 48883 RVA: 0x002CE4D0 File Offset: 0x002CC8D0
		public static bool IsPlayerAlreadyAgreeFightEndVote(ulong playerGuid)
		{
			List<ulong> fightEndVoteAgreeList = DataManager<TeamDuplicationDataManager>.GetInstance().FightEndVoteAgreeList;
			if (fightEndVoteAgreeList == null || fightEndVoteAgreeList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < fightEndVoteAgreeList.Count; i++)
			{
				if (playerGuid == fightEndVoteAgreeList[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BEF4 RID: 48884 RVA: 0x002CE524 File Offset: 0x002CC924
		public static bool IsPlayerAlreadyRefuseFightEndVote(ulong playerGuid)
		{
			List<ulong> fightEndVoteRefuseList = DataManager<TeamDuplicationDataManager>.GetInstance().FightEndVoteRefuseList;
			if (fightEndVoteRefuseList == null || fightEndVoteRefuseList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < fightEndVoteRefuseList.Count; i++)
			{
				if (playerGuid == fightEndVoteRefuseList[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BEF5 RID: 48885 RVA: 0x002CE577 File Offset: 0x002CC977
		public static bool IsTeamDuplicationFightStart()
		{
			return TeamDuplicationUtility.GetTeamDuplicationTeamStatus() != TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE;
		}

		// Token: 0x0600BEF6 RID: 48886 RVA: 0x002CE588 File Offset: 0x002CC988
		public static bool IsFightPointShowInFightPanel(TeamDuplicationFightPointDataModel fightPointDataModel)
		{
			if (fightPointDataModel == null)
			{
				return false;
			}
			TeamCopyFieldStatus fightPointStatusType = fightPointDataModel.FightPointStatusType;
			return fightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_INVALID && fightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_DEFEAT;
		}

		// Token: 0x0600BEF7 RID: 48887 RVA: 0x002CE5B4 File Offset: 0x002CC9B4
		public static string GetFightPointStatusContent(TeamCopyFieldStatus fightPointStatusType)
		{
			switch (fightPointStatusType)
			{
			case TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_INVALID:
				return TR.Value("team_duplication_setting_guide_model_invalid");
			case TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_INIT:
				return TR.Value("team_duplication_setting_guide_model_can_challenge");
			case TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_REBORN:
				return TR.Value("team_duplication_setting_guide_model_reborn");
			case TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_DEFEAT:
				return TR.Value("team_duplication_setting_guide_model_destroy");
			case TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_URGENT:
				return TR.Value("team_duplication_setting_guide_model_urgent");
			default:
				return TR.Value("team_duplication_setting_guide_model_challenging");
			}
		}

		// Token: 0x0600BEF8 RID: 48888 RVA: 0x002CE624 File Offset: 0x002CCA24
		public static void UpdateTeamDuplicationFightPointDataModel(TeamDuplicationFightPointDataModel fightPointDataModel, TeamCopyFeild teamCopyField)
		{
			fightPointDataModel.FightPointId = (int)teamCopyField.feildId;
			fightPointDataModel.FightPointLeftFightNumber = (int)teamCopyField.oddNum;
			fightPointDataModel.FightPointStatusType = (TeamCopyFieldStatus)teamCopyField.state;
			fightPointDataModel.FightPointRebornTime = (int)teamCopyField.rebornTime;
			fightPointDataModel.FightPointEnergyAccumulationStartTime = (int)teamCopyField.energyReviveTime;
			fightPointDataModel.FightPointTeamList = teamCopyField.attackSquadList.ToList<uint>();
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>((int)teamCopyField.feildId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				fightPointDataModel.FightPointPosition = tableItem.PositionIndex;
				fightPointDataModel.FightPointTotalFightNumber = tableItem.DefeatCond;
			}
			if (fightPointDataModel.FightPointTotalFightNumber < fightPointDataModel.FightPointLeftFightNumber)
			{
				fightPointDataModel.FightPointTotalFightNumber = fightPointDataModel.FightPointLeftFightNumber;
			}
		}

		// Token: 0x0600BEF9 RID: 48889 RVA: 0x002CE6D4 File Offset: 0x002CCAD4
		public static bool IsFightPointFinishUnlocking(TeamCopyFieldStatus fieldPreStatus, TeamCopyFieldStatus fieldCurrentStatus)
		{
			return fieldPreStatus != fieldCurrentStatus && fieldPreStatus == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_UNLOCKING;
		}

		// Token: 0x0600BEFA RID: 48890 RVA: 0x002CE6EC File Offset: 0x002CCAEC
		public static void UpdateTeamDuplicationFightGoalDataModel(TeamDuplicationFightGoalDataModel teamDuplicationFightGoalDataModel, TeamCopyTarget teamCopyTarget)
		{
			if (teamDuplicationFightGoalDataModel == null || teamCopyTarget == null)
			{
				return;
			}
			teamDuplicationFightGoalDataModel.FightGoalId = (int)teamCopyTarget.targetId;
			teamDuplicationFightGoalDataModel.FightGoalDetailDataModelList.Clear();
			for (int i = 0; i < teamCopyTarget.targetDetailList.Length; i++)
			{
				TeamCopyTargetDetail teamCopyTargetDetail = teamCopyTarget.targetDetailList[i];
				if (teamCopyTargetDetail != null)
				{
					TeamDuplicationFightGoalDetailDataModel teamDuplicationFightGoalDetailDataModel = new TeamDuplicationFightGoalDetailDataModel();
					teamDuplicationFightGoalDetailDataModel.FightPointId = (int)teamCopyTargetDetail.fieldId;
					teamDuplicationFightGoalDetailDataModel.FightPointCurrentNumber = (int)teamCopyTargetDetail.curNum;
					teamDuplicationFightGoalDetailDataModel.FightPointTotalNumber = (int)teamCopyTargetDetail.totalNum;
					teamDuplicationFightGoalDataModel.FightGoalDetailDataModelList.Add(teamDuplicationFightGoalDetailDataModel);
				}
			}
		}

		// Token: 0x0600BEFB RID: 48891 RVA: 0x002CE77C File Offset: 0x002CCB7C
		public static string GetTeamDuplicationStageDescription(int stageId)
		{
			TeamCopyStageTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyStageTable>(stageId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Description;
			}
			return null;
		}

		// Token: 0x0600BEFC RID: 48892 RVA: 0x002CE7B0 File Offset: 0x002CCBB0
		public static string GetTeamDuplicationStageNamePath(int stageId)
		{
			TeamCopyStageTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyStageTable>(stageId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.StageImagePath;
			}
			return null;
		}

		// Token: 0x0600BEFD RID: 48893 RVA: 0x002CE7E4 File Offset: 0x002CCBE4
		public static bool IsSelectFightPointInFightPointList(int fightPointId)
		{
			List<TeamDuplicationFightPointDataModel> teamDuplicationFightPointDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightPointDataModelList;
			if (teamDuplicationFightPointDataModelList == null || teamDuplicationFightPointDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < teamDuplicationFightPointDataModelList.Count; i++)
			{
				TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = teamDuplicationFightPointDataModelList[i];
				if (teamDuplicationFightPointDataModel != null)
				{
					if (teamDuplicationFightPointDataModel.FightPointId == fightPointId)
					{
						if (TeamDuplicationUtility.IsFightPointShowInFightPanel(teamDuplicationFightPointDataModel))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BEFE RID: 48894 RVA: 0x002CE85C File Offset: 0x002CCC5C
		public static TeamDuplicationFightPointDataModel GetDefaultSelectedFightPointDataModel()
		{
			TeamDuplicationFightPointDataModel firstShowFightPointDataModel = TeamDuplicationUtility.GetFirstShowFightPointDataModel();
			if (!TeamDuplicationUtility.IsCaptainGoalExist())
			{
				return firstShowFightPointDataModel;
			}
			List<TeamDuplicationFightGoalDetailDataModel> fightGoalDetailDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel.FightGoalDetailDataModelList;
			if (fightGoalDetailDataModelList == null || fightGoalDetailDataModelList.Count <= 0)
			{
				return firstShowFightPointDataModel;
			}
			List<TeamDuplicationFightPointDataModel> teamDuplicationFightPointDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightPointDataModelList;
			if (teamDuplicationFightPointDataModelList == null || teamDuplicationFightPointDataModelList.Count <= 0)
			{
				return firstShowFightPointDataModel;
			}
			for (int i = 0; i < fightGoalDetailDataModelList.Count; i++)
			{
				TeamDuplicationFightGoalDetailDataModel teamDuplicationFightGoalDetailDataModel = fightGoalDetailDataModelList[i];
				if (teamDuplicationFightGoalDetailDataModel != null)
				{
					for (int j = 0; j < teamDuplicationFightPointDataModelList.Count; j++)
					{
						TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = teamDuplicationFightPointDataModelList[j];
						if (teamDuplicationFightPointDataModel != null)
						{
							if (teamDuplicationFightGoalDetailDataModel.FightPointId == teamDuplicationFightPointDataModel.FightPointId)
							{
								if (TeamDuplicationUtility.IsFightPointShowInFightPanel(teamDuplicationFightPointDataModel))
								{
									return teamDuplicationFightPointDataModel;
								}
							}
						}
					}
				}
			}
			return firstShowFightPointDataModel;
		}

		// Token: 0x0600BEFF RID: 48895 RVA: 0x002CE944 File Offset: 0x002CCD44
		private static TeamDuplicationFightPointDataModel GetFirstShowFightPointDataModel()
		{
			List<TeamDuplicationFightPointDataModel> teamDuplicationFightPointDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightPointDataModelList;
			if (teamDuplicationFightPointDataModelList == null || teamDuplicationFightPointDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < teamDuplicationFightPointDataModelList.Count; i++)
			{
				TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = teamDuplicationFightPointDataModelList[i];
				if (teamDuplicationFightPointDataModel != null)
				{
					if (TeamDuplicationUtility.IsFightPointShowInFightPanel(teamDuplicationFightPointDataModel))
					{
						return teamDuplicationFightPointDataModel;
					}
				}
			}
			return null;
		}

		// Token: 0x0600BF00 RID: 48896 RVA: 0x002CE9A8 File Offset: 0x002CCDA8
		public static bool IsFightPointInCaptainGoal(int fightPointId)
		{
			if (!TeamDuplicationUtility.IsCaptainGoalExist())
			{
				return false;
			}
			List<TeamDuplicationFightGoalDetailDataModel> fightGoalDetailDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel.FightGoalDetailDataModelList;
			if (fightGoalDetailDataModelList == null || fightGoalDetailDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < fightGoalDetailDataModelList.Count; i++)
			{
				TeamDuplicationFightGoalDetailDataModel teamDuplicationFightGoalDetailDataModel = fightGoalDetailDataModelList[i];
				if (teamDuplicationFightGoalDetailDataModel != null)
				{
					if (teamDuplicationFightGoalDetailDataModel.FightPointId == fightPointId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600BF01 RID: 48897 RVA: 0x002CEA1E File Offset: 0x002CCE1E
		public static bool IsCaptainGoalExist()
		{
			return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel != null && DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel.FightGoalId > 0;
		}

		// Token: 0x0600BF02 RID: 48898 RVA: 0x002CEA49 File Offset: 0x002CCE49
		public static bool IsTeamDuplicationGoalExit()
		{
			return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTeamFightGoalDataModel != null && DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTeamFightGoalDataModel.FightGoalId > 0;
		}

		// Token: 0x0600BF03 RID: 48899 RVA: 0x002CEA74 File Offset: 0x002CCE74
		public static List<ComControlData> GetFightGoalDataModelList(TeamDuplicationFightPointDataModel fightPointDataModel = null)
		{
			List<ComControlData> list = new List<ComControlData>();
			if (fightPointDataModel != null)
			{
				ComControlData item = new ComControlData
				{
					Id = 3,
					Name = TR.Value("team_duplication_fight_point_goal_Label"),
					Index = fightPointDataModel.FightPointId
				};
				list.Add(item);
			}
			if (TeamDuplicationUtility.IsTeamDuplicationGoalExit())
			{
				ComControlData item2 = new ComControlData
				{
					Id = 2,
					Name = TR.Value("team_duplication_fight_team_duplication_goal_Label"),
					Index = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTeamFightGoalDataModel.FightGoalId
				};
				list.Add(item2);
			}
			if (TeamDuplicationUtility.IsCaptainGoalExist())
			{
				ComControlData item3 = new ComControlData
				{
					Id = 1,
					Name = TR.Value("team_duplication_fight_captain_goal_Label"),
					Index = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainFightGoalDataModel.FightGoalId
				};
				list.Add(item3);
			}
			return list;
		}

		// Token: 0x0600BF04 RID: 48900 RVA: 0x002CEB4C File Offset: 0x002CCF4C
		public static void ShowUnLockFightPointNameTips(int fightPointId)
		{
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(fightPointId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.UnLockTip == 0)
			{
				return;
			}
			string name = tableItem.Name;
			if (string.IsNullOrEmpty(name))
			{
				return;
			}
			string msgContent = TR.Value("team_duplication_fight_point_unlock", name);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BF05 RID: 48901 RVA: 0x002CEBAC File Offset: 0x002CCFAC
		public static void ShowUnLockFightPointListTips(List<string> unLockFightPointNameList)
		{
			if (unLockFightPointNameList == null || unLockFightPointNameList.Count <= 0)
			{
				return;
			}
			int count = unLockFightPointNameList.Count;
			string text = string.Empty;
			for (int i = 0; i < count; i++)
			{
				string str = unLockFightPointNameList[i];
				text += str;
				if (i < count - 1)
				{
					text += " ";
				}
			}
			string msgContent = TR.Value("team_duplication_fight_point_unlock", text);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BF06 RID: 48902 RVA: 0x002CEC28 File Offset: 0x002CD028
		public static void GetUnLockFightPointName(int fightPointId, List<string> unLockFightPointNameList)
		{
			if (unLockFightPointNameList == null)
			{
				return;
			}
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(fightPointId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.UnLockTip == 0)
			{
				return;
			}
			unLockFightPointNameList.Add(tableItem.Name);
		}

		// Token: 0x0600BF07 RID: 48903 RVA: 0x002CEC74 File Offset: 0x002CD074
		public static string GetFightGoalDescription(TeamDuplicationFightGoalDataModel fightGoalDataModel)
		{
			if (fightGoalDataModel == null)
			{
				return string.Empty;
			}
			TeamCopyTargetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyTargetTable>(fightGoalDataModel.FightGoalId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string description = tableItem.Description;
				string text = string.Empty;
				string subDescription = tableItem.SubDescription;
				List<TeamDuplicationFightGoalDetailDataModel> fightGoalDetailDataModelList = fightGoalDataModel.FightGoalDetailDataModelList;
				if (fightGoalDetailDataModelList != null)
				{
					for (int i = 0; i < fightGoalDetailDataModelList.Count; i++)
					{
						TeamDuplicationFightGoalDetailDataModel teamDuplicationFightGoalDetailDataModel = fightGoalDetailDataModelList[i];
						if (teamDuplicationFightGoalDetailDataModel != null)
						{
							TeamCopyFieldTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(teamDuplicationFightGoalDetailDataModel.FightPointId, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								string str = string.Format(subDescription, tableItem2.Name, teamDuplicationFightGoalDetailDataModel.FightPointCurrentNumber, teamDuplicationFightGoalDetailDataModel.FightPointTotalNumber);
								text += str;
								if (i < fightGoalDetailDataModelList.Count - 1)
								{
									text += ",";
								}
							}
						}
					}
				}
				return string.Format(description, text);
			}
			return string.Empty;
		}

		// Token: 0x0600BF08 RID: 48904 RVA: 0x002CED88 File Offset: 0x002CD188
		public static TeamDuplicationFightPointEnergyAccumulationDataModel GetEnergyAccumulationFightPointDataModel()
		{
			TeamDuplicationFightPointEnergyAccumulationDataModel teamDuplicationFightPointEnergyAccumulationDataModel = new TeamDuplicationFightPointEnergyAccumulationDataModel();
			teamDuplicationFightPointEnergyAccumulationDataModel.TimeUpdateInterval = 0f;
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(39, string.Empty, string.Empty);
			if (tableItem != null)
			{
				teamDuplicationFightPointEnergyAccumulationDataModel.FightPointEnergyAccumulation5 = tableItem.Value;
			}
			TeamCopyValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(100, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				teamDuplicationFightPointEnergyAccumulationDataModel.FightPointEnergyAccumulation30 = tableItem2.Value;
			}
			TeamCopyValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(101, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				teamDuplicationFightPointEnergyAccumulationDataModel.FightPointEnergyAccumulation50 = tableItem3.Value;
			}
			TeamCopyValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(102, string.Empty, string.Empty);
			if (tableItem4 != null)
			{
				teamDuplicationFightPointEnergyAccumulationDataModel.FightPointEnergyAccumulation80 = tableItem4.Value;
			}
			TeamCopyValueTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(103, string.Empty, string.Empty);
			if (tableItem5 != null)
			{
				teamDuplicationFightPointEnergyAccumulationDataModel.FightPointEnergyAccumulation100 = tableItem5.Value;
			}
			return teamDuplicationFightPointEnergyAccumulationDataModel;
		}

		// Token: 0x0600BF09 RID: 48905 RVA: 0x002CEE7C File Offset: 0x002CD27C
		public static void UpdateFightStageRewardDataModel(TeamCopyFlop teamCopyFlop, TeamDuplicationFightStageRewardDataModel fightStageRewardDataModel)
		{
			if (teamCopyFlop == null || fightStageRewardDataModel == null)
			{
				return;
			}
			fightStageRewardDataModel.PlayerGuid = teamCopyFlop.playerId;
			fightStageRewardDataModel.PlayerName = teamCopyFlop.playerName;
			fightStageRewardDataModel.RewardId = (int)teamCopyFlop.rewardId;
			fightStageRewardDataModel.RewardNum = (int)teamCopyFlop.rewardNum;
			fightStageRewardDataModel.RewardIndex = (int)teamCopyFlop.number;
			fightStageRewardDataModel.IsGoldReward = (teamCopyFlop.goldFlop == 1U);
			fightStageRewardDataModel.IsLimit = (TeamCopyFlopLimit)teamCopyFlop.isLimit;
		}

		// Token: 0x0600BF0A RID: 48906 RVA: 0x002CEEF0 File Offset: 0x002CD2F0
		public static string GetStageLimitDescriptionByLimitType(TeamCopyFlopLimit flopLimit)
		{
			string result = string.Empty;
			if (flopLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_WEEK)
			{
				result = TR.Value("team_duplication_fight_stage_reward_week_zero");
			}
			else if (flopLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_DAY)
			{
				result = TR.Value("team_duplication_fight_stage_reward_day_zero");
			}
			else if (flopLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_PASS_GATE)
			{
				result = TR.Value("team_duplication_fight_stage_reward_without_pass");
			}
			return result;
		}

		// Token: 0x0600BF0B RID: 48907 RVA: 0x002CEF44 File Offset: 0x002CD344
		public static void OnSendTeamRecru()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				Logger.LogErrorFormat("TeamDataModel is null", new object[0]);
				return;
			}
			string content = TR.Value("team_duplication_quick_chat_challenge_type_content");
			if (teamDuplicationTeamDataModel.TeamModel == 2)
			{
				content = TR.Value("team_duplication_quick_chat_gold_type_content");
			}
			DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_TEAM_COPY_PREPARE, content, 0UL, 0);
		}

		// Token: 0x0600BF0C RID: 48908 RVA: 0x002CEFA8 File Offset: 0x002CD3A8
		public static TeamDuplicationChatBubbleViewControl LoadTeamDuplicationChatBubbleViewControl(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			TeamDuplicationChatBubbleViewControl result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<TeamDuplicationChatBubbleViewControl>();
				}
			}
			return result;
		}

		// Token: 0x0600BF0D RID: 48909 RVA: 0x002CF008 File Offset: 0x002CD408
		public static bool IsPlayerCanFreeQuitTeam()
		{
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			return playerInformationDataModel != null && playerInformationDataModel.DayFreeQuitNumber > 0;
		}

		// Token: 0x0600BF0E RID: 48910 RVA: 0x002CF038 File Offset: 0x002CD438
		public static string GetJobName(int jobId, int awakeState = 0)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.Name;
		}

		// Token: 0x0600BF0F RID: 48911 RVA: 0x002CF070 File Offset: 0x002CD470
		public static void OnQuitTeamAndReturnToTown(string tipContent, Action onQuitAndReturn)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onQuitAndReturn
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BF10 RID: 48912 RVA: 0x002CF0C0 File Offset: 0x002CD4C0
		public static void SortTeamDuplicationRequesterDataModelList(List<TeamDuplicationRequesterDataModel> requesterDataModelList)
		{
			if (requesterDataModelList == null || requesterDataModelList.Count <= 0)
			{
				return;
			}
			requesterDataModelList.Sort(delegate(TeamDuplicationRequesterDataModel x, TeamDuplicationRequesterDataModel y)
			{
				int num = -x.IsGold.CompareTo(y.IsGold);
				if (num == 0)
				{
					num = -x.IsFriend.CompareTo(y.IsFriend);
				}
				if (num == 0)
				{
					num = -x.IsGuild.CompareTo(y.IsGuild);
				}
				return num;
			});
		}

		// Token: 0x0600BF11 RID: 48913 RVA: 0x002CF0F8 File Offset: 0x002CD4F8
		public static bool IsShowTeamDuplicationWithNormalLevel()
		{
			return Utility.IsUnLockFunc(91) && DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_TEAM_COPY);
		}

		// Token: 0x0600BF12 RID: 48914 RVA: 0x002CF11F File Offset: 0x002CD51F
		public static bool IsShowTeamDuplicationWith65Level()
		{
			return Utility.IsUnLockFunc(102) && DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_TEAM_COPY_TWO);
		}

		// Token: 0x0600BF13 RID: 48915 RVA: 0x002CF146 File Offset: 0x002CD546
		public static bool IsTeamDuplicationServerSwitchOpen()
		{
			return DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_TEAM_COPY);
		}

		// Token: 0x0600BF14 RID: 48916 RVA: 0x002CF160 File Offset: 0x002CD560
		public static void OnShowCommonMsgBoxFrame(string contentStr, Action onOkAction, TextAnchor contentTextAnchor = 4)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				ContentTextAnchor = contentTextAnchor,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure_2"),
				OnRightButtonClickCallBack = onOkAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BF15 RID: 48917 RVA: 0x002CF1B7 File Offset: 0x002CD5B7
		public static bool IsTeamDuplicationOwnerTeam()
		{
			return TeamDuplicationUtility.IsInTeamDuplicationScene() && DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam;
		}

		// Token: 0x0600BF16 RID: 48918 RVA: 0x002CF1D0 File Offset: 0x002CD5D0
		public static bool IsInTeamDuplicationScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			int currentSceneID = clientSystemTown.CurrentSceneID;
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(currentSceneID, string.Empty, string.Empty);
			return tableItem != null && (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight);
		}

		// Token: 0x0600BF17 RID: 48919 RVA: 0x002CF238 File Offset: 0x002CD638
		public static void AcceptJoinTeamDuplicationLink(string param)
		{
			string[] array = param.Split(new char[]
			{
				'|'
			});
			if (array.Length != 2)
			{
				return;
			}
			int num = 0;
			if (!int.TryParse(array[0], out num))
			{
				return;
			}
			if (num <= 0)
			{
				return;
			}
			if (!TeamDuplicationUtility.IsInTeamDuplicationScene())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_switch_to_team_duplication"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_cannot_join_in_for_owner_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyLinkJoinReq(num);
		}

		// Token: 0x0600BF18 RID: 48920 RVA: 0x002CF2C4 File Offset: 0x002CD6C4
		public static void OnShowLeaveTeamTipFrame(string contentStr, Action onOkAction)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure_2"),
				OnRightButtonClickCallBack = onOkAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600BF19 RID: 48921 RVA: 0x002CF314 File Offset: 0x002CD714
		public static ulong GetPlayerExpireTime(ulong playerGuid)
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerExpireTimeDic == null || DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerExpireTimeDic.Count <= 0)
			{
				return 0UL;
			}
			ulong result = 0UL;
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerExpireTimeDic.ContainsKey(playerGuid))
			{
				result = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerExpireTimeDic[playerGuid];
			}
			return result;
		}

		// Token: 0x0600BF1A RID: 48922 RVA: 0x002CF374 File Offset: 0x002CD774
		public static bool IsPlayerTicketIsEnough()
		{
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			return playerInformationDataModel != null && playerInformationDataModel.TicketIsEnough;
		}

		// Token: 0x0600BF1B RID: 48923 RVA: 0x002CF39C File Offset: 0x002CD79C
		public static bool IsPlayerCanDoTeamDuplication()
		{
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			return playerInformationDataModel != null && playerInformationDataModel.DayAlreadyFightNumber < playerInformationDataModel.DayTotalFightNumber && playerInformationDataModel.WeekAlreadyFightNumber < playerInformationDataModel.WeekTotalFightNumber;
		}

		// Token: 0x0600BF1C RID: 48924 RVA: 0x002CF3E4 File Offset: 0x002CD7E4
		public static bool IsTwoGridPositionAdjacent(TilePos firstPosition, TilePos secondPosition)
		{
			if (firstPosition.X == secondPosition.X)
			{
				return Mathf.Abs(firstPosition.Y - secondPosition.Y) <= 1;
			}
			if (firstPosition.Y == secondPosition.Y)
			{
				return Mathf.Abs(firstPosition.X - secondPosition.X) <= 1;
			}
			return (firstPosition.X - secondPosition.X == 1 && firstPosition.Y - secondPosition.Y == -1) || (firstPosition.X - secondPosition.X == -1 && firstPosition.Y - secondPosition.Y == 1);
		}

		// Token: 0x0600BF1D RID: 48925 RVA: 0x002CF4AC File Offset: 0x002CD8AC
		public static List<TilePos> GetAdjacentTilePosList(TilePos tilePos)
		{
			return new List<TilePos>
			{
				new TilePos(tilePos.X, tilePos.Y + 1),
				new TilePos(tilePos.X, tilePos.Y - 1),
				new TilePos(tilePos.X - 1, tilePos.Y),
				new TilePos(tilePos.X + 1, tilePos.Y),
				new TilePos(tilePos.X - 1, tilePos.Y + 1),
				new TilePos(tilePos.X + 1, tilePos.Y - 1)
			};
		}

		// Token: 0x0600BF1E RID: 48926 RVA: 0x002CF566 File Offset: 0x002CD966
		public static int GetAdjacentGridNumber()
		{
			return 6;
		}

		// Token: 0x0600BF1F RID: 48927 RVA: 0x002CF56C File Offset: 0x002CD96C
		public static TeamDuplicationGridPropertyDataModel CreateGridPropertyDataModel(TCGridProperty gridProperty)
		{
			if (gridProperty == null)
			{
				return null;
			}
			return new TeamDuplicationGridPropertyDataModel
			{
				PropertyType = gridProperty.proType,
				PropertyValue = gridProperty.proValue
			};
		}

		// Token: 0x0600BF20 RID: 48928 RVA: 0x002CF5A0 File Offset: 0x002CD9A0
		public static TeamDuplicationGridObjectDataModel CreateGridObjectDataModel(TCGridObjData gridObjData)
		{
			if (gridObjData == null)
			{
				return null;
			}
			TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = new TeamDuplicationGridObjectDataModel();
			TeamDuplicationUtility.UpdateGridObjectDataModel(teamDuplicationGridObjectDataModel, gridObjData);
			return teamDuplicationGridObjectDataModel;
		}

		// Token: 0x0600BF21 RID: 48929 RVA: 0x002CF5C4 File Offset: 0x002CD9C4
		public static void UpdateGridObjectDataModel(TeamDuplicationGridObjectDataModel gridObjectDataModel, TCGridObjData gridObjData)
		{
			if (gridObjectDataModel == null || gridObjData == null)
			{
				return;
			}
			gridObjectDataModel.GridObjectId = gridObjData.gridObjId;
			gridObjectDataModel.GridId = gridObjData.gridId;
			gridObjectDataModel.GridType = gridObjData.gridType;
			gridObjectDataModel.GridStatus = gridObjData.gridStatus;
			if (gridObjectDataModel.GridPropertyDataModelList == null)
			{
				gridObjectDataModel.GridPropertyDataModelList = new List<TeamDuplicationGridPropertyDataModel>();
			}
			gridObjectDataModel.GridPropertyDataModelList.Clear();
			TCGridProperty[] gridPro = gridObjData.gridPro;
			if (gridPro != null && gridPro.Length > 0)
			{
				foreach (TCGridProperty tcgridProperty in gridPro)
				{
					if (tcgridProperty != null)
					{
						TeamDuplicationGridPropertyDataModel teamDuplicationGridPropertyDataModel = TeamDuplicationUtility.CreateGridPropertyDataModel(tcgridProperty);
						if (teamDuplicationGridPropertyDataModel != null)
						{
							gridObjectDataModel.GridPropertyDataModelList.Add(teamDuplicationGridPropertyDataModel);
						}
					}
				}
			}
		}

		// Token: 0x0600BF22 RID: 48930 RVA: 0x002CF688 File Offset: 0x002CDA88
		public static void UpdateOwnerGridCaptainDataModel(TeamDuplicationGridOwnerCaptainDataModel ownerGridCaptainDataModel, TeamCopyGridSquadNotify gridSquadNotify)
		{
			if (ownerGridCaptainDataModel == null || gridSquadNotify == null)
			{
				return;
			}
			ownerGridCaptainDataModel.CaptainId = gridSquadNotify.squadId;
			ownerGridCaptainDataModel.CaptainStatus = gridSquadNotify.squadStatus;
			ownerGridCaptainDataModel.TargetGridId = gridSquadNotify.targetGridId;
			ownerGridCaptainDataModel.TargetMonsterId = gridSquadNotify.targetObjId;
			if (gridSquadNotify.squadData != null)
			{
				ownerGridCaptainDataModel.GridId = gridSquadNotify.squadData.gridId;
				uint num = 0U;
				uint num2 = 0U;
				TCGridProperty[] gridPro = gridSquadNotify.squadData.gridPro;
				if (gridPro != null && gridPro.Length > 0)
				{
					foreach (TCGridProperty tcgridProperty in gridPro)
					{
						if (tcgridProperty != null)
						{
							TCGridPropretyType proType = (TCGridPropretyType)tcgridProperty.proType;
							if (proType == TCGridPropretyType.TC_GRID_PRO_CD_DOWN_TIME)
							{
								num = tcgridProperty.proValue;
							}
							else if (proType == TCGridPropretyType.TC_GRID_PRO_CD_END_STAMP)
							{
								num2 = tcgridProperty.proValue;
							}
						}
					}
				}
				ownerGridCaptainDataModel.CaptainCdEndTimeStamp = num2;
				ownerGridCaptainDataModel.CaptainCdStartTimeStamp = num2 - num;
				ownerGridCaptainDataModel.CaptainCdTotalTimeInterval = num;
			}
			ownerGridCaptainDataModel.CaptainPathList.Clear();
			uint[] pathList = gridSquadNotify.pathList;
			ownerGridCaptainDataModel.CaptainPathList.AddRange(pathList);
		}

		// Token: 0x0600BF23 RID: 48931 RVA: 0x002CF798 File Offset: 0x002CDB98
		public static TeamDuplicationGridOwnerCaptainPosition CreateGridOwnerCaptainPosition(TeamDuplicationGridOwnerCaptainDataModel gridOwnerCaptainDataModel, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridOwnerCaptainDataModel == null)
			{
				return null;
			}
			if (gridItemDictionary == null)
			{
				return null;
			}
			TeamDuplicationGridOwnerCaptainPosition teamDuplicationGridOwnerCaptainPosition = new TeamDuplicationGridOwnerCaptainPosition();
			uint gridId = gridOwnerCaptainDataModel.GridId;
			if (gridItemDictionary.ContainsKey(gridId))
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = gridItemDictionary[gridId];
				if (teamDuplicationGridMapGridItem != null)
				{
					teamDuplicationGridOwnerCaptainPosition.StartPointPosition = teamDuplicationGridMapGridItem.GetGridPointPosition();
				}
			}
			TCGridSquadStatus captainStatus = (TCGridSquadStatus)gridOwnerCaptainDataModel.CaptainStatus;
			if (captainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_MOVE)
			{
				List<uint> captainPathList = gridOwnerCaptainDataModel.CaptainPathList;
				if (captainPathList != null && captainPathList.Count > 0)
				{
					for (int i = 0; i < captainPathList.Count; i++)
					{
						uint key = captainPathList[i];
						uint key2;
						if (i == 0)
						{
							key2 = gridId;
						}
						else
						{
							key2 = captainPathList[i - 1];
						}
						TeamDuplicationGridPathPosition teamDuplicationGridPathPosition = new TeamDuplicationGridPathPosition();
						if (gridItemDictionary.ContainsKey(key2))
						{
							TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem2 = gridItemDictionary[key2];
							if (teamDuplicationGridMapGridItem2 != null)
							{
								teamDuplicationGridPathPosition.StartPointPosition = teamDuplicationGridMapGridItem2.GetGridPointPosition();
								teamDuplicationGridPathPosition.StartTilePos = teamDuplicationGridMapGridItem2.GetTileInsTilePos();
							}
						}
						if (gridItemDictionary.ContainsKey(key))
						{
							TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem3 = gridItemDictionary[key];
							if (teamDuplicationGridMapGridItem3 != null)
							{
								teamDuplicationGridPathPosition.EndPointPosition = teamDuplicationGridMapGridItem3.GetGridPointPosition();
								teamDuplicationGridPathPosition.EndTilePos = teamDuplicationGridMapGridItem3.GetTileInsTilePos();
								if (i == captainPathList.Count - 1)
								{
									teamDuplicationGridOwnerCaptainPosition.EndPointPosition = teamDuplicationGridMapGridItem3.GetGridPointPosition();
								}
							}
						}
						teamDuplicationGridOwnerCaptainPosition.GridPathPositionList.Add(teamDuplicationGridPathPosition);
					}
				}
			}
			return teamDuplicationGridOwnerCaptainPosition;
		}

		// Token: 0x0600BF24 RID: 48932 RVA: 0x002CF910 File Offset: 0x002CDD10
		public static void UpdateOtherGridCaptainDataModel(TeamDuplicationGridOtherCaptainDataModel otherGridCaptainDataModel, TeamCopyOtherSquadData otherSquadData)
		{
			if (otherGridCaptainDataModel == null || otherSquadData == null)
			{
				return;
			}
			otherGridCaptainDataModel.CaptainId = otherSquadData.squadId;
			otherGridCaptainDataModel.CaptainStatus = otherSquadData.squadStatus;
			otherGridCaptainDataModel.GridId = otherSquadData.squadGridId;
			otherGridCaptainDataModel.TargetGridId = otherSquadData.squadTargetId;
			otherGridCaptainDataModel.PlayerNumber = otherSquadData.squadMemberNum;
			if (otherGridCaptainDataModel.PlayerNumber > 0U)
			{
				otherGridCaptainDataModel.IsExist = true;
			}
			else
			{
				otherGridCaptainDataModel.IsExist = false;
			}
		}

		// Token: 0x0600BF25 RID: 48933 RVA: 0x002CF988 File Offset: 0x002CDD88
		public static TeamDuplicationGridPathPosition CreateGridOtherCaptainPosition(TeamDuplicationGridOtherCaptainDataModel gridOtherCaptainDataModel, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridOtherCaptainDataModel == null)
			{
				return null;
			}
			if (gridItemDictionary == null)
			{
				return null;
			}
			TeamDuplicationGridPathPosition teamDuplicationGridPathPosition = new TeamDuplicationGridPathPosition();
			uint gridId = gridOtherCaptainDataModel.GridId;
			if (gridItemDictionary.ContainsKey(gridId))
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = gridItemDictionary[gridId];
				if (teamDuplicationGridMapGridItem != null)
				{
					teamDuplicationGridPathPosition.StartPointPosition = teamDuplicationGridMapGridItem.GetGridPointPosition();
				}
			}
			uint targetGridId = gridOtherCaptainDataModel.TargetGridId;
			if (gridItemDictionary.ContainsKey(targetGridId))
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem2 = gridItemDictionary[targetGridId];
				if (teamDuplicationGridMapGridItem2 != null)
				{
					teamDuplicationGridPathPosition.EndPointPosition = teamDuplicationGridMapGridItem2.GetGridPointPosition();
				}
			}
			return teamDuplicationGridPathPosition;
		}

		// Token: 0x0600BF26 RID: 48934 RVA: 0x002CFA18 File Offset: 0x002CDE18
		public static Dictionary<uint, Vector3> CreateGridMonsterPositionDictionary(List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return null;
			}
			if (gridItemDictionary == null || gridItemDictionary.Count <= 0)
			{
				return null;
			}
			Dictionary<uint, Vector3> dictionary = new Dictionary<uint, Vector3>();
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					uint gridObjectId = teamDuplicationGridObjectDataModel.GridObjectId;
					uint gridId = teamDuplicationGridObjectDataModel.GridId;
					if (gridItemDictionary.ContainsKey(gridId))
					{
						TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = gridItemDictionary[gridId];
						if (teamDuplicationGridMapGridItem != null)
						{
							Vector3 gridPointPosition = teamDuplicationGridMapGridItem.GetGridPointPosition();
							dictionary[gridObjectId] = gridPointPosition;
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600BF27 RID: 48935 RVA: 0x002CFAC4 File Offset: 0x002CDEC4
		public static Dictionary<uint, TeamDuplicationGridMapGridItem> CreateGridItemDictionary(List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return null;
			}
			if (gridItemDictionary == null || gridItemDictionary.Count <= 0)
			{
				return null;
			}
			Dictionary<uint, TeamDuplicationGridMapGridItem> dictionary = new Dictionary<uint, TeamDuplicationGridMapGridItem>();
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					uint gridObjectId = teamDuplicationGridObjectDataModel.GridObjectId;
					uint gridId = teamDuplicationGridObjectDataModel.GridId;
					if (gridItemDictionary.ContainsKey(gridId))
					{
						TeamDuplicationGridMapGridItem value = gridItemDictionary[gridId];
						dictionary[gridObjectId] = value;
					}
					else
					{
						dictionary[gridObjectId] = null;
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600BF28 RID: 48936 RVA: 0x002CFB68 File Offset: 0x002CDF68
		public static Dictionary<uint, TeamDuplicationGridMapGridItem> CreateNextGridItemDictionary(List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return null;
			}
			if (gridItemDictionary == null || gridItemDictionary.Count <= 0)
			{
				return null;
			}
			Dictionary<uint, TeamDuplicationGridMapGridItem> dictionary = new Dictionary<uint, TeamDuplicationGridMapGridItem>();
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					uint gridObjectId = teamDuplicationGridObjectDataModel.GridObjectId;
					uint gridId = teamDuplicationGridObjectDataModel.GridId;
					uint monsterNextGridId = TeamDuplicationUtility.GetMonsterNextGridId(gridObjectId, gridId);
					uint gridObjectId2 = teamDuplicationGridObjectDataModel.GridObjectId;
					if (gridItemDictionary.ContainsKey(monsterNextGridId))
					{
						TeamDuplicationGridMapGridItem value = gridItemDictionary[monsterNextGridId];
						dictionary[gridObjectId2] = value;
					}
					else
					{
						dictionary[gridObjectId2] = null;
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600BF29 RID: 48937 RVA: 0x002CFC20 File Offset: 0x002CE020
		public static TeamDuplicationGridPathPosition CreateGridBattlePosition(TeamDuplicationGridBattleDataModel gridBattleDataModel, Dictionary<uint, TeamDuplicationGridMapGridItem> gridItemDictionary)
		{
			if (gridBattleDataModel == null)
			{
				return null;
			}
			if (gridItemDictionary == null)
			{
				return null;
			}
			TeamDuplicationGridPathPosition teamDuplicationGridPathPosition = new TeamDuplicationGridPathPosition();
			uint captainGridId = gridBattleDataModel.CaptainGridId;
			if (gridItemDictionary.ContainsKey(captainGridId))
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = gridItemDictionary[captainGridId];
				if (teamDuplicationGridMapGridItem != null)
				{
					teamDuplicationGridPathPosition.StartPointPosition = teamDuplicationGridMapGridItem.GetGridPointPosition();
				}
			}
			uint fieldGridId = gridBattleDataModel.FieldGridId;
			if (gridItemDictionary.ContainsKey(fieldGridId))
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem2 = gridItemDictionary[fieldGridId];
				if (teamDuplicationGridMapGridItem2 != null)
				{
					teamDuplicationGridPathPosition.EndPointPosition = teamDuplicationGridMapGridItem2.GetGridPointPosition();
				}
			}
			return teamDuplicationGridPathPosition;
		}

		// Token: 0x0600BF2A RID: 48938 RVA: 0x002CFCB0 File Offset: 0x002CE0B0
		public static float GetZAxisRotationNumber(TilePos startTilePos, TilePos endTilePos)
		{
			if (endTilePos.Y == startTilePos.Y)
			{
				if (endTilePos.X > startTilePos.X)
				{
					return 0f;
				}
				if (endTilePos.X < startTilePos.X)
				{
					return 180f;
				}
			}
			if (endTilePos.X == startTilePos.X)
			{
				if (endTilePos.Y > startTilePos.Y)
				{
					return 45f;
				}
				if (endTilePos.Y < startTilePos.Y)
				{
					return 225f;
				}
			}
			if (endTilePos.X > startTilePos.X && endTilePos.Y < startTilePos.Y)
			{
				return 315f;
			}
			if (endTilePos.X < startTilePos.X && endTilePos.Y > startTilePos.Y)
			{
				return 135f;
			}
			return 0f;
		}

		// Token: 0x0600BF2B RID: 48939 RVA: 0x002CFDA4 File Offset: 0x002CE1A4
		public static void UpdateGridBattleDataModel(TeamDuplicationGridBattleDataModel gridBattleDataModel, TeamCopyGridSquadBattleNotify gridSquadBattleNotify)
		{
			if (gridBattleDataModel == null || gridSquadBattleNotify == null)
			{
				return;
			}
			gridBattleDataModel.CaptainId = gridSquadBattleNotify.squadId;
			gridBattleDataModel.CaptainGridId = gridSquadBattleNotify.squadGridId;
			gridBattleDataModel.FieldGridId = gridSquadBattleNotify.fieldGridId;
			gridBattleDataModel.IsInBattle = (gridSquadBattleNotify.isBattle != 0U);
		}

		// Token: 0x0600BF2C RID: 48940 RVA: 0x002CFDF4 File Offset: 0x002CE1F4
		public static bool IsExistGridInReviveStatus(uint currentGridId)
		{
			Dictionary<uint, TeamDuplicationGridObjectDataModel> gridFieldDataModelDictionary = DataManager<TeamDuplicationDataManager>.GetInstance().GridFieldDataModelDictionary;
			if (gridFieldDataModelDictionary == null || gridFieldDataModelDictionary.Count <= 0)
			{
				return false;
			}
			foreach (KeyValuePair<uint, TeamDuplicationGridObjectDataModel> keyValuePair in gridFieldDataModelDictionary)
			{
				uint key = keyValuePair.Key;
				if (key != currentGridId)
				{
					Dictionary<uint, TeamDuplicationGridObjectDataModel>.Enumerator enumerator;
					KeyValuePair<uint, TeamDuplicationGridObjectDataModel> keyValuePair2 = enumerator.Current;
					TeamDuplicationGridObjectDataModel value = keyValuePair2.Value;
					if (value != null)
					{
						TCGridObjType gridType = (TCGridObjType)value.GridType;
						if (gridType == TCGridObjType.TC_GRID_OBJ_MAKE_MONSTER)
						{
							TCGridFieldStatus gridStatus = (TCGridFieldStatus)value.GridStatus;
							if (gridStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_REVIVE)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BF2D RID: 48941 RVA: 0x002CFEA4 File Offset: 0x002CE2A4
		public static void ShowGridDestroyTipFrame(uint gridId, TCGridObjType gridObjType, TCGridFieldStatus gridFieldStatus = TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS, bool isBattleDead = true, bool isExistReviveGrid = false)
		{
			TileInsData gridInsDataByGridId = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridInsDataByGridId((int)gridId);
			if (gridInsDataByGridId == null)
			{
				return;
			}
			int tableID = gridInsDataByGridId.TableID;
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string name = tableItem.Name;
			if (gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS)
			{
				if (gridObjType == TCGridObjType.TC_GRID_OBJ_REVIVE_CNT)
				{
					int resID = gridInsDataByGridId.ResID;
					int supplyReliveTimes = TeamDuplicationUtility.GetSupplyReliveTimes(resID);
					string tipStr = TR.Value("Team_Duplication_Grid_Item_Destroy_Supply", name, supplyReliveTimes);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr);
				}
				else if (gridObjType == TCGridObjType.TC_GRID_OBJ_CD_DOWN)
				{
					int resID2 = gridInsDataByGridId.ResID;
					string arg = TR.Value("Team_Duplication_Monster_Common_Name_Label");
					string tipStr2 = TR.Value("Team_Duplication_Grid_Item_Destroy_Machine", name, arg);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr2);
				}
				return;
			}
			if (gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD)
			{
				if (gridObjType == TCGridObjType.TC_GRID_OBJ_ALTAR)
				{
					if (isBattleDead)
					{
						string tipStr3 = TR.Value("Team_Duplication_Grid_Item_Destroy_Soul", name);
						TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr3);
					}
				}
				else if (gridObjType == TCGridObjType.TC_GRID_OBJ_TERROR_ALTAR)
				{
					if (isBattleDead)
					{
						string tipStr4 = TR.Value("Team_Duplication_Grid_Item_Destroy_Terror_Soul", name);
						TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr4);
					}
				}
				else if (gridObjType == TCGridObjType.TC_GRID_OBJ_FIX_POINT)
				{
					string tipStr5 = TR.Value("Team_Duplication_Grid_Item_Destroy_Pre_Station", name);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr5);
				}
				else if (gridObjType == TCGridObjType.TC_GRID_OBJ_ENERGY_POINT)
				{
					string tipStr6 = TR.Value("Team_Duplication_Grid_Item_Destroy_Energy_Station", name);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr6);
				}
				return;
			}
			if (gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_REVIVE)
			{
				if (gridObjType == TCGridObjType.TC_GRID_OBJ_MAKE_MONSTER)
				{
					int resID3 = gridInsDataByGridId.ResID;
					int num = 0;
					int labReAliveTimeOfMinute = TeamDuplicationUtility.GetLabReAliveTimeOfMinute(resID3, ref num);
					string tipStr7 = string.Empty;
					if (!isExistReviveGrid)
					{
						tipStr7 = TR.Value("Team_Duplication_Grid_Item_Destroy_Lab_With_First_Destroy", name, labReAliveTimeOfMinute);
					}
					else
					{
						tipStr7 = TR.Value("Team_Duplication_Grid_Item_Destroy_Lab_With_Second_Destroy", name, num);
					}
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr7);
				}
				return;
			}
		}

		// Token: 0x0600BF2E RID: 48942 RVA: 0x002D005C File Offset: 0x002CE45C
		public static void ShowGridMainCityTipFrame(uint gridId, uint curBloodNumber)
		{
			TileInsData gridInsDataByGridId = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridInsDataByGridId((int)gridId);
			if (gridInsDataByGridId == null)
			{
				return;
			}
			int tableID = gridInsDataByGridId.TableID;
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string name = tableItem.Name;
			if (curBloodNumber == 0U)
			{
				string tipStr = TR.Value("Team_Duplication_Grid_Item_Destroy_Main_City", name);
				TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr);
			}
			else
			{
				int resID = gridInsDataByGridId.ResID;
				int mainCityTotalBloodNumber = TeamDuplicationUtility.GetMainCityTotalBloodNumber(resID);
				if (curBloodNumber == 1U)
				{
					string tipStr2 = TR.Value("Team_Duplication_Grid_Item_Main_City_Left_One_Blood", name, curBloodNumber, mainCityTotalBloodNumber, name);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr2);
				}
				else if (curBloodNumber == 2U || curBloodNumber == 3U)
				{
					string tipStr3 = TR.Value("Team_Duplication_Grid_Item_Main_City_Left_Two_Or_Three_Blood", name, curBloodNumber, mainCityTotalBloodNumber, name);
					TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr3);
				}
			}
		}

		// Token: 0x0600BF2F RID: 48943 RVA: 0x002D0138 File Offset: 0x002CE538
		public static void ShowGridMonsterDestroyTipFrame(TeamDuplicationGridObjectDataModel gridObjectDataModel)
		{
			if (gridObjectDataModel == null)
			{
				return;
			}
			uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(gridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_MONSTER_PRO_ID);
			TeamCopyGridMonsterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridMonsterTable>((int)gridPropertyValue, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string monsterName = tableItem.MonsterName;
			string tipStr = TR.Value("Team_Duplication_Grid_Map_Monster_Destroy", monsterName);
			TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr);
		}

		// Token: 0x0600BF30 RID: 48944 RVA: 0x002D018C File Offset: 0x002CE58C
		public static void ShowGridMonsterNearByMainCityTipFrame(int gridMonsterTableId)
		{
			TeamCopyGridMonsterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridMonsterTable>(gridMonsterTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string monsterName = tableItem.MonsterName;
			string tipStr = TR.Value("Team_Duplication_Grid_Map_Monster_NearBy_Main_City", monsterName);
			TeamDuplicationUtility.ShowTeamDuplicationRelationTipFrame(tipStr);
		}

		// Token: 0x0600BF31 RID: 48945 RVA: 0x002D01D0 File Offset: 0x002CE5D0
		public static List<uint> GetGridMonsterPathList(uint monsterObjId)
		{
			Dictionary<uint, List<uint>> gridMonsterPathDictionary = DataManager<TeamDuplicationDataManager>.GetInstance().GridMonsterPathDictionary;
			if (gridMonsterPathDictionary == null)
			{
				return null;
			}
			List<uint> result = null;
			if (gridMonsterPathDictionary.ContainsKey(monsterObjId))
			{
				result = gridMonsterPathDictionary[monsterObjId];
			}
			return result;
		}

		// Token: 0x0600BF32 RID: 48946 RVA: 0x002D0208 File Offset: 0x002CE608
		public static uint GetMonsterNextGridId(uint gridMonsterObjId, uint gridMonsterStandGridId)
		{
			List<uint> gridMonsterPathList = TeamDuplicationUtility.GetGridMonsterPathList(gridMonsterObjId);
			if (gridMonsterPathList == null || gridMonsterPathList.Count <= 0)
			{
				return 0U;
			}
			return gridMonsterPathList[0];
		}

		// Token: 0x0600BF33 RID: 48947 RVA: 0x002D0238 File Offset: 0x002CE638
		public static bool IsMonsterNearByMainCityWithTwoGrid(List<uint> pathList)
		{
			if (pathList == null)
			{
				return false;
			}
			int count = pathList.Count;
			return count == 2;
		}

		// Token: 0x0600BF34 RID: 48948 RVA: 0x002D0260 File Offset: 0x002CE660
		private static void ShowTeamDuplicationRelationTipFrame(string tipStr)
		{
			float gridItemTipTimeInterval = DataManager<TeamDuplicationDataManager>.GetInstance().GridItemTipTimeInterval;
			SystemNotifyManager.SysDungeonSkillTip(tipStr, gridItemTipTimeInterval, true);
		}

		// Token: 0x0600BF35 RID: 48949 RVA: 0x002D0284 File Offset: 0x002CE684
		public static bool IsIn65LevelTeamDuplication()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			int currentSceneID = clientSystemTown.CurrentSceneID;
			return currentSceneID == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildSceneIdWith65Level || currentSceneID == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level;
		}

		// Token: 0x0600BF36 RID: 48950 RVA: 0x002D02D4 File Offset: 0x002CE6D4
		public static bool IsInFightSceneOf65LevelTeamDuplication()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			int currentSceneID = clientSystemTown.CurrentSceneID;
			return currentSceneID == DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightSceneIdWith65Level;
		}

		// Token: 0x0600BF37 RID: 48951 RVA: 0x002D0313 File Offset: 0x002CE713
		public static int GetTotalPlayerNumberInTeamDuplication(TeamCopyType teamType)
		{
			if (teamType == TeamCopyType.TC_TYPE_ONE)
			{
				return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTotalPlayerNumberInTeam;
			}
			return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationTotalPlayerNumberInTeamWith65Level;
		}

		// Token: 0x0600BF38 RID: 48952 RVA: 0x002D0331 File Offset: 0x002CE731
		public static int GetCaptainNumberInTeamDuplication(TeamCopyType teamType)
		{
			if (teamType == TeamCopyType.TC_TYPE_ONE)
			{
				return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumber;
			}
			return DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumberWith65Level;
		}

		// Token: 0x0600BF39 RID: 48953 RVA: 0x002D0350 File Offset: 0x002CE750
		public static TeamCopyType GetTeamTypeByTeamDuplicationScene()
		{
			TeamCopyType result = TeamCopyType.TC_TYPE_ONE;
			bool flag = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
			if (flag)
			{
				result = TeamCopyType.TC_TYPE_TWO;
			}
			return result;
		}

		// Token: 0x0600BF3A RID: 48954 RVA: 0x002D0370 File Offset: 0x002CE770
		public static uint GetGridPropertyValue(TeamDuplicationGridObjectDataModel gridObjectDataModel, TCGridPropretyType propertyType)
		{
			if (gridObjectDataModel == null)
			{
				return 0U;
			}
			List<TeamDuplicationGridPropertyDataModel> gridPropertyDataModelList = gridObjectDataModel.GridPropertyDataModelList;
			if (gridPropertyDataModelList == null || gridPropertyDataModelList.Count <= 0)
			{
				return 0U;
			}
			uint result = 0U;
			for (int i = 0; i < gridPropertyDataModelList.Count; i++)
			{
				TeamDuplicationGridPropertyDataModel teamDuplicationGridPropertyDataModel = gridPropertyDataModelList[i];
				if (teamDuplicationGridPropertyDataModel != null)
				{
					if (propertyType == (TCGridPropretyType)teamDuplicationGridPropertyDataModel.PropertyType)
					{
						result = teamDuplicationGridPropertyDataModel.PropertyValue;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600BF3B RID: 48955 RVA: 0x002D03E8 File Offset: 0x002CE7E8
		public static bool IsGridItemBeStandByOtherCaptain(uint gridId)
		{
			TeamDuplicationGridOtherCaptainDataModel otherGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OtherGridCaptainDataModel;
			return otherGridCaptainDataModel != null && otherGridCaptainDataModel.IsExist && otherGridCaptainDataModel.GridId == gridId;
		}

		// Token: 0x0600BF3C RID: 48956 RVA: 0x002D0424 File Offset: 0x002CE824
		public static bool IsGridItemBeStandByOwnerCaptain(uint gridId)
		{
			TeamDuplicationGridOwnerCaptainDataModel ownerGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OwnerGridCaptainDataModel;
			return ownerGridCaptainDataModel != null && ownerGridCaptainDataModel.GridId == gridId;
		}

		// Token: 0x0600BF3D RID: 48957 RVA: 0x002D0454 File Offset: 0x002CE854
		public static bool IsGridItemBeStandByMonster(uint gridId, ref uint monsterId)
		{
			List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GridMonsterDataModelList;
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					if (teamDuplicationGridObjectDataModel.GridId == gridId)
					{
						monsterId = teamDuplicationGridObjectDataModel.GridObjectId;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600BF3E RID: 48958 RVA: 0x002D04C4 File Offset: 0x002CE8C4
		public static bool IsNearByGridCanStand(TeamDuplicationGridMapGridItem nearByGridItem, uint nearByGridId)
		{
			if (nearByGridItem == null)
			{
				return false;
			}
			if (!nearByGridItem.IsGridItemCanStand())
			{
				return false;
			}
			bool flag = TeamDuplicationUtility.IsGridItemBeStandByOwnerCaptain(nearByGridId);
			if (flag)
			{
				return false;
			}
			bool flag2 = TeamDuplicationUtility.IsGridItemBeStandByOtherCaptain(nearByGridId);
			if (flag2)
			{
				return false;
			}
			uint num = 0U;
			bool flag3 = TeamDuplicationUtility.IsGridItemBeStandByMonster(nearByGridId, ref num);
			return !flag3;
		}

		// Token: 0x0600BF3F RID: 48959 RVA: 0x002D0520 File Offset: 0x002CE920
		public static int GetTransportDoorFieldIdInGridParamTable(int resId)
		{
			TeamCopyGridParamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridParamTable>(resId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(tableItem.Param))
			{
				return 0;
			}
			return Convert.ToInt32(tableItem.Param);
		}

		// Token: 0x0600BF40 RID: 48960 RVA: 0x002D056C File Offset: 0x002CE96C
		public static int GetMachineReduceCdTime(int resId)
		{
			TeamCopyGridParamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridParamTable>(resId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(tableItem.Param))
			{
				return 0;
			}
			return Convert.ToInt32(tableItem.Param);
		}

		// Token: 0x0600BF41 RID: 48961 RVA: 0x002D05B8 File Offset: 0x002CE9B8
		public static int GetSupplyReliveTimes(int resId)
		{
			TeamCopyGridParamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridParamTable>(resId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(tableItem.Param))
			{
				return 0;
			}
			return Convert.ToInt32(tableItem.Param);
		}

		// Token: 0x0600BF42 RID: 48962 RVA: 0x002D0604 File Offset: 0x002CEA04
		public static int GetMainCityTotalBloodNumber(int resId)
		{
			TeamCopyGridParamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridParamTable>(resId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(tableItem.Param))
			{
				return 0;
			}
			return Convert.ToInt32(tableItem.Param);
		}

		// Token: 0x0600BF43 RID: 48963 RVA: 0x002D0650 File Offset: 0x002CEA50
		public static int GetLabReAliveTimeOfMinute(int resId, ref int addCdTimeOfMinute)
		{
			TeamCopyGridParamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyGridParamTable>(resId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(tableItem.Param))
			{
				return 0;
			}
			List<int> numberListBySplitString = CommonUtility.GetNumberListBySplitString(tableItem.Param);
			if (numberListBySplitString == null || numberListBySplitString.Count < 3)
			{
				return 0;
			}
			int num = numberListBySplitString[0];
			int num2 = numberListBySplitString[2];
			int result = num / 60;
			addCdTimeOfMinute = num2 / 60;
			return result;
		}

		// Token: 0x0600BF44 RID: 48964 RVA: 0x002D06CC File Offset: 0x002CEACC
		public static void OnOpenClientFrameStackCmd()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamType != TeamCopyType.TC_TYPE_TWO)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamStatus != TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_BATTLE)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().Push2FrameStack(new OpenClientFrameInTeamDuplicationSceneStackCmd(TeamCopyType.TC_TYPE_TWO));
		}

		// Token: 0x0600BF45 RID: 48965 RVA: 0x002D0718 File Offset: 0x002CEB18
		public static string GetTicketItemNameOfTeamDuplication(bool isTeamDuplicationOf65Level)
		{
			int id;
			if (isTeamDuplicationOf65Level)
			{
				id = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemIdWith65Level();
			}
			else
			{
				id = DataManager<TeamDuplicationDataManager>.GetInstance().GetCostItemIdWithNormalLevel();
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return CommonUtility.GetItemColorName(tableItem);
		}

		// Token: 0x04006BED RID: 27629
		[CompilerGenerated]
		private static Action <>f__mg$cache0;

		// Token: 0x04006BEE RID: 27630
		[CompilerGenerated]
		private static Action <>f__mg$cache1;
	}
}
