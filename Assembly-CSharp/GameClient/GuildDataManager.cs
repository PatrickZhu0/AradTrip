using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LitJson;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200126B RID: 4715
	internal class GuildDataManager : DataManager<GuildDataManager>
	{
		// Token: 0x0600B478 RID: 46200 RVA: 0x00285A48 File Offset: 0x00283E48
		public List<GuildDataManager.DungeonDamageRankInfo> GetDungeonRankInfoList()
		{
			return this.m_DungeonRankInfoList;
		}

		// Token: 0x17001AD2 RID: 6866
		// (get) Token: 0x0600B479 RID: 46201 RVA: 0x00285A50 File Offset: 0x00283E50
		// (set) Token: 0x0600B47A RID: 46202 RVA: 0x00285A58 File Offset: 0x00283E58
		public bool IsGuildAuctionOpen { get; private set; }

		// Token: 0x17001AD3 RID: 6867
		// (get) Token: 0x0600B47B RID: 46203 RVA: 0x00285A61 File Offset: 0x00283E61
		// (set) Token: 0x0600B47C RID: 46204 RVA: 0x00285A69 File Offset: 0x00283E69
		public bool IsGuildWorldAuctionOpen { get; private set; }

		// Token: 0x17001AD4 RID: 6868
		// (get) Token: 0x0600B47D RID: 46205 RVA: 0x00285A72 File Offset: 0x00283E72
		// (set) Token: 0x0600B47E RID: 46206 RVA: 0x00285A7A File Offset: 0x00283E7A
		public bool HaveNewWorldAuctonItem { get; set; }

		// Token: 0x17001AD5 RID: 6869
		// (get) Token: 0x0600B47F RID: 46207 RVA: 0x00285A83 File Offset: 0x00283E83
		// (set) Token: 0x0600B480 RID: 46208 RVA: 0x00285A8B File Offset: 0x00283E8B
		public bool HaveNewGuildAuctonItem { get; set; }

		// Token: 0x0600B481 RID: 46209 RVA: 0x00285A94 File Offset: 0x00283E94
		public List<GuildDataManager.GuildAuctionItemData> GetGuildAuctionItemDatasForGuildAuction()
		{
			return this.guildAuctionItemDatasForGuildAuction;
		}

		// Token: 0x0600B482 RID: 46210 RVA: 0x00285A9C File Offset: 0x00283E9C
		public List<GuildDataManager.GuildAuctionItemData> GetGuildAuctionItemDatasForWorldAuction()
		{
			return this.guildAuctionItemDatasForWorldAuction;
		}

		// Token: 0x0600B483 RID: 46211 RVA: 0x00285AA4 File Offset: 0x00283EA4
		public GuildDataManager.GuildDungeonActivityData GetGuildDungeonActivityData()
		{
			return this.m_GuildDungeonActivityData;
		}

		// Token: 0x0600B484 RID: 46212 RVA: 0x00285AAC File Offset: 0x00283EAC
		public GuildDataManager.DungeonDamageRankInfo GetMyDungeonDamageRankInfo()
		{
			return this.m_MyDungeonDamageRankInfo;
		}

		// Token: 0x17001AD6 RID: 6870
		// (get) Token: 0x0600B485 RID: 46213 RVA: 0x00285AB4 File Offset: 0x00283EB4
		// (set) Token: 0x0600B486 RID: 46214 RVA: 0x00285ABC File Offset: 0x00283EBC
		public GuildMyData myGuild { get; private set; }

		// Token: 0x17001AD7 RID: 6871
		// (get) Token: 0x0600B487 RID: 46215 RVA: 0x00285AC5 File Offset: 0x00283EC5
		// (set) Token: 0x0600B488 RID: 46216 RVA: 0x00285ACD File Offset: 0x00283ECD
		public int donatePointCost { get; private set; }

		// Token: 0x17001AD8 RID: 6872
		// (get) Token: 0x0600B489 RID: 46217 RVA: 0x00285AD6 File Offset: 0x00283ED6
		// (set) Token: 0x0600B48A RID: 46218 RVA: 0x00285ADE File Offset: 0x00283EDE
		public int donateGoldCost { get; private set; }

		// Token: 0x17001AD9 RID: 6873
		// (get) Token: 0x0600B48B RID: 46219 RVA: 0x00285AE7 File Offset: 0x00283EE7
		// (set) Token: 0x0600B48C RID: 46220 RVA: 0x00285AEF File Offset: 0x00283EEF
		public int donatePointGet { get; private set; }

		// Token: 0x17001ADA RID: 6874
		// (get) Token: 0x0600B48D RID: 46221 RVA: 0x00285AF8 File Offset: 0x00283EF8
		// (set) Token: 0x0600B48E RID: 46222 RVA: 0x00285B00 File Offset: 0x00283F00
		public int donateGoldGet { get; private set; }

		// Token: 0x17001ADB RID: 6875
		// (get) Token: 0x0600B48F RID: 46223 RVA: 0x00285B09 File Offset: 0x00283F09
		// (set) Token: 0x0600B490 RID: 46224 RVA: 0x00285B11 File Offset: 0x00283F11
		public int exchangeCost { get; private set; }

		// Token: 0x17001ADC RID: 6876
		// (get) Token: 0x0600B491 RID: 46225 RVA: 0x00285B1A File Offset: 0x00283F1A
		// (set) Token: 0x0600B492 RID: 46226 RVA: 0x00285B22 File Offset: 0x00283F22
		public bool canJoinAllGuild { get; private set; }

		// Token: 0x0600B493 RID: 46227 RVA: 0x00285B2B File Offset: 0x00283F2B
		public int GetEmblemSkillID()
		{
			return this.nEmblemSkillID;
		}

		// Token: 0x0600B494 RID: 46228 RVA: 0x00285B34 File Offset: 0x00283F34
		public int GetEmblemLv()
		{
			GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
			if (myGuild == null)
			{
				return -1;
			}
			return (int)myGuild.emblemLevel;
		}

		// Token: 0x0600B495 RID: 46229 RVA: 0x00285B5C File Offset: 0x00283F5C
		public int GetGuildDungeonDiffType()
		{
			GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
			if (myGuild == null)
			{
				return 0;
			}
			return (int)myGuild.dungeonType;
		}

		// Token: 0x0600B496 RID: 46230 RVA: 0x00285B84 File Offset: 0x00283F84
		public string GetEmblemNamePath(int iEmblemLv)
		{
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(iEmblemLv, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.namePath;
			}
			return string.Empty;
		}

		// Token: 0x0600B497 RID: 46231 RVA: 0x00285BBC File Offset: 0x00283FBC
		public string GetEmblemIconPath(int iEmblemLv)
		{
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(iEmblemLv, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.iconPath;
			}
			return string.Empty;
		}

		// Token: 0x0600B498 RID: 46232 RVA: 0x00285BF1 File Offset: 0x00283FF1
		public int GetMaxEmblemLv()
		{
			return this.nMaxEmblemLv;
		}

		// Token: 0x0600B499 RID: 46233 RVA: 0x00285BFC File Offset: 0x00283FFC
		public int GetEmblemLvUpGuildLvLimit()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(557, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.Value;
		}

		// Token: 0x0600B49A RID: 46234 RVA: 0x00285C34 File Offset: 0x00284034
		public int GetEmblemLvUpPlayerLvLimit()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(556, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.Value;
		}

		// Token: 0x0600B49B RID: 46235 RVA: 0x00285C6C File Offset: 0x0028406C
		public int GetEmblemLvUpHonourLvLimit()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(558, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.Value;
		}

		// Token: 0x0600B49C RID: 46236 RVA: 0x00285CA4 File Offset: 0x002840A4
		public void GetEmblemLvUpCost(int iEmblemLv, ref int[] itemIDs, ref int[] itemNums)
		{
			if (iEmblemLv <= 0 || iEmblemLv > this.GetMaxEmblemLv())
			{
				return;
			}
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(iEmblemLv, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			itemIDs = new int[tableItem.costIdLength];
			itemNums = new int[tableItem.costNumLength];
			if (itemIDs == null || itemNums == null)
			{
				return;
			}
			for (int i = 0; i < itemIDs.Length; i++)
			{
				itemIDs[i] = tableItem.costId[i];
			}
			for (int j = 0; j < itemNums.Length; j++)
			{
				itemNums[j] = tableItem.costNum[j];
			}
		}

		// Token: 0x0600B49D RID: 46237 RVA: 0x00285D58 File Offset: 0x00284158
		public bool IsCostEnoughToLvUpEmblem(ref List<int> notEnoughItemIDs)
		{
			int[] array = null;
			int[] array2 = null;
			notEnoughItemIDs = new List<int>();
			if (notEnoughItemIDs == null)
			{
				return false;
			}
			int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
			DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpCost(emblemLv + 1, ref array, ref array2);
			if (array == null || array2 == null)
			{
				return false;
			}
			int num = Math.Min(array.Length, array2.Length);
			for (int i = 0; i < num; i++)
			{
				if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(array[i], true) < array2[i])
				{
					notEnoughItemIDs.Add(array[i]);
				}
			}
			return notEnoughItemIDs.Count == 0;
		}

		// Token: 0x0600B49E RID: 46238 RVA: 0x00285DF4 File Offset: 0x002841F4
		public int GetEmblemNeedHonourLv(int nEmblemLv)
		{
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(nEmblemLv, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.needHonourLevel;
		}

		// Token: 0x17001ADD RID: 6877
		// (get) Token: 0x0600B49F RID: 46239 RVA: 0x00285E25 File Offset: 0x00284225
		// (set) Token: 0x0600B4A0 RID: 46240 RVA: 0x00285E2D File Offset: 0x0028422D
		public int winPower { get; private set; }

		// Token: 0x17001ADE RID: 6878
		// (get) Token: 0x0600B4A1 RID: 46241 RVA: 0x00285E36 File Offset: 0x00284236
		// (set) Token: 0x0600B4A2 RID: 46242 RVA: 0x00285E3E File Offset: 0x0028423E
		public int losePower { get; private set; }

		// Token: 0x17001ADF RID: 6879
		// (get) Token: 0x0600B4A3 RID: 46243 RVA: 0x00285E47 File Offset: 0x00284247
		// (set) Token: 0x0600B4A4 RID: 46244 RVA: 0x00285E4F File Offset: 0x0028424F
		public GuildPost contributePower { get; private set; }

		// Token: 0x17001AE0 RID: 6880
		// (get) Token: 0x0600B4A5 RID: 46245 RVA: 0x00285E58 File Offset: 0x00284258
		// (set) Token: 0x0600B4A6 RID: 46246 RVA: 0x00285E60 File Offset: 0x00284260
		public GuildPost clearPower { get; private set; }

		// Token: 0x0600B4A7 RID: 46247 RVA: 0x00285E6C File Offset: 0x0028426C
		public void SendChangeGuildSettingPower(PowerSettingType ePowerSettingType, int iPowerValue)
		{
			if (ePowerSettingType > PowerSettingType.PST_INVALID && ePowerSettingType < PowerSettingType.PST_COUNT)
			{
				switch (ePowerSettingType)
				{
				case PowerSettingType.PST_WIN_POWER:
				{
					WorldGuildStorageSettingReq worldGuildStorageSettingReq = new WorldGuildStorageSettingReq();
					worldGuildStorageSettingReq.type = 1;
					worldGuildStorageSettingReq.value = (uint)iPowerValue;
					NetManager.Instance().SendCommand<WorldGuildStorageSettingReq>(ServerType.GATE_SERVER, worldGuildStorageSettingReq);
					break;
				}
				case PowerSettingType.PST_LOSE_POWER:
				{
					WorldGuildStorageSettingReq worldGuildStorageSettingReq2 = new WorldGuildStorageSettingReq();
					worldGuildStorageSettingReq2.type = 2;
					worldGuildStorageSettingReq2.value = (uint)iPowerValue;
					NetManager.Instance().SendCommand<WorldGuildStorageSettingReq>(ServerType.GATE_SERVER, worldGuildStorageSettingReq2);
					break;
				}
				case PowerSettingType.PST_CONTRIBUTE_POWER:
				{
					WorldGuildStorageSettingReq worldGuildStorageSettingReq3 = new WorldGuildStorageSettingReq();
					worldGuildStorageSettingReq3.type = 3;
					worldGuildStorageSettingReq3.value = (uint)iPowerValue;
					NetManager.Instance().SendCommand<WorldGuildStorageSettingReq>(ServerType.GATE_SERVER, worldGuildStorageSettingReq3);
					break;
				}
				case PowerSettingType.PST_DELETE_POWER:
				{
					WorldGuildStorageSettingReq worldGuildStorageSettingReq4 = new WorldGuildStorageSettingReq();
					worldGuildStorageSettingReq4.type = 4;
					worldGuildStorageSettingReq4.value = (uint)iPowerValue;
					NetManager.Instance().SendCommand<WorldGuildStorageSettingReq>(ServerType.GATE_SERVER, worldGuildStorageSettingReq4);
					break;
				}
				}
			}
			else
			{
				Logger.LogErrorFormat("setting ePowerSettingType = {0} ERROR!!!!!", new object[]
				{
					ePowerSettingType
				});
			}
		}

		// Token: 0x0600B4A8 RID: 46248 RVA: 0x00285F58 File Offset: 0x00284358
		private void _OnRecvWorldGuildStorageSettingRes(MsgDATA msgData)
		{
			WorldGuildStorageSettingRes worldGuildStorageSettingRes = new WorldGuildStorageSettingRes();
			worldGuildStorageSettingRes.decode(msgData.bytes);
			if (worldGuildStorageSettingRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildStorageSettingRes.result, string.Empty);
			}
		}

		// Token: 0x0600B4A9 RID: 46249 RVA: 0x00285F94 File Offset: 0x00284394
		private void _OnStorageSettingSync(GuildStorageSetting eSetting, int iPowerValue)
		{
			PowerSettingType powerSettingType = PowerSettingType.PST_COUNT;
			switch (eSetting)
			{
			case GuildStorageSetting.GSS_WIN_PROBABILITY:
				powerSettingType = PowerSettingType.PST_WIN_POWER;
				this.winPower = iPowerValue;
				break;
			case GuildStorageSetting.GSS_LOSE_PROBABILITY:
				powerSettingType = PowerSettingType.PST_LOSE_POWER;
				this.losePower = iPowerValue;
				break;
			case GuildStorageSetting.GSS_STORAGE_ADD_POST:
				powerSettingType = PowerSettingType.PST_CONTRIBUTE_POWER;
				this.contributePower = (GuildPost)iPowerValue;
				break;
			case GuildStorageSetting.GSS_STORAGE_DEL_POST:
				powerSettingType = PowerSettingType.PST_DELETE_POWER;
				this.clearPower = (GuildPost)iPowerValue;
				break;
			}
			if (powerSettingType != PowerSettingType.PST_COUNT && this.onGuildPowerChanged != null)
			{
				this.onGuildPowerChanged(powerSettingType, iPowerValue);
			}
		}

		// Token: 0x17001AE1 RID: 6881
		// (get) Token: 0x0600B4AA RID: 46250 RVA: 0x00286017 File Offset: 0x00284417
		// (set) Token: 0x0600B4AB RID: 46251 RVA: 0x0028601F File Offset: 0x0028441F
		public bool queried { get; set; }

		// Token: 0x17001AE2 RID: 6882
		// (get) Token: 0x0600B4AC RID: 46252 RVA: 0x00286028 File Offset: 0x00284428
		public List<ItemData> storeDatas
		{
			get
			{
				return this.storageDatas;
			}
		}

		// Token: 0x17001AE3 RID: 6883
		// (get) Token: 0x0600B4AD RID: 46253 RVA: 0x00286030 File Offset: 0x00284430
		// (set) Token: 0x0600B4AE RID: 46254 RVA: 0x00286038 File Offset: 0x00284438
		public int storeageCapacity { get; set; }

		// Token: 0x0600B4AF RID: 46255 RVA: 0x00286044 File Offset: 0x00284444
		public int translateWinPowerIndex(int iPowerValue)
		{
			int result = -1;
			for (int i = 0; i < GuildDataManager.winPowerSetting.Count; i++)
			{
				if (GuildDataManager.winPowerSetting[i] == iPowerValue)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600B4B0 RID: 46256 RVA: 0x00286088 File Offset: 0x00284488
		public int translateLosePowerIndex(int iPowerValue)
		{
			int result = -1;
			for (int i = 0; i < GuildDataManager.losePowerSetting.Count; i++)
			{
				if (GuildDataManager.losePowerSetting[i] == iPowerValue)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600B4B1 RID: 46257 RVA: 0x002860CB File Offset: 0x002844CB
		public static int getWinPowerByIndex(int iIndex)
		{
			if (iIndex >= 0 && iIndex < GuildDataManager.winPowerSetting.Count)
			{
				return GuildDataManager.winPowerSetting[iIndex];
			}
			return GuildDataManager.winPowerSetting[0];
		}

		// Token: 0x0600B4B2 RID: 46258 RVA: 0x002860FB File Offset: 0x002844FB
		public static int getLosePowerByIndex(int iIndex)
		{
			if (iIndex >= 0 && iIndex < GuildDataManager.losePowerSetting.Count)
			{
				return GuildDataManager.losePowerSetting[iIndex];
			}
			return GuildDataManager.losePowerSetting[0];
		}

		// Token: 0x0600B4B3 RID: 46259 RVA: 0x0028612C File Offset: 0x0028452C
		private void _OnSorageItemUpdated(MsgDATA msgData)
		{
			WorldGuildStorageItemSync worldGuildStorageItemSync = new WorldGuildStorageItemSync();
			worldGuildStorageItemSync.decode(msgData.bytes);
			for (int i = 0; i < worldGuildStorageItemSync.records.Length; i++)
			{
				this.AddRecord(worldGuildStorageItemSync.records[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildSotrageOperationRecordsChanged, null, null, null, null);
			for (int j = 0; j < worldGuildStorageItemSync.items.Length; j++)
			{
				GuildStorageItemInfo item = worldGuildStorageItemSync.items[j];
				ItemData itemData = this.storageDatas.Find((ItemData x) => x.GUID == item.uid);
				if (itemData == null)
				{
					if (item.num > 0)
					{
						ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)item.dataId, 100, 0);
						if (itemData2 != null)
						{
							itemData2.Count = (int)item.num;
							itemData2.GUID = item.uid;
							itemData2.StrengthenLevel = (int)item.str;
							itemData2.EquipType = (EEquipType)item.equipType;
							this.storageDatas.Add(itemData2);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildHouseItemAdd, itemData2, null, null, null);
						}
					}
				}
				else if (item.num == 0)
				{
					this.storageDatas.Remove(itemData);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildHouseItemRemoved, itemData, null, null, null);
				}
				else
				{
					itemData.Count = (int)item.num;
					itemData.StrengthenLevel = (int)item.str;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildHouseItemUpdate, itemData, null, null, null);
				}
			}
		}

		// Token: 0x0600B4B4 RID: 46260 RVA: 0x002862DC File Offset: 0x002846DC
		public void SendStoreItems(GuildStorageItemInfo[] items)
		{
			if (items != null && items.Length > 0)
			{
				WorldGuildAddStorageReq worldGuildAddStorageReq = new WorldGuildAddStorageReq();
				worldGuildAddStorageReq.items = items;
				NetManager.Instance().SendCommand<WorldGuildAddStorageReq>(ServerType.GATE_SERVER, worldGuildAddStorageReq);
			}
		}

		// Token: 0x0600B4B5 RID: 46261 RVA: 0x00286314 File Offset: 0x00284714
		private void _OnRecvWorldGuildAddStorageRes(MsgDATA msgData)
		{
			WorldGuildAddStorageRes worldGuildAddStorageRes = new WorldGuildAddStorageRes();
			worldGuildAddStorageRes.decode(msgData.bytes);
			if (worldGuildAddStorageRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildAddStorageRes.result, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_item_add_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildHouseItemStoreRet, null, null, null, null);
		}

		// Token: 0x0600B4B6 RID: 46262 RVA: 0x00286378 File Offset: 0x00284778
		public void SendDeleteStorageItems(GuildStorageDelItemInfo[] items)
		{
			if (items != null && items.Length > 0)
			{
				WorldGuildDelStorageReq worldGuildDelStorageReq = new WorldGuildDelStorageReq();
				worldGuildDelStorageReq.items = items;
				NetManager.Instance().SendCommand<WorldGuildDelStorageReq>(ServerType.GATE_SERVER, worldGuildDelStorageReq);
			}
		}

		// Token: 0x0600B4B7 RID: 46263 RVA: 0x002863B0 File Offset: 0x002847B0
		private void _OnRecvWorldGuildDelStorageRes(MsgDATA msgData)
		{
			WorldGuildDelStorageRes worldGuildDelStorageRes = new WorldGuildDelStorageRes();
			worldGuildDelStorageRes.decode(msgData.bytes);
			if (worldGuildDelStorageRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildDelStorageRes.result, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_item_clear_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildHouseItemDeleteRet, null, null, null, null);
		}

		// Token: 0x17001AE4 RID: 6884
		// (get) Token: 0x0600B4B8 RID: 46264 RVA: 0x00286412 File Offset: 0x00284812
		// (set) Token: 0x0600B4B9 RID: 46265 RVA: 0x0028641A File Offset: 0x0028481A
		public List<object> GuildStorageOperationRecords
		{
			get
			{
				return this.records;
			}
			private set
			{
				this.records = value;
			}
		}

		// Token: 0x0600B4BA RID: 46266 RVA: 0x00286423 File Offset: 0x00284823
		private void _OnRecordsChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildSotrageOperationRecordsChanged, null, null, null, null);
		}

		// Token: 0x0600B4BB RID: 46267 RVA: 0x00286438 File Offset: 0x00284838
		public void AddRecord(GuildStorageOpRecord record)
		{
			string text = string.Empty;
			GuildStorageOpType opType = (GuildStorageOpType)record.opType;
			if (opType != GuildStorageOpType.GSOT_BUYPUT)
			{
				if (opType != GuildStorageOpType.GSOT_PUT)
				{
					if (opType == GuildStorageOpType.GSOT_GET)
					{
						text = TR.Value("guild_op_desc_1");
					}
				}
				else
				{
					text = TR.Value("guild_op_desc_2");
				}
			}
			else
			{
				text = TR.Value("guild_op_desc_3");
			}
			string arg = this._GetTimeDesc(record);
			if (!string.IsNullOrEmpty(text) && record.items != null)
			{
				int i = 0;
				int num = 0;
				while (i < record.items.Length)
				{
					int num2 = IntMath.Min(num + 5, record.items.Length);
					string text2 = this._GetItemDescs(record, num, num2);
					num = num2;
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
					{
						SotrageOperateRecordData sotrageOperateRecordData = new SotrageOperateRecordData();
						sotrageOperateRecordData.record = record;
						sotrageOperateRecordData.measured = false;
						sotrageOperateRecordData.value = TR.Value("guild_op_desc", arg, sotrageOperateRecordData.record.name, text, text2);
						this.records.Add(sotrageOperateRecordData);
					}
					i += 5;
				}
			}
			else
			{
				Logger.LogErrorFormat("desc is empty!!!", new object[]
				{
					text
				});
			}
		}

		// Token: 0x0600B4BC RID: 46268 RVA: 0x00286570 File Offset: 0x00284970
		private string _GetTimeDesc(GuildStorageOpRecord record)
		{
			string empty = string.Empty;
			if (record != null)
			{
				return Utility.ToUtcTime2Local((long)((ulong)record.time)).ToString(TR.Value("guild_record_date_string"), Utility.cultureInfo);
			}
			return empty;
		}

		// Token: 0x0600B4BD RID: 46269 RVA: 0x002865B0 File Offset: 0x002849B0
		private string _GetItemDescs(GuildStorageOpRecord record, int iStart, int iEnd)
		{
			string text = string.Empty;
			if (record != null)
			{
				int num = iStart;
				while (num < record.items.Length && num < iEnd)
				{
					GuildStorageItemInfo guildStorageItemInfo = record.items[num];
					if (guildStorageItemInfo != null && guildStorageItemInfo.num > 0)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)guildStorageItemInfo.dataId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, tableItem.Color2 == 1, false);
							if (qualityInfo != null)
							{
								string arg = "{" + string.Format("I {0} {1} {2}", 0, guildStorageItemInfo.dataId, guildStorageItemInfo.str) + "}";
								if (string.IsNullOrEmpty(text))
								{
									text += string.Format("{0}*{1}", TR.Value("common_color_text", qualityInfo.ColStr, arg), guildStorageItemInfo.num);
								}
								else
								{
									text += string.Format(",{0}*{1}", TR.Value("common_color_text", qualityInfo.ColStr, arg), guildStorageItemInfo.num);
								}
							}
						}
					}
					num++;
				}
			}
			return text;
		}

		// Token: 0x17001AE5 RID: 6885
		// (get) Token: 0x0600B4BE RID: 46270 RVA: 0x002866F3 File Offset: 0x00284AF3
		public Dictionary<int, List<GuildSkillTable>> dictSkillTableData
		{
			get
			{
				return this.m_dictSkillTableData;
			}
		}

		// Token: 0x0600B4BF RID: 46271 RVA: 0x002866FB File Offset: 0x00284AFB
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.GuildDataManager;
		}

		// Token: 0x17001AE6 RID: 6886
		// (get) Token: 0x0600B4C0 RID: 46272 RVA: 0x002866FE File Offset: 0x00284AFE
		public string GuildPVPBattleHideName
		{
			get
			{
				return this.mGuildPVPBattleHideName;
			}
		}

		// Token: 0x0600B4C1 RID: 46273 RVA: 0x00286708 File Offset: 0x00284B08
		public sealed override void Initialize()
		{
			this.RegisterNetHandler();
			this._RegisterUIEvent();
			this._InitGuildSkillData();
			this.donatePointCost = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(112, string.Empty, string.Empty).Value;
			this.donateGoldCost = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(110, string.Empty, string.Empty).Value;
			this.donatePointGet = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(113, string.Empty, string.Empty).Value;
			this.donateGoldGet = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(111, string.Empty, string.Empty).Value;
			this.exchangeCost = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(114, string.Empty, string.Empty).Value;
			this.canJoinAllGuild = true;
			this.winPower = 0;
			this.losePower = 0;
			this.contributePower = GuildPost.GUILD_POST_ELDER;
			this.clearPower = GuildPost.GUILD_POST_ASSISTANT;
			this.storageDatas.Clear();
			this.storeageCapacity = 50;
			this.queried = false;
			this.records.Clear();
			this.IsShowFireworks = false;
			this.ActivityNotifyUIOpenCount = 0;
			this.m_GuildDungeonActivityData = new GuildDataManager.GuildDungeonActivityData();
			this.m_MyDungeonDamageRankInfo = new GuildDataManager.DungeonDamageRankInfo();
			this.m_DungeonRankInfoList = new List<GuildDataManager.DungeonDamageRankInfo>();
			this.guildDungeonID2TeamDungeonID = new Dictionary<int, int>();
			if (this.guildDungeonID2TeamDungeonID != null)
			{
				this.guildDungeonID2TeamDungeonID.Clear();
				Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<TeamDungeonTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
						if (teamDungeonTable != null)
						{
							if (teamDungeonTable.DungeonID > 0)
							{
								this.guildDungeonID2TeamDungeonID[teamDungeonTable.DungeonID] = teamDungeonTable.ID;
							}
						}
					}
				}
			}
			this.m_GuildDungeonID2LvTable = new Dictionary<int, GuildDungeonLvlTable>();
			if (this.m_GuildDungeonID2LvTable != null)
			{
				Dictionary<int, object> table2 = Singleton<TableManager>.instance.GetTable<GuildDungeonLvlTable>();
				if (table2 != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair2 in table2)
					{
						GuildDungeonLvlTable guildDungeonLvlTable = keyValuePair2.Value as GuildDungeonLvlTable;
						if (guildDungeonLvlTable != null)
						{
							this.m_GuildDungeonID2LvTable.SafeAdd(guildDungeonLvlTable.DungeonId, guildDungeonLvlTable);
						}
					}
				}
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance3 = DataManager<PlayerBaseData>.GetInstance();
			instance3.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance3.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			ItemDataManager instance5 = DataManager<ItemDataManager>.GetInstance();
			instance5.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance5.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance6 = DataManager<ItemDataManager>.GetInstance();
			instance6.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance6.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance7 = DataManager<ItemDataManager>.GetInstance();
			instance7.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance7.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance8 = DataManager<ItemDataManager>.GetInstance();
			instance8.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance8.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			this.guildAuctionItemDatasForGuildAuction = new List<GuildDataManager.GuildAuctionItemData>();
			this.guildAuctionItemDatasForWorldAuction = new List<GuildDataManager.GuildAuctionItemData>();
			this.IsGuildAuctionOpen = false;
			this.IsGuildWorldAuctionOpen = false;
			this.HaveNewWorldAuctonItem = false;
			this.HaveNewGuildAuctonItem = false;
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.OpenNotifyUI));
			this.nEmblemSkillID = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(565, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.nEmblemSkillID = tableItem.Value;
			}
			this.nMaxEmblemLv = 0;
			Dictionary<int, object> table3 = Singleton<TableManager>.instance.GetTable<GuildEmblemTable>();
			if (table3 != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair3 in table3)
				{
					GuildEmblemTable guildEmblemTable = keyValuePair3.Value as GuildEmblemTable;
					if (guildEmblemTable != null)
					{
						if (guildEmblemTable.ID > this.nMaxEmblemLv)
						{
							this.nMaxEmblemLv = guildEmblemTable.ID;
						}
					}
				}
			}
			this.guildBuildType2Talbe = new Dictionary<GuildBuildingType, GuildBuildInfoTable>();
			if (this.guildBuildType2Talbe != null)
			{
				Dictionary<int, object> table4 = Singleton<TableManager>.instance.GetTable<GuildBuildInfoTable>();
				if (table4 != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair4 in table4)
					{
						GuildBuildInfoTable guildBuildInfoTable = keyValuePair4.Value as GuildBuildInfoTable;
						if (guildBuildInfoTable != null)
						{
							this.guildBuildType2Talbe[(GuildBuildingType)guildBuildInfoTable.buildType] = guildBuildInfoTable;
						}
					}
				}
			}
			this.checkedLvUpBulilding = false;
			this.checkedLvUpEmblem = false;
			this.checkedSetBossDiff = false;
			this._InitTRValue();
		}

		// Token: 0x0600B4C2 RID: 46274 RVA: 0x00286C00 File Offset: 0x00285000
		private void _InitTRValue()
		{
			this.mGuildPVPBattleHideName = TR.Value("guild_PVP_battle_hide_name");
		}

		// Token: 0x0600B4C3 RID: 46275 RVA: 0x00286C12 File Offset: 0x00285012
		private void _UnInitTRValue()
		{
			this.mGuildPVPBattleHideName = string.Empty;
		}

		// Token: 0x0600B4C4 RID: 46276 RVA: 0x00286C1F File Offset: 0x0028501F
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this.UpdateGuildEmblemRedPoint();
		}

		// Token: 0x0600B4C5 RID: 46277 RVA: 0x00286C27 File Offset: 0x00285027
		private void _OnAddNewItem(List<Item> items)
		{
			this.UpdateGuildEmblemRedPoint();
		}

		// Token: 0x0600B4C6 RID: 46278 RVA: 0x00286C2F File Offset: 0x0028502F
		private void OnUpdateItem(List<Item> items)
		{
			this.UpdateGuildEmblemRedPoint();
		}

		// Token: 0x0600B4C7 RID: 46279 RVA: 0x00286C38 File Offset: 0x00285038
		public sealed override void Clear()
		{
			Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(this.iIntervalCallID);
			this.UnRegisterNetHandler();
			this._UnregisterUIEvent();
			this._ClearGuildSkillData();
			this._ClearMyGuild();
			this.chestDoubleFlag = 0;
			this.donatePointCost = 0;
			this.donateGoldCost = 0;
			this.donatePointGet = 0;
			this.donateGoldGet = 0;
			this.exchangeCost = 0;
			this.canJoinAllGuild = true;
			this.winPower = 0;
			this.losePower = 0;
			this.contributePower = GuildPost.GUILD_POST_ELDER;
			this.clearPower = GuildPost.GUILD_POST_ASSISTANT;
			this.storageDatas.Clear();
			this.storeageCapacity = 50;
			this.queried = false;
			this.records.Clear();
			this.m_AttackCityData.ClearData();
			this.m_GuildInspireList.Clear();
			if (this.LotteryItem != null)
			{
				this.LotteryItem = null;
			}
			this.m_bHasLotteryed = true;
			if (this.TownStatueList != null)
			{
				this.TownStatueList.Clear();
			}
			if (this.GuildGuardStatueList != null)
			{
				this.GuildGuardStatueList.Clear();
			}
			if (this.m_DungeonRankInfoList != null)
			{
				this.m_DungeonRankInfoList.Clear();
			}
			this.UpBuildingNeedTicket = 0;
			this.guildBuildType2Talbe = null;
			this.checkedLvUpBulilding = false;
			this.checkedLvUpEmblem = false;
			this.checkedSetBossDiff = false;
			DataManager<PlayerBaseData>.GetInstance().GuildEmblemLv = 0U;
			this.IsHaveMergedRequest = false;
			this.IsAgreeMergerRequest = false;
			this.CanMergerdGuildMembers.Clear();
			this.mServerStartGameTime = 0UL;
			this.IsJumpTipWhenStartGuildBattle = false;
			this.IsJumpTipWhenStartGuildBattleCorssServer = false;
			this._UnInitTRValue();
		}

		// Token: 0x0600B4C8 RID: 46280 RVA: 0x00286DB5 File Offset: 0x002851B5
		public override void Update(float a_fTime)
		{
		}

		// Token: 0x0600B4C9 RID: 46281 RVA: 0x00286DB7 File Offset: 0x002851B7
		public override void OnApplicationStart()
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kSavePath, out this.jsonText);
			if (this.jsonText == null)
			{
				FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, string.Empty);
				this.jsonText = string.Empty;
				return;
			}
		}

		// Token: 0x0600B4CA RID: 46282 RVA: 0x00286DF4 File Offset: 0x002851F4
		public bool CheckExchangeRedPoint()
		{
			uint nExchangeCoolTime = DataManager<GuildDataManager>.GetInstance().myGuild.nExchangeCoolTime;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(122, string.Empty, string.Empty).Value;
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_exchange");
			int num = value - count;
			return nExchangeCoolTime <= serverTime && num > 0;
		}

		// Token: 0x0600B4CB RID: 46283 RVA: 0x00286E5C File Offset: 0x0028525C
		public void RequestGuildList(int a_nStartIndex, int a_nCount)
		{
			WorldGuildListReq worldGuildListReq = new WorldGuildListReq();
			worldGuildListReq.start = (ushort)a_nStartIndex;
			worldGuildListReq.num = (ushort)a_nCount;
			NetManager.Instance().SendCommand<WorldGuildListReq>(ServerType.GATE_SERVER, worldGuildListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildListRes>(delegate(WorldGuildListRes msgRet)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildListUpdated, msgRet, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600B4CC RID: 46284 RVA: 0x00286EBC File Offset: 0x002852BC
		public void CreateGuild(string a_strName, string a_strDeclaration)
		{
			if (this.HasSelfGuild())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_already_have_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			WorldGuildCreateReq worldGuildCreateReq = new WorldGuildCreateReq();
			worldGuildCreateReq.name = a_strName;
			worldGuildCreateReq.declaration = a_strDeclaration;
			NetManager.Instance().SendCommand<WorldGuildCreateReq>(ServerType.GATE_SERVER, worldGuildCreateReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildCreateRes>(delegate(WorldGuildCreateRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_creat_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCreateSuccess, null, null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatGuildJoin, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B4CD RID: 46285 RVA: 0x00286F38 File Offset: 0x00285338
		public static void AcceptJoinGuild(string param)
		{
			if (string.IsNullOrEmpty(param))
			{
				return;
			}
			ulong a_uGuildID = 0UL;
			if (!ulong.TryParse(param, out a_uGuildID))
			{
				return;
			}
			DataManager<GuildDataManager>.GetInstance().RequestJoinGuild(a_uGuildID);
		}

		// Token: 0x0600B4CE RID: 46286 RVA: 0x00286F70 File Offset: 0x00285370
		public void RequestJoinGuild(ulong a_uGuildID)
		{
			if (this.HasSelfGuild())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_already_have_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			WorldGuildJoinReq worldGuildJoinReq = new WorldGuildJoinReq();
			worldGuildJoinReq.id = a_uGuildID;
			NetManager.Instance().SendCommand<WorldGuildJoinReq>(ServerType.GATE_SERVER, worldGuildJoinReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldJoinGuildRes>(delegate(WorldJoinGuildRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_application"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestJoinSuccess, a_uGuildID, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B4CF RID: 46287 RVA: 0x00286FE4 File Offset: 0x002853E4
		public void RequestJoinAllGuild()
		{
			if (this.HasSelfGuild())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_already_have_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!this.canJoinAllGuild)
			{
				return;
			}
			WorldGuildJoinReq worldGuildJoinReq = new WorldGuildJoinReq();
			worldGuildJoinReq.id = 0UL;
			NetManager.Instance().SendCommand<WorldGuildJoinReq>(ServerType.GATE_SERVER, worldGuildJoinReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldJoinGuildRes>(delegate(WorldJoinGuildRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					this.canJoinAllGuild = false;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestJoinAllSuccess, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B4D0 RID: 46288 RVA: 0x00287054 File Offset: 0x00285454
		public void RequestGuildMembers()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildMemberListReq worldGuildMemberListReq = new WorldGuildMemberListReq();
				worldGuildMemberListReq.guildID = 0UL;
				NetManager.Instance().SendCommand<WorldGuildMemberListReq>(ServerType.GATE_SERVER, worldGuildMemberListReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildMemberListRes>(delegate(WorldGuildMemberListRes msgRet)
				{
					this.myGuild.arrMembers.Clear();
					for (int i = 0; i < msgRet.members.Length; i++)
					{
						GuildMemberEntry guildMemberEntry = msgRet.members[i];
						GuildMemberData guildMemberData = new GuildMemberData();
						guildMemberData.uGUID = guildMemberEntry.id;
						guildMemberData.strName = guildMemberEntry.name;
						guildMemberData.nLevel = (int)guildMemberEntry.level;
						guildMemberData.nJobID = (int)guildMemberEntry.occu;
						guildMemberData.vipLevel = (uint)guildMemberEntry.vipLevel;
						guildMemberData.seasonLevel = guildMemberEntry.seasonLevel;
						guildMemberData.eGuildDuty = this.GetClientDuty(guildMemberEntry.post);
						guildMemberData.nContribution = (int)guildMemberEntry.contribution;
						guildMemberData.uOffLineTime = guildMemberEntry.logoutTime;
						guildMemberData.uActiveDegree = guildMemberEntry.activeDegree;
						guildMemberData.playerLabelInfo = guildMemberEntry.playerLabelInfo;
						RelationData relationData = null;
						DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(guildMemberEntry.id, ref relationData);
						if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
						{
							guildMemberData.remark = relationData.remark;
						}
						this.myGuild.arrMembers.Add(guildMemberData);
					}
					int num = this.myGuild.arrMembers.FindIndex((GuildMemberData value) => value.uGUID == DataManager<PlayerBaseData>.GetInstance().RoleID);
					if (num > 0 && num < this.myGuild.arrMembers.Count)
					{
						GuildMemberData value2 = this.myGuild.arrMembers[num];
						this.myGuild.arrMembers[num] = this.myGuild.arrMembers[0];
						this.myGuild.arrMembers[0] = value2;
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildMembersUpdated, null, null, null, null);
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D1 RID: 46289 RVA: 0x002870A8 File Offset: 0x002854A8
		public void RequestGuildRequesters()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildRequesterReq cmd = new WorldGuildRequesterReq();
				NetManager.Instance().SendCommand<WorldGuildRequesterReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildRequesterRes>(delegate(WorldGuildRequesterRes msgRet)
				{
					if (this.myGuild.arrRequesters == null)
					{
						this.myGuild.arrRequesters = new List<GuildRequesterData>();
					}
					else
					{
						this.myGuild.arrRequesters.Clear();
					}
					for (int i = 0; i < msgRet.requesters.Length; i++)
					{
						GuildRequesterInfo guildRequesterInfo = msgRet.requesters[i];
						GuildRequesterData guildRequesterData = new GuildRequesterData();
						guildRequesterData.uGUID = guildRequesterInfo.id;
						guildRequesterData.strName = guildRequesterInfo.name;
						guildRequesterData.nLevel = (int)guildRequesterInfo.level;
						guildRequesterData.nJobID = (int)guildRequesterInfo.occu;
						RelationData relationData = null;
						DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(guildRequesterInfo.id, ref relationData);
						if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
						{
							guildRequesterData.remark = relationData.remark;
						}
						this.myGuild.arrRequesters.Add(guildRequesterData);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestersUpdated, null, null, null, null);
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D2 RID: 46290 RVA: 0x002870F4 File Offset: 0x002854F4
		public void ProcessRequester(ulong a_uGUID, bool a_bAgree)
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.ProcessRequester, EGuildDuty.Invalid))
			{
				WorldGuildProcessRequester worldGuildProcessRequester = new WorldGuildProcessRequester();
				worldGuildProcessRequester.id = a_uGUID;
				worldGuildProcessRequester.agree = ((!a_bAgree) ? 0 : 1);
				NetManager.Instance().SendCommand<WorldGuildProcessRequester>(ServerType.GATE_SERVER, worldGuildProcessRequester);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildProcessRequesterRes>(delegate(WorldGuildProcessRequesterRes msgRet)
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else
					{
						if (a_uGUID == 0UL)
						{
							this._ClearRequester();
						}
						else
						{
							this._RemoveRequester(a_uGUID);
							if (a_bAgree)
							{
								this._AddMember(msgRet.entry);
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_agree_requester_success", msgRet.entry.name), CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildProcessRequesterSuccess, a_uGUID, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D3 RID: 46291 RVA: 0x00287190 File Offset: 0x00285590
		public void ChangeMemberDuty(ulong a_uMemberGUID, EGuildDuty a_eDuty, ulong a_uReplaceMemberGUID)
		{
			if (this._CheckSelfGuild(true))
			{
				GuildMemberData member = this._FindMember(a_uMemberGUID);
				if (member == null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_can_not_find_member"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				EGuildPermission a_ePermission = (EGuildPermission)(1 << (int)a_eDuty);
				if (this._CheckPermission(a_ePermission, member.eGuildDuty))
				{
					WorldGuildChangePostReq worldGuildChangePostReq = new WorldGuildChangePostReq();
					worldGuildChangePostReq.id = a_uMemberGUID;
					worldGuildChangePostReq.post = this.GetServerDuty(a_eDuty);
					worldGuildChangePostReq.replacerId = a_uReplaceMemberGUID;
					NetManager.Instance().SendCommand<WorldGuildChangePostReq>(ServerType.GATE_SERVER, worldGuildChangePostReq);
					DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildChangePostRes>(delegate(WorldGuildChangePostRes msgRet)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else if (member != null)
						{
							member.eGuildDuty = a_eDuty;
							if (a_uReplaceMemberGUID > 0UL)
							{
								GuildMemberData guildMemberData = this._FindMember(a_uReplaceMemberGUID);
								if (guildMemberData != null)
								{
									guildMemberData.eGuildDuty = EGuildDuty.Normal;
								}
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildChangeDutySuccess, a_uMemberGUID, a_uReplaceMemberGUID, null, null);
						}
					}, true, 15f, null);
				}
			}
		}

		// Token: 0x0600B4D4 RID: 46292 RVA: 0x00287284 File Offset: 0x00285684
		public void DismissGuild()
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.Dismiss, EGuildDuty.Invalid))
			{
				WorldGuildDismissReq cmd = new WorldGuildDismissReq();
				NetManager.Instance().SendCommand<WorldGuildDismissReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 8)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.nDismissTime = msgRet.param;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestDismissSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D5 RID: 46293 RVA: 0x002872E0 File Offset: 0x002856E0
		public void CancelDismissGuild()
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.Dismiss, EGuildDuty.Invalid))
			{
				WorldGuildCancelDismissReq cmd = new WorldGuildCancelDismissReq();
				NetManager.Instance().SendCommand<WorldGuildCancelDismissReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 9)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.nDismissTime = 0U;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestCancelDismissSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D6 RID: 46294 RVA: 0x0028733C File Offset: 0x0028573C
		public void LeaveGuild()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildLeaveReq cmd = new WorldGuildLeaveReq();
				NetManager.Instance().SendCommand<WorldGuildLeaveReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildLeaveRes>(delegate(WorldGuildLeaveRes msgRet)
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else
					{
						this._ClearMyGuild();
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildLeaveGuildSuccess, null, null, null, null);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatGuildLeave, null, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D7 RID: 46295 RVA: 0x00287388 File Offset: 0x00285788
		public void KickMember(ulong a_uMemberGUID)
		{
			if (this._CheckSelfGuild(true))
			{
				GuildMemberData guildMemberData = this._FindMember(a_uMemberGUID);
				if (guildMemberData == null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_can_not_find_member"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (this._CheckPermission(EGuildPermission.KickMember, guildMemberData.eGuildDuty))
				{
					WorldGuildKick worldGuildKick = new WorldGuildKick();
					worldGuildKick.id = a_uMemberGUID;
					NetManager.Instance().SendCommand<WorldGuildKick>(ServerType.GATE_SERVER, worldGuildKick);
					DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildKickRes>(delegate(WorldGuildKickRes msgRet)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this._RemoveMember(a_uMemberGUID);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildKickMemberSuccess, a_uMemberGUID, null, null, null);
						}
					}, true, 15f, null);
				}
			}
		}

		// Token: 0x0600B4D8 RID: 46296 RVA: 0x0028742C File Offset: 0x0028582C
		public void SendMail(string a_strContent)
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.SendMail, EGuildDuty.Invalid))
			{
				WorldGuildSendMail worldGuildSendMail = new WorldGuildSendMail();
				worldGuildSendMail.content = a_strContent;
				NetManager.Instance().SendCommand<WorldGuildSendMail>(ServerType.GATE_SERVER, worldGuildSendMail);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (msgRet.type == 3)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildSendMailSuccess, null, null, null, null);
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_sende-mail_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4D9 RID: 46297 RVA: 0x002874A0 File Offset: 0x002858A0
		public void ChangeDeclaration(string a_strContent)
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.ChangeDeclaration, EGuildDuty.Invalid))
			{
				WorldGuildModifyDeclaration worldGuildModifyDeclaration = new WorldGuildModifyDeclaration();
				worldGuildModifyDeclaration.declaration = a_strContent;
				NetManager.Instance().SendCommand<WorldGuildModifyDeclaration>(ServerType.GATE_SERVER, worldGuildModifyDeclaration);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (msgRet.type == 0)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.strDeclaration = a_strContent;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildChangeDeclarationSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4DA RID: 46298 RVA: 0x0028751C File Offset: 0x0028591C
		public void ChangeNotice(string a_strContent)
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.ChangeNotice, EGuildDuty.Invalid))
			{
				WorldGuildModifyAnnouncement worldGuildModifyAnnouncement = new WorldGuildModifyAnnouncement();
				worldGuildModifyAnnouncement.content = a_strContent;
				NetManager.Instance().SendCommand<WorldGuildModifyAnnouncement>(ServerType.GATE_SERVER, worldGuildModifyAnnouncement);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (msgRet.type == 2)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.strNotice = a_strContent;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildChangeNoticeSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4DB RID: 46299 RVA: 0x00287598 File Offset: 0x00285998
		public void ChangeName(uint a_ItemtableID, ulong a_itemGUID, string a_strContent)
		{
			if (this._CheckSelfGuild(true) && this._CheckPermission(EGuildPermission.ChangeName, EGuildDuty.Invalid))
			{
				WorldGuildModifyName worldGuildModifyName = new WorldGuildModifyName();
				worldGuildModifyName.itemTableID = a_ItemtableID;
				worldGuildModifyName.itemGUID = a_itemGUID;
				worldGuildModifyName.name = a_strContent;
				NetManager.Instance().SendCommand<WorldGuildModifyName>(ServerType.GATE_SERVER, worldGuildModifyName);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (msgRet.type == 1)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.strName = a_strContent;
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildCommonModifyFrame>(null, false);
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_change_name_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildChangeNameSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4DC RID: 46300 RVA: 0x00287624 File Offset: 0x00285A24
		public void UpgradeBuilding(GuildBuildingType a_eType, int costFund)
		{
			if (this.GetBuildingData(a_eType) == null)
			{
				return;
			}
			if (!this._CheckSelfGuild(true))
			{
				return;
			}
			if (!this._CheckPermission(EGuildPermission.UpgradeBuilding, EGuildDuty.Invalid))
			{
				return;
			}
			this.m_eBuidingType = a_eType;
			this.SendUpBuildingReq();
		}

		// Token: 0x0600B4DD RID: 46301 RVA: 0x0028766C File Offset: 0x00285A6C
		private void OnClickSendUpBuildingLv()
		{
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			costInfo.nCount = this.UpBuildingNeedTicket;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendUpBuildingReq();
			}, "common_money_cost", null);
		}

		// Token: 0x0600B4DE RID: 46302 RVA: 0x002876BA File Offset: 0x00285ABA
		private void UpdateGuildBuildingRedPoint()
		{
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildMain);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildBuilding);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildBuildingManager);
		}

		// Token: 0x0600B4DF RID: 46303 RVA: 0x002876E0 File Offset: 0x00285AE0
		private void UpdateGuildEmblemRedPoint()
		{
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildMain);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildBuilding);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildEmblem);
		}

		// Token: 0x0600B4E0 RID: 46304 RVA: 0x00287706 File Offset: 0x00285B06
		private void UpdateGuildSetBossDiffRedPoint()
		{
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildMain);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildBuilding);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildSetBossDiff);
		}

		// Token: 0x0600B4E1 RID: 46305 RVA: 0x0028772C File Offset: 0x00285B2C
		public void SendUpBuildingReq()
		{
			WorldGuildUpgradeBuilding worldGuildUpgradeBuilding = new WorldGuildUpgradeBuilding();
			worldGuildUpgradeBuilding.type = (byte)this.m_eBuidingType;
			NetManager.Instance().SendCommand<WorldGuildUpgradeBuilding>(ServerType.GATE_SERVER, worldGuildUpgradeBuilding);
			int nLevel = 0;
			int nFund = 0;
			if (this.myGuild.dictBuildings.ContainsKey(this.m_eBuidingType))
			{
				nLevel = this.myGuild.dictBuildings[this.m_eBuidingType].nLevel + 1;
				nFund = this.myGuild.nFund - this.myGuild.dictBuildings[this.m_eBuidingType].nUpgradeCost;
			}
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
			{
				if (msgRet.type == 4)
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else
					{
						if (this.myGuild.dictBuildings.ContainsKey(this.m_eBuidingType))
						{
							this.myGuild.dictBuildings[this.m_eBuidingType].nLevel = nLevel;
							this.myGuild.nFund = nFund;
							this.UpdateGuildBuildingRedPoint();
							this._UpdateBuildingData();
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_build_lv_up_success", this.GetBuildingName(this.m_eBuidingType)), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildUpgradeBuildingSuccess, null, null, null, null);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateGuildEmblemLvUpEntry, null, null, null, null);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateGuildEmblemLvUpRedPoint, null, null, null, null);
					}
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B4E2 RID: 46306 RVA: 0x00287800 File Offset: 0x00285C00
		public void RequsetDonateLog()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildDonateLogReq cmd = new WorldGuildDonateLogReq();
				NetManager.Instance().SendCommand<WorldGuildDonateLogReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildDonateLogRes>(delegate(WorldGuildDonateLogRes msgRet)
				{
					List<GuildDonateData> list = new List<GuildDonateData>();
					for (int i = 0; i < msgRet.logs.Length; i++)
					{
						GuildDonateData guildDonateData = new GuildDonateData();
						GuildDonateLog guildDonateLog = msgRet.logs[i];
						guildDonateData.uGUID = guildDonateLog.id;
						guildDonateData.strName = guildDonateLog.name;
						guildDonateData.eType = (GuildDonateType)guildDonateLog.type;
						guildDonateData.nTimes = (int)guildDonateLog.num;
						guildDonateData.nFund = (int)guildDonateLog.contri;
						list.Add(guildDonateData);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRequestDonateLogSuccess, list, null, null, null);
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E3 RID: 46307 RVA: 0x0028785C File Offset: 0x00285C5C
		public void Donate(GuildDonateType a_eType, int a_nTimes)
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildDonateReq worldGuildDonateReq = new WorldGuildDonateReq();
				worldGuildDonateReq.type = (byte)a_eType;
				worldGuildDonateReq.num = (byte)a_nTimes;
				NetManager.Instance().SendCommand<WorldGuildDonateReq>(ServerType.GATE_SERVER, worldGuildDonateReq);
				int nFund = this.myGuild.nFund;
				int nContribution = DataManager<PlayerBaseData>.GetInstance().guildContribution;
				ulong uGold = DataManager<PlayerBaseData>.GetInstance().Gold;
				ulong uBindGold = DataManager<PlayerBaseData>.GetInstance().BindGold;
				ulong uTicket = DataManager<PlayerBaseData>.GetInstance().Ticket;
				ulong uBindTicket = DataManager<PlayerBaseData>.GetInstance().BindTicket;
				uint nDonateGoldTimes = 0U;
				uint nDonateTicketTimes = 0U;
				if (a_eType == GuildDonateType.GOLD)
				{
					int num = this.donateGoldGet * a_nTimes;
					ulong num2 = (ulong)((long)(this.donateGoldCost * a_nTimes));
					nFund += num;
					nContribution += num;
					if (uBindGold >= num2)
					{
						uBindGold -= num2;
					}
					else
					{
						uGold -= num2 - uBindGold;
						uBindGold = 0UL;
					}
					nDonateGoldTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_donate_gold") + a_nTimes);
				}
				else if (a_eType == GuildDonateType.POINT)
				{
					int num3 = this.donatePointGet * a_nTimes;
					ulong num4 = (ulong)((long)(this.donatePointCost * a_nTimes));
					nFund += num3;
					nContribution += num3;
					if (uBindTicket >= num4)
					{
						uBindTicket -= num4;
					}
					else
					{
						uTicket -= num4 - uBindTicket;
						uBindTicket = 0UL;
					}
					nDonateTicketTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_donate_point") + a_nTimes);
				}
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 5)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							GuildDonateData guildDonateData = new GuildDonateData();
							guildDonateData.uGUID = DataManager<PlayerBaseData>.GetInstance().RoleID;
							guildDonateData.strName = DataManager<PlayerBaseData>.GetInstance().Name;
							guildDonateData.eType = a_eType;
							guildDonateData.nTimes = a_nTimes;
							this.myGuild.nFund = nFund;
							DataManager<PlayerBaseData>.GetInstance().guildContribution = nContribution;
							DataManager<PlayerBaseData>.GetInstance().BindGold = uBindGold;
							DataManager<PlayerBaseData>.GetInstance().Gold = uGold;
							DataManager<PlayerBaseData>.GetInstance().Ticket = uTicket;
							DataManager<PlayerBaseData>.GetInstance().BindTicket = uBindTicket;
							if (a_eType == GuildDonateType.GOLD)
							{
								guildDonateData.nFund = this.donateGoldGet * a_nTimes;
								DataManager<CountDataManager>.GetInstance().SetCount("guild_donate_gold", nDonateGoldTimes);
							}
							else if (a_eType == GuildDonateType.POINT)
							{
								guildDonateData.nFund = this.donatePointGet * a_nTimes;
								DataManager<CountDataManager>.GetInstance().SetCount("guild_donate_point", nDonateTicketTimes);
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDonateSuccess, guildDonateData, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E4 RID: 46308 RVA: 0x00287AA0 File Offset: 0x00285EA0
		public void Exchange()
		{
			if (this._CheckSelfGuild(true))
			{
				SceneGuildExchangeReq cmd = new SceneGuildExchangeReq();
				NetManager.Instance().SendCommand<SceneGuildExchangeReq>(ServerType.GATE_SERVER, cmd);
				uint nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_exchange") + 1);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 6)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							DataManager<CountDataManager>.GetInstance().SetCount("guild_exchange", nTimes);
							this.myGuild.nExchangeCoolTime = msgRet.param;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildExchangeSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E5 RID: 46309 RVA: 0x00287B10 File Offset: 0x00285F10
		public void Worship(GuildOrzType a_eType)
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildOrzReq worldGuildOrzReq = new WorldGuildOrzReq();
				worldGuildOrzReq.type = (byte)a_eType;
				NetManager.Instance().SendCommand<WorldGuildOrzReq>(ServerType.GATE_SERVER, worldGuildOrzReq);
				uint nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_orz") + 1);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 10)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							DataManager<CountDataManager>.GetInstance().SetCount("guild_orz", nTimes);
							this.myGuild.leaderData.nPopularity += 1U;
							DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildStatue);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildWorshipSuccess, a_eType, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E6 RID: 46310 RVA: 0x00287BA0 File Offset: 0x00285FA0
		public void RequestLeaderStatue()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildLeaderInfoReq cmd = new WorldGuildLeaderInfoReq();
				NetManager.Instance().SendCommand<WorldGuildLeaderInfoReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildLeaderInfoRes>(delegate(WorldGuildLeaderInfoRes msgRet)
				{
					this.myGuild.leaderData.strName = msgRet.info.name;
					this.myGuild.leaderData.nPopularity = msgRet.info.popularoty;
					this.myGuild.leaderData.uGUID = msgRet.info.id;
					this.myGuild.leaderData.nJobID = (int)msgRet.info.occu;
					this.myGuild.leaderData.avatorInfo = msgRet.info.avatar;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildLeaderUpdated, null, null, null, null);
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E7 RID: 46311 RVA: 0x00287BEC File Offset: 0x00285FEC
		public void JoinTable(int a_nPos)
		{
			if (this._CheckSelfGuild(true))
			{
				if (this.HasJoinedTable())
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_table_already_joined"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				GuildRoundtableTable.eType eType = this.GetTableType();
				WorldGuildTableJoinReq worldGuildTableJoinReq = new WorldGuildTableJoinReq();
				worldGuildTableJoinReq.seat = (byte)a_nPos;
				worldGuildTableJoinReq.type = (byte)eType;
				NetManager.Instance().SendCommand<WorldGuildTableJoinReq>(ServerType.GATE_SERVER, worldGuildTableJoinReq);
				uint nTimes = 0U;
				if (eType == GuildRoundtableTable.eType.First)
				{
					nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_table") + 1);
				}
				else if (eType == GuildRoundtableTable.eType.Help)
				{
					nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_table_help") + 1);
				}
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 11)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							if (eType == GuildRoundtableTable.eType.First)
							{
								DataManager<CountDataManager>.GetInstance().SetCount("guild_table", nTimes);
							}
							else if (eType == GuildRoundtableTable.eType.Help)
							{
								DataManager<CountDataManager>.GetInstance().SetCount("guild_table_help", nTimes);
							}
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_table_join_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.GuildTable);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildJoinTableSuccess, a_nPos, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E8 RID: 46312 RVA: 0x00287CE4 File Offset: 0x002860E4
		public void BuyAndSendRedPacket(int a_nID, int a_nNum, string a_strName)
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildPayRedPacketReq worldGuildPayRedPacketReq = new WorldGuildPayRedPacketReq();
				worldGuildPayRedPacketReq.reason = (ushort)a_nID;
				worldGuildPayRedPacketReq.num = (byte)a_nNum;
				worldGuildPayRedPacketReq.name = a_strName;
				NetManager.Instance().SendCommand<WorldGuildPayRedPacketReq>(ServerType.GATE_SERVER, worldGuildPayRedPacketReq);
				uint nTimes = (uint)(DataManager<CountDataManager>.GetInstance().GetCount("guild_pay_rp") + 1);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildOperRes>(delegate(WorldGuildOperRes msgRet)
				{
					if (msgRet.type == 12)
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							DataManager<CountDataManager>.GetInstance().SetCount("guild_pay_rp", nTimes);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B4E9 RID: 46313 RVA: 0x00287D64 File Offset: 0x00286164
		public GuildRoundtableTable.eType GetTableType()
		{
			GuildRoundtableTable.eType result;
			if (this._GetFirstRemainTimes() > 0)
			{
				result = GuildRoundtableTable.eType.First;
			}
			else if (this._GetHelpRemainTimes() > 0)
			{
				result = GuildRoundtableTable.eType.Help;
			}
			else
			{
				result = GuildRoundtableTable.eType.FreeHelp;
			}
			return result;
		}

		// Token: 0x0600B4EA RID: 46314 RVA: 0x00287D9C File Offset: 0x0028619C
		public int GetRemainWorshipTimes()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_orz");
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(123, string.Empty, string.Empty).Value;
			int num = value - count;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600B4EB RID: 46315 RVA: 0x00287DE4 File Offset: 0x002861E4
		public bool HasPermission(EGuildPermission a_ePermission, EGuildDuty a_eSourceDuty = EGuildDuty.Invalid)
		{
			if (this.myGuild == null)
			{
				return false;
			}
			EGuildPermission eguildPermission = a_ePermission;
			if (eguildPermission == EGuildPermission.SetDutyNormal || eguildPermission == EGuildPermission.SetDutyElder || eguildPermission == EGuildPermission.SetDutyAssistant || eguildPermission == EGuildPermission.SetDutyLeader)
			{
				if (DataManager<PlayerBaseData>.GetInstance().eGuildDuty < a_eSourceDuty)
				{
					eguildPermission = EGuildPermission.Invalid;
				}
			}
			else if (eguildPermission == EGuildPermission.KickMember && DataManager<PlayerBaseData>.GetInstance().eGuildDuty <= a_eSourceDuty)
			{
				eguildPermission = EGuildPermission.Invalid;
			}
			EGuildPermission eguildPermission2 = EGuildPermission.Invalid;
			switch (DataManager<PlayerBaseData>.GetInstance().eGuildDuty)
			{
			case EGuildDuty.Invalid:
				eguildPermission2 = EGuildPermission.Invalid;
				break;
			case EGuildDuty.Normal:
				eguildPermission2 = EGuildPermission.Invalid;
				break;
			case EGuildDuty.Elite:
				eguildPermission2 = EGuildPermission.Invalid;
				break;
			case EGuildDuty.Elder:
				eguildPermission2 = EGuildPermission.ElderMask;
				break;
			case EGuildDuty.Assistant:
				eguildPermission2 = EGuildPermission.AssistantMask;
				break;
			case EGuildDuty.Leader:
				eguildPermission2 = EGuildPermission.LeaderMask;
				break;
			}
			return (eguildPermission2 & eguildPermission) != EGuildPermission.Invalid;
		}

		// Token: 0x0600B4EC RID: 46316 RVA: 0x00287EBE File Offset: 0x002862BE
		public bool HasSelfGuild()
		{
			return this.myGuild != null;
		}

		// Token: 0x0600B4ED RID: 46317 RVA: 0x00287ECC File Offset: 0x002862CC
		public bool HasJoinedTable()
		{
			if (this.HasSelfGuild())
			{
				for (int i = 0; i < this.myGuild.arrTableMembers.Length; i++)
				{
					if (this.myGuild.arrTableMembers[i] != null && this.myGuild.arrTableMembers[i].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B4EE RID: 46318 RVA: 0x00287F38 File Offset: 0x00286338
		public bool IsDutyFull(EGuildDuty a_eDuty)
		{
			if (!this.HasSelfGuild())
			{
				return false;
			}
			if (a_eDuty == EGuildDuty.Leader)
			{
				return true;
			}
			if (a_eDuty == EGuildDuty.Assistant)
			{
				int num = 0;
				for (int i = 0; i < this.myGuild.arrMembers.Count; i++)
				{
					if (this.myGuild.arrMembers[i].eGuildDuty == EGuildDuty.Assistant)
					{
						num++;
					}
				}
				return num == 2;
			}
			if (a_eDuty == EGuildDuty.Elder)
			{
				int num2 = 0;
				for (int j = 0; j < this.myGuild.arrMembers.Count; j++)
				{
					if (this.myGuild.arrMembers[j].eGuildDuty == EGuildDuty.Elder)
					{
						num2++;
					}
				}
				return num2 >= 4;
			}
			return false;
		}

		// Token: 0x0600B4EF RID: 46319 RVA: 0x00288003 File Offset: 0x00286403
		public List<GuildMemberData> GetMembers()
		{
			return this.myGuild.arrMembers;
		}

		// Token: 0x0600B4F0 RID: 46320 RVA: 0x00288010 File Offset: 0x00286410
		public List<GuildMemberData> GetMembersByDuty(EGuildDuty a_eDuty)
		{
			List<GuildMemberData> list = new List<GuildMemberData>();
			if (this.HasSelfGuild())
			{
				for (int i = 0; i < this.myGuild.arrMembers.Count; i++)
				{
					if (this.myGuild.arrMembers[i].eGuildDuty == a_eDuty)
					{
						list.Add(this.myGuild.arrMembers[i]);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B4F1 RID: 46321 RVA: 0x00288084 File Offset: 0x00286484
		public byte GetServerDuty(EGuildDuty a_eDuty)
		{
			GuildPost guildPost = GuildPost.GUILD_INVALID;
			switch (a_eDuty)
			{
			case EGuildDuty.Invalid:
				guildPost = GuildPost.GUILD_INVALID;
				break;
			case EGuildDuty.Normal:
				guildPost = GuildPost.GUILD_POST_NORMAL;
				break;
			case EGuildDuty.Elite:
				guildPost = GuildPost.GUILD_POST_ELITE;
				break;
			case EGuildDuty.Elder:
				guildPost = GuildPost.GUILD_POST_ELDER;
				break;
			case EGuildDuty.Assistant:
				guildPost = GuildPost.GUILD_POST_ASSISTANT;
				break;
			case EGuildDuty.Leader:
				guildPost = GuildPost.GUILD_POST_LEADER;
				break;
			}
			return (byte)guildPost;
		}

		// Token: 0x0600B4F2 RID: 46322 RVA: 0x002880E8 File Offset: 0x002864E8
		public EGuildDuty GetClientDuty(byte a_nDuty)
		{
			switch (a_nDuty)
			{
			case 0:
				return EGuildDuty.Invalid;
			case 1:
				return EGuildDuty.Normal;
			case 2:
				return EGuildDuty.Elite;
			default:
				switch (a_nDuty)
				{
				case 11:
					return EGuildDuty.Elder;
				case 12:
					return EGuildDuty.Assistant;
				case 13:
					return EGuildDuty.Leader;
				default:
					return EGuildDuty.Invalid;
				}
				break;
			}
		}

		// Token: 0x0600B4F3 RID: 46323 RVA: 0x00288130 File Offset: 0x00286530
		public int GetBuildingLevel(GuildBuildingType a_eType)
		{
			if (this.HasSelfGuild())
			{
				GuildBuildingData guildBuildingData = null;
				this.myGuild.dictBuildings.TryGetValue(a_eType, out guildBuildingData);
				if (guildBuildingData != null)
				{
					return guildBuildingData.nLevel;
				}
			}
			return 0;
		}

		// Token: 0x0600B4F4 RID: 46324 RVA: 0x0028816C File Offset: 0x0028656C
		public string GetBuildingName(GuildBuildingType guildBuildingType)
		{
			GuildBuildInfoTable guildBuildInfoTable = this.GetGuildBuildInfoTable(guildBuildingType);
			if (guildBuildInfoTable != null)
			{
				return guildBuildInfoTable.buildName;
			}
			return string.Empty;
		}

		// Token: 0x0600B4F5 RID: 46325 RVA: 0x00288194 File Offset: 0x00286594
		public GuildBuildingData GetBuildingData(GuildBuildingType a_eType)
		{
			if (this.HasSelfGuild())
			{
				GuildBuildingData result = null;
				this.myGuild.dictBuildings.TryGetValue(a_eType, out result);
				return result;
			}
			return null;
		}

		// Token: 0x0600B4F6 RID: 46326 RVA: 0x002881C5 File Offset: 0x002865C5
		public int GetUnLockBuildingNeedMainCityLv(GuildBuildingType guildBuildingType)
		{
			if (guildBuildingType == GuildBuildingType.HONOUR)
			{
				return this.GetEmblemLvUpGuildLvLimit();
			}
			if (guildBuildingType == GuildBuildingType.FETE)
			{
				return GuildDataManager.GetGuildDungeonActivityGuildLvLimit();
			}
			return 0;
		}

		// Token: 0x0600B4F7 RID: 46327 RVA: 0x002881E4 File Offset: 0x002865E4
		public GuildBuildInfoTable GetGuildBuildInfoTable(GuildBuildingType guildBuildingType)
		{
			if (this.guildBuildType2Talbe == null)
			{
				return null;
			}
			GuildBuildInfoTable result = null;
			this.guildBuildType2Talbe.TryGetValue(guildBuildingType, out result);
			return result;
		}

		// Token: 0x0600B4F8 RID: 46328 RVA: 0x00288210 File Offset: 0x00286610
		public string GetMyGuildName()
		{
			if (this.HasSelfGuild())
			{
				return this.myGuild.strName;
			}
			return string.Empty;
		}

		// Token: 0x0600B4F9 RID: 46329 RVA: 0x0028822E File Offset: 0x0028662E
		public int GetMyGuildFund()
		{
			if (this.HasSelfGuild())
			{
				return this.myGuild.nFund;
			}
			return 0;
		}

		// Token: 0x0600B4FA RID: 46330 RVA: 0x00288248 File Offset: 0x00286648
		public int GetGuildLv()
		{
			if (this.myGuild != null)
			{
				return this.myGuild.nLevel;
			}
			return 0;
		}

		// Token: 0x0600B4FB RID: 46331 RVA: 0x00288264 File Offset: 0x00286664
		public void InviteJoinGuild(ulong roleID)
		{
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 31;
			sceneRequest.target = roleID;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
		}

		// Token: 0x0600B4FC RID: 46332 RVA: 0x002882A8 File Offset: 0x002866A8
		private GuildMemberData _FindMember(ulong a_uMemberGUID)
		{
			if (this.myGuild != null && this.myGuild.arrMembers != null)
			{
				return this.myGuild.arrMembers.Find((GuildMemberData value) => value.uGUID == a_uMemberGUID);
			}
			return null;
		}

		// Token: 0x0600B4FD RID: 46333 RVA: 0x002882FC File Offset: 0x002866FC
		private void _AddMember(GuildMemberEntry a_sourceData)
		{
			if (this.myGuild != null && a_sourceData != null && this.myGuild.arrMembers.Find((GuildMemberData value) => value.uGUID == a_sourceData.id) == null)
			{
				GuildMemberData guildMemberData = new GuildMemberData();
				guildMemberData.uGUID = a_sourceData.id;
				guildMemberData.strName = a_sourceData.name;
				guildMemberData.nLevel = (int)a_sourceData.level;
				guildMemberData.nJobID = (int)a_sourceData.occu;
				guildMemberData.vipLevel = (uint)a_sourceData.vipLevel;
				guildMemberData.seasonLevel = a_sourceData.seasonLevel;
				guildMemberData.eGuildDuty = this.GetClientDuty(a_sourceData.post);
				guildMemberData.nContribution = (int)a_sourceData.contribution;
				guildMemberData.uOffLineTime = a_sourceData.logoutTime;
				guildMemberData.uActiveDegree = a_sourceData.activeDegree;
				this.myGuild.arrMembers.Add(guildMemberData);
			}
		}

		// Token: 0x0600B4FE RID: 46334 RVA: 0x00288414 File Offset: 0x00286814
		private void _RemoveMember(ulong a_uMemberGUID)
		{
			if (this.myGuild != null && this.myGuild.arrMembers != null)
			{
				int num = this.myGuild.arrMembers.FindIndex((GuildMemberData member) => member.uGUID == a_uMemberGUID);
				if (num >= 0 && num < this.myGuild.arrMembers.Count)
				{
					this.myGuild.arrMembers.RemoveAt(num);
				}
			}
		}

		// Token: 0x0600B4FF RID: 46335 RVA: 0x00288494 File Offset: 0x00286894
		private void _RemoveRequester(ulong a_uRequesterGUID)
		{
			if (this.myGuild != null && this.myGuild.arrRequesters != null)
			{
				int num = this.myGuild.arrRequesters.FindIndex((GuildRequesterData value) => value.uGUID == a_uRequesterGUID);
				if (num >= 0 && num < this.myGuild.arrRequesters.Count)
				{
					this.myGuild.arrRequesters.RemoveAt(num);
				}
			}
		}

		// Token: 0x0600B500 RID: 46336 RVA: 0x00288514 File Offset: 0x00286914
		private void _ClearRequester()
		{
			if (this.myGuild != null && this.myGuild.arrRequesters != null)
			{
				this.myGuild.arrRequesters.Clear();
			}
		}

		// Token: 0x0600B501 RID: 46337 RVA: 0x00288544 File Offset: 0x00286944
		private bool _CheckSelfGuild(bool a_bHas = true)
		{
			if (a_bHas)
			{
				if (!this.HasSelfGuild())
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return false;
				}
			}
			else if (this.HasSelfGuild())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_already_have_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			return true;
		}

		// Token: 0x0600B502 RID: 46338 RVA: 0x00288597 File Offset: 0x00286997
		private bool _CheckPermission(EGuildPermission a_ePermission, EGuildDuty a_eSourceDuty = EGuildDuty.Invalid)
		{
			if (!this.HasPermission(a_ePermission, a_eSourceDuty))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_no_permission_to_operate"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			return true;
		}

		// Token: 0x0600B503 RID: 46339 RVA: 0x002885BC File Offset: 0x002869BC
		private void _UpdateBuildingData()
		{
			GuildBuildingData guildBuildingData = this.myGuild.dictBuildings[GuildBuildingType.MAIN];
			guildBuildingData.nMaxLevel = 10;
			guildBuildingData.nUnlockMaincityLevel = -1;
			GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData.nLevel + 1, string.Empty, string.Empty);
			if (tableItem != null)
			{
				guildBuildingData.nUpgradeCost = tableItem.MainCost;
			}
			int nLevel = this.myGuild.dictBuildings[GuildBuildingType.MAIN].nLevel;
			GuildTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(nLevel, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				GuildBuildingData guildBuildingData2 = this.myGuild.dictBuildings[GuildBuildingType.SHOP];
				guildBuildingData2.nMaxLevel = tableItem2.ShopLevel;
				int num = nLevel;
				GuildTable tableItem3;
				do
				{
					num++;
					tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num, string.Empty, string.Empty);
					if (tableItem3 == null)
					{
						goto IL_F4;
					}
				}
				while (tableItem3.ShopLevel <= guildBuildingData2.nMaxLevel);
				guildBuildingData2.nUnlockMaincityLevel = num;
				goto IL_106;
				IL_F4:
				guildBuildingData2.nUnlockMaincityLevel = -1;
				IL_106:
				GuildBuildingTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData2.nLevel + 1, string.Empty, string.Empty);
				if (tableItem4 != null)
				{
					guildBuildingData2.nUpgradeCost = tableItem4.ShopCost;
				}
				GuildBuildingData guildBuildingData3 = this.myGuild.dictBuildings[GuildBuildingType.HONOUR];
				guildBuildingData3.nMaxLevel = tableItem2.HonourLevel;
				int num2 = nLevel;
				GuildTable tableItem5;
				do
				{
					num2++;
					tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num2, string.Empty, string.Empty);
					if (tableItem5 == null)
					{
						goto IL_1AB;
					}
				}
				while (tableItem5.HonourLevel <= guildBuildingData3.nMaxLevel);
				guildBuildingData3.nUnlockMaincityLevel = num2;
				goto IL_1BD;
				IL_1AB:
				guildBuildingData3.nUnlockMaincityLevel = -1;
				IL_1BD:
				GuildBuildingTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData3.nLevel + 1, string.Empty, string.Empty);
				if (tableItem6 != null)
				{
					guildBuildingData3.nUpgradeCost = tableItem6.HonourCost;
				}
				GuildBuildingData guildBuildingData4 = this.myGuild.dictBuildings[GuildBuildingType.FETE];
				guildBuildingData4.nMaxLevel = tableItem2.FeteLevel;
				int num3 = nLevel;
				GuildTable tableItem7;
				do
				{
					num3++;
					tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num3, string.Empty, string.Empty);
					if (tableItem7 == null)
					{
						goto IL_262;
					}
				}
				while (tableItem7.FeteLevel <= guildBuildingData4.nMaxLevel);
				guildBuildingData4.nUnlockMaincityLevel = num3;
				goto IL_274;
				IL_262:
				guildBuildingData4.nUnlockMaincityLevel = -1;
				IL_274:
				GuildBuildingTable tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData4.nLevel + 1, string.Empty, string.Empty);
				if (tableItem8 != null)
				{
					guildBuildingData4.nUpgradeCost = tableItem8.FeteCost;
				}
				GuildBuildingData guildBuildingData5 = this.myGuild.dictBuildings[GuildBuildingType.TABLE];
				guildBuildingData5.nMaxLevel = tableItem2.TableLevel;
				int num4 = nLevel;
				GuildTable tableItem9;
				do
				{
					num4++;
					tableItem9 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num4, string.Empty, string.Empty);
					if (tableItem9 == null)
					{
						goto IL_319;
					}
				}
				while (tableItem9.TableLevel <= guildBuildingData5.nMaxLevel);
				guildBuildingData5.nUnlockMaincityLevel = num4;
				goto IL_32B;
				IL_319:
				guildBuildingData5.nUnlockMaincityLevel = -1;
				IL_32B:
				GuildBuildingTable tableItem10 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData5.nLevel + 1, string.Empty, string.Empty);
				if (tableItem10 != null)
				{
					guildBuildingData5.nUpgradeCost = tableItem10.TableCost;
				}
				GuildBuildingData guildBuildingData6 = this.myGuild.dictBuildings[GuildBuildingType.DUNGEON];
				guildBuildingData6.nMaxLevel = tableItem2.DungeonLevel;
				int num5 = nLevel;
				GuildTable tableItem11;
				do
				{
					num5++;
					tableItem11 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num5, string.Empty, string.Empty);
					if (tableItem11 == null)
					{
						goto IL_3D0;
					}
				}
				while (tableItem11.DungeonLevel <= guildBuildingData6.nMaxLevel);
				guildBuildingData6.nUnlockMaincityLevel = num5;
				goto IL_3E2;
				IL_3D0:
				guildBuildingData6.nUnlockMaincityLevel = -1;
				IL_3E2:
				GuildBuildingTable tableItem12 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData6.nLevel + 1, string.Empty, string.Empty);
				if (tableItem12 != null)
				{
					guildBuildingData6.nUpgradeCost = tableItem12.DungeonCost;
				}
				GuildBuildingData guildBuildingData7 = this.myGuild.dictBuildings[GuildBuildingType.STATUE];
				guildBuildingData7.nMaxLevel = tableItem2.StatueLevel;
				int num6 = nLevel;
				GuildTable tableItem13;
				do
				{
					num6++;
					tableItem13 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num6, string.Empty, string.Empty);
					if (tableItem13 == null)
					{
						goto IL_487;
					}
				}
				while (tableItem13.StatueLevel <= guildBuildingData7.nMaxLevel);
				guildBuildingData7.nUnlockMaincityLevel = num6;
				goto IL_499;
				IL_487:
				guildBuildingData7.nUnlockMaincityLevel = -1;
				IL_499:
				GuildBuildingTable tableItem14 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData7.nLevel + 1, string.Empty, string.Empty);
				if (tableItem14 != null)
				{
					guildBuildingData7.nUpgradeCost = tableItem14.StatueCost;
				}
				GuildBuildingData guildBuildingData8 = this.myGuild.dictBuildings[GuildBuildingType.BATTLE];
				guildBuildingData8.nMaxLevel = tableItem2.BattleLevel;
				int num7 = nLevel;
				GuildTable tableItem15;
				do
				{
					num7++;
					tableItem15 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num7, string.Empty, string.Empty);
					if (tableItem15 == null)
					{
						goto IL_53E;
					}
				}
				while (tableItem15.BattleLevel <= guildBuildingData8.nMaxLevel);
				guildBuildingData8.nUnlockMaincityLevel = num7;
				goto IL_550;
				IL_53E:
				guildBuildingData8.nUnlockMaincityLevel = -1;
				IL_550:
				GuildBuildingTable tableItem16 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData8.nLevel + 1, string.Empty, string.Empty);
				if (tableItem16 != null)
				{
					guildBuildingData8.nUpgradeCost = tableItem16.BattleCost;
				}
				GuildBuildingData guildBuildingData9 = this.myGuild.dictBuildings[GuildBuildingType.WELFARE];
				guildBuildingData9.nMaxLevel = tableItem2.WelfareLevel;
				int num8 = nLevel;
				GuildTable tableItem17;
				do
				{
					num8++;
					tableItem17 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(num8, string.Empty, string.Empty);
					if (tableItem17 == null)
					{
						goto IL_5F5;
					}
				}
				while (tableItem17.WelfareLevel <= guildBuildingData9.nMaxLevel);
				guildBuildingData9.nUnlockMaincityLevel = num8;
				goto IL_607;
				IL_5F5:
				guildBuildingData9.nUnlockMaincityLevel = -1;
				IL_607:
				GuildBuildingTable tableItem18 = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(guildBuildingData9.nLevel + 1, string.Empty, string.Empty);
				if (tableItem18 != null)
				{
					guildBuildingData9.nUpgradeCost = tableItem18.WelfareCost;
				}
			}
			else
			{
				Logger.LogErrorFormat(string.Format("公会表找不到ID:{0}的条目", nLevel), new object[0]);
			}
			this.UpdateGuildBuildingRedPoint();
			this.UpdateGuildEmblemRedPoint();
			this.UpdateGuildSetBossDiffRedPoint();
		}

		// Token: 0x0600B504 RID: 46340 RVA: 0x00288C38 File Offset: 0x00287038
		private void _InitGuildSkillData()
		{
			this._ClearGuildSkillData();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<GuildSkillTable>())
			{
				GuildSkillTable guildSkillTable = keyValuePair.Value as GuildSkillTable;
				if (!this.m_dictSkillTableData.ContainsKey(guildSkillTable.SkillID))
				{
					this.m_dictSkillTableData.Add(guildSkillTable.SkillID, new List<GuildSkillTable>());
				}
				this.m_dictSkillTableData[guildSkillTable.SkillID].Add(guildSkillTable);
			}
		}

		// Token: 0x0600B505 RID: 46341 RVA: 0x00288CC4 File Offset: 0x002870C4
		private void _ClearGuildSkillData()
		{
			this.m_dictSkillTableData.Clear();
		}

		// Token: 0x0600B506 RID: 46342 RVA: 0x00288CD4 File Offset: 0x002870D4
		private int _GetFirstRemainTimes()
		{
			int timesLimit = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(0, string.Empty, string.Empty).TimesLimit;
			int num = timesLimit - DataManager<CountDataManager>.GetInstance().GetCount("guild_table");
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600B507 RID: 46343 RVA: 0x00288D18 File Offset: 0x00287118
		private int _GetHelpRemainTimes()
		{
			int timesLimit = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(1, string.Empty, string.Empty).TimesLimit;
			int num = timesLimit - DataManager<CountDataManager>.GetInstance().GetCount("guild_table_help");
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600B508 RID: 46344 RVA: 0x00288D5C File Offset: 0x0028715C
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(601918U, new Action<MsgDATA>(this._OnInitMyGuild));
			NetProcess.AddMsgHandler(601957U, new Action<MsgDATA>(this._OnInviteJoinGuild));
			NetProcess.AddMsgHandler(600108U, new Action<MsgDATA>(this._OnTownStatueRes));
			NetProcess.AddMsgHandler(601966U, new Action<MsgDATA>(this._OnRecvWorldGuildStorageSettingRes));
			NetProcess.AddMsgHandler(601971U, new Action<MsgDATA>(this._OnSorageItemUpdated));
			NetProcess.AddMsgHandler(601973U, new Action<MsgDATA>(this._OnRecvWorldGuildAddStorageRes));
			NetProcess.AddMsgHandler(601975U, new Action<MsgDATA>(this._OnRecvWorldGuildDelStorageRes));
			NetProcess.AddMsgHandler(608519U, new Action<MsgDATA>(this._OnWorldGuildAuctionNotify));
			NetProcess.AddMsgHandler(608514U, new Action<MsgDATA>(this._OnWorldGuildAuctionItemRes));
			NetProcess.AddMsgHandler(608518U, new Action<MsgDATA>(this._OnWorldGuildAuctionFixRes));
			NetProcess.AddMsgHandler(608516U, new Action<MsgDATA>(this._OnWorldGuildAuctionBidRes));
			NetProcess.AddMsgHandler(601995U, new Action<MsgDATA>(this._OnWorldGuildGetTerrDayRewardRes));
			NetProcess.AddMsgHandler(604401U, new Action<MsgDATA>(this._OnSyncWordStartTime));
		}

		// Token: 0x0600B509 RID: 46345 RVA: 0x00288E88 File Offset: 0x00287288
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(601918U, new Action<MsgDATA>(this._OnInitMyGuild));
			NetProcess.RemoveMsgHandler(601957U, new Action<MsgDATA>(this._OnInviteJoinGuild));
			NetProcess.RemoveMsgHandler(600108U, new Action<MsgDATA>(this._OnTownStatueRes));
			NetProcess.RemoveMsgHandler(601966U, new Action<MsgDATA>(this._OnRecvWorldGuildStorageSettingRes));
			NetProcess.RemoveMsgHandler(601971U, new Action<MsgDATA>(this._OnSorageItemUpdated));
			NetProcess.RemoveMsgHandler(601973U, new Action<MsgDATA>(this._OnRecvWorldGuildAddStorageRes));
			NetProcess.RemoveMsgHandler(601975U, new Action<MsgDATA>(this._OnRecvWorldGuildDelStorageRes));
			NetProcess.RemoveMsgHandler(608519U, new Action<MsgDATA>(this._OnWorldGuildAuctionNotify));
			NetProcess.RemoveMsgHandler(608514U, new Action<MsgDATA>(this._OnWorldGuildAuctionItemRes));
			NetProcess.RemoveMsgHandler(608518U, new Action<MsgDATA>(this._OnWorldGuildAuctionFixRes));
			NetProcess.RemoveMsgHandler(608516U, new Action<MsgDATA>(this._OnWorldGuildAuctionBidRes));
			NetProcess.RemoveMsgHandler(601995U, new Action<MsgDATA>(this._OnWorldGuildGetTerrDayRewardRes));
			NetProcess.RemoveMsgHandler(604401U, new Action<MsgDATA>(this._OnSyncWordStartTime));
		}

		// Token: 0x0600B50A RID: 46346 RVA: 0x00288FB3 File Offset: 0x002873B3
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataGuildUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountChanged));
		}

		// Token: 0x0600B50B RID: 46347 RVA: 0x00288FE8 File Offset: 0x002873E8
		private void _UnregisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataGuildUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountChanged));
		}

		// Token: 0x0600B50C RID: 46348 RVA: 0x00289020 File Offset: 0x00287420
		private void _OnPlayerDataGuildUpdated(UIEvent a_event)
		{
			if (a_event.Param1 == null)
			{
				return;
			}
			if (a_event.Param1.GetType() != typeof(SceneObjectAttr))
			{
				return;
			}
			SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)a_event.Param1;
			if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_POST)
			{
				if (DataManager<PlayerBaseData>.GetInstance().eGuildDuty == EGuildDuty.Invalid)
				{
					this._ClearMyGuild();
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildHasDismissed, null, null, null, null);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildChangeDutySuccess, null, null, null, null);
				}
			}
		}

		// Token: 0x0600B50D RID: 46349 RVA: 0x002890A8 File Offset: 0x002874A8
		private void _OnCountChanged(UIEvent a_event)
		{
			if (this.HasSelfGuild())
			{
				string a = a_event.Param1 as string;
				if (a == "guild_exchange_cold")
				{
					this.myGuild.nExchangeCoolTime = (uint)DataManager<CountDataManager>.GetInstance().GetCount("guild_exchange_cold");
				}
			}
		}

		// Token: 0x0600B50E RID: 46350 RVA: 0x002890F8 File Offset: 0x002874F8
		private void _BindSelfGuildNetMsg()
		{
			NetProcess.AddMsgHandler(601925U, new Action<MsgDATA>(this._OnNetSyncMyGuild));
			NetProcess.AddMsgHandler(601938U, new Action<MsgDATA>(this._OnNetAddTableMember));
			NetProcess.AddMsgHandler(601939U, new Action<MsgDATA>(this._OnNetRemoveTableMember));
			NetProcess.AddMsgHandler(601940U, new Action<MsgDATA>(this._OnNetNotifyTableFinished));
			NetProcess.AddMsgHandler(601950U, new Action<MsgDATA>(this._OnNetSyncBattleRecord));
			NetProcess.AddMsgHandler(601949U, new Action<MsgDATA>(this._OnNetGuildBattleRecordRes));
			NetProcess.AddMsgHandler(601960U, new Action<MsgDATA>(this._OnGuildChallengeRes));
			NetProcess.AddMsgHandler(601964U, new Action<MsgDATA>(this._OnGuildBattleInspireRes));
			NetProcess.AddMsgHandler(601968U, new Action<MsgDATA>(this._OnGuildBattleLotteryRes));
			NetProcess.AddMsgHandler(601958U, new Action<MsgDATA>(this._OnNetSyncGuildBattleState));
			NetProcess.AddMsgHandler(601962U, new Action<MsgDATA>(this._OnNetSyncGuildAttackCityRes));
			NetProcess.AddMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
			NetProcess.AddMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
			NetProcess.AddMsgHandler(608506U, new Action<MsgDATA>(this._OnWorldGuildDungeonCopyRes));
			NetProcess.AddMsgHandler(608504U, new Action<MsgDATA>(this._OnWorldGuildDungeonDamageRankRes));
			NetProcess.AddMsgHandler(608502U, new Action<MsgDATA>(this._OnWorldGuildDungeonInfoRes));
			NetProcess.AddMsgHandler(608508U, new Action<MsgDATA>(this._OnWorldGuildDungeonLotteryRes));
			NetProcess.AddMsgHandler(608509U, new Action<MsgDATA>(this._OnWorldGuildDungeonStatusSync));
			NetProcess.AddMsgHandler(608511U, new Action<MsgDATA>(this._OnWorldGuildDungeonStatueRes));
			NetProcess.AddMsgHandler(608512U, new Action<MsgDATA>(this._OnWorldGuildDungeonBossDeadNotify));
			NetProcess.AddMsgHandler(601989U, new Action<MsgDATA>(this._OnWorldGuildSetJoinLevelRes));
			NetProcess.AddMsgHandler(601991U, new Action<MsgDATA>(this._OnWorldGuildEmblemUpRes));
			NetProcess.AddMsgHandler(601993U, new Action<MsgDATA>(this._OnWorldGuildSetDungeonTypeRes));
			NetProcess.AddMsgHandler(601978U, new Action<MsgDATA>(this._OnCanMergerGuildListRes));
			NetProcess.AddMsgHandler(601980U, new Action<MsgDATA>(this._OnGuildMergerRequestOperatorRes));
			NetProcess.AddMsgHandler(601982U, new Action<MsgDATA>(this._OnGuildReceiveMergerRequestRes));
			NetProcess.AddMsgHandler(601984U, new Action<MsgDATA>(this._OnGuildWatchHavedMergerRequestRes));
			NetProcess.AddMsgHandler(601986U, new Action<MsgDATA>(this._OnGuildAcceptOrRefuseOrCancleMergerRequestRes));
			NetProcess.AddMsgHandler(601920U, new Action<MsgDATA>(this._OnCanMergerdGuildMembersRes));
			NetProcess.AddMsgHandler(601987U, new Action<MsgDATA>(this._OnGuildSyncMergerInfo));
		}

		// Token: 0x0600B50F RID: 46351 RVA: 0x0028939C File Offset: 0x0028779C
		private void _UnBindSelfGuildNetMsg()
		{
			NetProcess.RemoveMsgHandler(601925U, new Action<MsgDATA>(this._OnNetSyncMyGuild));
			NetProcess.RemoveMsgHandler(601938U, new Action<MsgDATA>(this._OnNetAddTableMember));
			NetProcess.RemoveMsgHandler(601939U, new Action<MsgDATA>(this._OnNetRemoveTableMember));
			NetProcess.RemoveMsgHandler(601940U, new Action<MsgDATA>(this._OnNetNotifyTableFinished));
			NetProcess.RemoveMsgHandler(601950U, new Action<MsgDATA>(this._OnNetSyncBattleRecord));
			NetProcess.RemoveMsgHandler(601949U, new Action<MsgDATA>(this._OnNetGuildBattleRecordRes));
			NetProcess.RemoveMsgHandler(601960U, new Action<MsgDATA>(this._OnGuildChallengeRes));
			NetProcess.RemoveMsgHandler(601964U, new Action<MsgDATA>(this._OnGuildBattleInspireRes));
			NetProcess.RemoveMsgHandler(601968U, new Action<MsgDATA>(this._OnGuildBattleLotteryRes));
			NetProcess.RemoveMsgHandler(601958U, new Action<MsgDATA>(this._OnNetSyncGuildBattleState));
			NetProcess.RemoveMsgHandler(601962U, new Action<MsgDATA>(this._OnNetSyncGuildAttackCityRes));
			NetProcess.RemoveMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
			NetProcess.RemoveMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
			NetProcess.RemoveMsgHandler(608506U, new Action<MsgDATA>(this._OnWorldGuildDungeonCopyRes));
			NetProcess.RemoveMsgHandler(608504U, new Action<MsgDATA>(this._OnWorldGuildDungeonDamageRankRes));
			NetProcess.RemoveMsgHandler(608502U, new Action<MsgDATA>(this._OnWorldGuildDungeonInfoRes));
			NetProcess.RemoveMsgHandler(608508U, new Action<MsgDATA>(this._OnWorldGuildDungeonLotteryRes));
			NetProcess.RemoveMsgHandler(608509U, new Action<MsgDATA>(this._OnWorldGuildDungeonStatusSync));
			NetProcess.RemoveMsgHandler(608511U, new Action<MsgDATA>(this._OnWorldGuildDungeonStatueRes));
			NetProcess.RemoveMsgHandler(608512U, new Action<MsgDATA>(this._OnWorldGuildDungeonBossDeadNotify));
			NetProcess.RemoveMsgHandler(601989U, new Action<MsgDATA>(this._OnWorldGuildSetJoinLevelRes));
			NetProcess.RemoveMsgHandler(601991U, new Action<MsgDATA>(this._OnWorldGuildEmblemUpRes));
			NetProcess.RemoveMsgHandler(601993U, new Action<MsgDATA>(this._OnWorldGuildSetDungeonTypeRes));
			NetProcess.RemoveMsgHandler(601978U, new Action<MsgDATA>(this._OnCanMergerGuildListRes));
			NetProcess.RemoveMsgHandler(601980U, new Action<MsgDATA>(this._OnGuildMergerRequestOperatorRes));
			NetProcess.RemoveMsgHandler(601982U, new Action<MsgDATA>(this._OnGuildReceiveMergerRequestRes));
			NetProcess.RemoveMsgHandler(601984U, new Action<MsgDATA>(this._OnGuildWatchHavedMergerRequestRes));
			NetProcess.RemoveMsgHandler(601986U, new Action<MsgDATA>(this._OnGuildAcceptOrRefuseOrCancleMergerRequestRes));
			NetProcess.RemoveMsgHandler(601920U, new Action<MsgDATA>(this._OnCanMergerdGuildMembersRes));
			NetProcess.RemoveMsgHandler(601987U, new Action<MsgDATA>(this._OnGuildSyncMergerInfo));
		}

		// Token: 0x0600B510 RID: 46352 RVA: 0x00289640 File Offset: 0x00287A40
		private void _onStartBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			WorldMatchStartRes worldMatchStartRes = new WorldMatchStartRes();
			worldMatchStartRes.decode(a_msgData.bytes);
			if (worldMatchStartRes == null)
			{
				return;
			}
			if (worldMatchStartRes.result != 0U)
			{
				if (worldMatchStartRes.result != 3302003U)
				{
					SystemNotifyManager.SystemNotify((int)worldMatchStartRes.result, string.Empty);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchStartSuccess, null, null, null, null);
		}

		// Token: 0x0600B511 RID: 46353 RVA: 0x002896C4 File Offset: 0x00287AC4
		private void _onCancelBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			WorldMatchCancelRes worldMatchCancelRes = new WorldMatchCancelRes();
			worldMatchCancelRes.decode(a_msgData.bytes);
			if (worldMatchCancelRes == null)
			{
				return;
			}
			if (worldMatchCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMatchCancelRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelSuccess, null, null, null, null);
		}

		// Token: 0x0600B512 RID: 46354 RVA: 0x00289734 File Offset: 0x00287B34
		private void _InitMyGuild(MsgDATA a_msgData)
		{
			if (a_msgData != null)
			{
				WorldGuildSyncInfo worldGuildSyncInfo = new WorldGuildSyncInfo();
				worldGuildSyncInfo.decode(a_msgData.bytes);
				if (worldGuildSyncInfo.info.id <= 0UL)
				{
					return;
				}
				this.myGuild = new GuildMyData();
				this.myGuild.uGUID = worldGuildSyncInfo.info.id;
				this.myGuild.strName = worldGuildSyncInfo.info.name;
				this.myGuild.nLevel = (int)worldGuildSyncInfo.info.level;
				this.myGuild.nJoinLevel = worldGuildSyncInfo.info.joinLevel;
				this.myGuild.emblemLevel = worldGuildSyncInfo.info.emblemLevel;
				this.myGuild.dungeonType = worldGuildSyncInfo.info.dungeonType;
				this.OnGuildLevelChanged((int)worldGuildSyncInfo.info.level, this.myGuild.nLevel);
				this.myGuild.nMemberCount = (int)worldGuildSyncInfo.info.memberNum;
				this.myGuild.nMemberMaxCount = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(this.myGuild.nLevel, string.Empty, string.Empty).MemberNum;
				this.myGuild.nFund = (int)worldGuildSyncInfo.info.fund;
				this.UpdateGuildBuildingRedPoint();
				this.UpdateGuildEmblemRedPoint();
				this.myGuild.strDeclaration = worldGuildSyncInfo.info.declaration;
				this.myGuild.strNotice = worldGuildSyncInfo.info.announcement;
				this.myGuild.nDismissTime = worldGuildSyncInfo.info.dismissTime;
				this.myGuild.nExchangeCoolTime = (uint)DataManager<CountDataManager>.GetInstance().GetCount("guild_exchange_cold");
				this.myGuild.leaderData.strName = worldGuildSyncInfo.info.leaderName;
				this.myGuild.leaderData.eGuildDuty = EGuildDuty.Leader;
				this.myGuild.nWinProbability = (int)worldGuildSyncInfo.info.winProbability;
				this._OnStorageSettingSync(GuildStorageSetting.GSS_WIN_PROBABILITY, (int)worldGuildSyncInfo.info.winProbability);
				this.myGuild.nLoseProbability = (int)worldGuildSyncInfo.info.loseProbability;
				this._OnStorageSettingSync(GuildStorageSetting.GSS_LOSE_PROBABILITY, (int)worldGuildSyncInfo.info.loseProbability);
				this.myGuild.nStorageAddPost = (int)worldGuildSyncInfo.info.storageAddPost;
				this._OnStorageSettingSync(GuildStorageSetting.GSS_STORAGE_ADD_POST, (int)worldGuildSyncInfo.info.storageAddPost);
				this.myGuild.nStorageDelPost = (int)worldGuildSyncInfo.info.storageDelPost;
				this._OnStorageSettingSync(GuildStorageSetting.GSS_STORAGE_DEL_POST, (int)worldGuildSyncInfo.info.storageDelPost);
				this.myGuild.lastWeekFunValue = worldGuildSyncInfo.info.lastWeekAddedFund;
				this.myGuild.thisWeekFunValue = worldGuildSyncInfo.info.weekAddedFund;
				this.GuildInviteList.Clear();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
				for (int i = 0; i < this.myGuild.arrTableMembers.Length; i++)
				{
					this.myGuild.arrTableMembers[i] = null;
				}
				for (int j = 0; j < worldGuildSyncInfo.info.tableMembers.Length; j++)
				{
					GuildTableMember guildTableMember = worldGuildSyncInfo.info.tableMembers[j];
					if (guildTableMember.seat >= 0 && (int)guildTableMember.seat < this.myGuild.arrTableMembers.Length)
					{
						this.myGuild.arrTableMembers[(int)guildTableMember.seat] = guildTableMember;
					}
				}
				for (int k = 0; k < worldGuildSyncInfo.info.building.Length; k++)
				{
					GuildBuilding guildBuilding = worldGuildSyncInfo.info.building[k];
					GuildBuildingData guildBuildingData = new GuildBuildingData();
					guildBuildingData.eType = (GuildBuildingType)guildBuilding.type;
					guildBuildingData.nLevel = (int)guildBuilding.level;
					this.myGuild.dictBuildings.Add(guildBuildingData.eType, guildBuildingData);
				}
				this._UpdateBuildingData();
				this._InitGuildBattle(worldGuildSyncInfo.info.guildBattleInfo);
				this._BindSelfGuildNetMsg();
			}
		}

		// Token: 0x0600B513 RID: 46355 RVA: 0x00289B0A File Offset: 0x00287F0A
		private void _ClearMyGuild()
		{
			this.myGuild = null;
			this.GuildInviteList.Clear();
			this._ClearGuildBattle();
			this._UnBindSelfGuildNetMsg();
		}

		// Token: 0x0600B514 RID: 46356 RVA: 0x00289B2C File Offset: 0x00287F2C
		private void _OnNetSyncMyGuild(MsgDATA a_msgData)
		{
			if (a_msgData != null && this.myGuild != null)
			{
				int num = 0;
				for (;;)
				{
					byte b = 0;
					BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b);
					if (b == 0)
					{
						break;
					}
					if (b == 1)
					{
						ushort num2 = 0;
						BaseDLL.decode_uint16(a_msgData.bytes, ref num, ref num2);
						byte[] array = new byte[(int)num2];
						for (int i = 0; i < (int)num2; i++)
						{
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref array[i]);
						}
						this.myGuild.strName = Encoding.UTF8.GetString(array);
					}
					else if (b == 2)
					{
						byte b2 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b2);
						this.myGuild.nLevel = (int)b2;
						this.OnGuildLevelChanged((int)b2, this.myGuild.nLevel);
						this.myGuild.nMemberMaxCount = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>(this.myGuild.nLevel, string.Empty, string.Empty).MemberNum;
					}
					else if (b == 3)
					{
						ushort num3 = 0;
						BaseDLL.decode_uint16(a_msgData.bytes, ref num, ref num3);
						byte[] array2 = new byte[(int)num3];
						for (int j = 0; j < (int)num3; j++)
						{
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref array2[j]);
						}
						this.myGuild.strDeclaration = Encoding.UTF8.GetString(array2);
					}
					else if (b == 4)
					{
						BaseDLL.decode_int32(a_msgData.bytes, ref num, ref this.myGuild.nFund);
						this.UpdateGuildBuildingRedPoint();
					}
					else if (b == 5)
					{
						ushort num4 = 0;
						BaseDLL.decode_uint16(a_msgData.bytes, ref num, ref num4);
						byte[] array3 = new byte[(int)num4];
						for (int k = 0; k < (int)num4; k++)
						{
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref array3[k]);
						}
						this.myGuild.strNotice = Encoding.UTF8.GetString(array3);
					}
					else if (b == 8)
					{
						ushort nMemberCount = 0;
						BaseDLL.decode_uint16(a_msgData.bytes, ref num, ref nMemberCount);
						this.myGuild.nMemberCount = (int)nMemberCount;
					}
					else if (b == 7)
					{
						BaseDLL.decode_uint32(a_msgData.bytes, ref num, ref this.myGuild.nDismissTime);
					}
					else if (b == 9)
					{
						ushort num5 = 0;
						BaseDLL.decode_uint16(a_msgData.bytes, ref num, ref num5);
						byte[] array4 = new byte[(int)num5];
						for (int l = 0; l < (int)num5; l++)
						{
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref array4[l]);
						}
						this.myGuild.leaderData.strName = Encoding.UTF8.GetString(array4);
					}
					else if (b == 6)
					{
						byte b3 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b3);
						for (int m = 0; m < (int)b3; m++)
						{
							byte b4 = 0;
							byte nLevel = 0;
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b4);
							BaseDLL.decode_int8(a_msgData.bytes, ref num, ref nLevel);
							GuildBuildingType key = (GuildBuildingType)b4;
							if (this.myGuild.dictBuildings.ContainsKey(key))
							{
								this.myGuild.dictBuildings[key].nLevel = (int)nLevel;
							}
						}
						this.UpdateGuildEmblemRedPoint();
						this.UpdateGuildSetBossDiffRedPoint();
					}
					else if (b == 10)
					{
						byte b5 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b5);
						if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
						{
							this.myGuild.nTargetCrossManorID = (int)b5;
						}
						else
						{
							this.myGuild.nTargetManorID = (int)b5;
						}
					}
					else if (b == 11)
					{
						BaseDLL.decode_int32(a_msgData.bytes, ref num, ref this.myGuild.nBattleScore);
					}
					else if (b == 12)
					{
						byte nSelfManorID = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref nSelfManorID);
						this.myGuild.nSelfManorID = (int)nSelfManorID;
					}
					else if (b == 18)
					{
						byte nSelfCrossManorID = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref nSelfCrossManorID);
						this.myGuild.nSelfCrossManorID = (int)nSelfCrossManorID;
					}
					else if (b == 19)
					{
						byte nSelfHistoryManorID = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref nSelfHistoryManorID);
						this.myGuild.nSelfHistoryManorID = (int)nSelfHistoryManorID;
					}
					else if (b == 20)
					{
						uint nJoinLevel = 0U;
						BaseDLL.decode_uint32(a_msgData.bytes, ref num, ref nJoinLevel);
						this.myGuild.nJoinLevel = nJoinLevel;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildJoinLvUpdate, null, null, null, null);
					}
					else if (b == 21)
					{
						uint dungeonType = 0U;
						BaseDLL.decode_uint32(a_msgData.bytes, ref num, ref dungeonType);
						this.myGuild.dungeonType = dungeonType;
						this._UpdateBuildingData();
					}
					else if (b == 13)
					{
						byte nInspire = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref nInspire);
						this.myGuild.nInspire = (int)nInspire;
					}
					else if (b == 14)
					{
						byte b6 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b6);
						this.myGuild.nWinProbability = (int)b6;
						this._OnStorageSettingSync(GuildStorageSetting.GSS_WIN_PROBABILITY, (int)b6);
					}
					else if (b == 15)
					{
						byte b7 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b7);
						this.myGuild.nLoseProbability = (int)b7;
						this._OnStorageSettingSync(GuildStorageSetting.GSS_LOSE_PROBABILITY, (int)b7);
					}
					else if (b == 16)
					{
						byte b8 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b8);
						this.myGuild.nStorageAddPost = (int)b8;
						this._OnStorageSettingSync(GuildStorageSetting.GSS_STORAGE_ADD_POST, (int)b8);
					}
					else if (b == 17)
					{
						byte b9 = 0;
						BaseDLL.decode_int8(a_msgData.bytes, ref num, ref b9);
						this.myGuild.nStorageDelPost = (int)b9;
						this._OnStorageSettingSync(GuildStorageSetting.GSS_STORAGE_DEL_POST, (int)b9);
					}
					else if (b == 22)
					{
						uint lastWeekFunValue = 0U;
						BaseDLL.decode_uint32(a_msgData.bytes, ref num, ref lastWeekFunValue);
						this.myGuild.lastWeekFunValue = lastWeekFunValue;
					}
					else if (b == 23)
					{
						uint thisWeekFunValue = 0U;
						BaseDLL.decode_uint32(a_msgData.bytes, ref num, ref thisWeekFunValue);
						this.myGuild.thisWeekFunValue = thisWeekFunValue;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBaseInfoUpdated, null, null, null, null);
			}
		}

		// Token: 0x0600B515 RID: 46357 RVA: 0x0028A180 File Offset: 0x00288580
		private void _OnNetAddTableMember(MsgDATA a_msgData)
		{
			WorldGuildTableNewMember worldGuildTableNewMember = new WorldGuildTableNewMember();
			worldGuildTableNewMember.decode(a_msgData.bytes);
			int seat = (int)worldGuildTableNewMember.member.seat;
			if (seat >= 0 && seat < this.myGuild.arrTableMembers.Length)
			{
				this.myGuild.arrTableMembers[seat] = worldGuildTableNewMember.member;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildAddTableMember, seat, null, null, null);
			}
		}

		// Token: 0x0600B516 RID: 46358 RVA: 0x0028A1F0 File Offset: 0x002885F0
		private void _OnNetRemoveTableMember(MsgDATA a_msgData)
		{
			WorldGuildTableDelMember worldGuildTableDelMember = new WorldGuildTableDelMember();
			worldGuildTableDelMember.decode(a_msgData.bytes);
			for (int i = 0; i < this.myGuild.arrTableMembers.Length; i++)
			{
				if (this.myGuild.arrTableMembers[i].id == worldGuildTableDelMember.id)
				{
					this.myGuild.arrTableMembers[i] = null;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildRemoveTableMember, i, null, null, null);
					break;
				}
			}
		}

		// Token: 0x0600B517 RID: 46359 RVA: 0x0028A278 File Offset: 0x00288678
		private void _OnNetNotifyTableFinished(MsgDATA a_msgData)
		{
			for (int i = 0; i < this.myGuild.arrTableMembers.Length; i++)
			{
				this.myGuild.arrTableMembers[i] = null;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildTableFinished, null, null, null, null);
		}

		// Token: 0x0600B518 RID: 46360 RVA: 0x0028A2C4 File Offset: 0x002886C4
		private void _OnInitMyGuild(MsgDATA a_data)
		{
			if (a_data != null)
			{
				this._InitMyGuild(a_data);
			}
			else
			{
				this._ClearMyGuild();
			}
		}

		// Token: 0x0600B519 RID: 46361 RVA: 0x0028A2E0 File Offset: 0x002886E0
		private void _OnInviteJoinGuild(MsgDATA a_data)
		{
			WorldGuildInviteNotify worldGuildInviteNotify = new WorldGuildInviteNotify();
			worldGuildInviteNotify.decode(a_data.bytes);
			if (this.HasSelfGuild())
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < this.GuildInviteList.Count; i++)
			{
				if (this.GuildInviteList[i].inviterId == worldGuildInviteNotify.inviterId)
				{
					if (this.GuildInviteList[i].guildId != worldGuildInviteNotify.guildId)
					{
						flag2 = true;
					}
					this.GuildInviteList[i] = worldGuildInviteNotify;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.GuildInviteList.Add(worldGuildInviteNotify);
				flag2 = true;
			}
			if (flag2)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
			}
			this.AddInviteGuildNotify(worldGuildInviteNotify);
		}

		// Token: 0x0600B51A RID: 46362 RVA: 0x0028A3B0 File Offset: 0x002887B0
		public void AddInviteGuildNotify(WorldGuildInviteNotify notify)
		{
			RelationData relationData = new RelationData();
			relationData.uid = notify.inviterId;
			relationData.name = notify.inviterName;
			relationData.level = notify.inviterLevel;
			relationData.occu = notify.inviterOccu;
			relationData.vipLv = notify.inviterVipLevel;
			relationData.type = 3;
			DataManager<ChatManager>.GetInstance().AddAskForPupilInvite(relationData, TR.Value("tap_invite_Guild", notify.guildName, notify.guildId), false);
		}

		// Token: 0x0600B51B RID: 46363 RVA: 0x0028A430 File Offset: 0x00288830
		private void _OnTownStatueRes(MsgDATA a_data)
		{
			WorldFigureStatueSync worldFigureStatueSync = new WorldFigureStatueSync();
			worldFigureStatueSync.decode(a_data.bytes);
			this.TownStatueList.Clear();
			for (int i = 0; i < worldFigureStatueSync.figureStatue.Length; i++)
			{
				this.TownStatueList.Add(worldFigureStatueSync.figureStatue[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildTownStatueUpdate, null, null, null, null);
		}

		// Token: 0x17001AE7 RID: 6887
		// (get) Token: 0x0600B51C RID: 46364 RVA: 0x0028A499 File Offset: 0x00288899
		// (set) Token: 0x0600B51D RID: 46365 RVA: 0x0028A4A1 File Offset: 0x002888A1
		public bool isBattleNotifyInited
		{
			get
			{
				return this.m_bBattleNotifyInited;
			}
			set
			{
				this.m_bBattleNotifyInited = value;
			}
		}

		// Token: 0x0600B51E RID: 46366 RVA: 0x0028A4AC File Offset: 0x002888AC
		public GuildTerritoryBaseInfo GetGuildTerritoryBaseInfo(int a_nID)
		{
			if (this.m_arrGuildManorInfos != null)
			{
				for (int i = 0; i < this.m_arrGuildManorInfos.Length; i++)
				{
					if ((int)this.m_arrGuildManorInfos[i].terrId == a_nID)
					{
						return this.m_arrGuildManorInfos[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600B51F RID: 46367 RVA: 0x0028A4FC File Offset: 0x002888FC
		public string GetManorOwner(int a_nID)
		{
			if (this.m_arrGuildManorInfos != null)
			{
				for (int i = 0; i < this.m_arrGuildManorInfos.Length; i++)
				{
					if ((int)this.m_arrGuildManorInfos[i].terrId == a_nID)
					{
						return this.m_arrGuildManorInfos[i].guildName;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x0600B520 RID: 46368 RVA: 0x0028A553 File Offset: 0x00288953
		public bool IsSameGuild(ulong guildID)
		{
			return this.myGuild != null && this.myGuild.uGUID == guildID;
		}

		// Token: 0x0600B521 RID: 46369 RVA: 0x0028A574 File Offset: 0x00288974
		public bool IsInBattlePrepareScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				int nTargetManorID = DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID;
				GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(nTargetManorID, string.Empty, string.Empty);
				if (tableItem != null && clientSystemTown.CurrentSceneID == tableItem.SceneID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B522 RID: 46370 RVA: 0x0028A5E6 File Offset: 0x002889E6
		public int GetLatestBattleRecordID()
		{
			return this.m_nLatestRecordID;
		}

		// Token: 0x0600B523 RID: 46371 RVA: 0x0028A5F0 File Offset: 0x002889F0
		public int GetGuildBattleWinTimes()
		{
			int num = 0;
			for (int i = 0; i < this.m_arrSelfBattleRecords.Count; i++)
			{
				if (this.m_arrSelfBattleRecords[i].winner.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600B524 RID: 46372 RVA: 0x0028A648 File Offset: 0x00288A48
		public int GetGuildBattleFailTimes()
		{
			int num = 0;
			for (int i = 0; i < this.m_arrSelfBattleRecords.Count; i++)
			{
				if (this.m_arrSelfBattleRecords[i].loser.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600B525 RID: 46373 RVA: 0x0028A69D File Offset: 0x00288A9D
		public EGuildBattleState GetGuildBattleState()
		{
			return this.m_guildBattleState;
		}

		// Token: 0x0600B526 RID: 46374 RVA: 0x0028A6A5 File Offset: 0x00288AA5
		public GuildBattleType GetGuildBattleType()
		{
			return this.m_guildBattleType;
		}

		// Token: 0x0600B527 RID: 46375 RVA: 0x0028A6AD File Offset: 0x00288AAD
		public uint GetGuildBattleStateEndTime()
		{
			return this.m_nStateEndTime;
		}

		// Token: 0x0600B528 RID: 46376 RVA: 0x0028A6B5 File Offset: 0x00288AB5
		public bool CurTargetCrossManorIDIsYGWZ()
		{
			return this.myGuild != null && this.myGuild.nTargetCrossManorID == 8;
		}

		// Token: 0x0600B529 RID: 46377 RVA: 0x0028A6D2 File Offset: 0x00288AD2
		public bool HasSelfManor()
		{
			return this.HasSelfGuild() && this.myGuild.nSelfManorID > 0;
		}

		// Token: 0x0600B52A RID: 46378 RVA: 0x0028A6EF File Offset: 0x00288AEF
		public bool HasSelfCrossManor()
		{
			return this.HasSelfGuild() && this.myGuild.nSelfCrossManorID > 0;
		}

		// Token: 0x0600B52B RID: 46379 RVA: 0x0028A70C File Offset: 0x00288B0C
		public bool HasTargetManor()
		{
			return this.HasSelfGuild() && (this.myGuild.nTargetManorID > 0 || this.myGuild.nTargetCrossManorID > 0);
		}

		// Token: 0x0600B52C RID: 46380 RVA: 0x0028A740 File Offset: 0x00288B40
		public string GetTargetManorName()
		{
			if (!this.HasTargetManor())
			{
				return string.Empty;
			}
			int num = this.myGuild.nTargetManorID;
			if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
			{
				num = this.myGuild.nTargetCrossManorID;
			}
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("加载公会领地表错误，id{0}不存在", new object[]
				{
					num
				});
				return string.Empty;
			}
			return tableItem.Name;
		}

		// Token: 0x0600B52D RID: 46381 RVA: 0x0028A7C4 File Offset: 0x00288BC4
		public static int GetJoinGuildMaxLevel()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(524, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Value;
			}
			return GuildDataManager.iJoinGuildMaxLevel;
		}

		// Token: 0x0600B52E RID: 46382 RVA: 0x0028A800 File Offset: 0x00288C00
		public void BattleInspire()
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildBattleInspireReq cmd = new WorldGuildBattleInspireReq();
				NetManager.Instance().SendCommand<WorldGuildBattleInspireReq>(ServerType.GATE_SERVER, cmd);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildBattleInspireRes>(delegate(WorldGuildBattleInspireRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (this._CheckSelfGuild(true))
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							this.myGuild.nInspire = (int)msgRet.inspire;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInspireSuccess, null, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B52F RID: 46383 RVA: 0x0028A84C File Offset: 0x00288C4C
		public void BattleSignup(int a_nManorID)
		{
			if (!this._CheckSelfGuild(true))
			{
				return;
			}
			if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
			{
				if (!this._CheckPermission(EGuildPermission.StartGuildCrossBattle, EGuildDuty.Invalid))
				{
					return;
				}
			}
			else if (!this._CheckPermission(EGuildPermission.StartGuildBattle, EGuildDuty.Invalid))
			{
				return;
			}
			WorldGuildBattleReq worldGuildBattleReq = new WorldGuildBattleReq();
			worldGuildBattleReq.terrId = (byte)a_nManorID;
			NetManager.Instance().SendCommand<WorldGuildBattleReq>(ServerType.GATE_SERVER, worldGuildBattleReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildBattleRes>(delegate(WorldGuildBattleRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (this._CheckSelfGuild(true))
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else
					{
						if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
						{
							this.myGuild.nTargetCrossManorID = a_nManorID;
						}
						else
						{
							this.myGuild.nTargetManorID = a_nManorID;
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildSignupSuccess, null, null, null, null);
					}
				}
			}, false, 15f, null);
		}

		// Token: 0x0600B530 RID: 46384 RVA: 0x0028A8F0 File Offset: 0x00288CF0
		public void RequestManorInfo(int a_nManorID)
		{
			if (this._CheckSelfGuild(true))
			{
				WorldGuildBattleTerritoryReq worldGuildBattleTerritoryReq = new WorldGuildBattleTerritoryReq();
				worldGuildBattleTerritoryReq.terrId = (byte)a_nManorID;
				NetManager.Instance().SendCommand<WorldGuildBattleTerritoryReq>(ServerType.GATE_SERVER, worldGuildBattleTerritoryReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildBattleTerritoryRes>(delegate(WorldGuildBattleTerritoryRes msgRet)
				{
					if (msgRet == null)
					{
						return;
					}
					if (this._CheckSelfGuild(true))
					{
						if (msgRet.result != 0U)
						{
							SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildManorInfoUpdated, msgRet.info, null, null, null);
						}
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B531 RID: 46385 RVA: 0x0028A942 File Offset: 0x00288D42
		public List<GuildBattleRecord> GetBattleRecords()
		{
			if (this._CheckSelfGuild(true))
			{
				return this.m_arrBattleRecords;
			}
			return null;
		}

		// Token: 0x0600B532 RID: 46386 RVA: 0x0028A958 File Offset: 0x00288D58
		public List<GuildBattleRecord> GetSelfBattleRecords()
		{
			return this.m_arrSelfBattleRecords;
		}

		// Token: 0x0600B533 RID: 46387 RVA: 0x0028A960 File Offset: 0x00288D60
		public void RequestGetBattleReward(int a_nBoxID)
		{
			WorldGuildBattleReceiveReq worldGuildBattleReceiveReq = new WorldGuildBattleReceiveReq();
			worldGuildBattleReceiveReq.boxId = (byte)a_nBoxID;
			NetManager.Instance().SendCommand<WorldGuildBattleReceiveReq>(ServerType.GATE_SERVER, worldGuildBattleReceiveReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildBattleReceiveRes>(delegate(WorldGuildBattleReceiveRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleRewardGetSuccess, msgRet.boxId, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B534 RID: 46388 RVA: 0x0028A9B8 File Offset: 0x00288DB8
		public void RequestRanklist(SortListType a_type, int a_nStart = 0, int a_nCount = 100)
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = (byte)a_type;
			worldSortListReq.start = (ushort)a_nStart;
			worldSortListReq.num = (ushort)a_nCount;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList param = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleRanklistChanged, param, null, null, null);
			}, false, 15f, null);
		}

		// Token: 0x0600B535 RID: 46389 RVA: 0x0028AA28 File Offset: 0x00288E28
		public void RequestGuildManorWeekRanklist()
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 45;
			worldSortListReq.start = 0;
			worldSortListReq.num = 20;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList userData = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildManorRankListFrame>(FrameLayer.Middle, userData, string.Empty);
			}, false, 15f, null);
		}

		// Token: 0x0600B536 RID: 46390 RVA: 0x0028AA98 File Offset: 0x00288E98
		public void RequestSelfRanklist()
		{
			WorldGuildBattleSelfSortListReq cmd = new WorldGuildBattleSelfSortListReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildBattleSelfSortListReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGuildBattleSelfSortListRes>(delegate(WorldGuildBattleSelfSortListRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildSelfRankChanged, msgRet.memberRanking, msgRet.guildRanking, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B537 RID: 46391 RVA: 0x0028AAEC File Offset: 0x00288EEC
		public void StartBattle()
		{
			if (this.m_guildBattleType == GuildBattleType.GBT_CROSS && DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_GUILD_CROSS_BATTLE))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("跨服公会战系统目前已关闭", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
			worldMatchStartReq.type = 2;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
		}

		// Token: 0x0600B538 RID: 46392 RVA: 0x0028AB40 File Offset: 0x00288F40
		public void CancelStartBattle()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B539 RID: 46393 RVA: 0x0028AB62 File Offset: 0x00288F62
		public bool CheckGuildBattleSignUpRedPoint()
		{
			return this.m_bGuildBattleSignUp;
		}

		// Token: 0x0600B53A RID: 46394 RVA: 0x0028AB6A File Offset: 0x00288F6A
		public void SetGuildBattleSignUpRedPoint(bool a_bHas)
		{
			if (a_bHas != this.m_bGuildBattleSignUp)
			{
				this.m_bGuildBattleSignUp = a_bHas;
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
			}
		}

		// Token: 0x0600B53B RID: 46395 RVA: 0x0028AB8A File Offset: 0x00288F8A
		public bool CheckGuildBattleEnterRedPoint()
		{
			return this.m_bGuildBattleEnter;
		}

		// Token: 0x0600B53C RID: 46396 RVA: 0x0028AB92 File Offset: 0x00288F92
		public void SetGuildBattleEnterRedPoint(bool a_bHas)
		{
			if (a_bHas != this.m_bGuildBattleEnter)
			{
				this.m_bGuildBattleEnter = a_bHas;
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
			}
		}

		// Token: 0x0600B53D RID: 46397 RVA: 0x0028ABB4 File Offset: 0x00288FB4
		private void _InitGuildBattle(GuildBattleBaseInfo a_data)
		{
			this._InitGuildBattleRecord(a_data.selfGuildBattleRecord);
			EGuildBattleState guildBattleState = this.m_guildBattleState;
			this.m_guildBattleState = (EGuildBattleState)a_data.guildBattleStatus;
			this.m_guildBattleType = (GuildBattleType)a_data.guildBattleType;
			this.m_nStateEndTime = a_data.guildBattleStatusEndTime;
			this.myGuild.nInspire = (int)a_data.inspire;
			this.myGuild.nSelfManorID = (int)a_data.occupyTerrId;
			this.myGuild.nSelfCrossManorID = (int)a_data.occupyCrossTerrId;
			this.myGuild.nSelfHistoryManorID = (int)a_data.historyTerrId;
			if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
			{
				this.myGuild.nTargetCrossManorID = (int)a_data.enrollTerrId;
			}
			else
			{
				this.myGuild.nTargetManorID = (int)a_data.enrollTerrId;
			}
			this.myGuild.nBattleScore = (int)a_data.guildBattleScore;
			this.m_arrGuildManorInfos = a_data.terrInfos;
			if (this.m_guildBattleState == EGuildBattleState.Invalid)
			{
				this.myGuild.nTargetManorID = 0;
				this.myGuild.nTargetCrossManorID = 0;
				this.myGuild.nInspire = 0;
			}
			this._SetupGuildBattleRedPoint();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleStateChanged, guildBattleState, this.m_guildBattleState, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
		}

		// Token: 0x0600B53E RID: 46398 RVA: 0x0028ACF8 File Offset: 0x002890F8
		private void _ClearGuildBattle()
		{
			this._ClearGuildBattleRecord();
			this.m_bGuildBattleSignUp = false;
			this.m_bGuildBattleEnter = false;
			this.m_arrGuildManorInfos = null;
			EGuildBattleState guildBattleState = this.m_guildBattleState;
			this.m_guildBattleState = EGuildBattleState.Invalid;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleStateChanged, guildBattleState, this.m_guildBattleState, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
		}

		// Token: 0x0600B53F RID: 46399 RVA: 0x0028AD63 File Offset: 0x00289163
		private void _InitGuildBattleRecord(GuildBattleRecord[] a_selfBattleRecords)
		{
			this._ClearGuildBattleRecord();
			if (a_selfBattleRecords != null)
			{
				this.m_arrSelfBattleRecords.AddRange(a_selfBattleRecords);
				this.m_arrBattleRecords.AddRange(a_selfBattleRecords);
			}
		}

		// Token: 0x0600B540 RID: 46400 RVA: 0x0028AD89 File Offset: 0x00289189
		private void _ClearGuildBattleRecord()
		{
			this.m_nLatestRecordID = -1;
			this.m_arrBattleRecords.Clear();
			this.m_arrSelfBattleRecords.Clear();
		}

		// Token: 0x0600B541 RID: 46401 RVA: 0x0028ADA8 File Offset: 0x002891A8
		private void _SetupGuildBattleRedPoint()
		{
			if (this.m_guildBattleState == EGuildBattleState.Signup)
			{
				this.SetGuildBattleSignUpRedPoint(true);
				this.SetGuildBattleEnterRedPoint(false);
			}
			else if (this.m_guildBattleState == EGuildBattleState.Preparing || this.m_guildBattleState == EGuildBattleState.Firing)
			{
				this.SetGuildBattleSignUpRedPoint(false);
				if (this.HasTargetManor())
				{
					this.SetGuildBattleEnterRedPoint(true);
				}
			}
			else
			{
				this.SetGuildBattleSignUpRedPoint(false);
				this.SetGuildBattleEnterRedPoint(false);
			}
		}

		// Token: 0x0600B542 RID: 46402 RVA: 0x0028AE18 File Offset: 0x00289218
		private void _OnNetSyncGuildBattleState(MsgDATA a_msgData)
		{
			if (!this.HasSelfGuild())
			{
				return;
			}
			WorldGuildBattleStatusSync msgData = new WorldGuildBattleStatusSync();
			msgData.decode(a_msgData.bytes);
			EGuildBattleState guildBattleState = this.m_guildBattleState;
			this.m_guildBattleState = (EGuildBattleState)msgData.status;
			this.m_guildBattleType = (GuildBattleType)msgData.type;
			this.m_nStateEndTime = msgData.time;
			this._SetupGuildBattleRedPoint();
			if (this.m_guildBattleState == EGuildBattleState.Preparing)
			{
				if (this.HasTargetManor())
				{
					string text = string.Empty;
					if (this.GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
					{
						text = TR.Value("guild_chat_notify_signup_success", this.GetTargetManorName());
					}
					else if (this.GetGuildBattleType() == GuildBattleType.GBT_CROSS)
					{
						text = TR.Value("guild_chat_notify_signup_success", this.GetTargetManorName());
					}
					else
					{
						text = TR.Value("guild_chat_notify_attackcity_signup_success", this.GetTargetManorName());
					}
					text = text.Replace('[', '{');
					text = text.Replace(']', '}');
					DataManager<ChatManager>.GetInstance().AddLocalGuildChatData(text);
				}
			}
			else if (this.m_guildBattleState == EGuildBattleState.Firing)
			{
				if (DataManager<GuildDataManager>.GetInstance().HasTargetManor())
				{
					string text2 = TR.Value("guild_chat_notify_battle_start", this.GetTargetManorName());
					text2 = text2.Replace('[', '{');
					text2 = text2.Replace(']', '}');
					DataManager<ChatManager>.GetInstance().AddLocalGuildChatData(text2);
				}
			}
			else if (guildBattleState == EGuildBattleState.Firing && this.m_guildBattleState == EGuildBattleState.Invalid)
			{
				int num = this.myGuild.nTargetManorID;
				if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
				{
					num = this.myGuild.nTargetCrossManorID;
				}
				for (int i = 0; i < msgData.endInfo.Length; i++)
				{
					GuildBattleEndInfo guildBattleEndInfo = msgData.endInfo[i];
					if ((int)guildBattleEndInfo.terrId == num)
					{
						if (guildBattleEndInfo.guildName == this.myGuild.strName)
						{
							DataManager<ChatManager>.GetInstance().AddLocalGuildChatData(TR.Value("guild_chat_notify_battle_win", this.GetTargetManorName(), this.GetTargetManorName()));
						}
						else
						{
							DataManager<ChatManager>.GetInstance().AddLocalGuildChatData(TR.Value("guild_chat_notify_battle_lose", this.GetTargetManorName(), guildBattleEndInfo.guildName, this.GetTargetManorName()));
						}
						break;
					}
				}
			}
			if (guildBattleState == EGuildBattleState.Firing && this.m_guildBattleState == EGuildBattleState.LuckyDraw)
			{
				for (int j = 0; j < msgData.endInfo.Length; j++)
				{
					GuildBattleEndInfo guildBattleEndInfo2 = msgData.endInfo[j];
					for (int k = 0; k < this.m_arrGuildManorInfos.Length; k++)
					{
						if (this.m_arrGuildManorInfos[k].terrId == guildBattleEndInfo2.terrId)
						{
							this.m_arrGuildManorInfos[k].guildName = guildBattleEndInfo2.guildName;
							this.m_arrGuildManorInfos[k].serverName = guildBattleEndInfo2.guildServerName;
							break;
						}
					}
				}
				this.myGuild.nTargetManorID = 0;
				this.myGuild.nTargetCrossManorID = 0;
				this.myGuild.nInspire = 0;
				this.m_GuildInspireList.Clear();
				CitySceneTable.eSceneSubType eSceneSubType;
				if (ClientSystemTown.GetCurrentSceneSubType(out eSceneSubType) && (eSceneSubType == CitySceneTable.eSceneSubType.GuildBattle || eSceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle))
				{
					DataManager<NewMessageNoticeManager>.GetInstance().AddNewMessageNoticeWhenNoExist("GuildBattleEnd", null, delegate(NewMessageNoticeData data)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleResultFrame>(FrameLayer.Middle, msgData.endInfo, string.Empty);
						DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNotice(data);
					});
				}
			}
			else
			{
				this._ClearGuildBattleRecord();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleStateChanged, guildBattleState, this.m_guildBattleState, msgData.endInfo, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
		}

		// Token: 0x0600B543 RID: 46403 RVA: 0x0028B1C4 File Offset: 0x002895C4
		private void _OnNetSyncGuildAttackCityRes(MsgDATA a_msgData)
		{
			WorldGuildChallengeInfoSync worldGuildChallengeInfoSync = new WorldGuildChallengeInfoSync();
			worldGuildChallengeInfoSync.decode(a_msgData.bytes);
			this.m_AttackCityData.info = worldGuildChallengeInfoSync.info;
			this.m_AttackCityData.enrollGuildId = worldGuildChallengeInfoSync.enrollGuildId;
			this.m_AttackCityData.enrollGuildName = worldGuildChallengeInfoSync.enrollGuildName;
			this.m_AttackCityData.enrollGuildLevel = worldGuildChallengeInfoSync.enrollGuildLevel;
			this.m_AttackCityData.enrollGuildleaderName = worldGuildChallengeInfoSync.enrollGuildleaderName;
			this.m_AttackCityData.itemId = worldGuildChallengeInfoSync.itemId;
			this.m_AttackCityData.itemNum = worldGuildChallengeInfoSync.itemNum;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildAttackCityInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600B544 RID: 46404 RVA: 0x0028B270 File Offset: 0x00289670
		private void _OnNetSyncBattleRecord(MsgDATA a_msgData)
		{
			if (this.m_guildBattleState != EGuildBattleState.Firing)
			{
				return;
			}
			WorldGuildBattleRecordSync worldGuildBattleRecordSync = new WorldGuildBattleRecordSync();
			worldGuildBattleRecordSync.decode(a_msgData.bytes);
			if (worldGuildBattleRecordSync.record.index > (uint)this.m_nLatestRecordID)
			{
				this.m_nLatestRecordID = (int)worldGuildBattleRecordSync.record.index;
			}
			this.m_arrBattleRecords.Add(worldGuildBattleRecordSync.record);
			if (worldGuildBattleRecordSync.record.loser.id == DataManager<PlayerBaseData>.GetInstance().RoleID || worldGuildBattleRecordSync.record.winner.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.m_arrSelfBattleRecords.Add(worldGuildBattleRecordSync.record);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildBattleRecordSync, worldGuildBattleRecordSync.record, null, null, null);
		}

		// Token: 0x0600B545 RID: 46405 RVA: 0x0028B33C File Offset: 0x0028973C
		private void _OnNetGuildBattleRecordRes(MsgDATA a_msgData)
		{
			WorldGuildBattleRecordRes worldGuildBattleRecordRes = new WorldGuildBattleRecordRes();
			worldGuildBattleRecordRes.decode(a_msgData.bytes);
			if (worldGuildBattleRecordRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildBattleRecordRes.result, string.Empty);
				return;
			}
			this._InitGuildBattleRecord(worldGuildBattleRecordRes.records);
		}

		// Token: 0x0600B546 RID: 46406 RVA: 0x0028B384 File Offset: 0x00289784
		private void _OnGuildChallengeRes(MsgDATA a_msgData)
		{
			WorldGuildChallengeRes worldGuildChallengeRes = new WorldGuildChallengeRes();
			worldGuildChallengeRes.decode(a_msgData.bytes);
			if (worldGuildChallengeRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildChallengeRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("宣战成功!", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B547 RID: 46407 RVA: 0x0028B3CC File Offset: 0x002897CC
		private void _OnGuildBattleInspireRes(MsgDATA a_msgData)
		{
			WorldGuildBattleInspireInfoRes worldGuildBattleInspireInfoRes = new WorldGuildBattleInspireInfoRes();
			worldGuildBattleInspireInfoRes.decode(a_msgData.bytes);
			if (worldGuildBattleInspireInfoRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildBattleInspireInfoRes.result, string.Empty);
				return;
			}
			this.m_GuildInspireList.Clear();
			int terrId = (int)worldGuildBattleInspireInfoRes.terrId;
			for (int i = 0; i < worldGuildBattleInspireInfoRes.inspireInfos.Length; i++)
			{
				this.m_GuildInspireList.Add(worldGuildBattleInspireInfoRes.inspireInfos[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInspireInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600B548 RID: 46408 RVA: 0x0028B458 File Offset: 0x00289858
		private void _OnGuildBattleLotteryRes(MsgDATA a_msgData)
		{
			WorldGuildBattleLotteryRes worldGuildBattleLotteryRes = new WorldGuildBattleLotteryRes();
			int num = 0;
			worldGuildBattleLotteryRes.decode(a_msgData.bytes, ref num);
			if (worldGuildBattleLotteryRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildBattleLotteryRes.result, string.Empty);
				return;
			}
			if (worldGuildBattleLotteryRes.contribution > 0U)
			{
				this.LotteryItem = ItemDataManager.CreateItemDataFromTable(600000009, 100, 0);
				if (this.LotteryItem == null)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("Get Contribution is null in [_OnGuildBattleLotteryRes]", null, string.Empty, false);
					Logger.LogError("Get Contribution is null in [_OnGuildBattleLotteryRes]");
					return;
				}
				this.LotteryItem.Count = (int)worldGuildBattleLotteryRes.contribution;
			}
			else
			{
				List<Item> list = ItemDecoder.Decode(a_msgData.bytes, ref num, a_msgData.bytes.Length, false);
				if (list == null || list.Count <= 0)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("Get nothing in [_OnGuildBattleLotteryRes]", null, string.Empty, false);
					Logger.LogError("Get nothing in [_OnGuildBattleLotteryRes]");
					return;
				}
				this.LotteryItem = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(list[0]);
				if (this.LotteryItem == null)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("Get item is null in [_OnGuildBattleLotteryRes]", null, string.Empty, false);
					Logger.LogError("Get item is null in [_OnGuildBattleLotteryRes]");
					return;
				}
			}
			this.m_bHasLotteryed = true;
			ShowItemsFrameData userData = this.GenerateJarAnimationNeedData();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildLotteryFrame>(FrameLayer.Middle, userData, string.Empty);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildLotteryResultRes, null, null, null, null);
		}

		// Token: 0x0600B549 RID: 46409 RVA: 0x0028B5B0 File Offset: 0x002899B0
		public ShowItemsFrameData GenerateJarAnimationNeedData()
		{
			ShowItemsFrameData showItemsFrameData = new ShowItemsFrameData();
			showItemsFrameData.data = new JarData();
			showItemsFrameData.data.arrRealBonusItems = new List<ItemSimpleData>();
			showItemsFrameData.items = new List<JarBonus>();
			showItemsFrameData.data.eType = JarBonus.eType.MagicJar;
			showItemsFrameData.data.nID = 801;
			showItemsFrameData.data.strName = "公会仓库魔罐";
			showItemsFrameData.data.strJarImagePath = "UI/Image/Icon/Icon_Jar/item_jar_01.png:item_jar_01";
			showItemsFrameData.data.strJarModelPath = "UIFlatten/Prefabs/Jar/EffUI_xiuzhenguan02";
			if (this.storageDatas != null && this.storageDatas.Count > 0)
			{
				for (int i = 0; i < this.storageDatas.Count; i++)
				{
					ItemSimpleData itemSimpleData = new ItemSimpleData();
					itemSimpleData.ItemID = this.storageDatas[i].TableID;
					itemSimpleData.Count = this.storageDatas[i].Count;
					itemSimpleData.Name = this.storageDatas[i].Name;
					showItemsFrameData.data.arrRealBonusItems.Add(itemSimpleData);
				}
			}
			int num = 3;
			if (this.storageDatas != null && this.storageDatas.Count > 2)
			{
				num = 1;
			}
			for (int j = 0; j < num; j++)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(600000009, 100, 0);
				ItemSimpleData itemSimpleData2 = new ItemSimpleData();
				itemSimpleData2.ItemID = 600000009;
				itemSimpleData2.Count = (j + 1) * 100;
				itemSimpleData2.Name = itemData.Name + ((j + 1) * 100).ToString();
				showItemsFrameData.data.arrRealBonusItems.Add(itemSimpleData2);
			}
			for (int k = 0; k < 2; k++)
			{
				if (k == 0)
				{
					showItemsFrameData.items.Add(new JarBonus());
				}
				else
				{
					if (this.LotteryItem == null)
					{
						Logger.LogError("LotteryItem is null when play animation");
					}
					JarBonus jarBonus = new JarBonus();
					jarBonus.item = this.LotteryItem;
					showItemsFrameData.items.Add(jarBonus);
				}
			}
			return showItemsFrameData;
		}

		// Token: 0x0600B54A RID: 46410 RVA: 0x0028B7D3 File Offset: 0x00289BD3
		public void SetDataExchange(ref GuildBattleInspireInfo recive, GuildBattleInspireInfo give)
		{
			recive.playerId = give.playerId;
			recive.playerName = give.playerName;
			recive.inspireNum = give.inspireNum;
		}

		// Token: 0x0600B54B RID: 46411 RVA: 0x0028B7FC File Offset: 0x00289BFC
		public void UpdateInspireInfo(ref Text mInspireLevel, ref Text mCurAttr, ref GameObject mInspireMax, ref Button mInspire, ref Image mInspireIcon, ref Text mInspireCount, ref ComButtonEnbale mEnableInspire, GuildBattleOpenType guildopentype = GuildBattleOpenType.GBOT_INVALID)
		{
			if (this.myGuild == null)
			{
				Logger.LogError("myGuild is null");
				return;
			}
			int nInspire = this.myGuild.nInspire;
			int id = nInspire + 1;
			if (mInspireLevel != null)
			{
				mInspireLevel.text = nInspire.ToString() + "级";
			}
			if (mCurAttr != null)
			{
				mCurAttr.text = this._GetInspireAttrDesc(nInspire);
			}
			GuildInspireTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildInspireTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				if (mInspireMax != null && mInspire != null)
				{
					mInspireMax.CustomActive(true);
					mInspire.gameObject.CustomActive(false);
				}
			}
			else
			{
				if (mInspireMax != null && mInspire != null)
				{
					mInspireMax.CustomActive(false);
					mInspire.gameObject.CustomActive(true);
				}
				if (tableItem.ConsumeItem.Count != 1 || tableItem.CrossConsumeItem.Count != 1)
				{
					Logger.LogError("【公会鼓舞】消耗的道具种类数量错误！！");
				}
				string[] array = new string[]
				{
					string.Empty,
					string.Empty
				};
				string[] array2;
				if (guildopentype == GuildBattleOpenType.GBOT_CROSS)
				{
					array2 = tableItem.CrossConsumeItem[0].Split(new char[]
					{
						'_'
					});
				}
				else if (guildopentype == GuildBattleOpenType.GBOT_NORMAL_CHALLENGE)
				{
					array2 = tableItem.ConsumeItem[0].Split(new char[]
					{
						'_'
					});
				}
				else if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
				{
					array2 = tableItem.CrossConsumeItem[0].Split(new char[]
					{
						'_'
					});
				}
				else
				{
					array2 = tableItem.ConsumeItem[0].Split(new char[]
					{
						'_'
					});
				}
				int a_nTableID = 0;
				if (int.TryParse(array2[0], out a_nTableID))
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nTableID);
					if (mInspireIcon != null)
					{
						ETCImageLoader.LoadSprite(ref mInspireIcon, commonItemTableDataByID.Icon, true);
					}
					if (mInspireCount != null)
					{
						mInspireCount.text = array2[1];
					}
					bool flag = true;
					if (!this.HasTargetManor())
					{
						flag = false;
					}
					if (this.GetGuildBattleType() == GuildBattleType.GBT_NORMAL || this.GetGuildBattleType() == GuildBattleType.GBT_CROSS)
					{
						if (this.GetGuildBattleState() < EGuildBattleState.Signup || this.GetGuildBattleState() > EGuildBattleState.Preparing)
						{
							flag = false;
						}
					}
					else if (this.GetGuildBattleState() != EGuildBattleState.Preparing)
					{
						flag = false;
					}
					if (mEnableInspire != null)
					{
						if (guildopentype == GuildBattleOpenType.GBOT_CROSS)
						{
							mEnableInspire.SetEnable(this.m_guildBattleType == GuildBattleType.GBT_CROSS && flag);
						}
						else if (guildopentype == GuildBattleOpenType.GBOT_NORMAL_CHALLENGE)
						{
							mEnableInspire.SetEnable((this.m_guildBattleType == GuildBattleType.GBT_NORMAL || this.m_guildBattleType == GuildBattleType.GBT_CHALLENGE) && flag);
						}
						else
						{
							mEnableInspire.SetEnable(flag);
						}
					}
				}
			}
		}

		// Token: 0x0600B54C RID: 46412 RVA: 0x0028BAF9 File Offset: 0x00289EF9
		public GuildAttackCityData GetAttackCityData()
		{
			return this.m_AttackCityData;
		}

		// Token: 0x0600B54D RID: 46413 RVA: 0x0028BB01 File Offset: 0x00289F01
		public List<GuildBattleInspireInfo> GetGuildBattleInspireInfoList()
		{
			return this.m_GuildInspireList;
		}

		// Token: 0x0600B54E RID: 46414 RVA: 0x0028BB09 File Offset: 0x00289F09
		public List<FigureStatueInfo> GetTownStatueInfo()
		{
			return this.TownStatueList;
		}

		// Token: 0x0600B54F RID: 46415 RVA: 0x0028BB11 File Offset: 0x00289F11
		public List<FigureStatueInfo> GetGuildGuardStatueInfo()
		{
			return this.GuildGuardStatueList;
		}

		// Token: 0x0600B550 RID: 46416 RVA: 0x0028BB19 File Offset: 0x00289F19
		public bool HasGuildBattleLotteryed()
		{
			return this.m_bHasLotteryed;
		}

		// Token: 0x0600B551 RID: 46417 RVA: 0x0028BB21 File Offset: 0x00289F21
		public bool IsInGuildBattle()
		{
			return this.m_guildBattleState >= EGuildBattleState.Preparing && this.m_guildBattleState <= EGuildBattleState.Firing && this.m_guildBattleType != GuildBattleType.GBT_CROSS;
		}

		// Token: 0x0600B552 RID: 46418 RVA: 0x0028BB4A File Offset: 0x00289F4A
		public void SetLotteryState(byte state)
		{
			if (state == 2)
			{
				this.m_bHasLotteryed = false;
			}
			else
			{
				this.m_bHasLotteryed = true;
			}
		}

		// Token: 0x0600B553 RID: 46419 RVA: 0x0028BB68 File Offset: 0x00289F68
		public void SendGuildBattleLotteryReq()
		{
			if (this.m_guildBattleState != EGuildBattleState.LuckyDraw)
			{
				return;
			}
			WorldGuildBattleLotteryReq cmd = new WorldGuildBattleLotteryReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildBattleLotteryReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B554 RID: 46420 RVA: 0x0028BB98 File Offset: 0x00289F98
		private void _GetInspireCost(out int a_nTableID, out int a_nCount)
		{
			int nInspire = DataManager<GuildDataManager>.GetInstance().myGuild.nInspire;
			int id = nInspire + 1;
			GuildInspireTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildInspireTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.m_guildBattleType == GuildBattleType.GBT_CROSS)
				{
					string[] array = tableItem.CrossConsumeItem[0].Split(new char[]
					{
						'_'
					});
					a_nTableID = int.Parse(array[0]);
					a_nCount = int.Parse(array[1]);
				}
				else
				{
					string[] array2 = tableItem.ConsumeItem[0].Split(new char[]
					{
						'_'
					});
					a_nTableID = int.Parse(array2[0]);
					a_nCount = int.Parse(array2[1]);
				}
			}
			else
			{
				a_nTableID = 0;
				a_nCount = 0;
			}
		}

		// Token: 0x0600B555 RID: 46421 RVA: 0x0028BC58 File Offset: 0x0028A058
		private string _GetInspireAttrDesc(int a_nLevel)
		{
			if (a_nLevel <= 0)
			{
				return TR.Value("guild_manor_inspire_none");
			}
			GuildInspireTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildInspireTable>(a_nLevel, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return TR.Value("guild_manor_inspire_max");
			}
			if (DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.MAIN) < tableItem.NeedGuildLevel)
			{
				return TR.Value("guild_manor_inspire_max");
			}
			string text = string.Empty;
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(127, string.Empty, string.Empty).Value;
			List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(value, (byte)a_nLevel, FightTypeLabel.PVE);
			for (int i = 0; i < skillDesList.Count; i++)
			{
				if (i == 0)
				{
					text = skillDesList[i];
				}
				else
				{
					text += "\n";
					text += skillDesList[i];
				}
			}
			return text;
		}

		// Token: 0x0600B556 RID: 46422 RVA: 0x0028BD3C File Offset: 0x0028A13C
		public void SendInspire()
		{
			if (this.GetGuildBattleType() == GuildBattleType.GBT_NORMAL || this.GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				if (this.GetGuildBattleState() < EGuildBattleState.Signup || this.GetGuildBattleState() > EGuildBattleState.Preparing)
				{
					SystemNotifyManager.SystemNotify(2314014, string.Empty);
					return;
				}
			}
			else if (this.GetGuildBattleState() != EGuildBattleState.Preparing)
			{
				SystemNotifyManager.SystemNotify(2314039, string.Empty);
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			this._GetInspireCost(out costInfo.nMoneyID, out costInfo.nCount);
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				this.BattleInspire();
			}, "common_money_cost", null);
		}

		// Token: 0x0600B557 RID: 46423 RVA: 0x0028BDE0 File Offset: 0x0028A1E0
		public void SwitchToGuildScene()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildMyMainFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMyMainFrame>(null, false);
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(true);
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 6090,
				targetDoorID = 0
			}, false));
		}

		// Token: 0x0600B558 RID: 46424 RVA: 0x0028BEB4 File Offset: 0x0028A2B4
		public static string GetTerrName(int terrID)
		{
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(terrID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Name;
			}
			return "无";
		}

		// Token: 0x0600B559 RID: 46425 RVA: 0x0028BEEC File Offset: 0x0028A2EC
		private GuildDungeonLvlTable GetGuildDungeonLvlTable(int nDungeonID)
		{
			if (this.m_GuildDungeonID2LvTable == null)
			{
				return null;
			}
			if (!this.m_GuildDungeonID2LvTable.ContainsKey(nDungeonID))
			{
				return null;
			}
			GuildDungeonLvlTable guildDungeonLvlTable = this.m_GuildDungeonID2LvTable[nDungeonID];
			if (guildDungeonLvlTable == null)
			{
				return null;
			}
			return guildDungeonLvlTable;
		}

		// Token: 0x0600B55A RID: 46426 RVA: 0x0028BF34 File Offset: 0x0028A334
		public string GetGuildDungeonName(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.dungeonName;
			}
			return string.Empty;
		}

		// Token: 0x0600B55B RID: 46427 RVA: 0x0028BF5C File Offset: 0x0028A35C
		public static int GetDungeonTypeByDungeonID(int iDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonLvlTable(iDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.dungeonType;
			}
			return 0;
		}

		// Token: 0x0600B55C RID: 46428 RVA: 0x0028BF84 File Offset: 0x0028A384
		private static int GetDungeonTypeByFeteLv(int iFeteLv)
		{
			int result = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonTypeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonTypeTable guildDungeonTypeTable = keyValuePair.Value as GuildDungeonTypeTable;
					if (guildDungeonTypeTable != null)
					{
						if (guildDungeonTypeTable.buildLvl >= iFeteLv)
						{
							result = guildDungeonTypeTable.dungeonType;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B55D RID: 46429 RVA: 0x0028BFF6 File Offset: 0x0028A3F6
		public static bool CheckGuildDungeonCanEnter(int iFeteLv, int iDungeonID)
		{
			return GuildDataManager.GetDungeonTypeByFeteLv(iFeteLv) >= GuildDataManager.GetDungeonTypeByDungeonID(iDungeonID);
		}

		// Token: 0x0600B55E RID: 46430 RVA: 0x0028C00C File Offset: 0x0028A40C
		public bool CanLvUpBulilding()
		{
			if (this.checkedLvUpBulilding)
			{
				return false;
			}
			if (this.myGuild == null)
			{
				return false;
			}
			if (this.myGuild.dictBuildings == null)
			{
				return false;
			}
			if (!this.HasPermission(EGuildPermission.UpgradeBuilding, EGuildDuty.Invalid))
			{
				return false;
			}
			foreach (KeyValuePair<GuildBuildingType, GuildBuildingData> keyValuePair in DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings)
			{
				GuildBuildingData value = keyValuePair.Value;
				if (value != null)
				{
					Dictionary<GuildBuildingType, GuildBuildingData>.Enumerator enumerator;
					KeyValuePair<GuildBuildingType, GuildBuildingData> keyValuePair2 = enumerator.Current;
					GuildBuildInfoTable guildBuildInfoTable = this.GetGuildBuildInfoTable(keyValuePair2.Key);
					if (guildBuildInfoTable != null)
					{
						if (guildBuildInfoTable.isOpen)
						{
							if (value.nLevel < value.nMaxLevel)
							{
								if (DataManager<GuildDataManager>.GetInstance().GetMyGuildFund() >= value.nUpgradeCost)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B55F RID: 46431 RVA: 0x0028C100 File Offset: 0x0028A500
		public bool CanActiveEmblem()
		{
			if (this.checkedLvUpEmblem)
			{
				return false;
			}
			List<int> list = null;
			return this.GetEmblemLv() == 0 && this.GetGuildLv() >= this.GetEmblemLvUpGuildLvLimit() && (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.GetEmblemLvUpPlayerLvLimit() && this.GetBuildingLevel(GuildBuildingType.HONOUR) >= this.GetEmblemLvUpHonourLvLimit() && DataManager<GuildDataManager>.GetInstance().IsCostEnoughToLvUpEmblem(ref list);
		}

		// Token: 0x0600B560 RID: 46432 RVA: 0x0028C170 File Offset: 0x0028A570
		public bool CanLvUpEmblem()
		{
			if (this.checkedLvUpEmblem)
			{
				return false;
			}
			List<int> list = null;
			return this.GetEmblemLv() >= 1 && this.GetEmblemLv() < this.GetMaxEmblemLv() && DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR) >= DataManager<GuildDataManager>.GetInstance().GetEmblemNeedHonourLv(this.GetEmblemLv() + 1) && DataManager<GuildDataManager>.GetInstance().IsCostEnoughToLvUpEmblem(ref list);
		}

		// Token: 0x0600B561 RID: 46433 RVA: 0x0028C1DC File Offset: 0x0028A5DC
		private int GetCanSelectBossDiffCount()
		{
			int num = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonTypeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonTypeTable guildDungeonTypeTable = keyValuePair.Value as GuildDungeonTypeTable;
					if (guildDungeonTypeTable != null)
					{
						GuildDungeonTypeTable guildDungeonTypeTable2 = guildDungeonTypeTable;
						bool flag = guildDungeonTypeTable2.buildLvl > GuildDataManager.currentMaxBuildLv;
						if (!flag)
						{
							if (DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.FETE) >= guildDungeonTypeTable2.buildLvl)
							{
								num++;
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600B562 RID: 46434 RVA: 0x0028C27E File Offset: 0x0028A67E
		public bool CanSetBossDiff()
		{
			return !this.checkedSetBossDiff && (this.HasPermission(EGuildPermission.SetGuildDungeonBossDiff, EGuildDuty.Invalid) && this.GetGuildLv() >= GuildDataManager.GetGuildDungeonActivityGuildLvLimit()) && this.GetCanSelectBossDiffCount() >= 1;
		}

		// Token: 0x0600B563 RID: 46435 RVA: 0x0028C2C0 File Offset: 0x0028A6C0
		public int GetGuildDungeonDiffLevel(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.dungeonLvl;
			}
			return 0;
		}

		// Token: 0x0600B564 RID: 46436 RVA: 0x0028C2E4 File Offset: 0x0028A6E4
		public ulong GetGuildDungeonBossMaxHp(uint nDungeonID)
		{
			ulong result = 0UL;
			string s = string.Empty;
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				s = guildDungeonLvlTable.bossBlood;
			}
			ulong.TryParse(s, out result);
			return result;
		}

		// Token: 0x0600B565 RID: 46437 RVA: 0x0028C31C File Offset: 0x0028A71C
		public int GetGuildDungeonLv(uint nDungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>((int)nDungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Level;
			}
			return 0;
		}

		// Token: 0x0600B566 RID: 46438 RVA: 0x0028C350 File Offset: 0x0028A750
		public string GetGuildDungeonIconPath(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.iconPath;
			}
			return string.Empty;
		}

		// Token: 0x0600B567 RID: 46439 RVA: 0x0028C378 File Offset: 0x0028A778
		public string GetGuildDungeonMiniIconPath(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.miniIconPath;
			}
			return string.Empty;
		}

		// Token: 0x0600B568 RID: 46440 RVA: 0x0028C3A0 File Offset: 0x0028A7A0
		public string GetGuildDungeonPlayingDesc(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.playingDesc;
			}
			return string.Empty;
		}

		// Token: 0x0600B569 RID: 46441 RVA: 0x0028C3C8 File Offset: 0x0028A7C8
		public string GetGuildDungeonWeaknessDesc(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.weaknessDesc;
			}
			return string.Empty;
		}

		// Token: 0x0600B56A RID: 46442 RVA: 0x0028C3F0 File Offset: 0x0028A7F0
		public string GetGuildDungeonRecommendDesc(uint nDungeonID)
		{
			GuildDungeonLvlTable guildDungeonLvlTable = this.GetGuildDungeonLvlTable((int)nDungeonID);
			if (guildDungeonLvlTable != null)
			{
				return guildDungeonLvlTable.recommendDesc;
			}
			return string.Empty;
		}

		// Token: 0x0600B56B RID: 46443 RVA: 0x0028C418 File Offset: 0x0028A818
		private static int _getCellValue(Type type, string filed, BuffTable buf, int lv)
		{
			try
			{
				PropertyInfo property = type.GetProperty(filed, BindingFlags.Instance | BindingFlags.Public);
				object value = property.GetValue(buf, null);
				if (value is UnionCell)
				{
					UnionCell unionCell = value as UnionCell;
					if (unionCell != null)
					{
						return TableManager.GetValueFromUnionCell(unionCell, lv, true);
					}
				}
				else if (value is int)
				{
					return (int)value;
				}
			}
			catch
			{
			}
			return -1;
		}

		// Token: 0x0600B56C RID: 46444 RVA: 0x0028C498 File Offset: 0x0028A898
		private static int _getFinalValue(BuffDrugConfigInfoTable.eValueType type, int val)
		{
			if (type != BuffDrugConfigInfoTable.eValueType.Rate1000)
			{
				return val;
			}
			return val / 10;
		}

		// Token: 0x0600B56D RID: 46445 RVA: 0x0028C4AC File Offset: 0x0028A8AC
		private static int GetGuildDungeonBufMaxLv(int iBufID)
		{
			int result = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ItemBuffTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ItemBuffTable itemBuffTable = keyValuePair.Value as ItemBuffTable;
					if (itemBuffTable != null)
					{
						if (itemBuffTable.buffId == iBufID)
						{
							result = itemBuffTable.buffMaxLvl;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B56E RID: 46446 RVA: 0x0028C524 File Offset: 0x0028A924
		public static string GetBuffAddUpInfo(int iBufID, int iBufLv)
		{
			string text = string.Empty;
			BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(iBufID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			BuffType type = (BuffType)tableItem.Type;
			Type type2 = tableItem.GetType();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<BuffDrugConfigInfoTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				BuffDrugConfigInfoTable buffDrugConfigInfoTable = keyValuePair.Value as BuffDrugConfigInfoTable;
				if (buffDrugConfigInfoTable != null)
				{
					int val = GuildDataManager._getCellValue(type2, buffDrugConfigInfoTable.Filed, tableItem, iBufLv);
					int num = GuildDataManager._getFinalValue(buffDrugConfigInfoTable.ValueType, val);
					if (num > 0)
					{
						text = string.Format(TR.Value(buffDrugConfigInfoTable.Filed), num);
					}
				}
			}
			if (iBufLv == GuildDataManager.GetGuildDungeonBufMaxLv(iBufID))
			{
				text += "(Max)";
			}
			return text;
		}

		// Token: 0x0600B56F RID: 46447 RVA: 0x0028C608 File Offset: 0x0028AA08
		private List<int> GetOpenedGuildDungeonIDList()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			if (this.m_GuildDungeonActivityData != null && this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos != null)
			{
				for (int i = 0; i < this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos.Count; i++)
				{
					list.Add((int)this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos[i].nDungeonID);
				}
				if (this.m_GuildDungeonActivityData != null && this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos != null)
				{
					for (int j = 0; j < this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Count; j++)
					{
						list.Add((int)this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos[j].nDungeonID);
					}
					int num = 0;
					for (int k = 0; k < this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Count; k++)
					{
						if (this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos[k].nOddHp == 0UL)
						{
							num++;
						}
					}
					if (num == this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Count && this.m_GuildDungeonActivityData != null && this.m_GuildDungeonActivityData.bossDungeonDamageInfos.Count > 0)
					{
						list.Add((int)this.m_GuildDungeonActivityData.bossDungeonDamageInfos[0].nDungeonID);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B570 RID: 46448 RVA: 0x0028C794 File Offset: 0x0028AB94
		public bool IsGuildDungeonMap(int nDungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(nDungeonID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON;
		}

		// Token: 0x0600B571 RID: 46449 RVA: 0x0028C7CC File Offset: 0x0028ABCC
		public bool IsGuildDungeonOpen(int nDungeonID)
		{
			List<int> openedGuildDungeonIDList = this.GetOpenedGuildDungeonIDList();
			return openedGuildDungeonIDList != null && openedGuildDungeonIDList.Contains(nDungeonID);
		}

		// Token: 0x0600B572 RID: 46450 RVA: 0x0028C7F0 File Offset: 0x0028ABF0
		public bool IsShowChestModel()
		{
			return GuildDataManager.CheckActivityLimit() && this.m_GuildDungeonActivityData != null && this.m_GuildDungeonActivityData.nActivityState != 0U && this.m_GuildDungeonActivityData.nActivityState != 1U && this.m_GuildDungeonActivityData.nBossOddHp == 0UL;
		}

		// Token: 0x0600B573 RID: 46451 RVA: 0x0028C850 File Offset: 0x0028AC50
		public void TryGetGuildDungeonActivityChestAward()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				if (guildDungeonActivityData.bGetReward)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonHaveGetReward"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonLotteryReq();
				}
			}
		}

		// Token: 0x0600B574 RID: 46452 RVA: 0x0028C89C File Offset: 0x0028AC9C
		public static bool CheckActivityLimit()
		{
			if (DataManager<GuildDataManager>.GetInstance().myGuild == null)
			{
				return false;
			}
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_GUILD_DUNGEON))
			{
				return false;
			}
			int guildDungeonActivityGuildLvLimit = GuildDataManager.GetGuildDungeonActivityGuildLvLimit();
			int guildDungeonActivityPlayerLvLimit = GuildDataManager.GetGuildDungeonActivityPlayerLvLimit();
			return DataManager<GuildDataManager>.GetInstance().myGuild.nLevel >= guildDungeonActivityGuildLvLimit && (int)DataManager<PlayerBaseData>.GetInstance().Level >= guildDungeonActivityPlayerLvLimit;
		}

		// Token: 0x0600B575 RID: 46453 RVA: 0x0028C904 File Offset: 0x0028AD04
		public GuildDungeonStatus GetGuildDungeonActivityStatus()
		{
			if (this.m_GuildDungeonActivityData == null)
			{
				return GuildDungeonStatus.GUILD_DUNGEON_END;
			}
			return (GuildDungeonStatus)this.m_GuildDungeonActivityData.nActivityState;
		}

		// Token: 0x0600B576 RID: 46454 RVA: 0x0028C920 File Offset: 0x0028AD20
		public bool IsGuildDungeonActivityOpen()
		{
			GuildDungeonStatus guildDungeonActivityStatus = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus();
			return GuildDataManager.CheckActivityLimit() && (guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_PREPARE || guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_START || guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_REWARD);
		}

		// Token: 0x0600B577 RID: 46455 RVA: 0x0028C95C File Offset: 0x0028AD5C
		public static int GetGuildDungeonActivityPlayerLvLimit()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(470, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Value;
			}
			return 1;
		}

		// Token: 0x0600B578 RID: 46456 RVA: 0x0028C994 File Offset: 0x0028AD94
		public static int GetGuildDungeonActivityGuildLvLimit()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(469, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Value;
			}
			return 1;
		}

		// Token: 0x0600B579 RID: 46457 RVA: 0x0028C9CC File Offset: 0x0028ADCC
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			int guildDungeonActivityPlayerLvLimit = GuildDataManager.GetGuildDungeonActivityPlayerLvLimit();
			if (guildDungeonActivityPlayerLvLimit > 0 && iPreLv < guildDungeonActivityPlayerLvLimit && iCurLv >= guildDungeonActivityPlayerLvLimit)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
			}
			this.UpdateGuildEmblemRedPoint();
		}

		// Token: 0x0600B57A RID: 46458 RVA: 0x0028CA10 File Offset: 0x0028AE10
		private void OnGuildLevelChanged(int iPreLv, int iCurLv)
		{
			int guildDungeonActivityGuildLvLimit = GuildDataManager.GetGuildDungeonActivityGuildLvLimit();
			if (guildDungeonActivityGuildLvLimit > 0 && iPreLv < guildDungeonActivityGuildLvLimit && iCurLv >= guildDungeonActivityGuildLvLimit)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
			}
			this.UpdateGuildEmblemRedPoint();
			this.UpdateGuildSetBossDiffRedPoint();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateGuildEmblemLvUpEntry, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildUpgradeBuildingSuccess, null, null, null, null);
		}

		// Token: 0x0600B57B RID: 46459 RVA: 0x0028CA80 File Offset: 0x0028AE80
		private void OnUpdateActivityNotice(GuildDungeonStatus oldState, GuildDungeonStatus newState)
		{
			NotifyInfo a_info = new NotifyInfo
			{
				type = 8U
			};
			if (oldState == GuildDungeonStatus.GUILD_DUNGEON_END && newState != GuildDungeonStatus.GUILD_DUNGEON_END)
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().AddActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().AddActivityNotice(a_info);
			}
			else if (oldState != GuildDungeonStatus.GUILD_DUNGEON_END && newState == GuildDungeonStatus.GUILD_DUNGEON_END)
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(a_info);
			}
		}

		// Token: 0x17001AE8 RID: 6888
		// (get) Token: 0x0600B57C RID: 46460 RVA: 0x0028CAE5 File Offset: 0x0028AEE5
		// (set) Token: 0x0600B57D RID: 46461 RVA: 0x0028CAED File Offset: 0x0028AEED
		public bool IsShowFireworks { get; set; }

		// Token: 0x17001AE9 RID: 6889
		// (get) Token: 0x0600B57E RID: 46462 RVA: 0x0028CAF6 File Offset: 0x0028AEF6
		// (set) Token: 0x0600B57F RID: 46463 RVA: 0x0028CAFE File Offset: 0x0028AEFE
		private int ActivityNotifyUIOpenCount { get; set; }

		// Token: 0x0600B580 RID: 46464 RVA: 0x0028CB07 File Offset: 0x0028AF07
		private void OpenNotifyUI()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonActivityOpenNotifyFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B581 RID: 46465 RVA: 0x0028CB1C File Offset: 0x0028AF1C
		public static bool IsGuildTeamDungeonID(int iTeamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iTeamDungeonID, string.Empty, string.Empty);
			return tableItem != null && DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(tableItem.DungeonID);
		}

		// Token: 0x0600B582 RID: 46466 RVA: 0x0028CB58 File Offset: 0x0028AF58
		public static bool IsGuildDungeonMapScence()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			return clientSystemTown != null && clientSystemTown.CurrentSceneID == 6031;
		}

		// Token: 0x0600B583 RID: 46467 RVA: 0x0028CB90 File Offset: 0x0028AF90
		public static bool IsInGuildAreanScence()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Guild)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B584 RID: 46468 RVA: 0x0028CBE4 File Offset: 0x0028AFE4
		public static void FliterTeamDungeonID(ref List<int> Fliter, ref Dictionary<int, List<int>> SecFliterDict)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < Fliter.Count; i++)
			{
				if (SecFliterDict.ContainsKey(Fliter[i]))
				{
					List<int> list2 = SecFliterDict[Fliter[i]];
					for (int j = 0; j < list2.Count; j++)
					{
						TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list2[j], string.Empty, string.Empty);
						if (tableItem != null)
						{
							DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
								{
									list.Add(Fliter[i]);
									break;
								}
							}
						}
					}
				}
			}
			if (GuildDataManager.IsInGuildAreanScence() || GuildDataManager.IsGuildDungeonMapScence())
			{
				Fliter.Clear();
				Fliter.AddRange(list);
				for (int k = 0; k < Fliter.Count; k++)
				{
					if (SecFliterDict.ContainsKey(Fliter[k]))
					{
						SecFliterDict[Fliter[k]] = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonIDList();
					}
				}
			}
			else
			{
				int l = 0;
				while (l < Fliter.Count)
				{
					if (list.Contains(Fliter[l]))
					{
						Fliter.RemoveAt(l);
					}
					else
					{
						l++;
					}
				}
				for (int m = 0; m < list.Count; m++)
				{
					if (SecFliterDict.ContainsKey(list[m]))
					{
						SecFliterDict.Remove(list[m]);
					}
				}
			}
		}

		// Token: 0x0600B585 RID: 46469 RVA: 0x0028CDB0 File Offset: 0x0028B1B0
		public List<int> GetGuildDungeonIDList()
		{
			List<int> list = new List<int>();
			if (this.m_GuildDungeonActivityData != null)
			{
				if (this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos != null)
				{
					for (int i = 0; i < this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos.Count; i++)
					{
						int key = (int)this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos[i].nDungeonID;
						if (this.guildDungeonID2TeamDungeonID != null && this.guildDungeonID2TeamDungeonID.ContainsKey(key))
						{
							list.Add(this.guildDungeonID2TeamDungeonID[key]);
						}
					}
				}
				if (this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos != null)
				{
					for (int j = 0; j < this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Count; j++)
					{
						int key2 = (int)this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos[j].nDungeonID;
						if (this.guildDungeonID2TeamDungeonID != null && this.guildDungeonID2TeamDungeonID.ContainsKey(key2))
						{
							list.Add(this.guildDungeonID2TeamDungeonID[key2]);
						}
					}
				}
				if (this.m_GuildDungeonActivityData.bossDungeonDamageInfos != null)
				{
					for (int k = 0; k < this.m_GuildDungeonActivityData.bossDungeonDamageInfos.Count; k++)
					{
						int key3 = (int)this.m_GuildDungeonActivityData.bossDungeonDamageInfos[k].nDungeonID;
						if (this.guildDungeonID2TeamDungeonID != null && this.guildDungeonID2TeamDungeonID.ContainsKey(key3))
						{
							list.Add(this.guildDungeonID2TeamDungeonID[key3]);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B586 RID: 46470 RVA: 0x0028CF40 File Offset: 0x0028B340
		private void RequestActivityData()
		{
			if (GuildDataManager.IsInGuildAreanScence() || GuildDataManager.IsGuildDungeonMapScence())
			{
				GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
				if (guildDungeonActivityData != null && guildDungeonActivityData.nActivityState != 0U && GuildDataManager.CheckActivityLimit())
				{
					DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonInfoReq();
					DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonCopyReq();
				}
			}
		}

		// Token: 0x0600B587 RID: 46471 RVA: 0x0028CF9C File Offset: 0x0028B39C
		public bool IsIDOpened(ulong id)
		{
			if (string.IsNullOrEmpty(this.jsonText))
			{
				return false;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return false;
			}
			string text = id.ToString();
			return jsonData.ContainsKey(text) && jsonData[text].IsBoolean && (bool)jsonData[text];
		}

		// Token: 0x0600B588 RID: 46472 RVA: 0x0028D00C File Offset: 0x0028B40C
		public void ClearIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = false;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600B589 RID: 46473 RVA: 0x0028D09C File Offset: 0x0028B49C
		public void SetIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = true;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600B58A RID: 46474 RVA: 0x0028D12C File Offset: 0x0028B52C
		public int GetDailySendRedPacketMaxCount()
		{
			return Utility.GetSystemValueFromTable(SystemValueTable.eType.SVT_GUILD_BUY_REDPACKET_TIME);
		}

		// Token: 0x0600B58B RID: 46475 RVA: 0x0028D138 File Offset: 0x0028B538
		public int GetDailySendRedPacketLeftCount()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("guild_pay_rp");
			int num = this.GetDailySendRedPacketMaxCount() - count;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0600B58C RID: 46476 RVA: 0x0028D168 File Offset: 0x0028B568
		public void SendWorldGuildDungeonDamageRankReq()
		{
			WorldGuildDungeonDamageRankReq cmd = new WorldGuildDungeonDamageRankReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildDungeonDamageRankReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B58D RID: 46477 RVA: 0x0028D18C File Offset: 0x0028B58C
		public void SendWorldGuildDungeonInfoReq()
		{
			WorldGuildDungeonInfoReq cmd = new WorldGuildDungeonInfoReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildDungeonInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B58E RID: 46478 RVA: 0x0028D1B0 File Offset: 0x0028B5B0
		public void SendWorldGuildDungeonCopyReq()
		{
			WorldGuildDungeonCopyReq cmd = new WorldGuildDungeonCopyReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildDungeonCopyReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B58F RID: 46479 RVA: 0x0028D1D4 File Offset: 0x0028B5D4
		public void SendWorldGuildDungeonLotteryReq()
		{
			WorldGuildDungeonLotteryReq cmd = new WorldGuildDungeonLotteryReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildDungeonLotteryReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B590 RID: 46480 RVA: 0x0028D1F8 File Offset: 0x0028B5F8
		public void SendWorldGuildDungeonStatueReq()
		{
			WorldGuildDungeonStatueReq cmd = new WorldGuildDungeonStatueReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildDungeonStatueReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B591 RID: 46481 RVA: 0x0028D21C File Offset: 0x0028B61C
		public void SendWorldGuildSetJoinLevelReq(uint joinLv)
		{
			WorldGuildSetJoinLevelReq worldGuildSetJoinLevelReq = new WorldGuildSetJoinLevelReq();
			NetManager netManager = NetManager.Instance();
			worldGuildSetJoinLevelReq.joinLevel = joinLv;
			netManager.SendCommand<WorldGuildSetJoinLevelReq>(ServerType.GATE_SERVER, worldGuildSetJoinLevelReq);
		}

		// Token: 0x0600B592 RID: 46482 RVA: 0x0028D248 File Offset: 0x0028B648
		public void SendWorldGuildSetDungeonTypeReq(uint iDiffType)
		{
			WorldGuildSetDungeonTypeReq worldGuildSetDungeonTypeReq = new WorldGuildSetDungeonTypeReq();
			NetManager netManager = NetManager.Instance();
			worldGuildSetDungeonTypeReq.dungeonType = iDiffType;
			netManager.SendCommand<WorldGuildSetDungeonTypeReq>(ServerType.GATE_SERVER, worldGuildSetDungeonTypeReq);
		}

		// Token: 0x0600B593 RID: 46483 RVA: 0x0028D274 File Offset: 0x0028B674
		public void SendWorldGuildAuctionItemReq(GuildAuctionType guildAuctionType)
		{
			WorldGuildAuctionItemReq worldGuildAuctionItemReq = new WorldGuildAuctionItemReq();
			NetManager netManager = NetManager.Instance();
			worldGuildAuctionItemReq.type = (uint)guildAuctionType;
			netManager.SendCommand<WorldGuildAuctionItemReq>(ServerType.GATE_SERVER, worldGuildAuctionItemReq);
		}

		// Token: 0x0600B594 RID: 46484 RVA: 0x0028D2A0 File Offset: 0x0028B6A0
		public void SendWorldGuildAuctionFixReq(ulong itemGUID)
		{
			WorldGuildAuctionFixReq worldGuildAuctionFixReq = new WorldGuildAuctionFixReq();
			NetManager netManager = NetManager.Instance();
			worldGuildAuctionFixReq.guid = itemGUID;
			netManager.SendCommand<WorldGuildAuctionFixReq>(ServerType.GATE_SERVER, worldGuildAuctionFixReq);
		}

		// Token: 0x0600B595 RID: 46485 RVA: 0x0028D2CC File Offset: 0x0028B6CC
		public void SendWorldGuildAuctionBidReq(ulong itemGUID, ulong price)
		{
			WorldGuildAuctionBidReq worldGuildAuctionBidReq = new WorldGuildAuctionBidReq();
			NetManager netManager = NetManager.Instance();
			worldGuildAuctionBidReq.guid = itemGUID;
			worldGuildAuctionBidReq.bidPrice = (uint)price;
			netManager.SendCommand<WorldGuildAuctionBidReq>(ServerType.GATE_SERVER, worldGuildAuctionBidReq);
		}

		// Token: 0x0600B596 RID: 46486 RVA: 0x0028D300 File Offset: 0x0028B700
		public void SendWorldGuildGetTerrDayRewardReq()
		{
			WorldGuildGetTerrDayRewardReq cmd = new WorldGuildGetTerrDayRewardReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildGetTerrDayRewardReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B597 RID: 46487 RVA: 0x0028D324 File Offset: 0x0028B724
		public void SendWorldGuildEmblemUpReq()
		{
			WorldGuildEmblemUpReq cmd = new WorldGuildEmblemUpReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildEmblemUpReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B598 RID: 46488 RVA: 0x0028D348 File Offset: 0x0028B748
		private void _OnWorldGuildAuctionItemRes(MsgDATA msg)
		{
			WorldGuildAuctionItemRes worldGuildAuctionItemRes = new WorldGuildAuctionItemRes();
			worldGuildAuctionItemRes.decode(msg.bytes);
			bool bAuctionOpen = false;
			Action<List<GuildDataManager.GuildAuctionItemData>, GuildAuctionItem[]> action = delegate(List<GuildDataManager.GuildAuctionItemData> auctionItemDatas, GuildAuctionItem[] auctionItemList)
			{
				if (auctionItemDatas == null || auctionItemList == null)
				{
					return;
				}
				auctionItemDatas.Clear();
				for (int j = 0; j < auctionItemList.Length; j++)
				{
					GuildDataManager.GuildAuctionItemData guildAuctionItemData2 = new GuildDataManager.GuildAuctionItemData();
					GuildAuctionItem guildAuctionItem = auctionItemList[j];
					if (guildAuctionItemData2 != null && guildAuctionItem != null)
					{
						guildAuctionItemData2.guid = guildAuctionItem.guid;
						if (guildAuctionItem.itemList != null && guildAuctionItem.itemList.Length >= 1)
						{
							guildAuctionItemData2.itemData0.ID = (int)guildAuctionItem.itemList[0].id;
							guildAuctionItemData2.itemData0.Num = (int)guildAuctionItem.itemList[0].num;
						}
						if (guildAuctionItem.itemList != null && guildAuctionItem.itemList.Length >= 2)
						{
							guildAuctionItemData2.itemData1.ID = (int)guildAuctionItem.itemList[1].id;
							guildAuctionItemData2.itemData1.Num = (int)guildAuctionItem.itemList[1].num;
						}
						guildAuctionItemData2.curbiddingPrice = (ulong)guildAuctionItem.curPrice;
						guildAuctionItemData2.nextBiddingPrice = (ulong)guildAuctionItem.bidPrice;
						guildAuctionItemData2.buyNowPrice = (ulong)guildAuctionItem.fixPrice;
						guildAuctionItemData2.statusEndStamp = (ulong)guildAuctionItem.endTime;
						guildAuctionItemData2.bidRoleId = guildAuctionItem.bidRoleId;
						GuildAuctionItemState state = (GuildAuctionItemState)guildAuctionItem.state;
						if (state == GuildAuctionItemState.GAI_STATE_PREPARE)
						{
							guildAuctionItemData2.auctionItemState = GuildDataManager.AuctionItemState.Prepare;
						}
						else if (state == GuildAuctionItemState.GAI_STATE_NORMAL)
						{
							guildAuctionItemData2.auctionItemState = GuildDataManager.AuctionItemState.InAuction;
						}
						else if (state == GuildAuctionItemState.GAI_STATE_DEAL)
						{
							guildAuctionItemData2.auctionItemState = GuildDataManager.AuctionItemState.SoldOut;
						}
						else if (state == GuildAuctionItemState.GAI_STATE_ABORATION)
						{
							guildAuctionItemData2.auctionItemState = GuildDataManager.AuctionItemState.AbortiveAuction;
						}
						if (state == GuildAuctionItemState.GAI_STATE_NORMAL)
						{
							bAuctionOpen = true;
						}
						auctionItemDatas.Add(guildAuctionItemData2);
					}
				}
			};
			if (worldGuildAuctionItemRes.type == 1U)
			{
				action(this.guildAuctionItemDatasForGuildAuction, worldGuildAuctionItemRes.auctionItemList);
				this.guildAuctionItemDatasForGuildAuction.Sort(new Comparison<GuildDataManager.GuildAuctionItemData>(this.SortGuildAuctionItemData));
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildDungeonAuctionFrame>(null))
				{
					bool flag = false;
					for (int i = 0; i < this.guildAuctionItemDatasForGuildAuction.Count; i++)
					{
						GuildDataManager.GuildAuctionItemData guildAuctionItemData = this.guildAuctionItemDatasForGuildAuction[i];
						if (guildAuctionItemData != null)
						{
							if (guildAuctionItemData.auctionItemState != GuildDataManager.AuctionItemState.AbortiveAuction && guildAuctionItemData.auctionItemState != GuildDataManager.AuctionItemState.SoldOut)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonAuctionFrame>(FrameLayer.Middle, GuildDungeonAuctionFrame.FrameType.GuildAuction, string.Empty);
					}
					else
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonAuctionFrame>(FrameLayer.Middle, GuildDungeonAuctionFrame.FrameType.WorldAuction, string.Empty);
					}
				}
			}
			else if (worldGuildAuctionItemRes.type == 2U)
			{
				action(this.guildAuctionItemDatasForWorldAuction, worldGuildAuctionItemRes.auctionItemList);
				this.guildAuctionItemDatasForWorldAuction.Sort(new Comparison<GuildDataManager.GuildAuctionItemData>(this.SortGuildAuctionItemData));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionItemsUpdate, (GuildAuctionType)worldGuildAuctionItemRes.type, null, null, null);
		}

		// Token: 0x0600B599 RID: 46489 RVA: 0x0028D4B4 File Offset: 0x0028B8B4
		private int SortGuildAuctionItemData(GuildDataManager.GuildAuctionItemData x, GuildDataManager.GuildAuctionItemData y)
		{
			if (x == null || y == null)
			{
				return 0;
			}
			if (GuildDataManager.states == null)
			{
				return 0;
			}
			int num = GuildDataManager.states.FindIndex((GuildDataManager.AuctionItemState state) => state == x.auctionItemState);
			int value = GuildDataManager.states.FindIndex((GuildDataManager.AuctionItemState state) => state == y.auctionItemState);
			return num.CompareTo(value);
		}

		// Token: 0x0600B59A RID: 46490 RVA: 0x0028D530 File Offset: 0x0028B930
		private void _OnWorldGuildAuctionNotify(MsgDATA msg)
		{
			WorldGuildAuctionNotify worldGuildAuctionNotify = new WorldGuildAuctionNotify();
			worldGuildAuctionNotify.decode(msg.bytes);
			if (worldGuildAuctionNotify.type == 1U)
			{
				this.IsGuildAuctionOpen = (worldGuildAuctionNotify.isOpen != 0U);
				if (!this.IsGuildAuctionOpen)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildDungeonAuctionFrame>(null, false);
				}
				this.HaveNewGuildAuctonItem = (worldGuildAuctionNotify.isOpen != 0U);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionAddNewItem, null, null, null, null);
			}
			else if (worldGuildAuctionNotify.type == 2U)
			{
				this.IsGuildWorldAuctionOpen = (worldGuildAuctionNotify.isOpen != 0U);
				if (!this.IsGuildWorldAuctionOpen)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildDungeonAuctionFrame>(null, false);
				}
				this.HaveNewWorldAuctonItem = (worldGuildAuctionNotify.isOpen != 0U);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionAddNewItem, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionStateUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonWorldAuctionStateUpdate, null, null, null, null);
		}

		// Token: 0x0600B59B RID: 46491 RVA: 0x0028D630 File Offset: 0x0028BA30
		private void _OnWorldGuildAuctionFixRes(MsgDATA msg)
		{
			WorldGuildAuctionFixRes worldGuildAuctionFixRes = new WorldGuildAuctionFixRes();
			worldGuildAuctionFixRes.decode(msg.bytes);
			if (worldGuildAuctionFixRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildAuctionFixRes.retCode, string.Empty);
				return;
			}
			GuildDungeonAuctionFrame.RequestGuildAuctionItem();
		}

		// Token: 0x0600B59C RID: 46492 RVA: 0x0028D670 File Offset: 0x0028BA70
		private void _OnWorldGuildAuctionBidRes(MsgDATA msg)
		{
			WorldGuildAuctionBidRes worldGuildAuctionBidRes = new WorldGuildAuctionBidRes();
			worldGuildAuctionBidRes.decode(msg.bytes);
			if (worldGuildAuctionBidRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildAuctionBidRes.retCode, string.Empty);
				if (worldGuildAuctionBidRes.retCode == 2318003U)
				{
					GuildDungeonAuctionFrame.RequestGuildAuctionItem();
				}
				return;
			}
			GuildDungeonAuctionFrame.RequestGuildAuctionItem();
		}

		// Token: 0x0600B59D RID: 46493 RVA: 0x0028D6C8 File Offset: 0x0028BAC8
		private void _OnWorldGuildEmblemUpRes(MsgDATA msg)
		{
			WorldGuildEmblemUpRes worldGuildEmblemUpRes = new WorldGuildEmblemUpRes();
			worldGuildEmblemUpRes.decode(msg.bytes);
			if (worldGuildEmblemUpRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildEmblemUpRes.result, string.Empty);
				return;
			}
			if (this.myGuild != null)
			{
				this.myGuild.emblemLevel = worldGuildEmblemUpRes.emblemLevel;
			}
			this.UpdateGuildEmblemRedPoint();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildEmblemLevelUp, null, null, null, null);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildEmblemLvUpResultFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B59E RID: 46494 RVA: 0x0028D74C File Offset: 0x0028BB4C
		private void _OnWorldGuildDungeonDamageRankRes(MsgDATA msg)
		{
			WorldGuildDungeonDamageRankRes worldGuildDungeonDamageRankRes = new WorldGuildDungeonDamageRankRes();
			worldGuildDungeonDamageRankRes.decode(msg.bytes);
			if (this.m_DungeonRankInfoList != null)
			{
				this.m_DungeonRankInfoList.Clear();
				for (int i = 0; i < worldGuildDungeonDamageRankRes.damageVec.Length; i++)
				{
					GuildDataManager.DungeonDamageRankInfo dungeonDamageRankInfo = new GuildDataManager.DungeonDamageRankInfo();
					dungeonDamageRankInfo.nRank = worldGuildDungeonDamageRankRes.damageVec[i].rank;
					dungeonDamageRankInfo.nPlayerID = worldGuildDungeonDamageRankRes.damageVec[i].playerId;
					dungeonDamageRankInfo.nDamage = worldGuildDungeonDamageRankRes.damageVec[i].damageVal;
					dungeonDamageRankInfo.strPlayerName = worldGuildDungeonDamageRankRes.damageVec[i].playerName;
					this.m_DungeonRankInfoList.Add(dungeonDamageRankInfo);
					if (this.m_MyDungeonDamageRankInfo != null && dungeonDamageRankInfo.nPlayerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						this.m_MyDungeonDamageRankInfo.nRank = dungeonDamageRankInfo.nRank;
						this.m_MyDungeonDamageRankInfo.nPlayerID = dungeonDamageRankInfo.nPlayerID;
						this.m_MyDungeonDamageRankInfo.nDamage = dungeonDamageRankInfo.nDamage;
						this.m_MyDungeonDamageRankInfo.strPlayerName = dungeonDamageRankInfo.strPlayerName;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonDamageRank, null, null, null, null);
		}

		// Token: 0x0600B59F RID: 46495 RVA: 0x0028D870 File Offset: 0x0028BC70
		private void _OnWorldGuildDungeonInfoRes(MsgDATA msg)
		{
			WorldGuildDungeonInfoRes worldGuildDungeonInfoRes = new WorldGuildDungeonInfoRes();
			worldGuildDungeonInfoRes.decode(msg.bytes);
			if (worldGuildDungeonInfoRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildDungeonInfoRes.result, string.Empty);
				return;
			}
			if (this.m_GuildDungeonActivityData != null)
			{
				uint nActivityState = this.m_GuildDungeonActivityData.nActivityState;
				uint dungeonStatus = worldGuildDungeonInfoRes.dungeonStatus;
				ulong nBossOddHp = this.m_GuildDungeonActivityData.nBossOddHp;
				if (worldGuildDungeonInfoRes.bossBlood.Length == 4)
				{
					if (this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos != null)
					{
						this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Clear();
					}
					for (int i = 0; i < worldGuildDungeonInfoRes.bossBlood.Length; i++)
					{
						GuildDungeonBossBlood guildDungeonBossBlood = worldGuildDungeonInfoRes.bossBlood[i];
						int guildDungeonDiffLevel = this.GetGuildDungeonDiffLevel(guildDungeonBossBlood.dungeonId);
						if (guildDungeonDiffLevel == 3)
						{
							this.m_GuildDungeonActivityData.nBossMaxHp = this.GetGuildDungeonBossMaxHp(guildDungeonBossBlood.dungeonId);
							this.m_GuildDungeonActivityData.nBossOddHp = guildDungeonBossBlood.oddBlood;
							this.m_GuildDungeonActivityData.nVerifyBlood = guildDungeonBossBlood.verifyBlood;
						}
						else if (guildDungeonDiffLevel == 2)
						{
							GuildDataManager.MediumDungeonDamageInfo mediumDungeonDamageInfo = new GuildDataManager.MediumDungeonDamageInfo();
							mediumDungeonDamageInfo.nDungeonID = (ulong)guildDungeonBossBlood.dungeonId;
							mediumDungeonDamageInfo.nMaxHp = this.GetGuildDungeonBossMaxHp(guildDungeonBossBlood.dungeonId);
							mediumDungeonDamageInfo.nOddHp = guildDungeonBossBlood.oddBlood;
							mediumDungeonDamageInfo.nVerifyBlood = guildDungeonBossBlood.verifyBlood;
							this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Add(mediumDungeonDamageInfo);
						}
					}
				}
				else
				{
					Debug.LogErrorFormat("boss血量信息长度非法，应该为4，当前长度为{0}", new object[]
					{
						worldGuildDungeonInfoRes.bossBlood.Length
					});
				}
				if (worldGuildDungeonInfoRes.clearGateTime != null && this.m_GuildDungeonActivityData.guildDungeonClearGateInfos != null)
				{
					this.m_GuildDungeonActivityData.guildDungeonClearGateInfos.Clear();
					for (int j = 0; j < worldGuildDungeonInfoRes.clearGateTime.Length; j++)
					{
						GuildDataManager.GuildDungeonClearGateInfo guildDungeonClearGateInfo = new GuildDataManager.GuildDungeonClearGateInfo();
						guildDungeonClearGateInfo.guildName = worldGuildDungeonInfoRes.clearGateTime[j].guildName;
						guildDungeonClearGateInfo.spendTime = worldGuildDungeonInfoRes.clearGateTime[j].spendTime;
						this.m_GuildDungeonActivityData.guildDungeonClearGateInfos.Add(guildDungeonClearGateInfo);
					}
					this.m_GuildDungeonActivityData.guildDungeonClearGateInfos.Sort(delegate(GuildDataManager.GuildDungeonClearGateInfo info1, GuildDataManager.GuildDungeonClearGateInfo info2)
					{
						if (info1.spendTime == info2.spendTime)
						{
							return 0;
						}
						return (info1.spendTime >= info2.spendTime) ? 1 : -1;
					});
				}
				this.m_GuildDungeonActivityData.nActivityState = worldGuildDungeonInfoRes.dungeonStatus;
				this.m_GuildDungeonActivityData.nActivityStateEndTime = worldGuildDungeonInfoRes.statusEndStamp;
				this.m_GuildDungeonActivityData.bGetReward = (worldGuildDungeonInfoRes.isReward == 1U);
				this.OnUpdateActivityNotice((GuildDungeonStatus)nActivityState, (GuildDungeonStatus)dungeonStatus);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.GuildMain, null, null, null);
				if (nBossOddHp != 0UL && this.m_GuildDungeonActivityData.nBossOddHp == 0UL)
				{
					bool flag = GuildDataManager.IsInGuildAreanScence();
					this.IsShowFireworks = true;
					if (flag)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonShowFireworks, null, null, null, null);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonUpdateActivityData, null, null, null, null);
		}

		// Token: 0x0600B5A0 RID: 46496 RVA: 0x0028DB7C File Offset: 0x0028BF7C
		private void _OnWorldGuildDungeonCopyRes(MsgDATA msg)
		{
			WorldGuildDungeonCopyRes worldGuildDungeonCopyRes = new WorldGuildDungeonCopyRes();
			worldGuildDungeonCopyRes.decode(msg.bytes);
			if (this.m_GuildDungeonActivityData != null)
			{
				if (this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos != null)
				{
					this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos.Clear();
				}
				if (this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos != null)
				{
					this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Clear();
				}
				if (this.m_GuildDungeonActivityData.bossDungeonDamageInfos != null)
				{
					this.m_GuildDungeonActivityData.bossDungeonDamageInfos.Clear();
				}
				if (this.m_GuildDungeonActivityData.buffAddUpInfos != null)
				{
					this.m_GuildDungeonActivityData.buffAddUpInfos.Clear();
				}
				for (int i = 0; i < worldGuildDungeonCopyRes.battleRecord.Length; i++)
				{
					GuildDungeonBattleRecord guildDungeonBattleRecord = worldGuildDungeonCopyRes.battleRecord[i];
					int guildDungeonDiffLevel = this.GetGuildDungeonDiffLevel(guildDungeonBattleRecord.dungeonId);
					if (guildDungeonDiffLevel == 1)
					{
						GuildDataManager.JuniorDungeonDamageInfo juniorDungeonDamageInfo = new GuildDataManager.JuniorDungeonDamageInfo();
						juniorDungeonDamageInfo.nDungeonID = (ulong)guildDungeonBattleRecord.dungeonId;
						juniorDungeonDamageInfo.nKillCount = (ulong)guildDungeonBattleRecord.battleCnt;
						this.m_GuildDungeonActivityData.juniorDungeonDamgeInfos.Add(juniorDungeonDamageInfo);
					}
					else if (guildDungeonDiffLevel == 2)
					{
						GuildDataManager.MediumDungeonDamageInfo mediumDungeonDamageInfo = new GuildDataManager.MediumDungeonDamageInfo();
						mediumDungeonDamageInfo.nDungeonID = (ulong)guildDungeonBattleRecord.dungeonId;
						mediumDungeonDamageInfo.nMaxHp = this.GetGuildDungeonBossMaxHp(guildDungeonBattleRecord.dungeonId);
						mediumDungeonDamageInfo.nOddHp = guildDungeonBattleRecord.oddBlood;
						this.m_GuildDungeonActivityData.mediumDungeonDamgeInfos.Add(mediumDungeonDamageInfo);
					}
					else if (guildDungeonDiffLevel == 3)
					{
						GuildDataManager.BossDungeonDamageInfo bossDungeonDamageInfo = new GuildDataManager.BossDungeonDamageInfo();
						bossDungeonDamageInfo.nDungeonID = (ulong)guildDungeonBattleRecord.dungeonId;
						this.m_GuildDungeonActivityData.bossDungeonDamageInfos.Add(bossDungeonDamageInfo);
					}
					for (int j = 0; j < guildDungeonBattleRecord.buffVec.Length; j++)
					{
						GuildDungeonBuff guildDungeonBuff = guildDungeonBattleRecord.buffVec[j];
						GuildDataManager.BuffAddUpInfo buffAddUpInfo = new GuildDataManager.BuffAddUpInfo();
						buffAddUpInfo.nDungeonID = (ulong)guildDungeonBattleRecord.dungeonId;
						buffAddUpInfo.nBuffLv = (ulong)guildDungeonBuff.buffLvl;
						buffAddUpInfo.nBuffID = (ulong)guildDungeonBuff.buffId;
						this.m_GuildDungeonActivityData.buffAddUpInfos.Add(buffAddUpInfo);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonUpdateDungeonMapInfo, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonUpdateDungeonBufInfo, null, null, null, null);
		}

		// Token: 0x0600B5A1 RID: 46497 RVA: 0x0028DDAC File Offset: 0x0028C1AC
		private void _OnWorldGuildDungeonLotteryRes(MsgDATA msg)
		{
			WorldGuildDungeonLotteryRes worldGuildDungeonLotteryRes = new WorldGuildDungeonLotteryRes();
			worldGuildDungeonLotteryRes.decode(msg.bytes);
			if (worldGuildDungeonLotteryRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildDungeonLotteryRes.result, string.Empty);
				return;
			}
			List<GuildDungeonActivityChestItem> list = new List<GuildDungeonActivityChestItem>();
			if (list != null)
			{
				for (int i = 0; i < worldGuildDungeonLotteryRes.lotteryItemVec.Length; i++)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)worldGuildDungeonLotteryRes.lotteryItemVec[i].itemId, 100, 0);
					if (itemData != null)
					{
						itemData.Count = (int)worldGuildDungeonLotteryRes.lotteryItemVec[i].itemNum;
						list.Add(new GuildDungeonActivityChestItem
						{
							itemData = itemData,
							isHighValue = (worldGuildDungeonLotteryRes.lotteryItemVec[i].isHighVal > 0U)
						});
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenGuildDungeonTreasureChests, list, null, null, null);
		}

		// Token: 0x0600B5A2 RID: 46498 RVA: 0x0028DE7C File Offset: 0x0028C27C
		private void _OnWorldGuildDungeonBossDeadNotify(MsgDATA msg)
		{
			WorldGuildDungeonBossDeadNotify worldGuildDungeonBossDeadNotify = new WorldGuildDungeonBossDeadNotify();
			worldGuildDungeonBossDeadNotify.decode(msg.bytes);
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildBossKilledNotify", this.GetGuildDungeonName(worldGuildDungeonBossDeadNotify.dungeonId)), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B5A3 RID: 46499 RVA: 0x0028DEB8 File Offset: 0x0028C2B8
		private void _OnWorldGuildDungeonStatusSync(MsgDATA msg)
		{
			WorldGuildDungeonStatusSync worldGuildDungeonStatusSync = new WorldGuildDungeonStatusSync();
			worldGuildDungeonStatusSync.decode(msg.bytes);
			if (this.m_GuildDungeonActivityData != null)
			{
				uint nActivityState = this.m_GuildDungeonActivityData.nActivityState;
				uint dungeonStatus = worldGuildDungeonStatusSync.dungeonStatus;
				this.m_GuildDungeonActivityData.nActivityState = dungeonStatus;
				this.OnUpdateActivityNotice((GuildDungeonStatus)nActivityState, (GuildDungeonStatus)dungeonStatus);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonSyncActivityState, nActivityState, dungeonStatus, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.GuildMain, null, null, null);
				if (dungeonStatus == 0U)
				{
					Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(this.iIntervalCallID);
				}
				else
				{
					this.RequestActivityData();
					Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(this.iIntervalCallID);
					this.iIntervalCallID = Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeIntervalCall(this, Time.time, 5f, 5f, 100000000f, null, new UnityAction(this.RequestActivityData), null);
				}
				if (dungeonStatus == 2U)
				{
					if (!this.IsIDOpened((ulong)ClientApplication.playerinfo.accid))
					{
						this.SetIDOpened((ulong)ClientApplication.playerinfo.accid);
						ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
						if (clientSystemTown != null)
						{
							InvokeMethod.Invoke(2f, new UnityAction(this.OpenNotifyUI));
						}
					}
				}
				else
				{
					this.ClearIDOpened((ulong)ClientApplication.playerinfo.accid);
				}
			}
		}

		// Token: 0x0600B5A4 RID: 46500 RVA: 0x0028E024 File Offset: 0x0028C424
		private void _OnWorldGuildDungeonStatueRes(MsgDATA msg)
		{
			WorldGuildDungeonStatueRes worldGuildDungeonStatueRes = new WorldGuildDungeonStatueRes();
			worldGuildDungeonStatueRes.decode(msg.bytes);
			this.GuildGuardStatueList.Clear();
			for (int i = 0; i < worldGuildDungeonStatueRes.figureStatue.Length; i++)
			{
				this.GuildGuardStatueList.Add(worldGuildDungeonStatueRes.figureStatue[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildGuardStatueUpdate, null, null, null, null);
		}

		// Token: 0x0600B5A5 RID: 46501 RVA: 0x0028E090 File Offset: 0x0028C490
		private void _OnWorldGuildSetJoinLevelRes(MsgDATA msg)
		{
			WorldGuildSetJoinLevelRes worldGuildSetJoinLevelRes = new WorldGuildSetJoinLevelRes();
			worldGuildSetJoinLevelRes.decode(msg.bytes);
			if (worldGuildSetJoinLevelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildSetJoinLevelRes.result, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildJoinLvUpdate, null, null, null, null);
		}

		// Token: 0x0600B5A6 RID: 46502 RVA: 0x0028E0E0 File Offset: 0x0028C4E0
		private void _OnWorldGuildSetDungeonTypeRes(MsgDATA msg)
		{
			WorldGuildSetDungeonTypeRes worldGuildSetDungeonTypeRes = new WorldGuildSetDungeonTypeRes();
			worldGuildSetDungeonTypeRes.decode(msg.bytes);
			if (worldGuildSetDungeonTypeRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildSetDungeonTypeRes.result, string.Empty);
				return;
			}
			if (this.myGuild != null)
			{
				this.myGuild.dungeonType = worldGuildSetDungeonTypeRes.dungeonType;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonSetBossDiff, null, null, null, null);
		}

		// Token: 0x0600B5A7 RID: 46503 RVA: 0x0028E14C File Offset: 0x0028C54C
		private void _OnWorldGuildGetTerrDayRewardRes(MsgDATA msg)
		{
			WorldGuildGetTerrDayRewardRes worldGuildGetTerrDayRewardRes = new WorldGuildGetTerrDayRewardRes();
			worldGuildGetTerrDayRewardRes.decode(msg.bytes);
			if (worldGuildGetTerrDayRewardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildGetTerrDayRewardRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B5A8 RID: 46504 RVA: 0x0028E187 File Offset: 0x0028C587
		public bool GuildMemberIsEnoughMegrge()
		{
			return this.myGuild != null && this.myGuild.nMemberCount <= this.myGuild.nMemberMaxCount / 2;
		}

		// Token: 0x0600B5A9 RID: 46505 RVA: 0x0028E1B4 File Offset: 0x0028C5B4
		public bool IsCanGuildMerger()
		{
			ulong num = (ulong)DataManager<TimeManager>.GetInstance().GetServerTime() - this.mServerStartGameTime;
			return num >= 1209600UL;
		}

		// Token: 0x0600B5AA RID: 46506 RVA: 0x0028E1EC File Offset: 0x0028C5EC
		public void RequestCanMergerdGuildList(int a_nStartIndex, int a_nCount)
		{
			WorldGuildWatchCanMergerReq worldGuildWatchCanMergerReq = new WorldGuildWatchCanMergerReq();
			worldGuildWatchCanMergerReq.start = (ushort)a_nStartIndex;
			worldGuildWatchCanMergerReq.num = (ushort)a_nCount;
			NetManager.Instance().SendCommand<WorldGuildWatchCanMergerReq>(ServerType.GATE_SERVER, worldGuildWatchCanMergerReq);
		}

		// Token: 0x0600B5AB RID: 46507 RVA: 0x0028E21C File Offset: 0x0028C61C
		private void _OnCanMergerGuildListRes(MsgDATA msgDATA)
		{
			WorldGuildWatchCanMergerRet worldGuildWatchCanMergerRet = new WorldGuildWatchCanMergerRet();
			int num = 0;
			worldGuildWatchCanMergerRet.decode(msgDATA.bytes, ref num);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildListUpdated, worldGuildWatchCanMergerRet, null, null, null);
		}

		// Token: 0x0600B5AC RID: 46508 RVA: 0x0028E254 File Offset: 0x0028C654
		public void RequestCanMergerdGuildMembers(ulong guildID)
		{
			WorldGuildMemberListReq worldGuildMemberListReq = new WorldGuildMemberListReq();
			worldGuildMemberListReq.guildID = guildID;
			NetManager.Instance().SendCommand<WorldGuildMemberListReq>(ServerType.GATE_SERVER, worldGuildMemberListReq);
		}

		// Token: 0x0600B5AD RID: 46509 RVA: 0x0028E27C File Offset: 0x0028C67C
		private void _OnCanMergerdGuildMembersRes(MsgDATA msgDATA)
		{
			WorldGuildMemberListRes worldGuildMemberListRes = new WorldGuildMemberListRes();
			int num = 0;
			worldGuildMemberListRes.decode(msgDATA.bytes, ref num);
			this.CanMergerdGuildMembers.Clear();
			for (int i = 0; i < worldGuildMemberListRes.members.Length; i++)
			{
				GuildMemberEntry guildMemberEntry = worldGuildMemberListRes.members[i];
				GuildMemberData guildMemberData = new GuildMemberData();
				guildMemberData.uGUID = guildMemberEntry.id;
				guildMemberData.strName = guildMemberEntry.name;
				guildMemberData.nLevel = (int)guildMemberEntry.level;
				guildMemberData.nJobID = (int)guildMemberEntry.occu;
				guildMemberData.vipLevel = (uint)guildMemberEntry.vipLevel;
				guildMemberData.seasonLevel = guildMemberEntry.seasonLevel;
				guildMemberData.eGuildDuty = this.GetClientDuty(guildMemberEntry.post);
				guildMemberData.nContribution = (int)guildMemberEntry.contribution;
				guildMemberData.uOffLineTime = guildMemberEntry.logoutTime;
				guildMemberData.uActiveDegree = guildMemberEntry.activeDegree;
				guildMemberData.playerLabelInfo = guildMemberEntry.playerLabelInfo;
				RelationData relationData = null;
				DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(guildMemberEntry.id, ref relationData);
				if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
				{
					guildMemberData.remark = relationData.remark;
				}
				this.CanMergerdGuildMembers.Add(guildMemberData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CanMergerdGuildMemberUpdate, null, null, null, null);
		}

		// Token: 0x0600B5AE RID: 46510 RVA: 0x0028E3D8 File Offset: 0x0028C7D8
		public void RequestGuildMergeOp(ulong guildId, byte type)
		{
			WorldGuildMergerRequestOperatorReq worldGuildMergerRequestOperatorReq = new WorldGuildMergerRequestOperatorReq();
			worldGuildMergerRequestOperatorReq.guildId = guildId;
			worldGuildMergerRequestOperatorReq.opType = type;
			NetManager.Instance().SendCommand<WorldGuildMergerRequestOperatorReq>(ServerType.GATE_SERVER, worldGuildMergerRequestOperatorReq);
		}

		// Token: 0x0600B5AF RID: 46511 RVA: 0x0028E408 File Offset: 0x0028C808
		private void _OnGuildMergerRequestOperatorRes(MsgDATA msgDATA)
		{
			WorldGuildMergerRequestOperatorRet worldGuildMergerRequestOperatorRet = new WorldGuildMergerRequestOperatorRet();
			int num = 0;
			worldGuildMergerRequestOperatorRet.decode(msgDATA.bytes, ref num);
			if (worldGuildMergerRequestOperatorRet.errorCode == 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RequestGuildMergerSucess, worldGuildMergerRequestOperatorRet.opType, null, null, null);
			}
			else if (worldGuildMergerRequestOperatorRet.errorCode == 2320001U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildMergerRequestOperatorRet.errorCode, string.Empty);
			}
			else if (worldGuildMergerRequestOperatorRet.errorCode == 2320005U)
			{
				CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)worldGuildMergerRequestOperatorRet.errorCode, string.Empty, string.Empty);
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(608, string.Empty, string.Empty);
				string msgContent = string.Empty;
				if (tableItem != null && tableItem2 != null)
				{
					msgContent = string.Format(tableItem.Descs, tableItem2.Value);
				}
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B5B0 RID: 46512 RVA: 0x0028E4F8 File Offset: 0x0028C8F8
		public void RequestGuildReceiveMergeRequest()
		{
			WorldGuildReceiveMergerRequestReq cmd = new WorldGuildReceiveMergerRequestReq();
			NetManager.Instance().SendCommand<WorldGuildReceiveMergerRequestReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B5B1 RID: 46513 RVA: 0x0028E518 File Offset: 0x0028C918
		private void _OnGuildReceiveMergerRequestRes(MsgDATA msgDATA)
		{
			WorldGuildReceiveMergerRequestRet worldGuildReceiveMergerRequestRet = new WorldGuildReceiveMergerRequestRet();
			int num = 0;
			worldGuildReceiveMergerRequestRet.decode(msgDATA.bytes, ref num);
			if (worldGuildReceiveMergerRequestRet.isHave == 0)
			{
				this.IsHaveMergedRequest = false;
			}
			else if (worldGuildReceiveMergerRequestRet.isHave == 1)
			{
				this.IsHaveMergedRequest = true;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildReceiveMergerd, null, null, null, null);
		}

		// Token: 0x0600B5B2 RID: 46514 RVA: 0x0028E578 File Offset: 0x0028C978
		public void RequestGuildHaveMgergeRequest()
		{
			WorldGuildWatchHavedMergerRequestReq cmd = new WorldGuildWatchHavedMergerRequestReq();
			NetManager.Instance().SendCommand<WorldGuildWatchHavedMergerRequestReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B5B3 RID: 46515 RVA: 0x0028E598 File Offset: 0x0028C998
		private void _OnGuildWatchHavedMergerRequestRes(MsgDATA msgDATA)
		{
			WorldGuildWatchHavedMergerRequestRet worldGuildWatchHavedMergerRequestRet = new WorldGuildWatchHavedMergerRequestRet();
			int num = 0;
			worldGuildWatchHavedMergerRequestRet.decode(msgDATA.bytes, ref num);
			if (worldGuildWatchHavedMergerRequestRet.guilds != null && worldGuildWatchHavedMergerRequestRet.guilds.Length > 0)
			{
				for (int i = 0; i < worldGuildWatchHavedMergerRequestRet.guilds.Length; i++)
				{
					if (worldGuildWatchHavedMergerRequestRet.guilds[i].isRequested != 0)
					{
						this.IsAgreeMergerRequest = true;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildReceiveMergedList, worldGuildWatchHavedMergerRequestRet.guilds, null, null, null);
		}

		// Token: 0x0600B5B4 RID: 46516 RVA: 0x0028E620 File Offset: 0x0028CA20
		public void AcceptOrRefuseOrCancelMergeRequest(byte opType, ulong guildId)
		{
			WorldGuildAcceptOrRefuseOrCancleMergerRequestReq worldGuildAcceptOrRefuseOrCancleMergerRequestReq = new WorldGuildAcceptOrRefuseOrCancleMergerRequestReq();
			worldGuildAcceptOrRefuseOrCancleMergerRequestReq.opType = opType;
			worldGuildAcceptOrRefuseOrCancleMergerRequestReq.guildId = guildId;
			NetManager.Instance().SendCommand<WorldGuildAcceptOrRefuseOrCancleMergerRequestReq>(ServerType.GATE_SERVER, worldGuildAcceptOrRefuseOrCancleMergerRequestReq);
		}

		// Token: 0x0600B5B5 RID: 46517 RVA: 0x0028E650 File Offset: 0x0028CA50
		private void _OnGuildAcceptOrRefuseOrCancleMergerRequestRes(MsgDATA msgDATA)
		{
			WorldGuildAcceptOrRefuseOrCancleMergerRequestRet worldGuildAcceptOrRefuseOrCancleMergerRequestRet = new WorldGuildAcceptOrRefuseOrCancleMergerRequestRet();
			int num = 0;
			worldGuildAcceptOrRefuseOrCancleMergerRequestRet.decode(msgDATA.bytes, ref num);
			if (worldGuildAcceptOrRefuseOrCancleMergerRequestRet.errorCode == 0U)
			{
				this.RequestGuildHaveMgergeRequest();
				if (worldGuildAcceptOrRefuseOrCancleMergerRequestRet.opType == 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AgreeMerger, null, null, null, null);
				}
				else if (worldGuildAcceptOrRefuseOrCancleMergerRequestRet.opType == 3)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefuseAllReceive, null, null, null, null);
				}
			}
			else if (worldGuildAcceptOrRefuseOrCancleMergerRequestRet.errorCode == 2320004U || worldGuildAcceptOrRefuseOrCancleMergerRequestRet.errorCode == 2320003U)
			{
				SystemNotifyManager.SystemNotify((int)worldGuildAcceptOrRefuseOrCancleMergerRequestRet.errorCode, string.Empty);
			}
		}

		// Token: 0x0600B5B6 RID: 46518 RVA: 0x0028E6FC File Offset: 0x0028CAFC
		private void _OnGuildSyncMergerInfo(MsgDATA msgDATA)
		{
			WorldGuildSyncMergerInfo worldGuildSyncMergerInfo = new WorldGuildSyncMergerInfo();
			int num = 0;
			worldGuildSyncMergerInfo.decode(msgDATA.bytes, ref num);
			this.myGuild.prosperity = worldGuildSyncMergerInfo.prosperityStatus;
			this.myGuild.mergerRequestType = worldGuildSyncMergerInfo.mergerRequsetStatus;
		}

		// Token: 0x0600B5B7 RID: 46519 RVA: 0x0028E744 File Offset: 0x0028CB44
		private void _OnSyncWordStartTime(MsgDATA msgDATA)
		{
			WorldNotifyGameStartTime worldNotifyGameStartTime = new WorldNotifyGameStartTime();
			int num = 0;
			worldNotifyGameStartTime.decode(msgDATA.bytes, ref num);
			this.mServerStartGameTime = (ulong)worldNotifyGameStartTime.time;
		}

		// Token: 0x04006641 RID: 26177
		private Dictionary<int, List<GuildSkillTable>> m_dictSkillTableData = new Dictionary<int, List<GuildSkillTable>>();

		// Token: 0x04006642 RID: 26178
		private const string m_strExchangeCoolTime = "guild_exchange_cold";

		// Token: 0x04006643 RID: 26179
		private GuildAttackCityData m_AttackCityData = new GuildAttackCityData();

		// Token: 0x04006644 RID: 26180
		private List<GuildBattleInspireInfo> m_GuildInspireList = new List<GuildBattleInspireInfo>();

		// Token: 0x04006645 RID: 26181
		private ItemData LotteryItem;

		// Token: 0x04006646 RID: 26182
		private List<FigureStatueInfo> TownStatueList = new List<FigureStatueInfo>();

		// Token: 0x04006647 RID: 26183
		private List<FigureStatueInfo> GuildGuardStatueList = new List<FigureStatueInfo>();

		// Token: 0x04006648 RID: 26184
		private GuildBuildingType m_eBuidingType;

		// Token: 0x04006649 RID: 26185
		private int UpBuildingNeedTicket;

		// Token: 0x0400664A RID: 26186
		private const string kKeyPrefix = "battle_buff_";

		// Token: 0x0400664B RID: 26187
		private List<GuildDataManager.DungeonDamageRankInfo> m_DungeonRankInfoList = new List<GuildDataManager.DungeonDamageRankInfo>();

		// Token: 0x0400664C RID: 26188
		public const int nGuildDungeonMapScenceID = 6031;

		// Token: 0x0400664D RID: 26189
		public const int nGuildAreanScenceID = 6090;

		// Token: 0x0400664E RID: 26190
		private const float fReqGuildActivityDataInterval = 5f;

		// Token: 0x0400664F RID: 26191
		private int iIntervalCallID;

		// Token: 0x04006650 RID: 26192
		private Dictionary<int, GuildDungeonLvlTable> m_GuildDungeonID2LvTable;

		// Token: 0x04006651 RID: 26193
		private GuildDataManager.GuildDungeonActivityData m_GuildDungeonActivityData = new GuildDataManager.GuildDungeonActivityData();

		// Token: 0x04006652 RID: 26194
		private List<GuildDataManager.GuildAuctionItemData> guildAuctionItemDatasForGuildAuction;

		// Token: 0x04006653 RID: 26195
		private List<GuildDataManager.GuildAuctionItemData> guildAuctionItemDatasForWorldAuction;

		// Token: 0x04006658 RID: 26200
		private string m_kSavePath = "GuildDungeonOpen.json";

		// Token: 0x04006659 RID: 26201
		private string jsonText;

		// Token: 0x0400665A RID: 26202
		private GuildDataManager.DungeonDamageRankInfo m_MyDungeonDamageRankInfo = new GuildDataManager.DungeonDamageRankInfo();

		// Token: 0x0400665B RID: 26203
		private Dictionary<int, int> guildDungeonID2TeamDungeonID;

		// Token: 0x0400665C RID: 26204
		public byte chestDoubleFlag;

		// Token: 0x0400665D RID: 26205
		private const int nYGWZManorID = 8;

		// Token: 0x0400665F RID: 26207
		private Dictionary<GuildBuildingType, GuildBuildInfoTable> guildBuildType2Talbe = new Dictionary<GuildBuildingType, GuildBuildInfoTable>();

		// Token: 0x04006666 RID: 26214
		public static int iJoinGuildMaxLevel = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;

		// Token: 0x04006667 RID: 26215
		private int nEmblemSkillID;

		// Token: 0x04006668 RID: 26216
		public List<GuildMemberData> CanMergerdGuildMembers = new List<GuildMemberData>();

		// Token: 0x04006669 RID: 26217
		public bool IsHaveMergedRequest;

		// Token: 0x0400666A RID: 26218
		public bool IsAgreeMergerRequest;

		// Token: 0x0400666B RID: 26219
		private ulong mServerStartGameTime;

		// Token: 0x0400666C RID: 26220
		public bool IsJumpTipWhenStartGuildBattle;

		// Token: 0x0400666D RID: 26221
		public bool IsJumpTipWhenStartGuildBattleCorssServer;

		// Token: 0x0400666E RID: 26222
		private int nMaxEmblemLv = 10;

		// Token: 0x04006673 RID: 26227
		public GuildDataManager.OnGuildPowerChanged onGuildPowerChanged;

		// Token: 0x04006675 RID: 26229
		private List<ItemData> storageDatas = new List<ItemData>();

		// Token: 0x04006677 RID: 26231
		public static List<int> winPowerSetting = new List<int>
		{
			0,
			30,
			50,
			80,
			100
		};

		// Token: 0x04006678 RID: 26232
		public static List<int> losePowerSetting = new List<int>
		{
			0,
			30,
			50,
			80,
			100
		};

		// Token: 0x04006679 RID: 26233
		private List<object> records = new List<object>();

		// Token: 0x0400667A RID: 26234
		public List<WorldGuildInviteNotify> GuildInviteList = new List<WorldGuildInviteNotify>();

		// Token: 0x0400667B RID: 26235
		private string mGuildPVPBattleHideName = string.Empty;

		// Token: 0x0400667C RID: 26236
		private List<GuildBattleRecord> m_arrSelfBattleRecords = new List<GuildBattleRecord>();

		// Token: 0x0400667D RID: 26237
		private List<GuildBattleRecord> m_arrBattleRecords = new List<GuildBattleRecord>();

		// Token: 0x0400667E RID: 26238
		private int m_nLatestRecordID = -1;

		// Token: 0x0400667F RID: 26239
		private bool m_bGuildBattleSignUp;

		// Token: 0x04006680 RID: 26240
		private bool m_bGuildBattleEnter;

		// Token: 0x04006681 RID: 26241
		private GuildBattleType m_guildBattleType;

		// Token: 0x04006682 RID: 26242
		private EGuildBattleState m_guildBattleState;

		// Token: 0x04006683 RID: 26243
		private uint m_nStateEndTime;

		// Token: 0x04006684 RID: 26244
		private GuildTerritoryBaseInfo[] m_arrGuildManorInfos;

		// Token: 0x04006685 RID: 26245
		private bool m_bBattleNotifyInited;

		// Token: 0x04006686 RID: 26246
		private bool m_bHasLotteryed = true;

		// Token: 0x04006687 RID: 26247
		public bool checkedLvUpBulilding;

		// Token: 0x04006688 RID: 26248
		public bool checkedLvUpEmblem;

		// Token: 0x04006689 RID: 26249
		public static int currentMaxBuildLv = 3;

		// Token: 0x0400668A RID: 26250
		public bool checkedSetBossDiff;

		// Token: 0x0400668D RID: 26253
		private static List<GuildDataManager.AuctionItemState> states = new List<GuildDataManager.AuctionItemState>
		{
			GuildDataManager.AuctionItemState.InAuction,
			GuildDataManager.AuctionItemState.Prepare,
			GuildDataManager.AuctionItemState.AbortiveAuction,
			GuildDataManager.AuctionItemState.SoldOut
		};

		// Token: 0x0200126C RID: 4716
		public class DungeonDamageRankInfo
		{
			// Token: 0x04006698 RID: 26264
			public uint nRank;

			// Token: 0x04006699 RID: 26265
			public string strPlayerName;

			// Token: 0x0400669A RID: 26266
			public ulong nDamage;

			// Token: 0x0400669B RID: 26267
			public ulong nPlayerID;
		}

		// Token: 0x0200126D RID: 4717
		public class BossDungeonDamageInfo
		{
			// Token: 0x0400669C RID: 26268
			public ulong nBossID;

			// Token: 0x0400669D RID: 26269
			public ulong nDungeonID;
		}

		// Token: 0x0200126E RID: 4718
		public class GuildDungeonClearGateInfo
		{
			// Token: 0x0400669E RID: 26270
			public string guildName;

			// Token: 0x0400669F RID: 26271
			public ulong spendTime;
		}

		// Token: 0x0200126F RID: 4719
		public class MediumDungeonDamageInfo
		{
			// Token: 0x040066A0 RID: 26272
			public ulong nDungeonID;

			// Token: 0x040066A1 RID: 26273
			public ulong nMaxHp;

			// Token: 0x040066A2 RID: 26274
			public ulong nOddHp;

			// Token: 0x040066A3 RID: 26275
			public ulong nVerifyBlood;
		}

		// Token: 0x02001270 RID: 4720
		public class JuniorDungeonDamageInfo
		{
			// Token: 0x040066A4 RID: 26276
			public ulong nDungeonID;

			// Token: 0x040066A5 RID: 26277
			public ulong nKillCount;
		}

		// Token: 0x02001271 RID: 4721
		public class BuffAddUpInfo
		{
			// Token: 0x040066A6 RID: 26278
			public ulong nDungeonID;

			// Token: 0x040066A7 RID: 26279
			public ulong nBuffID;

			// Token: 0x040066A8 RID: 26280
			public ulong nBuffLv;
		}

		// Token: 0x02001272 RID: 4722
		public class GuildDungeonActivityData
		{
			// Token: 0x040066A9 RID: 26281
			public ulong nBossOddHp;

			// Token: 0x040066AA RID: 26282
			public ulong nBossMaxHp;

			// Token: 0x040066AB RID: 26283
			public ulong nVerifyBlood;

			// Token: 0x040066AC RID: 26284
			public List<GuildDataManager.JuniorDungeonDamageInfo> juniorDungeonDamgeInfos = new List<GuildDataManager.JuniorDungeonDamageInfo>();

			// Token: 0x040066AD RID: 26285
			public List<GuildDataManager.MediumDungeonDamageInfo> mediumDungeonDamgeInfos = new List<GuildDataManager.MediumDungeonDamageInfo>();

			// Token: 0x040066AE RID: 26286
			public List<GuildDataManager.BossDungeonDamageInfo> bossDungeonDamageInfos = new List<GuildDataManager.BossDungeonDamageInfo>();

			// Token: 0x040066AF RID: 26287
			public List<GuildDataManager.BuffAddUpInfo> buffAddUpInfos = new List<GuildDataManager.BuffAddUpInfo>();

			// Token: 0x040066B0 RID: 26288
			public List<GuildDataManager.GuildDungeonClearGateInfo> guildDungeonClearGateInfos = new List<GuildDataManager.GuildDungeonClearGateInfo>();

			// Token: 0x040066B1 RID: 26289
			public uint nActivityState;

			// Token: 0x040066B2 RID: 26290
			public uint nActivityStateEndTime;

			// Token: 0x040066B3 RID: 26291
			public bool bGetReward;
		}

		// Token: 0x02001273 RID: 4723
		public enum AuctionItemState
		{
			// Token: 0x040066B5 RID: 26293
			Prepare,
			// Token: 0x040066B6 RID: 26294
			InAuction,
			// Token: 0x040066B7 RID: 26295
			SoldOut,
			// Token: 0x040066B8 RID: 26296
			AbortiveAuction
		}

		// Token: 0x02001274 RID: 4724
		public class GuildAuctionItemData
		{
			// Token: 0x040066B9 RID: 26297
			public ulong guid;

			// Token: 0x040066BA RID: 26298
			public AwardItemData itemData0 = new AwardItemData();

			// Token: 0x040066BB RID: 26299
			public AwardItemData itemData1 = new AwardItemData();

			// Token: 0x040066BC RID: 26300
			public ulong statusEndStamp;

			// Token: 0x040066BD RID: 26301
			public GuildDataManager.AuctionItemState auctionItemState;

			// Token: 0x040066BE RID: 26302
			public ulong buyNowPrice;

			// Token: 0x040066BF RID: 26303
			public ulong curbiddingPrice;

			// Token: 0x040066C0 RID: 26304
			public ulong nextBiddingPrice;

			// Token: 0x040066C1 RID: 26305
			public ulong bidRoleId;
		}

		// Token: 0x02001275 RID: 4725
		// (Invoke) Token: 0x0600B5D7 RID: 46551
		public delegate void OnGuildPowerChanged(PowerSettingType ePowerSettingType, int iPowerValue);
	}
}
