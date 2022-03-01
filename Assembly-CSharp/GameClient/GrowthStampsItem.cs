using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B7E RID: 7038
	public class GrowthStampsItem : MonoBehaviour
	{
		// Token: 0x06011435 RID: 70709 RVA: 0x004FAA5C File Offset: 0x004F8E5C
		public void OnItemVisiable(ItemData itemData, UnityAction<ItemData> OnToggleClick)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			this.mComItem.Setup(itemData, null);
			if (this.mName != null)
			{
				this.mName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.mToggle != null)
			{
				this.mToggle.onValueChanged.RemoveAllListeners();
				this.mToggle.onValueChanged.AddListener(delegate(bool value)
				{
					if (value)
					{
						OnToggleClick.Invoke(itemData);
					}
					this.mCheckMark.CustomActive(value);
				});
			}
		}

		// Token: 0x06011436 RID: 70710 RVA: 0x004FAB2E File Offset: 0x004F8F2E
		public void ItemChangeDisplay()
		{
			this.mCheckMark.CustomActive(false);
		}

		// Token: 0x06011437 RID: 70711 RVA: 0x004FAB3C File Offset: 0x004F8F3C
		private void OnDestroy()
		{
			this.mComItem = null;
		}

		// Token: 0x0400B268 RID: 45672
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B269 RID: 45673
		[SerializeField]
		private Text mName;

		// Token: 0x0400B26A RID: 45674
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x0400B26B RID: 45675
		[SerializeField]
		private GameObject mCheckMark;

		// Token: 0x0400B26C RID: 45676
		private ComItem mComItem;
	}
}
