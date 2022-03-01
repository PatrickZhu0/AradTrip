using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime
{
	// Token: 0x020046D4 RID: 18132
	internal sealed class AssetManager : BaseModule, ITMAssetManager
	{
		// Token: 0x06019F62 RID: 106338 RVA: 0x0081A880 File Offset: 0x00818C80
		public AssetManager()
		{
			this.m_ReadOnlyPath = null;
			this.m_ReadWritePath = null;
			this.m_CurrentVariant = null;
			this.m_AssetMode = new EnumHelper<AssetMode>(AssetMode.None);
			this.m_ApplicationVersion = null;
			this.m_InternalResourceVersion = 0;
			this.m_RemoteResServerURI = null;
			this.m_PackageRootFolder = string.Empty;
			this.m_AssetPool = null;
			this.m_AssetPackagePool = null;
			this.m_AssetLoader = null;
			this.m_AssetInitCompleteEventHandler = null;
			this.m_VersionListUpdateSuccessEventHandler = null;
			this.m_VersionListUpdateFailureEventHandler = null;
			this.m_AssetCheckCompleteEventHandler = null;
			this.m_AssetUpdateStartEventHandler = null;
			this.m_AssetUpdateChangedEventHandler = null;
			this.m_AssetUpdateFailureEventHandler = null;
			this.m_AssetUpdateFinishEventHandler = null;
			this.m_AssetDescTableIsReady = false;
			this.m_AssetPackageDescTableIsReady = false;
			this.m_AssetDescTable = new LinearMap<string, AssetDesc>(true);
			this.m_AssetPackageDescTable = new LinearMap<AssetPackageName, AssetPackageDesc>(true);
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06019F63 RID: 106339 RVA: 0x0081A95E File Offset: 0x00818D5E
		// (remove) Token: 0x06019F64 RID: 106340 RVA: 0x0081A977 File Offset: 0x00818D77
		public event EventHandler<AssetInitCompleteEventArgs> AssetInitComplete
		{
			add
			{
				this.m_AssetInitCompleteEventHandler = (EventHandler<AssetInitCompleteEventArgs>)Delegate.Combine(this.m_AssetInitCompleteEventHandler, value);
			}
			remove
			{
				this.m_AssetInitCompleteEventHandler = (EventHandler<AssetInitCompleteEventArgs>)Delegate.Remove(this.m_AssetInitCompleteEventHandler, value);
			}
		}

		// Token: 0x06019F65 RID: 106341 RVA: 0x0081A990 File Offset: 0x00818D90
		private void _OnAssetInitComplete()
		{
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06019F66 RID: 106342 RVA: 0x0081A992 File Offset: 0x00818D92
		// (remove) Token: 0x06019F67 RID: 106343 RVA: 0x0081A9AB File Offset: 0x00818DAB
		public event EventHandler<VersionListUpdateSuccessEventArgs> VersionListUpdateSuccess
		{
			add
			{
				this.m_VersionListUpdateSuccessEventHandler = (EventHandler<VersionListUpdateSuccessEventArgs>)Delegate.Combine(this.m_VersionListUpdateSuccessEventHandler, value);
			}
			remove
			{
				this.m_VersionListUpdateSuccessEventHandler = (EventHandler<VersionListUpdateSuccessEventArgs>)Delegate.Remove(this.m_VersionListUpdateSuccessEventHandler, value);
			}
		}

		// Token: 0x06019F68 RID: 106344 RVA: 0x0081A9C4 File Offset: 0x00818DC4
		private void _OnVersionListUpdateSuccess()
		{
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06019F69 RID: 106345 RVA: 0x0081A9C6 File Offset: 0x00818DC6
		// (remove) Token: 0x06019F6A RID: 106346 RVA: 0x0081A9DF File Offset: 0x00818DDF
		public event EventHandler<VersionListUpdateFailureEventArgs> VersionListUpdateFailure
		{
			add
			{
				this.m_VersionListUpdateFailureEventHandler = (EventHandler<VersionListUpdateFailureEventArgs>)Delegate.Combine(this.m_VersionListUpdateFailureEventHandler, value);
			}
			remove
			{
				this.m_VersionListUpdateFailureEventHandler = (EventHandler<VersionListUpdateFailureEventArgs>)Delegate.Remove(this.m_VersionListUpdateFailureEventHandler, value);
			}
		}

		// Token: 0x06019F6B RID: 106347 RVA: 0x0081A9F8 File Offset: 0x00818DF8
		private void _OnVersionListUpdateFailure()
		{
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06019F6C RID: 106348 RVA: 0x0081A9FA File Offset: 0x00818DFA
		// (remove) Token: 0x06019F6D RID: 106349 RVA: 0x0081AA13 File Offset: 0x00818E13
		public event EventHandler<AssetCheckCompleteEventArgs> AssetCheckComplete
		{
			add
			{
				this.m_AssetCheckCompleteEventHandler = (EventHandler<AssetCheckCompleteEventArgs>)Delegate.Combine(this.m_AssetCheckCompleteEventHandler, value);
			}
			remove
			{
				this.m_AssetCheckCompleteEventHandler = (EventHandler<AssetCheckCompleteEventArgs>)Delegate.Remove(this.m_AssetCheckCompleteEventHandler, value);
			}
		}

		// Token: 0x06019F6E RID: 106350 RVA: 0x0081AA2C File Offset: 0x00818E2C
		private void _OnAssetCheckComplete()
		{
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06019F6F RID: 106351 RVA: 0x0081AA2E File Offset: 0x00818E2E
		// (remove) Token: 0x06019F70 RID: 106352 RVA: 0x0081AA47 File Offset: 0x00818E47
		public event EventHandler<AssetUpdateStartEventArgs> AssetUpdateStart
		{
			add
			{
				this.m_AssetUpdateStartEventHandler = (EventHandler<AssetUpdateStartEventArgs>)Delegate.Combine(this.m_AssetUpdateStartEventHandler, value);
			}
			remove
			{
				this.m_AssetUpdateStartEventHandler = (EventHandler<AssetUpdateStartEventArgs>)Delegate.Remove(this.m_AssetUpdateStartEventHandler, value);
			}
		}

		// Token: 0x06019F71 RID: 106353 RVA: 0x0081AA60 File Offset: 0x00818E60
		private void _OnAssetUpdateStart()
		{
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06019F72 RID: 106354 RVA: 0x0081AA62 File Offset: 0x00818E62
		// (remove) Token: 0x06019F73 RID: 106355 RVA: 0x0081AA7B File Offset: 0x00818E7B
		public event EventHandler<AssetUpdateChangedEventArgs> AssetUpdateChanged
		{
			add
			{
				this.m_AssetUpdateChangedEventHandler = (EventHandler<AssetUpdateChangedEventArgs>)Delegate.Combine(this.m_AssetUpdateChangedEventHandler, value);
			}
			remove
			{
				this.m_AssetUpdateChangedEventHandler = (EventHandler<AssetUpdateChangedEventArgs>)Delegate.Remove(this.m_AssetUpdateChangedEventHandler, value);
			}
		}

		// Token: 0x06019F74 RID: 106356 RVA: 0x0081AA94 File Offset: 0x00818E94
		private void _OnAssetUpdateChanged()
		{
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06019F75 RID: 106357 RVA: 0x0081AA96 File Offset: 0x00818E96
		// (remove) Token: 0x06019F76 RID: 106358 RVA: 0x0081AAAF File Offset: 0x00818EAF
		public event EventHandler<AssetUpdateSuccessEventArgs> AssetUpdateSuccess
		{
			add
			{
				this.m_AssetUpdateSuccessEventHandler = (EventHandler<AssetUpdateSuccessEventArgs>)Delegate.Combine(this.m_AssetUpdateSuccessEventHandler, value);
			}
			remove
			{
				this.m_AssetUpdateSuccessEventHandler = (EventHandler<AssetUpdateSuccessEventArgs>)Delegate.Remove(this.m_AssetUpdateSuccessEventHandler, value);
			}
		}

		// Token: 0x06019F77 RID: 106359 RVA: 0x0081AAC8 File Offset: 0x00818EC8
		private void _OnAssetUpdateSuccess()
		{
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06019F78 RID: 106360 RVA: 0x0081AACA File Offset: 0x00818ECA
		// (remove) Token: 0x06019F79 RID: 106361 RVA: 0x0081AAE3 File Offset: 0x00818EE3
		public event EventHandler<AssetUpdateFailureEventArgs> AssetUpdateFailure
		{
			add
			{
				this.m_AssetUpdateFailureEventHandler = (EventHandler<AssetUpdateFailureEventArgs>)Delegate.Combine(this.m_AssetUpdateFailureEventHandler, value);
			}
			remove
			{
				this.m_AssetUpdateFailureEventHandler = (EventHandler<AssetUpdateFailureEventArgs>)Delegate.Remove(this.m_AssetUpdateFailureEventHandler, value);
			}
		}

		// Token: 0x06019F7A RID: 106362 RVA: 0x0081AAFC File Offset: 0x00818EFC
		private void _OnAssetUpdateFailure()
		{
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06019F7B RID: 106363 RVA: 0x0081AAFE File Offset: 0x00818EFE
		// (remove) Token: 0x06019F7C RID: 106364 RVA: 0x0081AB17 File Offset: 0x00818F17
		public event EventHandler<AssetUpdateFinishEventArgs> AssetUpdateFinish
		{
			add
			{
				this.m_AssetUpdateFinishEventHandler = (EventHandler<AssetUpdateFinishEventArgs>)Delegate.Combine(this.m_AssetUpdateFinishEventHandler, value);
			}
			remove
			{
				this.m_AssetUpdateFinishEventHandler = (EventHandler<AssetUpdateFinishEventArgs>)Delegate.Remove(this.m_AssetUpdateFinishEventHandler, value);
			}
		}

		// Token: 0x06019F7D RID: 106365 RVA: 0x0081AB30 File Offset: 0x00818F30
		private void _OnAssetUpdateFinish()
		{
		}

		// Token: 0x06019F7E RID: 106366 RVA: 0x0081AB34 File Offset: 0x00818F34
		public void CreateAssetLoader(string asyncResLoaderTypeName, string syncResLoaderTypeName)
		{
			this.m_AssetPool = new ReferencePoolManager.ReferencePool<AssetManager.Asset>("Asset pool", true, 60f, 30, 256, 300f);
			this.m_AssetPackagePool = new ReferencePoolManager.ReferencePool<AssetManager.AssetPackage>("Asset package pool", true, 120f, 25, 128, 300f);
			this.m_AssetLoader = new AssetManager.AssetLoader(this, this.m_AssetPool, this.m_AssetPackagePool, asyncResLoaderTypeName, syncResLoaderTypeName);
			this.m_AssetTree = new AssetManager.AssetTree(this);
		}

		// Token: 0x06019F7F RID: 106367 RVA: 0x0081ABAB File Offset: 0x00818FAB
		public void SetAssetLoadAgentCount(int agentCount)
		{
			if (this.m_AssetLoader == null)
			{
				TMDebug.LogWarningFormat("Asset loader is not create yet!", new object[0]);
				return;
			}
			this.m_AssetLoader.SetAssetLoadAgentCount(agentCount);
		}

		// Token: 0x1700215C RID: 8540
		// (get) Token: 0x06019F80 RID: 106368 RVA: 0x0081ABD5 File Offset: 0x00818FD5
		public bool IsAssetLoaderReady
		{
			get
			{
				return this.m_AssetDescTableIsReady && this.m_AssetPackageDescTableIsReady;
			}
		}

		// Token: 0x1700215D RID: 8541
		// (get) Token: 0x06019F81 RID: 106369 RVA: 0x0081ABEB File Offset: 0x00818FEB
		public string ReadOnlyPath
		{
			get
			{
				return this.m_ReadOnlyPath;
			}
		}

		// Token: 0x1700215E RID: 8542
		// (get) Token: 0x06019F82 RID: 106370 RVA: 0x0081ABF3 File Offset: 0x00818FF3
		public string ReadWritePath
		{
			get
			{
				return this.m_ReadWritePath;
			}
		}

		// Token: 0x1700215F RID: 8543
		// (get) Token: 0x06019F83 RID: 106371 RVA: 0x0081ABFB File Offset: 0x00818FFB
		public string PackageRootFolder
		{
			get
			{
				return this.m_PackageRootFolder;
			}
		}

		// Token: 0x17002160 RID: 8544
		// (get) Token: 0x06019F84 RID: 106372 RVA: 0x0081AC03 File Offset: 0x00819003
		public string CurrentVariant
		{
			get
			{
				return this.m_CurrentVariant;
			}
		}

		// Token: 0x17002161 RID: 8545
		// (get) Token: 0x06019F85 RID: 106373 RVA: 0x0081AC0B File Offset: 0x0081900B
		public string ApplicationVersion
		{
			get
			{
				return this.m_ApplicationVersion;
			}
		}

		// Token: 0x17002162 RID: 8546
		// (get) Token: 0x06019F86 RID: 106374 RVA: 0x0081AC13 File Offset: 0x00819013
		public int InternalResourceVersion
		{
			get
			{
				return this.m_InternalResourceVersion;
			}
		}

		// Token: 0x17002163 RID: 8547
		// (get) Token: 0x06019F87 RID: 106375 RVA: 0x0081AC1B File Offset: 0x0081901B
		public int AssetCount
		{
			get
			{
				return this.m_AssetDescTable.Count;
			}
		}

		// Token: 0x17002164 RID: 8548
		// (get) Token: 0x06019F88 RID: 106376 RVA: 0x0081AC28 File Offset: 0x00819028
		public int AssetPackageCount
		{
			get
			{
				return this.m_AssetPackageDescTable.Count;
			}
		}

		// Token: 0x17002165 RID: 8549
		// (get) Token: 0x06019F89 RID: 106377 RVA: 0x0081AC35 File Offset: 0x00819035
		public int UpdateWaitingCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17002166 RID: 8550
		// (get) Token: 0x06019F8A RID: 106378 RVA: 0x0081AC38 File Offset: 0x00819038
		public int UpdatingCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17002167 RID: 8551
		// (get) Token: 0x06019F8B RID: 106379 RVA: 0x0081AC3B File Offset: 0x0081903B
		public int LoadAgentTotalCount
		{
			get
			{
				return this.m_AssetLoader.LoadAgentTotalCount;
			}
		}

		// Token: 0x17002168 RID: 8552
		// (get) Token: 0x06019F8C RID: 106380 RVA: 0x0081AC48 File Offset: 0x00819048
		public int LoadAgentFreeCount
		{
			get
			{
				return this.m_AssetLoader.FreeAgentCount;
			}
		}

		// Token: 0x17002169 RID: 8553
		// (get) Token: 0x06019F8D RID: 106381 RVA: 0x0081AC55 File Offset: 0x00819055
		public int LoadAgentWorkingCount
		{
			get
			{
				return this.m_AssetLoader.WorkingAgentCount;
			}
		}

		// Token: 0x1700216A RID: 8554
		// (get) Token: 0x06019F8E RID: 106382 RVA: 0x0081AC62 File Offset: 0x00819062
		public int LoadTaskWaitingCount
		{
			get
			{
				return this.m_AssetLoader.WaitingTaskCount;
			}
		}

		// Token: 0x1700216B RID: 8555
		// (get) Token: 0x06019F8F RID: 106383 RVA: 0x0081AC6F File Offset: 0x0081906F
		public float AssetPoolAutoPurgeInterval
		{
			get
			{
				return this.m_AssetPoolAutoPurgeInterval;
			}
		}

		// Token: 0x1700216C RID: 8556
		// (get) Token: 0x06019F90 RID: 106384 RVA: 0x0081AC77 File Offset: 0x00819077
		public float AssetExpireTime
		{
			get
			{
				return this.m_AssetPool.ExpireTime;
			}
		}

		// Token: 0x1700216D RID: 8557
		// (get) Token: 0x06019F91 RID: 106385 RVA: 0x0081AC84 File Offset: 0x00819084
		public int AssetLoadedCount
		{
			get
			{
				return this.m_AssetPool.ObjectCount;
			}
		}

		// Token: 0x1700216E RID: 8558
		// (get) Token: 0x06019F92 RID: 106386 RVA: 0x0081AC91 File Offset: 0x00819091
		public int AssetCanReleaseCount
		{
			get
			{
				return this.m_AssetPool.CanReleasedCount;
			}
		}

		// Token: 0x1700216F RID: 8559
		// (get) Token: 0x06019F93 RID: 106387 RVA: 0x0081AC9E File Offset: 0x0081909E
		public int AssetPoolPriority
		{
			get
			{
				return this.m_AssetPool.Priority;
			}
		}

		// Token: 0x17002170 RID: 8560
		// (get) Token: 0x06019F94 RID: 106388 RVA: 0x0081ACAB File Offset: 0x008190AB
		public float AssetPackagePoolAutoPurgeInterval
		{
			get
			{
				return this.m_AssetPackagePoolAutoPurgeInterval;
			}
		}

		// Token: 0x17002171 RID: 8561
		// (get) Token: 0x06019F95 RID: 106389 RVA: 0x0081ACB3 File Offset: 0x008190B3
		public float AssetPackageExpireTime
		{
			get
			{
				return this.m_AssetPackagePool.ExpireTime;
			}
		}

		// Token: 0x17002172 RID: 8562
		// (get) Token: 0x06019F96 RID: 106390 RVA: 0x0081ACC0 File Offset: 0x008190C0
		public int AssetPackageLoadedCount
		{
			get
			{
				return this.m_AssetPackagePool.ObjectCount;
			}
		}

		// Token: 0x17002173 RID: 8563
		// (get) Token: 0x06019F97 RID: 106391 RVA: 0x0081ACCD File Offset: 0x008190CD
		public int AssetPackageCanReleaseCount
		{
			get
			{
				return this.m_AssetPackagePool.CanReleasedCount;
			}
		}

		// Token: 0x17002174 RID: 8564
		// (get) Token: 0x06019F98 RID: 106392 RVA: 0x0081ACDA File Offset: 0x008190DA
		public int AssetPackagePoolPriority
		{
			get
			{
				return this.m_AssetPackagePool.Priority;
			}
		}

		// Token: 0x17002175 RID: 8565
		// (get) Token: 0x06019F99 RID: 106393 RVA: 0x0081ACE7 File Offset: 0x008190E7
		public string RemoteResServerURI
		{
			get
			{
				return this.m_RemoteResServerURI;
			}
		}

		// Token: 0x17002176 RID: 8566
		// (get) Token: 0x06019F9A RID: 106394 RVA: 0x0081ACEF File Offset: 0x008190EF
		public ObjectDesc[] AssetPoolObjectInfos
		{
			get
			{
				return this.m_AssetPool.GetAllObjectInfos();
			}
		}

		// Token: 0x17002177 RID: 8567
		// (get) Token: 0x06019F9B RID: 106395 RVA: 0x0081ACFC File Offset: 0x008190FC
		public ObjectDesc[] AssetPackagePoolObjectInfos
		{
			get
			{
				return this.m_AssetPackagePool.GetAllObjectInfos();
			}
		}

		// Token: 0x17002178 RID: 8568
		// (get) Token: 0x06019F9C RID: 106396 RVA: 0x0081AD09 File Offset: 0x00819109
		internal override int Priority
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06019F9D RID: 106397 RVA: 0x0081AD0C File Offset: 0x0081910C
		public void SetReadOnlyPath(string readOnlyPath)
		{
			this.m_ReadOnlyPath = readOnlyPath;
		}

		// Token: 0x06019F9E RID: 106398 RVA: 0x0081AD15 File Offset: 0x00819115
		public void SetReadWritePath(string readWritePath)
		{
			this.m_ReadWritePath = readWritePath;
		}

		// Token: 0x06019F9F RID: 106399 RVA: 0x0081AD20 File Offset: 0x00819120
		public void AddResourceOnlyPath(string resourceOnlyPath)
		{
			if (string.IsNullOrEmpty(resourceOnlyPath))
			{
				TMDebug.LogWarningFormat("Resource only path can not be null or empty!", new object[0]);
				return;
			}
			resourceOnlyPath = Utility.Path.Normalize(resourceOnlyPath);
			if (resourceOnlyPath[resourceOnlyPath.Length - 1] != '/')
			{
				resourceOnlyPath += '/';
			}
			int i = 0;
			int count = this.m_ResourceOnlyPath.Count;
			while (i < count)
			{
				if (resourceOnlyPath == this.m_ResourceOnlyPath[i])
				{
					return;
				}
				i++;
			}
			this.m_ResourceOnlyPath.Add(resourceOnlyPath);
		}

		// Token: 0x06019FA0 RID: 106400 RVA: 0x0081ADB7 File Offset: 0x008191B7
		public void SetAssetMode(uint assetmode)
		{
			this.m_AssetMode = new EnumHelper<AssetMode>(assetmode);
		}

		// Token: 0x06019FA1 RID: 106401 RVA: 0x0081ADC5 File Offset: 0x008191C5
		public void SetCurrentVariant(string currentVariant)
		{
			this.m_CurrentVariant = currentVariant;
		}

		// Token: 0x06019FA2 RID: 106402 RVA: 0x0081ADCE File Offset: 0x008191CE
		public void SetPackageRootFolder(string packageRoot)
		{
			this.m_PackageRootFolder = packageRoot;
		}

		// Token: 0x06019FA3 RID: 106403 RVA: 0x0081ADD7 File Offset: 0x008191D7
		public void SetAssetPoolPriority(int priority)
		{
			this.m_AssetPool.SetPriority(priority);
		}

		// Token: 0x06019FA4 RID: 106404 RVA: 0x0081ADE5 File Offset: 0x008191E5
		public void SetAssetPoolAutoPurgeInterval(float intervalInSeconds)
		{
			this.m_AssetPoolAutoPurgeInterval = intervalInSeconds;
		}

		// Token: 0x06019FA5 RID: 106405 RVA: 0x0081ADEE File Offset: 0x008191EE
		public void SetAssetExpireTime(float expireTime)
		{
			this.m_AssetPool.SetExpireTime(expireTime);
		}

		// Token: 0x06019FA6 RID: 106406 RVA: 0x0081ADFC File Offset: 0x008191FC
		public void SetAssetPackagePoolPriority(int priority)
		{
			this.m_AssetPackagePool.SetPriority(priority);
		}

		// Token: 0x06019FA7 RID: 106407 RVA: 0x0081AE0A File Offset: 0x0081920A
		public void SetAssetPackagePoolAutoPurgeInterval(float intervalInSeconds)
		{
			this.m_AssetPackagePoolAutoPurgeInterval = intervalInSeconds;
		}

		// Token: 0x06019FA8 RID: 106408 RVA: 0x0081AE13 File Offset: 0x00819213
		public void SetAssetPackageExpireTime(float expireTime)
		{
			this.m_AssetPackagePool.SetExpireTime(expireTime);
		}

		// Token: 0x06019FA9 RID: 106409 RVA: 0x0081AE21 File Offset: 0x00819221
		public bool IsAssetExist(string assetName, Type assetType, bool loadFromPackage)
		{
			loadFromPackage = this.m_AssetMode.HasFlag(AssetMode.Package);
			return this.m_AssetLoader.IsAssetExist(assetName, assetType, loadFromPackage);
		}

		// Token: 0x06019FAA RID: 106410 RVA: 0x0081AE3F File Offset: 0x0081923F
		public void QurreyAssetPackage(string assetName, List<string> packages)
		{
			this.m_AssetLoader.QurreyAssetPackage(assetName, packages);
		}

		// Token: 0x06019FAB RID: 106411 RVA: 0x0081AE50 File Offset: 0x00819250
		public bool PreLoadAsset(string assetName, Type assetType, object userData, uint uFlag = 0U)
		{
			bool flag = this._CheckAssetIsLoadFromResource(assetName);
			if ((this.m_AssetDescTableIsReady && this.m_AssetPackageDescTableIsReady) || !flag)
			{
				return this.m_AssetLoader.PreLoadAsset(assetName, assetType, userData, flag, uFlag);
			}
			TMDebug.LogErrorFormat("Can not load asset '{0}' since asset desc table is not ready!", new object[]
			{
				assetName
			});
			return false;
		}

		// Token: 0x06019FAC RID: 106412 RVA: 0x0081AEA8 File Offset: 0x008192A8
		public object LoadAsset(string assetName, Type assetType, object userData, uint uFlag = 0U)
		{
			bool flag = this._CheckAssetIsLoadFromResource(assetName);
			if ((this.m_AssetDescTableIsReady && this.m_AssetPackageDescTableIsReady) || !flag)
			{
				return this.m_AssetLoader.LoadAsset(assetName, assetType, userData, flag, uFlag);
			}
			TMDebug.LogErrorFormat("Can not load asset '{0}' since asset desc table is not ready!", new object[]
			{
				assetName
			});
			return null;
		}

		// Token: 0x06019FAD RID: 106413 RVA: 0x0081AF00 File Offset: 0x00819300
		public int LoadAssetAsync(string assetName, Type assetType, AssetLoadCallbacks assetLoadCallback, object userData, int priorityLevel = 0)
		{
			if (assetLoadCallback != null)
			{
				bool flag = this._CheckAssetIsLoadFromResource(assetName);
				if ((this.m_AssetDescTableIsReady && this.m_AssetPackageDescTableIsReady) || !flag)
				{
					return this.m_AssetLoader.LoadAssetAsync(assetName, assetType, assetLoadCallback, userData, flag, priorityLevel);
				}
				assetLoadCallback.OnAssetLoadFailure(assetName, AssetLoadErrorCode.NotReady, string.Format("Can not load asset '{0}' since asset desc table is not ready!", assetName), userData);
			}
			else
			{
				TMDebug.LogErrorFormat("Asset load callback can not be null!", new object[0]);
			}
			return -1;
		}

		// Token: 0x06019FAE RID: 106414 RVA: 0x0081AF7B File Offset: 0x0081937B
		public void BeginClearUnusedAssets(bool releaseAll)
		{
			this.m_AssetPool.ReleaseUnusedObject(releaseAll);
			this.m_AssetPackagePool.ReleaseUnusedObject(releaseAll);
		}

		// Token: 0x06019FAF RID: 106415 RVA: 0x0081AF95 File Offset: 0x00819395
		public bool EndClearUnusedAssets()
		{
			return true;
		}

		// Token: 0x06019FB0 RID: 106416 RVA: 0x0081AF98 File Offset: 0x00819398
		public bool BuildAssetTree(object assetTreeData)
		{
			if (this.m_AssetTree == null)
			{
				TMDebug.LogErrorFormat("Asset tree is null!", new object[0]);
				return false;
			}
			if (assetTreeData == null)
			{
				TMDebug.LogErrorFormat("Asset tree data can not be null!", new object[0]);
				return false;
			}
			ITMAssetTreeData itmassetTreeData = assetTreeData as ITMAssetTreeData;
			if (itmassetTreeData != null)
			{
				this.m_AssetTree.BuildAssetTree(itmassetTreeData);
				return true;
			}
			DAssetPackageDependency dassetPackageDependency = assetTreeData as DAssetPackageDependency;
			if (null != dassetPackageDependency)
			{
				this.m_AssetTree.BuildAssetTree(dassetPackageDependency);
				return true;
			}
			return false;
		}

		// Token: 0x06019FB1 RID: 106417 RVA: 0x0081B017 File Offset: 0x00819417
		internal override void Update(float elapseSeconds, float realElapseSeconds)
		{
			if (this.m_AssetLoader != null)
			{
				this.m_AssetLoader.Update(elapseSeconds, realElapseSeconds);
			}
		}

		// Token: 0x06019FB2 RID: 106418 RVA: 0x0081B031 File Offset: 0x00819431
		internal override void Shutdown()
		{
			this.BeginClearUnusedAssets(true);
			this.EndClearUnusedAssets();
			this.m_AssetDescTableIsReady = false;
			this.m_AssetDescTable.Clear();
			this.m_AssetPackageDescTableIsReady = false;
			this.m_AssetPackageDescTable.Clear();
			this.m_AssetLoader.Shutdown();
		}

		// Token: 0x06019FB3 RID: 106419 RVA: 0x0081B070 File Offset: 0x00819470
		private AssetDesc? _GetAssetDescWithAssetName(string assetName)
		{
			AssetDesc value = default(AssetDesc);
			if (this.m_AssetDescTable.TryGetValue(assetName, out value))
			{
				return new AssetDesc?(value);
			}
			return null;
		}

		// Token: 0x06019FB4 RID: 106420 RVA: 0x0081B0AC File Offset: 0x008194AC
		private AssetPackageDesc? _GetAssetPackageDescWithPackageName(AssetPackageName packageName)
		{
			AssetPackageDesc value = default(AssetPackageDesc);
			if (this.m_AssetPackageDescTable.TryGetValue(packageName, out value))
			{
				return new AssetPackageDesc?(value);
			}
			return null;
		}

		// Token: 0x06019FB5 RID: 106421 RVA: 0x0081B0E6 File Offset: 0x008194E6
		private void _OnAssetTreeBuildComplete()
		{
			this.m_AssetPackageDescTableIsReady = true;
			this.m_AssetDescTableIsReady = true;
		}

		// Token: 0x06019FB6 RID: 106422 RVA: 0x0081B0F8 File Offset: 0x008194F8
		private bool _CheckAssetIsLoadFromResource(string assetName)
		{
			if (!this.m_AssetMode.HasFlag(AssetMode.Package))
			{
				return false;
			}
			List<string> resourceOnlyPath = this.m_ResourceOnlyPath;
			int i = 0;
			int count = resourceOnlyPath.Count;
			while (i < count)
			{
				if (assetName.StartsWith(resourceOnlyPath[i]))
				{
					return false;
				}
				i++;
			}
			return true;
		}

		// Token: 0x06019FB7 RID: 106423 RVA: 0x0081B14D File Offset: 0x0081954D
		private static bool _IsAssetExistWithPath(string assetPath)
		{
			return Utility.File.Exists(assetPath);
		}

		// Token: 0x06019FB8 RID: 106424 RVA: 0x0081B155 File Offset: 0x00819555
		public bool LockAsset(string assetName, int lockFlag)
		{
			return this.m_AssetPool.Lock(assetName, lockFlag);
		}

		// Token: 0x04012503 RID: 75011
		private EventHandler<AssetInitCompleteEventArgs> m_AssetInitCompleteEventHandler;

		// Token: 0x04012504 RID: 75012
		private EventHandler<VersionListUpdateSuccessEventArgs> m_VersionListUpdateSuccessEventHandler;

		// Token: 0x04012505 RID: 75013
		private EventHandler<VersionListUpdateFailureEventArgs> m_VersionListUpdateFailureEventHandler;

		// Token: 0x04012506 RID: 75014
		private EventHandler<AssetCheckCompleteEventArgs> m_AssetCheckCompleteEventHandler;

		// Token: 0x04012507 RID: 75015
		private EventHandler<AssetUpdateStartEventArgs> m_AssetUpdateStartEventHandler;

		// Token: 0x04012508 RID: 75016
		private EventHandler<AssetUpdateChangedEventArgs> m_AssetUpdateChangedEventHandler;

		// Token: 0x04012509 RID: 75017
		private EventHandler<AssetUpdateFailureEventArgs> m_AssetUpdateFailureEventHandler;

		// Token: 0x0401250A RID: 75018
		private EventHandler<AssetUpdateSuccessEventArgs> m_AssetUpdateSuccessEventHandler;

		// Token: 0x0401250B RID: 75019
		private EventHandler<AssetUpdateFinishEventArgs> m_AssetUpdateFinishEventHandler;

		// Token: 0x0401250C RID: 75020
		private readonly List<string> m_ResourceOnlyPath = new List<string>();

		// Token: 0x0401250D RID: 75021
		private string m_ReadOnlyPath;

		// Token: 0x0401250E RID: 75022
		private string m_ReadWritePath;

		// Token: 0x0401250F RID: 75023
		private string m_CurrentVariant;

		// Token: 0x04012510 RID: 75024
		private EnumHelper<AssetMode> m_AssetMode = new EnumHelper<AssetMode>(AssetMode.None);

		// Token: 0x04012511 RID: 75025
		private AssetManager.AssetLoader m_AssetLoader;

		// Token: 0x04012512 RID: 75026
		private ITMReferencePool<AssetManager.Asset> m_AssetPool;

		// Token: 0x04012513 RID: 75027
		private float m_AssetPoolAutoPurgeInterval;

		// Token: 0x04012514 RID: 75028
		private ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

		// Token: 0x04012515 RID: 75029
		private float m_AssetPackagePoolAutoPurgeInterval;

		// Token: 0x04012516 RID: 75030
		private AssetManager.AssetTree m_AssetTree;

		// Token: 0x04012517 RID: 75031
		private string m_PackageRootFolder;

		// Token: 0x04012518 RID: 75032
		private string m_ApplicationVersion;

		// Token: 0x04012519 RID: 75033
		private int m_InternalResourceVersion;

		// Token: 0x0401251A RID: 75034
		private string m_RemoteResServerURI;

		// Token: 0x0401251B RID: 75035
		private bool m_AssetDescTableIsReady;

		// Token: 0x0401251C RID: 75036
		private readonly LinearMap<string, AssetDesc> m_AssetDescTable;

		// Token: 0x0401251D RID: 75037
		private bool m_AssetPackageDescTableIsReady;

		// Token: 0x0401251E RID: 75038
		private readonly LinearMap<AssetPackageName, AssetPackageDesc> m_AssetPackageDescTable;

		// Token: 0x020046D5 RID: 18133
		private class Asset : Referable
		{
			// Token: 0x06019FB9 RID: 106425 RVA: 0x0081B16C File Offset: 0x0081956C
			public Asset(string assetName, ITMAssetObject assetObject, AssetManager.AssetPackage assetPackage, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool)
			{
				TMDebug.Assert(!string.IsNullOrEmpty(assetName), "Asset name can not be null or empty string!");
				TMDebug.Assert(null != assetObject, "Asset object can not be null!");
				this.m_Name = assetName;
				this.m_NameHashCode = assetName.GetHashCode();
				this.m_AssetPackage = assetPackage;
				if (this.m_AssetPackage != null)
				{
					this.m_AssetPackage.SpawmAsset();
				}
				this.m_AssetPackagePool = assetPackagePool;
				this.m_AssetObject = assetObject;
				this.m_Hold = true;
			}

			// Token: 0x06019FBA RID: 106426 RVA: 0x0081B1F1 File Offset: 0x008195F1
			public object CreateAssetInst()
			{
				this.m_Hold = false;
				return this.m_AssetObject.CreateAssetInst();
			}

			// Token: 0x06019FBB RID: 106427 RVA: 0x0081B205 File Offset: 0x00819605
			public void ReleaseHold()
			{
				this.m_Hold = false;
			}

			// Token: 0x06019FBC RID: 106428 RVA: 0x0081B20E File Offset: 0x0081960E
			public override void OnSpawn()
			{
				this.m_TimeStamp = Utility.Time.GetTicksNow();
				this.m_Hold = true;
			}

			// Token: 0x06019FBD RID: 106429 RVA: 0x0081B222 File Offset: 0x00819622
			public override void OnUnspawn()
			{
			}

			// Token: 0x06019FBE RID: 106430 RVA: 0x0081B224 File Offset: 0x00819624
			public override void OnRelease()
			{
				if (this.m_AssetPackage != null)
				{
					this.m_AssetPackage.UnspawnAsset();
					this.m_AssetPackagePool.Unspawn(this.m_AssetPackage);
				}
			}

			// Token: 0x17002179 RID: 8569
			// (get) Token: 0x06019FBF RID: 106431 RVA: 0x0081B24D File Offset: 0x0081964D
			public override string Name
			{
				get
				{
					return this.m_Name;
				}
			}

			// Token: 0x1700217A RID: 8570
			// (get) Token: 0x06019FC0 RID: 106432 RVA: 0x0081B255 File Offset: 0x00819655
			public override int NameHashCode
			{
				get
				{
					return this.m_NameHashCode;
				}
			}

			// Token: 0x1700217B RID: 8571
			// (get) Token: 0x06019FC1 RID: 106433 RVA: 0x0081B25D File Offset: 0x0081965D
			public override bool IsInUse
			{
				get
				{
					if (this.m_AssetObject.IsWeakRefAsset)
					{
						return this.m_AssetObject.IsInUse;
					}
					return this.m_AssetObject.IsInUse || this.m_Hold;
				}
			}

			// Token: 0x1700217C RID: 8572
			// (get) Token: 0x06019FC2 RID: 106434 RVA: 0x0081B294 File Offset: 0x00819694
			public override bool IsLocked
			{
				get
				{
					return this.m_LockFlag != 0;
				}
			}

			// Token: 0x1700217D RID: 8573
			// (get) Token: 0x06019FC3 RID: 106435 RVA: 0x0081B2A2 File Offset: 0x008196A2
			// (set) Token: 0x06019FC4 RID: 106436 RVA: 0x0081B2AA File Offset: 0x008196AA
			public override int LockFlag
			{
				get
				{
					return this.m_LockFlag;
				}
				set
				{
					this.m_LockFlag = value;
				}
			}

			// Token: 0x1700217E RID: 8574
			// (get) Token: 0x06019FC5 RID: 106437 RVA: 0x0081B2B3 File Offset: 0x008196B3
			public override long LastUseTime
			{
				get
				{
					return this.m_TimeStamp;
				}
			}

			// Token: 0x1700217F RID: 8575
			// (get) Token: 0x06019FC6 RID: 106438 RVA: 0x0081B2BB File Offset: 0x008196BB
			public override int SpawnCount
			{
				get
				{
					return this.m_AssetObject.SpawnCount;
				}
			}

			// Token: 0x0401251F RID: 75039
			private readonly string m_Name;

			// Token: 0x04012520 RID: 75040
			private readonly int m_NameHashCode;

			// Token: 0x04012521 RID: 75041
			private readonly ITMAssetObject m_AssetObject;

			// Token: 0x04012522 RID: 75042
			private readonly AssetManager.AssetPackage m_AssetPackage;

			// Token: 0x04012523 RID: 75043
			private readonly ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

			// Token: 0x04012524 RID: 75044
			private bool m_Hold;

			// Token: 0x04012525 RID: 75045
			private long m_TimeStamp = -1L;

			// Token: 0x04012526 RID: 75046
			private int m_LockFlag;
		}

		// Token: 0x020046D6 RID: 18134
		private class AssetLoader
		{
			// Token: 0x06019FC7 RID: 106439 RVA: 0x0081B2C8 File Offset: 0x008196C8
			public AssetLoader(AssetManager assetManager, ITMReferencePool<AssetManager.Asset> assetPool, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool, string resAsyncLoaderTypeName, string resSyncLoaderTypeName)
			{
				if (assetManager == null)
				{
					TMDebug.AssertFailed("Asset manager can not be null!");
				}
				if (assetPool == null)
				{
					TMDebug.AssertFailed("Asset pool can not be null!");
				}
				if (assetPackagePool == null)
				{
					TMDebug.AssertFailed("Asset package pool can not be null!");
				}
				if (string.IsNullOrEmpty(resAsyncLoaderTypeName))
				{
					TMDebug.AssertFailed("Res-async loader type name can not be null or empty!");
				}
				if (string.IsNullOrEmpty(resAsyncLoaderTypeName))
				{
					TMDebug.AssertFailed("Res-sync loader type name can not be null or empty!");
				}
				this.m_AssetManager = assetManager;
				this.m_TaskPool = new AssetManager.AssetLoader.TaskPool<AssetManager.AssetLoader.LoadTaskBase>();
				this.m_AssetPool = assetPool;
				this.m_AssetPackagePool = assetPackagePool;
				this.m_ResAsyncLoaderTypeName = resAsyncLoaderTypeName;
				this.m_ResSyncLoaderTypeName = resSyncLoaderTypeName;
				this.m_ResAsyncLoaderList = new LinkedList<TMResAsyncLoader>();
				this.m_ResSyncLoader = (this._CreateResourceLoader(resSyncLoaderTypeName) as TMResSyncLoader);
				if (this.m_ResSyncLoader == null)
				{
					TMDebug.AssertFailed("Create resource sync-loader has failed!");
				}
				this.m_TaskGroupIDCnt = 0U;
			}

			// Token: 0x06019FC8 RID: 106440 RVA: 0x0081B3C4 File Offset: 0x008197C4
			private void _RegisterLoadingRecord(string recordName, List<AssetManager.AssetLoader.AssetNameRecord> loadingRecordsList)
			{
				TMDebug.Assert(!string.IsNullOrEmpty(recordName));
				int hashCode = recordName.GetHashCode();
				loadingRecordsList.Add(new AssetManager.AssetLoader.AssetNameRecord(recordName, hashCode));
			}

			// Token: 0x06019FC9 RID: 106441 RVA: 0x0081B3F4 File Offset: 0x008197F4
			private void _UnregisterLoadingRecord(string recordName, List<AssetManager.AssetLoader.AssetNameRecord> loadingRecordsList)
			{
				int hashCode = recordName.GetHashCode();
				int i = 0;
				int count = loadingRecordsList.Count;
				while (i < count)
				{
					if (loadingRecordsList[i].m_AssetHashCode == hashCode && loadingRecordsList[i].m_AssetName == recordName)
					{
						loadingRecordsList.RemoveAt(i);
						return;
					}
					i++;
				}
				TMDebug.LogWarningFormat("Asset with name [{0}] is not in loading list!", new object[]
				{
					recordName
				});
			}

			// Token: 0x06019FCA RID: 106442 RVA: 0x0081B470 File Offset: 0x00819870
			private bool _IsRecordInLoading(string recordName, List<AssetManager.AssetLoader.AssetNameRecord> loadingRecordsList)
			{
				int hashCode = recordName.GetHashCode();
				int i = 0;
				int count = loadingRecordsList.Count;
				while (i < count)
				{
					if (loadingRecordsList[i].m_AssetHashCode == hashCode && loadingRecordsList[i].m_AssetName == recordName)
					{
						return true;
					}
					i++;
				}
				return false;
			}

			// Token: 0x06019FCB RID: 106443 RVA: 0x0081B4D0 File Offset: 0x008198D0
			private void _RegisterLoadingAsset(string assetName)
			{
				this._RegisterLoadingRecord(assetName, this.m_LoadingAssetRecords);
			}

			// Token: 0x06019FCC RID: 106444 RVA: 0x0081B4DF File Offset: 0x008198DF
			private void _UnregisterLoadingAsset(string assetName)
			{
				this._UnregisterLoadingRecord(assetName, this.m_LoadingAssetRecords);
			}

			// Token: 0x06019FCD RID: 106445 RVA: 0x0081B4EE File Offset: 0x008198EE
			private bool _IsAssetInLoading(string assetName)
			{
				return this._IsRecordInLoading(assetName, this.m_LoadingAssetRecords);
			}

			// Token: 0x06019FCE RID: 106446 RVA: 0x0081B4FD File Offset: 0x008198FD
			private void _RegisterLoadingPackage(string packageName)
			{
				TMDebug.Assert(!this.m_AssetPackagePool.CanSpawn(packageName), "Asset package '{0}' has already loaded!", new object[]
				{
					packageName
				});
				this._RegisterLoadingRecord(packageName, this.m_LoadingPackageRecords);
			}

			// Token: 0x06019FCF RID: 106447 RVA: 0x0081B52F File Offset: 0x0081992F
			private void _UnregisterLoadingPackage(string packageName)
			{
				this._UnregisterLoadingRecord(packageName, this.m_LoadingPackageRecords);
			}

			// Token: 0x06019FD0 RID: 106448 RVA: 0x0081B53E File Offset: 0x0081993E
			private bool _IsPackageInLoading(string packageName)
			{
				return this._IsRecordInLoading(packageName, this.m_LoadingPackageRecords);
			}

			// Token: 0x17002180 RID: 8576
			// (get) Token: 0x06019FD1 RID: 106449 RVA: 0x0081B54D File Offset: 0x0081994D
			public string ReadOnlyPath
			{
				get
				{
					return this.m_AssetManager.ReadOnlyPath;
				}
			}

			// Token: 0x17002181 RID: 8577
			// (get) Token: 0x06019FD2 RID: 106450 RVA: 0x0081B55A File Offset: 0x0081995A
			public string ReadWritePath
			{
				get
				{
					return this.m_AssetManager.ReadWritePath;
				}
			}

			// Token: 0x17002182 RID: 8578
			// (get) Token: 0x06019FD3 RID: 106451 RVA: 0x0081B567 File Offset: 0x00819967
			public string PackageRootFolder
			{
				get
				{
					return this.m_AssetManager.PackageRootFolder;
				}
			}

			// Token: 0x17002183 RID: 8579
			// (get) Token: 0x06019FD4 RID: 106452 RVA: 0x0081B574 File Offset: 0x00819974
			public int LoadAgentTotalCount
			{
				get
				{
					return this.m_TaskPool.TotalAgentCount;
				}
			}

			// Token: 0x17002184 RID: 8580
			// (get) Token: 0x06019FD5 RID: 106453 RVA: 0x0081B581 File Offset: 0x00819981
			public int FreeAgentCount
			{
				get
				{
					return this.m_TaskPool.FreeAgentCount;
				}
			}

			// Token: 0x17002185 RID: 8581
			// (get) Token: 0x06019FD6 RID: 106454 RVA: 0x0081B58E File Offset: 0x0081998E
			public int WorkingAgentCount
			{
				get
				{
					return this.m_TaskPool.WorkingAgentCount;
				}
			}

			// Token: 0x17002186 RID: 8582
			// (get) Token: 0x06019FD7 RID: 106455 RVA: 0x0081B59B File Offset: 0x0081999B
			public int WaitingTaskCount
			{
				get
				{
					return this.m_TaskPool.WaitingTaskCount;
				}
			}

			// Token: 0x17002187 RID: 8583
			// (get) Token: 0x06019FD8 RID: 106456 RVA: 0x0081B5A8 File Offset: 0x008199A8
			public TMResSyncLoader ResSyncLoader
			{
				get
				{
					return this.m_ResSyncLoader;
				}
			}

			// Token: 0x06019FD9 RID: 106457 RVA: 0x0081B5B0 File Offset: 0x008199B0
			public byte[] LoadFile(string fileName, uint uFlag = 0U, uint waterMark = 4294967295U)
			{
				return null;
			}

			// Token: 0x06019FDA RID: 106458 RVA: 0x0081B5B3 File Offset: 0x008199B3
			public int LoadFileAsync(string fileName, FileLoadCallbacks fileLoadCallback, object userData, int priorityLevel = 0)
			{
				return -1;
			}

			// Token: 0x06019FDB RID: 106459 RVA: 0x0081B5B8 File Offset: 0x008199B8
			public bool IsAssetExist(string assetName, Type assetType, bool loadFromPackage)
			{
				string assetName2;
				string text;
				this._ParseAssetPath(assetName, out assetName2, out text);
				int num = -1;
				string text2 = null;
				AssetPackageDesc? assetPackageDesc = null;
				return this._CheckAsset(assetName2, loadFromPackage, out assetPackageDesc, out text2, out num);
			}

			// Token: 0x06019FDC RID: 106460 RVA: 0x0081B5F0 File Offset: 0x008199F0
			public bool PreLoadAsset(string assetName, Type assetType, object userData, bool loadFromPackage, uint uFlag = 0U)
			{
				string assetName2;
				string subResName;
				this._ParseAssetPath(assetName, out assetName2, out subResName);
				EnumHelper<AssetLoadFlag> enumHelper = new EnumHelper<AssetLoadFlag>(uFlag);
				AssetManager.Asset asset = this.m_AssetPool.Spawn(assetName);
				if (asset != null)
				{
					return true;
				}
				AssetManager.AssetPackage assetPackage = null;
				string text = null;
				int assetPackageDescID = -1;
				AssetPackageDesc? assetPackageDesc = null;
				if (!this._CheckAsset(assetName2, loadFromPackage, out assetPackageDesc, out text, out assetPackageDescID))
				{
					TMDebug.LogWarningFormat("Asset with name [{0}] check failed!", new object[]
					{
						assetName
					});
					return false;
				}
				if (loadFromPackage)
				{
					List<AssetManager.AssetPackage> list = null;
					if (assetPackageDesc != null && !string.IsNullOrEmpty(text) && !this._LoadPackageSync(assetPackageDescID, false, userData, ref list, ref assetPackage))
					{
						TMDebug.LogErrorFormat("Can not load dependency package '{0}' when load asset '{1}'!", new object[]
						{
							assetPackageDesc.Value.PackageName.Name,
							assetName
						});
						return false;
					}
				}
				object obj;
				if (assetPackage == null)
				{
					obj = this.m_ResSyncLoader.LoadAsset(null, assetName2, subResName, assetType);
				}
				else
				{
					obj = this.m_ResSyncLoader.LoadAsset(assetPackage.Object, text, subResName, assetType);
				}
				if (obj == null)
				{
					return false;
				}
				asset = new AssetManager.Asset(assetName, obj as ITMAssetObject, assetPackage, this.m_AssetPackagePool);
				this.m_AssetPool.Register(asset, true);
				asset.ReleaseHold();
				return true;
			}

			// Token: 0x06019FDD RID: 106461 RVA: 0x0081B737 File Offset: 0x00819B37
			public void QurreyAssetPackage(string assetName, List<string> packages)
			{
				this._QureyAssetPackages(assetName, packages);
			}

			// Token: 0x06019FDE RID: 106462 RVA: 0x0081B744 File Offset: 0x00819B44
			public object LoadAsset(string assetName, Type assetType, object userData, bool loadFromPackage, uint uFlag = 0U)
			{
				string assetName2;
				string subResName;
				this._ParseAssetPath(assetName, out assetName2, out subResName);
				EnumHelper<AssetLoadFlag> enumHelper = new EnumHelper<AssetLoadFlag>(uFlag);
				AssetManager.Asset asset = this.m_AssetPool.Spawn(assetName);
				if (asset != null)
				{
					return asset.CreateAssetInst();
				}
				AssetManager.AssetPackage assetPackage = null;
				string text = null;
				int assetPackageDescID = -1;
				AssetPackageDesc? assetPackageDesc = null;
				if (!this._CheckAsset(assetName2, loadFromPackage, out assetPackageDesc, out text, out assetPackageDescID))
				{
					TMDebug.LogWarningFormat("Asset with name [{0}] check failed!", new object[]
					{
						assetName
					});
					return null;
				}
				if (loadFromPackage)
				{
					List<AssetManager.AssetPackage> list = null;
					if (assetPackageDesc != null && !string.IsNullOrEmpty(text) && !this._LoadPackageSync(assetPackageDescID, false, userData, ref list, ref assetPackage))
					{
						TMDebug.LogErrorFormat("Can not load dependency package '{0}' when load asset '{1}'!", new object[]
						{
							assetPackageDesc.Value.PackageName.Name,
							assetName
						});
						return null;
					}
				}
				object obj;
				if (assetPackage == null)
				{
					obj = this.m_ResSyncLoader.LoadAsset(null, assetName2, subResName, assetType);
				}
				else
				{
					obj = this.m_ResSyncLoader.LoadAsset(assetPackage.Object, text, subResName, assetType);
				}
				if (obj == null)
				{
					return null;
				}
				asset = new AssetManager.Asset(assetName, obj as ITMAssetObject, assetPackage, this.m_AssetPackagePool);
				this.m_AssetPool.Register(asset, true);
				return asset.CreateAssetInst();
			}

			// Token: 0x06019FDF RID: 106463 RVA: 0x0081B890 File Offset: 0x00819C90
			public int LoadAssetAsync(string assetName, Type assetType, AssetLoadCallbacks assetLoadCallback, object userData, bool loadFromPackage, int priorityLevel = 0)
			{
				string text;
				string subResName;
				this._ParseAssetPath(assetName, out text, out subResName);
				AssetPackageDesc? assetPackageDesc = null;
				string assetNameInPackage = null;
				int assetPackageID = -1;
				if (!this._CheckAsset(text, loadFromPackage, out assetPackageDesc, out assetNameInPackage, out assetPackageID))
				{
					assetLoadCallback.OnAssetLoadFailure(assetName, AssetLoadErrorCode.NotExist, string.Format("Asset with name [{0}] check asset has failed!", assetName), userData);
					return -1;
				}
				AssetManager.AssetLoader.AssetTask assetTask = new AssetManager.AssetLoader.AssetTask(this, this.m_AssetPool, this.m_AssetPackagePool, text, text, subResName, assetType, assetLoadCallback, assetPackageDesc.Value, assetNameInPackage, (int)this._AllocHandle(), userData);
				if (loadFromPackage && !this._LoadPackageAsync(assetPackageID, false, assetTask, userData, priorityLevel))
				{
					string message = string.Format("Can not load package '{0}' when load asset '{1}'!", assetPackageDesc.Value.PackageName.Name, assetName);
					assetLoadCallback.OnAssetLoadFailure(assetName, AssetLoadErrorCode.DependencyLoadError, message, userData);
					return -1;
				}
				this.m_TaskPool.AddTask(assetTask, priorityLevel);
				return assetTask.TaskGroupID;
			}

			// Token: 0x06019FE0 RID: 106464 RVA: 0x0081B97C File Offset: 0x00819D7C
			public void SetAssetLoadAgentCount(int agentCount)
			{
				this._ClearAssetLoadAgent();
				if (agentCount > 64)
				{
					agentCount = 64;
				}
				Debug.LogFormat("### Set asset load agent count:{0}", new object[]
				{
					agentCount
				});
				int i = 0;
				int num = agentCount;
				while (i < num)
				{
					AssetManager.AssetLoader.LoadTaskAgent agent = new AssetManager.AssetLoader.LoadTaskAgent(this.m_AssetPool, this.m_AssetPackagePool, this);
					this.m_TaskPool.AddAgent(agent);
					i++;
				}
			}

			// Token: 0x06019FE1 RID: 106465 RVA: 0x0081B9E7 File Offset: 0x00819DE7
			public void Update(float elapseSeconds, float realElapseSeconds)
			{
				this.m_TaskPool.Update(elapseSeconds, realElapseSeconds);
			}

			// Token: 0x06019FE2 RID: 106466 RVA: 0x0081B9F6 File Offset: 0x00819DF6
			private void _ClearAssetLoadAgent()
			{
				this.m_TaskPool.ClearFreeAgent();
			}

			// Token: 0x06019FE3 RID: 106467 RVA: 0x0081BA04 File Offset: 0x00819E04
			private bool _LoadPackageSync(int assetPackageDescID, bool asDependency, object userData, ref List<AssetManager.AssetPackage> assetPackageList, ref AssetManager.AssetPackage assetPackage)
			{
				AssetPackageDesc assetPackageDesc;
				if (this.m_AssetManager.m_AssetPackageDescTable.TryGetValueAt(assetPackageDescID, out assetPackageDesc))
				{
					AssetManager.AssetPackage assetPackage2 = this.m_AssetPackagePool.Spawn(assetPackageDesc.PackageName.Name);
					if (assetPackage2 != null)
					{
						if (asDependency)
						{
							assetPackageList.Add(assetPackage2);
							return true;
						}
						if (!assetPackage2.AsDependency)
						{
							assetPackage = assetPackage2;
							return true;
						}
					}
					if (!asDependency)
					{
						assetPackageList = new List<AssetManager.AssetPackage>();
						int[] dependencyPackageIDs = assetPackageDesc.DependencyPackageIDs;
						int i = 0;
						int num = dependencyPackageIDs.Length;
						while (i < num)
						{
							if (!this._LoadPackageSync(dependencyPackageIDs[i], true, userData, ref assetPackageList, ref assetPackage))
							{
								TMDebug.LogErrorFormat("Can not load dependency package when load asset package'{0}'!", new object[]
								{
									assetPackageDesc.PackageName.Name
								});
								return false;
							}
							i++;
						}
					}
					if (assetPackage2 == null)
					{
						string name = assetPackageDesc.PackageName.Name;
						string text = Utility.Path.Combine(this.ReadWritePath, Utility.Path.Combine(this.PackageRootFolder, name));
						if (!AssetManager._IsAssetExistWithPath(text))
						{
							text = Utility.Path.Combine(this.ReadOnlyPath, Utility.Path.Combine(this.PackageRootFolder, name));
						}
						object obj = this.m_ResSyncLoader.LoadPackage(text);
						if (obj == null)
						{
							return false;
						}
						assetPackage2 = new AssetManager.AssetPackage(name, obj, this.m_ResSyncLoader, (!asDependency) ? assetPackageList : null, this.m_AssetPackagePool);
						this.m_AssetPackagePool.Register(assetPackage2, true);
					}
					if (asDependency)
					{
						assetPackageList.Add(assetPackage2);
					}
					else
					{
						assetPackage2.AddDependency(assetPackageList);
					}
					assetPackage = assetPackage2;
					return true;
				}
				TMDebug.LogErrorFormat("Can not load dependency package when load package '{0}'!", new object[]
				{
					assetPackageDesc.PackageName.Name,
					assetPackageDesc.PackageName.Name
				});
				return false;
			}

			// Token: 0x06019FE4 RID: 106468 RVA: 0x0081BBD4 File Offset: 0x00819FD4
			private bool _LoadPackageAsync(int assetPackageID, bool asDependency, AssetManager.AssetLoader.LoadTaskBase mainTask, object userData, int priorityLevel)
			{
				TMDebug.Assert(null != mainTask, "Main task can not be null!");
				AssetPackageDesc packageDesc;
				if (this.m_AssetManager.m_AssetPackageDescTable.TryGetValueAt(assetPackageID, out packageDesc))
				{
					AssetManager.AssetLoader.PackageTask packageTask = new AssetManager.AssetLoader.PackageTask(this, this.m_AssetPool, this.m_AssetPackagePool, packageDesc.PackageName.Name, mainTask, packageDesc, userData, asDependency);
					if (!asDependency)
					{
						int[] dependencyPackageIDs = packageDesc.DependencyPackageIDs;
						int i = 0;
						int num = dependencyPackageIDs.Length;
						while (i < num)
						{
							if (!this._LoadPackageAsync(dependencyPackageIDs[i], true, packageTask, userData, priorityLevel))
							{
								TMDebug.LogErrorFormat("Can not load dependency package when load package '{1}'!", new object[]
								{
									packageDesc.PackageName.Name
								});
								return false;
							}
							i++;
						}
					}
					this.m_TaskPool.AddTask(packageTask, priorityLevel);
					return true;
				}
				TMDebug.LogErrorFormat("Can not load dependency package when load package '{0}'!", new object[]
				{
					packageDesc.PackageName.Name
				});
				return false;
			}

			// Token: 0x06019FE5 RID: 106469 RVA: 0x0081BCCC File Offset: 0x0081A0CC
			private bool _CheckAsset(string assetName, bool loadFromPackage, out AssetPackageDesc? assetPackageDesc, out string assetNameInPackage, out int assetPackageID)
			{
				assetPackageDesc = new AssetPackageDesc?(default(AssetPackageDesc));
				assetNameInPackage = null;
				assetPackageID = -1;
				if (string.IsNullOrEmpty(assetName))
				{
					return false;
				}
				if (!loadFromPackage)
				{
					return this._IsAssetExist(assetName);
				}
				AssetDesc assetDesc;
				AssetPackageDesc value;
				if (this.m_AssetManager.m_AssetDescTable.TryGetValue(Utility.Path.ChangeExtension(assetName, null).ToLower(), out assetDesc) && 0 <= assetDesc.AssetPackageID && assetDesc.AssetPackageID < this.m_AssetManager.m_AssetPackageDescTable.Count && this.m_AssetManager.m_AssetPackageDescTable.TryGetValueAt(assetDesc.AssetPackageID, out value))
				{
					assetPackageDesc = new AssetPackageDesc?(value);
					assetPackageID = assetDesc.AssetPackageID;
					if (assetPackageDesc.Value.AssetPackageUsage.HasFlag(AssetPackageUsage.LoadAssetWithGUIDName))
					{
						assetNameInPackage = assetDesc.AssetGUIDName;
					}
					else
					{
						int num = assetName.LastIndexOf('/');
						if (num + 1 >= assetName.Length)
						{
							TMDebug.LogWarningFormat("Invalid asset name [{0}]!", new object[]
							{
								assetName
							});
							return false;
						}
						assetNameInPackage = assetName.Substring(num + 1);
					}
					return true;
				}
				return false;
			}

			// Token: 0x06019FE6 RID: 106470 RVA: 0x0081BDFC File Offset: 0x0081A1FC
			private void _QureyAssetPackages(string assetName, List<string> packages)
			{
				AssetDesc assetDesc;
				AssetPackageDesc assetPackageDesc;
				if (this.m_AssetManager.m_AssetDescTable.TryGetValue(Utility.Path.ChangeExtension(assetName, null).ToLower(), out assetDesc) && 0 <= assetDesc.AssetPackageID && assetDesc.AssetPackageID < this.m_AssetManager.m_AssetPackageDescTable.Count && this.m_AssetManager.m_AssetPackageDescTable.TryGetValueAt(assetDesc.AssetPackageID, out assetPackageDesc))
				{
					packages.Add(assetPackageDesc.m_PackageName.Name);
					if (assetPackageDesc.DependencyPackageIDs != null)
					{
						int i = 0;
						int num = assetPackageDesc.DependencyPackageIDs.Length;
						while (i < num)
						{
							AssetPackageDesc assetPackageDesc2;
							if (this.m_AssetManager.m_AssetPackageDescTable.TryGetValueAt(assetPackageDesc.DependencyPackageIDs[i], out assetPackageDesc2))
							{
								packages.Add(assetPackageDesc2.m_PackageName.Name);
							}
							i++;
						}
					}
				}
			}

			// Token: 0x06019FE7 RID: 106471 RVA: 0x0081BEE1 File Offset: 0x0081A2E1
			private bool _IsAssetExist(string assetPath)
			{
				return true;
			}

			// Token: 0x06019FE8 RID: 106472 RVA: 0x0081BEE4 File Offset: 0x0081A2E4
			private ITMResourceLoader _CreateResourceLoader(string resLoaderTypeName)
			{
				ITMResourceLoader itmresourceLoader = (ITMResourceLoader)Utility.Assembly.CreateInstance(resLoaderTypeName);
				if (itmresourceLoader != null)
				{
					return itmresourceLoader;
				}
				TMDebug.AssertFailed(string.Format("Can not create resource loader with type '{0}'!", resLoaderTypeName));
				return null;
			}

			// Token: 0x06019FE9 RID: 106473 RVA: 0x0081BF18 File Offset: 0x0081A318
			public TMResAsyncLoader AllocateResAsyncLoader()
			{
				LinkedListNode<TMResAsyncLoader> first = this.m_ResAsyncLoaderList.First;
				if (first != null)
				{
					this.m_ResAsyncLoaderList.RemoveFirst();
					return first.Value;
				}
				return this._CreateResourceLoader(this.m_ResAsyncLoaderTypeName) as TMResAsyncLoader;
			}

			// Token: 0x06019FEA RID: 106474 RVA: 0x0081BF5A File Offset: 0x0081A35A
			public void RecycleAsyncLoader(TMResAsyncLoader resAsyncLoader)
			{
				if (resAsyncLoader == null)
				{
					TMDebug.LogErrorFormat("Resource loader can not be null!", new object[0]);
					return;
				}
				this.m_ResAsyncLoaderList.AddLast(resAsyncLoader);
			}

			// Token: 0x06019FEB RID: 106475 RVA: 0x0081BF80 File Offset: 0x0081A380
			public void Shutdown()
			{
				this.m_TaskPool.Shutdown();
				if (this.m_ResSyncLoader != null)
				{
					this.m_ResSyncLoader.Reset();
				}
				LinkedListNode<TMResAsyncLoader> next;
				for (LinkedListNode<TMResAsyncLoader> linkedListNode = this.m_ResAsyncLoaderList.First; linkedListNode != null; linkedListNode = next)
				{
					next = linkedListNode.Next;
					linkedListNode.Value.Reset();
					this.m_ResAsyncLoaderList.Remove(linkedListNode);
				}
			}

			// Token: 0x06019FEC RID: 106476 RVA: 0x0081BFE8 File Offset: 0x0081A3E8
			private void _ParseAssetPath(string assetPath, out string mainRes, out string subRes)
			{
				int num = assetPath.LastIndexOf(':');
				if (0 <= num && num < assetPath.Length)
				{
					mainRes = assetPath.Substring(0, num);
					subRes = assetPath.Substring(num + 1);
				}
				else
				{
					subRes = string.Empty;
					mainRes = assetPath;
				}
			}

			// Token: 0x06019FED RID: 106477 RVA: 0x0081C038 File Offset: 0x0081A438
			private string _GetAssetPackageNameByPackageID(int packageID)
			{
				if (0 <= packageID && packageID < this.m_AssetManager.m_AssetPackageDescTable.Count)
				{
					return this.m_AssetManager.m_AssetPackageDescTable[packageID].PackageName.Name;
				}
				return string.Empty;
			}

			// Token: 0x06019FEE RID: 106478 RVA: 0x0081C08C File Offset: 0x0081A48C
			protected uint _AllocHandle()
			{
				if (this.m_TaskGroupIDCnt + 1U >= 1073741823U)
				{
					this.m_TaskGroupIDCnt = 0U;
				}
				return this.m_TaskGroupIDCnt++ | (this.m_HandleType & 3U) << 30;
			}

			// Token: 0x04012527 RID: 75047
			private readonly List<AssetManager.AssetLoader.AssetNameRecord> m_LoadingAssetRecords = new List<AssetManager.AssetLoader.AssetNameRecord>();

			// Token: 0x04012528 RID: 75048
			private readonly List<AssetManager.AssetLoader.AssetNameRecord> m_LoadingPackageRecords = new List<AssetManager.AssetLoader.AssetNameRecord>();

			// Token: 0x04012529 RID: 75049
			private readonly AssetManager m_AssetManager;

			// Token: 0x0401252A RID: 75050
			private readonly AssetManager.AssetLoader.TaskPool<AssetManager.AssetLoader.LoadTaskBase> m_TaskPool;

			// Token: 0x0401252B RID: 75051
			private readonly ITMReferencePool<AssetManager.Asset> m_AssetPool;

			// Token: 0x0401252C RID: 75052
			private readonly ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

			// Token: 0x0401252D RID: 75053
			private readonly string m_ResAsyncLoaderTypeName;

			// Token: 0x0401252E RID: 75054
			private readonly string m_ResSyncLoaderTypeName;

			// Token: 0x0401252F RID: 75055
			private readonly TMResSyncLoader m_ResSyncLoader;

			// Token: 0x04012530 RID: 75056
			private readonly LinkedList<TMResAsyncLoader> m_ResAsyncLoaderList;

			// Token: 0x04012531 RID: 75057
			private uint m_TaskGroupIDCnt;

			// Token: 0x04012532 RID: 75058
			private readonly uint m_HandleType;

			// Token: 0x04012533 RID: 75059
			private readonly string[] m_InvalidDependencyAssetName = new string[0];

			// Token: 0x020046D7 RID: 18135
			private sealed class AssetTask : AssetManager.AssetLoader.LoadTaskBase
			{
				// Token: 0x06019FEF RID: 106479 RVA: 0x0081C1E4 File Offset: 0x0081A5E4
				public AssetTask(AssetManager.AssetLoader assetLoader, ITMReferencePool<AssetManager.Asset> assetPool, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool, string assetName, string mainResPath, string subResName, Type assetType, AssetLoadCallbacks callbacks, AssetPackageDesc packageDesc, string assetNameInPackage, int groupID, object userData) : base(assetLoader, assetPool, assetPackagePool, assetName, packageDesc, groupID, userData)
				{
					TMDebug.Assert(!string.IsNullOrEmpty(mainResPath), "Asset name can not be null or empty string!");
					TMDebug.Assert(null != callbacks, "Asset load call back can not be null!");
					this.m_MainResPath = mainResPath;
					this.m_SubResName = subResName;
					this.m_AssetNameInPackage = assetNameInPackage;
					this.m_LoadFromPackage = !string.IsNullOrEmpty(assetNameInPackage);
					this.m_Callbacks = callbacks;
					this.m_AssetType = assetType;
				}

				// Token: 0x06019FF0 RID: 106480 RVA: 0x0081C260 File Offset: 0x0081A660
				public sealed override void OnStart(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					if (this.m_AssetLoader._IsAssetInLoading(base.AssetName))
					{
						agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForTarget);
						return;
					}
					AssetManager.Asset asset = this.m_AssetPool.Spawn(base.AssetName);
					if (asset != null)
					{
						this.OnLoadSuccess(agent, asset, Utility.Time.TicksToSeconds(DateTime.Now.Ticks - base.StartTimeStamp));
						return;
					}
					this.m_IsTaskInLoading = true;
					this.m_AssetLoader._RegisterLoadingAsset(base.AssetName);
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForDependency);
					this.OnWaitDependency(agent);
				}

				// Token: 0x06019FF1 RID: 106481 RVA: 0x0081C2EC File Offset: 0x0081A6EC
				public sealed override void OnWaitDependency(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					if (this.m_LoadFromPackage)
					{
						string name = this.m_AssetPackageDesc.PackageName.Name;
						if (!this.m_AssetPackagePool.CanSpawn(name))
						{
							if (!this.m_AssetLoader._IsPackageInLoading(name))
							{
								this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, string.Format("Can not find dependency package with name '{0}' in loading!", name));
								return;
							}
							agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForDependency);
							return;
						}
						else if (this.m_AssetPackage == null)
						{
							this.m_AssetPackage = this.m_AssetPackagePool.Spawn(this.m_AssetPackageDesc.PackageName.Name);
						}
					}
					this.OnDependencyLoadReady(agent);
				}

				// Token: 0x06019FF2 RID: 106482 RVA: 0x0081C394 File Offset: 0x0081A794
				public sealed override void OnDependencyLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForTarget);
					if (this.m_LoadFromPackage)
					{
						if (this.m_AssetPackage == null)
						{
							this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, string.Format("Dependency package with asset name '{0}' is null!", base.AssetName));
							return;
						}
						agent.LoadAssetAsync(this.m_AssetPackage, this.AssetNameInPackage, this.SubResName, this.AssetType);
					}
					else
					{
						agent.LoadAssetAsync(null, this.MainResPath, this.SubResName, this.AssetType);
					}
				}

				// Token: 0x06019FF3 RID: 106483 RVA: 0x0081C418 File Offset: 0x0081A818
				public sealed override void OnWaitTarget(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					string assetName = base.AssetName;
					if (this.m_AssetLoader._IsAssetInLoading(assetName))
					{
						return;
					}
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.None);
					AssetManager.Asset asset = this.m_AssetPool.Spawn(assetName);
					if (asset == null)
					{
						this.OnLoadFailure(agent, AssetLoadErrorCode.NotExist, string.Format("Asset '{0}' has been destroyed, or does not exist!", assetName));
						return;
					}
					this.OnTargetLoadReady(agent, asset);
				}

				// Token: 0x06019FF4 RID: 106484 RVA: 0x0081C474 File Offset: 0x0081A874
				public sealed override void OnTargetLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent, object asset)
				{
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.None);
					this.OnLoadSuccess(agent, asset, Utility.Time.TicksToSeconds(DateTime.Now.Ticks - base.StartTimeStamp));
				}

				// Token: 0x06019FF5 RID: 106485 RVA: 0x0081C4AC File Offset: 0x0081A8AC
				public sealed override void OnLoadSuccess(AssetManager.AssetLoader.LoadTaskAgent agent, object asset, float duration)
				{
					if (this.m_IsTaskInLoading)
					{
						this.m_IsTaskInLoading = false;
						this.m_AssetLoader._UnregisterLoadingAsset(base.AssetName);
					}
					base.OnLoadSuccess(agent, asset, duration);
					AssetManager.Asset asset2 = asset as AssetManager.Asset;
					this.m_StateCode = AssetManager.AssetLoader.LoadTaskState.Done;
					if (asset2 != null)
					{
						this.m_Callbacks.OnAssetLoadSuccess(base.AssetName, asset2.CreateAssetInst(), this.m_TaskGroupID, duration, this.m_UserData);
					}
					else
					{
						this.m_Callbacks.OnAssetLoadFailure(base.AssetName, AssetLoadErrorCode.NullAsset, "Asset loaded is null!", this.m_UserData);
					}
				}

				// Token: 0x06019FF6 RID: 106486 RVA: 0x0081C54C File Offset: 0x0081A94C
				public sealed override void OnLoadFailure(AssetManager.AssetLoader.LoadTaskAgent agent, AssetLoadErrorCode errorCoude, string message)
				{
					base.OnLoadFailure(agent, errorCoude, message);
					if (this.m_IsTaskInLoading)
					{
						this.m_IsTaskInLoading = false;
						this.m_AssetLoader._UnregisterLoadingAsset(base.AssetName);
					}
					this.m_StateCode = AssetManager.AssetLoader.LoadTaskState.Done;
					this.m_Callbacks.OnAssetLoadFailure(base.AssetName, errorCoude, message, this.m_UserData);
				}

				// Token: 0x06019FF7 RID: 106487 RVA: 0x0081C5AA File Offset: 0x0081A9AA
				public sealed override void OnLoadUpdate(AssetManager.AssetLoader.LoadTaskAgent agent, float progress)
				{
					base.OnLoadUpdate(agent, progress);
					if (this.m_Callbacks.OnAssetLoadUpdate != null)
					{
						this.m_Callbacks.OnAssetLoadUpdate(base.AssetName, progress, this.m_UserData);
					}
				}

				// Token: 0x06019FF8 RID: 106488 RVA: 0x0081C5E4 File Offset: 0x0081A9E4
				public sealed override void OnLoadDependencyDone(AssetManager.AssetLoader.LoadTaskAgent agent, object dependency)
				{
					base.OnLoadDependencyDone(agent, dependency);
					AssetManager.AssetPackage assetPackage = dependency as AssetManager.AssetPackage;
					if (assetPackage != null)
					{
						this.m_AssetPackage = assetPackage;
					}
					else
					{
						string message = string.Format("Dependency package '{0}' type cast error source object type '{1}' needed type:{2}", base.AssetName, dependency.GetType().Name, typeof(AssetManager.AssetPackage).Name);
						this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, message);
					}
				}

				// Token: 0x06019FF9 RID: 106489 RVA: 0x0081C648 File Offset: 0x0081AA48
				public sealed override List<AssetManager.AssetPackage> GetDependencyPackages()
				{
					return new List<AssetManager.AssetPackage>(1)
					{
						this.m_AssetPackage
					};
				}

				// Token: 0x06019FFA RID: 106490 RVA: 0x0081C669 File Offset: 0x0081AA69
				public sealed override AssetManager.AssetPackage GetMainPackage()
				{
					return this.m_AssetPackage;
				}

				// Token: 0x17002188 RID: 8584
				// (get) Token: 0x06019FFB RID: 106491 RVA: 0x0081C671 File Offset: 0x0081AA71
				public string MainResPath
				{
					get
					{
						return this.m_MainResPath;
					}
				}

				// Token: 0x17002189 RID: 8585
				// (get) Token: 0x06019FFC RID: 106492 RVA: 0x0081C679 File Offset: 0x0081AA79
				public string SubResName
				{
					get
					{
						return this.m_SubResName;
					}
				}

				// Token: 0x1700218A RID: 8586
				// (get) Token: 0x06019FFD RID: 106493 RVA: 0x0081C681 File Offset: 0x0081AA81
				public Type AssetType
				{
					get
					{
						return this.m_AssetType;
					}
				}

				// Token: 0x1700218B RID: 8587
				// (get) Token: 0x06019FFE RID: 106494 RVA: 0x0081C689 File Offset: 0x0081AA89
				public string AssetNameInPackage
				{
					get
					{
						return this.m_AssetNameInPackage;
					}
				}

				// Token: 0x04012534 RID: 75060
				private readonly AssetLoadCallbacks m_Callbacks;

				// Token: 0x04012535 RID: 75061
				private readonly bool m_LoadFromPackage;

				// Token: 0x04012536 RID: 75062
				private AssetManager.AssetPackage m_AssetPackage;

				// Token: 0x04012537 RID: 75063
				private readonly string m_MainResPath;

				// Token: 0x04012538 RID: 75064
				private readonly string m_SubResName;

				// Token: 0x04012539 RID: 75065
				private readonly string m_AssetGUIDName;

				// Token: 0x0401253A RID: 75066
				private readonly string m_AssetNameInPackage;

				// Token: 0x0401253B RID: 75067
				private readonly Type m_AssetType;
			}

			// Token: 0x020046D8 RID: 18136
			private enum LoadState
			{
				// Token: 0x0401253D RID: 75069
				None,
				// Token: 0x0401253E RID: 75070
				WaitForDependency,
				// Token: 0x0401253F RID: 75071
				WaitForTarget
			}

			// Token: 0x020046D9 RID: 18137
			private struct AssetNameRecord
			{
				// Token: 0x06019FFF RID: 106495 RVA: 0x0081C691 File Offset: 0x0081AA91
				public AssetNameRecord(string name, int hashCode)
				{
					if (string.IsNullOrEmpty(name))
					{
						TMDebug.AssertFailed("Name can not be null or empty!");
					}
					this.m_AssetName = name;
					this.m_AssetHashCode = hashCode;
				}

				// Token: 0x04012540 RID: 75072
				public readonly string m_AssetName;

				// Token: 0x04012541 RID: 75073
				public readonly int m_AssetHashCode;
			}

			// Token: 0x020046DA RID: 18138
			private class LoadTaskAgent
			{
				// Token: 0x0601A000 RID: 106496 RVA: 0x0081C6B8 File Offset: 0x0081AAB8
				public LoadTaskAgent(ITMReferencePool<AssetManager.Asset> assetPool, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool, AssetManager.AssetLoader assetLoader)
				{
					if (assetPool == null)
					{
						TMDebug.AssertFailed("Asset pool is null!");
					}
					if (assetPackagePool == null)
					{
						TMDebug.AssertFailed("Asset package pool is null!");
					}
					if (assetLoader == null)
					{
						TMDebug.AssertFailed("Asset loader is null!");
					}
					this.m_AssetPool = assetPool;
					this.m_AssetPackagePool = assetPackagePool;
					this.m_AssetLoader = assetLoader;
					this.m_ResAsyncLoader = this.m_AssetLoader.AllocateResAsyncLoader();
					this.m_CurrentTask = null;
					this.m_State = AssetManager.AssetLoader.LoadState.None;
				}

				// Token: 0x1700218C RID: 8588
				// (get) Token: 0x0601A001 RID: 106497 RVA: 0x0081C72F File Offset: 0x0081AB2F
				public AssetManager.AssetLoader.LoadTaskBase Task
				{
					get
					{
						return this.m_CurrentTask;
					}
				}

				// Token: 0x0601A002 RID: 106498 RVA: 0x0081C738 File Offset: 0x0081AB38
				public void Initialize()
				{
					this.m_ResAsyncLoader.UpdateResourceEventHandler += this._OnAssetLoadAgentUpdate;
					this.m_ResAsyncLoader.LoadResourceCompleteEventHandler += this._OnAssetLoadAgentLoadAssetComplete;
					this.m_ResAsyncLoader.LoadResourceFailedEventHandler += this._OnAssetLoadAgentLoadAssetFailed;
					this.m_ResAsyncLoader.LoadPackageCompleteEventHandler += this._OnAssetLoadAgentLoadPackageComplete;
				}

				// Token: 0x0601A003 RID: 106499 RVA: 0x0081C7A4 File Offset: 0x0081ABA4
				public void Shutdown()
				{
					this.m_ResAsyncLoader.UpdateResourceEventHandler -= this._OnAssetLoadAgentUpdate;
					this.m_ResAsyncLoader.LoadResourceCompleteEventHandler -= this._OnAssetLoadAgentLoadAssetComplete;
					this.m_ResAsyncLoader.LoadResourceFailedEventHandler -= this._OnAssetLoadAgentLoadAssetFailed;
					this.m_ResAsyncLoader.LoadPackageCompleteEventHandler -= this._OnAssetLoadAgentLoadPackageComplete;
					this.m_AssetLoader.RecycleAsyncLoader(this.m_ResAsyncLoader);
					this.m_ResAsyncLoader = null;
				}

				// Token: 0x0601A004 RID: 106500 RVA: 0x0081C825 File Offset: 0x0081AC25
				public void Start(AssetManager.AssetLoader.LoadTaskBase task)
				{
					if (task == null)
					{
						TMDebug.AssertFailed("Task is null!");
					}
					this.m_CurrentTask = task;
					this.m_State = AssetManager.AssetLoader.LoadState.None;
					this.m_CurrentTask.OnStart(this);
				}

				// Token: 0x0601A005 RID: 106501 RVA: 0x0081C851 File Offset: 0x0081AC51
				public void SetAgentState(AssetManager.AssetLoader.LoadState state)
				{
					this.m_State = state;
				}

				// Token: 0x0601A006 RID: 106502 RVA: 0x0081C85A File Offset: 0x0081AC5A
				public void LoadAssetAsync(AssetManager.AssetPackage package, string assetName, string subResName, Type assetType)
				{
					if (package != null)
					{
						package.AddRequestCount();
						this.m_ResAsyncLoader.LoadAsset(package.Object, assetName, subResName, assetType);
					}
					else
					{
						this.m_ResAsyncLoader.LoadAsset(null, assetName, subResName, assetType);
					}
				}

				// Token: 0x0601A007 RID: 106503 RVA: 0x0081C892 File Offset: 0x0081AC92
				public void LoadPackageAsync(string packageFullPath)
				{
					this.m_ResAsyncLoader.LoadPackage(packageFullPath);
				}

				// Token: 0x0601A008 RID: 106504 RVA: 0x0081C8A0 File Offset: 0x0081ACA0
				public void Reset()
				{
					this.m_ResAsyncLoader.Reset();
					this.m_CurrentTask = null;
					this.m_State = AssetManager.AssetLoader.LoadState.None;
				}

				// Token: 0x0601A009 RID: 106505 RVA: 0x0081C8BC File Offset: 0x0081ACBC
				public void Update(float logicDeltaTime, float realDeltaTime)
				{
					this.m_ResAsyncLoader.Update();
					switch (this.m_State)
					{
					case AssetManager.AssetLoader.LoadState.None:
						return;
					case AssetManager.AssetLoader.LoadState.WaitForDependency:
						this.m_CurrentTask.OnWaitDependency(this);
						return;
					case AssetManager.AssetLoader.LoadState.WaitForTarget:
						this.m_CurrentTask.OnWaitTarget(this);
						return;
					default:
						TMDebug.AssertFailed(string.Format("Invalid state code:{0}", this.m_State));
						return;
					}
				}

				// Token: 0x0601A00A RID: 106506 RVA: 0x0081C927 File Offset: 0x0081AD27
				private void _OnAssetLoadAgentUpdate(object sender, LoadResourceUpdateEventArgs args)
				{
					this.m_CurrentTask.OnLoadUpdate(this, args.Progress);
				}

				// Token: 0x0601A00B RID: 106507 RVA: 0x0081C93C File Offset: 0x0081AD3C
				private void _OnAssetLoadAgentLoadAssetComplete(object sender, LoadResourceCompleteEventArgs args)
				{
					AssetManager.AssetPackage mainPackage = this.m_CurrentTask.GetMainPackage();
					if (mainPackage != null)
					{
						mainPackage.ReleaseRequestCount();
					}
					AssetManager.Asset asset = new AssetManager.Asset(this.m_CurrentTask.AssetName, args.Asset as ITMAssetObject, mainPackage, this.m_AssetPackagePool);
					this.m_AssetPool.Register(asset, true);
					this.m_CurrentTask.OnTargetLoadReady(this, asset);
				}

				// Token: 0x0601A00C RID: 106508 RVA: 0x0081C99E File Offset: 0x0081AD9E
				private void _OnAssetLoadAgentLoadAssetFailed(object sender, LoadResourceFailedEventArgs args)
				{
					this.m_CurrentTask.OnLoadFailure(this, args.ErrorCode, args.Message);
				}

				// Token: 0x0601A00D RID: 106509 RVA: 0x0081C9B8 File Offset: 0x0081ADB8
				private void _OnAssetLoadAgentLoadPackageComplete(object sender, LoadPackageCompleteEventArgs args)
				{
					string name = this.m_CurrentTask.AssetPackageDesc.PackageName.Name;
					AssetManager.AssetPackage assetPackage = new AssetManager.AssetPackage(name, args.Package, this.m_ResAsyncLoader, this.m_CurrentTask.GetDependencyPackages(), this.m_AssetPackagePool);
					this.m_AssetPackagePool.Register(assetPackage, true);
					this.m_CurrentTask.OnTargetLoadReady(this, assetPackage);
				}

				// Token: 0x04012542 RID: 75074
				private readonly AssetManager.AssetLoader m_AssetLoader;

				// Token: 0x04012543 RID: 75075
				private readonly ITMReferencePool<AssetManager.Asset> m_AssetPool;

				// Token: 0x04012544 RID: 75076
				private readonly ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

				// Token: 0x04012545 RID: 75077
				private TMResAsyncLoader m_ResAsyncLoader;

				// Token: 0x04012546 RID: 75078
				private AssetManager.AssetLoader.LoadTaskBase m_CurrentTask;

				// Token: 0x04012547 RID: 75079
				private AssetManager.AssetLoader.LoadState m_State;
			}

			// Token: 0x020046DB RID: 18139
			internal enum LoadTaskState
			{
				// Token: 0x04012549 RID: 75081
				None,
				// Token: 0x0401254A RID: 75082
				Ready,
				// Token: 0x0401254B RID: 75083
				Loading,
				// Token: 0x0401254C RID: 75084
				Done
			}

			// Token: 0x020046DC RID: 18140
			private class LoadTaskBase
			{
				// Token: 0x0601A00E RID: 106510 RVA: 0x0081C0D0 File Offset: 0x0081A4D0
				internal LoadTaskBase(AssetManager.AssetLoader assetLoader, ITMReferencePool<AssetManager.Asset> assetPool, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool, string assetName, AssetPackageDesc assetPackageDesc, int groupID, object userData)
				{
					TMDebug.Assert(!string.IsNullOrEmpty(assetName), "Asset name can not be null or empty string!");
					this.m_AssetLoader = assetLoader;
					this.m_AssetPool = assetPool;
					this.m_AssetPackagePool = assetPackagePool;
					this.m_AssetName = assetName;
					this.m_AssetPackageDesc = assetPackageDesc;
					this.m_TaskID = AssetManager.AssetLoader.LoadTaskBase.ms_TaskIDAllocCount++;
					this.m_TaskGroupID = groupID;
					this.m_UserData = userData;
					this.m_TimeStamp = DateTime.Now.Ticks;
					this.m_StateCode = AssetManager.AssetLoader.LoadTaskState.None;
					this.m_DependencyPackageWaitingList = new LinkedList<string>();
					this.m_IsTaskInLoading = false;
				}

				// Token: 0x0601A00F RID: 106511 RVA: 0x0081C16B File Offset: 0x0081A56B
				public virtual void OnStart(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
				}

				// Token: 0x0601A010 RID: 106512 RVA: 0x0081C16D File Offset: 0x0081A56D
				public virtual void OnWaitDependency(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
				}

				// Token: 0x0601A011 RID: 106513 RVA: 0x0081C16F File Offset: 0x0081A56F
				public virtual void OnDependencyLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
				}

				// Token: 0x0601A012 RID: 106514 RVA: 0x0081C171 File Offset: 0x0081A571
				public virtual void OnWaitTarget(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
				}

				// Token: 0x0601A013 RID: 106515 RVA: 0x0081C173 File Offset: 0x0081A573
				public virtual void OnTargetLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent, object asset)
				{
				}

				// Token: 0x0601A014 RID: 106516 RVA: 0x0081C175 File Offset: 0x0081A575
				public virtual void OnLoadSuccess(AssetManager.AssetLoader.LoadTaskAgent agent, object asset, float duration)
				{
				}

				// Token: 0x0601A015 RID: 106517 RVA: 0x0081C177 File Offset: 0x0081A577
				public virtual void OnLoadFailure(AssetManager.AssetLoader.LoadTaskAgent agent, AssetLoadErrorCode errorCoude, string message)
				{
				}

				// Token: 0x0601A016 RID: 106518 RVA: 0x0081C179 File Offset: 0x0081A579
				public virtual void OnLoadUpdate(AssetManager.AssetLoader.LoadTaskAgent agent, float progress)
				{
				}

				// Token: 0x0601A017 RID: 106519 RVA: 0x0081C17B File Offset: 0x0081A57B
				public virtual void OnLoadDependencyDone(AssetManager.AssetLoader.LoadTaskAgent agent, object dependency)
				{
				}

				// Token: 0x0601A018 RID: 106520 RVA: 0x0081C17D File Offset: 0x0081A57D
				public void AddDependencyCount()
				{
					this.m_TotalDependentCount++;
				}

				// Token: 0x0601A019 RID: 106521 RVA: 0x0081C18D File Offset: 0x0081A58D
				public virtual List<AssetManager.AssetPackage> GetDependencyPackages()
				{
					return null;
				}

				// Token: 0x0601A01A RID: 106522 RVA: 0x0081C190 File Offset: 0x0081A590
				public virtual AssetManager.AssetPackage GetMainPackage()
				{
					return null;
				}

				// Token: 0x0601A01B RID: 106523 RVA: 0x0081C193 File Offset: 0x0081A593
				public virtual bool LoadFromPackage()
				{
					return false;
				}

				// Token: 0x1700218D RID: 8589
				// (get) Token: 0x0601A01C RID: 106524 RVA: 0x0081C196 File Offset: 0x0081A596
				public string AssetName
				{
					get
					{
						return this.m_AssetName;
					}
				}

				// Token: 0x1700218E RID: 8590
				// (get) Token: 0x0601A01D RID: 106525 RVA: 0x0081C19E File Offset: 0x0081A59E
				public int TaskID
				{
					get
					{
						return this.m_TaskID;
					}
				}

				// Token: 0x1700218F RID: 8591
				// (get) Token: 0x0601A01E RID: 106526 RVA: 0x0081C1A6 File Offset: 0x0081A5A6
				public int TaskGroupID
				{
					get
					{
						return this.m_TaskGroupID;
					}
				}

				// Token: 0x17002190 RID: 8592
				// (get) Token: 0x0601A01F RID: 106527 RVA: 0x0081C1AE File Offset: 0x0081A5AE
				public long TimeStamp
				{
					get
					{
						return this.m_TimeStamp;
					}
				}

				// Token: 0x17002191 RID: 8593
				// (get) Token: 0x0601A020 RID: 106528 RVA: 0x0081C1B6 File Offset: 0x0081A5B6
				public object UserData
				{
					get
					{
						return this.m_UserData;
					}
				}

				// Token: 0x17002192 RID: 8594
				// (get) Token: 0x0601A021 RID: 106529 RVA: 0x0081C1BE File Offset: 0x0081A5BE
				public int TotalDependencyCount
				{
					get
					{
						return this.m_TotalDependentCount;
					}
				}

				// Token: 0x17002193 RID: 8595
				// (get) Token: 0x0601A022 RID: 106530 RVA: 0x0081C1C6 File Offset: 0x0081A5C6
				public bool IsDone
				{
					get
					{
						return AssetManager.AssetLoader.LoadTaskState.Done == this.m_StateCode;
					}
				}

				// Token: 0x17002194 RID: 8596
				// (get) Token: 0x0601A023 RID: 106531 RVA: 0x0081C1D1 File Offset: 0x0081A5D1
				public long StartTimeStamp
				{
					get
					{
						return this.m_TimeStamp;
					}
				}

				// Token: 0x17002195 RID: 8597
				// (get) Token: 0x0601A024 RID: 106532 RVA: 0x0081C1D9 File Offset: 0x0081A5D9
				public AssetPackageDesc AssetPackageDesc
				{
					get
					{
						return this.m_AssetPackageDesc;
					}
				}

				// Token: 0x0401254D RID: 75085
				private static int ms_TaskIDAllocCount;

				// Token: 0x0401254E RID: 75086
				protected readonly AssetManager.AssetLoader m_AssetLoader;

				// Token: 0x0401254F RID: 75087
				protected readonly ITMReferencePool<AssetManager.Asset> m_AssetPool;

				// Token: 0x04012550 RID: 75088
				protected readonly ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

				// Token: 0x04012551 RID: 75089
				protected readonly int m_TaskID;

				// Token: 0x04012552 RID: 75090
				protected readonly int m_TaskGroupID;

				// Token: 0x04012553 RID: 75091
				protected readonly LinkedList<string> m_DependencyPackageWaitingList;

				// Token: 0x04012554 RID: 75092
				protected readonly string m_AssetName;

				// Token: 0x04012555 RID: 75093
				protected readonly AssetPackageDesc m_AssetPackageDesc;

				// Token: 0x04012556 RID: 75094
				protected readonly long m_TimeStamp;

				// Token: 0x04012557 RID: 75095
				protected readonly object m_UserData;

				// Token: 0x04012558 RID: 75096
				protected AssetManager.AssetLoader.LoadTaskState m_StateCode;

				// Token: 0x04012559 RID: 75097
				protected int m_TotalDependentCount;

				// Token: 0x0401255A RID: 75098
				protected bool m_IsTaskInLoading;
			}

			// Token: 0x020046DD RID: 18141
			private sealed class PackageTask : AssetManager.AssetLoader.LoadTaskBase
			{
				// Token: 0x0601A026 RID: 106534 RVA: 0x0081CA20 File Offset: 0x0081AE20
				public PackageTask(AssetManager.AssetLoader assetLoader, ITMReferencePool<AssetManager.Asset> assetPool, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool, string packageName, AssetManager.AssetLoader.LoadTaskBase mainTask, AssetPackageDesc packageDesc, object userData, bool asDependecy) : base(assetLoader, assetPool, assetPackagePool, packageName, packageDesc, mainTask.TaskGroupID, userData)
				{
					TMDebug.Assert(null != mainTask, "Main task can not be null!");
					this.m_MainTask = mainTask;
					this.m_MainTask.AddDependencyCount();
					this.m_AsDependency = asDependecy;
					this.m_DependecyPackages = ((!asDependecy) ? new List<AssetManager.AssetPackage>() : null);
					this.m_TargetPackage = null;
				}

				// Token: 0x0601A027 RID: 106535 RVA: 0x0081CA90 File Offset: 0x0081AE90
				public sealed override void OnStart(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					if (this.m_AssetLoader._IsPackageInLoading(base.AssetName))
					{
						agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForTarget);
						return;
					}
					this.m_TargetPackage = this.m_AssetPackagePool.Spawn(base.AssetName);
					if (this.m_TargetPackage != null)
					{
						if (this.m_AsDependency || !this.m_TargetPackage.AsDependency)
						{
							this.OnTargetLoadReady(agent, this.m_TargetPackage);
						}
					}
					else
					{
						this.m_IsTaskInLoading = true;
						this.m_AssetLoader._RegisterLoadingPackage(base.AssetName);
					}
					if (this.m_TotalDependentCount > 0)
					{
						int[] dependencyPackageIDs = this.m_AssetPackageDesc.DependencyPackageIDs;
						int i = 0;
						int num = dependencyPackageIDs.Length;
						while (i < num)
						{
							string text = this.m_AssetLoader._GetAssetPackageNameByPackageID(dependencyPackageIDs[i]);
							if (!(text == this.m_AssetPackageDesc.PackageName.Name))
							{
								if (!this.m_AssetPackagePool.CanSpawn(text))
								{
									if (!this.m_AssetLoader._IsPackageInLoading(text))
									{
										this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, string.Format("Can not find dependency package with name '{0}' in loading!", text));
										return;
									}
									this.m_DependencyPackageWaitingList.AddLast(text);
								}
							}
							i++;
						}
						if (this.m_DependencyPackageWaitingList.Count > 0)
						{
							agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForDependency);
							return;
						}
					}
					this.OnDependencyLoadReady(agent);
				}

				// Token: 0x0601A028 RID: 106536 RVA: 0x0081CBF4 File Offset: 0x0081AFF4
				public sealed override void OnWaitDependency(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					LinkedListNode<string> linkedListNode = this.m_DependencyPackageWaitingList.First;
					while (linkedListNode != null)
					{
						if (!this.m_AssetLoader._IsPackageInLoading(linkedListNode.Value))
						{
							LinkedListNode<string> next = linkedListNode.Next;
							if (!this.m_AssetPackagePool.CanSpawn(linkedListNode.Value))
							{
								this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, string.Format("Can not find dependency package with name '{0}' in loading!", linkedListNode.Value));
								return;
							}
							this.m_DependencyPackageWaitingList.Remove(linkedListNode);
							linkedListNode = next;
						}
						else
						{
							linkedListNode = linkedListNode.Next;
						}
					}
					if (this.m_DependencyPackageWaitingList.Count > 0)
					{
						return;
					}
					this.OnDependencyLoadReady(agent);
				}

				// Token: 0x0601A029 RID: 106537 RVA: 0x0081CC98 File Offset: 0x0081B098
				public sealed override void OnDependencyLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					if (this.m_DependecyPackages != null)
					{
						int i = 0;
						int count = this.m_DependecyPackages.Count;
						while (i < count)
						{
							this.m_DependecyPackages[i].ReleaseRequestCount();
							i++;
						}
					}
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.WaitForTarget);
					if (this.m_TargetPackage == null)
					{
						string text = Utility.Path.Combine(this.m_AssetLoader.ReadWritePath, Utility.Path.Combine(this.m_AssetLoader.PackageRootFolder, this.m_AssetPackageDesc.PackageName.FullName));
						if (!AssetManager._IsAssetExistWithPath(text))
						{
							text = Utility.Path.Combine(this.m_AssetLoader.ReadOnlyPath, Utility.Path.Combine(this.m_AssetLoader.PackageRootFolder, this.m_AssetPackageDesc.PackageName.FullName));
						}
						agent.LoadPackageAsync(text);
					}
					else
					{
						this.OnTargetLoadReady(agent, this.m_TargetPackage);
					}
				}

				// Token: 0x0601A02A RID: 106538 RVA: 0x0081CD88 File Offset: 0x0081B188
				public sealed override void OnWaitTarget(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					string name = this.m_AssetPackageDesc.PackageName.Name;
					if (this.m_AssetLoader._IsPackageInLoading(name))
					{
						return;
					}
					this.m_TargetPackage = this.m_AssetPackagePool.Spawn(name);
					if (this.m_TargetPackage == null)
					{
						this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, string.Format("Can not find package named '{0}'!", name));
						return;
					}
					this.OnTargetLoadReady(agent, this.m_TargetPackage);
				}

				// Token: 0x0601A02B RID: 106539 RVA: 0x0081CDFC File Offset: 0x0081B1FC
				public sealed override void OnTargetLoadReady(AssetManager.AssetLoader.LoadTaskAgent agent, object asset)
				{
					agent.SetAgentState(AssetManager.AssetLoader.LoadState.None);
					this.OnLoadSuccess(agent, asset, Utility.Time.TicksToSeconds(Utility.Time.GetTicksNow() - base.StartTimeStamp));
				}

				// Token: 0x0601A02C RID: 106540 RVA: 0x0081CE20 File Offset: 0x0081B220
				public sealed override void OnLoadSuccess(AssetManager.AssetLoader.LoadTaskAgent agent, object asset, float duration)
				{
					if (this.m_IsTaskInLoading)
					{
						this.m_IsTaskInLoading = false;
						this.m_AssetLoader._UnregisterLoadingPackage(base.AssetName);
					}
					this.m_TargetPackage = (asset as AssetManager.AssetPackage);
					base.OnLoadSuccess(agent, asset, duration);
					this.m_MainTask.OnLoadDependencyDone(agent, asset);
					this.m_StateCode = AssetManager.AssetLoader.LoadTaskState.Done;
				}

				// Token: 0x0601A02D RID: 106541 RVA: 0x0081CE7C File Offset: 0x0081B27C
				public sealed override void OnLoadFailure(AssetManager.AssetLoader.LoadTaskAgent agent, AssetLoadErrorCode errorCode, string message)
				{
					base.OnLoadFailure(agent, errorCode, message);
					if (this.m_IsTaskInLoading)
					{
						this.m_IsTaskInLoading = false;
						this.m_AssetLoader._UnregisterLoadingPackage(base.AssetName);
					}
					this.m_StateCode = AssetManager.AssetLoader.LoadTaskState.Done;
					string message2 = string.Format("Load dependency '{0}' failed! \nInternal error code:[{0}] message:'{2}'!\n", this.m_AssetName, errorCode, message);
					this.m_MainTask.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, message2);
				}

				// Token: 0x0601A02E RID: 106542 RVA: 0x0081CEE4 File Offset: 0x0081B2E4
				public sealed override void OnLoadDependencyDone(AssetManager.AssetLoader.LoadTaskAgent agent, object dependency)
				{
					base.OnLoadDependencyDone(agent, dependency);
					AssetManager.AssetPackage assetPackage = dependency as AssetManager.AssetPackage;
					if (assetPackage != null)
					{
						assetPackage.AddRequestCount();
						this.m_DependecyPackages.Add(assetPackage);
					}
					else
					{
						string message = string.Format("Dependency package '{0}' type cast error source object type '{1}' needed type:{2}", base.AssetName, dependency.GetType().Name, typeof(AssetManager.AssetPackage).Name);
						this.OnLoadFailure(agent, AssetLoadErrorCode.DependencyLoadError, message);
					}
				}

				// Token: 0x0601A02F RID: 106543 RVA: 0x0081CF51 File Offset: 0x0081B351
				public sealed override List<AssetManager.AssetPackage> GetDependencyPackages()
				{
					return this.m_DependecyPackages;
				}

				// Token: 0x0601A030 RID: 106544 RVA: 0x0081CF59 File Offset: 0x0081B359
				public sealed override AssetManager.AssetPackage GetMainPackage()
				{
					return this.m_TargetPackage;
				}

				// Token: 0x0401255B RID: 75099
				private readonly AssetManager.AssetLoader.LoadTaskBase m_MainTask;

				// Token: 0x0401255C RID: 75100
				private readonly List<AssetManager.AssetPackage> m_DependecyPackages;

				// Token: 0x0401255D RID: 75101
				private readonly bool m_AsDependency;

				// Token: 0x0401255E RID: 75102
				private AssetManager.AssetPackage m_TargetPackage;
			}

			// Token: 0x020046DE RID: 18142
			private class TaskPool<T> where T : AssetManager.AssetLoader.LoadTaskBase
			{
				// Token: 0x0601A031 RID: 106545 RVA: 0x0081CF61 File Offset: 0x0081B361
				public TaskPool()
				{
					this.m_FreeAgents = new Stack<AssetManager.AssetLoader.LoadTaskAgent>();
					this.m_WorkingAgents = new LinkedList<AssetManager.AssetLoader.LoadTaskAgent>();
					this.m_HighPriorityWaitingTasks = new LinkedList<T>();
					this.m_WaitingTasks = new LinkedList<T>();
				}

				// Token: 0x17002196 RID: 8598
				// (get) Token: 0x0601A032 RID: 106546 RVA: 0x0081CF95 File Offset: 0x0081B395
				public int TotalAgentCount
				{
					get
					{
						return this.FreeAgentCount + this.WorkingAgentCount;
					}
				}

				// Token: 0x17002197 RID: 8599
				// (get) Token: 0x0601A033 RID: 106547 RVA: 0x0081CFA4 File Offset: 0x0081B3A4
				public int FreeAgentCount
				{
					get
					{
						return this.m_FreeAgents.Count;
					}
				}

				// Token: 0x17002198 RID: 8600
				// (get) Token: 0x0601A034 RID: 106548 RVA: 0x0081CFB1 File Offset: 0x0081B3B1
				public int WorkingAgentCount
				{
					get
					{
						return this.m_WorkingAgents.Count;
					}
				}

				// Token: 0x17002199 RID: 8601
				// (get) Token: 0x0601A035 RID: 106549 RVA: 0x0081CFBE File Offset: 0x0081B3BE
				public int WaitingTaskCount
				{
					get
					{
						return this.m_WaitingTasks.Count + this.m_HighPriorityWaitingTasks.Count;
					}
				}

				// Token: 0x0601A036 RID: 106550 RVA: 0x0081CFD8 File Offset: 0x0081B3D8
				public void Update(float elapseSeconds, float realElapseSeconds)
				{
					LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> linkedListNode = this.m_WorkingAgents.First;
					while (linkedListNode != null)
					{
						if (linkedListNode.Value.Task.IsDone)
						{
							LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> next = linkedListNode.Next;
							linkedListNode.Value.Reset();
							this.m_FreeAgents.Push(linkedListNode.Value);
							this.m_WorkingAgents.Remove(linkedListNode);
							linkedListNode = next;
						}
						else
						{
							linkedListNode.Value.Update(elapseSeconds, realElapseSeconds);
							linkedListNode = linkedListNode.Next;
						}
					}
					int num = this.TotalAgentCount * (this.WaitingTaskCount / 1000 + 1);
					while (this.FreeAgentCount > 0 && this.WaitingTaskCount > 0 && num > 0)
					{
						AssetManager.AssetLoader.LoadTaskAgent loadTaskAgent = this.m_FreeAgents.Pop();
						LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> node = this.m_WorkingAgents.AddLast(loadTaskAgent);
						if (this.m_HighPriorityWaitingTasks.Count > 0)
						{
							T value = this.m_HighPriorityWaitingTasks.First.Value;
							this.m_HighPriorityWaitingTasks.RemoveFirst();
							loadTaskAgent.Start(value);
							if (value.IsDone)
							{
								num--;
								loadTaskAgent.Reset();
								this.m_FreeAgents.Push(loadTaskAgent);
								this.m_WorkingAgents.Remove(node);
							}
						}
						else
						{
							T value2 = this.m_WaitingTasks.First.Value;
							this.m_WaitingTasks.RemoveFirst();
							loadTaskAgent.Start(value2);
							if (value2.IsDone)
							{
								num--;
								loadTaskAgent.Reset();
								this.m_FreeAgents.Push(loadTaskAgent);
								this.m_WorkingAgents.Remove(node);
							}
						}
					}
				}

				// Token: 0x0601A037 RID: 106551 RVA: 0x0081D184 File Offset: 0x0081B584
				public void Shutdown()
				{
					while (this.FreeAgentCount > 0)
					{
						this.m_FreeAgents.Pop().Shutdown();
					}
					for (LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> linkedListNode = this.m_WorkingAgents.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
					{
						AssetManager.AssetLoader.LoadTaskAgent value = linkedListNode.Value;
						value.Shutdown();
					}
					this.m_WorkingAgents.Clear();
					this.m_WaitingTasks.Clear();
					this.m_HighPriorityWaitingTasks.Clear();
				}

				// Token: 0x0601A038 RID: 106552 RVA: 0x0081D1FE File Offset: 0x0081B5FE
				public void AddAgent(AssetManager.AssetLoader.LoadTaskAgent agent)
				{
					if (agent == null)
					{
						throw new TMEngineException("Task agent is invalid.");
					}
					agent.Initialize();
					this.m_FreeAgents.Push(agent);
				}

				// Token: 0x0601A039 RID: 106553 RVA: 0x0081D223 File Offset: 0x0081B623
				public void ClearFreeAgent()
				{
					while (this.FreeAgentCount > 0)
					{
						this.m_FreeAgents.Pop().Shutdown();
					}
				}

				// Token: 0x0601A03A RID: 106554 RVA: 0x0081D248 File Offset: 0x0081B648
				public void AddTask(T task, int priorityLevel)
				{
					bool flag = priorityLevel > 0;
					if (flag)
					{
						this.m_HighPriorityWaitingTasks.AddLast(task);
					}
					else
					{
						this.m_WaitingTasks.AddLast(task);
					}
				}

				// Token: 0x0601A03B RID: 106555 RVA: 0x0081D280 File Offset: 0x0081B680
				public AssetManager.AssetLoader.LoadTaskBase RemoveTask(int taskID)
				{
					for (LinkedListNode<T> linkedListNode = this.m_WaitingTasks.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
					{
						T value = linkedListNode.Value;
						if (value.TaskID == taskID)
						{
							this.m_WaitingTasks.Remove(linkedListNode);
							return value;
						}
					}
					for (LinkedListNode<T> linkedListNode2 = this.m_HighPriorityWaitingTasks.First; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Next)
					{
						T value2 = linkedListNode2.Value;
						if (value2.TaskID == taskID)
						{
							this.m_WaitingTasks.Remove(linkedListNode2);
							return value2;
						}
					}
					for (LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> linkedListNode3 = this.m_WorkingAgents.First; linkedListNode3 != null; linkedListNode3 = linkedListNode3.Next)
					{
						AssetManager.AssetLoader.LoadTaskAgent value3 = linkedListNode3.Value;
						if (value3.Task.TaskID == taskID)
						{
							value3.Reset();
							this.m_FreeAgents.Push(value3);
							this.m_WorkingAgents.Remove(value3);
							return value3.Task;
						}
					}
					return null;
				}

				// Token: 0x0601A03C RID: 106556 RVA: 0x0081D38C File Offset: 0x0081B78C
				public bool RemoveTaskGroup(int groupId)
				{
					bool result = false;
					LinkedListNode<T> next;
					for (LinkedListNode<T> linkedListNode = this.m_WaitingTasks.First; linkedListNode != null; linkedListNode = next)
					{
						next = linkedListNode.Next;
						T value = linkedListNode.Value;
						if (value.TaskGroupID == groupId)
						{
							result = true;
							this.m_WaitingTasks.Remove(linkedListNode);
						}
					}
					for (LinkedListNode<T> linkedListNode = this.m_HighPriorityWaitingTasks.First; linkedListNode != null; linkedListNode = next)
					{
						next = linkedListNode.Next;
						T value2 = linkedListNode.Value;
						if (value2.TaskGroupID == groupId)
						{
							result = true;
							this.m_HighPriorityWaitingTasks.Remove(linkedListNode);
						}
					}
					for (LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> linkedListNode2 = this.m_WorkingAgents.First; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Next)
					{
						AssetManager.AssetLoader.LoadTaskAgent value3 = linkedListNode2.Value;
						if (value3.Task.TaskGroupID == groupId)
						{
						}
					}
					return result;
				}

				// Token: 0x0601A03D RID: 106557 RVA: 0x0081D46C File Offset: 0x0081B86C
				public void RemoveAllTasks()
				{
					this.m_WaitingTasks.Clear();
					this.m_HighPriorityWaitingTasks.Clear();
					for (LinkedListNode<AssetManager.AssetLoader.LoadTaskAgent> linkedListNode = this.m_WorkingAgents.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
					{
						AssetManager.AssetLoader.LoadTaskAgent value = linkedListNode.Value;
						value.Reset();
						this.m_FreeAgents.Push(value);
					}
					this.m_WorkingAgents.Clear();
				}

				// Token: 0x0601A03E RID: 106558 RVA: 0x0081D4D1 File Offset: 0x0081B8D1
				public void BeginCleanRuningTask()
				{
				}

				// Token: 0x0601A03F RID: 106559 RVA: 0x0081D4D3 File Offset: 0x0081B8D3
				public bool EndCleanRuningTask()
				{
					return true;
				}

				// Token: 0x0401255F RID: 75103
				private readonly Stack<AssetManager.AssetLoader.LoadTaskAgent> m_FreeAgents;

				// Token: 0x04012560 RID: 75104
				private readonly LinkedList<AssetManager.AssetLoader.LoadTaskAgent> m_WorkingAgents;

				// Token: 0x04012561 RID: 75105
				private readonly LinkedList<T> m_WaitingTasks;

				// Token: 0x04012562 RID: 75106
				private readonly LinkedList<T> m_HighPriorityWaitingTasks;
			}
		}

		// Token: 0x020046DF RID: 18143
		private class AssetPackage : Referable
		{
			// Token: 0x0601A040 RID: 106560 RVA: 0x0081D4D8 File Offset: 0x0081B8D8
			public AssetPackage(string name, object packageObject, ITMResourceLoader resourceLoader, List<AssetManager.AssetPackage> dependencyPackages, ITMReferencePool<AssetManager.AssetPackage> assetPackagePool)
			{
				TMDebug.Assert(!string.IsNullOrEmpty(name), "Package name can not be null or empty string!");
				TMDebug.Assert(null != resourceLoader, "Resource loader can not be null!");
				TMDebug.Assert(null != packageObject, "Package object can not be null!");
				TMDebug.Assert(null != assetPackagePool, "Asset package pool object can not be null!");
				this.m_PackageName = name;
				this.m_PackageNameHashCode = name.GetHashCode();
				this.m_PackageObject = packageObject;
				this.m_ResourceLoader = resourceLoader;
				this.m_AssetPackagePool = assetPackagePool;
				this.m_DependencyCount = 0;
				this.m_AsyncRequestCount = 0;
				this.m_AssetCount = 0;
				this.m_Hold = true;
				this.AddDependency(dependencyPackages);
			}

			// Token: 0x1700219A RID: 8602
			// (get) Token: 0x0601A041 RID: 106561 RVA: 0x0081D57F File Offset: 0x0081B97F
			public override string Name
			{
				get
				{
					return this.m_PackageName;
				}
			}

			// Token: 0x1700219B RID: 8603
			// (get) Token: 0x0601A042 RID: 106562 RVA: 0x0081D587 File Offset: 0x0081B987
			public override int NameHashCode
			{
				get
				{
					return this.m_PackageNameHashCode;
				}
			}

			// Token: 0x1700219C RID: 8604
			// (get) Token: 0x0601A043 RID: 106563 RVA: 0x0081D58F File Offset: 0x0081B98F
			public override bool IsInUse
			{
				get
				{
					return this.SpawnCount > 0 || this.m_Hold;
				}
			}

			// Token: 0x1700219D RID: 8605
			// (get) Token: 0x0601A044 RID: 106564 RVA: 0x0081D5A6 File Offset: 0x0081B9A6
			public override bool IsLocked
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700219E RID: 8606
			// (get) Token: 0x0601A045 RID: 106565 RVA: 0x0081D5A9 File Offset: 0x0081B9A9
			// (set) Token: 0x0601A046 RID: 106566 RVA: 0x0081D5AC File Offset: 0x0081B9AC
			public override int LockFlag
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			// Token: 0x1700219F RID: 8607
			// (get) Token: 0x0601A047 RID: 106567 RVA: 0x0081D5AE File Offset: 0x0081B9AE
			public override long LastUseTime
			{
				get
				{
					return this.m_TimeStamp;
				}
			}

			// Token: 0x170021A0 RID: 8608
			// (get) Token: 0x0601A048 RID: 106568 RVA: 0x0081D5B6 File Offset: 0x0081B9B6
			public override int SpawnCount
			{
				get
				{
					return this.m_AssetCount + this.m_DependencyCount + this.m_AsyncRequestCount;
				}
			}

			// Token: 0x170021A1 RID: 8609
			// (get) Token: 0x0601A049 RID: 106569 RVA: 0x0081D5CC File Offset: 0x0081B9CC
			public object Object
			{
				get
				{
					return this.m_PackageObject;
				}
			}

			// Token: 0x170021A2 RID: 8610
			// (get) Token: 0x0601A04A RID: 106570 RVA: 0x0081D5D4 File Offset: 0x0081B9D4
			public bool AsDependency
			{
				get
				{
					return null == this.m_DependecyPackages;
				}
			}

			// Token: 0x0601A04B RID: 106571 RVA: 0x0081D5E0 File Offset: 0x0081B9E0
			public void AddDependency(List<AssetManager.AssetPackage> dependencyPackages)
			{
				if (this.m_DependecyPackages == null)
				{
					this.m_DependecyPackages = dependencyPackages;
					if (this.m_DependecyPackages != null)
					{
						int i = 0;
						int count = this.m_DependecyPackages.Count;
						while (i < count)
						{
							this.m_DependecyPackages[i]._AddDependencyCount();
							i++;
						}
					}
				}
			}

			// Token: 0x0601A04C RID: 106572 RVA: 0x0081D639 File Offset: 0x0081BA39
			public void SpawmAsset()
			{
				this.m_Hold = false;
				this.m_AssetCount++;
			}

			// Token: 0x0601A04D RID: 106573 RVA: 0x0081D650 File Offset: 0x0081BA50
			public void UnspawnAsset()
			{
				this.m_AssetCount--;
				TMDebug.Assert(this.m_AssetCount >= 0, "Asset count can not less than zero!");
			}

			// Token: 0x0601A04E RID: 106574 RVA: 0x0081D676 File Offset: 0x0081BA76
			public void AddRequestCount()
			{
				this.m_Hold = false;
				this.m_AsyncRequestCount++;
			}

			// Token: 0x0601A04F RID: 106575 RVA: 0x0081D68D File Offset: 0x0081BA8D
			public void ReleaseRequestCount()
			{
				this.m_AsyncRequestCount--;
				TMDebug.Assert(this.m_AsyncRequestCount >= 0, "Request count can not less than zero!");
			}

			// Token: 0x0601A050 RID: 106576 RVA: 0x0081D6B3 File Offset: 0x0081BAB3
			public sealed override void OnSpawn()
			{
				this.m_Hold = true;
				this.m_TimeStamp = Utility.Time.GetTicksNow();
			}

			// Token: 0x0601A051 RID: 106577 RVA: 0x0081D6C7 File Offset: 0x0081BAC7
			public sealed override void OnUnspawn()
			{
			}

			// Token: 0x0601A052 RID: 106578 RVA: 0x0081D6CC File Offset: 0x0081BACC
			public sealed override void OnRelease()
			{
				if (this.m_DependecyPackages != null)
				{
					int i = 0;
					int count = this.m_DependecyPackages.Count;
					while (i < count)
					{
						AssetManager.AssetPackage assetPackage = this.m_DependecyPackages[i];
						assetPackage._ReleaseDependencyCount();
						i++;
					}
				}
				this.m_ResourceLoader.UnloadPackage(this.m_PackageObject);
			}

			// Token: 0x0601A053 RID: 106579 RVA: 0x0081D726 File Offset: 0x0081BB26
			private void _AddDependencyCount()
			{
				this.m_Hold = false;
				this.m_DependencyCount++;
			}

			// Token: 0x0601A054 RID: 106580 RVA: 0x0081D73D File Offset: 0x0081BB3D
			private void _ReleaseDependencyCount()
			{
				this.m_DependencyCount--;
				TMDebug.Assert(this.m_DependencyCount >= 0, "Dependent count can not less than zero!");
			}

			// Token: 0x04012563 RID: 75107
			private readonly string m_PackageName;

			// Token: 0x04012564 RID: 75108
			private readonly int m_PackageNameHashCode;

			// Token: 0x04012565 RID: 75109
			private readonly ITMResourceLoader m_ResourceLoader;

			// Token: 0x04012566 RID: 75110
			private readonly object m_PackageObject;

			// Token: 0x04012567 RID: 75111
			private readonly ITMReferencePool<AssetManager.AssetPackage> m_AssetPackagePool;

			// Token: 0x04012568 RID: 75112
			private List<AssetManager.AssetPackage> m_DependecyPackages;

			// Token: 0x04012569 RID: 75113
			private int m_DependencyCount;

			// Token: 0x0401256A RID: 75114
			private int m_AsyncRequestCount;

			// Token: 0x0401256B RID: 75115
			private int m_AssetCount;

			// Token: 0x0401256C RID: 75116
			private bool m_Hold;

			// Token: 0x0401256D RID: 75117
			private long m_TimeStamp;
		}

		// Token: 0x020046E0 RID: 18144
		// (Invoke) Token: 0x0601A056 RID: 106582
		internal delegate void OnAssetTreeBuildComplete();

		// Token: 0x020046E1 RID: 18145
		internal class AssetTree
		{
			// Token: 0x0601A059 RID: 106585 RVA: 0x0081D763 File Offset: 0x0081BB63
			public AssetTree(AssetManager assetManager)
			{
				TMDebug.Assert(null != assetManager, "Asset manager object can not be null!");
				this.m_AssetManager = assetManager;
				this.m_OnAssetTreeBuildComplete = new AssetManager.OnAssetTreeBuildComplete(this.m_AssetManager._OnAssetTreeBuildComplete);
			}

			// Token: 0x0601A05A RID: 106586 RVA: 0x0081D79C File Offset: 0x0081BB9C
			public void BuildAssetTree(DAssetPackageDependency assetTree)
			{
				if (null == assetTree)
				{
					TMDebug.LogErrorFormat("Asset tree data can not be null!", new object[0]);
					return;
				}
				this._ClearAssetTree();
				long ticksNow = Utility.Time.GetTicksNow();
				if (assetTree.packageDescArray != null)
				{
					int[] array = new int[0];
					int i = 0;
					int num = assetTree.packageDescArray.Length;
					while (i < num)
					{
						DAssetPackageDesc dassetPackageDesc = assetTree.packageDescArray[i];
						if (dassetPackageDesc == null)
						{
							TMDebug.LogErrorFormat("Asset tree data is crashed!", new object[0]);
							this._ClearAssetTree();
							return;
						}
						int[] array2 = array;
						if (dassetPackageDesc.packageAutoDependIdx != null)
						{
							array2 = new int[dassetPackageDesc.packageAutoDependIdx.Length];
							int j = 0;
							int num2 = dassetPackageDesc.packageAutoDependIdx.Length;
							while (j < num2)
							{
								int num3 = dassetPackageDesc.packageAutoDependIdx[j];
								if (0 > num3 || num3 >= num)
								{
									TMDebug.LogErrorFormat("Asset tree data is crashed!", new object[0]);
									this._ClearAssetTree();
									return;
								}
								array2[j] = num3;
								j++;
							}
						}
						AssetPackageName assetPackageName = new AssetPackageName(dassetPackageDesc.packageName, string.Empty);
						EnumHelper<AssetPackageUsage> flags = new EnumHelper<AssetPackageUsage>(AssetPackageUsage.LoadFromFile);
						if ((dassetPackageDesc.packageFlag & 2U) != 0U)
						{
							flags.AddFlag(AssetPackageUsage.LoadAssetWithGUIDName);
						}
						this.m_AssetManager.m_AssetPackageDescTable.Add(assetPackageName, new AssetPackageDesc(assetPackageName, i, array2, flags, 0, -1, dassetPackageDesc.packageMD5));
						i++;
					}
				}
				if (assetTree.assetDescPackageMap != null)
				{
					int k = 0;
					int count = assetTree.assetDescPackageMap.Count;
					while (k < count)
					{
						DAssetPackageMapDesc dassetPackageMapDesc = assetTree.assetDescPackageMap[k];
						if (0 > dassetPackageMapDesc.packageDescIdx || dassetPackageMapDesc.packageDescIdx >= assetTree.packageDescArray.Length)
						{
							TMDebug.LogErrorFormat("Asset tree data is crashed!", new object[0]);
							this._ClearAssetTree();
							return;
						}
						this.m_AssetManager.m_AssetDescTable.Add(dassetPackageMapDesc.assetPathKey, new AssetDesc(dassetPackageMapDesc.assetPathKey, dassetPackageMapDesc.assetPackageGUID, dassetPackageMapDesc.packageDescIdx));
						k++;
					}
				}
				if (this.m_OnAssetTreeBuildComplete != null)
				{
					this.m_OnAssetTreeBuildComplete();
				}
				TMDebug.LogInfoFormat("Init asset tree {0} (ms)!", new object[]
				{
					Utility.Time.TicksToMicroseconds(Utility.Time.GetTicksNow() - ticksNow)
				});
			}

			// Token: 0x0601A05B RID: 106587 RVA: 0x0081D9EC File Offset: 0x0081BDEC
			public void BuildAssetTree(ITMAssetTreeData assetTree)
			{
				if (assetTree == null)
				{
					TMDebug.LogErrorFormat("Asset tree data can not be null!", new object[0]);
					return;
				}
				List<AssetDesc> assetDescMap = assetTree.GetAssetDescMap();
				List<AssetPackageDesc> assetPackageDescMap = assetTree.GetAssetPackageDescMap();
				List<LinearMap<string, AssetDesc>.KeyValuePair<string, AssetDesc>> list = new List<LinearMap<string, AssetDesc>.KeyValuePair<string, AssetDesc>>();
				int i = 0;
				int count = assetDescMap.Count;
				while (i < count)
				{
					AssetDesc value = assetDescMap[i];
					list.Add(new LinearMap<string, AssetDesc>.KeyValuePair<string, AssetDesc>(value.AssetName, value));
					i++;
				}
				List<LinearMap<AssetPackageName, AssetPackageDesc>.KeyValuePair<AssetPackageName, AssetPackageDesc>> list2 = new List<LinearMap<AssetPackageName, AssetPackageDesc>.KeyValuePair<AssetPackageName, AssetPackageDesc>>();
				int j = 0;
				int count2 = assetPackageDescMap.Count;
				while (j < count2)
				{
					AssetPackageDesc value2 = assetPackageDescMap[j];
					list2.Add(new LinearMap<AssetPackageName, AssetPackageDesc>.KeyValuePair<AssetPackageName, AssetPackageDesc>(value2.PackageName, value2));
					j++;
				}
				this.m_AssetManager.m_AssetDescTable.Fill(list, false);
				this.m_AssetManager.m_AssetPackageDescTable.Fill(list2, false);
				if (this.m_OnAssetTreeBuildComplete != null)
				{
					this.m_OnAssetTreeBuildComplete();
				}
			}

			// Token: 0x0601A05C RID: 106588 RVA: 0x0081DADC File Offset: 0x0081BEDC
			private void _ClearAssetTree()
			{
				this.m_AssetManager.m_AssetDescTableIsReady = false;
				this.m_AssetManager.m_AssetDescTable.Clear();
				this.m_AssetManager.m_AssetPackageDescTableIsReady = false;
				this.m_AssetManager.m_AssetPackageDescTable.Clear();
			}

			// Token: 0x0401256E RID: 75118
			private readonly AssetManager m_AssetManager;

			// Token: 0x0401256F RID: 75119
			private readonly AssetManager.OnAssetTreeBuildComplete m_OnAssetTreeBuildComplete;
		}
	}
}
