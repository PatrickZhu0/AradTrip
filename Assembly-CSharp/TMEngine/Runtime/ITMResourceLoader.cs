using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200471C RID: 18204
	internal interface ITMResourceLoader
	{
		// Token: 0x0601A224 RID: 107044
		void Reset();

		// Token: 0x0601A225 RID: 107045
		void UnloadPackage(object package);
	}
}
