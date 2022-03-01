using System;

// Token: 0x0200420F RID: 16911
public class BeScaleBy : BeAction
{
	// Token: 0x060176A3 RID: 95907 RVA: 0x00731D74 File Offset: 0x00730174
	public static BeScaleBy Create(BeEntity entity, int dur, VInt curScale, VInt deltaScale)
	{
		return new BeScaleBy
		{
			duration = dur,
			target = entity,
			startScale = curScale,
			deltaScale = deltaScale
		};
	}

	// Token: 0x060176A4 RID: 95908 RVA: 0x00731DA8 File Offset: 0x007301A8
	public sealed override void OnUpdate(VFactor process)
	{
		VInt scale = this.startScale + this.deltaScale.i * process;
		if (this.target != null)
		{
			this.target.SetScale(scale);
		}
	}

	// Token: 0x04010D04 RID: 68868
	protected VInt startScale;

	// Token: 0x04010D05 RID: 68869
	protected VInt deltaScale;
}
