using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A96 RID: 6806
	public class WeekSignInPreviewAwardItem : MonoBehaviour
	{
		// Token: 0x06010B58 RID: 68440 RVA: 0x004BD331 File Offset: 0x004BB731
		private void OnDestroy()
		{
			this._previewAwardItemDataModel = null;
			this._commonNewItem = null;
		}

		// Token: 0x06010B59 RID: 68441 RVA: 0x004BD344 File Offset: 0x004BB744
		public void InitItem(WeekSignInPreviewAwardDataModel previewAwardItemDataModel)
		{
			this._previewAwardItemDataModel = previewAwardItemDataModel;
			if (this._previewAwardItemDataModel == null)
			{
				Logger.LogErrorFormat("WeekSingInPreviewAwardItem itemDataModel is null", new object[0]);
				return;
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = this._previewAwardItemDataModel.ItemId,
				ItemCount = this._previewAwardItemDataModel.ItemNumber
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
			if (this.specialFlag != null)
			{
				this.specialFlag.CustomActive(this._previewAwardItemDataModel.IsSpecialAward);
			}
		}

		// Token: 0x0400AADB RID: 43739
		private WeekSignInPreviewAwardDataModel _previewAwardItemDataModel;

		// Token: 0x0400AADC RID: 43740
		private CommonNewItem _commonNewItem;

		// Token: 0x0400AADD RID: 43741
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400AADE RID: 43742
		[SerializeField]
		private GameObject specialFlag;
	}
}
