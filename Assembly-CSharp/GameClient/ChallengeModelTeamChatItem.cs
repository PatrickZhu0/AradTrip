using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020014D7 RID: 5335
	public class ChallengeModelTeamChatItem : MonoBehaviour
	{
		// Token: 0x0600CEE4 RID: 52964 RVA: 0x003308E3 File Offset: 0x0032ECE3
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CEE5 RID: 52965 RVA: 0x003308EB File Offset: 0x0032ECEB
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CEE6 RID: 52966 RVA: 0x003308F9 File Offset: 0x0032ECF9
		private void BindEvents()
		{
		}

		// Token: 0x0600CEE7 RID: 52967 RVA: 0x003308FB File Offset: 0x0032ECFB
		private void UnBindEvents()
		{
		}

		// Token: 0x0600CEE8 RID: 52968 RVA: 0x003308FD File Offset: 0x0032ECFD
		private void ClearData()
		{
			this._chatBlock = null;
		}

		// Token: 0x0600CEE9 RID: 52969 RVA: 0x00330906 File Offset: 0x0032ED06
		public void InitItem(ChatBlock chatBlock)
		{
			this._chatBlock = chatBlock;
			if (this._chatBlock == null || this._chatBlock.chatData == null)
			{
				Logger.LogErrorFormat("ChallengeModelTeamChatItem ChatData is null", new object[0]);
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CEEA RID: 52970 RVA: 0x00330944 File Offset: 0x0032ED44
		private void InitContent()
		{
			if (this.chatContent != null)
			{
				this.chatContent.RemoveFailedListener(new UnityAction(this.OnClickFailed));
				this.chatContent.AddOnFailedListener(new UnityAction(this.OnClickFailed));
				string nameLink = this._chatBlock.chatData.GetNameLink();
				if (!string.IsNullOrEmpty(nameLink))
				{
					this.chatContent.SetText(this._chatBlock.chatData.GetChannelString() + nameLink + ":" + this._chatBlock.chatData.GetWords(), true);
				}
				else
				{
					this.chatContent.SetText(this._chatBlock.chatData.GetChannelString() + this._chatBlock.chatData.GetWords(), true);
				}
			}
		}

		// Token: 0x0600CEEB RID: 52971 RVA: 0x00330A19 File Offset: 0x0032EE19
		private void OnClickFailed()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChatFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChatFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x040078E2 RID: 30946
		private ChatBlock _chatBlock;

		// Token: 0x040078E3 RID: 30947
		[SerializeField]
		private LinkParse chatContent;
	}
}
