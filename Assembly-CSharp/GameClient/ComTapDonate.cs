using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE9 RID: 7145
	internal class ComTapDonate : MonoBehaviour
	{
		// Token: 0x17001DB5 RID: 7605
		// (get) Token: 0x0601182D RID: 71725 RVA: 0x0051825E File Offset: 0x0051665E
		public ItemData Value
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x0601182E RID: 71726 RVA: 0x00518266 File Offset: 0x00516666
		public static void Clear()
		{
			ComTapDonate.ms_selectItems.Clear();
		}

		// Token: 0x17001DB6 RID: 7606
		// (get) Token: 0x0601182F RID: 71727 RVA: 0x00518272 File Offset: 0x00516672
		public static List<ItemData> SelectedItems
		{
			get
			{
				return ComTapDonate.ms_selectItems;
			}
		}

		// Token: 0x06011830 RID: 71728 RVA: 0x00518279 File Offset: 0x00516679
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDonateSelecteItemChanged, new ClientEventSystem.UIEventHandler(this._OnDonateSelecteItemChanged));
		}

		// Token: 0x06011831 RID: 71729 RVA: 0x00518296 File Offset: 0x00516696
		private void _OnDonateSelecteItemChanged(UIEvent uiEvent)
		{
			this._UpdateCheckMark();
		}

		// Token: 0x06011832 RID: 71730 RVA: 0x005182A0 File Offset: 0x005166A0
		private void _UpdateCheckMark()
		{
			if (ComTapDonate.ms_selectItems == null)
			{
				return;
			}
			ItemData itemData = ComTapDonate.ms_selectItems.Find((ItemData x) => x != null && this.Value != null && x.GUID == this.Value.GUID);
			this.goCheckMark.CustomActive(null != itemData);
		}

		// Token: 0x06011833 RID: 71731 RVA: 0x005182E4 File Offset: 0x005166E4
		public static void DelecteAllItems()
		{
			while (ComTapDonate.ms_selectItems.Count > 0)
			{
				ItemData itemData = ComTapDonate.ms_selectItems[0];
				ComTapDonate.ms_selectItems.RemoveAt(0);
				if (itemData != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDonateSelecteItemChanged, null, null, null, null);
				}
			}
		}

		// Token: 0x06011834 RID: 71732 RVA: 0x00518338 File Offset: 0x00516738
		public static ulong[] GetSelectedItems()
		{
			List<ulong> list = ListPool<ulong>.Get();
			for (int i = 0; i < ComTapDonate.ms_selectItems.Count; i++)
			{
				if (ComTapDonate.ms_selectItems[i] != null)
				{
					list.Add(ComTapDonate.ms_selectItems[i].GUID);
				}
			}
			ulong[] result = list.ToArray();
			ListPool<ulong>.Release(list);
			return result;
		}

		// Token: 0x06011835 RID: 71733 RVA: 0x0051839C File Offset: 0x0051679C
		public void OnItemVisible(ItemData value)
		{
			this.data = value;
			if (this.data != null)
			{
				if (null != this.Name)
				{
					this.Name.text = this.data.GetColorName(string.Empty, false);
				}
				if (null == this.comItem)
				{
					this.comItem = ComItemManager.Create(this.goItemParent);
				}
				if (null != this.comItem)
				{
					this.comItem.Setup(this.data, delegate(GameObject obj, ItemData item)
					{
						if (item != null)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
						}
					});
				}
				if (null != this.toggle)
				{
					this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged));
				}
				this._UpdateCheckMark();
				ItemData itemData = ComTapDonate.ms_selectItems.Find((ItemData x) => x != null && x.GUID == this.Value.GUID);
				if (null != this.toggle)
				{
					this.toggle.isOn = (null != itemData);
					this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnToggleChanged));
				}
			}
		}

		// Token: 0x06011836 RID: 71734 RVA: 0x005184D4 File Offset: 0x005168D4
		private void _OnToggleChanged(bool bValue)
		{
			if (bValue)
			{
				if (!ComTapDonate.ms_selectItems.Contains(this.Value))
				{
					ComTapDonate.ms_selectItems.Add(this.Value);
				}
			}
			else
			{
				ComTapDonate.ms_selectItems.Remove(this.Value);
			}
			ItemData itemData = ComTapDonate.ms_selectItems.Find((ItemData x) => x != null && x.GUID == this.Value.GUID);
			this.goCheckMark.CustomActive(null != itemData);
		}

		// Token: 0x06011837 RID: 71735 RVA: 0x0051854C File Offset: 0x0051694C
		private void OnDestroy()
		{
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnToggleChanged));
				this.toggle = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDonateSelecteItemChanged, new ClientEventSystem.UIEventHandler(this._OnDonateSelecteItemChanged));
		}

		// Token: 0x0400B62F RID: 46639
		public GameObject goItemParent;

		// Token: 0x0400B630 RID: 46640
		public Text Name;

		// Token: 0x0400B631 RID: 46641
		public Toggle toggle;

		// Token: 0x0400B632 RID: 46642
		public GameObject goCheckMark;

		// Token: 0x0400B633 RID: 46643
		private ComItem comItem;

		// Token: 0x0400B634 RID: 46644
		private static List<ItemData> ms_selectItems = new List<ItemData>();

		// Token: 0x0400B635 RID: 46645
		private ItemData data;
	}
}
