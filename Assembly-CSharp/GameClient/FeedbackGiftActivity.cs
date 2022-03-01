using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001840 RID: 6208
	public sealed class FeedbackGiftActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3EB RID: 62443 RVA: 0x0041E20C File Offset: 0x0041C60C
		public override void Init(uint activityId)
		{
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (this.mData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.mData, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F3EC RID: 62444 RVA: 0x0041E25B File Offset: 0x0041C65B
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F3ED RID: 62445 RVA: 0x0041E264 File Offset: 0x0041C664
		protected override string _GetPrefabPath()
		{
			if (this.mData != null && this.mData.parm3.Length > 0)
			{
				int num = (int)this.mData.parm3[0];
				if (num == 1)
				{
					return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FeedbackGiftActivityNew";
				}
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FeedbackGiftActivity";
		}

		// Token: 0x0600F3EE RID: 62446 RVA: 0x0041E2B0 File Offset: 0x0041C6B0
		protected override string _GetItemPrefabPath()
		{
			if (this.mData != null && this.mData.parm3.Length > 0)
			{
				int num = (int)this.mData.parm3[0];
				if (num == 1)
				{
					return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/FeedbackGiftActivityNewItem";
				}
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/FeedbackGiftActivityItem";
		}

		// Token: 0x040095EB RID: 38379
		private OpActivityData mData;
	}
}
