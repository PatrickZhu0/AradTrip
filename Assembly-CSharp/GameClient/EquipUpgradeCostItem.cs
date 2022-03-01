using System;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B0C RID: 6924
	public class EquipUpgradeCostItem : MonoBehaviour
	{
		// Token: 0x06010FF3 RID: 69619 RVA: 0x004DC8E0 File Offset: 0x004DACE0
		private void Awake()
		{
			if (this.mBtnItemComLink)
			{
				this.mBtnItemComLink.onClick.RemoveAllListeners();
				this.mBtnItemComLink.onClick.AddListener(delegate()
				{
					ItemComeLink.OnLink(this.itemData.TableID, 0, false, null, false, false, false, null, string.Empty);
				});
			}
		}

		// Token: 0x06010FF4 RID: 69620 RVA: 0x004DC920 File Offset: 0x004DAD20
		public void OnItemVisiable(ItemSimpleData smipleData)
		{
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			this.itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(smipleData.ItemID);
			if (this.itemData == null)
			{
				return;
			}
			this.itemData.Count = 0;
			ComItem comItem = this.comItem;
			ItemData item = this.itemData;
			if (EquipUpgradeCostItem.<>f__mg$cache0 == null)
			{
				EquipUpgradeCostItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, EquipUpgradeCostItem.<>f__mg$cache0);
			this.mName.text = this.itemData.GetColorName(string.Empty, false);
			int ownedItemCount;
			if (this.itemData.Type == ItemTable.eType.MATERIAL)
			{
				ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemData.TableID, true);
				if (ownedItemCount >= smipleData.Count)
				{
					this.mCountText.text = TR.Value("EquipUpgrade_Merial_white", ownedItemCount, smipleData.Count);
				}
				else
				{
					this.mCountText.text = TR.Value("EquipUpgrade_Merial_Red", ownedItemCount, smipleData.Count);
				}
			}
			else
			{
				ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemData.TableID, true);
				if (ownedItemCount >= smipleData.Count)
				{
					this.mCountText.text = TR.Value("EquipUpgrade_Gold_white", smipleData.Count);
				}
				else
				{
					this.mCountText.text = TR.Value("EquipUpgrade_Gold_Red", smipleData.Count);
				}
			}
			this.mBtnItemComLink.CustomActive(ownedItemCount < smipleData.Count);
		}

		// Token: 0x06010FF5 RID: 69621 RVA: 0x004DCAD0 File Offset: 0x004DAED0
		public void OnItemVisiable(ItemSimpleData smipleData, int iSynthesisNumber)
		{
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			this.itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(smipleData.ItemID);
			if (this.itemData == null)
			{
				return;
			}
			ComItem comItem = this.comItem;
			ItemData item = this.itemData;
			if (EquipUpgradeCostItem.<>f__mg$cache1 == null)
			{
				EquipUpgradeCostItem.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, EquipUpgradeCostItem.<>f__mg$cache1);
			this.mName.text = this.itemData.GetColorName(string.Empty, false);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemData.TableID, true);
			if (ownedItemCount >= smipleData.Count * iSynthesisNumber)
			{
				this.mCountText.text = TR.Value("EquipUpgrade_Merial_white", ownedItemCount, smipleData.Count * iSynthesisNumber);
			}
			else
			{
				this.mCountText.text = TR.Value("EquipUpgrade_Merial_Red", ownedItemCount, smipleData.Count * iSynthesisNumber);
			}
			this.mBtnItemComLink.CustomActive(ownedItemCount < smipleData.Count * iSynthesisNumber);
		}

		// Token: 0x06010FF6 RID: 69622 RVA: 0x004DCBFD File Offset: 0x004DAFFD
		private void OnDestroy()
		{
			this.comItem = null;
			this.itemData = null;
		}

		// Token: 0x0400AEE7 RID: 44775
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AEE8 RID: 44776
		[SerializeField]
		private Text mName;

		// Token: 0x0400AEE9 RID: 44777
		[SerializeField]
		private Text mCountText;

		// Token: 0x0400AEEA RID: 44778
		[SerializeField]
		private GameObject mGoItemComLink;

		// Token: 0x0400AEEB RID: 44779
		[SerializeField]
		private Button mBtnItemComLink;

		// Token: 0x0400AEEC RID: 44780
		private ComItem comItem;

		// Token: 0x0400AEED RID: 44781
		private ItemData itemData;

		// Token: 0x0400AEEE RID: 44782
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AEEF RID: 44783
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
