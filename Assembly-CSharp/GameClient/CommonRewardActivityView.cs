using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001885 RID: 6277
	public class CommonRewardActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5CC RID: 62924 RVA: 0x004251C0 File Offset: 0x004235C0
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			if (this.mHelpAssistant != null)
			{
				CommonRewardItemType param = (CommonRewardItemType)model.Param;
				if (param != CommonRewardItemType.EveryChanllenge)
				{
					if (param == CommonRewardItemType.EquipmentDelivery)
					{
						this.mHelpAssistant.eType = HelpFrame.HelpType.HT_EQUIPMENTDELIVERYACTIVITY;
						this.mHelpAssistant.gameObject.transform.localPosition = new Vector3(530f, 164f, 0f);
					}
				}
				else
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_FULLLEVELSPRINTACTIVITY;
					this.mHelpAssistant.gameObject.transform.localPosition = new Vector3(-209f, 266f, 0f);
				}
			}
			if (this.mBg != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBg, model.LogoPath, true);
			}
			this.mTime.SafeSetText(string.Format("{0}~{1}", Function._TransTimeStampToStr(model.StartTime), Function._TransTimeStampToStr(model.EndTime)));
			this.mRule.SafeSetText(model.RuleDesc);
			this._InitItems(model);
		}

		// Token: 0x040096C3 RID: 38595
		[SerializeField]
		private Text mTime;

		// Token: 0x040096C4 RID: 38596
		[SerializeField]
		private Text mRule;

		// Token: 0x040096C5 RID: 38597
		[SerializeField]
		private Image mBg;

		// Token: 0x040096C6 RID: 38598
		[SerializeField]
		private HelpAssistant mHelpAssistant;
	}
}
