using System;
using System.Collections.Generic;

// Token: 0x02004367 RID: 17255
public class Mechanism2048 : BeMechanism
{
	// Token: 0x06017E51 RID: 97873 RVA: 0x00764815 File Offset: 0x00762C15
	public Mechanism2048(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E52 RID: 97874 RVA: 0x00764838 File Offset: 0x00762C38
	public override void OnInit()
	{
		base.OnInit();
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.castSkillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017E53 RID: 97875 RVA: 0x007648D0 File Offset: 0x00762CD0
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, new BeEventHandle.Del(this.onSkillHitTarget));
		this.handleB = base.owner.RegisterEvent(BeEventType.onHitOtherAfterAddBuff, new BeEventHandle.Del(this.onSkillHitTargetAfterAddBuff));
	}

	// Token: 0x06017E54 RID: 97876 RVA: 0x00764924 File Offset: 0x00762D24
	private void ReleaseHitTarget(Mechanism2048.TargetInfo target)
	{
		if (target == null || target.hitTarget == null)
		{
			return;
		}
		target.hitTarget.Reset();
		if (target.rebornHandle != null)
		{
			target.rebornHandle.Remove();
			target.rebornHandle = null;
		}
		if (target.hitTarget.buffController != null)
		{
			target.hitTarget.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		if (target.hitTarget.isLocalActor)
		{
			InputManager.instance.SetEnable(true);
		}
	}

	// Token: 0x06017E55 RID: 97877 RVA: 0x007649B0 File Offset: 0x00762DB0
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo target = this.targets[i];
			this.ReleaseHitTarget(target);
		}
		this.targets.Clear();
	}

	// Token: 0x06017E56 RID: 97878 RVA: 0x00764A00 File Offset: 0x00762E00
	private void onPlayerReborn(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null || beActor.buffController == null)
		{
			return;
		}
		if (beActor.buffController.HasBuffByID(this.buffID) == null)
		{
			return;
		}
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo targetInfo = this.targets[i];
			if (targetInfo != null && targetInfo.hitTarget != null)
			{
				if (targetInfo.hitTarget.GetPID() == beActor.GetPID())
				{
					this.ReleaseHitTarget(targetInfo);
					this.targets.RemoveAt(i);
					return;
				}
			}
		}
	}

	// Token: 0x06017E57 RID: 97879 RVA: 0x00764AA8 File Offset: 0x00762EA8
	private void RestoreAllTargets()
	{
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo targetInfo = this.targets[i];
			if (targetInfo != null && this.CanRestoreTarget(targetInfo.hitTarget))
			{
				this.ReleaseHitTarget(targetInfo);
				this.targets.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x06017E58 RID: 97880 RVA: 0x00764B0C File Offset: 0x00762F0C
	private bool CanRestoreTarget(BeActor hitTarget)
	{
		return hitTarget == null || hitTarget.buffController == null || hitTarget.IsDead() || hitTarget.buffController.HasBuffByID(this.buffID) == null;
	}

	// Token: 0x06017E59 RID: 97881 RVA: 0x00764B47 File Offset: 0x00762F47
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.durTime += deltaTime;
		if (this.durTime < 100)
		{
			return;
		}
		this.durTime -= 100;
		this.RestoreAllTargets();
		this.OnExecuteControlledTarget();
	}

	// Token: 0x06017E5A RID: 97882 RVA: 0x00764B88 File Offset: 0x00762F88
	private void OnExecuteControlledTarget()
	{
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo curTarget = this.targets[i];
			this.OnUpdateTarget(curTarget);
		}
	}

	// Token: 0x06017E5B RID: 97883 RVA: 0x00764BC8 File Offset: 0x00762FC8
	private bool IsTargetExist(BeActor target)
	{
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo targetInfo = this.targets[i];
			if (targetInfo != null && targetInfo.hitTarget != null && targetInfo.hitTarget.GetPID() == target.GetPID())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017E5C RID: 97884 RVA: 0x00764C28 File Offset: 0x00763028
	private void onSkillHitTargetAfterAddBuff(object[] args)
	{
		BeActor beActor = args[2] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.isMainActor)
		{
			return;
		}
		int num = (int)args[3];
		if (num != this.castSkillID)
		{
			return;
		}
		for (int i = 0; i < this.targets.Count; i++)
		{
			Mechanism2048.TargetInfo targetInfo = this.targets[i];
			if (targetInfo != null && targetInfo.hitTarget != null && targetInfo.hitTarget.GetPID() == beActor.GetPID())
			{
				if (!this.IsTargetActionValid(beActor))
				{
					this.ReleaseHitTarget(targetInfo);
					this.targets.RemoveAt(i);
				}
				return;
			}
		}
	}

	// Token: 0x06017E5D RID: 97885 RVA: 0x00764CD8 File Offset: 0x007630D8
	private void onSkillHitTarget(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.isMainActor)
		{
			return;
		}
		if (beActor.isSpecialMonster)
		{
			return;
		}
		int num = (int)args[2];
		if (num != this.castSkillID)
		{
			return;
		}
		if (beActor.buffController == null)
		{
			return;
		}
		if (beActor.buffController.HasBuffByID(this.buffID) != null)
		{
			return;
		}
		if (this.IsTargetExist(beActor))
		{
			return;
		}
		Mechanism2048.TargetInfo item = new Mechanism2048.TargetInfo
		{
			hitTarget = beActor,
			attackTarget = null,
			rebornHandle = beActor.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this.onPlayerReborn))
		};
		this.targets.Add(item);
		if (beActor.isLocalActor)
		{
			InputManager.instance.SetEnable(false);
		}
	}

	// Token: 0x06017E5E RID: 97886 RVA: 0x00764DA8 File Offset: 0x007631A8
	private BeActor FindNearestTarget(BeActor attacker)
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return null;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return null;
		}
		int num = 999999999;
		BeActor result = null;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null)
			{
				BeActor playerActor = battlePlayer.playerActor;
				if (playerActor != null && !playerActor.IsDead() && playerActor.GetPID() != attacker.GetPID())
				{
					int distance = playerActor.GetDistance(attacker);
					if (distance < num)
					{
						result = playerActor;
						num = distance;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06017E5F RID: 97887 RVA: 0x00764E85 File Offset: 0x00763285
	private void SetIdle(BeActor hitTarget)
	{
		if (hitTarget.IsCastingSkill())
		{
			return;
		}
		if (hitTarget.sgGetCurrentState() != 0)
		{
			hitTarget.sgSwitchStates(new BeStateData(0, 0));
		}
	}

	// Token: 0x06017E60 RID: 97888 RVA: 0x00764EAC File Offset: 0x007632AC
	private bool IsTargetActionValid(BeActor target)
	{
		return target == null || target.GetStateGraph() == null || (!target.GetStateGraph().CurrentStateHasTag(1) && (!target.GetStateGraph().CurrentStateHasTag(2) || target.HasTag(2)));
	}

	// Token: 0x06017E61 RID: 97889 RVA: 0x00764EFC File Offset: 0x007632FC
	private void OnUpdateTarget(Mechanism2048.TargetInfo curTarget)
	{
		if (curTarget == null || curTarget.hitTarget == null)
		{
			return;
		}
		if (curTarget.hitTarget.IsDead())
		{
			return;
		}
		if (!curTarget.hitTarget.stateController.CanMove())
		{
			return;
		}
		if (!this.IsTargetActionValid(curTarget.hitTarget))
		{
			return;
		}
		int i = 0;
		if (curTarget.attackTarget == null || curTarget.attackTarget.IsDead())
		{
			curTarget.attackTarget = this.FindNearestTarget(curTarget.hitTarget);
		}
		if (curTarget.attackTarget != null)
		{
			i = curTarget.attackTarget.GetDistance(curTarget.hitTarget);
		}
		if (curTarget.attackTarget == null)
		{
			curTarget.hitTarget.ResetMoveCmd();
			this.SetIdle(curTarget.hitTarget);
			return;
		}
		if (curTarget.attackTarget.IsDead())
		{
			return;
		}
		if (i < this.radius)
		{
			if (curTarget.hitTarget.CanUseSkill(curTarget.hitTarget.GetEntityData().normalAttackID))
			{
				curTarget.hitTarget.ResetMoveCmd();
				curTarget.hitTarget.UseSkill(curTarget.hitTarget.GetEntityData().normalAttackID, false);
			}
		}
		else
		{
			VInt3 vint = curTarget.attackTarget.GetPosition() - curTarget.hitTarget.GetPosition();
			curTarget.hitTarget.ResetMoveCmd();
			if (vint.x > VInt.half)
			{
				curTarget.hitTarget.ModifyMoveCmd(0, true);
			}
			else if (vint.x < -VInt.half)
			{
				curTarget.hitTarget.ModifyMoveCmd(1, true);
			}
			if (vint.y > VInt.half)
			{
				curTarget.hitTarget.ModifyMoveCmd(2, true);
			}
			else if (vint.y < -VInt.half)
			{
				curTarget.hitTarget.ModifyMoveCmd(3, true);
			}
		}
	}

	// Token: 0x0401132C RID: 70444
	private int castSkillID;

	// Token: 0x0401132D RID: 70445
	private int buffID;

	// Token: 0x0401132E RID: 70446
	private VInt radius = VInt.zero;

	// Token: 0x0401132F RID: 70447
	private List<Mechanism2048.TargetInfo> targets = new List<Mechanism2048.TargetInfo>();

	// Token: 0x04011330 RID: 70448
	private int durTime;

	// Token: 0x02004368 RID: 17256
	private class TargetInfo
	{
		// Token: 0x04011331 RID: 70449
		public BeActor hitTarget;

		// Token: 0x04011332 RID: 70450
		public BeActor attackTarget;

		// Token: 0x04011333 RID: 70451
		public BeEventHandle rebornHandle;
	}
}
