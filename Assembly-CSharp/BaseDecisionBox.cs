using System;
using UnityEngine;

// Token: 0x02004B9E RID: 19358
[Serializable]
public class BaseDecisionBox
{
	// Token: 0x0401392D RID: 80173
	public ShapeBox[] boxs = new ShapeBox[0];

	// Token: 0x0401392E RID: 80174
	[HideInInspector]
	public bool hasHit;

	// Token: 0x0401392F RID: 80175
	[HideInInspector]
	public bool blockToggle;
}
