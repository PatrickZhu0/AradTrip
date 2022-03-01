using System;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004728 RID: 18216
	[DisallowMultipleComponent]
	[AddComponentMenu("TMEngine/AssetModule")]
	public class TMAssetModuleComponent : TMModuleComponent
	{
		// Token: 0x17002221 RID: 8737
		// (get) Token: 0x0601A262 RID: 107106 RVA: 0x00820C48 File Offset: 0x0081F048
		public string ReadOnlyPath
		{
			get
			{
				return (this.m_AssetManager == null) ? string.Empty : this.m_AssetManager.ReadOnlyPath;
			}
		}

		// Token: 0x17002222 RID: 8738
		// (get) Token: 0x0601A263 RID: 107107 RVA: 0x00820C6A File Offset: 0x0081F06A
		public string ReadWritePath
		{
			get
			{
				return (this.m_AssetManager == null) ? string.Empty : this.m_AssetManager.ReadWritePath;
			}
		}

		// Token: 0x17002223 RID: 8739
		// (get) Token: 0x0601A264 RID: 107108 RVA: 0x00820C8C File Offset: 0x0081F08C
		public uint AssetMode
		{
			get
			{
				return this.m_AssetMode;
			}
		}

		// Token: 0x17002224 RID: 8740
		// (get) Token: 0x0601A265 RID: 107109 RVA: 0x00820C94 File Offset: 0x0081F094
		public bool UseTempPath
		{
			get
			{
				return this.m_UseTempPath;
			}
		}

		// Token: 0x17002225 RID: 8741
		// (get) Token: 0x0601A266 RID: 107110 RVA: 0x00820C9C File Offset: 0x0081F09C
		public string CurrentVariant
		{
			get
			{
				return (this.m_AssetManager == null) ? string.Empty : this.m_AssetManager.CurrentVariant;
			}
		}

		// Token: 0x17002226 RID: 8742
		// (get) Token: 0x0601A267 RID: 107111 RVA: 0x00820CBE File Offset: 0x0081F0BE
		// (set) Token: 0x0601A268 RID: 107112 RVA: 0x00820CC6 File Offset: 0x0081F0C6
		public float UnloadUnusedAssetsInterval
		{
			get
			{
				return this.m_UnloadUnusedAssetsInterval;
			}
			set
			{
				this.m_UnloadUnusedAssetsInterval = value;
			}
		}

		// Token: 0x17002227 RID: 8743
		// (get) Token: 0x0601A269 RID: 107113 RVA: 0x00820CCF File Offset: 0x0081F0CF
		public string ApplicationVersion
		{
			get
			{
				return (this.m_AssetManager == null) ? string.Empty : this.m_AssetManager.ApplicationVersion;
			}
		}

		// Token: 0x17002228 RID: 8744
		// (get) Token: 0x0601A26A RID: 107114 RVA: 0x00820CF1 File Offset: 0x0081F0F1
		public int InternalResourceVersion
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.InternalResourceVersion;
			}
		}

		// Token: 0x17002229 RID: 8745
		// (get) Token: 0x0601A26B RID: 107115 RVA: 0x00820D0F File Offset: 0x0081F10F
		public int AssetCount
		{
			get
			{
				return (this.m_AssetManager == null) ? 0 : this.m_AssetManager.AssetCount;
			}
		}

		// Token: 0x1700222A RID: 8746
		// (get) Token: 0x0601A26C RID: 107116 RVA: 0x00820D2D File Offset: 0x0081F12D
		public int AssetPackageCount
		{
			get
			{
				return (this.m_AssetManager == null) ? 0 : this.m_AssetManager.AssetPackageCount;
			}
		}

		// Token: 0x1700222B RID: 8747
		// (get) Token: 0x0601A26D RID: 107117 RVA: 0x00820D4B File Offset: 0x0081F14B
		public string RemoteResServerURL
		{
			get
			{
				return (this.m_AssetManager == null) ? string.Empty : this.m_AssetManager.RemoteResServerURI;
			}
		}

		// Token: 0x1700222C RID: 8748
		// (get) Token: 0x0601A26E RID: 107118 RVA: 0x00820D6D File Offset: 0x0081F16D
		public int UpdateWaitingCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.UpdateWaitingCount;
			}
		}

		// Token: 0x1700222D RID: 8749
		// (get) Token: 0x0601A26F RID: 107119 RVA: 0x00820D8B File Offset: 0x0081F18B
		public int UpdatingCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.UpdatingCount;
			}
		}

		// Token: 0x1700222E RID: 8750
		// (get) Token: 0x0601A270 RID: 107120 RVA: 0x00820DA9 File Offset: 0x0081F1A9
		public int LoadAgentTotalCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.LoadAgentTotalCount;
			}
		}

		// Token: 0x1700222F RID: 8751
		// (get) Token: 0x0601A271 RID: 107121 RVA: 0x00820DC7 File Offset: 0x0081F1C7
		public int LoadAgentFreeCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.LoadAgentFreeCount;
			}
		}

		// Token: 0x17002230 RID: 8752
		// (get) Token: 0x0601A272 RID: 107122 RVA: 0x00820DE5 File Offset: 0x0081F1E5
		public int LoadAgentWorkingCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.LoadAgentWorkingCount;
			}
		}

		// Token: 0x17002231 RID: 8753
		// (get) Token: 0x0601A273 RID: 107123 RVA: 0x00820E03 File Offset: 0x0081F203
		public int LoadWaitingTaskCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.LoadTaskWaitingCount;
			}
		}

		// Token: 0x17002232 RID: 8754
		// (get) Token: 0x0601A274 RID: 107124 RVA: 0x00820E21 File Offset: 0x0081F221
		// (set) Token: 0x0601A275 RID: 107125 RVA: 0x00820E43 File Offset: 0x0081F243
		public float AssetPoolAutoPurgeInterval
		{
			get
			{
				return (this.m_AssetManager == null) ? -1f : this.m_AssetManager.AssetPoolAutoPurgeInterval;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetPoolAutoPurgeInterval = value;
					this.m_AssetManager.SetAssetPoolAutoPurgeInterval(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x17002233 RID: 8755
		// (get) Token: 0x0601A276 RID: 107126 RVA: 0x00820E72 File Offset: 0x0081F272
		// (set) Token: 0x0601A277 RID: 107127 RVA: 0x00820E94 File Offset: 0x0081F294
		public float AssetExpireTime
		{
			get
			{
				return (this.m_AssetManager == null) ? -1f : this.m_AssetManager.AssetExpireTime;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetExpireTime = value;
					this.m_AssetManager.SetAssetExpireTime(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x17002234 RID: 8756
		// (get) Token: 0x0601A278 RID: 107128 RVA: 0x00820EC3 File Offset: 0x0081F2C3
		public int AssetLoadedCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetLoadedCount;
			}
		}

		// Token: 0x17002235 RID: 8757
		// (get) Token: 0x0601A279 RID: 107129 RVA: 0x00820EE1 File Offset: 0x0081F2E1
		public int AssetCanReleaseCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetCanReleaseCount;
			}
		}

		// Token: 0x17002236 RID: 8758
		// (get) Token: 0x0601A27A RID: 107130 RVA: 0x00820EFF File Offset: 0x0081F2FF
		// (set) Token: 0x0601A27B RID: 107131 RVA: 0x00820F1D File Offset: 0x0081F31D
		public int AssetPoolPriority
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetPoolPriority;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetPoolPriority = value;
					this.m_AssetManager.SetAssetPoolPriority(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x17002237 RID: 8759
		// (get) Token: 0x0601A27C RID: 107132 RVA: 0x00820F4C File Offset: 0x0081F34C
		// (set) Token: 0x0601A27D RID: 107133 RVA: 0x00820F6E File Offset: 0x0081F36E
		public float AssetPackagePoolAutoPurgeInterval
		{
			get
			{
				return (this.m_AssetManager == null) ? -1f : this.m_AssetManager.AssetPackagePoolAutoPurgeInterval;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetPackagePoolAutoPurgeInterval = value;
					this.m_AssetManager.SetAssetPackagePoolAutoPurgeInterval(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x17002238 RID: 8760
		// (get) Token: 0x0601A27E RID: 107134 RVA: 0x00820F9D File Offset: 0x0081F39D
		// (set) Token: 0x0601A27F RID: 107135 RVA: 0x00820FBF File Offset: 0x0081F3BF
		public float AssetPackageExpireTime
		{
			get
			{
				return (this.m_AssetManager == null) ? -1f : this.m_AssetManager.AssetPackageExpireTime;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetPackageExpireTime = value;
					this.m_AssetManager.SetAssetPackageExpireTime(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x17002239 RID: 8761
		// (get) Token: 0x0601A280 RID: 107136 RVA: 0x00820FEE File Offset: 0x0081F3EE
		public int AssetPackageLoadedCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetPackageLoadedCount;
			}
		}

		// Token: 0x1700223A RID: 8762
		// (get) Token: 0x0601A281 RID: 107137 RVA: 0x0082100C File Offset: 0x0081F40C
		public int AssetPackageCanReleaseCount
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetPackageCanReleaseCount;
			}
		}

		// Token: 0x1700223B RID: 8763
		// (get) Token: 0x0601A282 RID: 107138 RVA: 0x0082102A File Offset: 0x0081F42A
		// (set) Token: 0x0601A283 RID: 107139 RVA: 0x00821048 File Offset: 0x0081F448
		public int AssetPackagePoolPriority
		{
			get
			{
				return (this.m_AssetManager == null) ? -1 : this.m_AssetManager.AssetPackagePoolPriority;
			}
			set
			{
				if (this.m_AssetManager != null)
				{
					this.m_AssetPackagePoolPriority = value;
					this.m_AssetManager.SetAssetPackagePoolPriority(value);
				}
				else
				{
					Debug.LogWarning("Asset manager is not initialize yet!");
				}
			}
		}

		// Token: 0x1700223C RID: 8764
		// (get) Token: 0x0601A284 RID: 107140 RVA: 0x00821077 File Offset: 0x0081F477
		public ObjectDesc[] AssetPoolObjectInfos
		{
			get
			{
				return (this.m_AssetManager == null) ? new ObjectDesc[0] : this.m_AssetManager.AssetPoolObjectInfos;
			}
		}

		// Token: 0x1700223D RID: 8765
		// (get) Token: 0x0601A285 RID: 107141 RVA: 0x0082109A File Offset: 0x0081F49A
		public ObjectDesc[] AssetPackagePoolObjectInfos
		{
			get
			{
				return (this.m_AssetManager == null) ? new ObjectDesc[0] : this.m_AssetManager.AssetPackagePoolObjectInfos;
			}
		}

		// Token: 0x0601A286 RID: 107142 RVA: 0x008210BD File Offset: 0x0081F4BD
		protected sealed override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0601A287 RID: 107143 RVA: 0x008210C5 File Offset: 0x0081F4C5
		public void SetAssetLoadAgentCount(int loadAgentCount)
		{
			this.m_AssetLoadAgentCount = loadAgentCount;
			if (this.m_AssetManager != null)
			{
				this.m_AssetManager.SetAssetLoadAgentCount(this.m_AssetLoadAgentCount);
			}
			else
			{
				Debugger.LogWarning("AssetManager is not create yet!");
			}
		}

		// Token: 0x0601A288 RID: 107144 RVA: 0x008210FC File Offset: 0x0081F4FC
		private void Start()
		{
			this.m_AssetManager = ModuleManager.GetModule<ITMAssetManager>();
			if (this.m_AssetManager == null)
			{
				TMDebug.LogErrorFormat("Resource manager is invalid!", new object[0]);
				return;
			}
			this.m_AssetManager.AssetInitComplete += this._OnAssetInitComplete;
			this.m_AssetManager.VersionListUpdateSuccess += this._OnVersionListUpdateSuccess;
			this.m_AssetManager.VersionListUpdateFailure += this._OnVersionListUpdateFailure;
			this.m_AssetManager.AssetCheckComplete += this._OnAssetCheckComplete;
			this.m_AssetManager.AssetUpdateStart += this._OnAssetUpdateStart;
			this.m_AssetManager.AssetUpdateChanged += this._OnAssetUpdateChanged;
			this.m_AssetManager.AssetUpdateSuccess += this._OnAssetUpdateSuccess;
			this.m_AssetManager.AssetUpdateFailure += this._OnAssetUpdateFailure;
			this.m_AssetManager.AssetUpdateFinish += this._OnAssetUpdateFinish;
			this.m_AssetManager.SetReadOnlyPath(Application.streamingAssetsPath);
			string readWritePath;
			if (this.m_UseTempPath)
			{
				readWritePath = Application.temporaryCachePath;
			}
			else
			{
				readWritePath = Application.persistentDataPath;
			}
			this.m_AssetManager.SetReadWritePath(readWritePath);
			EnumHelper<AssetMode> flags = new EnumHelper<AssetMode>(this.m_AssetMode);
			if (Global.Settings.loadFromPackage)
			{
				flags.AddFlag(TMEngine.Runtime.AssetMode.Package);
			}
			else
			{
				flags.RemoveFlag(TMEngine.Runtime.AssetMode.Package);
			}
			this.m_AssetManager.SetAssetMode(flags);
			this.m_AssetManager.SetPackageRootFolder(this.m_AssetPackageRootFolder);
			this.m_AssetManager.CreateAssetLoader(this.m_ResAsyncLoaderTypeName, this.m_ResSyncLoaderTypeName);
			this.m_AssetManager.AddResourceOnlyPath(this.m_ResourceOnlyRootFolder);
			this.m_AssetManager.SetAssetLoadAgentCount(this.m_AssetLoadAgentCount);
			this.m_AssetManager.SetAssetExpireTime(this.m_AssetExpireTime);
			this.m_AssetManager.SetAssetPoolPriority(this.m_AssetPoolPriority);
			this.m_AssetManager.SetAssetPoolAutoPurgeInterval(this.m_AssetPoolAutoPurgeInterval);
			this.m_AssetManager.SetAssetPackageExpireTime(this.m_AssetPackageExpireTime);
			this.m_AssetManager.SetAssetPackagePoolPriority(this.m_AssetPackagePoolPriority);
			this.m_AssetManager.SetAssetPackagePoolAutoPurgeInterval(this.m_AssetPackagePoolAutoPurgeInterval);
		}

		// Token: 0x0601A289 RID: 107145 RVA: 0x0082132B File Offset: 0x0081F72B
		private void Update()
		{
		}

		// Token: 0x0601A28A RID: 107146 RVA: 0x0082132D File Offset: 0x0081F72D
		private void _OnAssetInitComplete(object sender, AssetInitCompleteEventArgs e)
		{
		}

		// Token: 0x0601A28B RID: 107147 RVA: 0x0082132F File Offset: 0x0081F72F
		private void _OnVersionListUpdateSuccess(object sender, VersionListUpdateSuccessEventArgs e)
		{
		}

		// Token: 0x0601A28C RID: 107148 RVA: 0x00821331 File Offset: 0x0081F731
		private void _OnVersionListUpdateFailure(object sender, VersionListUpdateFailureEventArgs e)
		{
		}

		// Token: 0x0601A28D RID: 107149 RVA: 0x00821333 File Offset: 0x0081F733
		private void _OnAssetCheckComplete(object sender, AssetCheckCompleteEventArgs e)
		{
		}

		// Token: 0x0601A28E RID: 107150 RVA: 0x00821335 File Offset: 0x0081F735
		private void _OnAssetUpdateStart(object sender, AssetUpdateStartEventArgs e)
		{
		}

		// Token: 0x0601A28F RID: 107151 RVA: 0x00821337 File Offset: 0x0081F737
		private void _OnAssetUpdateChanged(object sender, AssetUpdateChangedEventArgs e)
		{
		}

		// Token: 0x0601A290 RID: 107152 RVA: 0x00821339 File Offset: 0x0081F739
		private void _OnAssetUpdateSuccess(object sender, AssetUpdateSuccessEventArgs e)
		{
		}

		// Token: 0x0601A291 RID: 107153 RVA: 0x0082133B File Offset: 0x0081F73B
		private void _OnAssetUpdateFailure(object sender, AssetUpdateFailureEventArgs e)
		{
		}

		// Token: 0x0601A292 RID: 107154 RVA: 0x0082133D File Offset: 0x0081F73D
		private void _OnAssetUpdateFinish(object sender, AssetUpdateFinishEventArgs e)
		{
		}

		// Token: 0x0401260D RID: 75277
		private ITMAssetManager m_AssetManager;

		// Token: 0x0401260E RID: 75278
		[SerializeField]
		private uint m_AssetMode;

		// Token: 0x0401260F RID: 75279
		[SerializeField]
		private bool m_UseTempPath;

		// Token: 0x04012610 RID: 75280
		[SerializeField]
		private float m_UnloadUnusedAssetsInterval = 60f;

		// Token: 0x04012611 RID: 75281
		[SerializeField]
		private float m_AssetPoolAutoPurgeInterval = 60f;

		// Token: 0x04012612 RID: 75282
		[SerializeField]
		private float m_AssetExpireTime = 30f;

		// Token: 0x04012613 RID: 75283
		[SerializeField]
		private int m_AssetPoolPriority = 30;

		// Token: 0x04012614 RID: 75284
		[SerializeField]
		private float m_AssetPackagePoolAutoPurgeInterval = 60f;

		// Token: 0x04012615 RID: 75285
		[SerializeField]
		private float m_AssetPackageExpireTime = 30f;

		// Token: 0x04012616 RID: 75286
		[SerializeField]
		private int m_AssetPackagePoolPriority = 25;

		// Token: 0x04012617 RID: 75287
		[SerializeField]
		private int m_UpdateRetryCount = 3;

		// Token: 0x04012618 RID: 75288
		[SerializeField]
		private int m_AssetLoadAgentCount = 3;

		// Token: 0x04012619 RID: 75289
		[SerializeField]
		private string m_ResAsyncLoaderTypeName = typeof(UnityResAsyncLoader).FullName;

		// Token: 0x0401261A RID: 75290
		[SerializeField]
		private string m_ResSyncLoaderTypeName = typeof(UnityResSyncLoader).FullName;

		// Token: 0x0401261B RID: 75291
		[SerializeField]
		private string m_AssetPackageRootFolder = "AssetBundles";

		// Token: 0x0401261C RID: 75292
		[SerializeField]
		private string m_ResourceOnlyRootFolder = "Base";
	}
}
