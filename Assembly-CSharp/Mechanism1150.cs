using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042C5 RID: 17093
public class Mechanism1150 : BeMechanism
{
	// Token: 0x06017A64 RID: 96868 RVA: 0x007499B8 File Offset: 0x00747DB8
	public Mechanism1150(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A65 RID: 96869 RVA: 0x00749A10 File Offset: 0x00747E10
	public override void OnInit()
	{
		base.OnInit();
		this._registerSkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._comboSkillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._comboTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this._canSwitchWeapon = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 1);
	}

	// Token: 0x06017A66 RID: 96870 RVA: 0x00749AD0 File Offset: 0x00747ED0
	public override void OnStart()
	{
		base.OnStart();
		this._comboState = Mechanism1150.ComboState.None;
		if (this.attachBuff != null)
		{
			this._attachBuffTime = this.attachBuff.duration;
		}
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onSpecialSkillCombo, new BeEvent.BeEventHandleNew.Function(this._OnSpecialSkillCombo)));
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onComboSkillCDCoolDown, new BeEvent.BeEventHandleNew.Function(this._OnComboSkillCDCoolDown)));
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onWillUseSkill, new BeEvent.BeEventHandleNew.Function(this._OnWillUseSkill)));
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onChangeAttackCanTriggerSkill, new BeEvent.BeEventHandleNew.Function(this._OnChangeAttackCanTriggerSkill)));
		this.handleA = base.owner.RegisterEvent(BeEventType.onStateChange, new BeEventHandle.Del(this._OnStateChange));
		this.handleB = base.owner.RegisterEvent(BeEventType.onReplaceSkill, new BeEventHandle.Del(this._OnReplaceSkill));
		this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onSkillCoolDownStart, new BeEvent.BeEventHandleNew.Function(this._OnSkillCoolDownStart)));
		if (base.owner.isLocalActor)
		{
			this._handleList.Add(base.owner.RegisterEventNew(BeEventType.onCanChangeWeaponButton, new BeEvent.BeEventHandleNew.Function(this._OnCanChangeWeaponButton)));
		}
	}

	// Token: 0x06017A67 RID: 96871 RVA: 0x00749C3A File Offset: 0x0074803A
	public override void OnFinish()
	{
		base.OnFinish();
		this._RemoveHandle();
		this._CheckSkillStartCoolDown();
	}

	// Token: 0x06017A68 RID: 96872 RVA: 0x00749C4E File Offset: 0x0074804E
	public override void OnUpdateImpactBySpeed(int deltaTime)
	{
		base.OnUpdateImpactBySpeed(deltaTime);
		this._CheckLifeTime(deltaTime);
		this._CheckCombo(deltaTime);
	}

	// Token: 0x06017A69 RID: 96873 RVA: 0x00749C65 File Offset: 0x00748065
	private void _OnComboSkillCDCoolDown(BeEvent.BeEventParam param)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		if (param.m_Int != this._registerSkillId)
		{
			return;
		}
		param.m_Bool = true;
	}

	// Token: 0x06017A6A RID: 96874 RVA: 0x00749C8D File Offset: 0x0074808D
	private void _OnWillUseSkill(BeEvent.BeEventParam param)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		if (param.m_Int != this._registerSkillId)
		{
			return;
		}
		param.m_Int = -1;
	}

	// Token: 0x06017A6B RID: 96875 RVA: 0x00749CB5 File Offset: 0x007480B5
	private void _OnCanChangeWeaponButton(BeEvent.BeEventParam param)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		param.m_Bool = this._canSwitchWeapon;
	}

	// Token: 0x06017A6C RID: 96876 RVA: 0x00749CD0 File Offset: 0x007480D0
	private void _OnStateChange(object[] args)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		ActionState actionState = (ActionState)args[0];
		if (actionState == ActionState.AS_CASTSKILL)
		{
			return;
		}
		this._comboState = Mechanism1150.ComboState.Finish;
		if (this.attachBuff != null)
		{
			this.attachBuff.ReduceDuration(this._attachBuffTime, true);
		}
	}

	// Token: 0x06017A6D RID: 96877 RVA: 0x00749D20 File Offset: 0x00748120
	private void _OnSkillCoolDownStart(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (@int != this._registerSkillId)
		{
			return;
		}
		this._canSwitchWeapon = true;
	}

	// Token: 0x06017A6E RID: 96878 RVA: 0x00749D48 File Offset: 0x00748148
	private void _OnChangeAttackCanTriggerSkill(BeEvent.BeEventParam param)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		if (Array.IndexOf<int>(this._normalAttIdArr, param.m_Int) < 0)
		{
			return;
		}
		param.m_Bool = true;
	}

	// Token: 0x06017A6F RID: 96879 RVA: 0x00749D78 File Offset: 0x00748178
	private void _CheckSkillStartCoolDown()
	{
		if (this.attachBuff != null && this.attachBuff.GetProcess() < 1f)
		{
			return;
		}
		BeSkill skill = base.owner.GetSkill(this._registerSkillId);
		if (skill == null)
		{
			return;
		}
		if (skill.isCooldown)
		{
			return;
		}
		skill.SetIgnoreCD(false, false);
		skill.StartCoolDown();
		skill.SetIgnoreCD(true, false);
	}

	// Token: 0x06017A70 RID: 96880 RVA: 0x00749DE1 File Offset: 0x007481E1
	private void _CheckCombo(int deltaTime)
	{
		if (this._comboState != Mechanism1150.ComboState.None)
		{
			return;
		}
		this._curComboTime += deltaTime;
		if (this._curComboTime > this._comboTime)
		{
			this._comboState = Mechanism1150.ComboState.Ready;
		}
	}

	// Token: 0x06017A71 RID: 96881 RVA: 0x00749E18 File Offset: 0x00748218
	private void _CheckLifeTime(int deltaTime)
	{
		if (this._attachBuffTime <= 0)
		{
			return;
		}
		this._curLifeTime += deltaTime;
		if (this._curLifeTime > this._attachBuffTime && this.attachBuff != null)
		{
			this.attachBuff.ReduceDuration(this._attachBuffTime, true);
		}
	}

	// Token: 0x06017A72 RID: 96882 RVA: 0x00749E70 File Offset: 0x00748270
	private void _OnSpecialSkillCombo(BeEvent.BeEventParam param)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		if (param.m_Int != this._registerSkillId)
		{
			return;
		}
		Mechanism1150.ComboState comboState = this._comboState;
		if (comboState == Mechanism1150.ComboState.None)
		{
			param.m_Bool = true;
			return;
		}
		if (comboState == Mechanism1150.ComboState.Ready)
		{
			this._comboState = Mechanism1150.ComboState.Finish;
		}
		if (!base.owner.HasSkill(this._comboSkillId))
		{
			Logger.LogErrorFormat("没有携带该技能 ID:{0}", new object[]
			{
				this._comboSkillId
			});
			return;
		}
		BeSkill currentSkill = base.owner.GetCurrentSkill();
		if (currentSkill != null)
		{
			base.owner.CancelSkill(currentSkill.skillID, true);
			currentSkill.cancelByCombo = true;
			currentSkill.OnComboBreak();
		}
		base.owner.CastSkill(this._comboSkillId);
		param.m_Bool = true;
	}

	// Token: 0x06017A73 RID: 96883 RVA: 0x00749F48 File Offset: 0x00748348
	private void _OnReplaceSkill(object[] args)
	{
		if (this._comboState == Mechanism1150.ComboState.Finish)
		{
			return;
		}
		int[] array = args[0] as int[];
		if (array == null)
		{
			return;
		}
		int value = array[0];
		if (Array.IndexOf<int>(this._useSkillIdArr, value) > -1)
		{
			return;
		}
		this._comboState = Mechanism1150.ComboState.Finish;
		if (this.attachBuff != null)
		{
			this.attachBuff.ReduceDuration(this._attachBuffTime, true);
		}
	}

	// Token: 0x06017A74 RID: 96884 RVA: 0x00749FB0 File Offset: 0x007483B0
	private void _RemoveHandle()
	{
		for (int i = 0; i < this._handleList.Count; i++)
		{
			if (this._handleList[i] != null)
			{
				this._handleList[i].Remove();
				this._handleList[i] = null;
			}
		}
	}

	// Token: 0x04010FEE RID: 69614
	private int _registerSkillId;

	// Token: 0x04010FEF RID: 69615
	private int _comboSkillId;

	// Token: 0x04010FF0 RID: 69616
	private int _comboTime;

	// Token: 0x04010FF1 RID: 69617
	private int[] _useSkillIdArr = new int[]
	{
		1500,
		1501,
		1502,
		1901,
		1902,
		1903,
		1904
	};

	// Token: 0x04010FF2 RID: 69618
	private int _curComboTime;

	// Token: 0x04010FF3 RID: 69619
	private Mechanism1150.ComboState _comboState;

	// Token: 0x04010FF4 RID: 69620
	private List<BeEvent.BeEventHandleNew> _handleList = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x04010FF5 RID: 69621
	private bool _canSwitchWeapon = true;

	// Token: 0x04010FF6 RID: 69622
	private int _attachBuffTime;

	// Token: 0x04010FF7 RID: 69623
	private int _curLifeTime;

	// Token: 0x04010FF8 RID: 69624
	private int[] _normalAttIdArr = new int[]
	{
		1500,
		1501,
		1502
	};

	// Token: 0x020042C6 RID: 17094
	private enum ComboState
	{
		// Token: 0x04010FFA RID: 69626
		None,
		// Token: 0x04010FFB RID: 69627
		Ready,
		// Token: 0x04010FFC RID: 69628
		Finish
	}
}
