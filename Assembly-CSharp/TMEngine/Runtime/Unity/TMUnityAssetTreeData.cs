using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200472D RID: 18221
	public class TMUnityAssetTreeData : ScriptableObject, ITMAssetTreeData
	{
		// Token: 0x0601A2B4 RID: 107188 RVA: 0x008216DF File Offset: 0x0081FADF
		public void Fill(List<AssetDesc> assetDescList, List<AssetPackageDesc> assetPackageList)
		{
			this.m_AssetDescList = assetDescList;
			this.m_AssetPackageDescList = assetPackageList;
		}

		// Token: 0x0601A2B5 RID: 107189 RVA: 0x008216EF File Offset: 0x0081FAEF
		public List<AssetDesc> GetAssetDescMap()
		{
			return this.m_AssetDescList;
		}

		// Token: 0x0601A2B6 RID: 107190 RVA: 0x008216F7 File Offset: 0x0081FAF7
		public List<AssetPackageDesc> GetAssetPackageDescMap()
		{
			return this.m_AssetPackageDescList;
		}

		// Token: 0x04012625 RID: 75301
		[SerializeField]
		private List<AssetDesc> m_AssetDescList;

		// Token: 0x04012626 RID: 75302
		[SerializeField]
		private List<AssetPackageDesc> m_AssetPackageDescList;
	}
}
