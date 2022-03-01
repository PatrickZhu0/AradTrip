using System;

// Token: 0x0200427C RID: 17020
public class Mechanism1050 : BeMechanism
{
	// Token: 0x060178D1 RID: 96465 RVA: 0x0073F69B File Offset: 0x0073DA9B
	public Mechanism1050(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178D2 RID: 96466 RVA: 0x0073F6A5 File Offset: 0x0073DAA5
	public override void OnInit()
	{
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060178D3 RID: 96467 RVA: 0x0073F6CF File Offset: 0x0073DACF
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onKill, new BeEventHandle.Del(this.OnKillMonster));
	}

	// Token: 0x060178D4 RID: 96468 RVA: 0x0073F6FC File Offset: 0x0073DAFC
	private void OnKillMonster(object[] args)
	{
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		base.owner.buffController.TryAddBuff(this.buffInfoId, null, false, null, 0);
	}

	// Token: 0x04010EC3 RID: 69315
	private int buffInfoId;
}
