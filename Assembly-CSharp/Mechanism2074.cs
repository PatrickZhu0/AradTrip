using System;
using GameClient;

// Token: 0x02004383 RID: 17283
public class Mechanism2074 : BeMechanism
{
	// Token: 0x06017F6F RID: 98159 RVA: 0x0076C955 File Offset: 0x0076AD55
	public Mechanism2074(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F70 RID: 98160 RVA: 0x0076C95F File Offset: 0x0076AD5F
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06017F71 RID: 98161 RVA: 0x0076C968 File Offset: 0x0076AD68
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeBattle == null)
		{
			return;
		}
		TreasureMapBattle treasureMapBattle = base.owner.CurrentBeBattle as TreasureMapBattle;
		if (treasureMapBattle == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onDead));
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			treasureMapBattle.AddRegionIdLibary(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			treasureMapBattle.AddReduceIdLibary(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
	}

	// Token: 0x06017F72 RID: 98162 RVA: 0x0076CA60 File Offset: 0x0076AE60
	private void onDead(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null)
		{
			return;
		}
		TreasureMapBattle treasureMapBattle = base.owner.CurrentBeBattle as TreasureMapBattle;
		if (treasureMapBattle == null)
		{
			return;
		}
		treasureMapBattle.GenerateRegion(base.owner.GetPosition());
	}
}
