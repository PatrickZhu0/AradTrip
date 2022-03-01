using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x020043FC RID: 17404
public class Mechanism60 : BeMechanism
{
	// Token: 0x06018293 RID: 98963 RVA: 0x007841C0 File Offset: 0x007825C0
	public Mechanism60(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018294 RID: 98964 RVA: 0x0078423C File Offset: 0x0078263C
	public override void OnInit()
	{
		this.skillCD = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.startHeight = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.duration = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.fallSpeed = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.baseDamageValue = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		for (int i = 0; i < this.data.ValueF.Count; i++)
		{
			this.damageCoefficient[i] = TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true);
		}
		this.attackID = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
	}

	// Token: 0x06018295 RID: 98965 RVA: 0x00784384 File Offset: 0x00782784
	public override void OnStart()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.boss1ID, true);
		if (list.Count > 0)
		{
			this.boss1 = list[0];
		}
		base.owner.CurrentBeScene.FindMonsterByID(list, this.boss2ID, true);
		if (list.Count > 0)
		{
			this.boss2 = list[0];
		}
		if (this.boss1 != null && this.boss2 != null)
		{
			BeEventHandle item = this.boss1.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
			{
				ActionState actionState = (ActionState)args[0];
				if (actionState == ActionState.AS_DEAD)
				{
					base.owner.DoDead(false);
				}
				else
				{
					this.canUseSkill = (this.CheckSpellCondition(this.boss1) && this.CheckSpellCondition(this.boss2));
				}
			});
			this.handlerList.Add(item);
			BeEventHandle item2 = this.boss2.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
			{
				ActionState actionState = (ActionState)args[0];
				if (actionState == ActionState.AS_DEAD)
				{
					base.owner.DoDead(false);
				}
				else
				{
					this.canUseSkill = (this.CheckSpellCondition(this.boss1) && this.CheckSpellCondition(this.boss2));
				}
			});
			this.handlerList.Add(item2);
		}
		else
		{
			Logger.LogError("boss1 or boss2 do not exist");
		}
		this.timeAcc = 0;
	}

	// Token: 0x06018296 RID: 98966 RVA: 0x00784474 File Offset: 0x00782874
	private bool CheckSpellCondition(BeActor actor)
	{
		if (this.boss1.IsDead() || this.boss2.IsDead())
		{
			return false;
		}
		bool flag = actor.stateController.HasBuffState(BeBuffStateType.FROZEN) || actor.stateController.HasBuffState(BeBuffStateType.STUN) || actor.stateController.HasBuffState(BeBuffStateType.STONE) || actor.stateController.HasBuffState(BeBuffStateType.SLEEP) || actor.stateController.HasBuffState(BeBuffStateType.STRAIN);
		return actor.sgGetCurrentState() != 9 && actor.sgGetCurrentState() != 15 && actor.sgGetCurrentState() != 14 && actor.sgGetCurrentState() != 18 && !flag && !actor.IsInPassiveState() && !actor.stateController.WillBeGrab();
	}

	// Token: 0x06018297 RID: 98967 RVA: 0x00784568 File Offset: 0x00782968
	public override void OnUpdate(int deltaTime)
	{
		this.timeAcc += deltaTime;
		if (this.timeAcc >= this.skillCD && this.canUseSkill)
		{
			this.timeAcc = 0;
			this.canUseSkill = false;
			this.DoSkill();
		}
		if (this.protectHurtTime > 0)
		{
			this.protectHurtTime -= deltaTime;
			if (this.protectHurtTime < 0)
			{
				this.protectHurtTime = 0;
			}
			if (this.battleSystem != null)
			{
				this.battleSystem.ChangeCountDown(this.protectHurtTime / 1000);
			}
		}
	}

	// Token: 0x06018298 RID: 98968 RVA: 0x00784604 File Offset: 0x00782A04
	private void DoSkill()
	{
		int count = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers().Count;
		if (count > 0)
		{
			int diffID = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.diffID;
			int num = this.damageCoefficient[diffID];
			VFactor f = new VFactor((long)num, (long)GlobalLogic.VALUE_1000);
			this.damageValue = this.baseDamageValue * count * (diffID + 1) * f;
			this.boss1.UseSkill(this.skill1ID, true);
			this.boss2.UseSkill(this.skill2ID, true);
			this.SummonProtector();
			this.CreateEntity();
			this.damageAcc = 0;
			SystemNotifyManager.SysDungeonSkillTip(this.tipsContent, (float)this.duration / 1000f, false);
			this.battleSystem = (Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle);
			this.ShowDamageBar(true);
			this.protectHurtTime = this.duration;
			if (this.battleSystem != null)
			{
				this.battleSystem.ChangeCountDown(this.protectHurtTime / 1000);
				this.battleSystem.ChangeDamageData((float)this.damageAcc, (float)this.damageValue, false);
			}
		}
	}

	// Token: 0x06018299 RID: 98969 RVA: 0x0078473C File Offset: 0x00782B3C
	private void SummonProtector()
	{
		object[] array = new object[1];
		if (this.boss1.DoSummon(this.protectorID, this.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, array, true) && array[0] != null)
		{
			this.protector1 = (BeActor)array[0];
			this.protector1.RegisterEvent(BeEventType.onHit, delegate(object[] args)
			{
				this.ProtectorOnHurt((int)args[0]);
			});
		}
		if (this.boss2.DoSummon(this.protectorID, this.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, array, true) && array[0] != null)
		{
			this.protector2 = (BeActor)array[0];
			this.protector2.RegisterEvent(BeEventType.onHit, delegate(object[] args)
			{
				this.ProtectorOnHurt((int)args[0]);
			});
		}
	}

	// Token: 0x0601829A RID: 98970 RVA: 0x00784810 File Offset: 0x00782C10
	private void CreateEntity()
	{
		BattlePlayer playerBySeat = base.owner.CurrentBeBattle.dungeonPlayerManager.GetPlayerBySeat(0);
		if (playerBySeat != null)
		{
			VInt3 pos = new VInt3(playerBySeat.playerActor.GetPosition().vector3 + Vector3.up * ((float)this.startHeight / 10000f));
			this.fireBall = (BeProjectile)base.owner.AddEntity(this.fireBallID, pos, 1, 0);
			if (this.fireBall != null)
			{
				this.handler = this.fireBall.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					this.DoAttack();
					this.StopBossSkill();
				});
				this.fireBall.delayCaller.DelayCall(this.duration, delegate
				{
					if (this.fireBall != null && !this.fireBall.IsDead())
					{
						this.fireBall.SetMoveSpeedZ(this.fallSpeed);
					}
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x0601829B RID: 98971 RVA: 0x007848E0 File Offset: 0x00782CE0
	private void DoAttack()
	{
		this.ShowDamageBar(false);
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, VInt.Float2VIntValue(100f), false, null);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor pkEntity = list[i];
			VInt3 position = base.owner.GetPosition();
			position.z += VInt.one.i;
			base.owner._onHurtEntity(pkEntity, position, this.attackID);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0601829C RID: 98972 RVA: 0x00784984 File Offset: 0x00782D84
	private void ProtectorOnHurt(int value)
	{
		this.damageAcc += value;
		if (this.damageAcc >= this.damageValue)
		{
			this.StopBossSkill();
			this.RemoveProjectile();
			this.ShowDamageBar(false);
		}
		else if (this.battleSystem != null)
		{
			this.ShowDamageBar(true);
			this.battleSystem.ChangeDamageData((float)this.damageAcc, (float)this.damageValue, false);
		}
	}

	// Token: 0x0601829D RID: 98973 RVA: 0x007849F4 File Offset: 0x00782DF4
	private void StopBossSkill()
	{
		if (this.protector1 != null)
		{
			this.protector1.GetEntityData().SetHP(-1);
			this.protector1.DoDead(false);
		}
		if (this.protector2 != null)
		{
			this.protector2.GetEntityData().SetHP(-1);
			this.protector2.DoDead(false);
		}
		if (this.boss1 != null)
		{
			this.boss1.CancelSkill(this.skill1ID, true);
			this.boss1.sgSwitchStates(new BeStateData(0, 0));
			this.boss1.buffController.RemoveBuff(38, 0, 0);
		}
		if (this.boss2 != null)
		{
			this.boss2.CancelSkill(this.skill2ID, true);
			this.boss2.sgSwitchStates(new BeStateData(0, 0));
			this.boss2.buffController.RemoveBuff(38, 0, 0);
		}
	}

	// Token: 0x0601829E RID: 98974 RVA: 0x00784AD7 File Offset: 0x00782ED7
	private void ShowDamageBar(bool show)
	{
		if (this.battleSystem != null)
		{
			this.battleSystem.ShowDamageBar(show);
		}
	}

	// Token: 0x0601829F RID: 98975 RVA: 0x00784AF0 File Offset: 0x00782EF0
	private void RemoveProjectile()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.fireBall != null)
		{
			this.fireBall.DoDie();
		}
	}

	// Token: 0x060182A0 RID: 98976 RVA: 0x00784B25 File Offset: 0x00782F25
	public override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x060182A1 RID: 98977 RVA: 0x00784B30 File Offset: 0x00782F30
	private void RemoveHandler()
	{
		for (int i = 0; i < this.handlerList.Count; i++)
		{
			this.handlerList[i].Remove();
			this.handlerList[i] = null;
		}
		this.handlerList.Clear();
	}

	// Token: 0x040116E4 RID: 71396
	private List<BeEventHandle> handlerList = new List<BeEventHandle>();

	// Token: 0x040116E5 RID: 71397
	private BeActor boss1;

	// Token: 0x040116E6 RID: 71398
	private BeActor boss2;

	// Token: 0x040116E7 RID: 71399
	private BeActor protector1;

	// Token: 0x040116E8 RID: 71400
	private BeActor protector2;

	// Token: 0x040116E9 RID: 71401
	private BeProjectile fireBall;

	// Token: 0x040116EA RID: 71402
	private BeEventHandle handler;

	// Token: 0x040116EB RID: 71403
	private int boss1ID = 8280031;

	// Token: 0x040116EC RID: 71404
	private int boss2ID = 8290031;

	// Token: 0x040116ED RID: 71405
	private int protectorID = 3140011;

	// Token: 0x040116EE RID: 71406
	private int skill1ID = 5647;

	// Token: 0x040116EF RID: 71407
	private int skill2ID = 5648;

	// Token: 0x040116F0 RID: 71408
	private int fireBallID = 60317;

	// Token: 0x040116F1 RID: 71409
	private int skillCD;

	// Token: 0x040116F2 RID: 71410
	private int startHeight;

	// Token: 0x040116F3 RID: 71411
	private new int duration;

	// Token: 0x040116F4 RID: 71412
	private int fallSpeed;

	// Token: 0x040116F5 RID: 71413
	private int baseDamageValue;

	// Token: 0x040116F6 RID: 71414
	private int[] damageCoefficient = new int[4];

	// Token: 0x040116F7 RID: 71415
	private int attackID;

	// Token: 0x040116F8 RID: 71416
	private int timeAcc;

	// Token: 0x040116F9 RID: 71417
	private int damageAcc;

	// Token: 0x040116FA RID: 71418
	private int damageValue;

	// Token: 0x040116FB RID: 71419
	private bool canUseSkill;

	// Token: 0x040116FC RID: 71420
	private string tipsContent = string.Empty;

	// Token: 0x040116FD RID: 71421
	private ClientSystemBattle battleSystem;

	// Token: 0x040116FE RID: 71422
	private int protectHurtTime;
}
