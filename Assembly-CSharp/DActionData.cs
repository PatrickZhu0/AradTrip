using System;

// Token: 0x02004BD0 RID: 19408
[Serializable]
public class DActionData : DSkillFrameEvent
{
	// Token: 0x04013AB5 RID: 80565
	public BeActionType actionType;

	// Token: 0x04013AB6 RID: 80566
	public float duration;

	// Token: 0x04013AB7 RID: 80567
	public float deltaScale;

	// Token: 0x04013AB8 RID: 80568
	public Vec3 deltaPos;

	// Token: 0x04013AB9 RID: 80569
	public bool ignoreBlock = true;
}
