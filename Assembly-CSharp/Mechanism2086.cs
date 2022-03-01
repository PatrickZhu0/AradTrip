using System;
using GameClient;

// Token: 0x0200438F RID: 17295
public class Mechanism2086 : BeMechanism
{
	// Token: 0x06017FAE RID: 98222 RVA: 0x0076DFDE File Offset: 0x0076C3DE
	public Mechanism2086(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017FAF RID: 98223 RVA: 0x0076DFE8 File Offset: 0x0076C3E8
	public override void OnInit()
	{
		this.buffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.changeRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017FB0 RID: 98224 RVA: 0x0076E045 File Offset: 0x0076C445
	public override void OnStart()
	{
		this.AddTriggerBuff();
	}

	// Token: 0x06017FB1 RID: 98225 RVA: 0x0076E04D File Offset: 0x0076C44D
	public override void OnFinish()
	{
		this.RemoveTriggerBuff();
	}

	// Token: 0x06017FB2 RID: 98226 RVA: 0x0076E058 File Offset: 0x0076C458
	private bool IsRightDungeonType()
	{
		if (base.owner != null)
		{
			BaseBattle currentBeBattle = base.owner.CurrentBeBattle;
			if (currentBeBattle != null && currentBeBattle.dungeonManager != null && currentBeBattle.dungeonManager.GetDungeonDataManager() != null)
			{
				return currentBeBattle.dungeonManager.GetDungeonDataManager().IsHardRaid;
			}
		}
		return false;
	}

	// Token: 0x06017FB3 RID: 98227 RVA: 0x0076E0B0 File Offset: 0x0076C4B0
	private void AddTriggerBuff()
	{
		if (base.owner != null)
		{
			BuffInfoData buffInfoData = new BuffInfoData(this.buffInfoId, 0, 0);
			if (this.IsRightDungeonType())
			{
				BuffInfoData buffInfoData2 = buffInfoData;
				buffInfoData2.prob += this.changeRate;
			}
			base.owner.buffController.AddTriggerBuff(buffInfoData);
		}
	}

	// Token: 0x06017FB4 RID: 98228 RVA: 0x0076E110 File Offset: 0x0076C510
	private void RemoveTriggerBuff()
	{
		if (base.owner != null)
		{
			base.owner.buffController.RemoveTriggerBuff(this.buffInfoId);
		}
	}

	// Token: 0x0401143B RID: 70715
	private int buffInfoId;

	// Token: 0x0401143C RID: 70716
	protected int changeRate;
}
