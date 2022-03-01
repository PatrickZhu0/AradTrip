using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001C98 RID: 7320
	public class TeamDuplicationTalkItem : MonoBehaviour
	{
		// Token: 0x06011F35 RID: 73525 RVA: 0x0053FA24 File Offset: 0x0053DE24
		private void Awake()
		{
			if (this.content != null)
			{
				this.content.RemoveFailedListener(new UnityAction(this.OnTalkItemFailedClick));
				this.content.AddOnFailedListener(new UnityAction(this.OnTalkItemFailedClick));
			}
		}

		// Token: 0x06011F36 RID: 73526 RVA: 0x0053FA70 File Offset: 0x0053DE70
		private void OnDestroy()
		{
			if (this.content != null)
			{
				this.content.RemoveFailedListener(new UnityAction(this.OnTalkItemFailedClick));
			}
			this._chatBlock = null;
		}

		// Token: 0x06011F37 RID: 73527 RVA: 0x0053FAA1 File Offset: 0x0053DEA1
		public void Init(ChatBlock chatBlock)
		{
			this._chatBlock = chatBlock;
			if (this._chatBlock == null)
			{
				return;
			}
			this._chatData = this._chatBlock.chatData;
			if (this._chatData == null)
			{
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F38 RID: 73528 RVA: 0x0053FADC File Offset: 0x0053DEDC
		private void InitItem()
		{
			string nameLink = this._chatData.GetNameLink();
			if (!string.IsNullOrEmpty(nameLink))
			{
				this.content.SetText(this._chatData.GetChannelString() + nameLink + ":" + this._chatData.GetWords(), true);
			}
			else
			{
				this.content.SetText(this._chatData.GetChannelString() + this._chatData.GetWords(), true);
			}
			if (this.layoutSortOrder != null)
			{
				this.layoutSortOrder.SortID = this._chatBlock.iOrder;
			}
		}

		// Token: 0x06011F39 RID: 73529 RVA: 0x0053FB80 File Offset: 0x0053DF80
		private void OnTalkItemFailedClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationChatFrame();
		}

		// Token: 0x0400BB1C RID: 47900
		private ChatBlock _chatBlock;

		// Token: 0x0400BB1D RID: 47901
		private ChatData _chatData;

		// Token: 0x0400BB1E RID: 47902
		[SerializeField]
		private LinkParse content;

		// Token: 0x0400BB1F RID: 47903
		[SerializeField]
		private LayoutSortOrder layoutSortOrder;
	}
}
