using System;
using System.Collections.Generic;

// Token: 0x020043BC RID: 17340
public class Mechanism2127 : BeMechanism
{
	// Token: 0x060180C8 RID: 98504 RVA: 0x00777C27 File Offset: 0x00776027
	public Mechanism2127(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180C9 RID: 98505 RVA: 0x00777C3C File Offset: 0x0077603C
	public override void OnInit()
	{
		int valueALength = this.data.ValueALength;
		for (int i = 0; i < valueALength; i++)
		{
			this.buffList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x060180CA RID: 98506 RVA: 0x00777C94 File Offset: 0x00776094
	public override void OnStart()
	{
		this.AddRandomBuff();
	}

	// Token: 0x060180CB RID: 98507 RVA: 0x00777C9C File Offset: 0x0077609C
	protected void AddRandomBuff()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null || allPlayers.Count > this.buffList.Count)
		{
			return;
		}
		int num = this.buffList.Count;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			int index = base.FrameRandom.InRange(0, num);
			int buffInfoID = this.buffList[index];
			allPlayers[i].playerActor.buffController.TryAddBuff(buffInfoID, null, false, base.owner, 0);
			this.buffList[index] = this.buffList[num - 1];
			num--;
		}
	}

	// Token: 0x060180CC RID: 98508 RVA: 0x00777D5B File Offset: 0x0077615B
	public override void OnFinish()
	{
		this.buffList.Clear();
	}

	// Token: 0x04011547 RID: 70983
	private List<int> buffList = new List<int>();
}
