using System;
using UnityEngine;

// Token: 0x02004212 RID: 16914
public class BeSimpleMoveBy : BeSimpleAction
{
	// Token: 0x060176A9 RID: 95913 RVA: 0x00731E40 File Offset: 0x00730240
	public static BeSimpleMoveBy Create(GameObject entity, int dur, Vector3 curPos, Vector3 deltaPos, int delay = 0)
	{
		return new BeSimpleMoveBy
		{
			duration = dur,
			delay = delay,
			targetGameObject = entity,
			startPos = curPos,
			deltaPos = deltaPos
		};
	}

	// Token: 0x060176AA RID: 95914 RVA: 0x00731E7C File Offset: 0x0073027C
	public sealed override void OnUpdate(VFactor process)
	{
		Vector3 localPosition = this.startPos + this.deltaPos * process.single;
		if (this.targetGameObject != null)
		{
			this.targetGameObject.transform.localPosition = localPosition;
		}
	}

	// Token: 0x04010D07 RID: 68871
	protected Vector3 startPos;

	// Token: 0x04010D08 RID: 68872
	protected Vector3 deltaPos;
}
