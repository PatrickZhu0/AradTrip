using System;

// Token: 0x02000179 RID: 377
[Serializable]
public class InputSlotContinueClickMap
{
	// Token: 0x040007D6 RID: 2006
	public string name;

	// Token: 0x040007D7 RID: 2007
	public bool isNormal = true;

	// Token: 0x040007D8 RID: 2008
	public int normalClickSlot;

	// Token: 0x040007D9 RID: 2009
	public bool isConClick;

	// Token: 0x040007DA RID: 2010
	public InputSkillComboData[] skillComboData = new InputSkillComboData[0];
}
