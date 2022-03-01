using System;

// Token: 0x02004242 RID: 16962
public sealed class Gravitation : LinearLogicTrial
{
	// Token: 0x06017788 RID: 96136 RVA: 0x007377D7 File Offset: 0x00735BD7
	public override void Init()
	{
		this.speedVec = new VInt3(this.speed * 10000, 0, 0);
		this.speed = 7;
		this.currentPos = this.StartPoint;
	}

	// Token: 0x06017789 RID: 96137 RVA: 0x00737808 File Offset: 0x00735C08
	public override void OnTick(int deltaTime)
	{
		if (this.target != null)
		{
			VInt3 position = this.target.GetPosition();
			position.z = 0;
			VInt3 position2 = this.owner.GetPosition();
			position2.z = 0;
			VInt3 rhs = (position - position2).NormalizeTo(10000) * new VFactor((long)this.acc, (long)GlobalLogic.VALUE_1000);
			this.speedVec = (this.speedVec + rhs).NormalizeTo(10000) * this.speed;
			VInt3 currentPos = this.owner.GetPosition() + this.speedVec * new VFactor((long)deltaTime, (long)GlobalLogic.VALUE_1000);
			this.currentPos = currentPos;
		}
	}

	// Token: 0x04010DCC RID: 69068
	public VInt3 speedVec = VInt3.zero;

	// Token: 0x04010DCD RID: 69069
	public int speed = 15;

	// Token: 0x04010DCE RID: 69070
	public int acc = 1200;

	// Token: 0x04010DCF RID: 69071
	public BeActor target;

	// Token: 0x04010DD0 RID: 69072
	public BeProjectile owner;
}
