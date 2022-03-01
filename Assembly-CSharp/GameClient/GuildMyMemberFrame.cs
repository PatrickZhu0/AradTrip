using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200163C RID: 5692
	internal class GuildMyMemberFrame : ClientFrame
	{
		// Token: 0x0600DFE6 RID: 57318 RVA: 0x00392BE7 File Offset: 0x00390FE7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMyMember";
		}

		// Token: 0x0600DFE7 RID: 57319 RVA: 0x00392BF0 File Offset: 0x00390FF0
		protected override void _OnOpenFrame()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				return;
			}
			this.m_objMemberTemplate.SetActive(false);
			this.m_objMenu.SetActive(false);
			this.m_objMenuFuncTempLate.SetActive(false);
			this.m_comBtnCloseMenu.gameObject.SetActive(false);
			this.m_comBtnCloseMenu.onMouseDown.RemoveAllListeners();
			this.m_comBtnCloseMenu.onMouseDown.AddListener(delegate(PointerEventData var)
			{
				this._CloseMenu();
			});
			this.m_comBtnCloseMenu.onClick.RemoveAllListeners();
			this.m_comBtnCloseMenu.onClick.AddListener(delegate()
			{
				this.m_comBtnCloseMenu.gameObject.SetActive(false);
			});
			this._RegisterUIEvent();
			for (int i = 0; i < 9; i++)
			{
				this.m_arrSortInfos.Add(new GuildMyMemberFrame.SortInfo());
			}
			this.m_arrSortInfos[0].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Job/Sort");
			this.m_arrSortInfos[1].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Name/Sort");
			this.m_arrSortInfos[2].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Level/Sort");
			this.m_arrSortInfos[3].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Duty/Sort");
			this.m_arrSortInfos[4].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Contribution/Sort");
			this.m_arrSortInfos[5].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/OffLineTime/Sort");
			this.m_arrSortInfos[6].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "ScrollView/Title/Active/Sort");
			this.m_arrSortInfos[7].imgAscending = this.mBind.GetCom<Image>("SortVipLv");
			this.m_arrSortInfos[8].imgAscending = this.mBind.GetCom<Image>("SortSeasonLv");
			for (int j = 0; j < this.m_arrSortInfos.Count; j++)
			{
				this.m_arrSortInfos[j].imgAscending.gameObject.SetActive(false);
			}
			this.m_arrSortInfos[0].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => a_left.nJobID - a_right.nJobID);
			this.m_arrSortInfos[1].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => string.Compare(a_left.strName, a_right.strName));
			this.m_arrSortInfos[2].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => a_left.nLevel - a_right.nLevel);
			this.m_arrSortInfos[3].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => a_left.eGuildDuty - a_right.eGuildDuty);
			this.m_arrSortInfos[4].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => a_left.nContribution - a_right.nContribution);
			this.m_arrSortInfos[5].delCompare = delegate(GuildMemberData a_left, GuildMemberData a_right)
			{
				int result;
				if (a_left.uOffLineTime == 0U)
				{
					if (a_right.uOffLineTime > 0U)
					{
						result = 1;
					}
					else
					{
						result = 0;
					}
				}
				else if (a_right.uOffLineTime > 0U)
				{
					result = (int)(a_left.uOffLineTime - a_right.uOffLineTime);
				}
				else
				{
					result = -1;
				}
				return result;
			};
			this.m_arrSortInfos[6].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => (int)(a_left.uActiveDegree - a_right.uActiveDegree));
			this.m_arrSortInfos[7].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => (int)(a_left.vipLevel - a_right.vipLevel));
			this.m_arrSortInfos[8].delCompare = ((GuildMemberData a_left, GuildMemberData a_right) => (int)(a_left.seasonLevel - a_right.seasonLevel));
			this._UpdateRequesterList();
			this._UpdateRedPoint();
			DataManager<GuildDataManager>.GetInstance().RequestGuildMembers();
			this._UpdatePermission();
		}

		// Token: 0x0600DFE8 RID: 57320 RVA: 0x00392FDE File Offset: 0x003913DE
		protected override void _OnCloseFrame()
		{
			this.m_uCurrMemberID = 0UL;
			this.m_arrSortInfos.Clear();
			this._CloseMenu();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DFE9 RID: 57321 RVA: 0x00393000 File Offset: 0x00391400
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildMembersUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildMembersUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildKickMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnKickMemberSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildProcessRequesterSuccess, new ClientEventSystem.UIEventHandler(this._OnProcessRequesterSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildChangeDutySuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDutySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildDataChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestDismissGuildSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestCancelDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestCancelDismissGuildSuccess));
		}

		// Token: 0x0600DFEA RID: 57322 RVA: 0x003930E0 File Offset: 0x003914E0
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildMembersUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildMembersUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildKickMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnKickMemberSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildProcessRequesterSuccess, new ClientEventSystem.UIEventHandler(this._OnProcessRequesterSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildChangeDutySuccess, new ClientEventSystem.UIEventHandler(this._OnChangeDutySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildDataChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestDismissGuildSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestCancelDismissSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestCancelDismissGuildSuccess));
		}

		// Token: 0x0600DFEB RID: 57323 RVA: 0x003931BF File Offset: 0x003915BF
		private void _UpdateRequesterList()
		{
			if (this.m_objRequesterList != null)
			{
				this.m_objRequesterList.SetActive(DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ProcessRequester, EGuildDuty.Invalid));
			}
		}

		// Token: 0x0600DFEC RID: 57324 RVA: 0x003931ED File Offset: 0x003915ED
		private void _UpdateRedPoint()
		{
			if (this.m_objRedPoint != null)
			{
				this.m_objRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMember));
			}
		}

		// Token: 0x0600DFED RID: 57325 RVA: 0x00393218 File Offset: 0x00391618
		private void _DestroyGuildMemberInfo(ulong a_uGUID)
		{
			List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
			int num = arrMembers.FindIndex((GuildMemberData value) => value.uGUID == a_uGUID);
			if (num >= 0 && num < arrMembers.Count)
			{
				arrMembers.RemoveAt(num);
			}
			this.RefreshMemberListCount();
		}

		// Token: 0x0600DFEE RID: 57326 RVA: 0x00393278 File Offset: 0x00391678
		private string _GetOfflineDesc(int a_nOffline)
		{
			if (a_nOffline <= 0)
			{
				return TR.Value("guild_online");
			}
			int num = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - (uint)a_nOffline);
			if (num < 1)
			{
				num = 1;
			}
			int num2 = num / 86400;
			if (num2 > 0)
			{
				return TR.Value("guild_offline_day", num2);
			}
			int num3 = num / 3600;
			if (num3 > 0)
			{
				return TR.Value("guild_offline_hour", num3);
			}
			int num4 = num / 60;
			if (num4 > 0)
			{
				return TR.Value("guild_offline_minute", num4);
			}
			return TR.Value("guild_offline_second", num);
		}

		// Token: 0x0600DFEF RID: 57327 RVA: 0x0039331C File Offset: 0x0039171C
		private void _OpenMenu(GuildMemberData MemData)
		{
			if (MemData.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			this.m_objMenu.SetActive(true);
			this.m_comBtnCloseMenu.gameObject.SetActive(true);
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
			gameObject.transform.SetParent(this.m_objMenu.transform, false);
			gameObject.SetActive(true);
			gameObject.GetComponent<Button>().onClick.AddListener(delegate()
			{
				this._OnMenuFuncChat(MemData);
			});
			Utility.GetComponetInChild<Text>(gameObject, "Text").text = TR.Value("guild_menu_chat");
			this.m_arrMenuFuncs.Add(gameObject);
			GameObject gameObject2 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
			gameObject2.transform.SetParent(this.m_objMenu.transform, false);
			gameObject2.SetActive(true);
			gameObject2.GetComponent<Button>().onClick.AddListener(delegate()
			{
				this._OnMenuFuncWatch(MemData.uGUID);
			});
			Utility.GetComponetInChild<Text>(gameObject2, "Text").text = TR.Value("guild_menu_watch");
			this.m_arrMenuFuncs.Add(gameObject2);
			GameObject gameObject3 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
			gameObject3.transform.SetParent(this.m_objMenu.transform, false);
			gameObject3.SetActive(true);
			gameObject3.GetComponent<Button>().onClick.AddListener(delegate()
			{
				this._OnMenuFuncAddFriend(MemData.uGUID);
			});
			Utility.GetComponetInChild<Text>(gameObject3, "Text").text = TR.Value("guild_menu_add_friend");
			this.m_arrMenuFuncs.Add(gameObject3);
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.KickMember, MemData.eGuildDuty))
			{
				GameObject gameObject4 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
				gameObject4.transform.SetParent(this.m_objMenu.transform, false);
				gameObject4.SetActive(true);
				gameObject4.GetComponent<Button>().onClick.AddListener(delegate()
				{
					this._OnMenuFuncKickMember(MemData.uGUID);
				});
				Utility.GetComponetInChild<Text>(gameObject4, "Text").text = TR.Value("guild_menu_kick_member");
				this.m_arrMenuFuncs.Add(gameObject4);
			}
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SetDutyNormal, MemData.eGuildDuty) && MemData.eGuildDuty != EGuildDuty.Normal && MemData.eGuildDuty != EGuildDuty.Elite)
			{
				GameObject gameObject5 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
				gameObject5.transform.SetParent(this.m_objMenu.transform, false);
				gameObject5.SetActive(true);
				gameObject5.GetComponent<Button>().onClick.AddListener(delegate()
				{
					this._OnMenuSetDuty(MemData.uGUID, EGuildDuty.Normal);
				});
				Utility.GetComponetInChild<Text>(gameObject5, "Text").text = TR.Value("guild_menu_set_duty_normal");
				this.m_arrMenuFuncs.Add(gameObject5);
			}
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SetDutyElder, MemData.eGuildDuty) && MemData.eGuildDuty != EGuildDuty.Elder)
			{
				GameObject gameObject6 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
				gameObject6.transform.SetParent(this.m_objMenu.transform, false);
				gameObject6.SetActive(true);
				gameObject6.GetComponent<Button>().onClick.AddListener(delegate()
				{
					this._OnMenuSetDuty(MemData.uGUID, EGuildDuty.Elder);
				});
				Utility.GetComponetInChild<Text>(gameObject6, "Text").text = TR.Value("guild_menu_set_duty_elder");
				this.m_arrMenuFuncs.Add(gameObject6);
			}
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SetDutyAssistant, MemData.eGuildDuty) && MemData.eGuildDuty != EGuildDuty.Assistant)
			{
				GameObject gameObject7 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
				gameObject7.transform.SetParent(this.m_objMenu.transform, false);
				gameObject7.SetActive(true);
				gameObject7.GetComponent<Button>().onClick.AddListener(delegate()
				{
					this._OnMenuSetDuty(MemData.uGUID, EGuildDuty.Assistant);
				});
				Utility.GetComponetInChild<Text>(gameObject7, "Text").text = TR.Value("guild_menu_set_duty_assistant");
				this.m_arrMenuFuncs.Add(gameObject7);
			}
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.SetDutyLeader, MemData.eGuildDuty) && MemData.eGuildDuty != EGuildDuty.Leader)
			{
				GameObject gameObject8 = Object.Instantiate<GameObject>(this.m_objMenuFuncTempLate);
				gameObject8.transform.SetParent(this.m_objMenu.transform, false);
				gameObject8.SetActive(true);
				gameObject8.GetComponent<Button>().onClick.AddListener(delegate()
				{
					this._CloseMenu();
					SystemNotifyManager.SystemNotify(3003, delegate()
					{
						this._OnMenuSetDuty(MemData.uGUID, EGuildDuty.Leader);
					});
				});
				Utility.GetComponetInChild<Text>(gameObject8, "Text").text = TR.Value("guild_menu_set_duty_leader");
				this.m_arrMenuFuncs.Add(gameObject8);
			}
			if (this.m_objMenu != null)
			{
				Utility.SetPopMenuPosition(this.m_objMenu, new Vector2(20f, 20f), new Vector2(0f, 0f));
			}
		}

		// Token: 0x0600DFF0 RID: 57328 RVA: 0x0039380C File Offset: 0x00391C0C
		private void _OpenSelfMenu(GuildMemberData MemData)
		{
		}

		// Token: 0x0600DFF1 RID: 57329 RVA: 0x00393810 File Offset: 0x00391C10
		private void _UpdatePermission()
		{
			if (this.btnQuit == null || this.m_objTime == null)
			{
				return;
			}
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.Dismiss, EGuildDuty.Invalid))
			{
				if (DataManager<GuildDataManager>.GetInstance().myGuild.nDismissTime > 0U)
				{
					this.btnQuit.GetComponentInChildren<Text>().text = TR.Value("guild_cancel_dismiss");
					this.m_objTime.CustomActive(true);
					this.m_objTime.GetComponent<Text>().text = this._GetFreeTimeCDDesc((int)DataManager<GuildDataManager>.GetInstance().myGuild.nDismissTime);
					this.m_fUpdateTime = 1f;
					this.isUpdate = true;
				}
				else
				{
					this.btnQuit.GetComponentInChildren<Text>().text = TR.Value("guild_dissmiss");
					this.m_objTime.CustomActive(false);
					this.isUpdate = false;
				}
			}
			else
			{
				this.btnQuit.GetComponentInChildren<Text>().text = TR.Value("guild_quit");
				this.m_objTime.CustomActive(false);
				this.isUpdate = false;
			}
			this.SetBottomRightBtnPos();
		}

		// Token: 0x0600DFF2 RID: 57330 RVA: 0x00393934 File Offset: 0x00391D34
		private void SetBottomRightBtnPos()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.Dismiss, EGuildDuty.Invalid) || DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.ProcessRequester, EGuildDuty.Invalid))
			{
				this.btnQuit.GetComponent<RectTransform>().anchoredPosition = new Vector2(-380f, 26f);
			}
			else
			{
				this.btnQuit.GetComponent<RectTransform>().anchoredPosition = new Vector2(-60f, 26f);
			}
		}

		// Token: 0x0600DFF3 RID: 57331 RVA: 0x003939B0 File Offset: 0x00391DB0
		private void _CloseMenu()
		{
			this.m_objMenu.SetActive(false);
			for (int i = 0; i < this.m_arrMenuFuncs.Count; i++)
			{
				Object.Destroy(this.m_arrMenuFuncs[i]);
			}
			this.m_arrMenuFuncs.Clear();
		}

		// Token: 0x0600DFF4 RID: 57332 RVA: 0x00393A01 File Offset: 0x00391E01
		public override bool IsNeedUpdate()
		{
			return this.isUpdate;
		}

		// Token: 0x0600DFF5 RID: 57333 RVA: 0x00393A0C File Offset: 0x00391E0C
		private void _OnMenuFuncChat(GuildMemberData a_memberData)
		{
			RelationData relationData = new RelationData();
			relationData.type = 0;
			relationData.uid = a_memberData.uGUID;
			relationData.name = a_memberData.strName;
			relationData.level = (ushort)a_memberData.nLevel;
			relationData.isOnline = ((a_memberData.uOffLineTime > 0U) ? 0 : 1);
			relationData.occu = (byte)a_memberData.nJobID;
			DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationData);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
		}

		// Token: 0x0600DFF6 RID: 57334 RVA: 0x00393A90 File Offset: 0x00391E90
		private void _OnMenuFuncWatch(ulong a_uGUID)
		{
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(a_uGUID, 0U, 0U);
			this._CloseMenu();
		}

		// Token: 0x0600DFF7 RID: 57335 RVA: 0x00393AA5 File Offset: 0x00391EA5
		private void _OnMenuFuncAddFriend(ulong a_uGUID)
		{
			DataManager<RelationDataManager>.GetInstance().AddFriendByID(a_uGUID);
			this._CloseMenu();
		}

		// Token: 0x0600DFF8 RID: 57336 RVA: 0x00393AB8 File Offset: 0x00391EB8
		private void _OnMenuFuncKickMember(ulong a_uGUID)
		{
			SystemNotifyManager.SystemNotify(3002, delegate()
			{
				DataManager<GuildDataManager>.GetInstance().KickMember(a_uGUID);
			});
			this._CloseMenu();
		}

		// Token: 0x0600DFF9 RID: 57337 RVA: 0x00393AF0 File Offset: 0x00391EF0
		private void _OnMenuSetDuty(ulong a_uMemberGUID, EGuildDuty a_eDuty)
		{
			if (DataManager<GuildDataManager>.GetInstance().IsDutyFull(a_eDuty))
			{
				GuildChangeDutyData guildChangeDutyData = new GuildChangeDutyData();
				guildChangeDutyData.uMemberGUID = a_uMemberGUID;
				guildChangeDutyData.eDuty = a_eDuty;
				this.frameMgr.OpenFrame<GuildChangeDutyFrame>(FrameLayer.Middle, guildChangeDutyData, string.Empty);
			}
			else
			{
				DataManager<GuildDataManager>.GetInstance().ChangeMemberDuty(a_uMemberGUID, a_eDuty, 0UL);
			}
			this._CloseMenu();
		}

		// Token: 0x0600DFFA RID: 57338 RVA: 0x00393B50 File Offset: 0x00391F50
		private void _OnQuitGuild()
		{
			GuildDataManager guildMgr = DataManager<GuildDataManager>.GetInstance();
			if (guildMgr == null)
			{
				return;
			}
			if (guildMgr.HasSelfGuild())
			{
				if (guildMgr.HasPermission(EGuildPermission.Dismiss, EGuildDuty.Invalid))
				{
					if (guildMgr.myGuild.nDismissTime > 0U)
					{
						guildMgr.CancelDismissGuild();
					}
					else
					{
						SystemNotifyManager.SystemNotify(3004, delegate()
						{
							guildMgr.DismissGuild();
						});
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(3001, delegate()
					{
						guildMgr.LeaveGuild();
					});
				}
			}
			this._CloseMenu();
		}

		// Token: 0x0600DFFB RID: 57339 RVA: 0x00393C00 File Offset: 0x00392000
		private int _CompareByColType(GuildMemberData a_left, GuildMemberData a_right, GuildMyMemberFrame.EColType a_colType, int a_nSign)
		{
			if (a_left.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return -1;
			}
			if (a_right.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return 1;
			}
			int num = 0;
			if (a_colType >= GuildMyMemberFrame.EColType.Job && a_colType < (GuildMyMemberFrame.EColType)this.m_arrSortInfos.Count)
			{
				num = this.m_arrSortInfos[(int)a_colType].delCompare(a_left, a_right);
				if (num == 0)
				{
					for (int i = 0; i < this.m_arrSortPriority.Length; i++)
					{
						int num2 = (int)this.m_arrSortPriority[i];
						if (num2 != (int)a_colType)
						{
							num = this.m_arrSortInfos[num2].delCompare(a_left, a_right);
							if (num != 0)
							{
								break;
							}
						}
					}
				}
			}
			return num * a_nSign;
		}

		// Token: 0x0600DFFC RID: 57340 RVA: 0x00393CC8 File Offset: 0x003920C8
		private void _SortMembers(GuildMyMemberFrame.EColType a_colType)
		{
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
				if (arrMembers != null)
				{
					int nIndex = (int)a_colType;
					if (this.m_arrSortInfos != null && nIndex >= 0 && nIndex < this.m_arrSortInfos.Count)
					{
						GuildMyMemberFrame.SortInfo sortInfo = this.m_arrSortInfos[nIndex];
						if (sortInfo != null)
						{
							sortInfo.bAscending = !sortInfo.bAscending;
							int nSign = (!sortInfo.bAscending) ? -1 : 1;
							arrMembers.Sort(delegate(GuildMemberData a_left, GuildMemberData a_right)
							{
								if (a_left.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
								{
									return -1;
								}
								if (a_right.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
								{
									return 1;
								}
								int num = sortInfo.delCompare(a_left, a_right);
								if (num == 0 && this.m_arrSortPriority != null)
								{
									for (int j = 0; j < this.m_arrSortPriority.Length; j++)
									{
										int num2 = (int)this.m_arrSortPriority[j];
										if (num2 != nIndex)
										{
											num = this.m_arrSortInfos[num2].delCompare(a_left, a_right);
											if (num != 0)
											{
												break;
											}
										}
									}
								}
								return num * nSign;
							});
							for (int i = 0; i < this.m_arrSortInfos.Count; i++)
							{
								if (this.m_arrSortInfos[i].imgAscending != null)
								{
									this.m_arrSortInfos[i].imgAscending.gameObject.SetActive(false);
								}
							}
							if (this.m_arrSortInfos[nIndex].imgAscending != null)
							{
								this.m_arrSortInfos[nIndex].imgAscending.gameObject.SetActive(true);
								this.m_arrSortInfos[nIndex].imgAscending.transform.localRotation = ((!this.m_arrSortInfos[nIndex].bAscending) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 180f));
							}
						}
					}
				}
			}
		}

		// Token: 0x0600DFFD RID: 57341 RVA: 0x00393EC4 File Offset: 0x003922C4
		private void _OnGuildMembersUpdate(UIEvent a_event)
		{
			this.InitMemberScrollListBind();
			List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
			this._SortMembers(GuildMyMemberFrame.EColType.OfflineTime);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600DFFE RID: 57342 RVA: 0x00393EF4 File Offset: 0x003922F4
		private void RefreshOnLineMembers()
		{
			List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
			int num = 0;
			for (int i = 0; i < arrMembers.Count; i++)
			{
				string a = this._GetOfflineDesc((int)arrMembers[i].uOffLineTime);
				if (!(a != TR.Value("guild_online")))
				{
					num++;
				}
			}
			this.onLineCountTexte.text = string.Concat(new object[]
			{
				"在线成员：",
				num,
				"/",
				arrMembers.Count
			});
		}

		// Token: 0x0600DFFF RID: 57343 RVA: 0x00393F98 File Offset: 0x00392398
		private void _OnKickMemberSuccess(UIEvent a_event)
		{
			ulong a_uGUID = (ulong)a_event.Param1;
			this._DestroyGuildMemberInfo(a_uGUID);
		}

		// Token: 0x0600E000 RID: 57344 RVA: 0x00393FB8 File Offset: 0x003923B8
		private void _OnProcessRequesterSuccess(UIEvent a_event)
		{
			ulong uGUID = (ulong)a_event.Param1;
			GuildMemberData guildMemberData = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers.Find((GuildMemberData value) => value.uGUID == uGUID);
			if (guildMemberData != null)
			{
				this.RefreshMemberListCount();
			}
		}

		// Token: 0x0600E001 RID: 57345 RVA: 0x00394009 File Offset: 0x00392409
		private void _OnChangeDutySuccess(UIEvent a_event)
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_change_duty_success"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			this.RefreshMemberListCount();
			this._UpdatePermission();
		}

		// Token: 0x0600E002 RID: 57346 RVA: 0x00394028 File Offset: 0x00392428
		private void _OnRedPointChanged(UIEvent a_event)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600E003 RID: 57347 RVA: 0x00394030 File Offset: 0x00392430
		private void _OnGuildDataChanged(UIEvent a_event)
		{
			SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)a_event.Param1;
			if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_POST)
			{
				this._UpdateRequesterList();
			}
		}

		// Token: 0x0600E004 RID: 57348 RVA: 0x00394057 File Offset: 0x00392457
		private void _OnRequestDismissGuildSuccess(UIEvent a_event)
		{
			this._UpdatePermission();
		}

		// Token: 0x0600E005 RID: 57349 RVA: 0x0039405F File Offset: 0x0039245F
		private void _OnRequestCancelDismissGuildSuccess(UIEvent a_event)
		{
			this._UpdatePermission();
		}

		// Token: 0x0600E006 RID: 57350 RVA: 0x00394067 File Offset: 0x00392467
		[UIEventHandle("RequesterList")]
		private void _OnRequesterListClicked()
		{
			this.frameMgr.OpenFrame<GuildRequesterListFrame>(FrameLayer.Middle, null, string.Empty);
			DataManager<RedPointDataManager>.GetInstance().ClearRedPoint(ERedPoint.GuildRequester);
		}

		// Token: 0x0600E007 RID: 57351 RVA: 0x00394087 File Offset: 0x00392487
		[UIEventHandle("ScrollView/Title/Job")]
		private void _OnTitleJobClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.Job);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E008 RID: 57352 RVA: 0x00394096 File Offset: 0x00392496
		[UIEventHandle("ScrollView/Title/Name")]
		private void _OnTitleNameClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.Name);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E009 RID: 57353 RVA: 0x003940A5 File Offset: 0x003924A5
		[UIEventHandle("ScrollView/Title/Level")]
		private void _OnTitleLevelClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.Level);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E00A RID: 57354 RVA: 0x003940B4 File Offset: 0x003924B4
		[UIEventHandle("ScrollView/Title/Duty")]
		private void _OnTitleDutyClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.Duty);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E00B RID: 57355 RVA: 0x003940C3 File Offset: 0x003924C3
		[UIEventHandle("ScrollView/Title/Contribution")]
		private void _OnTitleContributionClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.Contribution);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E00C RID: 57356 RVA: 0x003940D2 File Offset: 0x003924D2
		[UIEventHandle("ScrollView/Title/OffLineTime")]
		private void _OnTitleOffLineTimeClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.OfflineTime);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E00D RID: 57357 RVA: 0x003940E1 File Offset: 0x003924E1
		[UIEventHandle("ScrollView/Title/Active")]
		private void _OnTitleActiveClicked()
		{
			this._SortMembers(GuildMyMemberFrame.EColType.ActiveDegree);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E00E RID: 57358 RVA: 0x003940F0 File Offset: 0x003924F0
		protected override void _OnUpdate(float timeElapsed)
		{
			this.m_fUpdateTime -= timeElapsed;
			if (this.m_fUpdateTime <= 0f && this.m_objTime != null)
			{
				this.m_objTime.GetComponent<Text>().text = this._GetFreeTimeCDDesc((int)DataManager<GuildDataManager>.GetInstance().myGuild.nDismissTime);
			}
		}

		// Token: 0x0600E00F RID: 57359 RVA: 0x00394154 File Offset: 0x00392554
		private string _GetFreeTimeCDDesc(int a_timeStamp)
		{
			int num = a_timeStamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				num = 0;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = num % 60;
			int num5 = num / 60;
			if (num5 > 0)
			{
				num2 = num5 % 60;
				num3 = num5 / 60;
			}
			return TR.Value("guild_dissolutionguild_success", num3, num2, num4);
		}

		// Token: 0x0600E010 RID: 57360 RVA: 0x003941B8 File Offset: 0x003925B8
		protected override void _bindExUI()
		{
			this.mMemberList = this.mBind.GetCom<ComUIListScript>("MemberList");
			this.btnSortVipLv = this.mBind.GetCom<Button>("btnSortVipLv");
			this.btnSortVipLv.SafeAddOnClickListener(delegate
			{
				this._SortMembers(GuildMyMemberFrame.EColType.VipLevel);
				this.RefreshMemberListCount();
			});
			this.btnSortSeasonLv = this.mBind.GetCom<Button>("btnSortSeasonLv");
			this.btnSortSeasonLv.SafeAddOnClickListener(delegate
			{
				this._SortMembers(GuildMyMemberFrame.EColType.SeasonLv);
				this.RefreshMemberListCount();
			});
			this.btnQuit = this.mBind.GetCom<Button>("BtnQuit");
			this.btnQuit.SafeAddOnClickListener(delegate
			{
				this._OnQuitGuild();
			});
			this.m_objTime = this.mBind.GetGameObject("time");
		}

		// Token: 0x0600E011 RID: 57361 RVA: 0x00394278 File Offset: 0x00392678
		protected override void _unbindExUI()
		{
			this.mMemberList = null;
			this.btnSortVipLv = null;
			this.btnSortSeasonLv = null;
			this.m_objTime = null;
		}

		// Token: 0x0600E012 RID: 57362 RVA: 0x00394298 File Offset: 0x00392698
		private void InitMemberScrollListBind()
		{
			if (this.mMemberList == null)
			{
				return;
			}
			this.mMemberList.Initialize();
			this.mMemberList.onItemChageDisplay = delegate(ComUIListElementScript item, bool bSelected)
			{
				if (item == null)
				{
					return;
				}
				if (DataManager<GuildDataManager>.GetInstance().myGuild == null)
				{
					return;
				}
				List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
				if (item.m_index >= 0 && item.m_index < arrMembers.Count)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					GameObject gameObject = component.GetGameObject("Select");
					if (gameObject != null)
					{
						gameObject.CustomActive(false);
					}
				}
			};
			this.mMemberList.onItemSelected = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				if (DataManager<GuildDataManager>.GetInstance().myGuild == null)
				{
					return;
				}
				List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
				if (item.m_index >= 0 && item.m_index < arrMembers.Count)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					GameObject gameObject = component.GetGameObject("Select");
					if (gameObject != null)
					{
						gameObject.CustomActive(true);
					}
				}
			};
			this.mMemberList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				if (item.m_index >= 0)
				{
					this.UpdateMemberScrollListBind(item);
				}
			};
			this.mMemberList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("Mask");
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
				}
			};
		}

		// Token: 0x0600E013 RID: 57363 RVA: 0x00394354 File Offset: 0x00392754
		private void UpdateMemberScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
			if (item.m_index < 0 || item.m_index >= arrMembers.Count)
			{
				return;
			}
			GuildMemberData MemData = arrMembers[item.m_index];
			if (MemData == null)
			{
				return;
			}
			GameObject mSelect = component.GetGameObject("Select");
			Text com = component.GetCom<Text>("JobName");
			Text com2 = component.GetCom<Text>("Name");
			Text com3 = component.GetCom<Text>("Level");
			Text com4 = component.GetCom<Text>("Duty");
			Text com5 = component.GetCom<Text>("Contribution");
			Text com6 = component.GetCom<Text>("OffLineTime");
			Text com7 = component.GetCom<Text>("Active");
			Text com8 = component.GetCom<Text>("vipLv");
			Text com9 = component.GetCom<Text>("seasonLv");
			Image com10 = component.GetCom<Image>("Face");
			Button com11 = component.GetCom<Button>("Mask");
			UIGray com12 = component.GetCom<UIGray>("FaceGray");
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(MemData.nJobID, string.Empty, string.Empty);
			mSelect.SetActive(false);
			com.text = Utility.GetJobName(MemData.nJobID, 0);
			com2.text = MemData.strName;
			com3.text = string.Format("Lv{0}", MemData.nLevel);
			com4.text = TR.Value(MemData.eGuildDuty.GetDescription(true));
			com5.text = MemData.nContribution.ToString();
			com6.text = this._GetOfflineDesc((int)MemData.uOffLineTime);
			com7.text = MemData.uActiveDegree.ToString();
			com8.SafeSetText(TR.Value("vip_level", MemData.vipLevel));
			com9.SafeSetText(DataManager<SeasonDataManager>.GetInstance().GetRankName((int)MemData.seasonLevel, true));
			if (MemData.seasonLevel == 0U)
			{
				com9.SafeSetText(TR.Value("no_seasonlv_data"));
			}
			if (MemData.uOffLineTime > 0U)
			{
				com.color = this.m_colorGray;
				com2.color = this.m_colorGray;
				com3.color = this.m_colorGray;
				com4.color = this.m_colorGray;
				com5.color = this.m_colorGray;
				com6.color = this.m_colorGray;
				com7.color = this.m_colorGray;
				com8.color = this.m_colorGray;
				com9.color = this.m_colorGray;
			}
			else
			{
				com.color = this.m_colorNormal;
				com2.color = this.m_colorNormal;
				com3.color = this.m_colorNormal;
				com4.color = this.m_colorNormal;
				com5.color = this.m_colorNormal;
				com6.color = this.m_colorNormal;
				com7.color = this.m_colorNormal;
				com8.color = this.m_colorNormal;
				com9.color = this.m_colorNormal;
			}
			string path = string.Empty;
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				path = tableItem2.IconPath;
			}
			ETCImageLoader.LoadSprite(ref com10, path, true);
			com12.SetEnable(MemData.uOffLineTime > 0U);
			com11.onClick.RemoveAllListeners();
			com11.onClick.AddListener(delegate()
			{
				if (MemData != null)
				{
					mSelect.SetActive(false);
				}
				mSelect.SetActive(true);
				this.m_uCurrMemberID = MemData.uGUID;
				this._OpenMenu(MemData);
			});
		}

		// Token: 0x0600E014 RID: 57364 RVA: 0x0039473C File Offset: 0x00392B3C
		private void RefreshMemberListCount()
		{
			List<GuildMemberData> arrMembers = DataManager<GuildDataManager>.GetInstance().myGuild.arrMembers;
			this.mMemberList.SetElementAmount(arrMembers.Count);
			this.RefreshOnLineMembers();
		}

		// Token: 0x04008510 RID: 34064
		[UIObject("GuildComMenuFrame/Menu")]
		private GameObject m_objMenu;

		// Token: 0x04008511 RID: 34065
		[UIObject("ScrollView/Viewport/Content")]
		private GameObject m_objMemberRoot;

		// Token: 0x04008512 RID: 34066
		[UIObject("ScrollView/Viewport/Content/Template")]
		private GameObject m_objMemberTemplate;

		// Token: 0x04008513 RID: 34067
		[UIObject("GuildComMenuFrame/Menu/Func")]
		private GameObject m_objMenuFuncTempLate;

		// Token: 0x04008514 RID: 34068
		[UIControl("CloseMenu", typeof(ComButtonEx), 0)]
		private ComButtonEx m_comBtnCloseMenu;

		// Token: 0x04008515 RID: 34069
		[UIObject("RequesterList/RedPoint")]
		private GameObject m_objRedPoint;

		// Token: 0x04008516 RID: 34070
		[UIObject("RequesterList")]
		private GameObject m_objRequesterList;

		// Token: 0x04008517 RID: 34071
		[UIControl("onLineCount", null, 0)]
		private Text onLineCountTexte;

		// Token: 0x04008518 RID: 34072
		private ulong m_uCurrMemberID;

		// Token: 0x04008519 RID: 34073
		private List<GameObject> m_arrMenuFuncs = new List<GameObject>();

		// Token: 0x0400851A RID: 34074
		private Color m_colorGray = new Color(0.654902f, 0.64705884f, 0.64705884f, 1f);

		// Token: 0x0400851B RID: 34075
		private Color m_colorNormal = new Color(0.65882355f, 0.74509805f, 0.7764706f, 1f);

		// Token: 0x0400851C RID: 34076
		private float m_fUpdateTime;

		// Token: 0x0400851D RID: 34077
		private bool isUpdate;

		// Token: 0x0400851E RID: 34078
		private List<GuildMyMemberFrame.SortInfo> m_arrSortInfos = new List<GuildMyMemberFrame.SortInfo>();

		// Token: 0x0400851F RID: 34079
		private GuildMyMemberFrame.EColType[] m_arrSortPriority = new GuildMyMemberFrame.EColType[]
		{
			GuildMyMemberFrame.EColType.OfflineTime,
			GuildMyMemberFrame.EColType.Duty,
			GuildMyMemberFrame.EColType.Contribution,
			GuildMyMemberFrame.EColType.Level,
			GuildMyMemberFrame.EColType.Name,
			GuildMyMemberFrame.EColType.Job,
			GuildMyMemberFrame.EColType.ActiveDegree,
			GuildMyMemberFrame.EColType.VipLevel,
			GuildMyMemberFrame.EColType.SeasonLv
		};

		// Token: 0x04008520 RID: 34080
		private ComUIListScript mMemberList;

		// Token: 0x04008521 RID: 34081
		private Button btnSortVipLv;

		// Token: 0x04008522 RID: 34082
		private Button btnSortSeasonLv;

		// Token: 0x04008523 RID: 34083
		private Button btnQuit;

		// Token: 0x04008524 RID: 34084
		private GameObject m_objTime;

		// Token: 0x0200163D RID: 5693
		private enum EColType
		{
			// Token: 0x04008532 RID: 34098
			Job,
			// Token: 0x04008533 RID: 34099
			Name,
			// Token: 0x04008534 RID: 34100
			Level,
			// Token: 0x04008535 RID: 34101
			Duty,
			// Token: 0x04008536 RID: 34102
			Contribution,
			// Token: 0x04008537 RID: 34103
			OfflineTime,
			// Token: 0x04008538 RID: 34104
			ActiveDegree,
			// Token: 0x04008539 RID: 34105
			VipLevel,
			// Token: 0x0400853A RID: 34106
			SeasonLv,
			// Token: 0x0400853B RID: 34107
			Count
		}

		// Token: 0x0200163E RID: 5694
		// (Invoke) Token: 0x0600E028 RID: 57384
		private delegate int CompareFunc(GuildMemberData a_left, GuildMemberData a_right);

		// Token: 0x0200163F RID: 5695
		private class SortInfo
		{
			// Token: 0x0400853C RID: 34108
			public bool bAscending = true;

			// Token: 0x0400853D RID: 34109
			public Image imgAscending;

			// Token: 0x0400853E RID: 34110
			public GuildMyMemberFrame.CompareFunc delCompare;
		}

		// Token: 0x02001640 RID: 5696
		private class GuildMemberInfo
		{
			// Token: 0x0400853F RID: 34111
			public GuildMemberData data;

			// Token: 0x04008540 RID: 34112
			public GameObject objRoot;

			// Token: 0x04008541 RID: 34113
			public GameObject objSelect;

			// Token: 0x04008542 RID: 34114
			public Text labJob;

			// Token: 0x04008543 RID: 34115
			public Text labName;

			// Token: 0x04008544 RID: 34116
			public Text labLevel;

			// Token: 0x04008545 RID: 34117
			public Text labDuty;

			// Token: 0x04008546 RID: 34118
			public Text labContribution;

			// Token: 0x04008547 RID: 34119
			public Text labOffline;

			// Token: 0x04008548 RID: 34120
			public Text labActiveDegree;
		}
	}
}
