using System;

// Token: 0x02004BD2 RID: 19410
[DSFFrameEventType("AddBuffInfoOrBuff")]
[Serializable]
public class DSkillBuff : DSkillFrameEvent
{
	// Token: 0x04013ABF RID: 80575
	public float buffTime;

	// Token: 0x04013AC0 RID: 80576
	public int buffID;

	// Token: 0x04013AC1 RID: 80577
	public bool phaseDelete;

	// Token: 0x04013AC2 RID: 80578
	public int[] buffInfoList = new int[0];

	// Token: 0x04013AC3 RID: 80579
	public bool finishDeleteAll;

	// Token: 0x04013AC4 RID: 80580
	public int level = 1;

	// Token: 0x04013AC5 RID: 80581
	public bool levelBySkill;
}
