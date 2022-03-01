using System;

// Token: 0x02000D2F RID: 3375
public struct MyImage
{
	// Token: 0x060089DD RID: 35293 RVA: 0x00190A6C File Offset: 0x0018EE6C
	public MyImage(Vec3 position, float passedTime, int actorID, int hitEffectType, int animCurveIndex)
	{
		this.position = position;
		this.passedTime = passedTime;
		this.actorID = actorID;
		this.hitEffectType = hitEffectType;
		this.animCurveIndex = animCurveIndex;
	}

	// Token: 0x04004352 RID: 17234
	public Vec3 position;

	// Token: 0x04004353 RID: 17235
	public float passedTime;

	// Token: 0x04004354 RID: 17236
	public int actorID;

	// Token: 0x04004355 RID: 17237
	public int hitEffectType;

	// Token: 0x04004356 RID: 17238
	public int animCurveIndex;
}
