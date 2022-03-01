using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001706 RID: 5894
	public class StorageItem : MonoBehaviour
	{
		// Token: 0x0600E791 RID: 59281 RVA: 0x003D11D0 File Offset: 0x003CF5D0
		private void Awake()
		{
		}

		// Token: 0x0600E792 RID: 59282 RVA: 0x003D11D2 File Offset: 0x003CF5D2
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600E793 RID: 59283 RVA: 0x003D11DA File Offset: 0x003CF5DA
		private void ClearData()
		{
			this._itemGuid = 0UL;
		}

		// Token: 0x0600E794 RID: 59284 RVA: 0x003D11E4 File Offset: 0x003CF5E4
		public void InitStorageItem(StorageItemDataModel storageItemDataModel)
		{
			this._itemGuid = 0UL;
			if (storageItemDataModel != null)
			{
				this._itemGuid = storageItemDataModel.ItemGuid;
			}
			this.InitItemView();
		}

		// Token: 0x0600E795 RID: 59285 RVA: 0x003D1206 File Offset: 0x003CF606
		public void OnItemRecycle()
		{
			this._itemGuid = 0UL;
		}

		// Token: 0x0600E796 RID: 59286 RVA: 0x003D1210 File Offset: 0x003CF610
		private void InitItemView()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this._itemGuid);
			if (item == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.comItemRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.itemBgRoot, true);
				if (this.itemBgRoot != null && this.itemBgPrefab != null)
				{
					Image componentInChildren = this.itemBgRoot.GetComponentInChildren<Image>();
					if (componentInChildren == null)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.itemBgPrefab);
						if (gameObject != null)
						{
							gameObject.transform.SetParent(this.itemBgRoot.transform, false);
							CommonUtility.UpdateGameObjectVisible(gameObject, true);
						}
					}
				}
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.itemBgRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.comItemRoot, true);
			ComItem comItem = this.comItemRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = ComItemManager.Create(this.comItemRoot);
			}
			if (comItem != null)
			{
				comItem.Setup(item, new ComItem.OnItemClicked(this.OnStorageItemClick));
			}
		}

		// Token: 0x0600E797 RID: 59287 RVA: 0x003D1318 File Offset: 0x003CF718
		private void OnStorageItemClick(GameObject obj, ItemData itemData)
		{
			List<TipFuncButon> list = new List<TipFuncButon>();
			TipFuncButonSpecial item = new TipFuncButonSpecial
			{
				text = TR.Value("tip_take"),
				callback = new OnTipFuncClicked(this.OnTakeStorageItem)
			};
			list.Add(item);
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, list, 5, true, false, true);
		}

		// Token: 0x0600E798 RID: 59288 RVA: 0x003D136C File Offset: 0x003CF76C
		private void OnTakeStorageItem(ItemData itemData, object data)
		{
			if (itemData != null)
			{
				if (itemData.Count > 1)
				{
					StoreItemFrame storeItemFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<StoreItemFrame>(FrameLayer.Middle, null, string.Empty) as StoreItemFrame;
					if (storeItemFrame != null)
					{
						storeItemFrame.TakeItem(itemData);
					}
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().TakeItem(itemData, itemData.Count);
				}
			}
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x04008C74 RID: 35956
		private ulong _itemGuid;

		// Token: 0x04008C75 RID: 35957
		[Space(10f)]
		[Header("ItemBg")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemBgPrefab;

		// Token: 0x04008C76 RID: 35958
		[SerializeField]
		private GameObject itemBgRoot;

		// Token: 0x04008C77 RID: 35959
		[Space(10f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject comItemRoot;
	}
}
