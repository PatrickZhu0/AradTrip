using System;
using GameClient;

// Token: 0x0200429A RID: 17050
public class Mechanism1081 : BeMechanism
{
	// Token: 0x0601796C RID: 96620 RVA: 0x00743BF9 File Offset: 0x00741FF9
	public Mechanism1081(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601796D RID: 96621 RVA: 0x00743C04 File Offset: 0x00742004
	public override void OnInit()
	{
		base.OnInit();
		this.m_KillDamage = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_KillDamagePercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.m_AddBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x0601796E RID: 96622 RVA: 0x00743C99 File Offset: 0x00742099
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.RegisterEvent));
	}

	// Token: 0x0601796F RID: 96623 RVA: 0x00743CC0 File Offset: 0x007420C0
	protected void RegisterEvent(object[] args)
	{
		BeActor beActor = (BeActor)args[0];
		if (beActor == null)
		{
			return;
		}
		int num = (int)args[5];
		int hp = beActor.attribute.GetHP();
		VFactor hprate = beActor.attribute.GetHPRate();
		if (this.m_KillDamage != 0 && hp > this.m_KillDamage)
		{
			return;
		}
		if (this.m_KillDamagePercent != VFactor.zero && hprate > this.m_KillDamagePercent)
		{
			return;
		}
		if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.HasFlag(BattleFlagType.ZhanshaMechanismFlag))
		{
			beActor.DoHPChange(-beActor.attribute.GetHP(), true);
			beActor.DoDead(false);
			beActor.TriggerEvent(BeEventType.onSpecialDead, null);
		}
		else
		{
			beActor.DoHurt(hp, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
		}
		if (this.m_AddBuffInfoId != 0)
		{
			base.owner.buffController.TryAddBuffInfo(this.m_AddBuffInfoId, base.owner, this.level);
		}
	}

	// Token: 0x04010F32 RID: 69426
	protected int m_KillDamage;

	// Token: 0x04010F33 RID: 69427
	protected VFactor m_KillDamagePercent;

	// Token: 0x04010F34 RID: 69428
	protected int m_AddBuffInfoId;
}
