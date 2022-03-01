using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;

// Token: 0x02001CF8 RID: 7416
public class DailyChargeRaffleModel
{
	// Token: 0x060123AE RID: 74670 RVA: 0x0054E8B0 File Offset: 0x0054CCB0
	public void Clear()
	{
		this.Id = 0;
		this.SortIndex = 1;
		if (this.AwardItemDataList != null)
		{
			this.AwardItemDataList.Clear();
		}
		this.RaffleTableId = 0;
		this.ChargeItemId = -1;
		this.ChargePrice = 1;
		this.ChargeMallType = ChargeMallType.DayChargeWelfare;
		this.RaffleTicketType = DrawPrizeTable.eRaffleTicketType.RaffleTicketType_None;
		this.Status = TaskStatus.TASK_INIT;
		this.accLimitChargeNum = 0;
		this.accLimitChargeMax = 0;
	}

	// Token: 0x0400BD9A RID: 48538
	public int Id;

	// Token: 0x0400BD9B RID: 48539
	public int SortIndex = 1;

	// Token: 0x0400BD9C RID: 48540
	public List<ItemSimpleData> AwardItemDataList = new List<ItemSimpleData>();

	// Token: 0x0400BD9D RID: 48541
	public int RaffleTableId;

	// Token: 0x0400BD9E RID: 48542
	public DrawPrizeTable.eRaffleTicketType RaffleTicketType;

	// Token: 0x0400BD9F RID: 48543
	public int ChargeItemId;

	// Token: 0x0400BDA0 RID: 48544
	public int ChargePrice;

	// Token: 0x0400BDA1 RID: 48545
	public ChargeMallType ChargeMallType = ChargeMallType.DayChargeWelfare;

	// Token: 0x0400BDA2 RID: 48546
	public TaskStatus Status;

	// Token: 0x0400BDA3 RID: 48547
	public int accLimitChargeNum;

	// Token: 0x0400BDA4 RID: 48548
	public int accLimitChargeMax;
}
