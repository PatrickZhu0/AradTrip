using System;

namespace GameClient
{
	// Token: 0x02000DB1 RID: 3505
	public class CachedObject
	{
		// Token: 0x06008DD4 RID: 36308 RVA: 0x00007968 File Offset: 0x00005D68
		public virtual void OnCreate(object[] param)
		{
		}

		// Token: 0x06008DD5 RID: 36309 RVA: 0x0000796A File Offset: 0x00005D6A
		public virtual void OnDestroy()
		{
		}

		// Token: 0x06008DD6 RID: 36310 RVA: 0x0000796C File Offset: 0x00005D6C
		public virtual void OnRecycle()
		{
		}

		// Token: 0x06008DD7 RID: 36311 RVA: 0x0000796E File Offset: 0x00005D6E
		public virtual void OnDecycle(object[] param)
		{
		}

		// Token: 0x06008DD8 RID: 36312 RVA: 0x00007970 File Offset: 0x00005D70
		public virtual void OnRefresh(object[] param)
		{
		}

		// Token: 0x06008DD9 RID: 36313 RVA: 0x00007972 File Offset: 0x00005D72
		public virtual void Enable()
		{
		}

		// Token: 0x06008DDA RID: 36314 RVA: 0x00007974 File Offset: 0x00005D74
		public virtual void Disable()
		{
		}

		// Token: 0x06008DDB RID: 36315 RVA: 0x00007976 File Offset: 0x00005D76
		public virtual bool NeedFilter(object[] param)
		{
			return false;
		}

		// Token: 0x06008DDC RID: 36316 RVA: 0x00007979 File Offset: 0x00005D79
		public virtual void SetAsLastSibling()
		{
		}
	}
}
