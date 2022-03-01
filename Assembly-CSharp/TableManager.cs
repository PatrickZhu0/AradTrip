using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FlatBuffers;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020001EF RID: 495
public class TableManager : Singleton<TableManager>
{
	// Token: 0x06000F98 RID: 3992 RVA: 0x00050B98 File Offset: 0x0004EF98
	public IEnumerator _InitCoroutine(UnityAction<int, string> progress)
	{
		if (this.bInit)
		{
			Logger.LogErrorFormat("[INIT PROCESS]table _InitCoroutine binited!!!!!", new object[0]);
			yield break;
		}
		this.bInit = true;
		TableManager.bNeedUninit = true;
		for (int i = 0; i < this.mTypeList.Length; i++)
		{
			Type type = this.mTypeList[i];
			Dictionary<int, object> dictionary = this._loadTable(type);
			if (typeof(ItemTable) == type)
			{
				this._loadTable(type, typeof(ChijiItemTable), dictionary);
			}
			this.mTypeTableDict.Add(this.mTypeList[i], dictionary);
		}
		if (progress != null)
		{
			progress.Invoke(30, null);
		}
		yield return new WaitForEndOfFrame();
		this._loadSkillInfo();
		this._loadExpInfo();
		this._LoadCommonSkillInfo();
		this._loadComboScore();
		this._LoadJobInstituteInfo();
		this._LoadBornSkillInfo();
		if (progress != null)
		{
			progress.Invoke(40, null);
		}
		yield return new WaitForEndOfFrame();
		this._LoadJobChangeMap();
		this._LoadOpenSkillBarLevelInfo();
		this._loadMonsterAttributeInfo();
		this._loadAuctionClassifyInfo();
		this._loadTreasureDungeonInfo();
		if (progress != null)
		{
			progress.Invoke(50, null);
		}
		yield return new WaitForEndOfFrame();
		Singleton<ItemSearchEngine>.CreateInstance(true);
		this._loadPKHPAdjustInfo();
		this._loadDungeonDifficultyAdjustInfo();
		this._LoadTeamDungeonInfo();
		this._LoadNewbieGuideOrderInfo();
		if (progress != null)
		{
			progress.Invoke(60, null);
		}
		yield return new WaitForEndOfFrame();
		yield break;
	}

	// Token: 0x06000F99 RID: 3993 RVA: 0x00050BBC File Offset: 0x0004EFBC
	private void _loadTable(Type originalType, Type realType, Dictionary<int, object> table)
	{
		string text = this._getTablePath(realType);
		TextAsset textAsset = Singleton<AssetLoader>.instance.LoadRes(text, typeof(TextAsset), true, 0U).obj as TextAsset;
		if (null == textAsset)
		{
			Logger.LogError("Load table has failed, table resource:" + text);
			return;
		}
		byte[] bytes = textAsset.bytes;
		Table table2 = new Table();
		ByteBuffer bb = new ByteBuffer(bytes);
		table2.bb_pos = 0;
		table2.bb = bb;
		int num = table2.__vector_len(0);
		for (int i = 0; i < num; i++)
		{
			int num2 = table2.__vector(i);
			object obj = Activator.CreateInstance(originalType);
			MethodInfo method = originalType.GetMethod("__assign");
			MethodInfo getMethod = originalType.GetProperty("ID").GetGetMethod();
			BindingFlags invokeAttr = BindingFlags.Instance | BindingFlags.Public;
			object[] parameters = new object[]
			{
				table2.__indirect(table2.__vector(0) + i * 4),
				table2.bb
			};
			method.Invoke(obj, invokeAttr, Type.DefaultBinder, parameters, null);
			int num3 = (int)getMethod.Invoke(obj, null);
			if (!table.ContainsKey(num3))
			{
				table.Add(num3, obj);
				if (originalType == typeof(GlobalSettingTable))
				{
					this.gst = (obj as GlobalSettingTable);
				}
			}
			else
			{
				Logger.LogErrorFormat("type:{0},拥有相同ID：{1},请及时修正", new object[]
				{
					realType.Name,
					num3
				});
			}
		}
	}

	// Token: 0x06000F9A RID: 3994 RVA: 0x00050D37 File Offset: 0x0004F137
	public override void Init()
	{
		if (this.bInit)
		{
			return;
		}
	}

	// Token: 0x06000F9B RID: 3995 RVA: 0x00050D45 File Offset: 0x0004F145
	public void LogicServerInit()
	{
		if (this.bInit)
		{
			return;
		}
		Utility.IterCoroutineImm(this._InitCoroutine(null));
	}

	// Token: 0x06000F9C RID: 3996 RVA: 0x00050D60 File Offset: 0x0004F160
	public override void UnInit()
	{
		this.mTypeTableDict.Clear();
		this.mSkillInfoDict.Clear();
		this.jobInstituteDic.Clear();
		this.mPerLevelNeedExp.Clear();
		this.mToLevelNeedExp.Clear();
		this.CommonSkillList.Clear();
		this.mBornInfoDict.Clear();
		this.mPassiveSkillInfoDict.Clear();
		this.JobChangeMap.Clear();
		this.OpenSkillBarLevelMap.Clear();
		this.comboScoreDic.Clear();
		this.monsterAttributeMap.Clear();
		this.comboDataList.Clear();
		this.AuctionGuiJianShiWeaponType.Clear();
		this.AuctionShenQiangShouWeaponType.Clear();
		this.AuctionMoFaShiWeaponType.Clear();
		this.AuctionGeDouJiaWeaponType.Clear();
		this.AuctionDefenceType.Clear();
		this.AuctionJewelryType.Clear();
		this.AuctionArmorType.Clear();
		this.AuctionQualityType.Clear();
		this.AuctionConsumablesType.Clear();
		this.AuctionMaterialsType.Clear();
		this.pkHPProfessionAdjustInfo = null;
		this.dungeonDifficultyAdjustInfo.Clear();
		this.dungeonDifficultyAdjustInfo.Clear();
		this.TeamDungeonFirstMenuList.Clear();
		this.TeamDungeonSecondMenuDict.Clear();
		this.treasureRoomRandomLibrary.Clear();
		this.NewbieGuideOrderList.Clear();
		TableManager.bNeedUninit = false;
		this.bInit = false;
		base.UnInit();
	}

