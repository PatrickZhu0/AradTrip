using System;
using UnityEngine;

// Token: 0x02004213 RID: 16915
public class BeSimpleScaleBy : BeSimpleAction
{
	// Token: 0x060176AC RID: 95916 RVA: 0x00731ED4 File Offset: 0x007302D4
	public static BeSimpleScaleBy Create(GameObject entity, int dur, VInt curScale, VInt deltaScale, int delay = 0)
	{
		return new BeSimpleScaleBy
		{
			duration = dur,
			delay = delay,
			targetGameObject = entity,
			startScale = curScale,
			deltaScale = deltaScale
		};
	}

	// Token: 0x060176AD RID: 95917 RVA: 0x00731F10 File Offset: 0x00730310
	public sealed override void OnUpdate(VFactor process)
	{
		float num = this.startScale.scalar + this.deltaScale.scalar * process.single;
		this.tmpScale.x = num;
		this.tmpScale.y = num;
		this.tmpScale.z = num;
		if (this.targetGameObject != null)
		{
			this.targetGameObject.transform.localScale = this.tmpScale;
		}
	}

	// Token: 0x04010D09 RID: 68873
	protected VInt startScale;

	// Token: 0x04010D0A RID: 68874
	protected VInt deltaScale;

	// Token: 0x04010D0B RID: 68875
	protected Vector3 tmpScale;
}
