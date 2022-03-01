using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004401 RID: 17409
public class Mechanism65 : BeMechanism
{
	// Token: 0x060182C2 RID: 99010 RVA: 0x007857AA File Offset: 0x00783BAA
	public Mechanism65(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182C3 RID: 99011 RVA: 0x007857D4 File Offset: 0x00783BD4
	public override void OnInit()
	{
		this.m_AttackType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_MonsterType = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			for (int i = 0; i < this.data.ValueC.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
				this.m_MonsterIdList.Add(valueFromUnionCell);
			}
		}
		this.m_BuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		for (int j = 0; j < this.data.ValueE.Count; j++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
		}
	}

	// Token: 0x060182C4 RID: 99012 RVA: 0x0078590D File Offset: 0x00783D0D
	public override void OnStart()
	{
		this.RemoveHandle();
		if (this.m_AttackType == 0)
		{
			this.AttackHandle();
		}
		else if (this.m_AttackType == 1)
		{
			this.OnBeHitHandle();
		}
	}

	// Token: 0x060182C5 RID: 99013 RVA: 0x0078593D File Offset: 0x00783D3D
	protected void AttackHandle()
	{
		this.m_OnHitOtherHandle = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor != null && !beActor.IsDead() && (beActor.GetEntityData().type == this.m_MonsterType || (beActor.GetEntityData().isSummonMonster && this.m_MonsterType == Global.SUMMONMONSTERTYPE)))
			{
				EffectTable hurtData = args[1] as EffectTable;
				if (this.HaveMonster(beActor) && this.CheckSkillUseId(hurtData))
				{
					beActor.buffController.TryAddBuffInfo(this.m_BuffInfoId, base.owner, this.level);
				}
			}
		});
	}

	// Token: 0x060182C6 RID: 99014 RVA: 0x0078595E File Offset: 0x00783D5E
	protected void OnBeHitHandle()
	{
		this.m_OnBeHitHandle = base.owner.RegisterEvent(BeEventType.onBeforeOtherHit, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor != null && !beActor.IsDead() && (beActor.GetEntityData().type == this.m_MonsterType || (beActor.GetEntityData().isSummonMonster && this.m_MonsterType == Global.SUMMONMONSTERTYPE)))
			{
				EffectTable hurtData = args[1] as EffectTable;
				if (this.HaveMonster(beActor) && this.CheckSkillUseId(hurtData))
				{
					base.owner.buffController.TryAddBuffInfo(this.m_BuffInfoId, base.owner, this.level);
				}
			}
		});
	}

	// Token: 0x060182C7 RID: 99015 RVA: 0x00785980 File Offset: 0x00783D80
	protected bool HaveMonster(BeActor monster)
	{
		if (this.m_MonsterIdList.Count <= 0)
		{
			return true;
		}
		bool result = false;
		for (int i = 0; i < this.m_MonsterIdList.Count; i++)
		{
			int num = this.m_MonsterIdList[i];
			if (monster.GetEntityData().MonsterIDEqual(this.m_MonsterIdList[i]))
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x060182C8 RID: 99016 RVA: 0x007859EA File Offset: 0x00783DEA
	protected bool CheckSkillUseId(EffectTable hurtData)
	{
		return this.skillIdList.Count <= 0 || hurtData == null || this.skillIdList.Contains(hurtData.SkillID);
	}

	// Token: 0x060182C9 RID: 99017 RVA: 0x00785A20 File Offset: 0x00783E20
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x060182CA RID: 99018 RVA: 0x00785A28 File Offset: 0x00783E28
	protected void RemoveHandle()
	{
		if (this.m_OnHitOtherHandle != null)
		{
			this.m_OnHitOtherHandle.Remove();
			this.m_OnHitOtherHandle = null;
		}
		if (this.m_OnBeHitHandle != null)
		{
			this.m_OnBeHitHandle.Remove();
			this.m_OnBeHitHandle = null;
		}
	}

	// Token: 0x04011714 RID: 71444
	protected int m_AttackType = -1;

	// Token: 0x04011715 RID: 71445
	protected int m_MonsterType;

	// Token: 0x04011716 RID: 71446
	protected List<int> m_MonsterIdList = new List<int>();

	// Token: 0x04011717 RID: 71447
	protected int m_BuffInfoId;

	// Token: 0x04011718 RID: 71448
	protected List<int> skillIdList = new List<int>();

	// Token: 0x04011719 RID: 71449
	protected BeEventHandle m_OnHitOtherHandle;

	// Token: 0x0401171A RID: 71450
	protected BeEventHandle m_OnBeHitHandle;
}
