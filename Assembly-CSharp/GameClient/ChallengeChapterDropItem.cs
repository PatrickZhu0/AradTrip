using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014B6 RID: 5302
	public class ChallengeChapterDropItem : MonoBehaviour
	{
		// Token: 0x0600CD84 RID: 52612 RVA: 0x00328FFD File Offset: 0x003273FD
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CD85 RID: 52613 RVA: 0x00329005 File Offset: 0x00327405
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CD86 RID: 52614 RVA: 0x00329013 File Offset: 0x00327413
		private void BindEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
				this.itemButton.onClick.AddListener(new UnityAction(this.OnItemClicked));
			}
		}

		// Token: 0x0600CD87 RID: 52615 RVA: 0x00329052 File Offset: 0x00327452
		private void UnBindEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CD88 RID: 52616 RVA: 0x00329075 File Offset: 0x00327475
		private void ClearData()
		{
			this._dropItemId = 0;
			this._chapterId = 0;
			this._dropItemType = ChapterDropItemType.None;
		}

		// Token: 0x0600CD89 RID: 52617 RVA: 0x0032908C File Offset: 0x0032748C
		public void InitItem(int itemId, int chapterId = 0)
		{
			this._dropItemId = itemId;
			this._chapterId = chapterId;
			this._dropItemType = this.GetDropItemType();
			if (this._dropItemType == ChapterDropItemType.None)
			{
				Logger.LogErrorFormat("Cannot find dropItem Id is {0}", new object[]
				{
					itemId
				});
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CD8A RID: 52618 RVA: 0x003290E0 File Offset: 0x003274E0
		private void InitContent()
		{
			ChapterDropItemType dropItemType = this._dropItemType;
			if (dropItemType != ChapterDropItemType.Item)
			{
				if (dropItemType == ChapterDropItemType.ItemCollection)
				{
					this.InitDropItemCollection();
				}
			}
			else
			{
				this.InitDropItem();
			}
		}

		// Token: 0x0600CD8B RID: 52619 RVA: 0x00329120 File Offset: 0x00327520
		private void InitDropItem()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._dropItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, tableItem.Color2);
				string colorString = ChallengeUtility.GetColorString(qualityInfo.ColStr, tableItem.Name);
				string icon = tableItem.Icon;
				if (this.itemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.itemIcon, icon, true);
				}
				if (this.itemNameText != null)
				{
					this.itemNameText.text = colorString;
				}
				if (this.itemQualityText != null)
				{
					this.itemQualityText.text = string.Empty;
				}
				this.UpdateItemBackground(tableItem.Color, tableItem.Color2);
			}
		}

		// Token: 0x0600CD8C RID: 52620 RVA: 0x003291E8 File Offset: 0x003275E8
		private void InitDropItemCollection()
		{
			ItemTable.eColor color = ItemTable.eColor.WHITE;
			int color2 = 0;
			ItemCollectionTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(this._dropItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				List<int> list = new List<int>(tableItem.Color);
				list.Sort();
				if (this.itemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.itemIcon, tableItem.Icon, true);
				}
				if (this.itemNameText != null)
				{
					this.itemNameText.text = tableItem.Level;
				}
				ItemData.QualityInfo qualityInfo = null;
				ItemData.QualityInfo qualityInfo2 = null;
				if (list.Count > 0)
				{
					try
					{
						color2 = tableItem.Color2;
						qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)list[list.Count - 1], color2);
						qualityInfo2 = ItemData.GetQualityInfo((ItemTable.eColor)list[0], color2);
						color = (ItemTable.eColor)list[list.Count - 1];
					}
					catch
					{
						qualityInfo = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
						qualityInfo2 = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
						color = ItemTable.eColor.WHITE;
						color2 = 0;
					}
					string text = string.Empty;
					if (qualityInfo == qualityInfo2 || qualityInfo.Quality == qualityInfo2.Quality)
					{
						text = string.Format("{0}", ChallengeUtility.GetColorString(qualityInfo.ColStr, qualityInfo.Desc));
					}
					else
					{
						text = string.Format("{0}-{1}", ChallengeUtility.GetColorString(qualityInfo2.ColStr, qualityInfo2.Desc), ChallengeUtility.GetColorString(qualityInfo.ColStr, qualityInfo.Desc));
					}
					if (this.itemQualityText != null)
					{
						this.itemQualityText.text = text;
					}
				}
				this.UpdateItemBackground(color, color2);
			}
		}

		// Token: 0x0600CD8D RID: 52621 RVA: 0x00329394 File Offset: 0x00327794
		private void UpdateItemBackground(ItemTable.eColor color, int color2)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(color, color2);
			if (this.itemBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemBackground, qualityInfo.Background, true);
			}
		}

		// Token: 0x0600CD8E RID: 52622 RVA: 0x003293D0 File Offset: 0x003277D0
		private void OnItemClicked()
		{
			ChapterDropItemType dropItemType = this._dropItemType;
			if (dropItemType != ChapterDropItemType.Item)
			{
				if (dropItemType == ChapterDropItemType.ItemCollection)
				{
					this.ShopItemCollectionTip();
				}
			}
			else
			{
				this.ShowItemTip();
			}
		}

		// Token: 0x0600CD8F RID: 52623 RVA: 0x00329410 File Offset: 0x00327810
		private void ShowItemTip()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this._dropItemId, 100, 0);
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600CD90 RID: 52624 RVA: 0x00329444 File Offset: 0x00327844
		private void ShopItemCollectionTip()
		{
			ItemCollectionTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(this._dropItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.TipsType == ItemCollectionTable.eTipsType.COLLECTION)
				{
					List<int[]> list = ListPool<int[]>.Get();
					for (int i = 0; i < tableItem.TipsContent.Count; i++)
					{
						if (tableItem.TipsContent[i].valueType == UnionCellType.union_everyvalue && tableItem.TipsContent[i].eValues.everyValues != null)
						{
							FlatBufferArray<int> everyValues = tableItem.TipsContent[i].eValues.everyValues;
							int[] array = new int[everyValues.Count];
							for (int j = 0; j < everyValues.Count; j++)
							{
								array[j] = everyValues[i];
							}
							list.Add(array);
						}
					}
					if (list.Count > 0)
					{
						ChapterInfoDropTipsFrame.ShowTips(list);
					}
					ListPool<int[]>.Release(list);
				}
				else if (tableItem.TipsType == ItemCollectionTable.eTipsType.SINGLE)
				{
					ChapterTempTipsFrame.Show(this._dropItemId);
				}
			}
		}

		// Token: 0x0600CD91 RID: 52625 RVA: 0x0032955C File Offset: 0x0032795C
		private ChapterDropItemType GetDropItemType()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._dropItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return ChapterDropItemType.Item;
			}
			ItemCollectionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemCollectionTable>(this._dropItemId, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				return ChapterDropItemType.ItemCollection;
			}
			return ChapterDropItemType.None;
		}

		// Token: 0x040077E3 RID: 30691
		private int _dropItemId;

		// Token: 0x040077E4 RID: 30692
		private int _chapterId;

		// Token: 0x040077E5 RID: 30693
		private ChapterDropItemType _dropItemType;

		// Token: 0x040077E6 RID: 30694
		[Space(10f)]
		[Header("Item")]
		[SerializeField]
		private Image itemBackground;

		// Token: 0x040077E7 RID: 30695
		[SerializeField]
		private Image itemIcon;

		// Token: 0x040077E8 RID: 30696
		[SerializeField]
		private Text itemNameText;

		// Token: 0x040077E9 RID: 30697
		[SerializeField]
		private Text itemQualityText;

		// Token: 0x040077EA RID: 30698
		[SerializeField]
		private Button itemButton;
	}
}
