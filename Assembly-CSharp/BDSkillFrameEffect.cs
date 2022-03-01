using System;
using GameClient;

// Token: 0x020040FE RID: 16638
public class BDSkillFrameEffect : BDEventBase
{
	// Token: 0x06016A6B RID: 92779 RVA: 0x006DD7E4 File Offset: 0x006DBBE4
	public BDSkillFrameEffect(int eid, int d, bool useBuffAni, bool usePause, float pauseTime, bool finishDelete, bool finishDeleteAll, int mechanismId)
	{
		this.effectID = eid;
		this.buffTime = d;
		this.useBuffAni = useBuffAni;
		this.usePause = usePause;
		this.pauseTime = pauseTime;
		this.finishDelete = finishDelete;
		this.finishDeleteAll = finishDeleteAll;
		this.mechanismId = mechanismId;
	}

	// Token: 0x06016A6C RID: 92780 RVA: 0x006DD83C File Offset: 0x006DBC3C
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (this.usePause)
		{
			pkEntity.Pause(IntMath.Float2Int(this.pauseTime * (float)GlobalLogic.VALUE_1000), true);
		}
		else
		{
			pkEntity.DealEffectFrame(pkEntity, this.effectID, this.buffTime, false, this.useBuffAni, this.finishDelete, this.finishDeleteAll);
		}
		if (this.mechanismId > 0)
		{
			pkEntity.TryAddMechanism(this.mechanismId);
		}
	}

	// Token: 0x06016A6D RID: 92781 RVA: 0x006DD8B7 File Offset: 0x006DBCB7
	public override void PreparePreload(BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
	{
		if (useCube)
		{
			return;
		}
		PreloadManager.PreloadEffectID(this.effectID, frameMgr, fileCache);
	}

	// Token: 0x04010252 RID: 66130
	public int effectID;

	// Token: 0x04010253 RID: 66131
	public int buffTime;

	// Token: 0x04010254 RID: 66132
	private bool useBuffAni = true;

	// Token: 0x04010255 RID: 66133
	private bool usePause;

	// Token: 0x04010256 RID: 66134
	private float pauseTime;

	// Token: 0x04010257 RID: 66135
	private bool finishDelete;

	// Token: 0x04010258 RID: 66136
	private bool finishDeleteAll;

	// Token: 0x04010259 RID: 66137
	private int mechanismId;
}
