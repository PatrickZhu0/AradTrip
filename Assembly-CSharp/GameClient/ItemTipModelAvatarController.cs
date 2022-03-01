using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016E7 RID: 5863
	public class ItemTipModelAvatarController : MonoBehaviour
	{
		// Token: 0x0600E58F RID: 58767 RVA: 0x003BCF6A File Offset: 0x003BB36A
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600E590 RID: 58768 RVA: 0x003BCF72 File Offset: 0x003BB372
		private void ClearData()
		{
			this._clickedItemTable = null;
			this._itemTipModelAvatarLayerIndex = 0;
			this.ResetGiftPackDataModel();
			this._followPetAvatarEx = null;
			this._giftPackSelectItemTableIndex = 1;
			this._itemTipModelAvatarEnumerationController = null;
			this._otherPlayerProfessionId = 0;
			this._otherPlayerProfessionIdList = null;
			this._otherPlayerProfessionIdIndex = 1;
		}

		// Token: 0x0600E591 RID: 58769 RVA: 0x003BCFB2 File Offset: 0x003BB3B2
		private void ResetGiftPackDataModel()
		{
			this._giftPackShowModelAvatarType = GiftPackTable.eShowAvatarModelType.None;
			this._giftPackShowItemTableList = null;
			this._isOwnerCompleteShowType = false;
		}

		// Token: 0x0600E592 RID: 58770 RVA: 0x003BCFCC File Offset: 0x003BB3CC
		public void UpdateModelAvatarController(ItemTable itemTable, int itemTipModelAvatarLayerIndex, GiftPackModelAvatarDataModel giftPackModelAvatarDataModel = null, int otherProfessionId = 0)
		{
			this._clickedItemTable = itemTable;
			this._itemTipModelAvatarLayerIndex = itemTipModelAvatarLayerIndex;
			this.ResetGiftPackDataModel();
			if (giftPackModelAvatarDataModel != null)
			{
				this._giftPackShowItemTableList = giftPackModelAvatarDataModel.GiftPackShowItemTableList;
				this._giftPackShowModelAvatarType = giftPackModelAvatarDataModel.GiftPackShowModelAvatarType;
				this._isOwnerCompleteShowType = giftPackModelAvatarDataModel.IsOwnerCompleteShowType;
			}
			this._otherPlayerProfessionId = otherProfessionId;
			if (this._clickedItemTable == null)
			{
				return;
			}
			if (this.geAvatarRenderEx != null)
			{
				this.geAvatarRenderEx.m_Layer = this._itemTipModelAvatarLayerIndex;
			}
			this.UpdateModelAvatar();
		}

		// Token: 0x0600E593 RID: 58771 RVA: 0x003BD054 File Offset: 0x003BB454
		private void UpdateModelAvatar()
		{
			CommonUtility.UpdateGameObjectVisible(this.itemTitleRoot, false);
			CommonUtility.UpdateTextVisible(this.itemNameLabel, false);
			CommonUtility.UpdateGameObjectVisible(this.avatarChangeRoot, false);
			if (this._clickedItemTable.SubType == ItemTable.eSubType.PetEgg)
			{
				this.InitPetAvatar(this._clickedItemTable);
			}
			else if (this._clickedItemTable.Type == ItemTable.eType.VirtualPack || this._clickedItemTable.SubType == ItemTable.eSubType.GiftPackage)
			{
				this.InitGiftPackModelAvatar();
			}
			else if (this._otherPlayerProfessionId > 0)
			{
				this.ShowOtherPlayerAvatar();
			}
			else
			{
				this.UpdateSelfPlayerByItemTable(this._clickedItemTable);
			}
		}

		// Token: 0x0600E594 RID: 58772 RVA: 0x003BD0FA File Offset: 0x003BB4FA
		private void InitPlayerAvatar()
		{
			PlayerUtility.LoadPlayerAvatarBySelfPlayer(this.geAvatarRenderEx);
		}

		// Token: 0x0600E595 RID: 58773 RVA: 0x003BD107 File Offset: 0x003BB507
		private void UpdateSelfPlayerByItemTable(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			this.InitPlayerName(itemTable);
			this.InitPlayerAvatar();
			this.UpdateModelAvatarByItemTable(itemTable);
		}

		// Token: 0x0600E596 RID: 58774 RVA: 0x003BD124 File Offset: 0x003BB524
		private void InitPlayerTitle(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			if (itemTable.Path2.Count < 4)
			{
				return;
			}
			List<string> list = itemTable.Path2.ToList<string>();
			CommonUtility.UpdateGameObjectVisible(this.itemTitleRoot, true);
			if (this.spriteAniRenderChangeHao != null)
			{
				string orgPath = list[0];
				string orgName = list[1];
				int count = 0;
				float fScale = 0f;
				if (int.TryParse(list[2], out count) && float.TryParse(list[3], out fScale))
				{
					this.spriteAniRenderChangeHao.Reset(orgPath, orgName, count, fScale, itemTable.ModelPath);
				}
			}
			if (this.spriteAniImage != null)
			{
				this.spriteAniImage.enabled = true;
			}
		}

		// Token: 0x0600E597 RID: 58775 RVA: 0x003BD1E8 File Offset: 0x003BB5E8
		private void InitPlayerName(ItemTable itemTable)
		{
			if (this.itemNameLabel == null)
			{
				return;
			}
			if (itemTable == null)
			{
				return;
			}
			string itemColorName = CommonUtility.GetItemColorName(itemTable);
			this.itemNameLabel.text = itemColorName;
			CommonUtility.UpdateTextVisible(this.itemNameLabel, true);
		}

		// Token: 0x0600E598 RID: 58776 RVA: 0x003BD230 File Offset: 0x003BB630
		private void ShowPlayerAvatarByWeaponType()
		{
			if (this._mixPlayerProfessionIdList == null)
			{
				this._mixPlayerProfessionIdList = PlayerUtility.GetItemTableSuitMixProfessionIdList(this._clickedItemTable);
			}
			if (this._mixPlayerProfessionIdList == null || this._mixPlayerProfessionIdList.Count <= 1)
			{
				this.UpdateSelfPlayerByItemTable(this._clickedItemTable);
			}
			else
			{
				this.ShowMixPlayerAvatarByEnumerationType();
			}
		}

		// Token: 0x0600E599 RID: 58777 RVA: 0x003BD28C File Offset: 0x003BB68C
		private void ShowMixPlayerAvatarByEnumerationType()
		{
			if (this.avatarChangeRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.avatarChangeRoot, true);
			if (this._itemTipModelAvatarEnumerationController == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.avatarChangeRoot);
				if (gameObject != null)
				{
					this._itemTipModelAvatarEnumerationController = gameObject.GetComponent<ItemTipModelAvatarEnumerationController>();
				}
				if (this._itemTipModelAvatarEnumerationController != null)
				{
					this._itemTipModelAvatarEnumerationController.InitController(this._mixPlayerProfessionIdList, this._mixPlayerProfessionIdIndex, new OnItemTipModelAvatarEnumerationItemClick(this.OnMixPlayerAvatarChangeActionInEnumerationType));
				}
			}
			else
			{
				this._itemTipModelAvatarEnumerationController.OnEnableController(this._mixPlayerProfessionIdIndex);
			}
			this.ShowMixPlayerAvatarInEnumerationType();
		}

		// Token: 0x0600E59A RID: 58778 RVA: 0x003BD33C File Offset: 0x003BB73C
		private void OnMixPlayerAvatarChangeActionInEnumerationType(int selectedIndex)
		{
			if (this._mixPlayerProfessionIdIndex == selectedIndex)
			{
				return;
			}
			this._mixPlayerProfessionIdIndex = selectedIndex;
			this.ShowMixPlayerAvatarInEnumerationType();
		}

		// Token: 0x0600E59B RID: 58779 RVA: 0x003BD358 File Offset: 0x003BB758
		private void ShowMixPlayerAvatarInEnumerationType()
		{
			int num = this._mixPlayerProfessionIdIndex - 1;
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= this._mixPlayerProfessionIdList.Count)
			{
				num = this._mixPlayerProfessionIdList.Count - 1;
			}
			int num2 = this._mixPlayerProfessionIdList[num];
			if (num2 == DataManager<PlayerBaseData>.GetInstance().JobTableID)
			{
				this.UpdateSelfPlayerByItemTable(this._clickedItemTable);
			}
			else
			{
				this.ShowOneOtherPlayerAvatarByProfessionId(num2);
			}
		}

		// Token: 0x0600E59C RID: 58780 RVA: 0x003BD3D0 File Offset: 0x003BB7D0
		private void ShowOtherPlayerAvatar()
		{
			if (this._otherPlayerProfessionIdList == null)
			{
				this._otherPlayerProfessionIdList = PlayerUtility.GetItemTableSuitBaseProfessionIdList(this._clickedItemTable);
			}
			if (this._otherPlayerProfessionIdList == null || this._otherPlayerProfessionIdList.Count <= 1)
			{
				this.ShowOneOtherPlayerAvatarByProfessionId(this._otherPlayerProfessionId);
			}
			else
			{
				this.ShowOtherPlayerAvatarByEnumerationType();
			}
		}

		// Token: 0x0600E59D RID: 58781 RVA: 0x003BD42C File Offset: 0x003BB82C
		private void ShowOneOtherPlayerAvatarByProfessionId(int professionId)
		{
			this.InitPlayerName(this._clickedItemTable);
			PlayerUtility.LoadPlayerAvatarByProfessionId(this.geAvatarRenderEx, professionId);
			ItemTable.eSubType subType = this._clickedItemTable.SubType;
			if (subType == ItemTable.eSubType.WEAPON || subType == ItemTable.eSubType.FASHION_WEAPON)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.geAvatarRenderEx, professionId, this._clickedItemTable.ID, null, false);
			}
		}

		// Token: 0x0600E59E RID: 58782 RVA: 0x003BD48C File Offset: 0x003BB88C
		private void ShowOtherPlayerAvatarByEnumerationType()
		{
			if (this.avatarChangeRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.avatarChangeRoot, true);
			if (this._itemTipModelAvatarEnumerationController == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.avatarChangeRoot);
				if (gameObject != null)
				{
					this._itemTipModelAvatarEnumerationController = gameObject.GetComponent<ItemTipModelAvatarEnumerationController>();
				}
				if (this._itemTipModelAvatarEnumerationController != null)
				{
					this._itemTipModelAvatarEnumerationController.InitController(this._otherPlayerProfessionIdList, this._otherPlayerProfessionIdIndex, new OnItemTipModelAvatarEnumerationItemClick(this.OnOtherPlayerAvatarChangeActionInEnumerationType));
				}
			}
			else
			{
				this._itemTipModelAvatarEnumerationController.OnEnableController(this._otherPlayerProfessionIdIndex);
			}
			this.ShowOneOtherPlayerAvatarInEnumerationType();
		}

		// Token: 0x0600E59F RID: 58783 RVA: 0x003BD53C File Offset: 0x003BB93C
		private void OnOtherPlayerAvatarChangeActionInEnumerationType(int selectedIndex)
		{
			if (this._otherPlayerProfessionIdIndex == selectedIndex)
			{
				return;
			}
			this._otherPlayerProfessionIdIndex = selectedIndex;
			this.ShowOneOtherPlayerAvatarInEnumerationType();
		}

		// Token: 0x0600E5A0 RID: 58784 RVA: 0x003BD558 File Offset: 0x003BB958
		private void ShowOneOtherPlayerAvatarInEnumerationType()
		{
			int num = this._otherPlayerProfessionIdIndex - 1;
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= this._otherPlayerProfessionIdList.Count)
			{
				num = this._otherPlayerProfessionIdList.Count - 1;
			}
			int professionId = this._otherPlayerProfessionIdList[num];
			this.ShowOneOtherPlayerAvatarByProfessionId(professionId);
		}

		// Token: 0x0600E5A1 RID: 58785 RVA: 0x003BD5B0 File Offset: 0x003BB9B0
		private void InitPetAvatar(ItemTable itemTable)
		{
			int petIdByItemTable = ItemDataUtility.GetPetIdByItemTable(itemTable);
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petIdByItemTable, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.InitPetNameLabel(tableItem);
			PlayerUtility.LoadPetAvatarRenderEx(petIdByItemTable, this.geAvatarRenderEx, true);
		}

		// Token: 0x0600E5A2 RID: 58786 RVA: 0x003BD5F8 File Offset: 0x003BB9F8
		private void InitPetNameLabel(PetTable petTable)
		{
			if (this.itemNameLabel == null)
			{
				return;
			}
			if (petTable == null)
			{
				return;
			}
			CommonUtility.UpdateTextVisible(this.itemNameLabel, true);
			string petItemName = CommonUtility.GetPetItemName(petTable);
			this.itemNameLabel.text = petItemName;
		}

		// Token: 0x0600E5A3 RID: 58787 RVA: 0x003BD63D File Offset: 0x003BBA3D
		private void InitGiftPackModelAvatar()
		{
			if (this._giftPackShowModelAvatarType == GiftPackTable.eShowAvatarModelType.None)
			{
				return;
			}
			if (this._giftPackShowItemTableList == null || this._giftPackShowItemTableList.Count <= 0)
			{
				return;
			}
			this.ShowGiftPackModelAvatar();
		}

		// Token: 0x0600E5A4 RID: 58788 RVA: 0x003BD670 File Offset: 0x003BBA70
		private void ShowGiftPackModelAvatar()
		{
			switch (this._giftPackShowModelAvatarType)
			{
			case GiftPackTable.eShowAvatarModelType.Single:
				this.ShowGiftPackModelAvatarBySingleShow();
				break;
			case GiftPackTable.eShowAvatarModelType.Complete:
				this.ShowGiftPackModelAvatarByCombinationShow();
				break;
			case GiftPackTable.eShowAvatarModelType.Enumeration:
				this.ShowGiftPackModelAvatarByEnumerationShow();
				break;
			case GiftPackTable.eShowAvatarModelType.Combination:
				this.ShowGiftPackModelAvatarByCombinationShow();
				break;
			case GiftPackTable.eShowAvatarModelType.Matching:
				this.ShowGiftPackModelAvatarByMatchingShow();
				break;
			case GiftPackTable.eShowAvatarModelType.CompleteEnumeration:
				this.ShowGiftPackModelAvatarByCompleteEnumerationShow();
				break;
			}
		}

		// Token: 0x0600E5A5 RID: 58789 RVA: 0x003BD6F0 File Offset: 0x003BBAF0
		private void ShowGiftPackModelAvatarBySingleShow()
		{
			ItemTable itemTable = this._giftPackShowItemTableList[0];
			this.UpdateOneItemTableInPackGift(itemTable);
		}

		// Token: 0x0600E5A6 RID: 58790 RVA: 0x003BD714 File Offset: 0x003BBB14
		private void ShowGiftPackModelAvatarByCombinationShow()
		{
			this.InitPlayerAvatar();
			this.TakeOffFashionItemInPlayerModel(this._isOwnerCompleteShowType);
			for (int i = 0; i < this._giftPackShowItemTableList.Count; i++)
			{
				ItemTable itemTable = this._giftPackShowItemTableList[i];
				if (itemTable != null)
				{
					this.UpdateModelAvatarByItemTable(itemTable);
				}
			}
		}

		// Token: 0x0600E5A7 RID: 58791 RVA: 0x003BD770 File Offset: 0x003BBB70
		private void ShowGiftPackModelAvatarByEnumerationShow()
		{
			if (this.avatarChangeRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.avatarChangeRoot, true);
			if (this._itemTipModelAvatarEnumerationController == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.avatarChangeRoot);
				if (gameObject != null)
				{
					this._itemTipModelAvatarEnumerationController = gameObject.GetComponent<ItemTipModelAvatarEnumerationController>();
				}
				if (this._itemTipModelAvatarEnumerationController != null)
				{
					this._itemTipModelAvatarEnumerationController.InitController(this._giftPackShowItemTableList, this._giftPackSelectItemTableIndex, new OnItemTipModelAvatarEnumerationItemClick(this.OnItemPageChangeActionInItemEnumerationType));
				}
			}
			else
			{
				this._itemTipModelAvatarEnumerationController.OnEnableController(this._giftPackSelectItemTableIndex);
			}
			this.UpdateModelAvatarInItemEnumerationType();
		}

		// Token: 0x0600E5A8 RID: 58792 RVA: 0x003BD820 File Offset: 0x003BBC20
		private void ShowGiftPackModelAvatarByMatchingShow()
		{
			int count = this._giftPackShowItemTableList.Count;
			this.InitPlayerAvatar();
			this.TakeOffFashionItemInPlayerModel(this._isOwnerCompleteShowType);
			for (int i = 0; i < count - 1; i++)
			{
				ItemTable itemTable = this._giftPackShowItemTableList[i];
				if (itemTable != null)
				{
					this.UpdateModelAvatarByItemTable(itemTable);
				}
			}
			ItemTable itemTable2 = this._giftPackShowItemTableList[count - 1];
			this.ShowMatchingTypePetAvatar(itemTable2);
		}

		// Token: 0x0600E5A9 RID: 58793 RVA: 0x003BD894 File Offset: 0x003BBC94
		private void ShowGiftPackModelAvatarByCompleteEnumerationShow()
		{
			if (this.avatarChangeRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.avatarChangeRoot, true);
			if (this._itemTipModelAvatarEnumerationController == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.avatarChangeRoot);
				if (gameObject != null)
				{
					this._itemTipModelAvatarEnumerationController = gameObject.GetComponent<ItemTipModelAvatarEnumerationController>();
				}
				if (this._itemTipModelAvatarEnumerationController != null)
				{
					this._itemTipModelAvatarEnumerationController.InitController(this._giftPackShowItemTableList, this._giftPackSelectItemTableIndex, new OnItemTipModelAvatarEnumerationItemClick(this.OnGiftPackPageChangeActionInGiftPackEnumerationType));
				}
			}
			else
			{
				this._itemTipModelAvatarEnumerationController.OnEnableController(this._giftPackSelectItemTableIndex);
			}
			this.UpdateModelAvatarInGiftPackEnumerationType();
		}

		// Token: 0x0600E5AA RID: 58794 RVA: 0x003BD944 File Offset: 0x003BBD44
		private void UpdateModelAvatarByItemTable(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			if (itemTable.Type == ItemTable.eType.HEAD_FRAME)
			{
				return;
			}
			if (itemTable.Type == ItemTable.eType.VirtualPack)
			{
				return;
			}
			if (itemTable.SubType == ItemTable.eSubType.PetEgg || itemTable.SubType == ItemTable.eSubType.GiftPackage)
			{
				return;
			}
			if (itemTable.SubType == ItemTable.eSubType.TITLE)
			{
				this.InitPlayerTitle(itemTable);
			}
			else
			{
				this.RefreshPlayerAvatar(itemTable);
			}
		}

		// Token: 0x0600E5AB RID: 58795 RVA: 0x003BD9B0 File Offset: 0x003BBDB0
		private void RefreshPlayerAvatar(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_HAIR)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.geAvatarRenderEx, itemTable.ID, null, false);
			}
			else if (itemTable.SubType == ItemTable.eSubType.FASHION_AURAS)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipHalo(this.geAvatarRenderEx, itemTable.ID, null, false, false);
			}
			else if (itemTable.SubType == ItemTable.eSubType.WEAPON)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarShowWeaponStrengthen(this.geAvatarRenderEx, 0, null, false);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.geAvatarRenderEx, DataManager<PlayerBaseData>.GetInstance().JobTableID, itemTable.ID, null, false);
			}
			else if (itemTable.SubType == ItemTable.eSubType.FASHION_WEAPON)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.geAvatarRenderEx, DataManager<PlayerBaseData>.GetInstance().JobTableID, itemTable.ID, null, false);
			}
			else
			{
				EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(itemTable);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.geAvatarRenderEx, equipSlotType, 0, null, 0, false);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.geAvatarRenderEx, equipSlotType, itemTable.ID, null, 0, false);
			}
			this.geAvatarRenderEx.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600E5AC RID: 58796 RVA: 0x003BDADF File Offset: 0x003BBEDF
		private void OnGiftPackPageChangeActionInGiftPackEnumerationType(int selectedIndex)
		{
			if (this._giftPackSelectItemTableIndex == selectedIndex)
			{
				return;
			}
			this._giftPackSelectItemTableIndex = selectedIndex;
			this.UpdateModelAvatarInGiftPackEnumerationType();
		}

		// Token: 0x0600E5AD RID: 58797 RVA: 0x003BDAFC File Offset: 0x003BBEFC
		private void UpdateModelAvatarInGiftPackEnumerationType()
		{
			CommonUtility.UpdateGameObjectVisible(this.itemTitleRoot, false);
			CommonUtility.UpdateTextVisible(this.itemNameLabel, false);
			int num = this._giftPackSelectItemTableIndex - 1;
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= this._giftPackShowItemTableList.Count)
			{
				num = this._giftPackShowItemTableList.Count - 1;
			}
			ItemTable itemTable = this._giftPackShowItemTableList[num];
			if (itemTable == null)
			{
				return;
			}
			bool isOwnerCompleteShowType = false;
			List<ItemTable> finalGiftPackShowItemTableList = ItemDataUtility.GetFinalGiftPackShowItemTableList(itemTable.PackageID, GiftPackTable.eShowAvatarModelType.CompleteEnumeration, out isOwnerCompleteShowType);
			this.InitPlayerName(itemTable);
			this.InitPlayerAvatar();
			this.TakeOffFashionItemInPlayerModel(isOwnerCompleteShowType);
			for (int i = 0; i < finalGiftPackShowItemTableList.Count; i++)
			{
				ItemTable itemTable2 = finalGiftPackShowItemTableList[i];
				if (itemTable2 != null)
				{
					this.UpdateModelAvatarByItemTable(itemTable2);
				}
			}
		}

		// Token: 0x0600E5AE RID: 58798 RVA: 0x003BDBC9 File Offset: 0x003BBFC9
		private void OnItemPageChangeActionInItemEnumerationType(int selectedIndex)
		{
			if (this._giftPackSelectItemTableIndex == selectedIndex)
			{
				return;
			}
			this._giftPackSelectItemTableIndex = selectedIndex;
			this.UpdateModelAvatarInItemEnumerationType();
		}

		// Token: 0x0600E5AF RID: 58799 RVA: 0x003BDBE8 File Offset: 0x003BBFE8
		private void UpdateModelAvatarInItemEnumerationType()
		{
			CommonUtility.UpdateGameObjectVisible(this.itemTitleRoot, false);
			int num = this._giftPackSelectItemTableIndex - 1;
			if (num < 0)
			{
				num = 0;
			}
			else if (num >= this._giftPackShowItemTableList.Count)
			{
				num = this._giftPackShowItemTableList.Count - 1;
			}
			ItemTable itemTable = this._giftPackShowItemTableList[num];
			this.UpdateOneItemTableInPackGift(itemTable);
		}

		// Token: 0x0600E5B0 RID: 58800 RVA: 0x003BDC4B File Offset: 0x003BC04B
		private void UpdateOneItemTableInPackGift(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return;
			}
			if (itemTable.SubType == ItemTable.eSubType.PetEgg)
			{
				this.InitPetAvatar(itemTable);
			}
			else
			{
				this.UpdateSelfPlayerByItemTable(itemTable);
			}
		}

		// Token: 0x0600E5B1 RID: 58801 RVA: 0x003BDC74 File Offset: 0x003BC074
		private void ShowMatchingTypePetAvatar(ItemTable itemTable)
		{
			if (this.followPetAvatarRoot == null)
			{
				return;
			}
			if (itemTable == null)
			{
				return;
			}
			if (itemTable.SubType != ItemTable.eSubType.PetEgg)
			{
				return;
			}
			int petIdByItemTable = ItemDataUtility.GetPetIdByItemTable(itemTable);
			CommonUtility.UpdateGameObjectVisible(this.followPetAvatarRoot, true);
			if (this._followPetAvatarEx == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.followPetAvatarRoot);
				if (gameObject != null)
				{
					this._followPetAvatarEx = gameObject.GetComponent<GeAvatarRendererEx>();
				}
			}
			if (this._followPetAvatarEx == null)
			{
				return;
			}
			if (this._itemTipModelAvatarLayerIndex < DataManager<ItemTipManager>.GetInstance().ItemTipModelAvatarMaxLayerIndex)
			{
				this._followPetAvatarEx.m_Layer = this._itemTipModelAvatarLayerIndex + 1;
			}
			else
			{
				this._followPetAvatarEx.m_Layer = this._itemTipModelAvatarLayerIndex - 1;
			}
			PlayerUtility.LoadPetAvatarRenderEx(petIdByItemTable, this._followPetAvatarEx, false);
		}

		// Token: 0x0600E5B2 RID: 58802 RVA: 0x003BDD50 File Offset: 0x003BC150
		public void ResetModelAvatarEx()
		{
			if (this.geAvatarRenderEx != null)
			{
				this.geAvatarRenderEx.m_Layer = DataManager<ItemTipManager>.GetInstance().ItemTipModelAvatarBaseLayerIndex;
				this.geAvatarRenderEx.ClearAvatar();
			}
			if (this._followPetAvatarEx != null)
			{
				this._followPetAvatarEx.m_Layer = DataManager<ItemTipManager>.GetInstance().ItemTipModelAvatarBaseLayerIndex;
				this._followPetAvatarEx.ClearAvatar();
			}
		}

		// Token: 0x0600E5B3 RID: 58803 RVA: 0x003BDDC0 File Offset: 0x003BC1C0
		private void TakeOffFashionItemInPlayerModel(bool isOwnerCompleteShowType)
		{
			if (!isOwnerCompleteShowType)
			{
				return;
			}
			PlayerAvatar avatar = DataManager<PlayerBaseData>.GetInstance().avatar;
			if (avatar == null)
			{
				return;
			}
			uint[] equipItemIds = avatar.equipItemIds;
			if (equipItemIds == null || equipItemIds.Length <= 0)
			{
				return;
			}
			foreach (int id in equipItemIds)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(tableItem);
					if (equipSlotType != EFashionWearSlotType.Weapon && equipSlotType != EFashionWearSlotType.Invalid)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.geAvatarRenderEx, equipSlotType, 0, null, 0, false);
					}
				}
			}
		}

		// Token: 0x04008B00 RID: 35584
		private ItemTable _clickedItemTable;

		// Token: 0x04008B01 RID: 35585
		private int _itemTipModelAvatarLayerIndex;

		// Token: 0x04008B02 RID: 35586
		private GiftPackTable.eShowAvatarModelType _giftPackShowModelAvatarType;

		// Token: 0x04008B03 RID: 35587
		private List<ItemTable> _giftPackShowItemTableList;

		// Token: 0x04008B04 RID: 35588
		private bool _isOwnerCompleteShowType;

		// Token: 0x04008B05 RID: 35589
		private int _otherPlayerProfessionId;

		// Token: 0x04008B06 RID: 35590
		private List<int> _otherPlayerProfessionIdList;

		// Token: 0x04008B07 RID: 35591
		private int _otherPlayerProfessionIdIndex = 1;

		// Token: 0x04008B08 RID: 35592
		private int _mixPlayerProfessionId;

		// Token: 0x04008B09 RID: 35593
		private List<int> _mixPlayerProfessionIdList;

		// Token: 0x04008B0A RID: 35594
		private int _mixPlayerProfessionIdIndex = 1;

		// Token: 0x04008B0B RID: 35595
		private GeAvatarRendererEx _followPetAvatarEx;

		// Token: 0x04008B0C RID: 35596
		private int _giftPackSelectItemTableIndex = 1;

		// Token: 0x04008B0D RID: 35597
		private ItemTipModelAvatarEnumerationController _itemTipModelAvatarEnumerationController;

		// Token: 0x04008B0E RID: 35598
		[Space(10f)]
		[Header("ItemName")]
		[SerializeField]
		private Text itemNameLabel;

		// Token: 0x04008B0F RID: 35599
		[Space(10f)]
		[Header("ItemTitle")]
		[SerializeField]
		private GameObject itemTitleRoot;

		// Token: 0x04008B10 RID: 35600
		[SerializeField]
		private SpriteAniRenderChenghao spriteAniRenderChangeHao;

		// Token: 0x04008B11 RID: 35601
		[SerializeField]
		private Image spriteAniImage;

		// Token: 0x04008B12 RID: 35602
		[Space(10f)]
		[Header("GeAvatar")]
		[SerializeField]
		private GeAvatarRendererEx geAvatarRenderEx;

		// Token: 0x04008B13 RID: 35603
		[Space(10f)]
		[Header("followPet")]
		[SerializeField]
		private GameObject followPetAvatarRoot;

		// Token: 0x04008B14 RID: 35604
		[Space(10f)]
		[Header("ChangeAvatarButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject avatarChangeRoot;
	}
}
