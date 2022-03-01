using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F8 RID: 6648
	internal class ComRelationInfo : MonoBehaviour
	{
		// Token: 0x17001D43 RID: 7491
		// (get) Token: 0x060104E8 RID: 66792 RVA: 0x00492567 File Offset: 0x00490967
		public RelationData RelationData
		{
			get
			{
				return (this.value != null) ? this.value : null;
			}
		}

		// Token: 0x060104E9 RID: 66793 RVA: 0x00492580 File Offset: 0x00490980
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x060104EA RID: 66794 RVA: 0x00492590 File Offset: 0x00490990
		private void _OnDonateAllSended(UIEvent uiEvent)
		{
			if (uiEvent != null)
			{
				Relation relation = uiEvent.Param1 as Relation;
				if (relation != null && this.value != null && relation.uid == this.value.uid)
				{
					if (null != this.btnGive)
					{
						this.btnGive.enabled = false;
					}
					if (null != this.grayGive)
					{
						this.grayGive.enabled = true;
					}
				}
			}
		}

		// Token: 0x060104EB RID: 66795 RVA: 0x00492610 File Offset: 0x00490A10
		private void _UpdateLeaveDesc()
		{
			if (null != this.LeaveDesc && this.value != null)
			{
				if (this.value.offlineTime == 0U)
				{
					this.LeaveDesc.text = TR.Value("relation_leave_un_time");
				}
				else
				{
					uint num = (DataManager<TimeManager>.GetInstance().GetServerTime() <= this.value.offlineTime) ? 0U : (DataManager<TimeManager>.GetInstance().GetServerTime() - this.value.offlineTime);
					if (num < 3600U)
					{
						uint num2 = num / 60U;
						num2 = (uint)IntMath.Clamp((long)((ulong)num2), 1L, 60L);
						this.LeaveDesc.text = TR.Value("relation_leave_m", num2);
					}
					else if (num < 86400U)
					{
						this.LeaveDesc.text = TR.Value("relation_leave_h", num / 3600U);
					}
					else if (num < 604800U)
					{
						this.LeaveDesc.text = TR.Value("relation_leave_d", num / 86400U);
					}
					else
					{
						this.LeaveDesc.text = TR.Value("relation_leave_fixed_date");
					}
				}
			}
		}

		// Token: 0x060104EC RID: 66796 RVA: 0x00492750 File Offset: 0x00490B50
		public void OnRemoveFriend()
		{
			if (this.value.type == 1)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_confirm_to_del_friend"), delegate()
				{
					DataManager<RelationDataManager>.GetInstance().DelFriend(this.value.uid);
				}, null, 0f, false);
			}
			else if (this.value.type == 4 || this.value.type == 5)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_confirm_to_del_aop"), delegate()
				{
					DataManager<RelationDataManager>.GetInstance().DelRelation(this.value.uid, (RelationType)this.value.type);
				}, null, 0f, false);
			}
		}

		// Token: 0x060104ED RID: 66797 RVA: 0x004927DC File Offset: 0x00490BDC
		public void OnPopupMenu()
		{
			if (this.value != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.value;
				if (this.eRelationTabType == RelationTabType.RTT_RECENTLY)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT;
				}
				else if (this.eRelationTabType == RelationTabType.RTT_FRIEND)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_COMMON;
				}
				else if (this.eRelationTabType == RelationTabType.RTT_BLACK)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_BLACK;
				}
				UIEventSystem.GetInstance().SendUIEvent(new UIEventShowFriendSecMenu(relationMenuData));
			}
		}

		// Token: 0x060104EE RID: 66798 RVA: 0x00492858 File Offset: 0x00490C58
		public void OnHuiGuiBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FriendBackBuffBonusFrame>(FrameLayer.Middle, this.value, string.Empty);
		}

		// Token: 0x060104EF RID: 66799 RVA: 0x00492871 File Offset: 0x00490C71
		private void OnChat(bool bValue)
		{
			if (bValue && this.value != null)
			{
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.value, false);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.value, false));
			}
		}

		// Token: 0x060104F0 RID: 66800 RVA: 0x004928AC File Offset: 0x00490CAC
		public void OnSendGift()
		{
			if (this.value != null)
			{
				if (this.value.dayGiftNum <= 0)
				{
					return;
				}
				WorldRelationPresentGiveReq worldRelationPresentGiveReq = new WorldRelationPresentGiveReq();
				worldRelationPresentGiveReq.friendUID = this.value.uid;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldRelationPresentGiveReq>(ServerType.GATE_SERVER, worldRelationPresentGiveReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(601775U, delegate(MsgDATA data)
				{
					if (data == null)
					{
						return;
					}
					WorldRelationPresentGiveRes worldRelationPresentGiveRes = new WorldRelationPresentGiveRes();
					worldRelationPresentGiveRes.decode(data.bytes);
					if (worldRelationPresentGiveRes.code != 0U)
					{
						CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)worldRelationPresentGiveRes.code, string.Empty, string.Empty);
						if (tableItem != null)
						{
							SystemNotifyManager.SysNotifyTextAnimation(tableItem.Descs, CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
					else
					{
						this.btnGive.enabled = false;
						this.grayGive.enabled = true;
					}
				}, false, 15f, null);
			}
		}

		// Token: 0x060104F1 RID: 66801 RVA: 0x00492920 File Offset: 0x00490D20
		public static void SendGift(RelationData value)
		{
			if (value != null)
			{
				WorldRelationPresentGiveReq worldRelationPresentGiveReq = new WorldRelationPresentGiveReq();
				worldRelationPresentGiveReq.friendUID = value.uid;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldRelationPresentGiveReq>(ServerType.GATE_SERVER, worldRelationPresentGiveReq);
			}
		}

		// Token: 0x060104F2 RID: 66802 RVA: 0x00492954 File Offset: 0x00490D54
		public void OnTalkToFriend()
		{
			DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.value, false);
			DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(this.value);
			Singleton<ClientSystemManager>.instance.CloseFrame<RelationFrameNew>(null, false);
			UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.value, true));
		}

		// Token: 0x060104F3 RID: 66803 RVA: 0x004929A8 File Offset: 0x00490DA8
		public void OnRefuse()
		{
			if (this.inviteData != null)
			{
				SceneReply sceneReply = new SceneReply();
				sceneReply.type = 3;
				sceneReply.requester = this.inviteData.requester;
				sceneReply.result = 0;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
				DataManager<RelationDataManager>.GetInstance().DelInviter(this.inviteData.requester);
			}
		}

		// Token: 0x060104F4 RID: 66804 RVA: 0x00492A0C File Offset: 0x00490E0C
		public void OnAccept()
		{
			if (this.inviteData != null)
			{
				SceneReply sceneReply = new SceneReply();
				sceneReply.type = 3;
				sceneReply.requester = this.inviteData.requester;
				sceneReply.result = 1;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
				DataManager<RelationDataManager>.GetInstance().DelInviter(this.inviteData.requester);
			}
		}

		// Token: 0x060104F5 RID: 66805 RVA: 0x00492A6D File Offset: 0x00490E6D
		public void OnRemoveBlack()
		{
			if (this.value != null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_confirm_to_del_black"), delegate()
				{
					DataManager<RelationDataManager>.GetInstance().DelBlack(this.value.uid);
				}, null, 0f, false);
			}
		}

		// Token: 0x060104F6 RID: 66806 RVA: 0x00492A9C File Offset: 0x00490E9C
		public void OnAddRecommendFriend()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.value != null && this.btnAdd.enabled)
			{
				this.grayAdd.enabled = true;
				this.btnAdd.enabled = false;
				SceneRequest sceneRequest = new SceneRequest();
				sceneRequest.type = 29;
				sceneRequest.targetName = this.value.name;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
				DataManager<RelationDataManager>.GetInstance().AddQueryInfo(this.value.uid);
			}
		}

		// Token: 0x060104F7 RID: 66807 RVA: 0x00492B70 File Offset: 0x00490F70
		public void OnItemVisible(RelationData friendInfo, RelationTabType eRelationTabType)
		{
			this.value = null;
			this.inviteData = null;
			InvokeMethod.RmoveInvokeIntervalCall(this);
			if (null != this.btnMenu)
			{
				this.btnMenu.onClick.RemoveListener(new UnityAction(this.OnPopupMenu));
			}
			this.value = friendInfo;
			this.eRelationTabType = eRelationTabType;
			if (null != this.btnMenu && this.value != null)
			{
				this.btnMenu.onClick.AddListener(new UnityAction(this.OnPopupMenu));
			}
			if (this.goHuiGuiIcon != null)
			{
				this.goHuiGuiIcon.CustomActive(this.value.isRegress == 1);
			}
			if (this.btnHuiGui != null)
			{
				this.btnHuiGui.CustomActive(this.value.isRegress == 1);
				this.btnHuiGui.onClick.RemoveListener(new UnityAction(this.OnHuiGuiBtnClick));
				this.btnHuiGui.onClick.AddListener(new UnityAction(this.OnHuiGuiBtnClick));
			}
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)friendInfo.occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			ETCImageLoader.LoadSprite(ref this.jobIcon, path, true);
			if (this.jobIIconGray != null)
			{
				this.jobIIconGray.enabled = false;
				bool enabled = this.value.status == 2;
				this.jobIIconGray.enabled = enabled;
			}
			if (friendInfo.remark != null && friendInfo.remark != string.Empty)
			{
				this.roleName.text = friendInfo.remark;
				this.remarkName.text = string.Format("({0})", friendInfo.name);
			}
			else
			{
				this.roleName.text = friendInfo.name;
				this.remarkName.text = string.Empty;
			}
			if (tableItem != null)
			{
				this.roleLvAndJob.text = string.Format("Lv.{0}", friendInfo.level);
			}
			this.vipLv.Value = (int)friendInfo.vipLv;
			bool bActive = this.value.type != 0 && this.value.type != 3 && this.value.type != 2;
			this.btnGive.CustomActive(bActive);
			bool flag = friendInfo.dayGiftNum > 0;
			this.btnGive.enabled = true;
			this.grayGive.enabled = !flag;
			this._UpdateLeaveDesc();
			if (eRelationTabType == RelationTabType.RTT_RECENTLY)
			{
				if (this.value.type == 3 || this.value.type == 0)
				{
					this.goBusy.CustomActive(false);
					this.goFree.CustomActive(this.value.isOnline > 0);
					this.goOffLine.CustomActive(this.value.isOnline < 1);
					if (this.value.isOnline == 0)
					{
						InvokeMethod.InvokeInterval(this, 1f, 1f, 999999f, null, new UnityAction(this._UpdateLeaveDesc), null);
					}
					if (this.jobIIconGray != null)
					{
						this.jobIIconGray.enabled = false;
						bool enabled2 = this.value.isOnline < 1;
						this.jobIIconGray.enabled = enabled2;
					}
				}
				else
				{
					this.goBusy.CustomActive(this.value.status == 1);
					this.goFree.CustomActive(this.value.status == 0);
					this.goOffLine.CustomActive(this.value.status == 2);
					if (this.value.status == 2)
					{
						InvokeMethod.InvokeInterval(this, 1f, 1f, 999999f, null, new UnityAction(this._UpdateLeaveDesc), null);
					}
				}
			}
			else
			{
				this.goBusy.CustomActive(this.value.status == 1);
				this.goFree.CustomActive(this.value.status == 0);
				this.goOffLine.CustomActive(this.value.status == 2);
				if (this.value.status == 2)
				{
					InvokeMethod.InvokeInterval(this, 1f, 1f, 999999f, null, new UnityAction(this._UpdateLeaveDesc), null);
				}
			}
			if (eRelationTabType == RelationTabType.RTT_RECENTLY)
			{
				this.goChatRedPoint.CustomActive(DataManager<RelationDataManager>.GetInstance().GetPriDirtyByUid(this.value.uid));
			}
			if (null != this.RelationFlag)
			{
				if (this.value != null)
				{
					if (this.value.type == 4)
					{
						ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_master, true);
						this.RelationFlag.CustomActive(true);
					}
					else if (this.value.type == 5)
					{
						ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_pupil, true);
						this.RelationFlag.CustomActive(true);
					}
					else if (this.value.type == 3 || this.value.type == 0)
					{
						ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_stranger, true);
						this.RelationFlag.CustomActive(true);
					}
					else if (this.value.type == 1 && this.value.mark == 1U)
					{
						ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_relation, true);
						this.RelationFlag.CustomActive(true);
					}
					else
					{
						this.RelationFlag.sprite = null;
						this.RelationFlag.CustomActive(false);
					}
				}
				else
				{
					this.RelationFlag.sprite = null;
					this.RelationFlag.CustomActive(false);
				}
			}
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (this.value.headFrame != 0U)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)this.value.headFrame);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x060104F8 RID: 66808 RVA: 0x004931D0 File Offset: 0x004915D0
		public void OnItemVisible(InviteFriendData inviteFriendData)
		{
			this.value = null;
			this.inviteData = null;
			if (null != this.btnMenu)
			{
				this.btnMenu.onClick.RemoveListener(new UnityAction(this.OnPopupMenu));
			}
			this.inviteData = inviteFriendData;
			if (null != this.btnMenu && this.inviteData != null)
			{
				this.btnMenu.onClick.AddListener(new UnityAction(this.OnPopupMenu));
			}
			this.roleName.text = inviteFriendData.requesterName;
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)inviteFriendData.requesterOccu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			ETCImageLoader.LoadSprite(ref this.jobIcon, path, true);
			if (tableItem != null)
			{
				this.roleLvAndJob.text = string.Format("Lv.{0} {1}", inviteFriendData.requesterLevel, tableItem.Name);
			}
			this.vipLv.Value = (int)inviteFriendData.vipLv;
			this.goBusy.CustomActive(false);
			this.goFree.CustomActive(false);
			this.goOffLine.CustomActive(false);
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(inviteFriendData.requester);
			RelationType relationType = RelationType.RELATION_STRANGER;
			if (relationByRoleID != null)
			{
				relationType = (RelationType)relationByRoleID.type;
			}
			if (null != this.RelationFlag)
			{
				if (relationType == RelationType.RELATION_MASTER)
				{
					ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_master, true);
					this.RelationFlag.CustomActive(true);
				}
				else if (relationType == RelationType.RELATION_DISCIPLE)
				{
					ETCImageLoader.LoadSprite(ref this.RelationFlag, ComRelationInfo.ms_icon_pupil, true);
					this.RelationFlag.CustomActive(true);
				}
				else
				{
					this.RelationFlag.sprite = null;
					this.RelationFlag.CustomActive(false);
				}
			}
		}

		// Token: 0x060104F9 RID: 66809 RVA: 0x004933C8 File Offset: 0x004917C8
		private void Start()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryIntervalChanged, new ClientEventSystem.UIEventHandler(this._OnQueryIntervalChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDonateAllSended, new ClientEventSystem.UIEventHandler(this._OnDonateAllSended));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryIntervalChanged, new ClientEventSystem.UIEventHandler(this._OnQueryIntervalChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDonateAllSended, new ClientEventSystem.UIEventHandler(this._OnDonateAllSended));
		}

		// Token: 0x060104FA RID: 66810 RVA: 0x00493478 File Offset: 0x00491878
		private void _OnRoleChatDirtyChanged(UIEvent uiEvent)
		{
			if (this.value != null && this.eRelationTabType == RelationTabType.RTT_RECENTLY)
			{
				ulong num = (ulong)uiEvent.Param1;
				bool flag = (bool)uiEvent.Param2;
				if (this.value.uid == num)
				{
					this.goChatRedPoint.CustomActive(DataManager<RelationDataManager>.GetInstance().GetPriDirtyByUid(this.value.uid));
				}
			}
			else
			{
				this.goChatRedPoint.CustomActive(false);
			}
		}

		// Token: 0x060104FB RID: 66811 RVA: 0x004934F5 File Offset: 0x004918F5
		private void _OnQueryIntervalChanged(UIEvent uiEvent)
		{
			if (this.value != null)
			{
				this.OnItemVisible(this.value, this.eRelationTabType);
			}
		}

		// Token: 0x060104FC RID: 66812 RVA: 0x00493514 File Offset: 0x00491914
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryIntervalChanged, new ClientEventSystem.UIEventHandler(this._OnQueryIntervalChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDonateAllSended, new ClientEventSystem.UIEventHandler(this._OnDonateAllSended));
			InvokeMethod.RmoveInvokeIntervalCall(this);
			this.value = null;
			this.inviteData = null;
			if (null != this.btnMenu)
			{
				this.btnMenu.onClick.RemoveListener(new UnityAction(this.OnPopupMenu));
			}
		}

		// Token: 0x0400A520 RID: 42272
		public static RelationData ms_selected;

		// Token: 0x0400A521 RID: 42273
		public static string ms_icon_master = "UI/Image/Packed/p_UI_Social.png:UI_Social_Biaoqian_Shifu";

		// Token: 0x0400A522 RID: 42274
		public static string ms_icon_pupil = "UI/Image/Packed/p_UI_Social.png:UI_Social_Biaoqian_Tudi";

		// Token: 0x0400A523 RID: 42275
		public static string ms_icon_relation = "UI/Image/Packed/p_UI_Social.png:UI_Social_Biaoqian_Haoyou";

		// Token: 0x0400A524 RID: 42276
		public static string ms_icon_stranger = "UI/Image/Packed/p_UI_Social.png:UI_Social_Biaoqian_Moshengren";

		// Token: 0x0400A525 RID: 42277
		public UIGray jobIIconGray;

		// Token: 0x0400A526 RID: 42278
		public Image jobIcon;

		// Token: 0x0400A527 RID: 42279
		public Text roleName;

		// Token: 0x0400A528 RID: 42280
		public Text remarkName;

		// Token: 0x0400A529 RID: 42281
		public Text roleLvAndJob;

		// Token: 0x0400A52A RID: 42282
		public UINumber vipLv;

		// Token: 0x0400A52B RID: 42283
		public Image imgFightIcon;

		// Token: 0x0400A52C RID: 42284
		public Image imgFightLv;

		// Token: 0x0400A52D RID: 42285
		public Text fightLv;

		// Token: 0x0400A52E RID: 42286
		public UIGray grayGive;

		// Token: 0x0400A52F RID: 42287
		public Button btnGive;

		// Token: 0x0400A530 RID: 42288
		public GameObject goBusy;

		// Token: 0x0400A531 RID: 42289
		public GameObject goFree;

		// Token: 0x0400A532 RID: 42290
		public GameObject goOffLine;

		// Token: 0x0400A533 RID: 42291
		public UIGray grayAdd;

		// Token: 0x0400A534 RID: 42292
		public Button btnAdd;

		// Token: 0x0400A535 RID: 42293
		public Button btnMenu;

		// Token: 0x0400A536 RID: 42294
		public GameObject goChatRedPoint;

		// Token: 0x0400A537 RID: 42295
		public Image RelationFlag;

		// Token: 0x0400A538 RID: 42296
		public Text LeaveDesc;

		// Token: 0x0400A539 RID: 42297
		public GameObject goCheckMark;

		// Token: 0x0400A53A RID: 42298
		public GameObject goHuiGuiIcon;

		// Token: 0x0400A53B RID: 42299
		public Button btnHuiGui;

		// Token: 0x0400A53C RID: 42300
		public ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x0400A53D RID: 42301
		private InviteFriendData inviteData;

		// Token: 0x0400A53E RID: 42302
		private RelationData value;

		// Token: 0x0400A53F RID: 42303
		private RelationTabType eRelationTabType = RelationTabType.RTT_COUNT;
	}
}
