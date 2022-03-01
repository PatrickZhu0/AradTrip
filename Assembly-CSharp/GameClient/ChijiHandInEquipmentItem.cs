using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200110B RID: 4363
	public class ChijiHandInEquipmentItem : MonoBehaviour
	{
		// Token: 0x0600A553 RID: 42323 RVA: 0x00221AB0 File Offset: 0x0021FEB0
		public void OnItemVisiable(ItemData itemData, OnEquipItemClickDelegate onEquipItemClick)
		{
			this.mCurrent = itemData;
			this.mOnEquipItemClick = onEquipItemClick;
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = this.mCurrent;
			if (ChijiHandInEquipmentItem.<>f__mg$cache0 == null)
			{
				ChijiHandInEquipmentItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, ChijiHandInEquipmentItem.<>f__mg$cache0);
			this.mEquipName.text = this.mCurrent.GetColorName(string.Empty, false);
			bool bActive = ChijiHandInEquipmentView.mHandInEquipmentList.Contains(this.mCurrent.GUID);
			this.mCheckMarkRoot.CustomActive(bActive);
			this.mAddItemToggle.onValueChanged.RemoveAllListeners();
			this.mAddItemToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnAddItemTogClick));
		}

		// Token: 0x0600A554 RID: 42324 RVA: 0x00221B88 File Offset: 0x0021FF88
		private void OnAddItemTogClick(bool value)
		{
			if (value)
			{
				if (ChijiHandInEquipmentView.hasSelectNumber >= this.mMaxHandInNumber)
				{
					this.mAddItemToggle.isOn = false;
					return;
				}
				if (this.mOnEquipItemClick != null)
				{
					this.mOnEquipItemClick(this.mCurrent.GUID, true);
				}
			}
			else if (this.mOnEquipItemClick != null)
			{
				this.mOnEquipItemClick(this.mCurrent.GUID, false);
			}
			this.mCheckMarkRoot.CustomActive(value);
		}

		// Token: 0x0600A555 RID: 42325 RVA: 0x00221C0D File Offset: 0x0022000D
		private void OnDestroy()
		{
			this.mComItem = null;
			this.mCurrent = null;
			this.mOnEquipItemClick = null;
		}

		// Token: 0x04005C3E RID: 23614
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x04005C3F RID: 23615
		[SerializeField]
		private GameObject mCheckMarkRoot;

		// Token: 0x04005C40 RID: 23616
		[SerializeField]
		private Text mEquipName;

		// Token: 0x04005C41 RID: 23617
		[SerializeField]
		private Toggle mAddItemToggle;

		// Token: 0x04005C42 RID: 23618
		[SerializeField]
		private int mMaxHandInNumber = 5;

		// Token: 0x04005C43 RID: 23619
		private ComItem mComItem;

		// Token: 0x04005C44 RID: 23620
		private ItemData mCurrent;

		// Token: 0x04005C45 RID: 23621
		private OnEquipItemClickDelegate mOnEquipItemClick;

		// Token: 0x04005C46 RID: 23622
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
