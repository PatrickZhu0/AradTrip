using System;
using System.Collections.Generic;

// Token: 0x0200425A RID: 16986
public class Mechanism1019 : BeMechanism
{
	// Token: 0x0601780C RID: 96268 RVA: 0x0073B1C0 File Offset: 0x007395C0
	public Mechanism1019(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601780D RID: 96269 RVA: 0x0073B1D6 File Offset: 0x007395D6
	public override void OnInit()
	{
		base.OnInit();
		this.skillAttackAddRate = new VRate(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true));
	}

	// Token: 0x0601780E RID: 96270 RVA: 0x0073B20B File Offset: 0x0073960B
	public override void OnStart()
	{
		base.OnStart();
		this.AttackAdd(this.skillAttackAddRate, true);
	}

	// Token: 0x0601780F RID: 96271 RVA: 0x0073B220 File Offset: 0x00739620
	public override void OnFinish()
	{
		base.OnFinish();
		this.AttackAdd(this.skillAttackAddRate, false);
	}

	// Token: 0x06017810 RID: 96272 RVA: 0x0073B238 File Offset: 0x00739638
	private void AttackAdd(VRate rate, bool isAdd = true)
	{
		if (base.owner == null)
		{
			return;
		}
		Dictionary<int, BeSkill> skills = base.owner.GetSkills();
		if (skills == null)
		{
			return;
		}
		foreach (KeyValuePair<int, BeSkill> keyValuePair in skills)
		{
			int key = keyValuePair.Key;
			Dictionary<int, BeSkill>.Enumerator enumerator;
			KeyValuePair<int, BeSkill> keyValuePair2 = enumerator.Current;
			BeSkill value = keyValuePair2.Value;
			if (value != null)
			{
				if (value.skillCategory == 3 || value.skillCategory == 4)
				{
					if (isAdd)
					{
						value.attackAddRate += rate;
					}
					if (!isAdd)
					{
						value.attackAddRate -= rate;
					}
				}
			}
		}
	}

	// Token: 0x04010E46 RID: 69190
	private VRate skillAttackAddRate = 0;
}
