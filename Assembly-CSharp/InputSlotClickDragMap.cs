using System;

// Token: 0x02000174 RID: 372
[Serializable]
public class InputSlotClickDragMap
{
	// Token: 0x040007C1 RID: 1985
	public string name;

	// Token: 0x040007C2 RID: 1986
	public bool isClick = true;

	// Token: 0x040007C3 RID: 1987
	public int dragClickSlot = 1;

	// Token: 0x040007C4 RID: 1988
	public bool isDragDown;

	// Token: 0x040007C5 RID: 1989
	public InputSkillComboData[] drageDownList = new InputSkillComboData[0];

	// Token: 0x040007C6 RID: 1990
	public bool isDragUp;

	// Token: 0x040007C7 RID: 1991
	public InputSkillComboData[] drageUpList = new InputSkillComboData[0];
}
