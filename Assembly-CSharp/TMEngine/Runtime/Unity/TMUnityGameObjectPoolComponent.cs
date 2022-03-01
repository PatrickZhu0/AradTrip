using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004738 RID: 18232
	[DisallowMultipleComponent]
	[AddComponentMenu("TMEngine/GameObjectPoolModule")]
	public class TMUnityGameObjectPoolComponent : TMModuleComponent
	{
		// Token: 0x17002250 RID: 8784
		// (get) Token: 0x0601A2EF RID: 107247 RVA: 0x00822306 File Offset: 0x00820706
		public int GameObjectAssetCount
		{
			get
			{
				return this.m_UnityGameObjectPool.GameObjectPoolCount;
			}
		}

		// Token: 0x0601A2F0 RID: 107248 RVA: 0x00822313 File Offset: 0x00820713
		public void GetAllPoolInfo(ref List<UnityGameObjectPoolInfo> poolInfoList)
		{
			this.m_UnityGameObjectPool.GetAllPoolInfo(ref poolInfoList);
		}

		// Token: 0x0601A2F1 RID: 107249 RVA: 0x00822321 File Offset: 0x00820721
		protected sealed override void Awake()
		{
			base.Awake();
			this.m_UnityGameObjectPool = ModuleManager.GetModule<ITMUnityGameObjectPool>();
			if (this.m_UnityGameObjectPool == null)
			{
				TMDebug.LogErrorFormat("Unity game-object pool is invalid!", new object[0]);
				return;
			}
			this.m_UnityGameObjectPool.SetPoolRootNode(base.gameObject);
		}

		// Token: 0x0601A2F2 RID: 107250 RVA: 0x00822361 File Offset: 0x00820761
		private void Start()
		{
		}

		// Token: 0x04012651 RID: 75345
		private ITMUnityGameObjectPool m_UnityGameObjectPool;
	}
}
