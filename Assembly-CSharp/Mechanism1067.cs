using System;
using ProtoTable;

// Token: 0x0200428C RID: 17036
public class Mechanism1067 : BeMechanism
{
	// Token: 0x06017923 RID: 96547 RVA: 0x00741656 File Offset: 0x0073FA56
	public Mechanism1067(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017924 RID: 96548 RVA: 0x00741674 File Offset: 0x0073FA74
	public override void OnInit()
	{
		this.mDungeonType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.percent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017925 RID: 96549 RVA: 0x007416DC File Offset: 0x0073FADC
	public override void OnStart()
	{
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null && base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager() != null && base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().table != null && base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().table.SubType == (DungeonTable.eSubType)this.mDungeonType)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args)
			{
				int[] array = (int[])args[0];
				array[0] += array[0] * this.percent;
			});
		}
	}

	// Token: 0x04010EFA RID: 69370
	private int mDungeonType = -1;

	// Token: 0x04010EFB RID: 69371
	private VFactor percent = VFactor.zero;
}