	// Token: 0x06000F9D RID: 3997 RVA: 0x00050EC8 File Offset: 0x0004F2C8
	public object GetTableItemForLua(Type curType, int id)
	{
		if (!this.mTypeTableDict.ContainsKey(curType))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				curType.Name
			});
			return null;
		}
		Dictionary<int, object> dictionary = this.mTypeTableDict[curType];
		if (dictionary == null)
		{
			return null;
		}
		if (!dictionary.ContainsKey(id))
		{
			return null;
		}
		return dictionary[id];
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x00050F2C File Offset: 0x0004F32C
	public Dictionary<int, object> GetTableForLua(Type curType)
	{
		Dictionary<int, object> dictionary = new Dictionary<int, object>();
		if (!this.mTypeTableDict.ContainsKey(curType))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				curType.Name
			});
			return null;
		}
		Dictionary<int, object> dictionary2 = this.mTypeTableDict[curType];
		if (dictionary2 == null)
		{
			return null;
		}
		return dictionary2;
	}

	// Token: 0x06000F9F RID: 3999 RVA: 0x00050F81 File Offset: 0x0004F381
	public Dictionary<int, object> GetTable<T>()
	{
		return this.GetTable(typeof(T));
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x00050F94 File Offset: 0x0004F394
	public Dictionary<int, object> GetTable(Type curType)
	{
		Dictionary<int, object> result = new Dictionary<int, object>();
		if (!this.mTypeTableDict.ContainsKey(curType))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				curType.Name
			});
			return result;
		}
		Dictionary<int, object> dictionary = this.mTypeTableDict[curType];
		if (dictionary == null)
		{
			return result;
		}
		return dictionary;
	}

	// Token: 0x06000FA1 RID: 4001 RVA: 0x00050FEC File Offset: 0x0004F3EC
	public UltimateChallengeDungeonTable GetFinalTestTime(int dungeonID)
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(UltimateChallengeDungeonTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			UltimateChallengeDungeonTable ultimateChallengeDungeonTable = keyValuePair.Value as UltimateChallengeDungeonTable;
			if (ultimateChallengeDungeonTable.dungeonID == dungeonID)
			{
				return ultimateChallengeDungeonTable;
			}
		}
		return null;
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x00051078 File Offset: 0x0004F478
	public bool IsLastFloor(int _id)
	{
		int num = 0;
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(UltimateChallengeDungeonTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			UltimateChallengeDungeonTable ultimateChallengeDungeonTable = keyValuePair.Value as UltimateChallengeDungeonTable;
			if (ultimateChallengeDungeonTable.ID > num)
			{
				num = ultimateChallengeDungeonTable.ID;
			}
		}
		return num == _id;
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x00051108 File Offset: 0x0004F508
	public T GetTableItem<T>(int id, string who = "", string dowhat = "")
	{
		Type typeFromHandle = typeof(T);
		Dictionary<int, object> dictionary = null;
		if (!this.mTypeTableDict.TryGetValue(typeFromHandle, out dictionary))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				typeFromHandle.Name
			});
			return default(T);
		}
		object obj = null;
		if (dictionary.TryGetValue(id, out obj))
		{
			return (T)((object)obj);
		}
		return default(T);
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x00051178 File Offset: 0x0004F578
	public object GetTableItem(Type curType, int id, string who = "", string dowhat = "")
	{
		Dictionary<int, object> dictionary = null;
		if (!this.mTypeTableDict.TryGetValue(curType, out dictionary))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				curType.Name
			});
			return null;
		}
		object result = null;
		if (dictionary.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x000511C8 File Offset: 0x0004F5C8
	public T GetTableItemByIndex<T>(int iIndex)
	{
		Type typeFromHandle = typeof(T);
		if (!this.mTypeTableDict.ContainsKey(typeFromHandle))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				typeFromHandle.Name
			});
			return default(T);
		}
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeFromHandle];
		if (dictionary == null)
		{
			return default(T);
		}
		int num = 0;
		foreach (int key in dictionary.Keys)
		{
			if (num == iIndex)
			{
				return (T)((object)dictionary[key]);
			}
			num++;
		}
		return default(T);
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x000512A8 File Offset: 0x0004F6A8
	public int GetTableItemCount<T>()
	{
		Type typeFromHandle = typeof(T);
		if (!this.mTypeTableDict.ContainsKey(typeFromHandle))
		{
			Logger.LogErrorFormat("没有加载 {0}", new object[]
			{
				typeFromHandle.Name
			});
			return -1;
		}
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeFromHandle];
		if (dictionary == null)
		{
			return -1;
		}
		return dictionary.Count;
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x00051308 File Offset: 0x0004F708
	public T GetTableItem<T>(string key)
	{
		T tableItem = this.GetTableItem<T>(key.GetHashCode(), string.Empty, string.Empty);
		if (tableItem == null)
		{
		}
		return tableItem;
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x00051338 File Offset: 0x0004F738
	public NpcTable GetNpcItemByUnitTable(UnitTable unitItem)
	{
		Dictionary<int, object> dictionary;
		if (unitItem != null && this.mTypeTableDict.TryGetValue(typeof(NpcTable), out dictionary) && dictionary != null)
		{
			foreach (KeyValuePair<int, object> keyValuePair in dictionary)
			{
				NpcTable npcTable = keyValuePair.Value as NpcTable;
				if (npcTable.UnitTableID == unitItem.ID)
				{
					return npcTable;
				}
			}
		}
		return null;
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x000513DC File Offset: 0x0004F7DC
	private string _getTablePath(Type type)
	{
		return "Data/table_fb/" + type.Name;
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x000513EE File Offset: 0x0004F7EE
	public static string _getTablePathNew(Type type)
	{
		return string.Format("{0}.bytes", Utility.Combine("Data/table_fb/", type.Name));
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x0005140C File Offset: 0x0004F80C
	private Dictionary<int, object> _loadTable(Type type)
	{
		Dictionary<int, object> dictionary = new Dictionary<int, object>();
		string text = this._getTablePath(type);
		TextAsset textAsset = Singleton<AssetLoader>.instance.LoadRes(text, typeof(TextAsset), true, 0U).obj as TextAsset;
		if (null == textAsset)
		{
			Logger.LogError("Load table has failed, table resource:" + text);
			return dictionary;
		}
		byte[] bytes = textAsset.bytes;
		Table table = new Table();
		ByteBuffer bb = new ByteBuffer(bytes);
		table.bb_pos = 0;
		table.bb = bb;
		int num = table.__vector_len(0);
		for (int i = 0; i < num; i++)
		{
			int num2 = table.__vector(i);
			object obj = Activator.CreateInstance(type);
			MethodInfo method = type.GetMethod("__assign");
			MethodInfo getMethod = type.GetProperty("ID").GetGetMethod();
			BindingFlags invokeAttr = BindingFlags.Instance | BindingFlags.Public;
			object[] parameters = new object[]
			{
				table.__indirect(table.__vector(0) + i * 4),
				table.bb
			};
			method.Invoke(obj, invokeAttr, Type.DefaultBinder, parameters, null);
			int num3 = (int)getMethod.Invoke(obj, null);
			if (!dictionary.ContainsKey(num3))
			{
				dictionary.Add(num3, obj);
				if (type == typeof(GlobalSettingTable))
				{
					this.gst = (obj as GlobalSettingTable);
				}
			}
			else
			{
				Logger.LogErrorFormat("id {0} 相同,严重错误 {1}", new object[]
				{
					num3,
					type.ToString()
				});
			}
		}
		return dictionary;
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x00051597 File Offset: 0x0004F997
	public void Reinit()
	{
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x0005159C File Offset: 0x0004F99C
	public ComboTeachData GetComboData(int dungeonID)
	{
		for (int i = 0; i < this.comboDataList.Count; i++)
		{
			if (!(this.comboDataList[i] == null))
			{
				if (this.comboDataList[i].roomID == dungeonID)
				{
					return this.comboDataList[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x00051608 File Offset: 0x0004FA08
	public void LoadData()
	{
		this.comboDataList.Clear();
		List<InstituteTable> jobInstituteData = Singleton<TableManager>.instance.GetJobInstituteData(DataManager<PlayerBaseData>.GetInstance().JobTableID);
		for (int i = 0; i < jobInstituteData.Count; i++)
		{
			this.comboDataList.Add(this.LoadComboData(jobInstituteData[i]));
		}
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x00051664 File Offset: 0x0004FA64
	private ComboTeachData LoadComboData(InstituteTable table)
	{
		string text = (table.DifficultyType != 1) ? "Advance" : "Easy";
		string text2 = string.Concat(new object[]
		{
			table.Resource,
			"/",
			text,
			"/",
			table.DungeonID
		});
		Object obj = Singleton<AssetLoader>.instance.LoadRes(text2, typeof(ComboTeachData), true, 0U).obj;
		if (obj == null)
		{
			Logger.LogErrorFormat("combodata is null+ key{0}", new object[]
			{
				text2
			});
		}
		return obj as ComboTeachData;
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x00051708 File Offset: 0x0004FB08
	private void _loadExpInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(ExpTable)];
		int count = dictionary.Count;
		this.mPerLevelNeedExp.Clear();
		this.mToLevelNeedExp.Clear();
		this.mPerLevelNeedExp.Add(0UL);
		this.mToLevelNeedExp.Add(0UL);
		for (int i = 1; i <= count; i++)
		{
			ExpTable expTable = dictionary[i] as ExpTable;
			if (expTable.TotalExp < 0)
			{
				this.mPerLevelNeedExp.Add(0UL);
				Logger.LogErrorFormat("expItem with negative value index : {0}", new object[]
				{
					i
				});
			}
			else
			{
				this.mPerLevelNeedExp.Add((ulong)((long)expTable.TotalExp));
			}
			if (expTable.TotalExp <= 0)
			{
				this.mToLevelNeedExp.Add(0UL);
			}
			else
			{
				this.mToLevelNeedExp.Add((ulong)((long)expTable.TotalExp + (long)this.mToLevelNeedExp[i - 1]));
			}
		}
		this.mPerLevelNeedExp[0] = 0UL;
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x00051818 File Offset: 0x0004FC18
	private void _loadSkillInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(SkillTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			SkillTable skillTable = keyValuePair.Value as SkillTable;
			if (skillTable.SkillCategory < 5)
			{
				for (int i = 0; i < skillTable.JobID.Count; i++)
				{
					int key = skillTable.JobID[i];
					if (!this.mSkillInfoDict.ContainsKey(key))
					{
						this.mSkillInfoDict.Add(key, new Dictionary<int, int>());
					}
					if (!this.mSkillInfoDict[key].ContainsKey(skillTable.ID))
					{
						this.mSkillInfoDict[key].Add(skillTable.ID, 1);
					}
				}
			}
		}
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x00051904 File Offset: 0x0004FD04
	private void _loadComboScore()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(ComboScoreTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			ComboScoreTable comboScoreTable = keyValuePair.Value as ComboScoreTable;
			if (!this.comboScoreDic.ContainsKey(comboScoreTable.JobID))
			{
				List<ComboScoreTable> list = new List<ComboScoreTable>();
				list.Add(comboScoreTable);
				this.comboScoreDic[comboScoreTable.JobID] = list;
			}
			else
			{
				this.comboScoreDic[comboScoreTable.JobID].Add(comboScoreTable);
			}
		}
		foreach (KeyValuePair<int, List<ComboScoreTable>> keyValuePair2 in this.comboScoreDic)
		{
			keyValuePair2.Value.Sort(delegate(ComboScoreTable x, ComboScoreTable y)
			{
				if (x.Percent >= y.Percent)
				{
					return -1;
				}
				if (x.Percent < y.Percent)
				{
					return 1;
				}
				return 0;
			});
		}
	}

	// Token: 0x06000FB3 RID: 4019 RVA: 0x00051A1C File Offset: 0x0004FE1C
	public uint GetComboScore(int jobID, int percent, int minCombo)
	{
		List<ComboScoreTable> list;
		if (this.comboScoreDic.TryGetValue(jobID, out list))
		{
			percent = Mathf.Min(percent, list[0].Percent);
			ComboScoreTable comboScoreTable = this.FindItemByPercent(list, percent);
			if (comboScoreTable != null)
			{
				if (comboScoreTable.MinCombo <= minCombo)
				{
					return (uint)comboScoreTable.BaseScore;
				}
				if (comboScoreTable.MinCombo > minCombo)
				{
					ComboScoreTable comboScoreTable2 = this.FindItemByCombo(list, minCombo);
					if (comboScoreTable2 != null)
					{
						return (uint)comboScoreTable2.BaseScore;
					}
				}
			}
		}
		return 0U;
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x00051A98 File Offset: 0x0004FE98
	private ComboScoreTable FindItemByCombo(List<ComboScoreTable> list, int combo)
	{
		if (combo <= 0)
		{
			return null;
		}
		ComboScoreTable comboScoreTable = list.Find((ComboScoreTable x) => x.MinCombo == combo);
		if (comboScoreTable == null)
		{
			combo--;
			return this.FindItemByCombo(list, combo);
		}
		return comboScoreTable;
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x00051AF8 File Offset: 0x0004FEF8
	private ComboScoreTable FindItemByPercent(List<ComboScoreTable> list, int percent)
	{
		if (percent <= 0)
		{
			return null;
		}
		ComboScoreTable comboScoreTable = list.Find((ComboScoreTable x) => x.Percent == percent);
		if (comboScoreTable == null)
		{
			percent--;
			return this.FindItemByPercent(list, percent);
		}
		return comboScoreTable;
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x00051B56 File Offset: 0x0004FF56
	public Dictionary<int, int> GetSkillInfoByPid(int pid)
	{
		if (this.mSkillInfoDict.ContainsKey(pid))
		{
			return this.mSkillInfoDict[pid];
		}
		return new Dictionary<int, int>();
	}

	// Token: 0x06000FB7 RID: 4023 RVA: 0x00051B7C File Offset: 0x0004FF7C
	public ulong GetExpByLevel(int level)
	{
		if (level >= this.mPerLevelNeedExp.Count || level <= 0)
		{
			Logger.LogErrorFormat("level out of range with level : {0}", new object[]
			{
				level
			});
			return ulong.MaxValue;
		}
		return this.mPerLevelNeedExp[level];
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x00051BCC File Offset: 0x0004FFCC
	public int GetLevelByExp(ulong totalExp)
	{
		int i = 1;
		int num = this.mToLevelNeedExp.Count - 1;
		while (i < num)
		{
			int num2 = (i + num) / 2;
			if (this.mToLevelNeedExp[num2] <= totalExp)
			{
				i = num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return i;
	}

	// Token: 0x06000FB9 RID: 4025 RVA: 0x00051C1C File Offset: 0x0005001C
	public KeyValuePair<ulong, ulong> GetCurRoleExp(ulong totalExp)
	{
		int levelByExp = this.GetLevelByExp(totalExp);
		ulong expByLevel = this.GetExpByLevel(levelByExp);
		if (levelByExp == this.mToLevelNeedExp.Count - 1)
		{
			return new KeyValuePair<ulong, ulong>(expByLevel, expByLevel);
		}
		return new KeyValuePair<ulong, ulong>(expByLevel - (this.mToLevelNeedExp[levelByExp] - totalExp), expByLevel);
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x00051C6C File Offset: 0x0005006C
	public KeyValuePair<ulong, ulong> GetCurVipLevelExp(int VipLevel, ulong CurVipLvRmb)
	{
		ulong num = 0UL;
		Dictionary<int, object> table = this.GetTable<VipTable>();
		if (table != null)
		{
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				VipTable vipTable = keyValuePair.Value as VipTable;
				if (vipTable.ID < VipLevel)
				{
					num += (ulong)((long)vipTable.TotalRmb);
				}
			}
		}
		SystemValueTable tableItem = this.GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
		if (tableItem != null && VipLevel >= tableItem.Value)
		{
			return new KeyValuePair<ulong, ulong>(CurVipLvRmb + num, num);
		}
		ulong num2 = 0UL;
		VipTable tableItem2 = this.GetTableItem<VipTable>(VipLevel, string.Empty, string.Empty);
		if (tableItem2 != null)
		{
			num2 = (ulong)((long)tableItem2.TotalRmb);
		}
		if (num2 == 0UL)
		{
			return new KeyValuePair<ulong, ulong>(CurVipLvRmb + num, num);
		}
		if (CurVipLvRmb >= num2)
		{
			CurVipLvRmb -= 1UL;
		}
		return new KeyValuePair<ulong, ulong>(CurVipLvRmb + num, num2 + num);
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x00051D54 File Offset: 0x00050154
	public KeyValuePair<ulong, ulong> GetCurPetExpBar(int Level, ulong CurExp, PetTable.eQuality ePetQuality)
	{
		Dictionary<int, object> table = this.GetTable<PetLevelTable>();
		Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
		ulong num = 0UL;
		while (enumerator.MoveNext())
		{
			KeyValuePair<int, object> keyValuePair = enumerator.Current;
			PetLevelTable petLevelTable = keyValuePair.Value as PetLevelTable;
			if (petLevelTable != null)
			{
				if (petLevelTable.Level == Level && petLevelTable.Quality == (int)ePetQuality)
				{
					num = (ulong)((long)petLevelTable.UplevelExp);
					break;
				}
			}
		}
		if (num == 0UL)
		{
			return new KeyValuePair<ulong, ulong>(0UL, 0UL);
		}
		return new KeyValuePair<ulong, ulong>(CurExp, num);
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x00051DE8 File Offset: 0x000501E8
	private void _LoadCommonSkillInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(SkillTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			SkillTable skillTable = keyValuePair.Value as SkillTable;
			if (skillTable.SkillCategory == 2 && skillTable.BindButtonIndex > 0)
			{
				if (!this.CommonSkillList.ContainsKey(skillTable.BindButtonIndex))
				{
					this.CommonSkillList.Add(skillTable.BindButtonIndex, skillTable.ID);
				}
				else
				{
					Logger.LogErrorFormat("[加载CommonSkillList] 已有{0}索引, 技能ID {1}", new object[]
					{
						skillTable.BindButtonIndex,
						skillTable.ID
					});
				}
			}
		}
	}

	// Token: 0x06000FBD RID: 4029 RVA: 0x00051ED4 File Offset: 0x000502D4
	public InstituteTable GetDataByDungeonID(int jobID, int id)
	{
		List<InstituteTable> jobInstituteData = this.GetJobInstituteData(jobID);
		if (jobInstituteData != null)
		{
			for (int i = 0; i < jobInstituteData.Count; i++)
			{
				if (jobInstituteData[i].DungeonID == id)
				{
					return jobInstituteData[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x00051F24 File Offset: 0x00050324
	public List<InstituteTable> GetJobInstituteData(int jobID)
	{
		List<InstituteTable> result;
		if (this.jobInstituteDic.TryGetValue(jobID, out result))
		{
			return result;
		}
		return new List<InstituteTable>();
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x00051F4C File Offset: 0x0005034C
	public List<InstituteTable> GetJobAndTypeInstitue(int jobID, int type)
	{
		List<InstituteTable> jobInstituteData = this.GetJobInstituteData(jobID);
		List<InstituteTable> list = new List<InstituteTable>();
		for (int i = 0; i < jobInstituteData.Count; i++)
		{
			if (jobInstituteData[i].DifficultyType == type)
			{
				list.Add(jobInstituteData[i]);
			}
		}
		return list;
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x00051FA0 File Offset: 0x000503A0
	private void _LoadJobInstituteInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(InstituteTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			InstituteTable instituteTable = keyValuePair.Value as InstituteTable;
			if (this.jobInstituteDic.ContainsKey(instituteTable.JobID))
			{
				this.jobInstituteDic[instituteTable.JobID].Add(instituteTable);
			}
			else
			{
				this.jobInstituteDic[instituteTable.JobID] = new List<InstituteTable>();
				this.jobInstituteDic[instituteTable.JobID].Add(instituteTable);
			}
		}
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x00052074 File Offset: 0x00050474
	private void _LoadBornSkillInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(SkillTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			SkillTable skillTable = keyValuePair.Value as SkillTable;
			if (skillTable.SkillCategory == 1 && skillTable.JobID[0] > 0)
			{
				foreach (int key in ((IEnumerable<int>)skillTable.JobID))
				{
					if (!this.mBornInfoDict.ContainsKey(key))
					{
						this.mBornInfoDict.Add(key, new List<int>());
					}
					this.mBornInfoDict[key].Add(skillTable.ID);
				}
			}
			if (skillTable.SkillCategory == 3 && skillTable.JobID[0] > 0 && skillTable.PassiveSkillBtnIndex > 0)
			{
				for (int i = 0; i < skillTable.JobID.Count; i++)
				{
					int key2 = skillTable.JobID[i];
					if (!this.mPassiveSkillInfoDict.ContainsKey(key2))
					{
						this.mPassiveSkillInfoDict.Add(key2, new List<int>());
					}
					this.mPassiveSkillInfoDict[key2].Add(skillTable.ID);
				}
			}
		}
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x00052238 File Offset: 0x00050638
	public List<int> GetBornSkills(int jobId)
	{
		if (!this.mBornInfoDict.ContainsKey(jobId))
		{
			return new List<int>();
		}
		return this.mBornInfoDict[jobId];
	}

	// Token: 0x06000FC3 RID: 4035 RVA: 0x0005225D File Offset: 0x0005065D
	public List<int> GetPassiveSkills(int jobId)
	{
		if (!this.mPassiveSkillInfoDict.ContainsKey(jobId))
		{
			return new List<int>();
		}
		return this.mPassiveSkillInfoDict[jobId];
	}

	// Token: 0x06000FC4 RID: 4036 RVA: 0x00052282 File Offset: 0x00050682
	public Dictionary<int, int> GetCommonSkillList()
	{
		return this.CommonSkillList;
	}

	// Token: 0x06000FC5 RID: 4037 RVA: 0x0005228C File Offset: 0x0005068C
	public int GetItemConfigID(int itemid)
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(ItemConfigTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			ItemConfigTable itemConfigTable = keyValuePair.Value as ItemConfigTable;
			if (itemConfigTable != null && itemConfigTable.ItemID == itemid)
			{
				return itemConfigTable.ID;
			}
		}
		return -1;
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x000522F8 File Offset: 0x000506F8
	private void _LoadJobChangeMap()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(JobTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			JobTable jobTable = keyValuePair.Value as JobTable;
			if (jobTable.ID != 0)
			{
				if (jobTable.ToJob != null && jobTable.ToJob.Count > 0 && (jobTable.ToJob.Count != 1 || jobTable.ToJob[0] != 0))
				{
					if (!this.JobChangeMap.ContainsKey(jobTable.ID))
					{
						this.JobChangeMap.Add(jobTable.ID, jobTable.ToJob);
					}
				}
			}
		}
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x000523F0 File Offset: 0x000507F0
	public IList<int> GetNextJobsIDByCurJobID(int CurJobID)
	{
		IList<int> result = null;
		if (!this.JobChangeMap.TryGetValue(CurJobID, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x00052418 File Offset: 0x00050818
	private void _LoadOpenSkillBarLevelInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(ExpTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			ExpTable expTable = keyValuePair.Value as ExpTable;
			if (!this.OpenSkillBarLevelMap.ContainsKey(expTable.SkillNum))
			{
				this.OpenSkillBarLevelMap.Add(expTable.SkillNum, expTable.ID);
			}
		}
	}

	// Token: 0x06000FC9 RID: 4041 RVA: 0x000524C0 File Offset: 0x000508C0
	public int GetLevelBySkillBarIndex(int skillbarIndex)
	{
		foreach (int num in this.OpenSkillBarLevelMap.Keys)
		{
			if (skillbarIndex <= num)
			{
				return this.OpenSkillBarLevelMap[num];
			}
		}
		return -1;
	}

	// Token: 0x06000FCA RID: 4042 RVA: 0x00052538 File Offset: 0x00050938
	public static int GetValueFromUnionCell(UnionCell ucell, int level, bool bNeedBaseLevel = true)
	{
		if (bNeedBaseLevel && level <= 0)
		{
			level = 1;
		}
		if (level <= 0)
		{
			return 0;
		}
		UnionCellType valueType = ucell.valueType;
		if (valueType == UnionCellType.union_fix)
		{
			return ucell.fixValue;
		}
		if (valueType == UnionCellType.union_fixGrow)
		{
			return ucell.fixInitValue + (level - 1) * ucell.fixLevelGrow;
		}
		if (valueType != UnionCellType.union_everyvalue)
		{
			return 0;
		}
		if (level - 1 < ucell.eValues.everyValues.Count)
		{
			return ucell.eValues.everyValues[level - 1];
		}
		return ucell.eValues.everyValues[ucell.eValues.everyValues.Count - 1];
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x000525E4 File Offset: 0x000509E4
	private void MergeTable(Dictionary<int, object> t1, Dictionary<int, object> t2)
	{
		foreach (KeyValuePair<int, object> keyValuePair in t1)
		{
			if (!t2.ContainsKey(keyValuePair.Key))
			{
				Dictionary<int, object>.Enumerator enumerator;
				KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
				int key = keyValuePair2.Key;
				KeyValuePair<int, object> keyValuePair3 = enumerator.Current;
				t2.Add(key, keyValuePair3.Value);
			}
		}
	}

	// Token: 0x06000FCC RID: 4044 RVA: 0x0005264C File Offset: 0x00050A4C
	private void _loadMonsterAttributeInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(MonsterAttributeTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			MonsterAttributeTable monsterAttributeTable = (MonsterAttributeTable)keyValuePair.Value;
			int monsterMode = monsterAttributeTable.MonsterMode;
			int difficulty = monsterAttributeTable.Difficulty;
			int monsterType = monsterAttributeTable.MonsterType;
			int level = monsterAttributeTable.level;
			int num = difficulty * GlobalLogic.VALUE_100000 + monsterType * GlobalLogic.VALUE_10000 + monsterMode * GlobalLogic.VALUE_1000 + level;
			if (!this.monsterAttributeMap.ContainsKey(num))
			{
				Dictionary<int, object> dictionary2 = this.monsterAttributeMap;
				int key = num;
				Dictionary<int, object>.Enumerator enumerator;
				KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
				dictionary2.Add(key, keyValuePair2.Value);
			}
		}
	}

	// Token: 0x06000FCD RID: 4045 RVA: 0x0005270C File Offset: 0x00050B0C
	public object GetMonsterAttribute(int mode, int difficulty, int type, int level)
	{
		object result = null;
		try
		{
			int key = difficulty * GlobalLogic.VALUE_100000 + type * GlobalLogic.VALUE_10000 + mode * GlobalLogic.VALUE_1000 + level;
			result = this.monsterAttributeMap[key];
		}
		catch
		{
			Logger.LogErrorFormat("[获取怪物属] 出错 mode : {0}, diff {1}, type {2}, level {3}", new object[]
			{
				mode,
				difficulty,
				type,
				level
			});
		}
		return result;
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x00052794 File Offset: 0x00050B94
	private bool _isProfessionValid(int pro)
	{
		return pro > 0 && pro <= 100;
	}

	// Token: 0x06000FCF RID: 4047 RVA: 0x000527A8 File Offset: 0x00050BA8
	private void _loadPKHPAdjustInfo()
	{
	}

	// Token: 0x06000FD0 RID: 4048 RVA: 0x000527AA File Offset: 0x00050BAA
	public object GetDungeonDifficultyAdjustInfo(int dungeonID, int playerNum)
	{
		if (this.dungeonDifficultyAdjustInfo.ContainsKey(dungeonID) && playerNum > 0 && playerNum <= 4)
		{
			return this.dungeonDifficultyAdjustInfo[dungeonID][playerNum];
		}
		return null;
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x000527DC File Offset: 0x00050BDC
	private void _loadDungeonDifficultyAdjustInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(DungeonDifficultyAdjustTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			DungeonDifficultyAdjustTable dungeonDifficultyAdjustTable = (DungeonDifficultyAdjustTable)keyValuePair.Value;
			int dungeonID = dungeonDifficultyAdjustTable.DungeonID;
			if (!this.dungeonDifficultyAdjustInfo.ContainsKey(dungeonID))
			{
				this.dungeonDifficultyAdjustInfo.Add(dungeonID, new object[5]);
			}
			if (dungeonDifficultyAdjustTable.PlayerNum > 0 && dungeonDifficultyAdjustTable.PlayerNum <= 4)
			{
				object[] array = this.dungeonDifficultyAdjustInfo[dungeonID];
				int playerNum = dungeonDifficultyAdjustTable.PlayerNum;
				Dictionary<int, object>.Enumerator enumerator;
				KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
				array[playerNum] = keyValuePair2.Value;
			}
		}
	}

	// Token: 0x06000FD2 RID: 4050 RVA: 0x00052898 File Offset: 0x00050C98
	private void _loadTreasureDungeonInfo()
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<RandomDungeonTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			RandomDungeonTable randomDungeonTable = keyValuePair.Value as RandomDungeonTable;
			if (randomDungeonTable != null)
			{
				if (!this.treasureRoomRandomLibrary.ContainsKey(randomDungeonTable.dungeonType))
				{
					this.treasureRoomRandomLibrary.Add(randomDungeonTable.dungeonType, new List<string>());
				}
				List<string> list = this.treasureRoomRandomLibrary[randomDungeonTable.dungeonType];
				if (!list.Contains(randomDungeonTable.DungeonRoom))
				{
					list.Add(randomDungeonTable.DungeonRoom);
				}
			}
		}
	}

	// Token: 0x06000FD3 RID: 4051 RVA: 0x00052946 File Offset: 0x00050D46
	public List<string> GetTreasureDungeonRandomLibrary(int roomType)
	{
		if (this.treasureRoomRandomLibrary.ContainsKey(roomType))
		{
			return this.treasureRoomRandomLibrary[roomType];
		}
		return null;
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x00052968 File Offset: 0x00050D68
	private void _LoadTeamDungeonInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(TeamDungeonTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
			if (teamDungeonTable.ShowIndependent == 1)
			{
				this.TeamDungeonFirstMenuList.Add(teamDungeonTable.ID);
			}
			else if (teamDungeonTable.Type == TeamDungeonTable.eType.MENU)
			{
				this.TeamDungeonFirstMenuList.Add(teamDungeonTable.ID);
				List<int> value = new List<int>();
				if (!this.TeamDungeonSecondMenuDict.TryGetValue(teamDungeonTable.ID, out value))
				{
					value = new List<int>();
					this.TeamDungeonSecondMenuDict.Add(teamDungeonTable.ID, value);
				}
			}
			else if (teamDungeonTable.Type == TeamDungeonTable.eType.DUNGEON || teamDungeonTable.Type == TeamDungeonTable.eType.CityMonster)
			{
				List<int> list = new List<int>();
				if (this.TeamDungeonSecondMenuDict.TryGetValue(teamDungeonTable.MenuID, out list))
				{
					list.Add(teamDungeonTable.ID);
				}
				else
				{
					list = new List<int>();
					list.Add(teamDungeonTable.ID);
					this.TeamDungeonSecondMenuDict.Add(teamDungeonTable.MenuID, list);
				}
			}
		}
	}

	// Token: 0x06000FD5 RID: 4053 RVA: 0x00052AD4 File Offset: 0x00050ED4
	private void _LoadNewbieGuideOrderInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(NewbieGuideTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			NewbieGuideTable newbieGuideTable = keyValuePair.Value as NewbieGuideTable;
			if (newbieGuideTable.ID != 1 && newbieGuideTable.IsOpen != 0)
			{
				if (this.NewbieGuideOrderList.Count == 0)
				{
					this.NewbieGuideOrderList.Add(newbieGuideTable.ID);
				}
				else
				{
					for (int i = 0; i < this.NewbieGuideOrderList.Count; i++)
					{
						NewbieGuideTable tableItem = this.GetTableItem<NewbieGuideTable>(this.NewbieGuideOrderList[i], string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (tableItem.Order > newbieGuideTable.Order)
							{
								this.NewbieGuideOrderList.Insert(i, newbieGuideTable.ID);
								break;
							}
							if (i == this.NewbieGuideOrderList.Count - 1)
							{
								this.NewbieGuideOrderList.Add(newbieGuideTable.ID);
								break;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x00052C0C File Offset: 0x0005100C
	public float GetPKHPAdjustFactor(int ourPro, int raceType)
	{
		if (!this._isProfessionValid(ourPro))
		{
			Logger.LogErrorFormat("GetPKHPAdjustFactor error ourPro:{0}", new object[]
			{
				ourPro
			});
			return 1f;
		}
		PkHPProfessionAdjustTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkHPProfessionAdjustTable>(ourPro, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 1f;
		}
		if (raceType == 6)
		{
			return (float)tableItem.factor_3v3 / (float)GlobalLogic.VALUE_1000;
		}
		if (raceType == 8)
		{
			return (float)tableItem.factor_chiji / (float)GlobalLogic.VALUE_1000;
		}
		return (float)tableItem.factor / (float)GlobalLogic.VALUE_1000;
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x00052CA0 File Offset: 0x000510A0
	private void _loadAuctionClassifyInfo()
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(AuctionClassify)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			AuctionClassify auctionClassify = keyValuePair.Value as AuctionClassify;
			if (auctionClassify.IsFirstNode == 1)
			{
				if (auctionClassify.Type == AuctionClassify.eType.AT_EQUIP)
				{
					if (auctionClassify.Job == AuctionClassify.eJob.AC_JIANSHI)
					{
						this.AuctionGuiJianShiWeaponType.Add(auctionClassify.ID);
					}
					else if (auctionClassify.Job == AuctionClassify.eJob.AC_QIANGSHOU)
					{
						this.AuctionShenQiangShouWeaponType.Add(auctionClassify.ID);
					}
					else if (auctionClassify.Job == AuctionClassify.eJob.AC_FASHI)
					{
						this.AuctionMoFaShiWeaponType.Add(auctionClassify.ID);
					}
					else if (auctionClassify.Job == AuctionClassify.eJob.AC_GEDOU)
					{
						this.AuctionGeDouJiaWeaponType.Add(auctionClassify.ID);
					}
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_DEFENCE)
				{
					this.AuctionDefenceType.Add(auctionClassify.ID);
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_JEWELRY)
				{
					this.AuctionJewelryType.Add(auctionClassify.ID);
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_ARMOR)
				{
					this.AuctionArmorType.Add(auctionClassify.ID);
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_QUALITY)
				{
					this.AuctionQualityType.Add(auctionClassify.ID);
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_EXPENDABLE)
				{
					this.AuctionConsumablesType.Add(auctionClassify.ID);
				}
				else if (auctionClassify.Type == AuctionClassify.eType.AT_MATERIAL)
				{
					this.AuctionMaterialsType.Add(auctionClassify.ID);
				}
			}
		}
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x00052E8C File Offset: 0x0005128C
	public List<int> GetAuctionWeaponList(AuctionClassify.eJob eJobType)
	{
		if (eJobType == AuctionClassify.eJob.AC_JIANSHI)
		{
			return this.AuctionGuiJianShiWeaponType;
		}
		if (eJobType == AuctionClassify.eJob.AC_QIANGSHOU)
		{
			return this.AuctionShenQiangShouWeaponType;
		}
		if (eJobType == AuctionClassify.eJob.AC_FASHI)
		{
			return this.AuctionMoFaShiWeaponType;
		}
		if (eJobType == AuctionClassify.eJob.AC_GEDOU)
		{
			return this.AuctionGeDouJiaWeaponType;
		}
		return null;
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x00052EC6 File Offset: 0x000512C6
	public List<int> GetAuctionDefenceList()
	{
		return this.AuctionDefenceType;
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x00052ECE File Offset: 0x000512CE
	public List<int> GetAuctionJewelryList()
	{
		return this.AuctionJewelryType;
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x00052ED6 File Offset: 0x000512D6
	public List<int> GetAuctionArmorList()
	{
		return this.AuctionArmorType;
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x00052EDE File Offset: 0x000512DE
	public List<int> GetAuctionQualityList()
	{
		return this.AuctionQualityType;
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x00052EE6 File Offset: 0x000512E6
	public List<int> GetAuctionConsumablesList()
	{
		return this.AuctionConsumablesType;
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x00052EEE File Offset: 0x000512EE
	public List<int> GetAuctionMaterialsList()
	{
		return this.AuctionMaterialsType;
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x00052EF8 File Offset: 0x000512F8
	public bool IsAuctionJianshiWeaponSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionGuiJianShiWeaponType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionGuiJianShiWeaponType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x00052F54 File Offset: 0x00051354
	public bool IsAuctionQiangshouWeaponSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionShenQiangShouWeaponType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionShenQiangShouWeaponType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x00052FB0 File Offset: 0x000513B0
	public bool IsAuctionFashiWeaponSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionMoFaShiWeaponType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionMoFaShiWeaponType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x0005300C File Offset: 0x0005140C
	public bool IsAuctionGeDouJiaWeaponSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionGeDouJiaWeaponType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionGeDouJiaWeaponType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE3 RID: 4067 RVA: 0x00053068 File Offset: 0x00051468
	public bool IsAuctionDefenceSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionDefenceType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionDefenceType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x000530C4 File Offset: 0x000514C4
	public bool IsAuctionJewelrySum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionJewelryType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionJewelryType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE5 RID: 4069 RVA: 0x00053120 File Offset: 0x00051520
	public bool IsAuctionConsumablesSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionConsumablesType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionConsumablesType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x0005317C File Offset: 0x0005157C
	public bool IsAuctionMaterialsSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionMaterialsType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionMaterialsType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE7 RID: 4071 RVA: 0x000531D8 File Offset: 0x000515D8
	public bool IsAuctionArmorSum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionArmorType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionArmorType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x00053234 File Offset: 0x00051634
	public bool IsAuctionQualitySum(int iIndex)
	{
		if (iIndex < 0 || iIndex >= this.AuctionQualityType.Count)
		{
			return false;
		}
		AuctionClassify tableItem = this.GetTableItem<AuctionClassify>(this.AuctionQualityType[iIndex], string.Empty, string.Empty);
		return tableItem != null && tableItem.Sum == AuctionClassify.eSum.SUM_ALL;
	}

	// Token: 0x06000FE9 RID: 4073 RVA: 0x00053290 File Offset: 0x00051690
	public int GetJobIDByFightID(int fightID)
	{
		Dictionary<int, object> dictionary = this.mTypeTableDict[typeof(JobTable)];
		foreach (KeyValuePair<int, object> keyValuePair in dictionary)
		{
			JobTable jobTable = keyValuePair.Value as JobTable;
			if (jobTable != null && jobTable.FightID == fightID)
			{
				Dictionary<int, object>.Enumerator enumerator;
				KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
				return keyValuePair2.Key;
			}
		}
		return 0;
	}

	// Token: 0x06000FEA RID: 4074 RVA: 0x00053304 File Offset: 0x00051704
	public List<int> GetTeamDungeonFirstMenuList()
	{
		return this.TeamDungeonFirstMenuList;
	}

	// Token: 0x06000FEB RID: 4075 RVA: 0x0005330C File Offset: 0x0005170C
	public Dictionary<int, List<int>> GetTeamDungeonSecondMenuDict()
	{
		return this.TeamDungeonSecondMenuDict;
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x00053314 File Offset: 0x00051714
	public List<int> GetNewbieGuideOrderList()
	{
		return this.NewbieGuideOrderList;
	}

	// Token: 0x06000FED RID: 4077 RVA: 0x0005331C File Offset: 0x0005171C
	public int GetMonsterTableProperty(AttributeType attributeType, UnitTable data)
	{
		int result = 0;
		switch (attributeType)
		{
		case AttributeType.maxHp:
			result = data.maxHp;
			break;
		case AttributeType.maxMp:
			result = data.maxMp;
			break;
		case AttributeType.hpRecover:
			result = data.hpRecover;
			break;
		case AttributeType.mpRecover:
			result = data.mpRecover;
			break;
		case AttributeType.attack:
			result = data.attack;
			break;
		case AttributeType.magicAttack:
			result = data.magicAttack;
			break;
		case AttributeType.defence:
			result = data.defence;
			break;
		case AttributeType.magicDefence:
			result = data.magicDefence;
			break;
		case AttributeType.attackSpeed:
			result = data.attackSpeed;
			break;
		case AttributeType.spellSpeed:
			result = data.spellSpeed;
			break;
		case AttributeType.moveSpeed:
			result = data.moveSpeed;
			break;
		case AttributeType.ciriticalAttack:
			result = data.ciriticalAttack;
			break;
		case AttributeType.ciriticalMagicAttack:
			result = data.ciriticalMagicAttack;
			break;
		case AttributeType.dex:
			result = data.dex;
			break;
		case AttributeType.dodge:
			result = data.dodge;
			break;
		case AttributeType.frozen:
			result = data.frozen;
			break;
		case AttributeType.hard:
			result = data.hard;
			break;
		case AttributeType.cdReduceRate:
			result = data.cdReduceRate;
			break;
		case AttributeType.ignoreDefAttackAdd:
			result = data.ignoreDefAttackAdd;
			break;
		case AttributeType.ignoreDefMagicAttackAdd:
			result = data.ignoreDefMagicAttackAdd;
			break;
		case AttributeType.baseAtk:
			result = data.baseAtk;
			break;
		case AttributeType.baseInt:
			result = data.baseInt;
			break;
		case AttributeType.baseSta:
			result = data.sta;
			break;
		case AttributeType.baseSpr:
			result = data.spr;
			break;
		}
		return result;
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x000534F8 File Offset: 0x000518F8
	public int GetMonsterAttributeTableProperty(AttributeType attributeType, MonsterAttributeTable data)
	{
		int result = 0;
		switch (attributeType)
		{
		case AttributeType.maxHp:
			result = data.maxHp;
			break;
		case AttributeType.maxMp:
			result = data.maxMp;
			break;
		case AttributeType.hpRecover:
			result = data.hpRecover;
			break;
		case AttributeType.mpRecover:
			result = data.mpRecover;
			break;
		case AttributeType.attack:
			result = data.attack;
			break;
		case AttributeType.magicAttack:
			result = data.magicAttack;
			break;
		case AttributeType.defence:
			result = data.defence;
			break;
		case AttributeType.magicDefence:
			result = data.magicDefence;
			break;
		case AttributeType.attackSpeed:
			result = data.attackSpeed;
			break;
		case AttributeType.spellSpeed:
			result = data.spellSpeed;
			break;
		case AttributeType.moveSpeed:
			result = data.moveSpeed;
			break;
		case AttributeType.ciriticalAttack:
			result = data.ciriticalAttack;
			break;
		case AttributeType.ciriticalMagicAttack:
			result = data.ciriticalMagicAttack;
			break;
		case AttributeType.dex:
			result = data.dex;
			break;
		case AttributeType.dodge:
			result = data.dodge;
			break;
		case AttributeType.frozen:
			result = data.frozen;
			break;
		case AttributeType.hard:
			result = data.hard;
			break;
		case AttributeType.cdReduceRate:
			result = data.cdReduceRate;
			break;
		case AttributeType.ignoreDefAttackAdd:
			result = data.ignoreDefAttackAdd;
			break;
		case AttributeType.ignoreDefMagicAttackAdd:
			result = data.ignoreDefMagicAttackAdd;
			break;
		case AttributeType.baseAtk:
			result = data.baseAtk;
			break;
		case AttributeType.baseInt:
			result = data.baseInt;
			break;
		case AttributeType.baseSta:
			result = data.sta;
			break;
		case AttributeType.baseSpr:
			result = data.spr;
			break;
		}
		return result;
	}

	// Token: 0x06000FEF RID: 4079 RVA: 0x000536D4 File Offset: 0x00051AD4
	public UnionCell GetBuffTableProperty(AttributeType attributeType, BuffTable data)
	{
		UnionCell result = null;
		switch (attributeType)
		{
		case AttributeType.maxHp:
			result = data.maxHp;
			break;
		case AttributeType.maxMp:
			result = data.maxMp;
			break;
		case AttributeType.hpRecover:
			result = data.hpRecover;
			break;
		case AttributeType.mpRecover:
			result = data.mpRecover;
			break;
		case AttributeType.attack:
			result = data.attack;
			break;
		case AttributeType.magicAttack:
			result = data.magicAttack;
			break;
		case AttributeType.defence:
			result = data.defence;
			break;
		case AttributeType.magicDefence:
			result = data.magicDefence;
			break;
		case AttributeType.attackSpeed:
			result = data.attackSpeed;
			break;
		case AttributeType.spellSpeed:
			result = data.spellSpeed;
			break;
		case AttributeType.moveSpeed:
			result = data.moveSpeed;
			break;
		case AttributeType.ciriticalAttack:
			result = data.ciriticalAttack;
			break;
		case AttributeType.ciriticalMagicAttack:
			result = data.ciriticalMagicAttack;
			break;
		case AttributeType.dex:
			result = data.dex;
			break;
		case AttributeType.dodge:
			result = data.dodge;
			break;
		case AttributeType.frozen:
			result = data.frozen;
			break;
		case AttributeType.hard:
			result = data.hard;
			break;
		case AttributeType.abnormalResist:
			result = data.abnormalResist;
			break;
		case AttributeType.criticalPercent:
			result = data.criticalPercent;
			break;
		case AttributeType.cdReduceRate:
			result = data.cdReduceRate;
			break;
		case AttributeType.attackAddRate:
			result = data.attackAddRate;
			break;
		case AttributeType.magicAttackAddRate:
			result = data.magicAttackAddRate;
			break;
		case AttributeType.defenceAddRate:
			result = data.defenceAddRate;
			break;
		case AttributeType.magicDefenceAddRate:
			result = data.magicDefenceAddRate;
			break;
		case AttributeType.ingnoreDefRate:
			result = data.ingnoreDefRate;
			break;
		case AttributeType.ingnoreMagicDefRate:
			result = data.ingnoreMagicDefRate;
			break;
		case AttributeType.baseAtk:
			result = data.baseAtk;
			break;
		case AttributeType.baseInt:
			result = data.baseInt;
			break;
		case AttributeType.baseIndependence:
			result = data.baseIndependent;
			break;
		}
		return result;
	}

	// Token: 0x06000FF0 RID: 4080 RVA: 0x000538E8 File Offset: 0x00051CE8
	public UnionCell GetBuffTablePropertyByName(string itemName, BuffTable data)
	{
		UnionCell result = null;
		switch (itemName)
		{
		case "atkAddRate":
			result = data.atkAddRate;
			break;
		case "intAddRate":
			result = data.intAddRate;
			break;
		case "staAddRate":
			result = data.staAddRate;
			break;
		case "sprAddRate":
			result = data.sprAddRate;
			break;
		case "maxHpAddRate":
			result = data.maxHpAddRate;
			break;
		case "maxMpAddRate":
			result = data.maxMpAddRate;
			break;
		case "ignoreDefAttackAddRate":
			result = data.ignoreDefAttackAddRate;
			break;
		case "ignoreDefMagicAttackAddRate":
			result = data.ignoreDefMagicAttackAddRate;
			break;
		case "independenceAddRate":
			result = data.independentAddRate;
			break;
		}
		return result;
	}

	// Token: 0x04000AC7 RID: 2759
	private const string kTablePath = "Data/table_fb/";

	// Token: 0x04000AC8 RID: 2760
	private bool bInit;

	// Token: 0x04000AC9 RID: 2761
	public static bool bNeedUninit;

	// Token: 0x04000ACA RID: 2762
	private Type[] mTypeList = new Type[]
	{
		typeof(GlobalSettingTable),
		typeof(MonsterAttributeTable),
		typeof(JobTable),
		typeof(EffectTable),
		typeof(FightPackageTable),
		typeof(SkillTable),
		typeof(MechanismTable),
		typeof(EqualItemTable),
		typeof(BuffInfoTable),
		typeof(BuffDrugConfigTable),
		typeof(BuffTable),
		typeof(BuffDrugConfigInfoTable),
		typeof(ObjectTable),
		typeof(ResTable),
		typeof(SceneRegionTable),
		typeof(ExpTable),
		typeof(MissionTable),
		typeof(DungeonTable),
		typeof(QuickBuyTable),
		typeof(DungeonUIConfigTable),
		typeof(ItemTable),
		typeof(ItemCollectionTable),
		typeof(TalkTable),
		typeof(NpcTable),
		typeof(DungeonTimesTable),
		typeof(PkLevelTable),
		typeof(EquipStrengthenTable),
		typeof(CitySceneTable),
		typeof(DestrucTable),
		typeof(UnitTable),
		typeof(NameTable),
		typeof(MonsterSpeech),
		typeof(TipsTable),
		typeof(CommonTipsDesc),
		typeof(ShopItemTable),
		typeof(AccountShopItemTable),
		typeof(MonsterPrefixTable),
		typeof(AuctionClassify),
		typeof(ShopTable),
		typeof(TeamNameTable),
		typeof(SkillDescriptionTable),
		typeof(FaceTable),
		typeof(EquipSuitTable),
		typeof(EquipMasterTable),
		typeof(AnnounceTable),
		typeof(EquipAttrTable),
		typeof(FunctionUnLock),
		typeof(ActiveTable),
		typeof(MagicCardTable),
		typeof(ActivityDungeonTable),
		typeof(MallTypeTable),
		typeof(AreaTable),
		typeof(ActiveMainTable),
		typeof(ItemConfigTable),
		typeof(SystemValueTable),
		typeof(SeasonDailyTable),
		typeof(RewardAdapterTable),
		typeof(VipTable),
		typeof(DeathTowerAwardTable),
		typeof(AcquiredMethodTable),
		typeof(GuildTable),
		typeof(ProtoTable.JarBonus),
		typeof(AIConfigTable),
		typeof(JarItemPool),
		typeof(GuildSkillTable),
		typeof(RobotConfigTable),
		typeof(GuildRoundtableTable),
		typeof(GuildBuildingTable),
		typeof(TestFunctionConfigTable),
		typeof(GuildTerritoryTable),
		typeof(PkHPLevelAdjustTable),
		typeof(PkHPProfessionAdjustTable),
		typeof(RedPacketTable),
		typeof(MissionScoreTable),
		typeof(GuildRewardTable),
		typeof(TeamDungeonTable),
		typeof(StrengthenTicketTable),
		typeof(GuildInspireTable),
		typeof(BudoAwardTable),
		typeof(DungeonDifficultyAdjustTable),
		typeof(NewbieGuideTable),
		typeof(VoiceTable),
		typeof(VipPrivilegeTable),
		typeof(FashionComposeSkyTable),
		typeof(SoundTable),
		typeof(EquipForgeTable),
		typeof(EquipStrModTable),
		typeof(LoadingResourcesTable),
		typeof(DefaultAdminServerTable),
		typeof(GuidanceMainTable),
		typeof(GuidanceMainItemTable),
		typeof(GuidanceEntranceTable),
		typeof(NotificationTable),
		typeof(SeasonLevelTable),
		typeof(SwitchClientFunctionTable),
		typeof(SeasonAttrTable),
		typeof(GuidanceLevelTable),
		typeof(AuctionBoothTable),
		typeof(CurrencyConfigureTable),
		typeof(FashionAttributesConfigTable),
		typeof(EquipQLValueTable),
		typeof(ShopMainFrameTable),
		typeof(FashionComposeTable),
		typeof(ActivityJarTable),
		typeof(JarItemShowPool),
		typeof(ChargeMallTable),
		typeof(ChargeGearTable),
		typeof(GiftTable),
		typeof(LiaoTianDynamicTextureTable),
		typeof(PetTable),
		typeof(GiftPackTable),
		typeof(PetFeedTable),
		typeof(PetDialogBaseTable),
		typeof(FatigueMakeUp),
		typeof(FatigueMakeUpPrice),
		typeof(PetLevelTable),
		typeof(LegendMainTable),
		typeof(LegendTraceTable),
		typeof(LinkTable),
		typeof(DungeonDailyDropTable),
		typeof(SuperLinkTable),
		typeof(MallGiftPackTable),
		typeof(MallItemTable),
		typeof(EquipScoreTable),
		typeof(MallLimitTimeActivity),
		typeof(PersonalTailorTriggerTable),
		typeof(BeadTable),
		typeof(PremiumLeagueTimeTable),
		typeof(DrawPrizeTable),
		typeof(RewardPoolTable),
		typeof(OpActivityTable),
		typeof(OpActivityTaskTable),
		typeof(JuedouchangItemPropellingTable),
		typeof(AchievementGroupMainItemTable),
		typeof(AchievementLevelInfoTable),
		typeof(AchievementGroupSubItemTable),
		typeof(AchievementGroupSecondMenuTable),
		typeof(ScreenShakeTable),
		typeof(EquipmentRelationTable),
		typeof(EquipHandbookAttachedTable),
		typeof(EquipHandbookCommentTable),
		typeof(EquipHandbookContentTable),
		typeof(EquipHandbookSourceTable),
		typeof(EquipHandbookCollectionTable),
		typeof(EquipTransMapTable),
		typeof(EquipRecoveryRewardTable),
		typeof(EquipRecoveryPriceTable),
		typeof(ChampionBattleTable),
		typeof(EquipRecoScUpConsRtiTable),
		typeof(ChapterTable),
		typeof(OneKeyWearTable),
		typeof(NewBieGuideJobData),
		typeof(InstituteTable),
		typeof(MoneyManageTable),
		typeof(LevelAdapterTable),
		typeof(ItemNotifyGetTable),
		typeof(ChargeDisplayTable),
		typeof(MysticalMerchantTable),
		typeof(AreaProvinceTable),
		typeof(TAPQuestionnaireTable),
		typeof(MasterSysGiftTable),
		typeof(ScoreWarRewardTable),
		typeof(DigMapTable),
		typeof(BetHorseShooter),
		typeof(BetHorseCfg),
		typeof(BetHorseMap),
		typeof(SkillPreTable),
		typeof(SkillPreInfoTable),
		typeof(FriendWelfareAddTable),
		typeof(BuffRandomTable),
		typeof(SDKClientResTable),
		typeof(RemovejewelsTable),
		typeof(StrengthenTicketSynthesisTable),
		typeof(StrenTicketFuseMaterialTable),
		typeof(StrengthenTicketFuseTable),
		typeof(ChangeFashionActiveMergeTable),
		typeof(BeadRandomBuff),
		typeof(GuildDungeonRewardTable),
		typeof(GuildDungeonLvlTable),
		typeof(AuctionNewFrameTable),
		typeof(AuctionNewFilterTable),
		typeof(EquipInitialAttribute),
		typeof(ItemBuffTable),
		typeof(GuildDungeonTypeTable),
		typeof(ReplacejewelsTable),
		typeof(ArtifactJarLotteryTable),
		typeof(ShopNewFilterTable),
		typeof(CommonHelpTable),
		typeof(BlackMarketTable),
		typeof(EquieUpdateTable),
		typeof(PveTrainingMonsterTable),
		typeof(ExpeditionMapTable),
		typeof(ExpeditionMapRewardTable),
		typeof(DungeonModelTable),
		typeof(ComboScoreTable),
		typeof(AdventureTeamTable),
		typeof(PictureFrameTable),
		typeof(WeekSignTable),
		typeof(WeekSignSumTable),
		typeof(GuildEmblemTable),
		typeof(NewTitleTable),
		typeof(GuildBuildInfoTable),
		typeof(ChiJiTimeTable),
		typeof(ChijiItemTable),
		typeof(ChijiBuffTable),
		typeof(ChiJiNpcRewardTable),
		typeof(ChijiEffectMapTable),
		typeof(ChijiSkillMapTable),
		typeof(MagicCardProbabilityTable),
		typeof(GuildActivityTable),
		typeof(AuctionMagiStrengAdditTable),
		typeof(EqualPvPEuqipTable),
		typeof(AssistEqStrengFouerDimAddTable),
		typeof(DailyTodoTable),
		typeof(EquipEnhanceAttributeTable),
		typeof(EquipEnhanceCostTable),
		typeof(MaterialsSynthesis),
		typeof(AdventureTeamTitleTypeTable),
		typeof(MonthSignAward),
		typeof(MonthSignCollectAward),
		typeof(TeamCopyFieldTable),
		typeof(TeamCopyFlopTable),
		typeof(TeamCopyTargetTable),
		typeof(TeamCopyStageTable),
		typeof(TeamCopyValueTable),
		typeof(TeamDuplicationSetTable),
		typeof(TeamCopyGridParamTable),
		typeof(TeamCopyGridMonsterTable),
		typeof(AdventureTeamGradeTable),
		typeof(UltimateChallengeBuffTable),
		typeof(UltimateChallengeDungeonTable),
		typeof(MallShopMultiITable),
		typeof(FashionDecomposeTable),
		typeof(EquipInscriptionHoleTable),
		typeof(InscriptionHoleSetTable),
		typeof(InscriptionTable),
		typeof(InscriptionExtractTable),
		typeof(InscriptionProbabilityTable),
		typeof(CurrencyQuickTipsTable),
		typeof(InscriptionSynthesisTable),
		typeof(AdventurePassRewardTable),
		typeof(AdventurePassActivityTable),
		typeof(AdventurePassBuyLevelTable),
		typeof(AdventurePassBuyRewardTable),
		typeof(EquipBaseScoreModTable),
		typeof(EquipBaseScoreTable),
		typeof(MagicCardUpdateTable),
		typeof(ChijiRewardTable),
		typeof(RandomDungeonTable),
		typeof(ScoreWar2v2RewardTable),
		typeof(BeadConvertCostTable),
		typeof(EquipStrModIndAtkTable),
		typeof(HonorLevelTable),
		typeof(HonorPlayerTable),
		typeof(EquieChangeTable),
		typeof(EquChangeConsumeTable),
		typeof(ChiJiShopTable),
		typeof(ChiJiShopItemTable),
		typeof(WeekSignSpringTable),
		typeof(ChiJiPkSceneTable),
		typeof(HireTask),
		typeof(TeamRewardTable),
		typeof(HonorRewardTable),
		typeof(LimiteBargainShowTable),
		typeof(WholeBargainDiscountTable),
		typeof(GuildBattleScoreRankRewardTable),
		typeof(GuildBattleTimeTable),
		typeof(ChampionshipScheduleTable),
		typeof(ChampionBigRewardPreviewTable),
		typeof(ChampionshipGuessBetTable),
		typeof(ChampionTimeTable),
		typeof(OverlondDeviceValueTable),
		typeof(OneStrengEnhanceTicketTable),
		typeof(GoldConsignmentValueTable),
		typeof(CityTeleportTable),
		typeof(UltimateChallengeRewardTable),
		typeof(MonopolyMapTable),
		typeof(MonopolyRandomTable),
		typeof(MonopolyCardTable),
		typeof(MonopolyCardRewardTable),
		typeof(HitEffectInfoTable)
	};

	// Token: 0x04000ACB RID: 2763
	private Dictionary<Type, Dictionary<int, object>> mTypeTableDict = new Dictionary<Type, Dictionary<int, object>>();

	// Token: 0x04000ACC RID: 2764
	public GlobalSettingTable gst;

	// Token: 0x04000ACD RID: 2765
	private Dictionary<int, Dictionary<int, int>> mSkillInfoDict = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x04000ACE RID: 2766
	private Dictionary<int, int> CommonSkillList = new Dictionary<int, int>();

	// Token: 0x04000ACF RID: 2767
	private Dictionary<int, List<int>> mBornInfoDict = new Dictionary<int, List<int>>();

	// Token: 0x04000AD0 RID: 2768
	private Dictionary<int, List<int>> mPassiveSkillInfoDict = new Dictionary<int, List<int>>();

	// Token: 0x04000AD1 RID: 2769
	private Dictionary<int, List<ComboScoreTable>> comboScoreDic = new Dictionary<int, List<ComboScoreTable>>();

	// Token: 0x04000AD2 RID: 2770
	private List<ulong> mPerLevelNeedExp = new List<ulong>();

	// Token: 0x04000AD3 RID: 2771
	private List<ulong> mToLevelNeedExp = new List<ulong>();

	// Token: 0x04000AD4 RID: 2772
	private Dictionary<int, IList<int>> JobChangeMap = new Dictionary<int, IList<int>>();

	// Token: 0x04000AD5 RID: 2773
	private Dictionary<int, int> OpenSkillBarLevelMap = new Dictionary<int, int>();

	// Token: 0x04000AD6 RID: 2774
	private List<int> NewbieGuideOrderList = new List<int>();

	// Token: 0x04000AD7 RID: 2775
	private Dictionary<int, List<InstituteTable>> jobInstituteDic = new Dictionary<int, List<InstituteTable>>();

	// Token: 0x04000AD8 RID: 2776
	private List<int> TeamDungeonFirstMenuList = new List<int>();

	// Token: 0x04000AD9 RID: 2777
	private Dictionary<int, List<int>> TeamDungeonSecondMenuDict = new Dictionary<int, List<int>>();

	// Token: 0x04000ADA RID: 2778
	private List<int> AuctionGuiJianShiWeaponType = new List<int>();

	// Token: 0x04000ADB RID: 2779
	private List<int> AuctionShenQiangShouWeaponType = new List<int>();

	// Token: 0x04000ADC RID: 2780
	private List<int> AuctionMoFaShiWeaponType = new List<int>();

	// Token: 0x04000ADD RID: 2781
	private List<int> AuctionGeDouJiaWeaponType = new List<int>();

	// Token: 0x04000ADE RID: 2782
	private List<int> AuctionDefenceType = new List<int>();

	// Token: 0x04000ADF RID: 2783
	private List<int> AuctionJewelryType = new List<int>();

	// Token: 0x04000AE0 RID: 2784
	private List<int> AuctionArmorType = new List<int>();

	// Token: 0x04000AE1 RID: 2785
	private List<int> AuctionQualityType = new List<int>();

	// Token: 0x04000AE2 RID: 2786
	private List<int> AuctionConsumablesType = new List<int>();

	// Token: 0x04000AE3 RID: 2787
	private List<int> AuctionMaterialsType = new List<int>();

	// Token: 0x04000AE4 RID: 2788
	private Dictionary<int, object> monsterAttributeMap = new Dictionary<int, object>();

	// Token: 0x04000AE5 RID: 2789
	private Dictionary<int, List<string>> treasureRoomRandomLibrary = new Dictionary<int, List<string>>();

	// Token: 0x04000AE6 RID: 2790
	private int[] pkHPProfessionAdjustInfo;

	// Token: 0x04000AE7 RID: 2791
	private Dictionary<int, object[]> dungeonDifficultyAdjustInfo = new Dictionary<int, object[]>();

	// Token: 0x04000AE8 RID: 2792
	public List<ComboTeachData> comboDataList = new List<ComboTeachData>();
}
