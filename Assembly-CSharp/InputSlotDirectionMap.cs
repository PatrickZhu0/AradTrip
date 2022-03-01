using System;

// Token: 0x02000178 RID: 376
[Serializable]
public class InputSlotDirectionMap
{
	// Token: 0x040007D1 RID: 2001
	public string name;

	// Token: 0x040007D2 RID: 2002
	public bool isNormalSlot;

	// Token: 0x040007D3 RID: 2003
	public int normalClickSlot;

	// Token: 0x040007D4 RID: 2004
	public bool isDirectionCombo;

	// Token: 0x040007D5 RID: 2005
	public InputSkillDirectionComboData[] directionComboData = new InputSkillDirectionComboData[0];
}
