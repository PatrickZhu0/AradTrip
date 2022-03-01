using System;
using GameClient;
using Protocol;

// Token: 0x02001927 RID: 6439
public class VanityCustomClearanceActivity : LimitTimeCommonActivity
{
	// Token: 0x0600FA8F RID: 64143 RVA: 0x00449E89 File Offset: 0x00448289
	public sealed override void Init(uint activityId)
	{
		base.Init(activityId);
		if (this.mDataModel != null)
		{
			this.mDataModel.SortTaskByState();
		}
		this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
	}

	// Token: 0x0600FA90 RID: 64144 RVA: 0x00449EB9 File Offset: 0x004482B9
	public override bool IsHaveRedPoint()
	{
		return base.IsHaveRedPoint();
	}

	// Token: 0x0600FA91 RID: 64145 RVA: 0x00449EC4 File Offset: 0x004482C4
	protected sealed override string _GetPrefabPath()
	{
		if (this.mData != null)
		{
			string prefabPath = this.mData.prefabPath;
			if (!string.IsNullOrEmpty(prefabPath))
			{
				return prefabPath;
			}
		}
		return "UIFlatten/Prefabs/OperateActivity/YiJie/Activities/VanityCustomClearanceActivity";
	}

	// Token: 0x0600FA92 RID: 64146 RVA: 0x00449EFA File Offset: 0x004482FA
	protected sealed override string _GetItemPrefabPath()
	{
		return "UIFlatten/Prefabs/OperateActivity/YiJie/Items/VanityDailyCustomClearanceRewardItem";
	}

	// Token: 0x04009C86 RID: 40070
	private OpActivityData mData;
}
