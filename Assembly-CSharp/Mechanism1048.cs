using System;

// Token: 0x02004279 RID: 17017
public class Mechanism1048 : BeMechanism
{
	// Token: 0x060178C5 RID: 96453 RVA: 0x0073F207 File Offset: 0x0073D607
	public Mechanism1048(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178C6 RID: 96454 RVA: 0x0073F211 File Offset: 0x0073D611
	public override void OnInit()
	{
		base.OnInit();
		this.hurtId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060178C7 RID: 96455 RVA: 0x0073F241 File Offset: 0x0073D641
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, new BeEventHandle.Del(this.RegisterBeHit));
	}

	// Token: 0x060178C8 RID: 96456 RVA: 0x0073F268 File Offset: 0x0073D668
	private void RegisterBeHit(object[] args)
	{
		int num = (int)args[1];
		bool[] array = (bool[])args[2];
		if (this.hurtId != num)
		{
			return;
		}
		array[0] = true;
	}

	// Token: 0x04010EBD RID: 69309
	private int hurtId;
}
