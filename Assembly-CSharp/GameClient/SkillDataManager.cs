using System;
using System.Collections.Generic;
using System.Reflection;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012EF RID: 4847
	internal class SkillDataManager : DataManager<SkillDataManager>
	{
		// Token: 0x17001B6A RID: 7018
		// (get) Token: 0x0600BBCB RID: 48075 RVA: 0x002BA329 File Offset: 0x002B8729
		// (set) Token: 0x0600BBCA RID: 48074 RVA: 0x002BA320 File Offset: 0x002B8720
		public SkillConfigType CurSkillConfigType
		{
			get
			{
				return this.curSkillConfigType;
			}
			set
			{
				this.curSkillConfigType = value;
			}
		}

		// Token: 0x0600BBCC RID: 48076 RVA: 0x002BA331 File Offset: 0x002B8731
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.SkillDataManager;
		}

		// Token: 0x0600BBCD RID: 48077 RVA: 0x002BA338 File Offset: 0x002B8738
		public override void Initialize()
		{
			this.Clear();
			this.BindEvents();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(703, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.UnLockTaskLvl = tableItem.Value;
			}
		}

		// Token: 0x0600BBCE RID: 48078 RVA: 0x002BA380 File Offset: 0x002B8780
		public override void Clear()
		{
			this.skillList.Clear();
			this.pvpSkillList.Clear();
			this.skillBarSolution.Clear();
			this.pvpSkillBarSolution.Clear();
			this.skillList2.Clear();
			this.pvpSkillList2.Clear();
			this.skillBarSolution2.Clear();
			this.pvpSkillBarSolution2.Clear();
			this.skillBar.Clear();
			this.pvpSkillBar.Clear();
			this.skillBar2.Clear();
			this.pvpSkillBar2.Clear();
			this.PassiveSkillList.Clear();
			this.ClearChijiSkill();
			this.UniqueButtonBindSkill.Clear();
			this.CommonButtonBindSkill.Clear();
			this.PassiveButtonBindSkill.Clear();
			this.InitSkills.Clear();
			this.LockSkillList.Clear();
			this.NewOpenUniSkillList.Clear();
			this.NewOpenComSkillList.Clear();
			this.NewOpenSkillAll.Clear();
			this.LastSeeSkillLv = 1;
			this.bNoticeSkillLvUp = true;
			this.IsNotShowSkillConfigTip = false;
			this.IsNotShowSkillLevelUpTip = false;
			this.IsFinishUnlockTask = false;
			this.ClearFairDuelSkill();
			this.CurPVESKillPage = EPVESkillPage.Page1;
			this.CurPVPSKillPage = EPVPSkillPage.Page1;
			this.PVESkillPage2IsUnlock = false;
			this.PVPSkillPage2IsUnlock = false;
			this.ActiveAwakeSkillIsGray = false;
			this.ActiveAwakeSkillIsGray2 = false;
			this.IsJumpPVESkillPageExchangeTip = false;
			this.IsJumpPVPSkillPageExchangeTip = false;
			this.UnBindEvents();
		}

		// Token: 0x0600BBCF RID: 48079 RVA: 0x002BA4E1 File Offset: 0x002B88E1
		public void ClearChijiSkill()
		{
			this.ChijiSkillList.Clear();
			this.ChijiSkillBar.Clear();
		}

		// Token: 0x0600BBD0 RID: 48080 RVA: 0x002BA4F9 File Offset: 0x002B88F9
		private void ClearFairDuelSkill()
		{
			this.FairDuelSkillList.Clear();
			this.FairDuelSkillBar.Clear();
		}

		// Token: 0x0600BBD1 RID: 48081 RVA: 0x002BA511 File Offset: 0x002B8911
		public void SetPvePage1SkillBar(List<SkillBarGrid> list)
		{
			this.skillBar = list;
		}

		// Token: 0x0600BBD2 RID: 48082 RVA: 0x002BA51C File Offset: 0x002B891C
		public void UpdateSkillData(SkillMgr skillMgr, SkillConfigType skillType)
		{
			if (skillMgr.skillPages.Length < 2)
			{
				Logger.LogError("服务器下发的技能页数量小于2");
				return;
			}
			for (int i = 0; i < skillMgr.skillPages.Length; i++)
			{
				for (int j = 0; j < skillMgr.skillPages[i].skillList.Length; j++)
				{
					Skill skill = skillMgr.skillPages[i].skillList[j];
					if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skill.id, string.Empty, string.Empty) != null)
					{
						if (skillType != SkillConfigType.SKILL_CONFIG_PVE)
						{
							if (skillType == SkillConfigType.SKILL_CONFIG_PVP)
							{
								if (i == 0)
								{
									this.UpdateSkillList(skill, this.pvpSkillList);
								}
								else if (i == 1)
								{
									this.UpdateSkillList(skill, this.pvpSkillList2);
								}
							}
						}
						else if (i == 0)
						{
							this.UpdateSkillList(skill, this.skillList);
						}
						else if (i == 1)
						{
							this.UpdateSkillList(skill, this.skillList2);
						}
					}
				}
			}
		}

		// Token: 0x0600BBD3 RID: 48083 RVA: 0x002BA628 File Offset: 0x002B8A28
		private void UpdateSkillList(Skill skill, List<Skill> skillList)
		{
			bool flag = false;
			for (int i = 0; i < skillList.Count; i++)
			{
				if (skill.id == skillList[i].id)
				{
					if (skill.level == 0)
					{
						skillList.RemoveAt(i);
					}
					else
					{
						skillList[i].level = skill.level;
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				skillList.Add(skill);
			}
		}

		// Token: 0x0600BBD4 RID: 48084 RVA: 0x002BA6A4 File Offset: 0x002B8AA4
		public void UpdateChijiSkillData(SkillMgr skillMgr)
		{
			if (skillMgr == null || skillMgr.skillPages.Length <= 0)
			{
				Logger.LogError("skillMgr is null or skillMgr.skillPages.Length<=0 ");
				return;
			}
			Skill[] array = skillMgr.skillPages[0].skillList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id != 0)
				{
					bool flag = false;
					for (int j = 0; j < this.ChijiSkillList.Count; j++)
					{
						if (array[i].id == this.ChijiSkillList[j].id)
						{
							if (array[i].level == 0)
							{
								Logger.LogErrorFormat("吃鸡捡到的技能等级为0,技能id = {0}", new object[]
								{
									array[i].id
								});
							}
							else
							{
								this.ChijiSkillList[j].level = array[i].level;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)array[i].id, string.Empty, string.Empty) == null)
						{
							return;
						}
						this.ChijiSkillList.Add(array[i]);
						if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage >= ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_1)
						{
						}
					}
				}
			}
		}

		// Token: 0x0600BBD5 RID: 48085 RVA: 0x002BA7DC File Offset: 0x002B8BDC
		public void UpdateFairDuelSkillData(SkillMgr skillMgr)
		{
			if (skillMgr == null || skillMgr.skillPages.Length <= 0)
			{
				Logger.LogError("skillMgr is null or skillMgr.skillPages.Length<=0 ");
				return;
			}
			Skill[] array = skillMgr.skillPages[0].skillList;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id != 0)
				{
					bool flag = false;
					for (int j = 0; j < this.FairDuelSkillList.Count; j++)
					{
						if (array[i].id == this.FairDuelSkillList[j].id)
						{
							if (array[i].level == 0)
							{
								this.FairDuelSkillList.RemoveAt(j);
							}
							else
							{
								this.FairDuelSkillList[j].level = array[i].level;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.FairDuelSkillList.Add(array[i]);
					}
				}
			}
		}

		// Token: 0x0600BBD6 RID: 48086 RVA: 0x002BA8CC File Offset: 0x002B8CCC
		private void _AutoSendSaveChijiSkillPlan(SkillTable skillData)
		{
			if (this.ChijiSkillBar == null || this.ChijiSkillBar.Count >= 11)
			{
				return;
			}
			if (skillData.SkillType == SkillTable.eSkillType.PASSIVE || skillData.IsQTE != 0)
			{
				return;
			}
			if (skillData.IsBuff == 1)
			{
				return;
			}
			if (!this.IsSkillJobAdaptToTargetJob(skillData, DataManager<PlayerBaseData>.GetInstance().JobTableID))
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			SceneExchangeSkillBarReq sceneExchangeSkillBarReq = new SceneExchangeSkillBarReq();
			sceneExchangeSkillBarReq.skillBars.index = 1;
			sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
			sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
			sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[1];
			sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
			sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = new SkillBarGrid();
			sceneExchangeSkillBarReq.skillBars.bar[0].grids[0].id = (ushort)skillData.ID;
			sceneExchangeSkillBarReq.skillBars.bar[0].grids[0].slot = (byte)(this.ChijiSkillBar.Count + 1);
			sceneExchangeSkillBarReq.configType = 2;
			netManager.SendCommand<SceneExchangeSkillBarReq>(ServerType.GATE_SERVER, sceneExchangeSkillBarReq);
		}

		// Token: 0x0600BBD7 RID: 48087 RVA: 0x002BAA0C File Offset: 0x002B8E0C
		public void UpdatePassiveSkillData()
		{
			Dictionary<int, int> skillInfoByPid = Singleton<TableManager>.GetInstance().GetSkillInfoByPid(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			Dictionary<int, int>.Enumerator enumerator = skillInfoByPid.GetEnumerator();
			this.PassiveSkillList.Clear();
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				int key = keyValuePair.Key;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(key, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SkillCategory != 1)
					{
						if (tableItem.PassiveSkillBtnIndex > 0)
						{
							if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.LevelLimit)
							{
								Skill skill = new Skill();
								skill.id = (ushort)key;
								skill.level = 1;
								this.PassiveSkillList.Add(skill);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BBD8 RID: 48088 RVA: 0x002BAAE8 File Offset: 0x002B8EE8
		public void UpdateSkillBar(SkillBars skillBars, SkillConfigType skillType)
		{
			if (skillType != SkillConfigType.SKILL_CONFIG_PVE)
			{
				if (skillType == SkillConfigType.SKILL_CONFIG_PVP)
				{
					if (skillBars.bar.Length >= 2)
					{
						this.pvpSkillBarSolution.Clear();
						this.pvpSkillBarSolution2.Clear();
						for (int i = 0; i < skillBars.bar.Length; i++)
						{
							if (i == 0)
							{
								this.UpdatePvpOrPveSkillBar(this.pvpSkillBarSolution, this.pvpSkillBar, skillBars.bar[i]);
							}
							else if (i == 1)
							{
								this.UpdatePvpOrPveSkillBar(this.pvpSkillBarSolution2, this.pvpSkillBar2, skillBars.bar[i]);
							}
						}
					}
				}
			}
			else if (skillBars.bar.Length >= 2)
			{
				this.skillBarSolution.Clear();
				this.skillBarSolution2.Clear();
				for (int j = 0; j < skillBars.bar.Length; j++)
				{
					if (j == 0)
					{
						this.UpdatePvpOrPveSkillBar(this.skillBarSolution, this.skillBar, skillBars.bar[j]);
					}
					else if (j == 1)
					{
						this.UpdatePvpOrPveSkillBar(this.skillBarSolution2, this.skillBar2, skillBars.bar[j]);
					}
				}
			}
		}

		// Token: 0x0600BBD9 RID: 48089 RVA: 0x002BAC18 File Offset: 0x002B9018
		private void UpdatePvpOrPveSkillBar(List<SkillBar> skillSolution, List<SkillBarGrid> skillBarGird, SkillBar skillbar)
		{
			skillSolution.Add(skillbar);
			skillBarGird.Clear();
			for (int i = 0; i < skillbar.grids.Length; i++)
			{
				skillBarGird.Add(skillbar.grids[i]);
			}
		}

		// Token: 0x0600BBDA RID: 48090 RVA: 0x002BAC5C File Offset: 0x002B905C
		public void UpdateChijiSkillBar(SkillBars skillBars)
		{
			for (int i = 0; i < skillBars.bar.Length; i++)
			{
				if (skillBars.bar[i].index == skillBars.index)
				{
					this.ChijiSkillBar.Clear();
					for (int j = 0; j < skillBars.bar[i].grids.Length; j++)
					{
						this.ChijiSkillBar.Add(skillBars.bar[i].grids[j]);
					}
				}
			}
		}

		// Token: 0x0600BBDB RID: 48091 RVA: 0x002BACE4 File Offset: 0x002B90E4
		public void UpdateFairDuelSkillBar(SkillBars skillBars)
		{
			if (skillBars.bar.Length >= 1)
			{
				SkillBarGrid[] grids = skillBars.bar[0].grids;
				if (grids != null)
				{
					this.FairDuelSkillBar.Clear();
					for (int i = 0; i < grids.Length; i++)
					{
						this.FairDuelSkillBar.Add(grids[i]);
					}
				}
			}
		}

		// Token: 0x0600BBDC RID: 48092 RVA: 0x002BAD40 File Offset: 0x002B9140
		public void UpdateNewSkill()
		{
			this._UpdateNewSkillList();
			if (this.NewOpenUniSkillList.Count > 0 || this.NewOpenComSkillList.Count > 0)
			{
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillLvUpNoticeUpdate, null, null, null, null);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Skill);
			}
		}

		// Token: 0x0600BBDD RID: 48093 RVA: 0x002BADB0 File Offset: 0x002B91B0
		public Dictionary<int, int> GetSkillInfo(bool isPvp, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<SkillBarGrid> curSkillBar = this.GetCurSkillBar(isPvp, skillSourceType);
			List<Skill> curSkillList = this.GetCurSkillList(isPvp, skillSourceType);
			foreach (SkillBarGrid skillBarGrid in curSkillBar)
			{
				Skill skillByID = this.GetSkillByID((int)skillBarGrid.id, isPvp, skillSourceType);
				if (skillByID != null && !dictionary.ContainsKey((int)skillByID.id))
				{
					dictionary.Add((int)skillByID.id, (int)skillByID.level);
				}
			}
			for (int i = 0; i < curSkillList.Count; i++)
			{
				int id = (int)curSkillList[i].id;
				int level = (int)curSkillList[i].level;
				if (!dictionary.ContainsKey(id))
				{
					dictionary.Add(id, level);
				}
			}
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && skillSourceType == SkillSystemSourceType.None)
			{
				int nSelfManorID = DataManager<GuildDataManager>.GetInstance().myGuild.nSelfManorID;
				GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(nSelfManorID, string.Empty, string.Empty);
				if (tableItem != null && DataManager<PlayerBaseData>.GetInstance().eGuildDuty == EGuildDuty.Leader)
				{
					if (isPvp)
					{
						if (tableItem.LeaderPvPAddSkill != 0 && !dictionary.ContainsKey(tableItem.LeaderPvPAddSkill))
						{
							dictionary.Add(tableItem.LeaderPvPAddSkill, 1);
						}
					}
					else if (tableItem.LeaderPveAddSkill != 0 && !dictionary.ContainsKey(tableItem.LeaderPveAddSkill))
					{
						dictionary.Add(tableItem.LeaderPveAddSkill, 1);
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600BBDE RID: 48094 RVA: 0x002BAF60 File Offset: 0x002B9360
		public List<Skill> GetCurSkillList(bool isPvp, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
		{
			List<Skill> result;
			if ((BattleMain.instance != null && BattleMain.IsChiji()) || skillSourceType == SkillSystemSourceType.Chiji)
			{
				result = this.GetChijiSkillList();
			}
			else if ((BattleMain.instance != null && BattleMain.IsFairDuel()) || skillSourceType == SkillSystemSourceType.FairDuel)
			{
				result = this.GetFairDuelSkillList();
			}
			else
			{
				result = ((!isPvp) ? this.GetPveSkillList() : this.GetPvpSkillList());
			}
			return result;
		}

		// Token: 0x0600BBDF RID: 48095 RVA: 0x002BAFD8 File Offset: 0x002B93D8
		public List<SkillBarGrid> GetCurSkillBar(bool isPvp, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
		{
			List<SkillBarGrid> result;
			if ((BattleMain.instance != null && BattleMain.IsChiji()) || skillSourceType == SkillSystemSourceType.Chiji)
			{
				result = this.GetChijiSkillBar();
			}
			else if ((BattleMain.instance != null && BattleMain.IsFairDuel()) || skillSourceType == SkillSystemSourceType.FairDuel)
			{
				result = this.GetFairDuelSkillBar();
			}
			else
			{
				result = ((!isPvp) ? this.GetPveSkillBar() : this.GetPvpSkillBar());
			}
			return result;
		}

		// Token: 0x0600BBE0 RID: 48096 RVA: 0x002BB050 File Offset: 0x002B9450
		public bool HaveLearnSkill(int skillID)
		{
			foreach (Skill skill in this.skillList)
			{
				if ((int)skill.id == skillID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BBE1 RID: 48097 RVA: 0x002BB0BC File Offset: 0x002B94BC
		public bool IsSkillJobAdaptToTargetJob(SkillTable skillData, int TargetJobId)
		{
			if (skillData == null || skillData.JobID == null || skillData.JobID.Count < 1)
			{
				return false;
			}
			if (skillData.JobID[0] == -1)
			{
				return true;
			}
			if (skillData.JobID[0] == 0)
			{
				return false;
			}
			if (BattleMain.battleType != BattleType.NewbieGuide)
			{
				bool flag = false;
				for (int i = 0; i < skillData.JobID.Count; i++)
				{
					if (skillData.JobID[i] == TargetJobId && TargetJobId != 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
				Logger.LogErrorFormat(string.Format("技能与目标职业不匹配，技能id={0},技能名称={1}，职业id={2},", skillData.ID, skillData.Name, TargetJobId), new object[0]);
			}
			else
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(TargetJobId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.JobType == 0)
				{
					for (int j = 0; j < tableItem.ToJob.Count; j++)
					{
						bool flag2 = false;
						for (int k = 0; k < skillData.JobID.Count; k++)
						{
							if (tableItem.ToJob[j] == skillData.JobID[k])
							{
								flag2 = true;
								break;
							}
						}
						if (flag2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BBE2 RID: 48098 RVA: 0x002BB22C File Offset: 0x002B962C
		public Dictionary<int, int> GetSkillSlotMap()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (SkillBarGrid skillBarGrid in this.skillBar)
			{
				int num = (int)(skillBarGrid.slot + 3);
				if (!dictionary.ContainsKey(num))
				{
					dictionary.Add(num, (int)skillBarGrid.id);
				}
				else
				{
					Logger.LogErrorFormat("already contain the bar slot {0}", new object[]
					{
						num
					});
				}
			}
			return dictionary;
		}

		// Token: 0x0600BBE3 RID: 48099 RVA: 0x002BB2C8 File Offset: 0x002B96C8
		public Skill GetSkillByID(int sid, bool isPvp = false, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
		{
			if (skillSourceType == SkillSystemSourceType.Chiji)
			{
				return this.ChijiSkillList.Find((Skill s) => (int)s.id == sid);
			}
			if (skillSourceType == SkillSystemSourceType.FairDuel)
			{
				return this.FairDuelSkillList.Find((Skill s) => (int)s.id == sid);
			}
			if (isPvp)
			{
				List<Skill> list = this.GetPvpSkillList();
				return list.Find((Skill s) => (int)s.id == sid);
			}
			List<Skill> pveSkillList = this.GetPveSkillList();
			return pveSkillList.Find((Skill s) => (int)s.id == sid);
		}

		// Token: 0x0600BBE4 RID: 48100 RVA: 0x002BB35C File Offset: 0x002B975C
		public List<int> GetBuffSkillID(bool isPvp)
		{
			List<int> list = new List<int>();
			List<Skill> curSkillList = this.GetCurSkillList(isPvp, SkillSystemSourceType.None);
			for (int i = 0; i < curSkillList.Count; i++)
			{
				int id = (int)curSkillList[i].id;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.IsBuff > 0 && id > 0)
				{
					list.Add(id);
				}
			}
			return list;
		}

		// Token: 0x0600BBE5 RID: 48101 RVA: 0x002BB3D8 File Offset: 0x002B97D8
		public List<int> GetBuffSkillIDByLevelLimit(bool isPvp)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<Skill> curSkillList = this.GetCurSkillList(isPvp, SkillSystemSourceType.None);
			for (int i = 0; i < curSkillList.Count; i++)
			{
				int id = (int)curSkillList[i].id;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.IsBuff > 0 && id > 0)
				{
					int num = Utility.BinarySearch(list2, tableItem.LevelLimit);
					num = Mathf.Clamp(num, 0, list2.Count);
					list2.Insert(num, tableItem.LevelLimit);
					list.Insert(num, id);
				}
			}
			return list;
		}

		// Token: 0x0600BBE6 RID: 48102 RVA: 0x002BB48C File Offset: 0x002B988C
		public int GetQTESkillID(bool isPvp)
		{
			List<Skill> curSkillList = this.GetCurSkillList(isPvp, SkillSystemSourceType.None);
			for (int i = 0; i < curSkillList.Count; i++)
			{
				int id = (int)curSkillList[i].id;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.IsQTE > 0 && id > 0)
				{
					return id;
				}
			}
			return 0;
		}

		// Token: 0x0600BBE7 RID: 48103 RVA: 0x002BB4F8 File Offset: 0x002B98F8
		public int GetRunAttackSkillID(bool isPvp)
		{
			List<Skill> curSkillList = this.GetCurSkillList(isPvp, SkillSystemSourceType.None);
			for (int i = 0; i < curSkillList.Count; i++)
			{
				int id = (int)curSkillList[i].id;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.IsRunAttack > 0 && id > 0)
				{
					return id;
				}
			}
			return 0;
		}

		// Token: 0x0600BBE8 RID: 48104 RVA: 0x002BB564 File Offset: 0x002B9964
		public bool IsEquipSkill(int iSkillID)
		{
			for (int i = 0; i < this.skillBar.Count; i++)
			{
				if ((int)this.skillBar[i].id == iSkillID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BBE9 RID: 48105 RVA: 0x002BB5A8 File Offset: 0x002B99A8
		public bool IsEquipFairDuelSKill(int skillID)
		{
			for (int i = 0; i < this.FairDuelSkillBar.Count; i++)
			{
				if ((int)this.FairDuelSkillBar[i].id == skillID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BBEA RID: 48106 RVA: 0x002BB5EC File Offset: 0x002B99EC
		public bool IsSkillBarFull(SkillConfigType skillType)
		{
			List<Skill> list = new List<Skill>();
			List<SkillBarGrid> list2 = new List<SkillBarGrid>();
			if (skillType != SkillConfigType.SKILL_CONFIG_PVE)
			{
				if (skillType == SkillConfigType.SKILL_CONFIG_PVP)
				{
					list = this.GetPvpSkillList();
					list2 = this.GetPvpSkillBar();
				}
			}
			else
			{
				list = this.GetPveSkillList();
				list2 = this.GetPveSkillBar();
			}
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(level, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return true;
			}
			int num = tableItem.SkillNum;
			if (level >= this.UnLockTaskLvl && !this.IsFinishUnlockTask)
			{
				num--;
			}
			bool flag = true;
			int i = 0;
			while (i < list.Count)
			{
				bool flag2 = false;
				for (int j = 0; j < list2.Count; j++)
				{
					if (list[i].id == list2[j].id)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					goto IL_13B;
				}
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)list[i].id, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (tableItem2.SkillType == SkillTable.eSkillType.ACTIVE && tableItem2.BindButtonIndex > 0)
					{
						flag = false;
						goto IL_13B;
					}
				}
				IL_147:
				i++;
				continue;
				IL_13B:
				if (!flag)
				{
					break;
				}
				goto IL_147;
			}
			return list2.Count >= num || flag;
		}

		// Token: 0x0600BBEB RID: 48107 RVA: 0x002BB76C File Offset: 0x002B9B6C
		public bool IsFairDuelSkillBarFull(int maxLevel)
		{
			List<Skill> fairDuelSkillList = this.FairDuelSkillList;
			List<SkillBarGrid> fairDuelSkillBar = this.FairDuelSkillBar;
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(maxLevel, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return true;
			}
			bool flag = true;
			int i = 0;
			while (i < fairDuelSkillList.Count)
			{
				bool flag2 = false;
				for (int j = 0; j < fairDuelSkillBar.Count; j++)
				{
					if (fairDuelSkillList[i].id == fairDuelSkillBar[j].id)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					goto IL_D2;
				}
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)fairDuelSkillList[i].id, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (tableItem2.SkillType == SkillTable.eSkillType.ACTIVE && tableItem2.BindButtonIndex > 0)
					{
						flag = false;
						goto IL_D2;
					}
				}
				IL_DD:
				i++;
				continue;
				IL_D2:
				if (!flag)
				{
					break;
				}
				goto IL_DD;
			}
			return fairDuelSkillBar.Count >= tableItem.SkillNum || flag;
		}

		// Token: 0x0600BBEC RID: 48108 RVA: 0x002BB884 File Offset: 0x002B9C84
		public void InitSkillData(int iLevel)
		{
			Dictionary<int, int> skillInfoByPid = Singleton<TableManager>.GetInstance().GetSkillInfoByPid(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			Dictionary<int, int> commonSkillList = Singleton<TableManager>.GetInstance().GetCommonSkillList();
			this.UniqueButtonBindSkill.Clear();
			this.PassiveButtonBindSkill.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in skillInfoByPid)
			{
				int key = keyValuePair.Key;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(key, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", key));
					return;
				}
				if (tableItem.SkillCategory != 1)
				{
					if (tableItem.BindButtonIndex > 0 && !this.UniqueButtonBindSkill.ContainsKey(tableItem.BindButtonIndex))
					{
						this.UniqueButtonBindSkill.Add(tableItem.BindButtonIndex, key);
						if (iLevel < tableItem.LevelLimit)
						{
							this.LockSkillList.Add(key);
						}
					}
					if (tableItem.PassiveSkillBtnIndex > 0)
					{
						PassiveSkillData item = default(PassiveSkillData);
						item.skillid = key;
						item.skillslot = tableItem.PassiveSkillBtnIndex;
						bool flag = false;
						for (int i = 0; i < this.PassiveButtonBindSkill.Count; i++)
						{
							if (tableItem.PassiveSkillBtnIndex < this.PassiveButtonBindSkill[i].skillslot)
							{
								this.PassiveButtonBindSkill.Insert(i, item);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							this.PassiveButtonBindSkill.Add(item);
						}
					}
				}
			}
			this.CommonButtonBindSkill.Clear();
			foreach (int key2 in commonSkillList.Keys)
			{
				int num = 0;
				if (commonSkillList.TryGetValue(key2, out num))
				{
					this.CommonButtonBindSkill.Add(key2, num);
					SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (iLevel < tableItem2.LevelLimit)
						{
							this.LockSkillList.Add(num);
						}
					}
				}
			}
			JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem3 != null && tableItem3.InitSkills.Count > 0 && tableItem3.InitSkills[0] != 0)
			{
				this.InitSkills = new List<int>(tableItem3.InitSkills);
			}
			this._UpdateNewSkillList();
		}

		// Token: 0x0600BBED RID: 48109 RVA: 0x002BBB38 File Offset: 0x002B9F38
		private void _UpdateNewSkillList()
		{
			this.NewOpenUniSkillList.Clear();
			for (int i = 0; i < this.LockSkillList.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(this.LockSkillList[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.LevelLimit <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						if (tableItem.LevelLimit > this.LastSeeSkillLv)
						{
							if (tableItem.SkillCategory == 3)
							{
								this.NewOpenUniSkillList.Add(this.LockSkillList[i]);
								this.NewOpenSkillAll.Add(this.LockSkillList[i]);
							}
							else if (tableItem.SkillCategory == 2)
							{
								this.NewOpenComSkillList.Add(this.LockSkillList[i]);
								this.NewOpenSkillAll.Add(this.LockSkillList[i]);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BBEE RID: 48110 RVA: 0x002BBC41 File Offset: 0x002BA041
		public bool isSkillNew(int id)
		{
			if (this.NewOpenSkillAll.Contains(id))
			{
				this.NewOpenSkillAll.Remove(id);
				return true;
			}
			return false;
		}

		// Token: 0x0600BBEF RID: 48111 RVA: 0x002BBC64 File Offset: 0x002BA064
		public void UpdateLockSkillList(List<int> AlreadyLookSkill)
		{
			this.NewOpenUniSkillList.Clear();
		}

		// Token: 0x0600BBF0 RID: 48112 RVA: 0x002BBC74 File Offset: 0x002BA074
		public bool CheckInitSkills(int SkillID)
		{
			for (int i = 0; i < this.InitSkills.Count; i++)
			{
				if (this.InitSkills[i] == SkillID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BBF1 RID: 48113 RVA: 0x002BBCB4 File Offset: 0x002BA0B4
		public Dictionary<int, SkillLevelAddInfo> GetSkillLevelAddInfo(bool isPVE, List<ItemProperty> equips = null, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
		{
			Dictionary<int, SkillLevelAddInfo> dictionary = new Dictionary<int, SkillLevelAddInfo>();
			if (equips == null)
			{
				equips = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
			}
			for (int i = 0; i < equips.Count; i++)
			{
				if (isPVE)
				{
					this.ExtractSkillLevelAddInfo(equips[i].attachBuffIDs, dictionary, SkillLevelAddType.EQUIP);
				}
				else
				{
					this.ExtractSkillLevelAddInfo(equips[i].attachPVPBuffIDs, dictionary, SkillLevelAddType.EQUIP);
				}
			}
			bool ispvp = !isPVE;
			BeActor mainPlayerActor = BeUtility.GetMainPlayerActor(ispvp, equips, skillSourceType);
			foreach (KeyValuePair<int, CrypticInt32> keyValuePair in mainPlayerActor.GetEntityData().skillLevelInfo)
			{
				int skillID = keyValuePair.Key;
				Skill skill = new Skill();
				if (isPVE)
				{
					if (this.CurPVESKillPage == EPVESkillPage.Page1)
					{
						skill = this.skillList.Find((Skill x) => (int)x.id == skillID);
					}
					else
					{
						skill = this.skillList2.Find((Skill x) => (int)x.id == skillID);
					}
				}
				else if (skillSourceType == SkillSystemSourceType.FairDuel)
				{
					skill = this.FairDuelSkillList.Find((Skill x) => (int)x.id == skillID);
				}
				else if (this.CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					skill = this.pvpSkillList.Find((Skill x) => (int)x.id == skillID);
				}
				else
				{
					skill = this.pvpSkillList2.Find((Skill x) => (int)x.id == skillID);
				}
				if (skill != null)
				{
					int num = keyValuePair.Value - (int)skill.level;
					if (!dictionary.ContainsKey(skillID))
					{
						dictionary.Add(skillID, new SkillLevelAddInfo());
					}
					SkillLevelAddInfo skillLevelAddInfo = dictionary[skillID];
					skillLevelAddInfo.totalAddLevel = num;
					int currentTotalAddNum = skillLevelAddInfo.GetCurrentTotalAddNum();
					if (currentTotalAddNum < num)
					{
						skillLevelAddInfo.items.Add(new SkillLevelAddItem(SkillLevelAddType.SKILL, num - currentTotalAddNum));
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0600BBF2 RID: 48114 RVA: 0x002BBEE4 File Offset: 0x002BA2E4
		public int GetAddedSkillLevel(int iSkillID, Dictionary<int, SkillLevelAddInfo> AddSkillLevelInfo)
		{
			SkillLevelAddInfo skillLevelAddInfo = null;
			if (AddSkillLevelInfo == null)
			{
				return 0;
			}
			if (AddSkillLevelInfo.TryGetValue(iSkillID, out skillLevelAddInfo))
			{
				return skillLevelAddInfo.totalAddLevel;
			}
			return 0;
		}

		// Token: 0x0600BBF3 RID: 48115 RVA: 0x002BBF14 File Offset: 0x002BA314
		public SkillLevelAddInfo GetAddedSkillInfo(int iSkillID, Dictionary<int, SkillLevelAddInfo> AddSkillLevelInfo)
		{
			if (AddSkillLevelInfo == null)
			{
				return null;
			}
			SkillLevelAddInfo result = null;
			if (!AddSkillLevelInfo.TryGetValue(iSkillID, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600BBF4 RID: 48116 RVA: 0x002BBF3C File Offset: 0x002BA33C
		private void ExtractSkillLevelAddInfo(List<BuffInfoData> buffInfos, Dictionary<int, SkillLevelAddInfo> info, SkillLevelAddType type)
		{
			for (int i = 0; i < buffInfos.Count; i++)
			{
				BuffInfoData buffInfoData = buffInfos[i];
				if (buffInfoData != null && buffInfoData.skillIDs != null && buffInfoData.skillIDs.Count > 0 && buffInfoData.skillIDs[0] > 0)
				{
					for (int j = 0; j < buffInfoData.skillIDs.Count; j++)
					{
						int skillID = buffInfoData.skillIDs[j];
						int num = 0;
						BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffInfoData.buffID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num = TableManager.GetValueFromUnionCell(tableItem.level, buffInfoData.level, true);
						}
						if (num > 0)
						{
							this.FillSkill(skillID, num, info, type, true);
						}
					}
				}
			}
		}

		// Token: 0x0600BBF5 RID: 48117 RVA: 0x002BC020 File Offset: 0x002BA420
		private void ExtractSkillLevelAddInfo(IList<int> buffInfoIDs, Dictionary<int, SkillLevelAddInfo> info, SkillLevelAddType type)
		{
			List<BuffInfoData> list = new List<BuffInfoData>();
			for (int i = 0; i < buffInfoIDs.Count; i++)
			{
				BuffInfoData buffInfoData = new BuffInfoData(buffInfoIDs[i], 1, 0);
				list.Add(buffInfoData);
				if (buffInfoData.data != null)
				{
					if (buffInfoData.data.RelatedSkillLV.Length == 1)
					{
						int num = buffInfoData.data.RelatedSkillLV[0];
						if (num != 0)
						{
							foreach (Skill skill in this.GetPveSkillList())
							{
								if (skill != null)
								{
									SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skill.id, string.Empty, string.Empty);
									List<Skill>.Enumerator enumerator;
									if (tableItem != null && tableItem.LevelLimit == num && !buffInfoData.skillIDs.Contains((int)enumerator.Current.id))
									{
										buffInfoData.skillIDs.Add((int)enumerator.Current.id);
									}
								}
							}
						}
					}
					else if (buffInfoData.data.RelatedSkillLV.Length == 2)
					{
						int num2 = buffInfoData.data.RelatedSkillLV[0];
						int num3 = buffInfoData.data.RelatedSkillLV[1];
						if (num2 > 0 && num2 < num3)
						{
							foreach (Skill skill2 in this.GetPveSkillList())
							{
								if (skill2 != null)
								{
									SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skill2.id, string.Empty, string.Empty);
									List<Skill>.Enumerator enumerator2;
									if (tableItem2 != null && tableItem2.LevelLimit >= num2 && tableItem2.LevelLimit <= num3 && !buffInfoData.skillIDs.Contains((int)enumerator2.Current.id))
									{
										buffInfoData.skillIDs.Add((int)enumerator2.Current.id);
									}
								}
							}
						}
					}
				}
			}
			this.ExtractSkillLevelAddInfo(list, info, type);
		}

		// Token: 0x0600BBF6 RID: 48118 RVA: 0x002BC228 File Offset: 0x002BA628
		private void FillSkill(int skillID, int addLevel, Dictionary<int, SkillLevelAddInfo> info, SkillLevelAddType type, bool merge = true)
		{
			List<Skill> pveSkillList = this.GetPveSkillList();
			Skill skill = pveSkillList.Find((Skill x) => (int)x.id == skillID);
			if (skill != null)
			{
				if (!info.ContainsKey(skillID))
				{
					info.Add(skillID, new SkillLevelAddInfo());
				}
				if (!merge)
				{
					SkillLevelAddInfo skillLevelAddInfo = info[skillID];
					skillLevelAddInfo.items.Add(new SkillLevelAddItem(type, addLevel));
				}
				else
				{
					SkillLevelAddInfo skillLevelAddInfo2 = info[skillID];
					SkillLevelAddItem skillLevelAddItem = skillLevelAddInfo2.items.Find((SkillLevelAddItem x) => x.type == type);
					if (skillLevelAddItem != null)
					{
						skillLevelAddItem.addLevel += addLevel;
					}
					else
					{
						info[skillID].items.Add(new SkillLevelAddItem(type, addLevel));
					}
				}
			}
		}

		// Token: 0x0600BBF7 RID: 48119 RVA: 0x002BC324 File Offset: 0x002BA724
		public string UpdateSkillDescription(int skillID, byte AlreadyLearnLv, byte NeedShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			string text = string.Empty;
			if (NeedShowLv <= 0)
			{
				return TR.Value("NotLearnSkillDes");
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return text;
			}
			if (NeedShowLv > (byte)tableItem.TopLevel)
			{
				return TR.Value("MaxLvSkillDes");
			}
			List<string> skillDesList = this.GetSkillDesList(skillID, NeedShowLv, TypeLabel);
			for (int i = 0; i < skillDesList.Count; i++)
			{
				string[] array = skillDesList[i].Split(new char[]
				{
					':'
				});
				if (array.Length >= 2)
				{
					string text2 = array[0] + ":<color=";
					if (AlreadyLearnLv < NeedShowLv)
					{
						text2 += "lime>";
					}
					else if (AlreadyLearnLv == NeedShowLv)
					{
						text2 += "white>";
					}
					else
					{
						text2 += "red>";
					}
					if (i == skillDesList.Count - 1)
					{
						text2 = text2 + array[1] + "</color>";
					}
					else
					{
						text2 = text2 + array[1] + "</color>\n";
					}
					text += text2;
				}
			}
			return text;
		}

		// Token: 0x0600BBF8 RID: 48120 RVA: 0x002BC45C File Offset: 0x002BA85C
		public string UpdatePetSkillDescription(int skillID, byte AlreadyLearnLv, byte NeedShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			string text = string.Empty;
			if (NeedShowLv <= 0)
			{
				return "当前未学习\n";
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return text;
			}
			if (NeedShowLv > (byte)tableItem.TopLevel)
			{
				return "已精通该技能，技能效果已达上限\n";
			}
			List<string> petSkillDesList = this.GetPetSkillDesList(skillID, NeedShowLv, TypeLabel);
			for (int i = 0; i < petSkillDesList.Count; i++)
			{
				string[] array = petSkillDesList[i].Split(new char[]
				{
					':'
				});
				if (array.Length < 2)
				{
					string str = array[0];
					text = text + str + "\n";
				}
				else
				{
					string text2 = array[0] + ":<color=";
					if (AlreadyLearnLv < NeedShowLv)
					{
						text2 += "lime>";
					}
					else if (AlreadyLearnLv == NeedShowLv)
					{
						text2 += "white>";
					}
					else
					{
						text2 += "red>";
					}
					if (i == petSkillDesList.Count - 1)
					{
						text2 = text2 + array[1] + "</color>";
					}
					else
					{
						text2 = text2 + array[1] + "</color>\n";
					}
					text += text2;
				}
			}
			return text;
		}

		// Token: 0x0600BBF9 RID: 48121 RVA: 0x002BC5A0 File Offset: 0x002BA9A0
		public List<string> GetPetSkillDesList(int skillid, byte skillShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			List<string> list = new List<string>();
			if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillid, string.Empty, string.Empty) == null)
			{
				return list;
			}
			SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return list;
			}
			PropertyInfo[] properties = tableItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
			string text = string.Empty;
			int num = 1;
			List<object> list2 = new List<object>();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo != null)
				{
					string a = string.Format("DataText{0}", num);
					string a2 = string.Format("DataNumber{0}", num);
					string a3 = string.Format("Description", new object[0]);
					if (TypeLabel == FightTypeLabel.PVP)
					{
						a2 = string.Format("PVPDataNum{0}", num);
					}
					if (a3 == propertyInfo.Name)
					{
						if (propertyInfo.GetValue(tableItem, null) as string == "0")
						{
							break;
						}
						text = (propertyInfo.GetValue(tableItem, null) as string);
						list.Add(text);
					}
					if (a == propertyInfo.Name)
					{
						if (propertyInfo.GetValue(tableItem, null) as string == "0")
						{
							break;
						}
						text = (propertyInfo.GetValue(tableItem, null) as string);
					}
					if (tableItem.DescType == 2)
					{
						string a4 = string.Format("PVPDataNum{0}", num);
						if (a2 == propertyInfo.Name)
						{
							list2 = new List<object>();
							bool flag = true;
							object[] skillValues = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag);
							list2.AddRange(skillValues);
						}
						else if (a4 == propertyInfo.Name)
						{
							bool flag2 = true;
							object[] skillValues2 = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag2);
							list2.AddRange(skillValues2);
							object[] array = new object[list2.Count];
							for (int j = 0; j < list2.Count; j++)
							{
								array[j] = list2[j];
							}
							try
							{
								if (flag2)
								{
									text = string.Format(text, array);
								}
								else
								{
									text = "-";
								}
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("[技能描述表string.Format参数长度不一致,让策划检查表格], skillid = {0}, skillShowLv = {1}, e = {2}", new object[]
								{
									skillid,
									skillShowLv,
									ex.ToString()
								});
							}
							list.Add(text);
							num++;
						}
					}
					else if (a2 == propertyInfo.Name)
					{
						bool flag3 = true;
						object[] skillValues3 = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag3);
						try
						{
							if (flag3)
							{
								text = string.Format(text, skillValues3);
							}
							else
							{
								text = "-";
							}
						}
						catch (Exception ex2)
						{
							Logger.LogErrorFormat("[技能描述表string.Format参数长度不一致,让策划检查表格], skillid = {0}, skillShowLv = {1}, e = {2}", new object[]
							{
								skillid,
								skillShowLv,
								ex2.ToString()
							});
						}
						list.Add(text);
						num++;
					}
				}
			}
			return list;
		}

		// Token: 0x0600BBFA RID: 48122 RVA: 0x002BC8EC File Offset: 0x002BACEC
		private object[] GetSkillValues(PropertyInfo propertyInfo, SkillDescriptionTable SkillDescription, byte skillShowLv, ref bool DescDataIsValid)
		{
			string text = propertyInfo.GetValue(SkillDescription, null) as string;
			string[] array = text.Split(new char[]
			{
				';'
			});
			if (array.Length > 0 && (array[0] == "-" || array[0] == string.Empty))
			{
				DescDataIsValid = false;
				return null;
			}
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string[] array3 = array[i].Split(new char[]
				{
					','
				});
				if (array3.Length == 1)
				{
					array2[i] = array3[0];
				}
				else if (array3.Length == 2)
				{
					float fdata = float.Parse(array3[0]) + float.Parse(array3[1]) * (float)(skillShowLv - 1);
					array2[i] = Utility.GetStringByFloat(fdata);
				}
				else
				{
					if ((int)skillShowLv > array3.Length)
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("技能描述表技能id = {0} 所填数据长度与技能极限等级长度不匹配，打策划", SkillDescription.ID), null, string.Empty, false);
						break;
					}
					for (int j = 0; j < array3.Length; j++)
					{
						if (j == (int)(skillShowLv - 1))
						{
							array2[i] = array3[j];
							break;
						}
					}
				}
			}
			return array2;
		}

		// Token: 0x0600BBFB RID: 48123 RVA: 0x002BCA28 File Offset: 0x002BAE28
		public List<string> GetSkillDesList(int skillid, byte skillShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			List<string> list = new List<string>();
			if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillid, string.Empty, string.Empty) == null)
			{
				return list;
			}
			SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return list;
			}
			PropertyInfo[] properties = tableItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
			string text = string.Empty;
			int num = 1;
			List<object> list2 = new List<object>();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo != null)
				{
					string a = string.Format("DataText{0}", num);
					string a2 = string.Format("DataNumber{0}", num);
					if (TypeLabel == FightTypeLabel.PVP)
					{
						a2 = string.Format("PVPDataNum{0}", num);
					}
					if (a == propertyInfo.Name)
					{
						if (propertyInfo.GetValue(tableItem, null) as string == "0")
						{
							break;
						}
						text = (propertyInfo.GetValue(tableItem, null) as string);
					}
					if (tableItem.DescType == 2)
					{
						string a3 = string.Format("PVPDataNum{0}", num);
						if (a2 == propertyInfo.Name)
						{
							list2 = new List<object>();
							bool flag = true;
							object[] skillValues = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag);
							list2.AddRange(skillValues);
						}
						else if (a3 == propertyInfo.Name)
						{
							bool flag2 = true;
							object[] skillValues2 = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag2);
							list2.AddRange(skillValues2);
							object[] array = new object[list2.Count];
							for (int j = 0; j < list2.Count; j++)
							{
								array[j] = list2[j];
							}
							try
							{
								if (flag2)
								{
									text = string.Format(text, array);
								}
								else
								{
									text = "-";
								}
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("[技能描述表string.Format参数长度不一致,让策划检查表格], skillid = {0}, skillShowLv = {1}, e = {2}", new object[]
								{
									skillid,
									skillShowLv,
									ex.ToString()
								});
							}
							list.Add(text);
							num++;
						}
					}
					else if (a2 == propertyInfo.Name)
					{
						bool flag3 = true;
						object[] skillValues3 = this.GetSkillValues(propertyInfo, tableItem, skillShowLv, ref flag3);
						try
						{
							if (flag3)
							{
								text = string.Format(text, skillValues3);
							}
							else
							{
								text = "-";
							}
						}
						catch (Exception ex2)
						{
							Logger.LogErrorFormat("[技能描述表string.Format参数长度不一致,让策划检查表格], skillid = {0}, skillShowLv = {1}, e = {2}", new object[]
							{
								skillid,
								skillShowLv,
								ex2.ToString()
							});
						}
						list.Add(text);
						num++;
					}
				}
			}
			return list;
		}

		// Token: 0x0600BBFC RID: 48124 RVA: 0x002BCD14 File Offset: 0x002BB114
		public List<float> GetSkillDataList(int skillid, byte skillShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			List<float> list = new List<float>();
			if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillid, string.Empty, string.Empty) == null)
			{
				return list;
			}
			SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return list;
			}
			PropertyInfo[] properties = tableItem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
			int num = 1;
			for (int i = 0; i < properties.Length; i++)
			{
				string a = string.Format("DataNumber{0}", num);
				if (TypeLabel == FightTypeLabel.PVP)
				{
					a = string.Format("PVPDataNum{0}", num);
				}
				if (a == properties[i].Name)
				{
					string text = properties[i].GetValue(tableItem, null) as string;
					if (!(text == "0"))
					{
						string[] array = text.Split(new char[]
						{
							';'
						});
						string[] array2 = new string[array.Length];
						if (array.Length <= 0 || (!(array[0] == "-") && !(array[0] == string.Empty)))
						{
							for (int j = 0; j < array.Length; j++)
							{
								string[] array3 = array[j].Split(new char[]
								{
									','
								});
								if (array3.Length == 1)
								{
									array2[j] = array3[0];
								}
								else if (array3.Length == 2)
								{
									float fdata = float.Parse(array3[0]) + float.Parse(array3[1]) * (float)(skillShowLv - 1);
									array2[j] = Utility.GetStringByFloat(fdata);
								}
								else
								{
									if ((int)skillShowLv > array3.Length)
									{
										SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("技能描述表技能id = {0} 所填数据长度与技能极限等级长度不匹配，打策划", skillid), null, string.Empty, false);
										break;
									}
									for (int k = 0; k < array3.Length; k++)
									{
										if (k == (int)(skillShowLv - 1))
										{
											array2[j] = array3[k];
											break;
										}
									}
								}
							}
							list.Add(float.Parse(array2[0]));
							num++;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BBFD RID: 48125 RVA: 0x002BCF40 File Offset: 0x002BB340
		public string GetSkillDes(int skillid, byte skillShowLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			string result = string.Empty;
			SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			List<float> skillDataList = this.GetSkillDataList(skillid, skillShowLv, TypeLabel);
			if (skillDataList.Count > 0)
			{
				object[] array = new object[skillDataList.Count];
				for (int i = 0; i < skillDataList.Count; i++)
				{
					array[i] = skillDataList[i];
				}
				result = string.Format(tableItem.Description, array);
			}
			return result;
		}

		// Token: 0x0600BBFE RID: 48126 RVA: 0x002BCFD0 File Offset: 0x002BB3D0
		public bool CheckSkillLvUp(int SkillID)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit)
			{
				return false;
			}
			int num = this.CalSkillLvFromOutside(tableItem);
			if (!this.CanLvUpByCurRoleLv(tableItem, (byte)num))
			{
				return false;
			}
			if (num >= (int)((byte)tableItem.TopLevelLimit))
			{
				return false;
			}
			if (num == 0 && tableItem.PreSkills.Count > 0 && tableItem.PreSkills[0] > 0 && !this.CheckPreSkillsFromOutside(tableItem))
			{
				return false;
			}
			uint num2 = 0U;
			if (this.CurPVESKillPage == EPVESkillPage.Page1)
			{
				num2 = DataManager<PlayerBaseData>.GetInstance().SP;
			}
			else if (this.CurPVESKillPage == EPVESkillPage.Page2)
			{
				num2 = DataManager<PlayerBaseData>.GetInstance().SP2;
			}
			return (ulong)num2 >= (ulong)((long)tableItem.LearnSPCost);
		}

		// Token: 0x0600BBFF RID: 48127 RVA: 0x002BD0B8 File Offset: 0x002BB4B8
		public bool CheckPreSkillsFromOutside(SkillTable skillData)
		{
			if (skillData.PreSkills.Count != skillData.PreSkillsLevel.Count)
			{
				Logger.LogError(string.Format("技能表 {0} 的前置技能与等级数组长度不等，请检查表格", skillData.ID));
				return false;
			}
			for (int i = 0; i < skillData.PreSkills.Count; i++)
			{
				if (Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillData.PreSkills[i], string.Empty, string.Empty) == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillData.PreSkills[i]));
					return false;
				}
				if (this.CalSkillLvFromOutside(skillData) < (int)((byte)skillData.PreSkillsLevel[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600BC00 RID: 48128 RVA: 0x002BD180 File Offset: 0x002BB580
		public int CalSkillLvFromOutside(SkillTable skillData)
		{
			int result = 0;
			List<Skill> pveSkillList = this.GetPveSkillList();
			for (int i = 0; i < pveSkillList.Count; i++)
			{
				if (skillData.ID == (int)pveSkillList[i].id)
				{
					return (int)pveSkillList[i].level;
				}
			}
			return result;
		}

		// Token: 0x0600BC01 RID: 48129 RVA: 0x002BD1D4 File Offset: 0x002BB5D4
		public bool CanLvUpByCurRoleLv(SkillTable skilldata, byte SkillCurLv)
		{
			bool result = false;
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			if (skilldata.LevelLimit + skilldata.LevelLimitAmend * (int)SkillCurLv <= (int)level)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600BC02 RID: 48130 RVA: 0x002BD208 File Offset: 0x002BB608
		public bool CanFairDuelLvUpByCurRoleLv(SkillTable skilldata, byte SkillCurLv, ushort playerLv)
		{
			bool result = false;
			if (skilldata.LevelLimit + skilldata.LevelLimitAmend * (int)SkillCurLv <= (int)playerLv)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600BC03 RID: 48131 RVA: 0x002BD230 File Offset: 0x002BB630
		public bool HasSkillLvCanUp()
		{
			foreach (KeyValuePair<int, int> keyValuePair in this.UniqueButtonBindSkill)
			{
				int value = keyValuePair.Value;
				if (this.CheckSkillLvUp(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BC04 RID: 48132 RVA: 0x002BD27C File Offset: 0x002BB67C
		public bool HasNewSkillorSkillCanUp()
		{
			Dictionary<int, int>.Enumerator enumerator = this.UniqueButtonBindSkill.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				SkillTable tableItem = instance.GetTableItem<SkillTable>(keyValuePair.Value, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.LevelLimit == (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						return true;
					}
					if (tableItem.LevelLimit < (int)DataManager<PlayerBaseData>.GetInstance().Level && this.CheckSkillLvUp(tableItem.ID))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600BC05 RID: 48133 RVA: 0x002BD310 File Offset: 0x002BB710
		public int GetSkillNextOpenNeedRoleLv(SkillTable skilldata, int iCurSkillLv)
		{
			return skilldata.LevelLimit + skilldata.LevelLimitAmend * iCurSkillLv;
		}

		// Token: 0x0600BC06 RID: 48134 RVA: 0x002BD324 File Offset: 0x002BB724
		public string GetSkillDescription(SkillTable skillData)
		{
			SkillDescriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillData.ID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能描述表没有ID为 {0} 的条目", skillData.ID));
				return string.Empty;
			}
			return tableItem.Description;
		}

		// Token: 0x0600BC07 RID: 48135 RVA: 0x002BD378 File Offset: 0x002BB778
		public string GetSkillType(SkillTable skillData)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(skillData.ID, string.Empty, string.Empty) == null)
			{
				Logger.LogError(string.Format("技能描述表没有ID为 {0} 的条目", skillData.ID));
				return string.Empty;
			}
			if (skillData.IsBuff == 1)
			{
				return "[Buff技能]";
			}
			if (skillData.IsQTE != 0)
			{
				return "[被动技能]";
			}
			if (skillData.SkillType == SkillTable.eSkillType.ACTIVE)
			{
				return "[主动技能]";
			}
			if (skillData.SkillType == SkillTable.eSkillType.PASSIVE)
			{
				return "[被动技能]";
			}
			return string.Empty;
		}

		// Token: 0x0600BC08 RID: 48136 RVA: 0x002BD412 File Offset: 0x002BB812
		public bool isPve()
		{
			return this.CurSkillConfigType == SkillConfigType.SKILL_CONFIG_PVE;
		}

		// Token: 0x0600BC09 RID: 48137 RVA: 0x002BD41D File Offset: 0x002BB81D
		public List<Skill> GetSkillListBattle(bool isPvp)
		{
			return (!isPvp) ? this.GetPveSkillList() : this.GetPvpSkillList();
		}

		// Token: 0x0600BC0A RID: 48138 RVA: 0x002BD438 File Offset: 0x002BB838
		public List<Skill> GetPvpSkillList()
		{
			List<Skill> result = null;
			if (this.CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				result = this.pvpSkillList;
			}
			else if (this.CurPVPSKillPage == EPVPSkillPage.Page2)
			{
				result = this.pvpSkillList2;
			}
			return result;
		}

		// Token: 0x0600BC0B RID: 48139 RVA: 0x002BD474 File Offset: 0x002BB874
		public List<Skill> GetPveSkillList()
		{
			List<Skill> result = null;
			if (this.CurPVESKillPage == EPVESkillPage.Page1)
			{
				result = this.skillList;
			}
			else if (this.CurPVESKillPage == EPVESkillPage.Page2)
			{
				result = this.skillList2;
			}
			return result;
		}

		// Token: 0x0600BC0C RID: 48140 RVA: 0x002BD4B0 File Offset: 0x002BB8B0
		public List<SkillBar> GetPvpSkillBarSolution()
		{
			List<SkillBar> result;
			if (this.CurPVESKillPage == EPVESkillPage.Page1)
			{
				result = this.skillBarSolution;
			}
			else
			{
				result = this.pvpSkillBarSolution;
			}
			return result;
		}

		// Token: 0x0600BC0D RID: 48141 RVA: 0x002BD4E0 File Offset: 0x002BB8E0
		public List<SkillBarGrid> GetPvpSkillBar()
		{
			List<SkillBarGrid> result = null;
			if (this.CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				result = this.pvpSkillBar;
			}
			else if (this.CurPVPSKillPage == EPVPSkillPage.Page2)
			{
				result = this.pvpSkillBar2;
			}
			return result;
		}

		// Token: 0x0600BC0E RID: 48142 RVA: 0x002BD51C File Offset: 0x002BB91C
		public List<SkillBarGrid> GetPveSkillBar()
		{
			List<SkillBarGrid> result = null;
			if (this.CurPVESKillPage == EPVESkillPage.Page1)
			{
				result = this.skillBar;
			}
			else if (this.CurPVESKillPage == EPVESkillPage.Page2)
			{
				result = this.skillBar2;
			}
			return result;
		}

		// Token: 0x0600BC0F RID: 48143 RVA: 0x002BD556 File Offset: 0x002BB956
		public List<SkillBarGrid> GetChijiSkillBar()
		{
			return this.ChijiSkillBar;
		}

		// Token: 0x0600BC10 RID: 48144 RVA: 0x002BD55E File Offset: 0x002BB95E
		public List<Skill> GetChijiSkillList()
		{
			return this.ChijiSkillList;
		}

		// Token: 0x0600BC11 RID: 48145 RVA: 0x002BD566 File Offset: 0x002BB966
		public List<SkillBarGrid> GetFairDuelSkillBar()
		{
			return this.FairDuelSkillBar;
		}

		// Token: 0x0600BC12 RID: 48146 RVA: 0x002BD56E File Offset: 0x002BB96E
		public List<Skill> GetFairDuelSkillList()
		{
			return this.FairDuelSkillList;
		}

		// Token: 0x0600BC13 RID: 48147 RVA: 0x002BD576 File Offset: 0x002BB976
		public bool IsShowSkillButton()
		{
			return DataManager<PlayerBaseData>.GetInstance().Level >= 15;
		}

		// Token: 0x0600BC14 RID: 48148 RVA: 0x002BD58C File Offset: 0x002BB98C
		private void BindEvents()
		{
			NetProcess.AddMsgHandler(500714U, new Action<MsgDATA>(this.OnReceiveSceneInitSkillsRes));
			NetProcess.AddMsgHandler(500716U, new Action<MsgDATA>(this.OnReceiveSceneRecommendSkillsRes));
			NetProcess.AddMsgHandler(508904U, new Action<MsgDATA>(this.OnChijiLearnSkillRes));
			NetProcess.AddMsgHandler(501227U, new Action<MsgDATA>(this._OnReciveSetEqualPvpSkillConfigRes));
			NetProcess.AddMsgHandler(500717U, new Action<MsgDATA>(this._OnReceiveSkillSlotUnLockNotify));
			NetProcess.AddMsgHandler(500719U, new Action<MsgDATA>(this._OnReceiveSetSkillPageRes));
			NetProcess.AddMsgHandler(500721U, new Action<MsgDATA>(this._OnReceiveBuySkillPageRes));
		}

		// Token: 0x0600BC15 RID: 48149 RVA: 0x002BD634 File Offset: 0x002BBA34
		private void UnBindEvents()
		{
			NetProcess.RemoveMsgHandler(500714U, new Action<MsgDATA>(this.OnReceiveSceneInitSkillsRes));
			NetProcess.RemoveMsgHandler(500716U, new Action<MsgDATA>(this.OnReceiveSceneRecommendSkillsRes));
			NetProcess.RemoveMsgHandler(508904U, new Action<MsgDATA>(this.OnChijiLearnSkillRes));
			NetProcess.RemoveMsgHandler(501227U, new Action<MsgDATA>(this._OnReciveSetEqualPvpSkillConfigRes));
			NetProcess.RemoveMsgHandler(500717U, new Action<MsgDATA>(this._OnReceiveSkillSlotUnLockNotify));
			NetProcess.RemoveMsgHandler(500719U, new Action<MsgDATA>(this._OnReceiveSetSkillPageRes));
			NetProcess.RemoveMsgHandler(500721U, new Action<MsgDATA>(this._OnReceiveBuySkillPageRes));
		}

		// Token: 0x0600BC16 RID: 48150 RVA: 0x002BD6DC File Offset: 0x002BBADC
		public void SendSetSkillConfigReq(byte isSetedEqualPvPConfig)
		{
			SceneSetEqualPvpSkillConfigReq sceneSetEqualPvpSkillConfigReq = new SceneSetEqualPvpSkillConfigReq();
			sceneSetEqualPvpSkillConfigReq.isSetedEqualPvPConfig = isSetedEqualPvPConfig;
			NetManager.Instance().SendCommand<SceneSetEqualPvpSkillConfigReq>(ServerType.GATE_SERVER, sceneSetEqualPvpSkillConfigReq);
		}

		// Token: 0x0600BC17 RID: 48151 RVA: 0x002BD704 File Offset: 0x002BBB04
		private void _OnReciveSetEqualPvpSkillConfigRes(MsgDATA data)
		{
			SceneSetEqualPvpSkillConfigRes sceneSetEqualPvpSkillConfigRes = new SceneSetEqualPvpSkillConfigRes();
			sceneSetEqualPvpSkillConfigRes.decode(data.bytes);
			if (sceneSetEqualPvpSkillConfigRes.result == 0U)
			{
				this.IsHaveSetFairDueSkillBar = false;
				CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("fairduel_setskillBar_content"),
					IsShowNotify = false,
					LeftButtonText = TR.Value("fairduel_setskillBar_cancel"),
					RightButtonText = TR.Value("fairduel_setskillBar_ok"),
					OnRightButtonClickCallBack = new Action(this.OnOpenFairSkillFrame)
				};
				SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
			}
			else
			{
				this.IsHaveSetFairDueSkillBar = true;
			}
		}

		// Token: 0x0600BC18 RID: 48152 RVA: 0x002BD798 File Offset: 0x002BBB98
		private void OnOpenFairSkillFrame()
		{
			this.SendSetSkillConfigReq(1);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelSkillFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BC19 RID: 48153 RVA: 0x002BD7B4 File Offset: 0x002BBBB4
		public void OnSendSceneInitSkillsReq(SkillConfigType configType)
		{
			SceneInitSkillsReq sceneInitSkillsReq = new SceneInitSkillsReq();
			sceneInitSkillsReq.configType = (uint)configType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneInitSkillsReq>(ServerType.GATE_SERVER, sceneInitSkillsReq);
			}
		}

		// Token: 0x0600BC1A RID: 48154 RVA: 0x002BD7EC File Offset: 0x002BBBEC
		private void OnReceiveSceneInitSkillsRes(MsgDATA msgData)
		{
			SceneInitSkillsRes sceneInitSkillsRes = new SceneInitSkillsRes();
			sceneInitSkillsRes.decode(msgData.bytes);
			if (sceneInitSkillsRes.result == 0U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("skill_new_initialize_succeed"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				SystemNotifyManager.SystemNotify((int)sceneInitSkillsRes.result, string.Empty);
			}
		}

		// Token: 0x0600BC1B RID: 48155 RVA: 0x002BD83C File Offset: 0x002BBC3C
		public void OnSendSceneRecommendSkillsReq(SkillConfigType configType)
		{
			SceneRecommendSkillsReq sceneRecommendSkillsReq = new SceneRecommendSkillsReq();
			sceneRecommendSkillsReq.configType = (uint)configType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneRecommendSkillsReq>(ServerType.GATE_SERVER, sceneRecommendSkillsReq);
			}
		}

		// Token: 0x0600BC1C RID: 48156 RVA: 0x002BD874 File Offset: 0x002BBC74
		private void OnReceiveSceneRecommendSkillsRes(MsgDATA msgData)
		{
			SceneRecommendSkillsRes sceneRecommendSkillsRes = new SceneRecommendSkillsRes();
			sceneRecommendSkillsRes.decode(msgData.bytes);
			if (sceneRecommendSkillsRes.result == 0U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("skill_new_recommend_config_succeed"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				SystemNotifyManager.SystemNotify((int)sceneRecommendSkillsRes.result, string.Empty);
			}
		}

		// Token: 0x0600BC1D RID: 48157 RVA: 0x002BD8C4 File Offset: 0x002BBCC4
		private void OnChijiLearnSkillRes(MsgDATA msgData)
		{
			SceneBattleChangeSkillsRes sceneBattleChangeSkillsRes = new SceneBattleChangeSkillsRes();
			sceneBattleChangeSkillsRes.decode(msgData.bytes);
			if (sceneBattleChangeSkillsRes.result != 0U)
			{
				Logger.LogErrorFormat("[SceneBattleChangeSkillsRes] error code = {0}", new object[]
				{
					sceneBattleChangeSkillsRes.result
				});
				return;
			}
		}

		// Token: 0x0600BC1E RID: 48158 RVA: 0x002BD910 File Offset: 0x002BBD10
		public bool IsShowSkillCanLevelUpTip()
		{
			return !this.IsNotShowSkillLevelUpTip && this.IsExistSkillCanLevelUp();
		}

		// Token: 0x0600BC1F RID: 48159 RVA: 0x002BD93C File Offset: 0x002BBD3C
		public bool IsExistSkillCanLevelUp()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(464, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int num = tableItem.Value * (int)DataManager<PlayerBaseData>.GetInstance().Level;
				uint num2 = 0U;
				if (this.isPve())
				{
					if (this.CurPVESKillPage == EPVESkillPage.Page1)
					{
						num2 = DataManager<PlayerBaseData>.GetInstance().SP;
					}
					else if (this.CurPVESKillPage == EPVESkillPage.Page2)
					{
						num2 = DataManager<PlayerBaseData>.GetInstance().SP2;
					}
				}
				else if (this.CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					num2 = DataManager<PlayerBaseData>.GetInstance().pvpSP;
				}
				else if (this.CurPVPSKillPage == EPVPSkillPage.Page2)
				{
					num2 = DataManager<PlayerBaseData>.GetInstance().pvpSP2;
				}
				if ((ulong)num2 < (ulong)((long)num))
				{
					return false;
				}
			}
			return this.HasSkillLvCanUp();
		}

		// Token: 0x0600BC20 RID: 48160 RVA: 0x002BDA0C File Offset: 0x002BBE0C
		public bool IsShowSkillTreeFrameTipBySkillConfig(Action onEnterGame)
		{
			if (this.IsNotShowSkillConfigTip)
			{
				return false;
			}
			if (!DataManager<SkillDataManager>.GetInstance().IsExistSkillCanConfig())
			{
				return false;
			}
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_skill_point_enough"),
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateSkillConfigTip),
				LeftButtonText = TR.Value("skill_new_enter_dungeon"),
				OnLeftButtonClickCallBack = onEnterGame,
				RightButtonText = TR.Value("skill_new_enter_skill_config"),
				OnRightButtonClickCallBack = new Action(this.OnShowTreeFrame)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
			return true;
		}

		// Token: 0x0600BC21 RID: 48161 RVA: 0x002BDAA8 File Offset: 0x002BBEA8
		public bool IsExistSkillCanConfig()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(465, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int num = tableItem.Value * (int)DataManager<PlayerBaseData>.GetInstance().Level;
				uint num2 = 0U;
				if (this.CurPVESKillPage == EPVESkillPage.Page1)
				{
					num2 = DataManager<PlayerBaseData>.GetInstance().SP;
				}
				else if (this.CurPVESKillPage == EPVESkillPage.Page2)
				{
					num2 = DataManager<PlayerBaseData>.GetInstance().SP2;
				}
				if ((ulong)num2 < (ulong)((long)num))
				{
					return false;
				}
			}
			return this.HasSkillLvCanUp();
		}

		// Token: 0x0600BC22 RID: 48162 RVA: 0x002BDB34 File Offset: 0x002BBF34
		private void OnShowTreeFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillTreeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillTreeFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BC23 RID: 48163 RVA: 0x002BDB64 File Offset: 0x002BBF64
		private void OnUpdateSkillConfigTip(bool value)
		{
			this.IsNotShowSkillConfigTip = value;
		}

		// Token: 0x0600BC24 RID: 48164 RVA: 0x002BDB70 File Offset: 0x002BBF70
		public SkillTable GetPassiveAwakeSkillData()
		{
			SkillTable result = null;
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<SkillTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					SkillTable skillTable = keyValuePair.Value as SkillTable;
					if (skillTable != null)
					{
						if (skillTable.SkillType == SkillTable.eSkillType.ACTIVE && skillTable.SkillCategory == 4)
						{
							for (int i = 0; i < skillTable.JobID.Length; i++)
							{
								if (skillTable.JobID[i] == jobTableID)
								{
									result = skillTable;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600BC25 RID: 48165 RVA: 0x002BDC29 File Offset: 0x002BC029
		private void _OnReceiveSkillSlotUnLockNotify(MsgDATA data)
		{
			this.IsFinishUnlockTask = true;
		}

		// Token: 0x0600BC26 RID: 48166 RVA: 0x002BDC34 File Offset: 0x002BC034
		public void SendChooseSkillPage(SkillConfigType config, byte page)
		{
			SceneSetSkillPageReq sceneSetSkillPageReq = new SceneSetSkillPageReq();
			sceneSetSkillPageReq.configType = (uint)((byte)config);
			sceneSetSkillPageReq.page = page;
			NetManager.Instance().SendCommand<SceneSetSkillPageReq>(ServerType.GATE_SERVER, sceneSetSkillPageReq);
		}

		// Token: 0x0600BC27 RID: 48167 RVA: 0x002BDC64 File Offset: 0x002BC064
		private void _OnReceiveSetSkillPageRes(MsgDATA obj)
		{
			SceneSetSkillPageRes sceneSetSkillPageRes = new SceneSetSkillPageRes();
			sceneSetSkillPageRes.decode(obj.bytes);
			if (sceneSetSkillPageRes.result == 0U)
			{
				if (sceneSetSkillPageRes.configType == 1U)
				{
					if (sceneSetSkillPageRes.page == 0)
					{
						this.CurPVESKillPage = EPVESkillPage.Page1;
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Change_SKillConfig1"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						this.CurPVESKillPage = EPVESkillPage.Page2;
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Change_SKillConfig2"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
				else if (sceneSetSkillPageRes.page == 0)
				{
					this.CurPVPSKillPage = EPVPSkillPage.Page1;
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Change_SKillConfig1"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					this.CurPVPSKillPage = EPVPSkillPage.Page2;
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Change_SKillConfig2"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSelectSkillPage, null, null, null, null);
			}
		}

		// Token: 0x0600BC28 RID: 48168 RVA: 0x002BDD34 File Offset: 0x002BC134
		public void SendBuySkillPageReq(SkillConfigType configType, byte page)
		{
			SceneBuySkillPageReq sceneBuySkillPageReq = new SceneBuySkillPageReq();
			sceneBuySkillPageReq.page = page;
			sceneBuySkillPageReq.configType = (uint)((byte)configType);
			NetManager.Instance().SendCommand<SceneBuySkillPageReq>(ServerType.GATE_SERVER, sceneBuySkillPageReq);
		}

		// Token: 0x0600BC29 RID: 48169 RVA: 0x002BDD64 File Offset: 0x002BC164
		private void _OnReceiveBuySkillPageRes(MsgDATA obj)
		{
			SceneBuySkillPageRes sceneBuySkillPageRes = new SceneBuySkillPageRes();
			sceneBuySkillPageRes.decode(obj.bytes);
			if (sceneBuySkillPageRes.result == 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BuySkillPage2Sucess, null, null, null, null);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("CnaNotBugSkillPage_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x040069AB RID: 27051
		private List<Skill> skillList = new List<Skill>();

		// Token: 0x040069AC RID: 27052
		private List<Skill> skillList2 = new List<Skill>();

		// Token: 0x040069AD RID: 27053
		private List<Skill> pvpSkillList = new List<Skill>();

		// Token: 0x040069AE RID: 27054
		private List<Skill> pvpSkillList2 = new List<Skill>();

		// Token: 0x040069AF RID: 27055
		public List<Skill> PassiveSkillList = new List<Skill>();

		// Token: 0x040069B0 RID: 27056
		public List<SkillBar> skillBarSolution = new List<SkillBar>();

		// Token: 0x040069B1 RID: 27057
		public List<SkillBar> skillBarSolution2 = new List<SkillBar>();

		// Token: 0x040069B2 RID: 27058
		public List<SkillBar> pvpSkillBarSolution = new List<SkillBar>();

		// Token: 0x040069B3 RID: 27059
		public List<SkillBar> pvpSkillBarSolution2 = new List<SkillBar>();

		// Token: 0x040069B4 RID: 27060
		private List<SkillBarGrid> skillBar = new List<SkillBarGrid>();

		// Token: 0x040069B5 RID: 27061
		private List<SkillBarGrid> skillBar2 = new List<SkillBarGrid>();

		// Token: 0x040069B6 RID: 27062
		private List<SkillBarGrid> pvpSkillBar = new List<SkillBarGrid>();

		// Token: 0x040069B7 RID: 27063
		private List<SkillBarGrid> pvpSkillBar2 = new List<SkillBarGrid>();

		// Token: 0x040069B8 RID: 27064
		public bool PVESkillPage2IsUnlock;

		// Token: 0x040069B9 RID: 27065
		public bool PVPSkillPage2IsUnlock;

		// Token: 0x040069BA RID: 27066
		public List<Skill> ChijiSkillList = new List<Skill>();

		// Token: 0x040069BB RID: 27067
		public List<SkillBarGrid> ChijiSkillBar = new List<SkillBarGrid>();

		// Token: 0x040069BC RID: 27068
		public List<Skill> FairDuelSkillList = new List<Skill>();

		// Token: 0x040069BD RID: 27069
		public List<SkillBarGrid> FairDuelSkillBar = new List<SkillBarGrid>();

		// Token: 0x040069BE RID: 27070
		public bool IsHaveSetFairDueSkillBar;

		// Token: 0x040069BF RID: 27071
		public Dictionary<int, int> UniqueButtonBindSkill = new Dictionary<int, int>();

		// Token: 0x040069C0 RID: 27072
		public Dictionary<int, int> CommonButtonBindSkill = new Dictionary<int, int>();

		// Token: 0x040069C1 RID: 27073
		public List<PassiveSkillData> PassiveButtonBindSkill = new List<PassiveSkillData>();

		// Token: 0x040069C2 RID: 27074
		public List<int> InitSkills = new List<int>();

		// Token: 0x040069C3 RID: 27075
		public List<int> LockSkillList = new List<int>();

		// Token: 0x040069C4 RID: 27076
		public List<int> NewOpenUniSkillList = new List<int>();

		// Token: 0x040069C5 RID: 27077
		public List<int> NewOpenComSkillList = new List<int>();

		// Token: 0x040069C6 RID: 27078
		public List<int> NewOpenSkillAll = new List<int>();

		// Token: 0x040069C7 RID: 27079
		public int LastSeeSkillLv = 1;

		// Token: 0x040069C8 RID: 27080
		public bool bNoticeSkillLvUp = true;

		// Token: 0x040069C9 RID: 27081
		public bool IsNotShowSkillLevelUpTip;

		// Token: 0x040069CA RID: 27082
		public bool IsNotShowSkillConfigTip;

		// Token: 0x040069CB RID: 27083
		private const int ShowSkillButtonLevel = 15;

		// Token: 0x040069CC RID: 27084
		public bool IsFinishUnlockTask;

		// Token: 0x040069CD RID: 27085
		public int UnLockTaskLvl = 60;

		// Token: 0x040069CE RID: 27086
		public EPVESkillPage CurPVESKillPage;

		// Token: 0x040069CF RID: 27087
		public EPVPSkillPage CurPVPSKillPage;

		// Token: 0x040069D0 RID: 27088
		public bool ActiveAwakeSkillIsGray;

		// Token: 0x040069D1 RID: 27089
		public bool ActiveAwakeSkillIsGray2;

		// Token: 0x040069D2 RID: 27090
		public bool IsJumpPVESkillPageExchangeTip;

		// Token: 0x040069D3 RID: 27091
		public bool IsJumpPVPSkillPageExchangeTip;

		// Token: 0x040069D4 RID: 27092
		private SkillConfigType curSkillConfigType;
	}
}
