using System;
using UnityEngine;

// Token: 0x020044C5 RID: 17605
public class Skill3217 : BeSkill
{
	// Token: 0x060187F4 RID: 100340 RVA: 0x007A5D40 File Offset: 0x007A4140
	public Skill3217(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187F5 RID: 100341 RVA: 0x007A5D6C File Offset: 0x007A416C
	public override void OnStart()
	{
		this.time = 0;
		if (Camera.main != null && base.owner.isLocalActor)
		{
			this.originalSize = Camera.main.orthographicSize;
		}
		this.handle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			if (base.owner.isLocalActor)
			{
				string a = args[0] as string;
				if (a == "hideScene" && Camera.main != null && Camera.main.transform != null)
				{
					this.flag = true;
					Vector3 vector = base.owner.GetPosition().vector3;
					Transform transform = Camera.main.transform;
					float num = (vector.x - transform.position.x) * (1f - this.targetSize / this.originalSize);
					if (base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null && base.owner.CurrentBeScene.currentGeScene.GetCamera() != null && base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController() != null)
					{
						float num2 = (vector.z - transform.position.z + (base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().m_CtrlOffset.z - 1f)) * (1f - this.targetSize / this.originalSize);
						this.targetPos = new Vector3(num, 0f, num2);
					}
				}
				else if (a == "showScene" && Camera.main != null && Camera.main.transform != null)
				{
					this.ResetCamera();
				}
			}
		});
	}

	// Token: 0x060187F6 RID: 100342 RVA: 0x007A5DD0 File Offset: 0x007A41D0
	public override void OnUpdate(int iDeltime)
	{
		if (base.owner.isLocalActor)
		{
			base.OnUpdate(iDeltime);
			this.time += iDeltime;
			if (this.flag)
			{
				Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, this.targetPos, (float)this.time / 1000f * this.speed);
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, this.targetSize, (float)this.time / 1000f * this.speed);
			}
		}
	}

	// Token: 0x060187F7 RID: 100343 RVA: 0x007A5E7D File Offset: 0x007A427D
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x060187F8 RID: 100344 RVA: 0x007A5E9C File Offset: 0x007A429C
	public override void OnCancel()
	{
		this.ResetCamera();
		this.RemoveHandle();
		base.OnCancel();
	}

	// Token: 0x060187F9 RID: 100345 RVA: 0x007A5EB0 File Offset: 0x007A42B0
	public override void OnFinish()
	{
		this.ResetCamera();
		this.RemoveHandle();
		base.OnFinish();
	}

	// Token: 0x060187FA RID: 100346 RVA: 0x007A5EC4 File Offset: 0x007A42C4
	private void ResetCamera()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		this.flag = false;
		Camera main = Camera.main;
		if (main != null)
		{
			main.orthographicSize = this.originalSize;
			main.transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x04011ACC RID: 72396
	private BeEventHandle handle;

	// Token: 0x04011ACD RID: 72397
	private float targetSize = 2.05f;

	// Token: 0x04011ACE RID: 72398
	private float originalSize = 3.05f;

	// Token: 0x04011ACF RID: 72399
	private Vector3 targetPos;

	// Token: 0x04011AD0 RID: 72400
	private bool flag;

	// Token: 0x04011AD1 RID: 72401
	private float speed = 3f;

	// Token: 0x04011AD2 RID: 72402
	private int time;
}
