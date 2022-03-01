using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200124E RID: 4686
	public class EpicEquipmentTransformationDataManager : DataManager<EpicEquipmentTransformationDataManager>
	{
		// Token: 0x0600B411 RID: 46097 RVA: 0x00283BAC File Offset: 0x00281FAC
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B412 RID: 46098 RVA: 0x00283BB0 File Offset: 0x00281FB0
		public sealed override void Clear()
		{
			this._UnRegisterNetHandler();
			this.UnbindEvent();
			this.mEquieChangeTableList.Clear();
			this.mEquChangeConsumeTableList.Clear();
		}

		// Token: 0x0600B413 RID: 46099 RVA: 0x00283BD4 File Offset: 0x00281FD4
		public sealed override void Initialize()
		{
			this.OnInitEquieChangeTable();
			this.OnInitEquChangeConsumeTable();
			this._RegisterNetHandler();
			this.BindEvent();
		}

		// Token: 0x0600B414 RID: 46100 RVA: 0x00283BEE File Offset: 0x00281FEE
		private void BindEvent()
		{
		}

		// Token: 0x0600B415 RID: 46101 RVA: 0x00283BF0 File Offset: 0x00281FF0
		private void UnbindEvent()
		{
		}

		// Token: 0x0600B416 RID: 46102 RVA: 0x00283BF2 File Offset: 0x00281FF2
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(501093U, new Action<MsgDATA>(this.OnSceneEquipConvertRes));
		}

		// Token: 0x0600B417 RID: 46103 RVA: 0x00283C0A File Offset: 0x0028200A
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(501093U, new Action<MsgDATA>(this.OnSceneEquipConvertRes));
		}

		// Token: 0x0600B418 RID: 46104 RVA: 0x00283C24 File Offset: 0x00282024
		private void OnSceneEquipConvertRes(MsgDATA msg)
		{
			SceneEquipConvertRes sceneEquipConvertRes = new SceneEquipConvertRes();
			sceneEquipConvertRes.decode(msg.bytes);
			if (sceneEquipConvertRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipConvertRes.retCode, string.Empty);
			}
			else
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(sceneEquipConvertRes.eqGuid);
				if (item == null)
				{
					Logger.LogErrorFormat("装备转化返回装备GUID有误", new object[0]);
					return;
				}
				item.TableData = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				item.ThirdType = item.TableData.ThirdType;
				item.SubType = (int)item.TableData.SubType;
				item.EquipWearSlotType = (EEquipWearSlotType)item.TableData.SubType;
				if (item.MagicProp != null)
				{
					item.MagicProp.ResetProperties();
				}
				if (item.BeadProp != null)
				{
					item.BeadProp.ResetProperties();
				}
				if (item.IncriptionProp != null)
				{
					item.IncriptionProp.ResetProperties();
				}
				bool isOpenHole = item.InscriptionHoles.Count > 0 && item.InscriptionHoles[0].IsOpenHole;
				item.InscriptionHoles = DataManager<InscriptionMosaicDataManager>.GetInstance().GetEquipmentInscriptionHoleData(item);
				if (item.InscriptionHoles.Count > 0)
				{
					item.InscriptionHoles[0].IsOpenHole = isOpenHole;
				}
				EpicEquipmentTransformationSuccessData epicEquipmentTransformationSuccessData = new EpicEquipmentTransformationSuccessData();
				epicEquipmentTransformationSuccessData.itemData = item;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EquipUpgradeResultFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<EquipUpgradeResultFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, epicEquipmentTransformationSuccessData, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEpicEquipmentConversionSuccessed, null, null, null, null);
			}
		}

		// Token: 0x0600B419 RID: 46105 RVA: 0x00283DCC File Offset: 0x002821CC
		public void OnSceneEquipConvertReq(byte equipConvertType, ulong guid, uint targetid, ulong converterGuid)
		{
			SceneEquipConvertReq sceneEquipConvertReq = new SceneEquipConvertReq();
			sceneEquipConvertReq.type = equipConvertType;
			sceneEquipConvertReq.sourceEqGuid = guid;
			sceneEquipConvertReq.targetEqTypeId = targetid;
			sceneEquipConvertReq.convertorGuid = converterGuid;
			MonoSingleton<NetManager>.instance.SendCommand<SceneEquipConvertReq>(ServerType.GATE_SERVER, sceneEquipConvertReq);
		}

		// Token: 0x0600B41A RID: 46106 RVA: 0x00283E0C File Offset: 0x0028220C
		private void OnInitEquieChangeTable()
		{
			if (this.mEquieChangeTableList != null)
			{
				this.mEquieChangeTableList.Clear();
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquieChangeTable>())
			{
				EquieChangeTable equieChangeTable = keyValuePair.Value as EquieChangeTable;
				if (equieChangeTable != null)
				{
					if (equieChangeTable.ConvertType == 1)
					{
						this.mEquieChangeTableList.Add(equieChangeTable);
					}
				}
			}
		}

		// Token: 0x0600B41B RID: 46107 RVA: 0x00283E90 File Offset: 0x00282290
		private void OnInitEquChangeConsumeTable()
		{
			if (this.mEquChangeConsumeTableList != null)
			{
				this.mEquChangeConsumeTableList.Clear();
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquChangeConsumeTable>())
			{
				EquChangeConsumeTable equChangeConsumeTable = keyValuePair.Value as EquChangeConsumeTable;
				if (equChangeConsumeTable != null)
				{
					this.mEquChangeConsumeTableList.Add(equChangeConsumeTable);
				}
			}
		}

		// Token: 0x0600B41C RID: 46108 RVA: 0x00283F00 File Offset: 0x00282300
		public bool CheckEpicEquipmentCanbeDisplayedInTheEquipmentList(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			for (int i = 0; i < this.mEquieChangeTableList.Count; i++)
			{
				EquieChangeTable equieChangeTable = this.mEquieChangeTableList[i];
				if (equieChangeTable != null)
				{
					if (equieChangeTable.JobID.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						if (equieChangeTable.UseEquipSuit.Contains(itemData.TableID))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B41D RID: 46109 RVA: 0x00283F88 File Offset: 0x00282388
		public bool CheckCrossEpicEquipmentCanbeDisplayedInTheEquipmentList(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			for (int i = 0; i < this.mEquieChangeTableList.Count; i++)
			{
				EquieChangeTable equieChangeTable = this.mEquieChangeTableList[i];
				if (equieChangeTable != null)
				{
					if (!equieChangeTable.JobID.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						if (equieChangeTable.UseEquipSuit.Contains(itemData.TableID))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B41E RID: 46110 RVA: 0x00284010 File Offset: 0x00282410
		public List<ItemData> GetTargetEquipmentList(ItemData itemData)
		{
			List<ItemData> list = new List<ItemData>();
			for (int i = 0; i < this.mEquieChangeTableList.Count; i++)
			{
				EquieChangeTable equieChangeTable = this.mEquieChangeTableList[i];
				if (equieChangeTable != null)
				{
					if (equieChangeTable.JobID.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						if (equieChangeTable.Level.Contains(itemData.LevelLimit))
						{
							for (int j = 0; j < equieChangeTable.UseEquipSuit.Count; j++)
							{
								ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(equieChangeTable.UseEquipSuit[j], itemData.SubQuality, 0);
								if (itemData2 != null)
								{
									if (itemData2.SubType != itemData.SubType)
									{
										if (itemData2.ThirdType == itemData.ThirdType)
										{
											itemData2.StrengthenLevel = itemData.StrengthenLevel;
											itemData2.bLocked = itemData.bLocked;
											itemData2.SubQuality = itemData.SubQuality;
											itemData2.BeadAdditiveAttributeBuffID = itemData.BeadAdditiveAttributeBuffID;
											itemData2.EquipType = itemData.EquipType;
											itemData2.GrowthAttrType = itemData.GrowthAttrType;
											itemData2.GrowthAttrNum = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(itemData2, itemData2.StrengthenLevel);
											itemData2.InscriptionHoles = DataManager<InscriptionMosaicDataManager>.GetInstance().GetEquipmentInscriptionHoleData(itemData2);
											for (int k = 0; k < itemData.InscriptionHoles.Count; k++)
											{
												InscriptionHoleData inscriptionHoleData = itemData.InscriptionHoles[k];
												if (inscriptionHoleData != null)
												{
													if (itemData2.InscriptionHoles[k] != null)
													{
														itemData2.InscriptionHoles[k].IsOpenHole = inscriptionHoleData.IsOpenHole;
													}
												}
											}
											ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(itemData2.TableID, false);
											itemStrengthAttribute.SetStrength(itemData2.StrengthenLevel, false, 0);
											ItemData itemData3 = itemStrengthAttribute.GetItemData();
											itemData2.BaseProp.props[39] = itemData3.BaseProp.props[39];
											itemData2.BaseProp.props[37] = itemData3.BaseProp.props[37];
											itemData2.BaseProp.props[40] = itemData3.BaseProp.props[40];
											itemData2.BaseProp.props[38] = itemData3.BaseProp.props[38];
											itemData2.BaseProp.props[60] = itemData3.BaseProp.props[60];
											itemData2.BaseProp.props[43] = itemData3.BaseProp.props[43];
											itemData2.BaseProp.props[41] = itemData3.BaseProp.props[41];
											itemData2.BaseProp.props[44] = itemData3.BaseProp.props[44];
											itemData2.BaseProp.props[42] = itemData3.BaseProp.props[42];
											itemData2.RefreshRateScore();
											list.Add(itemData2);
										}
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B41F RID: 46111 RVA: 0x002843CC File Offset: 0x002827CC
		public List<ItemData> GetCrossTargetEquipmentList(ItemData itemData)
		{
			List<ItemData> list = new List<ItemData>();
			for (int i = 0; i < this.mEquieChangeTableList.Count; i++)
			{
				EquieChangeTable equieChangeTable = this.mEquieChangeTableList[i];
				if (equieChangeTable != null)
				{
					if (equieChangeTable.JobID.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						if (equieChangeTable.Level.Contains(itemData.LevelLimit))
						{
							for (int j = 0; j < equieChangeTable.UseEquipSuit.Count; j++)
							{
								ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(equieChangeTable.UseEquipSuit[j], itemData.SubQuality, 0);
								if (itemData2 != null)
								{
									if (itemData2.SubType == itemData.SubType)
									{
										itemData2.StrengthenLevel = itemData.StrengthenLevel;
										itemData2.bLocked = itemData.bLocked;
										itemData2.SubQuality = itemData.SubQuality;
										itemData2.BeadAdditiveAttributeBuffID = itemData.BeadAdditiveAttributeBuffID;
										itemData2.EquipType = itemData.EquipType;
										itemData2.GrowthAttrType = itemData.GrowthAttrType;
										itemData2.GrowthAttrNum = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(itemData2, itemData2.StrengthenLevel);
										itemData2.InscriptionHoles = DataManager<InscriptionMosaicDataManager>.GetInstance().GetEquipmentInscriptionHoleData(itemData2);
										for (int k = 0; k < itemData.InscriptionHoles.Count; k++)
										{
											InscriptionHoleData inscriptionHoleData = itemData.InscriptionHoles[k];
											if (inscriptionHoleData != null)
											{
												if (itemData2.InscriptionHoles[k] != null)
												{
													itemData2.InscriptionHoles[k].IsOpenHole = inscriptionHoleData.IsOpenHole;
												}
											}
										}
										ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(itemData2.TableID, false);
										itemStrengthAttribute.SetStrength(itemData2.StrengthenLevel, false, 0);
										ItemData itemData3 = itemStrengthAttribute.GetItemData();
										itemData2.BaseProp.props[39] = itemData3.BaseProp.props[39];
										itemData2.BaseProp.props[37] = itemData3.BaseProp.props[37];
										itemData2.BaseProp.props[40] = itemData3.BaseProp.props[40];
										itemData2.BaseProp.props[38] = itemData3.BaseProp.props[38];
										itemData2.BaseProp.props[60] = itemData3.BaseProp.props[60];
										itemData2.BaseProp.props[43] = itemData3.BaseProp.props[43];
										itemData2.BaseProp.props[41] = itemData3.BaseProp.props[41];
										itemData2.BaseProp.props[44] = itemData3.BaseProp.props[44];
										itemData2.BaseProp.props[42] = itemData3.BaseProp.props[42];
										itemData2.RefreshRateScore();
										list.Add(itemData2);
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B420 RID: 46112 RVA: 0x00284774 File Offset: 0x00282B74
		public void GetConvertedTargetEquipmentMaterial(EpicEquipmentTransformationType type, ItemData itemData, ref List<ItemSimpleData> materialList, ref List<ItemSimpleData> converterList)
		{
			for (int i = 0; i < this.mEquChangeConsumeTableList.Count; i++)
			{
				EquChangeConsumeTable equChangeConsumeTable = this.mEquChangeConsumeTableList[i];
				if (equChangeConsumeTable != null)
				{
					if (equChangeConsumeTable.ConvertType == (int)type)
					{
						if (equChangeConsumeTable.Level == itemData.LevelLimit)
						{
							if (equChangeConsumeTable.SubType == (EquChangeConsumeTable.eSubType)itemData.SubType)
							{
								for (int j = 0; j < equChangeConsumeTable.ItemConsume.Count; j++)
								{
									string text = equChangeConsumeTable.ItemConsume[j];
									foreach (string text2 in text.Split(new char[]
									{
										'|'
									}))
									{
										string[] array2 = text2.Split(new char[]
										{
											'_'
										});
										if (array2.Length >= 2)
										{
											int itemID = 0;
											int count = 0;
											int.TryParse(array2[0], out itemID);
											int.TryParse(array2[1], out count);
											ItemSimpleData itemSimpleData = new ItemSimpleData();
											itemSimpleData.ItemID = itemID;
											itemSimpleData.Count = count;
											materialList.Add(itemSimpleData);
										}
									}
								}
								string converterConsume = equChangeConsumeTable.ConverterConsume;
								foreach (string text3 in converterConsume.Split(new char[]
								{
									'|'
								}))
								{
									string[] array4 = text3.Split(new char[]
									{
										'_'
									});
									if (array4.Length >= 3)
									{
										int itemID2 = 0;
										int count2 = 0;
										int level = 0;
										int.TryParse(array4[0], out itemID2);
										int.TryParse(array4[1], out level);
										int.TryParse(array4[2], out count2);
										ItemSimpleData itemSimpleData2 = new ItemSimpleData();
										itemSimpleData2.ItemID = itemID2;
										itemSimpleData2.Count = count2;
										itemSimpleData2.level = level;
										converterList.Add(itemSimpleData2);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04006585 RID: 25989
		private List<EquieChangeTable> mEquieChangeTableList = new List<EquieChangeTable>();

		// Token: 0x04006586 RID: 25990
		private List<EquChangeConsumeTable> mEquChangeConsumeTableList = new List<EquChangeConsumeTable>();
	}
}
