using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x020046EE RID: 18158
	public sealed class AssetPackageNameComparer : IComparer<AssetPackageName>, IEqualityComparer<AssetPackageName>
	{
		// Token: 0x0601A0B6 RID: 106678 RVA: 0x0081E002 File Offset: 0x0081C402
		public int Compare(AssetPackageName x, AssetPackageName y)
		{
			return x.CompareTo(y);
		}

		// Token: 0x0601A0B7 RID: 106679 RVA: 0x0081E00C File Offset: 0x0081C40C
		public bool Equals(AssetPackageName x, AssetPackageName y)
		{
			return x.Equals(y);
		}

		// Token: 0x0601A0B8 RID: 106680 RVA: 0x0081E016 File Offset: 0x0081C416
		public int GetHashCode(AssetPackageName obj)
		{
			return obj.GetHashCode();
		}
	}
}
