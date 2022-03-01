using System;
using GameClient;

// Token: 0x0200438B RID: 17291
public class Mechanism2083 : BeMechanism
{
	// Token: 0x06017F9D RID: 98205 RVA: 0x0076D90C File Offset: 0x0076BD0C
	public Mechanism2083(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F9E RID: 98206 RVA: 0x0076D916 File Offset: 0x0076BD16
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06017F9F RID: 98207 RVA: 0x0076D91E File Offset: 0x0076BD1E
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onDead));
	}

	// Token: 0x06017FA0 RID: 98208 RVA: 0x0076D948 File Offset: 0x0076BD48
	private void onDead(object[] args)
	{
		if (this.data.ValueA.Count <= 0)
		{
			return;
		}
		if (base.owner == null || base.owner.CurrentBeBattle == null)
		{
			return;
		}
		TreasureMapBattle treasureMapBattle = base.owner.CurrentBeBattle as TreasureMapBattle;
		if (treasureMapBattle == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		int index = base.FrameRandom.InRange(0, this.data.ValueA.Count);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[index], this.level, true);
		treasureMapBattle.AddRegionInfo(valueFromUnionCell, base.owner.GetPosition());
	}
}
