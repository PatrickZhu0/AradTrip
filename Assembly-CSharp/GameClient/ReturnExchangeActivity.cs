using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001861 RID: 6241
	public sealed class ReturnExchangeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4BD RID: 62653 RVA: 0x00420C6A File Offset: 0x0041F06A
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._UpdateItemCount));
		}

		// Token: 0x0600F4BE RID: 62654 RVA: 0x00420C8E File Offset: 0x0041F08E
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._UpdateItemCount));
		}

		// Token: 0x0600F4BF RID: 62655 RVA: 0x00420CB1 File Offset: 0x0041F0B1
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ReturnExchangeActivity";
		}

		// Token: 0x0600F4C0 RID: 62656 RVA: 0x00420CB8 File Offset: 0x0041F0B8
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ReturnExchangeItem";
		}

		// Token: 0x0600F4C1 RID: 62657 RVA: 0x00420CBF File Offset: 0x0041F0BF
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F4C2 RID: 62658 RVA: 0x00420CDD File Offset: 0x0041F0DD
		private void _UpdateItemCount(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F4C3 RID: 62659 RVA: 0x00420CFC File Offset: 0x0041F0FC
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			if (this.mDataModel == null || this.mDataModel.TaskDatas == null)
			{
				return;
			}
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if ((ulong)this.mDataModel.TaskDatas[i].DataId == (ulong)((long)taskId))
				{
					if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
					{
						base._OnItemClick(taskId, 0, 0UL);
					}
					else if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_UNFINISH)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_cannot_exchange_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					break;
				}
			}
		}
	}
}
