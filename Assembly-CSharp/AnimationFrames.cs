using System;
using UnityEngine;

// Token: 0x02004BAF RID: 19375
[Serializable]
public class AnimationFrames
{
	// Token: 0x0601C761 RID: 116577 RVA: 0x0089F224 File Offset: 0x0089D624
	public void Copy(AnimationFrames src)
	{
		this.start = src.start;
		this.anim = src.anim;
		this.blend = src.blend;
		this.mode = src.mode;
		this.speed = src.speed;
		this.clip = src.clip;
	}

	// Token: 0x040139A7 RID: 80295
	public float start;

	// Token: 0x040139A8 RID: 80296
	public string anim;

	// Token: 0x040139A9 RID: 80297
	public float blend = 0.1f;

	// Token: 0x040139AA RID: 80298
	public WrapMode mode;

	// Token: 0x040139AB RID: 80299
	public float speed = 1f;

	// Token: 0x040139AC RID: 80300
	public AnimationClip clip;
}
