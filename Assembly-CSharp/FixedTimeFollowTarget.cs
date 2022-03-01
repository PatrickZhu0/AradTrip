using System;

// Token: 0x02004244 RID: 16964
public sealed class FixedTimeFollowTarget : LinearLogicTrial
{
	// Token: 0x0601778F RID: 96143 RVA: 0x007379C7 File Offset: 0x00735DC7
	public override void Init()
	{
		base.Init();
		this.currentPos = this.StartPoint;
		this.curTime = 0;
	}

	// Token: 0x06017790 RID: 96144 RVA: 0x007379E4 File Offset: 0x00735DE4
	public override void OnTick(int deltaTime)
	{
		if (this.owner.IsDead())
		{
			return;
		}
		VInt3 b = this.target.GetPosition() + new VInt3(0, 0, this.offsetHeight.i);
		this.curTime += deltaTime;
		VInt3 currentPos = VInt3.Lerp(this.StartPoint, b, VFactor.NewVFactor(this.curTime * GlobalLogic.VALUE_1000 / this.moveTime, GlobalLogic.VALUE_1000));
		this.currentPos = currentPos;
		if (this.curTime >= this.moveTime)
		{
			this.owner.DoDie();
		}
	}

	// Token: 0x04010DD4 RID: 69076
	public BeActor target;

	// Token: 0x04010DD5 RID: 69077
	public BeProjectile owner;

	// Token: 0x04010DD6 RID: 69078
	public int moveTime;

	// Token: 0x04010DD7 RID: 69079
	private int curTime;

	// Token: 0x04010DD8 RID: 69080
	public VInt offsetHeight = 0;
}
