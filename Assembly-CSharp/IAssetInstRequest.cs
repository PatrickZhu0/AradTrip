using System;

// Token: 0x020000AD RID: 173
public interface IAssetInstRequest
{
	// Token: 0x06000395 RID: 917
	bool IsDone();

	// Token: 0x06000396 RID: 918
	AssetInst Extract();

	// Token: 0x06000397 RID: 919
	void Abort();
}
