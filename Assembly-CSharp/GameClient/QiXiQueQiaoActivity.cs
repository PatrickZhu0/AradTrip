using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200185E RID: 6238
	public sealed class QiXiQueQiaoActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4B0 RID: 62640 RVA: 0x00420A60 File Offset: 0x0041EE60
		public override void Init(uint activityId)
		{
			this.data = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			OpActivityTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<OpActivityTable>((int)activityId, string.Empty, string.Empty);
			if (this.data != null && tableItem != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.data, this._GetItemPrefabPath(), tableItem.BgPath, null, null);
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F4B1 RID: 62641 RVA: 0x00420ADF File Offset: 0x0041EEDF
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			this.data = null;
		}

		// Token: 0x0600F4B2 RID: 62642 RVA: 0x00420B0C File Offset: 0x0041EF0C
		protected override string _GetItemPrefabPath()
		{
			string result = string.Empty;
			switch (this.data.parm)
			{
			case 2U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ChristmasSnowmanItem";
				break;
			case 3U:
			case 4U:
			case 5U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/LanternFestivalItem";
				break;
			case 6U:
			case 7U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/QiXiQueQiaoItem";
				break;
			}
			return result;
		}

		// Token: 0x0600F4B3 RID: 62643 RVA: 0x00420B78 File Offset: 0x0041EF78
		protected override string _GetPrefabPath()
		{
			string result = string.Empty;
			switch (this.mDataModel.Param)
			{
			case 2U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ChristmasSnowmanActivity";
				break;
			case 3U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LanternFestivalActivity";
				break;
			case 4U:
			case 5U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/AprilFoolsDayActivity";
				break;
			case 6U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/QiXiQueQiaoActivity";
				break;
			case 7U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/QiXiQueQiaoActivity2";
				break;
			}
			return result;
		}

		// Token: 0x0600F4B4 RID: 62644 RVA: 0x00420BF9 File Offset: 0x0041EFF9
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x04009633 RID: 38451
		private OpActivityData data;
	}
}
