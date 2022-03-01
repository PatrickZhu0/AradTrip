using System;
using UnityEngine;

// Token: 0x02004BC2 RID: 19394
[Serializable]
public class DSkillSfx : DSkillFrameEvent
{
	// Token: 0x0601C76E RID: 116590 RVA: 0x0089F520 File Offset: 0x0089D920
	public override void copyFrameEvent(DSkillFrameEvent src)
	{
		base.copyFrameEvent(src);
		DSkillSfx dskillSfx = src as DSkillSfx;
		this.soundClip = dskillSfx.soundClip;
		this.soundClipAsset = dskillSfx.soundClipAsset;
		this.loop = dskillSfx.loop;
		this.soundID = dskillSfx.soundID;
		this.useActorSpeed = dskillSfx.useActorSpeed;
		this.phaseFinishDelete = dskillSfx.phaseFinishDelete;
		this.finishDelete = dskillSfx.finishDelete;
		this.volume = dskillSfx.volume;
	}

	// Token: 0x04013A5F RID: 80479
	public Object soundClip;

	// Token: 0x04013A60 RID: 80480
	public DAssetObject soundClipAsset;

	// Token: 0x04013A61 RID: 80481
	public bool loop;

	// Token: 0x04013A62 RID: 80482
	public int soundID;

	// Token: 0x04013A63 RID: 80483
	public bool useActorSpeed;

	// Token: 0x04013A64 RID: 80484
	public bool phaseFinishDelete;

	// Token: 0x04013A65 RID: 80485
	public bool finishDelete;

	// Token: 0x04013A66 RID: 80486
	public float volume = 1f;
}
