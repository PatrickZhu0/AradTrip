using System;
using UnityEngine;

// Token: 0x0200423F RID: 16959
public class LinearLogicTrial
{
	// Token: 0x0601777F RID: 96127 RVA: 0x00737348 File Offset: 0x00735748
	public virtual void Init()
	{
		this.currentPos = this.StartPoint;
		this.MoveDir = (this.EndPoint - this.StartPoint).NormalizeTo(10000);
		Vector3 normalized = (this.EndPoint.vector3 - this.StartPoint.vector3).normalized;
		this.TimeAcc = 0;
	}

	// Token: 0x06017780 RID: 96128 RVA: 0x007373B0 File Offset: 0x007357B0
	public virtual void OnTick(int deltaTime)
	{
		this.TimeAcc += deltaTime;
		VInt3 rhs = this.MoveDir * (VFactor.NewVFactor((long)deltaTime, 1000L) * this.MoveSpeed.factor);
		this.currentPos += rhs;
	}

	// Token: 0x04010DBA RID: 69050
	public VInt3 StartPoint;

	// Token: 0x04010DBB RID: 69051
	public VInt3 EndPoint;

	// Token: 0x04010DBC RID: 69052
	public VInt MoveSpeed;

	// Token: 0x04010DBD RID: 69053
	public VInt3 MoveDir;

	// Token: 0x04010DBE RID: 69054
	public VInt3 currentPos;

	// Token: 0x04010DBF RID: 69055
	protected int TimeAcc;
}
