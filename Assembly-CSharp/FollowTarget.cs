using System;

// Token: 0x02004243 RID: 16963
public sealed class FollowTarget : LinearLogicTrial
{
	// Token: 0x0601778B RID: 96139 RVA: 0x007378D9 File Offset: 0x00735CD9
	public override void Init()
	{
		base.Init();
		this.currentPos = this.StartPoint;
	}

	// Token: 0x0601778C RID: 96140 RVA: 0x007378F0 File Offset: 0x00735CF0
	public override void OnTick(int deltaTime)
	{
		base.OnTick(deltaTime);
		if (this.owner.IsDead())
		{
			return;
		}
		VInt3 position = this.target.GetPosition();
		position.z = 0;
		VInt3 position2 = this.owner.GetPosition();
		position2.z = 0;
		if (this.CheckNearNotMove((position - position2).magnitude))
		{
			this.owner.DoDie();
		}
		VInt3 rhs = (position - position2).NormalizeTo(this.MoveSpeed.i);
		this.currentPos = this.owner.GetPosition() + rhs;
	}

	// Token: 0x0601778D RID: 96141 RVA: 0x00737996 File Offset: 0x00735D96
	private bool CheckNearNotMove(int dis)
	{
		return this.nearReove && dis <= 10000;
	}

	// Token: 0x04010DD1 RID: 69073
	public BeActor target;

	// Token: 0x04010DD2 RID: 69074
	public BeProjectile owner;

	// Token: 0x04010DD3 RID: 69075
	public bool nearReove;
}
