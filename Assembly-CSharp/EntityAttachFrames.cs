using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004BB0 RID: 19376
[Serializable]
public class EntityAttachFrames
{
	// Token: 0x0601C763 RID: 116579 RVA: 0x0089F290 File Offset: 0x0089D690
	public void Copy(EntityAttachFrames src)
	{
		this.name = src.name;
		this.resID = src.resID;
		this.start = src.start;
		this.end = src.end;
		this.attachName = src.attachName;
		this.entityPrefab = src.entityPrefab;
		this.entityAsset = src.entityAsset;
		this.trans = src.trans;
		List<AnimationFrames> list = new List<AnimationFrames>();
		for (int i = 0; i < src.animations.Length; i++)
		{
			AnimationFrames animationFrames = new AnimationFrames();
			animationFrames.Copy(src.animations[i]);
			list.Add(animationFrames);
		}
		this.animations = list.ToArray();
	}

	// Token: 0x040139AD RID: 80301
	public string name;

	// Token: 0x040139AE RID: 80302
	public int resID;

	// Token: 0x040139AF RID: 80303
	public float start;

	// Token: 0x040139B0 RID: 80304
	public float end;

	// Token: 0x040139B1 RID: 80305
	public string attachName;

	// Token: 0x040139B2 RID: 80306
	public GameObject entityPrefab;

	// Token: 0x040139B3 RID: 80307
	public DAssetObject entityAsset;

	// Token: 0x040139B4 RID: 80308
	public TransformParam trans;

	// Token: 0x040139B5 RID: 80309
	public AnimationFrames[] animations = new AnimationFrames[0];
}
