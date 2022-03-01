using System;

// Token: 0x020040F8 RID: 16632
public class BDSceneShock : BDEventBase
{
	// Token: 0x06016A56 RID: 92758 RVA: 0x006DBD1D File Offset: 0x006DA11D
	public BDSceneShock(float t, float s, float xr, float yr)
	{
		this.time = t;
		this.speed = s;
		this.xrange = xr;
		this.yrange = yr;
		this.isNew = false;
	}

	// Token: 0x06016A57 RID: 92759 RVA: 0x006DBD4C File Offset: 0x006DA14C
	public BDSceneShock(float totalTime, int num, float xRange, float yRange, bool decelebrate, float xReduce, float yReduce, int mode, float radius = 1f)
	{
		this.time = totalTime;
		this.num = num;
		this.xrange = xRange;
		this.yrange = yRange;
		this.decelerate = decelebrate;
		this.xreduce = xReduce;
		this.yreduce = yReduce;
		this.mode = mode;
		this.radius = radius;
		this.isNew = true;
	}

	// Token: 0x06016A58 RID: 92760 RVA: 0x006DBDAC File Offset: 0x006DA1AC
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = pkEntity.GetTopOwner(pkEntity) as BeActor;
		if (beActor != null && beActor.isLocalActor)
		{
			this.PlayShockEffect(pkEntity);
		}
	}

	// Token: 0x06016A59 RID: 92761 RVA: 0x006DBDE8 File Offset: 0x006DA1E8
	private void PlayShockEffect(BeEntity pkEntity)
	{
		if (BattleMain.instance != null)
		{
			if (this.isNew)
			{
				BattleMain.instance.Main.currentGeScene.GetCamera().PlayShockEffect(this.time, this.num, this.xrange, this.yrange, this.decelerate, this.xreduce, this.yreduce, this.mode, this.radius, pkEntity.IsCurSkillOpenShock());
			}
			else
			{
				BattleMain.instance.Main.currentGeScene.GetCamera().PlayShockEffect(this.time, this.speed, this.xrange, this.yrange, 2, pkEntity.IsCurSkillOpenShock());
			}
		}
	}

	// Token: 0x04010233 RID: 66099
	public float time;

	// Token: 0x04010234 RID: 66100
	public float speed;

	// Token: 0x04010235 RID: 66101
	public float xrange;

	// Token: 0x04010236 RID: 66102
	public float yrange;

	// Token: 0x04010237 RID: 66103
	public bool isNew;

	// Token: 0x04010238 RID: 66104
	public int mode;

	// Token: 0x04010239 RID: 66105
	public bool decelerate;

	// Token: 0x0401023A RID: 66106
	public float xreduce;

	// Token: 0x0401023B RID: 66107
	public float yreduce;

	// Token: 0x0401023C RID: 66108
	public int num;

	// Token: 0x0401023D RID: 66109
	public float radius;
}
