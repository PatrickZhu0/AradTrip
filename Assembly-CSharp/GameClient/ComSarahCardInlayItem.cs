using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AE7 RID: 6887
	public class ComSarahCardInlayItem : MonoBehaviour
	{
		// Token: 0x17001D77 RID: 7543
		// (get) Token: 0x06010E81 RID: 69249 RVA: 0x004D3E14 File Offset: 0x004D2214
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06010E82 RID: 69250 RVA: 0x004D3E38 File Offset: 0x004D2238
		public static int Sort(ItemData left, ItemData right)
		{
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(left.TableID, string.Empty, string.Empty);
			BeadTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(right.TableID, string.Empty, string.Empty);
			if (tableItem.Level != tableItem2.Level)
			{
				return tableItem2.Level - tableItem.Level;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x06010E83 RID: 69251 RVA: 0x004D3EC8 File Offset: 0x004D22C8
		public static ItemData _TryAddSarahCard(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 54 && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage)
			{
				return item;
			}
			return null;
		}

		// Token: 0x06010E84 RID: 69252 RVA: 0x004D3F1C File Offset: 0x004D231C
		public void OnSelectedItem()
		{
			if (null != this.comItem && this.comItem.ItemData != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSarakCardSelected, this.comItem.ItemData, null, null, null);
			}
		}

		// Token: 0x06010E85 RID: 69253 RVA: 0x004D3F5C File Offset: 0x004D235C
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010E86 RID: 69254 RVA: 0x004D3F6A File Offset: 0x004D236A
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010E87 RID: 69255 RVA: 0x004D3F84 File Offset: 0x004D2384
		public void OnItemVisible(ItemData itemData)
		{
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(itemData.TableID, string.Empty, string.Empty);
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.checkName.text = itemData.GetColorName(string.Empty, false);
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			base.gameObject.name = itemData.TableID.ToString();
			if (itemData.BeadAdditiveAttributeBuffID > 0)
			{
				Text text = this.sarahText;
				string text2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem.ID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(itemData.BeadAdditiveAttributeBuffID));
				this.checkSarahText.text = text2;
				text.text = text2;
			}
			else
			{
				Text text3 = this.sarahText;
				string text2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem.ID, false);
				this.checkSarahText.text = text2;
				text3.text = text2;
			}
			this.ShowBeadReplaceRemainNumber(itemData);
			this.mScrollRect.verticalNormalizedPosition = 1f;
		}

		// Token: 0x06010E88 RID: 69256 RVA: 0x004D40D4 File Offset: 0x004D24D4
		public void ShowBeadReplaceRemainNumber(ItemData mItemData)
		{
			if (this.mIsShowBeadReplaceNumber)
			{
				string beadReplaceRemainNumber = DataManager<BeadCardManager>.GetInstance().GetBeadReplaceRemainNumber(mItemData.TableID, mItemData.BeadReplaceNumber);
				if (beadReplaceRemainNumber != string.Empty)
				{
					Text text = this.sarahText;
					text.text = text.text + "\n" + beadReplaceRemainNumber;
				}
			}
		}

		// Token: 0x06010E89 RID: 69257 RVA: 0x004D412F File Offset: 0x004D252F
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0400ADB3 RID: 44467
		public static ItemData ms_selected;

		// Token: 0x0400ADB4 RID: 44468
		public GameObject goItemParent;

		// Token: 0x0400ADB5 RID: 44469
		public Text Name;

		// Token: 0x0400ADB6 RID: 44470
		public Text checkName;

		// Token: 0x0400ADB7 RID: 44471
		public Text sarahText;

		// Token: 0x0400ADB8 RID: 44472
		public Text checkSarahText;

		// Token: 0x0400ADB9 RID: 44473
		public Text beadAppendArrt;

		// Token: 0x0400ADBA RID: 44474
		public Text checkBeadAppendArrt;

		// Token: 0x0400ADBB RID: 44475
		public GameObject goCheckMark;

		// Token: 0x0400ADBC RID: 44476
		public Image imageItemBack;

		// Token: 0x0400ADBD RID: 44477
		public ScrollRect mScrollRect;

		// Token: 0x0400ADBE RID: 44478
		[Header("是否显示宝珠置换次数")]
		[SerializeField]
		private bool mIsShowBeadReplaceNumber;

		// Token: 0x0400ADBF RID: 44479
		private ComItem comItem;
	}
}
