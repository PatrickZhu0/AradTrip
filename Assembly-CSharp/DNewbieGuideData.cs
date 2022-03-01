using System;
using UnityEngine;

// Token: 0x0200101C RID: 4124
public class DNewbieGuideData : ScriptableObject
{
	// Token: 0x040055E5 RID: 21989
	public string GuideName;

	// Token: 0x040055E6 RID: 21990
	public NewbieDataUnitData[] UnitData = new NewbieDataUnitData[0];

	// Token: 0x040055E7 RID: 21991
	public NewbieConditionData[] ConditionData = new NewbieConditionData[0];
}
