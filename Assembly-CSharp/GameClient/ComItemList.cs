using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EFD RID: 3837
	public class ComItemList : MonoBehaviour
	{
		// Token: 0x06009616 RID: 38422 RVA: 0x001C62AD File Offset: 0x001C46AD
		private void Awake()
		{
			this._getLayoutGroup();
			this._loadItems();
			this._bindUIEvent();
		}

		// Token: 0x06009617 RID: 38423 RVA: 0x001C62C1 File Offset: 0x001C46C1
		private void OnDestroy()
		{
			this._unloadItems();
			this._unbindUIEvent();
		}

		// Token: 0x06009618 RID: 38424 RVA: 0x001C62D0 File Offset: 0x001C46D0
		private void _bindUIEvent()
		{
			if (this.mUseOnCountUpdate)
			{
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._updatePackageCount));
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._updatePackageCount));
			}
		}

		// Token: 0x06009619 RID: 38425 RVA: 0x001C6320 File Offset: 0x001C4720
		private void _unbindUIEvent()
		{
			if (this.mUseOnCountUpdate)
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._updatePackageCount));
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._updatePackageCount));
			}
		}

		// Token: 0x0600961A RID: 38426 RVA: 0x001C6370 File Offset: 0x001C4770
		private void _updatePackageCount(UIEvent ui)
		{
			if (this.mItemDatas == null)
			{
				return;
			}
			if (this.mCachedItems == null)
			{
				return;
			}
			for (int i = 0; i < this.mItemDatas.Length; i++)
			{
				if (this.mItemDatas[i] != null && this.mItemDatas[i].type == ComItemList.eItemType.Package)
				{
					int id = this.mItemDatas[i].id;
					ComItem comItem = this.mCachedItems.Find((ComItem x) => x != null && x.ItemData != null && id == x.ItemData.TableID);
					if (null != comItem)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
						if (itemData != null)
						{
							itemData.Count = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(id, false);
							if (this.mShowTips)
							{
								comItem.Setup(itemData, delegate(GameObject go, ItemData data)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(data, null, 4, true, false, true);
								});
							}
							else
							{
								comItem.Setup(itemData, null);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600961B RID: 38427 RVA: 0x001C6478 File Offset: 0x001C4878
		private void _loadItems()
		{
			this._unloadItems();
			this._autoAdjustSize();
			for (int i = 0; i < this.mItemDatas.Length; i++)
			{
				ComItemList.Items items = this.mItemDatas[i];
				if (items != null)
				{
					ComItem comItem = ComItemManager.Create(base.gameObject);
					if (!(comItem == null))
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(items.id, 100, 0);
						if (itemData != null)
						{
							itemData.CanSell = this.mCanSell;
							itemData.StrengthenLevel = items.strenthLevel;
							itemData.EquipType = items.equipType;
							if (items.type == ComItemList.eItemType.Custom)
							{
								itemData.Count = (int)items.count;
							}
							else
							{
								itemData.Count = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(items.id, false);
							}
							if (this.mUseCustomCountFormat)
							{
								comItem.SetCountFormatter((ComItem x) => string.Format("{0}", x.ItemData.Count));
							}
							comItem.SetActive(true);
							if (this.mShowTips)
							{
								comItem.Setup(itemData, delegate(GameObject go, ItemData data)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(data, null, 4, true, false, true);
								});
							}
							else
							{
								comItem.Setup(itemData, null);
							}
							if (items.flag == ComItemList.eItemExtraFlag.ExtraReward)
							{
								GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Chapter/Normal/ChapterDropItemTeamFlag", true, 0U);
								Utility.AttachTo(gameObject, comItem.gameObject, false);
								this.mCachedFlags.Add(gameObject);
							}
						}
						GameObject gameObject2 = comItem.gameObject;
						LayoutElement layoutElement = gameObject2.AddComponent<LayoutElement>();
						layoutElement.preferredWidth = (float)this.mWeidth;
						layoutElement.preferredHeight = (float)this.mHeight;
						this.mCachedItems.Add(comItem);
						this.mCachedComs.Add(layoutElement);
					}
				}
			}
		}

		// Token: 0x0600961C RID: 38428 RVA: 0x001C6638 File Offset: 0x001C4A38
		private void _unloadItems()
		{
			for (int i = 0; i < this.mCachedComs.Count; i++)
			{
				Object.Destroy(this.mCachedComs[i]);
				this.mCachedComs[i] = null;
			}
			this.mCachedComs.Clear();
			for (int j = 0; j < this.mCachedItems.Count; j++)
			{
				ComItemManager.Destroy(this.mCachedItems[j]);
				this.mCachedItems[j] = null;
			}
			this.mCachedItems.Clear();
			for (int k = 0; k < this.mCachedFlags.Count; k++)
			{
				Object.Destroy(this.mCachedFlags[k]);
				this.mCachedFlags[k] = null;
			}
			this.mCachedFlags.Clear();
		}

		// Token: 0x0600961D RID: 38429 RVA: 0x001C6714 File Offset: 0x001C4B14
		public void SetItems(ComItemList.Items[] list)
		{
			if (list != null)
			{
				this.mItemDatas = list;
				this._loadItems();
			}
		}

		// Token: 0x0600961E RID: 38430 RVA: 0x001C672C File Offset: 0x001C4B2C
		public void SetItems(IList<int> list)
		{
			this.mItemDatas = new ComItemList.Items[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				this.mItemDatas[i] = new ComItemList.Items();
				this.mItemDatas[i].id = list[i];
				this.mItemDatas[i].type = ComItemList.eItemType.Custom;
				this.mItemDatas[i].flag = ComItemList.eItemExtraFlag.Normal;
				this.mItemDatas[i].count = 0U;
			}
			this._loadItems();
		}

		// Token: 0x0600961F RID: 38431 RVA: 0x001C67B4 File Offset: 0x001C4BB4
		public void AddItems(ComItemList.Items[] list)
		{
			List<ComItemList.Items> list2 = new List<ComItemList.Items>(this.mItemDatas);
			for (int i = 0; i < list.Length; i++)
			{
				list2.Add(list[i]);
			}
			this.mItemDatas = list2.ToArray();
			this._loadItems();
		}

		// Token: 0x06009620 RID: 38432 RVA: 0x001C67FC File Offset: 0x001C4BFC
		private void _getLayoutGroup()
		{
			this.mHorizontalLayoutGroup = base.transform.GetComponent<HorizontalLayoutGroup>();
			this.mVerticalLayoutGroup = base.transform.GetComponent<VerticalLayoutGroup>();
		}

		// Token: 0x06009621 RID: 38433 RVA: 0x001C6820 File Offset: 0x001C4C20
		private void _autoAdjustSize()
		{
			if (this.mIsAutoAdjustSize)
			{
				RectTransform rectTransform = base.transform as RectTransform;
				int num = this.mItemDatas.Length;
				if (this.mHorizontalLayoutGroup != null)
				{
					float num2 = (float)this.mWeidth + ((this.mHorizontalLayoutGroup.spacing <= 0f) ? 0f : this.mHorizontalLayoutGroup.spacing);
					rectTransform.sizeDelta = new Vector2((float)num * num2, rectTransform.sizeDelta.y);
				}
				else if (this.mVerticalLayoutGroup != null)
				{
					float num3 = (float)this.mHeight + ((this.mVerticalLayoutGroup.spacing <= 0f) ? 0f : this.mVerticalLayoutGroup.spacing);
					rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (float)num * num3);
				}
			}
		}

		// Token: 0x04004CED RID: 19693
		public int mWeidth = 100;

		// Token: 0x04004CEE RID: 19694
		public int mHeight = 100;

		// Token: 0x04004CEF RID: 19695
		public int mMaxCount = 5;

		// Token: 0x04004CF0 RID: 19696
		public bool mCanSell;

		// Token: 0x04004CF1 RID: 19697
		public bool mCanUse;

		// Token: 0x04004CF2 RID: 19698
		public bool mShowTips = true;

		// Token: 0x04004CF3 RID: 19699
		public bool mUseCustomCountFormat;

		// Token: 0x04004CF4 RID: 19700
		public bool mUseOnCountUpdate = true;

		// Token: 0x04004CF5 RID: 19701
		public bool mIsAutoAdjustSize;

		// Token: 0x04004CF6 RID: 19702
		private HorizontalLayoutGroup mHorizontalLayoutGroup;

		// Token: 0x04004CF7 RID: 19703
		private VerticalLayoutGroup mVerticalLayoutGroup;

		// Token: 0x04004CF8 RID: 19704
		private List<ComItem> mCachedItems = new List<ComItem>();

		// Token: 0x04004CF9 RID: 19705
		private List<Component> mCachedComs = new List<Component>();

		// Token: 0x04004CFA RID: 19706
		private List<GameObject> mCachedFlags = new List<GameObject>();

		// Token: 0x04004CFB RID: 19707
		public ComItemList.Items[] mItemDatas = new ComItemList.Items[0];

		// Token: 0x02000EFE RID: 3838
		public enum eItemType
		{
			// Token: 0x04004D00 RID: 19712
			Custom,
			// Token: 0x04004D01 RID: 19713
			Package
		}

		// Token: 0x02000EFF RID: 3839
		public enum eItemExtraFlag
		{
			// Token: 0x04004D03 RID: 19715
			Normal,
			// Token: 0x04004D04 RID: 19716
			ExtraReward
		}

		// Token: 0x02000F00 RID: 3840
		[Serializable]
		public class Items
		{
			// Token: 0x04004D05 RID: 19717
			public ComItemList.eItemType type;

			// Token: 0x04004D06 RID: 19718
			public ComItemList.eItemExtraFlag flag;

			// Token: 0x04004D07 RID: 19719
			public uint count;

			// Token: 0x04004D08 RID: 19720
			public int id;

			// Token: 0x04004D09 RID: 19721
			public int strenthLevel;

			// Token: 0x04004D0A RID: 19722
			public EEquipType equipType;
		}
	}
}
