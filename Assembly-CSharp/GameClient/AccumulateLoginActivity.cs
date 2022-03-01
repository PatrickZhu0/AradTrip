using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001823 RID: 6179
	public sealed class AccumulateLoginActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F354 RID: 62292 RVA: 0x0041C608 File Offset: 0x0041AA08
		public override void Init(uint activityId)
		{
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (this.mData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.mData, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F355 RID: 62293 RVA: 0x0041C657 File Offset: 0x0041AA57
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F356 RID: 62294 RVA: 0x0041C65F File Offset: 0x0041AA5F
		protected override string _GetPrefabPath()
		{
			if (this.mData != null && this.mData.parm == 1U)
			{
				return "UIFlatten/Prefabs/OperateActivity/AccumulateLoginActivityNew/AccumulateLoginActivityNew";
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/AccumulateLoginActivity";
		}

		// Token: 0x0600F357 RID: 62295 RVA: 0x0041C688 File Offset: 0x0041AA88
		protected override string _GetItemPrefabPath()
		{
			if (this.mData != null && this.mData.parm == 1U)
			{
				return "UIFlatten/Prefabs/OperateActivity/AccumulateLoginActivityNew/AccumulateLoginNewItem";
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/AccumulateLoginItem";
		}

		// Token: 0x040095D3 RID: 38355
		private OpActivityData mData;
	}
}
