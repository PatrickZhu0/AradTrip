using System;

namespace YouMe
{
	// Token: 0x02004AA7 RID: 19111
	public class IMReconnectEvent
	{
		// Token: 0x0601BB55 RID: 113493 RVA: 0x00880D5B File Offset: 0x0087F15B
		public IMReconnectEvent(ReconnectEventType eType, ReconnectEventResult result)
		{
			this._type = eType;
			this._result = result;
		}

		// Token: 0x17002545 RID: 9541
		// (get) Token: 0x0601BB56 RID: 113494 RVA: 0x00880D71 File Offset: 0x0087F171
		public ReconnectEventType EventType
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17002546 RID: 9542
		// (get) Token: 0x0601BB57 RID: 113495 RVA: 0x00880D79 File Offset: 0x0087F179
		public ReconnectEventResult Result
		{
			get
			{
				return this._result;
			}
		}

		// Token: 0x0401355E RID: 79198
		private ReconnectEventType _type;

		// Token: 0x0401355F RID: 79199
		private ReconnectEventResult _result;
	}
}
