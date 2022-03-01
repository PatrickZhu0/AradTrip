using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DB9 RID: 3513
	internal class CachedNormalObject<T> : CachedObject where T : class, new()
	{
		// Token: 0x170018CF RID: 6351
		// (get) Token: 0x06008E03 RID: 36355 RVA: 0x00007983 File Offset: 0x00005D83
		public T Value
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x06008E04 RID: 36356 RVA: 0x0000798C File Offset: 0x00005D8C
		public override void OnCreate(object[] param)
		{
			this.goParent = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.data = (param[2] as T);
			this.bUseTemplate = (bool)param[3];
			if (this.goLocal == null)
			{
				if (this.bUseTemplate)
				{
					this.goLocal = this.goPrefab;
				}
				else
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				}
				Utility.AttachTo(this.goLocal, this.goParent, false);
			}
			if (!this.bCreate)
			{
				this.Initialize();
				this.bCreate = true;
			}
			this.Enable();
			this.SetAsLastSibling();
			this.OnUpdate();
		}

		// Token: 0x06008E05 RID: 36357 RVA: 0x00007A50 File Offset: 0x00005E50
		public override void OnDestroy()
		{
			this.UnInitialize();
			this.goLocal = null;
			this.data = (T)((object)null);
			this.goPrefab = null;
			this.goParent = null;
			this.bCreate = false;
		}

		// Token: 0x06008E06 RID: 36358 RVA: 0x00007A80 File Offset: 0x00005E80
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x06008E07 RID: 36359 RVA: 0x00007A9F File Offset: 0x00005E9F
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x06008E08 RID: 36360 RVA: 0x00007ABE File Offset: 0x00005EBE
		public override void SetAsLastSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsLastSibling();
			}
		}

		// Token: 0x06008E09 RID: 36361 RVA: 0x00007AE1 File Offset: 0x00005EE1
		public void SetSiblingIndex(int iIndex)
		{
			if (null != this.goLocal)
			{
				this.goLocal.transform.SetSiblingIndex(iIndex);
			}
		}

		// Token: 0x06008E0A RID: 36362 RVA: 0x00007B05 File Offset: 0x00005F05
		public override void OnRefresh(object[] param)
		{
			if (param != null && param.Length > 0)
			{
				this.data = (param[0] as T);
			}
			this.OnUpdate();
		}

		// Token: 0x06008E0B RID: 36363 RVA: 0x00007B2F File Offset: 0x00005F2F
		public override void OnRecycle()
		{
			this.Disable();
		}

		// Token: 0x06008E0C RID: 36364 RVA: 0x00007B37 File Offset: 0x00005F37
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x06008E0D RID: 36365 RVA: 0x00007B40 File Offset: 0x00005F40
		public virtual void Initialize()
		{
		}

		// Token: 0x06008E0E RID: 36366 RVA: 0x00007B42 File Offset: 0x00005F42
		public virtual void UnInitialize()
		{
		}

		// Token: 0x06008E0F RID: 36367 RVA: 0x00007B44 File Offset: 0x00005F44
		public virtual void OnUpdate()
		{
		}

		// Token: 0x0400467E RID: 18046
		private bool bCreate;

		// Token: 0x0400467F RID: 18047
		protected GameObject goLocal;

		// Token: 0x04004680 RID: 18048
		public GameObject goPrefab;

		// Token: 0x04004681 RID: 18049
		public GameObject goParent;

		// Token: 0x04004682 RID: 18050
		protected T data;

		// Token: 0x04004683 RID: 18051
		protected bool bUseTemplate;
	}
}
