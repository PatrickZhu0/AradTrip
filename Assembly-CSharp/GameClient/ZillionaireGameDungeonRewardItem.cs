using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001935 RID: 6453
	public class ZillionaireGameDungeonRewardItem : MonoBehaviour
	{
		// Token: 0x0600FAF3 RID: 64243 RVA: 0x0044C050 File Offset: 0x0044A450
		public void OnItemVisiable(ItemSimpleData itemSimpleData)
		{
			if (itemSimpleData == null)
			{
				return;
			}
			if (this.desc != null)
			{
				this.desc.text = this.SwitchRatingDesc(itemSimpleData.level);
			}
			CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.itemParent);
			if (commonNewItem != null)
			{
				commonNewItem.InitItem(itemSimpleData.ItemID, itemSimpleData.Count);
			}
		}

		// Token: 0x0600FAF4 RID: 64244 RVA: 0x0044C0B8 File Offset: 0x0044A4B8
		private string SwitchRatingDesc(int level)
		{
			string result = string.Empty;
			switch (level)
			{
			case 1:
				result = string.Format(this.content, "SSS");
				break;
			case 2:
				result = string.Format(this.content, "SS");
				break;
			case 3:
				result = string.Format(this.content, "S");
				break;
			default:
				result = "无评分奖励";
				break;
			}
			return result;
		}

		// Token: 0x04009CCC RID: 40140
		[SerializeField]
		private Text desc;

		// Token: 0x04009CCD RID: 40141
		[SerializeField]
		private GameObject itemParent;

		// Token: 0x04009CCE RID: 40142
		[SerializeField]
		private string content = "评分{0}奖励";
	}
}
