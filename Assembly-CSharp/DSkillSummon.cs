using System;

// Token: 0x02004BD3 RID: 19411
[DSFFrameEventType("DoSummon")]
[Serializable]
public class DSkillSummon : DSkillFrameEvent
{
	// Token: 0x04013AC6 RID: 80582
	public int summonID;

	// Token: 0x04013AC7 RID: 80583
	public int summonLevel;

	// Token: 0x04013AC8 RID: 80584
	public bool levelGrowBySkill;

	// Token: 0x04013AC9 RID: 80585
	public int summonNum;

	// Token: 0x04013ACA RID: 80586
	public int posType;

	// Token: 0x04013ACB RID: 80587
	public int[] posType2 = new int[0];

	// Token: 0x04013ACC RID: 80588
	public bool isSameFace = true;

	// Token: 0x04013ACD RID: 80589
	public int summonNumLimit;
}
