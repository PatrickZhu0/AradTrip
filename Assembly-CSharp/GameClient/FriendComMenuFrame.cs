using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019FD RID: 6653
	public class FriendComMenuFrame : ClientFrame
	{
		// Token: 0x06010524 RID: 66852 RVA: 0x004943E8 File Offset: 0x004927E8
		protected sealed override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mContent = this.mBind.GetGameObject("Content");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x06010525 RID: 66853 RVA: 0x00494464 File Offset: 0x00492864
		protected sealed override void _unbindExUI()
		{
			this.mName = null;
			this.mContent = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x06010526 RID: 66854 RVA: 0x004944B3 File Offset: 0x004928B3
		private void _onCloseButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCloseMenu, null, null, null, null);
		}

		// Token: 0x06010527 RID: 66855 RVA: 0x004944C8 File Offset: 0x004928C8
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/FriendComMenuFrame";
		}

		// Token: 0x06010528 RID: 66856 RVA: 0x004944CF File Offset: 0x004928CF
		protected sealed override void _OnOpenFrame()
		{
			this._InitData();
			this._InitElement();
			this._Initialize();
		}

		// Token: 0x06010529 RID: 66857 RVA: 0x004944E3 File Offset: 0x004928E3
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0601052A RID: 66858 RVA: 0x004944E5 File Offset: 0x004928E5
		private void _Initialize()
		{
			if (this.mContent != null)
			{
				Utility.SetPopMenuPosition(this.mContent, new Vector2(10f, 10f), new Vector2(0f, -418f));
			}
		}

		// Token: 0x0601052B RID: 66859 RVA: 0x00494524 File Offset: 0x00492924
		private void _SetupFramePosition(Vector2 pos)
		{
			RectTransform component = this.mContent.GetComponent<RectTransform>();
			RectTransform rectTransform = component.transform.parent as RectTransform;
			Vector2 anchoredPosition;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref anchoredPosition))
			{
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			Vector2 vector;
			vector..ctor(10f, 10f);
			float x = vector.x;
			float num = rectTransform.rect.size.x - vector.x - component.rect.size.x;
			float y = vector.y;
			float num2 = -(rectTransform.rect.size.y - vector.y - component.rect.size.y);
			anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, x, num);
			anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, num2, y);
			component.anchoredPosition = anchoredPosition;
		}

		// Token: 0x0601052C RID: 66860 RVA: 0x0049463E File Offset: 0x00492A3E
		protected void _InitData()
		{
			this.m_data = (this.userData as RelationMenuData);
		}

		// Token: 0x0601052D RID: 66861 RVA: 0x00494654 File Offset: 0x00492A54
		protected void _InitElement()
		{
			if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_COMMON)
			{
				this._InitCommonMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT)
			{
				this._InitPrivateMenu();
			}
			else if (this.m_data.type == CommonPlayerInfo.CommonPlayerType.CPT_BLACK)
			{
				this._InitBlackMenu();
			}
		}

		// Token: 0x0601052E RID: 66862 RVA: 0x004946B0 File Offset: 0x00492AB0
		protected void _InitCommonMenu()
		{
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5 || this.m_data.m_data.type == 1)
			{
				this._AddElement("备注名称", delegate
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SettingNoteNameFrame>(FrameLayer.Middle, this.m_data.m_data, string.Empty);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				if (this.m_data.m_data.type == 1)
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
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			if (RelationMenuFram._CheckGetTeacher(this.m_data.m_data))
			{
				this._AddElement("拜师", delegate
				{
					if (RelationMenuFram._OnAskForTeacher(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			if (DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen())
			{
				this._AddElement("举报违规", new UnityAction(this._OnReport));
			}
		}

		// Token: 0x0601052F RID: 66863 RVA: 0x00494894 File Offset: 0x00492C94
		protected void _InitPrivateMenu()
		{
			this._AddElement("查看信息", new UnityAction(this._OnCheckInfo));
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5 || this.m_data.m_data.type == 1)
			{
				this._AddElement("备注名称", delegate
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SettingNoteNameFrame>(FrameLayer.Middle, this.m_data.m_data, string.Empty);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			this._AddElement("邀请入队", new UnityAction(this._OnInvitTeam));
			this._AddElement("申请入队", new UnityAction(this._OnApplicationTeam));
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				this._AddElement("邀请入会", new UnityAction(this._OnInviteMembership));
			}
			this._AddElement("移除列表", new UnityAction(this._OnPrivateMenuRemoveList));
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Friend))
			{
				if (this.m_data.m_data.type == 3)
				{
					this._AddElement("加为好友", new UnityAction(this._OnAddFriend));
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
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			if (RelationMenuFram._CheckGetTeacher(this.m_data.m_data))
			{
				this._AddElement("拜师", delegate
				{
					if (RelationMenuFram._OnAskForTeacher(this.m_data.m_data))
					{
						this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
					}
				});
			}
			if (this.m_data.m_data.type == 4 || this.m_data.m_data.type == 5)
			{
				this._AddElement("解除师徒", delegate
				{
					RelationMenuFram._OnFireTeacher(this.m_data.m_data);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				});
			}
			if (DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen())
			{
				this._AddElement("举报违规", new UnityAction(this._OnReport));
			}
		}

		// Token: 0x06010530 RID: 66864 RVA: 0x00494ABF File Offset: 0x00492EBF
		protected void _InitBlackMenu()
		{
			this._AddElement("移除列表", new UnityAction(this._OnBlackMenuRemoveList));
			if (DataManager<BaseWebViewManager>.GetInstance().IsReportFuncOpen())
			{
				this._AddElement("举报违规", new UnityAction(this._OnReport));
			}
		}

		// Token: 0x06010531 RID: 66865 RVA: 0x00494AFE File Offset: 0x00492EFE
		protected void _OnReport()
		{
			if (this.m_data != null)
			{
				DataManager<BaseWebViewManager>.GetInstance().TryOpenReportFrame(this.m_data.m_data);
			}
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010532 RID: 66866 RVA: 0x00494B2D File Offset: 0x00492F2D
		protected void _OnCheckInfo()
		{
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.m_data.m_data.uid, 0U, 0U);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010533 RID: 66867 RVA: 0x00494B58 File Offset: 0x00492F58
		protected void _OnInvitTeam()
		{
			DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010534 RID: 66868 RVA: 0x00494B81 File Offset: 0x00492F81
		protected void _OnApplicationTeam()
		{
			DataManager<TeamDataManager>.GetInstance().JoinTeam(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010535 RID: 66869 RVA: 0x00494BAC File Offset: 0x00492FAC
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
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010536 RID: 66870 RVA: 0x00494C58 File Offset: 0x00493058
		protected void _OnDelFriend()
		{
			string msgContent = string.Format("您确定删除好友{0}吗？删除后友好度清零！", this.m_data.m_data.name);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().DelFriend(this.m_data.m_data.uid);
			}, delegate()
			{
			}, 0f, false);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010537 RID: 66871 RVA: 0x00494CC4 File Offset: 0x004930C4
		protected void _OnAddBlack()
		{
			string msgContent = string.Format("是否加入黑名单?", new object[0]);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().AddBlackList(this.m_data.m_data.uid);
			}, delegate()
			{
			}, 0f, false);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010538 RID: 66872 RVA: 0x00494D24 File Offset: 0x00493124
		protected void _OnInviteMembership()
		{
			DataManager<GuildDataManager>.GetInstance().InviteJoinGuild(this.m_data.m_data.uid);
			this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
		}

		// Token: 0x06010539 RID: 66873 RVA: 0x00494D50 File Offset: 0x00493150
		protected void _OnPrivateMenuRemoveList()
		{
			List<PrivateChatPlayerData> priChatList = DataManager<RelationDataManager>.GetInstance().GetPriChatList();
			if (priChatList != null)
			{
				PrivateChatPlayerData privateChatPlayerData = priChatList.Find((PrivateChatPlayerData x) => x.relationData.uid == this.m_data.m_data.uid);
				if (privateChatPlayerData != null)
				{
					priChatList.Remove(privateChatPlayerData);
					DataManager<ChatRecordManager>.GetInstance().RemoveChatRecords(DataManager<PlayerBaseData>.GetInstance().RoleID, this.m_data.m_data.uid);
					DataManager<ChatManager>.GetInstance().RemovePrivateChatData(this.m_data.m_data.uid);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FriendComMenuRemoveList, null, null, null, null);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				}
			}
		}

		// Token: 0x0601053A RID: 66874 RVA: 0x00494DED File Offset: 0x004931ED
		protected void _OnBlackMenuRemoveList()
		{
			if (this.m_data.m_data != null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_confirm_to_del_black"), delegate()
				{
					DataManager<RelationDataManager>.GetInstance().DelBlack(this.m_data.m_data.uid);
					this.frameMgr.CloseFrame<FriendComMenuFrame>(this, false);
				}, null, 0f, false);
			}
		}

		// Token: 0x0601053B RID: 66875 RVA: 0x00494E24 File Offset: 0x00493224
		protected void _AddElement(string name, UnityAction cb)
		{
			this.m_element = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/RelationFrame/FriendComMenuLayoutElement", true, 0U);
			Text componetInChild = Utility.GetComponetInChild<Text>(this.m_element, "Button/Text");
			componetInChild.text = name;
			Button componetInChild2 = Utility.GetComponetInChild<Button>(this.m_element, "Button");
			componetInChild2.onClick.AddListener(cb);
			GameObject gameObject = Utility.FindGameObject(this.frame, "Content", true);
			this.m_element.transform.SetParent(gameObject.transform, false);
		}

		// Token: 0x0400A553 RID: 42323
		private GameObject m_element;

		// Token: 0x0400A554 RID: 42324
		private RelationMenuData m_data;

		// Token: 0x0400A555 RID: 42325
		private Text mName;

		// Token: 0x0400A556 RID: 42326
		private GameObject mContent;

		// Token: 0x0400A557 RID: 42327
		private Button mClose;
	}
}
