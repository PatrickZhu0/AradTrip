using System;

// Token: 0x020043F9 RID: 17401
public class Mechanism58 : BeMechanism
{
	// Token: 0x06018274 RID: 98932 RVA: 0x0078351D File Offset: 0x0078191D
	public Mechanism58(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018275 RID: 98933 RVA: 0x00783532 File Offset: 0x00781932
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			this.mDealIntervel = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		}
	}

	// Token: 0x06018276 RID: 98934 RVA: 0x00783572 File Offset: 0x00781972
	public override void OnStart()
	{
		base.owner.aiManager.Stop();
		base.owner.ChangeRunMode(true);
	}

	// Token: 0x06018277 RID: 98935 RVA: 0x00783590 File Offset: 0x00781990
	private void MoveTo(int delta)
	{
		this.mDealCount += delta;
		if (this.mDealCount > this.mDealIntervel)
		{
			VInt3 logicPosInRange = base.owner.CurrentBeScene.GetLogicPosInRange(base.owner, GlobalLogic.VALUE_20000);
			this.mPos = logicPosInRange - base.owner.GetPosition();
			this.mDealCount = 0;
			base.owner.ResetMoveCmd();
			if (this.mPos.x > VInt.zeroDotOne)
			{
				base.owner.ModifyMoveCmd(0, true);
				this.ChangeAnimation();
			}
			else if (this.mPos.x < -VInt.zeroDotOne)
			{
				base.owner.ModifyMoveCmd(1, true);
				this.ChangeAnimation();
			}
			if (this.mPos.y > VInt.zeroDotOne)
			{
				base.owner.ModifyMoveCmd(2, true);
				this.ChangeAnimation();
			}
			else if (this.mPos.y < -VInt.zeroDotOne)
			{
				base.owner.ModifyMoveCmd(3, true);
				this.ChangeAnimation();
			}
		}
	}

	// Token: 0x06018278 RID: 98936 RVA: 0x007836DD File Offset: 0x00781ADD
	private void ChangeAnimation()
	{
		base.owner.m_pkGeActor.ChangeAction("Anim_Zhuangji_02", 0.25f, true, true, false);
	}

	// Token: 0x06018279 RID: 98937 RVA: 0x007836FD File Offset: 0x00781AFD
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null && !base.owner.IsDead() && !base.owner.IsInPassiveState())
		{
			this.MoveTo(deltaTime);
		}
	}

	// Token: 0x0601827A RID: 98938 RVA: 0x00783731 File Offset: 0x00781B31
	public override void OnFinish()
	{
		if (!base.owner.IsDead())
		{
			base.owner.GetEntityData().SetHP(-1);
			base.owner.DoDead(false);
		}
	}

	// Token: 0x040116C3 RID: 71363
	private int mDealIntervel = 1000;

	// Token: 0x040116C4 RID: 71364
	private int mDealCount;

	// Token: 0x040116C5 RID: 71365
	private VInt3 mPos;
}
