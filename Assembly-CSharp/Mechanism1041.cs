using System;
using System.Collections.Generic;

// Token: 0x02004274 RID: 17012
public class Mechanism1041 : BeMechanism
{
	// Token: 0x060178AF RID: 96431 RVA: 0x0073E96A File Offset: 0x0073CD6A
	public Mechanism1041(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178B0 RID: 96432 RVA: 0x0073E980 File Offset: 0x0073CD80
	public override void OnInit()
	{
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.fHpPercent = new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_1000);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				this.buffInfoIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
	}

	// Token: 0x060178B1 RID: 96433 RVA: 0x0073EA27 File Offset: 0x0073CE27
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, new BeEventHandle.Del(this.onHpChange));
	}

	// Token: 0x060178B2 RID: 96434 RVA: 0x0073EA50 File Offset: 0x0073CE50
	private void onHpChange(object[] args)
	{
		if (base.owner.IsDead())
		{
			return;
		}
		if (base.owner.attribute.GetHPRate() < this.fHpPercent)
		{
			for (int i = 0; i < this.buffInfoIds.Count; i++)
			{
				base.owner.buffController.TryAddBuff(this.buffInfoIds[i], null, false, null, 0);
			}
		}
	}

	// Token: 0x04010EAC RID: 69292
	private VFactor fHpPercent;

	// Token: 0x04010EAD RID: 69293
	private List<int> buffInfoIds = new List<int>();
}
