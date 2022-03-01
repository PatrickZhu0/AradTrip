using System;
using UnityEngine;

// Token: 0x02004287 RID: 17031
public class Mechanism1062 : BeMechanism
{
	// Token: 0x0601790B RID: 96523 RVA: 0x00740E4F File Offset: 0x0073F24F
	public Mechanism1062(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601790C RID: 96524 RVA: 0x00740E59 File Offset: 0x0073F259
	public override void OnInit()
	{
		base.OnInit();
		this.nearValue = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
	}

	// Token: 0x0601790D RID: 96525 RVA: 0x00740E90 File Offset: 0x0073F290
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.isLocalActor)
		{
			Camera camera = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetCamera();
			this.tempValue = camera.nearClipPlane;
			camera.nearClipPlane = this.nearValue;
		}
	}

	// Token: 0x0601790E RID: 96526 RVA: 0x00740EE8 File Offset: 0x0073F2E8
	public override void OnFinish()
	{
		base.OnFinish();
		if (base.owner.isLocalActor)
		{
			Camera camera = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetCamera();
			camera.nearClipPlane = this.tempValue;
		}
	}

	// Token: 0x04010EEA RID: 69354
	private float nearValue;

	// Token: 0x04010EEB RID: 69355
	private float tempValue;
}
