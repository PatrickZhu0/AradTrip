using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GamePool
{
	// Token: 0x02000159 RID: 345
	internal class ObjectPool<T> where T : new()
	{
		// Token: 0x060009F3 RID: 2547 RVA: 0x0003479E File Offset: 0x00032B9E
		public ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
			this.m_ActionOnGet = actionOnGet;
			this.m_ActionOnRelease = actionOnRelease;
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x000347BF File Offset: 0x00032BBF
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x000347C7 File Offset: 0x00032BC7
		public int countAll { get; private set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x000347D0 File Offset: 0x00032BD0
		public int countActive
		{
			get
			{
				return this.countAll - this.countInactive;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x000347DF File Offset: 0x00032BDF
		public int countInactive
		{
			get
			{
				return this.m_Stack.Count;
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x000347EC File Offset: 0x00032BEC
		public T Get()
		{
			T t;
			if (this.m_Stack.Count == 0)
			{
				t = Activator.CreateInstance<T>();
				this.countAll++;
			}
			else
			{
				t = this.m_Stack.Pop();
			}
			if (this.m_ActionOnGet != null)
			{
				this.m_ActionOnGet.Invoke(t);
			}
			return t;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00034848 File Offset: 0x00032C48
		public void Release(T element)
		{
			if (this.m_Stack.Count > 0 && object.ReferenceEquals(this.m_Stack.Peek(), element))
			{
				Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
			}
			if (this.m_ActionOnRelease != null)
			{
				this.m_ActionOnRelease.Invoke(element);
			}
			this.m_Stack.Push(element);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x000348B3 File Offset: 0x00032CB3
		public void Clear()
		{
			this.countAll = 0;
			this.m_Stack.Clear();
		}

		// Token: 0x0400076C RID: 1900
		private readonly Stack<T> m_Stack = new Stack<T>();

		// Token: 0x0400076D RID: 1901
		private readonly UnityAction<T> m_ActionOnGet;

		// Token: 0x0400076E RID: 1902
		private readonly UnityAction<T> m_ActionOnRelease;
	}
}
