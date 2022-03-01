using System;

// Token: 0x02004454 RID: 17492
public class Skill1305 : BeSkill
{
	// Token: 0x06018499 RID: 99481 RVA: 0x00790215 File Offset: 0x0078E615
	public Skill1305(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601849A RID: 99482 RVA: 0x00790244 File Offset: 0x0078E644
	public override void OnInit()
	{
		this.m_CanBoomBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		if (this.skillData.ValueB.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
				this.m_BoomMonsterIdArray[i] = valueFromUnionCell;
			}
		}
		if (this.skillData.ValueC.Count > 0)
		{
			for (int j = 0; j < this.skillData.ValueC.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueC[j], base.level, true);
				this.m_BoomEntityIdArray[j] = valueFromUnionCell2;
			}
		}
	}

	// Token: 0x0601849B RID: 99483 RVA: 0x00790330 File Offset: 0x0078E730
	public override void OnStart()
	{
		this.InitData();
		this.RemoveHandle();
		this.m_AddBuffHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = (BeBuff)args[0];
			if (beBuff.buffID == this.m_CanBoomBuff)
			{
				this.CanBoom();
			}
		});
		this.m_PassDoorHandle = base.owner.RegisterEvent(BeEventType.onStartPassDoor, delegate(object[] args)
		{
			this.ClearDeadHandle();
		});
		this.m_PassTowerHandle = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, delegate(object[] args)
		{
			this.ClearDeadHandle();
		});
		this.m_SummonMonsterHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor != null && !beActor.IsDead() && beActor.GetEntityData().MonsterIDEqual(this.GetMonsterId()))
			{
				this.m_SummonMonster = beActor;
				this.m_MonsterPos = beActor.GetPosition();
				this.m_MonsterDeadHandle = beActor.RegisterEvent(BeEventType.onDead, delegate(object[] args1)
				{
					this.MonsterDead();
				});
			}
		});
	}

	// Token: 0x0601849C RID: 99484 RVA: 0x007903C4 File Offset: 0x0078E7C4
	public override void OnClickAgain()
	{
		if (this.m_CanBoom)
		{
			this.SetMonsterDead();
		}
	}

	// Token: 0x0601849D RID: 99485 RVA: 0x007903D7 File Offset: 0x0078E7D7
	public override void OnCancel()
	{
		this.End();
	}

	// Token: 0x0601849E RID: 99486 RVA: 0x007903DF File Offset: 0x0078E7DF
	public override void OnFinish()
	{
		this.End();
	}

	// Token: 0x0601849F RID: 99487 RVA: 0x007903E7 File Offset: 0x0078E7E7
	protected void InitData()
	{
		this.m_MonsterPos = VInt3.zero;
		this.m_CanBoom = false;
		this.m_SummonMonster = null;
	}

	// Token: 0x060184A0 RID: 99488 RVA: 0x00790402 File Offset: 0x0078E802
	protected void End()
	{
		if (this.m_SummonMonster == null)
		{
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
	}

	// Token: 0x060184A1 RID: 99489 RVA: 0x00790416 File Offset: 0x0078E816
	protected void CanBoom()
	{
		this.m_CanBoom = true;
		if (base.button != null)
		{
			base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060184A2 RID: 99490 RVA: 0x00790440 File Offset: 0x0078E840
	protected void ClearDeadHandle()
	{
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
	}

	// Token: 0x060184A3 RID: 99491 RVA: 0x0079048F File Offset: 0x0078E88F
	protected void SetMonsterDead()
	{
		if (this.m_SummonMonster != null)
		{
			this.m_SummonMonster.DoDead(false);
			this.m_SummonMonster = null;
		}
	}

	// Token: 0x060184A4 RID: 99492 RVA: 0x007904B0 File Offset: 0x0078E8B0
	protected void MonsterDead()
	{
		int entityID = (!BattleMain.IsModePvP(base.battleType)) ? this.m_BoomEntityIdArray[0] : this.m_BoomEntityIdArray[1];
		base.owner.AddEntity(entityID, this.m_MonsterPos, base.level, 0);
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060184A5 RID: 99493 RVA: 0x00790524 File Offset: 0x0078E924
	protected int GetMonsterId()
	{
		return (!BattleMain.IsModePvP(base.battleType)) ? this.m_BoomMonsterIdArray[0] : this.m_BoomMonsterIdArray[1];
	}

	// Token: 0x060184A6 RID: 99494 RVA: 0x00790558 File Offset: 0x0078E958
	protected void RemoveHandle()
	{
		if (this.m_AddBuffHandle != null)
		{
			this.m_AddBuffHandle.Remove();
			this.m_AddBuffHandle = null;
		}
		if (this.m_SummonMonsterHandle != null)
		{
			this.m_SummonMonsterHandle.Remove();
			this.m_SummonMonsterHandle = null;
		}
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
		if (this.m_PassDoorHandle != null)
		{
			this.m_PassDoorHandle.Remove();
			this.m_PassDoorHandle = null;
		}
		if (this.m_PassTowerHandle != null)
		{
			this.m_PassTowerHandle.Remove();
			this.m_PassTowerHandle = null;
		}
	}

	// Token: 0x0401186F RID: 71791
	protected int m_CanBoomBuff;

	// Token: 0x04011870 RID: 71792
	protected int[] m_BoomMonsterIdArray = new int[2];

	// Token: 0x04011871 RID: 71793
	protected int[] m_BoomEntityIdArray = new int[2];

	// Token: 0x04011872 RID: 71794
	protected BeEventHandle m_AddBuffHandle;

	// Token: 0x04011873 RID: 71795
	protected BeEventHandle m_SummonMonsterHandle;

	// Token: 0x04011874 RID: 71796
	protected BeEventHandle m_MonsterDeadHandle;

	// Token: 0x04011875 RID: 71797
	protected BeActor m_SummonMonster;

	// Token: 0x04011876 RID: 71798
	protected bool m_CanBoom;

	// Token: 0x04011877 RID: 71799
	protected VInt3 m_MonsterPos = VInt3.zero;

	// Token: 0x04011878 RID: 71800
	protected BeEventHandle m_PassDoorHandle;

	// Token: 0x04011879 RID: 71801
	protected BeEventHandle m_PassTowerHandle;
}
