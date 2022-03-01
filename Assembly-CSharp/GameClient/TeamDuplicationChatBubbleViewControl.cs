using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C3C RID: 7228
	public class TeamDuplicationChatBubbleViewControl : MonoBehaviour
	{
		// Token: 0x06011C00 RID: 72704 RVA: 0x0053316B File Offset: 0x0053156B
		public void SetMessage(string msg)
		{
			this.ShowRoot(true);
			this.SetChatMessage(msg);
			this._interval = this.showDelay;
		}

		// Token: 0x06011C01 RID: 72705 RVA: 0x00533187 File Offset: 0x00531587
		public void SetChatBgRotate()
		{
			if (this.chatBgRtf == null)
			{
				return;
			}
			this.chatBgRtf.localRotation = new Quaternion(0f, 180f, 0f, 1f);
		}

		// Token: 0x06011C02 RID: 72706 RVA: 0x005331BF File Offset: 0x005315BF
		public void SetChatPlayerGuid(ulong guid)
		{
			this._playerGuid = guid;
		}

		// Token: 0x06011C03 RID: 72707 RVA: 0x005331C8 File Offset: 0x005315C8
		public ulong GetChatPlayerGuid()
		{
			return this._playerGuid;
		}

		// Token: 0x06011C04 RID: 72708 RVA: 0x005331D0 File Offset: 0x005315D0
		public void ShowRoot(bool isShow)
		{
			this._chatMessageState = ((!isShow) ? TeamDuplicationChatBubbleViewControl.ChatMessageState.ChatHidden : TeamDuplicationChatBubbleViewControl.ChatMessageState.ChatShow);
			if (null != this.chatRoot)
			{
				this.chatRoot.SetActive(isShow);
			}
		}

		// Token: 0x06011C05 RID: 72709 RVA: 0x00533202 File Offset: 0x00531602
		private void SetChatMessage(string msg)
		{
			if (null != this.chatContent)
			{
				this.chatContent.text = msg;
			}
			if (null != this.linkParse)
			{
				this.linkParse.SetText(msg, true);
			}
		}

		// Token: 0x06011C06 RID: 72710 RVA: 0x0053323F File Offset: 0x0053163F
		private void Update()
		{
			if (this._chatMessageState == TeamDuplicationChatBubbleViewControl.ChatMessageState.ChatShow)
			{
				if (this._interval > 0f)
				{
					this._interval -= Time.deltaTime;
				}
				else
				{
					this.ShowRoot(false);
				}
			}
		}

		// Token: 0x0400B8F5 RID: 47349
		private ulong _playerGuid;

		// Token: 0x0400B8F6 RID: 47350
		private float _interval;

		// Token: 0x0400B8F7 RID: 47351
		private TeamDuplicationChatBubbleViewControl.ChatMessageState _chatMessageState = TeamDuplicationChatBubbleViewControl.ChatMessageState.ChatHidden;

		// Token: 0x0400B8F8 RID: 47352
		[SerializeField]
		private RectTransform chatBgRtf;

		// Token: 0x0400B8F9 RID: 47353
		public float showDelay = 5f;

		// Token: 0x0400B8FA RID: 47354
		public GameObject chatRoot;

		// Token: 0x0400B8FB RID: 47355
		public Text chatContent;

		// Token: 0x0400B8FC RID: 47356
		public GameObject linkRoot;

		// Token: 0x0400B8FD RID: 47357
		public LinkParse linkParse;

		// Token: 0x02001C3D RID: 7229
		private enum ChatMessageState
		{
			// Token: 0x0400B8FF RID: 47359
			ChatShow,
			// Token: 0x0400B900 RID: 47360
			ChatHidden
		}
	}
}
