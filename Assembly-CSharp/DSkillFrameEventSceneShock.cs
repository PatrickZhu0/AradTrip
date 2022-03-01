using System;

// Token: 0x02004BCD RID: 19405
[DSFFrameEventType("震屏帧")]
[Serializable]
public class DSkillFrameEventSceneShock : DSkillFrameEvent
{
	// Token: 0x0601C777 RID: 116599 RVA: 0x0089F66C File Offset: 0x0089DA6C
	public override void copyFrameEvent(DSkillFrameEvent src)
	{
		base.copyFrameEvent(src);
		DSkillFrameEventSceneShock dskillFrameEventSceneShock = src as DSkillFrameEventSceneShock;
		this.time = dskillFrameEventSceneShock.time;
		this.speed = dskillFrameEventSceneShock.speed;
		this.xrange = dskillFrameEventSceneShock.xrange;
		this.yrange = dskillFrameEventSceneShock.yrange;
		this.isNew = dskillFrameEventSceneShock.isNew;
		this.mode = dskillFrameEventSceneShock.mode;
		this.decelerate = dskillFrameEventSceneShock.decelerate;
		this.xreduce = dskillFrameEventSceneShock.xreduce;
		this.yreduce = dskillFrameEventSceneShock.yreduce;
		this.radius = dskillFrameEventSceneShock.radius;
		this.num = dskillFrameEventSceneShock.num;
	}

	// Token: 0x04013AA1 RID: 80545
	public float time;

	// Token: 0x04013AA2 RID: 80546
	public float speed;

	// Token: 0x04013AA3 RID: 80547
	public float xrange;

	// Token: 0x04013AA4 RID: 80548
	public float yrange;

	// Token: 0x04013AA5 RID: 80549
	public bool isNew;

	// Token: 0x04013AA6 RID: 80550
	public int mode;

	// Token: 0x04013AA7 RID: 80551
	public bool decelerate;

	// Token: 0x04013AA8 RID: 80552
	public float xreduce;

	// Token: 0x04013AA9 RID: 80553
	public float yreduce;

	// Token: 0x04013AAA RID: 80554
	public float radius;

	// Token: 0x04013AAB RID: 80555
	public int num;
}
