using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200472C RID: 18220
	internal class UnityAssetObject : ITMAssetObject
	{
		// Token: 0x0601A2AC RID: 107180 RVA: 0x00821564 File Offset: 0x0081F964
		public UnityAssetObject(object assetObject)
		{
			this.m_IsInstAsset = (assetObject is GameObject);
			if (this.m_IsInstAsset)
			{
				this.m_AssetObject = (assetObject as GameObject);
				this.m_AssetObjRef = null;
			}
			else
			{
				this.m_AssetObject = null;
				this.m_AssetObjRef = new WeakReference(assetObject, false);
			}
			this.m_ObjInstList = new List<object>();
		}

		// Token: 0x0601A2AD RID: 107181 RVA: 0x008215C8 File Offset: 0x0081F9C8
		public object CreateAssetInst()
		{
			if (this.m_IsInstAsset)
			{
				TMDebug.Assert(this.m_AssetObject != null, "Asset is not a instance type!");
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_AssetObject);
				if (null != gameObject)
				{
					this.m_ObjInstList.Add(gameObject);
				}
				return gameObject;
			}
			return this.m_AssetObjRef.Target;
		}

		// Token: 0x17002240 RID: 8768
		// (get) Token: 0x0601A2AE RID: 107182 RVA: 0x00821627 File Offset: 0x0081FA27
		public bool IsWeakRefAsset
		{
			get
			{
				return !this.m_IsInstAsset;
			}
		}

		// Token: 0x17002241 RID: 8769
		// (get) Token: 0x0601A2AF RID: 107183 RVA: 0x00821632 File Offset: 0x0081FA32
		public bool IsInUse
		{
			get
			{
				if (this.m_IsInstAsset)
				{
					this._CheckDeadInst();
					return 0 != this.m_ObjInstList.Count;
				}
				return null != this.m_AssetObjRef.Target as Object;
			}
		}

		// Token: 0x17002242 RID: 8770
		// (get) Token: 0x0601A2B0 RID: 107184 RVA: 0x0082166D File Offset: 0x0081FA6D
		public int SpawnCount
		{
			get
			{
				if (this.m_IsInstAsset)
				{
					this._CheckDeadInst();
					return this.m_ObjInstList.Count;
				}
				return (!this.IsInUse) ? 0 : 1;
			}
		}

		// Token: 0x0601A2B1 RID: 107185 RVA: 0x0082169E File Offset: 0x0081FA9E
		private void _CheckDeadInst()
		{
			this.m_ObjInstList.RemoveAll((object inst) => null == inst as Object);
		}

		// Token: 0x04012620 RID: 75296
		private readonly WeakReference m_AssetObjRef;

		// Token: 0x04012621 RID: 75297
		private readonly GameObject m_AssetObject;

		// Token: 0x04012622 RID: 75298
		private readonly bool m_IsInstAsset;

		// Token: 0x04012623 RID: 75299
		private readonly List<object> m_ObjInstList;
	}
}
