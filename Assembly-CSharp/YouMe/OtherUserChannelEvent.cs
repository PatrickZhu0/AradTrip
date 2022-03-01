using System;

namespace YouMe
{
	// Token: 0x02004AA3 RID: 19107
	public class OtherUserChannelEvent
	{
		// Token: 0x0601BB4A RID: 113482 RVA: 0x00880CCA File Offset: 0x0087F0CA
		public OtherUserChannelEvent(OtherUserChannelEventType eType, string channelID, string userID)
		{
			this._eventType = eType;
			this._channelID = channelID;
			this._userID = userID;
		}

		// Token: 0x1700253F RID: 9535
		// (get) Token: 0x0601BB4B RID: 113483 RVA: 0x00880CE7 File Offset: 0x0087F0E7
		public string ChannelID
		{
			get
			{
				return this._channelID;
			}
		}

		// Token: 0x17002540 RID: 9536
		// (get) Token: 0x0601BB4C RID: 113484 RVA: 0x00880CEF File Offset: 0x0087F0EF
		public string UserID
		{
			get
			{
				return this._userID;
			}
		}

		// Token: 0x17002541 RID: 9537
		// (get) Token: 0x0601BB4D RID: 113485 RVA: 0x00880CF7 File Offset: 0x0087F0F7
		public OtherUserChannelEventType EventType
		{
			get
			{
				return this._eventType;
			}
		}

		// Token: 0x04013550 RID: 79184
		private string _channelID;

		// Token: 0x04013551 RID: 79185
		private string _userID;

		// Token: 0x04013552 RID: 79186
		private OtherUserChannelEventType _eventType;
	}
}
