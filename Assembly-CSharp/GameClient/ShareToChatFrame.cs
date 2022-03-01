using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020001EA RID: 490
	public class ShareToChatFrame : ClientFrame
	{
		// Token: 0x06000F74 RID: 3956 RVA: 0x0004F19C File Offset: 0x0004D59C
		protected override void _bindExUI()
		{
			this.mContent = this.mBind.GetGameObject("Content");
			this.mNear = this.mBind.GetCom<Button>("Near");
			if (null != this.mNear)
			{
				this.mNear.onClick.AddListener(new UnityAction(this._onNearButtonClick));
			}
			this.mWorld = this.mBind.GetCom<Button>("World");
			if (null != this.mWorld)
			{
				this.mWorld.onClick.AddListener(new UnityAction(this._onWorldButtonClick));
			}
			this.mGuild = this.mBind.GetCom<Button>("Guild");
			if (null != this.mGuild)
			{
				this.mGuild.onClick.AddListener(new UnityAction(this._onGuildButtonClick));
			}
			this.mTeam = this.mBind.GetCom<Button>("Team");
			if (null != this.mTeam)
			{
				this.mTeam.onClick.AddListener(new UnityAction(this._onTeamButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0004F310 File Offset: 0x0004D710
		protected override void _unbindExUI()
		{
			this.mContent = null;
			if (null != this.mNear)
			{
				this.mNear.onClick.RemoveListener(new UnityAction(this._onNearButtonClick));
			}
			this.mNear = null;
			if (null != this.mWorld)
			{
				this.mWorld.onClick.RemoveListener(new UnityAction(this._onWorldButtonClick));
			}
			this.mWorld = null;
			if (null != this.mGuild)
			{
				this.mGuild.onClick.RemoveListener(new UnityAction(this._onGuildButtonClick));
			}
			this.mGuild = null;
			if (null != this.mTeam)
			{
				this.mTeam.onClick.RemoveListener(new UnityAction(this._onTeamButtonClick));
			}
			this.mTeam = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0004F428 File Offset: 0x0004D828
		private void _onNearButtonClick()
		{
			this.SendMessage(ChatType.CT_NORMAL);
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0004F431 File Offset: 0x0004D831
		private void _onWorldButtonClick()
		{
			this.SendMessage(ChatType.CT_WORLD);
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0004F43A File Offset: 0x0004D83A
		private void _onGuildButtonClick()
		{
			this.SendMessage(ChatType.CT_GUILD);
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x0004F443 File Offset: 0x0004D843
		private void _onTeamButtonClick()
		{
			this.SendMessage(ChatType.CT_TEAM);
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0004F44C File Offset: 0x0004D84C
		private void _onCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x0004F455 File Offset: 0x0004D855
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/ShareToChatFrame";
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0004F45C File Offset: 0x0004D85C
		public void InitData(Vector3 pos, string msg)
		{
			if (this.mContent == null)
			{
				return;
			}
			this.mContent.transform.position = pos;
			this.message = msg;
			NetProcess.AddMsgHandler(500803U, new Action<MsgDATA>(this._OnNetSyncChat));
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0004F4AC File Offset: 0x0004D8AC
		private void SendMessage(ChatType type)
		{
			if (!DataManager<TeamDataManager>.GetInstance().HasTeam() && type == ChatType.CT_TEAM)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chat_failed_for_has_no_team"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				base.Close(false);
				return;
			}
			this.chatType = type;
			DataManager<ChatManager>.GetInstance().SendChat(type, this.message, 0UL, 0);
			base.Close(false);
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x0004F50C File Offset: 0x0004D90C
		private void _OnNetSyncChat(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			SceneSyncChat sceneSyncChat = new SceneSyncChat();
			sceneSyncChat.decode(msg.bytes);
			if (sceneSyncChat == null || sceneSyncChat.objid != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			ChanelType chanelType = DataManager<ChatManager>.GetInstance()._TransChatType(this.chatType);
			if ((ChanelType)sceneSyncChat.channel != chanelType)
			{
				return;
			}
			SystemNotifyManager.SysNotifyTextAnimation("分享成功", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
		}

		// Token: 0x04000AB9 RID: 2745
		private GameObject mContent;

		// Token: 0x04000ABA RID: 2746
		private Button mNear;

		// Token: 0x04000ABB RID: 2747
		private Button mWorld;

		// Token: 0x04000ABC RID: 2748
		private Button mGuild;

		// Token: 0x04000ABD RID: 2749
		private Button mTeam;

		// Token: 0x04000ABE RID: 2750
		private Button mClose;

		// Token: 0x04000ABF RID: 2751
		private string message;

		// Token: 0x04000AC0 RID: 2752
		private ChatType chatType = ChatType.CT_NORMAL;
	}
}
