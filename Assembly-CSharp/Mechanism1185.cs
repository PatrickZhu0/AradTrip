using System;

// Token: 0x020042EE RID: 17134
public class Mechanism1185 : BeMechanism
{
	// Token: 0x06017B53 RID: 97107 RVA: 0x0074EA3F File Offset: 0x0074CE3F
	public Mechanism1185(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B54 RID: 97108 RVA: 0x0074EA4C File Offset: 0x0074CE4C
	public override void OnInit()
	{
		this.mReduceCdSkillIDArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.mReduceCdSkillIDArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.mReduceTimeArray = new int[this.data.ValueB.Length];
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.mReduceTimeArray[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
		this.mReduceTimeRateArray = new VRate[this.data.ValueC.Length];
		for (int k = 0; k < this.data.ValueC.Length; k++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true);
			this.mReduceTimeRateArray[k] = ((valueFromUnionCell != 0) ? new VRate(valueFromUnionCell) : VRate.zero);
		}
	}

	// Token: 0x06017B55 RID: 97109 RVA: 0x0074EBAC File Offset: 0x0074CFAC
	public override void OnStart()
	{
		if (base.owner != null)
		{
			for (int i = 0; i < this.mReduceCdSkillIDArray.Length; i++)
			{
				BeSkill skill = base.owner.GetSkill(this.mReduceCdSkillIDArray[i]);
				int time = (i >= this.mReduceTimeArray.Length) ? 0 : this.mReduceTimeArray[i];
				VRate rate = (i >= this.mReduceTimeRateArray.Length) ? 0 : this.mReduceTimeRateArray[i];
				this.AddSkillCoolDownTime(skill, time, rate);
			}
		}
	}

	// Token: 0x06017B56 RID: 97110 RVA: 0x0074EC44 File Offset: 0x0074D044
	private void AddSkillCoolDownTime(BeSkill _skill, int _time, VRate _rate)
	{
		if (_skill == null)
		{
			return;
		}
		if (_skill.isCooldown && _time > 0)
		{
			_skill.AccTimeCD(_time);
		}
		if (_skill.isCooldown && _rate > VRate.zero)
		{
			_skill.AccTimeCD(_skill.GetCurrentCD() * _rate.factor);
		}
	}

	// Token: 0x0401108F RID: 69775
	protected int[] mReduceCdSkillIDArray;

	// Token: 0x04011090 RID: 69776
	protected int[] mReduceTimeArray;

	// Token: 0x04011091 RID: 69777
	protected VRate[] mReduceTimeRateArray;
}
