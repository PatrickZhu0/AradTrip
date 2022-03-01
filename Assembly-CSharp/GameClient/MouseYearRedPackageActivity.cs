using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001858 RID: 6232
	public class MouseYearRedPackageActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F49B RID: 62619 RVA: 0x00420904 File Offset: 0x0041ED04
		public override void Init(uint activityId)
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null);
			}
		}

		// Token: 0x0600F49C RID: 62620 RVA: 0x00420938 File Offset: 0x0041ED38
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/MouseYearRedPackageActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}

		// Token: 0x0600F49D RID: 62621 RVA: 0x0042097A File Offset: 0x0041ED7A
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/MouseYearRedPackageItem";
		}
	}
}
