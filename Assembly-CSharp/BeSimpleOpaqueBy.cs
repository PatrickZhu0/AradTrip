using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004214 RID: 16916
public class BeSimpleOpaqueBy : BeSimpleAction
{
	// Token: 0x060176AF RID: 95919 RVA: 0x00731F90 File Offset: 0x00730390
	public static BeSimpleOpaqueBy Create(GameObject entity, int dur, float curOpaque, float deltaOpaque, int delay = 0)
	{
		return new BeSimpleOpaqueBy
		{
			duration = dur,
			delay = delay,
			targetGameObject = entity,
			startOpaque = curOpaque,
			deltaOpaque = deltaOpaque
		};
	}

	// Token: 0x060176B0 RID: 95920 RVA: 0x00731FCC File Offset: 0x007303CC
	public sealed override void OnStart()
	{
		if (this.targetGameObject != null)
		{
			Text componentInChildren = this.targetGameObject.GetComponentInChildren<Text>(true);
			if (componentInChildren != null)
			{
				this.maskableGraphic = componentInChildren;
			}
			Image componentInChildren2 = this.targetGameObject.GetComponentInChildren<Image>(true);
			if (componentInChildren2 != null)
			{
				this.maskableGraphic = componentInChildren2;
			}
			if (this.maskableGraphic != null)
			{
				this.tmpColor = this.maskableGraphic.color;
				this.tmpColor.a = this.startOpaque;
				this.maskableGraphic.color = this.tmpColor;
			}
		}
	}

	// Token: 0x060176B1 RID: 95921 RVA: 0x00732070 File Offset: 0x00730470
	public sealed override void OnUpdate(VFactor process)
	{
		float a = this.startOpaque + this.deltaOpaque * process.single;
		this.tmpColor.a = a;
		if (this.maskableGraphic != null)
		{
			this.maskableGraphic.color = this.tmpColor;
		}
	}

	// Token: 0x04010D0C RID: 68876
	protected float startOpaque;

	// Token: 0x04010D0D RID: 68877
	protected float deltaOpaque;

	// Token: 0x04010D0E RID: 68878
	protected MaskableGraphic maskableGraphic;

	// Token: 0x04010D0F RID: 68879
	protected Color tmpColor;
}
