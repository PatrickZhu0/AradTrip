using System;
using System.Collections.Generic;
using Battle;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x0200108F RID: 4239
	[LoggerModel("GlobalBattleData")]
	public class BattleDataManager : DataManager<BattleDataManager>
	{
		// Token: 0x06009FB4 RID: 40884 RVA: 0x001FFC99 File Offset: 0x001FE099
		public override void Initialize()
		{
			this.RegisterNetHandler();
		}

		// Token: 0x06009FB5 RID: 40885 RVA: 0x001FFCA1 File Offset: 0x001FE0A1
		public override void Clear()
		{
			this.ChapterInfo = new ChapterInfo();
			this.PlayerInfo = new RacePlayerInfo[0];
			this.pkRaceType = RaceType.Dungeon;
			this.ClearBatlte();
			this.UnRegisterNetHandler();
		}

		// Token: 0x06009FB6 RID: 40886 RVA: 0x001FFCD0 File Offset: 0x001FE0D0
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(506822U, new Action<MsgDATA>(this._onSceneDungeonSyncNewOpenedList));
			NetProcess.AddMsgHandler(506801U, new Action<MsgDATA>(this._onSceneDungeonInit));
			NetProcess.AddMsgHandler(506803U, new Action<MsgDATA>(this._onSceneDungeonHardInit));
			NetProcess.AddMsgHandler(506804U, new Action<MsgDATA>(this._onSceneDungeonHardUpdate));
			NetProcess.AddMsgHandler(506802U, new Action<MsgDATA>(this._onSceneDungeonUpdate));
			NetProcess.AddMsgHandler(506815U, new Action<MsgDATA>(this._onSceneDungeonAddMonsterDropItemNotify));
			NetProcess.AddMsgHandler(606818U, new Action<MsgDATA>(this._OnDungeonRollItemRes));
			NetProcess.AddMsgHandler(606819U, new Action<MsgDATA>(this._OnDungonRollItemStatistic));
		}

		// Token: 0x06009FB7 RID: 40887 RVA: 0x001FFD90 File Offset: 0x001FE190
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(506822U, new Action<MsgDATA>(this._onSceneDungeonSyncNewOpenedList));
			NetProcess.RemoveMsgHandler(506801U, new Action<MsgDATA>(this._onSceneDungeonInit));
			NetProcess.RemoveMsgHandler(506803U, new Action<MsgDATA>(this._onSceneDungeonHardInit));
			NetProcess.RemoveMsgHandler(506804U, new Action<MsgDATA>(this._onSceneDungeonHardUpdate));
			NetProcess.RemoveMsgHandler(506802U, new Action<MsgDATA>(this._onSceneDungeonUpdate));
			NetProcess.RemoveMsgHandler(506815U, new Action<MsgDATA>(this._onSceneDungeonAddMonsterDropItemNotify));
			NetProcess.RemoveMsgHandler(606818U, new Action<MsgDATA>(this._OnDungeonRollItemRes));
			NetProcess.RemoveMsgHandler(606819U, new Action<MsgDATA>(this._OnDungonRollItemStatistic));
		}

		// Token: 0x06009FB8 RID: 40888 RVA: 0x001FFE50 File Offset: 0x001FE250
		private void _OnDungeonRollItemRes(MsgDATA msg)
		{
			WorldDungeonRollItemRes worldDungeonRollItemRes = new WorldDungeonRollItemRes();
			worldDungeonRollItemRes.decode(msg.bytes);
			if (worldDungeonRollItemRes.result == 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpateRollItem, worldDungeonRollItemRes, null, null, null);
			}
		}

		// Token: 0x06009FB9 RID: 40889 RVA: 0x001FFE90 File Offset: 0x001FE290
		private void _OnDungonRollItemStatistic(MsgDATA msg)
		{
			this.mSelfRollItems.Clear();
			if (this.rollRewardItem == null)
			{
				return;
			}
			WorldDungeonRollItemResult worldDungeonRollItemResult = new WorldDungeonRollItemResult();
			worldDungeonRollItemResult.decode(msg.bytes);
			RollDropResultItem[] items = worldDungeonRollItemResult.items;
			if (items == null)
			{
				return;
			}
			List<BattleDataManager.ResultRollItem> list = new List<BattleDataManager.ResultRollItem>();
			for (int i = 0; i < this.rollRewardItem.Length; i++)
			{
				BattleDataManager.ResultRollItem resultRollItem = new BattleDataManager.ResultRollItem();
				list.Add(resultRollItem);
				RollItemInfo rollItemInfo = this.rollRewardItem[i];
				resultRollItem.itemData = rollItemInfo;
				DropItem dropItem = rollItemInfo.dropItem;
				if (dropItem != null)
				{
					resultRollItem.item = ItemDataManager.CreateItemDataFromTable((int)dropItem.itemId, 100, 0);
				}
				int num = 0;
				int num2 = 0;
				for (int j = 0; j < items.Length; j++)
				{
					RollDropResultItem rollDropResultItem = items[j];
					if (rollItemInfo.rollIndex == rollDropResultItem.rollIndex)
					{
						resultRollItem.playerInfoes.Add(rollDropResultItem);
						if (num < (int)rollDropResultItem.point)
						{
							num = (int)rollDropResultItem.point;
							num2 = j;
						}
					}
				}
				if (num2 < items.Length && items[num2].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID && dropItem != null)
				{
					this.mSelfRollItems.Add(new ComItemList.Items
					{
						count = dropItem.num,
						id = (int)dropItem.itemId,
						type = ComItemList.eItemType.Custom,
						strenthLevel = (int)dropItem.strenth,
						equipType = (EEquipType)dropItem.equipType
					});
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRollItemEnd, list, null, null, null);
		}

		// Token: 0x06009FBA RID: 40890 RVA: 0x0020002C File Offset: 0x001FE42C
		private void _onSceneDungeonSyncNewOpenedList(MsgDATA data)
		{
			SceneDungeonSyncNewOpenedList sceneDungeonSyncNewOpenedList = new SceneDungeonSyncNewOpenedList();
			sceneDungeonSyncNewOpenedList.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonOpenList(sceneDungeonSyncNewOpenedList);
		}

		// Token: 0x06009FBB RID: 40891 RVA: 0x00200058 File Offset: 0x001FE458
		private void _onSceneDungeonInit(MsgDATA data)
		{
			SceneDungeonInit sceneDungeonInit = new SceneDungeonInit();
			sceneDungeonInit.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonInit(sceneDungeonInit);
		}

		// Token: 0x06009FBC RID: 40892 RVA: 0x00200084 File Offset: 0x001FE484
		private void _onSceneDungeonHardInit(MsgDATA data)
		{
			SceneDungeonHardInit sceneDungeonHardInit = new SceneDungeonHardInit();
			sceneDungeonHardInit.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonHardInit(sceneDungeonHardInit);
		}

		// Token: 0x06009FBD RID: 40893 RVA: 0x002000B0 File Offset: 0x001FE4B0
		private void _onSceneDungeonUpdate(MsgDATA data)
		{
			SceneDungeonUpdate sceneDungeonUpdate = new SceneDungeonUpdate();
			sceneDungeonUpdate.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonUpdate(sceneDungeonUpdate);
		}

		// Token: 0x06009FBE RID: 40894 RVA: 0x002000DC File Offset: 0x001FE4DC
		private void _onSceneDungeonHardUpdate(MsgDATA data)
		{
			SceneDungeonHardUpdate sceneDungeonHardUpdate = new SceneDungeonHardUpdate();
			sceneDungeonHardUpdate.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonHardUpdate(sceneDungeonHardUpdate);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonUnlockDiff, (int)sceneDungeonHardUpdate.info.id, (int)sceneDungeonHardUpdate.info.unlockedHardType, null, null);
		}

		// Token: 0x06009FBF RID: 40895 RVA: 0x00200138 File Offset: 0x001FE538
		private void _onSceneDungeonAddMonsterDropItemNotify(MsgDATA data)
		{
			SceneDungeonAddMonsterDropItemNotify sceneDungeonAddMonsterDropItemNotify = new SceneDungeonAddMonsterDropItemNotify();
			sceneDungeonAddMonsterDropItemNotify.decode(data.bytes);
			DataManager<BattleDataManager>.GetInstance().DungeonAddMonsterDropItemNotify(sceneDungeonAddMonsterDropItemNotify);
		}

		// Token: 0x06009FC0 RID: 40896 RVA: 0x00200162 File Offset: 0x001FE562
		public void ClearBatlte()
		{
			this.BattleInfo = new BattleInfo();
			this.chestInfo = new DungeonChestInfo();
			this.rollRewardItem = new RollItemInfo[0];
			this.mAllRollRewardItems.Clear();
			this.mSelfRollItems.Clear();
		}

		// Token: 0x06009FC1 RID: 40897 RVA: 0x0020019C File Offset: 0x001FE59C
		private void _updateAllInfo(SceneDungeonInfo repInfo)
		{
			List<DungeonInfo> allInfo = this.ChapterInfo.allInfo;
			DungeonInfo dungeonInfo = new DungeonInfo
			{
				id = (int)repInfo.id,
				bestScore = (int)repInfo.bestScore,
				bestRecordTime = (int)repInfo.bestRecordTime
			};
			int num = allInfo.BinarySearch(dungeonInfo);
			if (num < 0)
			{
				allInfo.Insert(~num, dungeonInfo);
			}
			else
			{
				allInfo[num] = dungeonInfo;
			}
		}

		// Token: 0x06009FC2 RID: 40898 RVA: 0x00200208 File Offset: 0x001FE608
		private void _updateHardInfo(SceneDungeonHardInfo repInfo)
		{
			List<DungeonHardInfo> allHardInfo = this.ChapterInfo.allHardInfo;
			DungeonHardInfo dungeonHardInfo = new DungeonHardInfo
			{
				id = (int)repInfo.id,
				unlockedHardType = (int)repInfo.unlockedHardType
			};
			int num = allHardInfo.BinarySearch(dungeonHardInfo);
			if (num < 0)
			{
				allHardInfo.Insert(~num, dungeonHardInfo);
			}
			else
			{
				allHardInfo[num] = dungeonHardInfo;
			}
		}

		// Token: 0x17001992 RID: 6546
		// (get) Token: 0x06009FC3 RID: 40899 RVA: 0x00200266 File Offset: 0x001FE666
		// (set) Token: 0x06009FC4 RID: 40900 RVA: 0x0020026E File Offset: 0x001FE66E
		public RaceType PkRaceType
		{
			get
			{
				return this.pkRaceType;
			}
			set
			{
				this.pkRaceType = value;
			}
		}

		// Token: 0x06009FC5 RID: 40901 RVA: 0x00200278 File Offset: 0x001FE678
		public void DungeonOpenList(SceneDungeonSyncNewOpenedList rep)
		{
			for (int i = 0; i < rep.newOpenedList.Length; i++)
			{
				Protocol.DungeonOpenInfo dungeonOpenInfo = rep.newOpenedList[i];
				this.sSearchOpenOp.id = (int)dungeonOpenInfo.id;
				int num = this.ChapterInfo.openedList.BinarySearch(this.sSearchOpenOp);
				if (num < 0)
				{
					this.ChapterInfo.openedList.Insert(~num, new Battle.DungeonOpenInfo
					{
						id = (int)dungeonOpenInfo.id,
						isHell = (dungeonOpenInfo.hellMode == 1)
					});
				}
				else
				{
					this.ChapterInfo.openedList[num].isHell = (dungeonOpenInfo.hellMode == 1);
				}
			}
			for (int j = 0; j < rep.newClosedList.Length; j++)
			{
				int data = (int)rep.newClosedList[j];
				this.ChapterInfo.openedList.RemoveAll((Battle.DungeonOpenInfo x) => x.id == data);
			}
		}

		// Token: 0x06009FC6 RID: 40902 RVA: 0x00200380 File Offset: 0x001FE780
		public void DungeonInit(SceneDungeonInit rep)
		{
			for (int i = 0; i < rep.allInfo.Length; i++)
			{
				this._updateAllInfo(rep.allInfo[i]);
			}
		}

		// Token: 0x06009FC7 RID: 40903 RVA: 0x002003B4 File Offset: 0x001FE7B4
		public void DungeonUpdate(SceneDungeonUpdate rep)
		{
			this._updateAllInfo(rep.info);
		}

		// Token: 0x06009FC8 RID: 40904 RVA: 0x002003C4 File Offset: 0x001FE7C4
		public void DungeonHardInit(SceneDungeonHardInit rep)
		{
			for (int i = 0; i < rep.allInfo.Length; i++)
			{
				this._updateHardInfo(rep.allInfo[i]);
			}
		}

		// Token: 0x06009FC9 RID: 40905 RVA: 0x002003F8 File Offset: 0x001FE7F8
		public void DungeonHardUpdate(SceneDungeonHardUpdate rep)
		{
			this._updateHardInfo(rep.info);
		}

		// Token: 0x06009FCA RID: 40906 RVA: 0x00200408 File Offset: 0x001FE808
		private void _addMonsterDropItem(DungeonAddMonsterDropItem item)
		{
			List<DungeonAddMonsterDropItem> addMonsterDropItem = this.BattleInfo.addMonsterDropItem;
			int num = addMonsterDropItem.BinarySearch(item);
			if (num < 0)
			{
				addMonsterDropItem.Insert(~num, item);
			}
			else
			{
				List<DungeonDropItem> dropItems = item.dropItems;
				dropItems.GetEnumerator();
				List<DungeonDropItem> dropItems2 = addMonsterDropItem[num].dropItems;
				for (int i = 0; i < dropItems.Count; i++)
				{
					dropItems2.Add(dropItems[i]);
				}
			}
		}

		// Token: 0x06009FCB RID: 40907 RVA: 0x00200484 File Offset: 0x001FE884
		public void DungeonAddMonsterDropItemNotify(SceneDungeonAddMonsterDropItemNotify notify)
		{
			DungeonAddMonsterDropItem dungeonAddMonsterDropItem = new DungeonAddMonsterDropItem
			{
				monsterId = (int)notify.monsterId
			};
			for (int i = 0; i < notify.dropItems.Length; i++)
			{
				SceneDungeonDropItem sceneDungeonDropItem = notify.dropItems[i];
				dungeonAddMonsterDropItem.dropItems.Add(new DungeonDropItem
				{
					id = (int)sceneDungeonDropItem.id,
					typeId = (int)sceneDungeonDropItem.typeId,
					num = (int)sceneDungeonDropItem.num,
					isDouble = (sceneDungeonDropItem.isDouble == 1),
					strenthLevel = (int)sceneDungeonDropItem.strenth
				});
			}
			this._addMonsterDropItem(dungeonAddMonsterDropItem);
		}

		// Token: 0x06009FCC RID: 40908 RVA: 0x00200528 File Offset: 0x001FE928
		private void _convertDungeonDropItem(List<DungeonDropItem> battleDrops, SceneDungeonDropItem[] protocolDrops)
		{
			if (battleDrops != null && protocolDrops != null)
			{
				foreach (SceneDungeonDropItem sceneDungeonDropItem in protocolDrops)
				{
					DungeonDropItem item = new DungeonDropItem
					{
						id = (int)sceneDungeonDropItem.id,
						typeId = (int)sceneDungeonDropItem.typeId,
						num = (int)sceneDungeonDropItem.num,
						isDouble = (sceneDungeonDropItem.isDouble == 1),
						strenthLevel = (int)sceneDungeonDropItem.strenth,
						equipType = (EEquipType)sceneDungeonDropItem.equipType
					};
					battleDrops.Add(item);
					if (this.BattleInfo.dropItems != null)
					{
						this.BattleInfo.dropItems.Add(item);
					}
				}
			}
		}

		// Token: 0x06009FCD RID: 40909 RVA: 0x002005D4 File Offset: 0x001FE9D4
		private DungeonMonster _convertOneDungeonMonster(SceneDungeonMonster resMonster)
		{
			DungeonMonster dungeonMonster = new DungeonMonster
			{
				id = (int)resMonster.id,
				pointId = (int)resMonster.pointId,
				typeId = (int)resMonster.typeId,
				summonerId = (int)resMonster.summonerId
			};
			if (resMonster.prefixes != null)
			{
				for (int i = 0; i < resMonster.prefixes.Length; i++)
				{
					dungeonMonster.prefixes.Add((int)resMonster.prefixes[i]);
				}
			}
			this._convertDungeonDropItem(dungeonMonster.dropItems, resMonster.dropItems);
			return dungeonMonster;
		}

		// Token: 0x06009FCE RID: 40910 RVA: 0x00200668 File Offset: 0x001FEA68
		public void ConvertPKBattleInfo(WorldNotifyRaceStart res)
		{
			this.BattleInfo = new BattleInfo();
			this.BattleInfo.dungeonId = (int)res.dungeonId;
		}

		// Token: 0x06009FCF RID: 40911 RVA: 0x00200688 File Offset: 0x001FEA88
		public void ConvertDungeonBattleEndInfo(SceneDungeonRaceEndRes res)
		{
			this.mSelfRollItems.Clear();
			this.mAllRollRewardItems.Clear();
			this.rollRewardItem = res.rollReward;
			if (this.rollRewardItem == null)
			{
				return;
			}
			for (int i = 0; i < this.rollRewardItem.Length; i++)
			{
				RollItemInfo rollItemInfo = this.rollRewardItem[i];
				if (rollItemInfo != null)
				{
					DropItem dropItem = rollItemInfo.dropItem;
					if (dropItem != null)
					{
						DungeonDropItem dungeonDropItem = new DungeonDropItem();
						dungeonDropItem.id = -1;
						dungeonDropItem.num = (int)dropItem.num;
						dungeonDropItem.typeId = (int)dropItem.itemId;
						dungeonDropItem.isDouble = false;
						dungeonDropItem.strenthLevel = (int)dropItem.strenth;
						dungeonDropItem.equipType = (EEquipType)dropItem.equipType;
						this.mAllRollRewardItems.Add(dungeonDropItem);
					}
				}
			}
			if (res.rollSingleReward == null)
			{
				return;
			}
			for (int j = 0; j < res.rollSingleReward.Length; j++)
			{
				ItemReward itemReward = res.rollSingleReward[j];
				if (itemReward != null)
				{
					this.mAllRollRewardItems.Add(new DungeonDropItem
					{
						id = -1,
						num = (int)itemReward.num,
						typeId = (int)itemReward.id,
						isDouble = false,
						strenthLevel = (int)itemReward.strength,
						equipType = (EEquipType)itemReward.equipType
					});
					this.mSelfRollItems.Add(new ComItemList.Items
					{
						count = itemReward.num,
						id = (int)itemReward.id,
						type = ComItemList.eItemType.Custom,
						strenthLevel = (int)itemReward.strength,
						equipType = (EEquipType)itemReward.equipType
					});
				}
			}
		}

		// Token: 0x06009FD0 RID: 40912 RVA: 0x00200844 File Offset: 0x001FEC44
		public void ConvertDungeonBattleInfo(SceneDungeonStartRes res)
		{
			this.BattleInfo = new BattleInfo();
			this.BattleInfo.dungeonId = (int)res.dungeonId;
			this.BattleInfo.startAreaId = (int)res.startAreaId;
			this.BattleInfo.key4 = res.key4;
			this.BattleInfo.key1 = res.key1;
			this.BattleInfo.key3 = res.key3;
			this.BattleInfo.key2 = res.key2;
			this._convertDungeonDropItem(this.BattleInfo.bossDropItems, res.bossDropItems);
			List<DungeonInfo> allInfo = this.ChapterInfo.allInfo;
			for (int i = 0; i < allInfo.Count; i++)
			{
				if ((long)allInfo[i].id == (long)((ulong)res.dungeonId))
				{
					this.BattleInfo.bestRecordTime = allInfo[i].bestRecordTime;
					break;
				}
			}
			SceneDungeonArea[] areas = res.areas;
			List<DungeonArea> areas2 = this.BattleInfo.areas;
			foreach (SceneDungeonArea sceneDungeonArea in areas)
			{
				SceneDungeonMonster[] monsters = sceneDungeonArea.monsters;
				List<DungeonMonster> list = new List<DungeonMonster>();
				List<DungeonMonster> list2 = new List<DungeonMonster>();
				for (int k = 0; k < sceneDungeonArea.destructs.Length; k++)
				{
					DungeonMonster item = this._convertOneDungeonMonster(sceneDungeonArea.destructs[k]);
					list2.Add(item);
				}
				for (int l = 0; l < monsters.Length; l++)
				{
					DungeonMonster monster = this._convertOneDungeonMonster(monsters[l]);
					list.Add(monster);
					if (monster.summonerId > 0)
					{
						DungeonMonster dungeonMonster = list2.Find((DungeonMonster x) => x.id == monster.summonerId);
						if (dungeonMonster != null)
						{
							if (dungeonMonster.summonerMonsters == null)
							{
								dungeonMonster.summonerMonsters = new List<DungeonMonster>();
							}
							dungeonMonster.summonerMonsters.Add(monster);
						}
					}
				}
				areas2.Add(new DungeonArea
				{
					id = (int)sceneDungeonArea.id,
					monsters = list,
					destructs = list2
				});
			}
			Protocol.DungeonHellInfo hellInfo = res.hellInfo;
			Battle.DungeonHellInfo dungeonHealInfo = this.BattleInfo.dungeonHealInfo;
			dungeonHealInfo.mode = (DungeonHellMode)hellInfo.mode;
			if (dungeonHealInfo.mode != DungeonHellMode.Null)
			{
				dungeonHealInfo.areaId = (int)hellInfo.areaId;
				for (int m = 0; m < hellInfo.waveInfoes.Length; m++)
				{
					Protocol.DungeonHellWaveInfo dungeonHellWaveInfo = hellInfo.waveInfoes[m];
					Battle.DungeonHellWaveInfo dungeonHellWaveInfo2 = new Battle.DungeonHellWaveInfo();
					dungeonHellWaveInfo2.wave = m;
					for (int n = 0; n < dungeonHellWaveInfo.monsters.Length; n++)
					{
						dungeonHellWaveInfo2.monsters.Add(this._convertOneDungeonMonster(dungeonHellWaveInfo.monsters[n]));
					}
					dungeonHealInfo.waveInfos.Add(dungeonHellWaveInfo2);
				}
				this._convertDungeonDropItem(dungeonHealInfo.dropItems, hellInfo.dropItems);
			}
			if (this.BattleInfo.dropOverMonster != null)
			{
				this.BattleInfo.dropOverMonster.Clear();
				if (res.dropOverMonster != null)
				{
					for (int num = 0; num < res.dropOverMonster.Length; num++)
					{
						this.BattleInfo.dropOverMonster.Add(res.dropOverMonster[num]);
					}
				}
			}
		}

		// Token: 0x04005878 RID: 22648
		public BattleInfo BattleInfo = new BattleInfo();

		// Token: 0x04005879 RID: 22649
		public ChapterInfo ChapterInfo = new ChapterInfo();

		// Token: 0x0400587A RID: 22650
		public RacePlayerInfo[] PlayerInfo = new RacePlayerInfo[0];

		// Token: 0x0400587B RID: 22651
		public DungeonChestInfo chestInfo = new DungeonChestInfo();

		// Token: 0x0400587C RID: 22652
		public RollItemInfo[] rollRewardItem = new RollItemInfo[0];

		// Token: 0x0400587D RID: 22653
		public List<DungeonDropItem> mAllRollRewardItems = new List<DungeonDropItem>();

		// Token: 0x0400587E RID: 22654
		public List<ComItemList.Items> mSelfRollItems = new List<ComItemList.Items>();

		// Token: 0x0400587F RID: 22655
		private RaceType pkRaceType;

		// Token: 0x04005880 RID: 22656
		public ulong originExp;

		// Token: 0x04005881 RID: 22657
		private Battle.DungeonOpenInfo sSearchOpenOp = new Battle.DungeonOpenInfo();

		// Token: 0x02001090 RID: 4240
		public class ResultRollItem
		{
			// Token: 0x04005882 RID: 22658
			public ItemData item;

			// Token: 0x04005883 RID: 22659
			public RollItemInfo itemData;

			// Token: 0x04005884 RID: 22660
			public List<RollDropResultItem> playerInfoes = new List<RollDropResultItem>();
		}
	}
}
