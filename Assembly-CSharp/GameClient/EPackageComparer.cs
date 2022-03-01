using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001289 RID: 4745
	public class EPackageComparer : IEqualityComparer<EPackageType>
	{
		// Token: 0x0600B671 RID: 46705 RVA: 0x00293BCE File Offset: 0x00291FCE
		public bool Equals(EPackageType x, EPackageType y)
		{
			return x == y;
		}

		// Token: 0x0600B672 RID: 46706 RVA: 0x00293BD4 File Offset: 0x00291FD4
		public int GetHashCode(EPackageType x)
		{
			return (int)x;
		}
	}
}
