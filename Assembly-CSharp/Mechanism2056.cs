using System;

// Token: 0x02004370 RID: 17264
public class Mechanism2056 : BeMechanism
{
	// Token: 0x06017E9D RID: 97949 RVA: 0x00766D2C File Offset: 0x0076512C
	public Mechanism2056(int mid, int lv) : base(mid, lv)
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (valueFromUnionCell != 0)
		{
			this.monsterID = valueFromUnionCell;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (valueFromUnionCell != 0)
		{
			this.bossID = valueFromUnionCell;
		}
	}

	// Token: 0x06017E9E RID: 97950 RVA: 0x00766DB8 File Offset: 0x007651B8
	public override void OnStart()
	{
		base.OnStart();
		BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(this.bossID);
		if (beActor != null)
		{
			this.mechanism = (beActor.GetMechanismByIndex(2057) as Mechanism2057);
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onCollide, delegate(object[] args)
		{
			BeEntity beEntity = args[0] as BeEntity;
			BeActor beActor2 = beEntity as BeActor;
			if (beActor2 != null && beActor2.isMainActor && beActor2.GetPID() == base.owner.GetOwner().GetPID())
			{
				base.owner.DoDead(false);
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			if (this.mechanism != null && this.mechanism.IsTimeStop())
			{
				return;
			}
			VInt3 vint = base.owner.CurrentBeScene.GetRandomPos(10);
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
			{
				vint = base.owner.GetPosition();
			}
			BeActor beActor2 = base.owner.GetOwner() as BeActor;
			if (beActor2 != null)
			{
				base.owner.CurrentBeScene.SummonMonster(this.monsterID, vint, 1, beActor2, false, 0, true, 0, false, false);
			}
		});
	}

	// Token: 0x06017E9F RID: 97951 RVA: 0x00766E3C File Offset: 0x0076523C
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04011368 RID: 70504
	private int monsterID = 81120011;

	// Token: 0x04011369 RID: 70505
	private int bossID = 87100031;

	// Token: 0x0401136A RID: 70506
	private Mechanism2057 mechanism;
}
