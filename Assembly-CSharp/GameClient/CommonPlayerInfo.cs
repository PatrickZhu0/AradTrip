using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F3 RID: 6643
	internal class CommonPlayerInfo
	{
		// Token: 0x060104C0 RID: 66752 RVA: 0x00491408 File Offset: 0x0048F808
		public CommonPlayerInfo(ulong uid, string name, ushort lv, byte occu, CommonPlayerInfo.CommonPlayerType type, bool dirty, byte online, byte relationType, byte vipLv)
		{
			this.m_uid = uid;
			this.m_name = name;
			this.m_level = lv;
			this.m_occu = occu;
			this.m_type = type;
			this.m_vipLv = (ushort)vipLv;
			this.m_isOnline = online;
			this.m_relationType = relationType;
			this.m_friendPrefab = (Singleton<AssetLoader>.instance.LoadRes("UIFlatten/Prefabs/Common/ComPlayerInfo", true, 0U).obj as GameObject);
			this.m_friendPrefab.SetActive(true);
			this.m_addFriendBtn = Utility.FindComponent<Button>(this.m_friendPrefab, "AddFriend", true);
			this.m_menu = Utility.FindComponent<Button>(this.m_friendPrefab, "Menu", true);
			this.m_stranger = Utility.FindComponent<Text>(this.m_friendPrefab, "Stranger", true);
			this.m_button = Utility.FindComponent<Button>(this.m_friendPrefab, "Button", true);
			this.m_redPt = Utility.FindComponent<Image>(this.m_friendPrefab, "RedPt", true);
			this.m_redPt.gameObject.SetActive(dirty);
			this.m_button.onClick.AddListener(new UnityAction(this.OnClickButton));
			this.m_addFriendBtn.onClick.AddListener(new UnityAction(this.OnClickAddFriendBtn));
			this.m_menu.onClick.AddListener(new UnityAction(this.OnMenu));
			this.SetupInfo();
		}

		// Token: 0x060104C1 RID: 66753 RVA: 0x00491564 File Offset: 0x0048F964
		~CommonPlayerInfo()
		{
			this.Finatial();
		}

		// Token: 0x060104C2 RID: 66754 RVA: 0x00491594 File Offset: 0x0048F994
		public void Finatial()
		{
			this.m_addFriendBtn.onClick.RemoveListener(new UnityAction(this.OnClickAddFriendBtn));
			this.m_menu.onClick.RemoveListener(new UnityAction(this.OnMenu));
			this.m_friendPrefab = null;
			this.m_addFriendBtn = null;
		}

		// Token: 0x060104C3 RID: 66755 RVA: 0x004915E8 File Offset: 0x0048F9E8
		private void SetupInfo()
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)this.m_occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					Image image = Utility.FindComponent<Image>(this.m_friendPrefab, "Image", true);
					Utility.createSprite(tableItem2.IconPath, ref image);
					UIGray uigray = Utility.FindComponent<UIGray>(this.m_friendPrefab, "Image", true);
					uigray.enabled = (this.m_isOnline <= 0);
				}
				Text text = Utility.FindComponent<Text>(this.m_friendPrefab, "Job", true);
				text.text = tableItem.Name;
			}
			Text text2 = Utility.FindComponent<Text>(this.m_friendPrefab, "Name", true);
			text2.text = string.Format("{0}", this.m_name);
			Text text3 = Utility.FindComponent<Text>(this.m_friendPrefab, "Lv/LvText", true);
			text3.text = string.Format("Lv.{0}", this.m_level);
			Text text4 = Utility.FindComponent<Text>(this.m_friendPrefab, "VipLv", true);
			text4.text = string.Format("贵{0}", this.m_vipLv);
			this.SetupType();
		}

		// Token: 0x060104C4 RID: 66756 RVA: 0x00491730 File Offset: 0x0048FB30
		private void SetupType()
		{
			if (this.m_type == CommonPlayerInfo.CommonPlayerType.CPT_RECOMEND)
			{
				this.m_addFriendBtn.gameObject.SetActive(true);
				this.m_menu.gameObject.SetActive(false);
				this.m_stranger.gameObject.SetActive(false);
			}
			else if (this.m_type == CommonPlayerInfo.CommonPlayerType.CPT_COMMON)
			{
				this.m_addFriendBtn.gameObject.SetActive(false);
				this.m_menu.gameObject.SetActive(true);
				this.m_stranger.gameObject.SetActive(false);
			}
			else if (this.m_type == CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT)
			{
				this.m_addFriendBtn.gameObject.SetActive(false);
				this.m_menu.gameObject.SetActive(true);
				this.m_stranger.gameObject.SetActive(this.m_relationType == 3);
			}
		}

		// Token: 0x060104C5 RID: 66757 RVA: 0x00491818 File Offset: 0x0048FC18
		public void OnClickAddFriendBtn()
		{
			UIGray uigray = Utility.FindComponent<UIGray>(this.m_friendPrefab, "AddFriend", true);
			Text text = Utility.FindComponent<Text>(this.m_friendPrefab, "AddFriend/Text", true);
			if (uigray.enabled)
			{
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 29;
			sceneRequest.targetName = this.m_name;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			uigray.enabled = true;
			text.text = "已申请";
			this.m_addFriendBtn.enabled = false;
		}

		// Token: 0x060104C6 RID: 66758 RVA: 0x004918EC File Offset: 0x0048FCEC
		private void OnMenu()
		{
			RelationData relationData = new RelationData();
			relationData.uid = this.m_uid;
			relationData.name = this.m_name;
			relationData.level = this.m_level;
			relationData.occu = this.m_occu;
			relationData.type = this.m_relationType;
			relationData.vipLv = (byte)this.m_vipLv;
			RelationMenuData relationMenuData = new RelationMenuData();
			relationMenuData.m_data = relationData;
			relationMenuData.type = this.m_type;
			UIEventSystem.GetInstance().SendUIEvent(new UIEventShowFriendSecMenu(relationMenuData));
		}

		// Token: 0x060104C7 RID: 66759 RVA: 0x00491974 File Offset: 0x0048FD74
		private void OnClickButton()
		{
			if (this.m_type == CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT)
			{
				RelationData relationData = new RelationData();
				relationData.uid = this.m_uid;
				relationData.name = this.m_name;
				relationData.level = this.m_level;
				relationData.occu = this.m_occu;
				relationData.type = this.m_relationType;
				relationData.isOnline = this.m_isOnline;
				relationData.vipLv = (byte)this.m_vipLv;
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationData, false);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(relationData, false));
			}
		}

		// Token: 0x0400A4ED RID: 42221
		public GameObject m_friendPrefab;

		// Token: 0x0400A4EE RID: 42222
		private Button m_addFriendBtn;

		// Token: 0x0400A4EF RID: 42223
		private Button m_button;

		// Token: 0x0400A4F0 RID: 42224
		private Button m_menu;

		// Token: 0x0400A4F1 RID: 42225
		private Text m_stranger;

		// Token: 0x0400A4F2 RID: 42226
		private Image m_redPt;

		// Token: 0x0400A4F3 RID: 42227
		public ulong m_uid;

		// Token: 0x0400A4F4 RID: 42228
		public string m_name;

		// Token: 0x0400A4F5 RID: 42229
		public ushort m_level;

		// Token: 0x0400A4F6 RID: 42230
		public byte m_occu;

		// Token: 0x0400A4F7 RID: 42231
		public ushort m_vipLv;

		// Token: 0x0400A4F8 RID: 42232
		public CommonPlayerInfo.CommonPlayerType m_type;

		// Token: 0x0400A4F9 RID: 42233
		public byte m_isOnline;

		// Token: 0x0400A4FA RID: 42234
		public byte m_relationType;

		// Token: 0x020019F4 RID: 6644
		public enum CommonPlayerType
		{
			// Token: 0x0400A4FC RID: 42236
			CPT_NONE,
			// Token: 0x0400A4FD RID: 42237
			CPT_RECOMEND,
			// Token: 0x0400A4FE RID: 42238
			CPT_COMMON,
			// Token: 0x0400A4FF RID: 42239
			CPT_PRIVAT_CHAT,
			// Token: 0x0400A500 RID: 42240
			CPT_BLACK,
			// Token: 0x0400A501 RID: 42241
			CPT_TEACHER_REAL = 50,
			// Token: 0x0400A502 RID: 42242
			CPT_TEACHER,
			// Token: 0x0400A503 RID: 42243
			CPT_PUPIL_REAL,
			// Token: 0x0400A504 RID: 42244
			CPT_PUPIL_APPLY,
			// Token: 0x0400A505 RID: 42245
			CPT_DEL_PRIVATE_CHAT,
			// Token: 0x0400A506 RID: 42246
			CPT_CLASSMATE,
			// Token: 0x0400A507 RID: 42247
			CPT_TEAMDUPLICATION
		}
	}
}
