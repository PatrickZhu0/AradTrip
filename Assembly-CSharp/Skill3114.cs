using System;

// Token: 0x020044BE RID: 17598
public class Skill3114 : BeSkill
{
	// Token: 0x060187BB RID: 100283 RVA: 0x007A4A24 File Offset: 0x007A2E24
	public Skill3114(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187BC RID: 100284 RVA: 0x007A4A30 File Offset: 0x007A2E30
	public override void OnInit()
	{
		this.m_PveBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.m_PvpBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x060187BD RID: 100285 RVA: 0x007A4A83 File Offset: 0x007A2E83
	public override void OnPostInit()
	{
		this.DoEffect();
	}

	// Token: 0x060187BE RID: 100286 RVA: 0x007A4A8C File Offset: 0x007A2E8C
	protected void DoEffect()
	{
		if (!BattleMain.IsModePvP(base.battleType))
		{
			base.owner.buffController.RemoveBuff(this.m_PveBuffId, 0, 0);
			base.owner.buffController.TryAddBuff(this.m_PveBuffId, -1, base.level);
		}
		else
		{
			base.owner.buffController.RemoveBuff(this.m_PvpBuffId, 0, 0);
			base.owner.buffController.TryAddBuff(this.m_PvpBuffId, -1, base.level);
		}
	}

	// Token: 0x04011AA6 RID: 72358
	protected int m_PveBuffId;

	// Token: 0x04011AA7 RID: 72359
	protected int m_PvpBuffId;
}
