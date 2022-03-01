using System;
using System.Collections.Generic;

// Token: 0x0200421F RID: 16927
public class Buff2000002 : BeBuff
{
	// Token: 0x060176E2 RID: 95970 RVA: 0x00732C90 File Offset: 0x00731090
	public Buff2000002(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176E3 RID: 95971 RVA: 0x00732CB0 File Offset: 0x007310B0
	public override void OnInit()
	{
		int count = this.buffData.ValueB.Count;
		for (int i = 0; i < count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.ValueB[i], 1, true);
			if (valueFromUnionCell > 0)
			{
				this.buffIds.Add(valueFromUnionCell);
			}
		}
	}

	// Token: 0x060176E4 RID: 95972 RVA: 0x00732D0C File Offset: 0x0073110C
	public override void OnStart()
	{
		if (base.owner == null)
		{
			base.Finish();
			return;
		}
		this.target = this.FindTarget(base.owner.GetPosition());
		if (this.target == null)
		{
			base.Finish();
			return;
		}
		BeStateControl stateController = base.owner.stateController;
		if (stateController == null)
		{
			base.Finish();
			return;
		}
		if (!stateController.CanBeGrap())
		{
			base.Finish();
			return;
		}
		int num = (this.target.GetPosition().x - base.owner.GetPosition().x <= 0) ? 1 : -1;
		base.owner.Locomote(new BeStateData(15, 1, 0, 0, 0, this.duration, true), false);
		stateController.SetGrabStat(GrabState.BEING_GRAB);
		this.ownerOnHitHandler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			this.OnFinish();
		});
		this.targetBeKillHandler = this.target.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
		{
			this.OnFinish();
		});
		this.targetBeFallHandler = this.target.RegisterEvent(BeEventType.onStateChange, new BeEventHandle.Del(this.OnActorStateChange));
		this.isBited = true;
		BeBuffManager buffController = this.target.buffController;
		if (buffController != null)
		{
			for (int i = 0; i < this.buffIds.Count; i++)
			{
				buffController.TryAddBuff(this.buffIds[i], null, false, null, 0);
			}
		}
	}

	// Token: 0x060176E5 RID: 95973 RVA: 0x00732E90 File Offset: 0x00731290
	public void OnActorStateChange(object[] args)
	{
		ActionState actionState = (ActionState)args[0];
		if (actionState == ActionState.AS_FALL)
		{
			this.OnFinish();
		}
	}

	// Token: 0x060176E6 RID: 95974 RVA: 0x00732EB4 File Offset: 0x007312B4
	protected BeActor FindTarget(VInt3 pos)
	{
		if (base.owner == null)
		{
			return null;
		}
		return base.owner.CurrentBeScene.FindNearestRangeTarget(pos, base.owner, VInt.one, null);
	}

	// Token: 0x060176E7 RID: 95975 RVA: 0x00732EF0 File Offset: 0x007312F0
	public override void OnFinish()
	{
		this.RemoveHandler();
		if (!this.isBited)
		{
			return;
		}
		if (base.owner == null)
		{
			return;
		}
		BeStateControl stateController = base.owner.stateController;
		if (stateController == null)
		{
			return;
		}
		if (stateController.IsBeingGrab())
		{
			base.owner.sgClearStateStack();
			base.owner.sgPushState(new BeStateData(9, 0));
			base.owner.sgLocomoteState();
			base.owner.OnDealFrameTag(DSFFrameTags.TAG_SET_TARGET_POS_XY);
		}
		if (this.target != null)
		{
			BeBuffManager buffController = this.target.buffController;
			if (buffController != null)
			{
				for (int i = 0; i < this.buffIds.Count; i++)
				{
					buffController.RemoveBuff(this.buffIds[i], 1, 0);
				}
			}
		}
	}

	// Token: 0x060176E8 RID: 95976 RVA: 0x00732FC0 File Offset: 0x007313C0
	private void RemoveHandler()
	{
		if (this.ownerOnHitHandler != null)
		{
			this.ownerOnHitHandler.Remove();
			this.ownerOnHitHandler = null;
		}
		if (this.targetBeKillHandler != null)
		{
			this.targetBeKillHandler.Remove();
			this.targetBeKillHandler = null;
		}
		if (this.targetBeFallHandler != null)
		{
			this.targetBeFallHandler.Remove();
			this.targetBeFallHandler = null;
		}
	}

	// Token: 0x060176E9 RID: 95977 RVA: 0x00733024 File Offset: 0x00731424
	public override void OnUpdate(int delta)
	{
		if (!this.isBited)
		{
			return;
		}
		if (base.owner == null || this.target == null)
		{
			return;
		}
		if (this.target.IsDead() || base.owner.IsDead())
		{
			this.OnFinish();
			return;
		}
		BeStateControl stateController = base.owner.stateController;
		if (stateController == null)
		{
			return;
		}
		if (!stateController.IsBeingGrab())
		{
			this.OnFinish();
			return;
		}
		VInt3 position = this.target.GetPosition();
		VInt3 rkPos = position;
		if (base.owner.GetFace())
		{
			rkPos.x = position.x + VInt.Float2VIntValue(0.7f);
		}
		else
		{
			rkPos.x = position.x - VInt.Float2VIntValue(0.7f);
		}
		rkPos.y -= VInt.Float2VIntValue(0.03f);
		rkPos.z += VInt.Float2VIntValue(0.3f);
		base.owner.SetPosition(rkPos, false, true, false);
	}

	// Token: 0x060176EA RID: 95978 RVA: 0x00733134 File Offset: 0x00731534
	public override void DoWorkForInterval()
	{
		if (base.owner.stateController.IsBeingGrab())
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
			base.owner.DoAttackTo(this.target, valueFromUnionCell, true, false);
		}
	}

	// Token: 0x04010D29 RID: 68905
	private int maxHitCount = 5;

	// Token: 0x04010D2A RID: 68906
	private BeActor target;

	// Token: 0x04010D2B RID: 68907
	private BeEventHandle ownerOnHitHandler;

	// Token: 0x04010D2C RID: 68908
	private BeEventHandle targetBeKillHandler;

	// Token: 0x04010D2D RID: 68909
	private BeEventHandle targetBeFallHandler;

	// Token: 0x04010D2E RID: 68910
	private bool isBited;

	// Token: 0x04010D2F RID: 68911
	private List<int> buffIds = new List<int>();
}
