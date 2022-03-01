using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200472B RID: 18219
	[DisallowMultipleComponent]
	[AddComponentMenu("TMEngine/ReferencePoolModule")]
	public class TMReferencePoolModuleComponent : TMModuleComponent
	{
		// Token: 0x0601A29B RID: 107163 RVA: 0x0082143B File Offset: 0x0081F83B
		protected sealed override void Awake()
		{
			base.Awake();
			this.m_ObjectPoolManager = ModuleManager.GetModule<ITMReferencePoolManager>();
			if (this.m_ObjectPoolManager == null)
			{
				TMDebug.LogErrorFormat("Object pool manager is invalid!", new object[0]);
				return;
			}
		}

		// Token: 0x0601A29C RID: 107164 RVA: 0x0082146A File Offset: 0x0081F86A
		private void Start()
		{
		}

		// Token: 0x1700223F RID: 8767
		// (get) Token: 0x0601A29D RID: 107165 RVA: 0x0082146C File Offset: 0x0081F86C
		public int Count
		{
			get
			{
				return this.m_ObjectPoolManager.Count;
			}
		}

		// Token: 0x0601A29E RID: 107166 RVA: 0x00821479 File Offset: 0x0081F879
		public bool HasObjectPool<T>() where T : Referable
		{
			return this.m_ObjectPoolManager.HasReferencePool<T>();
		}

		// Token: 0x0601A29F RID: 107167 RVA: 0x00821486 File Offset: 0x0081F886
		public bool HasObjectPool<T>(string name) where T : Referable
		{
			return this.m_ObjectPoolManager.HasReferencePool<T>(name);
		}

		// Token: 0x0601A2A0 RID: 107168 RVA: 0x00821494 File Offset: 0x0081F894
		public ITMReferencePool<T> GetObjectPool<T>() where T : Referable
		{
			return this.m_ObjectPoolManager.GetReferencePool<T>();
		}

		// Token: 0x0601A2A1 RID: 107169 RVA: 0x008214A1 File Offset: 0x0081F8A1
		public ITMReferencePool<T> GetObjectPool<T>(string name) where T : Referable
		{
			return this.m_ObjectPoolManager.GetReferencePool<T>(name);
		}

		// Token: 0x0601A2A2 RID: 107170 RVA: 0x008214AF File Offset: 0x0081F8AF
		public void GetAllObjectPools(List<ReferencePoolBase> objectPools)
		{
			this.m_ObjectPoolManager.GetAllReferencePools(objectPools);
		}

		// Token: 0x0601A2A3 RID: 107171 RVA: 0x008214BD File Offset: 0x0081F8BD
		public void GetAllObjectPools(List<ReferencePoolBase> objectPools, bool sort)
		{
			this.m_ObjectPoolManager.GetAllReferencePools(objectPools, sort);
		}

		// Token: 0x0601A2A4 RID: 107172 RVA: 0x008214CC File Offset: 0x0081F8CC
		public ITMReferencePool<T> CreateSingleSpawnObjectPool<T>(string name) where T : Referable
		{
			return this.m_ObjectPoolManager.CreateSingleSpawnReferencePool<T>(name);
		}

		// Token: 0x0601A2A5 RID: 107173 RVA: 0x008214DA File Offset: 0x0081F8DA
		public ITMReferencePool<T> CreateSingleSpawnObjectPool<T>(string name, int capacity, float expireTime, int priority) where T : Referable
		{
			return this.m_ObjectPoolManager.CreateSingleSpawnReferencePool<T>(name, capacity, expireTime, priority);
		}

		// Token: 0x0601A2A6 RID: 107174 RVA: 0x008214EC File Offset: 0x0081F8EC
		public ITMReferencePool<T> CreateMultiSpawnObjectPool<T>(string name) where T : Referable
		{
			return this.m_ObjectPoolManager.CreateMultiSpawnReferencePool<T>(name);
		}

		// Token: 0x0601A2A7 RID: 107175 RVA: 0x008214FA File Offset: 0x0081F8FA
		public ITMReferencePool<T> CreateMultiSpawnObjectPool<T>(string name, int capacity, float expireTime, int priority) where T : Referable
		{
			return this.m_ObjectPoolManager.CreateMultiSpawnReferencePool<T>(name, capacity, expireTime, priority);
		}

		// Token: 0x0601A2A8 RID: 107176 RVA: 0x0082150C File Offset: 0x0081F90C
		public bool DestroyObjectPool<T>(string name) where T : Referable
		{
			return this.m_ObjectPoolManager.DestroyReferencePool<T>(name);
		}

		// Token: 0x0601A2A9 RID: 107177 RVA: 0x0082151A File Offset: 0x0081F91A
		public bool DestroyObjectPool(ReferencePoolBase objectPool)
		{
			return this.m_ObjectPoolManager.DestroyReferencePool(objectPool);
		}

		// Token: 0x0601A2AA RID: 107178 RVA: 0x00821528 File Offset: 0x0081F928
		public void Release()
		{
			TMDebug.LogInfoFormat("Object pool release...", new object[0]);
			this.m_ObjectPoolManager.Release();
		}

		// Token: 0x0601A2AB RID: 107179 RVA: 0x00821545 File Offset: 0x0081F945
		public void ReleaseAllUnused()
		{
			TMDebug.LogInfoFormat("Object pool release all unused...", new object[0]);
			this.m_ObjectPoolManager.ReleaseAllUnused();
		}

		// Token: 0x0401261F RID: 75295
		private ITMReferencePoolManager m_ObjectPoolManager;
	}
}
