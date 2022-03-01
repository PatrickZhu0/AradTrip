using System;

// Token: 0x02004BC7 RID: 19399
[DSFFrameEventType("抓取帧")]
[Serializable]
public class DSkillFrameGrap : DSkillFrameEvent
{
	// Token: 0x04013A82 RID: 80514
	public DSFGrapOp op;

	// Token: 0x04013A83 RID: 80515
	public bool faceGraber;

	// Token: 0x04013A84 RID: 80516
	public Vec3 targetPos;

	// Token: 0x04013A85 RID: 80517
	public ActionType targetAction;
}
