using System;

// Token: 0x020040F5 RID: 16629
public class BDEventBase
{
	// Token: 0x06016A4C RID: 92748 RVA: 0x006DB346 File Offset: 0x006D9746
	public FrameRandomImp FrameRandom(BeEntity entity)
	{
		return entity.FrameRandom;
	}

	// Token: 0x06016A4D RID: 92749 RVA: 0x006DB34E File Offset: 0x006D974E
	public virtual void OnEvent(BeEntity pkEntity)
	{
	}

	// Token: 0x06016A4E RID: 92750 RVA: 0x006DB350 File Offset: 0x006D9750
	public virtual void PreparePreload(BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
	{
	}
}
