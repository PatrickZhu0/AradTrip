using System;

// Token: 0x020043DA RID: 17370
public class Mechanism29 : BeMechanism
{
	// Token: 0x06018198 RID: 98712 RVA: 0x0077D688 File Offset: 0x0077BA88
	public Mechanism29(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018199 RID: 98713 RVA: 0x0077D6AC File Offset: 0x0077BAAC
	public override void OnInit()
	{
		this.m_CurrEffectCount = 0;
		this.m_EffectHp = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_SkillId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_EffectCountMax = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_BossInvincibleTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		if (this.data.ValueE.Count > 0)
		{
			this.m_StopAI = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.m_DunfuBuffId = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		}
	}

	// Token: 0x0601819A RID: 98714 RVA: 0x0077D7DC File Offset: 0x0077BBDC
	public override void OnStart()
	{
		base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (base.owner.GetEntityData().GetHP() <= this.m_EffectHp)
			{
				base.owner.buffController.RemoveInPassiveBuff();
				if (this.m_CurrEffectCount < this.m_EffectCountMax && base.owner.HasSkill(this.m_SkillId))
				{
					bool flag = base.owner.UseSkill(this.m_SkillId, true);
					if (flag)
					{
						if (this.m_DunfuBuffId != -1)
						{
							base.owner.buffController.TryAddBuff(this.m_DunfuBuffId, -1, this.level);
						}
						if (this.m_StopAI == 1)
						{
							base.owner.aiManager.Stop();
						}
						base.owner.protectManager.SetEnable(false);
						base.owner.GetEntityData().SetHP(1);
						this.m_CurrEffectCount++;
						if (this.m_BossInvincibleTime > 0)
						{
							base.owner.buffController.TryAddBuff(2, this.m_BossInvincibleTime, 1);
						}
					}
				}
			}
		});
	}

	// Token: 0x040115F7 RID: 71159
	protected int m_EffectHp;

	// Token: 0x040115F8 RID: 71160
	protected int m_SkillId = 5574;

	// Token: 0x040115F9 RID: 71161
	protected int m_EffectCountMax = 1;

	// Token: 0x040115FA RID: 71162
	protected int m_BossInvincibleTime;

	// Token: 0x040115FB RID: 71163
	protected int m_StopAI;

	// Token: 0x040115FC RID: 71164
	protected int m_DunfuBuffId = -1;

	// Token: 0x040115FD RID: 71165
	protected int m_CurrEffectCount;
}
