using System;
using GameClient;
using ProtoTable;

// Token: 0x02004267 RID: 16999
public class Mechanism1030 : BeMechanism
{
	// Token: 0x0601785F RID: 96351 RVA: 0x0073CC3F File Offset: 0x0073B03F
	public Mechanism1030(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017860 RID: 96352 RVA: 0x0073CC4C File Offset: 0x0073B04C
	public override void OnInit()
	{
		base.OnInit();
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.itemID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.itemCnt = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017861 RID: 96353 RVA: 0x0073CCFF File Offset: 0x0073B0FF
	public override void OnStart()
	{
		base.OnStart();
		base.owner.delayCaller.DelayCall(100, delegate
		{
			this.timer = 0;
			this.DoCostItem();
		}, 0, 0, false);
	}

	// Token: 0x06017862 RID: 96354 RVA: 0x0073CD2C File Offset: 0x0073B12C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.time < 1000)
		{
			return;
		}
		this.timer += deltaTime;
		if (this.timer >= this.time)
		{
			this.DoCostItem();
			this.timer = 0;
		}
	}

	// Token: 0x06017863 RID: 96355 RVA: 0x0073CD80 File Offset: 0x0073B180
	private void DoCostItem()
	{
		if (base.owner.GetEntityData().GetCrystalNum() >= this.itemCnt)
		{
			base.owner.buffController.TryAddBuff(this.buffInfoID, null, false, null, 0);
			base.owner.GetEntityData().ModifyCrystalessNum(-this.itemCnt);
			base.owner.TriggerEvent(BeEventType.OnUseCrystal, null);
			if (base.owner.isLocalActor && !BattleMain.IsModeTrain(BattleMain.battleType) && !Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				BeUtility.UseItemInBattle(this.itemID, 0, this.itemCnt);
			}
		}
		else if (base.owner.isLocalActor)
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("strengthen_uncolor_not_enough"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}
	}

	// Token: 0x04010E73 RID: 69235
	private int itemID;

	// Token: 0x04010E74 RID: 69236
	private int time;

	// Token: 0x04010E75 RID: 69237
	private int buffInfoID;

	// Token: 0x04010E76 RID: 69238
	private int itemCnt;

	// Token: 0x04010E77 RID: 69239
	private int timer;
}
