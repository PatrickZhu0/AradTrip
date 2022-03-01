using System;
using System.Collections.Generic;

// Token: 0x020043DF RID: 17375
public class Mechanism33 : BeMechanism
{
	// Token: 0x060181BE RID: 98750 RVA: 0x0077E748 File Offset: 0x0077CB48
	public Mechanism33(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181BF RID: 98751 RVA: 0x0077E760 File Offset: 0x0077CB60
	public override void OnInit()
	{
		this.m_CallNameBuff = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_Num = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x060181C0 RID: 98752 RVA: 0x0077E7BD File Offset: 0x0077CBBD
	public override void OnStart()
	{
		this.AddBuff();
	}

	// Token: 0x060181C1 RID: 98753 RVA: 0x0077E7C8 File Offset: 0x0077CBC8
	protected void AddBuff()
	{
		List<BeActor> list = new List<BeActor>();
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers.Count > this.m_Num)
		{
			for (int i = 0; i < this.m_Num; i++)
			{
				int num = base.FrameRandom.InRange(0, allPlayers.Count);
				if (num < allPlayers.Count)
				{
					list.Add(allPlayers[num].playerActor);
				}
			}
		}
		else
		{
			for (int j = 0; j < allPlayers.Count; j++)
			{
				list.Add(allPlayers[j].playerActor);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			BeActor beActor = list[k];
			beActor.buffController.TryAddBuff(this.m_CallNameBuff, null, false, null, 0);
		}
	}

	// Token: 0x04011621 RID: 71201
	protected int m_CallNameBuff;

	// Token: 0x04011622 RID: 71202
	protected int m_Num;

	// Token: 0x04011623 RID: 71203
	protected List<BattlePlayer> m_TargetList = new List<BattlePlayer>();
}
