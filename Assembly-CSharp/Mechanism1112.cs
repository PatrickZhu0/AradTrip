using System;

// Token: 0x020042A9 RID: 17065
public class Mechanism1112 : BeMechanism
{
	// Token: 0x060179BD RID: 96701 RVA: 0x00745E2E File Offset: 0x0074422E
	public Mechanism1112(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179BE RID: 96702 RVA: 0x00745E38 File Offset: 0x00744238
	public override void OnInit()
	{
		this.m_maxHurtValue = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_spellSkillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_isTimeRelated = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
		this.m_reduceHurtValue = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x060179BF RID: 96703 RVA: 0x00745EF1 File Offset: 0x007442F1
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHurt, new BeEventHandle.Del(this._onBeHit));
	}

	// Token: 0x060179C0 RID: 96704 RVA: 0x00745F14 File Offset: 0x00744314
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.m_needSpellSkill)
		{
			this._tryUseSkill();
			return;
		}
		if (!this.m_isTimeRelated)
		{
			return;
		}
		if (this.m_curHurtValue <= 0)
		{
			return;
		}
		this.m_durTime += deltaTime;
		if (this.m_durTime < 200)
		{
			return;
		}
		this.m_durTime -= 200;
		int curHurtValue = this.m_curHurtValue;
		this.m_curHurtValue -= this.m_reduceHurtValue;
		if (this.m_curHurtValue < 0)
		{
			this.m_curHurtValue = 0;
		}
		if (this.m_curHurtValue <= 0)
		{
			base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
		}
		else
		{
			this._updateProgress(this.m_curHurtValue - curHurtValue);
		}
	}

	// Token: 0x060179C1 RID: 96705 RVA: 0x00745FE0 File Offset: 0x007443E0
	private void _onBeHit(object[] args)
	{
		if (this.m_needSpellSkill)
		{
			return;
		}
		int num = (int)args[0];
		if (num <= 0)
		{
			return;
		}
		this.m_curHurtValue += num;
		this._updateProgress(num);
		if (this.m_curHurtValue >= this.m_maxHurtValue)
		{
			this.m_needSpellSkill = true;
			this._tryUseSkill();
		}
	}

	// Token: 0x060179C2 RID: 96706 RVA: 0x00746040 File Offset: 0x00744440
	private bool _canUseSkill()
	{
		return base.owner == null || base.owner.GetStateGraph() == null || (!base.owner.GetStateGraph().CurrentStateHasTag(1) && (!base.owner.GetStateGraph().CurrentStateHasTag(2) || base.owner.HasTag(2)));
	}

	// Token: 0x060179C3 RID: 96707 RVA: 0x007460A8 File Offset: 0x007444A8
	private void _updateProgress(int addValue)
	{
		int spellBarDuration = base.owner.GetSpellBarDuration(eDungeonCharactorBar.Progress);
		if (spellBarDuration <= 0)
		{
			string text = string.Empty;
			if (this.data.StringValueA.Count > 0)
			{
				text = this.data.StringValueA[0];
			}
			SpellBar spellBar = base.owner.StartSpellBar(eDungeonCharactorBar.Progress, this.m_maxHurtValue, true, text, false);
			spellBar.autoAcc = false;
			spellBar.reverse = false;
			spellBar.autodelete = false;
		}
		base.owner.AddSpellBarProgress(eDungeonCharactorBar.Progress, new VFactor((long)addValue, (long)this.m_maxHurtValue));
	}

	// Token: 0x060179C4 RID: 96708 RVA: 0x00746144 File Offset: 0x00744544
	private void _tryUseSkill()
	{
		if (base.owner != null && !base.owner.IsDead() && this._canUseSkill() && base.owner.CanUseSkill(this.m_spellSkillID) && base.owner.UseSkill(this.m_spellSkillID, false))
		{
			this.m_curHurtValue = 0;
			base.owner.StopSpellBar(eDungeonCharactorBar.Progress, true);
			this.m_needSpellSkill = false;
			this.m_durTime = 0;
		}
	}

	// Token: 0x04010F7D RID: 69501
	private int m_maxHurtValue;

	// Token: 0x04010F7E RID: 69502
	private int m_spellSkillID;

	// Token: 0x04010F7F RID: 69503
	private int m_curHurtValue;

	// Token: 0x04010F80 RID: 69504
	private bool m_isTimeRelated;

	// Token: 0x04010F81 RID: 69505
	private int m_reduceHurtValue;

	// Token: 0x04010F82 RID: 69506
	private int m_durTime;

	// Token: 0x04010F83 RID: 69507
	private bool m_needSpellSkill;
}
