using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200182E RID: 6190
	public sealed class ChangeFashionSpecialExchangeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3A6 RID: 62374 RVA: 0x0041D3A8 File Offset: 0x0041B7A8
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F3A7 RID: 62375 RVA: 0x0041D3B1 File Offset: 0x0041B7B1
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F3A8 RID: 62376 RVA: 0x0041D3B9 File Offset: 0x0041B7B9
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ChangeFashionSpecialExchangeActivity";
		}

		// Token: 0x0600F3A9 RID: 62377 RVA: 0x0041D3C0 File Offset: 0x0041B7C0
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ChangeFashionSpecialExchangeItem";
		}

		// Token: 0x0600F3AA RID: 62378 RVA: 0x0041D3C8 File Offset: 0x0041B7C8
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			if (this.mDataModel == null || this.mDataModel.TaskDatas == null)
			{
				return;
			}
			if (this.mDataModel.State == OpActivityState.OAS_PREPARE)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_havenot_open_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (param2 == 0UL)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("change_fashion_activity_havenot_fashion_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if ((ulong)this.mDataModel.TaskDatas[i].DataId == (ulong)((long)taskId))
				{
					if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(param2);
						if (item == null)
						{
							return;
						}
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem == null)
						{
							return;
						}
						if (tableItem.SuitID > 100107)
						{
							string msgContent = TR.Value("change_fashion_activity_fashion_expensive_tips");
							SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
							{
								DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this.mDataModel.Id, (uint)taskId, param2);
							}, null, 0f, false);
						}
						else
						{
							DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this.mDataModel.Id, (uint)taskId, param2);
						}
					}
					else if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_UNFINISH)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("change_special_fashion_activity_cannot_exchange_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					break;
				}
			}
		}
	}
}
