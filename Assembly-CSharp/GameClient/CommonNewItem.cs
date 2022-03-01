using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E05 RID: 3589
	public class CommonNewItem : MonoBehaviour
	{
		// Token: 0x06008FD4 RID: 36820 RVA: 0x001A948A File Offset: 0x001A788A
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06008FD5 RID: 36821 RVA: 0x001A9492 File Offset: 0x001A7892
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06008FD6 RID: 36822 RVA: 0x001A94A0 File Offset: 0x001A78A0
		private void BindEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
				this.itemButton.onClick.AddListener(new UnityAction(this.OnItemClicked));
			}
		}

		// Token: 0x06008FD7 RID: 36823 RVA: 0x001A94DF File Offset: 0x001A78DF
		private void UnBindEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06008FD8 RID: 36824 RVA: 0x001A9502 File Offset: 0x001A7902
		private void ClearData()
		{
			this._commonNewItemDataModel = null;
			this._itemId = 0;
			this._itemCount = 0;
			this._itemTable = null;
			this._itemData = null;
		}

		// Token: 0x06008FD9 RID: 36825 RVA: 0x001A9528 File Offset: 0x001A7928
		public void InitItem(ItemTable itemTable, int itemCount = 1, int itemStrengthLevel = 0)
		{
			this._itemTable = itemTable;
			if (this._itemTable == null)
			{
				return;
			}
			this._itemId = this._itemTable.ID;
			this._itemCount = itemCount;
			this._itemStrengthenLevel = itemStrengthLevel;
			this._commonNewItemDataModel = new CommonNewItemDataModel
			{
				ItemId = this._itemId,
				ItemCount = this._itemCount
			};
			this.InitItemView();
		}

		// Token: 0x06008FDA RID: 36826 RVA: 0x001A9594 File Offset: 0x001A7994
		public void InitItem(int itemId, int itemCount = 1)
		{
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = itemId,
				ItemCount = itemCount
			};
			this.InitItem(dataModel);
		}

		// Token: 0x06008FDB RID: 36827 RVA: 0x001A95C0 File Offset: 0x001A79C0
		public void InitItem(CommonNewItemDataModel dataModel)
		{
			this._commonNewItemDataModel = dataModel;
			if (this._commonNewItemDataModel == null)
			{
				return;
			}
			this._itemId = this._commonNewItemDataModel.ItemId;
			this._itemCount = this._commonNewItemDataModel.ItemCount;
			this._itemStrengthenLevel = this._commonNewItemDataModel.ItemStrengthenLevel;
			this._itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemId, string.Empty, string.Empty);
			if (this._itemTable == null)
			{
				Logger.LogErrorFormat("ItemTable is null and itemId is {0}", new object[]
				{
					this._itemId
				});
				return;
			}
			this.InitItemView();
		}

		// Token: 0x06008FDC RID: 36828 RVA: 0x001A9664 File Offset: 0x001A7A64
		private void InitItemView()
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(this._itemTable.Color, false, false);
			if (this.itemBackground != null && qualityInfo != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemBackground, qualityInfo.Background, true);
			}
			if (this.itemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemIcon, this._itemTable.Icon, true);
			}
			this.UpdateItemCount();
			this.UpdateItemLevel();
			this.UpdateItemStrengthenLevel();
			this.UpdateItemLimitTimeGo();
		}

		// Token: 0x06008FDD RID: 36829 RVA: 0x001A96F0 File Offset: 0x001A7AF0
		private void UpdateItemCount()
		{
			if (this.itemCountText != null)
			{
				if (this._itemCount <= 1)
				{
					this.itemCountText.gameObject.CustomActive(false);
				}
				else
				{
					this.itemCountText.gameObject.CustomActive(true);
					this.itemCountText.text = this._itemCount.ToString();
				}
			}
		}

		// Token: 0x06008FDE RID: 36830 RVA: 0x001A9760 File Offset: 0x001A7B60
		private void UpdateItemLevel()
		{
			if (this.itemLevelText != null)
			{
				if (this._itemTable.Type == ItemTable.eType.EQUIP && this._itemTable.NeedLevel > 0)
				{
					this.itemLevelText.gameObject.CustomActive(true);
					this.itemLevelText.text = string.Format("Lv.{0}", this._itemTable.NeedLevel);
				}
				else
				{
					this.itemLevelText.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06008FDF RID: 36831 RVA: 0x001A97EC File Offset: 0x001A7BEC
		private void UpdateItemStrengthenLevel()
		{
			if (this.itemStrengthenLevelText != null)
			{
				if (this._itemStrengthenLevel <= 0)
				{
					this.itemStrengthenLevelText.gameObject.CustomActive(false);
				}
				else
				{
					this.itemStrengthenLevelText.gameObject.CustomActive(true);
					this.itemStrengthenLevelText.text = string.Format("+{0}", this._itemStrengthenLevel);
				}
			}
		}

		// Token: 0x06008FE0 RID: 36832 RVA: 0x001A9860 File Offset: 0x001A7C60
		private void UpdateItemLimitTimeGo()
		{
			this._itemData = ItemDataManager.CreateItemDataFromTable(this._itemId, 100, 0);
			if (this.itemLimitTimeGo != null)
			{
				int num;
				bool flag;
				this._itemData.GetTimeLeft(out num, out flag);
				if ((flag && num > 0) || this._itemData.IsTimeLimit)
				{
					this.itemLimitTimeGo.CustomActive(true);
				}
				else
				{
					this.itemLimitTimeGo.CustomActive(false);
				}
			}
		}

		// Token: 0x06008FE1 RID: 36833 RVA: 0x001A98DB File Offset: 0x001A7CDB
		private void OnItemClicked()
		{
			if (this._commonNewItemDataModel == null)
			{
				return;
			}
			if (this._itemTable == null)
			{
				return;
			}
			this.ShowItemTipFrame();
		}

		// Token: 0x06008FE2 RID: 36834 RVA: 0x001A98FC File Offset: 0x001A7CFC
		private void ShowItemTipFrame()
		{
			this._itemData = ItemDataManager.CreateItemDataFromTable(this._itemId, 100, 0);
			this._itemData.Count = this._itemCount;
			this._itemData.StrengthenLevel = this._itemStrengthenLevel;
			if (this._itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(this._itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x06008FE3 RID: 36835 RVA: 0x001A995F File Offset: 0x001A7D5F
		public void SetItemLevelFontSize(int fontSize)
		{
			if (this.itemLevelText != null)
			{
				this.itemLevelText.fontSize = fontSize;
			}
		}

		// Token: 0x06008FE4 RID: 36836 RVA: 0x001A997E File Offset: 0x001A7D7E
		public void SetItemCountFontSize(int fontSize)
		{
			if (this.itemCountText != null)
			{
				this.itemCountText.fontSize = fontSize;
			}
		}

		// Token: 0x06008FE5 RID: 36837 RVA: 0x001A999D File Offset: 0x001A7D9D
		private void ResetItemIconSprite()
		{
			if (this.itemIcon != null)
			{
				this.itemIcon.sprite = null;
			}
		}

		// Token: 0x06008FE6 RID: 36838 RVA: 0x001A99BC File Offset: 0x001A7DBC
		public void Reset()
		{
			RectTransform component = base.gameObject.GetComponent<RectTransform>();
			if (component != null)
			{
				component.anchorMin = new Vector2(0f, 0f);
				component.anchorMax = new Vector2(1f, 1f);
				component.anchoredPosition = new Vector2(0f, 0f);
				component.sizeDelta = new Vector2(0f, 0f);
				component.pivot = new Vector2(0.5f, 0.5f);
			}
			this.ResetItemIconSprite();
		}

		// Token: 0x0400475C RID: 18268
		private CommonNewItemDataModel _commonNewItemDataModel;

		// Token: 0x0400475D RID: 18269
		private int _itemId;

		// Token: 0x0400475E RID: 18270
		private int _itemCount;

		// Token: 0x0400475F RID: 18271
		private int _itemStrengthenLevel;

		// Token: 0x04004760 RID: 18272
		private ItemTable _itemTable;

		// Token: 0x04004761 RID: 18273
		private ItemData _itemData;

		// Token: 0x04004762 RID: 18274
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private Image itemBackground;

		// Token: 0x04004763 RID: 18275
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04004764 RID: 18276
		[SerializeField]
		private Button itemButton;

		// Token: 0x04004765 RID: 18277
		[Space(10f)]
		[Header("Text")]
		[Space(10f)]
		[SerializeField]
		private Text itemLevelText;

		// Token: 0x04004766 RID: 18278
		[SerializeField]
		private Text itemCountText;

		// Token: 0x04004767 RID: 18279
		[SerializeField]
		private Text itemStrengthenLevelText;

		// Token: 0x04004768 RID: 18280
		[SerializeField]
		private GameObject itemLimitTimeGo;
	}
}
