using System;

// Token: 0x02004322 RID: 17186
public class Mechanism150 : BeMechanism
{
	// Token: 0x06017C7B RID: 97403 RVA: 0x00757647 File Offset: 0x00755A47
	public Mechanism150(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C7C RID: 97404 RVA: 0x0075765C File Offset: 0x00755A5C
	public override void OnInit()
	{
		base.OnInit();
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addHpRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.addHp = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017C7D RID: 97405 RVA: 0x007576F1 File Offset: 0x00755AF1
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.monsterID))
			{
				int maxHP = beActor.GetEntityData().GetMaxHP();
				if (this.addHpRate != VFactor.zero)
				{
					beActor.GetEntityData().SetHP(maxHP * (VFactor.one + this.addHpRate));
					beActor.GetEntityData().SetMaxHP(maxHP * (VFactor.one + this.addHpRate));
				}
				if (this.addHp != 0)
				{
					beActor.GetEntityData().SetHP(maxHP + this.addHp);
					beActor.GetEntityData().SetMaxHP(maxHP + this.addHp);
				}
			}
		});
	}

	// Token: 0x040111AD RID: 70061
	private int monsterID;

	// Token: 0x040111AE RID: 70062
	private int addHp;

	// Token: 0x040111AF RID: 70063
	private VFactor addHpRate = VFactor.zero;
}
