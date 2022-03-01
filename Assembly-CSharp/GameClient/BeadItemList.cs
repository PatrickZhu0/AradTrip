using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001ABE RID: 6846
	internal class BeadItemList
	{
		// Token: 0x17001D6D RID: 7533
		// (get) Token: 0x06010D02 RID: 68866 RVA: 0x004CA9B3 File Offset: 0x004C8DB3
		public bool Initilized
		{
			get
			{
				return this.bInitilized;
			}
		}

		// Token: 0x06010D03 RID: 68867 RVA: 0x004CA9BB File Offset: 0x004C8DBB
		public List<BeadItemModel> GetBeadItemList()
		{
			return this.equipments;
		}

		// Token: 0x06010D04 RID: 68868 RVA: 0x004CA9C4 File Offset: 0x004C8DC4
		private BeadItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<BeadItem>();
		}

		// Token: 0x06010D05 RID: 68869 RVA: 0x004CA9DC File Offset: 0x004C8DDC
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			if (beadItem != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				beadItem.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010D06 RID: 68870 RVA: 0x004CAA3C File Offset: 0x004C8E3C
		private void _OnItemSelectDelegate(ComUIListElementScript item)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			BeadItem.ms_select = ((!(beadItem == null)) ? beadItem.Model : null);
			if (this.onItemSelect != null)
			{
				this.onItemSelect(BeadItem.ms_select);
			}
		}

		// Token: 0x06010D07 RID: 68871 RVA: 0x004CAA90 File Offset: 0x004C8E90
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			BeadItem beadItem = item.gameObjectBindScript as BeadItem;
			if (beadItem != null)
			{
				beadItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010D08 RID: 68872 RVA: 0x004CAABC File Offset: 0x004C8EBC
		public void Initialize(GameObject gameObject, BeadItemList.OnItemSelect onItemSelected, SmithShopNewLinkData linkData)
		{
			if (this.Initilized)
			{
				return;
			}
			this.bInitilized = true;
			this.gameObject = gameObject;
			this.onItemSelect = (BeadItemList.OnItemSelect)Delegate.Combine(this.onItemSelect, onItemSelected);
			this.linkData = linkData;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.comUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectDelegate));
			ComUIListScript comUIListScript4 = this.comUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			this._LoadAllBeadItems(ref this.equipments);
			this._BindLinkData();
			this._TrySetDefultBeadItem();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBeadUpgradeSuccess, new ClientEventSystem.UIEventHandler(this._OnBeadUpgradeSuccess));
		}

		// Token: 0x06010D09 RID: 68873 RVA: 0x004CABEC File Offset: 0x004C8FEC
		public void RefreshAllBeadItems()
		{
			this._LoadAllBeadItems(ref this.equipments);
			this._TrySetDefultBeadItem();
		}

		// Token: 0x06010D0A RID: 68874 RVA: 0x004CAC00 File Offset: 0x004C9000
		private void _LoadAllBeadItems(ref List<BeadItemModel> kBeadItems)
		{
			kBeadItems.Clear();
			List<BeadItemModel> list = new List<BeadItemModel>();
			List<BeadItemModel> collection = this._AddBeadItems(EPackageType.Equip);
			List<BeadItemModel> collection2 = this._AddBeadItems(EPackageType.WearEquip);
			List<BeadItemModel> list2 = this._AddBeadItems(EPackageType.Consumable);
			list.AddRange(collection);
			list.AddRange(collection2);
			list.Sort(new Comparison<BeadItemModel>(this._SortBeadItems));
			list2.Sort(new Comparison<BeadItemModel>(this._SortBeadItems));
			kBeadItems.AddRange(list);
			kBeadItems.AddRange(list2);
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010D0B RID: 68875 RVA: 0x004CAC8C File Offset: 0x004C908C
		private int _SortBeadItems(BeadItemModel left, BeadItemModel right)
		{
			if (left.beadItemData.Quality != right.beadItemData.Quality)
			{
				return right.beadItemData.Quality - left.beadItemData.Quality;
			}
			return this.GetBeadLevel(right.beadItemData.TableID) - this.GetBeadLevel(left.beadItemData.TableID);
		}

		// Token: 0x06010D0C RID: 68876 RVA: 0x004CACF0 File Offset: 0x004C90F0
		private int GetBeadLevel(int beadId)
		{
			int result = 0;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(beadId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Level;
			}
			return result;
		}

		// Token: 0x06010D0D RID: 68877 RVA: 0x004CAD24 File Offset: 0x004C9124
		private List<BeadItemModel> _AddBeadItems(EPackageType ePackageType)
		{
			List<BeadItemModel> list = new List<BeadItemModel>();
			if (ePackageType == EPackageType.Equip || ePackageType == EPackageType.WearEquip)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(ePackageType);
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						if (item.PreciousBeadMountHole != null)
						{
							for (int j = 0; j < item.PreciousBeadMountHole.Length; j++)
							{
								PrecBead precBead = item.PreciousBeadMountHole[j];
								if (precBead != null)
								{
									ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(precBead.preciousBeadId);
									if (commonItemTableDataByID != null)
									{
										BeadItemModel item2 = new BeadItemModel(1, commonItemTableDataByID, precBead.index, item, precBead.randomBuffId, precBead.pickNumber, precBead.type, precBead.beadReplaceNumber);
										list.Add(item2);
									}
								}
							}
						}
					}
				}
			}
			else if (ePackageType == EPackageType.Consumable)
			{
				List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(ePackageType);
				for (int k = 0; k < itemsByPackageType2.Count; k++)
				{
					ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[k]);
					if (item3 != null)
					{
						if (item3.SubType == 54)
						{
							BeadItemModel item4 = new BeadItemModel(0, item3, 0, null, item3.BeadAdditiveAttributeBuffID, item3.BeadPickNumber, 0, item3.BeadReplaceNumber);
							list.Add(item4);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06010D0E RID: 68878 RVA: 0x004CAEB4 File Offset: 0x004C92B4
		private void _TrySetDefultBeadItem()
		{
			int iBindIndex = -1;
			if (BeadItem.ms_select != null)
			{
				for (int i = 0; i < this.equipments.Count; i++)
				{
					if (BeadItem.ms_select.mountedType == 1)
					{
						if (this.equipments[i].beadItemData.TableID == BeadItem.ms_select.beadItemData.TableID && this.equipments[i].equipItemData.GUID == BeadItem.ms_select.equipItemData.GUID)
						{
							iBindIndex = i;
							break;
						}
					}
					else if (this.equipments[i].beadItemData.GUID == BeadItem.ms_select.beadItemData.GUID)
					{
						iBindIndex = i;
						break;
					}
				}
			}
			else if (this.equipments.Count > 0)
			{
				iBindIndex = 0;
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010D0F RID: 68879 RVA: 0x004CAFAC File Offset: 0x004C93AC
		private void _TrySelectedItem(ulong guid)
		{
			int iBindIndex = -1;
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i].beadItemData.GUID == guid)
				{
					iBindIndex = i;
					break;
				}
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010D10 RID: 68880 RVA: 0x004CB004 File Offset: 0x004C9404
		private void _SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex < 0 || this.equipments.Count < 0)
			{
				return;
			}
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				BeadItem.ms_select = this.equipments[iBindIndex];
				if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.comUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.comUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.comUIListScript.SelectElement(-1, true);
				BeadItem.ms_select = null;
			}
			if (this.onItemSelect != null)
			{
				this.onItemSelect(BeadItem.ms_select);
			}
		}

		// Token: 0x06010D11 RID: 68881 RVA: 0x004CB0B0 File Offset: 0x004C94B0
		private void _BindLinkData()
		{
			if (this.linkData != null && this.linkData.itemData != null)
			{
				this._TrySelectedItem(this.linkData.itemData.GUID);
			}
		}

		// Token: 0x06010D12 RID: 68882 RVA: 0x004CB0E4 File Offset: 0x004C94E4
		private void _OnBeadUpgradeSuccess(UIEvent uiEvent)
		{
			BeadUpgradeResultData beadUpgradeResultData = uiEvent.Param1 as BeadUpgradeResultData;
			if (beadUpgradeResultData != null)
			{
				ItemData itemData = null;
				ItemData itemData2;
				if (beadUpgradeResultData.mountedType == 1)
				{
					itemData2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(beadUpgradeResultData.mBeadID);
					itemData = DataManager<ItemDataManager>.GetInstance().GetItem(beadUpgradeResultData.equipGuid);
					if (itemData == null)
					{
						Logger.LogErrorFormat("宝珠升级返回协议 [SceneUpgradePreciousbeadRes] 装备GUID  [equipGuid] 数据异常。", new object[0]);
					}
				}
				else
				{
					itemData2 = DataManager<ItemDataManager>.GetInstance().GetItem(beadUpgradeResultData.mBeadGUID);
				}
				if (itemData2 == null)
				{
					Logger.LogErrorFormat("宝珠升级返回协议 [SceneUpgradePreciousbeadRes] 宝珠ID  [precId] 数据异常。", new object[0]);
				}
				BeadItemModel ms_select = new BeadItemModel(beadUpgradeResultData.mountedType, itemData2, 0, itemData, 0, 0, 0, 0);
				BeadItem.ms_select = ms_select;
				this.RefreshAllBeadItems();
			}
		}

		// Token: 0x06010D13 RID: 68883 RVA: 0x004CB198 File Offset: 0x004C9598
		public void UnInitialize()
		{
			if (this.comUIListScript != null)
			{
				ComUIListScript comUIListScript = this.comUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.comUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.comUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectDelegate));
				ComUIListScript comUIListScript4 = this.comUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
				this.comUIListScript = null;
			}
			this.onItemSelect = (BeadItemList.OnItemSelect)Delegate.Remove(this.onItemSelect, this.onItemSelect);
			this.gameObject = null;
			this.equipments.Clear();
			BeadItem.ms_select = null;
			this.bInitilized = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBeadUpgradeSuccess, new ClientEventSystem.UIEventHandler(this._OnBeadUpgradeSuccess));
		}

		// Token: 0x0400AC70 RID: 44144
		private bool bInitilized;

		// Token: 0x0400AC71 RID: 44145
		private GameObject gameObject;

		// Token: 0x0400AC72 RID: 44146
		private ComUIListScript comUIListScript;

		// Token: 0x0400AC73 RID: 44147
		public BeadItemList.OnItemSelect onItemSelect;

		// Token: 0x0400AC74 RID: 44148
		private List<BeadItemModel> equipments = new List<BeadItemModel>();

		// Token: 0x0400AC75 RID: 44149
		public SmithShopNewLinkData linkData;

		// Token: 0x02001ABF RID: 6847
		// (Invoke) Token: 0x06010D15 RID: 68885
		public delegate void OnItemSelect(BeadItemModel model);
	}
}
