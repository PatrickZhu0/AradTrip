using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004306 RID: 17158
public class Mechanism13 : BeMechanism
{
	// Token: 0x06017BC6 RID: 97222 RVA: 0x00751CD5 File Offset: 0x007500D5
	public Mechanism13(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BC7 RID: 97223 RVA: 0x00751CF4 File Offset: 0x007500F4
	public override void OnInit()
	{
		this.distanceExplode = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		if (this.data.ValueB.Count > 0)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
			this.actorVisibleFlag = (valueFromUnionCell == 0);
			this.needRemove = (valueFromUnionCell == 2);
			this.m_delayRemove = (valueFromUnionCell == 3);
		}
	}

	// Token: 0x06017BC8 RID: 97224 RVA: 0x00751D94 File Offset: 0x00750194
	public override void OnStart()
	{
		this.mTarget = this._findActor();
		base.owner.aiManager.StopCurrentCommand();
		base.owner.aiManager.Stop();
		base.owner.SetForceRunMode(true);
		base.owner.ChangeRunMode(true);
		base.owner.delayCaller.DelayCall(100, delegate
		{
			if (!base.owner.IsDead() && !base.owner.IsGrabed())
			{
				if (base.owner.IsGrabed())
				{
					base.owner.sgPushState(new BeStateData(3, 0));
				}
				else
				{
					base.owner.Locomote(new BeStateData(3, 0), false);
				}
			}
		}, 0, 0, false);
	}

	// Token: 0x06017BC9 RID: 97225 RVA: 0x00751E08 File Offset: 0x00750208
	public override void OnUpdate(int deltaTime)
	{
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
			if (!base.owner.IsInPassiveState() && this.mTarget != null)
			{
				this._moveTo(this.mTarget, deltaTime);
				if ((this.mTarget.GetPosition() - base.owner.GetPosition()).magnitude <= this.distanceExplode.i)
				{
					this._DoDead();
				}
			}
		}
	}

	// Token: 0x06017BCA RID: 97226 RVA: 0x00751EBC File Offset: 0x007502BC
	public override void OnFinish()
	{
		this._DoDead();
		this.m_delayCalleerHandler.SetRemove(true);
	}

	// Token: 0x06017BCB RID: 97227 RVA: 0x00751ED0 File Offset: 0x007502D0
	private void _DoDead()
	{
		if (!base.owner.IsDead() && !this.playExpdeaded)
		{
			this._tryDoEffect();
			if (this.needRemove)
			{
				this._onSetDead();
			}
			else if (this.m_delayRemove)
			{
				if (base.owner.CurrentBeScene != null)
				{
					this.m_delayCalleerHandler = base.owner.CurrentBeScene.DelayCaller.DelayCall(0, new DelayCaller.Del(this._onSetDead), 0, 0, false);
				}
			}
			else
			{
				base.owner.delayCaller.DelayCall(30, delegate
				{
					base.owner.DoDead(false);
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x06017BCC RID: 97228 RVA: 0x00751F81 File Offset: 0x00750381
	private void _onSetDead()
	{
		if (base.owner.m_iEntityLifeState != 4)
		{
			base.owner.SetIsDead(true);
			base.owner.OnDead();
			base.owner.SetLifeState(EntityLifeState.ELS_CANREMOVE);
		}
	}

	// Token: 0x06017BCD RID: 97229 RVA: 0x00751FB8 File Offset: 0x007503B8
	private void _tryDoEffect()
	{
		this.playExpdeaded = true;
		if (this.actorVisibleFlag)
		{
			base.owner.m_pkGeActor.SetActorVisible(false);
		}
		base.owner.PlayAction("ExpDead", 1f);
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.RemoveHPBar();
		}
	}

	// Token: 0x06017BCE RID: 97230 RVA: 0x00752020 File Offset: 0x00750420
	private BeActor _findActor()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), VInt.Float2VIntValue(15f), 0, 0);
		BeActor result = null;
		if (list.Count > 0)
		{
			result = list[0];
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017BCF RID: 97231 RVA: 0x00752080 File Offset: 0x00750480
	private void _moveTo(BeActor actor, int delta)
	{
		this.mDealCount += delta;
		if (this.mDealCount > 450)
		{
			this.mPos = actor.GetPosition() - base.owner.GetPosition();
			this.mDealCount = 0;
			base.owner.ResetMoveCmd();
			if (this.mPos.x > VInt.half)
			{
				base.owner.ModifyMoveCmd(0, true);
			}
			else if (this.mPos.x < -VInt.half)
			{
				base.owner.ModifyMoveCmd(1, true);
			}
			if (this.mPos.y > VInt.half)
			{
				base.owner.ModifyMoveCmd(2, true);
			}
			else if (this.mPos.y < -VInt.half)
			{
				base.owner.ModifyMoveCmd(3, true);
			}
			return;
		}
	}

	// Token: 0x040110FE RID: 69886
	private VInt distanceExplode = 0;

	// Token: 0x040110FF RID: 69887
	private BeActor mTarget;

	// Token: 0x04011100 RID: 69888
	private bool playExpdeaded;

	// Token: 0x04011101 RID: 69889
	protected bool actorVisibleFlag = true;

	// Token: 0x04011102 RID: 69890
	private bool needRemove;

	// Token: 0x04011103 RID: 69891
	private bool m_delayRemove;

	// Token: 0x04011104 RID: 69892
	private DelayCallUnitHandle m_delayCalleerHandler;

	// Token: 0x04011105 RID: 69893
	private int mDealCount;

	// Token: 0x04011106 RID: 69894
	private VInt3 mPos;
}
