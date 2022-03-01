using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x020046F6 RID: 18166
	internal class FrameStackCache<T> where T : new()
	{
		// Token: 0x0601A0DF RID: 106719 RVA: 0x0081E200 File Offset: 0x0081C600
		public FrameStackCache(FrameStackCache<T>.OnAquiredAction onAquired, FrameStackCache<T>.OnReleasedAction onReleased)
		{
			this.m_OnAquiredAction = onAquired;
			this.m_OnReleasedAction = onReleased;
		}

		// Token: 0x170021D0 RID: 8656
		// (get) Token: 0x0601A0E0 RID: 106720 RVA: 0x0081E221 File Offset: 0x0081C621
		public int TotalAllocCount
		{
			get
			{
				return this.m_TotalAllocCount;
			}
		}

		// Token: 0x170021D1 RID: 8657
		// (get) Token: 0x0601A0E1 RID: 106721 RVA: 0x0081E229 File Offset: 0x0081C629
		public int UsingCount
		{
			get
			{
				return this.m_UsingCount;
			}
		}

		// Token: 0x170021D2 RID: 8658
		// (get) Token: 0x0601A0E2 RID: 106722 RVA: 0x0081E231 File Offset: 0x0081C631
		public int FreeCount
		{
			get
			{
				return this.m_FreeCount;
			}
		}

		// Token: 0x0601A0E3 RID: 106723 RVA: 0x0081E23C File Offset: 0x0081C63C
		public T Acquire()
		{
			if (this.m_StackDeepCount < 4096)
			{
				this.m_StackDeepCount++;
				T t;
				if (this.m_ObjectFrameStack.Count == 0)
				{
					t = Activator.CreateInstance<T>();
					this.m_TotalAllocCount++;
				}
				else
				{
					t = this.m_ObjectFrameStack.Pop();
				}
				if (this.m_OnAquiredAction != null)
				{
					this.m_OnAquiredAction(t);
				}
				return t;
			}
			TMDebug.LogErrorFormat("Allocate stack deep out of max range [{0}], did you acquire and release in different scope or using a terrible recursion?", new object[]
			{
				4096
			});
			return default(T);
		}

		// Token: 0x0601A0E4 RID: 106724 RVA: 0x0081E2DC File Offset: 0x0081C6DC
		public void Recycle(T element)
		{
			if (this.m_ObjectFrameStack.Count > 0 && object.ReferenceEquals(this.m_ObjectFrameStack.Peek(), element))
			{
				TMDebug.LogErrorFormat("Internal error. Trying to destroy object that is already released to pool.", new object[0]);
			}
			if (0 < this.m_StackDeepCount)
			{
				this.m_StackDeepCount--;
				if (this.m_OnReleasedAction != null)
				{
					this.m_OnReleasedAction(element);
				}
				this.m_ObjectFrameStack.Push(element);
				return;
			}
			TMDebug.LogErrorFormat("Allocate stack deep less than zero, did you acquire and release in different scope or using a terrible recursion?", new object[0]);
		}

		// Token: 0x0401259D RID: 75165
		private const int CONST_MAX_STACK_DEEP = 4096;

		// Token: 0x0401259E RID: 75166
		private readonly FrameStackCache<T>.OnAquiredAction m_OnAquiredAction;

		// Token: 0x0401259F RID: 75167
		private readonly FrameStackCache<T>.OnReleasedAction m_OnReleasedAction;

		// Token: 0x040125A0 RID: 75168
		private readonly Stack<T> m_ObjectFrameStack = new Stack<T>();

		// Token: 0x040125A1 RID: 75169
		private int m_TotalAllocCount;

		// Token: 0x040125A2 RID: 75170
		private int m_UsingCount;

		// Token: 0x040125A3 RID: 75171
		private int m_FreeCount;

		// Token: 0x040125A4 RID: 75172
		private int m_StackDeepCount;

		// Token: 0x020046F7 RID: 18167
		// (Invoke) Token: 0x0601A0E6 RID: 106726
		public delegate void OnAquiredAction(T obj);

		// Token: 0x020046F8 RID: 18168
		// (Invoke) Token: 0x0601A0EA RID: 106730
		public delegate void OnReleasedAction(T obj);
	}
}
