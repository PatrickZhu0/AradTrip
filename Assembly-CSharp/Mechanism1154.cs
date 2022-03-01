using System;
using System.Collections.Generic;

// Token: 0x020042CA RID: 17098
public class Mechanism1154 : BeMechanism
{
	// Token: 0x06017A8D RID: 96909 RVA: 0x0074A7AA File Offset: 0x00748BAA
	public Mechanism1154(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A8E RID: 96910 RVA: 0x0074A7E0 File Offset: 0x00748BE0
	public override void OnInit()
	{
		this.m_SkillIDListener.Clear();
		this.m_SkillIDReducer.Clear();
		this.m_SkillIDReduceTime.Clear();
		this.m_SkillIDReduceTimeRate.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_SkillIDListener.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		int count = this.data.ValueB.Count;
		for (int j = 0; j < count; j++)
		{
			this.m_SkillIDReducer.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		for (int k = 0; k < count; k++)
		{
			this.m_SkillIDReduceTime.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true));
		}
		for (int l = 0; l < count; l++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueD[l], this.level, true);
			this.m_SkillIDReduceTimeRate.Add((valueFromUnionCell != 0) ? new VRate(valueFromUnionCell) : VRate.zero);
		}
	}

	// Token: 0x06017A8F RID: 96911 RVA: 0x0074A954 File Offset: 0x00748D54
	public override void OnStart()
	{
		if (this.m_SkillIDReducer.Count != this.m_SkillIDReduceTime.Count && this.m_SkillIDReducer.Count != this.m_SkillIDReduceTimeRate.Count)
		{
			return;
		}
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.OnCastSkillEvent));
		}
	}

	// Token: 0x06017A90 RID: 96912 RVA: 0x0074A9C4 File Offset: 0x00748DC4
	private void OnCastSkillEvent(object[] args)
	{
		int item = (int)args[0];
		if (this.m_SkillIDListener.Contains(item))
		{
			for (int i = 0; i < this.m_SkillIDReducer.Count; i++)
			{
				BeSkill skill = base.owner.GetSkill(this.m_SkillIDReducer[i]);
				this.AddSkillCoolDownTime(skill, this.m_SkillIDReduceTime[i], this.m_SkillIDReduceTimeRate[i]);
			}
		}
	}

	// Token: 0x06017A91 RID: 96913 RVA: 0x0074AA3E File Offset: 0x00748E3E
	private void AddSkillCoolDownTime(BeSkill _skill, int _time, VRate _rate)
	{
		if (_skill == null)
		{
			return;
		}
		if (!_skill.isCooldown)
		{
			_skill.AccTimeCD(_time);
		}
		if (!_skill.isCooldown)
		{
			_skill.AccTimeCD(_skill.GetCurrentCD() * _rate.factor);
		}
	}

	// Token: 0x04011008 RID: 69640
	private List<int> m_SkillIDListener = new List<int>();

	// Token: 0x04011009 RID: 69641
	private List<int> m_SkillIDReducer = new List<int>();

	// Token: 0x0401100A RID: 69642
	private List<int> m_SkillIDReduceTime = new List<int>();

	// Token: 0x0401100B RID: 69643
	private List<VRate> m_SkillIDReduceTimeRate = new List<VRate>();
}
