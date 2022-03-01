using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001903 RID: 6403
	public class QiXiQueQiaoItem : ActivityItemBase
	{
		// Token: 0x0600F97F RID: 63871 RVA: 0x004425C1 File Offset: 0x004409C1
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mEffect.CustomActive(false);
			if (data != null && data.State == OpActTaskState.OATS_FINISHED)
			{
				this.mEffect.CustomActive(true);
			}
		}

		// Token: 0x0600F980 RID: 63872 RVA: 0x004425ED File Offset: 0x004409ED
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItem != null)
			{
				ComItemManager.Destroy(this.mComItem);
				this.mComItem = null;
			}
		}

		// Token: 0x0600F981 RID: 63873 RVA: 0x00442618 File Offset: 0x00440A18
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null && data.AwardDataList != null && data.AwardDataList.Count >= 1)
			{
				this.mComItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
				if (itemData == null)
				{
					return;
				}
				itemData.Count = (int)data.AwardDataList[0].num;
				ComItem comItem = this.mComItem;
				ItemData item = itemData;
				if (QiXiQueQiaoItem.<>f__mg$cache0 == null)
				{
					QiXiQueQiaoItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, QiXiQueQiaoItem.<>f__mg$cache0);
				string str = string.Format("{0}*{1}", itemData.Name, itemData.Count);
				this.mNameDesTxt.SafeSetText(str);
			}
			if (data.DataId == 1445001U || data.DataId == 1445002U || data.DataId == 1445003U || data.DataId == 1445004U || data.DataId == 1445005U)
			{
				base.GetComponent<RectTransform>().SetAsFirstSibling();
			}
			this.mTextDescription.SafeSetText(data.Desc);
		}

		// Token: 0x04009B57 RID: 39767
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009B58 RID: 39768
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009B59 RID: 39769
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(60f, 60f);

		// Token: 0x04009B5A RID: 39770
		[SerializeField]
		private GameObject mEffect;

		// Token: 0x04009B5B RID: 39771
		[SerializeField]
		private Text mNameDesTxt;

		// Token: 0x04009B5C RID: 39772
		private ComItem mComItem;

		// Token: 0x04009B5D RID: 39773
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
