using System;
using UnityEngine;

// Token: 0x02000CD6 RID: 3286
[Serializable]
public class GeAnimDesc
{
	// Token: 0x060086D8 RID: 34520 RVA: 0x0017AA61 File Offset: 0x00178E61
	public GeAnimDesc(string clipName, int clipCRC32, GeAnimClipPlayMode playMode, float time, AnimationClip animClip, string animClipPath)
	{
		this.animClipName = clipName;
		this.aniClipCRC32 = clipCRC32;
		this.animPlayMode = playMode;
		this.timeLen = time;
		this.animClipData = animClip;
		this.animClipPath = animClipPath;
	}

	// Token: 0x040040C0 RID: 16576
	public string animClipName;

	// Token: 0x040040C1 RID: 16577
	public int aniClipCRC32;

	// Token: 0x040040C2 RID: 16578
	public GeAnimClipPlayMode animPlayMode;

	// Token: 0x040040C3 RID: 16579
	public float timeLen;

	// Token: 0x040040C4 RID: 16580
	public string animClipPath;

	// Token: 0x040040C5 RID: 16581
	[NonSerialized]
	public AnimationClip animClipData;
}
