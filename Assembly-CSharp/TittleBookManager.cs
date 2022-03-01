using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;

// Token: 0x020045DA RID: 17882
internal class TittleBookManager : DataManager<TittleBookManager>
{
	// Token: 0x06019221 RID: 102945 RVA: 0x007EFC4C File Offset: 0x007EE04C
	protected void BindDelegate()
	{
		ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
		instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddTittle));
		ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
		instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveTittle));
		ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
		instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateTittle));
	}

	// Token: 0x06019222 RID: 102946 RVA: 0x007EFCCC File Offset: 0x007EE0CC
	protected void UnBindDelegate()
	{
		ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
		instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddTittle));
		ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
		instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveTittle));
		ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
		instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateTittle));
	}

	// Token: 0x06019223 RID: 102947 RVA: 0x007EFD4B File Offset: 0x007EE14B
	public override void Initialize()
	{
		this.LoadMergeTitleFromTable();
		this.LoadTittleFromTable();
		this.UnBindDelegate();
		this.BindDelegate();
	}

	// Token: 0x06019224 RID: 102948 RVA: 0x007EFD65 File Offset: 0x007EE165
	public override EEnterGameOrder GetOrder()
	{
		return EEnterGameOrder.TittleBookManager;
	}

	// Token: 0x06019225 RID: 102949 RVA: 0x007EFD68 File Offset: 0x007EE168
	public bool CanAsMergeMaterial(ItemData itemData)
	{
		if (itemData != null)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemData.GUID);
			if (item != null)
			{
				TitleMergeData titleMergeData = this.MergeTitles.Find((TitleMergeData x) => x != null && null != x.materials.Find((TitleMergeMaterialData t) => t.id == itemData.TableID));
				return null != titleMergeData;
			}
		}
		return false;
	}

	// Token: 0x06019226 RID: 102950 RVA: 0x007EFDCA File Offset: 0x007EE1CA
	public bool IsTitleMergeLevelFit()
	{
		return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Title);
	}

	// Token: 0x06019227 RID: 102951 RVA: 0x007EFDD4 File Offset: 0x007EE1D4
	public void OnGotoMerge(ItemData itemData, object data)
	{
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleBookFrame>(FrameLayer.Middle, new TitleBookFrameData
		{
			eTittleComeType = TittleComeType.TCT_MERGE
		}, string.Empty);
		DataManager<ItemTipManager>.GetInstance().CloseAll();
	}

	// Token: 0x06019228 RID: 102952 RVA: 0x007EFE0C File Offset: 0x007EE20C
	public bool CanTrade(ItemData itemData)
	{
		TittleComeType tittleType = this.GetTittleType(itemData.GUID);
		return tittleType == TittleComeType.TCT_TRADE;
	}

	// Token: 0x06019229 RID: 102953 RVA: 0x007EFE30 File Offset: 0x007EE230
	public bool HasBindedTitle(int iTableID)
	{
		for (int i = 0; i < this.m_akTittleList.Count; i++)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.m_akTittleList[i]);
			if (item != null && item.TableID == iTableID)
			{
				TittleComeType tittleType = this.GetTittleType(item);
				if (tittleType != TittleComeType.TCT_TRADE)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601922A RID: 102954 RVA: 0x007EFE94 File Offset: 0x007EE294
	public bool HasExtraTitle(ItemData compare)
	{
		if (!this.HasBindedTitle(compare.TableID))
		{
			return false;
		}
		TittleComeType tittleType = this.GetTittleType(compare);
		return tittleType == TittleComeType.TCT_TRADE;
	}

	// Token: 0x0601922B RID: 102955 RVA: 0x007EFEC6 File Offset: 0x007EE2C6
	private bool _IsBelongToTitleBook(TittleComeType eCurrent)
	{
		return eCurrent > TittleComeType.TCT_INVALID && eCurrent < TittleComeType.TCT_COUNT && eCurrent != TittleComeType.TCT_TRADE && eCurrent != TittleComeType.TCT_TIMELIMITED;
	}

	// Token: 0x0601922C RID: 102956 RVA: 0x007EFEEC File Offset: 0x007EE2EC
	private void _TryRemoveTableTitle(Item current)
	{
		if (current == null)
		{
			return;
		}
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(current.uid);
		TittleComeType tittleType = this.GetTittleType(current.uid);
		if (item != null && this._IsBelongToTitleBook(tittleType))
		{
			foreach (KeyValuePair<TittleComeType, List<ulong>> keyValuePair in this.m_akTableTittleDic)
			{
				if (keyValuePair.Value.Remove((ulong)((long)item.TableID)))
				{
					if (this.onRemoveTableTittle != null)
					{
						this.onRemoveTableTittle((ulong)((long)item.TableID));
					}
					break;
				}
			}
		}
	}

	// Token: 0x0601922D RID: 102957 RVA: 0x007EFF90 File Offset: 0x007EE390
	private void _OnAddTittle(List<Item> tittle)
	{
		for (int i = 0; i < tittle.Count; i++)
		{
			if (tittle[i] != null)
			{
				TittleComeType tittleType = this.GetTittleType(tittle[i].uid);
				TittleComeType tittleTableType = this.GetTittleTableType(tittle[i].uid);
				if (tittleType > TittleComeType.TCT_INVALID && tittleType < TittleComeType.TCT_COUNT)
				{
					this.m_akTittleList.Add(tittle[i].uid);
					List<ulong> list = null;
					if (!this.m_akType2Tittle.TryGetValue(tittleType, out list))
					{
						list = new List<ulong>();
						this.m_akType2Tittle.Add(tittleType, list);
					}
					list.Add(tittle[i].uid);
					this._TryRemoveTableTitle(tittle[i]);
					if (this.onAddTittle != null)
					{
						this.onAddTittle(tittle[i].uid);
					}
				}
			}
		}
	}

	// Token: 0x0601922E RID: 102958 RVA: 0x007F0074 File Offset: 0x007EE474
	private void _OnRemoveTittle(ItemData data)
	{
		this.m_akTittleList.Remove(data.GUID);
		bool flag = false;
		Dictionary<TittleComeType, List<ulong>>.Enumerator enumerator = this.m_akType2Tittle.GetEnumerator();
		while (!flag && enumerator.MoveNext())
		{
			KeyValuePair<TittleComeType, List<ulong>> keyValuePair = enumerator.Current;
			List<ulong> value = keyValuePair.Value;
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] == data.GUID)
				{
					value.RemoveAt(i);
					flag = true;
					break;
				}
			}
		}
		if (this.onRemoveTittle != null)
		{
			this.onRemoveTittle(data.GUID);
		}
		bool flag2 = true;
		List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.WearEquip, ItemTable.eSubType.TITLE);
		List<ulong> itemsByPackageSubType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Title, ItemTable.eSubType.TITLE);
		itemsByPackageSubType2.AddRange(itemsByPackageSubType);
		for (int j = 0; j < itemsByPackageSubType2.Count; j++)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType2[j]);
			if (item != null && item.TableID == data.TableID)
			{
				flag2 = false;
				break;
			}
		}
		if (!flag2)
		{
			return;
		}
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.TableID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			TittleComeType tittleType = this.GetTittleType(data);
			if (this._IsBelongToTitleBook(tittleType))
			{
				List<ulong> list = null;
				if (!this.m_akTableTittleDic.TryGetValue(tittleType, out list))
				{
					list = new List<ulong>();
					this.m_akTableTittleDic.Add(tittleType, list);
				}
				if (!list.Contains((ulong)((long)data.TableID)))
				{
					if (!list.Contains((ulong)((long)data.TableID)))
					{
						list.Add((ulong)((long)data.TableID));
					}
					if (this.onAddTableTittle != null)
					{
						this.onAddTableTittle((ulong)((long)data.TableID));
					}
				}
			}
		}
	}

	// Token: 0x0601922F RID: 102959 RVA: 0x007F0260 File Offset: 0x007EE660
	public TittleComeType GetTittleTableType(ulong uid)
	{
		TittleComeType result = TittleComeType.TCT_INVALID;
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(uid);
		if (item != null)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return this.GetTittleType(tableItem);
			}
		}
		return result;
	}

	// Token: 0x06019230 RID: 102960 RVA: 0x007F02AC File Offset: 0x007EE6AC
	public TittleComeType GetTittleType(ItemData itemData)
	{
		TittleComeType result = TittleComeType.TCT_INVALID;
		if (itemData != null && itemData.Type == ItemTable.eType.FUCKTITTLE)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (!string.IsNullOrEmpty(itemData.GetTimeLeftDesc()))
				{
					result = TittleComeType.TCT_TIMELIMITED;
				}
				else if (itemData.CanTrade())
				{
					result = TittleComeType.TCT_TRADE;
				}
				else if (tableItem.ComeType == ItemTable.eComeType.CT_ACTIVITY)
				{
					result = TittleComeType.TCT_ACTIVE;
				}
				else if (tableItem.ComeType == ItemTable.eComeType.CT_MISSION)
				{
					result = TittleComeType.TCT_MISSION;
				}
				else if (tableItem.ComeType == ItemTable.eComeType.CT_SHOP)
				{
					result = TittleComeType.TCT_SHOP;
				}
			}
		}
		return result;
	}

	// Token: 0x06019231 RID: 102961 RVA: 0x007F034C File Offset: 0x007EE74C
	public TittleComeType GetTittleType(ulong uid)
	{
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(uid);
		return this.GetTittleType(item);
	}

	// Token: 0x06019232 RID: 102962 RVA: 0x007F036C File Offset: 0x007EE76C
	public TittleComeType GetTittleType(ItemTable item)
	{
		TittleComeType result = TittleComeType.TCT_INVALID;
		if (item.TimeLeft == 0)
		{
			if (item.ComeType == ItemTable.eComeType.CT_MISSION)
			{
				result = TittleComeType.TCT_MISSION;
			}
			else if (item.ComeType == ItemTable.eComeType.CT_SHOP)
			{
				result = TittleComeType.TCT_SHOP;
			}
		}
		return result;
	}

	// Token: 0x06019233 RID: 102963 RVA: 0x007F03AC File Offset: 0x007EE7AC
	private void _OnUpdateTittle(List<Item> tittle)
	{
		for (int i = 0; i < tittle.Count; i++)
		{
			Item item = tittle[i];
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(item.uid);
			if (item2 != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item2.TableID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Type == ItemTable.eType.FUCKTITTLE)
				{
					foreach (KeyValuePair<TittleComeType, List<ulong>> keyValuePair in this.m_akType2Tittle)
					{
						List<ulong> value = keyValuePair.Value;
						if (value.Contains(item.uid))
						{
							value.Remove(item.uid);
						}
					}
					TittleComeType tittleType = this.GetTittleType(item.uid);
					if (tittleType > TittleComeType.TCT_INVALID && tittleType < TittleComeType.TCT_COUNT)
					{
						List<ulong> list = null;
						if (!this.m_akType2Tittle.TryGetValue(tittleType, out list))
						{
							list = new List<ulong>();
							this.m_akType2Tittle.Add(tittleType, list);
						}
						list.Add(item.uid);
					}
					this._TryRemoveTableTitle(item);
					if (this.onUpdateTittle != null)
					{
						this.onUpdateTittle(item.uid);
					}
				}
			}
		}
	}

	// Token: 0x170020AD RID: 8365
	// (get) Token: 0x06019234 RID: 102964 RVA: 0x007F04F1 File Offset: 0x007EE8F1
	// (set) Token: 0x06019235 RID: 102965 RVA: 0x007F04F9 File Offset: 0x007EE8F9
	public List<ulong> TittleList
	{
		get
		{
			return this.m_akTittleList;
		}
		set
		{
			this.TittleList = value;
		}
	}

	// Token: 0x06019236 RID: 102966 RVA: 0x007F0502 File Offset: 0x007EE902
	public bool GetTittle(TittleComeType eTittleComeType, out List<ulong> tittles)
	{
		return this.m_akType2Tittle.TryGetValue(eTittleComeType, out tittles);
	}

	// Token: 0x06019237 RID: 102967 RVA: 0x007F0514 File Offset: 0x007EE914
	public bool IsTittleTabMark(TittleComeType eCurrent)
	{
		if (this.m_akType2Tittle.ContainsKey(eCurrent))
		{
			List<ulong> list = this.m_akType2Tittle[eCurrent];
			for (int i = 0; i < list.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
				if (item != null && item.IsNew)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06019238 RID: 102968 RVA: 0x007F057C File Offset: 0x007EE97C
	public bool IsTittleMark(ulong guid)
	{
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
		return item != null && item.IsNew;
	}

	// Token: 0x06019239 RID: 102969 RVA: 0x007F05A8 File Offset: 0x007EE9A8
	public bool HasTittleTabMark()
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.IsTittleTabMark((TittleComeType)i))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601923A RID: 102970 RVA: 0x007F05D8 File Offset: 0x007EE9D8
	public bool HasTitle(int tableId)
	{
		foreach (KeyValuePair<TittleComeType, List<ulong>> keyValuePair in this.m_akType2Tittle)
		{
			List<ulong> value = keyValuePair.Value;
			if (value != null)
			{
				for (int i = 0; i < value.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(value[i]);
					if (item != null && item.TableID == tableId)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0601923B RID: 102971 RVA: 0x007F0659 File Offset: 0x007EEA59
	public bool HasTittle(TittleComeType eTittleComeType)
	{
		return this.m_akType2Tittle.ContainsKey(eTittleComeType) && this.m_akType2Tittle[eTittleComeType].Count > 0;
	}

	// Token: 0x0601923C RID: 102972 RVA: 0x007F0683 File Offset: 0x007EEA83
	public override void Clear()
	{
		this.m_akTittleList.Clear();
		this.m_akTableTittleDic.Clear();
		this.m_akType2Tittle.Clear();
	}

	// Token: 0x0601923D RID: 102973 RVA: 0x007F06A6 File Offset: 0x007EEAA6
	public bool GetTableTittle(TittleComeType eTittleComeType, out List<ulong> tittles)
	{
		return this.m_akTableTittleDic.TryGetValue(eTittleComeType, out tittles);
	}

	// Token: 0x0601923E RID: 102974 RVA: 0x007F06B8 File Offset: 0x007EEAB8
	private void LoadMergeTitleFromTable()
	{
		if (this.m_mergeTitles.Count == 0)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipForgeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					EquipForgeTable equipForgeTable = keyValuePair.Value as EquipForgeTable;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(equipForgeTable.ID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SubType == ItemTable.eSubType.TITLE)
					{
						TitleMergeData titleMergeData = new TitleMergeData();
						titleMergeData.forgeItem = equipForgeTable;
						titleMergeData.item = tableItem;
						titleMergeData.materials.Clear();
						for (int i = 0; i < equipForgeTable.Material.Count; i++)
						{
							if (!string.IsNullOrEmpty(equipForgeTable.Material[i]))
							{
								string[] array = equipForgeTable.Material[i].Split(new char[]
								{
									'_'
								});
								int id = 0;
								int num = 0;
								if (array.Length == 2 && int.TryParse(array[0], out id) && int.TryParse(array[1], out num) && num > 0)
								{
									ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
									if (tableItem2 != null)
									{
										titleMergeData.materials.Add(new TitleMergeMaterialData
										{
											id = id,
											count = num
										});
									}
								}
							}
						}
						if (titleMergeData.materials.Count > 0)
						{
							this.m_mergeTitles.Add(titleMergeData);
						}
					}
				}
			}
		}
	}

	// Token: 0x170020AE RID: 8366
	// (get) Token: 0x0601923F RID: 102975 RVA: 0x007F085B File Offset: 0x007EEC5B
	public List<TitleMergeData> MergeTitles
	{
		get
		{
			if (this.m_mergeTitles.Count <= 0)
			{
				this.LoadMergeTitleFromTable();
			}
			return this.m_mergeTitles;
		}
	}

	// Token: 0x06019240 RID: 102976 RVA: 0x007F087C File Offset: 0x007EEC7C
	private void LoadTittleFromTable()
	{
		if (this.m_akTableTittleDic.Count == 0)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ItemTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ItemTable itemTable = keyValuePair.Value as ItemTable;
				if (itemTable.Type == ItemTable.eType.FUCKTITTLE)
				{
					TittleComeType tittleType = this.GetTittleType(itemTable);
					if (tittleType > TittleComeType.TCT_INVALID && tittleType < TittleComeType.TCT_COUNT)
					{
						List<ulong> list = null;
						if (!this.m_akTableTittleDic.TryGetValue(tittleType, out list))
						{
							list = new List<ulong>();
							this.m_akTableTittleDic.Add(tittleType, list);
						}
						List<ulong> list2 = list;
						Dictionary<int, object>.Enumerator enumerator;
						KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
						list2.Add((ulong)((long)keyValuePair2.Key));
					}
				}
			}
			foreach (KeyValuePair<TittleComeType, List<ulong>> keyValuePair3 in this.m_akTableTittleDic)
			{
				keyValuePair3.Value.Sort();
			}
		}
	}

	// Token: 0x04012038 RID: 73784
	public TittleBookManager.OnAddTittle onAddTittle;

	// Token: 0x04012039 RID: 73785
	public TittleBookManager.OnRemoveTittle onRemoveTittle;

	// Token: 0x0401203A RID: 73786
	public TittleBookManager.OnUpdateTittle onUpdateTittle;

	// Token: 0x0401203B RID: 73787
	public TittleBookManager.OnRemoveTableTittle onRemoveTableTittle;

	// Token: 0x0401203C RID: 73788
	public TittleBookManager.OnAddTableTittle onAddTableTittle;

	// Token: 0x0401203D RID: 73789
	private List<ulong> m_akTittleList = new List<ulong>();

	// Token: 0x0401203E RID: 73790
	private Dictionary<TittleComeType, List<ulong>> m_akType2Tittle = new Dictionary<TittleComeType, List<ulong>>();

	// Token: 0x0401203F RID: 73791
	private Dictionary<TittleComeType, List<ulong>> m_akTableTittleDic = new Dictionary<TittleComeType, List<ulong>>();

	// Token: 0x04012040 RID: 73792
	private List<TitleMergeData> m_mergeTitles = new List<TitleMergeData>();

	// Token: 0x020045DB RID: 17883
	// (Invoke) Token: 0x06019242 RID: 102978
	public delegate void OnAddTittle(ulong uid);

	// Token: 0x020045DC RID: 17884
	// (Invoke) Token: 0x06019246 RID: 102982
	public delegate void OnRemoveTittle(ulong uid);

	// Token: 0x020045DD RID: 17885
	// (Invoke) Token: 0x0601924A RID: 102986
	public delegate void OnUpdateTittle(ulong uid);

	// Token: 0x020045DE RID: 17886
	// (Invoke) Token: 0x0601924E RID: 102990
	public delegate void OnRemoveTableTittle(ulong tableid);

	// Token: 0x020045DF RID: 17887
	// (Invoke) Token: 0x06019252 RID: 102994
	public delegate void OnAddTableTittle(ulong tableid);
}
