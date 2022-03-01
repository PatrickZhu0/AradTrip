using System;

// Token: 0x02004464 RID: 17508
public class Skill1621 : BeSkill
{
	// Token: 0x06018534 RID: 99636 RVA: 0x0079384E File Offset: 0x00791C4E
	public Skill1621(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018535 RID: 99637 RVA: 0x00793858 File Offset: 0x00791C58
	public override void OnStart()
	{
		base.OnStart();
		this._InitData();
		this._RemoveEvent();
		this._RegisterEvent();
	}

	// Token: 0x06018536 RID: 99638 RVA: 0x00793874 File Offset: 0x00791C74
	private void _InitData()
	{
		this._hpRecoverBuffId = ((!BattleMain.IsModePvP(base.battleType)) ? 162101 : 162102);
		this._addAttrBuffId = ((!BattleMain.IsModePvP(base.battleType)) ? 162103 : 162104);
	}

	// Token: 0x06018537 RID: 99639 RVA: 0x007938CB File Offset: 0x00791CCB
	private void _RegisterEvent()
	{
		this._onBeKilledHandle = base.owner.RegisterEvent(BeEventType.onBeKilled, new BeEventHandle.Del(this._OnBeKilled));
		this._onFakeRebornHandle = base.owner.RegisterEvent(BeEventType.OnFakeReborn, new BeEventHandle.Del(this._OnFakeReborn));
	}

	// Token: 0x06018538 RID: 99640 RVA: 0x0079390C File Offset: 0x00791D0C
	private void _OnBeKilled(object[] args)
	{
		if (base.owner.GetEntityData() == null)
		{
			return;
		}
		base.owner.buffController.RemoveBuff(this._hpRecoverBuffId, 0, 0);
		base.owner.buffController.RemoveBuff(this._addAttrBuffId, 0, 0);
	}

	// Token: 0x06018539 RID: 99641 RVA: 0x0079395C File Offset: 0x00791D5C
	private void _OnFakeReborn(object[] args)
	{
		if (base.owner.GetEntityData() == null)
		{
			return;
		}
		base.owner.buffController.RemoveBuff(this._hpRecoverBuffId, 0, 0);
		base.owner.buffController.RemoveBuff(this._addAttrBuffId, 0, 0);
	}

	// Token: 0x0601853A RID: 99642 RVA: 0x007939AA File Offset: 0x00791DAA
	private void _RemoveEvent()
	{
		if (this._onBeKilledHandle != null)
		{
			this._onBeKilledHandle.Remove();
			this._onBeKilledHandle = null;
		}
		if (this._onFakeRebornHandle != null)
		{
			this._onFakeRebornHandle.Remove();
			this._onFakeRebornHandle = null;
		}
	}

	// Token: 0x0601853B RID: 99643 RVA: 0x007939E8 File Offset: 0x00791DE8
	public override bool CanUseSkill()
	{
		if (base.CanUseSkill())
		{
			BeEntityData entityData = base.owner.GetEntityData();
			if (entityData != null)
			{
				VFactor hprate = entityData.GetHPRate();
				VFactor b = new VFactor((long)base.GetLowHPPercent(), (long)GlobalLogic.VALUE_1000);
				return hprate < b;
			}
		}
		return false;
	}

	// Token: 0x040118DF RID: 71903
	private int _hpRecoverBuffId;

	// Token: 0x040118E0 RID: 71904
	private int _addAttrBuffId;

	// Token: 0x040118E1 RID: 71905
	private BeEventHandle _onBeKilledHandle;

	// Token: 0x040118E2 RID: 71906
	private BeEventHandle _onFakeRebornHandle;
}
