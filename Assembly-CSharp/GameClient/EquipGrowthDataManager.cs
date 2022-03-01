using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001247 RID: 4679
	public class EquipGrowthDataManager : DataManager<EquipGrowthDataManager>
	{
		// Token: 0x0600B3AF RID: 45999 RVA: 0x00280018 File Offset: 0x0027E418
		public sealed override void Clear()
		{
			this.ClearGrowthAttributeDataList();
			this.ClearGrowthCostDataList();
			this.ClearMaterialsSynthesisDataList();
			this.IsEquipIntensify = false;
			this.IsEquipmentIntensifyBroken = false;
			if (this.mStrengthLevelDict != null)
			{
				this.mStrengthLevelDict.Clear();
			}
		}

		// Token: 0x0600B3B0 RID: 46000 RVA: 0x00280050 File Offset: 0x0027E450
		public sealed override void Initialize()
		{
			this.InitEquipEnhanceAttributeTable();
			this.InitEquipEnhanceCostTable();
			this.InitMaterialsSynthesisTable();
			this.InitOverlondDeviceValueTable();
		}

		// Token: 0x0600B3B1 RID: 46001 RVA: 0x0028006A File Offset: 0x0027E46A
		private void ClearMaterialsSynthesisDataList()
		{
			if (this.mMaterialsSynthesisDataList != null)
			{
				this.mMaterialsSynthesisDataList.Clear();
			}
		}

		// Token: 0x0600B3B2 RID: 46002 RVA: 0x00280082 File Offset: 0x0027E482
		private void ClearGrowthCostDataList()
		{
			if (this.mGrowthCostDataList != null)
			{
				this.mGrowthCostDataList.Clear();
			}
		}

		// Token: 0x0600B3B3 RID: 46003 RVA: 0x0028009A File Offset: 0x0027E49A
		private void ClearGrowthAttributeDataList()
		{
			if (this.mGrowthAttributeDataList != null)
			{
				this.mGrowthAttributeDataList.Clear();
			}
		}

		// Token: 0x0600B3B4 RID: 46004 RVA: 0x002800B2 File Offset: 0x0027E4B2
		public StrengthenResult GetGrowthResult()
		{
			return this.mGrowthResult;
		}

		// Token: 0x0600B3B5 RID: 46005 RVA: 0x002800BC File Offset: 0x0027E4BC
		public List<ItemSimpleData> GetCostMaterialsList(int itemId)
		{
			for (int i = 0; i < this.mMaterialsSynthesisDataList.Count; i++)
			{
				if (this.mMaterialsSynthesisDataList[i].tableID == itemId)
				{
					return this.mMaterialsSynthesisDataList[i].expendMaterials;
				}
			}
			return new List<ItemSimpleData>();
		}

		// Token: 0x0600B3B6 RID: 46006 RVA: 0x00280118 File Offset: 0x0027E518
		public List<MaterialsSynthesisData> GetMaterialsSynthesisData()
		{
			return this.mMaterialsSynthesisDataList;
		}

		// Token: 0x0600B3B7 RID: 46007 RVA: 0x00280120 File Offset: 0x0027E520
		private void InitMaterialsSynthesisTable()
		{
			if (this.mMaterialsSynthesisDataList == null)
			{
				this.mMaterialsSynthesisDataList = new List<MaterialsSynthesisData>();
			}
			else
			{
				this.mMaterialsSynthesisDataList.Clear();
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<MaterialsSynthesis>())
			{
				MaterialsSynthesis materialsSynthesis = keyValuePair.Value as MaterialsSynthesis;
				if (materialsSynthesis != null)
				{
					MaterialsSynthesisData materialsSynthesisData = new MaterialsSynthesisData();
					materialsSynthesisData.expendMaterials = new List<ItemSimpleData>();
					materialsSynthesisData.tableID = materialsSynthesis.ID;
					string[] array = materialsSynthesis.Composites.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						int id = 0;
						int count = 0;
						string[] array2 = array[i].Split(new char[]
						{
							'_'
						});
						if (array2.Length >= 2)
						{
							int.TryParse(array2[0], out id);
							int.TryParse(array2[1], out count);
							ItemSimpleData item = new ItemSimpleData(id, count);
							materialsSynthesisData.expendMaterials.Add(item);
						}
					}
					this.mMaterialsSynthesisDataList.Add(materialsSynthesisData);
				}
			}
		}

		// Token: 0x0600B3B8 RID: 46008 RVA: 0x00280248 File Offset: 0x0027E648
		private void InitEquipEnhanceCostTable()
		{
			this.ClearGrowthCostDataList();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquipEnhanceCostTable>())
			{
				EquipEnhanceCostTable equipEnhanceCostTable = keyValuePair.Value as EquipEnhanceCostTable;
				if (equipEnhanceCostTable != null)
				{
					List<ItemSimpleData> list = new List<ItemSimpleData>();
					ItemSimpleData itemSimpleData = new ItemSimpleData();
					itemSimpleData.ItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
					itemSimpleData.Count = equipEnhanceCostTable.NeedGold;
					ItemSimpleData itemSimpleData2 = new ItemSimpleData();
					itemSimpleData2.ItemID = equipEnhanceCostTable.ItemID;
					itemSimpleData2.Count = equipEnhanceCostTable.ItemNum;
					list.Add(itemSimpleData);
					list.Add(itemSimpleData2);
					GrowthCostData item = new GrowthCostData(equipEnhanceCostTable.Quality, equipEnhanceCostTable.EnhanceLevel, equipEnhanceCostTable.Level, list);
					this.mGrowthCostDataList.Add(item);
				}
			}
		}

		// Token: 0x0600B3B9 RID: 46009 RVA: 0x00280324 File Offset: 0x0027E724
		private void InitEquipEnhanceAttributeTable()
		{
			this.ClearGrowthAttributeDataList();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquipEnhanceAttributeTable>())
			{
				EquipEnhanceAttributeTable equipEnhanceAttributeTable = keyValuePair.Value as EquipEnhanceAttributeTable;
				if (equipEnhanceAttributeTable != null)
				{
					GrowthAttributeData item = new GrowthAttributeData(equipEnhanceAttributeTable.Quality, equipEnhanceAttributeTable.EnhanceLevel, equipEnhanceAttributeTable.Level, equipEnhanceAttributeTable.EnhanceAttribute);
					this.mGrowthAttributeDataList.Add(item);
				}
			}
		}

		// Token: 0x0600B3BA RID: 46010 RVA: 0x002803A4 File Offset: 0x0027E7A4
		private void InitOverlondDeviceValueTable()
		{
			if (this.mStrengthLevelDict == null)
			{
				this.mStrengthLevelDict = new Dictionary<int, List<int>>();
			}
			this.mStrengthLevelDict.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<OverlondDeviceValueTable>())
			{
				OverlondDeviceValueTable overlondDeviceValueTable = keyValuePair.Value as OverlondDeviceValueTable;
				if (overlondDeviceValueTable != null)
				{
					if (!this.mStrengthLevelDict.ContainsKey(overlondDeviceValueTable.ItemDataID))
					{
						this.mStrengthLevelDict.Add(overlondDeviceValueTable.ItemDataID, new List<int>());
					}
					this.mStrengthLevelDict[overlondDeviceValueTable.ItemDataID].Add(overlondDeviceValueTable.SharpenLv);
				}
			}
		}

		// Token: 0x0600B3BB RID: 46011 RVA: 0x0028045C File Offset: 0x0027E85C
		public void GetStrengthLevelIntervalValue(int itemId, ref int minLevel, ref int maxLevel)
		{
			List<int> list = new List<int>();
			if (this.mStrengthLevelDict.TryGetValue(itemId, out list))
			{
				list.Sort((int x, int y) => x.CompareTo(y));
				if (list.Count > 0)
				{
					minLevel = list[0];
					maxLevel = list[list.Count - 1];
				}
			}
		}

		// Token: 0x0600B3BC RID: 46012 RVA: 0x002804CC File Offset: 0x0027E8CC
		public List<ItemSimpleData> GetGrowthCosts(ItemData itemData)
		{
			if (itemData == null)
			{
				return new List<ItemSimpleData>();
			}
			for (int i = 0; i < this.mGrowthCostDataList.Count; i++)
			{
				GrowthCostData growthCostData = this.mGrowthCostDataList[i];
				if (itemData.Quality == (ItemTable.eColor)growthCostData.quality)
				{
					if (itemData.StrengthenLevel == growthCostData.growthLevel)
					{
						if (itemData.LevelLimit == growthCostData.equipLevel)
						{
							return growthCostData.growthCosts;
						}
					}
				}
			}
			return new List<ItemSimpleData>();
		}

		// Token: 0x0600B3BD RID: 46013 RVA: 0x0028055C File Offset: 0x0027E95C
		public int GetGrowthAttributeValue(ItemData itemData, int growthLevel)
		{
			if (itemData == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mGrowthAttributeDataList.Count; i++)
			{
				GrowthAttributeData growthAttributeData = this.mGrowthAttributeDataList[i];
				if (growthAttributeData != null)
				{
					if (growthAttributeData.quality == (int)itemData.Quality)
					{
						if (growthAttributeData.equipLevel == itemData.LevelLimit)
						{
							if (growthAttributeData.growthLevel == growthLevel)
							{
								return growthAttributeData.growthAttributeNum;
							}
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600B3BE RID: 46014 RVA: 0x002805EC File Offset: 0x0027E9EC
		public List<ItemData> GetGrowthStampList(ItemData currentSelectItemData)
		{
			if (currentSelectItemData == null)
			{
				return new List<ItemData>();
			}
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.ST_ZENGFU_AMPLIFICATION);
			if (itemsByPackageSubType != null)
			{
				for (int i = 0; i < itemsByPackageSubType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[i]);
					if (item != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							StrengthenTicketTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(tableItem.StrenTicketDataIndex, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (currentSelectItemData.StrengthenLevel < tableItem2.Level)
								{
									list.Add(item);
								}
							}
						}
					}
				}
			}
			list.Sort(new Comparison<ItemData>(this.GrowthStampItemSort));
			itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.ST_RANDOM_SHARPEN);
			if (itemsByPackageSubType != null)
			{
				for (int j = 0; j < itemsByPackageSubType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[j]);
					if (item2 != null)
					{
						int num = 0;
						int num2 = 0;
						DataManager<EquipGrowthDataManager>.GetInstance().GetStrengthLevelIntervalValue(item2.TableID, ref num, ref num2);
						if (currentSelectItemData.StrengthenLevel < num)
						{
							list.Add(item2);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B3BF RID: 46015 RVA: 0x0028075C File Offset: 0x0027EB5C
		private int GrowthStampItemSort(ItemData x, ItemData y)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(x.TableID, string.Empty, string.Empty);
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(y.TableID, string.Empty, string.Empty);
			StrengthenTicketTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(tableItem.StrenTicketDataIndex, string.Empty, string.Empty);
			StrengthenTicketTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(tableItem2.StrenTicketDataIndex, string.Empty, string.Empty);
			if (tableItem3.Level != tableItem4.Level)
			{
				return tableItem4.Level - tableItem3.Level;
			}
			if (tableItem3.Probility != tableItem4.Probility)
			{
				return tableItem4.Probility - tableItem3.Probility;
			}
			return tableItem3.ID - tableItem4.ID;
		}

		// Token: 0x0600B3C0 RID: 46016 RVA: 0x00280820 File Offset: 0x0027EC20
		public void SceneEquipEnhanceUpgrade(ItemData data, byte useUnbreak, ulong ticketid = 0UL)
		{
			SceneEquipEnhanceUpgrade sceneEquipEnhanceUpgrade = new SceneEquipEnhanceUpgrade();
			sceneEquipEnhanceUpgrade.euqipUid = data.GUID;
			sceneEquipEnhanceUpgrade.strTickt = ticketid;
			sceneEquipEnhanceUpgrade.useUnbreak = useUnbreak;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEquipEnhanceUpgrade>(ServerType.GATE_SERVER, sceneEquipEnhanceUpgrade);
			int iOrgStrengthenLevel = data.StrengthenLevel + 1;
			int[] aiOrgAttr;
			if (data.IsAssistEquip())
			{
				aiOrgAttr = new int[]
				{
					Mathf.FloorToInt((float)data.GrowthAttrNum),
					Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel)),
					Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel)),
					Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel)),
					Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel))
				};
			}
			else
			{
				aiOrgAttr = new int[]
				{
					Mathf.FloorToInt((float)data.GrowthAttrNum),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate))
				};
			}
			this.IsEquipIntensify = true;
			DataManager<WaitNetMessageManager>.GetInstance().Wait(501061U, delegate(MsgDATA msgData)
			{
				int num = 0;
				CustomDecoder.StrengthenRet strengthenRet;
				CustomDecoder.DecodeStrengthenResult(out strengthenRet, msgData.bytes, ref num, msgData.bytes.Length);
				if (strengthenRet.code == 1000016U)
				{
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventID = EUIEventID.ItemGrowthFail;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = false;
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.mGrowthResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int i = 0; i < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; i++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[i] = aiOrgAttr[i];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int j = 0; j < this.mGrowthResult.growthOrgAttr.Length; j++)
						{
							this.mGrowthResult.growthOrgAttr[j] = aiOrgAttr[j];
						}
						this.mGrowthResult.growthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.growthCurAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.mGrowthResult.growthCurAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.mGrowthResult.growthCurAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.mGrowthResult.growthCurAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.mGrowthResult.growthCurAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.mGrowthResult.growthCurAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.mGrowthResult.growthCurAttr[7] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				}
				else if (strengthenRet.code == 1000048U)
				{
					UIEvent idleUIEvent2 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent2.EventID = EUIEventID.OnSpecailGrowthFailed;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = false;
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.mGrowthResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int k = 0; k < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; k++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[k] = aiOrgAttr[k];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int l = 0; l < this.mGrowthResult.growthOrgAttr.Length; l++)
						{
							this.mGrowthResult.growthOrgAttr[l] = aiOrgAttr[l];
						}
						this.mGrowthResult.growthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.growthCurAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.mGrowthResult.growthCurAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.mGrowthResult.growthCurAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.mGrowthResult.growthCurAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.mGrowthResult.growthCurAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.mGrowthResult.growthCurAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.mGrowthResult.growthCurAttr[7] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent2);
				}
				else if (strengthenRet.code == 1000017U)
				{
					UIEvent idleUIEvent3 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent3.EventID = EUIEventID.ItemGrowthFail;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = false;
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.mGrowthResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int m = 0; m < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; m++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[m] = aiOrgAttr[m];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int n = 0; n < this.mGrowthResult.growthOrgAttr.Length; n++)
						{
							this.mGrowthResult.growthOrgAttr[n] = aiOrgAttr[n];
						}
						this.mGrowthResult.growthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.growthCurAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.mGrowthResult.growthCurAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.mGrowthResult.growthCurAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.mGrowthResult.growthCurAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.mGrowthResult.growthCurAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.mGrowthResult.growthCurAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.mGrowthResult.growthCurAttr[7] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent3);
				}
				else if (strengthenRet.code == 1000018U)
				{
					UIEvent idleUIEvent4 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent4.EventID = EUIEventID.ItemGrowthFail;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = false;
					this.mGrowthResult.BrokenItems = new List<ItemData>();
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.mGrowthResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int num2 = 0; num2 < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; num2++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[num2] = aiOrgAttr[num2];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int num3 = 0; num3 < this.mGrowthResult.growthOrgAttr.Length; num3++)
						{
							this.mGrowthResult.growthOrgAttr[num3] = aiOrgAttr[num3];
						}
						this.mGrowthResult.growthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.growthCurAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.mGrowthResult.growthCurAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.mGrowthResult.growthCurAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.mGrowthResult.growthCurAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.mGrowthResult.growthCurAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.mGrowthResult.growthCurAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.mGrowthResult.growthCurAttr[7] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					for (int num4 = 0; num4 < strengthenRet.BrokenItems.Count; num4++)
					{
						CustomDecoder.RewardItem rewardItem = strengthenRet.BrokenItems[num4];
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)rewardItem.ID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = (int)rewardItem.Num;
							this.mGrowthResult.BrokenItems.Add(itemData);
						}
						else
						{
							Logger.LogErrorFormat("Item can not find with id = {0}", new object[]
							{
								rewardItem.ID
							});
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent4);
				}
				else if (strengthenRet.code == 1000019U)
				{
					UIEvent idleUIEvent5 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent5.EventID = EUIEventID.ItemGrowthFail;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = false;
					this.mGrowthResult.BrokenItems = new List<ItemData>();
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = 0;
					this.mGrowthResult.iTableID = data.TableID;
					for (int num5 = 0; num5 < strengthenRet.BrokenItems.Count; num5++)
					{
						CustomDecoder.RewardItem rewardItem2 = strengthenRet.BrokenItems[num5];
						ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)rewardItem2.ID, 100, 0);
						if (itemData2 != null)
						{
							itemData2.Count = (int)rewardItem2.Num;
						}
						this.mGrowthResult.BrokenItems.Add(itemData2);
					}
					if (data.IsAssistEquip())
					{
						for (int num6 = 0; num6 < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; num6++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[num6] = aiOrgAttr[num6];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = 0;
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = 0;
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = 0;
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = 0;
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = 0;
					}
					else
					{
						for (int num7 = 0; num7 < this.mGrowthResult.growthOrgAttr.Length; num7++)
						{
							this.mGrowthResult.growthOrgAttr[num7] = aiOrgAttr[num7];
						}
						this.mGrowthResult.growthCurAttr[0] = 0;
						this.mGrowthResult.growthCurAttr[1] = 0;
						this.mGrowthResult.growthCurAttr[2] = 0;
						this.mGrowthResult.growthCurAttr[3] = 0;
						this.mGrowthResult.growthCurAttr[4] = 0;
						this.mGrowthResult.growthCurAttr[5] = 0;
						this.mGrowthResult.growthCurAttr[6] = 0;
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent5);
				}
				else if (strengthenRet.code == 0U)
				{
					UIEvent idleUIEvent6 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent6.EventID = EUIEventID.ItemGrowthSuccess;
					this.mGrowthResult = new StrengthenResult();
					this.mGrowthResult.StrengthenSuccess = true;
					this.mGrowthResult.EquipData = data;
					this.mGrowthResult.code = strengthenRet.code;
					this.mGrowthResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.mGrowthResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.mGrowthResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int num8 = 0; num8 < this.mGrowthResult.assistEquipGrowthOrgAttr.Length; num8++)
						{
							this.mGrowthResult.assistEquipGrowthOrgAttr[num8] = aiOrgAttr[num8];
						}
						this.mGrowthResult.assistEquipGrowthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.assistEquipGrowthCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.mGrowthResult.assistEquipGrowthCurAttr[4] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int num9 = 0; num9 < this.mGrowthResult.growthOrgAttr.Length; num9++)
						{
							this.mGrowthResult.growthOrgAttr[num9] = aiOrgAttr[num9];
						}
						this.mGrowthResult.growthCurAttr[0] = Mathf.FloorToInt((float)data.GrowthAttrNum);
						this.mGrowthResult.growthCurAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.mGrowthResult.growthCurAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.mGrowthResult.growthCurAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.mGrowthResult.growthCurAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.mGrowthResult.growthCurAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.mGrowthResult.growthCurAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.mGrowthResult.growthCurAttr[7] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent6);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)strengthenRet.code, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenError, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3C1 RID: 46017 RVA: 0x00280A18 File Offset: 0x0027EE18
		public void OnSceneEquipEnhanceRed(ItemData itemData, uint expendId)
		{
			SceneEquipEnhanceRed sceneEquipEnhanceRed = new SceneEquipEnhanceRed();
			sceneEquipEnhanceRed.euqipUid = itemData.GUID;
			sceneEquipEnhanceRed.stuffID = expendId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEquipEnhanceRed>(ServerType.GATE_SERVER, sceneEquipEnhanceRed);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(501065U, delegate(MsgDATA msgData)
			{
				SceneEquipEnhanceRedRet sceneEquipEnhanceRedRet = new SceneEquipEnhanceRedRet();
				sceneEquipEnhanceRedRet.decode(msgData.bytes);
				if (sceneEquipEnhanceRedRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)sceneEquipEnhanceRedRet.code, string.Empty);
				}
				else
				{
					EquipmentClearChangeActivationResultData equipmentClearChangeActivationResultData = new EquipmentClearChangeActivationResultData();
					equipmentClearChangeActivationResultData.mEquipItemData = itemData;
					equipmentClearChangeActivationResultData.mStrengthenGrowthType = StrengthenGrowthType.SGT_Activate;
					this.OpenClearActivationChangedResultFrame(equipmentClearChangeActivationResultData);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnBreathEquipActivationSuccess, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3C2 RID: 46018 RVA: 0x00280A8C File Offset: 0x0027EE8C
		public void OnSceneEquipEnhanceClear(ItemData itemData, uint expendId)
		{
			SceneEquipEnhanceClear sceneEquipEnhanceClear = new SceneEquipEnhanceClear();
			sceneEquipEnhanceClear.euqipUid = itemData.GUID;
			sceneEquipEnhanceClear.stuffID = expendId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEquipEnhanceClear>(ServerType.GATE_SERVER, sceneEquipEnhanceClear);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(501063U, delegate(MsgDATA msgData)
			{
				SceneEquipEnhanceClearRet sceneEquipEnhanceClearRet = new SceneEquipEnhanceClearRet();
				sceneEquipEnhanceClearRet.decode(msgData.bytes);
				if (sceneEquipEnhanceClearRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)sceneEquipEnhanceClearRet.code, string.Empty);
				}
				else
				{
					EquipmentClearChangeActivationResultData equipmentClearChangeActivationResultData = new EquipmentClearChangeActivationResultData();
					equipmentClearChangeActivationResultData.mEquipItemData = itemData;
					equipmentClearChangeActivationResultData.mStrengthenGrowthType = StrengthenGrowthType.SGT_Clear;
					this.OpenClearActivationChangedResultFrame(equipmentClearChangeActivationResultData);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnBreathEquipClearSuccess, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3C3 RID: 46019 RVA: 0x00280B00 File Offset: 0x0027EF00
		public void OnSceneEquipEnhanceChg(ItemData itemData, uint expendId, byte enhanceType)
		{
			SceneEquipEnhanceChg sceneEquipEnhanceChg = new SceneEquipEnhanceChg();
			sceneEquipEnhanceChg.euqipUid = itemData.GUID;
			sceneEquipEnhanceChg.stuffID = expendId;
			sceneEquipEnhanceChg.enhanceType = enhanceType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEquipEnhanceChg>(ServerType.GATE_SERVER, sceneEquipEnhanceChg);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(501067U, delegate(MsgDATA msgData)
			{
				SceneEquipEnhanceChgRet sceneEquipEnhanceChgRet = new SceneEquipEnhanceChgRet();
				sceneEquipEnhanceChgRet.decode(msgData.bytes);
				if (sceneEquipEnhanceChgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)sceneEquipEnhanceChgRet.code, string.Empty);
				}
				else
				{
					EquipmentClearChangeActivationResultData equipmentClearChangeActivationResultData = new EquipmentClearChangeActivationResultData();
					equipmentClearChangeActivationResultData.mEquipItemData = itemData;
					equipmentClearChangeActivationResultData.mStrengthenGrowthType = StrengthenGrowthType.SGT_Change;
					this.OpenClearActivationChangedResultFrame(equipmentClearChangeActivationResultData);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRedMarkEquipChangedSuccess, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3C4 RID: 46020 RVA: 0x00280B78 File Offset: 0x0027EF78
		public void OnSceneEnhanceMaterialCombo(uint goalId, uint goalNum)
		{
			SceneEnhanceMaterialCombo sceneEnhanceMaterialCombo = new SceneEnhanceMaterialCombo();
			sceneEnhanceMaterialCombo.goalId = goalId;
			sceneEnhanceMaterialCombo.goalNum = goalNum;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEnhanceMaterialCombo>(ServerType.GATE_SERVER, sceneEnhanceMaterialCombo);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(501069U, delegate(MsgDATA msgData)
			{
				SceneEnhanceMaterialComboRet sceneEnhanceMaterialComboRet = new SceneEnhanceMaterialComboRet();
				sceneEnhanceMaterialComboRet.decode(msgData.bytes);
				if (sceneEnhanceMaterialComboRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)sceneEnhanceMaterialComboRet.code, string.Empty);
				}
				else
				{
					MaterialsSynthesisResultData materialsSynthesisResultData = new MaterialsSynthesisResultData();
					materialsSynthesisResultData.itemId = (int)goalId;
					materialsSynthesisResultData.itemNumber = (int)goalNum;
					this.OpenClearActivationChangedResultFrame(materialsSynthesisResultData);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B3C5 RID: 46021 RVA: 0x00280BF0 File Offset: 0x0027EFF0
		private void OpenClearActivationChangedResultFrame(EquipmentClearChangeActivationResultData data)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EnchantResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<EnchantResultFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EnchantResultFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x0600B3C6 RID: 46022 RVA: 0x00280C20 File Offset: 0x0027F020
		private void OpenClearActivationChangedResultFrame(MaterialsSynthesisResultData data)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EnchantResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<EnchantResultFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EnchantResultFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x0600B3C7 RID: 46023 RVA: 0x00280C50 File Offset: 0x0027F050
		public string GetGrowthAttrDesc(EGrowthAttrType type)
		{
			string result = string.Empty;
			switch (type)
			{
			case EGrowthAttrType.GAT_STRENGTH:
				result = TR.Value("growth_attr_strength");
				break;
			case EGrowthAttrType.GAT_INTELLIGENCE:
				result = TR.Value("growth_attr_intelligence");
				break;
			case EGrowthAttrType.GAT_STAMINA:
				result = TR.Value("growth_attr_stamina");
				break;
			case EGrowthAttrType.GAT_SPIRIT:
				result = TR.Value("growth_attr_spirit");
				break;
			}
			return result;
		}

		// Token: 0x0600B3C8 RID: 46024 RVA: 0x00280CD0 File Offset: 0x0027F0D0
		public static void MandatoryCloseSmithshopNewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SmithShopNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenContinueResultsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenContinueResultsFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenContinueConfirm>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenContinueConfirm>(null, false);
			}
		}

		// Token: 0x0600B3C9 RID: 46025 RVA: 0x00280D50 File Offset: 0x0027F150
		public List<ItemData> GetDisposableIncreaseItemList(ItemData currentSelectItemData)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageThirdType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageThirdType(EPackageType.Material, ItemTable.eThirdType.DisposableIncreaseItem);
			if (itemsByPackageThirdType != null)
			{
				for (int i = 0; i < itemsByPackageThirdType.Count; i++)
				{
					ulong id = itemsByPackageThirdType[i];
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
					if (item != null)
					{
						OneStrengEnhanceTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<OneStrengEnhanceTicketTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null && currentSelectItemData != null)
						{
							int strengthenLevel = currentSelectItemData.StrengthenLevel;
							if (strengthenLevel < tableItem.LvLimitBegin || strengthenLevel > tableItem.LvLimitEnd)
							{
								goto IL_A0;
							}
						}
						list.Add(item);
					}
					IL_A0:;
				}
			}
			return list;
		}

		// Token: 0x04006561 RID: 25953
		private Dictionary<int, List<int>> mStrengthLevelDict = new Dictionary<int, List<int>>();

		// Token: 0x04006562 RID: 25954
		private List<GrowthCostData> mGrowthCostDataList = new List<GrowthCostData>();

		// Token: 0x04006563 RID: 25955
		private List<GrowthAttributeData> mGrowthAttributeDataList = new List<GrowthAttributeData>();

		// Token: 0x04006564 RID: 25956
		private List<MaterialsSynthesisData> mMaterialsSynthesisDataList = new List<MaterialsSynthesisData>();

		// Token: 0x04006565 RID: 25957
		private StrengthenResult mGrowthResult;

		// Token: 0x04006566 RID: 25958
		public bool IsEquipIntensify;

		// Token: 0x04006567 RID: 25959
		public bool IsEquipmentIntensifyBroken;
	}
}
