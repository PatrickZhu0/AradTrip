using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x020046CB RID: 18123
	public interface ITMAssetManager
	{
		// Token: 0x17002137 RID: 8503
		// (get) Token: 0x06019F02 RID: 106242
		bool IsAssetLoaderReady { get; }

		// Token: 0x17002138 RID: 8504
		// (get) Token: 0x06019F03 RID: 106243
		string ReadOnlyPath { get; }

		// Token: 0x17002139 RID: 8505
		// (get) Token: 0x06019F04 RID: 106244
		string ReadWritePath { get; }

		// Token: 0x1700213A RID: 8506
		// (get) Token: 0x06019F05 RID: 106245
		string PackageRootFolder { get; }

		// Token: 0x1700213B RID: 8507
		// (get) Token: 0x06019F06 RID: 106246
		string CurrentVariant { get; }

		// Token: 0x1700213C RID: 8508
		// (get) Token: 0x06019F07 RID: 106247
		string ApplicationVersion { get; }

		// Token: 0x1700213D RID: 8509
		// (get) Token: 0x06019F08 RID: 106248
		int InternalResourceVersion { get; }

		// Token: 0x1700213E RID: 8510
		// (get) Token: 0x06019F09 RID: 106249
		int AssetCount { get; }

		// Token: 0x1700213F RID: 8511
		// (get) Token: 0x06019F0A RID: 106250
		int AssetPackageCount { get; }

		// Token: 0x17002140 RID: 8512
		// (get) Token: 0x06019F0B RID: 106251
		int UpdateWaitingCount { get; }

		// Token: 0x17002141 RID: 8513
		// (get) Token: 0x06019F0C RID: 106252
		int UpdatingCount { get; }

		// Token: 0x17002142 RID: 8514
		// (get) Token: 0x06019F0D RID: 106253
		int LoadAgentTotalCount { get; }

		// Token: 0x17002143 RID: 8515
		// (get) Token: 0x06019F0E RID: 106254
		int LoadAgentFreeCount { get; }

		// Token: 0x17002144 RID: 8516
		// (get) Token: 0x06019F0F RID: 106255
		int LoadAgentWorkingCount { get; }

		// Token: 0x17002145 RID: 8517
		// (get) Token: 0x06019F10 RID: 106256
		int LoadTaskWaitingCount { get; }

		// Token: 0x17002146 RID: 8518
		// (get) Token: 0x06019F11 RID: 106257
		float AssetPoolAutoPurgeInterval { get; }

		// Token: 0x17002147 RID: 8519
		// (get) Token: 0x06019F12 RID: 106258
		float AssetExpireTime { get; }

		// Token: 0x17002148 RID: 8520
		// (get) Token: 0x06019F13 RID: 106259
		int AssetLoadedCount { get; }

		// Token: 0x17002149 RID: 8521
		// (get) Token: 0x06019F14 RID: 106260
		int AssetCanReleaseCount { get; }

		// Token: 0x1700214A RID: 8522
		// (get) Token: 0x06019F15 RID: 106261
		int AssetPoolPriority { get; }

		// Token: 0x1700214B RID: 8523
		// (get) Token: 0x06019F16 RID: 106262
		float AssetPackagePoolAutoPurgeInterval { get; }

		// Token: 0x1700214C RID: 8524
		// (get) Token: 0x06019F17 RID: 106263
		float AssetPackageExpireTime { get; }

		// Token: 0x1700214D RID: 8525
		// (get) Token: 0x06019F18 RID: 106264
		int AssetPackageLoadedCount { get; }

		// Token: 0x1700214E RID: 8526
		// (get) Token: 0x06019F19 RID: 106265
		int AssetPackageCanReleaseCount { get; }

		// Token: 0x1700214F RID: 8527
		// (get) Token: 0x06019F1A RID: 106266
		int AssetPackagePoolPriority { get; }

		// Token: 0x17002150 RID: 8528
		// (get) Token: 0x06019F1B RID: 106267
		string RemoteResServerURI { get; }

		// Token: 0x17002151 RID: 8529
		// (get) Token: 0x06019F1C RID: 106268
		ObjectDesc[] AssetPoolObjectInfos { get; }

		// Token: 0x17002152 RID: 8530
		// (get) Token: 0x06019F1D RID: 106269
		ObjectDesc[] AssetPackagePoolObjectInfos { get; }

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06019F1E RID: 106270
		// (remove) Token: 0x06019F1F RID: 106271
		event EventHandler<AssetInitCompleteEventArgs> AssetInitComplete;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06019F20 RID: 106272
		// (remove) Token: 0x06019F21 RID: 106273
		event EventHandler<VersionListUpdateSuccessEventArgs> VersionListUpdateSuccess;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06019F22 RID: 106274
		// (remove) Token: 0x06019F23 RID: 106275
		event EventHandler<VersionListUpdateFailureEventArgs> VersionListUpdateFailure;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06019F24 RID: 106276
		// (remove) Token: 0x06019F25 RID: 106277
		event EventHandler<AssetCheckCompleteEventArgs> AssetCheckComplete;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06019F26 RID: 106278
		// (remove) Token: 0x06019F27 RID: 106279
		event EventHandler<AssetUpdateStartEventArgs> AssetUpdateStart;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06019F28 RID: 106280
		// (remove) Token: 0x06019F29 RID: 106281
		event EventHandler<AssetUpdateChangedEventArgs> AssetUpdateChanged;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06019F2A RID: 106282
		// (remove) Token: 0x06019F2B RID: 106283
		event EventHandler<AssetUpdateSuccessEventArgs> AssetUpdateSuccess;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06019F2C RID: 106284
		// (remove) Token: 0x06019F2D RID: 106285
		event EventHandler<AssetUpdateFailureEventArgs> AssetUpdateFailure;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06019F2E RID: 106286
		// (remove) Token: 0x06019F2F RID: 106287
		event EventHandler<AssetUpdateFinishEventArgs> AssetUpdateFinish;

		// Token: 0x06019F30 RID: 106288
		void CreateAssetLoader(string asyncResLoaderTypeName, string syncResLoaderTypeName);

		// Token: 0x06019F31 RID: 106289
		void SetAssetLoadAgentCount(int agentCount);

		// Token: 0x06019F32 RID: 106290
		void SetReadOnlyPath(string readOnlyPath);

		// Token: 0x06019F33 RID: 106291
		void SetReadWritePath(string readWritePath);

		// Token: 0x06019F34 RID: 106292
		void AddResourceOnlyPath(string resourceOnlyPath);

		// Token: 0x06019F35 RID: 106293
		void SetAssetMode(uint assetmode);

		// Token: 0x06019F36 RID: 106294
		void SetCurrentVariant(string currentVariant);

		// Token: 0x06019F37 RID: 106295
		void SetPackageRootFolder(string packageRoot);

		// Token: 0x06019F38 RID: 106296
		void SetAssetPoolPriority(int priority);

		// Token: 0x06019F39 RID: 106297
		void SetAssetPoolAutoPurgeInterval(float intervalInSeconds);

		// Token: 0x06019F3A RID: 106298
		void SetAssetExpireTime(float expireTime);

		// Token: 0x06019F3B RID: 106299
		void SetAssetPackagePoolPriority(int priority);

		// Token: 0x06019F3C RID: 106300
		void SetAssetPackagePoolAutoPurgeInterval(float intervalInSeconds);

		// Token: 0x06019F3D RID: 106301
		void SetAssetPackageExpireTime(float expireTime);

		// Token: 0x06019F3E RID: 106302
		bool IsAssetExist(string assetName, Type assetType, bool loadFromPackage);

		// Token: 0x06019F3F RID: 106303
		void QurreyAssetPackage(string assetName, List<string> packages);

		// Token: 0x06019F40 RID: 106304
		object LoadAsset(string assetName, Type assetType, object userData, uint uFlag = 0U);

		// Token: 0x06019F41 RID: 106305
		bool PreLoadAsset(string assetName, Type assetType, object userData, uint uFlag = 0U);

		// Token: 0x06019F42 RID: 106306
		int LoadAssetAsync(string assetName, Type assetType, AssetLoadCallbacks assetLoadCallback, object userData, int priorityLevel = 0);

		// Token: 0x06019F43 RID: 106307
		void BeginClearUnusedAssets(bool releaseAll);

		// Token: 0x06019F44 RID: 106308
		bool EndClearUnusedAssets();

		// Token: 0x06019F45 RID: 106309
		bool BuildAssetTree(object assetTreeData);

		// Token: 0x06019F46 RID: 106310
		bool LockAsset(string assetName, int lockFlag);
	}
}
