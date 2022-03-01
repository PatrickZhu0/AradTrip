using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200470E RID: 18190
	internal interface ITMRecyclePoolManager
	{
		// Token: 0x0601A17F RID: 106879
		RecyclePoolBase CreateRecyclePool<T>(CreateRecyclable createAction) where T : Recyclable, new();

		// Token: 0x0601A180 RID: 106880
		void DestroyRecyclePool(RecyclePoolBase objPoolBase);
	}
}
