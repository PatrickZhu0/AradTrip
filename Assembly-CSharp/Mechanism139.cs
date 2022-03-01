using System;
using GameClient;

// Token: 0x02004311 RID: 17169
public class Mechanism139 : BeMechanism
{
	// Token: 0x06017C10 RID: 97296 RVA: 0x007541B6 File Offset: 0x007525B6
	public Mechanism139(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C11 RID: 97297 RVA: 0x007541C0 File Offset: 0x007525C0
	public override void OnStart()
	{
		BeActor actor = base.owner.GetOwner() as BeActor;
		if (actor != null)
		{
			this.handleA = actor.RegisterEvent(BeEventType.OnChangeWeaponEnd, delegate(object[] args)
			{
				this.AdjustSummonMonsterAttribute(actor, this.owner);
			});
			this.handleB = actor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				this.AdjustSummonMonsterAttribute(actor, this.owner);
			});
			this.handleC = actor.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
			{
				this.AdjustSummonMonsterAttribute(actor, this.owner);
			});
			this.handleNewA = actor.RegisterEventNew(BeEventType.onChangeEquipEnd, new BeEvent.BeEventHandleNew.Function(this.ChangeWeaponEnd));
		}
	}

	// Token: 0x06017C12 RID: 97298 RVA: 0x00754278 File Offset: 0x00752678
	protected void ChangeWeaponEnd(BeEvent.BeEventParam param)
	{
		BeActor beActor = base.owner.GetOwner() as BeActor;
		if (beActor == null)
		{
			return;
		}
		this.AdjustSummonMonsterAttribute(beActor, base.owner);
	}

	// Token: 0x06017C13 RID: 97299 RVA: 0x007542AC File Offset: 0x007526AC
	private void AdjustSummonMonsterAttribute(BeActor owner, BeActor monster)
	{
		if (owner == null || monster == null)
		{
			return;
		}
		monster.attribute.SetAttributeValue(AttributeType.attack, owner.attribute.GetAttributeValue(AttributeType.magicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.magicAttack, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.magicAttack, owner.attribute.GetAttributeValue(AttributeType.magicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.magicAttack, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.ignoreDefAttackAdd, owner.attribute.GetAttributeValue(AttributeType.ignoreDefMagicAttackAdd) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ignoreDefMagicAttackAdd, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.ignoreDefMagicAttackAdd, owner.attribute.GetAttributeValue(AttributeType.ignoreDefMagicAttackAdd) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ignoreDefMagicAttackAdd, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.baseAtk, owner.attribute.GetAttributeValue(AttributeType.baseInt) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseInt, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.baseInt, owner.attribute.GetAttributeValue(AttributeType.baseInt) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseInt, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.ciriticalAttack, owner.attribute.GetAttributeValue(AttributeType.ciriticalAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ciriticalAttack, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.ciriticalMagicAttack, owner.attribute.GetAttributeValue(AttributeType.ciriticalMagicAttack) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.ciriticalMagicAttack, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		monster.attribute.SetAttributeValue(AttributeType.baseIndependence, owner.attribute.GetAttributeValue(AttributeType.baseIndependence) * VFactor.NewVFactor(Singleton<TableManager>.instance.GetMonsterTableProperty(AttributeType.baseIndependence, monster.attribute.monsterData), GlobalLogic.VALUE_100000), false);
		for (int i = 1; i < 5; i++)
		{
			monster.attribute.battleData.magicElementsAttack[i] = owner.attribute.battleData.magicElementsAttack[i] * VRate.Factor(GlobalLogic.VALUE_1000);
		}
		if (monster.attribute.simpleMonsterID == 900 || monster.attribute.simpleMonsterID == 905 || monster.attribute.simpleMonsterID == 909)
		{
			for (int j = 1; j < 5; j++)
			{
				monster.attribute.battleData.magicELements[j] = owner.attribute.battleData.magicELements[j];
			}
		}
	}
}
