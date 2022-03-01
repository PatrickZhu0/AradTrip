using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004278 RID: 17016
public class Mechanism1047 : BeMechanism
{
	// Token: 0x060178C1 RID: 96449 RVA: 0x0073F090 File Offset: 0x0073D490
	public Mechanism1047(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178C2 RID: 96450 RVA: 0x0073F0B4 File Offset: 0x0073D4B4
	public override void OnInit()
	{
		base.OnInit();
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060178C3 RID: 96451 RVA: 0x0073F149 File Offset: 0x0073D549
	public override void OnStart()
	{
		base.OnStart();
		base.InitTimeAcc(this.timeAcc);
	}

	// Token: 0x060178C4 RID: 96452 RVA: 0x0073F160 File Offset: 0x0073D560
	public override void OnUpdateTimeAcc()
	{
		if (this.addBuffFlag)
		{
			return;
		}
		base.OnUpdateTimeAcc();
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), this.radius, base.owner.GetCamp(), this.monsterId);
		if (list.Count > 0)
		{
			this.addBuffFlag = true;
			list[0].buffController.TryAddBuffInfo(this.buffInfoId, base.owner, this.level);
			base.owner.DoDead(false);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04010EB8 RID: 69304
	private int monsterId;

	// Token: 0x04010EB9 RID: 69305
	private VInt radius = 0;

	// Token: 0x04010EBA RID: 69306
	private int buffInfoId;

	// Token: 0x04010EBB RID: 69307
	private int timeAcc = 500;

	// Token: 0x04010EBC RID: 69308
	private bool addBuffFlag;
}
