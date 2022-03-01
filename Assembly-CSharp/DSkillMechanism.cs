using System;

// Token: 0x02004BD4 RID: 19412
[Serializable]
public class DSkillMechanism : DSkillFrameEvent
{
	// Token: 0x04013ACE RID: 80590
	public int id;

	// Token: 0x04013ACF RID: 80591
	public float time;

	// Token: 0x04013AD0 RID: 80592
	public int level = 1;

	// Token: 0x04013AD1 RID: 80593
	public bool levelBySkill;

	// Token: 0x04013AD2 RID: 80594
	public bool phaseDelete;

	// Token: 0x04013AD3 RID: 80595
	public bool finishDeleteAll;
}
