using System;

// Token: 0x02004460 RID: 17504
public class Skill1614 : BeSkill
{
	// Token: 0x0601851D RID: 99613 RVA: 0x00792EB9 File Offset: 0x007912B9
	public Skill1614(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601851E RID: 99614 RVA: 0x00792ED8 File Offset: 0x007912D8
	public sealed override void OnPostInit()
	{
		this.buffProb = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		BeSkill skill = base.owner.GetSkill(this.skillID);
		if (skill != null)
		{
			BuffInfoData value = new BuffInfoData
			{
				buffID = this.buffID,
				prob = this.buffProb
			};
			if (skill.buffEnhanceList.ContainsKey(this.buffID))
			{
				skill.buffEnhanceList.Remove(this.buffID);
			}
			skill.buffEnhanceList.Add(this.buffID, value);
		}
	}

	// Token: 0x040118C7 RID: 71879
	private new int skillID = 1509;

	// Token: 0x040118C8 RID: 71880
	private int buffID = 5;

	// Token: 0x040118C9 RID: 71881
	private int buffProb;
}
