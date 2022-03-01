using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001643 RID: 5699
	public class GuildOtherMemberFrame : ClientFrame
	{
		// Token: 0x0600E03F RID: 57407 RVA: 0x003950FF File Offset: 0x003934FF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildOtherMember";
		}

		// Token: 0x0600E040 RID: 57408 RVA: 0x00395108 File Offset: 0x00393508
		protected override void _OnOpenFrame()
		{
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
				this.m_arrSortInfos.Add(new GuildOtherMemberFrame.SortInfo());
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
			ulong guildID = (ulong)this.userData;
			DataManager<GuildDataManager>.GetInstance().RequestCanMergerdGuildMembers(guildID);
		}

		// Token: 0x0600E041 RID: 57409 RVA: 0x003954E1 File Offset: 0x003938E1
		protected override void _OnCloseFrame()
		{
			this.m_uCurrMemberID = 0UL;
			this.m_arrSortInfos.Clear();
			this._CloseMenu();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E042 RID: 57410 RVA: 0x00395502 File Offset: 0x00393902
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CanMergerdGuildMemberUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildMembersUpdate));
		}

		// Token: 0x0600E043 RID: 57411 RVA: 0x0039551F File Offset: 0x0039391F
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CanMergerdGuildMemberUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildMembersUpdate));
		}

		// Token: 0x0600E044 RID: 57412 RVA: 0x0039553C File Offset: 0x0039393C
		private void _DestroyGuildMemberInfo(ulong a_uGUID)
		{
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			int num = canMergerdGuildMembers.FindIndex((GuildMemberData value) => value.uGUID == a_uGUID);
			if (num >= 0 && num < canMergerdGuildMembers.Count)
			{
				canMergerdGuildMembers.RemoveAt(num);
			}
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E045 RID: 57413 RVA: 0x00395594 File Offset: 0x00393994
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

		// Token: 0x0600E046 RID: 57414 RVA: 0x00395638 File Offset: 0x00393A38
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
		}

		// Token: 0x0600E047 RID: 57415 RVA: 0x003957D8 File Offset: 0x00393BD8
		private void _CloseMenu()
		{
			this.m_objMenu.SetActive(false);
			for (int i = 0; i < this.m_arrMenuFuncs.Count; i++)
			{
				Object.Destroy(this.m_arrMenuFuncs[i]);
			}
			this.m_arrMenuFuncs.Clear();
		}

		// Token: 0x0600E048 RID: 57416 RVA: 0x0039582C File Offset: 0x00393C2C
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

		// Token: 0x0600E049 RID: 57417 RVA: 0x003958B0 File Offset: 0x00393CB0
		private void _OnMenuFuncWatch(ulong a_uGUID)
		{
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(a_uGUID, 0U, 0U);
			this._CloseMenu();
		}

		// Token: 0x0600E04A RID: 57418 RVA: 0x003958C5 File Offset: 0x00393CC5
		private void _OnMenuFuncAddFriend(ulong a_uGUID)
		{
			DataManager<RelationDataManager>.GetInstance().AddFriendByID(a_uGUID);
			this._CloseMenu();
		}

		// Token: 0x0600E04B RID: 57419 RVA: 0x003958D8 File Offset: 0x00393CD8
		private void _SortMembers(GuildOtherMemberFrame.EColType a_colType)
		{
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			int nIndex = (int)a_colType;
			if (nIndex >= 0 && nIndex < this.m_arrSortInfos.Count)
			{
				GuildOtherMemberFrame.SortInfo sortInfo = this.m_arrSortInfos[nIndex];
				sortInfo.bAscending = !sortInfo.bAscending;
				int nSign = (!sortInfo.bAscending) ? -1 : 1;
				canMergerdGuildMembers.Sort(delegate(GuildMemberData a_left, GuildMemberData a_right)
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
					if (num == 0)
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
					this.m_arrSortInfos[i].imgAscending.gameObject.SetActive(false);
				}
				this.m_arrSortInfos[nIndex].imgAscending.gameObject.SetActive(true);
				this.m_arrSortInfos[nIndex].imgAscending.transform.localRotation = ((!this.m_arrSortInfos[nIndex].bAscending) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 180f));
			}
		}

		// Token: 0x0600E04C RID: 57420 RVA: 0x00395A54 File Offset: 0x00393E54
		private void _OnGuildMembersUpdate(UIEvent a_event)
		{
			this.InitMemberScrollListBind();
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			this._SortMembers(GuildOtherMemberFrame.EColType.OfflineTime);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E04D RID: 57421 RVA: 0x00395A80 File Offset: 0x00393E80
		private void RefreshOnLineMembers()
		{
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			int num = 0;
			for (int i = 0; i < canMergerdGuildMembers.Count; i++)
			{
				string a = this._GetOfflineDesc((int)canMergerdGuildMembers[i].uOffLineTime);
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
				canMergerdGuildMembers.Count
			});
		}

		// Token: 0x0600E04E RID: 57422 RVA: 0x00395B1F File Offset: 0x00393F1F
		[UIEventHandle("ScrollView/Title/Job")]
		private void _OnTitleJobClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.Job);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E04F RID: 57423 RVA: 0x00395B2E File Offset: 0x00393F2E
		[UIEventHandle("ScrollView/Title/Name")]
		private void _OnTitleNameClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.Name);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E050 RID: 57424 RVA: 0x00395B3D File Offset: 0x00393F3D
		[UIEventHandle("ScrollView/Title/Level")]
		private void _OnTitleLevelClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.Level);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E051 RID: 57425 RVA: 0x00395B4C File Offset: 0x00393F4C
		[UIEventHandle("ScrollView/Title/Duty")]
		private void _OnTitleDutyClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.Duty);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E052 RID: 57426 RVA: 0x00395B5B File Offset: 0x00393F5B
		[UIEventHandle("ScrollView/Title/Contribution")]
		private void _OnTitleContributionClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.Contribution);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E053 RID: 57427 RVA: 0x00395B6A File Offset: 0x00393F6A
		[UIEventHandle("ScrollView/Title/OffLineTime")]
		private void _OnTitleOffLineTimeClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.OfflineTime);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E054 RID: 57428 RVA: 0x00395B79 File Offset: 0x00393F79
		[UIEventHandle("ScrollView/Title/Active")]
		private void _OnTitleActiveClicked()
		{
			this._SortMembers(GuildOtherMemberFrame.EColType.ActiveDegree);
			this.RefreshMemberListCount();
		}

		// Token: 0x0600E055 RID: 57429 RVA: 0x00395B88 File Offset: 0x00393F88
		protected override void _bindExUI()
		{
			this.mMemberList = this.mBind.GetCom<ComUIListScript>("MemberList");
			this.btnSortVipLv = this.mBind.GetCom<Button>("btnSortVipLv");
			this.btnSortVipLv.SafeAddOnClickListener(delegate
			{
				this._SortMembers(GuildOtherMemberFrame.EColType.VipLevel);
				this.RefreshMemberListCount();
			});
			this.btnSortSeasonLv = this.mBind.GetCom<Button>("btnSortSeasonLv");
			this.btnSortSeasonLv.SafeAddOnClickListener(delegate
			{
				this._SortMembers(GuildOtherMemberFrame.EColType.SeasonLv);
				this.RefreshMemberListCount();
			});
			this.mCloseBtn = this.mBind.GetCom<Button>("Close");
			this.mCloseBtn.SafeAddOnClickListener(new UnityAction(this.OnCloseBtnClick));
		}

		// Token: 0x0600E056 RID: 57430 RVA: 0x00395C32 File Offset: 0x00394032
		protected override void _unbindExUI()
		{
			this.mMemberList = null;
			this.btnSortVipLv = null;
			this.btnSortSeasonLv = null;
			this.mCloseBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mCloseBtn = null;
		}

		// Token: 0x0600E057 RID: 57431 RVA: 0x00395C68 File Offset: 0x00394068
		private void InitMemberScrollListBind()
		{
			this.mMemberList.Initialize();
			this.mMemberList.onItemChageDisplay = delegate(ComUIListElementScript item, bool bSelected)
			{
				List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
				if (item.m_index >= 0 && item.m_index < canMergerdGuildMembers.Count)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					GameObject gameObject = component.GetGameObject("Select");
					gameObject.CustomActive(false);
				}
			};
			this.mMemberList.onItemSelected = delegate(ComUIListElementScript item)
			{
				List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
				if (item.m_index >= 0 && item.m_index < canMergerdGuildMembers.Count)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					GameObject gameObject = component.GetGameObject("Select");
					gameObject.CustomActive(true);
				}
			};
			this.mMemberList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdateMemberScrollListBind(item);
				}
			};
			this.mMemberList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("Mask");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600E058 RID: 57432 RVA: 0x00395D10 File Offset: 0x00394110
		private void UpdateMemberScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			if (item.m_index < 0 || item.m_index >= canMergerdGuildMembers.Count)
			{
				return;
			}
			GuildMemberData MemData = canMergerdGuildMembers[item.m_index];
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
			com.text = Utility.GetJobName(MemData.nJobID, (int)MemData.playerLabelInfo.awakenStatus);
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

		// Token: 0x0600E059 RID: 57433 RVA: 0x00396100 File Offset: 0x00394500
		private void RefreshMemberListCount()
		{
			List<GuildMemberData> canMergerdGuildMembers = DataManager<GuildDataManager>.GetInstance().CanMergerdGuildMembers;
			this.mMemberList.SetElementAmount(canMergerdGuildMembers.Count);
			this.RefreshOnLineMembers();
		}

		// Token: 0x0600E05A RID: 57434 RVA: 0x0039612F File Offset: 0x0039452F
		private void OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildOtherMemberFrame>(null, false);
		}

		// Token: 0x0400854F RID: 34127
		[UIObject("Menu")]
		private GameObject m_objMenu;

		// Token: 0x04008550 RID: 34128
		[UIObject("ScrollView/Viewport/Content")]
		private GameObject m_objMemberRoot;

		// Token: 0x04008551 RID: 34129
		[UIObject("ScrollView/Viewport/Content/Template")]
		private GameObject m_objMemberTemplate;

		// Token: 0x04008552 RID: 34130
		[UIObject("Menu/Func")]
		private GameObject m_objMenuFuncTempLate;

		// Token: 0x04008553 RID: 34131
		[UIControl("CloseMenu", typeof(ComButtonEx), 0)]
		private ComButtonEx m_comBtnCloseMenu;

		// Token: 0x04008554 RID: 34132
		[UIControl("onLineCount", null, 0)]
		private Text onLineCountTexte;

		// Token: 0x04008555 RID: 34133
		private ulong m_uCurrMemberID;

		// Token: 0x04008556 RID: 34134
		private List<GameObject> m_arrMenuFuncs = new List<GameObject>();

		// Token: 0x04008557 RID: 34135
		private Color m_colorGray = new Color(0.654902f, 0.64705884f, 0.64705884f, 1f);

		// Token: 0x04008558 RID: 34136
		private Color m_colorNormal = new Color(0.65882355f, 0.74509805f, 0.7764706f, 1f);

		// Token: 0x04008559 RID: 34137
		private List<GuildOtherMemberFrame.SortInfo> m_arrSortInfos = new List<GuildOtherMemberFrame.SortInfo>();

		// Token: 0x0400855A RID: 34138
		private GuildOtherMemberFrame.EColType[] m_arrSortPriority = new GuildOtherMemberFrame.EColType[]
		{
			GuildOtherMemberFrame.EColType.OfflineTime,
			GuildOtherMemberFrame.EColType.Duty,
			GuildOtherMemberFrame.EColType.Contribution,
			GuildOtherMemberFrame.EColType.Level,
			GuildOtherMemberFrame.EColType.Name,
			GuildOtherMemberFrame.EColType.Job,
			GuildOtherMemberFrame.EColType.ActiveDegree,
			GuildOtherMemberFrame.EColType.VipLevel,
			GuildOtherMemberFrame.EColType.SeasonLv
		};

		// Token: 0x0400855B RID: 34139
		private ComUIListScript mMemberList;

		// Token: 0x0400855C RID: 34140
		private Button btnSortVipLv;

		// Token: 0x0400855D RID: 34141
		private Button btnSortSeasonLv;

		// Token: 0x0400855E RID: 34142
		private Button mCloseBtn;

		// Token: 0x02001644 RID: 5700
		private enum EColType
		{
			// Token: 0x0400856C RID: 34156
			Job,
			// Token: 0x0400856D RID: 34157
			Name,
			// Token: 0x0400856E RID: 34158
			Level,
			// Token: 0x0400856F RID: 34159
			Duty,
			// Token: 0x04008570 RID: 34160
			Contribution,
			// Token: 0x04008571 RID: 34161
			OfflineTime,
			// Token: 0x04008572 RID: 34162
			ActiveDegree,
			// Token: 0x04008573 RID: 34163
			VipLevel,
			// Token: 0x04008574 RID: 34164
			SeasonLv,
			// Token: 0x04008575 RID: 34165
			Count
		}

		// Token: 0x02001645 RID: 5701
		// (Invoke) Token: 0x0600E06D RID: 57453
		private delegate int CompareFunc(GuildMemberData a_left, GuildMemberData a_right);

		// Token: 0x02001646 RID: 5702
		private class SortInfo
		{
			// Token: 0x04008576 RID: 34166
			public bool bAscending = true;

			// Token: 0x04008577 RID: 34167
			public Image imgAscending;

			// Token: 0x04008578 RID: 34168
			public GuildOtherMemberFrame.CompareFunc delCompare;
		}

		// Token: 0x02001647 RID: 5703
		private class GuildMemberInfoGuildDataManager
		{
			// Token: 0x04008579 RID: 34169
			public GuildMemberData data;

			// Token: 0x0400857A RID: 34170
			public GameObject objRoot;

			// Token: 0x0400857B RID: 34171
			public GameObject objSelect;

			// Token: 0x0400857C RID: 34172
			public Text labJob;

			// Token: 0x0400857D RID: 34173
			public Text labName;

			// Token: 0x0400857E RID: 34174
			public Text labLevel;

			// Token: 0x0400857F RID: 34175
			public Text labDuty;

			// Token: 0x04008580 RID: 34176
			public Text labContribution;

			// Token: 0x04008581 RID: 34177
			public Text labOffline;

			// Token: 0x04008582 RID: 34178
			public Text labActiveDegree;
		}
	}
}
