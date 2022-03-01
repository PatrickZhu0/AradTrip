using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200173A RID: 5946
	public class ActivityLTObject<T>
	{
		// Token: 0x17001CDE RID: 7390
		// (get) Token: 0x0600E9B2 RID: 59826 RVA: 0x003D9673 File Offset: 0x003D7A73
		// (set) Token: 0x0600E9B3 RID: 59827 RVA: 0x003D967B File Offset: 0x003D7A7B
		public bool IsUsed { get; private set; }

		// Token: 0x0600E9B4 RID: 59828 RVA: 0x003D9684 File Offset: 0x003D7A84
		public virtual void Create()
		{
			this.IsUsed = true;
		}

		// Token: 0x0600E9B5 RID: 59829 RVA: 0x003D968D File Offset: 0x003D7A8D
		public virtual void Destory()
		{
			this.IsUsed = false;
		}

		// Token: 0x0600E9B6 RID: 59830 RVA: 0x003D9696 File Offset: 0x003D7A96
		public GameObject CreatePrefab(GameObject initParent, string prefabResPath)
		{
			if (string.IsNullOrEmpty(prefabResPath))
			{
				return null;
			}
			this.goSelf = Singleton<CGameObjectPool>.instance.GetGameObject(prefabResPath, enResourceType.UIPrefab, 2U);
			Utility.AttachTo(this.goSelf, initParent, false);
			return this.goSelf;
		}

		// Token: 0x0600E9B7 RID: 59831 RVA: 0x003D96CB File Offset: 0x003D7ACB
		public GameObject GetGoSelf()
		{
			return this.goSelf;
		}

		// Token: 0x17001CDF RID: 7391
		// (get) Token: 0x0600E9B8 RID: 59832 RVA: 0x003D96D3 File Offset: 0x003D7AD3
		// (set) Token: 0x0600E9B9 RID: 59833 RVA: 0x003D96DB File Offset: 0x003D7ADB
		public T ObjType
		{
			get
			{
				return this.objType;
			}
			set
			{
				this.objType = value;
			}
		}

		// Token: 0x04008DC1 RID: 36289
		protected GameObject goSelf;

		// Token: 0x04008DC3 RID: 36291
		private T objType;
	}
}
