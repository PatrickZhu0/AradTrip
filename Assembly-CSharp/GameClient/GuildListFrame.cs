using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001625 RID: 5669
	internal class GuildListFrame : ClientFrame
	{
		// Token: 0x0600DE84 RID: 56964 RVA: 0x003890EF File Offset: 0x003874EF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildList";
		}

		// Token: 0x0600DE85 RID: 56965 RVA: 0x003890F6 File Offset: 0x003874F6
		public static void OpenLinkFrame(string strParam)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DE86 RID: 56966 RVA: 0x0038910A File Offset: 0x0038750A
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.eShowGuildType = (EShowGuildType)this.userData;
			}
			else
			{
				this.eShowGuildType = EShowGuildType.All;
			}
			this._InitUI();
			this._RequestGuildList(0, 10);
			this._RegisterUIEvent();
		}

		// Token: 0x0600DE87 RID: 56967 RVA: 0x00389149 File Offset: 0x00387549
		protected override void _OnCloseFrame()
		{
			this.m_nCurrentStart = -1;
			this.m_nTotalCount = 0;
			this.m_uCurrGuildID = 0UL;
			this.m_arrGuildInfos.Clear();
			this.eShowGuildType = EShowGuildType.All;
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DE88 RID: 56968 RVA: 0x0038917C File Offset: 0x0038757C
		protected override void _bindExUI()
		{
			this.JumpTo = this.mBind.GetCom<Button>("JumpTo");
			this.JumpTo.SafeAddOnClickListener(delegate
			{
				this.RequestGuildListByInput();
			});
			this.InputPage = this.mBind.GetCom<InputField>("InputPage");
			this.guildLv = this.mBind.GetCom<Text>("guildLv");
			this.leadName = this.mBind.GetCom<Text>("leadName");
			this.fund = this.mBind.GetCom<Text>("fund");
			this.memberInfo = this.mBind.GetCom<Text>("memberInfo");
			this.crossTerrName = this.mBind.GetCom<Text>("crossTerrName");
			this.terrName = this.mBind.GetCom<Text>("terrName");
			this.joinLv = this.mBind.GetCom<Text>("joinLv");
			this.btLookUp = this.mBind.GetCom<Button>("btLookUp");
			this.btLookUp.SafeAddOnClickListener(delegate
			{
				GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
				if (guildInfo != null)
				{
					ulong leaderID = guildInfo.data.leaderID;
					if (leaderID != DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(leaderID, 0U, 0U);
					}
				}
			});
			this.goGuildInfo = this.mBind.GetGameObject("guildInfo");
			this.ContactGuildLeader = this.mBind.GetCom<Button>("ContactGuildLeader");
			this.ContactGuildLeader.SafeAddOnClickListener(delegate
			{
				GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
				if (guildInfo != null)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(guildInfo.data.leaderID);
					if (relationByRoleID != null)
					{
						AuctionNewUtility.OpenChatFrame(relationByRoleID);
						return;
					}
					DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOnShelfItemOwnerInfo(guildInfo.data.leaderID);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_please_select_one_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			});
			this.mMergeBtn = this.mBind.GetCom<Button>("Merger");
			this.mMergeBtnGray = this.mBind.GetCom<UIGray>("Merger");
			this.mMergeBtn.SafeAddOnClickListener(new UnityAction(this.OnMergeBtnClick));
			this.mCancelMergeBtn = this.mBind.GetCom<Button>("CancelMerger");
			this.mCancelMergeBtn.SafeAddOnClickListener(new UnityAction(this.OnCancelMergerClick));
			this.mMembersBtn = this.mBind.GetCom<Button>("Members");
			this.mMembersBtnGray = this.mBind.GetCom<UIGray>("Members");
			this.mMembersBtn.SafeAddOnClickListener(new UnityAction(this.OnMemberstbClick));
			this.mTitleTxt = this.mBind.GetCom<Text>("TitleTxt");
		}

		// Token: 0x0600DE89 RID: 56969 RVA: 0x003893A0 File Offset: 0x003877A0
		protected override void _unbindExUI()
		{
			this.JumpTo = null;
			this.InputPage = null;
			this.guildLv = null;
			this.leadName = null;
			this.fund = null;
			this.memberInfo = null;
			this.crossTerrName = null;
			this.terrName = null;
			this.joinLv = null;
			this.btLookUp = null;
			this.goGuildInfo = null;
			this.ContactGuildLeader = null;
			this.mMergeBtn.SafeRemoveOnClickListener(new UnityAction(this.OnMergeBtnClick));
			this.mMergeBtn = null;
			this.mMergeBtnGray = null;
			this.mMembersBtn.SafeRemoveOnClickListener(new UnityAction(this.OnMemberstbClick));
			this.mMembersBtn = null;
			this.mMembersBtnGray = null;
			this.mTitleTxt = null;
			this.mCancelMergeBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCancelMergerClick));
			this.mCancelMergeBtn = null;
		}

		// Token: 0x0600DE8A RID: 56970 RVA: 0x00389470 File Offset: 0x00387870
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildListUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateGuildList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestJoinAllSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinAllSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VirtualInputNumberChange, new ClientEventSystem.UIEventHandler(this._OnInputPageNumChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VirtualInputEnsure, new ClientEventSystem.UIEventHandler(this._OnVirtualInputEnsure));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RequestGuildMergerSucess, new ClientEventSystem.UIEventHandler(this._OnRequestGuildMergerSucess));
		}

		// Token: 0x0600DE8B RID: 56971 RVA: 0x0038953C File Offset: 0x0038793C
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildListUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateGuildList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestJoinAllSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinAllSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VirtualInputNumberChange, new ClientEventSystem.UIEventHandler(this._OnInputPageNumChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VirtualInputEnsure, new ClientEventSystem.UIEventHandler(this._OnVirtualInputEnsure));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RequestGuildMergerSucess, new ClientEventSystem.UIEventHandler(this._OnRequestGuildMergerSucess));
		}

		// Token: 0x0600DE8C RID: 56972 RVA: 0x00389608 File Offset: 0x00387A08
		private void _InitUI()
		{
			if (this.eShowGuildType == EShowGuildType.CanMerged)
			{
				this.mTitleTxt.SafeSetText("公会兼并");
			}
			else if (this.eShowGuildType == EShowGuildType.All)
			{
				this.mTitleTxt.SafeSetText("公会信息");
			}
			this.m_objGuildTemplate.SetActive(false);
			this._UpdatePage();
			this._UpdateJoinGuild();
			this._UpdateJoinAll();
			this._UpdateSelectGuildUI();
		}

		// Token: 0x0600DE8D RID: 56973 RVA: 0x00389675 File Offset: 0x00387A75
		private void _RequestGuildList(int a_nStartIndex, int a_nCount)
		{
			if (this.eShowGuildType == EShowGuildType.All)
			{
				DataManager<GuildDataManager>.GetInstance().RequestGuildList(a_nStartIndex, a_nCount);
			}
			else if (this.eShowGuildType == EShowGuildType.CanMerged)
			{
				DataManager<GuildDataManager>.GetInstance().RequestCanMergerdGuildList(a_nStartIndex, a_nCount);
			}
		}

		// Token: 0x0600DE8E RID: 56974 RVA: 0x003896AC File Offset: 0x00387AAC
		private void _UpdatePage()
		{
			int num = this.m_nCurrentStart + 1;
			int num2 = num / 10;
			if (num % 10 > 0)
			{
				num2++;
			}
			int num3 = this.m_nTotalCount / 10;
			if (this.m_nTotalCount % 10 > 0)
			{
				num3++;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > num3)
			{
				num2 = num3;
			}
			this.m_comLeftPageBtnEnable.SetEnable(true);
			this.m_comRightPageBtnEnable.SetEnable(true);
			if (num2 <= 1)
			{
				this.m_comLeftPageBtnEnable.SetEnable(false);
			}
			if (num2 >= num3)
			{
				this.m_comRightPageBtnEnable.SetEnable(false);
			}
			this.m_labPage.text = string.Format("/ {0}", num3);
			if (this.InputPage != null)
			{
				this.InputPage.textComponent.text = num2.ToString();
			}
		}

		// Token: 0x0600DE8F RID: 56975 RVA: 0x0038978C File Offset: 0x00387B8C
		private void _UpdateJoinGuild()
		{
			GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
			if (guildInfo != null)
			{
				this.m_labGuildDeclaration.text = guildInfo.data.strDeclaration;
				this.goGuildInfo.CustomActive(true);
				this.guildLv.SafeSetText(guildInfo.data.nLevel.ToString());
				this.leadName.SafeSetText(guildInfo.data.strLeaderName);
				this.memberInfo.SafeSetText(string.Format("{0}/{1}", guildInfo.data.nMemberCount, guildInfo.data.nMemberMaxCount));
				this.crossTerrName.SafeSetText(GuildDataManager.GetTerrName(guildInfo.data.occupyCrossTerrId));
				this.terrName.SafeSetText(GuildDataManager.GetTerrName(guildInfo.data.occupyTerrId));
				this.joinLv.SafeSetText(guildInfo.data.joinLevel.ToString());
			}
			else
			{
				this.m_labGuildDeclaration.text = string.Empty;
				this.guildLv.SafeSetText(string.Empty);
				this.leadName.SafeSetText(string.Empty);
				this.fund.SafeSetText(string.Empty);
				this.memberInfo.SafeSetText(string.Empty);
				this.crossTerrName.SafeSetText(string.Empty);
				this.terrName.SafeSetText(string.Empty);
				this.joinLv.SafeSetText(string.Empty);
				this.goGuildInfo.CustomActive(false);
			}
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this.m_comCreateBtnEnable.gameObject.SetActive(false);
				this.m_comJoinBtnEnable.gameObject.SetActive(false);
				this.m_comJoinAllBtnEnable.gameObject.CustomActive(false);
				this.ContactGuildLeader.CustomActive(this.eShowGuildType == EShowGuildType.CanMerged);
			}
			else
			{
				this.m_comCreateBtnEnable.gameObject.SetActive(true);
				this.m_comJoinBtnEnable.gameObject.SetActive(true);
				this.m_comJoinAllBtnEnable.gameObject.CustomActive(true);
				this.ContactGuildLeader.CustomActive(true);
			}
		}

		// Token: 0x0600DE90 RID: 56976 RVA: 0x003899BC File Offset: 0x00387DBC
		private void _OnUpdateGuildList(UIEvent a_event)
		{
			if (this.eShowGuildType == EShowGuildType.All)
			{
				WorldGuildListRes worldGuildListRes = a_event.Param1 as WorldGuildListRes;
				if (worldGuildListRes != null)
				{
					this._UpdateGuildList((int)worldGuildListRes.start, (int)worldGuildListRes.totalnum, worldGuildListRes.guilds);
				}
			}
			else if (this.eShowGuildType == EShowGuildType.CanMerged)
			{
				WorldGuildWatchCanMergerRet worldGuildWatchCanMergerRet = a_event.Param1 as WorldGuildWatchCanMergerRet;
				if (worldGuildWatchCanMergerRet != null)
				{
					this._UpdateGuildList((int)worldGuildWatchCanMergerRet.start, (int)worldGuildWatchCanMergerRet.totalNum, worldGuildWatchCanMergerRet.guilds);
				}
			}
		}

		// Token: 0x0600DE91 RID: 56977 RVA: 0x00389A3C File Offset: 0x00387E3C
		private void _UpdateGuildList(int start, int totalNum, GuildEntry[] guilds)
		{
			this.m_arrGuildInfos.Clear();
			for (int i = 0; i < this.m_objGuildListRoot.transform.childCount; i++)
			{
				Object.Destroy(this.m_objGuildListRoot.transform.GetChild(i).gameObject);
			}
			this.m_nCurrentStart = start;
			this.m_nTotalCount = totalNum;
			int num = guilds.Length;
			if (num > 10)
			{
				num = 10;
			}
			for (int j = 0; j < num; j++)
			{
				GuildEntry guildEntry = guilds[j];
				GuildData guildData = new GuildData();
				guildData.uGUID = guildEntry.id;
				guildData.nLevel = (int)guildEntry.level;
				guildData.nMemberCount = (int)guildEntry.memberNum;
				guildData.nMemberMaxCount = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(guildData.nLevel, string.Empty, string.Empty).MemberNum;
				guildData.strDeclaration = guildEntry.declaration;
				guildData.strLeaderName = guildEntry.leaderName;
				guildData.strName = guildEntry.name;
				guildData.bHasApplied = (guildEntry.isRequested != 0);
				guildData.leaderID = guildEntry.leaderId;
				guildData.occupyCrossTerrId = (int)guildEntry.occupyCrossTerrId;
				guildData.occupyTerrId = (int)guildEntry.occupyTerrId;
				guildData.joinLevel = guildEntry.joinLevel;
				RelationData relationData = null;
				DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(guildEntry.id, ref relationData);
				if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
				{
					guildData.remark = relationData.remark;
				}
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_objGuildTemplate);
				gameObject.transform.SetParent(this.m_objGuildListRoot.transform, false);
				gameObject.SetActive(true);
				GuildListFrame.GuildInfo guildInfo = new GuildListFrame.GuildInfo();
				guildInfo.data = guildData;
				guildInfo.objApplied = Utility.FindGameObject(gameObject, "Tag/Image", true);
				guildInfo.labName = Utility.GetComponetInChild<Text>(gameObject, "Name/Text");
				guildInfo.labLevel = Utility.GetComponetInChild<Text>(gameObject, "Level/Text");
				guildInfo.labMemberCount = Utility.GetComponetInChild<Text>(gameObject, "Count/Text");
				guildInfo.labLeader = Utility.GetComponetInChild<Text>(gameObject, "Leader/Text");
				guildInfo.objAgree = Utility.FindGameObject(gameObject, "Agree", true);
				this.m_arrGuildInfos.Add(guildInfo);
				GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
				if (myGuild != null)
				{
					if (myGuild.mergerRequestType == 1)
					{
						guildInfo.objApplied.SetActive(guildData.bHasApplied);
						guildInfo.objAgree.SetActive(false);
					}
					else if (myGuild.mergerRequestType == 2)
					{
						guildInfo.objAgree.SetActive(guildData.bHasApplied);
						guildInfo.objApplied.SetActive(false);
					}
					else
					{
						guildInfo.objApplied.SetActive(guildData.bHasApplied);
						guildInfo.objAgree.SetActive(false);
					}
				}
				else if (this.eShowGuildType == EShowGuildType.CanMerged)
				{
					guildInfo.objApplied.SetActive(false);
					guildInfo.objAgree.SetActive(false);
				}
				else
				{
					guildInfo.objApplied.SetActive(guildData.bHasApplied);
					guildInfo.objAgree.SetActive(false);
				}
				guildInfo.labName.text = guildData.strName;
				guildInfo.labLevel.text = string.Format("Lv{0}", guildData.nLevel);
				guildInfo.labMemberCount.text = string.Format("{0}/{1}", guildData.nMemberCount, guildData.nMemberMaxCount);
				if (guildData.remark != null && relationData.remark != string.Empty)
				{
					guildInfo.labLeader.text = guildData.remark;
				}
				else
				{
					guildInfo.labLeader.text = guildData.strLeaderName;
				}
				this.m_uCurrGuildID = 0UL;
				Toggle component = gameObject.GetComponent<Toggle>();
				component.onValueChanged.RemoveAllListeners();
				component.onValueChanged.AddListener(delegate(bool var)
				{
					if (var)
					{
						this.m_labGuildDeclaration.text = guildInfo.data.strDeclaration;
						this.m_uCurrGuildID = guildInfo.data.uGUID;
						this.guildLv.SafeSetText(guildInfo.data.nLevel.ToString());
						this.leadName.SafeSetText(guildInfo.data.strLeaderName);
						this.memberInfo.SafeSetText(string.Format("{0}/{1}", guildInfo.data.nMemberCount, guildInfo.data.nMemberMaxCount));
						this.crossTerrName.SafeSetText(GuildDataManager.GetTerrName(guildInfo.data.occupyCrossTerrId));
						this.terrName.SafeSetText(GuildDataManager.GetTerrName(guildInfo.data.occupyTerrId));
						this.joinLv.SafeSetText(guildInfo.data.joinLevel.ToString());
						this.goGuildInfo.CustomActive(true);
						this._UpdateSelectGuildUI();
					}
				});
			}
			this._UpdatePage();
			this._UpdateSelectGuildUI();
		}

		// Token: 0x0600DE92 RID: 56978 RVA: 0x00389EE3 File Offset: 0x003882E3
		private void _OnRequestJoinAllSuccess(UIEvent a_event)
		{
			this._RequestGuildList(this.m_nCurrentStart, 10);
			this._UpdateJoinAll();
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_request_join_all_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0600DE93 RID: 56979 RVA: 0x00389F09 File Offset: 0x00388309
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildListFrame>(this, false);
		}

		// Token: 0x0600DE94 RID: 56980 RVA: 0x00389F18 File Offset: 0x00388318
		private void _OnRequestJoinSuccess(UIEvent a_event)
		{
			ulong a_uGUID = (ulong)a_event.Param1;
			GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(a_uGUID);
			if (guildInfo != null)
			{
				guildInfo.data.bHasApplied = true;
				guildInfo.objApplied.SetActive(true);
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_request_join_success", guildInfo.data.strName), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600DE95 RID: 56981 RVA: 0x00389F74 File Offset: 0x00388374
		private void _OnInputPageNumChange(UIEvent a_event)
		{
			if (this.InputPage != null)
			{
				int num = this.m_nTotalCount / 10;
				if (this.m_nTotalCount % 10 > 0)
				{
					num++;
				}
				int num2 = Utility.ToInt(this.InputPage.textComponent.text);
				if (num2 > num)
				{
					this.InputPage.textComponent.text = num.ToString();
				}
			}
		}

		// Token: 0x0600DE96 RID: 56982 RVA: 0x00389FE9 File Offset: 0x003883E9
		private void _OnVirtualInputEnsure(UIEvent a_event)
		{
			this.RequestGuildListByInput();
		}

		// Token: 0x0600DE97 RID: 56983 RVA: 0x00389FF4 File Offset: 0x003883F4
		private void _OnRequestGuildMergerSucess(UIEvent uiEvent)
		{
			GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
			byte b = (byte)uiEvent.Param1;
			if (guildInfo != null)
			{
				bool flag = b == 0;
				guildInfo.data.bHasApplied = flag;
				guildInfo.objApplied.CustomActive(flag);
				guildInfo.objAgree.CustomActive(false);
				this.mMergeBtn.CustomActive(!flag);
				if (this.mMergeBtnGray != null)
				{
					this.mMergeBtnGray.enabled = false;
					this.mMergeBtnGray.SetEnable(false);
				}
				this.mCancelMergeBtn.CustomActive(flag);
				if (flag)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guildmerge_applySuceess", guildInfo.data.strName), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guildmerge_cancelapplySuceess", guildInfo.data.strName), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}
		}

		// Token: 0x0600DE98 RID: 56984 RVA: 0x0038A0CE File Offset: 0x003884CE
		private void _UpdateJoinAll()
		{
			this.m_comJoinAllBtnEnable.SetEnable(DataManager<GuildDataManager>.GetInstance().canJoinAllGuild);
		}

		// Token: 0x0600DE99 RID: 56985 RVA: 0x0038A0E8 File Offset: 0x003884E8
		private void _UpdateSelectGuildUI()
		{
			GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
			UIGray uigray = this.ContactGuildLeader.gameObject.SafeAddComponent(false);
			if (uigray != null)
			{
				uigray.SetEnable(false);
				uigray.SetEnable(guildInfo == null);
			}
			if (this.ContactGuildLeader != null)
			{
				this.ContactGuildLeader.interactable = (guildInfo != null);
			}
			this.goGuildInfo.CustomActive(guildInfo != null);
			this.m_labGuildDeclaration.CustomActive(guildInfo != null);
			if (this.eShowGuildType == EShowGuildType.All)
			{
				if (this.m_comJoinBtnEnable != null)
				{
					this.m_comJoinBtnEnable.SetEnable(false);
					this.m_comJoinBtnEnable.SetEnable(guildInfo == null);
				}
				Button button = this.m_comJoinBtnEnable.gameObject.SafeAddComponent(false);
				if (button != null)
				{
					button.interactable = (guildInfo != null);
				}
				this.mMembersBtn.CustomActive(false);
				this.mMergeBtn.CustomActive(false);
				this.mCancelMergeBtn.CustomActive(false);
			}
			else if (this.eShowGuildType == EShowGuildType.CanMerged)
			{
				this.m_comJoinBtnEnable.CustomActive(false);
				this.m_comJoinBtnEnable.CustomActive(false);
				this.mMembersBtn.CustomActive(true);
				if (guildInfo != null && guildInfo.data != null)
				{
					this.mMergeBtn.CustomActive(!guildInfo.data.bHasApplied);
					this.mCancelMergeBtn.CustomActive(guildInfo.data.bHasApplied);
				}
				else
				{
					this.mMergeBtn.CustomActive(true);
					this.mCancelMergeBtn.CustomActive(false);
				}
				if (this.mMembersBtnGray != null)
				{
					this.mMembersBtnGray.enabled = (guildInfo == null);
					this.mMembersBtnGray.SetEnable(guildInfo == null);
				}
				if (this.mMembersBtn != null)
				{
					this.mMembersBtn.interactable = (guildInfo != null);
				}
				if (this.mMergeBtnGray != null)
				{
					this.mMergeBtnGray.enabled = (guildInfo == null);
					this.mMergeBtnGray.SetEnable(guildInfo == null);
				}
				if (this.mMergeBtn != null)
				{
					this.mMergeBtn.interactable = (guildInfo != null);
				}
			}
		}

		// Token: 0x0600DE9A RID: 56986 RVA: 0x0038A334 File Offset: 0x00388734
		private GuildListFrame.GuildInfo _GetGuildInfo(ulong a_uGUID)
		{
			return this.m_arrGuildInfos.Find((GuildListFrame.GuildInfo value) => value.data.uGUID == a_uGUID);
		}

		// Token: 0x0600DE9B RID: 56987 RVA: 0x0038A368 File Offset: 0x00388768
		[UIEventHandle("List/Page/LeftPage")]
		private void _OnLeftPageClicked()
		{
			int num = this.m_nCurrentStart + 1;
			int num2 = num / 10;
			if (num % 10 > 0)
			{
				num2++;
			}
			num2--;
			if (num2 < 1)
			{
				return;
			}
			this._RequestGuildList((num2 - 1) * 10, 10);
		}

		// Token: 0x0600DE9C RID: 56988 RVA: 0x0038A3AC File Offset: 0x003887AC
		[UIEventHandle("List/Page/RightPage")]
		private void _OnRightPageClicked()
		{
			int num = this.m_nCurrentStart + 1;
			int num2 = num / 10;
			if (num % 10 > 0)
			{
				num2++;
			}
			num2++;
			int num3 = this.m_nTotalCount / 10;
			if (this.m_nTotalCount % 10 > 0)
			{
				num3++;
			}
			if (num2 > num3)
			{
				return;
			}
			this._RequestGuildList((num2 - 1) * 10, 10);
		}

		// Token: 0x0600DE9D RID: 56989 RVA: 0x0038A40C File Offset: 0x0038880C
		[UIEventHandle("JoinGuild/Funcs/Create")]
		private void _OnCreateGuildClicked()
		{
			this.frameMgr.OpenFrame<GuildCreateFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DE9E RID: 56990 RVA: 0x0038A424 File Offset: 0x00388824
		[UIEventHandle("JoinGuild/Funcs/Join")]
		private void _OnJoinGuildClicked()
		{
			GuildListFrame.GuildInfo guildInfo = this._GetGuildInfo(this.m_uCurrGuildID);
			if (guildInfo != null)
			{
				DataManager<GuildDataManager>.GetInstance().RequestJoinGuild(guildInfo.data.uGUID);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_please_select_one_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600DE9F RID: 56991 RVA: 0x0038A46E File Offset: 0x0038886E
		[UIEventHandle("JoinGuild/Funcs/JoinAll")]
		private void _OnJoinAllGuildClicked()
		{
			DataManager<GuildDataManager>.GetInstance().RequestJoinAllGuild();
		}

		// Token: 0x0600DEA0 RID: 56992 RVA: 0x0038A47A File Offset: 0x0038887A
		[UIEventHandle("Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildListFrame>(this, false);
		}

		// Token: 0x0600DEA1 RID: 56993 RVA: 0x0038A48C File Offset: 0x0038888C
		private void RequestGuildListByInput()
		{
			if (this.InputPage != null)
			{
				if (string.IsNullOrEmpty(this.InputPage.textComponent.text))
				{
					SystemNotifyManager.SystemNotify(9980, string.Empty);
					return;
				}
				int num = 0;
				int.TryParse(this.InputPage.textComponent.text, out num);
				if (num == 0)
				{
					this._UpdatePage();
				}
				else
				{
					this._RequestGuildList((num - 1) * 10, 10);
				}
			}
		}

		// Token: 0x0600DEA2 RID: 56994 RVA: 0x0038A50D File Offset: 0x0038890D
		private void OnMemberstbClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildOtherMemberFrame>(FrameLayer.Middle, this.m_uCurrGuildID, string.Empty);
		}

		// Token: 0x0600DEA3 RID: 56995 RVA: 0x0038A52B File Offset: 0x0038892B
		private void OnMergeBtnClick()
		{
			if (DataManager<GuildDataManager>.GetInstance().GuildMemberIsEnoughMegrge())
			{
				DataManager<GuildDataManager>.GetInstance().RequestGuildMergeOp(this.m_uCurrGuildID, 0);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildmerge_menbersOver"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600DEA4 RID: 56996 RVA: 0x0038A564 File Offset: 0x00388964
		private void OnCancelMergerClick()
		{
			GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
			if (myGuild != null)
			{
				if (myGuild.mergerRequestType == 2)
				{
					CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
					{
						ContentLabel = TR.Value("guildmerge_cancelmergerContent"),
						IsShowNotify = false,
						LeftButtonText = TR.Value("guildmerge_cancelmergerContent_Cancel"),
						RightButtonText = TR.Value("guildmerge_cancelmergerContent_OK"),
						OnRightButtonClickCallBack = new Action(this.OnAgree)
					};
					SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
				}
				else
				{
					DataManager<GuildDataManager>.GetInstance().RequestGuildMergeOp(this.m_uCurrGuildID, 1);
				}
			}
		}

		// Token: 0x0600DEA5 RID: 56997 RVA: 0x0038A5FB File Offset: 0x003889FB
		private void OnAgree()
		{
			DataManager<GuildDataManager>.GetInstance().RequestGuildMergeOp(this.m_uCurrGuildID, 1);
		}

		// Token: 0x040083DA RID: 33754
		[UIObject("List/Content")]
		private GameObject m_objGuildListRoot;

		// Token: 0x040083DB RID: 33755
		[UIObject("List/Template")]
		private GameObject m_objGuildTemplate;

		// Token: 0x040083DC RID: 33756
		[UIControl("List/Page/LeftPage", typeof(ComButtonEnbale), 0)]
		private ComButtonEnbale m_comLeftPageBtnEnable;

		// Token: 0x040083DD RID: 33757
		[UIControl("List/Page/RightPage", typeof(ComButtonEnbale), 0)]
		private ComButtonEnbale m_comRightPageBtnEnable;

		// Token: 0x040083DE RID: 33758
		[UIControl("List/Page/Text", null, 0)]
		private Text m_labPage;

		// Token: 0x040083DF RID: 33759
		[UIControl("JoinGuild/Content/Text", null, 0)]
		private Text m_labGuildDeclaration;

		// Token: 0x040083E0 RID: 33760
		[UIControl("JoinGuild/Funcs/Create", typeof(ComButtonEnbale), 0)]
		private ComButtonEnbale m_comCreateBtnEnable;

		// Token: 0x040083E1 RID: 33761
		[UIControl("JoinGuild/Funcs/Join", typeof(UIGray), 0)]
		private UIGray m_comJoinBtnEnable;

		// Token: 0x040083E2 RID: 33762
		[UIControl("JoinGuild/Funcs/JoinAll", null, 0)]
		private ComButtonEnbale m_comJoinAllBtnEnable;

		// Token: 0x040083E3 RID: 33763
		private Button JumpTo;

		// Token: 0x040083E4 RID: 33764
		private InputField InputPage;

		// Token: 0x040083E5 RID: 33765
		private Text guildLv;

		// Token: 0x040083E6 RID: 33766
		private Text leadName;

		// Token: 0x040083E7 RID: 33767
		private Text fund;

		// Token: 0x040083E8 RID: 33768
		private Text memberInfo;

		// Token: 0x040083E9 RID: 33769
		private Text crossTerrName;

		// Token: 0x040083EA RID: 33770
		private Text terrName;

		// Token: 0x040083EB RID: 33771
		private Text joinLv;

		// Token: 0x040083EC RID: 33772
		private Button btLookUp;

		// Token: 0x040083ED RID: 33773
		private GameObject goGuildInfo;

		// Token: 0x040083EE RID: 33774
		private Button ContactGuildLeader;

		// Token: 0x040083EF RID: 33775
		private Button mMergeBtn;

		// Token: 0x040083F0 RID: 33776
		private UIGray mMergeBtnGray;

		// Token: 0x040083F1 RID: 33777
		private Button mCancelMergeBtn;

		// Token: 0x040083F2 RID: 33778
		private Button mMembersBtn;

		// Token: 0x040083F3 RID: 33779
		private UIGray mMembersBtnGray;

		// Token: 0x040083F4 RID: 33780
		private Text mTitleTxt;

		// Token: 0x040083F5 RID: 33781
		private int m_nCurrentStart = -1;

		// Token: 0x040083F6 RID: 33782
		private int m_nTotalCount;

		// Token: 0x040083F7 RID: 33783
		private const int m_nPerPageCount = 10;

		// Token: 0x040083F8 RID: 33784
		private ulong m_uCurrGuildID;

		// Token: 0x040083F9 RID: 33785
		private const string mTitleDes1 = "公会信息";

		// Token: 0x040083FA RID: 33786
		private const string mTitleDes2 = "公会兼并";

		// Token: 0x040083FB RID: 33787
		private List<GuildListFrame.GuildInfo> m_arrGuildInfos = new List<GuildListFrame.GuildInfo>();

		// Token: 0x040083FC RID: 33788
		private EShowGuildType eShowGuildType;

		// Token: 0x02001626 RID: 5670
		private class GuildInfo
		{
			// Token: 0x040083FD RID: 33789
			public GuildData data;

			// Token: 0x040083FE RID: 33790
			public GameObject objApplied;

			// Token: 0x040083FF RID: 33791
			public GameObject objAgree;

			// Token: 0x04008400 RID: 33792
			public Text labName;

			// Token: 0x04008401 RID: 33793
			public Text labLevel;

			// Token: 0x04008402 RID: 33794
			public Text labMemberCount;

			// Token: 0x04008403 RID: 33795
			public Text labLeader;
		}
	}
}
