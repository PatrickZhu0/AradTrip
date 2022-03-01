using System;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200182D RID: 6189
	public sealed class ChangeFashionExchangeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F39D RID: 62365 RVA: 0x0041D1C0 File Offset: 0x0041B5C0
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F39E RID: 62366 RVA: 0x0041D1E4 File Offset: 0x0041B5E4
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F39F RID: 62367 RVA: 0x0041D208 File Offset: 0x0041B608
		public override void Show(Transform root)
		{
			base.Show(root);
			ChangeFashionExchangeView changeFashionExchangeView = this.mView as ChangeFashionExchangeView;
			if (changeFashionExchangeView != null)
			{
				changeFashionExchangeView.setGetScoreCallBack(new ChangeFashionExchangeView.GetScoreCallBack(this.GetScore));
			}
		}

		// Token: 0x0600F3A0 RID: 62368 RVA: 0x0041D248 File Offset: 0x0041B648
		private void GetScore(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemComeLink.OnLink(id, 0, false, null, false, tableItem.bNeedJump > 0, false, null, string.Empty);
			}
		}

		// Token: 0x0600F3A1 RID: 62369 RVA: 0x0041D28B File Offset: 0x0041B68B
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ChangeFashionExchangeActivity";
		}

		// Token: 0x0600F3A2 RID: 62370 RVA: 0x0041D292 File Offset: 0x0041B692
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ChangeFashionExchangeItem";
		}

		// Token: 0x0600F3A3 RID: 62371 RVA: 0x0041D299 File Offset: 0x0041B699
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F3A4 RID: 62372 RVA: 0x0041D2B8 File Offset: 0x0041B6B8
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
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("change_fashion_activity_cannot_exchange_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					break;
				}
			}
		}
	}
}
