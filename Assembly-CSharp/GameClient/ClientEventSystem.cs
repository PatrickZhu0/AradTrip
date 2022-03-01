using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000FD2 RID: 4050
	public class ClientEventSystem
	{
		// Token: 0x06009B01 RID: 39681 RVA: 0x001DF7FF File Offset: 0x001DDBFF
		public void Clear()
		{
			this.m_eventBuffers.Clear();
			this.m_eventProcessors.Clear();
		}

		// Token: 0x06009B02 RID: 39682 RVA: 0x001DF818 File Offset: 0x001DDC18
		public void PopupLeakedEvents()
		{
			foreach (KeyValuePair<EUIEventID, List<ClientEventSystem.UIEventHandler>> keyValuePair in this.m_eventProcessors)
			{
				if (keyValuePair.Value.Count > 0)
				{
					Dictionary<EUIEventID, List<ClientEventSystem.UIEventHandler>>.Enumerator enumerator;
					KeyValuePair<EUIEventID, List<ClientEventSystem.UIEventHandler>> keyValuePair2 = enumerator.Current;
					List<ClientEventSystem.UIEventHandler> value = keyValuePair2.Value;
					for (int i = 0; i < value.Count; i++)
					{
					}
				}
			}
		}

		// Token: 0x06009B03 RID: 39683 RVA: 0x001DF888 File Offset: 0x001DDC88
		public void RegisterEventHandler(EUIEventID id, ClientEventSystem.UIEventHandler eventHandler)
		{
			if (!this.m_eventProcessors.ContainsKey(id))
			{
				this.m_eventProcessors.Add(id, new List<ClientEventSystem.UIEventHandler>());
			}
			List<ClientEventSystem.UIEventHandler> list = this.m_eventProcessors[id];
			if (!list.Contains(eventHandler))
			{
				list.Add(eventHandler);
			}
		}

		// Token: 0x06009B04 RID: 39684 RVA: 0x001DF8D8 File Offset: 0x001DDCD8
		public void UnRegisterEventHandler(EUIEventID id, ClientEventSystem.UIEventHandler eventHandler)
		{
			List<ClientEventSystem.UIEventHandler> list;
			this.m_eventProcessors.TryGetValue(id, out list);
			if (list != null)
			{
				list.Remove(eventHandler);
			}
		}

		// Token: 0x06009B05 RID: 39685 RVA: 0x001DF904 File Offset: 0x001DDD04
		public UIEvent GetIdleUIEvent()
		{
			UIEvent uievent;
			for (int i = 0; i < this.m_eventBuffers.Count; i++)
			{
				uievent = this.m_eventBuffers[i];
				if (!uievent.IsUsing)
				{
					uievent.Initialize();
					uievent.IsUsing = true;
					return uievent;
				}
			}
			uievent = new UIEvent();
			this.m_eventBuffers.Add(uievent);
			uievent.Initialize();
			uievent.IsUsing = true;
			return uievent;
		}

		// Token: 0x06009B06 RID: 39686 RVA: 0x001DF974 File Offset: 0x001DDD74
		public static void SendUIEventEx(EUIEventID id, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
		{
			UIEventSystem instance = UIEventSystem.GetInstance();
			if (instance == null)
			{
				return;
			}
			UIEvent idleUIEvent = instance.GetIdleUIEvent();
			idleUIEvent.EventID = id;
			idleUIEvent.Param1 = param1;
			idleUIEvent.Param2 = param2;
			idleUIEvent.Param3 = param3;
			idleUIEvent.Param4 = param4;
			instance._HandleUIEvent(idleUIEvent);
		}

		// Token: 0x06009B07 RID: 39687 RVA: 0x001DF9C0 File Offset: 0x001DDDC0
		public void SendUIEvent(EUIEventID id, object param1 = null, object param2 = null, object param3 = null, object param4 = null)
		{
			UIEvent idleUIEvent = this.GetIdleUIEvent();
			idleUIEvent.EventID = id;
			idleUIEvent.Param1 = param1;
			idleUIEvent.Param2 = param2;
			idleUIEvent.Param3 = param3;
			idleUIEvent.Param4 = param4;
			this._HandleUIEvent(idleUIEvent);
		}

		// Token: 0x06009B08 RID: 39688 RVA: 0x001DFA00 File Offset: 0x001DDE00
		public void SendUIEvent(UIEvent uiEvent)
		{
			this._HandleUIEvent(uiEvent);
		}

		// Token: 0x06009B09 RID: 39689 RVA: 0x001DFA0C File Offset: 0x001DDE0C
		protected void _HandleUIEvent(UIEvent uiEvent)
		{
			if (uiEvent != null)
			{
				try
				{
					if (this.m_eventProcessors != null)
					{
						List<ClientEventSystem.UIEventHandler> list;
						this.m_eventProcessors.TryGetValue(uiEvent.EventID, out list);
						if (list != null)
						{
							List<ClientEventSystem.UIEventHandler> list2 = new List<ClientEventSystem.UIEventHandler>(list);
							for (int i = 0; i < list2.Count; i++)
							{
								list2[i](uiEvent);
							}
						}
					}
					uiEvent.IsUsing = false;
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
				}
			}
			else
			{
				Logger.LogError("uiEvent is null in [_HandleUIEvent].");
			}
		}

		// Token: 0x0400549B RID: 21659
		protected Dictionary<EUIEventID, List<ClientEventSystem.UIEventHandler>> m_eventProcessors = new Dictionary<EUIEventID, List<ClientEventSystem.UIEventHandler>>();

		// Token: 0x0400549C RID: 21660
		protected List<UIEvent> m_eventBuffers = new List<UIEvent>();

		// Token: 0x0400549D RID: 21661
		private bool bLock;

		// Token: 0x02000FD3 RID: 4051
		// (Invoke) Token: 0x06009B0B RID: 39691
		public delegate void UIEventHandler(UIEvent uiEvent);
	}
}
