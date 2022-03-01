using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020044D0 RID: 17616
public class Skill3705 : BeSkill
{
	// Token: 0x06018847 RID: 100423 RVA: 0x007A7174 File Offset: 0x007A5574
	public Skill3705(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018848 RID: 100424 RVA: 0x007A720C File Offset: 0x007A560C
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			this.effectIdArr[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
		}
		this.teleportDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), GlobalLogic.VALUE_1000);
		if (this.skillData.ValueC.Length > 0)
		{
			this.protectBuffInfoId = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		}
	}

	// Token: 0x06018849 RID: 100425 RVA: 0x007A72CC File Offset: 0x007A56CC
	public override void OnStart()
	{
		this.curTeleportCount = 0;
		this.SetEquipAdd();
		this.curPos = base.owner.GetPosition();
		this.curFace = base.owner.GetFace();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, delegate(object[] args)
		{
			int id = (int)args[1];
			BeActor beActor = (BeActor)args[0];
			this.InitChargeData();
			this.AddSwitchStateBuff(id, beActor);
			this.AddProtectBuff(beActor);
		});
	}

	// Token: 0x0601884A RID: 100426 RVA: 0x007A7328 File Offset: 0x007A5728
	private void InitChargeData()
	{
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.effectId = ((!this.charged) ? this.effectIdArr[0] : this.effectIdArr[1]);
		}
		else
		{
			this.effectId = ((!this.charged) ? this.effectIdArr[2] : this.effectIdArr[3]);
		}
		this.maxTeleportCount = ((!this.charged) ? (this.teleportCountArr[0] + this.equipTeleportCountArr[0]) : (this.teleportCountArr[1] + this.equipTeleportCountArr[1]));
		this.curBuffId = ((!this.charged) ? this.buffIdArr[0] : this.buffIdArr[1]);
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.curBuffTime = ((!this.charged) ? this.buffTimeArr[0] : this.buffTimeArr[1]);
		}
		else
		{
			this.curBuffTime = ((!this.charged) ? this.buffTimeArr[2] : this.buffTimeArr[3]);
		}
	}

	// Token: 0x0601884B RID: 100427 RVA: 0x007A7458 File Offset: 0x007A5858
	private void AddSwitchStateBuff(int Id, BeActor actor)
	{
		if (Id != this.effectId)
		{
			return;
		}
		if (actor == null || actor.IsDead())
		{
			return;
		}
		if (actor.isAbsorb)
		{
			return;
		}
		if (actor.buffController == null || actor.buffController.HaveBatiBuff() || actor.buffController.HasBuffByID(50) != null)
		{
			return;
		}
		if (actor.stateController == null || !actor.stateController.HasBornAbility(BeAbilityType.FALLGROUND) || !actor.stateController.HasBornAbility(BeAbilityType.FLOAT))
		{
			return;
		}
		if (actor.protectManager != null && actor.protectManager.IsInGroundProtect())
		{
			return;
		}
		if (!actor.stateController.HasBuffState(BeBuffStateType.FROZEN) && !actor.stateController.HasBuffState(BeBuffStateType.STONE))
		{
			actor.buffController.TryAddBuff(this.curBuffId, this.curBuffTime, 1);
		}
		this.MoveTo(actor);
	}

	// Token: 0x0601884C RID: 100428 RVA: 0x007A7554 File Offset: 0x007A5954
	private void MoveTo(BeActor target)
	{
		VInt3 position = target.GetPosition();
		int i = Mathf.Abs((!this.curFace) ? (this.curPos.x - position.x) : (position.x - this.curPos.x));
		if (i > this.teleportDis)
		{
			return;
		}
		int dur = 200;
		VInt3 toPos = this.curPos;
		toPos.x += ((!this.curFace) ? this.teleportDis.i : (-this.teleportDis.i));
		toPos.y = position.y;
		if (this.curPos.z > 0)
		{
			toPos.z = 0;
		}
		BeActionActorFilter beActionActorFilter = new BeActionActorFilter();
		beActionActorFilter.Init(true, true, true, true, true);
		BeMoveTo action = BeMoveTo.Create(target, dur, position, toPos, false, beActionActorFilter, false);
		target.actionManager.RunAction(action);
	}

	// Token: 0x0601884D RID: 100429 RVA: 0x007A7654 File Offset: 0x007A5A54
	private void SetEquipAdd()
	{
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		this.equipTeleportCountArr[0] = 0;
		this.equipTeleportCountArr[1] = 0;
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2024 mechanism = mechanismList[i] as Mechanism2024;
			if (mechanism != null)
			{
				this.equipTeleportCountArr[0] = mechanism.addCountArr[0];
				this.equipTeleportCountArr[1] += mechanism.addCountArr[1];
			}
		}
	}

	// Token: 0x0601884E RID: 100430 RVA: 0x007A76E0 File Offset: 0x007A5AE0
	private void AddProtectBuff(BeActor target)
	{
		if (!BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (target == null || this.protectBuffInfoId == 0 || !this.charged)
		{
			return;
		}
		if (target.HasTag(1))
		{
			target.buffController.TryAddBuffInfo(this.protectBuffInfoId, base.owner, base.level);
		}
	}

	// Token: 0x04011AF4 RID: 72436
	private int[] effectIdArr = new int[]
	{
		37050,
		37051,
		37052,
		37053
	};

	// Token: 0x04011AF5 RID: 72437
	private VInt teleportDis = 0;

	// Token: 0x04011AF6 RID: 72438
	private int[] teleportCountArr = new int[]
	{
		10,
		16
	};

	// Token: 0x04011AF7 RID: 72439
	private int[] buffIdArr = new int[]
	{
		370500,
		370501
	};

	// Token: 0x04011AF8 RID: 72440
	private int[] buffTimeArr = new int[]
	{
		700,
		1100,
		450,
		1100
	};

	// Token: 0x04011AF9 RID: 72441
	private int effectId;

	// Token: 0x04011AFA RID: 72442
	private int maxTeleportCount;

	// Token: 0x04011AFB RID: 72443
	private int curTeleportCount;

	// Token: 0x04011AFC RID: 72444
	private int curBuffId;

	// Token: 0x04011AFD RID: 72445
	private int curBuffTime;

	// Token: 0x04011AFE RID: 72446
	private VInt3 curPos = VInt3.zero;

	// Token: 0x04011AFF RID: 72447
	private bool curFace;

	// Token: 0x04011B00 RID: 72448
	private int[] equipTeleportCountArr = new int[2];

	// Token: 0x04011B01 RID: 72449
	private int protectBuffInfoId;
}
