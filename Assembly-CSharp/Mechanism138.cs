using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004310 RID: 17168
public class Mechanism138 : BeMechanism
{
	// Token: 0x06017C0A RID: 97290 RVA: 0x00753DA5 File Offset: 0x007521A5
	public Mechanism138(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C0B RID: 97291 RVA: 0x00753DE0 File Offset: 0x007521E0
	public override void OnInit()
	{
		base.OnInit();
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.timeAcc = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count > 0)
		{
			this.targetCount = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x06017C0C RID: 97292 RVA: 0x00753EB4 File Offset: 0x007522B4
	public override void OnStart()
	{
		base.OnStart();
		this.curTimeAcc = this.timeAcc;
		int num = 0;
		int num2 = GlobalLogic.VALUE_1000;
		int num3 = GlobalLogic.VALUE_1000;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism1005 mechanism = base.owner.MechanismList[i] as Mechanism1005;
			if (mechanism != null)
			{
				if (!mechanism.impactMechanismIdList.Contains(this.mechianismID))
				{
					num += mechanism.addEntityCount;
					num2 += mechanism.addRadius;
					num3 += mechanism.addTimeAccRate;
				}
			}
		}
		if (num2 == GlobalLogic.VALUE_1000 && num3 == GlobalLogic.VALUE_1000 && num == 0)
		{
			BeActor beActor = base.owner.GetOwner() as BeActor;
			if (beActor != null)
			{
				for (int j = 0; j < beActor.MechanismList.Count; j++)
				{
					Mechanism1005 mechanism2 = beActor.MechanismList[j] as Mechanism1005;
					if (mechanism2 != null)
					{
						if (mechanism2.impactMechanismIdList.Contains(this.mechianismID))
						{
							num += mechanism2.addEntityCount;
							num2 += mechanism2.addRadius;
							num3 += mechanism2.addTimeAccRate;
						}
					}
				}
			}
		}
		this.radius = this.radius.i * VFactor.NewVFactor(num2, GlobalLogic.VALUE_1000);
		this.targetCount += num;
		this.timeAcc *= VFactor.NewVFactor(num3, GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017C0D RID: 97293 RVA: 0x00754061 File Offset: 0x00752461
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateCheckTime(deltaTime);
	}

	// Token: 0x06017C0E RID: 97294 RVA: 0x00754071 File Offset: 0x00752471
	protected void UpdateCheckTime(int deltaTime)
	{
		if (this.curTimeAcc >= this.timeAcc)
		{
			this.curTimeAcc -= this.timeAcc;
			this.DoAttack();
		}
		else
		{
			this.curTimeAcc += deltaTime;
		}
	}

	// Token: 0x06017C0F RID: 97295 RVA: 0x007540B0 File Offset: 0x007524B0
	protected void DoAttack()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 position = base.owner.GetPosition();
		position.z = 0;
		int num = 0;
		base.owner.CurrentBeScene.FindActorInRange(list, position, this.radius, -1, 0);
		for (int i = 0; i < list.Count; i++)
		{
			if (num < this.targetCount)
			{
				BeActor beActor = list[i];
				if (!beActor.IsDead() && beActor.GetCamp() != base.owner.GetCamp() && beActor.GetLifeState() == 2)
				{
					BeActor beActor2 = (BeActor)base.owner.GetOwner();
					if (beActor2 != null && beActor.stateController.CanBeHit())
					{
						num++;
						VInt3 position2 = beActor.GetPosition();
						position2.z = 0;
						beActor2.AddEntity(this.entityId, position2, this.level, 0);
					}
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011140 RID: 69952
	protected VInt radius = 3000;

	// Token: 0x04011141 RID: 69953
	protected int entityId = 63610;

	// Token: 0x04011142 RID: 69954
	protected int targetCount = 9999;

	// Token: 0x04011143 RID: 69955
	public int timeAcc = 1000;

	// Token: 0x04011144 RID: 69956
	protected int curTimeAcc;
}
