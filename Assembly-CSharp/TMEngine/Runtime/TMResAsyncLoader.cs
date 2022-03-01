using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004722 RID: 18210
	public abstract class TMResAsyncLoader : ITMResourceLoader
	{
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x0601A23D RID: 107069
		// (remove) Token: 0x0601A23E RID: 107070
		public abstract event EventHandler<LoadResourceUpdateEventArgs> UpdateResourceEventHandler;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x0601A23F RID: 107071
		// (remove) Token: 0x0601A240 RID: 107072
		public abstract event EventHandler<LoadResourceCompleteEventArgs> LoadResourceCompleteEventHandler;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x0601A241 RID: 107073
		// (remove) Token: 0x0601A242 RID: 107074
		public abstract event EventHandler<LoadResourceFailedEventArgs> LoadResourceFailedEventHandler;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0601A243 RID: 107075
		// (remove) Token: 0x0601A244 RID: 107076
		public abstract event EventHandler<LoadPackageCompleteEventArgs> LoadPackageCompleteEventHandler;

		// Token: 0x0601A245 RID: 107077
		public abstract void LoadPackage(string fullpath);

		// Token: 0x0601A246 RID: 107078
		public abstract void LoadAsset(object resource, string assetName, string subResName, Type assetType);

		// Token: 0x0601A247 RID: 107079
		public abstract void LoadFile(string filepath, bool readWritePath, ResAsyncLoadFileCallback callback);

		// Token: 0x0601A248 RID: 107080
		public abstract void UnloadPackage(object package);

		// Token: 0x0601A249 RID: 107081
		public abstract void Reset();

		// Token: 0x0601A24A RID: 107082
		public abstract void Update();
	}
}
