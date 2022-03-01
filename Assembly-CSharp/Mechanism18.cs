using System;
using System.Collections.Generic;

// Token: 0x0200432F RID: 17199
public class Mechanism18 : BeMechanism
{
	// Token: 0x06017CB4 RID: 97460 RVA: 0x00758D87 File Offset: 0x00757187
	public Mechanism18(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CB5 RID: 97461 RVA: 0x00758DA8 File Offset: 0x007571A8
	public override void OnInit()
	{
		this.percent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this.monsterIDs.Add(valueFromUnionCell);
		}
	}

	// Token: 0x06017CB6 RID: 97462 RVA: 0x00758E32 File Offset: 0x00757232
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

	// Token: 0x06017CB7 RID: 97463 RVA: 0x00758E6B File Offset: 0x0075726B
	protected void Deal(BeEntity entity)
	{
		this.handleA = entity.RegisterEvent(BeEventType.onAfterFinalDamage, delegate(object[] args)
		{
			BeActor beActor = args[1] as BeActor;
			if (beActor != null)
			{
				BeEntityData entityData = beActor.GetEntityData();
				if (!BeUtility.IsMonsterIDEqualList(this.monsterIDs, entityData.simpleMonsterID))
				{
					return;
				}
				int[] array = (int[])args[0];
				int i = array[0];
				array[0] = i * (VFactor.one + VFactor.NewVFactor((long)this.percent, (long)GlobalLogic.VALUE_1000));
			}
		});
	}

	// Token: 0x040111E4 RID: 70116
	private CrypticInt32 percent = 0;

	// Token: 0x040111E5 RID: 70117
	private List<int> monsterIDs = new List<int>();
}
