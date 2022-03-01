using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AC4 RID: 6852
	public class BeadMosaicView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010D1C RID: 68892 RVA: 0x004CB354 File Offset: 0x004C9754
		private void Awake()
		{
			this.RegisterEventHandler();
			if (this.BtnAddSarah != null)
			{
				this.BtnAddSarah.onClick.RemoveAllListeners();
				this.BtnAddSarah.onClick.AddListener(new UnityAction(this.OnAddSarahClick));
			}
			if (this.BtnPickBead != null)
			{
				this.BtnPickBead.onClick.RemoveAllListeners();
				this.BtnPickBead.onClick.AddListener(new UnityAction(this.OnBtnPickBeadClick));
			}
			if (this.BtnRepalceBead != null)
			{
				this.BtnRepalceBead.onClick.RemoveAllListeners();
				this.BtnRepalceBead.onClick.AddListener(new UnityAction(this.OnBtnRepalceBeadClick));
			}
		}

		// Token: 0x06010D1D RID: 68893 RVA: 0x004CB420 File Offset: 0x004C9820
		private void OnDestroy()
		{
			this.UnRegisterEventHandler();
			this.m_kBeadComEquipmentList.UnInitialize();
			this.m_kComSarahCardInlayItemList.UnInitialize();
			this.UnInitItemTabComUIList();
			this.mBeadItemList.Clear();
			this.mCurrentSelectItemTab = ItemTabType.ITT_EQUIP;
			this.DefaultItemTabIndex = 0;
			this.mIndex = 0;
			this.m_kComEquipItem = null;
			this.m_kBeadComItem = null;
		}

		// Token: 0x06010D1E RID: 68894 RVA: 0x004CB480 File Offset: 0x004C9880
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.InitInterface();
			this.SetDefaultItemTabIndex(linkData);
			this.InitSarahCardsObjects(linkData);
			if (!this.m_kBeadComEquipmentList.Initilized)
			{
				this.m_kBeadComEquipmentList.Initialize(this.mEquipmentScrollView, new BeadEquipmentList.OnItemSelected(this.OnItemSelected), this.mCurrentSelectItemTab, linkData);
			}
			this.InitItemTabComUIList();
		}

		// Token: 0x06010D1F RID: 68895 RVA: 0x004CB4DB File Offset: 0x004C98DB
		public void OnEnableView()
		{
			this.RegisterDelegateHandler();
			this.m_kBeadComEquipmentList.RefreshAllEquipments(this.mCurrentSelectItemTab);
		}

		// Token: 0x06010D20 RID: 68896 RVA: 0x004CB4F4 File Offset: 0x004C98F4
		public void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06010D21 RID: 68897 RVA: 0x004CB4FC File Offset: 0x004C98FC
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010D22 RID: 68898 RVA: 0x004CB57C File Offset: 0x004C997C
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010D23 RID: 68899 RVA: 0x004CB5FC File Offset: 0x004C99FC
		private void RegisterEventHandler()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAddSarahSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsSarahChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BeadPickSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsSarahChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSarakCardSelected, new ClientEventSystem.UIEventHandler(this.OnSarahCardSelected));
			this.RegisterDelegateHandler();
		}

		// Token: 0x06010D24 RID: 68900 RVA: 0x004CB660 File Offset: 0x004C9A60
		private void UnRegisterEventHandler()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAddSarahSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsSarahChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BeadPickSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsSarahChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSarakCardSelected, new ClientEventSystem.UIEventHandler(this.OnSarahCardSelected));
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06010D25 RID: 68901 RVA: 0x004CB6C4 File Offset: 0x004C9AC4
		private void OnSlotItemsSarahChanged(UIEvent uiEvent)
		{
			this.m_kBeadComEquipmentList.RefreshAllEquipments(this.mCurrentSelectItemTab);
			this.OnSarahItemChanged();
			BeadItem.ms_select = null;
		}

		// Token: 0x06010D26 RID: 68902 RVA: 0x004CB6E4 File Offset: 0x004C9AE4
		private void OnSarahCardSelected(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			this.OnSarahCardChanged(itemData);
		}

		// Token: 0x06010D27 RID: 68903 RVA: 0x004CB704 File Offset: 0x004C9B04
		private void OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (!flag && this.m_kComSarahCardInlayItemList.HasObject(item.GUID))
					{
						ItemData itemData = ComSarahCardInlayItem._TryAddSarahCard(items[i].uid);
						if (itemData != null)
						{
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COMMON);
			}
		}

		// Token: 0x06010D28 RID: 68904 RVA: 0x004CB79C File Offset: 0x004C9B9C
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			ComBeadEquipment equipment = this.m_kBeadComEquipmentList.GetEquipment(itemData.GUID);
			if (equipment != null)
			{
				this.m_kBeadComEquipmentList.RefreshAllEquipments(this.mCurrentSelectItemTab);
			}
			if (this.m_kComSarahCardInlayItemList.HasObject(itemData.GUID))
			{
				this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COMMON);
			}
		}

		// Token: 0x06010D29 RID: 68905 RVA: 0x004CB804 File Offset: 0x004C9C04
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] != null)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
					if (item != null)
					{
						ComBeadEquipment equipment = this.m_kBeadComEquipmentList.GetEquipment(items[i].uid);
						if (equipment != null)
						{
							this.m_kBeadComEquipmentList.RefreshAllEquipments(this.mCurrentSelectItemTab);
						}
						if (!flag && this.m_kComSarahCardInlayItemList.HasObject(item.GUID))
						{
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COMMON);
			}
		}

		// Token: 0x06010D2A RID: 68906 RVA: 0x004CB8C4 File Offset: 0x004C9CC4
		private void OnItemSelected(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (itemData.Type == ItemTable.eType.FUCKTITTLE)
			{
				bool flag = itemData.Packing || itemData.iMaxPackTime > 0;
				if (flag)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("BeadInlay_TitleDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
			}
			this.mIndex = 1;
			this.mCurrentSelectPreciousBeadMountHoleType = PreciousBeadMountHoleType.PBMHT_COMMON;
			this.fuctionData.leftItem = null;
			this.fuctionData.rightItem = itemData;
			this.m_kComSarahCardInlayItemList.ClearSelectedItem();
			this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COMMON);
			this.OnSarahItemChanged();
		}

		// Token: 0x06010D2B RID: 68907 RVA: 0x004CB958 File Offset: 0x004C9D58
		private void InitInterface()
		{
			if (this.m_kComEquipItem == null)
			{
				this.m_kComEquipItem = ComItemManager.Create(this.m_kEquipItem);
			}
			this.mNomalBeadItemPath = this.mBeadComcomBind.GetPrefabPath("nomalBeadItemPath");
			this.mColorFulBeadItemPath = this.mBeadComcomBind.GetPrefabPath("colorFulBeadItemPath");
		}

		// Token: 0x06010D2C RID: 68908 RVA: 0x004CB9B4 File Offset: 0x004C9DB4
		private void SetDefaultItemTabIndex(SmithShopNewLinkData linkData)
		{
			this.DefaultItemTabIndex = 0;
			if (linkData != null && linkData.itemData != null)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(linkData.itemData.TableID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Parts.Contains(10))
				{
					this.DefaultItemTabIndex = 1;
				}
				if (linkData.itemData.Type == ItemTable.eType.FUCKTITTLE && linkData.itemData.SubType == 10)
				{
					this.DefaultItemTabIndex = 1;
				}
			}
		}

		// Token: 0x06010D2D RID: 68909 RVA: 0x004CBA42 File Offset: 0x004C9E42
		private void OnSarahItemChanged()
		{
			this.RefreshEquipItem();
			this.CreatBeadInlaidHole();
			this.UpdateFunctionButtonState();
			this.CheckAddSarahLink();
		}

		// Token: 0x06010D2E RID: 68910 RVA: 0x004CBA5C File Offset: 0x004C9E5C
		private void RefreshEquipItem()
		{
			if (this.fuctionData.rightItem != null)
			{
				ComItem kComEquipItem = this.m_kComEquipItem;
				ItemData rightItem = this.fuctionData.rightItem;
				if (BeadMosaicView.<>f__mg$cache0 == null)
				{
					BeadMosaicView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				kComEquipItem.Setup(rightItem, BeadMosaicView.<>f__mg$cache0);
				this.equipName.text = this.fuctionData.rightItem.GetColorName(string.Empty, false);
			}
			else
			{
				this.m_kComEquipItem.Setup(null, null);
				this.equipName.text = string.Empty;
			}
		}

		// Token: 0x06010D2F RID: 68911 RVA: 0x004CBAF0 File Offset: 0x004C9EF0
		private void CreatBeadInlaidHole()
		{
			if (this.fuctionData.rightItem == null)
			{
				return;
			}
			if (this.fuctionData.leftItem != null && this.fuctionData.rightItem != null)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.fuctionData.leftItem.TableID, string.Empty, string.Empty);
				if (tableItem == null || !tableItem.Parts.Contains((int)this.fuctionData.rightItem.EquipWearSlotType))
				{
					this.fuctionData.leftItem = null;
				}
			}
			this.mBeadComcomBind.ClearCacheBinds(this.mNomalBeadItemPath);
			this.mBeadComcomBind.ClearCacheBinds(this.mColorFulBeadItemPath);
			this.mBeadItemList.Clear();
			for (int i = 0; i < this.fuctionData.rightItem.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = this.fuctionData.rightItem.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					ComCommonBind comCommonBind;
					if (precBead.type == 1)
					{
						comCommonBind = this.mBeadComcomBind.LoadExtraBind(this.mNomalBeadItemPath);
					}
					else
					{
						comCommonBind = this.mBeadComcomBind.LoadExtraBind(this.mColorFulBeadItemPath);
					}
					Utility.AttachTo(comCommonBind.gameObject, this.mBeadItemRoot, false);
					BeadItemElement com = comCommonBind.GetCom<BeadItemElement>("BeadItemElement");
					if (com != null)
					{
						com.InitBeadItemVisiable(precBead, new OnBeadItemClick(this.OpenBeadCardsObjectRoot), new Action(this.CloseCallBack));
					}
					SaveBeadItemInfo item = new SaveBeadItemInfo(precBead, comCommonBind, this.m_kBeadComItem);
					this.mBeadItemList.Add(item);
				}
			}
		}

		// Token: 0x06010D30 RID: 68912 RVA: 0x004CBC92 File Offset: 0x004CA092
		private void OpenBeadCardsObjectRoot(PrecBead preBead)
		{
			if (preBead == null)
			{
				return;
			}
			this.OpenBeadCardsObjectRoot(preBead.index, (PreciousBeadMountHoleType)preBead.type);
		}

		// Token: 0x06010D31 RID: 68913 RVA: 0x004CBCAD File Offset: 0x004CA0AD
		private void OpenBeadCardsObjectRoot(int index, PreciousBeadMountHoleType type)
		{
			this.mIndex = index;
			this.mCurrentSelectPreciousBeadMountHoleType = type;
			this.OnOpenSarahCardsObjects();
		}

		// Token: 0x06010D32 RID: 68914 RVA: 0x004CBCC3 File Offset: 0x004CA0C3
		private void OnOpenSarahCardsObjects()
		{
			if (this.mCurrentSelectPreciousBeadMountHoleType == PreciousBeadMountHoleType.PBMHT_COMMON)
			{
				this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COMMON);
			}
			else
			{
				this.m_kComSarahCardInlayItemList.RefreshAllEquipments(PreciousBeadMountHoleType.PBMHT_COLOUR);
			}
			this.m_goBeadCardsObjects.CustomActive(true);
			this.CheckAddSarahLink();
		}

		// Token: 0x06010D33 RID: 68915 RVA: 0x004CBD00 File Offset: 0x004CA100
		private void CheckAddSarahLink()
		{
			if (this.m_goAddBeadComeLink != null)
			{
				this.m_goAddBeadComeLink.CustomActive(!this.m_kComSarahCardInlayItemList.HasEquipments());
			}
		}

		// Token: 0x06010D34 RID: 68916 RVA: 0x004CBD2C File Offset: 0x004CA12C
		private void CloseCallBack()
		{
			this.fuctionData.leftItem = null;
		}

		// Token: 0x06010D35 RID: 68917 RVA: 0x004CBD3C File Offset: 0x004CA13C
		private void UpdateFunctionButtonState()
		{
			if (this.fuctionData.rightItem == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < this.fuctionData.rightItem.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = this.fuctionData.rightItem.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(precBead.preciousBeadId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ReplacejewelsTable beadReplaceJewelsTableData = DataManager<BeadCardManager>.GetInstance().GetBeadReplaceJewelsTableData(tableItem.Color, tableItem.Level, tableItem.BeadType);
						if (beadReplaceJewelsTableData != null)
						{
							flag2 = true;
							if (beadReplaceJewelsTableData.ReplaceNum != 0)
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			if (flag2 && !flag)
			{
				this.mBeadStateCol.Key = this.mStateHasHoleBead;
			}
			else if (flag2 && flag)
			{
				this.mBeadStateCol.Key = this.mStateHasLowHoleBead;
			}
			else
			{
				this.mBeadStateCol.Key = this.mSateNoHoleBead;
			}
		}

		// Token: 0x06010D36 RID: 68918 RVA: 0x004CBE5C File Offset: 0x004CA25C
		private void OnRefreshBeadItemChange()
		{
			for (int i = 0; i < this.mBeadItemList.Count; i++)
			{
				SaveBeadItemInfo saveBeadItemInfo = this.mBeadItemList[i];
				if (this.mIndex == saveBeadItemInfo.mBeadMountHole.index)
				{
					if (saveBeadItemInfo.mBind != null)
					{
						BeadItemElement com = saveBeadItemInfo.mBind.GetCom<BeadItemElement>("BeadItemElement");
						if (com != null)
						{
							if (com.BeadStateIsHasBeenSet())
							{
								com.SetBeadCardState(BeadCardState.Replace, this.fuctionData.leftItem);
							}
							else
							{
								com.SetBeadCardState(BeadCardState.CanBeSet, this.fuctionData.leftItem);
							}
						}
					}
				}
			}
		}

		// Token: 0x06010D37 RID: 68919 RVA: 0x004CBF10 File Offset: 0x004CA310
		private void InitItemTabComUIList()
		{
			this.mItemTabComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mItemTabComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mItemTabComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			this.mItemTabComUIListScript.SetElementAmount(this.mItemTabDataList.Count);
		}

		// Token: 0x06010D38 RID: 68920 RVA: 0x004CBF8C File Offset: 0x004CA38C
		private void UnInitItemTabComUIList()
		{
			if (this.mItemTabComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mItemTabComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mItemTabComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mItemTabComUIListScript = null;
			}
		}

		// Token: 0x06010D39 RID: 68921 RVA: 0x004CBFFF File Offset: 0x004CA3FF
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x06010D3A RID: 68922 RVA: 0x004CC008 File Offset: 0x004CA408
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mItemTabDataList.Count)
			{
				ItemTabModelData mItemTabData = this.mItemTabDataList[item.m_index];
				Toggle com = comCommonBind.GetCom<Toggle>("toggle");
				Text com2 = comCommonBind.GetCom<Text>("name");
				Text com3 = comCommonBind.GetCom<Text>("checkname");
				Text text = com2;
				string mName = mItemTabData.mName;
				com3.text = mName;
				text.text = mName;
				com.onValueChanged.RemoveAllListeners();
				com.onValueChanged.AddListener(delegate(bool value)
				{
					if (value)
					{
						if (this.mCurrentSelectItemTab == mItemTabData.mItemTabType)
						{
							return;
						}
						this.mCurrentSelectItemTab = mItemTabData.mItemTabType;
						if (this.mCurrentSelectItemTab == ItemTabType.ITT_EQUIP)
						{
							this.SetItemLinkID(119);
						}
						else
						{
							this.SetItemLinkID(227);
						}
						this.m_kBeadComEquipmentList.RefreshAllEquipments(this.mCurrentSelectItemTab);
					}
				});
				if (mItemTabData.mIndex == this.DefaultItemTabIndex && com != null)
				{
					com.isOn = true;
				}
			}
		}

		// Token: 0x06010D3B RID: 68923 RVA: 0x004CC101 File Offset: 0x004CA501
		private void SetItemLinkID(int linkID)
		{
			if (this.m_ItemComLink != null)
			{
				this.m_ItemComLink.iItemLinkID = linkID;
			}
		}

		// Token: 0x06010D3C RID: 68924 RVA: 0x004CC120 File Offset: 0x004CA520
		private void InitSarahCardsObjects(SmithShopNewLinkData linkData)
		{
			this.m_kComSarahCardInlayItemList.Initialize(this.mScrollView, new ComSarahCardInlayItemList.OnItemSelected(this.OnSarahCardChanged), linkData, this.fuctionData);
		}

		// Token: 0x06010D3D RID: 68925 RVA: 0x004CC146 File Offset: 0x004CA546
		private void OnSarahCardChanged(ItemData itemData)
		{
			this.fuctionData.leftItem = itemData;
			this.m_goBeadCardsObjects.CustomActive(false);
			this.OnRefreshBeadItemChange();
		}

		// Token: 0x06010D3E RID: 68926 RVA: 0x004CC166 File Offset: 0x004CA566
		private void OnAddSarahClick()
		{
			if (this.BtnAddSarah != null)
			{
				this.BtnAddSarah.enabled = false;
				InvokeMethod.Invoke(this, 0.5f, delegate()
				{
					if (this.BtnAddSarah != null)
					{
						this.BtnAddSarah.enabled = true;
					}
				});
			}
			this.OnClickFunctionAddSarah();
		}

		// Token: 0x06010D3F RID: 68927 RVA: 0x004CC1A4 File Offset: 0x004CA5A4
		private void OnClickFunctionAddSarah()
		{
			if (this.fuctionData != null)
			{
				if (this.fuctionData.leftItem != null && this.fuctionData.rightItem != null)
				{
					if (this.fuctionData.rightItem.PreciousBeadMountHole == null || this.fuctionData.rightItem.PreciousBeadMountHole[this.mIndex - 1] == null)
					{
						this.SceneMountPreciousBeadReq();
					}
					else
					{
						BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.fuctionData.rightItem.PreciousBeadMountHole[this.mIndex - 1].preciousBeadId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							this.SendSceneMountPreciousBeadReq();
						}
						else
						{
							this.SceneMountPreciousBeadReq();
						}
					}
				}
				else if (this.fuctionData.rightItem == null)
				{
					SystemNotifyManager.SystemNotify(1141, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(1140, string.Empty);
				}
			}
		}

		// Token: 0x06010D40 RID: 68928 RVA: 0x004CC29C File Offset: 0x004CA69C
		private void SceneMountPreciousBeadReq()
		{
			string msgContent = TR.Value("HideGradeBeadInalyDesc");
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.fuctionData.leftItem.GUID);
			if (item != null)
			{
				if (item.Quality == ItemTable.eColor.PINK)
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this.SedndSceneMountPreciousBeadReq), null, 0f, false);
				}
				else
				{
					this.SedndSceneMountPreciousBeadReq();
				}
			}
		}

		// Token: 0x06010D41 RID: 68929 RVA: 0x004CC308 File Offset: 0x004CA708
		private void SedndSceneMountPreciousBeadReq()
		{
			if (this.fuctionData != null && this.fuctionData.leftItem != null && this.fuctionData.rightItem != null)
			{
				ulong guid = this.fuctionData.leftItem.GUID;
				ulong guid2 = this.fuctionData.rightItem.GUID;
				DataManager<BeadCardManager>.GetInstance().SedndSceneMountPreciousBeadReq(guid, guid2, (byte)this.mIndex);
			}
		}

		// Token: 0x06010D42 RID: 68930 RVA: 0x004CC378 File Offset: 0x004CA778
		private void SendSceneMountPreciousBeadReq()
		{
			AdjustResultFrame.AdjustResultFrameData adjustResultFrameData = new AdjustResultFrame.AdjustResultFrameData();
			AdjustResultFrame.AdjustResultFrameData adjustResultFrameData2 = adjustResultFrameData;
			adjustResultFrameData2.callback = (UnityAction)Delegate.Combine(adjustResultFrameData2.callback, new UnityAction(this._SendReq));
			if (this.fuctionData != null)
			{
				ItemData leftItem = this.fuctionData.leftItem;
				ItemData rightItem = this.fuctionData.rightItem;
				ItemData itemData = null;
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				if (rightItem != null)
				{
					PrecBead[] preciousBeadMountHole = rightItem.PreciousBeadMountHole;
					if (preciousBeadMountHole != null)
					{
						if (this.mIndex - 1 >= 0 && this.mIndex - 1 < preciousBeadMountHole.Length)
						{
							itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(preciousBeadMountHole[this.mIndex - 1].preciousBeadId);
							text3 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(preciousBeadMountHole[this.mIndex - 1].preciousBeadId, true);
							if (preciousBeadMountHole[this.mIndex - 1].randomBuffId > 0)
							{
								text2 = string.Format("[<color=#809CB3FF>附加属性:</color>{0}]", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(preciousBeadMountHole[this.mIndex - 1].randomBuffId));
							}
						}
						else
						{
							Logger.LogErrorFormat("PreciousBeadMountHole is out of range in [SendSceneMountPreciousBeadReq], mIndex = {0},PreciousBeadMountHole.Length = {1} ", new object[]
							{
								this.mIndex,
								preciousBeadMountHole.Length
							});
						}
					}
					else
					{
						Logger.LogError("PreciousBeadMountHole is null in [SendSceneMountPreciousBeadReq]");
					}
				}
				else
				{
					Logger.LogError("rightItem is null in [SendSceneMountPreciousBeadReq]");
				}
				if (leftItem != null && leftItem.BeadAdditiveAttributeBuffID > 0)
				{
					text = string.Format("[<color=#809CB3FF>附加属性:</color>{0}]", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(leftItem.BeadAdditiveAttributeBuffID));
				}
				if (leftItem != null && itemData != null)
				{
					adjustResultFrameData.desc = string.Format("使用[{0}]{1}的[{2}]\n替换\n[{3}]{4}的[{5}]\n被替换的宝珠将会消失，确定要替换？", new object[]
					{
						DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(leftItem.TableID, true),
						text,
						leftItem.GetColorName(string.Empty, false),
						text3,
						text2,
						itemData.GetColorName(string.Empty, false)
					});
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjustResultFrame>(FrameLayer.Middle, adjustResultFrameData, string.Empty);
				}
			}
			else
			{
				Logger.LogError("fuctionData is null in [SendSceneMountPreciousBeadReq]");
			}
		}

		// Token: 0x06010D43 RID: 68931 RVA: 0x004CC58E File Offset: 0x004CA98E
		private void _SendReq()
		{
			DataManager<BeadCardManager>.GetInstance().SedndSceneMountPreciousBeadReq(this.fuctionData.leftItem.GUID, this.fuctionData.rightItem.GUID, (byte)this.mIndex);
		}

		// Token: 0x06010D44 RID: 68932 RVA: 0x004CC5C4 File Offset: 0x004CA9C4
		private void OnBtnPickBeadClick()
		{
			BeadPickModel userData = null;
			for (int i = 0; i < this.fuctionData.rightItem.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = this.fuctionData.rightItem.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					userData = new BeadPickModel(precBead, this.fuctionData.rightItem);
					break;
				}
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BeadPickFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x06010D45 RID: 68933 RVA: 0x004CC640 File Offset: 0x004CAA40
		private void OnBtnRepalceBeadClick()
		{
			BeadPerfectReplacementModel userData = new BeadPerfectReplacementModel(this.fuctionData.rightItem);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BeadPerfectReplacementFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0400AC82 RID: 44162
		[SerializeField]
		private List<ItemTabModelData> mItemTabDataList;

		// Token: 0x0400AC83 RID: 44163
		[SerializeField]
		private ComUIListScript mItemTabComUIListScript;

		// Token: 0x0400AC84 RID: 44164
		[SerializeField]
		private ItemComeLink m_ItemComLink;

		// Token: 0x0400AC85 RID: 44165
		[SerializeField]
		private ComCommonBind mBeadComcomBind;

		// Token: 0x0400AC86 RID: 44166
		[SerializeField]
		private GameObject mBeadItemRoot;

		// Token: 0x0400AC87 RID: 44167
		[SerializeField]
		private GameObject m_kEquipItem;

		// Token: 0x0400AC88 RID: 44168
		[SerializeField]
		private GameObject m_goAddBeadComeLink;

		// Token: 0x0400AC89 RID: 44169
		[SerializeField]
		private GameObject m_goBeadCardsObjects;

		// Token: 0x0400AC8A RID: 44170
		[SerializeField]
		private GameObject mScrollView;

		// Token: 0x0400AC8B RID: 44171
		[SerializeField]
		private GameObject mEquipmentScrollView;

		// Token: 0x0400AC8C RID: 44172
		[SerializeField]
		private Text equipName;

		// Token: 0x0400AC8D RID: 44173
		[SerializeField]
		private Button BtnAddSarah;

		// Token: 0x0400AC8E RID: 44174
		[SerializeField]
		private Button BtnPickBead;

		// Token: 0x0400AC8F RID: 44175
		[SerializeField]
		private Button BtnRepalceBead;

		// Token: 0x0400AC90 RID: 44176
		[SerializeField]
		private StateController mBeadStateCol;

		// Token: 0x0400AC91 RID: 44177
		[SerializeField]
		private string mNomalBeadItemPath = string.Empty;

		// Token: 0x0400AC92 RID: 44178
		[SerializeField]
		private string mColorFulBeadItemPath = string.Empty;

		// Token: 0x0400AC93 RID: 44179
		private List<SaveBeadItemInfo> mBeadItemList = new List<SaveBeadItemInfo>();

		// Token: 0x0400AC94 RID: 44180
		private ComSarahCardInlayItemList m_kComSarahCardInlayItemList = new ComSarahCardInlayItemList();

		// Token: 0x0400AC95 RID: 44181
		private BeadEquipmentList m_kBeadComEquipmentList = new BeadEquipmentList();

		// Token: 0x0400AC96 RID: 44182
		private ItemTabType mCurrentSelectItemTab;

		// Token: 0x0400AC97 RID: 44183
		private int DefaultItemTabIndex;

		// Token: 0x0400AC98 RID: 44184
		private int mIndex;

		// Token: 0x0400AC99 RID: 44185
		private PreciousBeadMountHoleType mCurrentSelectPreciousBeadMountHoleType;

		// Token: 0x0400AC9A RID: 44186
		private SarahsFuctionData fuctionData = new SarahsFuctionData();

		// Token: 0x0400AC9B RID: 44187
		private ComItem m_kComEquipItem;

		// Token: 0x0400AC9C RID: 44188
		private ComItem m_kBeadComItem;

		// Token: 0x0400AC9D RID: 44189
		private string mSateNoHoleBead = "NoHoleBead";

		// Token: 0x0400AC9E RID: 44190
		private string mStateHasHoleBead = "HasHoleBead";

		// Token: 0x0400AC9F RID: 44191
		private string mStateHasLowHoleBead = "HasLowHoleBead";

		// Token: 0x0400ACA0 RID: 44192
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
