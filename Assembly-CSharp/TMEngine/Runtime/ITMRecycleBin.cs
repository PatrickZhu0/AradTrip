using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200470B RID: 18187
	public interface ITMRecycleBin
	{
		// Token: 0x0601A167 RID: 106855
		void SetReserveCountOfType(Type type, int reserveCount);

		// Token: 0x0601A168 RID: 106856
		int GetResserveCountOfType(Type type);

		// Token: 0x0601A169 RID: 106857
		T Acquire<T>() where T : Recyclable, new();

		// Token: 0x0601A16A RID: 106858
		void Recycle<T>(T obj) where T : Recyclable, new();

		// Token: 0x0601A16B RID: 106859
		void ClearAllObjectOfType<T>() where T : Recyclable, new();

		// Token: 0x0601A16C RID: 106860
		void Purge(bool clearAll);

		// Token: 0x0601A16D RID: 106861
		void Shutdown();
	}
}
