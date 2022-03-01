using System;
using GameClient;

// Token: 0x02004465 RID: 17509
public class Skill1622 : BeSkill
{
	// Token: 0x0601853C RID: 99644 RVA: 0x00793A36 File Offset: 0x00791E36
	public Skill1622(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601853D RID: 99645 RVA: 0x00793A6C File Offset: 0x00791E6C
	public override void OnInit()
	{
		this.canUseOnLowHp = !BattleMain.IsModePvP(base.owner.battleType);
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.ShiXueModify))
		{
			this.canUseOnLowHp = false;
		}
	}

	// Token: 0x0601853E RID: 99646 RVA: 0x00793AC0 File Offset: 0x00791EC0
	public override void OnStart()
	{
		this.flag = false;
		this.RemoveBuffHandle();
		this.buffInfoID = ((!BattleMain.IsModePvP(base.owner.battleType)) ? 162205 : 162206);
		this.buffInfoID1 = ((!BattleMain.IsModePvP(base.owner.battleType)) ? 162217 : 162218);
		this.buffID = ((!BattleMain.IsModePvP(base.owner.battleType)) ? 162209 : 162210);
		base.OnStart();
		this.addBuffHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.buffID)
			{
				BeMechanism mechanism = base.owner.GetMechanism(this.mechanismID);
				if (mechanism != null)
				{
					base.owner.RemoveMechanism(this.mechanismID);
				}
				base.owner.AddMechanism(this.mechanismID, 0, MechanismSourceType.NONE, null, 0);
				BuffInfoData info = new BuffInfoData((!BattleMain.IsModePvP(base.owner.battleType)) ? 162209 : 162210, base.level, 0);
				BuffInfoData info2 = new BuffInfoData((!BattleMain.IsModePvP(base.owner.battleType)) ? 162211 : 162212, base.level, 0);
				base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
				base.owner.buffController.TryAddBuff(info2, null, false, default(VRate), null);
			}
		});
		this.removeBuffHandle = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.buffID)
			{
				base.owner.RemoveMechanism(this.mechanismID);
				if (base.owner.sgGetCurrentState() == 0)
				{
					base.owner.Locomote(new BeStateData(0, 0), false);
				}
			}
		});
		if (!this.canUseOnLowHp)
		{
			this.hpChangeHandle = base.owner.RegisterEvent(BeEventType.OnBuffHpChange, delegate(object[] args)
			{
				int num = (int)args[0];
				if (num == 162101 || num == 162102 || num == 162215 || num == 162216)
				{
					int maxHP = base.owner.GetEntityData().GetMaxHP();
					if (base.owner.GetEntityData().GetHPRate() < VFactor.NewVFactor(10, 1000))
					{
						base.owner.GetEntityData().SetHP(maxHP * VFactor.NewVFactor(10, 1000));
						base.owner.SetIsDead(false);
						base.owner.m_pkGeActor.SyncHPBar();
					}
					if (base.owner.GetEntityData().GetHPRate() < VFactor.NewVFactor(5, 100))
					{
						((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
					}
				}
			});
		}
		this.triggerHandle = base.owner.RegisterEvent(BeEventType.OnReleaseButtonTrigger, delegate(object[] args)
		{
			if (this.flag || BattleMain.IsModePvP(base.owner.battleType))
			{
				return;
			}
			this.flag = true;
			if (this.pressDuration > 500)
			{
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
			else
			{
				this.delayCall = base.owner.delayCaller.DelayCall(250, delegate
				{
					((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
				}, 0, 0, false);
			}
		});
		if (this.canUseOnLowHp)
		{
			this.canAddBuffHandle = base.owner.RegisterEvent(BeEventType.BuffCanAdd, delegate(object[] args)
			{
				int num = (int)args[1];
				if ((num == 162215 || num == 162216 || num == 162201 || num == 162202) && base.owner.GetEntityData().GetHPRate() < VFactor.NewVFactor(20, 100))
				{
					((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
					int[] array = args[0] as int[];
					if (array != null)
					{
						array[0] = 1;
					}
				}
			});
		}
	}

	// Token: 0x0601853F RID: 99647 RVA: 0x00793C14 File Offset: 0x00792014
	public override bool CanUseSkill()
	{
		if (this.canUseOnLowHp)
		{
			return base.CanUseSkill();
		}
		if (base.CanUseSkill())
		{
			int hp = base.owner.GetEntityData().GetHP();
			int maxHP = base.owner.GetEntityData().GetMaxHP();
			return VFactor.NewVFactor(hp, maxHP) >= VFactor.NewVFactor(100, 1000);
		}
		return false;
	}

	// Token: 0x06018540 RID: 99648 RVA: 0x00793C7C File Offset: 0x0079207C
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (this.canUseOnLowHp)
		{
			return base.GetCannotUseType();
		}
		int hp = base.owner.GetEntityData().GetHP();
		int maxHP = base.owner.GetEntityData().GetMaxHP();
		if (VFactor.NewVFactor(hp, maxHP) < VFactor.NewVFactor(100, 1000))
		{
			return BeActor.SkillCannotUseType.NO_HP;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018541 RID: 99649 RVA: 0x00793CE2 File Offset: 0x007920E2
	public override void OnCancel()
	{
		base.OnCancel();
		this.RemoveHandle();
	}

	// Token: 0x06018542 RID: 99650 RVA: 0x00793CF0 File Offset: 0x007920F0
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x06018543 RID: 99651 RVA: 0x00793CFE File Offset: 0x007920FE
	private void RemoveBuffHandle()
	{
		if (this.addBuffHandle != null)
		{
			this.addBuffHandle.Remove();
			this.addBuffHandle = null;
		}
		if (this.removeBuffHandle != null)
		{
			this.removeBuffHandle.Remove();
			this.removeBuffHandle = null;
		}
	}

	// Token: 0x06018544 RID: 99652 RVA: 0x00793D3C File Offset: 0x0079213C
	private void RemoveHandle()
	{
		if (base.owner.buffController.HasBuffByID(this.buffID) == null)
		{
			BuffInfoData info = new BuffInfoData(this.buffInfoID, base.level, 0);
			base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
		}
		BuffInfoData info2 = new BuffInfoData(this.buffInfoID1, base.level, 0);
		base.owner.buffController.TryAddBuff(info2, null, false, default(VRate), null);
		if (this.hpChangeHandle != null)
		{
			this.hpChangeHandle.Remove();
			this.hpChangeHandle = null;
		}
		if (this.triggerHandle != null)
		{
			this.triggerHandle.Remove();
			this.triggerHandle = null;
		}
		if (this.canAddBuffHandle != null)
		{
			this.canAddBuffHandle.Remove();
			this.canAddBuffHandle = null;
		}
		this.delayCall.SetRemove(true);
	}

	// Token: 0x040118E3 RID: 71907
	private int buffInfoID = 162205;

	// Token: 0x040118E4 RID: 71908
	private int buffID = 162209;

	// Token: 0x040118E5 RID: 71909
	private int mechanismID = 999;

	// Token: 0x040118E6 RID: 71910
	private int buffInfoID1 = 162217;

	// Token: 0x040118E7 RID: 71911
	private BeEventHandle addBuffHandle;

	// Token: 0x040118E8 RID: 71912
	private BeEventHandle removeBuffHandle;

	// Token: 0x040118E9 RID: 71913
	private BeEventHandle hpChangeHandle;

	// Token: 0x040118EA RID: 71914
	private BeEventHandle triggerHandle;

	// Token: 0x040118EB RID: 71915
	private BeEventHandle canAddBuffHandle;

	// Token: 0x040118EC RID: 71916
	private DelayCallUnitHandle delayCall;

	// Token: 0x040118ED RID: 71917
	private bool flag;

	// Token: 0x040118EE RID: 71918
	private bool canUseOnLowHp;
}
