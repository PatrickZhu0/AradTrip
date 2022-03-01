using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FDE RID: 4062
	public class WaitNetMessage : IEnumerator, IEnumeratorLifeCycle
	{
		// Token: 0x06009B44 RID: 39748 RVA: 0x001E0EF4 File Offset: 0x001DF2F4
		public WaitNetMessage(MessageEvents msgEvents, float waitTime = 0f, bool bShowWaitFrame = true)
		{
			this._msgEvnets = msgEvents;
			this._handle = new Action<MsgDATA>(this._OnMessageReceived);
			this.m_time = waitTime;
			if (this.m_time <= 0f)
			{
				this.m_waitForever = true;
			}
			else
			{
				this.m_waitForever = false;
			}
			List<MessageEvents.Message> messages = this._msgEvnets.GetMessages();
			for (int i = 0; i < messages.Count; i++)
			{
				NetProcess.AddMsgHandler(messages[i].ID, this._handle);
			}
			this.m_bShowWaitFrame = bShowWaitFrame;
			if (this.m_bShowWaitFrame)
			{
				WaitNetMessageFrame.TryOpen();
				this.mHasOpenWaitNetMessageFrame = true;
			}
		}

		// Token: 0x06009B45 RID: 39749 RVA: 0x001E0FA9 File Offset: 0x001DF3A9
		public void OnAdd()
		{
		}

		// Token: 0x06009B46 RID: 39750 RVA: 0x001E0FAB File Offset: 0x001DF3AB
		public void OnRemove()
		{
			if (this.m_bShowWaitFrame && this.mHasOpenWaitNetMessageFrame)
			{
				WaitNetMessageFrame.TryClose();
				this.mHasOpenWaitNetMessageFrame = false;
			}
		}

		// Token: 0x17001943 RID: 6467
		// (get) Token: 0x06009B47 RID: 39751 RVA: 0x001E0FCF File Offset: 0x001DF3CF
		public object Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06009B48 RID: 39752 RVA: 0x001E0FD4 File Offset: 0x001DF3D4
		public bool MoveNext()
		{
			bool flag = false;
			if (!this.m_waitForever)
			{
				this.m_time -= Time.deltaTime;
				if (this.m_time > 0f)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				this._RemoveMsgHandlers();
				this._LogMessageUnReceived();
				if (this.m_bShowWaitFrame)
				{
					WaitNetMessageFrame.TryClose();
					this.mHasOpenWaitNetMessageFrame = false;
				}
				return false;
			}
			if (!this._msgEvnets.IsAllMessageReceived())
			{
				return true;
			}
			this._RemoveMsgHandlers();
			if (this.m_bShowWaitFrame)
			{
				WaitNetMessageFrame.TryClose();
				this.mHasOpenWaitNetMessageFrame = false;
			}
			return false;
		}

		// Token: 0x06009B49 RID: 39753 RVA: 0x001E1074 File Offset: 0x001DF474
		public void Reset()
		{
		}

		// Token: 0x06009B4A RID: 39754 RVA: 0x001E1076 File Offset: 0x001DF476
		protected void _OnMessageReceived(MsgDATA data)
		{
			if (data == null)
			{
				Logger.LogError("WaitNetMessage._OnMessageReceived ==>> data is null!!");
				return;
			}
			this._msgEvnets.SetMessageData(data.id, data);
		}

		// Token: 0x06009B4B RID: 39755 RVA: 0x001E109C File Offset: 0x001DF49C
		protected void _RemoveMsgHandlers()
		{
			List<MessageEvents.Message> messages = this._msgEvnets.GetMessages();
			for (int i = 0; i < messages.Count; i++)
			{
				NetProcess.RemoveMsgHandler(messages[i].ID, this._handle);
			}
		}

		// Token: 0x06009B4C RID: 39756 RVA: 0x001E10E4 File Offset: 0x001DF4E4
		protected void _LogMessageUnReceived()
		{
			List<MessageEvents.Message> messages = this._msgEvnets.GetMessages();
			string text = "time out !! unreceive message: ";
			for (int i = 0; i < messages.Count; i++)
			{
				if (messages[i].DataList == null && messages[i].MustWait)
				{
					text = text + ProtocolHelper.ID2Name(messages[i].ID) + " ";
				}
			}
			Logger.LogError(text);
		}

		// Token: 0x040054C2 RID: 21698
		private MessageEvents _msgEvnets;

		// Token: 0x040054C3 RID: 21699
		private Action<MsgDATA> _handle;

		// Token: 0x040054C4 RID: 21700
		private float m_time;

		// Token: 0x040054C5 RID: 21701
		private bool m_waitForever;

		// Token: 0x040054C6 RID: 21702
		private bool m_bShowWaitFrame;

		// Token: 0x040054C7 RID: 21703
		private bool mHasOpenWaitNetMessageFrame = true;
	}
}
