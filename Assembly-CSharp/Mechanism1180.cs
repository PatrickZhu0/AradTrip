using System;

// Token: 0x020042E8 RID: 17128
public class Mechanism1180 : BeMechanism
{
	// Token: 0x06017B37 RID: 97079 RVA: 0x0074E083 File Offset: 0x0074C483
	public Mechanism1180(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B38 RID: 97080 RVA: 0x0074E090 File Offset: 0x0074C490
	public override void OnInit()
	{
		this.mBoxX = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mBoxY = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
	}

	// Token: 0x06017B39 RID: 97081 RVA: 0x0074E0ED File Offset: 0x0074C4ED
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.mPrePos = base.owner.GetPosition();
		}
	}

	// Token: 0x06017B3A RID: 97082 RVA: 0x0074E10C File Offset: 0x0074C50C
	public override void OnUpdateImpactBySpeed(int deltaTime)
	{
		if (base.owner != null)
		{
			VInt3 position = base.owner.GetPosition();
			if (this.IsBoxInBlock(position))
			{
				base.owner.SetPosition(this.mPrePos, false, true, false);
			}
			else
			{
				this.mPrePos = position;
			}
		}
	}

	// Token: 0x06017B3B RID: 97083 RVA: 0x0074E15C File Offset: 0x0074C55C
	protected bool IsBoxInBlock(VInt3 pos)
	{
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			if (base.owner.CurrentBeScene.IsInBlockPlayer(new VInt3(pos.x + this.mBoxX, pos.y, pos.z)))
			{
				return true;
			}
			if (base.owner.CurrentBeScene.IsInBlockPlayer(new VInt3(pos.x - this.mBoxX, pos.y, pos.z)))
			{
				return true;
			}
			if (base.owner.CurrentBeScene.IsInBlockPlayer(new VInt3(pos.x, pos.y + this.mBoxY, pos.z)))
			{
				return true;
			}
			if (base.owner.CurrentBeScene.IsInBlockPlayer(new VInt3(pos.x, pos.y - this.mBoxY, pos.z)))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0401107E RID: 69758
	protected int mBoxX;

	// Token: 0x0401107F RID: 69759
	protected int mBoxY;

	// Token: 0x04011080 RID: 69760
	protected VInt3 mPrePos;
}
