using System;
using System.Diagnostics;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004739 RID: 18233
	public class UnityResAsyncLoader : TMResAsyncLoader, IDisposable
	{
		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0601A2F4 RID: 107252 RVA: 0x0082236C File Offset: 0x0082076C
		// (remove) Token: 0x0601A2F5 RID: 107253 RVA: 0x008223A4 File Offset: 0x008207A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler<LoadResourceUpdateEventArgs> m_LoadResourceUpdateEventHandler;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x0601A2F6 RID: 107254 RVA: 0x008223DC File Offset: 0x008207DC
		// (remove) Token: 0x0601A2F7 RID: 107255 RVA: 0x00822414 File Offset: 0x00820814
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler<LoadResourceCompleteEventArgs> m_LoadResourceCompleteEventHandler;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x0601A2F8 RID: 107256 RVA: 0x0082244C File Offset: 0x0082084C
		// (remove) Token: 0x0601A2F9 RID: 107257 RVA: 0x00822484 File Offset: 0x00820884
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler<LoadResourceFailedEventArgs> m_LoadResourceFailedEventHandler;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x0601A2FA RID: 107258 RVA: 0x008224BC File Offset: 0x008208BC
		// (remove) Token: 0x0601A2FB RID: 107259 RVA: 0x008224F4 File Offset: 0x008208F4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler<LoadPackageCompleteEventArgs> m_LoadPackageCompleteEventHandler;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x0601A2FC RID: 107260 RVA: 0x0082252A File Offset: 0x0082092A
		// (remove) Token: 0x0601A2FD RID: 107261 RVA: 0x00822533 File Offset: 0x00820933
		public override event EventHandler<LoadResourceUpdateEventArgs> UpdateResourceEventHandler
		{
			add
			{
				this.m_LoadResourceUpdateEventHandler += value;
			}
			remove
			{
				this.m_LoadResourceUpdateEventHandler -= value;
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x0601A2FE RID: 107262 RVA: 0x0082253C File Offset: 0x0082093C
		// (remove) Token: 0x0601A2FF RID: 107263 RVA: 0x00822545 File Offset: 0x00820945
		public override event EventHandler<LoadResourceCompleteEventArgs> LoadResourceCompleteEventHandler
		{
			add
			{
				this.m_LoadResourceCompleteEventHandler += value;
			}
			remove
			{
				this.m_LoadResourceCompleteEventHandler -= value;
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x0601A300 RID: 107264 RVA: 0x0082254E File Offset: 0x0082094E
		// (remove) Token: 0x0601A301 RID: 107265 RVA: 0x00822557 File Offset: 0x00820957
		public override event EventHandler<LoadResourceFailedEventArgs> LoadResourceFailedEventHandler
		{
			add
			{
				this.m_LoadResourceFailedEventHandler += value;
			}
			remove
			{
				this.m_LoadResourceFailedEventHandler -= value;
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0601A302 RID: 107266 RVA: 0x00822560 File Offset: 0x00820960
		// (remove) Token: 0x0601A303 RID: 107267 RVA: 0x00822569 File Offset: 0x00820969
		public override event EventHandler<LoadPackageCompleteEventArgs> LoadPackageCompleteEventHandler
		{
			add
			{
				this.m_LoadPackageCompleteEventHandler += value;
			}
			remove
			{
				this.m_LoadPackageCompleteEventHandler -= value;
			}
		}

		// Token: 0x0601A304 RID: 107268 RVA: 0x00822574 File Offset: 0x00820974
		public sealed override void LoadPackage(string packageFullpath)
		{
			if (this.m_LoadResourceFailedEventHandler == null || this.m_LoadResourceCompleteEventHandler == null || this.m_LoadPackageCompleteEventHandler == null)
			{
				TMDebug.AssertFailed("Load asset agent loader handler is invalid!");
				return;
			}
			if (string.IsNullOrEmpty(packageFullpath))
			{
				this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.PackageError, "Asset bundle path is invalid!"));
				return;
			}
			this.m_PackageFullPath = packageFullpath;
			this.m_PackageAssetBundleCreateReq = AssetBundle.LoadFromFileAsync(this.m_PackageFullPath);
		}

		// Token: 0x0601A305 RID: 107269 RVA: 0x008225E8 File Offset: 0x008209E8
		public sealed override void LoadAsset(object resource, string assetName, string subResName, Type assetType)
		{
			if (this.m_LoadResourceFailedEventHandler == null || this.m_LoadResourceCompleteEventHandler == null)
			{
				TMDebug.AssertFailed("Load asset agent loader handler is invalid!");
				return;
			}
			if (resource == null)
			{
				this._LoadAssetFromResource(assetName, subResName, assetType);
			}
			else
			{
				this._LoadAssetFromPackage(resource, assetName, subResName, assetType);
			}
		}

		// Token: 0x0601A306 RID: 107270 RVA: 0x00822638 File Offset: 0x00820A38
		protected void _LoadAssetFromPackage(object package, string assetNameInPackage, string subResName, Type assetType)
		{
			AssetBundle assetBundle = package as AssetBundle;
			if (null == assetBundle)
			{
				this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.TypeError, "Cant not load asset from loaded resource which is not a unity asset bundle!"));
				return;
			}
			if (string.IsNullOrEmpty(assetNameInPackage))
			{
				this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.InvalidParam, "Can not load asset form asset bundle cause asset name in package is invalid!"));
				return;
			}
			this.m_AssetSubName = subResName;
			this.m_AssetNameInPackage = assetNameInPackage;
			if (string.IsNullOrEmpty(subResName))
			{
				this.m_PackageAssetLoadReq = assetBundle.LoadAssetAsync(this.m_AssetNameInPackage, assetType);
			}
			else
			{
				this.m_PackageAssetLoadReq = assetBundle.LoadAssetWithSubAssetsAsync(this.m_AssetNameInPackage, assetType);
			}
		}

		// Token: 0x0601A307 RID: 107271 RVA: 0x008226DC File Offset: 0x00820ADC
		protected void _LoadAssetFromResource(string assetFullPath, string subResName, Type assetType)
		{
			if (string.IsNullOrEmpty(assetFullPath))
			{
				this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.InvalidParam, "Asset path is invalid!"));
				return;
			}
			this.m_AssetSubName = subResName;
			this.m_AssetFullPath = assetFullPath;
			this.m_AssetLoadReq = Resources.LoadAsync(Utility.Path.ChangeExtension(this.m_AssetFullPath, null), assetType);
		}

		// Token: 0x0601A308 RID: 107272 RVA: 0x00822734 File Offset: 0x00820B34
		public sealed override void LoadFile(string filepath, bool readWritePath, ResAsyncLoadFileCallback fileLoadCallback)
		{
			if (fileLoadCallback == null)
			{
				TMDebug.AssertFailed("Load file callback is can not be null!");
				return;
			}
			if (string.IsNullOrEmpty(filepath))
			{
				fileLoadCallback(filepath, null, 0f, "File path is invalid!");
				return;
			}
			this.m_FileLoadCallback = fileLoadCallback;
			this.m_FileFullPath = this._GetAccessFileURLProtocol(filepath, readWritePath);
			this.m_WWW = new WWW(this.m_FileFullPath);
			this.m_FileLoadStamp = DateTime.Now.Ticks;
		}

		// Token: 0x0601A309 RID: 107273 RVA: 0x008227A9 File Offset: 0x00820BA9
		private string _GetAccessFileURLProtocol(string filepath, bool readWritePath)
		{
			if (readWritePath)
			{
				return Utility.Path.Combine("file://" + Application.persistentDataPath, filepath);
			}
			return Utility.Path.Combine("jar:file://" + Application.dataPath + "!/assets/", filepath);
		}

		// Token: 0x0601A30A RID: 107274 RVA: 0x008227E4 File Offset: 0x00820BE4
		public sealed override void UnloadPackage(object package)
		{
			AssetBundle assetBundle = package as AssetBundle;
			if (null == assetBundle)
			{
				TMDebug.LogErrorFormat("Cant not unload asset from loaded resource which is not a unity asset bundle!", new object[0]);
				return;
			}
			assetBundle.Unload(true);
		}

		// Token: 0x0601A30B RID: 107275 RVA: 0x0082281C File Offset: 0x00820C1C
		public sealed override void Update()
		{
			this._UpdateWWWLoading();
			this._UpdatePackageFetchRequest();
			this._UpdatePackageLoadRequest();
			this._UpdatePackageAssetLoadRequest();
			this._UpdateResourceLoadRequest();
		}

		// Token: 0x0601A30C RID: 107276 RVA: 0x0082283C File Offset: 0x00820C3C
		public sealed override void Reset()
		{
			this.m_PackageFullPath = null;
			this.m_PackageUpdateUrl = null;
			this.m_AssetNameInPackage = null;
			this.m_AssetSubName = null;
			this.m_AssetFullPath = null;
			this.m_FileFullPath = null;
			this.m_PackageAssetBundleCreateReq = null;
			this.m_PackageAssetLoadReq = null;
			this.m_AssetLoadReq = null;
			this.m_FileLoadStamp = 0L;
			if (this.m_WWW != null)
			{
				this.m_WWW.Dispose();
				this.m_WWW = null;
			}
		}

		// Token: 0x0601A30D RID: 107277 RVA: 0x008228AD File Offset: 0x00820CAD
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0601A30E RID: 107278 RVA: 0x008228BC File Offset: 0x00820CBC
		public void Dispose(bool disposing)
		{
			if (this.m_Disposed)
			{
				return;
			}
			if (disposing && this.m_WWW != null)
			{
				this.m_WWW.Dispose();
				this.m_WWW = null;
			}
			this.m_Disposed = true;
		}

		// Token: 0x0601A30F RID: 107279 RVA: 0x008228F4 File Offset: 0x00820CF4
		private void _UpdateWWWLoading()
		{
			if (this.m_WWW != null && this.m_WWW.isDone)
			{
				if (string.IsNullOrEmpty(this.m_WWW.error))
				{
					this.m_FileLoadCallback(this.m_FileFullPath, this.m_WWW.bytes, Utility.Time.TicksToSeconds(DateTime.Now.Ticks - this.m_FileLoadStamp), null);
				}
				else
				{
					this.m_FileLoadCallback(this.m_FileFullPath, null, Utility.Time.TicksToSeconds(DateTime.Now.Ticks - this.m_FileLoadStamp), string.Format("Can not load file '{0}' with WWW! (internal error:{1})", this.m_FileFullPath, this.m_WWW.error));
				}
				this.m_WWW.Dispose();
				this.m_WWW = null;
				this.m_FileFullPath = null;
				this.m_FileLoadStamp = 0L;
				this.m_FileLoadCallback = null;
			}
		}

		// Token: 0x0601A310 RID: 107280 RVA: 0x008229DA File Offset: 0x00820DDA
		private void _UpdatePackageFetchRequest()
		{
		}

		// Token: 0x0601A311 RID: 107281 RVA: 0x008229DC File Offset: 0x00820DDC
		private void _UpdatePackageLoadRequest()
		{
			if (this.m_PackageAssetBundleCreateReq != null)
			{
				if (this.m_PackageAssetBundleCreateReq.isDone)
				{
					AssetBundle assetBundle = this.m_PackageAssetBundleCreateReq.assetBundle;
					if (null != assetBundle)
					{
						AssetBundleCreateRequest packageAssetBundleCreateReq = this.m_PackageAssetBundleCreateReq;
						this.m_LoadPackageCompleteEventHandler(this, new LoadPackageCompleteEventArgs(assetBundle));
						if (packageAssetBundleCreateReq == this.m_PackageAssetBundleCreateReq)
						{
							this.m_PackageAssetBundleCreateReq = null;
						}
					}
					else
					{
						this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.NotExist, string.Format("Can not load asset bundle from file '{0}' which is not a valid asset bundle resource!", this.m_PackageFullPath)));
					}
				}
				else
				{
					this.m_LoadResourceUpdateEventHandler(this, new LoadResourceUpdateEventArgs(ResourceLoadMode.LoadPackage, this.m_PackageAssetBundleCreateReq.progress));
				}
			}
		}

		// Token: 0x0601A312 RID: 107282 RVA: 0x00822A94 File Offset: 0x00820E94
		private void _UpdatePackageAssetLoadRequest()
		{
			if (this.m_PackageAssetLoadReq != null)
			{
				if (this.m_PackageAssetLoadReq.isDone)
				{
					if (null != this.m_PackageAssetLoadReq.asset)
					{
						Object @object = null;
						if (!string.IsNullOrEmpty(this.m_AssetSubName))
						{
							Object[] allAssets = this.m_PackageAssetLoadReq.allAssets;
							int i = 0;
							int num = allAssets.Length;
							while (i < num)
							{
								if (allAssets[i].name == this.m_AssetSubName)
								{
									@object = allAssets[i];
									break;
								}
								i++;
							}
						}
						if (null == @object)
						{
							@object = this.m_PackageAssetLoadReq.asset;
						}
						GameObject gameObject = this.m_PackageAssetLoadReq.asset as GameObject;
						this.m_LoadResourceCompleteEventHandler(this, new LoadResourceCompleteEventArgs(new UnityAssetObject(this.m_PackageAssetLoadReq.asset), null == gameObject));
						this.m_PackageAssetLoadReq = null;
						this.m_AssetNameInPackage = null;
					}
					else
					{
						this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.NotExist, string.Format("Can not load asset named '{0}' from asset bundle which does not exist in bundle '{1}'!", this.m_AssetNameInPackage, this.m_PackageFullPath)));
					}
				}
				else
				{
					this.m_LoadResourceUpdateEventHandler(this, new LoadResourceUpdateEventArgs(ResourceLoadMode.LoadAsset, this.m_PackageAssetLoadReq.progress));
				}
			}
		}

		// Token: 0x0601A313 RID: 107283 RVA: 0x00822BD8 File Offset: 0x00820FD8
		private void _UpdateResourceLoadRequest()
		{
			if (this.m_AssetLoadReq != null)
			{
				if (this.m_AssetLoadReq.isDone)
				{
					if (null != this.m_AssetLoadReq.asset)
					{
						Object @object = null;
						if (null == @object)
						{
							@object = this.m_AssetLoadReq.asset;
						}
						GameObject gameObject = this.m_AssetLoadReq.asset as GameObject;
						this.m_LoadResourceCompleteEventHandler(this, new LoadResourceCompleteEventArgs(new UnityAssetObject(this.m_AssetLoadReq.asset), null == gameObject));
						this.m_AssetLoadReq = null;
						this.m_AssetFullPath = null;
					}
					else
					{
						this.m_LoadResourceFailedEventHandler(this, new LoadResourceFailedEventArgs(AssetLoadErrorCode.NotExist, string.Format("Can not load asset named '{0}'!", this.m_AssetFullPath)));
					}
				}
				else
				{
					this.m_LoadResourceUpdateEventHandler(this, new LoadResourceUpdateEventArgs(ResourceLoadMode.LoadAsset, this.m_AssetLoadReq.progress));
				}
			}
		}

		// Token: 0x04012652 RID: 75346
		private string m_PackageFullPath;

		// Token: 0x04012653 RID: 75347
		private string m_PackageUpdateUrl;

		// Token: 0x04012654 RID: 75348
		private string m_AssetNameInPackage;

		// Token: 0x04012655 RID: 75349
		private string m_AssetSubName;

		// Token: 0x04012656 RID: 75350
		private string m_AssetFullPath;

		// Token: 0x04012657 RID: 75351
		private string m_FileFullPath;

		// Token: 0x04012658 RID: 75352
		private AssetBundleCreateRequest m_PackageAssetBundleCreateReq;

		// Token: 0x04012659 RID: 75353
		private AssetBundleRequest m_PackageAssetLoadReq;

		// Token: 0x0401265A RID: 75354
		private ResourceRequest m_AssetLoadReq;

		// Token: 0x0401265B RID: 75355
		private WWW m_WWW;

		// Token: 0x0401265C RID: 75356
		private ResAsyncLoadFileCallback m_FileLoadCallback;

		// Token: 0x0401265D RID: 75357
		private long m_FileLoadStamp;

		// Token: 0x0401265E RID: 75358
		private bool m_Disposed;
	}
}
