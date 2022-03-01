using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020041EA RID: 16874
	public class BeEventManager
	{
		// Token: 0x06017546 RID: 95558 RVA: 0x0072D8B0 File Offset: 0x0072BCB0
		public BeEventManager()
		{
			this.m_EventDic = new Dictionary<int, List<BeEvent.BeEventHandleNew>>();
		}

		// Token: 0x06017547 RID: 95559 RVA: 0x0072D8CE File Offset: 0x0072BCCE
		public void RemoveEvent(int type)
		{
			if (!this.m_removeEvents.Contains(type))
			{
				this.m_removeEvents.Add(type);
			}
		}

		// Token: 0x06017548 RID: 95560 RVA: 0x0072D8F0 File Offset: 0x0072BCF0
		public void Update()
		{
			for (int i = 0; i < this.m_removeEvents.Count; i++)
			{
				List<BeEvent.BeEventHandleNew> eventHandleList = null;
				if (this.m_EventDic.TryGetValue(this.m_removeEvents[i], out eventHandleList))
				{
					this._RemoveItem(eventHandleList);
				}
			}
			this.m_removeEvents.Clear();
		}

		// Token: 0x06017549 RID: 95561 RVA: 0x0072D950 File Offset: 0x0072BD50
		private void _RemoveItem(List<BeEvent.BeEventHandleNew> eventHandleList)
		{
			if (eventHandleList == null)
			{
				return;
			}
			for (int i = eventHandleList.Count - 1; i >= 0; i--)
			{
				if (eventHandleList[i] == null || eventHandleList[i].m_CanRemove)
				{
					eventHandleList.RemoveAt(i);
				}
			}
		}

		// Token: 0x0601754A RID: 95562 RVA: 0x0072D9A4 File Offset: 0x0072BDA4
		public BeEvent.BeEventHandleNew RegisterEvent(int type, BeEvent.BeEventHandleNew.Function function)
		{
			BeEvent.BeEventHandleNew beEventHandleNew = new BeEvent.BeEventHandleNew(type, function, this);
			if (!this.m_EventDic.ContainsKey(type))
			{
				List<BeEvent.BeEventHandleNew> list = new List<BeEvent.BeEventHandleNew>();
				list.Add(beEventHandleNew);
				this.m_EventDic.Add(type, list);
			}
			else
			{
				List<BeEvent.BeEventHandleNew> list2 = this.m_EventDic[type];
				list2.Add(beEventHandleNew);
			}
			return beEventHandleNew;
		}

		// Token: 0x0601754B RID: 95563 RVA: 0x0072DA00 File Offset: 0x0072BE00
		public void TriggerEvent(int eventType, BeEvent.BeEventParam eventParam)
		{
			if (!this.m_EventDic.ContainsKey(eventType))
			{
				return;
			}
			this.m_stackLevel++;
			if (this.m_stackLevel > Global.TriggerEventStackLevelLimit && this.m_stackLevel <= Global.MaxStackLevelLogLimit)
			{
				Logger.LogErrorFormat("trigger new event id {0} recurse all out of stack level {1} new param", new object[]
				{
					eventType,
					this.m_stackLevel
				});
			}
			List<BeEvent.BeEventHandleNew> list = this.m_EventDic[eventType];
			bool flag = false;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				BeEvent.BeEventHandleNew beEventHandleNew = list[i];
				if (beEventHandleNew == null || beEventHandleNew.m_CanRemove)
				{
					flag = true;
				}
				else
				{
					beEventHandleNew.DoFunc(eventParam);
				}
			}
			if (flag)
			{
				this.RemoveEvent(eventType);
			}
			this.m_stackLevel--;
		}

		// Token: 0x0601754C RID: 95564 RVA: 0x0072DAE0 File Offset: 0x0072BEE0
		public EventParam TriggerEvent(int eventType, EventParam eventParam)
		{
			if (!this.m_EventDic.ContainsKey(eventType))
			{
				return eventParam;
			}
			this.m_stackLevel++;
			if (this.m_stackLevel > Global.TriggerEventStackLevelLimit && this.m_stackLevel <= Global.MaxStackLevelLogLimit)
			{
				Logger.LogErrorFormat("trigger new event id {0} recurse all out of stack level {1}", new object[]
				{
					eventType,
					this.m_stackLevel
				});
			}
			BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
			beEventParam.FromStruct(eventParam);
			List<BeEvent.BeEventHandleNew> list = this.m_EventDic[eventType];
			bool flag = false;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				BeEvent.BeEventHandleNew beEventHandleNew = list[i];
				if (beEventHandleNew == null || beEventHandleNew.m_CanRemove)
				{
					flag = true;
				}
				else
				{
					beEventHandleNew.DoFunc(beEventParam);
				}
			}
			if (flag)
			{
				this.RemoveEvent(eventType);
			}
			beEventParam.ToStruct(out eventParam);
			DataStructPool.EventParamPool.Release(beEventParam);
			this.m_stackLevel--;
			return eventParam;
		}

		// Token: 0x0601754D RID: 95565 RVA: 0x0072DBDF File Offset: 0x0072BFDF
		public void RemoveSceneHandle(BeEvent.BeEventHandleNew handle)
		{
			if (handle != null)
			{
				this.RemoveEvent(handle.m_EventType);
			}
		}

		// Token: 0x0601754E RID: 95566 RVA: 0x0072DBF3 File Offset: 0x0072BFF3
		public void ClearAll()
		{
			this.m_EventDic.Clear();
		}

		// Token: 0x0601754F RID: 95567 RVA: 0x0072DC00 File Offset: 0x0072C000
		public Dictionary<int, List<BeEvent.BeEventHandleNew>> GetNewEventHandleList()
		{
			return this.m_EventDic;
		}

		// Token: 0x06017550 RID: 95568 RVA: 0x0072DC08 File Offset: 0x0072C008
		public void RemoveDeadHandle()
		{
			foreach (KeyValuePair<int, List<BeEvent.BeEventHandleNew>> keyValuePair in this.m_EventDic)
			{
				for (int i = keyValuePair.Value.Count - 1; i >= 0; i--)
				{
					List<BeEvent.BeEventHandleNew> value = keyValuePair.Value;
					if (value[i] != null && value[i].m_CanRemove)
					{
						value.RemoveAt(i);
					}
				}
			}
		}

		// Token: 0x04010C53 RID: 68691
		private Dictionary<int, List<BeEvent.BeEventHandleNew>> m_EventDic;

		// Token: 0x04010C54 RID: 68692
		private List<int> m_removeEvents = new List<int>();

		// Token: 0x04010C55 RID: 68693
		private int m_stackLevel;
	}
}
