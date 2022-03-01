using System;

// Token: 0x02004BCB RID: 19403
[DSFFrameEventType("状态操作帧")]
[Serializable]
public class DSkillFrameStateOp : DSkillFrameEvent
{
	// Token: 0x04013A9A RID: 80538
	public DSFEntityStateOp op;

	// Token: 0x04013A9B RID: 80539
	public DSFEntityStates state;

	// Token: 0x04013A9C RID: 80540
	public int idata1;

	// Token: 0x04013A9D RID: 80541
	public int idata2;

	// Token: 0x04013A9E RID: 80542
	public float fdata1;

	// Token: 0x04013A9F RID: 80543
	public float fdata2;

	// Token: 0x04013AA0 RID: 80544
	public DSFEntityStateTag statetag;
}
