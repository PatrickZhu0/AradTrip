using System;

// Token: 0x02004325 RID: 17189
public class Mechanism157 : BeMechanism
{
	// Token: 0x06017C86 RID: 97414 RVA: 0x00757A8F File Offset: 0x00755E8F
	public Mechanism157(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C87 RID: 97415 RVA: 0x00757ABC File Offset: 0x00755EBC
	public override void OnInit()
	{
		base.OnInit();
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mPos = new VInt2(valueFromUnionCell, valueFromUnionCell2);
		this.mDurTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017C88 RID: 97416 RVA: 0x00757B4A File Offset: 0x00755F4A
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null)
		{
			return;
		}
		base.owner.aiManager.Stop();
		this.moveTime = 0;
		this.mStarted = true;
	}

	// Token: 0x06017C89 RID: 97417 RVA: 0x00757B7C File Offset: 0x00755F7C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner == null)
		{
			return;
		}
		if (!this.mStarted)
		{
			return;
		}
		this.elapsTime += deltaTime;
		if (this.elapsTime < this.intervel)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			this.mStarted = false;
			return;
		}
		this.moveTime += this.elapsTime;
		this.elapsTime -= this.intervel;
		if (base.owner.stateController.WillBeGrab() || base.owner.stateController.IsGraping() || base.owner.stateController.IsBeingGrab())
		{
			this.mStarted = false;
			return;
		}
		if (!base.owner.stateController.CanNotAbsorbByBlockHole())
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CANNOTBE_SUCKED, false);
			this.disableSucked = true;
		}
		VInt2 vint = this.mPos - base.owner.GetPosition2();
		int num = this.mDurTime - this.moveTime;
		if (vint.magnitude <= this.tolerance.i)
		{
			base.owner.SetMoveSpeedX(VInt.zero);
			base.owner.SetMoveSpeedY(VInt.zero);
		}
		else if (num <= 0)
		{
			base.owner.SetMoveSpeedX(VInt.zero);
			base.owner.SetMoveSpeedY(VInt.zero);
			VInt3 rkPos = new VInt3(this.mPos.x, this.mPos.y, base.owner.GetPosition().z);
			base.owner.SetPosition(rkPos, false, true, false);
		}
		else
		{
			vint.NormalizeTo((vint.magnitude / num).i);
			base.owner.SetMoveSpeedX(vint.x);
			base.owner.SetMoveSpeedY(vint.y);
		}
		if (this.IsNearTargetPosition())
		{
			base.owner.aiManager.Start();
			if (this.disableSucked)
			{
				base.owner.stateController.SetAbilityEnable(BeAbilityType.CANNOTBE_SUCKED, true);
				this.disableSucked = false;
			}
			this.mStarted = false;
		}
	}

	// Token: 0x06017C8A RID: 97418 RVA: 0x00757DDC File Offset: 0x007561DC
	private bool IsNearTargetPosition()
	{
		int i = this.tolerance.i;
		int magnitude = (base.owner.GetPosition2() - this.mPos).magnitude;
		return magnitude <= i;
	}

	// Token: 0x040111B6 RID: 70070
	private VInt2 mPos;

	// Token: 0x040111B7 RID: 70071
	private int mDurTime;

	// Token: 0x040111B8 RID: 70072
	private int intervel = GlobalLogic.VALUE_200;

	// Token: 0x040111B9 RID: 70073
	private int elapsTime;

	// Token: 0x040111BA RID: 70074
	private bool mStarted;

	// Token: 0x040111BB RID: 70075
	private VInt tolerance = VInt.Float2VIntValue(0.1f);

	// Token: 0x040111BC RID: 70076
	private int moveTime;

	// Token: 0x040111BD RID: 70077
	private bool disableSucked;
}
