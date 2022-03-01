using System;
using UnityEngine;

// Token: 0x02004254 RID: 16980
public class Mechanism1015 : BeMechanism
{
	// Token: 0x060177EA RID: 96234 RVA: 0x00739FC8 File Offset: 0x007383C8
	public Mechanism1015(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177EB RID: 96235 RVA: 0x00739FF4 File Offset: 0x007383F4
	public override void OnInit()
	{
		base.OnInit();
		this.offsetY = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.speed = (float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f;
		this.targetSize = (float)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000f;
		this.restoreSpeed = (float)TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) / 1000f;
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		if (this.speed == 0f)
		{
			this.speed = 3f;
		}
		if (this.targetSize == 0f)
		{
			this.targetSize = 2.05f;
		}
	}

	// Token: 0x060177EC RID: 96236 RVA: 0x0073A11C File Offset: 0x0073851C
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.isLocalActor && base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null && base.owner.CurrentBeScene.currentGeScene.GetCamera() != null && base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController() != null)
		{
			Vector3 zero = Vector3.zero;
			if (this.offsetY != 0)
			{
				this.originalSize = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetCamera().orthographicSize;
				Vector3 vector = base.owner.GetPosition().vector3;
				Transform transform = Camera.main.transform;
				float num = (vector.x - transform.position.x) * (1f - this.targetSize / this.originalSize);
				float num2 = (vector.z - transform.position.z + (base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().m_CtrlOffset.z - 1f)) * (1f - this.targetSize / this.originalSize);
				zero..ctor(num, (float)this.offsetY / 1000f, num2);
			}
			base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().StartCameraPull(zero, this.speed, this.targetSize);
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.SkillCancel));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.SkillFinish));
	}

	// Token: 0x060177ED RID: 96237 RVA: 0x0073A300 File Offset: 0x00738700
	private void SkillCancel(object[] args)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		int num = (int)args[0];
		if (num != this.skillId)
		{
			return;
		}
		this.skillCancelFlag = true;
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().RestoreCameraPull(0f);
	}

	// Token: 0x060177EE RID: 96238 RVA: 0x0073A360 File Offset: 0x00738760
	private void SkillFinish(object[] args)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		int num = (int)args[0];
		if (num != this.skillId)
		{
			return;
		}
		this.skillCancelFlag = true;
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().RestoreCameraPull(0f);
	}

	// Token: 0x060177EF RID: 96239 RVA: 0x0073A3BF File Offset: 0x007387BF
	public override void OnFinish()
	{
		base.OnFinish();
		this.RestoreCamera();
	}

	// Token: 0x060177F0 RID: 96240 RVA: 0x0073A3D0 File Offset: 0x007387D0
	private void RestoreCamera()
	{
		if (this.skillCancelFlag)
		{
			return;
		}
		if (!base.owner.isLocalActor)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().RestoreCameraPull(this.restoreSpeed);
	}

	// Token: 0x04010E1B RID: 69147
	private int offsetY;

	// Token: 0x04010E1C RID: 69148
	private float speed = 3f;

	// Token: 0x04010E1D RID: 69149
	private float targetSize = 2.05f;

	// Token: 0x04010E1E RID: 69150
	private float restoreSpeed;

	// Token: 0x04010E1F RID: 69151
	private int skillId;

	// Token: 0x04010E20 RID: 69152
	private float originalSize = 3.05f;

	// Token: 0x04010E21 RID: 69153
	private bool skillCancelFlag;
}
