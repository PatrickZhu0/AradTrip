using System;
using System.Collections.Generic;
using Network;

namespace GameClient
{
	// Token: 0x02000FD9 RID: 4057
	public class MessageEvents
	{
		// Token: 0x06009B2B RID: 39723 RVA: 0x001E05D8 File Offset: 0x001DE9D8
		public MessageEvents(uint msgID, bool mustWait = true)
		{
			this.AddMessage(msgID, mustWait);
		}

		// Token: 0x06009B2C RID: 39724 RVA: 0x001E05F3 File Offset: 0x001DE9F3
		public MessageEvents()
		{
		}

		// Token: 0x06009B2D RID: 39725 RVA: 0x001E0606 File Offset: 0x001DEA06
		public void AddMessage(uint msgID, bool mustWait = true)
		{
			if (this._GetMessage(msgID) == null)
			{
				this._AddMessage(msgID, mustWait);
			}
		}

		// Token: 0x06009B2E RID: 39726 RVA: 0x001E061C File Offset: 0x001DEA1C
		public void SetMessageData(uint msgID, MsgDATA data)
		{
			MessageEvents.Message message = this._GetMessage(msgID);
			if (message != null)
			{
				if (message.DataList == null)
				{
					message.DataList = new List<MsgDATA>();
				}
				message.DataList.Add(data);
			}
		}

		// Token: 0x06009B2F RID: 39727 RVA: 0x001E065C File Offset: 0x001DEA5C
		public MsgDATA GetMessageData(uint msgID)
		{
			MessageEvents.Message message = this._GetMessage(msgID);
			if (message != null && message.DataList != null)
			{
				return message.DataList[0];
			}
			return null;
		}

		// Token: 0x06009B30 RID: 39728 RVA: 0x001E0690 File Offset: 0x001DEA90
		public List<MsgDATA> GetMessageDatas(uint msgID)
		{
			MessageEvents.Message message = this._GetMessage(msgID);
			if (message != null)
			{
				return message.DataList;
			}
			return null;
		}

		// Token: 0x06009B31 RID: 39729 RVA: 0x001E06B3 File Offset: 0x001DEAB3
		public List<MessageEvents.Message> GetMessages()
		{
			return this.m_messages;
		}

		// Token: 0x06009B32 RID: 39730 RVA: 0x001E06BC File Offset: 0x001DEABC
		public bool IsAllMessageReceived()
		{
			for (int i = 0; i < this.m_messages.Count; i++)
			{
				if (this.m_messages[i].MustWait && this.m_messages[i].DataList == null)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009B33 RID: 39731 RVA: 0x001E0714 File Offset: 0x001DEB14
		public int GetNotReceivedMessageID()
		{
			for (int i = 0; i < this.m_messages.Count; i++)
			{
				if (this.m_messages[i].MustWait && this.m_messages[i].DataList == null)
				{
					return (int)this.m_messages[i].ID;
				}
			}
			return -1;
		}

		// Token: 0x06009B34 RID: 39732 RVA: 0x001E077C File Offset: 0x001DEB7C
		public string GetUnreceivedMessageDesc()
		{
			string text = "unreceived message:";
			for (int i = 0; i < this.m_messages.Count; i++)
			{
				if (this.m_messages[i].DataList == null && this.m_messages[i].MustWait)
				{
					text = text + ProtocolHelper.ID2Name(this.m_messages[i].ID) + " ";
				}
			}
			return text;
		}

		// Token: 0x06009B35 RID: 39733 RVA: 0x001E07FC File Offset: 0x001DEBFC
		private MessageEvents.Message _GetMessage(uint id)
		{
			for (int i = 0; i < this.m_messages.Count; i++)
			{
				if (this.m_messages[i].ID == id)
				{
					return this.m_messages[i];
				}
			}
			return null;
		}

		// Token: 0x06009B36 RID: 39734 RVA: 0x001E084C File Offset: 0x001DEC4C
		private void _AddMessage(uint id, bool mustWait)
		{
			MessageEvents.Message message = new MessageEvents.Message();
			message.ID = id;
			message.DataList = null;
			message.MustWait = mustWait;
			this.m_messages.Add(message);
		}

		// Token: 0x040054B4 RID: 21684
		private List<MessageEvents.Message> m_messages = new List<MessageEvents.Message>();

		// Token: 0x02000FDA RID: 4058
		public class Message
		{
			// Token: 0x040054B5 RID: 21685
			public uint ID;

			// Token: 0x040054B6 RID: 21686
			public List<MsgDATA> DataList;

			// Token: 0x040054B7 RID: 21687
			public bool MustWait;
		}
	}
}
