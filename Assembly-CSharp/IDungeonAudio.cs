using System;

// Token: 0x020000FC RID: 252
public interface IDungeonAudio
{
	// Token: 0x06000551 RID: 1361
	bool PushBgm(string path);

	// Token: 0x06000552 RID: 1362
	void PopBgm();

	// Token: 0x06000553 RID: 1363
	void ClearBgm();
}
