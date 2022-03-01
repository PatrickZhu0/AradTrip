using System;
using UnityEngine;

// Token: 0x02004131 RID: 16689
public class BeAttachFrames
{
	// Token: 0x040103B2 RID: 66482
	public string name;

	// Token: 0x040103B3 RID: 66483
	public int resID;

	// Token: 0x040103B4 RID: 66484
	public float start;

	// Token: 0x040103B5 RID: 66485
	public float end;

	// Token: 0x040103B6 RID: 66486
	public string attachName;

	// Token: 0x040103B7 RID: 66487
	public GameObject entityPrefab;

	// Token: 0x040103B8 RID: 66488
	public DAssetObject entityAsset;

	// Token: 0x040103B9 RID: 66489
	public BeAnimationFrame[] animations = new BeAnimationFrame[0];
}
