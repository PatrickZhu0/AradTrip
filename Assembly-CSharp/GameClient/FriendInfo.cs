using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019EC RID: 6636
	internal class FriendInfo
	{
		// Token: 0x0601043C RID: 66620 RVA: 0x0048E7D8 File Offset: 0x0048CBD8
		public FriendInfo(ulong uid, string name, ushort lv, byte occu, byte giveNum, FriendListType type, byte isOnline, byte vipLv, uint seasonLv)
		{
			this.m_uid = uid;
			this.m_name = name;
			this.m_level = lv;
			this.m_occu = occu;
			this.m_giveNum = giveNum;
			this.m_isOnline = isOnline;
			this.m_vipLv = (ushort)vipLv;
			this.m_seasonLv = seasonLv;
			this.m_friendPrefab = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Friends/FriendInfo", enResourceType.UIPrefab, 2U);
			this.m_friendPrefab.SetActive(true);
			this.m_giveBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "Friend/Give", true);
			this.m_accBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "Invite/Accept", true);
			this.m_refBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "Invite/Refuse", true);
			this.m_delBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "Black/Del", true);
			this.m_chatBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "Chat", true);
			this.m_redPt = Utility.FindComponent<Image>(this.m_friendPrefab, "Chat/RedPt", true);
			this.m_redPt.gameObject.SetActive(false);
			this.m_secondInfoBtn = Utility.FindComponent<Toggle>(this.m_friendPrefab, "FriendBG", true);
			this.friendRoot = Utility.FindGameObject(this.m_friendPrefab, "Friend", true);
			this.inviteRoot = Utility.FindGameObject(this.m_friendPrefab, "Invite", true);
			this.blackRoot = Utility.FindGameObject(this.m_friendPrefab, "Black", true);
			this.m_giveBtn.onClick.AddListener(new UnityAction(this.OnClickGive));
			this.m_accBtn.onClick.AddListener(new UnityAction(this.OnClickAccept));
			this.m_refBtn.onClick.AddListener(new UnityAction(this.OnClickRefuse));
			this.m_delBtn.onClick.AddListener(new UnityAction(this.OnClickDel));
			this.m_chatBtn.onClick.AddListener(new UnityAction(this.OnClickChat));
			if (type == FriendListType.FLT_FRIEND || type == FriendListType.FLT_BLACK)
			{
				this.m_secondInfoBtn.onValueChanged.AddListener(new UnityAction<bool>(this.OnSecondInfo));
			}
			this.m_type = type;
			this.SetupInfo(type);
		}

		// Token: 0x17001D41 RID: 7489
		// (get) Token: 0x0601043D RID: 66621 RVA: 0x0048EA0A File Offset: 0x0048CE0A
		// (set) Token: 0x0601043E RID: 66622 RVA: 0x0048EA12 File Offset: 0x0048CE12
		private RelationData m_relationData
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}

		// Token: 0x0601043F RID: 66623 RVA: 0x0048EA1C File Offset: 0x0048CE1C
		~FriendInfo()
		{
			this.Finatial();
		}

		// Token: 0x06010440 RID: 66624 RVA: 0x0048EA4C File Offset: 0x0048CE4C
		public void SetRelationData(RelationData data)
		{
			this.m_relationData = data;
			if (this.m_relationData == null)
			{
				return;
			}
		}

		// Token: 0x06010441 RID: 66625 RVA: 0x0048EA61 File Offset: 0x0048CE61
		public void SetCustomParent(Transform tf)
		{
			this.m_friendPrefab.transform.SetParent(tf, false);
			this.m_secondInfoBtn.group = this.m_friendPrefab.GetComponentInParent<ToggleGroup>();
		}

		// Token: 0x06010442 RID: 66626 RVA: 0x0048EA8C File Offset: 0x0048CE8C
		public void Finatial()
		{
			this.m_giveBtn.onClick.RemoveListener(new UnityAction(this.OnClickGive));
			this.m_accBtn.onClick.RemoveListener(new UnityAction(this.OnClickAccept));
			this.m_refBtn.onClick.RemoveListener(new UnityAction(this.OnClickRefuse));
			this.m_delBtn.onClick.RemoveListener(new UnityAction(this.OnClickDel));
			this.m_chatBtn.onClick.RemoveListener(new UnityAction(this.OnClickChat));
			if (this.m_type == FriendListType.FLT_FRIEND || this.m_type == FriendListType.FLT_BLACK)
			{
				this.m_secondInfoBtn.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnSecondInfo));
			}
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_friendPrefab);
			this.m_giveBtn = null;
			this.m_accBtn = null;
			this.m_refBtn = null;
			this.m_delBtn = null;
			this.m_secondInfoBtn = null;
			this.m_relationData = null;
			this.friendRoot = null;
			this.inviteRoot = null;
			this.blackRoot = null;
		}

		// Token: 0x06010443 RID: 66627 RVA: 0x0048EBA8 File Offset: 0x0048CFA8
		private void SetupInfo(FriendListType type)
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)this.m_occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					Image image = Utility.FindComponent<Image>(this.m_friendPrefab, "Info/Mask/OccuHead", true);
					Utility.createSprite(tableItem.JobHalfBody, ref image);
					image.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
					image.gameObject.transform.localPosition += new Vector3((float)tableItem.OffSetXFriendInfo, 0f, 0f);
					UIGray uigray = Utility.FindComponent<UIGray>(this.m_friendPrefab, "Info/Mask/OccuHead", true);
					uigray.enabled = (this.m_isOnline <= 0);
				}
				Text text = Utility.FindComponent<Text>(this.m_friendPrefab, "Info/Title/Occu", true);
				text.text = tableItem.Name;
			}
			Text text2 = Utility.FindComponent<Text>(this.m_friendPrefab, "Info/Title/Name", true);
			text2.text = string.Format("{0}", this.m_name);
			Text text3 = Utility.FindComponent<Text>(this.m_friendPrefab, "Info/Lv", true);
			text3.text = string.Format("Lv.{0}", this.m_level);
			Text text4 = Utility.FindComponent<Text>(this.m_friendPrefab, "Info/VipLv", true);
			text4.text = string.Format("贵{0}", this.m_vipLv);
			Text text5 = Utility.FindComponent<Text>(this.m_friendPrefab, "Info/PkLv", true);
			text5.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)this.m_seasonLv, true);
			this.m_redPt.gameObject.SetActive(DataManager<RelationDataManager>.GetInstance().GetPriDirtyByUid(this.m_uid));
			this.SwitchType(type);
		}

		// Token: 0x06010444 RID: 66628 RVA: 0x0048ED90 File Offset: 0x0048D190
		public void ShowRedPoint()
		{
			this.m_redPt.gameObject.SetActive(true);
		}

		// Token: 0x06010445 RID: 66629 RVA: 0x0048EDA3 File Offset: 0x0048D1A3
		private bool CanGive()
		{
			return this.m_giveNum > 0;
		}

		// Token: 0x06010446 RID: 66630 RVA: 0x0048EDB4 File Offset: 0x0048D1B4
		private void SwitchType(FriendListType type)
		{
			this.m_chatBtn.gameObject.SetActive(false);
			if (type == FriendListType.FLT_FRIEND)
			{
				this.friendRoot.SetActive(true);
				this.inviteRoot.SetActive(false);
				this.blackRoot.SetActive(false);
				UIGray uigray = Utility.FindComponent<UIGray>(this.m_friendPrefab, "Friend/Give", true);
				uigray.enabled = !this.CanGive();
				Text text = Utility.FindComponent<Text>(this.m_friendPrefab, "Friend/Give/Text", true);
				if (this.CanGive())
				{
					text.text = "赠送礼物";
					this.m_giveBtn.enabled = true;
				}
				else
				{
					text.text = "已经赠送";
					this.m_giveBtn.enabled = false;
				}
				this.m_chatBtn.gameObject.SetActive(true);
			}
			else if (type == FriendListType.FLT_NOTIFY)
			{
				this.friendRoot.SetActive(false);
				this.inviteRoot.SetActive(true);
				this.blackRoot.SetActive(false);
			}
			else if (type == FriendListType.FLT_BLACK)
			{
				this.friendRoot.SetActive(false);
				this.inviteRoot.SetActive(false);
				this.blackRoot.SetActive(true);
			}
			else
			{
				this.friendRoot.SetActive(false);
				this.inviteRoot.SetActive(false);
				this.blackRoot.SetActive(false);
			}
		}

		// Token: 0x06010447 RID: 66631 RVA: 0x0048EF08 File Offset: 0x0048D308
		public void OnClickAccept()
		{
			SceneReply sceneReply = new SceneReply();
			sceneReply.type = 3;
			sceneReply.requester = this.m_uid;
			sceneReply.result = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
			DataManager<RelationDataManager>.GetInstance().DelInviter(this.m_uid);
		}

		// Token: 0x06010448 RID: 66632 RVA: 0x0048EF54 File Offset: 0x0048D354
		public void OnClickRefuse()
		{
			SceneReply sceneReply = new SceneReply();
			sceneReply.type = 3;
			sceneReply.requester = this.m_uid;
			sceneReply.result = 0;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
			DataManager<RelationDataManager>.GetInstance().DelInviter(this.m_uid);
		}

		// Token: 0x06010449 RID: 66633 RVA: 0x0048EFA0 File Offset: 0x0048D3A0
		private void OnClickGive()
		{
			WorldRelationPresentGiveReq worldRelationPresentGiveReq = new WorldRelationPresentGiveReq();
			worldRelationPresentGiveReq.friendUID = this.m_uid;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationPresentGiveReq>(ServerType.GATE_SERVER, worldRelationPresentGiveReq);
			UIGray uigray = Utility.FindComponent<UIGray>(this.m_friendPrefab, "Friend/Give", true);
			uigray.enabled = true;
			Text text = Utility.FindComponent<Text>(this.m_friendPrefab, "Friend/Give/Text", true);
			text.text = "已经赠送";
			this.m_giveBtn.enabled = false;
			RelationFrame relationFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(RelationFrame)) as RelationFrame;
			if (relationFrame != null)
			{
				relationFrame.GiveFriend = true;
			}
		}

		// Token: 0x0601044A RID: 66634 RVA: 0x0048F03C File Offset: 0x0048D43C
		private void OnClickDel()
		{
			string msgContent = string.Format("是否删除黑名单玩家?", new object[0]);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().DelBlack(this.m_uid);
			}, delegate()
			{
			}, 0f, false);
		}

		// Token: 0x0601044B RID: 66635 RVA: 0x0048F090 File Offset: 0x0048D490
		private void OnSecondInfo(bool bValue)
		{
			if (bValue)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				if (this.m_relationData == null)
				{
					return;
				}
				relationMenuData.m_data = this.m_relationData;
				relationMenuData.type = ((this.m_type != FriendListType.FLT_BLACK) ? CommonPlayerInfo.CommonPlayerType.CPT_COMMON : CommonPlayerInfo.CommonPlayerType.CPT_BLACK);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventShowFriendSecMenu(relationMenuData));
			}
		}

		// Token: 0x0601044C RID: 66636 RVA: 0x0048F0EC File Offset: 0x0048D4EC
		private void OnClickChat()
		{
			this.m_redPt.gameObject.SetActive(false);
			DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.m_relationData, false);
			DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(this.m_relationData);
			Singleton<ClientSystemManager>.instance.CloseFrame<RelationFrame>(null, false);
			UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.m_relationData, true));
		}

		// Token: 0x0400A4BC RID: 42172
		public GameObject m_friendPrefab;

		// Token: 0x0400A4BD RID: 42173
		private Button m_giveBtn;

		// Token: 0x0400A4BE RID: 42174
		private Button m_accBtn;

		// Token: 0x0400A4BF RID: 42175
		private Button m_refBtn;

		// Token: 0x0400A4C0 RID: 42176
		private Button m_delBtn;

		// Token: 0x0400A4C1 RID: 42177
		private Button m_chatBtn;

		// Token: 0x0400A4C2 RID: 42178
		private Image m_redPt;

		// Token: 0x0400A4C3 RID: 42179
		private Toggle m_secondInfoBtn;

		// Token: 0x0400A4C4 RID: 42180
		private GameObject friendRoot;

		// Token: 0x0400A4C5 RID: 42181
		private GameObject inviteRoot;

		// Token: 0x0400A4C6 RID: 42182
		private GameObject blackRoot;

		// Token: 0x0400A4C7 RID: 42183
		public ulong m_uid;

		// Token: 0x0400A4C8 RID: 42184
		public string m_name;

		// Token: 0x0400A4C9 RID: 42185
		public ushort m_level;

		// Token: 0x0400A4CA RID: 42186
		public ushort m_vipLv;

		// Token: 0x0400A4CB RID: 42187
		public byte m_occu;

		// Token: 0x0400A4CC RID: 42188
		public byte m_giveNum;

		// Token: 0x0400A4CD RID: 42189
		public byte m_isOnline;

		// Token: 0x0400A4CE RID: 42190
		public uint m_seasonLv;

		// Token: 0x0400A4CF RID: 42191
		private RelationData data;

		// Token: 0x0400A4D0 RID: 42192
		private FriendListType m_type;
	}
}
