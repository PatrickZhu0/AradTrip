using System;
using GameClient;

// Token: 0x02004382 RID: 17282
public class Mechanism2073 : BeMechanism
{
	// Token: 0x06017F6D RID: 98157 RVA: 0x0076C8DF File Offset: 0x0076ACDF
	public Mechanism2073(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F6E RID: 98158 RVA: 0x0076C8EC File Offset: 0x0076ACEC
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner != null)
		{
			base.owner.m_iEntityLifeState = 4;
			base.owner.m_iRemoveTime = 0;
			if (base.owner.CurrentBeBattle != null)
			{
				TreasureMapBattle treasureMapBattle = base.owner.CurrentBeBattle as TreasureMapBattle;
				if (treasureMapBattle != null)
				{
					treasureMapBattle.OnBossFleeAway(base.owner);
				}
			}
		}
	}
}
