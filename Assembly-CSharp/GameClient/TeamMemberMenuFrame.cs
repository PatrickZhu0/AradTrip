using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C19 RID: 7193
	internal class TeamMemberMenuFrame : ClientFrame
	{
		// Token: 0x060119F5 RID: 72181 RVA: 0x00526007 File Offset: 0x00524407
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMemberMenu";
		}

		// Token: 0x060119F6 RID: 72182 RVA: 0x0052600E File Offset: 0x0052440E
		protected override void _OnOpenFrame()
		{
			this.uiData = (this.userData as TeamMenuData);
			this.InitInterface();
		}

		// Token: 0x060119F7 RID: 72183 RVA: 0x00526027 File Offset: 0x00524427
		protected override void _OnCloseFrame()
		{
			this.Clear();
		}

		// Token: 0x060119F8 RID: 72184 RVA: 0x0052602F File Offset: 0x0052442F
		private new void Clear()
		{
			this.isLeader = false;
		}

		// Token: 0x060119F9 RID: 72185 RVA: 0x00526038 File Offset: 0x00524438
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<TeamMemberMenuFrame>(this, false);
		}

		// Token: 0x060119FA RID: 72186 RVA: 0x00526048 File Offset: 0x00524448
		[UIEventHandle("back/funcs/PrivateTalk/Button")]
		private void OnPrivateTalk()
		{
			RelationData relationData = new RelationData();
			relationData.uid = this.uiData.memberID;
			relationData.name = this.uiData.name;
			relationData.occu = this.uiData.occu;
			relationData.level = this.uiData.level;
			DataManager<RelationDataManager>.GetInstance().OnPrivateChat(relationData);
			this.OnClose();
		}

		// Token: 0x060119FB RID: 72187 RVA: 0x005260B0 File Offset: 0x005244B0
		[UIEventHandle("back/funcs/WatchInfo/Button")]
		private void OnWatchInfo()
		{
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.roleId = this.uiData.memberID;
			worldQueryPlayerReq.name = string.Empty;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_WATCH_PLAYER_INTO;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
			this.OnClose();
		}

		// Token: 0x060119FC RID: 72188 RVA: 0x00526100 File Offset: 0x00524500
		[UIEventHandle("back/funcs/MakeFriend/Button")]
		private void OnMakeFriend()
		{
			if (this.uiData.memberID == 0UL)
			{
				return;
			}
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.uiData.memberID);
			if (relationByRoleID != null && relationByRoleID.type == 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("该玩家已经是你的好友了", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 3;
			sceneRequest.target = this.uiData.memberID;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			this.OnClose();
		}

		// Token: 0x060119FD RID: 72189 RVA: 0x0052619C File Offset: 0x0052459C
		[UIEventHandle("back/funcs/KickOutTeam/Button")]
		private void OnKickOutTeam()
		{
			if (!this.isLeader)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null && myTeam.leaderInfo.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				WorldKickOutRoomReq worldKickOutRoomReq = new WorldKickOutRoomReq();
				worldKickOutRoomReq.playerId = this.uiData.memberID;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldKickOutRoomReq>(ServerType.GATE_SERVER, worldKickOutRoomReq);
				this.OnClose();
				return;
			}
			DataManager<TeamDataManager>.GetInstance().KickTeamMember(this.uiData.memberID);
			this.OnClose();
		}

		// Token: 0x060119FE RID: 72190 RVA: 0x00526248 File Offset: 0x00524648
		[UIEventHandle("back/funcs/ChangeLeader/Button")]
		private void OnChangeLeader()
		{
			if (!this.isLeader)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null && myTeam.leaderInfo.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				WorldChangeRoomOwnerReq worldChangeRoomOwnerReq = new WorldChangeRoomOwnerReq();
				worldChangeRoomOwnerReq.playerId = this.uiData.memberID;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldChangeRoomOwnerReq>(ServerType.GATE_SERVER, worldChangeRoomOwnerReq);
				this.OnClose();
				return;
			}
			DataManager<TeamDataManager>.GetInstance().ChangeTeamLeader(this.uiData.memberID);
			this.OnClose();
		}

		// Token: 0x060119FF RID: 72191 RVA: 0x005262F4 File Offset: 0x005246F4
		[UIEventHandle("back/funcs/BtnReport/Button")]
		private void OnReport()
		{
			if (this.uiData.memberID == 0UL)
			{
				return;
			}
			InformantInfo informantInfo = new InformantInfo();
			informantInfo.roleId = this.uiData.memberID.ToString();
			informantInfo.roleName = this.uiData.name;
			informantInfo.roleLevel = this.uiData.level.ToString();
			informantInfo.jobId = this.uiData.occu.ToString();
			informantInfo.jobName = DataManager<BaseWebViewManager>.GetInstance().GetJobNameByJobId((int)this.uiData.occu);
			DataManager<BaseWebViewManager>.GetInstance().TryOpenReportFrame(informantInfo);
			this.frameMgr.CloseFrame<TeamMemberMenuFrame>(this, false);
		}

		// Token: 0x06011A00 RID: 72192 RVA: 0x005263B4 File Offset: 0x005247B4
		private void InitInterface()
		{
			this.isLeader = DataManager<TeamDataManager>.GetInstance().IsTeamLeader();
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null && myTeam.leaderInfo.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.isLeader = true;
			}
			if (!this.isLeader)
			{
				this.btKickOutTeam.gameObject.SetActive(false);
				this.btChangeLeader.gameObject.SetActive(false);
			}
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				this.btMakeFriend.CustomActive(false);
			}
			this.btReport.CustomActive(DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen());
			Transform parent = this.btReport.transform.parent;
			if (parent != null)
			{
				GameObject gameObject = parent.parent.gameObject;
				if (gameObject != null)
				{
					Utility.SetPopMenuPosition(gameObject, default(Vector2), default(Vector2));
				}
			}
		}

		// Token: 0x06011A01 RID: 72193 RVA: 0x005264AF File Offset: 0x005248AF
		private void SetupFramePosition(Vector3 pos)
		{
		}

		// Token: 0x0400B78F RID: 46991
		private TeamMenuData uiData = new TeamMenuData();

		// Token: 0x0400B790 RID: 46992
		private bool isLeader;

		// Token: 0x0400B791 RID: 46993
		[UIObject("back/funcs/KickOutTeam")]
		private GameObject btKickOutTeam;

		// Token: 0x0400B792 RID: 46994
		[UIObject("back/funcs/ChangeLeader")]
		private GameObject btChangeLeader;

		// Token: 0x0400B793 RID: 46995
		[UIObject("back/funcs/MakeFriend")]
		private GameObject btMakeFriend;

		// Token: 0x0400B794 RID: 46996
		[UIObject("back/funcs/BtnReport")]
		private GameObject btReport;
	}
}
