using System;

// Token: 0x02004245 RID: 16965
public sealed class AccelerateFollowTarget : LinearLogicTrial
{
	// Token: 0x06017792 RID: 96146 RVA: 0x00737A94 File Offset: 0x00735E94
	public override void Init()
	{
		base.Init();
		this.currentPos = this.StartPoint;
		this.m_CurSpeed = this.m_InitSpeed;
	}

	// Token: 0x06017793 RID: 96147 RVA: 0x00737AB4 File Offset: 0x00735EB4
	public override void OnTick(int deltaTime)
	{
		if (this.owner.IsDead())
		{
			return;
		}
		VInt3 vint = this.target.GetPosition() + new VInt3(0, 0, this.offsetHeight.i);
		VInt3 vint2 = vint - this.currentPos;
		if (this.CheckNearNotMove(vint2.magnitude))
		{
			this.currentPos = vint;
			this.owner.SetPosition(this.currentPos, false, true);
			this.owner.DoDie();
			return;
		}
		VInt3 rhs = vint2.NormalizeTo(this.m_CurSpeed.i);
		this.m_CurSpeed += this.m_AccSpeed;
		if (rhs.magnitude > vint2.magnitude)
		{
			rhs = vint2;
		}
		this.currentPos += rhs;
	}

	// Token: 0x06017794 RID: 96148 RVA: 0x00737B8B File Offset: 0x00735F8B
	private bool CheckNearNotMove(int dis)
	{
		return dis <= 5000;
	}

	// Token: 0x04010DD9 RID: 69081
	public BeActor target;

	// Token: 0x04010DDA RID: 69082
	public BeProjectile owner;

	// Token: 0x04010DDB RID: 69083
	public VInt offsetHeight = 0;

	// Token: 0x04010DDC RID: 69084
	public VInt m_InitSpeed;

	// Token: 0x04010DDD RID: 69085
	public VInt m_AccSpeed;

	// Token: 0x04010DDE RID: 69086
	private VInt m_CurSpeed;
}
