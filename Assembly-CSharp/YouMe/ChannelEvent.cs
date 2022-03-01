using System;

namespace YouMe
{
	// Token: 0x02004AA1 RID: 19105
	public class ChannelEvent
	{
		// Token: 0x0601BB46 RID: 113478 RVA: 0x00880C95 File Offset: 0x0087F095
		public ChannelEvent(StatusCode code, ChannelEventType eType, string channelID)
		{
			this._code = code;
			this._eventType = eType;
			this._channelID = channelID;
		}

		// Token: 0x1700253C RID: 9532
		// (get) Token: 0x0601BB47 RID: 113479 RVA: 0x00880CB2 File Offset: 0x0087F0B2
		public StatusCode Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x1700253D RID: 9533
		// (get) Token: 0x0601BB48 RID: 113480 RVA: 0x00880CBA File Offset: 0x0087F0BA
		public ChannelEventType EventType
		{
			get
			{
				return this._eventType;
			}
		}

		// Token: 0x1700253E RID: 9534
		// (get) Token: 0x0601BB49 RID: 113481 RVA: 0x00880CC2 File Offset: 0x0087F0C2
		public string ChannelID
		{
			get
			{
				return this._channelID;
			}
		}

		// Token: 0x0401354A RID: 79178
		private StatusCode _code;

		// Token: 0x0401354B RID: 79179
		private ChannelEventType _eventType;

		// Token: 0x0401354C RID: 79180
		private string _channelID;
	}
}
