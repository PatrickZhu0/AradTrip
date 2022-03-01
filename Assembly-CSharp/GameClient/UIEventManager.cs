using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000FCB RID: 4043
	public class UIEventManager : Singleton<UIEventManager>
	{
		// Token: 0x06009AEC RID: 39660 RVA: 0x001DF36D File Offset: 0x001DD76D
		public UIEventManager()
		{
			this.m_EventDic = new Dictionary<int, List<UIEventNew.UIEventHandleNew>>();
		}

		// Token: 0x06009AED RID: 39661 RVA: 0x001DF380 File Offset: 0x001DD780
		public UIEventNew.UIEventHandleNew RegisterUIEvent(EUIEventID type, UIEventNew.UIEventHandleNew.Function function)
		{
			UIEventNew.UIEventHandleNew uieventHandleNew = new UIEventNew.UIEventHandleNew((int)type, function);
			if (!this.m_EventDic.ContainsKey((int)type))
			{
				List<UIEventNew.UIEventHandleNew> list = new List<UIEventNew.UIEventHandleNew>();
				list.Add(uieventHandleNew);
				this.m_EventDic.Add((int)type, list);
			}
			else
			{
				List<UIEventNew.UIEventHandleNew> list2 = this.m_EventDic[(int)type];
				list2.Add(uieventHandleNew);
			}
			return uieventHandleNew;
		}

		// Token: 0x06009AEE RID: 39662 RVA: 0x001DF3DC File Offset: 0x001DD7DC
		public void UnRegisterUIEvent(UIEventNew.UIEventHandleNew handler)
		{
			if (handler == null)
			{
				return;
			}
			List<UIEventNew.UIEventHandleNew> list;
			this.m_EventDic.TryGetValue(handler.m_EventType, out list);
			if (list != null)
			{
				list.Remove(handler);
			}
			handler.Remove();
		}

		// Token: 0x06009AEF RID: 39663 RVA: 0x001DF418 File Offset: 0x001DD818
		public void SendUIEvent(EUIEventID eventType, UIEventNew.UIEventParamNew eventParam)
		{
			if (!this.m_EventDic.ContainsKey((int)eventType))
			{
				return;
			}
			this.m_stackLevel++;
			if (this.m_stackLevel > Global.TriggerSingleEventStackLevelLimit && this.m_stackLevel <= Global.MaxStackLevelLogLimit)
			{
				Logger.LogErrorFormat("UIEventHandleNew SendUIEvent id {0} DoFunc out of Recurse stack Level {1}", new object[]
				{
					eventType,
					this.m_stackLevel
				});
			}
			List<UIEventNew.UIEventHandleNew> list = this.m_EventDic[(int)eventType];
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i] != null)
				{
					list[i].DoFunc(eventParam);
				}
			}
			this.m_stackLevel--;
		}

		// Token: 0x06009AF0 RID: 39664 RVA: 0x001DF4E0 File Offset: 0x001DD8E0
		public UIEventParam SendUIEvent(EUIEventID eventType, UIEventParam eventParam)
		{
			if (!this.m_EventDic.ContainsKey((int)eventType))
			{
				return eventParam;
			}
			this.m_stackLevel++;
			if (this.m_stackLevel > Global.TriggerSingleEventStackLevelLimit && this.m_stackLevel <= Global.MaxStackLevelLogLimit)
			{
				Logger.LogErrorFormat("UIEventHandleNew SendUIEvent id {0} DoFunc out of Recurse stack Level {1}", new object[]
				{
					eventType,
					this.m_stackLevel
				});
			}
			UIEventNew.UIEventParamNew uieventParamNew = DataStructPool.UIEventParamPool.Get();
			uieventParamNew.FromStruct(eventParam);
			List<UIEventNew.UIEventHandleNew> list = this.m_EventDic[(int)eventType];
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i] != null)
				{
					list[i].DoFunc(uieventParamNew);
				}
			}
			this.m_stackLevel--;
			uieventParamNew.ToStruct(out eventParam);
			DataStructPool.UIEventParamPool.Release(uieventParamNew);
			return eventParam;
		}

		// Token: 0x06009AF1 RID: 39665 RVA: 0x001DF5C3 File Offset: 0x001DD9C3
		public void ClearAll()
		{
			this.m_EventDic.Clear();
		}

		// Token: 0x06009AF2 RID: 39666 RVA: 0x001DF5D0 File Offset: 0x001DD9D0
		public Dictionary<int, List<UIEventNew.UIEventHandleNew>> GetNewEventHandleList()
		{
			return this.m_EventDic;
		}

		// Token: 0x04005484 RID: 21636
		private Dictionary<int, List<UIEventNew.UIEventHandleNew>> m_EventDic;

		// Token: 0x04005485 RID: 21637
		private int m_stackLevel;
	}
}
