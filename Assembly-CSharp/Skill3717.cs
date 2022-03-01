using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044D5 RID: 17621
public class Skill3717 : BeSkill
{
	// Token: 0x0601886C RID: 100460 RVA: 0x007A7F04 File Offset: 0x007A6304
	public Skill3717(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601886D RID: 100461 RVA: 0x007A7F70 File Offset: 0x007A6370
	public override void OnInit()
	{
		base.OnInit();
		this.summonEntityIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.summonEntityIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		this.hurtIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.hurtIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true);
		this.monsterIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.monsterIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		this.startEnterNextFlag = "371701";
		this.endEnterNextFlag = "371702";
	}

	// Token: 0x0601886E RID: 100462 RVA: 0x007A8078 File Offset: 0x007A6478
	public override void OnStart()
	{
		base.OnStart();
		this.mechanismTime = 0;
		this.deadFlag = false;
		this.RemoveHandles();
		BeEventHandle item = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null && (beProjectile.m_iResID == this.boomEntityIdArr[0] || beProjectile.m_iResID == this.boomEntityIdArr[1]))
			{
				BeEventHandle item2 = beProjectile.RegisterEvent(BeEventType.onAfterCalFirstDamage, delegate(object[] args1)
				{
					int[] damageArr = (int[])args1[0];
					int hurtId = (int)args1[2];
					this.ChangeHurtDamage(hurtId, damageArr);
				});
				this.handleList.Add(item2);
			}
		});
		this.handleList.Add(item);
	}

	// Token: 0x0601886F RID: 100463 RVA: 0x007A80C5 File Offset: 0x007A64C5
	public override void OnCancel()
	{
		base.OnCancel();
		this.SetMonsterDead();
	}

	// Token: 0x06018870 RID: 100464 RVA: 0x007A80D3 File Offset: 0x007A64D3
	public override void OnFinish()
	{
		base.OnFinish();
		this.SetMonsterDead();
	}

	// Token: 0x06018871 RID: 100465 RVA: 0x007A80E1 File Offset: 0x007A64E1
	public override void OnEnterNextPhase(int phase)
	{
		base.OnEnterNextPhase(phase);
		this.summonPhase = phase;
		base.owner.Locomote(new BeStateData(0, 0), true);
		base.Cancel();
	}

	// Token: 0x06018872 RID: 100466 RVA: 0x007A810C File Offset: 0x007A650C
	private void ChangeHurtDamage(int hurtId, int[] damageArr)
	{
		int num = (!BattleMain.IsModePvP(base.battleType)) ? this.hurtIdArr[0] : this.hurtIdArr[1];
		if (num != hurtId)
		{
			return;
		}
		if (this.summonPhase == 0)
		{
			damageArr[0] *= 2;
		}
		else
		{
			VFactor f = new VFactor((long)this.mechanismTime, (long)this.maxTime);
			damageArr[0] += damageArr[0] * f;
		}
	}

	// Token: 0x06018873 RID: 100467 RVA: 0x007A818C File Offset: 0x007A658C
	private void SetMonsterDead()
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (this.deadFlag)
		{
			return;
		}
		this.deadFlag = true;
		List<BeActor> list = ListPool<BeActor>.Get();
		int monsterID = (!BattleMain.IsModePvP(base.battleType)) ? this.monsterIdArr[0] : this.monsterIdArr[1];
		base.owner.CurrentBeScene.FindActorById2(list, monsterID, false);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Mechanism23 mechanism = this.GetMechanism(list[i]);
				if (mechanism != null)
				{
					this.mechanismTime = mechanism.GetRunningTime();
					list[i].buffController.RemoveBuff(mechanism.attachBuff);
				}
				list[i].DoDead(false);
				int entityID = (!BattleMain.IsModePvP(base.battleType)) ? this.summonEntityIdArr[0] : this.summonEntityIdArr[1];
				base.owner.AddEntity(entityID, list[i].GetPosition(), 1, 0);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018874 RID: 100468 RVA: 0x007A82B4 File Offset: 0x007A66B4
	private Mechanism23 GetMechanism(BeActor actor)
	{
		if (actor == null || actor.IsDead())
		{
			return null;
		}
		if (actor.MechanismList == null)
		{
			return null;
		}
		Mechanism23 mechanism = null;
		for (int i = 0; i < actor.MechanismList.Count; i++)
		{
			mechanism = (actor.MechanismList[i] as Mechanism23);
			if (mechanism != null)
			{
				break;
			}
		}
		return mechanism;
	}

	// Token: 0x06018875 RID: 100469 RVA: 0x007A8320 File Offset: 0x007A6720
	private void RemoveHandles()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x04011B0F RID: 72463
	private int[] summonEntityIdArr = new int[2];

	// Token: 0x04011B10 RID: 72464
	private int[] hurtIdArr = new int[2];

	// Token: 0x04011B11 RID: 72465
	private int[] monsterIdArr = new int[2];

	// Token: 0x04011B12 RID: 72466
	private int[] boomEntityIdArr = new int[]
	{
		63654,
		63667
	};

	// Token: 0x04011B13 RID: 72467
	private int summonPhase;

	// Token: 0x04011B14 RID: 72468
	private int mechanismTime;

	// Token: 0x04011B15 RID: 72469
	private bool deadFlag;

	// Token: 0x04011B16 RID: 72470
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011B17 RID: 72471
	private int maxTime = 3584;
}
