using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001831 RID: 6193
	public class CommonRewardActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3B5 RID: 62389 RVA: 0x0041D794 File Offset: 0x0041BB94
		public override void Init(uint activityId)
		{
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (this.mData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.mData, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F3B6 RID: 62390 RVA: 0x0041D7E3 File Offset: 0x0041BBE3
		public override void Show(Transform root)
		{
			base.Show(root);
			if (this.mData.parm == 2U)
			{
				this.mCheckComponent.Checked(this);
			}
		}

		// Token: 0x0600F3B7 RID: 62391 RVA: 0x0041D809 File Offset: 0x0041BC09
		public override bool IsHaveRedPoint()
		{
			if (this.mData.parm == 2U)
			{
				return !this.mCheckComponent.IsChecked();
			}
			return base.IsHaveRedPoint();
		}

		// Token: 0x0600F3B8 RID: 62392 RVA: 0x0041D831 File Offset: 0x0041BC31
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CommonRewardActivity";
		}

		// Token: 0x0600F3B9 RID: 62393 RVA: 0x0041D838 File Offset: 0x0041BC38
		protected override string _GetItemPrefabPath()
		{
			string result = string.Empty;
			CommonRewardItemType parm = (CommonRewardItemType)this.mData.parm;
			if (parm != CommonRewardItemType.EveryChanllenge)
			{
				if (parm != CommonRewardItemType.EquipmentDelivery)
				{
					result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/EveryChallengeItem";
				}
				else
				{
					result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/EquipmentDeliveryItem";
				}
			}
			else
			{
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/EveryChallengeItem";
			}
			return result;
		}

		// Token: 0x040095E3 RID: 38371
		private OpActivityData mData;
	}
}
