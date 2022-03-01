using System;
using UnityEngine;

// Token: 0x02004BA7 RID: 19367
[Serializable]
public class EffectsFrames
{
	// Token: 0x0601C75C RID: 116572 RVA: 0x0089EE94 File Offset: 0x0089D294
	public void Copy(EffectsFrames src)
	{
		this.name = src.name;
		this.effectResID = src.effectResID;
		this.startFrames = src.startFrames;
		this.endFrames = src.endFrames;
		this.attachname = src.attachname;
		this.playtype = src.playtype;
		this.timetype = src.timetype;
		this.time = src.time;
		this.effectGameObjectPrefeb = src.effectGameObjectPrefeb;
		this.effectAsset = src.effectAsset;
		this.attachPoint = src.attachPoint;
		this.localPosition = src.localPosition;
		this.localRotation = src.localRotation;
		this.localScale = src.localScale;
		this.effecttype = src.effecttype;
		this.useActorSpeed = src.useActorSpeed;
	}

	// Token: 0x0401394A RID: 80202
	public string name;

	// Token: 0x0401394B RID: 80203
	public int effectResID;

	// Token: 0x0401394C RID: 80204
	public int startFrames;

	// Token: 0x0401394D RID: 80205
	public int endFrames;

	// Token: 0x0401394E RID: 80206
	public string attachname;

	// Token: 0x0401394F RID: 80207
	public EffectPlayType playtype;

	// Token: 0x04013950 RID: 80208
	public EffectTimeType timetype;

	// Token: 0x04013951 RID: 80209
	public float time;

	// Token: 0x04013952 RID: 80210
	public GameObject effectGameObjectPrefeb;

	// Token: 0x04013953 RID: 80211
	public DAssetObject effectAsset;

	// Token: 0x04013954 RID: 80212
	public EffectAttachPoint attachPoint;

	// Token: 0x04013955 RID: 80213
	public Vector3 localPosition = Vector3.zero;

	// Token: 0x04013956 RID: 80214
	public Quaternion localRotation = Quaternion.identity;

	// Token: 0x04013957 RID: 80215
	public Vector3 localScale = Vector3.one;

	// Token: 0x04013958 RID: 80216
	public int effecttype;

	// Token: 0x04013959 RID: 80217
	public bool loop;

	// Token: 0x0401395A RID: 80218
	public bool loopLoop = true;

	// Token: 0x0401395B RID: 80219
	public bool onlyLocalSee;

	// Token: 0x0401395C RID: 80220
	public bool useActorSpeed;

	// Token: 0x0401395D RID: 80221
	[NonSerialized]
	public static readonly EffectsFrames Default = new EffectsFrames();
}
