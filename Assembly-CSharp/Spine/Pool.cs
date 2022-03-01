using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x020049A2 RID: 18850
	public class Pool<T> where T : class, new()
	{
		// Token: 0x0601B184 RID: 110980 RVA: 0x008567BC File Offset: 0x00854BBC
		public Pool(int initialCapacity = 16, int max = 2147483647)
		{
			this.freeObjects = new Stack<T>(initialCapacity);
			this.max = max;
		}

		// Token: 0x17002310 RID: 8976
		// (get) Token: 0x0601B185 RID: 110981 RVA: 0x008567D7 File Offset: 0x00854BD7
		public int Count
		{
			get
			{
				return this.freeObjects.Count;
			}
		}

		// Token: 0x17002311 RID: 8977
		// (get) Token: 0x0601B186 RID: 110982 RVA: 0x008567E4 File Offset: 0x00854BE4
		// (set) Token: 0x0601B187 RID: 110983 RVA: 0x008567EC File Offset: 0x00854BEC
		public int Peak { get; private set; }

		// Token: 0x0601B188 RID: 110984 RVA: 0x008567F5 File Offset: 0x00854BF5
		public T Obtain()
		{
			return (this.freeObjects.Count != 0) ? this.freeObjects.Pop() : Activator.CreateInstance<T>();
		}

		// Token: 0x0601B189 RID: 110985 RVA: 0x0085681C File Offset: 0x00854C1C
		public void Free(T obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj", "obj cannot be null");
			}
			if (this.freeObjects.Count < this.max)
			{
				this.freeObjects.Push(obj);
				this.Peak = Math.Max(this.Peak, this.freeObjects.Count);
			}
			this.Reset(obj);
		}

		// Token: 0x0601B18A RID: 110986 RVA: 0x00856889 File Offset: 0x00854C89
		public void Clear()
		{
			this.freeObjects.Clear();
		}

		// Token: 0x0601B18B RID: 110987 RVA: 0x00856898 File Offset: 0x00854C98
		protected void Reset(T obj)
		{
			Pool<T>.IPoolable poolable = obj as Pool<T>.IPoolable;
			if (poolable != null)
			{
				poolable.Reset();
			}
		}

		// Token: 0x04012E60 RID: 77408
		public readonly int max;

		// Token: 0x04012E61 RID: 77409
		private readonly Stack<T> freeObjects;

		// Token: 0x020049A3 RID: 18851
		public interface IPoolable
		{
			// Token: 0x0601B18C RID: 110988
			void Reset();
		}
	}
}
