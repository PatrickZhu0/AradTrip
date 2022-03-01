using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CAF RID: 7343
	internal class ComItemSetting : MonoBehaviour
	{
		// Token: 0x06012047 RID: 73799 RVA: 0x00544249 File Offset: 0x00542649
		public void SetProcessFormat(string format)
		{
			this.processFormatString = format;
		}

		// Token: 0x06012048 RID: 73800 RVA: 0x00544254 File Offset: 0x00542654
		public void SetValueByTableData(int iId, int count, int cost)
		{
			this.value = ItemDataManager.CreateItemDataFromTable(iId, 100, 0);
			if (this.value != null)
			{
				this.value.Count = count;
			}
			this.cost = cost;
			this._setComItem(this.value);
			this._setName(this.value);
			this._setProcess(this.value);
		}

		// Token: 0x06012049 RID: 73801 RVA: 0x005442B4 File Offset: 0x005426B4
		private void _setComItem(ItemData value)
		{
			this.value = value;
			if (null == this.comItem)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			if (null != this.comItem)
			{
				if (this.bUseTipsForItemClicked)
				{
					this.comItem.Setup(value, delegate(GameObject obj, ItemData item)
					{
						if (item != null)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
						}
					});
				}
				else if (this.bUseForItemComLink)
				{
					this.comItem.Setup(value, delegate(GameObject obj, ItemData item)
					{
						if (item != null)
						{
							ItemComeLink.OnLink(item.TableID, this.cost, true, null, false, false, false, null, string.Empty);
						}
					});
				}
				else
				{
					this.comItem.Setup(value, null);
				}
			}
		}

		// Token: 0x0601204A RID: 73802 RVA: 0x0054436C File Offset: 0x0054276C
		private void _setName(ItemData value)
		{
			if (null != this.Name)
			{
				if (value != null)
				{
					this.Name.text = value.GetColorName(string.Empty, false);
				}
				else
				{
					this.Name.text = string.Empty;
				}
			}
		}

		// Token: 0x0601204B RID: 73803 RVA: 0x005443BC File Offset: 0x005427BC
		private void _setProcess(ItemData value)
		{
			if (null != this.Process)
			{
				if (value != null)
				{
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(value.TableID, true);
					if (null != this.comProcessMode)
					{
						if (ownedItemCount >= this.cost)
						{
							this.comProcessMode.Key = "enough";
							this.processFormatString = "<color=#00ff00>{0}</color>/{1}";
						}
						else
						{
							this.comProcessMode.Key = "not_enough";
							this.processFormatString = "<color=#ff0000>{0}</color>/{1}";
						}
						this.Process.text = string.Format(this.processFormatString, ownedItemCount, this.cost);
					}
					else
					{
						this.Process.text = string.Empty;
					}
				}
				else
				{
					this.Process.text = string.Empty;
				}
			}
		}

		// Token: 0x0601204C RID: 73804 RVA: 0x0054449B File Offset: 0x0054289B
		public void OnDestroy()
		{
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
		}

		// Token: 0x0400BBCB RID: 48075
		public GameObject goItemParent;

		// Token: 0x0400BBCC RID: 48076
		public Text Name;

		// Token: 0x0400BBCD RID: 48077
		public Text Process;

		// Token: 0x0400BBCE RID: 48078
		public StateController comProcessMode;

		// Token: 0x0400BBCF RID: 48079
		private string processFormatString;

		// Token: 0x0400BBD0 RID: 48080
		public bool bUseTipsForItemClicked;

		// Token: 0x0400BBD1 RID: 48081
		public bool bUseForItemComLink;

		// Token: 0x0400BBD2 RID: 48082
		private ComItem comItem;

		// Token: 0x0400BBD3 RID: 48083
		private ItemData value;

		// Token: 0x0400BBD4 RID: 48084
		private int cost;
	}
}
