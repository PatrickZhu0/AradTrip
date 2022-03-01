using System;
using ProtoTable;

// Token: 0x02004285 RID: 17029
public class Mechanism1060 : BeMechanism
{
	// Token: 0x06017903 RID: 96515 RVA: 0x00740C15 File Offset: 0x0073F015
	public Mechanism1060(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017904 RID: 96516 RVA: 0x00740C2C File Offset: 0x0073F02C
	public override void OnInit()
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.addValueFactor = new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017905 RID: 96517 RVA: 0x00740C6F File Offset: 0x0073F06F
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this.onDamage));
	}

	// Token: 0x06017906 RID: 96518 RVA: 0x00740CA4 File Offset: 0x0073F0A4
	private void onDamage(object[] args)
	{
		BeActor beActor = args[1] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.IsMonster())
		{
			return;
		}
		EffectTable.eDamageType eDamageType = (EffectTable.eDamageType)args[3];
		int[] array = (int[])args[0];
		int num = array[0];
		if (eDamageType == EffectTable.eDamageType.MAGIC)
		{
			int num2 = beActor.GetEntityData().battleData.initMagicDefence - beActor.GetEntityData().battleData.magicDefence;
			if (num2 > 0)
			{
				int num3 = num2 * this.addValueFactor;
				num += num3;
			}
		}
		else
		{
			int num4 = beActor.GetEntityData().battleData.initDefence - beActor.GetEntityData().battleData.defence;
			if (num4 > 0)
			{
				int num5 = num4 * this.addValueFactor;
				num += num5;
			}
		}
		array[0] = num;
	}

	// Token: 0x04010EE9 RID: 69353
	private VFactor addValueFactor = VFactor.zero;
}
