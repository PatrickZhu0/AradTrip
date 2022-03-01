using System;

// Token: 0x02004295 RID: 17045
public class Mechanism1075 : BeMechanism
{
	// Token: 0x0601794F RID: 96591 RVA: 0x00742E4E File Offset: 0x0074124E
	public Mechanism1075(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017950 RID: 96592 RVA: 0x00742E58 File Offset: 0x00741258
	public override void OnInit()
	{
		base.OnInit();
		this.addBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.removeBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017951 RID: 96593 RVA: 0x00742EBB File Offset: 0x007412BB
	public override void OnStart()
	{
		base.OnStart();
		this.ChangeBuff();
	}

	// Token: 0x06017952 RID: 96594 RVA: 0x00742ECC File Offset: 0x007412CC
	protected void ChangeBuff()
	{
		int buffCountByID = base.owner.buffController.GetBuffCountByID(this.removeBuffId);
		base.owner.buffController.RemoveBuff(this.removeBuffId, 1, 0);
		if (buffCountByID <= 1)
		{
			base.owner.buffController.TryAddBuff(this.addBuffId, -1, this.level);
		}
	}

	// Token: 0x04010F1F RID: 69407
	protected int addBuffId;

	// Token: 0x04010F20 RID: 69408
	protected int removeBuffId;
}
