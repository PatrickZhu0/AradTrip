using System;

// Token: 0x020042B3 RID: 17075
public class Mechanism1121 : BeMechanism
{
	// Token: 0x060179EF RID: 96751 RVA: 0x00746E59 File Offset: 0x00745259
	public Mechanism1121(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179F0 RID: 96752 RVA: 0x00746E63 File Offset: 0x00745263
	public override void OnStart()
	{
		base.OnStart();
		this.m_IsInBlock = false;
		this.RecordPos();
	}

	// Token: 0x060179F1 RID: 96753 RVA: 0x00746E78 File Offset: 0x00745278
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.RecordPos();
	}

	// Token: 0x060179F2 RID: 96754 RVA: 0x00746E87 File Offset: 0x00745287
	public override void OnFinish()
	{
		base.OnFinish();
		this.RestorePos();
	}

	// Token: 0x060179F3 RID: 96755 RVA: 0x00746E98 File Offset: 0x00745298
	protected void RecordPos()
	{
		if (this.m_IsInBlock)
		{
			return;
		}
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		VInt3 position = base.owner.GetPosition();
		if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
		{
			this.m_IsInBlock = true;
			return;
		}
		this.m_RecordNotInBlockPos = position;
	}

	// Token: 0x060179F4 RID: 96756 RVA: 0x00746EF4 File Offset: 0x007452F4
	protected void RestorePos()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (!base.owner.CurrentBeScene.IsInBlockPlayer(base.owner.GetPosition()))
		{
			return;
		}
		if (base.owner.CurrentBeScene.IsInBlockPlayer(this.m_RecordNotInBlockPos))
		{
			Logger.LogErrorFormat("发生严重错误 记录的坐标处于阻挡中:{0}", new object[]
			{
				this.m_RecordNotInBlockPos
			});
			VInt3 rkPos = BeAIManager.FindStandPositionNew(this.m_RecordNotInBlockPos, base.owner.CurrentBeScene, false, false, 50);
			base.owner.SetPosition(rkPos, false, true, false);
			return;
		}
		base.owner.SetPosition(this.m_RecordNotInBlockPos, false, true, false);
	}

	// Token: 0x04010F9F RID: 69535
	protected VInt3 m_RecordNotInBlockPos;

	// Token: 0x04010FA0 RID: 69536
	protected bool m_IsInBlock;
}
