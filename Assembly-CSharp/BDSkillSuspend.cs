using System;

// Token: 0x020040F9 RID: 16633
public class BDSkillSuspend : BDEventBase
{
	// Token: 0x06016A5A RID: 92762 RVA: 0x006DBE9C File Offset: 0x006DA29C
	public BDSkillSuspend(int type)
	{
		this.suspendType = type;
	}

	// Token: 0x06016A5B RID: 92763 RVA: 0x006DBEB6 File Offset: 0x006DA2B6
	public BDSkillSuspend(int type, VInt3 targetPos, bool faceOffset, int targetAction)
	{
		this.suspendType = type;
		this.faceGraber = faceOffset;
		this.suspendTargetPos = targetPos;
		this.actionType = targetAction;
	}

	// Token: 0x06016A5C RID: 92764 RVA: 0x006DBEE8 File Offset: 0x006DA2E8
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = (BeActor)pkEntity;
		if (beActor == null)
		{
			return;
		}
		if (this.suspendType == 128)
		{
			if (!beActor.HasAttackEntityOnGrabCheck)
			{
				BeStateData rkData = new BeStateData(0, 0);
				beActor.sgForceSwitchState(rkData);
			}
		}
		else if (this.suspendType == 8)
		{
			if (!beActor.HasGrapedEntity())
			{
				BeStateData rkData2 = new BeStateData(0, 0);
				beActor.sgForceSwitchState(rkData2);
			}
		}
		else if (this.suspendType == 16 && beActor.stateController.IsGraping())
		{
			if (beActor.GrapedActorList != null)
			{
				beActor.grabPos = true;
				for (int i = 0; i < beActor.GrapedActorList.Count; i++)
				{
					BeActor beActor2 = beActor.GrapedActorList[i];
					if (beActor2 != null && !beActor2.IsDead())
					{
						if (this.faceGraber)
						{
							int num = beActor2.GetPosition().x - beActor.GetPosition().x;
							beActor2.SetFace(num >= 0, false, false);
						}
						VInt3 position = beActor.GetPosition();
						position.x += ((!beActor.GetFace()) ? (-this.suspendTargetPos.x) : this.suspendTargetPos.x);
						position.y += this.suspendTargetPos.y;
						position.z += this.suspendTargetPos.z;
						if (beActor2.CurrentBeScene == null || beActor2.GetGrabData() == null || !beActor2.GetGrabData().notGrabToBlock || !beActor2.CurrentBeScene.IsInBlockPlayer(position))
						{
							beActor2.SetPosition(position, true, true, false);
						}
						VInt3 position2 = beActor2.GetPosition();
						if (this.suspendTargetPos.z == 0 && position2.z != 0)
						{
							beActor2.SetPosition(new VInt3(position2.x, position2.y, 0), true, true, false);
						}
					}
				}
			}
		}
		else if (this.suspendType == 32 && beActor.stateController.IsGraping())
		{
			beActor.grabPos = false;
		}
		else if (this.suspendType == 64 && beActor.stateController.IsGraping() && beActor.GrapedActorList != null)
		{
			for (int j = 0; j < beActor.GrapedActorList.Count; j++)
			{
				BeActor beActor3 = beActor.GrapedActorList[j];
				if (beActor3 != null && !beActor3.IsDead())
				{
					beActor3.PlayAction((ActionType)this.actionType, 1f, false);
				}
			}
		}
	}

	// Token: 0x0401023E RID: 66110
	public int suspendType;

	// Token: 0x0401023F RID: 66111
	public bool faceGraber;

	// Token: 0x04010240 RID: 66112
	public VInt3 suspendTargetPos = VInt3.zero;

	// Token: 0x04010241 RID: 66113
	public int actionType;
}
