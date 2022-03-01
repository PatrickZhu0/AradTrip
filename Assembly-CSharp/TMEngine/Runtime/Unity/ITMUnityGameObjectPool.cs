using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004727 RID: 18215
	public interface ITMUnityGameObjectPool
	{
		// Token: 0x17002220 RID: 8736
		// (get) Token: 0x0601A259 RID: 107097
		int GameObjectPoolCount { get; }

		// Token: 0x0601A25A RID: 107098
		void SetPoolRootNode(GameObject root);

		// Token: 0x0601A25B RID: 107099
		void SetObjectPoolDesc(string prefabRes, GameObjectUsage objectUsage, int reserveCount, float expireTime, int priority);

		// Token: 0x0601A25C RID: 107100
		GameObject AcquireGameObjectSync(string prefabRes, uint flag);

		// Token: 0x0601A25D RID: 107101
		int AcquireGameObjectAsync(string prefabRes, object userData, AssetLoadCallbacks callbacks, uint flag);

		// Token: 0x0601A25E RID: 107102
		void RecycleGameObject(GameObject gameObject);

		// Token: 0x0601A25F RID: 107103
		void PurgePool(bool clearAll);

		// Token: 0x0601A260 RID: 107104
		void GetAllPoolInfo(ref List<UnityGameObjectPoolInfo> poolInfoList);
	}
}
