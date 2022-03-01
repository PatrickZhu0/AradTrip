using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004233 RID: 16947
public class Buff800001 : BeBuff
{
	// Token: 0x0601774F RID: 96079 RVA: 0x00734FD0 File Offset: 0x007333D0
	public Buff800001(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017750 RID: 96080 RVA: 0x00734FF8 File Offset: 0x007333F8
	public override void OnInit()
	{
		base.OnInit();
		if (this.buffData.ValueA.Count >= 1)
		{
			this.mEffectID = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], 1, true);
		}
		if (this.buffData.ValueB.Count >= 1)
		{
			this.mRadius = TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], 1, true);
		}
		if (this.buffData.ValueC.Count >= 1)
		{
			this.mCamp = TableManager.GetValueFromUnionCell(this.buffData.ValueC[0], 1, true);
		}
	}

	// Token: 0x06017751 RID: 96081 RVA: 0x007350AC File Offset: 0x007334AC
	public override void OnStart()
	{
		base.OnStart();
		this.mTarget = this._findActor();
		base.owner.ChangeRunMode(true);
		base.owner.aiManager.Stop();
	}

	// Token: 0x06017752 RID: 96082 RVA: 0x007350DC File Offset: 0x007334DC
	private void _tryDoEffect()
	{
		base.owner.m_pkGeActor.SetActorVisible(false);
		base.owner.PlayAction("ExpDead", 1f);
	}

	// Token: 0x06017753 RID: 96083 RVA: 0x00735108 File Offset: 0x00733508
	private BeActor _findActor()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), 150000, this.mCamp, 0);
		BeActor result = null;
		if (list.Count > 0)
		{
			result = list[0];
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017754 RID: 96084 RVA: 0x00735166 File Offset: 0x00733566
	public override void OnFinish()
	{
		if (!base.owner.IsDead())
		{
			this._tryDoEffect();
			base.owner.delayCaller.DelayCall(30, delegate
			{
				base.owner.DoDead(true);
			}, 0, 0, false);
		}
	}

	// Token: 0x06017755 RID: 96085 RVA: 0x007351A0 File Offset: 0x007335A0
	private void _moveTo(BeActor actor, int delta)
	{
		this.mDealCount += delta;
		if (this.mDealCount > 450)
		{
			this.mPos = actor.GetPosition() - base.owner.GetPosition();
			this.mDealCount = 0;
		}
		base.owner.ResetMoveCmd();
		if (this.mPos.x > Buff800001.dis01)
		{
			base.owner.ModifyMoveCmd(0, true);
		}
		else if (this.mPos.x < -Buff800001.dis01)
		{
			base.owner.ModifyMoveCmd(1, true);
		}
		if (this.mPos.y > Buff800001.dis01)
		{
			base.owner.ModifyMoveCmd(2, true);
		}
		else if (this.mPos.y < -Buff800001.dis01)
		{
			base.owner.ModifyMoveCmd(3, true);
		}
	}

	// Token: 0x06017756 RID: 96086 RVA: 0x007352C0 File Offset: 0x007336C0
	public override void OnUpdate(int delta)
	{
		base.OnUpdate(delta);
		if (base.owner != null && !base.owner.IsDead())
		{
			if (this.mTarget == null)
			{
				BeActor beActor = this._findActor();
				if (beActor != null && beActor != this.mTarget)
				{
					this.mTarget = beActor;
				}
			}
			if (this.mTarget != null)
			{
				this._moveTo(this.mTarget, delta);
			}
		}
	}

	// Token: 0x04010D64 RID: 68964
	private VInt mRadius = VInt.one;

	// Token: 0x04010D65 RID: 68965
	private int mEffectID = -1;

	// Token: 0x04010D66 RID: 68966
	private int mCamp = -1;

	// Token: 0x04010D67 RID: 68967
	private BeActor mTarget;

	// Token: 0x04010D68 RID: 68968
	private int mDealCount;

	// Token: 0x04010D69 RID: 68969
	private VInt3 mPos;

	// Token: 0x04010D6A RID: 68970
	private static readonly VInt dis01 = VInt.Float2VIntValue(0.1f);
}
