using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ACE RID: 6862
	public class PickBeadExpendItem : MonoBehaviour
	{
		// Token: 0x06010D87 RID: 68999 RVA: 0x004CD924 File Offset: 0x004CBD24
		private void Start()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
		}

		// Token: 0x06010D88 RID: 69000 RVA: 0x004CD9A4 File Offset: 0x004CBDA4
		public void Init(BeadPickItemModel item, ToggleGroup group, BeadPickModel beadPickModel)
		{
			if (item == null)
			{
				return;
			}
			this.mBeadPickItemModel = item;
			this.mBeadPickExpendItem = ComItemManager.Create(this.mItemPos);
			this.mItemTog.group = group;
			this.mBeadPickModel = beadPickModel;
			this.mBeadPickNumber = this.mBeadPickModel.mPrecBead.pickNumber;
			this.UpdatePickBeadExpendItem();
			this.SetPickSeccessRate();
			this.OnItemClickLink();
			this.ToggleOnClick();
		}

		// Token: 0x06010D89 RID: 69001 RVA: 0x004CDA11 File Offset: 0x004CBE11
		private void SetPickSeccessRate()
		{
			if (this.mPickSuccesRate != null)
			{
				this.mPickSuccesRate.text = string.Format(this.mStr, this.mBeadPickItemModel.mPickSuccessRate / 100);
			}
		}

		// Token: 0x06010D8A RID: 69002 RVA: 0x004CDA4D File Offset: 0x004CBE4D
		private void OnItemClickLink()
		{
			if (this.mItemClickBtn != null)
			{
				this.mItemClickBtn.SafeAddOnClickListener(delegate
				{
					ItemComeLink.OnLink(this.mBeadPickItemModel.mExpendItemID, 0, true, null, false, false, false, null, string.Empty);
				});
			}
		}

		// Token: 0x06010D8B RID: 69003 RVA: 0x004CDA77 File Offset: 0x004CBE77
		private void ToggleOnClick()
		{
			if (this.mItemTog != null)
			{
				this.mItemTog.onValueChanged.RemoveAllListeners();
				this.mItemTog.onValueChanged.AddListener(delegate(bool value)
				{
					if (value)
					{
						this.mCureentSelectExpendItemID = this.mBeadPickItemModel.mExpendItemID;
						this.mCurrentSelectExpendItemSuccessRate = this.mBeadPickItemModel.mPickSuccessRate;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectPickBeadExpendItem, this.mCureentSelectExpendItemID, this.mCurrentSelectExpendItemSuccessRate, this.mBeadRemainPickNumber, null);
					}
				});
			}
		}

		// Token: 0x06010D8C RID: 69004 RVA: 0x004CDAB8 File Offset: 0x004CBEB8
		public void UpdatePickBeadExpendItem()
		{
			if (this.mBeadPickExpendItem != null)
			{
				int mExpendCount = this.mBeadPickItemModel.mExpendCount;
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mBeadPickItemModel.mExpendItemID);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBeadPickItemModel.mExpendItemID, true);
				ComItem comItem = this.mBeadPickExpendItem;
				ItemData item = commonItemTableDataByID;
				if (PickBeadExpendItem.<>f__mg$cache0 == null)
				{
					PickBeadExpendItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, PickBeadExpendItem.<>f__mg$cache0);
				if (this.mBeadPickExpendItem != null)
				{
					this.mBeadPickExpendItem.SetEnable(mExpendCount <= ownedItemCount);
				}
				if (this.mOwnNum != null)
				{
					this.mOwnNum.text = ownedItemCount.ToString();
				}
				if (this.mExpendNum != null)
				{
					this.mExpendNum.text = mExpendCount.ToString();
				}
				if (this.mOwnNumState != null)
				{
					this.mOwnNumState.Key = ((mExpendCount > ownedItemCount) ? this.mStrDisable : this.mStrEnable);
				}
				if (commonItemTableDataByID.SubType == 89)
				{
					if (this.mBeadPickItemModel.mBeadPickTotleNumber > 0)
					{
						if (this.mBeadPickNumber >= this.mBeadPickItemModel.mBeadPickTotleNumber)
						{
							this.mBeadRemainPickNumber = 0;
						}
						else
						{
							this.mBeadRemainPickNumber = this.mBeadPickItemModel.mBeadPickTotleNumber - this.mBeadPickNumber;
						}
						this.mPickNumber.text = string.Format(this.mPickNumberDes, this.mBeadRemainPickNumber);
						this.mPickNumber.CustomActive(true);
					}
					else
					{
						this.mPickNumber.CustomActive(false);
					}
				}
				else
				{
					this.mPickNumber.CustomActive(false);
				}
			}
		}

		// Token: 0x06010D8D RID: 69005 RVA: 0x004CDC8C File Offset: 0x004CC08C
		private void OnDestroy()
		{
			if (this.mBeadPickExpendItem != null)
			{
				ComItemManager.Destroy(this.mBeadPickExpendItem);
				this.mBeadPickExpendItem = null;
			}
			if (this.mItemClickBtn != null)
			{
				this.mItemClickBtn.onClick.RemoveAllListeners();
			}
			if (this.mItemTog != null)
			{
				this.mItemTog.onValueChanged.RemoveAllListeners();
			}
			this.mCureentSelectExpendItemID = 0;
			this.mCurrentSelectExpendItemSuccessRate = 0;
			this.mBeadPickItemModel = null;
			this.mBeadRemainPickNumber = -1;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
		}

		// Token: 0x06010D8E RID: 69006 RVA: 0x004CDD8C File Offset: 0x004CC18C
		private void _OnAddNewItem(List<Item> items)
		{
			this.UpdatePickBeadExpendItem();
		}

		// Token: 0x06010D8F RID: 69007 RVA: 0x004CDD94 File Offset: 0x004CC194
		private void _OnRemoveItem(ItemData data)
		{
			this.UpdatePickBeadExpendItem();
		}

		// Token: 0x06010D90 RID: 69008 RVA: 0x004CDD9C File Offset: 0x004CC19C
		private void _OnUpdateItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.GUID == this.mBeadPickModel.mEquipItemData.GUID)
					{
						this.mBeadPickNumber = item.PreciousBeadMountHole[this.mBeadPickModel.mPrecBead.index - 1].pickNumber;
						break;
					}
				}
			}
			this.UpdatePickBeadExpendItem();
		}

		// Token: 0x0400ACC3 RID: 44227
		[SerializeField]
		private StateController mOwnNumState;

		// Token: 0x0400ACC4 RID: 44228
		[SerializeField]
		private GameObject mItemPos;

		// Token: 0x0400ACC5 RID: 44229
		[SerializeField]
		private Text mOwnNum;

		// Token: 0x0400ACC6 RID: 44230
		[SerializeField]
		private Text mExpendNum;

		// Token: 0x0400ACC7 RID: 44231
		[SerializeField]
		private Text mPickSuccesRate;

		// Token: 0x0400ACC8 RID: 44232
		[SerializeField]
		private Button mItemClickBtn;

		// Token: 0x0400ACC9 RID: 44233
		[SerializeField]
		private Toggle mItemTog;

		// Token: 0x0400ACCA RID: 44234
		[SerializeField]
		private Text mPickNumber;

		// Token: 0x0400ACCB RID: 44235
		[SerializeField]
		private string mStr;

		// Token: 0x0400ACCC RID: 44236
		[SerializeField]
		private string mPickNumberDes;

		// Token: 0x0400ACCD RID: 44237
		private BeadPickItemModel mBeadPickItemModel;

		// Token: 0x0400ACCE RID: 44238
		private BeadPickModel mBeadPickModel;

		// Token: 0x0400ACCF RID: 44239
		private ComItem mBeadPickExpendItem;

		// Token: 0x0400ACD0 RID: 44240
		private string mStrEnable = "Enable";

		// Token: 0x0400ACD1 RID: 44241
		private string mStrDisable = "Disable";

		// Token: 0x0400ACD2 RID: 44242
		private int mCureentSelectExpendItemID;

		// Token: 0x0400ACD3 RID: 44243
		private int mCurrentSelectExpendItemSuccessRate;

		// Token: 0x0400ACD4 RID: 44244
		private int mBeadPickNumber;

		// Token: 0x0400ACD5 RID: 44245
		private int mBeadRemainPickNumber = -1;

		// Token: 0x0400ACD6 RID: 44246
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
