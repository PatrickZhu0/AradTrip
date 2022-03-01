using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200151F RID: 5407
	public class ChapterBaseFrame : ChapterCommonBoardFrame
	{
		// Token: 0x0600D224 RID: 53796 RVA: 0x0033E9BD File Offset: 0x0033CDBD
		protected sealed override void _loadData()
		{
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			this._loadTableData();
		}

		// Token: 0x0600D225 RID: 53797 RVA: 0x0033E9D5 File Offset: 0x0033CDD5
		protected void _loadTableData()
		{
			this.mDungeonTable = this._getDungeonTable<DungeonTable>(this.mDungeonID.dungeonID);
			this.mDungeonUIConfigTable = this._getDungeonTable<DungeonUIConfigTable>(this.mDungeonID.dungeonIDWithOutDiff);
		}

		// Token: 0x0600D226 RID: 53798 RVA: 0x0033EA08 File Offset: 0x0033CE08
		protected override void _loadBg()
		{
			Sprite sprite = null;
			string backgroundImage = string.Empty;
			if (this.mDungeonUIConfigTable != null)
			{
				sprite = (Singleton<AssetLoader>.instance.LoadRes(this.mDungeonUIConfigTable.BackgroundPath, typeof(Sprite), true, 0U).obj as Sprite);
				backgroundImage = this.mDungeonUIConfigTable.BackgroundPath;
			}
			if (null == sprite)
			{
				sprite = (Singleton<AssetLoader>.instance.LoadRes("UI/Image/Dungeon/Select/Select-the_difficulty_beijing.png", typeof(Sprite), true, 0U).obj as Sprite);
				backgroundImage = "UI/Image/Dungeon/Select/Select-the_difficulty_beijing.png";
			}
			this.mCommonBoard.SetBackgroundImage(backgroundImage);
			this.mCommonBoard.AttachPrefab("UI/Prefabs/Chapter/ChapterCommonBg", ComCommonBoard.ePosition.Background, -1);
		}

		// Token: 0x0600D227 RID: 53799 RVA: 0x0033EAB8 File Offset: 0x0033CEB8
		protected void _loadCharactor()
		{
			GameObject gameObject = null;
			if (this.mDungeonUIConfigTable != null)
			{
				gameObject = this.mCommonBoard.AttachPrefab(this.mDungeonUIConfigTable.CharactorConfig, ComCommonBoard.ePosition.Right, 0);
			}
			if (null == gameObject)
			{
				gameObject = this.mCommonBoard.AttachPrefab("UI/Prefabs/Chapter/ChapterCommonCharactor", ComCommonBoard.ePosition.Right, 0);
			}
			if (null != gameObject)
			{
				ComChapterCharactor component = gameObject.GetComponent<ComChapterCharactor>();
				this.mChapterCharactor = component;
			}
			if (this.mChapterCharactor != null)
			{
				int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
				JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.mChapterCharactor.SetCharactor(tableItem.JobPortrayal);
				}
			}
		}

		// Token: 0x0600D228 RID: 53800 RVA: 0x0033EB68 File Offset: 0x0033CF68
		protected override void _loadRightPanel()
		{
			this._loadCharactor();
			GameObject gameObject = null;
			if (this.mDungeonUIConfigTable != null)
			{
				gameObject = this.mCommonBoard.AttachPrefab(this.mDungeonUIConfigTable.RightPannelConfig, ComCommonBoard.ePosition.Right, -1);
			}
			if (null == gameObject)
			{
				gameObject = this.mCommonBoard.AttachPrefab("UI/Prefabs/Chapter/ChapterCommonStart", ComCommonBoard.ePosition.Right, -1);
			}
			if (null != gameObject)
			{
				gameObject.name = "ChapterStart";
			}
		}

		// Token: 0x0600D229 RID: 53801 RVA: 0x0033EBD8 File Offset: 0x0033CFD8
		protected override void _loadLeftPanel()
		{
			GameObject gameObject = null;
			if (this.mDungeonUIConfigTable != null)
			{
				gameObject = this.mCommonBoard.AttachPrefab(this.mDungeonUIConfigTable.LeftPannelConfig, ComCommonBoard.ePosition.Left, -1);
			}
			if (null == gameObject)
			{
				gameObject = this.mCommonBoard.AttachPrefab("UI/Prefabs/Chapter/ChapterCommonInfo", ComCommonBoard.ePosition.Left, -1);
			}
			if (null != gameObject)
			{
				gameObject.name = "ChapterInfo";
				ComCommonChapterInfo component = gameObject.GetComponent<ComCommonChapterInfo>();
				this.mChapterInfoCommon = component;
				this.mChapterInfoDiffculte = component;
				this.mChapterInfoDrops = component;
				this.mChapterPassReward = component;
				this.mChapterScore = component;
				this.mChapterMonsterInfo = component;
				this.mChapterActivityTimes = component;
				this.mChapterProcess = component;
				this.mChapterInfoDrugs = component;
				this.mChapterDungeonMap = component;
				this.mChapterNodeState = component;
				this.mChapterConsume = component;
			}
		}

		// Token: 0x0600D22A RID: 53802 RVA: 0x0033EC9C File Offset: 0x0033D09C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._updateCommonInfo();
			this._updateDropInfo();
			this._updateDiffculteInfo();
			this._updatePassReward();
			this._updateScore();
			this._updateMonsterData();
			this._updateChapterActivityTimes();
		}

		// Token: 0x0600D22B RID: 53803 RVA: 0x0033ECCE File Offset: 0x0033D0CE
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x0600D22C RID: 53804 RVA: 0x0033ECD6 File Offset: 0x0033D0D6
		private void _updateChapterActivityTimes()
		{
			if (this.mChapterActivityTimes != null)
			{
				this.mChapterActivityTimes.SetActivityTimes(this.mDungeonID.dungeonID);
			}
		}

		// Token: 0x0600D22D RID: 53805 RVA: 0x0033ECFC File Offset: 0x0033D0FC
		protected virtual void _updateCommonInfo()
		{
			if (this.mChapterInfoCommon != null)
			{
				this.mChapterInfoCommon.SetName(this.mDungeonTable.Name);
				this.mChapterInfoCommon.SetDescription(this.mDungeonTable.Description);
				this.mChapterInfoCommon.SetRecommnedLevel(this.mDungeonTable.RecommendLevel);
				this.mChapterInfoCommon.SetRecommnedWeapon(this.mDungeonTable.RecommendLevel);
				ActivityDungeonSub subByDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByDungeonID(this.mDungeonID.dungeonIDWithOutDiff);
				if (subByDungeonID != null)
				{
					this.mChapterInfoCommon.SetOpenTime(subByDungeonID.table.OpenTime);
				}
			}
		}

		// Token: 0x0600D22E RID: 53806 RVA: 0x0033EDA0 File Offset: 0x0033D1A0
		protected virtual void _updateDropInfo()
		{
			if (this.mChapterInfoDrops != null)
			{
				if (this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL || this.mDungeonTable.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || this.mDungeonTable.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
				{
					this.mChapterInfoDrops.SetDropList(this.mDungeonTable.HellDropItems, this.mDungeonTable.ID);
				}
				else
				{
					this.mChapterInfoDrops.SetDropList(this.mDungeonTable.DropItems, this.mDungeonTable.ID);
				}
			}
		}

		// Token: 0x0600D22F RID: 53807 RVA: 0x0033EE34 File Offset: 0x0033D234
		protected virtual void _updatePassReward()
		{
			if (this.mChapterPassReward != null)
			{
				this.mChapterPassReward.SetExp(this.mDungeonTable.ExpReward);
				this.mChapterPassReward.SetGold(0);
			}
		}

		// Token: 0x0600D230 RID: 53808 RVA: 0x0033EE64 File Offset: 0x0033D264
		private List<int> _monsterList()
		{
			List<int> list = new List<int>();
			DDungeonData ddungeonData = Singleton<AssetLoader>.instance.LoadRes(this.mDungeonTable.DungeonConfig, typeof(DDungeonData), true, 0U).obj as DDungeonData;
			if (null != ddungeonData)
			{
				for (int i = 0; i < ddungeonData.areaconnectlist.Length; i++)
				{
					DSceneDataConnect dsceneDataConnect = ddungeonData.areaconnectlist[i];
					if (dsceneDataConnect.isboss)
					{
						DSceneData dsceneData = Singleton<AssetLoader>.instance.LoadRes(dsceneDataConnect.sceneareapath, typeof(DSceneData), true, 0U).obj as DSceneData;
						if (dsceneData != null)
						{
							DMonsterInfo[] monsterinfo = dsceneData._monsterinfo;
							for (int j = 0; j < monsterinfo.Length; j++)
							{
								int resid = monsterinfo[j].resid;
								bool flag = true;
								int num = resid % 100 + resid / 10000 * 10000;
								UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(num, string.Empty, string.Empty);
								if (tableItem != null && tableItem.Type == UnitTable.eType.SKILL_MONSTER)
								{
									flag = false;
								}
								if (flag)
								{
									list.Add(num);
								}
							}
						}
					}
				}
			}
			list.Sort((int x, int y) => y - x);
			int count = list.Count;
			if (count > 5)
			{
				list.RemoveRange(5, count - 5);
			}
			return list;
		}

		// Token: 0x0600D231 RID: 53809 RVA: 0x0033EFD9 File Offset: 0x0033D3D9
		protected virtual void _updateMonsterData()
		{
			if (this.mChapterMonsterInfo != null)
			{
				this.mChapterMonsterInfo.SetMonsterList(this._monsterList());
			}
		}

		// Token: 0x0600D232 RID: 53810 RVA: 0x0033EFF8 File Offset: 0x0033D3F8
		protected virtual void _updateScore()
		{
			if (this.mChapterScore != null)
			{
				this.mChapterScore.SetFightTime(TableManager.GetValueFromUnionCell(this.mDungeonTable.TimeSplitArg, this.mDungeonTable.TimeSplitArg.eValues.everyValues.Count - 1, true) * 1000);
				this.mChapterScore.SetHitCount(TableManager.GetValueFromUnionCell(this.mDungeonTable.HitSplitArg, this.mDungeonTable.HitSplitArg.eValues.everyValues.Count - 1, true));
				this.mChapterScore.SetRebornCount(TableManager.GetValueFromUnionCell(this.mDungeonTable.RebornSplitArg, this.mDungeonTable.RebornSplitArg.eValues.everyValues.Count - 1, true));
			}
		}

		// Token: 0x0600D233 RID: 53811 RVA: 0x0033F0C0 File Offset: 0x0033D4C0
		protected virtual void _updateDiffculteInfo()
		{
			if (this.mChapterInfoDiffculte != null)
			{
				this.mChapterInfoDiffculte.SetTopDiffculte(ChapterUtility.GetDungeonTopHard(ChapterBaseFrame.sDungeonID));
				DungeonID dungeonID = new DungeonID(this.mDungeonID.dungeonID);
				int dungeonTopHard = ChapterUtility.GetDungeonTopHard(dungeonID.dungeonID);
				List<int> list = new List<int>();
				List<string> list2 = new List<string>();
				for (int i = 0; i <= dungeonTopHard; i++)
				{
					dungeonID.diffID = i;
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID.dungeonID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(tableItem.MinLevel);
						list2.Add(tableItem.HardDescription);
					}
					else
					{
						list.Add(0);
						list2.Add(string.Empty);
					}
				}
				dungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
				ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID.dungeonID);
				bool @lock = dungeonState == ComChapterDungeonUnit.eState.Locked;
				this.mChapterInfoDiffculte.SetLock(@lock);
				this.mChapterInfoDiffculte.SetDiffculte(dungeonID.diffID, dungeonID.dungeonID);
				this.mChapterInfoDiffculte.SetLevelLimite(list.ToArray());
				this.mChapterInfoDiffculte.SetLevelDescription(list2.ToArray());
				this.mChapterInfoDiffculte.SetDiffculteCallback(new ChapterDiffCallback(this._commonDiffCallback));
				this._onDiffChange(dungeonID.diffID);
			}
		}

		// Token: 0x0600D234 RID: 53812 RVA: 0x0033F210 File Offset: 0x0033D610
		private void _commonDiffCallback(int idx)
		{
			this.mDungeonID.diffID = idx;
			int dungeonID = this.mDungeonID.dungeonID;
			this._loadTableData();
			if (this.mChapterInfoDiffculte != null)
			{
				ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID);
				bool @lock = dungeonState == ComChapterDungeonUnit.eState.Locked;
				this.mChapterInfoDiffculte.SetLock(@lock);
				this.mChapterInfoDiffculte.SetDiffculte(this.mChapterInfoDiffculte.GetDiffculte(), dungeonID);
			}
			this._updateCommonInfo();
			this._updateDropInfo();
			this._updatePassReward();
			this._updateScore();
			this._updateMonsterData();
			this._onDiffChange(idx);
		}

		// Token: 0x0600D235 RID: 53813 RVA: 0x0033F29A File Offset: 0x0033D69A
		protected virtual void _onDiffChange(int idx)
		{
		}

		// Token: 0x0600D236 RID: 53814 RVA: 0x0033F29C File Offset: 0x0033D69C
		private int _getTopHard(int dungeonID)
		{
			List<DungeonHardInfo> allHardInfo = DataManager<BattleDataManager>.GetInstance().ChapterInfo.allHardInfo;
			int result = 0;
			this.mDungeonID.dungeonID = dungeonID;
			int num = allHardInfo.BinarySearch(new DungeonHardInfo
			{
				id = this.mDungeonID.dungeonIDWithOutPrestory
			});
			if (num >= 0)
			{
				result = allHardInfo[num].unlockedHardType;
			}
			return result;
		}

		// Token: 0x0600D237 RID: 53815 RVA: 0x0033F2FC File Offset: 0x0033D6FC
		private T _getDungeonTable<T>(int id)
		{
			T tableItem = Singleton<TableManager>.instance.GetTableItem<T>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem;
			}
			return default(T);
		}

		// Token: 0x0600D238 RID: 53816 RVA: 0x0033F338 File Offset: 0x0033D738
		protected IEnumerator _commonStart()
		{
			if (!this.mIsSendMessage)
			{
				int diff = 0;
				if (this.mChapterInfoDiffculte != null)
				{
					diff = this.mChapterInfoDiffculte.GetDiffculte();
				}
				this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
				this.mDungeonID.diffID = diff;
				DungeonTable dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(ChapterBaseFrame.sDungeonID, string.Empty, string.Empty);
				if (dungeonTable != null && dungeonTable.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
				{
					if (!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen(ChapterBaseFrame.sDungeonID))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonNotOpenNow"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						yield break;
					}
				}
				else if (!ChapterUtility.GetDungeonCanEnter(this.mDungeonID.dungeonID, true, true, true))
				{
					yield break;
				}
				SceneDungeonStartReq req = new SceneDungeonStartReq
				{
					dungeonId = (uint)this.mDungeonID.dungeonID
				};
				if (this.mChapterInfoDrugs != null)
				{
					List<CostItemManager.CostInfo> costs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsCost(this.mDungeonID.dungeonID);
					req.buffDrugs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsByDungeonID(this.mDungeonID.dungeonID).ToArray();
					int index = -1;
					for (int i = 0; i < req.buffDrugs.Length; i++)
					{
						if (req.buffDrugs[i] > 0U && DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)req.buffDrugs[i], true) == 0)
						{
							index = i;
							break;
						}
					}
					if (index != -1)
					{
						int moneyCost = 0;
						for (int j = 0; j < costs.Count; j++)
						{
							moneyCost += costs[j].nCount;
						}
						int ret = -1;
						LoginToggleMsgBoxOKCancelFrame.TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType.EnterDungeonBuyDrug, TR.Value("enter_dungeon_buy_drug_tip", moneyCost), delegate
						{
							ret = 1;
						}, delegate
						{
							ret = 0;
						}, TR.Value("enter_dungeon_buy_drug"), TR.Value("enter_dungeon_not_buy_drug"));
						while (ret == -1)
						{
							yield return null;
						}
						if (ret == 0)
						{
							for (int k = 0; k < req.buffDrugs.Length; k++)
							{
								if (req.buffDrugs[k] > 0U && DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)req.buffDrugs[k], true) == 0)
								{
									DataManager<ChapterBuffDrugManager>.GetInstance().UnMarkBuffDrug2Use((int)req.buffDrugs[k]);
									req.buffDrugs[k] = 0U;
								}
							}
						}
					}
					int result = -1;
					costs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsCost(this.mDungeonID.dungeonID);
					bool isEnough2Cost = DataManager<CostItemManager>.GetInstance().IsEnough2Cost(costs);
					DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(costs, delegate
					{
						result = 1;
					}, delegate
					{
						result = 0;
					}, "common_money_cost");
					while (isEnough2Cost && result == -1)
					{
						yield return null;
					}
					if (result != 1)
					{
						yield break;
					}
					req.buffDrugs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsByDungeonID(this.mDungeonID.dungeonID).ToArray();
					DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
				}
				DungeonTable dungeonData = Singleton<TableManager>.instance.GetTableItem<DungeonTable>((int)req.dungeonId, string.Empty, string.Empty);
				if (dungeonData != null && dungeonData.Type == DungeonTable.eType.L_DEADTOWER)
				{
					int count = DataManager<CountDataManager>.GetInstance().GetCount("tower");
				}
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				this.mIsSendMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, BeClientSwitch.FunctionIsOpen(ClientSwitchType.EnterBattleShowWaittingFrame), 5f);
				this.mIsSendMessage = false;
			}
			yield break;
		}

		// Token: 0x0600D239 RID: 53817 RVA: 0x0033F354 File Offset: 0x0033D754
		private void _setStat(int id, List<int> buff)
		{
			DungeonID dungeonID = new DungeonID(id);
			Singleton<GameStatisticManager>.instance.DoStatLevelChoose(StatLevelChooseType.ENTER_LEVEL, ChapterSelectFrame.sSceneID, dungeonID.dungeonID, dungeonID.diffID, buff);
		}

		// Token: 0x04007B10 RID: 31504
		private const string kPrefabCharactor = "UI/Prefabs/Chapter/ChapterCommonCharactor";

		// Token: 0x04007B11 RID: 31505
		private const string kPrefabCommonBg = "UI/Prefabs/Chapter/ChapterCommonBg";

		// Token: 0x04007B12 RID: 31506
		private const string kPrefabInfo = "UI/Prefabs/Chapter/ChapterCommonInfo";

		// Token: 0x04007B13 RID: 31507
		private const string kPrefabStart = "UI/Prefabs/Chapter/ChapterCommonStart";

		// Token: 0x04007B14 RID: 31508
		private const string kBackgroud = "UI/Image/Dungeon/Select/Select-the_difficulty_beijing.png";

		// Token: 0x04007B15 RID: 31509
		protected const string kNameStart = "ChapterStart";

		// Token: 0x04007B16 RID: 31510
		protected const string kNameInfo = "ChapterInfo";

		// Token: 0x04007B17 RID: 31511
		protected IChapterInfoCommon mChapterInfoCommon;

		// Token: 0x04007B18 RID: 31512
		protected IChapterInfoDrops mChapterInfoDrops;

		// Token: 0x04007B19 RID: 31513
		protected IChapterInfoDiffculte mChapterInfoDiffculte;

		// Token: 0x04007B1A RID: 31514
		protected IChapterCharactor mChapterCharactor;

		// Token: 0x04007B1B RID: 31515
		protected IChapterPassReward mChapterPassReward;

		// Token: 0x04007B1C RID: 31516
		protected IChapterScore mChapterScore;

		// Token: 0x04007B1D RID: 31517
		protected IChapterMonsterInfo mChapterMonsterInfo;

		// Token: 0x04007B1E RID: 31518
		protected IChapterProcess mChapterProcess;

		// Token: 0x04007B1F RID: 31519
		protected IChapterInfoDrugs mChapterInfoDrugs;

		// Token: 0x04007B20 RID: 31520
		protected IChapterDungeonMap mChapterDungeonMap;

		// Token: 0x04007B21 RID: 31521
		protected IChapterNodeState mChapterNodeState;

		// Token: 0x04007B22 RID: 31522
		protected IChapterConsume mChapterConsume;

		// Token: 0x04007B23 RID: 31523
		protected IChapterActivityTimes mChapterActivityTimes;

		// Token: 0x04007B24 RID: 31524
		protected IChapterMask mChapterMask;

		// Token: 0x04007B25 RID: 31525
		protected DungeonTable mDungeonTable;

		// Token: 0x04007B26 RID: 31526
		protected DungeonUIConfigTable mDungeonUIConfigTable;

		// Token: 0x04007B27 RID: 31527
		public static int sDungeonID = -1;

		// Token: 0x04007B28 RID: 31528
		protected DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x04007B29 RID: 31529
		private bool mIsSendMessage;
	}
}
