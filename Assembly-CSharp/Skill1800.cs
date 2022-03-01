using System;

// Token: 0x0200446E RID: 17518
public class Skill1800 : BeSkill
{
	// Token: 0x060185B5 RID: 99765 RVA: 0x00796D0D File Offset: 0x0079510D
	public Skill1800(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185B6 RID: 99766 RVA: 0x00796D24 File Offset: 0x00795124
	public override void OnInit()
	{
		base.OnInit();
		if (this.skillData.ValueA.Count > 0)
		{
			this.m_BuffId = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true));
		}
	}

	// Token: 0x060185B7 RID: 99767 RVA: 0x00796DA2 File Offset: 0x007951A2
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && base.owner.buffController.HasBuffByID(this.m_BuffId) == null;
	}

	// Token: 0x04011952 RID: 72018
	private int m_BuffId = 180014;
}
