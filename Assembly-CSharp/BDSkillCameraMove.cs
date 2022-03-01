using System;

// Token: 0x020040FF RID: 16639
public class BDSkillCameraMove : BDEventBase
{
	// Token: 0x06016A6E RID: 92782 RVA: 0x006DD8CD File Offset: 0x006DBCCD
	public BDSkillCameraMove(float off, float dur, bool newoff)
	{
		this.offset = off;
		this.duration = dur;
		this.newOffset = newoff;
	}

	// Token: 0x06016A6F RID: 92783 RVA: 0x006DD8EC File Offset: 0x006DBCEC
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = pkEntity as BeActor;
		if (beActor != null && beActor.isLocalActor && beActor.CurrentBeScene != null && beActor.CurrentBeScene.currentGeScene != null && beActor.CurrentBeScene.currentGeScene.GetCamera() != null && beActor.CurrentBeScene.currentGeScene.GetCamera().GetController() != null)
		{
			GeCameraControllerScroll controller = beActor.CurrentBeScene.currentGeScene.GetCamera().GetController();
			float num = this.offset * ((!pkEntity.GetFace()) ? 1f : -1f);
			if (this.newOffset)
			{
				float num2 = controller.GetOffset();
				num -= num2;
			}
			controller.MoveCamera(num, this.duration);
		}
	}

	// Token: 0x0401025A RID: 66138
	public float offset;

	// Token: 0x0401025B RID: 66139
	public float duration;

	// Token: 0x0401025C RID: 66140
	public bool newOffset;
}
