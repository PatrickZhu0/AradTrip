using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043DC RID: 17372
public class Mechanism30 : BeMechanism
{
	// Token: 0x060181A0 RID: 98720 RVA: 0x0077DA54 File Offset: 0x0077BE54
	public Mechanism30(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181A1 RID: 98721 RVA: 0x0077DA80 File Offset: 0x0077BE80
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this.m_MonsterIdList.Add(valueFromUnionCell);
		}
		this.m_HpPercent = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			for (int j = 0; j < this.data.ValueC.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
				this.m_BuffIdList.Add(valueFromUnionCell2);
			}
		}
		if (this.data.ValueD.Count > 0)
		{
			this.m_SkillId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		this.Z_MustUseSkill = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
	}

	// Token: 0x060181A2 RID: 98722 RVA: 0x0077DBDD File Offset: 0x0077BFDD
	public override void OnStart()
	{
		this.m_EffectFlag = false;
		this.m_UseSkillFalg = false;
		this.m_HpRate = new VFactor((long)this.m_HpPercent, (long)VInt.Float2VIntValue(0.1f));
	}

	// Token: 0x060181A3 RID: 98723 RVA: 0x0077DC0C File Offset: 0x0077C00C
	public override void OnUpdate(int deltaTime)
	{
		if (!this.Z_MustUseSkill)
		{
			if (!this.m_EffectFlag)
			{
				this.m_EffectFlag = this.CheckMonsterHpRate();
				if (this.m_EffectFlag)
				{
					this.DoMonsterAction();
				}
			}
		}
		else if (this.CheckMonsterHpRate() && !this.m_UseSkillFalg)
		{
			this.DoUseSkillNew();
		}
	}

	// Token: 0x060181A4 RID: 98724 RVA: 0x0077DC70 File Offset: 0x0077C070
	protected bool CheckMonsterHpRate()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		for (int i = 0; i < this.m_MonsterIdList.Count; i++)
		{
			if (this.m_HpRate == 0L)
			{
				if (base.owner.CurrentBeScene.CheckMonsterAlive(this.m_MonsterIdList[i]))
				{
					ListPool<BeActor>.Release(list);
					return false;
				}
			}
			else
			{
				base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterIdList[i]);
				if (list.Count > 0 && list[0].GetEntityData().GetHPRate() > this.m_HpRate)
				{
					ListPool<BeActor>.Release(list);
					return false;
				}
			}
		}
		ListPool<BeActor>.Release(list);
		return true;
	}

	// Token: 0x060181A5 RID: 98725 RVA: 0x0077DD3C File Offset: 0x0077C13C
	protected void DoMonsterAction()
	{
		for (int i = 0; i < this.m_BuffIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.m_BuffIdList[i], 0, 0);
		}
		if (base.owner.aiManager.CanAIUseSkill(this.m_SkillId) && base.owner.CanUseSkill(this.m_SkillId))
		{
			base.owner.UseSkill(this.m_SkillId, false);
		}
	}

	// Token: 0x060181A6 RID: 98726 RVA: 0x0077DDC7 File Offset: 0x0077C1C7
	protected void DoUseSkillNew()
	{
		if (base.owner.CanUseSkill(this.m_SkillId))
		{
			this.m_UseSkillFalg = true;
			base.owner.UseSkill(this.m_SkillId, false);
		}
	}

	// Token: 0x04011600 RID: 71168
	protected List<int> m_MonsterIdList = new List<int>();

	// Token: 0x04011601 RID: 71169
	protected int m_HpPercent;

	// Token: 0x04011602 RID: 71170
	protected List<int> m_BuffIdList = new List<int>();

	// Token: 0x04011603 RID: 71171
	protected int m_SkillId;

	// Token: 0x04011604 RID: 71172
	protected bool Z_MustUseSkill;

	// Token: 0x04011605 RID: 71173
	protected bool m_EffectFlag;

	// Token: 0x04011606 RID: 71174
	protected VFactor m_HpRate = VFactor.zero;

	// Token: 0x04011607 RID: 71175
	protected bool m_UseSkillFalg;
}
