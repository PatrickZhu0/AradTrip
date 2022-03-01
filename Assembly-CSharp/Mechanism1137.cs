using System;

// Token: 0x020042BB RID: 17083
public class Mechanism1137 : BeMechanism
{
	// Token: 0x06017A2C RID: 96812 RVA: 0x0074823D File Offset: 0x0074663D
	public Mechanism1137(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A2D RID: 96813 RVA: 0x00748258 File Offset: 0x00746658
	public override void OnInit()
	{
		this.m_MoveTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_OutSideRadius = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_OutSideRadius *= GlobalLogic.VALUE_10;
		this.m_MoveTime = ((this.m_MoveTime != 0) ? this.m_MoveTime : 1);
		this.m_LockZ = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
	}

	// Token: 0x06017A2E RID: 96814 RVA: 0x00748318 File Offset: 0x00746718
	public override void OnStart()
	{
		VInt3 vint;
		if (base.owner != null && this.findTargetPos(out vint))
		{
			this.SetOwnerFace(vint);
			base.owner.actionManager.StopAll();
			BeMoveTo action = BeMoveTo.Create(base.owner, this.m_MoveTime, base.owner.GetPosition(), vint, true, null, this.m_LockZ);
			base.owner.actionManager.RunAction(action);
		}
	}

	// Token: 0x06017A2F RID: 96815 RVA: 0x0074838B File Offset: 0x0074678B
	public override void OnUpdate(int deltaTime)
	{
		this.m_MoveAcc += deltaTime;
		if (this.m_MoveAcc > this.m_MoveTime)
		{
			base.Finish();
		}
	}

	// Token: 0x06017A30 RID: 96816 RVA: 0x007483B4 File Offset: 0x007467B4
	public override void OnFinish()
	{
		if (base.owner != null && base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.IsInBlockPlayer(base.owner.GetPosition()))
		{
			VInt3 rkPos = BeAIManager.FindStandPositionNew(base.owner.GetPosition(), base.owner.CurrentBeScene, base.owner.GetFace(), false, 40);
			base.owner.SetPosition(rkPos, false, true, false);
		}
	}

	// Token: 0x06017A31 RID: 96817 RVA: 0x00748438 File Offset: 0x00746838
	private void SetOwnerFace(VInt3 pos)
	{
		if (pos.x > base.owner.GetPosition().x)
		{
			base.owner.SetFace(false, false, false);
		}
		else
		{
			base.owner.SetFace(true, false, false);
		}
	}

	// Token: 0x06017A32 RID: 96818 RVA: 0x00748488 File Offset: 0x00746888
	private bool findTargetPos(out VInt3 targetPos)
	{
		bool result = false;
		targetPos = VInt3.zero;
		if (base.owner.CurrentBeScene != null)
		{
			VInt3 position = base.owner.GetPosition();
			int num = 0;
			VInt3 randomPos;
			for (;;)
			{
				num++;
				randomPos = base.owner.CurrentBeScene.GetRandomPos(10);
				if ((randomPos - position).magnitude > this.m_OutSideRadius)
				{
					break;
				}
				if (num >= this.searchCount)
				{
					return result;
				}
			}
			result = true;
			targetPos = randomPos;
		}
		return result;
	}

	// Token: 0x04010FBD RID: 69565
	protected int m_MoveTime = 1;

	// Token: 0x04010FBE RID: 69566
	protected int m_OutSideRadius;

	// Token: 0x04010FBF RID: 69567
	protected int searchCount = 5;

	// Token: 0x04010FC0 RID: 69568
	protected int m_MoveAcc;

	// Token: 0x04010FC1 RID: 69569
	protected bool m_LockZ;
}
