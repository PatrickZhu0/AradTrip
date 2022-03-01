using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x02004336 RID: 17206
public class Mechanism2002 : BeMechanism
{
	// Token: 0x06017CDD RID: 97501 RVA: 0x00759DF5 File Offset: 0x007581F5
	public Mechanism2002(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CDE RID: 97502 RVA: 0x00759E2C File Offset: 0x0075822C
	public override void OnInit()
	{
		base.OnInit();
		this.moveSpeed[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.moveSpeed[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true), GlobalLogic.VALUE_1000);
		this.followRadius[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.followRadius[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true), GlobalLogic.VALUE_1000);
		this.attackRadius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.attackXOffset = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x06017CDF RID: 97503 RVA: 0x00759FBF File Offset: 0x007583BF
	public override void OnStart()
	{
		this.summoner = (base.owner.GetOwner() as BeActor);
	}

	// Token: 0x06017CE0 RID: 97504 RVA: 0x00759FD8 File Offset: 0x007583D8
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (!this.CanManualAttack())
		{
			this.UpdateFindTarget();
			this.UpdateSkillCD();
			this.UpdateGoToTargetAndAttack();
		}
		this.UpdateFollow();
		if (this.CanManualAttack())
		{
			this.UpdateFindTarget();
			if (this.attackTarget != null)
			{
				this.SetFaceTarget(this.attackTarget.GetPosition());
			}
		}
	}

	// Token: 0x06017CE1 RID: 97505 RVA: 0x0075A048 File Offset: 0x00758448
	protected void UpdateFindTarget()
	{
		if (this.attackTarget != null && this.attackTarget.IsDead())
		{
			this.attackTarget = null;
		}
		if (!this.CheckTargetInAttackRadius())
		{
			this.attackTarget = null;
		}
		if (this.attackTarget != null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, this.attackRadius, false, null);
		if (list != null && list.Count > 0)
		{
			Mechanism2002.TargetPriority targetPriority = Mechanism2002.TargetPriority.Normal;
			for (int i = 0; i < list.Count; i++)
			{
				Mechanism2002.TargetPriority prioritty = this.GetPrioritty(list[i]);
				if (prioritty >= targetPriority)
				{
					this.attackTarget = list[i];
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017CE2 RID: 97506 RVA: 0x0075A110 File Offset: 0x00758510
	protected bool CheckTargetInAttackRadius()
	{
		if (this.attackTarget == null)
		{
			return false;
		}
		int i = Mathf.Abs((this.attackTarget.GetPosition() - base.owner.GetPosition()).magnitude);
		return i <= this.attackRadius;
	}

	// Token: 0x06017CE3 RID: 97507 RVA: 0x0075A164 File Offset: 0x00758564
	protected Mechanism2002.TargetPriority GetPrioritty(BeActor actor)
	{
		if (!actor.IsMonster())
		{
			return Mechanism2002.TargetPriority.Player;
		}
		if (actor.IsBoss())
		{
			return Mechanism2002.TargetPriority.Boss;
		}
		if (actor.GetEntityData().monsterData.Type == UnitTable.eType.ELITE)
		{
			return Mechanism2002.TargetPriority.Elite;
		}
		return Mechanism2002.TargetPriority.Normal;
	}

	// Token: 0x06017CE4 RID: 97508 RVA: 0x0075A199 File Offset: 0x00758599
	protected void UpdateSkillCD()
	{
		if (base.owner.GetSkill(this.skillId) == null)
		{
			this.skillInCD = true;
		}
		this.skillInCD = base.owner.GetSkill(this.skillId).isCooldown;
	}

	// Token: 0x06017CE5 RID: 97509 RVA: 0x0075A1D4 File Offset: 0x007585D4
	protected void UpdateGoToTargetAndAttack()
	{
		if (this.attackTarget == null || this.skillInCD)
		{
			return;
		}
		if (base.owner.IsCastingSkill())
		{
			return;
		}
		if (this.CheckInAttackRadius() == 1)
		{
			this.SetIdle();
			this.SetFaceTarget(this.attackTarget.GetPosition());
			base.owner.UseSkill(this.skillId, false);
		}
		else if (this.CheckInAttackRadius() == 0)
		{
			this.GoToTarget(this.attackTarget.GetPosition(), this.attackXOffset, new VInt(0.1f));
		}
	}

	// Token: 0x06017CE6 RID: 97510 RVA: 0x0075A270 File Offset: 0x00758670
	protected int CheckInAttackRadius()
	{
		if (this.attackTarget == null)
		{
			return -1;
		}
		VInt3 position = this.attackTarget.GetPosition();
		int num = base.owner.GetPosition().x - position.x;
		int num2 = base.owner.GetPosition().y - position.y;
		int i = Mathf.Abs(num);
		int i2 = Mathf.Abs(num2);
		return (!(i <= this.attackXOffset) || !(i2 <= VInt.zeroDotOne)) ? 0 : 1;
	}

	// Token: 0x06017CE7 RID: 97511 RVA: 0x0075A314 File Offset: 0x00758714
	protected void GoToTarget(VInt3 targetPos, VInt limitRadiusX, VInt limitRadiusY)
	{
		this.switchIdleHandle.SetRemove(true);
		int num = base.owner.GetPosition().x - targetPos.x;
		int num2 = base.owner.GetPosition().y - targetPos.y;
		VInt vint = (num <= 0) ? this.moveSpeed[0] : (-this.moveSpeed[0]);
		VInt vint2 = (num2 <= 0) ? this.moveSpeed[1] : (-this.moveSpeed[1]);
		if (!this.CanManualAttack() || this.attackTarget == null)
		{
			base.owner.SetFace(num > 0, false, false);
		}
		vint = ((!(Math.Abs(num) > limitRadiusX)) ? 0 : vint);
		vint2 = ((!(Math.Abs(num2) > limitRadiusY)) ? 0 : vint2);
		base.owner.SetMoveSpeedX(vint);
		base.owner.SetMoveSpeedY(vint2);
		this.PlayWalk();
	}

	// Token: 0x06017CE8 RID: 97512 RVA: 0x0075A460 File Offset: 0x00758860
	protected void SetIdle()
	{
		base.owner.SetMoveSpeedX(0);
		base.owner.SetMoveSpeedY(0);
		this.switchIdleHandle = base.owner.delayCaller.DelayCall(GlobalLogic.VALUE_200, delegate
		{
			this.PlayIdle();
		}, 0, 0, false);
	}

	// Token: 0x06017CE9 RID: 97513 RVA: 0x0075A4BC File Offset: 0x007588BC
	protected void SetFaceTarget(VInt3 targetPos)
	{
		int num = base.owner.GetPosition().x - targetPos.x;
		int num2 = base.owner.GetPosition().y - targetPos.y;
		base.owner.SetFace(num > 0, false, false);
	}

	// Token: 0x06017CEA RID: 97514 RVA: 0x0075A514 File Offset: 0x00758914
	private bool CanManualAttack()
	{
		BeActor topOwner = base.GetTopOwner();
		return topOwner != null && topOwner.CurrentBeBattle != null && topOwner.XuanWuManualAttack && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.XuanwuManualAttack);
	}

	// Token: 0x06017CEB RID: 97515 RVA: 0x0075A564 File Offset: 0x00758964
	public void UpdateFollow()
	{
		if (!this.CanManualAttack() && this.attackTarget != null && !this.skillInCD)
		{
			return;
		}
		if (base.owner.IsCastingSkill())
		{
			return;
		}
		if (!this.IsInFollowRadius())
		{
			VInt3 position = this.summoner.GetPosition();
			this.GoToTarget(position, new VInt(0.1f), new VInt(0.1f));
		}
		else
		{
			this.SetIdle();
		}
	}

	// Token: 0x06017CEC RID: 97516 RVA: 0x0075A5E4 File Offset: 0x007589E4
	protected bool IsInFollowRadius()
	{
		if (this.summoner == null)
		{
			return true;
		}
		VInt3 position = this.summoner.GetPosition();
		int num = base.owner.GetPosition().x - position.x;
		int num2 = base.owner.GetPosition().y - position.y;
		int i = Mathf.Abs(num);
		int i2 = Mathf.Abs(num2);
		return i < this.followRadius[0] && i2 < this.followRadius[1];
	}

	// Token: 0x06017CED RID: 97517 RVA: 0x0075A698 File Offset: 0x00758A98
	protected void PlayIdle()
	{
		if (base.owner.IsCastingSkill())
		{
			return;
		}
		if (this.curActionState == ActionState.AS_IDLE)
		{
			return;
		}
		this.curActionState = ActionState.AS_IDLE;
		string acActionName = "Idle";
		base.owner.PlayAction(acActionName, 1f);
	}

	// Token: 0x06017CEE RID: 97518 RVA: 0x0075A6E4 File Offset: 0x00758AE4
	protected void PlayWalk()
	{
		if (base.owner.IsCastingSkill())
		{
			return;
		}
		if (this.curActionState == ActionState.AS_WALK)
		{
			return;
		}
		this.curActionState = ActionState.AS_WALK;
		string acActionName = "Walk";
		base.owner.PlayAction(acActionName, 1f);
	}

	// Token: 0x04011203 RID: 70147
	protected VInt[] moveSpeed = new VInt[2];

	// Token: 0x04011204 RID: 70148
	protected VInt[] followRadius = new VInt[2];

	// Token: 0x04011205 RID: 70149
	protected VInt attackRadius;

	// Token: 0x04011206 RID: 70150
	protected VInt attackXOffset;

	// Token: 0x04011207 RID: 70151
	protected int skillId = 5031;

	// Token: 0x04011208 RID: 70152
	protected BeActor summoner;

	// Token: 0x04011209 RID: 70153
	protected BeActor attackTarget;

	// Token: 0x0401120A RID: 70154
	protected bool skillInCD;

	// Token: 0x0401120B RID: 70155
	protected ActionState curActionState = ActionState.AS_NONE;

	// Token: 0x0401120C RID: 70156
	protected DelayCallUnitHandle switchIdleHandle;

	// Token: 0x02004337 RID: 17207
	protected enum TargetPriority
	{
		// Token: 0x0401120E RID: 70158
		None,
		// Token: 0x0401120F RID: 70159
		Normal,
		// Token: 0x04011210 RID: 70160
		Elite,
		// Token: 0x04011211 RID: 70161
		Boss,
		// Token: 0x04011212 RID: 70162
		Player
	}
}
