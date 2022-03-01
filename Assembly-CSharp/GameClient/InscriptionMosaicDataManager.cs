using System;
using System.Collections.Generic;
using System.Text;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001B5C RID: 7004
	public class InscriptionMosaicDataManager : DataManager<InscriptionMosaicDataManager>
	{
		// Token: 0x06011270 RID: 70256 RVA: 0x004ECC5D File Offset: 0x004EB05D
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x06011271 RID: 70257 RVA: 0x004ECC64 File Offset: 0x004EB064
		public sealed override void Clear()
		{
			if (this.mInscriptionAllEquipment != null)
			{
				this.mInscriptionAllEquipment.Clear();
			}
			if (this.mOpenInscriptionHoleConsumeList != null)
			{
				this.mOpenInscriptionHoleConsumeList.Clear();
			}
			if (this.mInscriptionExtractDataList != null)
			{
				this.mInscriptionExtractDataList.Clear();
			}
			if (this.mInscriptionFractureDataList != null)
			{
				this.mInscriptionFractureDataList.Clear();
			}
			if (this.mInscriptionProbabilityDataList != null)
			{
				this.mInscriptionProbabilityDataList.Clear();
			}
			if (this.mInscriptionSysnthesisDataList != null)
			{
				this.mInscriptionSysnthesisDataList.Clear();
			}
			InscriptionMosaicDataManager.IncriptionSynthesisHightQualityBounced = false;
			InscriptionMosaicDataManager.InscriptionMosiacBounced = false;
			this.UnBindNetMessage();
		}

		// Token: 0x06011272 RID: 70258 RVA: 0x004ECD07 File Offset: 0x004EB107
		public sealed override void Initialize()
		{
			this.BindNetMessage();
			this.InitEquipInscriptionHoleTable();
			this.InitInscriptionExtractTable();
			this.InitInscriptionProbabilityTable();
			this.InitInscriptionSynthesisTable();
		}

		// Token: 0x06011273 RID: 70259 RVA: 0x004ECD28 File Offset: 0x004EB128
		private void BindNetMessage()
		{
			NetProcess.AddMsgHandler(501076U, new Action<MsgDATA>(this.OnSceneEquipInscriptionOpenRes));
			NetProcess.AddMsgHandler(501078U, new Action<MsgDATA>(this.OnSceneEquipInscriptionMountRes));
			NetProcess.AddMsgHandler(501080U, new Action<MsgDATA>(this.OnSceneEquipInscriptionExtractRes));
			NetProcess.AddMsgHandler(501082U, new Action<MsgDATA>(this.OnSceneEquipInscriptionSynthesisRes));
			NetProcess.AddMsgHandler(501084U, new Action<MsgDATA>(this.OnSceneEquipInscriptionDestroyRes));
		}

		// Token: 0x06011274 RID: 70260 RVA: 0x004ECDA4 File Offset: 0x004EB1A4
		private void UnBindNetMessage()
		{
			NetProcess.RemoveMsgHandler(501076U, new Action<MsgDATA>(this.OnSceneEquipInscriptionOpenRes));
			NetProcess.RemoveMsgHandler(501078U, new Action<MsgDATA>(this.OnSceneEquipInscriptionMountRes));
			NetProcess.RemoveMsgHandler(501080U, new Action<MsgDATA>(this.OnSceneEquipInscriptionExtractRes));
			NetProcess.RemoveMsgHandler(501082U, new Action<MsgDATA>(this.OnSceneEquipInscriptionSynthesisRes));
			NetProcess.RemoveMsgHandler(501084U, new Action<MsgDATA>(this.OnSceneEquipInscriptionDestroyRes));
		}

		// Token: 0x06011275 RID: 70261 RVA: 0x004ECE20 File Offset: 0x004EB220
		private void OnSceneEquipInscriptionOpenRes(MsgDATA msg)
		{
			SceneEquipInscriptionOpenRes sceneEquipInscriptionOpenRes = new SceneEquipInscriptionOpenRes();
			sceneEquipInscriptionOpenRes.decode(msg.bytes);
			if (sceneEquipInscriptionOpenRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipInscriptionOpenRes.code, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect("铭文插槽开启成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnInscriptionHoleOpenHoleSuccess, null, null, null, null);
			}
		}

		// Token: 0x06011276 RID: 70262 RVA: 0x004ECE80 File Offset: 0x004EB280
		private void OnSceneEquipInscriptionMountRes(MsgDATA msg)
		{
			SceneEquipInscriptionMountRes sceneEquipInscriptionMountRes = new SceneEquipInscriptionMountRes();
			sceneEquipInscriptionMountRes.decode(msg.bytes);
			if (sceneEquipInscriptionMountRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipInscriptionMountRes.code, string.Empty);
			}
			else
			{
				InscriptionMosaicSuccessData inscriptionMosaicSuccessData = new InscriptionMosaicSuccessData();
				inscriptionMosaicSuccessData.guid = sceneEquipInscriptionMountRes.guid;
				inscriptionMosaicSuccessData.inscriptionId = (int)sceneEquipInscriptionMountRes.inscriptionId;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, inscriptionMosaicSuccessData, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnInscriptionMosaicSuccess, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnItemEquipInscriptionSucceed, sceneEquipInscriptionMountRes.guid, null, null, null);
			}
		}

		// Token: 0x06011277 RID: 70263 RVA: 0x004ECF20 File Offset: 0x004EB320
		private void OnSceneEquipInscriptionExtractRes(MsgDATA msg)
		{
			SceneEquipInscriptionExtractRes sceneEquipInscriptionExtractRes = new SceneEquipInscriptionExtractRes();
			sceneEquipInscriptionExtractRes.decode(msg.bytes);
			if (sceneEquipInscriptionExtractRes.code != 0U)
			{
				InscriptionExtractResultData userData = new InscriptionExtractResultData(false, null);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			else
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)sceneEquipInscriptionExtractRes.inscriptionId, 100, 0);
				InscriptionExtractResultData userData2 = new InscriptionExtractResultData(true, itemData);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, userData2, string.Empty);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<InscriptionExtractFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<InscriptionExtractFrame>(null, false);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnInscriptionMosaicSuccess, null, null, null, null);
			}
		}

		// Token: 0x06011278 RID: 70264 RVA: 0x004ECFC4 File Offset: 0x004EB3C4
		private void OnSceneEquipInscriptionSynthesisRes(MsgDATA msg)
		{
			SceneEquipInscriptionSynthesisRes sceneEquipInscriptionSynthesisRes = new SceneEquipInscriptionSynthesisRes();
			sceneEquipInscriptionSynthesisRes.decode(msg.bytes);
			if (sceneEquipInscriptionSynthesisRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipInscriptionSynthesisRes.retCode, string.Empty);
			}
			else
			{
				List<ResultItemData> list = new List<ResultItemData>();
				for (int i = 0; i < sceneEquipInscriptionSynthesisRes.items.Length; i++)
				{
					ItemReward itemReward = sceneEquipInscriptionSynthesisRes.items[i];
					if (itemReward != null)
					{
						ResultItemData resultItemData = new ResultItemData();
						resultItemData.itemData = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, 100, 0);
						resultItemData.itemData.Count = (int)itemReward.num;
						resultItemData.desc = resultItemData.itemData.GetColorName(string.Empty, false);
						list.Add(resultItemData);
					}
				}
				CommonGetItemData commonGetItemData = new CommonGetItemData();
				commonGetItemData.itemDatas = list;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<InscriptionSynthesisResultFrame>(FrameLayer.Middle, commonGetItemData, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnIncriptionSynthesisSuccess, null, null, null, null);
			}
		}

		// Token: 0x06011279 RID: 70265 RVA: 0x004ED0BC File Offset: 0x004EB4BC
		private void OnSceneEquipInscriptionDestroyRes(MsgDATA msg)
		{
			SceneEquipInscriptionDestroyRes sceneEquipInscriptionDestroyRes = new SceneEquipInscriptionDestroyRes();
			sceneEquipInscriptionDestroyRes.decode(msg.bytes);
			if (sceneEquipInscriptionDestroyRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipInscriptionDestroyRes.code, string.Empty);
			}
			else
			{
				InscriptionFracturnResultData inscriptionFracturnResultData = new InscriptionFracturnResultData();
				inscriptionFracturnResultData.IsSuccessed = true;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipUpgradeResultFrame>(FrameLayer.Middle, inscriptionFracturnResultData, string.Empty);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<InscriptionFractureFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<InscriptionFractureFrame>(null, false);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnInscriptionMosaicSuccess, null, null, null, null);
			}
		}

		// Token: 0x0601127A RID: 70266 RVA: 0x004ED14C File Offset: 0x004EB54C
		public void OnSceneEquipInscriptionOpenReq(ulong guid, uint index)
		{
			SceneEquipInscriptionOpenReq sceneEquipInscriptionOpenReq = new SceneEquipInscriptionOpenReq();
			sceneEquipInscriptionOpenReq.guid = guid;
			sceneEquipInscriptionOpenReq.index = index;
			NetManager.Instance().SendCommand<SceneEquipInscriptionOpenReq>(ServerType.GATE_SERVER, sceneEquipInscriptionOpenReq);
		}

		// Token: 0x0601127B RID: 70267 RVA: 0x004ED17C File Offset: 0x004EB57C
		public void OnSceneEquipInscriptionMountReq(ulong equipGuid, uint index, ulong inscriptionGuid, uint inscriptionItemid)
		{
			SceneEquipInscriptionMountReq sceneEquipInscriptionMountReq = new SceneEquipInscriptionMountReq();
			sceneEquipInscriptionMountReq.guid = equipGuid;
			sceneEquipInscriptionMountReq.index = index;
			sceneEquipInscriptionMountReq.inscriptionGuid = inscriptionGuid;
			sceneEquipInscriptionMountReq.inscriptionId = inscriptionItemid;
			NetManager.Instance().SendCommand<SceneEquipInscriptionMountReq>(ServerType.GATE_SERVER, sceneEquipInscriptionMountReq);
		}

		// Token: 0x0601127C RID: 70268 RVA: 0x004ED1BC File Offset: 0x004EB5BC
		public void OnSceneEquipInscriptionExtractReq(ulong equipGuid, uint inscriptionId, uint index)
		{
			SceneEquipInscriptionExtractReq sceneEquipInscriptionExtractReq = new SceneEquipInscriptionExtractReq();
			sceneEquipInscriptionExtractReq.guid = equipGuid;
			sceneEquipInscriptionExtractReq.inscriptionId = inscriptionId;
			sceneEquipInscriptionExtractReq.index = index;
			NetManager.Instance().SendCommand<SceneEquipInscriptionExtractReq>(ServerType.GATE_SERVER, sceneEquipInscriptionExtractReq);
		}

		// Token: 0x0601127D RID: 70269 RVA: 0x004ED1F4 File Offset: 0x004EB5F4
		public void OnSceneEquipInscriptionDestroyReq(ulong equipGuid, uint inscriptionId, uint index)
		{
			SceneEquipInscriptionDestroyReq sceneEquipInscriptionDestroyReq = new SceneEquipInscriptionDestroyReq();
			sceneEquipInscriptionDestroyReq.guid = equipGuid;
			sceneEquipInscriptionDestroyReq.inscriptionId = inscriptionId;
			sceneEquipInscriptionDestroyReq.index = index;
			NetManager.Instance().SendCommand<SceneEquipInscriptionDestroyReq>(ServerType.GATE_SERVER, sceneEquipInscriptionDestroyReq);
		}

		// Token: 0x0601127E RID: 70270 RVA: 0x004ED22C File Offset: 0x004EB62C
		public void OnSceneEquipInscriptionSynthesisReq(uint[] itemIDVec)
		{
			SceneEquipInscriptionSynthesisReq sceneEquipInscriptionSynthesisReq = new SceneEquipInscriptionSynthesisReq();
			sceneEquipInscriptionSynthesisReq.itemIDVec = itemIDVec;
			NetManager.Instance().SendCommand<SceneEquipInscriptionSynthesisReq>(ServerType.GATE_SERVER, sceneEquipInscriptionSynthesisReq);
		}

		// Token: 0x0601127F RID: 70271 RVA: 0x004ED254 File Offset: 0x004EB654
		private void InitEquipInscriptionHoleTable()
		{
			if (this.mOpenInscriptionHoleConsumeList == null)
			{
				this.mOpenInscriptionHoleConsumeList = new List<EquipInscriptionHoleData>();
			}
			this.mOpenInscriptionHoleConsumeList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipInscriptionHoleTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					EquipInscriptionHoleTable equipInscriptionHoleTable = keyValuePair.Value as EquipInscriptionHoleTable;
					if (equipInscriptionHoleTable != null)
					{
						EquipInscriptionHoleData equipInscriptionHoleData = new EquipInscriptionHoleData();
						equipInscriptionHoleData.iColor = (int)equipInscriptionHoleTable.Color;
						equipInscriptionHoleData.iSubType = (int)equipInscriptionHoleTable.SubType;
						equipInscriptionHoleData.iItemConsume = this.GetInscriptionConsume(equipInscriptionHoleTable.ItemConsume);
						equipInscriptionHoleData.iGoldConsume = this.GetInscriptionConsume(equipInscriptionHoleTable.GoldConsume);
						equipInscriptionHoleData.lEquipmentInscriptionHole = this.GetEquipmentInscriptionHoleData(equipInscriptionHoleTable.InscriptionHoleColor);
						this.mOpenInscriptionHoleConsumeList.Add(equipInscriptionHoleData);
					}
				}
			}
		}

		// Token: 0x06011280 RID: 70272 RVA: 0x004ED334 File Offset: 0x004EB734
		private void InitInscriptionExtractTable()
		{
			if (this.mInscriptionExtractDataList == null)
			{
				this.mInscriptionExtractDataList = new List<InscriptionExtractData>();
			}
			this.mInscriptionExtractDataList.Clear();
			if (this.mInscriptionFractureDataList == null)
			{
				this.mInscriptionFractureDataList = new List<InscriptionExtractData>();
			}
			this.mInscriptionFractureDataList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<InscriptionExtractTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					InscriptionExtractTable inscriptionExtractTable = keyValuePair.Value as InscriptionExtractTable;
					if (inscriptionExtractTable != null)
					{
						InscriptionExtractData item = new InscriptionExtractData((int)inscriptionExtractTable.Color, this.GetInscriptionExtractConsumes(inscriptionExtractTable.ExtractItemConsume), inscriptionExtractTable.ExtractProbability, inscriptionExtractTable.IsExtract == 1);
						this.mInscriptionExtractDataList.Add(item);
						InscriptionExtractData item2 = new InscriptionExtractData((int)inscriptionExtractTable.Color, this.GetInscriptionExtractConsumes(inscriptionExtractTable.DestroyConsume), inscriptionExtractTable.DestroyProbability, true);
						this.mInscriptionFractureDataList.Add(item2);
					}
				}
			}
		}

		// Token: 0x06011281 RID: 70273 RVA: 0x004ED430 File Offset: 0x004EB830
		private void InitInscriptionProbabilityTable()
		{
			this.mInscriptionProbabilityDataList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<InscriptionProbabilityTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					InscriptionProbabilityTable inscriptionProbabilityTable = keyValuePair.Value as InscriptionProbabilityTable;
					if (inscriptionProbabilityTable != null)
					{
						InscriptionProbabilityData item = new InscriptionProbabilityData(inscriptionProbabilityTable.MinProbability, inscriptionProbabilityTable.MaxProbability, inscriptionProbabilityTable.SuccessName);
						this.mInscriptionProbabilityDataList.Add(item);
					}
				}
			}
		}

		// Token: 0x06011282 RID: 70274 RVA: 0x004ED4B8 File Offset: 0x004EB8B8
		private InscriptionConsume GetInscriptionConsume(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return null;
			}
			InscriptionConsume inscriptionConsume = new InscriptionConsume();
			int itemId = 0;
			int count = 0;
			string[] array = str.Split(new char[]
			{
				'_'
			});
			if (array != null && array.Length >= 2)
			{
				int.TryParse(array[0], out itemId);
				int.TryParse(array[1], out count);
			}
			inscriptionConsume.itemId = itemId;
			inscriptionConsume.count = count;
			return inscriptionConsume;
		}

		// Token: 0x06011283 RID: 70275 RVA: 0x004ED524 File Offset: 0x004EB924
		private List<HoleData> GetEquipmentInscriptionHoleData(string str)
		{
			List<HoleData> list = new List<HoleData>();
			string[] array = str.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2 != null && array2.Length >= 2)
				{
					int index = 0;
					int type = 0;
					int.TryParse(array2[0], out index);
					int.TryParse(array2[1], out type);
					HoleData item = new HoleData(index, type);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06011284 RID: 70276 RVA: 0x004ED5B0 File Offset: 0x004EB9B0
		private List<InscriptionConsume> GetInscriptionExtractConsumes(string str)
		{
			List<InscriptionConsume> list = new List<InscriptionConsume>();
			string[] array = str.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2 != null && array2.Length >= 2)
				{
					int itemId = 0;
					int count = 0;
					int.TryParse(array2[0], out itemId);
					int.TryParse(array2[1], out count);
					list.Add(new InscriptionConsume
					{
						itemId = itemId,
						count = count
					});
				}
			}
			return list;
		}

		// Token: 0x06011285 RID: 70277 RVA: 0x004ED64A File Offset: 0x004EBA4A
		public List<ItemData> GetInscriptionAllEquipment()
		{
			return this.mInscriptionAllEquipment;
		}

		// Token: 0x06011286 RID: 70278 RVA: 0x004ED654 File Offset: 0x004EBA54
		public void LoadAllInscriptionEquipment()
		{
			if (this.mInscriptionAllEquipment == null)
			{
				this.mInscriptionAllEquipment = new List<ItemData>();
			}
			this.mInscriptionAllEquipment.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			this.AddInscriptionItemData(itemsByPackageType);
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			this.AddInscriptionItemData(itemsByPackageType2);
			this.mInscriptionAllEquipment.Sort(new Comparison<ItemData>(this.SoreInscriptionEquipment));
		}

		// Token: 0x06011287 RID: 70279 RVA: 0x004ED6C0 File Offset: 0x004EBAC0
		private void AddInscriptionItemData(List<ulong> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP)
					{
						if (item.SubType != 1)
						{
							if (item.Quality >= ItemTable.eColor.GREEN)
							{
								if (item.EquipType != EEquipType.ET_BREATH)
								{
									this.mInscriptionAllEquipment.Add(item);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06011288 RID: 70280 RVA: 0x004ED754 File Offset: 0x004EBB54
		private int SoreInscriptionEquipment(ItemData x, ItemData y)
		{
			if (x.PackageType != y.PackageType)
			{
				return y.PackageType - x.PackageType;
			}
			if (x.IsItemInUnUsedEquipPlan != y.IsItemInUnUsedEquipPlan)
			{
				if (x.IsItemInUnUsedEquipPlan)
				{
					return -1;
				}
				if (y.IsItemInUnUsedEquipPlan)
				{
					return 1;
				}
			}
			if (x.Quality != y.Quality)
			{
				return y.Quality - x.Quality;
			}
			if (x.SubType != y.SubType)
			{
				return x.SubType - y.SubType;
			}
			if (x.StrengthenLevel != y.StrengthenLevel)
			{
				return y.StrengthenLevel - x.StrengthenLevel;
			}
			return y.LevelLimit - x.LevelLimit;
		}

		// Token: 0x06011289 RID: 70281 RVA: 0x004ED818 File Offset: 0x004EBC18
		public List<InscriptionHoleData> GetEquipmentInscriptionHoleData(ItemData item)
		{
			List<HoleData> list = new List<HoleData>();
			for (int i = 0; i < this.mOpenInscriptionHoleConsumeList.Count; i++)
			{
				if (item.Quality == (ItemTable.eColor)this.mOpenInscriptionHoleConsumeList[i].iColor)
				{
					if (item.SubType == this.mOpenInscriptionHoleConsumeList[i].iSubType)
					{
						list = this.mOpenInscriptionHoleConsumeList[i].lEquipmentInscriptionHole;
						break;
					}
				}
			}
			List<InscriptionHoleData> list2 = new List<InscriptionHoleData>();
			for (int j = 0; j < list.Count; j++)
			{
				list2.Add(new InscriptionHoleData
				{
					Index = list[j].Index,
					Type = list[j].Type,
					InscriptionId = 0,
					IsOpenHole = false
				});
			}
			return list2;
		}

		// Token: 0x0601128A RID: 70282 RVA: 0x004ED904 File Offset: 0x004EBD04
		public List<HoleData> GetEquipmentInscriptionHoleNumber(ItemData item)
		{
			List<HoleData> result = new List<HoleData>();
			for (int i = 0; i < this.mOpenInscriptionHoleConsumeList.Count; i++)
			{
				if (item.Quality == (ItemTable.eColor)this.mOpenInscriptionHoleConsumeList[i].iColor)
				{
					if (item.SubType == this.mOpenInscriptionHoleConsumeList[i].iSubType)
					{
						result = this.mOpenInscriptionHoleConsumeList[i].lEquipmentInscriptionHole;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0601128B RID: 70283 RVA: 0x004ED990 File Offset: 0x004EBD90
		public List<ItemData> GetCanMosaicInscription(int holeType)
		{
			List<ItemData> list = new List<ItemData>();
			InscriptionHoleSetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionHoleSetTable>(holeType, string.Empty, string.Empty);
			if (tableItem != null)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Inscription);
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item != null)
						{
							if (tableItem.ThirdType.Contains((int)item.ThirdType))
							{
								InscriptionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(item.TableID, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									bool flag = false;
									if (tableItem2.Occu.Count > 0)
									{
										for (int j = 0; j < tableItem2.Occu.Count; j++)
										{
											int num = tableItem2.Occu[j];
											if (num == 0)
											{
												flag = true;
												break;
											}
											if (num == DataManager<PlayerBaseData>.GetInstance().JobTableID)
											{
												flag = true;
												break;
											}
											if (num == Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID))
											{
												flag = true;
												break;
											}
										}
									}
									if (flag)
									{
										list.Add(item);
									}
								}
							}
						}
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort(new Comparison<ItemData>(this.Sort));
			}
			return list;
		}

		// Token: 0x0601128C RID: 70284 RVA: 0x004EDB14 File Offset: 0x004EBF14
		private bool CheckAttributeIsApplyCurrentRole(InscriptionTable table)
		{
			bool result = false;
			if (table == null)
			{
				return result;
			}
			for (int i = 0; i < table.Occu.Length; i++)
			{
				if (table.Occu[i] == 0)
				{
					return true;
				}
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(table.Occu[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.prejob == 0)
					{
						if (tableItem.ID != Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID))
						{
							goto IL_A0;
						}
					}
					else if (tableItem.ID != DataManager<PlayerBaseData>.GetInstance().JobTableID)
					{
						goto IL_A0;
					}
					result = true;
					break;
				}
				IL_A0:;
			}
			return result;
		}

		// Token: 0x0601128D RID: 70285 RVA: 0x004EDBD8 File Offset: 0x004EBFD8
		public string GetInscriptionAttributesDesc(int id, bool isLine = true)
		{
			InscriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return this.GetInscriptionAttributesDesc(tableItem.PropType, tableItem.PropValue, tableItem.BuffID, isLine, this.CheckAttributeIsApplyCurrentRole(tableItem));
		}

		// Token: 0x0601128E RID: 70286 RVA: 0x004EDC28 File Offset: 0x004EC028
		public string GetInscriptionAttributesDesc(IList<int> iPropType, IList<int> iPropValue, IList<int> iBuffID, bool isLine, bool isApplyCurrentRole)
		{
			string result = string.Empty;
			bool flag = false;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			if (iPropType.Count == iPropValue.Count)
			{
				if (iPropType.Count > 0)
				{
					if (isApplyCurrentRole)
					{
						stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_attribute_color"));
					}
					else
					{
						stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_skills_gray_color"));
					}
				}
				for (int i = 0; i < iPropType.Count; i++)
				{
					if (iPropValue[i] != 0)
					{
						EServerProp enumValue = (EServerProp)iPropType[i];
						MapEnum mapEnum = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (mapEnum == null && iPropType[i] >= 18 && iPropType[i] <= 21)
						{
							mapEnum = new MapEnum((EEquipProp)(iPropType[i] - 18));
						}
						if (mapEnum == null && iPropType[i] >= 22 && iPropType[i] <= 25)
						{
							mapEnum = new MapEnum(EEquipProp.Elements);
						}
						if (mapEnum != null)
						{
							EEquipProp prop = mapEnum.Prop;
							string eequipProDesc = Utility.GetEEquipProDesc(prop, iPropValue[i], string.Empty);
							if (flag)
							{
								if (isLine)
								{
									stringBuilder.Append("\n");
								}
								else
								{
									stringBuilder.Append("、");
								}
							}
							stringBuilder.Append(eequipProDesc);
							flag = true;
						}
					}
				}
				if (iPropType.Count > 0)
				{
					stringBuilder.Append("</color>");
				}
			}
			for (int j = 0; j < iBuffID.Count; j++)
			{
				BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(iBuffID[j], string.Empty, string.Empty);
				if (tableItem != null && tableItem.Description.Count > 0)
				{
					if (flag)
					{
						if (isLine)
						{
							stringBuilder.Append("\n");
						}
						else
						{
							stringBuilder.Append("、");
						}
					}
					if (isApplyCurrentRole)
					{
						stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_color"), tableItem.Description[0]);
					}
					else
					{
						stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_skills_gray_color"), tableItem.Description[0]);
					}
					flag = true;
				}
			}
			result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x0601128F RID: 70287 RVA: 0x004EDE98 File Offset: 0x004EC298
		public string GetInscriptionSlotDescription(int inscriptionId)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat("<color={0}>", TR.Value("enchant_condition_color"));
			InscriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(inscriptionId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.InscriptionHole.Count; i++)
				{
					string enumDescription = Utility.GetEnumDescription<EInscriptionSlotType>((EInscriptionSlotType)tableItem.InscriptionHole[i]);
					stringBuilder.Append(TR.Value(enumDescription));
					if (i != tableItem.InscriptionHole.Count - 1)
					{
						stringBuilder.Append("、");
					}
				}
			}
			stringBuilder.Append("</color>");
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06011290 RID: 70288 RVA: 0x004EDF58 File Offset: 0x004EC358
		public string GetInscriptionApplicableToProfessionalDescription(int inscriptionId)
		{
			InscriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(inscriptionId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.AppendFormat(TR.Value("tip_inscription_job"), new object[0]);
			if (tableItem.Occu.Length == 1)
			{
				if (tableItem.Occu[0] == 0)
				{
					stringBuilder.Append(TR.Value("tip_inscription_job_green", "通用"));
				}
				else
				{
					JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(tableItem.Occu[0], string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						return string.Empty;
					}
					if (tableItem2.prejob == 0)
					{
						if (tableItem2.ID == Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID))
						{
							stringBuilder.Append(TR.Value("tip_inscription_job_green", tableItem2.Name));
						}
						else
						{
							stringBuilder.Append(TR.Value("tip_inscription_job_gray", tableItem2.Name));
						}
					}
					else if (tableItem2.ID == DataManager<PlayerBaseData>.GetInstance().JobTableID)
					{
						stringBuilder.Append(TR.Value("tip_inscription_job_green", tableItem2.Name));
					}
					else
					{
						stringBuilder.Append(TR.Value("tip_inscription_job_gray", tableItem2.Name));
					}
				}
			}
			else
			{
				for (int i = 0; i < tableItem.Occu.Length; i++)
				{
					JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(tableItem.Occu[i], string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						if (tableItem3.prejob == 0)
						{
							if (tableItem3.ID == Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID))
							{
								stringBuilder.Append(TR.Value("tip_inscription_job_green", tableItem3.Name));
							}
							else
							{
								stringBuilder.Append(TR.Value("tip_inscription_job_gray", tableItem3.Name));
							}
						}
						else if (tableItem3.ID == DataManager<PlayerBaseData>.GetInstance().JobTableID)
						{
							stringBuilder.Append(TR.Value("tip_inscription_job_green", tableItem3.Name));
						}
						else
						{
							stringBuilder.Append(TR.Value("tip_inscription_job_gray", tableItem3.Name));
						}
						if (i != tableItem.Occu.Length - 1)
						{
							stringBuilder.Append("、");
						}
					}
				}
			}
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06011291 RID: 70289 RVA: 0x004EE1E4 File Offset: 0x004EC5E4
		public EquipInscriptionHoleData GetOpenInscriptionHoleConsume(ItemData item)
		{
			EquipInscriptionHoleData result = null;
			if (item == null)
			{
				return result;
			}
			for (int i = 0; i < this.mOpenInscriptionHoleConsumeList.Count; i++)
			{
				if (item.Quality == (ItemTable.eColor)this.mOpenInscriptionHoleConsumeList[i].iColor)
				{
					if (item.SubType == this.mOpenInscriptionHoleConsumeList[i].iSubType)
					{
						result = this.mOpenInscriptionHoleConsumeList[i];
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011292 RID: 70290 RVA: 0x004EE26C File Offset: 0x004EC66C
		public bool CheckInscriptionItemIsExtract(int inscriptionItemId)
		{
			bool result = false;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(inscriptionItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < this.mInscriptionExtractDataList.Count; i++)
				{
					if (this.mInscriptionExtractDataList[i].Color == (int)tableItem.Color)
					{
						result = this.mInscriptionExtractDataList[i].IsExtract;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011293 RID: 70291 RVA: 0x004EE2EC File Offset: 0x004EC6EC
		public List<InscriptionConsume> GetInscriptionExtractConsume(int inscriptionItemId)
		{
			List<InscriptionConsume> result = new List<InscriptionConsume>();
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(inscriptionItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < this.mInscriptionExtractDataList.Count; i++)
				{
					if (this.mInscriptionExtractDataList[i].Color == (int)tableItem.Color)
					{
						result = this.mInscriptionExtractDataList[i].ExtractConsumes;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011294 RID: 70292 RVA: 0x004EE370 File Offset: 0x004EC770
		public List<InscriptionConsume> GetInscriptionFractureConsume(int inscriptionItemId)
		{
			List<InscriptionConsume> result = new List<InscriptionConsume>();
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(inscriptionItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < this.mInscriptionFractureDataList.Count; i++)
				{
					if (this.mInscriptionFractureDataList[i].Color == (int)tableItem.Color)
					{
						result = this.mInscriptionFractureDataList[i].ExtractConsumes;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011295 RID: 70293 RVA: 0x004EE3F4 File Offset: 0x004EC7F4
		public int GetInscriptionExtractSuccessRate(int inscriptionItemId)
		{
			int result = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(inscriptionItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < this.mInscriptionExtractDataList.Count; i++)
				{
					if (this.mInscriptionExtractDataList[i].Color == (int)tableItem.Color)
					{
						int.TryParse(this.mInscriptionExtractDataList[i].ExtractProbability, out result);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011296 RID: 70294 RVA: 0x004EE47C File Offset: 0x004EC87C
		public int GetInscriptionFractureSuccessRate(int inscriptionItemId)
		{
			int result = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(inscriptionItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < this.mInscriptionFractureDataList.Count; i++)
				{
					if (this.mInscriptionFractureDataList[i].Color == (int)tableItem.Color)
					{
						int.TryParse(this.mInscriptionFractureDataList[i].ExtractProbability, out result);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06011297 RID: 70295 RVA: 0x004EE504 File Offset: 0x004EC904
		public string GetInscriptionExtractSuccessRateDesc(int successRate)
		{
			string result = string.Empty;
			for (int i = 0; i < this.mInscriptionProbabilityDataList.Count; i++)
			{
				InscriptionProbabilityData inscriptionProbabilityData = this.mInscriptionProbabilityDataList[i];
				if (successRate > inscriptionProbabilityData.MinProbability && successRate <= inscriptionProbabilityData.MaxProbability)
				{
					result = inscriptionProbabilityData.SuccessName;
					break;
				}
			}
			return result;
		}

		// Token: 0x06011298 RID: 70296 RVA: 0x004EE568 File Offset: 0x004EC968
		public bool CheckEquipmentMosaicInscriptionQualityFollowingFive(ItemData item)
		{
			if (item.InscriptionHoles == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < item.InscriptionHoles.Count; i++)
			{
				InscriptionHoleData inscriptionHoleData = item.InscriptionHoles[i];
				if (inscriptionHoleData != null)
				{
					if (inscriptionHoleData.IsOpenHole)
					{
						if (inscriptionHoleData.InscriptionId > 0)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(inscriptionHoleData.InscriptionId, 100, 0);
							if (itemData != null)
							{
								if (itemData.Quality < ItemTable.eColor.YELLOW)
								{
									result = true;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06011299 RID: 70297 RVA: 0x004EE604 File Offset: 0x004ECA04
		public bool CheckEquipmentMosaicInscriptionQualityFive(ref List<ItemData> inscriptionItemDatas, ItemData item, bool isQualityFive = true)
		{
			if (item.InscriptionHoles == null)
			{
				return false;
			}
			inscriptionItemDatas = new List<ItemData>();
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < item.InscriptionHoles.Count; i++)
			{
				InscriptionHoleData inscriptionHoleData = item.InscriptionHoles[i];
				if (inscriptionHoleData != null)
				{
					if (inscriptionHoleData.IsOpenHole)
					{
						if (inscriptionHoleData.InscriptionId > 0)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(inscriptionHoleData.InscriptionId, 100, 0);
							if (itemData != null)
							{
								if (itemData.Quality == ItemTable.eColor.YELLOW)
								{
									flag = true;
								}
								else
								{
									flag2 = true;
								}
								inscriptionItemDatas.Add(itemData);
							}
						}
					}
				}
			}
			bool result;
			if (isQualityFive)
			{
				result = (flag && !flag2);
			}
			else
			{
				result = (flag && flag2);
			}
			return result;
		}

		// Token: 0x0601129A RID: 70298 RVA: 0x004EE6E8 File Offset: 0x004ECAE8
		public string GetInscriptionHoleName(int id)
		{
			string result = string.Empty;
			if (id == 800)
			{
				result = TR.Value("Inscription_Hole_Red");
			}
			else if (id == 801)
			{
				result = TR.Value("Inscription_Hole_Yellow");
			}
			else if (id == 802)
			{
				result = TR.Value("Inscription_Hole_Blue");
			}
			else if (id == 803)
			{
				result = TR.Value("Inscription_Hole_DarkGold");
			}
			else if (id == 804)
			{
				result = TR.Value("Inscription_Hole_YaoGolden");
			}
			else if (id == 805)
			{
				result = TR.Value("Inscription_Hole_Orange");
			}
			else if (id == 806)
			{
				result = TR.Value("Inscription_Hole_Green");
			}
			else if (id == 807)
			{
				result = TR.Value("Inscription_Hole_Purple");
			}
			return result;
		}

		// Token: 0x0601129B RID: 70299 RVA: 0x004EE7D0 File Offset: 0x004ECBD0
		private void InitInscriptionSynthesisTable()
		{
			this.mInscriptionSysnthesisDataList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<InscriptionSynthesisTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					InscriptionSynthesisTable inscriptionSynthesisTable = keyValuePair.Value as InscriptionSynthesisTable;
					if (inscriptionSynthesisTable != null)
					{
						InscriptionSysnthesisData inscriptionSysnthesisData = new InscriptionSysnthesisData();
						inscriptionSysnthesisData.quality = (int)inscriptionSynthesisTable.Color;
						inscriptionSysnthesisData.sysnthesisNumber = inscriptionSynthesisTable.SynthesisNum;
						inscriptionSysnthesisData.isMaxSynthesisNum = (inscriptionSynthesisTable.IsMaxSynthesisNum == 1);
						inscriptionSysnthesisData.canBeObtainedInscriptionItemDataList = this.GetCanBeObtainedInscriptionItemDataList(inscriptionSynthesisTable.GenerateInscriptionPreView);
						this.mInscriptionSysnthesisDataList.Add(inscriptionSysnthesisData);
					}
				}
			}
		}

		// Token: 0x0601129C RID: 70300 RVA: 0x004EE884 File Offset: 0x004ECC84
		private List<CanBeObtainedInscriptionItemData> GetCanBeObtainedInscriptionItemDataList(string str)
		{
			List<CanBeObtainedInscriptionItemData> list = new List<CanBeObtainedInscriptionItemData>();
			string[] array = str.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2 != null && array2.Length >= 2)
				{
					int tableId = 0;
					int probability = 0;
					int.TryParse(array2[0], out tableId);
					int.TryParse(array2[1], out probability);
					list.Add(new CanBeObtainedInscriptionItemData
					{
						inscriptionItemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0),
						probability = probability
					});
				}
			}
			return list;
		}

		// Token: 0x0601129D RID: 70301 RVA: 0x004EE928 File Offset: 0x004ECD28
		public int GetMaxInscriptionSynthesisNum(int color)
		{
			int result = 0;
			for (int i = 0; i < this.mInscriptionSysnthesisDataList.Count; i++)
			{
				InscriptionSysnthesisData inscriptionSysnthesisData = this.mInscriptionSysnthesisDataList[i];
				if (inscriptionSysnthesisData.quality == color)
				{
					if (inscriptionSysnthesisData.isMaxSynthesisNum)
					{
						result = inscriptionSysnthesisData.sysnthesisNumber;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0601129E RID: 70302 RVA: 0x004EE990 File Offset: 0x004ECD90
		public List<CanBeObtainedInscriptionItemData> GetCanBeObtainedInscriptionItemData(int color, int putInInscriptionNumber)
		{
			List<CanBeObtainedInscriptionItemData> list = new List<CanBeObtainedInscriptionItemData>();
			for (int i = 0; i < this.mInscriptionSysnthesisDataList.Count; i++)
			{
				InscriptionSysnthesisData inscriptionSysnthesisData = this.mInscriptionSysnthesisDataList[i];
				if (inscriptionSysnthesisData.quality == color)
				{
					if (putInInscriptionNumber == inscriptionSysnthesisData.sysnthesisNumber)
					{
						list = inscriptionSysnthesisData.canBeObtainedInscriptionItemDataList;
						list.Sort();
						break;
					}
				}
			}
			return list;
		}

		// Token: 0x0601129F RID: 70303 RVA: 0x004EEA04 File Offset: 0x004ECE04
		public List<ComControlData> GetInscriptionQualityTabDataList()
		{
			List<ComControlData> list = new List<ComControlData>();
			for (int i = 0; i <= 6; i++)
			{
				if (i != 4)
				{
					int num = i;
					string name = TR.Value(string.Format("Inscription_Compose_Quailty_Desc_{0}", num));
					InscriptionQualityTabData item = new InscriptionQualityTabData(num, num, name, num == 0);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060112A0 RID: 70304 RVA: 0x004EEA64 File Offset: 0x004ECE64
		public List<ComControlData> GetInscriptionThirdTypeTabDataList()
		{
			List<ComControlData> list = new List<ComControlData>();
			InscriptionThirdTypeTabData item = new InscriptionThirdTypeTabData(0, 0, TR.Value("Inscription_Compose_ThirdType_Desc_0"), true);
			list.Add(item);
			for (int i = 800; i <= 807; i++)
			{
				int num = i;
				string name = TR.Value(string.Format("Inscription_Compose_ThirdType_Desc_{0}", num));
				InscriptionThirdTypeTabData item2 = new InscriptionThirdTypeTabData(num, num, name, false);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x060112A1 RID: 70305 RVA: 0x004EEADC File Offset: 0x004ECEDC
		private int Sort(ItemData x, ItemData y)
		{
			if (x.Quality != y.Quality)
			{
				return y.Quality - x.Quality;
			}
			if (x.ThirdType != y.ThirdType)
			{
				return x.ThirdType - y.ThirdType;
			}
			return x.TableID - y.TableID;
		}

		// Token: 0x0400B126 RID: 45350
		private List<ItemData> mInscriptionAllEquipment = new List<ItemData>();

		// Token: 0x0400B127 RID: 45351
		private List<EquipInscriptionHoleData> mOpenInscriptionHoleConsumeList = new List<EquipInscriptionHoleData>();

		// Token: 0x0400B128 RID: 45352
		private List<InscriptionExtractData> mInscriptionExtractDataList = new List<InscriptionExtractData>();

		// Token: 0x0400B129 RID: 45353
		private List<InscriptionExtractData> mInscriptionFractureDataList = new List<InscriptionExtractData>();

		// Token: 0x0400B12A RID: 45354
		private List<InscriptionProbabilityData> mInscriptionProbabilityDataList = new List<InscriptionProbabilityData>();

		// Token: 0x0400B12B RID: 45355
		private List<InscriptionSysnthesisData> mInscriptionSysnthesisDataList = new List<InscriptionSysnthesisData>();

		// Token: 0x0400B12C RID: 45356
		public static bool IncriptionSynthesisHightQualityBounced;

		// Token: 0x0400B12D RID: 45357
		public static bool InscriptionMosiacBounced;
	}
}
