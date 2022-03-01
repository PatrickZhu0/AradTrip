using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000DE3 RID: 3555
	internal class SystemSwitchEventManager : Singleton<SystemSwitchEventManager>
	{
		// Token: 0x06008F52 RID: 36690 RVA: 0x001A889C File Offset: 0x001A6C9C
		public void RegisterEvent(SystemEventType eSystemEventType, SystemUnityAction action)
		{
			if (!this.m_events.ContainsKey(eSystemEventType))
			{
				this.m_events.Add(eSystemEventType, action);
			}
			else
			{
				this.m_events[eSystemEventType] = action;
			}
		}

		// Token: 0x06008F53 RID: 36691 RVA: 0x001A88D0 File Offset: 0x001A6CD0
		public void TriggerEvent(SystemEventType eSystemEventType)
		{
			if (this.m_events.ContainsKey(eSystemEventType))
			{
				SystemUnityAction systemUnityAction = this.m_events[eSystemEventType];
				if (systemUnityAction != null)
				{
					systemUnityAction();
				}
				this.m_events.Remove(eSystemEventType);
			}
		}

		// Token: 0x06008F54 RID: 36692 RVA: 0x001A8914 File Offset: 0x001A6D14
		public void RemoveEvent(SystemEventType eSystemEventType)
		{
			if (this.m_events.ContainsKey(eSystemEventType))
			{
				this.m_events.Remove(eSystemEventType);
			}
		}

		// Token: 0x0400471D RID: 18205
		private Dictionary<SystemEventType, SystemUnityAction> m_events = new Dictionary<SystemEventType, SystemUnityAction>();
	}
}
