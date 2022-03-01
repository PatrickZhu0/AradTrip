using System;

namespace Assets.Scripts.Common
{
	// Token: 0x02000250 RID: 592
	public class ClassObjPool<T> : ClassObjPoolBase where T : PooledClassObject, new()
	{
		// Token: 0x06001366 RID: 4966 RVA: 0x0006872C File Offset: 0x00066B2C
		public static T Get()
		{
			if (ClassObjPool<T>.instance == null)
			{
				ClassObjPool<T>.instance = new ClassObjPool<T>();
			}
			if (ClassObjPool<T>.instance.pool.Count > 0)
			{
				T t = (T)((object)ClassObjPool<T>.instance.pool[ClassObjPool<T>.instance.pool.Count - 1]);
				ClassObjPool<T>.instance.pool.RemoveAt(ClassObjPool<T>.instance.pool.Count - 1);
				ClassObjPool<T>.instance.reqSeq += 1U;
				t.usingSeq = ClassObjPool<T>.instance.reqSeq;
				t.holder = ClassObjPool<T>.instance;
				t.OnUse();
				return t;
			}
			T t2 = Activator.CreateInstance<T>();
			ClassObjPool<T>.instance.reqSeq += 1U;
			t2.usingSeq = ClassObjPool<T>.instance.reqSeq;
			t2.holder = ClassObjPool<T>.instance;
			t2.OnUse();
			return t2;
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x00068839 File Offset: 0x00066C39
		public static uint NewSeq()
		{
			if (ClassObjPool<T>.instance == null)
			{
				ClassObjPool<T>.instance = new ClassObjPool<T>();
			}
			ClassObjPool<T>.instance.reqSeq += 1U;
			return ClassObjPool<T>.instance.reqSeq;
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x0006886C File Offset: 0x00066C6C
		public override void Release(PooledClassObject obj)
		{
			T t = obj as T;
			obj.usingSeq = 0U;
			this.pool.Add(t);
		}

		// Token: 0x04000D2E RID: 3374
		private static ClassObjPool<T> instance;
	}
}
