using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046EC RID: 18156
	[Serializable]
	public struct AssetPackageDesc
	{
		// Token: 0x0601A0A0 RID: 106656 RVA: 0x0081DE28 File Offset: 0x0081C228
		public AssetPackageDesc(AssetPackageName packageName, int packageID, int[] dependencyPackageIDs, uint packageUsage, int packageByes, int packageCRC32, string packageMD5)
		{
			TMDebug.Assert(null != dependencyPackageIDs, "Dependency package can not be null!");
			this.m_PackageName = packageName;
			this.m_PackageID = packageID;
			this.m_PackageUsage = new EnumHelper<AssetPackageUsage>(packageUsage);
			this.m_PackageBytes = packageByes;
			this.m_PackageCRC32 = packageCRC32;
			this.m_PackageMD5 = packageMD5;
			this.m_DependencyPackageIDs = dependencyPackageIDs;
		}

		// Token: 0x170021C0 RID: 8640
		// (get) Token: 0x0601A0A1 RID: 106657 RVA: 0x0081DE85 File Offset: 0x0081C285
		public AssetPackageName PackageName
		{
			get
			{
				return this.m_PackageName;
			}
		}

		// Token: 0x170021C1 RID: 8641
		// (get) Token: 0x0601A0A2 RID: 106658 RVA: 0x0081DE8D File Offset: 0x0081C28D
		public int PackageID
		{
			get
			{
				return this.m_PackageID;
			}
		}

		// Token: 0x170021C2 RID: 8642
		// (get) Token: 0x0601A0A3 RID: 106659 RVA: 0x0081DE95 File Offset: 0x0081C295
		public int[] DependencyPackageIDs
		{
			get
			{
				return this.m_DependencyPackageIDs;
			}
		}

		// Token: 0x170021C3 RID: 8643
		// (get) Token: 0x0601A0A4 RID: 106660 RVA: 0x0081DE9D File Offset: 0x0081C29D
		public EnumHelper<AssetPackageUsage> AssetPackageUsage
		{
			get
			{
				return new EnumHelper<AssetPackageUsage>(this.m_PackageUsage);
			}
		}

		// Token: 0x170021C4 RID: 8644
		// (get) Token: 0x0601A0A5 RID: 106661 RVA: 0x0081DEAA File Offset: 0x0081C2AA
		public int PackageBytes
		{
			get
			{
				return this.m_PackageBytes;
			}
		}

		// Token: 0x170021C5 RID: 8645
		// (get) Token: 0x0601A0A6 RID: 106662 RVA: 0x0081DEB2 File Offset: 0x0081C2B2
		public int PackageCRC32
		{
			get
			{
				return this.m_PackageCRC32;
			}
		}

		// Token: 0x170021C6 RID: 8646
		// (get) Token: 0x0601A0A7 RID: 106663 RVA: 0x0081DEBA File Offset: 0x0081C2BA
		public string PackageMD5
		{
			get
			{
				return this.m_PackageMD5;
			}
		}

		// Token: 0x170021C7 RID: 8647
		// (get) Token: 0x0601A0A8 RID: 106664 RVA: 0x0081DEC2 File Offset: 0x0081C2C2
		public bool StorageInReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x04012590 RID: 75152
		public AssetPackageName m_PackageName;

		// Token: 0x04012591 RID: 75153
		public int m_PackageID;

		// Token: 0x04012592 RID: 75154
		public int[] m_DependencyPackageIDs;

		// Token: 0x04012593 RID: 75155
		public uint m_PackageUsage;

		// Token: 0x04012594 RID: 75156
		public int m_PackageBytes;

		// Token: 0x04012595 RID: 75157
		public int m_PackageCRC32;

		// Token: 0x04012596 RID: 75158
		public string m_PackageMD5;
	}
}
