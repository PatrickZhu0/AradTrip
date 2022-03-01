using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014D3 RID: 5331
	public class ChallengeTeamDuplicationDropItem : MonoBehaviour
	{
		// Token: 0x0600CEBC RID: 52924 RVA: 0x0032FE5C File Offset: 0x0032E25C
		private void OnDestroy()
		{
			this._commonNewItem = null;
		}

		// Token: 0x0600CEBD RID: 52925 RVA: 0x0032FE68 File Offset: 0x0032E268
		public void InitItem(int itemId, int itemNumber = 1)
		{
			if (itemId <= 0 || itemNumber <= 0)
			{
				Logger.LogErrorFormat("ChallengeTeamDuplicationDropItem Data is invalid and itemId is {0}, itemNumber is {1}", new object[]
				{
					itemId,
					itemNumber
				});
				return;
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = itemId,
				ItemCount = itemNumber
			};
			if (this.itemRoot != null)
			{
				this._commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (this._commonNewItem == null)
				{
					this._commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
			}
			if (this._commonNewItem != null)
			{
				this._commonNewItem.InitItem(dataModel);
			}
			if (this._commonNewItem != null)
			{
				this._commonNewItem.SetItemCountFontSize(32);
				this._commonNewItem.SetItemLevelFontSize(32);
			}
		}

		// Token: 0x040078C7 RID: 30919
		private CommonNewItem _commonNewItem;

		// Token: 0x040078C8 RID: 30920
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;
	}
}
