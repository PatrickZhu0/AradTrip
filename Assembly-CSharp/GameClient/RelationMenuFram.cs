using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F2 RID: 6642
	internal class RelationMenuFram : ComMenuFrame
	{
		// Token: 0x0601048F RID: 66703 RVA: 0x004901A8 File Offset: 0x0048E5A8
		protected override void _OnOpenFrame()
		{
			this._InitData();
			this._InitElement();
			base._OnOpenFrame();
		}

		// Token: 0x06010490 RID: 66704 RVA: 0x004901BC File Offset: 0x0048E5BC
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06010491 RID: 66705 RVA: 0x004901BE File Offset: 0x0048E5BE
		protected void _InitData()
		{
			this.m_data = (this.userData as RelationMenuData);
		}

		// Token: 0x06010492 RID: 66706 RVA: 0x004901D4 File Offset: 0x0048E5D4
		protected void _InitElement()
		{
			if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_COMMON)
			{
				this._InitCommonMenu(false);
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_DEL_PRIVATE_CHAT)
			{
				this._InitCommonMenu(true);
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT)
			{
				this._InitPrivateMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_RECOMEND)
			{
				this._InitRecomendMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_BLACK)
			{
				this._InitBlackMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_TEACHER)
			{
				this._InitTeacherMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_PUPIL_REAL)
			{
				this._InitPupilMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_PUPIL_APPLY)
			{
				this._InitPupilApplyMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_TEACHER_REAL)
			{
				this._InitMyTeacherMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_CLASSMATE)
			{
				this._InitClassmateMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_TEAMDUPLICATION)
			{
				this._InitTeamDuplicationMenu();
			}
		}

		// Token: 0x06010493 RID: 66707 RVA: 0x0049031C File Offset: 0x0048E71C
		protected void _InitCommonMenu(bool bDeletePrivate = false)
		{
			if (!bDeletePrivate)
			{
				this._AddElement("密聊", new UnityAction(this._OnChat));
			}
			else
			{
				this._AddElement("删除密聊", new UnityAction(this._OnDelPriChat2));
			}
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				if (this.m_data.m_data.type == 3)
				{
					this._AddElement("添加好友", new UnityAction(this._OnAddFriend));
				}
				else if (this.m_data.m_data.type == 1)
				{
					this._AddElement("删除好友", new UnityAction(this._OnDelFriend));
				}
				this._AddElement("加入黑名单", new UnityAction(this._OnAddBlack));
			}
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
			if (RelationMenuFram._CheckGetPupil(this.m_data.m_data))
			{
				this._AddElement("收为弟子", delegate
				{
					RelationMenuFram._OnAskForPupil(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
			if (RelationMenuFram._CheckGetTeacher(this.m_data.m_data))
			{
				this._AddElement("拜师", delegate
				{
					if (RelationMenuFram._OnAskForTeacher(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
			if (DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen())
			{
				this._AddElement("举报违规", new UnityAction(this._OnReport));
			}
		}

		// Token: 0x06010494 RID: 66708 RVA: 0x00490510 File Offset: 0x0048E910
		public static bool _CheckGetPupil(RelationData data)
		{
			return data != null && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.TAPSystem) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.TAPSystem, (int)data.level) && ((int)DataManager<PlayerBaseData>.GetInstance().Level <= DataManager<TAPDataManager>.GetInstance().apprentLevelMax || (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<TAPDataManager>.GetInstance().teacherMinLevel) && DataManager<PlayerBaseData>.GetInstance().Level > data.level && DataManager<TAPDataManager>.GetInstance().canGetpupil && !DataManager<TAPDataManager>.GetInstance().isPupilFull && data.type != 4 && data.type != 5 && DataManager<TAPDataManager>.GetInstance().CanApplyedPupil(data.uid);
		}

		// Token: 0x06010495 RID: 66709 RVA: 0x004905E8 File Offset: 0x0048E9E8
		public static bool _CheckGetTeacher(RelationData data)
		{
			return data != null && !DataManager<TAPDataManager>.GetInstance().hasTeacher && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.TAPSystem) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.TAPSystem, (int)data.level) && (int)DataManager<PlayerBaseData>.GetInstance().Level <= DataManager<TAPDataManager>.GetInstance().apprentLevelMax && DataManager<PlayerBaseData>.GetInstance().Level < data.level && (int)data.level >= DataManager<TAPDataManager>.GetInstance().teacherMinLevel && data.type != 4 && data.type != 5 && DataManager<TAPDataManager>.GetInstance().CanQuery(data.uid);
		}

		// Token: 0x06010496 RID: 66710 RVA: 0x004906AC File Offset: 0x0048EAAC
		protected void _InitPrivateMenu()
		{
			this._AddElement("删除密聊", new UnityAction(this._OnDelPriChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				if (this.m_data.m_data.type == 3)
				{
					this._AddElement("申请好友", new UnityAction(this._OnAddFriend));
				}
				else if (this.m_data.m_data.type == 1)
				{
					this._AddElement("删除好友", new UnityAction(this._OnDelFriend));
				}
				this._AddElement("加入黑名单", new UnityAction(this._OnAddBlack));
			}
			if (RelationMenuFram._CheckGetPupil(this.m_data.m_data))
			{
				this._AddElement("收为弟子", delegate
				{
					RelationMenuFram._OnAskForPupil(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
			if (RelationMenuFram._CheckGetTeacher(this.m_data.m_data))
			{
				this._AddElement("拜师", delegate
				{
					if (RelationMenuFram._OnAskForTeacher(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
		}

		// Token: 0x06010497 RID: 66711 RVA: 0x00490832 File Offset: 0x0048EC32
		protected void _InitRecomendMenu()
		{
		}

		// Token: 0x06010498 RID: 66712 RVA: 0x00490834 File Offset: 0x0048EC34
		protected void _InitTeamDuplicationMenu()
		{
			this._AddElement("查看信息", new UnityAction(this.OnCheckInfoInTeamDuplication));
		}

		// Token: 0x06010499 RID: 66713 RVA: 0x0049084D File Offset: 0x0048EC4D
		protected void _InitBlackMenu()
		{
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				this._AddElement("申请好友", new UnityAction(this._OnAddFriend));
			}
		}

		// Token: 0x0601049A RID: 66714 RVA: 0x0049088C File Offset: 0x0048EC8C
		protected void _InitTeacherMenu()
		{
			this._AddElement("密聊", new UnityAction(this._OnChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				this._AddElement("申请好友", new UnityAction(this._OnAddFriend));
			}
			if (RelationMenuFram._CheckGetTeacher(this.m_data.m_data))
			{
				this._AddElement("拜师", delegate
				{
					if (RelationMenuFram._OnAskForTeacher(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
		}

		// Token: 0x0601049B RID: 66715 RVA: 0x0049095C File Offset: 0x0048ED5C
		protected void _InitPupilMenu()
		{
			this._AddElement("密聊", new UnityAction(this._OnChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
		}

		// Token: 0x0601049C RID: 66716 RVA: 0x00490A30 File Offset: 0x0048EE30
		protected void _InitClassmateMenu()
		{
			this._AddElement("密聊", new UnityAction(this._OnChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
		}

		// Token: 0x0601049D RID: 66717 RVA: 0x00490AC0 File Offset: 0x0048EEC0
		protected void _InitPupilApplyMenu()
		{
			this._AddElement("密聊", new UnityAction(this._OnChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				this._AddElement("申请好友", new UnityAction(this._OnAddFriend));
			}
			if (RelationMenuFram._CheckGetPupil(this.m_data.m_data))
			{
				this._AddElement("收为弟子", delegate
				{
					if (RelationMenuFram._OnAskForPupil(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
		}

		// Token: 0x0601049E RID: 66718 RVA: 0x00490B90 File Offset: 0x0048EF90
		protected void _InitMyTeacherMenu()
		{
			this._AddElement("密聊", new UnityAction(this._OnChat));
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
				});
			}
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
		}

		// Token: 0x0601049F RID: 66719 RVA: 0x00490C64 File Offset: 0x0048F064
		public static bool _OnAskForTeacher(RelationData data)
		{
			if ((int)data.level < DataManager<TAPDataManager>.GetInstance().teacherMinLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("tap_other_get_pupil_need_lv", DataManager<TAPDataManager>.GetInstance().teacherMinLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			DataManager<TAPDataManager>.GetInstance().SendApplyTeacher(data.uid);
			DataManager<TAPDataManager>.GetInstance().AddQueryInfo(data.uid);
			return true;
		}

		// Token: 0x060104A0 RID: 66720 RVA: 0x00490CC8 File Offset: 0x0048F0C8
		public static bool _OnAskForPupil(RelationData data)
		{
			if (!DataManager<TAPDataManager>.GetInstance().CheckApplyPupil(true))
			{
				return false;
			}
			RelationData relationData = DataManager<RelationDataManager>.GetInstance().ApplyPupils.Find((RelationData x) => x.uid == data.uid);
			if (relationData != null)
			{
				DataManager<RelationDataManager>.GetInstance().AcceptApplyPupils(data.uid);
				DataManager<RelationDataManager>.GetInstance().RemoveApplyPupil(data.uid);
			}
			else
			{
				DataManager<TAPDataManager>.GetInstance().SendApplyPupil(data.uid);
				DataManager<TAPDataManager>.GetInstance().AddApplyedPupil(data.uid);
			}
			return true;
		}

		// Token: 0x060104A1 RID: 66721 RVA: 0x00490D70 File Offset: 0x0048F170
		public static void _OnFireTeacher(RelationData data)
		{
			SystemNotifyManager.SystemNotifyOkCancel(7020, null, delegate
			{
				if (data.type == 4)
				{
					DataManager<RelationDataManager>.GetInstance().DelRelation(data.uid, RelationType.RELATION_MASTER);
				}
				else if (data.type == 5)
				{
					DataManager<RelationDataManager>.GetInstance().DelRelation(data.uid, RelationType.RELATION_DISCIPLE);
				}
				DataManager<TAPDataManager>.GetInstance().OnFirstCheckFlag = false;
			}, FrameLayer.High, false);
		}

		// Token: 0x060104A2 RID: 66722 RVA: 0x00490DA4 File Offset: 0x0048F1A4
		protected void _AddElement(string name, UnityAction cb)
		{
			this.m_element = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Common/ComLayoutElement", true, 0U);
			Text componetInChild = Utility.GetComponetInChild<Text>(this.m_element, "Button/Text");
			componetInChild.text = name;
			Button componetInChild2 = Utility.GetComponetInChild<Button>(this.m_element, "Button");
			componetInChild2.onClick.AddListener(cb);
			GameObject gameObject = Utility.FindGameObject(this.frame, "Content", true);
			this.m_element.transform.SetParent(gameObject.transform, false);
		}

		// Token: 0x060104A3 RID: 66723 RVA: 0x00490E26 File Offset: 0x0048F226
		protected void _OnCheckInfo()
		{
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.m_data.m_data.uid, 0U, 0U);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104A4 RID: 66724 RVA: 0x00490E51 File Offset: 0x0048F251
		private void OnCheckInfoInTeamDuplication()
		{
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.m_data.m_data.uid, 1U, this.m_data.m_data.zoneId);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104A5 RID: 66725 RVA: 0x00490E8C File Offset: 0x0048F28C
		protected void _OnChat()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			DataManager<TAPNewDataManager>.GetInstance()._TalkToPeople(this.m_data.m_data, null);
		}

		// Token: 0x060104A6 RID: 66726 RVA: 0x00490F00 File Offset: 0x0048F300
		protected void _OnInvitePK()
		{
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 30;
			sceneRequest.target = this.m_data.m_data.uid;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104A7 RID: 66727 RVA: 0x00490F4D File Offset: 0x0048F34D
		protected void _OnInvitTeam()
		{
			DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104A8 RID: 66728 RVA: 0x00490F76 File Offset: 0x0048F376
		protected void _OnApplicationTeam()
		{
			DataManager<TeamDataManager>.GetInstance().JoinTeam(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104A9 RID: 66729 RVA: 0x00490F9F File Offset: 0x0048F39F
		protected void _OnReport()
		{
			if (this.m_data != null)
			{
				DataManager<BaseWebViewManager>.GetInstance().TryOpenReportFrame(this.m_data.m_data);
			}
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104AA RID: 66730 RVA: 0x00490FD0 File Offset: 0x0048F3D0
		protected void _OnAddFriend()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 3;
			sceneRequest.target = this.m_data.m_data.uid;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104AB RID: 66731 RVA: 0x0049107C File Offset: 0x0048F47C
		protected void _OnDelFriend()
		{
			string msgContent = string.Format("是否删除好友?", new object[0]);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().DelFriend(this.m_data.m_data.uid);
			}, delegate()
			{
			}, 0f, false);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104AC RID: 66732 RVA: 0x004910DC File Offset: 0x0048F4DC
		protected void _OnDelPriChat()
		{
			DataManager<RelationDataManager>.GetInstance().DelPriChat(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104AD RID: 66733 RVA: 0x00491105 File Offset: 0x0048F505
		protected void _OnDelPriChat2()
		{
			this._OnDelPriChat();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SetChatTab, ChatType.CT_PRIVATE_LIST, null, null, null);
		}

		// Token: 0x060104AE RID: 66734 RVA: 0x00491128 File Offset: 0x0048F528
		protected void _OnAddBlack()
		{
			string msgContent = string.Format("是否加入黑名单?", new object[0]);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().AddBlackList(this.m_data.m_data.uid);
			}, delegate()
			{
			}, 0f, false);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x060104AF RID: 66735 RVA: 0x00491188 File Offset: 0x0048F588
		protected void _OnInviteMembership()
		{
			DataManager<GuildDataManager>.GetInstance().InviteJoinGuild(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<RelationMenuFram>(this, false);
		}

		// Token: 0x0400A4E9 RID: 42217
		private GameObject m_element;

		// Token: 0x0400A4EA RID: 42218
		private RelationMenuData m_data;
	}
}
