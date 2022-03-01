using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004458 RID: 17496
public class Skill1514 : BeSkill
{
	// Token: 0x060184E1 RID: 99553 RVA: 0x007918C1 File Offset: 0x0078FCC1
	public Skill1514(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060184E2 RID: 99554 RVA: 0x007918E4 File Offset: 0x0078FCE4
	public override void OnInit()
	{
		this.carrerID.Clear();
		this.weaponType.Clear();
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
			if (valueFromUnionCell > 0)
			{
				this.carrerID.Add(valueFromUnionCell);
			}
		}
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		for (int j = 0; j < this.skillData.ValueC.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueC[j], base.level, true);
			if (valueFromUnionCell2 > 0)
			{
				this.weaponType.Add(valueFromUnionCell2);
			}
		}
		this._isYinluo = true;
	}

	// Token: 0x060184E3 RID: 99555 RVA: 0x007919D5 File Offset: 0x0078FDD5
	public override void OnPostInit()
	{
		base.OnPostInit();
		if (this._isYinluo)
		{
			this._RemoveEvent();
			this._RegisterEvent();
		}
	}

	// Token: 0x060184E4 RID: 99556 RVA: 0x007919F4 File Offset: 0x0078FDF4
	public override void OnStart()
	{
		base.OnStart();
		this._SetButtonEffect();
	}

	// Token: 0x060184E5 RID: 99557 RVA: 0x00791A02 File Offset: 0x0078FE02
	public override bool NeedCoolDown()
	{
		return false;
	}

	// Token: 0x060184E6 RID: 99558 RVA: 0x00791A05 File Offset: 0x0078FE05
	public override bool CanForceUseSkill()
	{
		return this._YinluoTwoPhaseCanUse() || base.CanForceUseSkill();
	}

	// Token: 0x060184E7 RID: 99559 RVA: 0x00791A1C File Offset: 0x0078FE1C
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2 && this.carrerID.Contains(base.owner.professionID) && this.weaponType.Contains(base.owner.GetWeaponType()))
		{
			base.owner.buffController.TryAddBuff(this.buffID, -1, 1);
		}
	}

	// Token: 0x060184E8 RID: 99560 RVA: 0x00791A86 File Offset: 0x0078FE86
	public override void OnCancel()
	{
		base.OnCancel();
		this._RemoveButtonEffect();
		this.RemoveBuff();
	}

	// Token: 0x060184E9 RID: 99561 RVA: 0x00791A9A File Offset: 0x0078FE9A
	public override void OnFinish()
	{
		base.StartCoolDown();
		this._RemoveButtonEffect();
		this.RemoveBuff();
	}

	// Token: 0x060184EA RID: 99562 RVA: 0x00791AAE File Offset: 0x0078FEAE
	private void _SetButtonEffect()
	{
		if (!this._isYinluo)
		{
			return;
		}
		if (!this._YinluoTwoPhaseCanUse())
		{
			return;
		}
		base.ChangeButtonEffect();
	}

	// Token: 0x060184EB RID: 99563 RVA: 0x00791ACE File Offset: 0x0078FECE
	private void _RegisterEvent()
	{
		this._yinluoCanUseHandle = base.owner.RegisterEventNew(BeEventType.onChangeYinluoFlag, new BeEvent.BeEventHandleNew.Function(this._OnChangeYinluoFlag));
	}

	// Token: 0x060184EC RID: 99564 RVA: 0x00791AF2 File Offset: 0x0078FEF2
	private void _RemoveEvent()
	{
		if (this._yinluoCanUseHandle != null)
		{
			this._yinluoCanUseHandle.Remove();
			this._yinluoCanUseHandle = null;
		}
	}

	// Token: 0x060184ED RID: 99565 RVA: 0x00791B11 File Offset: 0x0078FF11
	private void _OnChangeYinluoFlag(BeEvent.BeEventParam param)
	{
		this.SetCanUseSkillFlag(param.m_Bool);
	}

	// Token: 0x060184EE RID: 99566 RVA: 0x00791B1F File Offset: 0x0078FF1F
	private void RemoveBuff()
	{
		base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
	}

	// Token: 0x060184EF RID: 99567 RVA: 0x00791B3C File Offset: 0x0078FF3C
	private bool _YinluoTwoPhaseCanUse()
	{
		return (this._canUseSkillFalg && this.CanUseSkill()) || (base.owner.IsCastingSkill() && base.owner.GetCurSkillID() == this.skillID && this.buttonState != ButtonState.PRESS_AGAIN);
	}

	// Token: 0x060184F0 RID: 99568 RVA: 0x00791B96 File Offset: 0x0078FF96
	public void SetCanUseSkillFlag(bool canUse)
	{
		if (canUse)
		{
			if (this.CanUseSkill())
			{
				this._canUseSkillFalg = true;
				base.ChangeButtonEffect();
			}
		}
		else
		{
			this._RemoveButtonEffect();
			this._canUseSkillFalg = false;
		}
	}

	// Token: 0x060184F1 RID: 99569 RVA: 0x00791BC8 File Offset: 0x0078FFC8
	private void _RemoveButtonEffect()
	{
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x040118A1 RID: 71841
	private List<int> carrerID = new List<int>();

	// Token: 0x040118A2 RID: 71842
	private int buffID;

	// Token: 0x040118A3 RID: 71843
	private List<int> weaponType = new List<int>();

	// Token: 0x040118A4 RID: 71844
	protected bool _isYinluo;

	// Token: 0x040118A5 RID: 71845
	private bool _canUseSkillFalg;

	// Token: 0x040118A6 RID: 71846
	private IBeEventHandle _yinluoCanUseHandle;
}
