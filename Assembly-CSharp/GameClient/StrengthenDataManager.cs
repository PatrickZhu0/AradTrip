using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BB2 RID: 7090
	internal class StrengthenDataManager : DataManager<StrengthenDataManager>
	{
		// Token: 0x060115AE RID: 71086 RVA: 0x0050564B File Offset: 0x00503A4B
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.StrengthenDataManager;
		}

		// Token: 0x060115AF RID: 71087 RVA: 0x00505650 File Offset: 0x00503A50
		public override void Initialize()
		{
			this.m_bIsStrenghtenContinue = false;
			if (!this.m_bInited)
			{
				this.m_iMaxIndex = 0;
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipStrengthenTable>();
				if (table != null && table.Count >= 1)
				{
					this.m_iMaxIndex = table.Count / 20 + ((table.Count % 20 != 0) ? 1 : 0);
					this.m_arrStrengthenCost = new StrengthenDataManager.CostData[20, this.m_iMaxIndex];
				}
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					EquipStrengthenTable equipStrengthenTable = keyValuePair.Value as EquipStrengthenTable;
					StrengthenDataManager.CostData costData = new StrengthenDataManager.CostData();
					costData.EquipLevelMin = equipStrengthenTable.Lv[0];
					costData.EquipLevelMax = ((equipStrengthenTable.Lv.Count <= 1) ? equipStrengthenTable.Lv[0] : equipStrengthenTable.Lv[1]);
					try
					{
						costData.Costs[0] = new StrengthenCost(equipStrengthenTable.WhiteGoldCost, equipStrengthenTable.WhiteCost[0], equipStrengthenTable.WhiteCost[1]);
						costData.Costs[1] = new StrengthenCost(equipStrengthenTable.BlueGoldCost, equipStrengthenTable.BlueCost[0], equipStrengthenTable.BlueCost[1]);
						costData.Costs[2] = new StrengthenCost(equipStrengthenTable.PurpleGoldCost, equipStrengthenTable.PurpleCost[0], equipStrengthenTable.PurpleCost[1]);
						costData.Costs[3] = new StrengthenCost(equipStrengthenTable.GreenGoldCost, equipStrengthenTable.GreenCost[0], equipStrengthenTable.GreenCost[1]);
						costData.Costs[4] = new StrengthenCost(equipStrengthenTable.PinkGoldCost, equipStrengthenTable.PinkCost[0], equipStrengthenTable.PinkCost[1]);
						costData.Costs[5] = new StrengthenCost(equipStrengthenTable.YellowGoldCost, equipStrengthenTable.YellowCost[0], equipStrengthenTable.YellowCost[1]);
						this.m_arrStrengthenCost[equipStrengthenTable.Strengthen, (equipStrengthenTable.ID - 1) / 20] = costData;
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("data.WhiteCost.Length = {0}", new object[]
						{
							equipStrengthenTable.WhiteCost.Count
						});
						Logger.LogErrorFormat("data.Strengthen = {0},data.ID = {1},(data.ID - 1) / 20 = {2} costData.min = {3} costData.max = {4}", new object[]
						{
							equipStrengthenTable.Strengthen,
							equipStrengthenTable.ID,
							(equipStrengthenTable.ID - 1) / 20,
							costData.EquipLevelMin,
							costData.EquipLevelMax
						});
					}
				}
				this.m_bInited = true;
			}
			this.InitAssistEqStrengFouerDimAddTable();
		}

		// Token: 0x060115B0 RID: 71088 RVA: 0x00505958 File Offset: 0x00503D58
		public override void Clear()
		{
			if (this.mAuxiliaryEquipmentStrengthenAttrDataList != null)
			{
				this.mAuxiliaryEquipmentStrengthenAttrDataList.Clear();
			}
			this.IsEquipStrengthened = false;
			this.IsEquipmentStrengthBroken = false;
		}

		// Token: 0x060115B1 RID: 71089 RVA: 0x00505980 File Offset: 0x00503D80
		public float GetAssistEqStrengthAttrValue(ItemData itemData, int strengthenLevel)
		{
			if (itemData == null)
			{
				return 0f;
			}
			for (int i = 0; i < this.mAuxiliaryEquipmentStrengthenAttrDataList.Count; i++)
			{
				AuxiliaryEquipmentStrengthenAttrData auxiliaryEquipmentStrengthenAttrData = this.mAuxiliaryEquipmentStrengthenAttrDataList[i];
				if (strengthenLevel == auxiliaryEquipmentStrengthenAttrData.strengthenLevel)
				{
					if (itemData.LevelLimit == auxiliaryEquipmentStrengthenAttrData.equipLevel)
					{
						if (itemData.Quality == (ItemTable.eColor)auxiliaryEquipmentStrengthenAttrData.quality)
						{
							if (itemData.TableData.Color2 == auxiliaryEquipmentStrengthenAttrData.quality2)
							{
								return auxiliaryEquipmentStrengthenAttrData.attrValue / 1000f;
							}
						}
					}
				}
			}
			return 0f;
		}

		// Token: 0x060115B2 RID: 71090 RVA: 0x00505A2C File Offset: 0x00503E2C
		private void InitAssistEqStrengFouerDimAddTable()
		{
			if (this.mAuxiliaryEquipmentStrengthenAttrDataList == null)
			{
				this.mAuxiliaryEquipmentStrengthenAttrDataList = new List<AuxiliaryEquipmentStrengthenAttrData>();
			}
			else
			{
				this.mAuxiliaryEquipmentStrengthenAttrDataList.Clear();
			}
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<AssistEqStrengFouerDimAddTable>())
			{
				AssistEqStrengFouerDimAddTable assistEqStrengFouerDimAddTable = keyValuePair.Value as AssistEqStrengFouerDimAddTable;
				if (assistEqStrengFouerDimAddTable != null)
				{
					AuxiliaryEquipmentStrengthenAttrData auxiliaryEquipmentStrengthenAttrData = new AuxiliaryEquipmentStrengthenAttrData();
					auxiliaryEquipmentStrengthenAttrData.strengthenLevel = assistEqStrengFouerDimAddTable.Strengthen;
					auxiliaryEquipmentStrengthenAttrData.equipLevel = assistEqStrengFouerDimAddTable.Lv;
					auxiliaryEquipmentStrengthenAttrData.quality = (int)assistEqStrengFouerDimAddTable.Color;
					auxiliaryEquipmentStrengthenAttrData.quality2 = assistEqStrengFouerDimAddTable.Color2;
					auxiliaryEquipmentStrengthenAttrData.attrValue = (float)assistEqStrengFouerDimAddTable.StrengNum;
					this.mAuxiliaryEquipmentStrengthenAttrDataList.Add(auxiliaryEquipmentStrengthenAttrData);
				}
			}
		}

		// Token: 0x060115B3 RID: 71091 RVA: 0x00505AF0 File Offset: 0x00503EF0
		public bool GetCost(int strengthenLevel, int equipLevel, ItemTable.eColor equipQuality, ref StrengthenCost result)
		{
			if (strengthenLevel >= 0 && strengthenLevel < 20)
			{
				for (int i = 0; i < this.m_iMaxIndex; i++)
				{
					StrengthenDataManager.CostData costData = this.m_arrStrengthenCost[strengthenLevel, i];
					if (equipLevel >= costData.EquipLevelMin && equipLevel <= costData.EquipLevelMax)
					{
						result = costData.Costs[equipQuality - ItemTable.eColor.WHITE];
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060115B4 RID: 71092 RVA: 0x00505B68 File Offset: 0x00503F68
		public void StrengthenItem(ItemData data, byte useUnbreak, ulong ticketid = 0UL)
		{
			SceneEquipStrengthen sceneEquipStrengthen = new SceneEquipStrengthen();
			sceneEquipStrengthen.euqipUid = data.GUID;
			sceneEquipStrengthen.strTickt = ticketid;
			sceneEquipStrengthen.useUnbreak = useUnbreak;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneEquipStrengthen>(ServerType.GATE_SERVER, sceneEquipStrengthen);
			int iOrgStrengthenLevel = data.StrengthenLevel + 1;
			int[] aiOrgAttr;
			if (data.IsAssistEquip())
			{
				aiOrgAttr = new int[]
				{
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
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate)),
					Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate))
				};
			}
			this.IsEquipStrengthened = true;
			DataManager<WaitNetMessageManager>.GetInstance().Wait(500921U, delegate(MsgDATA msgData)
			{
				int num = 0;
				CustomDecoder.StrengthenRet strengthenRet;
				CustomDecoder.DecodeStrengthenResult(out strengthenRet, msgData.bytes, ref num, msgData.bytes.Length);
				if (strengthenRet.code == 1000016U)
				{
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventID = EUIEventID.ItemStrengthenFail;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = false;
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.m_strengthenResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int i = 0; i < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; i++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[i] = aiOrgAttr[i];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int j = 0; j < this.m_strengthenResult.orgAttr.Length; j++)
						{
							this.m_strengthenResult.orgAttr[j] = aiOrgAttr[j];
						}
						this.m_strengthenResult.curAttr[0] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.m_strengthenResult.curAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.m_strengthenResult.curAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.m_strengthenResult.curAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.m_strengthenResult.curAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.m_strengthenResult.curAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.m_strengthenResult.curAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				}
				else if (strengthenRet.code == 1000048U)
				{
					UIEvent idleUIEvent2 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent2.EventID = EUIEventID.OnSpecailStrenghthenFailed;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = false;
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.m_strengthenResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int k = 0; k < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; k++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[k] = aiOrgAttr[k];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int l = 0; l < this.m_strengthenResult.orgAttr.Length; l++)
						{
							this.m_strengthenResult.orgAttr[l] = aiOrgAttr[l];
						}
						this.m_strengthenResult.curAttr[0] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.m_strengthenResult.curAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.m_strengthenResult.curAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.m_strengthenResult.curAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.m_strengthenResult.curAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.m_strengthenResult.curAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.m_strengthenResult.curAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent2);
				}
				else if (strengthenRet.code == 1000017U)
				{
					UIEvent idleUIEvent3 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent3.EventID = EUIEventID.ItemStrengthenFail;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = false;
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.m_strengthenResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int m = 0; m < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; m++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[m] = aiOrgAttr[m];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int n = 0; n < this.m_strengthenResult.orgAttr.Length; n++)
						{
							this.m_strengthenResult.orgAttr[n] = aiOrgAttr[n];
						}
						this.m_strengthenResult.curAttr[0] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.m_strengthenResult.curAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.m_strengthenResult.curAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.m_strengthenResult.curAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.m_strengthenResult.curAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.m_strengthenResult.curAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.m_strengthenResult.curAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent3);
				}
				else if (strengthenRet.code == 1000018U)
				{
					UIEvent idleUIEvent4 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent4.EventID = EUIEventID.ItemStrengthenFail;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = false;
					this.m_strengthenResult.BrokenItems = new List<ItemData>();
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.m_strengthenResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int num2 = 0; num2 < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; num2++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[num2] = aiOrgAttr[num2];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int num3 = 0; num3 < this.m_strengthenResult.orgAttr.Length; num3++)
						{
							this.m_strengthenResult.orgAttr[num3] = aiOrgAttr[num3];
						}
						this.m_strengthenResult.curAttr[0] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.m_strengthenResult.curAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.m_strengthenResult.curAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.m_strengthenResult.curAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.m_strengthenResult.curAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.m_strengthenResult.curAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.m_strengthenResult.curAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
					}
					for (int num4 = 0; num4 < strengthenRet.BrokenItems.Count; num4++)
					{
						CustomDecoder.RewardItem rewardItem = strengthenRet.BrokenItems[num4];
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)rewardItem.ID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = (int)rewardItem.Num;
							this.m_strengthenResult.BrokenItems.Add(itemData);
						}
						else
						{
							Logger.LogErrorFormat("强化结果返回，道具表id找不到 = {0}", new object[]
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
					idleUIEvent5.EventID = EUIEventID.ItemStrengthenFail;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = false;
					this.m_strengthenResult.BrokenItems = new List<ItemData>();
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = 0;
					this.m_strengthenResult.iTableID = data.TableID;
					for (int num5 = 0; num5 < strengthenRet.BrokenItems.Count; num5++)
					{
						CustomDecoder.RewardItem rewardItem2 = strengthenRet.BrokenItems[num5];
						ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)rewardItem2.ID, 100, 0);
						if (itemData2 != null)
						{
							itemData2.Count = (int)rewardItem2.Num;
							this.m_strengthenResult.BrokenItems.Add(itemData2);
						}
						else
						{
							Logger.LogErrorFormat("强化结果返回，道具表id找不到 = {0}", new object[]
							{
								rewardItem2.ID
							});
						}
					}
					if (data.IsAssistEquip())
					{
						for (int num6 = 0; num6 < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; num6++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[num6] = aiOrgAttr[num6];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = 0;
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = 0;
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = 0;
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = 0;
					}
					else
					{
						for (int num7 = 0; num7 < this.m_strengthenResult.orgAttr.Length; num7++)
						{
							this.m_strengthenResult.orgAttr[num7] = aiOrgAttr[num7];
						}
						this.m_strengthenResult.curAttr[0] = 0;
						this.m_strengthenResult.curAttr[1] = 0;
						this.m_strengthenResult.curAttr[2] = 0;
						this.m_strengthenResult.curAttr[3] = 0;
						this.m_strengthenResult.curAttr[4] = 0;
						this.m_strengthenResult.curAttr[5] = 0;
						this.m_strengthenResult.curAttr[6] = 0;
					}
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent5);
				}
				else if (strengthenRet.code == 0U)
				{
					UIEvent idleUIEvent6 = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent6.EventID = EUIEventID.ItemStrengthenSuccess;
					this.m_strengthenResult = new StrengthenResult();
					this.m_strengthenResult.StrengthenSuccess = true;
					this.m_strengthenResult.EquipData = data;
					this.m_strengthenResult.code = strengthenRet.code;
					this.m_strengthenResult.iStrengthenLevel = iOrgStrengthenLevel;
					this.m_strengthenResult.iTargetStrengthenLevel = data.StrengthenLevel;
					this.m_strengthenResult.iTableID = data.TableID;
					if (data.IsAssistEquip())
					{
						for (int num8 = 0; num8 < this.m_strengthenResult.assistEquipStrengthenOrgAttr.Length; num8++)
						{
							this.m_strengthenResult.assistEquipStrengthenOrgAttr[num8] = aiOrgAttr[num8];
						}
						this.m_strengthenResult.assistEquipStrengthenCurAttr[0] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[1] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[2] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
						this.m_strengthenResult.assistEquipStrengthenCurAttr[3] = Mathf.FloorToInt((float)data.GetBaseFourAttrStrengthenAddUpValue(data.StrengthenLevel));
					}
					else
					{
						for (int num9 = 0; num9 < this.m_strengthenResult.orgAttr.Length; num9++)
						{
							this.m_strengthenResult.orgAttr[num9] = aiOrgAttr[num9];
						}
						this.m_strengthenResult.curAttr[0] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsAttack));
						this.m_strengthenResult.curAttr[1] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicAttack));
						this.m_strengthenResult.curAttr[2] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IngoreIndependence));
						this.m_strengthenResult.curAttr[3] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefense));
						this.m_strengthenResult.curAttr[4] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefense));
						this.m_strengthenResult.curAttr[5] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnorePhysicsDefenseRate));
						this.m_strengthenResult.curAttr[6] = Mathf.FloorToInt(data._GetGetStrengthenDescs(EEquipProp.IgnoreMagicDefenseRate));
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

		// Token: 0x17001DA8 RID: 7592
		// (get) Token: 0x060115B5 RID: 71093 RVA: 0x00505D36 File Offset: 0x00504136
		// (set) Token: 0x060115B6 RID: 71094 RVA: 0x00505D3E File Offset: 0x0050413E
		public bool IsStrengthenContinue
		{
			get
			{
				return this.m_bIsStrenghtenContinue;
			}
			set
			{
				this.m_bIsStrenghtenContinue = value;
			}
		}

		// Token: 0x060115B7 RID: 71095 RVA: 0x00505D47 File Offset: 0x00504147
		public StrengthenResult GetStrengthenResult()
		{
			return this.m_strengthenResult;
		}

		// Token: 0x060115B8 RID: 71096 RVA: 0x00505D50 File Offset: 0x00504150
		public List<ItemData> GetStrengthenStampList(ItemData currentSelectItemData)
		{
			if (currentSelectItemData == null)
			{
				return new List<ItemData>();
			}
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.Coupon);
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
			list.Sort(new Comparison<ItemData>(this.StrengthenStampItemSort));
			itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.ST_STRENTH_LUCK);
			if (itemsByPackageSubType != null)
			{
				for (int j = 0; j < itemsByPackageSubType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[j]);
					if (item2 != null)
					{
						OneStrengEnhanceTicketTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<OneStrengEnhanceTicketTable>(item2.TableID, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							if (currentSelectItemData.StrengthenLevel >= tableItem3.LvLimitBegin && currentSelectItemData.StrengthenLevel <= tableItem3.LvLimitEnd)
							{
								list.Insert(0, item2);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060115B9 RID: 71097 RVA: 0x00505EE8 File Offset: 0x005042E8
		private int StrengthenStampItemSort(ItemData x, ItemData y)
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

		// Token: 0x060115BA RID: 71098 RVA: 0x00505FAC File Offset: 0x005043AC
		public List<ItemData> GetDisposableStrengItemList(ItemData currentSelectItemData)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageThirdType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageThirdType(EPackageType.Material, ItemTable.eThirdType.DisposableStrengItem);
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

		// Token: 0x0400B3FB RID: 46075
		private StrengthenDataManager.CostData[,] m_arrStrengthenCost;

		// Token: 0x0400B3FC RID: 46076
		private bool m_bInited;

		// Token: 0x0400B3FD RID: 46077
		private StrengthenResult m_strengthenResult;

		// Token: 0x0400B3FE RID: 46078
		private int m_iMaxIndex;

		// Token: 0x0400B3FF RID: 46079
		public bool IsEquipStrengthened;

		// Token: 0x0400B400 RID: 46080
		private List<AuxiliaryEquipmentStrengthenAttrData> mAuxiliaryEquipmentStrengthenAttrDataList = new List<AuxiliaryEquipmentStrengthenAttrData>();

		// Token: 0x0400B401 RID: 46081
		public bool IsEquipmentStrengthBroken;

		// Token: 0x0400B402 RID: 46082
		private bool m_bIsStrenghtenContinue;

		// Token: 0x02001BB3 RID: 7091
		private class CostData
		{
			// Token: 0x0400B403 RID: 46083
			public int EquipLevelMin;

			// Token: 0x0400B404 RID: 46084
			public int EquipLevelMax;

			// Token: 0x0400B405 RID: 46085
			public StrengthenCost[] Costs = new StrengthenCost[6];
		}
	}
}
