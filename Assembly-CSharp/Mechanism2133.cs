using System;
using GameClient;

// Token: 0x020043C2 RID: 17346
public class Mechanism2133 : BeMechanism
{
	// Token: 0x060180F1 RID: 98545 RVA: 0x00778D09 File Offset: 0x00777109
	public Mechanism2133(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180F2 RID: 98546 RVA: 0x00778D13 File Offset: 0x00777113
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x060180F3 RID: 98547 RVA: 0x00778D21 File Offset: 0x00777121
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateToNextPhase();
	}

	// Token: 0x060180F4 RID: 98548 RVA: 0x00778D30 File Offset: 0x00777130
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this._OnCastSkill));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this._OnCastSkillFinish));
		this.handleC = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this._OnSkillCancel));
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onEnterPhase, new BeEvent.BeEventHandleNew.Function(this._OnEnterPhase));
	}

	// Token: 0x060180F5 RID: 98549 RVA: 0x00778DBC File Offset: 0x007771BC
	private void _OnCastSkill(object[] args)
	{
		BeSkill beSkill = args[1] as BeSkill;
		if (beSkill == null || !beSkill.charge)
		{
			return;
		}
		this._isChargeSkillRunning = true;
		this._skillId = beSkill.skillID;
		this._skill = beSkill;
		this._chargeSwitchPhase = beSkill.chargeConfig.changePhase;
	}

	// Token: 0x060180F6 RID: 98550 RVA: 0x00778E10 File Offset: 0x00777210
	private void _OnCastSkillFinish(object[] args)
	{
		int num = (int)args[0];
		if (this._skillId != num)
		{
			return;
		}
		this._ResetData();
	}

	// Token: 0x060180F7 RID: 98551 RVA: 0x00778E3C File Offset: 0x0077723C
	private void _OnSkillCancel(object[] args)
	{
		int num = (int)args[0];
		if (this._skillId != num)
		{
			return;
		}
		this._ResetData();
	}

	// Token: 0x060180F8 RID: 98552 RVA: 0x00778E68 File Offset: 0x00777268
	private void _OnEnterPhase(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (this._skillId != @int)
		{
			return;
		}
		if (!this._isChargeSkillRunning)
		{
			return;
		}
		int int2 = param.m_Int2;
		if (this._chargeSwitchPhase - int2 == 1 && this._skill != null)
		{
			this._skill.pressDuration += this._skill.GetCurrentCharge() + 1000;
			this._skill.charged = true;
			base.owner.StopSpellBar(eDungeonCharactorBar.Power, true);
		}
		if (int2 < this._chargeSwitchPhase)
		{
			this._switchToNextFlag = true;
		}
	}

	// Token: 0x060180F9 RID: 98553 RVA: 0x00778F04 File Offset: 0x00777304
	private void _UpdateToNextPhase()
	{
		if (!this._isChargeSkillRunning)
		{
			return;
		}
		if (!this._switchToNextFlag)
		{
			return;
		}
		base.owner.StopSpellBar(eDungeonCharactorBar.Sing, true);
		(base.owner.GetStateGraph() as BeActorStateGraph).ExecuteNextPhaseSkill();
		this._switchToNextFlag = false;
	}

	// Token: 0x060180FA RID: 98554 RVA: 0x00778F52 File Offset: 0x00777352
	private void _ResetData()
	{
		this._skillId = 0;
		this._chargeSwitchPhase = 0;
		this._skill = null;
		this._switchToNextFlag = false;
		this._isChargeSkillRunning = false;
		this.RemoveSelfAndAttachBuff();
	}

	// Token: 0x060180FB RID: 98555 RVA: 0x00778F7D File Offset: 0x0077737D
	private void RemoveSelfAndAttachBuff()
	{
		if (this.attachBuff != null)
		{
			this.attachBuff.Finish();
		}
		base.Finish();
	}

	// Token: 0x0401156A RID: 71018
	private int _skillId;

	// Token: 0x0401156B RID: 71019
	private int _chargeSwitchPhase;

	// Token: 0x0401156C RID: 71020
	private BeSkill _skill;

	// Token: 0x0401156D RID: 71021
	private bool _isChargeSkillRunning;

	// Token: 0x0401156E RID: 71022
	private bool _switchToNextFlag;
}
