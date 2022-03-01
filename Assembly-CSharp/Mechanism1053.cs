using System;

// Token: 0x0200427F RID: 17023
public class Mechanism1053 : BeMechanism
{
	// Token: 0x060178DE RID: 96478 RVA: 0x0073FB40 File Offset: 0x0073DF40
	public Mechanism1053(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178DF RID: 96479 RVA: 0x0073FB4C File Offset: 0x0073DF4C
	public override void OnInit()
	{
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.triggerNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.triggerNum == 0)
		{
			this.triggerNum = 1;
		}
	}

	// Token: 0x060178E0 RID: 96480 RVA: 0x0073FBBB File Offset: 0x0073DFBB
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.curTriggerNum = 0;
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this.onAttackTarget));
	}

	// Token: 0x060178E1 RID: 96481 RVA: 0x0073FBF0 File Offset: 0x0073DFF0
	private void onAttackTarget(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (this.curTriggerNum >= this.triggerNum && this.triggerNum != 0)
		{
			return;
		}
		this.curTriggerNum++;
		BeProjectile beProjectile = base.owner.AddEntity(this.entityId, VInt3.zero, 1, 0) as BeProjectile;
		if (beProjectile != null)
		{
			beProjectile.SetPosition(beActor.GetPosition(), false, true);
		}
	}

	// Token: 0x04010ECD RID: 69325
	private int entityId;

	// Token: 0x04010ECE RID: 69326
	protected int triggerNum;

	// Token: 0x04010ECF RID: 69327
	protected int curTriggerNum;
}
