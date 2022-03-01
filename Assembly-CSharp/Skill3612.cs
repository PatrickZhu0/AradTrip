using System;
using GameClient;

// Token: 0x020044CA RID: 17610
public class Skill3612 : BeSkill
{
	// Token: 0x06018814 RID: 100372 RVA: 0x007A6731 File Offset: 0x007A4B31
	public Skill3612(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018815 RID: 100373 RVA: 0x007A6746 File Offset: 0x007A4B46
	public override void OnPostInit()
	{
		base.OnPostInit();
		this._monsterId = ((!BattleMain.IsModePvP(base.battleType)) ? 93100031 : 93040031);
	}

	// Token: 0x06018816 RID: 100374 RVA: 0x007A6773 File Offset: 0x007A4B73
	public override void OnStart()
	{
		base.OnStart();
		if (this.CanManualAttack())
		{
			this.pressMode = SkillPressMode.PRESS_MANY_TWO;
			this._RemoveHandle();
			this._RegisterHandle();
		}
	}

	// Token: 0x06018817 RID: 100375 RVA: 0x007A6799 File Offset: 0x007A4B99
	public override bool CanUseSkill()
	{
		return (!this.CanManualAttack() || this._monster == null) && base.CanUseSkill();
	}

	// Token: 0x06018818 RID: 100376 RVA: 0x007A67B9 File Offset: 0x007A4BB9
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (this.CanManualAttack() && this._monster != null)
		{
			return BeActor.SkillCannotUseType.CAN_NOT_USE;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018819 RID: 100377 RVA: 0x007A67DA File Offset: 0x007A4BDA
	public override void OnClickAgain()
	{
		base.OnClickAgain();
		if (this.CanManualAttack())
		{
			this._MonsterUseSkill();
		}
	}

	// Token: 0x0601881A RID: 100378 RVA: 0x007A67F3 File Offset: 0x007A4BF3
	public override void OnCancel()
	{
		base.OnCancel();
		if (this.CanManualAttack() && this._monster == null)
		{
			base.ResetButtonEffect();
		}
	}

	// Token: 0x0601881B RID: 100379 RVA: 0x007A6817 File Offset: 0x007A4C17
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.CanManualAttack() && this._monster == null)
		{
			base.ResetButtonEffect();
		}
	}

	// Token: 0x0601881C RID: 100380 RVA: 0x007A683B File Offset: 0x007A4C3B
	private void _RegisterHandle()
	{
		this._monsterSummonHandle = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this._OnSummon));
		this._rebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this._OnReborn));
	}

	// Token: 0x0601881D RID: 100381 RVA: 0x007A687C File Offset: 0x007A4C7C
	private void _OnSummon(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.GetEntityData().MonsterIDEqual(this._monsterId))
		{
			return;
		}
		this._monsterDeadHandle = beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._OnSummonDead));
		this._monsterSkillStartCoolDownHandle = beActor.RegisterEventNew(BeEventType.onSkillCoolDownStart, new BeEvent.BeEventHandleNew.Function(this._OnSkillCoolDownStart));
		this._monsterSkillEndCoolDownHandle = beActor.RegisterEventNew(BeEventType.onSkillCoolDownFinish, new BeEvent.BeEventHandleNew.Function(this._OnSkillCoolDownFinish));
		this._monster = beActor;
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		base.ChangeButtonEffect();
	}

	// Token: 0x0601881E RID: 100382 RVA: 0x007A6912 File Offset: 0x007A4D12
	private void _OnReborn(object[] args)
	{
		base.ResetButtonEffect();
	}

	// Token: 0x0601881F RID: 100383 RVA: 0x007A691A File Offset: 0x007A4D1A
	private void _OnSummonDead(object[] args)
	{
		base.ResetButtonEffect();
		this._monster = null;
	}

	// Token: 0x06018820 RID: 100384 RVA: 0x007A6929 File Offset: 0x007A4D29
	private void _MonsterUseSkill()
	{
		if (this._monster == null)
		{
			return;
		}
		if (!this._monster.CanUseSkill(this._skillId))
		{
			return;
		}
		this._monster.UseSkill(this._skillId, false);
		base.ResetButtonEffect();
	}

	// Token: 0x06018821 RID: 100385 RVA: 0x007A6968 File Offset: 0x007A4D68
	private void _OnSkillCoolDownStart(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (@int != this._skillId)
		{
			return;
		}
		if (this._monster == null)
		{
			return;
		}
		base.ResetButtonEffect();
	}

	// Token: 0x06018822 RID: 100386 RVA: 0x007A699C File Offset: 0x007A4D9C
	private void _OnSkillCoolDownFinish(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (@int != this._skillId)
		{
			return;
		}
		if (this._monster == null)
		{
			return;
		}
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		base.ChangeButtonEffect();
	}

	// Token: 0x06018823 RID: 100387 RVA: 0x007A69D6 File Offset: 0x007A4DD6
	private bool CanManualAttack()
	{
		return base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.XuanwuManualAttack) && base.owner.XuanWuManualAttack;
	}

	// Token: 0x06018824 RID: 100388 RVA: 0x007A6A14 File Offset: 0x007A4E14
	private void _RemoveHandle()
	{
		if (this._monsterSummonHandle != null)
		{
			this._monsterSummonHandle.Remove();
			this._monsterSummonHandle = null;
		}
		if (this._monsterDeadHandle != null)
		{
			this._monsterDeadHandle.Remove();
			this._monsterDeadHandle = null;
		}
		if (this._monsterSkillStartCoolDownHandle != null)
		{
			this._monsterSkillStartCoolDownHandle.Remove();
			this._monsterSkillStartCoolDownHandle = null;
		}
		if (this._monsterSkillEndCoolDownHandle != null)
		{
			this._monsterSkillEndCoolDownHandle.Remove();
			this._monsterSkillEndCoolDownHandle = null;
		}
		if (this._rebornHandle != null)
		{
			this._rebornHandle.Remove();
			this._rebornHandle = null;
		}
	}

	// Token: 0x04011ADF RID: 72415
	private int _monsterId;

	// Token: 0x04011AE0 RID: 72416
	private int _skillId = 5031;

	// Token: 0x04011AE1 RID: 72417
	private BeActor _monster;

	// Token: 0x04011AE2 RID: 72418
	private BeEventHandle _monsterSummonHandle;

	// Token: 0x04011AE3 RID: 72419
	private BeEventHandle _monsterDeadHandle;

	// Token: 0x04011AE4 RID: 72420
	private BeEventHandle _rebornHandle;

	// Token: 0x04011AE5 RID: 72421
	private BeEvent.BeEventHandleNew _monsterSkillStartCoolDownHandle;

	// Token: 0x04011AE6 RID: 72422
	private BeEvent.BeEventHandleNew _monsterSkillEndCoolDownHandle;
}
