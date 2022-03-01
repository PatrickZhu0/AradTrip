using System;
using System.Collections.Generic;

// Token: 0x02004276 RID: 17014
public class Mechanism1043 : BeMechanism
{
	// Token: 0x060178B7 RID: 96439 RVA: 0x0073EBF9 File Offset: 0x0073CFF9
	public Mechanism1043(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178B8 RID: 96440 RVA: 0x0073EC03 File Offset: 0x0073D003
	public override void OnInit()
	{
		base.OnInit();
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060178B9 RID: 96441 RVA: 0x0073EC33 File Offset: 0x0073D033
	public override void OnStart()
	{
		base.OnStart();
		this.SelectPlayerAddBuff();
	}

	// Token: 0x060178BA RID: 96442 RVA: 0x0073EC44 File Offset: 0x0073D044
	private void SelectPlayerAddBuff()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers != null)
		{
			int index = base.FrameRandom.InRange(0, allPlayers.Count);
			if (allPlayers[index] != null && allPlayers[index].playerActor != null)
			{
				allPlayers[index].playerActor.buffController.TryAddBuff(this.buffInfoId, null, false, null, 0);
			}
		}
	}

	// Token: 0x04010EB0 RID: 69296
	private int buffInfoId;
}
