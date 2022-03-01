using System;

// Token: 0x02004210 RID: 16912
public class BeScaleTo : BeScaleBy
{
	// Token: 0x060176A6 RID: 95910 RVA: 0x00731DF8 File Offset: 0x007301F8
	public new static BeScaleTo Create(BeEntity entity, int dur, VInt curScale, VInt toScale)
	{
		return new BeScaleTo
		{
			duration = dur,
			target = entity,
			startScale = curScale,
			deltaScale = toScale - curScale
		};
	}
}
