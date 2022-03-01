using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001838 RID: 6200
	public sealed class DailyRewardActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3CC RID: 62412 RVA: 0x0041D953 File Offset: 0x0041BD53
		public override void Init(uint activityId)
		{
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (this.mData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.mData, this._GetItemPrefabPath(), null, null, null);
			}
		}

		// Token: 0x0600F3CD RID: 62413 RVA: 0x0041D98C File Offset: 0x0041BD8C
		protected sealed override string _GetItemPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/DailyRewardItem";
			if (this.mData != null && this.mData.parm2 != null && this.mData.parm2.Length >= 1)
			{
				uint num = this.mData.parm2[0];
				if (num != 1U)
				{
					if (num == 2U)
					{
						result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/LanternFestivalWorkItem";
					}
				}
				else
				{
					result = "UIFlatten/Prefabs/OperateActivity/Anniversary/Item/AnniversaryLoginItem";
				}
			}
			return result;
		}

		// Token: 0x0600F3CE RID: 62414 RVA: 0x0041DA08 File Offset: 0x0041BE08
		protected sealed override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/DailyRewardActivityNew";
			if (this.mData != null && !string.IsNullOrEmpty(this.mData.prefabPath))
			{
				return this.mData.prefabPath;
			}
			if (this.mData != null && this.mData.parm2 != null && this.mData.parm2.Length >= 1)
			{
				uint num = this.mData.parm2[0];
				if (num != 1U)
				{
					if (num != 2U)
					{
						if (num == 3U)
						{
							result = "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/TuanBenSupportActivity";
						}
					}
					else
					{
						result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LanternFestivalWorkActivity";
					}
				}
				else
				{
					result = "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryLoginActivity";
				}
			}
			return result;
		}

		// Token: 0x040095E9 RID: 38377
		private OpActivityData mData;
	}
}
