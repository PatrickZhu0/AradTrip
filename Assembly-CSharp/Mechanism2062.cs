using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004376 RID: 17270
public class Mechanism2062 : BeMechanism
{
	// Token: 0x06017EDC RID: 98012 RVA: 0x007689AC File Offset: 0x00766DAC
	public Mechanism2062(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017EDD RID: 98013 RVA: 0x00768A14 File Offset: 0x00766E14
	public override void OnInit()
	{
		base.OnInit();
		this.speed = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.hurtIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.hurtIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017EDE RID: 98014 RVA: 0x00768ACC File Offset: 0x00766ECC
	public override void OnStart()
	{
		base.OnStart();
		this.target = this.SelectOnePlayerByRamdom();
		this.ControlTarget();
		this.CreateChainEffect();
		this.handleA = base.owner.RegisterEvent(BeEventType.onCollide, new BeEventHandle.Del(this.RegisteHurtPlayer));
		this.handleB = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, new BeEventHandle.Del(this.RegisterSkill));
	}

	// Token: 0x06017EDF RID: 98015 RVA: 0x00768B35 File Offset: 0x00766F35
	public override void OnFinish()
	{
		base.OnFinish();
		if (!this.hurtFlag)
		{
			this.StopMoving();
		}
	}

	// Token: 0x06017EE0 RID: 98016 RVA: 0x00768B4E File Offset: 0x00766F4E
	private void ControlTarget()
	{
		if (this.target == null)
		{
			return;
		}
		this.target.buffController.TryAddBuff(this.buffId, GlobalLogic.VALUE_10000, 60);
	}

	// Token: 0x06017EE1 RID: 98017 RVA: 0x00768B7C File Offset: 0x00766F7C
	private void SetOwnerSpeed()
	{
		if (this.target == null)
		{
			return;
		}
		VInt3 position = base.owner.GetPosition();
		VInt3 position2 = this.target.GetPosition();
		VInt3 vint = new VInt3(position2.x - position.x, position2.y - position.y, position2.z - position.z);
		VInt3 vint2 = vint.NormalizeTo(this.speed);
		base.owner.SetMoveSpeedX(vint2.x);
		base.owner.SetMoveSpeedY(vint2.y);
		base.owner.SetMoveSpeedZ(vint2.z);
	}

	// Token: 0x06017EE2 RID: 98018 RVA: 0x00768C34 File Offset: 0x00767034
	private void RegisteHurtPlayer(object[] args)
	{
		if (this.hurtFlag)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		int num = (int)args[1];
		if (num != this.checkHurtId)
		{
			return;
		}
		if (beActor == null)
		{
			return;
		}
		if (!beActor.isMainActor)
		{
			return;
		}
		if (beActor.stateController.CanBeHit())
		{
			if (this.target != null && beActor.GetPID() == this.target.GetPID())
			{
				base.owner.DoAttackTo(beActor, this.hurtIdArr[1], true, false);
			}
			else
			{
				base.owner.DoAttackTo(beActor, this.hurtIdArr[0], true, false);
			}
		}
		this.hurtFlag = true;
		this.StopMoving();
	}

	// Token: 0x06017EE3 RID: 98019 RVA: 0x00768CF0 File Offset: 0x007670F0
	private void RegisterSkill(object[] args)
	{
		int[] array = (int[])args[0];
		if (array[0] != this.registerSkillPhaseId)
		{
			return;
		}
		this.SetOwnerSpeed();
	}

	// Token: 0x06017EE4 RID: 98020 RVA: 0x00768D1C File Offset: 0x0076711C
	private void StopMoving()
	{
		base.owner.ClearMoveSpeed(7);
		if (this.target != null)
		{
			this.target.buffController.RemoveBuff(this.buffId, 0, 0);
		}
		if (base.owner.GetStateGraph() != null)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
		this.ClearChainEffect();
	}

	// Token: 0x06017EE5 RID: 98021 RVA: 0x00768D84 File Offset: 0x00767184
	private BeActor SelectOnePlayerByRamdom()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return null;
		}
		if (base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return null;
		}
		BeActor result = null;
		List<BattlePlayer> list = ListPool<BattlePlayer>.Get();
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (!base.owner.CurrentBeBattle.dungeonPlayerManager.IsPlayerDeadByBattlePlayer(allPlayers[i]))
			{
				list.Add(allPlayers[i]);
			}
		}
		if (list != null && list.Count > 0)
		{
			int index = base.FrameRandom.InRange(0, list.Count);
			result = list[index].playerActor;
		}
		ListPool<BattlePlayer>.Release(list);
		return result;
	}

	// Token: 0x06017EE6 RID: 98022 RVA: 0x00768E58 File Offset: 0x00767258
	private void CreateChainEffect()
	{
		if (this.target == null)
		{
			return;
		}
		base.owner.m_pkGeActor.CreateChainEffect(this.target, this.chainEffect, EffectTimeType.SYNC_ANIMATION, false);
	}

	// Token: 0x06017EE7 RID: 98023 RVA: 0x00768E84 File Offset: 0x00767284
	private void ClearChainEffect()
	{
		base.owner.m_pkGeActor.ClearChainEffect();
	}

	// Token: 0x040113AB RID: 70571
	private int speed = 500000;

	// Token: 0x040113AC RID: 70572
	private int[] hurtIdArr = new int[]
	{
		212050,
		212051
	};

	// Token: 0x040113AD RID: 70573
	private int buffId = 521644;

	// Token: 0x040113AE RID: 70574
	private BeActor target;

	// Token: 0x040113AF RID: 70575
	private string chainEffect = "Effects/Monster_HMZD_zhenshou/Prefab/Eff_hmzd_zhenshou_shouhulian";

	// Token: 0x040113B0 RID: 70576
	private int registerSkillPhaseId = 212054;

	// Token: 0x040113B1 RID: 70577
	private bool hurtFlag;

	// Token: 0x040113B2 RID: 70578
	private int checkHurtId = 212052;
}
