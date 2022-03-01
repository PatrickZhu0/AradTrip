using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046ED RID: 18157
	[Serializable]
	public struct AssetPackageName : IComparable, IComparable<AssetPackageName>, IEquatable<AssetPackageName>
	{
		// Token: 0x0601A0A9 RID: 106665 RVA: 0x0081DEC5 File Offset: 0x0081C2C5
		public AssetPackageName(string name, string variant)
		{
			if (string.IsNullOrEmpty(name))
			{
				TMDebug.AssertFailed("Resource name can not be null or empty!");
			}
			this.m_PackageName = name;
			this.m_Variant = variant;
		}

		// Token: 0x170021C8 RID: 8648
		// (get) Token: 0x0601A0AA RID: 106666 RVA: 0x0081DEEA File Offset: 0x0081C2EA
		public string Name
		{
			get
			{
				return this.m_PackageName;
			}
		}

		// Token: 0x170021C9 RID: 8649
		// (get) Token: 0x0601A0AB RID: 106667 RVA: 0x0081DEF2 File Offset: 0x0081C2F2
		public string Variant
		{
			get
			{
				return this.m_Variant;
			}
		}

		// Token: 0x170021CA RID: 8650
		// (get) Token: 0x0601A0AC RID: 106668 RVA: 0x0081DEFA File Offset: 0x0081C2FA
		public bool IsVariant
		{
			get
			{
				return !string.IsNullOrEmpty(this.m_Variant);
			}
		}

		// Token: 0x170021CB RID: 8651
		// (get) Token: 0x0601A0AD RID: 106669 RVA: 0x0081DF0A File Offset: 0x0081C30A
		public string FullName
		{
			get
			{
				return (!this.IsVariant) ? this.m_PackageName : string.Format("{0}.{1}", this.m_PackageName, this.m_Variant);
			}
		}

		// Token: 0x0601A0AE RID: 106670 RVA: 0x0081DF38 File Offset: 0x0081C338
		public override int GetHashCode()
		{
			return this.FullName.GetHashCode();
		}

		// Token: 0x0601A0AF RID: 106671 RVA: 0x0081DF45 File Offset: 0x0081C345
		public override bool Equals(object value)
		{
			return value is AssetPackageName && this == (AssetPackageName)value;
		}

		// Token: 0x0601A0B0 RID: 106672 RVA: 0x0081DF66 File Offset: 0x0081C366
		public bool Equals(AssetPackageName assetPackageName)
		{
			return this == assetPackageName;
		}

		// Token: 0x0601A0B1 RID: 106673 RVA: 0x0081DF74 File Offset: 0x0081C374
		public static bool operator ==(AssetPackageName assetPackageName1, AssetPackageName assetPackageName2)
		{
			return assetPackageName1.CompareTo(assetPackageName2) == 0;
		}

		// Token: 0x0601A0B2 RID: 106674 RVA: 0x0081DF81 File Offset: 0x0081C381
		public static bool operator !=(AssetPackageName assetPackageName1, AssetPackageName assetPackageName2)
		{
			return assetPackageName1.CompareTo(assetPackageName2) != 0;
		}

		// Token: 0x0601A0B3 RID: 106675 RVA: 0x0081DF91 File Offset: 0x0081C391
		public int CompareTo(object value)
		{
			if (value == null)
			{
				return 1;
			}
			if (!(value is AssetPackageName))
			{
				throw new TMEngineException("Type of value is invalid.");
			}
			return this.CompareTo((AssetPackageName)value);
		}

		// Token: 0x0601A0B4 RID: 106676 RVA: 0x0081DFC0 File Offset: 0x0081C3C0
		public int CompareTo(AssetPackageName assetPackageName)
		{
			int num = string.Compare(this.m_PackageName, assetPackageName.m_PackageName);
			if (num != 0)
			{
				return num;
			}
			return string.Compare(this.m_Variant, assetPackageName.m_Variant);
		}

		// Token: 0x04012597 RID: 75159
		public string m_PackageName;

		// Token: 0x04012598 RID: 75160
		public string m_Variant;
	}
}
