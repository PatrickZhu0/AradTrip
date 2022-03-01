using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046D3 RID: 18131
	public enum AssetLoadErrorCode
	{
		// Token: 0x040124FA RID: 75002
		OK,
		// Token: 0x040124FB RID: 75003
		NotReady,
		// Token: 0x040124FC RID: 75004
		NullAsset,
		// Token: 0x040124FD RID: 75005
		NotExist,
		// Token: 0x040124FE RID: 75006
		PackageError,
		// Token: 0x040124FF RID: 75007
		DependencyLoadError,
		// Token: 0x04012500 RID: 75008
		TaskTypeError,
		// Token: 0x04012501 RID: 75009
		TypeError,
		// Token: 0x04012502 RID: 75010
		InvalidParam
	}
}
