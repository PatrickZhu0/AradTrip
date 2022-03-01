using System;

// Token: 0x02000D31 RID: 3377
public struct MyText
{
	// Token: 0x060089E6 RID: 35302 RVA: 0x0019140C File Offset: 0x0018F80C
	public MyText(float positionX, float positionY, float positionZ, int characterCount, float passedTime, int actorID, int hitEffectType, int animType, int animCurveIndex, int charIndex)
	{
		this.positionX = positionX;
		this.positionY = positionY;
		this.positionZ = positionZ;
		this.characterCount = characterCount;
		this.passedTime = passedTime;
		this.actorID = actorID;
		this.hitEffectType = hitEffectType;
		this.animType = animType;
		this.animCurveIndex = animCurveIndex;
		this.charIndex = charIndex;
	}

	// Token: 0x04004371 RID: 17265
	public int characterCount;

	// Token: 0x04004372 RID: 17266
	public float positionX;

	// Token: 0x04004373 RID: 17267
	public float positionY;

	// Token: 0x04004374 RID: 17268
	public float positionZ;

	// Token: 0x04004375 RID: 17269
	public float passedTime;

	// Token: 0x04004376 RID: 17270
	public int actorID;

	// Token: 0x04004377 RID: 17271
	public int hitEffectType;

	// Token: 0x04004378 RID: 17272
	public int animType;

	// Token: 0x04004379 RID: 17273
	public int animCurveIndex;

	// Token: 0x0400437A RID: 17274
	public int charIndex;
}
