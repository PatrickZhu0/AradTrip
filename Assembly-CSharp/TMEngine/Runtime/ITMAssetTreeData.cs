using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x020046CD RID: 18125
	public interface ITMAssetTreeData
	{
		// Token: 0x06019F4B RID: 106315
		List<AssetDesc> GetAssetDescMap();

		// Token: 0x06019F4C RID: 106316
		List<AssetPackageDesc> GetAssetPackageDescMap();
	}
}
