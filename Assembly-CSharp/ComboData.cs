using System;
using UnityEngine;

// Token: 0x02004AF7 RID: 19191
[Serializable]
public class ComboData
{
	// Token: 0x04013779 RID: 79737
	[SerializeField]
	public int skillGroupID;

	// Token: 0x0401377A RID: 79738
	[SerializeField]
	public int skillID;

	// Token: 0x0401377B RID: 79739
	[SerializeField]
	public int skillLevel;

	// Token: 0x0401377C RID: 79740
	[SerializeField]
	public int skillSlot;

	// Token: 0x0401377D RID: 79741
	[SerializeField]
	public int skillTime;

	// Token: 0x0401377E RID: 79742
	[SerializeField]
	public int waitInputTime;

	// Token: 0x0401377F RID: 79743
	[SerializeField]
	public int moveDir = -1;

	// Token: 0x04013780 RID: 79744
	[SerializeField]
	public int moveTime = -1;

	// Token: 0x04013781 RID: 79745
	[SerializeField]
	public int idleTime = -1;

	// Token: 0x04013782 RID: 79746
	[SerializeField]
	public int showUI = 1;

	// Token: 0x04013783 RID: 79747
	[SerializeField]
	public int faceRight = 1;

	// Token: 0x04013784 RID: 79748
	[SerializeField]
	public int sourceID;

	// Token: 0x04013785 RID: 79749
	[SerializeField]
	public int phase;
}
