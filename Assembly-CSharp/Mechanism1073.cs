using System;
using System.Collections.Generic;

// Token: 0x02004293 RID: 17043
public class Mechanism1073 : BeMechanism
{
	// Token: 0x06017946 RID: 96582 RVA: 0x007424CA File Offset: 0x007408CA
	public Mechanism1073(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017947 RID: 96583 RVA: 0x007424E0 File Offset: 0x007408E0
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.percentArr[i] = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true), GlobalLogic.VALUE_1000);
		}
	}

	// Token: 0x06017948 RID: 96584 RVA: 0x00742554 File Offset: 0x00740954
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeSummonMonsterAttach, new BeEventHandle.Del(this.ChangeSummonMonsterAttach));
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeSummonMonsterAddDamage, new BeEventHandle.Del(this.ChangeSummonMonsterAddDamage));
		this.handleC = base.owner.RegisterEvent(BeEventType.onChangeSummonMonsterAddCritiDamage, new BeEventHandle.Del(this.ChangeSummonMonsterAddCritiDamage));
	}

	// Token: 0x06017949 RID: 96585 RVA: 0x007425D0 File Offset: 0x007409D0
	protected void ChangeSummonMonsterAttach(object[] args)
	{
		BeEntity owner = base.owner.GetOwner();
		if (owner == null || owner.attribute == null || owner.attribute.battleData == null)
		{
			return;
		}
		List<AddDamageInfo> list = (List<AddDamageInfo>)args[0];
		List<AddDamageInfo> list2 = (List<AddDamageInfo>)args[1];
		for (int i = 0; i < owner.attribute.battleData.attachAddDamageFix.Count; i++)
		{
			list.Add(new AddDamageInfo
			{
				attackType = owner.attribute.battleData.attachAddDamageFix[i].attackType,
				value = owner.attribute.battleData.attachAddDamageFix[i].value * this.percentArr[0]
			});
		}
		for (int j = 0; j < owner.attribute.battleData.attachAddDamagePercent.Count; j++)
		{
			list2.Add(new AddDamageInfo
			{
				attackType = owner.attribute.battleData.attachAddDamagePercent[j].attackType,
				value = owner.attribute.battleData.attachAddDamagePercent[j].value * this.percentArr[0]
			});
		}
	}

	// Token: 0x0601794A RID: 96586 RVA: 0x00742768 File Offset: 0x00740B68
	protected void ChangeSummonMonsterAddDamage(object[] args)
	{
		BeEntity owner = base.owner.GetOwner();
		if (owner == null || owner.attribute == null || owner.attribute.battleData == null)
		{
			return;
		}
		List<AddDamageInfo> list = (List<AddDamageInfo>)args[0];
		List<AddDamageInfo> list2 = (List<AddDamageInfo>)args[1];
		for (int i = 0; i < owner.attribute.battleData.addDamageFix.Count; i++)
		{
			list.Add(new AddDamageInfo
			{
				attackType = owner.attribute.battleData.addDamageFix[i].attackType,
				value = owner.attribute.battleData.addDamageFix[i].value * this.percentArr[1]
			});
		}
		for (int j = 0; j < owner.attribute.battleData.addDamagePercent.Count; j++)
		{
			list2.Add(new AddDamageInfo
			{
				attackType = owner.attribute.battleData.addDamagePercent[j].attackType,
				value = owner.attribute.battleData.addDamagePercent[j].value * this.percentArr[1]
			});
		}
	}

	// Token: 0x0601794B RID: 96587 RVA: 0x00742900 File Offset: 0x00740D00
	protected void ChangeSummonMonsterAddCritiDamage(object[] args)
	{
		BeEntity owner = base.owner.GetOwner();
		if (owner == null || owner.attribute == null || owner.attribute.battleData == null)
		{
			return;
		}
		int[] array = (int[])args[0];
		array[0] += owner.attribute.battleData.criticalPercent * this.percentArr[2];
	}

	// Token: 0x04010F19 RID: 69401
	protected VFactor[] percentArr = new VFactor[3];
}
