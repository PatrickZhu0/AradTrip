using System;
using UnityEngine;

// Token: 0x02004146 RID: 16710
public class BeActorMoveController : IBeActorController
{
	// Token: 0x06016CCD RID: 93389 RVA: 0x00700BB7 File Offset: 0x006FEFB7
	public BeActorMoveController(VInt3 targetPosition, float tolerance, bool autoRemove = true)
	{
		this.targetPos = targetPosition;
		this.tolerance = VInt.Float2VIntValue(tolerance);
		this.autoRemove = autoRemove;
	}

	// Token: 0x06016CCE RID: 93390 RVA: 0x00700BDE File Offset: 0x006FEFDE
	public void SetOwner(BeActor actor)
	{
		this.owner = actor;
	}

	// Token: 0x06016CCF RID: 93391 RVA: 0x00700BE7 File Offset: 0x006FEFE7
	public void OnEnter()
	{
	}

	// Token: 0x06016CD0 RID: 93392 RVA: 0x00700BE9 File Offset: 0x006FEFE9
	public bool AutoRemove()
	{
		return this.autoRemove;
	}

	// Token: 0x06016CD1 RID: 93393 RVA: 0x00700BF4 File Offset: 0x006FEFF4
	public void OnTick(int delta)
	{
		if (this.isEnd)
		{
			return;
		}
		int num = this.owner.GetPosition().x - this.targetPos.x;
		if (num < 0)
		{
			this.DoWalk(BeActorMoveController.MoveDir.RIGHT, true);
		}
		else
		{
			this.DoWalk(BeActorMoveController.MoveDir.LEFT, true);
		}
		if (this.IsNearTargetPosition())
		{
			this.isEnd = true;
			this.owner.ResetMoveCmd();
		}
	}

	// Token: 0x06016CD2 RID: 93394 RVA: 0x00700C66 File Offset: 0x006FF066
	public bool IsEnd()
	{
		return this.isEnd;
	}

	// Token: 0x06016CD3 RID: 93395 RVA: 0x00700C70 File Offset: 0x006FF070
	private bool IsNearTargetPosition()
	{
		int i = this.tolerance.i;
		VInt3 position = this.owner.GetPosition();
		return Mathf.Abs(this.targetPos.x - position.x) <= i && Mathf.Abs(this.targetPos.y - position.y) <= i;
	}

	// Token: 0x06016CD4 RID: 93396 RVA: 0x00700CD4 File Offset: 0x006FF0D4
	private void DoWalk(BeActorMoveController.MoveDir dir, bool reset = false)
	{
		if (reset)
		{
			this.owner.ResetMoveCmd();
		}
		switch (dir)
		{
		case BeActorMoveController.MoveDir.RIGHT:
			this.owner.ModifyMoveCmd(0, true);
			break;
		case BeActorMoveController.MoveDir.LEFT:
			this.owner.ModifyMoveCmd(1, true);
			break;
		case BeActorMoveController.MoveDir.TOP:
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeActorMoveController.MoveDir.DOWN:
			this.owner.ModifyMoveCmd(3, true);
			break;
		case BeActorMoveController.MoveDir.RIGHT_TOP:
			this.owner.ModifyMoveCmd(0, true);
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeActorMoveController.MoveDir.LEFT_TOP:
			this.owner.ModifyMoveCmd(1, true);
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeActorMoveController.MoveDir.RIGHT_DOWN:
			this.owner.ModifyMoveCmd(0, true);
			this.owner.ModifyMoveCmd(3, true);
			break;
		case BeActorMoveController.MoveDir.LEFT_DOWN:
			this.owner.ModifyMoveCmd(1, true);
			this.owner.ModifyMoveCmd(3, true);
			break;
		}
	}

	// Token: 0x040104A4 RID: 66724
	public BeActor owner;

	// Token: 0x040104A5 RID: 66725
	public VInt3 targetPos;

	// Token: 0x040104A6 RID: 66726
	public VInt tolerance;

	// Token: 0x040104A7 RID: 66727
	private bool isEnd;

	// Token: 0x040104A8 RID: 66728
	private bool autoRemove;

	// Token: 0x02004147 RID: 16711
	private enum MoveDir
	{
		// Token: 0x040104AA RID: 66730
		RIGHT,
		// Token: 0x040104AB RID: 66731
		LEFT,
		// Token: 0x040104AC RID: 66732
		TOP,
		// Token: 0x040104AD RID: 66733
		DOWN,
		// Token: 0x040104AE RID: 66734
		RIGHT_TOP,
		// Token: 0x040104AF RID: 66735
		LEFT_TOP,
		// Token: 0x040104B0 RID: 66736
		RIGHT_DOWN,
		// Token: 0x040104B1 RID: 66737
		LEFT_DOWN,
		// Token: 0x040104B2 RID: 66738
		COUNT
	}
}
