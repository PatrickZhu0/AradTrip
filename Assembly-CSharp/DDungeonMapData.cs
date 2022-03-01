using System;
using UnityEngine;

// Token: 0x02004B5E RID: 19294
public class DDungeonMapData : ScriptableObject
{
	// Token: 0x04013821 RID: 79905
	public int weith;

	// Token: 0x04013822 RID: 79906
	public int heigth;

	// Token: 0x04013823 RID: 79907
	public int dungeonid;

	// Token: 0x04013824 RID: 79908
	public DDungeonMapUnitData[] dungeonList = new DDungeonMapUnitData[0];
}
