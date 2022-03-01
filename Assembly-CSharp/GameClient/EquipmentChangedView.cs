using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B79 RID: 7033
	internal class EquipmentChangedView : StrengthGrowthBaseView
	{
		// Token: 0x060113EE RID: 70638 RVA: 0x004F812E File Offset: 0x004F652E
		public sealed override void IniteData(SmithShopNewLinkData linkData, StrengthenGrowthType type, StrengthenGrowthView strengthenGrowthView)
		{
			this.mStrengthenGrowthType = type;
			this.mStrengthenGrowthView = strengthenGrowthView;
			this.CreatComitem();
			if (this.mEquipStateCtrl != null)
			{
				this.mEquipStateCtrl.Key = "notHasEquip";
			}
		}

		// Token: 0x060113EF RID: 70639 RVA: 0x004F8168 File Offset: 0x004F6568
		private void Awake()
		{
			this.RegisterUIEventHandle();
			this.InitGrowthArrtUILIstScript();
			if (this.mOpenExpendFrameBtn != null)
			{
				this.mOpenExpendFrameBtn.onClick.RemoveAllListeners();
				this.mOpenExpendFrameBtn.onClick.AddListener(new UnityAction(this.OnOpenExpendFrameBtnClick));
			}
			if (this.mChangedBtn != null)
			{
				this.mChangedBtn.onClick.RemoveAllListeners();
				this.mChangedBtn.onClick.AddListener(new UnityAction(this.OnChangedBtnClick));
			}
		}

		// Token: 0x060113F0 RID: 70640 RVA: 0x004F81FC File Offset: 0x004F65FC
		private void OnDestroy()
		{
			this.UnRegisterUIEventHandle();
			this.UnInitGrowthArrtUILIstScript();
			this.mEquipComItem = null;
			this.mExpendComItem = null;
			this.mExpendItemData = null;
			this.mSelectEquipItemData = null;
			this.mSelectChangeGrowthArrtType = EGrowthAttrType.GAT_NONE;
			this.mStrengthenGrowthView = null;
			this.mChangeGrowthArrtList.Clear();
			this.mGrowthArrtData = null;
		}

		// Token: 0x060113F1 RID: 70641 RVA: 0x004F8254 File Offset: 0x004F6654
		private void RegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Combine(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRedMarkEquipChangedSuccess, new ClientEventSystem.UIEventHandler(this.OnRedMarkEquipChangedSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x060113F2 RID: 70642 RVA: 0x004F82B8 File Offset: 0x004F66B8
		private void UnRegisterUIEventHandle()
		{
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Remove(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRedMarkEquipChangedSuccess, new ClientEventSystem.UIEventHandler(this.OnRedMarkEquipChangedSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
		}

		// Token: 0x060113F3 RID: 70643 RVA: 0x004F831C File Offset: 0x004F671C
		private void OnStrengthenGrowthEquipItemClick(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			this.mSelectEquipItemData = itemData;
			if (eStrengthenGrowthType == this.mStrengthenGrowthType)
			{
				this.mGrowthArrtData = null;
				this.mSelectChangeGrowthArrtType = EGrowthAttrType.GAT_NONE;
				this.mExpendItemData = null;
				this.UpdateEquipItem(itemData);
				this.UpdateGrowthExpendItem(itemData);
				this.UpdateGrowthArrtElementAmount(this.mGrowthArrtDataList.Count);
				if (this.mEquipStateCtrl != null)
				{
					this.mEquipStateCtrl.Key = "hasEquip";
				}
			}
		}

		// Token: 0x060113F4 RID: 70644 RVA: 0x004F8398 File Offset: 0x004F6798
		private void OnRedMarkEquipChangedSuccess(UIEvent uiEvent)
		{
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x060113F5 RID: 70645 RVA: 0x004F83B8 File Offset: 0x004F67B8
		private void OnEquipmentListNoEquipment(UIEvent uiEvent)
		{
			this.mExpendItemData = null;
			this.mSelectEquipItemData = null;
			this.mSelectChangeGrowthArrtType = EGrowthAttrType.GAT_NONE;
			this.UpdateEquipItem(this.mSelectEquipItemData);
			this.UpdateExpendState(this.mExpendItemData);
			this.UpdateGrowthArrtElementAmount(0);
			if (this.mEquipStateCtrl != null)
			{
				this.mEquipStateCtrl.Key = "notHasEquip";
			}
		}

		// Token: 0x060113F6 RID: 70646 RVA: 0x004F841C File Offset: 0x004F681C
		private void UpdateGrowthExpendItem(ItemData equipItemData)
		{
			if (equipItemData == null)
			{
				this.mExpendItemData = null;
			}
			else
			{
				this.creatItemData = null;
				this.overLoadItemData = null;
				this.changedItemData = null;
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
				if (equipItemData.EquipType == EEquipType.ET_COMMON && equipItemData.StrengthenLevel <= 0)
				{
					this.FindBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_CREATE, ref this.creatItemData);
					if (this.creatItemData == null)
					{
						this.FindUnBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_CREATE, ref this.creatItemData);
					}
					if (this.creatItemData == null)
					{
						this.FindBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_OVERLOAD, ref this.overLoadItemData);
						if (this.overLoadItemData == null)
						{
							this.FindUnBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_OVERLOAD, ref this.overLoadItemData);
						}
					}
				}
				else if (equipItemData.EquipType == EEquipType.ET_COMMON && equipItemData.StrengthenLevel > 0)
				{
					this.FindBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_OVERLOAD, ref this.overLoadItemData);
					if (this.overLoadItemData == null)
					{
						this.FindUnBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_OVERLOAD, ref this.overLoadItemData);
					}
				}
				else if (equipItemData.EquipType == EEquipType.ET_REDMARK)
				{
					this.FindBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_CHANGE, ref this.changedItemData);
					if (this.changedItemData == null)
					{
						this.FindUnBindExpendItemData(equipItemData, itemsByPackageType, ItemTable.eSubType.ST_ZENGFU_CHANGE, ref this.changedItemData);
					}
				}
				if (equipItemData.EquipType == EEquipType.ET_COMMON && equipItemData.StrengthenLevel <= 0)
				{
					if (this.creatItemData != null)
					{
						this.CreatExpendItem(this.creatItemData);
					}
					else
					{
						this.mExpendItemData = null;
					}
				}
				else if (equipItemData.EquipType == EEquipType.ET_COMMON && equipItemData.StrengthenLevel > 0)
				{
					if (this.overLoadItemData != null)
					{
						this.CreatExpendItem(this.overLoadItemData);
					}
					else
					{
						this.mExpendItemData = null;
					}
				}
				else if (equipItemData.EquipType == EEquipType.ET_REDMARK)
				{
					if (this.changedItemData != null)
					{
						this.CreatExpendItem(this.changedItemData);
					}
					else
					{
						this.mExpendItemData = null;
					}
				}
			}
			this.UpdateExpendState(this.mExpendItemData);
		}

		// Token: 0x060113F7 RID: 70647 RVA: 0x004F8610 File Offset: 0x004F6A10
		private void FindBindExpendItemData(ItemData equipItemData, List<ulong> items, ItemTable.eSubType subType, ref ItemData expendItemData)
		{
			if (subType == ItemTable.eSubType.ST_ZENGFU_OVERLOAD)
			{
				for (int i = 0; i < items.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
					if (item != null)
					{
						if (item.SubType == (int)subType)
						{
							if (item.BindAttr > ItemTable.eOwner.NOTBIND)
							{
								expendItemData = item;
								break;
							}
						}
					}
				}
			}
			else
			{
				ItemData itemData = null;
				if (equipItemData.Quality == ItemTable.eColor.PURPLE && equipItemData.EquipType != EEquipType.ET_REDMARK)
				{
					for (int j = 0; j < items.Count; j++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(items[j]);
						if (item2 != null)
						{
							if (item2.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
							{
								if (item2.SubType == (int)subType)
								{
									if (item2.BindAttr > ItemTable.eOwner.NOTBIND)
									{
										item2.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
										if (this.timeLeft > 0 || !this.bStartCountdown)
										{
											itemData = item2;
											break;
										}
									}
								}
							}
						}
					}
					if (itemData == null)
					{
						for (int k = 0; k < items.Count; k++)
						{
							ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(items[k]);
							if (item3 != null)
							{
								if (item3.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
								{
									if (item3.SubType == (int)subType)
									{
										if (item3.BindAttr > ItemTable.eOwner.NOTBIND)
										{
											item3.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
											if (this.timeLeft > 0 || !this.bStartCountdown)
											{
												expendItemData = item3;
												break;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						expendItemData = itemData;
					}
				}
				else if (equipItemData.Quality == ItemTable.eColor.GREEN && equipItemData.EquipType != EEquipType.ET_REDMARK)
				{
					for (int l = 0; l < items.Count; l++)
					{
						ItemData item4 = DataManager<ItemDataManager>.GetInstance().GetItem(items[l]);
						if (item4 != null)
						{
							if (item4.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
							{
								if (item4.SubType == (int)subType)
								{
									if (item4.BindAttr > ItemTable.eOwner.NOTBIND)
									{
										item4.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
										if (this.timeLeft > 0 || !this.bStartCountdown)
										{
											itemData = item4;
											break;
										}
									}
								}
							}
						}
					}
					if (itemData == null)
					{
						for (int m = 0; m < items.Count; m++)
						{
							ItemData item5 = DataManager<ItemDataManager>.GetInstance().GetItem(items[m]);
							if (item5 != null)
							{
								if (item5.SubType == (int)subType)
								{
									if (item5.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
									{
										if (item5.BindAttr > ItemTable.eOwner.NOTBIND)
										{
											item5.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
											if (this.timeLeft > 0 || !this.bStartCountdown)
											{
												expendItemData = item5;
												break;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						expendItemData = itemData;
					}
				}
				else
				{
					for (int n = 0; n < items.Count; n++)
					{
						ItemData item6 = DataManager<ItemDataManager>.GetInstance().GetItem(items[n]);
						if (item6 != null)
						{
							if (equipItemData.Quality > ItemTable.eColor.PURPLE && equipItemData.EquipType != EEquipType.ET_REDMARK)
							{
								if (item6.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
								{
									goto IL_43E;
								}
								if (item6.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
								{
									goto IL_43E;
								}
							}
							if (item6.SubType == (int)subType)
							{
								if (item6.BindAttr > ItemTable.eOwner.NOTBIND)
								{
									item6.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
									if (this.timeLeft > 0 || !this.bStartCountdown)
									{
										expendItemData = item6;
										break;
									}
								}
							}
						}
						IL_43E:;
					}
				}
			}
		}

		// Token: 0x060113F8 RID: 70648 RVA: 0x004F8A70 File Offset: 0x004F6E70
		private void FindUnBindExpendItemData(ItemData equipItemData, List<ulong> items, ItemTable.eSubType subType, ref ItemData expendItemData)
		{
			if (subType == ItemTable.eSubType.ST_ZENGFU_OVERLOAD)
			{
				for (int i = 0; i < items.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
					if (item != null)
					{
						if (item.SubType == (int)subType)
						{
							if (item.BindAttr == ItemTable.eOwner.NOTBIND)
							{
								expendItemData = item;
								break;
							}
						}
					}
				}
			}
			else
			{
				ItemData itemData = null;
				if (equipItemData.Quality == ItemTable.eColor.PURPLE && equipItemData.EquipType != EEquipType.ET_REDMARK)
				{
					for (int j = 0; j < items.Count; j++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(items[j]);
						if (item2 != null)
						{
							if (item2.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
							{
								if (item2.SubType == (int)subType)
								{
									if (item2.BindAttr == ItemTable.eOwner.NOTBIND)
									{
										item2.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
										if (this.timeLeft > 0 || !this.bStartCountdown)
										{
											itemData = item2;
											break;
										}
									}
								}
							}
						}
					}
					if (itemData == null)
					{
						for (int k = 0; k < items.Count; k++)
						{
							ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(items[k]);
							if (item3 != null)
							{
								if (item3.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
								{
									if (item3.SubType == (int)subType)
									{
										if (item3.BindAttr == ItemTable.eOwner.NOTBIND)
										{
											item3.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
											if (this.timeLeft > 0 || !this.bStartCountdown)
											{
												expendItemData = item3;
												break;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						expendItemData = itemData;
					}
				}
				else if (equipItemData.Quality == ItemTable.eColor.GREEN && equipItemData.EquipType != EEquipType.ET_REDMARK)
				{
					for (int l = 0; l < items.Count; l++)
					{
						ItemData item4 = DataManager<ItemDataManager>.GetInstance().GetItem(items[l]);
						if (item4 != null)
						{
							if (item4.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
							{
								if (item4.SubType == (int)subType)
								{
									if (item4.BindAttr == ItemTable.eOwner.NOTBIND)
									{
										item4.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
										if (this.timeLeft > 0 || !this.bStartCountdown)
										{
											itemData = item4;
											break;
										}
									}
								}
							}
						}
					}
					if (itemData == null)
					{
						for (int m = 0; m < items.Count; m++)
						{
							ItemData item5 = DataManager<ItemDataManager>.GetInstance().GetItem(items[m]);
							if (item5 != null)
							{
								if (item5.SubType == (int)subType)
								{
									if (item5.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
									{
										if (item5.BindAttr == ItemTable.eOwner.NOTBIND)
										{
											item5.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
											if (this.timeLeft > 0 || !this.bStartCountdown)
											{
												expendItemData = item5;
												break;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						expendItemData = itemData;
					}
				}
				else
				{
					for (int n = 0; n < items.Count; n++)
					{
						ItemData item6 = DataManager<ItemDataManager>.GetInstance().GetItem(items[n]);
						if (item6 != null)
						{
							if (equipItemData.Quality > ItemTable.eColor.PURPLE && equipItemData.EquipType != EEquipType.ET_REDMARK)
							{
								if (item6.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_PURPLE)
								{
									goto IL_43E;
								}
								if (item6.ThirdType == ItemTable.eThirdType.ZENGFU_COLOR_GREEN)
								{
									goto IL_43E;
								}
							}
							if (item6.SubType == (int)subType)
							{
								if (item6.BindAttr == ItemTable.eOwner.NOTBIND)
								{
									item6.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
									if (this.timeLeft > 0 || !this.bStartCountdown)
									{
										expendItemData = item6;
										break;
									}
								}
							}
						}
						IL_43E:;
					}
				}
			}
		}

		// Token: 0x060113F9 RID: 70649 RVA: 0x004F8ED0 File Offset: 0x004F72D0
		private void CreatExpendItem(ItemData itemData)
		{
			this.mExpendItemData = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			this.mExpendItemData.GUID = itemData.GUID;
			this.mExpendItemData.DeadTimestamp = itemData.DeadTimestamp;
			this.iExpendCount = itemData.Count;
		}

		// Token: 0x060113FA RID: 70650 RVA: 0x004F8F20 File Offset: 0x004F7320
		private void OnOpenExpendFrameBtnClick()
		{
			if (this.mSelectEquipItemData.EquipType == EEquipType.ET_COMMON && this.mSelectEquipItemData.StrengthenLevel <= 0)
			{
				if (this.creatItemData == null && this.overLoadItemData == null)
				{
					ItemComeLink.OnLink(300000202, 0, true, null, false, false, false, null, string.Empty);
					return;
				}
			}
			else if (this.mSelectEquipItemData.EquipType == EEquipType.ET_COMMON && this.mSelectEquipItemData.StrengthenLevel > 0)
			{
				if (this.overLoadItemData == null)
				{
					ItemComeLink.OnLink(310000228, 0, true, null, false, false, false, null, string.Empty);
					return;
				}
			}
			else if (this.mSelectEquipItemData.EquipType == EEquipType.ET_REDMARK && this.changedItemData == null)
			{
				ItemComeLink.OnLink(300000204, 0, true, null, false, false, false, null, string.Empty);
				return;
			}
			GrowthExpendData growthExpendData = new GrowthExpendData();
			growthExpendData.mStrengthenGrowthType = this.mStrengthenGrowthType;
			growthExpendData.mEquipItemData = this.mSelectEquipItemData;
			growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.OnGrowthExpendItemClick);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GrowthExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
		}

		// Token: 0x060113FB RID: 70651 RVA: 0x004F903D File Offset: 0x004F743D
		private void OnGrowthExpendItemClick(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.CreatExpendItem(itemData);
			this.UpdateExpendState(this.mExpendItemData);
			this.OnRefreshGrowthAttrDesc(this.mGrowthArrtData);
		}

		// Token: 0x060113FC RID: 70652 RVA: 0x004F9065 File Offset: 0x004F7465
		private void OnItemClick(GameObject obj, ItemData item)
		{
			this.OnOpenExpendFrameBtnClick();
		}

		// Token: 0x060113FD RID: 70653 RVA: 0x004F9070 File Offset: 0x004F7470
		private void CreatComitem()
		{
			if (this.mEquipComItem == null)
			{
				this.mEquipComItem = ComItemManager.Create(this.mItemParent);
			}
			this.mEquipComItem.Setup(null, null);
			if (this.mExpendComItem == null)
			{
				this.mExpendComItem = ComItemManager.Create(this.mExpendItemParent);
			}
			this.mExpendComItem.Setup(null, null);
		}

		// Token: 0x060113FE RID: 70654 RVA: 0x004F90DC File Offset: 0x004F74DC
		private void UpdateExpendState(ItemData itemData)
		{
			if (this.mExpendComItem != null)
			{
				this.mExpendComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClick));
			}
			string text = string.Empty;
			if (itemData == null)
			{
				if (this.mExpendStateCtl != null)
				{
					this.mExpendStateCtl.Key = "UnSelected";
				}
				if (this.mExpendCount != null)
				{
					this.mExpendCount.text = string.Empty;
					this.mExpendCount.color = Color.red;
				}
			}
			else
			{
				if (this.mExpendStateCtl != null)
				{
					this.mExpendStateCtl.Key = "Selected";
				}
				text = itemData.GetColorName(string.Empty, false);
				if (this.mExpendCount != null)
				{
					this.mExpendCount.text = string.Format("{0}/1", this.iExpendCount);
					this.mExpendCount.color = Color.white;
				}
			}
			if (this.mExpendName != null)
			{
				this.mExpendName.text = text;
			}
		}

		// Token: 0x060113FF RID: 70655 RVA: 0x004F9204 File Offset: 0x004F7604
		private void UpdateEquipItem(ItemData itemData)
		{
			if (this.mEquipComItem != null)
			{
				ComItem comItem = this.mEquipComItem;
				if (EquipmentChangedView.<>f__mg$cache0 == null)
				{
					EquipmentChangedView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(itemData, EquipmentChangedView.<>f__mg$cache0);
			}
			if (itemData != null)
			{
				if (itemData.EquipType == EEquipType.ET_REDMARK)
				{
					this.mArrtDesc.text = TR.Value("growth_attr_des", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(itemData.GrowthAttrType), itemData.GrowthAttrNum);
				}
				else if (itemData.EquipType == EEquipType.ET_COMMON)
				{
					this.mArrtDesc.text = "待转化";
				}
			}
		}

		// Token: 0x06011400 RID: 70656 RVA: 0x004F92AD File Offset: 0x004F76AD
		private void UpdateGrowthArrtElementAmount(int Count)
		{
			this.mChangeGrowthArrtList.Clear();
			if (this.mArrtUIListScript != null)
			{
				this.mArrtUIListScript.SetElementAmount(Count);
			}
		}

		// Token: 0x06011401 RID: 70657 RVA: 0x004F92D8 File Offset: 0x004F76D8
		private void InitGrowthArrtUILIstScript()
		{
			if (this.mArrtUIListScript != null)
			{
				this.mArrtUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mArrtUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mArrtUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011402 RID: 70658 RVA: 0x004F9350 File Offset: 0x004F7750
		private void UnInitGrowthArrtUILIstScript()
		{
			if (this.mArrtUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mArrtUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mArrtUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011403 RID: 70659 RVA: 0x004F93BC File Offset: 0x004F77BC
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x06011404 RID: 70660 RVA: 0x004F93C4 File Offset: 0x004F77C4
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mGrowthArrtDataList.Count)
			{
				Text com = comCommonBind.GetCom<Text>("ArrtDesc");
				Text com2 = comCommonBind.GetCom<Text>("CheckText");
				Toggle com3 = comCommonBind.GetCom<Toggle>("ArrtTog");
				GameObject mCheckMarkGo = comCommonBind.GetGameObject("CheckMark");
				mCheckMarkGo.CustomActive(false);
				GrowthArrtData mArrtData = this.mGrowthArrtDataList[item.m_index];
				if (com != null && com2 != null)
				{
					if (this.mSelectEquipItemData != null && this.mSelectEquipItemData.EquipType == EEquipType.ET_REDMARK && this.mSelectEquipItemData.GrowthAttrType == mArrtData.mGrowthAttrType)
					{
						Text text = com;
						string text2 = string.Format("{0}(当前)", mArrtData.mAttrDesc);
						com2.text = text2;
						text.text = text2;
					}
					else
					{
						Text text3 = com;
						string text2 = mArrtData.mAttrDesc;
						com2.text = text2;
						text3.text = text2;
					}
				}
				if (com3 != null)
				{
					com3.onValueChanged.RemoveAllListeners();
					com3.onValueChanged.AddListener(delegate(bool value)
					{
						if (value)
						{
							this.OnGrowthArrtToggleClick(mArrtData);
						}
						mCheckMarkGo.CustomActive(value);
					});
				}
				SaveAttrData saveAttrData = new SaveAttrData();
				saveAttrData.mGrowthArrtData = mArrtData;
				saveAttrData.mBind = comCommonBind;
				if (!this.mChangeGrowthArrtList.Contains(saveAttrData))
				{
					this.mChangeGrowthArrtList.Add(saveAttrData);
				}
			}
		}

		// Token: 0x06011405 RID: 70661 RVA: 0x004F9575 File Offset: 0x004F7975
		private void OnGrowthArrtToggleClick(GrowthArrtData data)
		{
			if (data != null)
			{
				this.mGrowthArrtData = data;
				this.mSelectChangeGrowthArrtType = data.mGrowthAttrType;
				this.OnRefreshGrowthAttrDesc(this.mGrowthArrtData);
			}
		}

		// Token: 0x06011406 RID: 70662 RVA: 0x004F959C File Offset: 0x004F799C
		private void OnRefreshGrowthAttrDesc(GrowthArrtData data)
		{
			if (data == null)
			{
				return;
			}
			if (this.mSelectEquipItemData.EquipType == EEquipType.ET_COMMON && this.mExpendItemData != null)
			{
				for (int i = 0; i < this.mChangeGrowthArrtList.Count; i++)
				{
					SaveAttrData saveAttrData = this.mChangeGrowthArrtList[i];
					if (saveAttrData != null)
					{
						Text com = saveAttrData.mBind.GetCom<Text>("ArrtDesc");
						Text com2 = saveAttrData.mBind.GetCom<Text>("CheckText");
						if (com != null && com2 != null)
						{
							Text text = com;
							string text2 = saveAttrData.mGrowthArrtData.mAttrDesc;
							com2.text = text2;
							text.text = text2;
						}
					}
				}
				if (this.mExpendItemData.SubType == 107)
				{
					SaveAttrData saveAttrData2 = null;
					for (int j = 0; j < this.mChangeGrowthArrtList.Count; j++)
					{
						SaveAttrData saveAttrData3 = this.mChangeGrowthArrtList[j];
						if (saveAttrData3 != null)
						{
							if (saveAttrData3.mGrowthArrtData.mGrowthAttrType == data.mGrowthAttrType)
							{
								saveAttrData2 = saveAttrData3;
								break;
							}
						}
					}
					Text com3 = saveAttrData2.mBind.GetCom<Text>("ArrtDesc");
					Text com4 = saveAttrData2.mBind.GetCom<Text>("CheckText");
					if (com3 != null && com4 != null)
					{
						Text text3 = com3;
						string text2 = saveAttrData2.mGrowthArrtData.mAttrDesc + this.GetIntervalValue();
						com4.text = text2;
						text3.text = text2;
					}
				}
			}
		}

		// Token: 0x06011407 RID: 70663 RVA: 0x004F9738 File Offset: 0x004F7B38
		private string GetIntervalValue()
		{
			if (this.mSelectEquipItemData != null)
			{
				float num = (float)DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(this.mSelectEquipItemData, this.mMinLevel);
				float num2 = (float)DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(this.mSelectEquipItemData, this.mMaxLevel);
				return string.Format("+{0}~+{1}", num, num2);
			}
			return string.Empty;
		}

		// Token: 0x06011408 RID: 70664 RVA: 0x004F979C File Offset: 0x004F7B9C
		private void OnChangedBtnClick()
		{
			if (this.mSelectEquipItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择装备", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mSelectEquipItemData != null && this.mSelectEquipItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法转化", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.mExpendItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择消耗道具", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mSelectChangeGrowthArrtType == EGrowthAttrType.GAT_NONE)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择转化的属性", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mSelectEquipItemData.EquipType == EEquipType.ET_REDMARK && this.mSelectEquipItemData.GrowthAttrType == this.mSelectChangeGrowthArrtType)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("equipment_changed_check_desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mExpendItemData != null)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.mExpendItemData.GUID);
				if (item == null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int num;
				bool flag;
				this.mExpendItemData.GetLimitTimeLeft(out num, out flag);
				if (num <= 0 && flag)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
			}
			if (this.mExpendItemData.SubType == 105)
			{
				string msgContent = TR.Value("change_converter_desc", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.mSelectEquipItemData.GrowthAttrType), this.mSelectEquipItemData.GrowthAttrNum, DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.mSelectChangeGrowthArrtType));
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnSceneEquipEnhanceChg();
				}, null, 0f, false);
				return;
			}
			if (this.mExpendItemData.SubType == 106)
			{
				string msgContent2 = TR.Value("change_generatingdevice_desc", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.mSelectChangeGrowthArrtType), DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(this.mSelectEquipItemData, this.mSelectEquipItemData.StrengthenLevel));
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent2, delegate()
				{
					this.OnSceneEquipEnhanceChg();
				}, null, 0f, false);
				return;
			}
			if (this.mSelectEquipItemData.EquipType == EEquipType.ET_COMMON && this.mSelectEquipItemData.StrengthenLevel >= 11)
			{
				string msgContent3 = TR.Value("equipment_changed_desc");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent3, delegate()
				{
					this.OnSceneEquipEnhanceChg();
				}, null, 0f, false);
				return;
			}
			this.OnSceneEquipEnhanceChg();
		}

		// Token: 0x06011409 RID: 70665 RVA: 0x004F99EE File Offset: 0x004F7DEE
		private void OnSceneEquipEnhanceChg()
		{
			DataManager<EquipGrowthDataManager>.GetInstance().OnSceneEquipEnhanceChg(this.mSelectEquipItemData, (uint)this.mExpendItemData.TableID, (byte)this.mSelectChangeGrowthArrtType);
		}

		// Token: 0x0400B22B RID: 45611
		[SerializeField]
		private List<GrowthArrtData> mGrowthArrtDataList = new List<GrowthArrtData>();

		// Token: 0x0400B22C RID: 45612
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B22D RID: 45613
		[SerializeField]
		private GameObject mExpendItemParent;

		// Token: 0x0400B22E RID: 45614
		[SerializeField]
		private Button mOpenExpendFrameBtn;

		// Token: 0x0400B22F RID: 45615
		[SerializeField]
		private Button mChangedBtn;

		// Token: 0x0400B230 RID: 45616
		[SerializeField]
		private Text mArrtDesc;

		// Token: 0x0400B231 RID: 45617
		[SerializeField]
		private ComUIListScript mArrtUIListScript;

		// Token: 0x0400B232 RID: 45618
		[SerializeField]
		private StateController mExpendStateCtl;

		// Token: 0x0400B233 RID: 45619
		[SerializeField]
		private StateController mEquipStateCtrl;

		// Token: 0x0400B234 RID: 45620
		[SerializeField]
		private Text mExpendName;

		// Token: 0x0400B235 RID: 45621
		[SerializeField]
		private Text mExpendCount;

		// Token: 0x0400B236 RID: 45622
		[SerializeField]
		private int mMinLevel = 8;

		// Token: 0x0400B237 RID: 45623
		[SerializeField]
		private int mMaxLevel = 10;

		// Token: 0x0400B238 RID: 45624
		private StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B239 RID: 45625
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B23A RID: 45626
		private ComItem mEquipComItem;

		// Token: 0x0400B23B RID: 45627
		private ComItem mExpendComItem;

		// Token: 0x0400B23C RID: 45628
		private EGrowthAttrType mSelectChangeGrowthArrtType;

		// Token: 0x0400B23D RID: 45629
		private ItemData mExpendItemData;

		// Token: 0x0400B23E RID: 45630
		private ItemData mSelectEquipItemData;

		// Token: 0x0400B23F RID: 45631
		private int iExpendCount;

		// Token: 0x0400B240 RID: 45632
		private ItemData creatItemData;

		// Token: 0x0400B241 RID: 45633
		private ItemData overLoadItemData;

		// Token: 0x0400B242 RID: 45634
		private ItemData changedItemData;

		// Token: 0x0400B243 RID: 45635
		private List<SaveAttrData> mChangeGrowthArrtList = new List<SaveAttrData>();

		// Token: 0x0400B244 RID: 45636
		private GrowthArrtData mGrowthArrtData;

		// Token: 0x0400B245 RID: 45637
		private int timeLeft;

		// Token: 0x0400B246 RID: 45638
		private bool bStartCountdown;

		// Token: 0x0400B247 RID: 45639
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
