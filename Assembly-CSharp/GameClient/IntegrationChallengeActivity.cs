using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001848 RID: 6216
	public class IntegrationChallengeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F414 RID: 62484 RVA: 0x0041ECDC File Offset: 0x0041D0DC
		public override void Init(uint activityId)
		{
			this.opActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (this.opActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(this.opActivityData, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F415 RID: 62485 RVA: 0x0041ED2B File Offset: 0x0041D12B
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F416 RID: 62486 RVA: 0x0041ED3B File Offset: 0x0041D13B
		public override void Show(Transform root)
		{
			this.mCheckComponent.Checked(this);
			base.Show(root);
		}

		// Token: 0x0600F417 RID: 62487 RVA: 0x0041ED50 File Offset: 0x0041D150
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/IntegrationChallengeActivity";
			if (this.opActivityData != null && !string.IsNullOrEmpty(this.opActivityData.prefabPath))
			{
				return this.opActivityData.prefabPath;
			}
			return result;
		}

		// Token: 0x0600F418 RID: 62488 RVA: 0x0041ED94 File Offset: 0x0041D194
		protected override string _GetItemPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/IntegrationChallengeItem";
			if (this.opActivityData != null && this.opActivityData.parm2.Length > 0 && this.opActivityData.parm2[0] == 1U)
			{
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/SummerMedalItem";
			}
			return result;
		}

		// Token: 0x04009606 RID: 38406
		private OpActivityData opActivityData;
	}
}
