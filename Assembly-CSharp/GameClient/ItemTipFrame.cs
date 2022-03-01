using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016E6 RID: 5862
	internal class ItemTipFrame : ClientFrame
	{
		// Token: 0x0600E546 RID: 58694 RVA: 0x003B9171 File Offset: 0x003B7571
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/ItemTip";
		}

		// Token: 0x0600E547 RID: 58695 RVA: 0x003B9178 File Offset: 0x003B7578
		private void _InitAlign(TextAnchor eTextAnchor)
		{
			RectTransform component = this.m_objTipRoot.GetComponent<RectTransform>();
			if (eTextAnchor != 3)
			{
				if (eTextAnchor != 4)
				{
					if (eTextAnchor == 5)
					{
						component.anchorMin = new Vector2(0.97f, 0.5f);
						component.anchorMax = new Vector2(0.97f, 0.5f);
						component.pivot = new Vector2(1f, 0.5f);
					}
				}
				else
				{
					component.anchorMin = new Vector2(0.5f, 0.5f);
					component.anchorMax = new Vector2(0.5f, 0.5f);
					component.pivot = new Vector2(0.5f, 0.5f);
				}
			}
			else
			{
				component.anchorMin = new Vector2(0.03f, 0.5f);
				component.anchorMax = new Vector2(0f, 0.5f);
				component.pivot = new Vector2(0f, 0.5f);
			}
		}

		// Token: 0x0600E548 RID: 58696 RVA: 0x003B9278 File Offset: 0x003B7678
		private void _InitOthers()
		{
			this.m_objTipTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_hTwoLabelsTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_leftLabelTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_rightLabelTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_groupTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_imageTemplate.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_objCommonItemInfoRoot.transform.SetParent(this.m_objTemplateGroup.transform, false);
			this.m_objTemplateGroup.SetActive(false);
			this.m_objFuncBtnPrefab.SetActive(false);
			this.m_objFuncSpecial.SetActive(false);
			this.m_objFuncBtnRoot.SetActive(false);
			this.m_objCommonItemInfoRoot.SetActive(false);
		}

		// Token: 0x0600E549 RID: 58697 RVA: 0x003B9388 File Offset: 0x003B7788
		private void _InitItemTipsData(ItemTipData tipData)
		{
			if (tipData == null)
			{
				return;
			}
			this.data = tipData;
			this._InitAlign(tipData.textAnchor);
			this._SetupTip(this.m_objTipTemplate, tipData.item, tipData.compareItem, tipData.itemSuitObj);
			if (tipData.compareItem != null)
			{
				this.compareItemContentGo = Object.Instantiate<GameObject>(this.m_objTipTemplate);
				if (tipData.item.SubType == 1)
				{
					this.SetSwitchBtn(this.compareItemContentGo);
				}
				this._SetupTip(this.compareItemContentGo, tipData.compareItem, null, tipData.compareItemSuitObj);
			}
			this._SetupFunc(tipData.item, tipData.funcs, tipData.nTipIndex);
			Button component = this.frame.GetComponent<Button>();
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate()
			{
				DataManager<ItemTipManager>.GetInstance().CloseTip(tipData.nTipIndex);
			});
			this.RegisterItemTipEvents();
			this.InitItemTipModelAvatarContent(tipData);
		}

		// Token: 0x0600E54A RID: 58698 RVA: 0x003B94C8 File Offset: 0x003B78C8
		private void RegisterItemTipEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnItemRemoved));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnItemUseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoreAndMoreBtnHandle, new ClientEventSystem.UIEventHandler(this._OnMoreAndMoreClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._ItemSellSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveItemTipFrameOpenMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveItemTipFrameOpenMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveItemTipFrameCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveItemTipFrameCloseMessage));
		}

		// Token: 0x0600E54B RID: 58699 RVA: 0x003B9594 File Offset: 0x003B7994
		private void UnRegisterItemTipEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnItemRemoved));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnItemUseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoreAndMoreBtnHandle, new ClientEventSystem.UIEventHandler(this._OnMoreAndMoreClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._ItemSellSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveItemTipFrameOpenMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveItemTipFrameOpenMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveItemTipFrameCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveItemTipFrameCloseMessage));
		}

		// Token: 0x0600E54C RID: 58700 RVA: 0x003B9660 File Offset: 0x003B7A60
		private void _InitPetTipsData(ItemTipPetData petData)
		{
			if (petData == null)
			{
				return;
			}
			this._InitAlign(petData.textAnchor);
			if (petData.compareItem != null)
			{
				this._SetupPetTip(this.m_objTipRoot, petData.compareItem, 9528);
			}
			if (petData.item != null)
			{
				this._SetupPetTip(this.m_objTipRoot, petData.item, 9527);
			}
			Button component = this.frame.GetComponent<Button>();
			component.onClick.RemoveAllListeners();
			component.onClick.AddListener(delegate()
			{
				DataManager<ItemTipManager>.GetInstance().CloseTip(petData.nTipIndex);
			});
		}

		// Token: 0x0600E54D RID: 58701 RVA: 0x003B9720 File Offset: 0x003B7B20
		private void SetSwitchBtn(GameObject instanceObj)
		{
			if (instanceObj != null && !this.data.item.isInSidePack)
			{
				GameObject mainWeapon = Utility.FindChild(instanceObj, "mainWeapnBtn");
				GameObject sideWeapon = Utility.FindChild(instanceObj, "sideWeaponBtn");
				ulong mainWeapon2 = DataManager<ItemDataManager>.GetInstance().GetMainWeapon();
				if (mainWeapon2 > 0UL)
				{
					ItemData data = DataManager<ItemDataManager>.GetInstance().GetItem(mainWeapon2);
					if (data != null)
					{
						EquipSuitObj suitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(data.SuitID);
						mainWeapon.CustomActive(true);
						mainWeapon.GetComponent<Button>().onClick.AddListener(delegate()
						{
							this.SetBtnState(mainWeapon, sideWeapon, true);
							this._SetupTip(this.m_objTipTemplate, this.data.item, data, suitObj);
							this._SetupTip(this.compareItemContentGo, data, null, suitObj);
							Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("TipsMainWeapon");
						});
					}
				}
				Dictionary<byte, ulong> sideWeaponDic = DataManager<SwitchWeaponDataManager>.GetInstance().GetSideWeaponDic();
				if (sideWeaponDic.Count > 0)
				{
					ItemData data = DataManager<ItemDataManager>.GetInstance().GetItem(sideWeaponDic[0]);
					if (data != null)
					{
						EquipSuitObj suitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(data.SuitID);
						sideWeapon.CustomActive(true);
						sideWeapon.GetComponent<Button>().onClick.AddListener(delegate()
						{
							this.SetBtnState(mainWeapon, sideWeapon, false);
							this._SetupTip(this.m_objTipTemplate, this.data.item, data, suitObj);
							this._SetupTip(this.compareItemContentGo, data, null, suitObj);
							Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("TipsSideWeapon");
						});
					}
				}
			}
		}

		// Token: 0x0600E54E RID: 58702 RVA: 0x003B98B8 File Offset: 0x003B7CB8
		private void SetBtnState(GameObject mainBtn, GameObject sideBtn, bool isMainBtn = true)
		{
			Image component = mainBtn.GetComponent<Image>();
			Image component2 = sideBtn.GetComponent<Image>();
			ETCImageLoader.LoadSprite(ref component, (!isMainBtn) ? this.unselectPath : this.selectPath, true);
			ETCImageLoader.LoadSprite(ref component2, (!isMainBtn) ? this.selectPath : this.unselectPath, true);
			Text componentInChildren = mainBtn.GetComponentInChildren<Text>();
			Text componentInChildren2 = sideBtn.GetComponentInChildren<Text>();
			componentInChildren.color = ((!isMainBtn) ? new Color(0.26666668f, 0.30980393f, 0.40784314f, 1f) : new Color(1f, 1f, 1f, 1f));
			componentInChildren2.color = ((!isMainBtn) ? new Color(1f, 1f, 1f, 1f) : new Color(0.26666668f, 0.30980393f, 0.40784314f, 1f));
		}

		// Token: 0x0600E54F RID: 58703 RVA: 0x003B99A8 File Offset: 0x003B7DA8
		private void _SetupPetTip(GameObject root, PetItemTipsData tipsData, int iID)
		{
			if (base._GetChildFrame(iID) == null)
			{
				IClientFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<PetItemTipsFrame>(root, tipsData, string.Format("PetItemTipsFrame_{0}", iID));
				base._AddChildFrame(iID, clientFrame);
			}
		}

		// Token: 0x0600E550 RID: 58704 RVA: 0x003B99E8 File Offset: 0x003B7DE8
		private void _UnInitPetTipsData()
		{
		}

		// Token: 0x0600E551 RID: 58705 RVA: 0x003B99EC File Offset: 0x003B7DEC
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this.OnGetGiftData));
			this.InitItemTipModelAvatarData();
			this._InitOthers();
			this._InitItemTipsData(this.userData as ItemTipData);
			this._InitPetTipsData(this.userData as ItemTipPetData);
		}

		// Token: 0x0600E552 RID: 58706 RVA: 0x003B9A44 File Offset: 0x003B7E44
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this.OnGetGiftData));
			this.mVirtualPackContent.Clear();
			this.mExpendablePackContent.Clear();
			this.UnRegisterItemTipEvents();
			this.otherBtnFuncInfosGo = null;
			this.mItemTipsFuncOtherButton = null;
			this.bIsSelect = false;
			this.ResetItemTipModelAvatarData();
		}

		// Token: 0x0600E553 RID: 58707 RVA: 0x003B9AA4 File Offset: 0x003B7EA4
		private void _SetupTip(GameObject a_objTip, ItemData a_item, ItemData a_compareItem, EquipSuitObj a_suitObj)
		{
			if (a_objTip == null)
			{
				return;
			}
			a_objTip.transform.SetParent(this.m_objTipRoot.transform, false);
			a_objTip.transform.SetAsFirstSibling();
			float minHeight = this.m_heights[1];
			switch (a_item.Type)
			{
			case ItemTable.eType.EQUIP:
			case ItemTable.eType.FASHION:
			case ItemTable.eType.FUCKTITTLE:
				minHeight = this.m_heights[2];
				break;
			case ItemTable.eType.EXPENDABLE:
			case ItemTable.eType.PET:
			case ItemTable.eType.HEAD_FRAME:
			case ItemTable.eType.ITEM_NEWTITLE:
			case ItemTable.eType.ITEM_MONOPOLY_CARD:
				if (a_item.PackID > 0)
				{
					minHeight = this.m_heights[2];
				}
				else
				{
					minHeight = this.m_heights[1];
				}
				break;
			case ItemTable.eType.MATERIAL:
			case ItemTable.eType.TASK:
			case ItemTable.eType.INCOME:
			case ItemTable.eType.ENERGY:
				minHeight = this.m_heights[0];
				break;
			case ItemTable.eType.VirtualPack:
				minHeight = this.m_heights[1];
				break;
			}
			a_objTip.GetComponent<LayoutElement>().minHeight = minHeight;
			this._SetupContent(a_objTip, a_item, a_compareItem, a_suitObj);
		}

		// Token: 0x0600E554 RID: 58708 RVA: 0x003B9BAC File Offset: 0x003B7FAC
		private void _SetupItemTitle(GameObject a_objRoot, ItemData a_itemData, bool isShowItemParent = true)
		{
			if (null == a_objRoot)
			{
				return;
			}
			if (isShowItemParent)
			{
				GameObject gameObject = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content/itemParent", true);
				if (null != gameObject)
				{
					ComItem comItem = base.CreateComItem(gameObject);
					comItem.Setup(a_itemData, null);
					if (a_itemData != null && a_itemData.IsShowTreasureFlagInTipFrame)
					{
						comItem.SetShowTreasure(true);
					}
				}
			}
			Image image = Utility.FindComponent<Image>(a_objRoot, "Tittle", true);
			if (null != image && !string.IsNullOrEmpty(a_itemData.GetQualityTipTitleBackGround()))
			{
				ETCImageLoader.LoadSprite(ref image, a_itemData.GetQualityTipTitleBackGround(), true);
			}
			Utility.GetComponetInChild<Text>(a_objRoot, "Tittle/name").text = a_itemData.GetColorName(string.Empty, false);
			Utility.GetComponetInChild<Text>(a_objRoot, "Tittle/LevelLimit").text = a_itemData.GetLevelLimitDesc();
			Utility.FindGameObject(a_objRoot, "Tittle/mark", true).SetActive(a_itemData.PackageType == EPackageType.WearEquip || a_itemData.PackageType == EPackageType.WearFashion);
			Utility.GetComponetInChild<Text>(a_objRoot, "Tittle/rateScore").text = a_itemData.GetRateScoreDesc();
		}

		// Token: 0x0600E555 RID: 58709 RVA: 0x003B9CB8 File Offset: 0x003B80B8
		private void _SetupHTwoLabels(GameObject a_objRoot, string a_strLeft, string a_strRight)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_hTwoLabelsTemplate);
			Text component = Utility.FindGameObject(gameObject, "LeftLabel", true).GetComponent<Text>();
			component.text = a_strLeft;
			Text component2 = Utility.FindGameObject(gameObject, "RightLabel", true).GetComponent<Text>();
			component2.text = a_strRight;
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
		}

		// Token: 0x0600E556 RID: 58710 RVA: 0x003B9D1C File Offset: 0x003B811C
		private void _SetupLeftLabel(GameObject a_objRoot, string a_strLeft)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_leftLabelTemplate);
			Text component = gameObject.GetComponent<Text>();
			component.text = a_strLeft;
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
		}

		// Token: 0x0600E557 RID: 58711 RVA: 0x003B9D5C File Offset: 0x003B815C
		private void _SetupRightLabel(GameObject a_objRoot, string a_strRight)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_rightLabelTemplate);
			Text component = gameObject.GetComponent<Text>();
			component.text = a_strRight;
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
		}

		// Token: 0x0600E558 RID: 58712 RVA: 0x003B9D9C File Offset: 0x003B819C
		private void _realSetupLine(GameObject a_objRoot)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_imageTemplate);
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
		}

		// Token: 0x0600E559 RID: 58713 RVA: 0x003B9DCE File Offset: 0x003B81CE
		private void _SetupLine(GameObject a_objRoot)
		{
		}

		// Token: 0x0600E55A RID: 58714 RVA: 0x003B9DD0 File Offset: 0x003B81D0
		private void _SetupShowItems(GameObject a_objRoot, List<GiftPackItemData> a_arrGiftData, int packID = 0)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_showItemsTemplate);
			gameObject.transform.SetParent(this._SetupGroup(a_objRoot).transform, false);
			gameObject.SetActive(true);
			List<ItemData> arrItemData = new List<ItemData>();
			if (this.data.giftItemIsRequestServer)
			{
				for (int i = 0; i < a_arrGiftData.Count; i++)
				{
					if (a_arrGiftData[i].Levels.Count <= 0 || ((int)DataManager<PlayerBaseData>.GetInstance().Level >= a_arrGiftData[i].Levels[0] && (int)DataManager<PlayerBaseData>.GetInstance().Level <= a_arrGiftData[i].Levels[1]))
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(a_arrGiftData[i].ItemID, 100, a_arrGiftData[i].Strengthen);
						if (itemData != null)
						{
							itemData.Count = a_arrGiftData[i].ItemCount;
							itemData.EquipType = (EEquipType)a_arrGiftData[i].EquipType;
							itemData.IsTimeLimit = a_arrGiftData[i].IsTimeLimit;
							arrItemData.Add(itemData);
						}
					}
				}
			}
			else
			{
				arrItemData = ItemDataUtility.GetGiftItemDataList(packID, DataManager<PlayerBaseData>.GetInstance().JobTableID);
			}
			ComUIListScript component = gameObject.GetComponent<ComUIListScript>();
			component.Initialize();
			component.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			component.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (arrItemData != null && var.m_index >= 0 && var.m_index < arrItemData.Count)
				{
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(arrItemData[var.m_index], delegate(GameObject var1, ItemData var2)
					{
						if (this.data.giftItemIsRequestServer)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						}
						else
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, false);
						}
					});
					if (arrItemData[var.m_index] != null && arrItemData[var.m_index].IsShowTreasureFlagInTipFrame)
					{
						comItem.SetShowTreasure(true);
					}
					Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = arrItemData[var.m_index].GetColorName(string.Empty, false);
				}
			};
			component.SetElementAmount(arrItemData.Count);
		}

		// Token: 0x0600E55B RID: 58715 RVA: 0x003B9F94 File Offset: 0x003B8394
		private GameObject _SetupGroup(GameObject a_objRoot)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_groupTemplate);
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
			return gameObject;
		}

		// Token: 0x0600E55C RID: 58716 RVA: 0x003B9FC8 File Offset: 0x003B83C8
		private void _SetupContent(GameObject a_objRoot, ItemData a_item, ItemData a_compareItem, EquipSuitObj a_suitObj)
		{
			if (a_objRoot == null || a_item == null)
			{
				return;
			}
			GameObject a_obj = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._ClearContent(a_obj);
			switch (a_item.Type)
			{
			case ItemTable.eType.EQUIP:
				this._SetupEquipContent(a_objRoot, a_item, a_compareItem, a_suitObj);
				break;
			case ItemTable.eType.EXPENDABLE:
			case ItemTable.eType.PET:
			case ItemTable.eType.HEAD_FRAME:
			case ItemTable.eType.ITEM_NEWTITLE:
			case ItemTable.eType.ITEM_INSCRIPTION:
			case ItemTable.eType.ITEM_MONOPOLY_CARD:
				this._SetupExpendableConetnt(a_objRoot, a_item);
				break;
			case ItemTable.eType.MATERIAL:
				this._SetupMaterialContent(a_objRoot, a_item);
				break;
			case ItemTable.eType.TASK:
				this._SetupTaskContent(a_objRoot, a_item);
				break;
			case ItemTable.eType.FASHION:
				this._SetupFashionContent(a_objRoot, a_item, a_compareItem, a_suitObj);
				break;
			case ItemTable.eType.INCOME:
				this._SetupInComeContent(a_objRoot, a_item);
				break;
			case ItemTable.eType.ENERGY:
				this._SetupEnergyContent(a_objRoot, a_item);
				break;
			case ItemTable.eType.FUCKTITTLE:
				this._SetupTitleContent(a_objRoot, a_item, a_compareItem);
				break;
			case ItemTable.eType.VirtualPack:
				this._SetupVirtualPackContent(a_objRoot, a_item);
				break;
			}
		}

		// Token: 0x0600E55D RID: 58717 RVA: 0x003BA0D8 File Offset: 0x003B84D8
		private void _ClearContent(GameObject a_obj)
		{
			if (a_obj == null)
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(a_obj, "itemParent", true);
			for (int i = 0; i < a_obj.transform.childCount; i++)
			{
				if (gameObject != a_obj.transform.GetChild(i).gameObject)
				{
					Object.Destroy(a_obj.transform.GetChild(i).gameObject);
				}
			}
		}

		// Token: 0x0600E55E RID: 58718 RVA: 0x003BA150 File Offset: 0x003B8550
		private void _SetupEquipContent(GameObject a_objRoot, ItemData item, ItemData compareItem, EquipSuitObj suitObj)
		{
			this._SetupItemTitle(a_objRoot, item, true);
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			List<string> list = new List<string>();
			this._TryAddDescs(list, this._GetBaseMainPropDescs(item.BaseProp, (compareItem != null) ? compareItem.BaseProp : null, item));
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, item.GetEquipTypeDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "stretch");
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			List<string> list3 = new List<string>();
			this._TryAddDesc(list3, item.GetBindStateDesc());
			this._TryAddDesc(list3, item.GetBindStateOwnerDesc());
			this._TryAddDesc(list3, "stretch");
			List<string> fourAttrAndResistMagicDescs = item.GetFourAttrAndResistMagicDescs();
			this._TryAddDescs(list3, fourAttrAndResistMagicDescs);
			List<string> list4 = new List<string>();
			if (this.data.giftItemIsRequestServer)
			{
				this._TryAddDesc(list4, item.GetRateScoreDesc());
			}
			this._TryAddDesc(list4, item.GetItemAuctionCoolTimeDesc());
			this._TryAddDesc(list4, item.GetTransactionNumberDesc());
			this._TryAddDesc(list4, item.GetOccupationLimitDesc());
			this._TryAddDesc(list4, "stretch");
			this._TryAddDesc(list4, item.GetEquipGradeDesc());
			this._TryAddDesc(list4, item.GetLevelLimitDesc());
			this._TryAddDesc(list4, item.GetEquipUpgradeDesc());
			this._TryAddDesc(list4, item.GetStoreDesc());
			this._TryShowDescsOnBothSide(a_objRoot2, list3, list4);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetTimeLeftDesc(), true);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetBreathEquipDesc(), true);
			this._TryShowDescsOnLeftSide(a_objRoot2, item.GetStrengthenDescs());
			this.InitBeadAttr(a_objRoot2, item);
			this.InitEnchantmentAttr(a_objRoot2, item);
			this.InitInscripotionAttr(a_objRoot2, item);
			this._TryShowDescsOnLeftSide(a_objRoot2, item.GetRandomAttrDescs());
			this._TryShowDescsOnLeftSide(a_objRoot2, item.GetAttachAttrDescs());
			this._TryShowDescsOnLeftSide(a_objRoot2, item.GetComplexAttrDescs());
			this._TryShowDescsOnLeftSide(a_objRoot2, item.GetMasterAttrDescs(true));
			this._SetupSuitContent(a_objRoot2, item, suitObj);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetSourceDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, item.GetPriceDesc(), true);
		}

		// Token: 0x0600E55F RID: 58719 RVA: 0x003BA394 File Offset: 0x003B8794
		private void _SetupExpendableConetnt(GameObject a_objRoot, ItemData a_item)
		{
			GameObject gameObject = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			if (a_item.SubType == 25 || a_item.SubType == 54 || a_item.SubType == 117)
			{
				this._SetupItemTitle(a_objRoot, a_item, true);
				List<string> list = new List<string>();
				this._TryAddDesc(list, a_item.GetSubTypeDesc());
				if (a_item.SubType == 54)
				{
					this._TryAddDesc(list, string.Format("类型：{0}", a_item.GetBeadTypeDesc()));
				}
				this._TryAddDesc(list, "stretch");
				this._TryAddDesc(list, a_item.GetTimeLeftDesc());
				this._TryAddDesc(list, a_item.GetUseTimePerDayDesc());
				this._TryAddDesc(list, a_item.GetBindStateDesc());
				this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
				this._TryAddDesc(list, a_item.GetCoolTimeDesc());
				this._TryAddDesc(list, a_item.GetMaxStackCountDesc());
				this._TryAddDesc(list, a_item.GetExpendableLimitDesc());
				List<string> list2 = new List<string>();
				this._TryAddDesc(list2, " ");
				this._TryAddDesc(list2, " ");
				this._TryAddDesc(list2, " ");
				this._TryAddDesc(list2, a_item.GetOccupationLimitDesc());
				this._TryAddDesc(list2, "stretch");
				this._TryAddDesc(list2, a_item.GetLevelLimitDesc());
				this._TryAddDesc(list2, a_item.GetItemAuctionCoolTimeDesc());
				this._TryAddDesc(list2, a_item.GetTransactionNumberDesc());
				this._TryAddDesc(list2, a_item.GetStoreDesc());
				this._TryShowDescsOnBothSide(gameObject, list, list2);
				this._realSetupLine(gameObject);
				List<string> list3 = new List<string>();
				this._TryAddDesc(list3, a_item.GetMagicPartDesc());
				this._TryAddDesc(list3, "stretch");
				List<string> list4 = new List<string>();
				this._TryAddDesc(list4, a_item.GetEnchantmentCardUpgradeDesce());
				this._TryAddDesc(list4, "stretch");
				this._TryShowDescsOnBothSide(gameObject, list3, list4);
				this._TryShowDescOnLeftSide(gameObject, DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(a_item.TableID, a_item.mPrecEnchantmentCard.iEnchantmentCardLevel, true), true);
				List<string> list5 = new List<string>();
				this._TryAddDesc(list5, a_item.GetBeadPartDesc());
				this._TryAddDesc(list5, "stretch");
				List<string> list6 = new List<string>();
				this._TryAddDesc(list6, "stretch");
				this._TryShowDescsOnBothSide(gameObject, list5, list6);
				this._TryShowDescOnLeftSide(gameObject, DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(a_item.TableID, false), true);
				if (a_item.SubType == 117)
				{
					List<string> list7 = new List<string>();
					this._TryAddDesc(list7, a_item.InscriptionMosaicSlot());
					this._TryAddDesc(list7, a_item.GetInscriptionApplicableToProfessionalDescription());
					this._TryAddDesc(list7, "stretch");
					List<string> list8 = new List<string>();
					this._TryAddDesc(list8, "stretch");
					this._TryShowDescsOnBothSide(gameObject, list7, list8);
					string text = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(a_item.TableID, true);
					text += TR.Value("tip_inscription_attrdesc");
					this._TryShowDescOnLeftSide(gameObject, text, true);
				}
				this._TryShowDescOnLeftSide(gameObject, a_item.GetDeadTimestampDesc(), true);
				this._TryShowDescOnLeftSide(gameObject, a_item.GetDescription(), true);
				this._TryShowDescOnLeftSide(gameObject, a_item.GetSourceDescription(), true);
				this._TryShowDescOnLeftSide(gameObject, DataManager<BeadCardManager>.GetInstance().GetBeadPickRemainNumber(a_item.TableID, a_item.BeadPickNumber), true);
				this._TryShowDescOnLeftSide(gameObject, DataManager<BeadCardManager>.GetInstance().GetBeadReplaceRemainNumber(a_item.TableID, a_item.BeadReplaceNumber), true);
				this._TryShowDescOnLeftSide(gameObject, a_item.GetPriceDesc(), true);
			}
			else
			{
				this._SetupItemTitle(a_objRoot, a_item, true);
				List<string> list9 = new List<string>();
				this._TryAddDesc(list9, a_item.GetItemTypeDesc());
				this._TryAddDesc(list9, " ");
				this._TryAddDesc(list9, "stretch");
				this._TryAddDesc(list9, a_item.GetTimeLeftDesc());
				this._TryAddDesc(list9, a_item.GetBindStateDesc());
				this._TryAddDesc(list9, a_item.GetBindStateOwnerDesc());
				this._TryAddDesc(list9, a_item.GetMaxStackCountDesc());
				this._TryAddDesc(list9, a_item.GetUseTimeDesc());
				if (!a_item.IsOccupationFit())
				{
					this._TryAddDesc(list9, " ");
				}
				if (a_item.SubType == 41 || a_item.SubType == 118 || a_item.ThirdType == ItemTable.eThirdType.LevelShow || a_item.SubType == 86)
				{
					this._TryAddDesc(list9, a_item.GetExperiencePillLevelLimitDesc());
				}
				else if (a_item.Type != ItemTable.eType.ITEM_MONOPOLY_CARD)
				{
					this._TryAddDesc(list9, a_item.GetLevelLimitDesc());
				}
				List<string> list10 = new List<string>();
				this._TryAddDesc(list10, " ");
				this._TryAddDesc(list10, " ");
				this._TryAddDesc(list10, " ");
				if (!a_item.IsOccupationFit())
				{
					this._TryAddDesc(list10, " ");
				}
				this._TryAddDesc(list10, a_item.GetRemainUseNumberDesc());
				this._TryAddDesc(list10, a_item.GetOccupationLimitDesc());
				this._TryAddDesc(list10, "stretch");
				this._TryAddDesc(list10, a_item.GetItemAuctionCoolTimeDesc());
				this._TryAddDesc(list10, a_item.GetTransactionNumberDesc());
				if (a_item.Type != ItemTable.eType.ITEM_MONOPOLY_CARD)
				{
					this._TryAddDesc(list10, a_item.GetStoreDesc());
				}
				this._TryShowDescsOnBothSide(gameObject, list9, list10);
				this._realSetupLine(gameObject);
				this._TryShowDescsOnLeftSide(gameObject, a_item.GetComplexAttrDescs());
				this._TryShowDescOnLeftSide(gameObject, a_item.GetDeadTimestampDesc(), true);
				this._TryShowDescOnLeftSide(gameObject, a_item.GetDescription(), true);
				if (a_item.SubType == 44)
				{
					foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PetTable>())
					{
						PetTable petTable = keyValuePair.Value as PetTable;
						if (petTable != null && petTable.PetEggID == a_item.TableID)
						{
							this._TryShowDescOnLeftSide(gameObject, DataManager<PetDataManager>.GetInstance().GetPetPropertyTips(petTable, petTable.MaxLv), true);
							this._TryShowDescOnLeftSide(gameObject, DataManager<PetDataManager>.GetInstance().GetPetCurSkillTips(petTable, DataManager<PlayerBaseData>.GetInstance().JobTableID, 0, petTable.MaxLv, true), true);
							this._TryShowDescOnLeftSide(gameObject, DataManager<PetDataManager>.GetInstance().GetCanSelectSkillTips(petTable, DataManager<PlayerBaseData>.GetInstance().JobTableID, 0, petTable.MaxLv), true);
							break;
						}
					}
				}
				if (a_item.PackID > 0)
				{
					if (this.data.giftItemIsRequestServer)
					{
						this.mExpendablePackContent.Add(new KeyValuePair<int, GameObject>(a_item.PackID, gameObject));
						DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(a_item.PackID);
					}
					else
					{
						this._SetupShowItems(gameObject, new List<GiftPackItemData>(), a_item.PackID);
					}
				}
				this._TryShowDescOnLeftSide(gameObject, a_item.GetSourceDescription(), true);
				this._TryShowDescOnLeftSide(gameObject, a_item.GetPriceDesc(), true);
			}
		}

		// Token: 0x0600E560 RID: 58720 RVA: 0x003BA9F0 File Offset: 0x003B8DF0
		private void _SetupMaterialContent(GameObject a_objRoot, ItemData a_item)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetTimeLeftDesc());
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			this._TryAddDesc(list, a_item.GetMaxStackCountDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, a_item.GetOccupationLimitDesc());
			this._TryAddDesc(list2, a_item.GetItemAuctionCoolTimeDesc());
			this._TryAddDesc(list2, a_item.GetTransactionNumberDesc());
			this._TryAddDesc(list2, "stretch");
			if (a_item.SubType != 158)
			{
				this._TryAddDesc(list2, a_item.GetStoreDesc());
			}
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetPriceDesc(), true);
		}

		// Token: 0x0600E561 RID: 58721 RVA: 0x003BAB40 File Offset: 0x003B8F40
		private void _SetupTaskContent(GameObject a_objRoot, ItemData a_item)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetTimeLeftDesc());
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			this._TryAddDesc(list, a_item.GetMaxStackCountDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, a_item.GetOccupationLimitDesc());
			this._TryAddDesc(list2, "stretch");
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetPriceDesc(), true);
		}

		// Token: 0x0600E562 RID: 58722 RVA: 0x003BAC50 File Offset: 0x003B9050
		private void _SetupFashionContent(GameObject a_objRoot, ItemData a_item, ItemData a_compareItem, EquipSuitObj a_suitObj)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			bool hasFashionAttribute = a_item.HasFashionAttribute;
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, a_item.GetTimeLeftDesc());
			this._TryAddDesc(list, a_item.GetSubTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			if (a_item.FashionFreeTimes <= 0 && a_item.HasFashionAttribute)
			{
				this._TryAddDesc(list, a_item.GetFasionFreeTimesDesc());
			}
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "stretch");
			this._TryAddDesc(list2, a_item.GetRateScoreDesc());
			this._TryAddDesc(list2, a_item.GetOccupationLimitDesc());
			this._TryAddDesc(list2, a_item.GetStoreDesc());
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			if (!hasFashionAttribute)
			{
				this._TryShowDescsOnLeftSide(a_objRoot2, this._GetBaseMainPropDescs(a_item.BaseProp, (a_compareItem != null) ? a_compareItem.BaseProp : null, null));
				this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetStrengthenDescs());
				if (!hasFashionAttribute)
				{
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetFourAttrDescs());
				}
				if (!hasFashionAttribute)
				{
				}
				if (!hasFashionAttribute)
				{
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetAttachAttrDescs());
				}
				this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetComplexAttrDescs());
			}
			else
			{
				this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetStrengthenDescs());
				if (a_item.FashionWearSlotType == EFashionWearSlotType.Auras)
				{
					this._TryShowDescsOnLeftSide(a_objRoot2, this._GetBaseMainPropDescs(a_item.BaseProp, (a_compareItem != null) ? a_compareItem.BaseProp : null, null));
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetFourAttrDescs());
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetSkillMPAndCDDescs());
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetAttachAttrDescs());
					this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetComplexAttrDescs());
				}
				this._SetupFashionAttributeContent(a_objRoot2, a_item);
			}
			this._SetupSuitContent(a_objRoot2, a_item, a_suitObj);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
		}

		// Token: 0x0600E563 RID: 58723 RVA: 0x003BAEA8 File Offset: 0x003B92A8
		private void _SetupFashionAttributeContent(GameObject a_objRoot, ItemData a_item)
		{
			if (a_item.HasFashionAttribute)
			{
				EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(a_item.FashionAttributeID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string attributesDesc = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(a_item.FashionAttributeID, "fashion_attribute_color", string.Empty);
					if (!string.IsNullOrEmpty(attributesDesc))
					{
						this._SetupLine(a_objRoot);
						GameObject a_objRoot2 = this._SetupGroup(a_objRoot);
						string text = TR.Value("color_blue", TR.Value("fashion_cur_attribute_title"));
						if (!string.IsNullOrEmpty(text))
						{
							this._SetupLeftLabel(a_objRoot2, text);
							this._SetupLeftLabel(a_objRoot2, attributesDesc);
						}
					}
				}
			}
			if (a_item.fashionAttributes != null && a_item.fashionAttributes.Count > 0)
			{
				this._SetupLine(a_objRoot);
				GameObject a_objRoot3 = this._SetupGroup(a_objRoot);
				string text2 = TR.Value("color_blue", TR.Value("fashion_selected_attribute_title"));
				if (!string.IsNullOrEmpty(text2))
				{
					this._SetupLeftLabel(a_objRoot3, text2);
				}
				for (int i = 0; i < a_item.fashionAttributes.Count; i++)
				{
					string attributesDesc2 = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(a_item.fashionAttributes[i].ID, "fashion_attribute_color", string.Empty);
					if (!string.IsNullOrEmpty(attributesDesc2))
					{
						this._SetupLeftLabel(a_objRoot3, attributesDesc2);
					}
				}
			}
		}

		// Token: 0x0600E564 RID: 58724 RVA: 0x003BAFFC File Offset: 0x003B93FC
		private void _SetupEnergyContent(GameObject a_objRoot, ItemData a_item)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "stretch");
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
		}

		// Token: 0x0600E565 RID: 58725 RVA: 0x003BB0C8 File Offset: 0x003B94C8
		private void _SetupTitleContent(GameObject a_objRoot, ItemData a_item, ItemData a_compareItem)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, a_item.GetTimeLeftDesc());
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "<size=40> </size>");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "stretch");
			this._TryAddDesc(list2, a_item.GetRateScoreDesc());
			this._TryAddDesc(list2, a_item.GetOccupationLimitDesc());
			this._TryAddDesc(list2, a_item.GetTransactionNumberDesc());
			this._TryAddDesc(list2, a_item.GetStoreDesc());
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescsOnLeftSide(a_objRoot2, this._GetBaseMainPropDescs(a_item.BaseProp, (a_compareItem != null) ? a_compareItem.BaseProp : null, null));
			this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetStrengthenDescs());
			List<string> fourAttrAndResistMagicDescs = a_item.GetFourAttrAndResistMagicDescs();
			this._TryShowDescsOnLeftSide(a_objRoot2, fourAttrAndResistMagicDescs);
			this.InitBeadAttr(a_objRoot2, a_item);
			this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetAttachAttrDescs());
			this._TryShowDescsOnLeftSide(a_objRoot2, a_item.GetComplexAttrDescs());
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
		}

		// Token: 0x0600E566 RID: 58726 RVA: 0x003BB248 File Offset: 0x003B9648
		private void _SetupInComeContent(GameObject a_objRoot, ItemData a_item)
		{
			GameObject a_objRoot2 = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, true);
			List<string> list = new List<string>();
			this._TryAddDesc(list, a_item.GetItemTypeDesc());
			this._TryAddDesc(list, " ");
			this._TryAddDesc(list, "stretch");
			this._TryAddDesc(list, a_item.GetTimeLeftDesc());
			this._TryAddDesc(list, a_item.GetBindStateDesc());
			this._TryAddDesc(list, a_item.GetBindStateOwnerDesc());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, " ");
			this._TryAddDesc(list2, "stretch");
			this._TryShowDescsOnBothSide(a_objRoot2, list, list2);
			this._realSetupLine(a_objRoot2);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetDescription(), true);
			this._TryShowDescOnLeftSide(a_objRoot2, a_item.GetSourceDescription(), true);
		}

		// Token: 0x0600E567 RID: 58727 RVA: 0x003BB330 File Offset: 0x003B9730
		private void _SetupVirtualPackContent(GameObject a_objRoot, ItemData a_item)
		{
			GameObject gameObject = Utility.FindGameObject(a_objRoot, "InfoView/ViewPort/Content", true);
			this._SetupItemTitle(a_objRoot, a_item, false);
			this._TryShowDescOnLeftSide(gameObject, a_item.GetDescription(), true);
			if (a_item.PackID > 0)
			{
				this.mVirtualPackContent.Add(new KeyValuePair<int, GameObject>(a_item.PackID, gameObject));
				DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(a_item.PackID);
			}
		}

		// Token: 0x0600E568 RID: 58728 RVA: 0x003BB394 File Offset: 0x003B9794
		private void OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			this.CheckVirtualPackList(giftPackSyncInfo, this.mVirtualPackContent);
			this.CheckVirtualPackList(giftPackSyncInfo, this.mExpendablePackContent);
		}

		// Token: 0x0600E569 RID: 58729 RVA: 0x003BB3E4 File Offset: 0x003B97E4
		private void CheckVirtualPackList(GiftPackSyncInfo data, List<KeyValuePair<int, GameObject>> list)
		{
			if (list != null && list.Count > 0 && data != null)
			{
				for (int i = list.Count - 1; i >= 0; i--)
				{
					if ((long)list[i].Key == (long)((ulong)data.id))
					{
						List<GiftPackItemData> list2 = new List<GiftPackItemData>();
						switch (data.filterType)
						{
						case 0U:
						case 2U:
						case 3U:
							for (int j = 0; j < data.gifts.Length; j++)
							{
								GiftPackItemData giftDataFromNet = GiftPackDataManager.GetGiftDataFromNet(data.gifts[j]);
								if (giftDataFromNet.ItemID > 0)
								{
									list2.Add(giftDataFromNet);
								}
							}
							break;
						case 1U:
						case 4U:
							for (int k = 0; k < data.gifts.Length; k++)
							{
								GiftPackItemData giftDataFromNet2 = GiftPackDataManager.GetGiftDataFromNet(data.gifts[k]);
								if (giftDataFromNet2.ItemID > 0 && giftDataFromNet2.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
								{
									list2.Add(giftDataFromNet2);
								}
							}
							break;
						}
						this._SetupShowItems(list[i].Value, list2, 0);
						list.RemoveAt(i);
						break;
					}
				}
			}
		}

		// Token: 0x0600E56A RID: 58730 RVA: 0x003BB538 File Offset: 0x003B9938
		private void _SetupSuitContent(GameObject a_objRoot, ItemData a_item, EquipSuitObj a_suitObj)
		{
			if (a_item == null || a_suitObj == null)
			{
				return;
			}
			this._SetupLine(a_objRoot);
			string text = TR.Value("color_green", string.Format("[{0}]", a_suitObj.equipSuitRes.name));
			if (!string.IsNullOrEmpty(text))
			{
				GameObject a_objRoot2 = this._SetupGroup(a_objRoot);
				this._SetupLeftLabel(a_objRoot2, text);
			}
			GameObject a_objRoot3 = this._SetupGroup(a_objRoot);
			string a_strLeft = string.Empty;
			for (int i = 0; i < a_suitObj.equipSuitRes.equips.Count; i++)
			{
				int a_nTableID = a_suitObj.equipSuitRes.equips[i];
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nTableID);
				if (commonItemTableDataByID != null)
				{
					if (a_suitObj.IsSuitEquipActive(commonItemTableDataByID))
					{
						a_strLeft = TR.Value("color_green", commonItemTableDataByID.Name);
					}
					else
					{
						a_strLeft = TR.Value("color_grey", commonItemTableDataByID.Name);
					}
					this._SetupLeftLabel(a_objRoot3, a_strLeft);
				}
			}
			GameObject a_objRoot4 = this._SetupGroup(a_objRoot);
			Dictionary<int, EquipProp>.Enumerator enumerator = a_suitObj.equipSuitRes.props.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = string.Empty;
				int count = a_suitObj.wearedEquipIDs.Count;
				KeyValuePair<int, EquipProp> keyValuePair = enumerator.Current;
				bool flag = count >= keyValuePair.Key;
				string text3 = (!flag) ? "color_half_grey" : "color_green";
				string key = text3;
				string key2 = "tip_suit_effect";
				KeyValuePair<int, EquipProp> keyValuePair2 = enumerator.Current;
				text2 = TR.Value(key, TR.Value(key2, keyValuePair2.Key));
				KeyValuePair<int, EquipProp> keyValuePair3 = enumerator.Current;
				List<string> propsFormatStr = keyValuePair3.Value.GetPropsFormatStr();
				if (propsFormatStr != null)
				{
					string key3 = (!flag) ? "color_half_grey" : "color_blue";
					for (int j = 0; j < propsFormatStr.Count; j++)
					{
						text2 += "\n";
						text2 += TR.Value(key3, propsFormatStr[j]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair4 = enumerator.Current;
				List<EquipProp.BuffSkillInfo> buffSkillInfos = keyValuePair4.Value.GetBuffSkillInfos();
				if (buffSkillInfos != null)
				{
					for (int k = 0; k < buffSkillInfos.Count; k++)
					{
						EquipProp.BuffSkillInfo buffSkillInfo = buffSkillInfos[k];
						string key4;
						if (this._IsJobMatch(buffSkillInfo.jobID))
						{
							if (flag)
							{
								key4 = "color_orange";
							}
							else
							{
								key4 = "color_half_grey";
							}
						}
						else
						{
							key4 = "color_grey";
						}
						text2 += "\n";
						text2 += TR.Value(key4, string.Format("[{0}]", buffSkillInfo.jobName));
						string key5;
						if (this._IsJobMatch(buffSkillInfo.jobID))
						{
							if (flag)
							{
								key5 = "color_blue";
							}
							else
							{
								key5 = "color_half_grey";
							}
						}
						else
						{
							key5 = "color_grey";
						}
						for (int l = 0; l < buffSkillInfo.skillDescs.Count; l++)
						{
							text2 += "\n";
							text2 += TR.Value(key5, buffSkillInfo.skillDescs[l]);
						}
					}
				}
				string text4 = (!flag) ? "color_half_grey" : "color_blue";
				KeyValuePair<int, EquipProp> keyValuePair5 = enumerator.Current;
				List<string> buffCommonDescs = keyValuePair5.Value.GetBuffCommonDescs();
				if (buffCommonDescs != null)
				{
					for (int m = 0; m < buffCommonDescs.Count; m++)
					{
						text2 += "\n";
						text2 += TR.Value(text4, buffCommonDescs[m]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair6 = enumerator.Current;
				if (!string.IsNullOrEmpty(keyValuePair6.Value.attachBuffDesc))
				{
					text2 += "\n";
					string str = text2;
					string key6 = text4;
					KeyValuePair<int, EquipProp> keyValuePair7 = enumerator.Current;
					text2 = str + TR.Value(key6, keyValuePair7.Value.attachBuffDesc);
				}
				string text5 = (!flag) ? "color_half_grey" : "color_blue";
				KeyValuePair<int, EquipProp> keyValuePair8 = enumerator.Current;
				List<string> mechanismDescs = keyValuePair8.Value.GetMechanismDescs();
				if (mechanismDescs != null)
				{
					for (int n = 0; n < mechanismDescs.Count; n++)
					{
						text2 += "\n";
						text2 += TR.Value(text5, mechanismDescs[n]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair9 = enumerator.Current;
				if (!string.IsNullOrEmpty(keyValuePair9.Value.attachMechanismDesc))
				{
					text2 += "\n";
					string str2 = text2;
					string key7 = text5;
					KeyValuePair<int, EquipProp> keyValuePair10 = enumerator.Current;
					text2 = str2 + TR.Value(key7, keyValuePair10.Value.attachMechanismDesc);
				}
				this._SetupLeftLabel(a_objRoot4, text2);
			}
		}

		// Token: 0x0600E56B RID: 58731 RVA: 0x003BBA14 File Offset: 0x003B9E14
		private List<string> _GetBaseMainPropDescs(EquipProp a_Prop, EquipProp a_compareProp, ItemData itemData = null)
		{
			List<string> list = new List<string>();
			EEquipProp[] array = new EEquipProp[]
			{
				EEquipProp.PhysicsAttack,
				EEquipProp.MagicAttack,
				EEquipProp.PhysicsDefense,
				EEquipProp.MagicDefense,
				EEquipProp.Independence
			};
			EEquipProp[] array2 = new EEquipProp[]
			{
				EEquipProp.IgnorePhysicsAttack,
				EEquipProp.IgnoreMagicAttack,
				EEquipProp.IgnorePhysicsDefense,
				EEquipProp.IgnoreMagicDefense
			};
			EEquipProp[] array3 = new EEquipProp[]
			{
				EEquipProp.IgnorePhysicsAttackRate,
				EEquipProp.IgnoreMagicAttackRate,
				EEquipProp.IgnorePhysicsDefenseRate,
				EEquipProp.IgnoreMagicDefenseRate
			};
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(637, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			for (int i = 0; i < array.Length; i++)
			{
				string text = a_Prop.GetPropFormatStr(array[i], -1);
				if (!string.IsNullOrEmpty(text))
				{
					string str = string.Empty;
					if (array[i] == EEquipProp.Independence)
					{
						str = ((num <= 0) ? TR.Value("tip_independence_pvpdesc") : string.Empty);
					}
					if (a_compareProp != null)
					{
						int num2 = (int)array[i];
						int a_value;
						int a_value2;
						if (array[i] == EEquipProp.Independence)
						{
							a_value = (int)((float)a_Prop.props[num2] / 1000f);
							a_value2 = (int)((float)a_compareProp.props[num2] / 1000f);
						}
						else
						{
							a_value = a_Prop.props[num2];
							a_value2 = a_compareProp.props[num2];
						}
						text += " ";
						text += this._GetDifferenceDesc(a_value, a_value2);
					}
					text += str;
					list.Add(text);
				}
			}
			if (itemData != null && itemData.Type == ItemTable.eType.EQUIP)
			{
				if (itemData.SubType == 1)
				{
					this._TryAddDesc(list, " ");
				}
				else
				{
					this._TryAddDesc(list, " ");
					this._TryAddDesc(list, " ");
				}
			}
			return list;
		}

		// Token: 0x0600E56C RID: 58732 RVA: 0x003BBC00 File Offset: 0x003BA000
		private string _GetDifferenceDesc(int a_value0, int a_value1)
		{
			if (a_value0 == a_value1)
			{
				return string.Empty;
			}
			if (a_value0 > a_value1)
			{
				string arg = string.Format("(+{0})", a_value0 - a_value1);
				return TR.Value("color_green", arg);
			}
			string arg2 = string.Format("({0})", a_value0 - a_value1);
			return TR.Value("color_red", arg2);
		}

		// Token: 0x0600E56D RID: 58733 RVA: 0x003BBC5E File Offset: 0x003BA05E
		private void _TryAddDesc(List<string> a_descs, string a_desc)
		{
			if (!string.IsNullOrEmpty(a_desc))
			{
				a_descs.Add(a_desc);
			}
		}

		// Token: 0x0600E56E RID: 58734 RVA: 0x003BBC72 File Offset: 0x003BA072
		private void _TryAddDescs(List<string> a_targetDescs, List<string> a_sourceDescs)
		{
			if (a_sourceDescs != null && a_sourceDescs.Count > 0)
			{
				a_targetDescs.AddRange(a_sourceDescs);
			}
		}

		// Token: 0x0600E56F RID: 58735 RVA: 0x003BBC90 File Offset: 0x003BA090
		private void _TryShowDescOnLeftSide(GameObject a_objRoot, string a_desc, bool a_bNeedLine = true)
		{
			if (!string.IsNullOrEmpty(a_desc))
			{
				if (a_objRoot.transform.childCount > 0 && a_bNeedLine)
				{
					this._SetupLine(a_objRoot);
				}
				GameObject a_objRoot2 = this._SetupGroup(a_objRoot);
				this._SetupLeftLabel(a_objRoot2, a_desc);
			}
		}

		// Token: 0x0600E570 RID: 58736 RVA: 0x003BBCD8 File Offset: 0x003BA0D8
		private void InitBeadAttr(GameObject a_objRoot, ItemData item)
		{
			if (item.PreciousBeadMountHole == null)
			{
				return;
			}
			for (int i = 0; i < item.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = item.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					if (DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(precBead.preciousBeadId) != null)
					{
						this.UpdateCommonItemInfo(a_objRoot, precBead, item, this.m_objCommonItemInfoRoot);
					}
				}
			}
		}

		// Token: 0x0600E571 RID: 58737 RVA: 0x003BBD4C File Offset: 0x003BA14C
		private void InitEnchantmentAttr(GameObject a_objRoot, ItemData item)
		{
			if (item.mPrecEnchantmentCard == null)
			{
				return;
			}
			if (ItemDataManager.CreateItemDataFromTable(item.mPrecEnchantmentCard.iEnchantmentCardID, 100, 0) == null)
			{
				return;
			}
			this.UpdateCommonItemInfo(a_objRoot, item.mPrecEnchantmentCard, item, this.m_objCommonItemInfoRoot);
		}

		// Token: 0x0600E572 RID: 58738 RVA: 0x003BBD94 File Offset: 0x003BA194
		private void InitInscripotionAttr(GameObject a_objRoot, ItemData item)
		{
			if (item.InscriptionHoles == null)
			{
				return;
			}
			for (int i = 0; i < item.InscriptionHoles.Count; i++)
			{
				InscriptionHoleData inscriptionHoleData = item.InscriptionHoles[i];
				if (inscriptionHoleData != null)
				{
					if (inscriptionHoleData.IsOpenHole)
					{
						this.UpdateCommonItemInfo(a_objRoot, inscriptionHoleData, item, this.m_objCommonItemInfoRoot);
					}
				}
			}
		}

		// Token: 0x0600E573 RID: 58739 RVA: 0x003BBE00 File Offset: 0x003BA200
		private void UpdateCommonItemInfo(GameObject a_objRoot, object data, ItemData equipmentItem, GameObject a_objCommonItemInfoRoot)
		{
			GameObject gameObject = this._SetCommonItemInfo(a_objRoot, a_objCommonItemInfoRoot);
			CommonItemInfo component = gameObject.GetComponent<CommonItemInfo>();
			if (component != null)
			{
				component.InitInterface(data, equipmentItem);
			}
		}

		// Token: 0x0600E574 RID: 58740 RVA: 0x003BBE34 File Offset: 0x003BA234
		private GameObject _SetCommonItemInfo(GameObject a_objeRoot, GameObject holeRoot)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(holeRoot);
			gameObject.transform.SetParent(a_objeRoot.transform, false);
			gameObject.SetActive(true);
			return gameObject;
		}

		// Token: 0x0600E575 RID: 58741 RVA: 0x003BBE64 File Offset: 0x003BA264
		private void _TryShowDescsOnLeftSide(GameObject a_objRoot, List<string> a_descs)
		{
			if (a_descs != null && a_descs.Count > 0)
			{
				if (a_objRoot.transform.childCount > 0)
				{
					this._SetupLine(a_objRoot);
				}
				GameObject a_objRoot2 = this._SetupGroup(a_objRoot);
				for (int i = 0; i < a_descs.Count; i++)
				{
					this._SetupLeftLabel(a_objRoot2, a_descs[i]);
				}
			}
		}

		// Token: 0x0600E576 RID: 58742 RVA: 0x003BBEC8 File Offset: 0x003BA2C8
		private void _TryShowDescsOnBothSide(GameObject a_objRoot, List<string> a_leftDescs, List<string> a_rightDescs)
		{
			if (a_leftDescs != null && a_rightDescs != null && a_leftDescs.Contains("stretch") && a_rightDescs.Contains("stretch") && (a_leftDescs.Count > 1 || a_rightDescs.Count > 1))
			{
				int num = Mathf.Abs(a_leftDescs.Count - a_rightDescs.Count);
				string[] array = new string[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = " ";
				}
				if (a_leftDescs.Count > a_rightDescs.Count)
				{
					a_rightDescs.InsertRange(a_rightDescs.FindIndex((string data) => data == "stretch"), array);
				}
				else if (a_leftDescs.Count < a_rightDescs.Count)
				{
					a_leftDescs.InsertRange(a_leftDescs.FindIndex((string data) => data == "stretch"), array);
				}
				a_leftDescs.Remove("stretch");
				a_rightDescs.Remove("stretch");
				if (a_leftDescs.Count == a_rightDescs.Count)
				{
					if (a_objRoot.transform.childCount > 1)
					{
						this._SetupLine(a_objRoot);
					}
					GameObject a_objRoot2 = this._SetupGroup(a_objRoot);
					for (int j = 0; j < a_leftDescs.Count; j++)
					{
						this._SetupHTwoLabels(a_objRoot2, a_leftDescs[j], a_rightDescs[j]);
					}
				}
			}
		}

		// Token: 0x0600E577 RID: 58743 RVA: 0x003BC043 File Offset: 0x003BA443
		private bool _IsJobMatch(int jobID)
		{
			return DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(jobID);
		}

		// Token: 0x0600E578 RID: 58744 RVA: 0x003BC058 File Offset: 0x003BA458
		private void _SetupFunc(ItemData item, List<TipFuncButon> funcInfos, int nTipIndex)
		{
			this._ClearFunc();
			if (funcInfos == null || this.m_objFuncBtnPrefab == null || this.m_objFuncBtnRoot == null || this.m_objFuncOtherBtnPrefab == null)
			{
				return;
			}
			if (funcInfos.Count <= 0)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < funcInfos.Count; i++)
			{
				if (funcInfos[i].tipFuncButtonType == TipFuncButtonType.Trigger)
				{
					num++;
				}
			}
			this.otherBtnFuncInfosGo = new List<GameObject>();
			this.m_objFuncBtnRoot.SetActive(true);
			for (int j = 0; j < funcInfos.Count; j++)
			{
				TipFuncButon temp = funcInfos[j];
				GameObject gameObject;
				if (temp is TipFuncButonSpecial)
				{
					gameObject = this.m_objFuncSpecial;
				}
				else if (temp is TipFuncButtonOther)
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objFuncOtherBtnPrefab);
					gameObject.transform.SetParent(this.m_objFuncBtnRoot.transform, false);
					gameObject.name = temp.name;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objFuncBtnPrefab);
					gameObject.transform.SetParent(this.m_objFuncBtnRoot.transform, false);
					gameObject.name = temp.name;
				}
				if (gameObject != null)
				{
					if (item.Type == ItemTable.eType.EQUIP)
					{
						if (num > 1)
						{
							if (temp.tipFuncButtonType == TipFuncButtonType.Trigger)
							{
								gameObject.CustomActive(false);
								this.otherBtnFuncInfosGo.Add(gameObject);
							}
							else
							{
								gameObject.CustomActive(true);
							}
						}
						else if (temp.tipFuncButtonType == TipFuncButtonType.Other)
						{
							gameObject.CustomActive(false);
						}
						else
						{
							gameObject.CustomActive(true);
						}
					}
					else
					{
						gameObject.CustomActive(true);
					}
					if (temp is TipFuncButtonOther)
					{
						this.mItemTipsFuncOtherButton = gameObject.GetComponent<ItemTipsFuncOtherButton>();
					}
					Button component = gameObject.GetComponent<Button>();
					if (component != null)
					{
						component.onClick.RemoveAllListeners();
						component.onClick.AddListener(delegate()
						{
							temp.callback(item, nTipIndex);
						});
					}
					Toggle component2 = gameObject.GetComponent<Toggle>();
					if (component2 != null)
					{
						component2.onValueChanged.RemoveAllListeners();
						component2.onValueChanged.AddListener(delegate(bool value)
						{
							this.bIsSelect = value;
							temp.callback(item, nTipIndex);
						});
					}
					Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Text");
					if (componetInChild != null)
					{
						componetInChild.text = temp.text;
					}
				}
			}
		}

		// Token: 0x0600E579 RID: 58745 RVA: 0x003BC348 File Offset: 0x003BA748
		private void _OnMoreAndMoreClick(UIEvent uiEvent)
		{
			if (this.mItemTipsFuncOtherButton != null)
			{
				this.mItemTipsFuncOtherButton.SetTabItemRoot();
			}
			for (int i = 0; i < this.otherBtnFuncInfosGo.Count; i++)
			{
				this.otherBtnFuncInfosGo[i].CustomActive(this.bIsSelect);
			}
		}

		// Token: 0x0600E57A RID: 58746 RVA: 0x003BC3A4 File Offset: 0x003BA7A4
		private void _ItemSellSuccess(UIEvent uiEvent)
		{
			this._SetupItemTitle(this.m_objTipTemplate, this.data.item, true);
		}

		// Token: 0x0600E57B RID: 58747 RVA: 0x003BC3BE File Offset: 0x003BA7BE
		private void _ClearFunc()
		{
			this.m_objFuncBtnRoot.SetActive(false);
			this.m_objFuncSpecial.SetActive(false);
			this.m_objFuncBtnPrefab.SetActive(false);
			this.m_objFuncOtherBtnPrefab.CustomActive(false);
		}

		// Token: 0x0600E57C RID: 58748 RVA: 0x003BC3F0 File Offset: 0x003BA7F0
		private void _OnItemRemoved(UIEvent a_event)
		{
			ItemTipData itemTipData = this.userData as ItemTipData;
			if ((long)itemTipData.item.TableID == (long)((ulong)((uint)a_event.Param1)) && DataManager<ItemDataManager>.GetInstance().GetItem(itemTipData.item.GUID) == null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseTip(itemTipData.nTipIndex);
			}
		}

		// Token: 0x0600E57D RID: 58749 RVA: 0x003BC450 File Offset: 0x003BA850
		private void _OnItemUseSuccess(UIEvent a_event)
		{
			ItemTipData itemTipData = this.userData as ItemTipData;
			if (itemTipData == null)
			{
				return;
			}
			this._SetupContent(this.m_objTipTemplate, itemTipData.item, itemTipData.compareItem, itemTipData.itemSuitObj);
		}

		// Token: 0x0600E57E RID: 58750 RVA: 0x003BC490 File Offset: 0x003BA890
		private void OnCounterChanged(UIEvent iEvent)
		{
			ItemTipData itemTipData = this.userData as ItemTipData;
			if (itemTipData == null || itemTipData.item == null)
			{
				return;
			}
			if (itemTipData.item.SubType != 131 && itemTipData.item.SubType != 140 && itemTipData.item.SubType != 151)
			{
				if (itemTipData.item.SubType != 37)
				{
					return;
				}
			}
			this._SetupTip(this.m_objTipTemplate, itemTipData.item, itemTipData.compareItem, itemTipData.itemSuitObj);
			this._SetupTip(this.compareItemContentGo, itemTipData.compareItem, null, itemTipData.compareItemSuitObj);
		}

		// Token: 0x0600E57F RID: 58751 RVA: 0x003BC54C File Offset: 0x003BA94C
		private void TryChangeShowShareTextForAppStore(Text name)
		{
			if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SHARE_TEXT_CHANGE) && name)
			{
				string text = name.text;
				if (text.Equals(TR.Value("tip_share")))
				{
					name.text = "展示";
				}
			}
		}

		// Token: 0x0600E580 RID: 58752 RVA: 0x003BC59C File Offset: 0x003BA99C
		private void InitItemTipModelAvatarData()
		{
			ItemTipData itemTipData = this.userData as ItemTipData;
			if (itemTipData != null)
			{
				this._itemTipFrameIndex = itemTipData.nTipIndex;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveItemTipFrameOpenMessage, this._itemTipFrameIndex, null, null, null);
			}
		}

		// Token: 0x0600E581 RID: 58753 RVA: 0x003BC5E4 File Offset: 0x003BA9E4
		private void ResetItemTipModelAvatarData()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveItemTipFrameCloseMessage, this._itemTipFrameIndex, null, null, null);
			this.ClearData();
		}

		// Token: 0x0600E582 RID: 58754 RVA: 0x003BC609 File Offset: 0x003BAA09
		private void ClearData()
		{
			this._twoToggleController = null;
			this._itemTipModelAvatarRootView = null;
			this._selectItemTipCompareItemTypeIndex = 0;
			this._itemTipShowAvatarType = ItemTipShowAvatarType.None;
			this._clickedItemData = null;
			this._isShowModelAvatarFlag = false;
			this._itemTipModelAvatarLayerIndex = 0;
			this.ResetGiftPackModelAvatarData();
			this._otherProfessionId = 0;
		}

		// Token: 0x0600E583 RID: 58755 RVA: 0x003BC649 File Offset: 0x003BAA49
		private void ResetGiftPackModelAvatarData()
		{
			this._giftPackModelAvatarDataModel = null;
		}

		// Token: 0x0600E584 RID: 58756 RVA: 0x003BC654 File Offset: 0x003BAA54
		public void InitItemTipModelAvatarContent(ItemTipData itemTipData)
		{
			this._isShowModelAvatarFlag = false;
			this._itemTipShowAvatarType = ItemTipShowAvatarType.None;
			this.ResetGiftPackModelAvatarData();
			this._otherProfessionId = 0;
			if (itemTipData == null)
			{
				return;
			}
			if (itemTipData.IsForceCloseModelAvatar)
			{
				return;
			}
			this._clickedItemData = itemTipData.item;
			if (this._clickedItemData == null)
			{
				return;
			}
			if (this._clickedItemData.TableData == null)
			{
				return;
			}
			if (!ItemDataUtility.IsItemTipShowModelAvatar(this._clickedItemData))
			{
				return;
			}
			if (this._clickedItemData.TableData.Type == ItemTable.eType.VirtualPack || this._clickedItemData.TableData.SubType == ItemTable.eSubType.GiftPackage)
			{
				int packageID = this._clickedItemData.TableData.PackageID;
				this._giftPackModelAvatarDataModel = ItemDataUtility.GetGiftPackModelAvatarDataModel(packageID);
				if (this._giftPackModelAvatarDataModel == null)
				{
					return;
				}
			}
			else
			{
				int otherProfessionId = 0;
				if (!ItemDataUtility.IsSuitPlayerProfession(this._clickedItemData.TableData, out otherProfessionId))
				{
					ItemTable.eSubType subType = this._clickedItemData.TableData.SubType;
					if (subType != ItemTable.eSubType.WEAPON && subType != ItemTable.eSubType.FASHION_WEAPON)
					{
						return;
					}
					this._otherProfessionId = otherProfessionId;
				}
			}
			this._isShowModelAvatarFlag = true;
			this._itemTipModelAvatarLayerIndex = DataManager<ItemTipManager>.GetInstance().GetItemTipModelAvatarLayerIndex(this._itemTipFrameIndex);
			if (itemTipData.compareItem == null)
			{
				this._itemTipShowAvatarType = ItemTipShowAvatarType.SingleTipType;
				this.InitItemTipModelAvatarContentBySingleType();
			}
			else
			{
				this._itemTipShowAvatarType = ItemTipShowAvatarType.CompareTipType;
				this.InitItemTipModelAvatarContentByCompareType();
			}
		}

		// Token: 0x0600E585 RID: 58757 RVA: 0x003BC7C0 File Offset: 0x003BABC0
		private void InitItemTipModelAvatarContentByCompareType()
		{
			if (this.m_tipTwoToggleRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.m_objFuncBtnRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.m_tipTwoToggleRoot, true);
			this._selectItemTipCompareItemTypeIndex = 1;
			GameObject gameObject = CommonUtility.LoadGameObject(this.m_tipTwoToggleRoot);
			if (gameObject != null)
			{
				this._twoToggleController = gameObject.GetComponent<ComTwoToggleController>();
				if (this._twoToggleController != null)
				{
					this._twoToggleController.InitTwoToggleController(1, TR.Value("Item_Tip_Frame_Attribute_Button_Label"), 2, TR.Value("Item_Tip_Frame_TryOn_Button_Label"), new OnTwoToggleClickAction(this.OnItemTipToggleClicked), this._selectItemTipCompareItemTypeIndex);
				}
			}
		}

		// Token: 0x0600E586 RID: 58758 RVA: 0x003BC866 File Offset: 0x003BAC66
		private void OnItemTipToggleClicked(int toggleIndex)
		{
			if (toggleIndex == this._selectItemTipCompareItemTypeIndex)
			{
				return;
			}
			this._selectItemTipCompareItemTypeIndex = toggleIndex;
			this.UpdateItemTipCompareItemContent();
		}

		// Token: 0x0600E587 RID: 58759 RVA: 0x003BC884 File Offset: 0x003BAC84
		private void UpdateItemTipCompareItemContent()
		{
			if (this._selectItemTipCompareItemTypeIndex == 2)
			{
				CommonUtility.UpdateGameObjectVisible(this.compareItemContentGo, false);
				if (this._itemTipModelAvatarRootView == null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_avatarModelRoot);
					if (gameObject != null && this.m_objTipRoot != null)
					{
						gameObject.transform.SetParent(this.m_objTipRoot.transform, false);
						gameObject.transform.SetAsFirstSibling();
						this._itemTipModelAvatarRootView = gameObject.GetComponent<ItemTipModelAvatarRootView>();
					}
				}
				if (this._itemTipModelAvatarRootView != null)
				{
					CommonUtility.UpdateGameObjectVisible(this._itemTipModelAvatarRootView.gameObject, true);
					this._itemTipModelAvatarRootView.UpdateModelAvatarRootViewByCompareItemType(this._clickedItemData.TableData, this._itemTipShowAvatarType, this._itemTipModelAvatarLayerIndex, this._otherProfessionId);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.compareItemContentGo, true);
				if (this._itemTipModelAvatarRootView != null)
				{
					this._itemTipModelAvatarRootView.OnDisappearShowModelAvatarView();
					CommonUtility.UpdateGameObjectVisible(this._itemTipModelAvatarRootView.gameObject, false);
				}
			}
		}

		// Token: 0x0600E588 RID: 58760 RVA: 0x003BC99C File Offset: 0x003BAD9C
		private void InitItemTipModelAvatarContentBySingleType()
		{
			if (this.m_avatarModelRoot == null || this.m_objTipRoot == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_avatarModelRoot);
			if (gameObject == null)
			{
				return;
			}
			gameObject.transform.SetParent(this.m_objTipRoot.transform, false);
			gameObject.transform.SetAsFirstSibling();
			CommonUtility.UpdateGameObjectVisible(gameObject, true);
			this._itemTipModelAvatarRootView = gameObject.GetComponent<ItemTipModelAvatarRootView>();
			if (this._itemTipModelAvatarRootView != null)
			{
				this._itemTipModelAvatarRootView.UpdateModelAvatarRootViewBySingleItemType(this._clickedItemData.TableData, this._itemTipShowAvatarType, this._itemTipModelAvatarLayerIndex, this._giftPackModelAvatarDataModel, this._otherProfessionId);
			}
		}

		// Token: 0x0600E589 RID: 58761 RVA: 0x003BCA5C File Offset: 0x003BAE5C
		private void OnReceiveItemTipFrameOpenMessage(UIEvent uiEvent)
		{
			if (!this._isShowModelAvatarFlag)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._itemTipFrameIndex == num)
			{
				return;
			}
			if (this._itemTipFrameIndex != num - 1)
			{
				return;
			}
			if (this._itemTipModelAvatarRootView == null)
			{
				return;
			}
			if (this._itemTipShowAvatarType == ItemTipShowAvatarType.SingleTipType)
			{
				this._itemTipModelAvatarRootView.OnDisappearShowModelAvatarView();
			}
			else if (this._itemTipShowAvatarType == ItemTipShowAvatarType.CompareTipType && this._selectItemTipCompareItemTypeIndex == 2)
			{
				this._itemTipModelAvatarRootView.OnDisappearShowModelAvatarView();
			}
		}

		// Token: 0x0600E58A RID: 58762 RVA: 0x003BCB00 File Offset: 0x003BAF00
		private void OnReceiveItemTipFrameCloseMessage(UIEvent uiEvent)
		{
			if (!this._isShowModelAvatarFlag)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._itemTipFrameIndex == num)
			{
				return;
			}
			if (this._itemTipFrameIndex != num - 1)
			{
				return;
			}
			if (this._itemTipModelAvatarRootView == null)
			{
				return;
			}
			if (this._itemTipShowAvatarType == ItemTipShowAvatarType.SingleTipType)
			{
				this._itemTipModelAvatarRootView.OnShowModelAvatarView();
			}
			else if (this._itemTipShowAvatarType == ItemTipShowAvatarType.CompareTipType && this._selectItemTipCompareItemTypeIndex == 2)
			{
				this._itemTipModelAvatarRootView.OnShowModelAvatarView();
			}
		}

		// Token: 0x0600E58B RID: 58763 RVA: 0x003BCBA4 File Offset: 0x003BAFA4
		public bool GetShowModelAvatarFlag()
		{
			return this._isShowModelAvatarFlag;
		}

		// Token: 0x04008AD9 RID: 35545
		[UIObject("Template")]
		private GameObject m_objTemplateGroup;

		// Token: 0x04008ADA RID: 35546
		[UIObject("Content")]
		private GameObject m_objTipRoot;

		// Token: 0x04008ADB RID: 35547
		[UIObject("Content/Tip")]
		private GameObject m_objTipTemplate;

		// Token: 0x04008ADC RID: 35548
		[UIObject("Content/Tip/InfoView/ViewPort/Content/Group")]
		private GameObject m_groupTemplate;

		// Token: 0x04008ADD RID: 35549
		[UIObject("Content/Tip/InfoView/ViewPort/Content/Group/HTwoLabels")]
		private GameObject m_hTwoLabelsTemplate;

		// Token: 0x04008ADE RID: 35550
		[UIObject("Content/Tip/InfoView/ViewPort/Content/Group/LeftLabel")]
		private GameObject m_leftLabelTemplate;

		// Token: 0x04008ADF RID: 35551
		[UIObject("Content/Tip/InfoView/ViewPort/Content/Group/RightLabel")]
		private GameObject m_rightLabelTemplate;

		// Token: 0x04008AE0 RID: 35552
		[UIObject("Template/Items")]
		private GameObject m_showItemsTemplate;

		// Token: 0x04008AE1 RID: 35553
		[UIObject("Content/Tip/InfoView/ViewPort/Content/Line")]
		private GameObject m_imageTemplate;

		// Token: 0x04008AE2 RID: 35554
		[UIObject("Content/Func")]
		private GameObject m_objFuncBtnRoot;

		// Token: 0x04008AE3 RID: 35555
		[UIObject("Content/Func/Special")]
		private GameObject m_objFuncSpecial;

		// Token: 0x04008AE4 RID: 35556
		[UIObject("Content/Func/BtnTemp")]
		private GameObject m_objFuncBtnPrefab;

		// Token: 0x04008AE5 RID: 35557
		[UIObject("Content/Func/Other")]
		private GameObject m_objFuncOtherBtnPrefab;

		// Token: 0x04008AE6 RID: 35558
		[UIObject("Content/Tip/InfoView/ViewPort/Content/CommonItemInfo")]
		private GameObject m_objCommonItemInfoRoot;

		// Token: 0x04008AE7 RID: 35559
		[UIObject("Content/Func/TipTwoToggleRoot")]
		private GameObject m_tipTwoToggleRoot;

		// Token: 0x04008AE8 RID: 35560
		[UIObject("Content/AvatarModelRoot")]
		private GameObject m_avatarModelRoot;

		// Token: 0x04008AE9 RID: 35561
		private GameObject compareItemContentGo;

		// Token: 0x04008AEA RID: 35562
		private ItemTipData data;

		// Token: 0x04008AEB RID: 35563
		private const string m_stretch = "stretch";

		// Token: 0x04008AEC RID: 35564
		private float[] m_heights = new float[]
		{
			570f,
			750f,
			935f
		};

		// Token: 0x04008AED RID: 35565
		private bool bIsSelect;

		// Token: 0x04008AEE RID: 35566
		private ItemTipsFuncOtherButton mItemTipsFuncOtherButton;

		// Token: 0x04008AEF RID: 35567
		private List<GameObject> otherBtnFuncInfosGo = new List<GameObject>();

		// Token: 0x04008AF0 RID: 35568
		private string selectPath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Xuanzhong_Di";

		// Token: 0x04008AF1 RID: 35569
		private string unselectPath = "UI/Image/Packed/p_UI_Package.png:UI_Package_Weixuanzhong_Di";

		// Token: 0x04008AF2 RID: 35570
		private List<KeyValuePair<int, GameObject>> mExpendablePackContent = new List<KeyValuePair<int, GameObject>>();

		// Token: 0x04008AF3 RID: 35571
		private List<KeyValuePair<int, GameObject>> mVirtualPackContent = new List<KeyValuePair<int, GameObject>>();

		// Token: 0x04008AF4 RID: 35572
		private int _itemTipFrameIndex;

		// Token: 0x04008AF5 RID: 35573
		private int _otherProfessionId;

		// Token: 0x04008AF6 RID: 35574
		private ComTwoToggleController _twoToggleController;

		// Token: 0x04008AF7 RID: 35575
		private ItemTipModelAvatarRootView _itemTipModelAvatarRootView;

		// Token: 0x04008AF8 RID: 35576
		private int _selectItemTipCompareItemTypeIndex;

		// Token: 0x04008AF9 RID: 35577
		private ItemTipShowAvatarType _itemTipShowAvatarType;

		// Token: 0x04008AFA RID: 35578
		private ItemData _clickedItemData;

		// Token: 0x04008AFB RID: 35579
		private bool _isShowModelAvatarFlag;

		// Token: 0x04008AFC RID: 35580
		private int _itemTipModelAvatarLayerIndex;

		// Token: 0x04008AFD RID: 35581
		private GiftPackModelAvatarDataModel _giftPackModelAvatarDataModel;
	}
}
