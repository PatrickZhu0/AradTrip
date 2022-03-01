using System;

// Token: 0x02004BC3 RID: 19395
[Serializable]
public class DSkillFrameEffect : DSkillFrameEvent
{
	// Token: 0x0601C770 RID: 116592 RVA: 0x0089F5B4 File Offset: 0x0089D9B4
	public override void copyFrameEvent(DSkillFrameEvent src)
	{
		DSkillFrameEffect dskillFrameEffect = src as DSkillFrameEffect;
		base.copyFrameEvent(src);
		this.effectID = dskillFrameEffect.effectID;
		this.buffTime = dskillFrameEffect.buffTime;
		this.phaseDelete = dskillFrameEffect.phaseDelete;
		this.finishDelete = dskillFrameEffect.finishDelete;
		this.finishDeleteAll = dskillFrameEffect.finishDeleteAll;
		this.useBuffAni = dskillFrameEffect.finishDeleteAll;
		this.usePause = dskillFrameEffect.usePause;
		this.pauseTime = dskillFrameEffect.pauseTime;
		this.mechanismId = dskillFrameEffect.mechanismId;
	}

	// Token: 0x04013A67 RID: 80487
	public int effectID;

	// Token: 0x04013A68 RID: 80488
	public float buffTime;

	// Token: 0x04013A69 RID: 80489
	public bool phaseDelete;

	// Token: 0x04013A6A RID: 80490
	public bool finishDelete = true;

	// Token: 0x04013A6B RID: 80491
	public bool finishDeleteAll;

	// Token: 0x04013A6C RID: 80492
	public bool useBuffAni = true;

	// Token: 0x04013A6D RID: 80493
	public bool usePause;

	// Token: 0x04013A6E RID: 80494
	public float pauseTime;

	// Token: 0x04013A6F RID: 80495
	public int mechanismId;
}
