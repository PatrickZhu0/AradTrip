using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200432E RID: 17198
public class Mechanism17 : BeMechanism
{
	// Token: 0x06017CAE RID: 97454 RVA: 0x00758AF7 File Offset: 0x00756EF7
	public Mechanism17(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CAF RID: 97455 RVA: 0x00758B18 File Offset: 0x00756F18
	public override void OnInit()
	{
		this.startLevel = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.endLevel = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.percent = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (this.data.ValueD.Count <= 0 || (this.data.ValueD.Count > 0 && TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 0))
		{
			this.monsterType.Add(UnitTable.eType.BOSS);
			this.monsterType.Add(UnitTable.eType.ELITE);
			this.monsterType.Add(UnitTable.eType.MONSTER);
		}
		else
		{
			for (int i = 0; i < this.data.ValueD.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
				if (valueFromUnionCell > 0)
				{
					this.monsterType.Add((UnitTable.eType)valueFromUnionCell);
				}
			}
		}
	}

	// Token: 0x06017CB0 RID: 97456 RVA: 0x00758C75 File Offset: 0x00757075
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.Deal(base.owner);
		this.handleB = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null)
			{
				this.Deal(beProjectile);
			}
		});
	}

	// Token: 0x06017CB1 RID: 97457 RVA: 0x00758CAE File Offset: 0x007570AE
	private void Deal(BeEntity entity)
	{
		this.handleA = entity.RegisterEvent(BeEventType.onAfterFinalDamage, delegate(object[] args)
		{
			BeActor beActor = args[1] as BeActor;
			if (beActor != null)
			{
				BeEntityData entityData = beActor.GetEntityData();
				int num = entityData.level;
				if (num < this.startLevel || num > this.endLevel || !this.monsterType.Contains((UnitTable.eType)entityData.type))
				{
					return;
				}
				int[] array = (int[])args[0];
				int i = array[0];
				array[0] = i * (VFactor.one + VFactor.NewVFactor((long)this.percent, (long)GlobalLogic.VALUE_1000));
			}
		});
	}

	// Token: 0x040111E0 RID: 70112
	private int startLevel;

	// Token: 0x040111E1 RID: 70113
	private int endLevel;

	// Token: 0x040111E2 RID: 70114
	private CrypticInt32 percent = 0;

	// Token: 0x040111E3 RID: 70115
	private List<UnitTable.eType> monsterType = new List<UnitTable.eType>();
}
