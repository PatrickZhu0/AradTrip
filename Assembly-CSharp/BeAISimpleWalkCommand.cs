using System;
using UnityEngine;

// Token: 0x02004115 RID: 16661
public class BeAISimpleWalkCommand : BeAICommand
{
	// Token: 0x06016AEB RID: 92907 RVA: 0x006E0018 File Offset: 0x006DE418
	public BeAISimpleWalkCommand(BeEntity e, VInt3 targetPosition, VInt tolerance) : base(e, "AISimpleWalkCommand")
	{
		this.targetPos = targetPosition;
		this.tolerance = tolerance;
		this.bCanClose = false;
	}

	// Token: 0x06016AEC RID: 92908 RVA: 0x006E003C File Offset: 0x006DE43C
	public override void OnExecute()
	{
		int num = this.entity.GetPosition().x - this.targetPos.x;
		if (num < 0)
		{
			this.aiManager.DoWalk(BeAIManager.MoveDir.RIGHT, true);
		}
		else
		{
			this.aiManager.DoWalk(BeAIManager.MoveDir.LEFT, true);
		}
		this.bCanClose = false;
	}

	// Token: 0x06016AED RID: 92909 RVA: 0x006E0098 File Offset: 0x006DE498
	public override void OnTick(int deltaTime)
	{
		if (this.IsNearTargetPosition())
		{
			base.End();
			if (this.entity != null && this.entity.aiManager != null)
			{
				BeActorAIManager beActorAIManager = this.entity.aiManager as BeActorAIManager;
				if (beActorAIManager != null)
				{
					beActorAIManager.ResetDestinationSelect();
				}
			}
		}
	}

	// Token: 0x06016AEE RID: 92910 RVA: 0x006E00F0 File Offset: 0x006DE4F0
	public bool IsNearTargetPosition()
	{
		int i = this.tolerance.i;
		VInt3 position = this.entity.GetPosition();
		return Mathf.Abs(this.targetPos.x - position.x) <= i && Mathf.Abs(this.targetPos.y - position.y) <= i;
	}

	// Token: 0x040102C7 RID: 66247
	public VInt3 targetPos;

	// Token: 0x040102C8 RID: 66248
	public VInt tolerance;
}
