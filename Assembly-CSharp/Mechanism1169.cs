using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042DE RID: 17118
public class Mechanism1169 : BeMechanism
{
	// Token: 0x06017AFB RID: 97019 RVA: 0x0074CDEE File Offset: 0x0074B1EE
	public Mechanism1169(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017AFC RID: 97020 RVA: 0x0074CE10 File Offset: 0x0074B210
	public override void OnInit()
	{
		base.OnInit();
		this._registerSkillIdList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this._registerSkillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x06017AFD RID: 97021 RVA: 0x0074CE7C File Offset: 0x0074B27C
	public override void OnStart()
	{
		base.OnStart();
		this._RgisterEvent();
	}

	// Token: 0x06017AFE RID: 97022 RVA: 0x0074CE8A File Offset: 0x0074B28A
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateCheckCombo();
	}

	// Token: 0x06017AFF RID: 97023 RVA: 0x0074CE99 File Offset: 0x0074B299
	public override void OnFinish()
	{
		base.OnFinish();
		this._RemoveEvent();
	}

	// Token: 0x06017B00 RID: 97024 RVA: 0x0074CEA8 File Offset: 0x0074B2A8
	private void _RgisterEvent()
	{
		if (!this.CheckPressComboFlag())
		{
			return;
		}
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onSkillPressButtonCombo, new BeEvent.BeEventHandleNew.Function(this._OnSkillPressButtonCombo));
		this._specialSkillComboHandle = base.owner.RegisterEventNew(BeEventType.onSpecialSkillComboRelease, new BeEvent.BeEventHandleNew.Function(this._OnSpecialSkillComboRelease));
	}

	// Token: 0x06017B01 RID: 97025 RVA: 0x0074CEFF File Offset: 0x0074B2FF
	private void _RemoveEvent()
	{
		if (this._specialSkillComboHandle != null)
		{
			this._specialSkillComboHandle.Remove();
			this._specialSkillComboHandle = null;
		}
	}

	// Token: 0x06017B02 RID: 97026 RVA: 0x0074CF1E File Offset: 0x0074B31E
	private void _OnSkillPressButtonCombo(BeEvent.BeEventParam param)
	{
		if (!this._registerSkillIdList.Contains(param.m_Int))
		{
			return;
		}
		this._SetComboSkillData(param.m_Int, param.m_Int2 != 1);
	}

	// Token: 0x06017B03 RID: 97027 RVA: 0x0074CF4F File Offset: 0x0074B34F
	private void _OnSpecialSkillComboRelease(BeEvent.BeEventParam param)
	{
		this._pressSkillIdList.Clear();
	}

	// Token: 0x06017B04 RID: 97028 RVA: 0x0074CF5C File Offset: 0x0074B35C
	private void _UpdateCheckCombo()
	{
		if (!this.CheckPressComboFlag())
		{
			return;
		}
		for (int i = 0; i < this._pressSkillIdList.Count; i++)
		{
			int skillID = this._pressSkillIdList[i];
			if (base.owner.IsCastingSkill())
			{
				base.owner.TriggerComboSkills(skillID);
			}
			else
			{
				base.owner.UseSkill(skillID, false);
			}
		}
	}

	// Token: 0x06017B05 RID: 97029 RVA: 0x0074CFD0 File Offset: 0x0074B3D0
	private void _SetComboSkillData(int skillId, bool isPress)
	{
		if (isPress)
		{
			if (!this._pressSkillIdList.Contains(skillId))
			{
				this._pressSkillIdList.Add(skillId);
			}
		}
		else if (this._pressSkillIdList.Contains(skillId))
		{
			this._pressSkillIdList.Remove(skillId);
		}
	}

	// Token: 0x06017B06 RID: 97030 RVA: 0x0074D023 File Offset: 0x0074B423
	private bool CheckPressComboFlag()
	{
		return base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.PressButtonComboSkill);
	}

	// Token: 0x0401105D RID: 69725
	private List<int> _registerSkillIdList = new List<int>();

	// Token: 0x0401105E RID: 69726
	private List<int> _pressSkillIdList = new List<int>();

	// Token: 0x0401105F RID: 69727
	private BeEvent.BeEventHandleNew _specialSkillComboHandle;
}
