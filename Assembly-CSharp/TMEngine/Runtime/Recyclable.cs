using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200470F RID: 18191
	public abstract class Recyclable
	{
		// Token: 0x170021E6 RID: 8678
		// (get) Token: 0x0601A182 RID: 106882
		public abstract string Name { get; }

		// Token: 0x170021E7 RID: 8679
		// (get) Token: 0x0601A183 RID: 106883 RVA: 0x0081EF19 File Offset: 0x0081D319
		public bool IsRecycled
		{
			get
			{
				return this.m_IsRecycled;
			}
		}

		// Token: 0x170021E8 RID: 8680
		// (get) Token: 0x0601A184 RID: 106884
		public abstract bool IsValid { get; }

		// Token: 0x0601A185 RID: 106885 RVA: 0x0081EF21 File Offset: 0x0081D321
		public virtual void OnCreate()
		{
		}

		// Token: 0x0601A186 RID: 106886 RVA: 0x0081EF23 File Offset: 0x0081D323
		public virtual void OnReuse()
		{
			this.m_IsRecycled = false;
		}

		// Token: 0x0601A187 RID: 106887 RVA: 0x0081EF2C File Offset: 0x0081D32C
		public virtual void OnRecycle()
		{
			this.m_IsRecycled = true;
		}

		// Token: 0x0601A188 RID: 106888
		public abstract void OnRelease();

		// Token: 0x040125C9 RID: 75209
		private bool m_IsRecycled;
	}
}
