using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046CE RID: 18126
	[Serializable]
	public struct AssetDesc
	{
		// Token: 0x06019F4D RID: 106317 RVA: 0x0081A7E7 File Offset: 0x00818BE7
		public AssetDesc(string assetName, string assetGUIDName, int assetPackageID)
		{
			this.m_AssetName = assetName;
			this.m_AssetGUIDName = assetGUIDName;
			this.m_AssetPackageID = assetPackageID;
		}

		// Token: 0x17002156 RID: 8534
		// (get) Token: 0x06019F4E RID: 106318 RVA: 0x0081A7FE File Offset: 0x00818BFE
		public string AssetName
		{
			get
			{
				return this.m_AssetName;
			}
		}

		// Token: 0x17002157 RID: 8535
		// (get) Token: 0x06019F4F RID: 106319 RVA: 0x0081A806 File Offset: 0x00818C06
		public string AssetGUIDName
		{
			get
			{
				return this.m_AssetGUIDName;
			}
		}

		// Token: 0x17002158 RID: 8536
		// (get) Token: 0x06019F50 RID: 106320 RVA: 0x0081A80E File Offset: 0x00818C0E
		public int AssetPackageID
		{
			get
			{
				return this.m_AssetPackageID;
			}
		}

		// Token: 0x040124F3 RID: 74995
		public string m_AssetName;

		// Token: 0x040124F4 RID: 74996
		public string m_AssetGUIDName;

		// Token: 0x040124F5 RID: 74997
		public int m_AssetPackageID;
	}
}
