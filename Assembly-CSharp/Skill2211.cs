using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x02004498 RID: 17560
public class Skill2211 : BeSkill
{
	// Token: 0x060186A2 RID: 100002 RVA: 0x0079D07C File Offset: 0x0079B47C
	public Skill2211(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060186A3 RID: 100003 RVA: 0x0079D0D8 File Offset: 0x0079B4D8
	public override void OnInit()
	{
		this.m_MonsterIdList.Clear();
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
				this.m_MonsterIdList.Add(valueFromUnionCell);
			}
		}
		this.m_AutoCancelTime = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x060186A4 RID: 100004 RVA: 0x0079D174 File Offset: 0x0079B574
	private bool FunctionIsOpen()
	{
		return base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.Skill2211ChargeBug);
	}

	// Token: 0x060186A5 RID: 100005 RVA: 0x0079D19E File Offset: 0x0079B59E
	public override void OnStart()
	{
		this.RemoveHandle();
		this.m_Monster = null;
		this.m_SummonHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			if (this.FunctionIsOpen())
			{
				int monsterId = this.GetMonsterId();
				if (monsterId != 0)
				{
					BeActor beActor = (BeActor)args[0];
					if (beActor.GetEntityData().monsterID.Equals(monsterId))
					{
						this.m_Monster = beActor;
						this.m_AddBuffHandle = this.m_Monster.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args2)
						{
							BeBuff beBuff = (BeBuff)args2[0];
							if (beBuff.buffID == this.GetBuffId() && this.m_Monster != null)
							{
								Mechanism23 mechanism = this.m_Monster.GetMechanism(this.GetMechanismId()) as Mechanism23;
								if (mechanism != null)
								{
									mechanism.SetAttackTimeAcc(base.GetSkillSpeedFactor());
								}
							}
						});
					}
				}
			}
			else
			{
				BeActor beActor2 = (BeActor)args[0];
				if (this.m_MonsterIdList.Contains(beActor2.GetEntityData().monsterID))
				{
					this.m_Monster = beActor2;
					this.m_AddBuffHandle = this.m_Monster.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args2)
					{
						BeBuff beBuff = (BeBuff)args2[0];
						if (Array.IndexOf<int>(this.m_BuffIdArray, beBuff.buffID) != -1 && this.m_Monster != null)
						{
							BeMechanism mechanismByIndex = this.m_Monster.GetMechanismByIndex(23);
							if (mechanismByIndex != null)
							{
								Mechanism23 mechanism = mechanismByIndex as Mechanism23;
								if (mechanism != null)
								{
									mechanism.SetAttackTimeAcc(base.GetSkillSpeedFactor());
								}
							}
						}
					});
				}
			}
		});
	}

	// Token: 0x060186A6 RID: 100006 RVA: 0x0079D1CC File Offset: 0x0079B5CC
	public override void OnCancel()
	{
		this.SetMonsterDead();
	}

	// Token: 0x060186A7 RID: 100007 RVA: 0x0079D1D4 File Offset: 0x0079B5D4
	public override void OnFinish()
	{
		this.SetMonsterDead();
	}

	// Token: 0x060186A8 RID: 100008 RVA: 0x0079D1DC File Offset: 0x0079B5DC
	protected void SetMonsterDead()
	{
		if (this.FunctionIsOpen())
		{
			int monsterId = this.GetMonsterId();
			if (monsterId != 0)
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindActorById2(list, monsterId, false);
				if (list.Count > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						BeActor beActor = list[i];
						if (beActor != null && !beActor.IsDead() && beActor.GetOwner() == base.owner)
						{
							beActor.DoDead(false);
						}
					}
				}
				ListPool<BeActor>.Release(list);
			}
		}
		else if (this.m_Monster != null && !this.m_Monster.IsDeadOrRemoved() && this.m_Monster.GetOwner() == base.owner)
		{
			this.m_Monster.DoDead(false);
			this.m_Monster = null;
		}
	}

	// Token: 0x060186A9 RID: 100009 RVA: 0x0079D2C0 File Offset: 0x0079B6C0
	protected int GetMonsterId()
	{
		int result;
		if (BattleMain.IsModePvP(base.battleType))
		{
			result = ((!this.charged) ? this.m_MonsterIdList[2] : this.m_MonsterIdList[3]);
		}
		else
		{
			result = ((!this.charged) ? this.m_MonsterIdList[0] : this.m_MonsterIdList[1]);
		}
		return result;
	}

	// Token: 0x060186AA RID: 100010 RVA: 0x0079D338 File Offset: 0x0079B738
	protected int GetMechanismId()
	{
		int result;
		if (BattleMain.IsModePvP(base.battleType))
		{
			result = ((!this.charged) ? this.m_MechanismIdArray[2] : this.m_MechanismIdArray[3]);
		}
		else
		{
			result = ((!this.charged) ? this.m_MechanismIdArray[0] : this.m_MechanismIdArray[1]);
		}
		return result;
	}

	// Token: 0x060186AB RID: 100011 RVA: 0x0079D3A0 File Offset: 0x0079B7A0
	protected int GetBuffId()
	{
		int result;
		if (BattleMain.IsModePvP(base.battleType))
		{
			result = ((!this.charged) ? this.m_BuffIdArray[2] : this.m_BuffIdArray[3]);
		}
		else
		{
			result = ((!this.charged) ? this.m_BuffIdArray[0] : this.m_BuffIdArray[1]);
		}
		return result;
	}

	// Token: 0x060186AC RID: 100012 RVA: 0x0079D407 File Offset: 0x0079B807
	protected void RemoveHandle()
	{
		if (this.m_SummonHandle != null)
		{
			this.m_SummonHandle.Remove();
			this.m_SummonHandle = null;
		}
		if (this.m_AddBuffHandle != null)
		{
			this.m_AddBuffHandle.Remove();
			this.m_AddBuffHandle = null;
		}
	}

	// Token: 0x040119E7 RID: 72167
	protected List<int> m_MonsterIdList = new List<int>();

	// Token: 0x040119E8 RID: 72168
	protected int m_AutoCancelTime = 10000;

	// Token: 0x040119E9 RID: 72169
	protected BeEventHandle m_SummonHandle;

	// Token: 0x040119EA RID: 72170
	protected BeEventHandle m_AddBuffHandle;

	// Token: 0x040119EB RID: 72171
	protected int[] m_BuffIdArray = new int[]
	{
		221100,
		221101,
		221102,
		221103
	};

	// Token: 0x040119EC RID: 72172
	protected int[] m_MechanismIdArray = new int[]
	{
		5007,
		5008,
		5009,
		5010
	};

	// Token: 0x040119ED RID: 72173
	protected BeActor m_Monster;
}
