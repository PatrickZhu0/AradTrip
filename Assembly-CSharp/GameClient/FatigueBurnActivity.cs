using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200183E RID: 6206
	public sealed class FatigueBurnActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3E1 RID: 62433 RVA: 0x0041DF80 File Offset: 0x0041C380
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FatigueBurnActivity";
		}

		// Token: 0x0600F3E2 RID: 62434 RVA: 0x0041DF87 File Offset: 0x0041C387
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/FatigueBurnItem";
		}

		// Token: 0x0600F3E3 RID: 62435 RVA: 0x0041DF90 File Offset: 0x0041C390
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			if (param == 0)
			{
				if (this.mDataModel != null && this.mDataModel.TaskDatas != null)
				{
					for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
					{
						ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mDataModel.TaskDatas[i];
						if ((ulong)limitTimeActivityTaskDataModel.DataId == (ulong)((long)taskId))
						{
							if (limitTimeActivityTaskDataModel.State != OpActTaskState.OATS_FINISHED)
							{
								List<uint> paramNums = limitTimeActivityTaskDataModel.ParamNums;
								if (paramNums != null && paramNums.Count > 2)
								{
									int id = (int)paramNums[0];
									ItemTable tableData = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
									int ordinaryItemCount = (int)paramNums[1];
									string name = tableData.Name;
									string msgContent = string.Format(TR.Value("activity_fatigue_burning_buy_text"), ordinaryItemCount, name);
									SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
									{
										CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
										costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(tableData.SubType);
										DataManager<ItemTipManager>.GetInstance().CloseAll();
										costInfo.nCount = ordinaryItemCount;
										DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
										{
											this.<_OnItemClick>__BaseCallProxy0(taskId, param, 0UL);
										}, "common_money_cost", null);
									}, null, 0f, false);
								}
							}
							else
							{
								SystemNotifyManager.SystemNotify(9054, string.Empty);
							}
							break;
						}
					}
				}
			}
			else
			{
				base._OnItemClick(taskId, param, 0UL);
			}
		}
	}
}
