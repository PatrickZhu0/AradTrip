using System;
using System.Collections.Generic;

// Token: 0x0200427E RID: 17022
public class Mechanism1052 : BeMechanism
{
	// Token: 0x060178DB RID: 96475 RVA: 0x0073FA71 File Offset: 0x0073DE71
	public Mechanism1052(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178DC RID: 96476 RVA: 0x0073FA7B File Offset: 0x0073DE7B
	public override void OnInit()
	{
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060178DD RID: 96477 RVA: 0x0073FAA8 File Offset: 0x0073DEA8
	public override void OnStart()
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		if (allPlayers.Count < 2)
		{
			return;
		}
		for (int i = 0; i < allPlayers.Count; i++)
		{
			base.owner.buffController.TryAddBuff(this.buffId, -1, 1);
		}
	}

	// Token: 0x04010ECC RID: 69324
	private int buffId;
}
