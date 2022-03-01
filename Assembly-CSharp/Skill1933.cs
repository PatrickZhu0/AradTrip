using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004477 RID: 17527
public class Skill1933 : BeSkill
{
	// Token: 0x060185EF RID: 99823 RVA: 0x0079819B File Offset: 0x0079659B
	public Skill1933(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185F0 RID: 99824 RVA: 0x007981BB File Offset: 0x007965BB
	public override void OnInit()
	{
		base.OnInit();
		this._comboYinluoMechanismId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x060185F1 RID: 99825 RVA: 0x007981E6 File Offset: 0x007965E6
	public override void OnStart()
	{
		base.OnStart();
		this._canComboYinluo = false;
		this._RemoveHandle();
		this._RegisterEvent();
	}

	// Token: 0x060185F2 RID: 99826 RVA: 0x00798204 File Offset: 0x00796604
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, new BeEventHandle.Del(this._OnSkillCurFrame));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.onTouchGround, new BeEventHandle.Del(this._OnTouchGround)));
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onStateChangeEnd, new BeEvent.BeEventHandleNew.Function(this._OnStateChangeEnd)));
		this._handleList.Add(base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, new BeEventHandle.Del(this._OnBeHitAfterFinalDamage)));
	}

	// Token: 0x060185F3 RID: 99827 RVA: 0x0079829C File Offset: 0x0079669C
	private void _OnSkillCurFrame(object[] args)
	{
		string a = (string)args[0];
		if (a == this._startComboFlag && !this._canComboYinluo)
		{
			this._ChangeYinluoCanUseFlag(true);
		}
	}

	// Token: 0x060185F4 RID: 99828 RVA: 0x007982D5 File Offset: 0x007966D5
	private void _OnTouchGround(object[] args)
	{
		if (this._canComboYinluo)
		{
			this._ChangeYinluoCanUseFlag(false);
		}
	}

	// Token: 0x060185F5 RID: 99829 RVA: 0x007982EC File Offset: 0x007966EC
	private void _OnStateChangeEnd(BeEvent.BeEventParam param)
	{
		ActionState @int = (ActionState)param.m_Int;
		if ((@int == ActionState.AS_HURT || @int == ActionState.AS_FALL || @int == ActionState.AS_GRAPED) && this._canComboYinluo)
		{
			this._ChangeYinluoCanUseFlag(false);
		}
	}

	// Token: 0x060185F6 RID: 99830 RVA: 0x00798329 File Offset: 0x00796729
	private void _OnBeHitAfterFinalDamage(object[] args)
	{
		if (this._canComboYinluo)
		{
			this._ChangeYinluoCanUseFlag(false);
		}
	}

	// Token: 0x060185F7 RID: 99831 RVA: 0x00798340 File Offset: 0x00796740
	private void _ChangeYinluoCanUseFlag(bool canCombo)
	{
		base.owner.TriggerEventNew(BeEventType.onChangeYinluoFlag, new EventParam
		{
			m_Bool = canCombo
		});
		if (canCombo)
		{
			if (base.owner.GetMechanism(this._comboYinluoMechanismId) == null)
			{
				base.owner.AddMechanism(this._comboYinluoMechanismId, base.level, MechanismSourceType.NONE, null, GlobalLogic.VALUE_10000);
			}
		}
		else
		{
			base.owner.RemoveMechanism(this._comboYinluoMechanismId);
		}
		this._canComboYinluo = canCombo;
	}

	// Token: 0x060185F8 RID: 99832 RVA: 0x007983C8 File Offset: 0x007967C8
	private void _RemoveHandle()
	{
		for (int i = 0; i < this._handleList.Count; i++)
		{
			IBeEventHandle beEventHandle = this._handleList[i];
			if (beEventHandle != null)
			{
				beEventHandle.Remove();
			}
		}
	}

	// Token: 0x0401197C RID: 72060
	private string _startComboFlag = "193301";

	// Token: 0x0401197D RID: 72061
	private List<IBeEventHandle> _handleList = new List<IBeEventHandle>();

	// Token: 0x0401197E RID: 72062
	private bool _canComboYinluo;

	// Token: 0x0401197F RID: 72063
	private int _comboYinluoMechanismId;
}
