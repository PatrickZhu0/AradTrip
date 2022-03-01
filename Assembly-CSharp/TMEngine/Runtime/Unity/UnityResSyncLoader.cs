using System;
using System.IO;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200473A RID: 18234
	public class UnityResSyncLoader : TMResSyncLoader
	{
		// Token: 0x0601A315 RID: 107285 RVA: 0x00822CC8 File Offset: 0x008210C8
		public sealed override object LoadPackage(string packageFullpath)
		{
			if (string.IsNullOrEmpty(packageFullpath))
			{
				TMDebug.LogErrorFormat("Can not load asset bundle cause package path is invalid!", new object[0]);
				return null;
			}
			this.m_PackageFullPath = packageFullpath;
			AssetBundle assetBundle = AssetBundle.LoadFromFile(this.m_PackageFullPath);
			if (null == assetBundle)
			{
				TMDebug.LogErrorFormat("Can not load asset bundle from file '{0}' which is not a valid asset bundle resource!", new object[]
				{
					this.m_PackageFullPath
				});
			}
			return assetBundle;
		}

		// Token: 0x0601A316 RID: 107286 RVA: 0x00822D2B File Offset: 0x0082112B
		public sealed override object LoadAsset(object package, string assetName, string subResName, Type assetType)
		{
			if (package == null)
			{
				return this._LoadAssetFromResource(assetName, subResName, assetType);
			}
			return this._LoadAssetFromPackage(package, assetName, subResName, assetType);
		}

		// Token: 0x0601A317 RID: 107287 RVA: 0x00822D4C File Offset: 0x0082114C
		protected object _LoadAssetFromPackage(object package, string assetNameInPackage, string subResName, Type assetType)
		{
			AssetBundle assetBundle = package as AssetBundle;
			if (null == assetBundle)
			{
				TMDebug.LogErrorFormat("Cant not load asset from loaded resource which is not a unity asset bundle!", new object[0]);
				return null;
			}
			if (string.IsNullOrEmpty(assetNameInPackage))
			{
				TMDebug.LogErrorFormat("Can not load asset form asset bundle cause asset name in package is invalid!", new object[0]);
				return null;
			}
			this.m_AssetNameInPackage = assetNameInPackage;
			Object @object = null;
			if (!string.IsNullOrEmpty(subResName) && assetType == typeof(Sprite))
			{
				Sprite[] array = assetBundle.LoadAssetWithSubAssets<Sprite>(CFileManager.EraseExtension(this.m_AssetNameInPackage));
				for (int i = 0; i < array.Length; i++)
				{
					if (subResName == array[i].name)
					{
						@object = array[i];
						break;
					}
				}
			}
			if (null == @object)
			{
				@object = assetBundle.LoadAsset(this.m_AssetNameInPackage, assetType);
			}
			if (null == @object)
			{
				TMDebug.LogErrorFormat("Can not load asset named '{0}' from asset bundle which does not exist in bundle '{1}'!", new object[]
				{
					this.m_AssetNameInPackage,
					this.m_PackageFullPath
				});
				return null;
			}
			return new UnityAssetObject(@object);
		}

		// Token: 0x0601A318 RID: 107288 RVA: 0x00822E54 File Offset: 0x00821254
		protected object _LoadAssetFromResource(string assetFullPath, string subResName, Type assetType)
		{
			if (string.IsNullOrEmpty(assetFullPath))
			{
				TMDebug.LogErrorFormat("Asset path is invalid!", new object[0]);
				return null;
			}
			this.m_AssetFullPath = Utility.Path.ChangeExtension(assetFullPath, null);
			Object @object = null;
			if (!string.IsNullOrEmpty(subResName) && assetType == typeof(Sprite))
			{
				Sprite[] array = Resources.LoadAll<Sprite>(CFileManager.EraseExtension(this.m_AssetFullPath));
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].name == subResName)
					{
						@object = array[i];
						break;
					}
				}
			}
			if (null == @object)
			{
				@object = Resources.Load(this.m_AssetFullPath, assetType);
			}
			if (null == @object)
			{
				TMDebug.LogWarningFormat("Can not load asset named '{0}'!", new object[]
				{
					this.m_AssetFullPath
				});
				return null;
			}
			return new UnityAssetObject(@object);
		}

		// Token: 0x0601A319 RID: 107289 RVA: 0x00822F30 File Offset: 0x00821330
		public sealed override bool LoadFile(string filepath, bool readWritePath, out byte[] filedata)
		{
			filedata = null;
			if (string.IsNullOrEmpty(filepath))
			{
				TMDebug.LogErrorFormat("file path is invalid!", new object[0]);
				return false;
			}
			if (!Utility.File.Exists(filepath))
			{
				TMDebug.LogErrorFormat("File with file path '{0}' does not exist!", new object[]
				{
					filepath
				});
				return false;
			}
			bool result;
			using (FileStream fileStream = Utility.File.OpenRead(filepath))
			{
				int num = (int)fileStream.Length;
				filedata = new byte[num];
				fileStream.Seek(0L, SeekOrigin.Begin);
				int num2 = fileStream.Read(filedata, 0, num);
				fileStream.Close();
				if (num2 != num)
				{
					TMDebug.LogErrorFormat("Read file '{0}' has failed!(total bytes:{1}, read bytes:{2})", new object[]
					{
						filepath,
						num,
						num2
					});
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0601A31A RID: 107290 RVA: 0x0082300C File Offset: 0x0082140C
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

		// Token: 0x0601A31B RID: 107291 RVA: 0x00823044 File Offset: 0x00821444
		public sealed override void Reset()
		{
			this.m_PackageFullPath = null;
			this.m_PackageUpdateUrl = null;
			this.m_AssetNameInPackage = null;
			this.m_AssetFullPath = null;
		}

		// Token: 0x04012663 RID: 75363
		private string m_PackageFullPath;

		// Token: 0x04012664 RID: 75364
		private string m_PackageUpdateUrl;

		// Token: 0x04012665 RID: 75365
		private string m_AssetNameInPackage;

		// Token: 0x04012666 RID: 75366
		private string m_AssetFullPath;
	}
}
