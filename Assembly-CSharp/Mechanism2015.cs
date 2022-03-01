using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004345 RID: 17221
public class Mechanism2015 : BeMechanism
{
	// Token: 0x06017D6A RID: 97642 RVA: 0x0075DBCE File Offset: 0x0075BFCE
	public Mechanism2015(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D6B RID: 97643 RVA: 0x0075DC10 File Offset: 0x0075C010
	public override void OnInit()
	{
		base.OnInit();
		this.entityIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.entityIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.summonRateArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.summonRateArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.summonRateArr[2] = TableManager.GetValueFromUnionCell(this.data.ValueB[2], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
	}

	// Token: 0x06017D6C RID: 97644 RVA: 0x0075DD44 File Offset: 0x0075C144
	public override void OnStart()
	{
		this.SetEquipAdd();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			int skillId = (int)args[2];
			BeActor actor = (BeActor)args[0];
			this.CheckAttackHit(skillId, actor);
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
		{
			if (!(bool)args[4])
			{
				return;
			}
			int num = (int)args[1];
			if (num == 37034)
			{
				return;
			}
			BeActor actor = (BeActor)args[3];
			EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(num, string.Empty, string.Empty);
			this.CheckBeHit(tableItem, actor);
		});
	}

	// Token: 0x06017D6D RID: 97645 RVA: 0x0075DD95 File Offset: 0x0075C195
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateTimeAcc(deltaTime);
	}

	// Token: 0x06017D6E RID: 97646 RVA: 0x0075DDA5 File Offset: 0x0075C1A5
	private void UpdateTimeAcc(int deltaTime)
	{
		if (this.curSummonRayCount == 0)
		{
			return;
		}
		if (this.curTimeAcc >= this.timeAcc)
		{
			this.curTimeAcc = 0;
			this.curSummonRayCount = 0;
		}
		else
		{
			this.curTimeAcc += deltaTime;
		}
	}

	// Token: 0x06017D6F RID: 97647 RVA: 0x0075DDE8 File Offset: 0x0075C1E8
	private void CheckAttackHit(int skillId, BeActor actor)
	{
		if (base.owner == null || base.owner.GetEntityData() == null)
		{
			return;
		}
		if (this.curSummonRayCount >= 3)
		{
			return;
		}
		this.curSummonRayCount++;
		int comboSkillId = BeUtility.GetComboSkillId(base.owner, skillId);
		if (this.skillIdList.Contains(skillId) || comboSkillId == base.owner.GetEntityData().normalAttackID)
		{
			this.SummonRay(this.summonRateArr[0], actor, skillId, this.entityIdArr[0]);
		}
	}

	// Token: 0x06017D70 RID: 97648 RVA: 0x0075DE78 File Offset: 0x0075C278
	private void CheckBeHit(EffectTable effectData, BeActor actor)
	{
		if (effectData == null)
		{
			return;
		}
		if (effectData.DamageType == EffectTable.eDamageType.MAGIC)
		{
			this.SummonRay(this.summonRateArr[1], actor, effectData.SkillID, this.entityIdArr[1]);
		}
		else if (effectData.DamageType == EffectTable.eDamageType.PHYSIC)
		{
			this.SummonRay(this.summonRateArr[2], actor, effectData.SkillID, this.entityIdArr[1]);
		}
	}

	// Token: 0x06017D71 RID: 97649 RVA: 0x0075DEE4 File Offset: 0x0075C2E4
	private void SummonRay(int rate, BeActor target, int skillId, int entityId)
	{
		if (target == null)
		{
			return;
		}
		int num = base.FrameRandom.InRange(0, GlobalLogic.VALUE_1000);
		if (num > rate)
		{
			return;
		}
		VInt3 summonPos = target.GetPosition();
		if (skillId == 3705)
		{
			base.owner.delayCaller.DelayCall(66, delegate
			{
				if (target != null && !target.IsDead())
				{
					summonPos = target.GetPosition();
				}
				this.AddEntity(entityId, summonPos);
			}, 0, 0, false);
		}
		else
		{
			this.AddEntity(entityId, summonPos);
		}
	}

	// Token: 0x06017D72 RID: 97650 RVA: 0x0075DF88 File Offset: 0x0075C388
	private void AddEntity(int entityId, VInt3 pos)
	{
		if (this.attachBuff == null)
		{
			return;
		}
		if (this.attachBuff.releaser == null || this.attachBuff.releaser.IsDead())
		{
			return;
		}
		this.attachBuff.releaser.AddEntity(entityId, pos, 1, 0);
	}

	// Token: 0x06017D73 RID: 97651 RVA: 0x0075DFDC File Offset: 0x0075C3DC
	private void SetEquipAdd()
	{
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2023 mechanism = mechanismList[i] as Mechanism2023;
			if (mechanism != null)
			{
				this.summonRateArr[0] += mechanism.addEntityRate;
				this.summonRateArr[1] += mechanism.addEntityRate;
			}
		}
	}

	// Token: 0x0401127F RID: 70271
	private int[] entityIdArr = new int[2];

	// Token: 0x04011280 RID: 70272
	private int[] summonRateArr = new int[]
	{
		1000,
		1000,
		1000
	};

	// Token: 0x04011281 RID: 70273
	private List<int> skillIdList = new List<int>();

	// Token: 0x04011282 RID: 70274
	private int curSummonRayCount;

	// Token: 0x04011283 RID: 70275
	private int timeAcc = 66;

	// Token: 0x04011284 RID: 70276
	private int curTimeAcc;
}
