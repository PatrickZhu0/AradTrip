using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200123C RID: 4668
	public class EquipSuitDataManager : DataManager<EquipSuitDataManager>
	{
		// Token: 0x0600B37D RID: 45949 RVA: 0x0027EBD6 File Offset: 0x0027CFD6
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.EquipSuitDataManager;
		}

		// Token: 0x0600B37E RID: 45950 RVA: 0x0027EBDA File Offset: 0x0027CFDA
		public override void Initialize()
		{
			this.Clear();
		}

		// Token: 0x0600B37F RID: 45951 RVA: 0x0027EBE2 File Offset: 0x0027CFE2
		public override void Clear()
		{
			this.m_suitsDict.Clear();
			this.m_selfEquipSuitObjs.Clear();
		}

		// Token: 0x0600B380 RID: 45952 RVA: 0x0027EBFC File Offset: 0x0027CFFC
		public void InitSelfEquipSuits()
		{
			List<ItemData> list = ListPool<ItemData>.Get();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					list.Add(item);
				}
			}
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
			for (int j = 0; j < itemsByPackageType2.Count; j++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
				if (item != null)
				{
					list.Add(item);
				}
			}
			this._CalculateEquipSuitInfos(list, this.m_selfEquipSuitObjs);
			ListPool<ItemData>.Release(list);
		}

		// Token: 0x0600B381 RID: 45953 RVA: 0x0027ECB0 File Offset: 0x0027D0B0
		public void UpdateSelfEquipSuits(ItemData a_item, bool a_bEquiped)
		{
			if (a_item != null && (a_item.Type == ItemTable.eType.EQUIP || a_item.Type == ItemTable.eType.FASHION) && a_item.SuitID > 0)
			{
				if (!a_bEquiped)
				{
					EquipSuitObj selfEquipSuitObj = this.GetSelfEquipSuitObj(a_item.SuitID);
					if (selfEquipSuitObj != null && selfEquipSuitObj.wearedEquipIDs != null)
					{
						selfEquipSuitObj.wearedEquipIDs.Remove(a_item.TableID);
					}
				}
				else
				{
					EquipSuitObj equipSuitObj = null;
					this.m_selfEquipSuitObjs.TryGetValue(a_item.SuitID, out equipSuitObj);
					if (equipSuitObj == null)
					{
						equipSuitObj = new EquipSuitObj();
						equipSuitObj.wearedEquipIDs = new List<int>();
						equipSuitObj.equipSuitRes = this.GetEquipSuitRes(a_item.SuitID);
						this.m_selfEquipSuitObjs.Add(a_item.SuitID, equipSuitObj);
					}
					if (!equipSuitObj.wearedEquipIDs.Contains(a_item.TableID))
					{
						equipSuitObj.wearedEquipIDs.Add(a_item.TableID);
					}
				}
			}
		}

		// Token: 0x0600B382 RID: 45954 RVA: 0x0027ED9C File Offset: 0x0027D19C
		public EquipSuitObj GetSelfEquipSuitObj(int a_nSuitID)
		{
			if (a_nSuitID <= 0)
			{
				return null;
			}
			EquipSuitObj equipSuitObj = null;
			this.m_selfEquipSuitObjs.TryGetValue(a_nSuitID, out equipSuitObj);
			if (equipSuitObj == null)
			{
				equipSuitObj = this.CreateEmptyEquipSuitObj(a_nSuitID);
				this.m_selfEquipSuitObjs.Add(a_nSuitID, equipSuitObj);
			}
			return equipSuitObj;
		}

		// Token: 0x0600B383 RID: 45955 RVA: 0x0027EDE0 File Offset: 0x0027D1E0
		public EquipSuitObj CreateEmptyEquipSuitObj(int a_nSuitID)
		{
			EquipSuitRes equipSuitRes = this.GetEquipSuitRes(a_nSuitID);
			if (equipSuitRes == null)
			{
				return null;
			}
			return new EquipSuitObj
			{
				wearedEquipIDs = new List<int>(),
				equipSuitRes = equipSuitRes
			};
		}

		// Token: 0x0600B384 RID: 45956 RVA: 0x0027EE18 File Offset: 0x0027D218
		public Dictionary<int, EquipSuitObj> CalculateEquipSuitInfos(List<ItemData> a_arrItems)
		{
			if (a_arrItems == null)
			{
				return null;
			}
			Dictionary<int, EquipSuitObj> dictionary = new Dictionary<int, EquipSuitObj>();
			this._CalculateEquipSuitInfos(a_arrItems, dictionary);
			return dictionary;
		}

		// Token: 0x0600B385 RID: 45957 RVA: 0x0027EE3C File Offset: 0x0027D23C
		public EquipProp GetEquipSuitBasePropByIDs(List<int> itemIDs)
		{
			List<ItemData> list = ListPool<ItemData>.Get();
			for (int i = 0; i < itemIDs.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(itemIDs[i]);
				if (commonItemTableDataByID != null)
				{
					list.Add(commonItemTableDataByID);
				}
			}
			Dictionary<int, EquipSuitObj> dictionary = this.CalculateEquipSuitInfos(list);
			EquipProp equipProp = new EquipProp();
			foreach (KeyValuePair<int, EquipSuitObj> keyValuePair in dictionary)
			{
				EquipSuitObj value = keyValuePair.Value;
				if (value != null)
				{
					if (value.equipSuitRes == null)
					{
						string str = "GetEquipSuitBasePropByIDs suitObj {0} equipSuitRes is null";
						object[] array = new object[1];
						int num = 0;
						Dictionary<int, EquipSuitObj>.Enumerator enumerator;
						KeyValuePair<int, EquipSuitObj> keyValuePair2 = enumerator.Current;
						array[num] = keyValuePair2.Key;
						Logger.LogErrorFormat(str, array);
					}
					else if (value.wearedEquipIDs == null)
					{
						string str2 = "GetEquipSuitBasePropByIDs suitObj {0} wearedEquipIDs  is null";
						object[] array2 = new object[1];
						int num2 = 0;
						Dictionary<int, EquipSuitObj>.Enumerator enumerator;
						KeyValuePair<int, EquipSuitObj> keyValuePair3 = enumerator.Current;
						array2[num2] = keyValuePair3.Key;
						Logger.LogErrorFormat(str2, array2);
					}
					else
					{
						foreach (KeyValuePair<int, EquipProp> keyValuePair4 in value.equipSuitRes.props)
						{
							if (keyValuePair4.Key <= value.wearedEquipIDs.Count)
							{
								EquipProp lhs = equipProp;
								Dictionary<int, EquipProp>.Enumerator enumerator2;
								KeyValuePair<int, EquipProp> keyValuePair5 = enumerator2.Current;
								equipProp = lhs + keyValuePair5.Value;
							}
						}
					}
				}
			}
			ListPool<ItemData>.Release(list);
			return equipProp;
		}

		// Token: 0x0600B386 RID: 45958 RVA: 0x0027EFA0 File Offset: 0x0027D3A0
		public ItemProperty GetEquipSuitPropByIDs(List<int> itemIDs)
		{
			EquipProp equipSuitBasePropByIDs = this.GetEquipSuitBasePropByIDs(itemIDs);
			if (equipSuitBasePropByIDs != null)
			{
				return equipSuitBasePropByIDs.ToItemProp(0, 0, EGrowthAttrType.GAT_NONE, 0);
			}
			return null;
		}

		// Token: 0x0600B387 RID: 45959 RVA: 0x0027EFC8 File Offset: 0x0027D3C8
		public EquipSuitRes GetEquipSuitRes(int suitID)
		{
			EquipSuitRes equipSuitRes;
			this.m_suitsDict.TryGetValue(suitID, out equipSuitRes);
			if (equipSuitRes == null)
			{
				EquipSuitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipSuitTable>(suitID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					equipSuitRes = new EquipSuitRes();
					equipSuitRes.id = suitID;
					equipSuitRes.name = tableItem.Name;
					equipSuitRes.equips = tableItem.EquipIDs;
					EquipProp equipProp = EquipProp.CreateFromTable(tableItem.TwoEquipsAttrID);
					if (equipProp != null)
					{
						equipSuitRes.props.Add(2, equipProp);
					}
					EquipProp equipProp2 = EquipProp.CreateFromTable(tableItem.ThreeEquipsAttrID);
					if (equipProp2 != null)
					{
						equipSuitRes.props.Add(3, equipProp2);
					}
					EquipProp equipProp3 = EquipProp.CreateFromTable(tableItem.FourEquipsAttrID);
					if (equipProp3 != null)
					{
						equipSuitRes.props.Add(4, equipProp3);
					}
					EquipProp equipProp4 = EquipProp.CreateFromTable(tableItem.FiveEquipsAttrID);
					if (equipProp4 != null)
					{
						equipSuitRes.props.Add(5, equipProp4);
					}
					EquipProp equipProp5 = EquipProp.CreateFromTable(tableItem.SixEquipsAttrID);
					if (equipProp5 != null)
					{
						equipSuitRes.props.Add(6, equipProp5);
					}
					EquipProp equipProp6 = EquipProp.CreateFromTable(tableItem.EightEquipsAttrID);
					if (equipProp6 != null)
					{
						equipSuitRes.props.Add(8, equipProp6);
					}
					EquipProp equipProp7 = EquipProp.CreateFromTable(tableItem.NineEquipsAttrID);
					if (equipProp7 != null)
					{
						equipSuitRes.props.Add(9, equipProp7);
					}
					this.m_suitsDict.Add(suitID, equipSuitRes);
				}
			}
			return equipSuitRes;
		}

		// Token: 0x0600B388 RID: 45960 RVA: 0x0027F128 File Offset: 0x0027D528
		protected void _CalculateEquipSuitInfos(List<ItemData> a_arrItems, Dictionary<int, EquipSuitObj> a_dictSuitObjs)
		{
			if (a_arrItems == null || a_dictSuitObjs == null)
			{
				return;
			}
			a_dictSuitObjs.Clear();
			for (int i = 0; i < a_arrItems.Count; i++)
			{
				ItemData itemData = a_arrItems[i];
				if (itemData != null && itemData.SuitID > 0)
				{
					EquipSuitObj equipSuitObj = null;
					a_dictSuitObjs.TryGetValue(itemData.SuitID, out equipSuitObj);
					if (equipSuitObj == null)
					{
						equipSuitObj = new EquipSuitObj();
						equipSuitObj.wearedEquipIDs = new List<int>();
						equipSuitObj.equipSuitRes = this.GetEquipSuitRes(itemData.SuitID);
						a_dictSuitObjs.Add(itemData.SuitID, equipSuitObj);
					}
					if (!equipSuitObj.wearedEquipIDs.Contains(itemData.TableID))
					{
						equipSuitObj.wearedEquipIDs.Add(itemData.TableID);
					}
				}
			}
		}

		// Token: 0x0400653A RID: 25914
		protected Dictionary<int, EquipSuitRes> m_suitsDict = new Dictionary<int, EquipSuitRes>();

		// Token: 0x0400653B RID: 25915
		protected Dictionary<int, EquipSuitObj> m_selfEquipSuitObjs = new Dictionary<int, EquipSuitObj>();
	}
}
