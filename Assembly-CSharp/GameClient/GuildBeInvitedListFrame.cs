using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F8 RID: 5624
	internal class GuildBeInvitedListFrame : ClientFrame
	{
		// Token: 0x0600DC6C RID: 56428 RVA: 0x0037A9C9 File Offset: 0x00378DC9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamBeInvitedListFrame";
		}

		// Token: 0x0600DC6D RID: 56429 RVA: 0x0037A9D0 File Offset: 0x00378DD0
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamNewInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			this.InitMainTabUIList();
			this.InitInterface();
		}

		// Token: 0x0600DC6E RID: 56430 RVA: 0x0037AA20 File Offset: 0x00378E20
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamNewInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			this.ClearData();
			this.UnInitMainTabUIList();
		}

		// Token: 0x0600DC6F RID: 56431 RVA: 0x0037AA70 File Offset: 0x00378E70
		private void InitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				this.mMainTabs.Initialize();
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600DC70 RID: 56432 RVA: 0x0037AAE8 File Offset: 0x00378EE8
		private void UnInitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600DC71 RID: 56433 RVA: 0x0037AB54 File Offset: 0x00378F54
		private TeamInvitedTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TeamInvitedTabItem>();
		}

		// Token: 0x0600DC72 RID: 56434 RVA: 0x0037AB5C File Offset: 0x00378F5C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TeamInvitedTabItem teamInvitedTabItem = item.gameObjectBindScript as TeamInvitedTabItem;
			if (teamInvitedTabItem != null && item.m_index >= 0 && item.m_index < this.mMainTabDataList.Count)
			{
				InvitedTabData invitedTabData = this.mMainTabDataList[item.m_index];
				if (this.invitedTabType != InvitedTabType.ITT_None)
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), invitedTabData.mInvitedTabType == this.invitedTabType);
				}
				else
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), item.m_index == 0);
				}
			}
		}

		// Token: 0x0600DC73 RID: 56435 RVA: 0x0037AC02 File Offset: 0x00379002
		private void OnInvitedTabClick(InvitedTabData invitedTabData)
		{
			if (invitedTabData == null)
			{
				return;
			}
			this.invitedTabType = invitedTabData.mInvitedTabType;
			this.UpdateEleObjList();
		}

		// Token: 0x0600DC74 RID: 56436 RVA: 0x0037AC20 File Offset: 0x00379020
		private void OnNewInviteNoticeUpdate(UIEvent iEvent)
		{
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (inviteTeamList.Count <= 0)
			{
				this.invitedTabType = InvitedTabType.ITT_None;
			}
			this.UpdateMainTabList();
			this.UpdateEleObjList();
		}

		// Token: 0x0600DC75 RID: 56437 RVA: 0x0037AC58 File Offset: 0x00379058
		private void ClearData()
		{
			for (int i = 0; i < this.EleObjList.Count; i++)
			{
				if (!(this.EleObjList[i] == null))
				{
					ComCommonBind component = this.EleObjList[i].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						GameObject gameObject = component.GetGameObject("BtReject");
						gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
						GameObject gameObject2 = component.GetGameObject("BtAgree");
						gameObject2.GetComponent<Button>().onClick.RemoveAllListeners();
					}
				}
			}
			this.EleObjList.Clear();
			this.invitedTabType = InvitedTabType.ITT_None;
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
		}

		// Token: 0x0600DC76 RID: 56438 RVA: 0x0037AD20 File Offset: 0x00379120
		private void OnReject(int index)
		{
			if (this.invitedTabType == InvitedTabType.ITT_Team)
			{
				NetManager netManager = NetManager.Instance();
				List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
				if (index < 0 || index > inviteTeamList.Count)
				{
					return;
				}
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, new SceneReply
				{
					result = 0,
					type = 1,
					requester = (ulong)inviteTeamList[index].baseinfo.teamId
				});
				inviteTeamList.RemoveAt(index);
				if (inviteTeamList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			else
			{
				List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
				if (index < 0 || index > guildInviteList.Count)
				{
					return;
				}
				guildInviteList.RemoveAt(index);
				if (guildInviteList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			this.UpdateEleObjList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
			if (DataManager<TeamDataManager>.GetInstance().GetInviteTeamList().Count <= 0 && DataManager<GuildDataManager>.GetInstance().GuildInviteList.Count <= 0)
			{
				this.frameMgr.CloseFrame<GuildBeInvitedListFrame>(this, false);
			}
		}

		// Token: 0x0600DC77 RID: 56439 RVA: 0x0037AE50 File Offset: 0x00379250
		private void OnAgree(int index)
		{
			if (this.invitedTabType == InvitedTabType.ITT_Team)
			{
				if (PkWaitingRoom.bBeginSeekPlayer)
				{
					SystemNotifyManager.SystemNotify(4004, string.Empty);
					return;
				}
				List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
				if (index < 0 || index > inviteTeamList.Count)
				{
					return;
				}
				SceneReply sceneReply = new SceneReply();
				sceneReply.result = 1;
				sceneReply.type = 1;
				sceneReply.requester = (ulong)inviteTeamList[index].baseinfo.teamId;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
				inviteTeamList.RemoveAt(index);
				if (inviteTeamList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			else
			{
				List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
				if (index < 0 || index > guildInviteList.Count)
				{
					return;
				}
				DataManager<GuildDataManager>.GetInstance().RequestJoinGuild(guildInviteList[index].guildId);
				guildInviteList.RemoveAt(index);
				if (guildInviteList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			this.UpdateEleObjList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
			if (this.invitedTabType == InvitedTabType.ITT_Team || (DataManager<GuildDataManager>.GetInstance().GuildInviteList.Count <= 0 && DataManager<TeamDataManager>.GetInstance().GetInviteTeamList().Count <= 0))
			{
				this.frameMgr.CloseFrame<GuildBeInvitedListFrame>(this, false);
			}
		}

		// Token: 0x0600DC78 RID: 56440 RVA: 0x0037AFBA File Offset: 0x003793BA
		private void InitInterface()
		{
			if (this.mTitle != null)
			{
				this.mTitle.text = "邀请列表";
			}
			this.UpdateMainTabList();
		}

		// Token: 0x0600DC79 RID: 56441 RVA: 0x0037AFE4 File Offset: 0x003793E4
		private void UpdateMainTabList()
		{
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
			for (int i = 0; i < 5; i++)
			{
				if (i == 3)
				{
					int count = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList().Count;
					if (count > 0)
					{
						InvitedTabData invitedTabData = new InvitedTabData();
						invitedTabData.mInvitedTabType = InvitedTabType.ITT_Team;
						invitedTabData.mTabName = "组队";
						this.mMainTabDataList.Add(invitedTabData);
					}
				}
				if (i == 4)
				{
					int count = DataManager<GuildDataManager>.GetInstance().GuildInviteList.Count;
					if (count > 0)
					{
						InvitedTabData invitedTabData2 = new InvitedTabData();
						invitedTabData2.mInvitedTabType = InvitedTabType.ITT_Guild;
						invitedTabData2.mTabName = "公会";
						this.mMainTabDataList.Add(invitedTabData2);
					}
				}
			}
			this.mMainTabs.SetElementAmount(this.mMainTabDataList.Count);
		}

		// Token: 0x0600DC7A RID: 56442 RVA: 0x0037B0B8 File Offset: 0x003794B8
		private void UpdateEleObjList()
		{
			int count;
			if (this.invitedTabType == InvitedTabType.ITT_Team)
			{
				count = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList().Count;
			}
			else
			{
				count = DataManager<GuildDataManager>.GetInstance().GuildInviteList.Count;
			}
			if (count > this.EleObjList.Count)
			{
				int num = count - this.EleObjList.Count;
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.BeInvitedListElePath, true, 0U);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.mEleRoot, false);
						this.EleObjList.Add(gameObject);
					}
				}
			}
			for (int j = 0; j < this.EleObjList.Count; j++)
			{
				if (j < count)
				{
					ComCommonBind component = this.EleObjList[j].GetComponent<ComCommonBind>();
					if (component == null)
					{
						this.EleObjList[j].SetActive(false);
					}
					else
					{
						GameObject gameObject2 = component.GetGameObject("Icon");
						Image component2 = gameObject2.GetComponent<Image>();
						GameObject gameObject3 = component.GetGameObject("LevelBack");
						GameObject gameObject4 = component.GetGameObject("Name");
						GameObject gameObject5 = component.GetGameObject("Level");
						GameObject gameObject6 = component.GetGameObject("Target");
						GameObject gameObject7 = component.GetGameObject("BtReject");
						GameObject gameObject8 = component.GetGameObject("BtAgree");
						Text component3 = gameObject4.GetComponent<Text>();
						if (this.invitedTabType == InvitedTabType.ITT_Team)
						{
							List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
							component3.text = string.Format("{0}  ({1}/{2})", inviteTeamList[j].baseinfo.masterInfo.name, inviteTeamList[j].baseinfo.memberNum, inviteTeamList[j].baseinfo.maxMemberNum);
							RelationData relationData = null;
							DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(inviteTeamList[j].baseinfo.masterInfo.id, ref relationData);
							if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
							{
								component3.text = string.Format("{0}  ({1}/{2})", relationData.remark, inviteTeamList[j].baseinfo.memberNum, inviteTeamList[j].baseinfo.maxMemberNum);
							}
							gameObject5.GetComponent<Text>().text = string.Format("Lv.{0}", inviteTeamList[j].baseinfo.masterInfo.level);
							int occu = (int)inviteTeamList[j].baseinfo.masterInfo.occu;
							TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)inviteTeamList[j].baseinfo.target, string.Empty, string.Empty);
							if (tableItem != null)
							{
								gameObject6.GetComponent<Text>().text = string.Format("目标:{0}", tableItem.Name);
							}
							JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occu, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								ResTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem2.Mode, string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									ETCImageLoader.LoadSprite(ref component2, tableItem3.IconPath, true);
								}
							}
							gameObject3.gameObject.SetActive(true);
						}
						else
						{
							List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
							ETCImageLoader.LoadSprite(ref component2, "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Gonghui", true);
							component3.text = string.Format("{0}邀请你加入", guildInviteList[j].inviterName);
							gameObject6.GetComponent<Text>().text = string.Format("[{0}]公会", guildInviteList[j].guildName);
							gameObject3.gameObject.SetActive(false);
						}
						Button component4 = gameObject7.GetComponent<Button>();
						component4.onClick.RemoveAllListeners();
						int index = j;
						component4.onClick.AddListener(delegate()
						{
							this.OnReject(index);
						});
						Button component5 = gameObject8.GetComponent<Button>();
						component5.onClick.RemoveAllListeners();
						int iIndex = j;
						component5.onClick.AddListener(delegate()
						{
							this.OnAgree(iIndex);
						});
						this.EleObjList[j].SetActive(true);
					}
				}
				else
				{
					this.EleObjList[j].SetActive(false);
				}
			}
		}

		// Token: 0x0600DC7B RID: 56443 RVA: 0x0037B55C File Offset: 0x0037995C
		protected override void _bindExUI()
		{
			this.mBtRejectAll = this.mBind.GetCom<Button>("BtRejectAll");
			this.mBtRejectAll.onClick.AddListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mEleRoot = this.mBind.GetGameObject("EleRoot");
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mMainTabs = this.mBind.GetCom<ComUIListScript>("MainTabs");
		}

		// Token: 0x0600DC7C RID: 56444 RVA: 0x0037B610 File Offset: 0x00379A10
		protected override void _unbindExUI()
		{
			this.mBtRejectAll.onClick.RemoveListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mBtRejectAll = null;
			this.mEleRoot = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTitle = null;
			this.mMainTabs = null;
		}

		// Token: 0x0600DC7D RID: 56445 RVA: 0x0037B678 File Offset: 0x00379A78
		private void _onBtRejectAllButtonClick()
		{
			if (this.invitedTabType == InvitedTabType.ITT_Team)
			{
				NetManager netManager = NetManager.Instance();
				List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
				for (int i = 0; i < inviteTeamList.Count; i++)
				{
					netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, new SceneReply
					{
						type = 1,
						requester = (ulong)inviteTeamList[i].baseinfo.teamId,
						result = 0
					});
				}
				inviteTeamList.Clear();
			}
			else
			{
				List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
				guildInviteList.Clear();
			}
			this.invitedTabType = InvitedTabType.ITT_None;
			this.UpdateEleObjList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
			List<NewTeamInviteList> inviteTeamList2 = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			List<WorldGuildInviteNotify> guildInviteList2 = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
			if (inviteTeamList2.Count <= 0 && guildInviteList2.Count <= 0)
			{
				this.frameMgr.CloseFrame<GuildBeInvitedListFrame>(this, false);
			}
		}

		// Token: 0x0600DC7E RID: 56446 RVA: 0x0037B76B File Offset: 0x00379B6B
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<GuildBeInvitedListFrame>(this, false);
		}

		// Token: 0x0400820E RID: 33294
		private string BeInvitedListElePath = "UIFlatten/Prefabs/Team/TeamBeInvitedEle";

		// Token: 0x0400820F RID: 33295
		private List<GameObject> EleObjList = new List<GameObject>();

		// Token: 0x04008210 RID: 33296
		private InvitedTabType invitedTabType;

		// Token: 0x04008211 RID: 33297
		private List<InvitedTabData> mMainTabDataList = new List<InvitedTabData>();

		// Token: 0x04008212 RID: 33298
		private Button mBtRejectAll;

		// Token: 0x04008213 RID: 33299
		private GameObject mEleRoot;

		// Token: 0x04008214 RID: 33300
		private Button mBtClose;

		// Token: 0x04008215 RID: 33301
		public Text mTitle;

		// Token: 0x04008216 RID: 33302
		private ComUIListScript mMainTabs;
	}
}
