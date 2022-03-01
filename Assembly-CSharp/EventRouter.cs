using System;

// Token: 0x02000DC5 RID: 3525
public class EventRouter<T>
{
	// Token: 0x06008EA8 RID: 36520 RVA: 0x001A6F6F File Offset: 0x001A536F
	public void AddEventHandler(T eventType, Action handler)
	{
		if (this.OnHandlerAdding(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action)Delegate.Combine((Action)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EA9 RID: 36521 RVA: 0x001A6FA6 File Offset: 0x001A53A6
	public void AddEventHandler<T1>(T eventType, Action<T1> handler)
	{
		if (this.OnHandlerAdding(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1>)Delegate.Combine((Action<T1>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EAA RID: 36522 RVA: 0x001A6FDD File Offset: 0x001A53DD
	public void AddEventHandler<T1, T2>(T eventType, Action<T1, T2> handler)
	{
		if (this.OnHandlerAdding(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2>)Delegate.Combine((Action<T1, T2>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EAB RID: 36523 RVA: 0x001A7014 File Offset: 0x001A5414
	public void AddEventHandler<T1, T2, T3>(T eventType, Action<T1, T2, T3> handler)
	{
		if (this.OnHandlerAdding(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2, T3>)Delegate.Combine((Action<T1, T2, T3>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EAC RID: 36524 RVA: 0x001A704B File Offset: 0x001A544B
	public void AddEventHandler<T1, T2, T3, T4>(T eventType, Action<T1, T2, T3, T4> handler)
	{
		if (this.OnHandlerAdding(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2, T3, T4>)Delegate.Combine((Action<T1, T2, T3, T4>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EAD RID: 36525 RVA: 0x001A7084 File Offset: 0x001A5484
	public void BroadCastEvent(T eventType)
	{
		if (this.OnBroadCasting(eventType))
		{
			Action action = this.m_eventTable[eventType] as Action;
			if (action != null)
			{
				action();
			}
		}
	}

	// Token: 0x06008EAE RID: 36526 RVA: 0x001A70BC File Offset: 0x001A54BC
	public void BroadCastEvent<T1>(T eventType, T1 arg1)
	{
		if (this.OnBroadCasting(eventType))
		{
			Action<T1> action = this.m_eventTable[eventType] as Action<T1>;
			if (action != null)
			{
				action(arg1);
			}
		}
	}

	// Token: 0x06008EAF RID: 36527 RVA: 0x001A70F4 File Offset: 0x001A54F4
	public void BroadCastEvent<T1, T2>(T eventType, T1 arg1, T2 arg2)
	{
		if (this.OnBroadCasting(eventType))
		{
			Action<T1, T2> action = this.m_eventTable[eventType] as Action<T1, T2>;
			if (action != null)
			{
				action(arg1, arg2);
			}
		}
	}

	// Token: 0x06008EB0 RID: 36528 RVA: 0x001A7130 File Offset: 0x001A5530
	public void BroadCastEvent<T1, T2, T3>(T eventType, T1 arg1, T2 arg2, T3 arg3)
	{
		if (this.OnBroadCasting(eventType))
		{
			Action<T1, T2, T3> action = this.m_eventTable[eventType] as Action<T1, T2, T3>;
			if (action != null)
			{
				action(arg1, arg2, arg3);
			}
		}
	}

	// Token: 0x06008EB1 RID: 36529 RVA: 0x001A716C File Offset: 0x001A556C
	public void BroadCastEvent<T1, T2, T3, T4>(T eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		if (this.OnBroadCasting(eventType))
		{
			Action<T1, T2, T3, T4> action = this.m_eventTable[eventType] as Action<T1, T2, T3, T4>;
			if (action != null)
			{
				action(arg1, arg2, arg3, arg4);
			}
		}
	}

	// Token: 0x06008EB2 RID: 36530 RVA: 0x001A71A9 File Offset: 0x001A55A9
	public void ClearAllEvents()
	{
		this.m_eventTable.Clear();
	}

	// Token: 0x06008EB3 RID: 36531 RVA: 0x001A71B6 File Offset: 0x001A55B6
	private bool OnBroadCasting(T eventType)
	{
		return this.m_eventTable.ContainsKey(eventType);
	}

	// Token: 0x06008EB4 RID: 36532 RVA: 0x001A71C4 File Offset: 0x001A55C4
	private bool OnHandlerAdding(T eventType, Delegate handler)
	{
		bool result = true;
		if (!this.m_eventTable.ContainsKey(eventType))
		{
			this.m_eventTable.Add(eventType, null);
		}
		Delegate @delegate = this.m_eventTable[eventType];
		if (@delegate != null && @delegate.GetType() != handler.GetType())
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06008EB5 RID: 36533 RVA: 0x001A7218 File Offset: 0x001A5618
	private bool OnHandlerRemoving(T eventType, Delegate handler)
	{
		bool flag = true;
		if (this.m_eventTable.ContainsKey(eventType))
		{
			Delegate @delegate = this.m_eventTable[eventType];
			return @delegate != null && @delegate.GetType() == handler.GetType() && flag;
		}
		return false;
	}

	// Token: 0x06008EB6 RID: 36534 RVA: 0x001A7265 File Offset: 0x001A5665
	public void RemoveEventHandler(T eventType, Action handler)
	{
		if (this.OnHandlerRemoving(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action)Delegate.Remove((Action)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EB7 RID: 36535 RVA: 0x001A729C File Offset: 0x001A569C
	public void RemoveEventHandler<T1>(T eventType, Action<T1> handler)
	{
		if (this.OnHandlerRemoving(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1>)Delegate.Remove((Action<T1>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EB8 RID: 36536 RVA: 0x001A72D3 File Offset: 0x001A56D3
	public void RemoveEventHandler<T1, T2>(T eventType, Action<T1, T2> handler)
	{
		if (this.OnHandlerRemoving(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2>)Delegate.Remove((Action<T1, T2>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EB9 RID: 36537 RVA: 0x001A730A File Offset: 0x001A570A
	public void RemoveEventHandler<T1, T2, T3>(T eventType, Action<T1, T2, T3> handler)
	{
		if (this.OnHandlerRemoving(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2, T3>)Delegate.Remove((Action<T1, T2, T3>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x06008EBA RID: 36538 RVA: 0x001A7341 File Offset: 0x001A5741
	public void RemoveEventHandler<T1, T2, T3, T4>(T eventType, Action<T1, T2, T3, T4> handler)
	{
		if (this.OnHandlerRemoving(eventType, handler))
		{
			this.m_eventTable[eventType] = (Action<T1, T2, T3, T4>)Delegate.Remove((Action<T1, T2, T3, T4>)this.m_eventTable[eventType], handler);
		}
	}

	// Token: 0x040046C0 RID: 18112
	public DictionaryView<T, Delegate> m_eventTable = new DictionaryView<T, Delegate>();
}
