using System;

// Token: 0x0200420D RID: 16909
public class BeMoveBy : BeAction
{
	// Token: 0x0601769E RID: 95902 RVA: 0x00731C20 File Offset: 0x00730020
	public static BeMoveBy Create(BeEntity entity, int dur, VInt3 curPos, VInt3 deltaPos, bool ignoreBlock = true, IEntityFilter fil = null, bool needUpdateBackPos = false)
	{
		return new BeMoveBy
		{
			duration = dur,
			target = entity,
			startPos = curPos,
			deltaPos = deltaPos,
			ignoreBlcok = ignoreBlock,
			m_NeedUpdateBackPos = needUpdateBackPos
		};
	}

	// Token: 0x0601769F RID: 95903 RVA: 0x00731C64 File Offset: 0x00730064
	public sealed override void OnUpdate(VFactor process)
	{
		VInt3 vint = this.startPos + this.deltaPos * process;
		if (this.target == null)
		{
			return;
		}
		if (!this.ignoreBlcok && this.target.CurrentBeScene.IsInBlockPlayer(vint))
		{
			return;
		}
		if (this.filter != null && !this.filter.isFit(this.target))
		{
			return;
		}
		if (this.m_LockZ)
		{
			vint.z = this.target.GetPosition().z;
		}
		this.target.SetPosition(vint, false, true, this.m_NeedUpdateBackPos);
	}

	// Token: 0x04010CFE RID: 68862
	protected VInt3 startPos;

	// Token: 0x04010CFF RID: 68863
	protected VInt3 deltaPos;

	// Token: 0x04010D00 RID: 68864
	protected bool ignoreBlcok;

	// Token: 0x04010D01 RID: 68865
	protected IEntityFilter filter;

	// Token: 0x04010D02 RID: 68866
	protected bool m_NeedUpdateBackPos;

	// Token: 0x04010D03 RID: 68867
	protected bool m_LockZ;
}
