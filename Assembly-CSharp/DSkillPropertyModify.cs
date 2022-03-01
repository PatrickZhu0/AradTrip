using System;

// Token: 0x02004BBF RID: 19391
[DSFFrameEventType("属性修改")]
[Serializable]
public class DSkillPropertyModify : DSkillFrameEvent
{
	// Token: 0x04013A45 RID: 80453
	public int tag;

	// Token: 0x04013A46 RID: 80454
	public DSkillPropertyModifyType modifyfliter;

	// Token: 0x04013A47 RID: 80455
	public float value;

	// Token: 0x04013A48 RID: 80456
	public float valueAcc;

	// Token: 0x04013A49 RID: 80457
	public float movedValue;

	// Token: 0x04013A4A RID: 80458
	public float movedValueAcc;

	// Token: 0x04013A4B RID: 80459
	public DModifyXBackward modifyXBackward;

	// Token: 0x04013A4C RID: 80460
	public float movedYValue;

	// Token: 0x04013A4D RID: 80461
	public float movedYValueAcc;

	// Token: 0x04013A4E RID: 80462
	public SUnion svalue;

	// Token: 0x04013A4F RID: 80463
	public bool jumpToTargetPos;

	// Token: 0x04013A50 RID: 80464
	public bool joyStickControl;

	// Token: 0x04013A51 RID: 80465
	public bool eachFrameModify;

	// Token: 0x04013A52 RID: 80466
	public bool useMovedYValue;
}
