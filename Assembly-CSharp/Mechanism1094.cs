using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020042A0 RID: 17056
public class Mechanism1094 : BeMechanism
{
	// Token: 0x0601798C RID: 96652 RVA: 0x00744AD5 File Offset: 0x00742ED5
	public Mechanism1094(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601798D RID: 96653 RVA: 0x00744AEC File Offset: 0x00742EEC
	public override void OnInit()
	{
		this.chainEffect = this.data.StringValueA[0];
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.distance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601798E RID: 96654 RVA: 0x00744B94 File Offset: 0x00742F94
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.RemoveEventHandle();
			this.ownerDeadHandle = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnDeadEvent));
			this.ownerRebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this.OnRebornEvent));
		}
	}

	// Token: 0x0601798F RID: 96655 RVA: 0x00744BF0 File Offset: 0x00742FF0
	public override void OnUpdate(int deltaTime)
	{
		if (this.target == null)
		{
			this.mFindTargetTimer += deltaTime;
			if (this.mFindTargetTimer > this.mFindTargetCD)
			{
				this.mFindTargetTimer = 0;
				this.FindTarget();
				this.needUpdateState = true;
			}
		}
		if (this.needUpdateState)
		{
			this.UpdateFlag();
		}
		if (this.needUpdatePos && base.owner != null && this.target != null)
		{
			bool flag = this.IsInRange(base.owner, this.target);
			if (flag && !this.hasCreateChain)
			{
				this.CreateChainEffect();
			}
			else if (!flag && this.hasCreateChain)
			{
				this.ClearChainEffect();
			}
		}
	}

	// Token: 0x06017990 RID: 96656 RVA: 0x00744CB3 File Offset: 0x007430B3
	public override void OnFinish()
	{
		this.RemoveEventHandle();
	}

	// Token: 0x06017991 RID: 96657 RVA: 0x00744CBC File Offset: 0x007430BC
	private void FindTarget()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null && list[i].GetPID() != base.owner.GetPID())
				{
					this.target = list[i];
					this.targetDeadHandle = this.target.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnDeadEvent));
					this.targetRebornHandle = this.target.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this.OnRebornEvent));
					break;
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017992 RID: 96658 RVA: 0x00744D83 File Offset: 0x00743183
	private void OnDeadEvent(object[] args)
	{
		this.needUpdateState = true;
		this.ClearChainEffect();
	}

	// Token: 0x06017993 RID: 96659 RVA: 0x00744D92 File Offset: 0x00743192
	private void OnRebornEvent(object[] args)
	{
		this.needUpdateState = true;
	}

	// Token: 0x06017994 RID: 96660 RVA: 0x00744D9C File Offset: 0x0074319C
	private void UpdateFlag()
	{
		if (base.owner == null || this.target == null)
		{
			this.needUpdatePos = false;
			return;
		}
		if (base.owner.IsDead() || this.target.IsDead())
		{
			this.needUpdatePos = false;
		}
		else
		{
			this.needUpdatePos = true;
		}
	}

	// Token: 0x06017995 RID: 96661 RVA: 0x00744DFA File Offset: 0x007431FA
	private bool IsInRange(BeActor player1, BeActor player2)
	{
		return !(player1.GetDistance(player2) > this.distance);
	}

	// Token: 0x06017996 RID: 96662 RVA: 0x00744E1C File Offset: 0x0074321C
	private void RemoveEventHandle()
	{
		if (this.ownerDeadHandle != null)
		{
			this.ownerDeadHandle.Remove();
			this.ownerDeadHandle = null;
		}
		if (this.ownerRebornHandle != null)
		{
			this.ownerRebornHandle.Remove();
			this.ownerRebornHandle = null;
		}
		if (this.targetDeadHandle != null)
		{
			this.targetDeadHandle.Remove();
			this.targetDeadHandle = null;
		}
		if (this.targetRebornHandle != null)
		{
			this.targetRebornHandle.Remove();
			this.targetRebornHandle = null;
		}
	}

	// Token: 0x06017997 RID: 96663 RVA: 0x00744EA0 File Offset: 0x007432A0
	private void CreateChainEffect()
	{
		if (base.owner == null || this.target == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		base.owner.m_pkGeActor.CreateChainEffect(this.target, this.chainEffect, EffectTimeType.SYNC_ANIMATION, false);
		base.owner.buffController.TryAddBuff(this.buffId, -1, this.level);
		this.target.buffController.TryAddBuff(this.buffId, -1, this.level);
		this.hasCreateChain = true;
	}

	// Token: 0x06017998 RID: 96664 RVA: 0x00744F40 File Offset: 0x00743340
	private void ClearChainEffect()
	{
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		base.owner.m_pkGeActor.ClearChainEffect();
		base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
		this.target.buffController.RemoveBuff(this.buffId, 0, 0);
		this.hasCreateChain = false;
	}

	// Token: 0x04010F4F RID: 69455
	private string chainEffect;

	// Token: 0x04010F50 RID: 69456
	private int monsterID;

	// Token: 0x04010F51 RID: 69457
	private int buffId;

	// Token: 0x04010F52 RID: 69458
	private VInt distance;

	// Token: 0x04010F53 RID: 69459
	private BeActor target;

	// Token: 0x04010F54 RID: 69460
	private BeEventHandle ownerDeadHandle;

	// Token: 0x04010F55 RID: 69461
	private BeEventHandle ownerRebornHandle;

	// Token: 0x04010F56 RID: 69462
	private BeEventHandle targetDeadHandle;

	// Token: 0x04010F57 RID: 69463
	private BeEventHandle targetRebornHandle;

	// Token: 0x04010F58 RID: 69464
	private bool needUpdatePos;

	// Token: 0x04010F59 RID: 69465
	private bool hasCreateChain;

	// Token: 0x04010F5A RID: 69466
	private bool needUpdateState;

	// Token: 0x04010F5B RID: 69467
	private int mFindTargetCD = 500;

	// Token: 0x04010F5C RID: 69468
	private int mFindTargetTimer;
}
