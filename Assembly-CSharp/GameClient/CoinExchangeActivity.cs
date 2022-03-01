using System;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200182F RID: 6191
	public sealed class CoinExchangeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3AC RID: 62380 RVA: 0x0041D5B3 File Offset: 0x0041B9B3
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F3AD RID: 62381 RVA: 0x0041D5D7 File Offset: 0x0041B9D7
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F3AE RID: 62382 RVA: 0x0041D5FA File Offset: 0x0041B9FA
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F3AF RID: 62383 RVA: 0x0041D610 File Offset: 0x0041BA10
		public override bool IsHaveRedPoint()
		{
			bool flag = false;
			if (this.mDataModel.TaskDatas == null || this.mDataModel.State != OpActivityState.OAS_IN)
			{
				flag = false;
			}
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
				{
					flag = true;
				}
			}
			return flag && !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F3B0 RID: 62384 RVA: 0x0041D697 File Offset: 0x0041BA97
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CoinExchangeActivity";
		}

		// Token: 0x0600F3B1 RID: 62385 RVA: 0x0041D69E File Offset: 0x0041BA9E
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/CoinExchangeItem";
		}

		// Token: 0x0600F3B2 RID: 62386 RVA: 0x0041D6A5 File Offset: 0x0041BAA5
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F3B3 RID: 62387 RVA: 0x0041D6C4 File Offset: 0x0041BAC4
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
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_cannot_exchange_tips2"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					break;
				}
			}
		}
	}
}
