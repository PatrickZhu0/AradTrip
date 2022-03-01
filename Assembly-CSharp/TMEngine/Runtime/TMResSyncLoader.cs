using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004723 RID: 18211
	public abstract class TMResSyncLoader : ITMResourceLoader
	{
		// Token: 0x0601A24C RID: 107084
		public abstract object LoadPackage(string fullpath);

		// Token: 0x0601A24D RID: 107085
		public abstract object LoadAsset(object package, string assetName, string subResName, Type assetType);

		// Token: 0x0601A24E RID: 107086
		public abstract bool LoadFile(string filepath, bool readWritePath, out byte[] data);

		// Token: 0x0601A24F RID: 107087
		public abstract void UnloadPackage(object package);

		// Token: 0x0601A250 RID: 107088
		public abstract void Reset();
	}
}
