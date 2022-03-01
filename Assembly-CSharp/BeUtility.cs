using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Battle;
using GameClient;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020041CC RID: 16844
public class BeUtility
{
	// Token: 0x0601739D RID: 95133 RVA: 0x0072379B File Offset: 0x00721B9B
	public static int RemoveMonsterLevel(int mid)
	{
		return mid - mid / GlobalLogic.VALUE_100 % GlobalLogic.VALUE_100 * GlobalLogic.VALUE_100;
	}

	// Token: 0x0601739E RID: 95134 RVA: 0x007237B4 File Offset: 0x00721BB4
	public static void AdjustMonsterDifficulty(ref int ownerID, ref int monsterID)
	{
		int num = monsterID;
		num -= num % 10;
		num += ownerID % 10;
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(BeUtility.RemoveMonsterLevel(num), string.Empty, string.Empty);
		if (tableItem != null)
		{
			monsterID = num;
		}
	}

	// Token: 0x0601739F RID: 95135 RVA: 0x007237F7 File Offset: 0x00721BF7
	public static bool IsMonsterIDEqual(int ma, int mb)
	{
		return BeUtility.GetOnlyMonsterID(ma) == BeUtility.GetOnlyMonsterID(mb);
	}

	// Token: 0x060173A0 RID: 95136 RVA: 0x00723808 File Offset: 0x00721C08
	public static bool IsMonsterIDEqualList(List<int> lists, int ma)
	{
		for (int i = 0; i < lists.Count; i++)
		{
			if (BeUtility.IsMonsterIDEqual(ma, lists[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060173A1 RID: 95137 RVA: 0x00723841 File Offset: 0x00721C41
	public static int GetOnlyMonsterID(int m)
	{
		if (m < GlobalLogic.VALUE_10000)
		{
			return m;
		}
		return m / GlobalLogic.VALUE_10000;
	}

	// Token: 0x060173A2 RID: 95138 RVA: 0x00723858 File Offset: 0x00721C58
	public static int FindPvP(List<SkillFileName> list, int index)
	{
		SkillFileName skillFileName = list[index];
		for (int i = 0; i < list.Count; i++)
		{
			SkillFileName skillFileName2 = list[i];
			if (i != index && skillFileName2.isPvp && skillFileName2.folderName.Contains(skillFileName.folderName) && skillFileName2.lastName == skillFileName.lastName && skillFileName2.weaponType == skillFileName.weaponType)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060173A3 RID: 95139 RVA: 0x007238E0 File Offset: 0x00721CE0
	public static int FindChiji(List<SkillFileName> list, int index)
	{
		SkillFileName skillFileName = list[index];
		for (int i = 0; i < list.Count; i++)
		{
			SkillFileName skillFileName2 = list[i];
			if (i != index && skillFileName2.isChiji && skillFileName2.folderName.Contains(skillFileName.folderName) && skillFileName2.lastName == skillFileName.lastName && skillFileName2.weaponType == skillFileName.weaponType)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060173A4 RID: 95140 RVA: 0x00723968 File Offset: 0x00721D68
	public static List<SkillFileName> GetSkillFileList(string path)
	{
		string pathLastName = Utility.GetPathLastName(path);
		string path2 = path + "/" + pathLastName + "_FileList";
		Object obj = Singleton<AssetLoader>.instance.LoadRes(path2, true, 0U).obj;
		if (obj == null)
		{
			return null;
		}
		string @string = Encoding.Default.GetString((obj as TextAsset).bytes);
		ArrayList arrayList = MiniJSON.jsonDecode(@string) as ArrayList;
		List<SkillFileName> list = new List<SkillFileName>();
		for (int i = 0; i < arrayList.Count; i++)
		{
			SkillFileName item = new SkillFileName((string)arrayList[i], path);
			list.Add(item);
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (!list[j].isPvp)
			{
				int num = BeUtility.FindPvP(list, j);
				if (num > -1)
				{
					list[j].pvpPath = list[num].fullPath;
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			if (!list[k].isChiji)
			{
				int num2 = BeUtility.FindChiji(list, k);
				if (num2 > -1)
				{
					list[k].chijiPath = list[num2].fullPath;
				}
			}
		}
		return list;
	}

	// Token: 0x060173A5 RID: 95141 RVA: 0x00723ADC File Offset: 0x00721EDC
	public static string GetStrengthenEffectName(string resName)
	{
		if (resName.Contains("sword", StringComparison.OrdinalIgnoreCase))
		{
			return "Sword_Effect";
		}
		if (resName.Contains("gun", StringComparison.OrdinalIgnoreCase))
		{
			return "Gun_Effect";
		}
		if (resName.Contains("magegirl", StringComparison.OrdinalIgnoreCase))
		{
			return "Mage_Effect";
		}
		if (resName.Contains("fighter", StringComparison.OrdinalIgnoreCase))
		{
			return "Fighter_Effect";
		}
		if (resName.Contains("Paladin_liandao", StringComparison.OrdinalIgnoreCase) || resName.Contains("Paladin_zhanfu", StringComparison.OrdinalIgnoreCase) || resName.Contains("Paladin_shizijia", StringComparison.OrdinalIgnoreCase))
		{
			return "Paladin_Liandao_Effect";
		}
		if (resName.Contains("Paladin_nianzhu", StringComparison.OrdinalIgnoreCase))
		{
			return "Paladin_Nianzhu_Effect";
		}
		return "强化1";
	}

	// Token: 0x060173A6 RID: 95142 RVA: 0x00723B9C File Offset: 0x00721F9C
	public static BeEventHandle ShowWin(BeActor actor, BeEventHandle handler)
	{
		if (actor.sgGetCurrentState() == 0)
		{
			actor.Locomote(new BeStateData(19, 0), true);
		}
		else if (handler == null)
		{
			handler = actor.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
			{
				if ((ActionState)args[0] == ActionState.AS_IDLE)
				{
					actor.delayCaller.DelayCall(30, delegate
					{
						actor.Locomote(new BeStateData(19, 0), true);
					}, 0, 0, false);
					if (handler != null)
					{
						handler.Remove();
						handler = null;
					}
				}
			});
		}
		return handler;
	}

	// Token: 0x060173A7 RID: 95143 RVA: 0x00723C18 File Offset: 0x00722018
	public static List<RaceEquip> GetEquips(int[] equipsData)
	{
		List<RaceEquip> list = new List<RaceEquip>();
		for (int i = 0; i < equipsData.Length; i++)
		{
			RaceEquip raceEquip = new RaceEquip();
			raceEquip.id = (uint)equipsData[i];
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(equipsData[i], string.Empty, string.Empty);
			if (tableItem != null)
			{
				EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(tableItem.EquipPropID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					raceEquip.phyAtk = (uint)tableItem2.Atk;
					raceEquip.magAtk = (uint)tableItem2.MagicAtk;
					raceEquip.phydef = (uint)tableItem2.Def;
					raceEquip.magdef = (uint)tableItem2.MagicDef;
					raceEquip.stamina = (uint)tableItem2.Stamina;
					raceEquip.strenth = (uint)tableItem2.Strenth;
					raceEquip.intellect = (uint)tableItem2.Intellect;
					raceEquip.spirit = (uint)tableItem2.Spirit;
				}
			}
			list.Add(raceEquip);
		}
		return list;
	}

	// Token: 0x060173A8 RID: 95144 RVA: 0x00723D00 File Offset: 0x00722100
	public static bool AddComboSkill(BeAIManager aiManager, AIInputData data, BeActor actor)
	{
		bool flag = false;
		int num = 0;
		bool randomChangeDirection = false;
		if (data.inputs.Count > 0)
		{
			randomChangeDirection = data.inputs[0].randomChangeDirection;
			num = data.inputs[0].skillID;
			flag = actor.IsComboSkill(data.inputs[0].skillID);
		}
		if (!flag || num == 0)
		{
			return false;
		}
		data.inputs.Clear();
		BDEntityActionInfo actionInfoBySkillID = actor.GetActionInfoBySkillID(num);
		if (actionInfoBySkillID == null)
		{
			return false;
		}
		data.AddInput(num, 0, 0, 0, false);
		while (actionInfoBySkillID != null && actionInfoBySkillID.comboSkillID != 0)
		{
			int d = actionInfoBySkillID.comboStartFrame * 33;
			data.AddInput(actionInfoBySkillID.comboSkillID, d, 0, 0, randomChangeDirection);
			actionInfoBySkillID = actor.GetActionInfoBySkillID(actionInfoBySkillID.comboSkillID);
		}
		aiManager.aiInputData = data;
		return true;
	}

	// Token: 0x060173A9 RID: 95145 RVA: 0x00723DF8 File Offset: 0x007221F8
	public static BeActor GetMainPlayerActor(bool ispvp = false, List<ItemProperty> equipedEquipments = null, SkillSystemSourceType skillSourceType = SkillSystemSourceType.None)
	{
		if (equipedEquipments == null)
		{
			equipedEquipments = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
		}
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		BeActor beActor = new BeActor(0, 1, 0);
		beActor.InitData((int)DataManager<PlayerBaseData>.GetInstance().Level, tableItem.FightID, DataManager<SkillDataManager>.GetInstance().GetSkillInfo(ispvp, skillSourceType), "town", DataManager<PlayerBaseData>.GetInstance().JobTableID, equipedEquipments, DataManager<PlayerBaseData>.GetInstance().buffList, 0, DataManager<PlayerBaseData>.GetInstance().GetRankBuff(), DataManager<PlayerBaseData>.GetInstance().GetPetData(ispvp), null, null, false, false, ispvp, skillSourceType);
		if (skillSourceType == SkillSystemSourceType.Chiji)
		{
			beActor.GetEntityData().AdjustHPForPvP((int)DataManager<PlayerBaseData>.GetInstance().Level, (int)DataManager<PlayerBaseData>.GetInstance().Level, DataManager<PlayerBaseData>.GetInstance().JobTableID, 0, 8);
		}
		return beActor;
	}

	// Token: 0x060173AA RID: 95146 RVA: 0x00723ECC File Offset: 0x007222CC
	public static int GetMainActorResist()
	{
		int num = 0;
		List<ItemProperty> equipedEquipments = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
		for (int i = 0; i < equipedEquipments.Count; i++)
		{
			ItemProperty itemProperty = equipedEquipments[i];
			if (itemProperty != null)
			{
				num += itemProperty.resistMagic;
			}
		}
		List<Battle.DungeonBuff> buffList = DataManager<PlayerBaseData>.GetInstance().buffList;
		for (int j = 0; j < buffList.Count; j++)
		{
			Battle.DungeonBuff dungeonBuff = buffList[j];
			if (dungeonBuff != null)
			{
				BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(dungeonBuff.id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					num += TableManager.GetValueFromUnionCell(tableItem.ResistMagic, 1, true);
				}
			}
		}
		return num;
	}

	// Token: 0x060173AB RID: 95147 RVA: 0x00723F94 File Offset: 0x00722394
	public static DisplayAttribute GetMainPlayerActorAttribute(bool ispvp = false, bool isChiji = false)
	{
		SkillSystemSourceType skillSourceType = SkillSystemSourceType.None;
		if (isChiji)
		{
			skillSourceType = SkillSystemSourceType.Chiji;
		}
		BeActor mainPlayerActor = BeUtility.GetMainPlayerActor(ispvp, null, skillSourceType);
		BeEntityData entityData = mainPlayerActor.GetEntityData();
		return BeEntityData.GetActorAttributeForDisplay(entityData);
	}

	// Token: 0x060173AC RID: 95148 RVA: 0x00723FC4 File Offset: 0x007223C4
	public static int GetMainPlayerResistAddByBuff()
	{
		int num = 0;
		BeActor mainPlayerActor = BeUtility.GetMainPlayerActor(false, null, SkillSystemSourceType.None);
		if (mainPlayerActor == null)
		{
			return num;
		}
		List<BeBuff> list = ListPool<BeBuff>.Get();
		list = mainPlayerActor.buffController.GetBuffList();
		for (int i = 0; i < list.Count; i++)
		{
			BeBuff beBuff = list[i];
			if (beBuff != null)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(beBuff.buffData.ResistMagic, beBuff.level, true);
				if (valueFromUnionCell > 0)
				{
					num += valueFromUnionCell;
				}
			}
		}
		ListPool<BeBuff>.Release(list);
		return num;
	}

	// Token: 0x060173AD RID: 95149 RVA: 0x00724054 File Offset: 0x00722454
	public static BeActor GetPlayerActorByRaceInfo(RacePlayerInfo racePlayer)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)racePlayer.occupation, string.Empty, string.Empty);
		BeActor beActor = new BeActor(0, 1, 0);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("职业表没有此职业，ID：｛0｝", new object[]
			{
				racePlayer.occupation
			});
			return beActor;
		}
		beActor.InitData((int)racePlayer.level, tableItem.FightID, BattlePlayer.GetSkillInfo(racePlayer), "town", (int)racePlayer.occupation, BattlePlayer.GetEquips(racePlayer, false), BattlePlayer.GetBuffList(racePlayer), BattlePlayer.GetWeaponStrengthenLevel(racePlayer), BattlePlayer.GetRankBuff(racePlayer), BattlePlayer.GetPetData(racePlayer, false), null, null, false, false, false, SkillSystemSourceType.None);
		return beActor;
	}

	// Token: 0x060173AE RID: 95150 RVA: 0x007240F8 File Offset: 0x007224F8
	public static DisplayAttribute GetPlayerActorAttributeByRaceInfo(RacePlayerInfo racePlayer)
	{
		BeActor playerActorByRaceInfo = BeUtility.GetPlayerActorByRaceInfo(racePlayer);
		BeEntityData entityData = playerActorByRaceInfo.GetEntityData();
		return BeEntityData.GetActorAttributeForDisplay(entityData);
	}

	// Token: 0x060173AF RID: 95151 RVA: 0x0072411C File Offset: 0x0072251C
	public static void SendGM(string str)
	{
		SceneChat sceneChat = new SceneChat();
		sceneChat.channel = 1;
		sceneChat.targetId = 0UL;
		sceneChat.voiceKey = string.Empty;
		sceneChat.word = str;
		MonoSingleton<NetManager>.instance.SendCommand<SceneChat>(ServerType.GATE_SERVER, sceneChat);
	}

	// Token: 0x060173B0 RID: 95152 RVA: 0x00724160 File Offset: 0x00722560
	public static void AddBuffFromSkill(int skillID, int level, List<BuffInfoData> list, bool isPvp = false)
	{
		if (skillID > 0)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			FlatBufferArray<int> flatBufferArray = tableItem.BuffInfoIDs;
			if (isPvp)
			{
				flatBufferArray = tableItem.BuffInfoIDsPVP;
			}
			for (int i = 0; i < flatBufferArray.Count; i++)
			{
				int num = flatBufferArray[i];
				if (num > 0)
				{
					BuffInfoData buffInfoData = new BuffInfoData(num, level, 0);
					buffInfoData.level = level;
					BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffInfoData.buffID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (tableItem2.Type < 19)
						{
							list.Add(buffInfoData);
						}
					}
				}
			}
		}
	}

	// Token: 0x060173B1 RID: 95153 RVA: 0x00724230 File Offset: 0x00722630
	public static void CopyVectors(int[] fromVec, int[] toVec)
	{
		int num = 0;
		while (num < fromVec.Length && num < toVec.Length)
		{
			toVec[num] = toVec[num];
			num++;
		}
	}

	// Token: 0x060173B2 RID: 95154 RVA: 0x00724260 File Offset: 0x00722660
	private static int FindAbnormalIndex(string arName)
	{
		for (int i = 0; i < 13; i++)
		{
			if (Global.AbnormalNames[i] == arName)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060173B3 RID: 95155 RVA: 0x00724298 File Offset: 0x00722698
	public static int[] ParseAbnormalResistString(IList<string> strs)
	{
		int[] array = new int[13];
		for (int i = 0; i < strs.Count; i++)
		{
			try
			{
				string[] array2 = strs[i].Split(new char[]
				{
					':'
				});
				string text = array2[0];
				int num = Convert.ToInt32(array2[1]);
				int num2 = BeUtility.FindAbnormalIndex(text);
				if (num2 == -1)
				{
					string str = string.Format("ParseAbnormalResistString找不到异常状态{0}", text);
					Logger.LogErrorFormat(str, new object[0]);
				}
				else if (num != 0)
				{
					array[num2] = num;
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("ParseAbnormalResistString:{0}", new object[]
				{
					ex.ToString()
				});
			}
		}
		return array;
	}

	// Token: 0x060173B4 RID: 95156 RVA: 0x00724360 File Offset: 0x00722760
	public static void UseItemInBattle(int itemid, int skillid, int num = 1)
	{
		ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(itemid, true, true);
		if (itemByTableID != null)
		{
			SceneUseItem sceneUseItem = new SceneUseItem();
			sceneUseItem.uid = itemByTableID.GUID;
			sceneUseItem.param1 = (uint)Mathf.Max(1, num);
			sceneUseItem.param2 = (uint)skillid;
			NetManager.Instance().SendCommand<SceneUseItem>(ServerType.GATE_SERVER, sceneUseItem);
		}
	}

	// Token: 0x060173B5 RID: 95157 RVA: 0x007243B4 File Offset: 0x007227B4
	public static void ChangeWeaponInBattle(ulong uid, ulong sideUid)
	{
		if (uid > 0UL)
		{
			SceneUseItem sceneUseItem = new SceneUseItem();
			sceneUseItem.uid = uid;
			NetManager.Instance().SendCommand<SceneUseItem>(ServerType.GATE_SERVER, sceneUseItem);
		}
	}

	// Token: 0x060173B6 RID: 95158 RVA: 0x007243E4 File Offset: 0x007227E4
	public static bool HaveBuffState(IList<int> stateDataList, BeBuffStateType type)
	{
		for (int i = 0; i < stateDataList.Count; i++)
		{
			int num = stateDataList[i];
			if (num >= 1)
			{
				BeBuffStateType beBuffStateType = (BeBuffStateType)(1 << num);
				if (beBuffStateType == type)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060173B7 RID: 95159 RVA: 0x00724430 File Offset: 0x00722830
	public static int GetEquipsStrengthBySlot(BeActor actor, int equipWearSlot)
	{
		List<ItemProperty> itemProperties = actor.attribute.itemProperties;
		if (itemProperties == null || itemProperties.Count <= 0)
		{
			return -1;
		}
		for (int i = 0; i < itemProperties.Count; i++)
		{
			if (itemProperties[i].grid == equipWearSlot && !BeUtility.IsFashionWear(itemProperties[i].itemID))
			{
				return itemProperties[i].strengthen;
			}
		}
		return -1;
	}

	// Token: 0x060173B8 RID: 95160 RVA: 0x007244B4 File Offset: 0x007228B4
	public static bool IsFashionWear(int itemId)
	{
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
		return tableItem != null && (tableItem.SubType >= ItemTable.eSubType.FASHION_HAIR && tableItem.SubType <= ItemTable.eSubType.FASHION_EPAULET);
	}

	// Token: 0x060173B9 RID: 95161 RVA: 0x007244FC File Offset: 0x007228FC
	public static bool CheckHaveTag(int tag, int flag)
	{
		int num = tag & flag;
		return num != 0;
	}

	// Token: 0x060173BA RID: 95162 RVA: 0x00724514 File Offset: 0x00722914
	public static void PlayerReborn(BeActor actor)
	{
		if (BattleMain.instance == null)
		{
			return;
		}
		if (BattleMain.instance.GetDungeonManager() == null)
		{
			return;
		}
		if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
		{
			return;
		}
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		if (!DungeonUtility.CanReborn(dungeonID, true))
		{
			SystemNotifyManager.SystemNotify(1098, string.Empty);
			return;
		}
		DungeonTable table = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table;
		if (table != null)
		{
			int rebornCount = table.RebornCount;
			bool flag = true;
			IBattle battle = BattleMain.instance.GetBattle();
			if (battle != null && battle.IsRebornCountLimit())
			{
				flag = (battle.GetLeftRebornCount() > 0);
			}
			if (!flag)
			{
				return;
			}
			if (rebornCount > 0 && actor != null)
			{
				int dungeonRebornCount = actor.dungeonRebornCount;
				if (dungeonRebornCount >= rebornCount)
				{
					return;
				}
			}
		}
		byte seat = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerInfo.seat;
		DungeonUtility.StartRebornProcess(seat, seat, dungeonID);
	}

	// Token: 0x060173BB RID: 95163 RVA: 0x00724624 File Offset: 0x00722A24
	public static bool CheckVipAutoDrug()
	{
		int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		if (vipLevel == 0 || !BeUtility.CheckVipFuncOpen(30))
		{
			return false;
		}
		if (BeUtility.CheckNotSet("SETTING_VIPDRUG"))
		{
			return BeUtility.GetDefaultData(30);
		}
		string roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		return Singleton<SettingManager>.GetInstance().GetVipSettingData("SETTING_VIPDRUG", roleId);
	}

	// Token: 0x060173BC RID: 95164 RVA: 0x00724690 File Offset: 0x00722A90
	public static bool CheckVipAutoUseDrug()
	{
		int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		if (vipLevel == 0 || !BeUtility.CheckVipFuncOpen(28))
		{
			return false;
		}
		if (BeUtility.CheckNotSet("STR_VIPPREFER"))
		{
			return BeUtility.GetDefaultData(28);
		}
		string roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		return Singleton<SettingManager>.GetInstance().GetVipSettingData("STR_VIPPREFER", roleId);
	}

	// Token: 0x060173BD RID: 95165 RVA: 0x007246FC File Offset: 0x00722AFC
	public static bool CheckVipAutoReborn()
	{
		int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		if (vipLevel == 0 || !BeUtility.CheckVipFuncOpen(31))
		{
			return false;
		}
		if (BeUtility.CheckNotSet("SETTING_VIPREBORN"))
		{
			return BeUtility.GetDefaultData(31);
		}
		string roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		return Singleton<SettingManager>.GetInstance().GetVipSettingData("SETTING_VIPREBORN", roleId);
	}

	// Token: 0x060173BE RID: 95166 RVA: 0x00724768 File Offset: 0x00722B68
	public static bool CheckVipAutoUseCrystalSkill()
	{
		int vipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		if (vipLevel == 0 || !BeUtility.CheckVipFuncOpen(32))
		{
			return true;
		}
		if (BeUtility.CheckNotSet("SETTING_VIPCRYSTAL"))
		{
			return BeUtility.GetDefaultData(32);
		}
		string roleId = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		return Singleton<SettingManager>.GetInstance().GetVipSettingData("SETTING_VIPCRYSTAL", roleId);
	}

	// Token: 0x060173BF RID: 95167 RVA: 0x007247D4 File Offset: 0x00722BD4
	protected static bool CheckNotSet(string key)
	{
		string arg = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
		string key2 = string.Format("{0}{1}", key, arg);
		return PlayerLocalSetting.GetValue(key2) == null;
	}

	// Token: 0x060173C0 RID: 95168 RVA: 0x00724810 File Offset: 0x00722C10
	public static bool GetDefaultData(int tableId)
	{
		SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(tableId, string.Empty, string.Empty);
		return tableItem.ValueB == 1;
	}

	// Token: 0x060173C1 RID: 95169 RVA: 0x00724846 File Offset: 0x00722C46
	public static bool CheckVipFuncOpen(int tableId)
	{
		return Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(tableId, string.Empty, string.Empty).Open;
	}

	// Token: 0x060173C2 RID: 95170 RVA: 0x00724864 File Offset: 0x00722C64
	public static int GetDungeonMagicValue(BeEntity owner)
	{
		if (owner == null || owner.CurrentBeScene == null || owner.CurrentBeBattle.dungeonManager == null || owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager() == null)
		{
			return 0;
		}
		int dungeonID = owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.dungeonID;
		if (dungeonID == -1)
		{
			return 0;
		}
		return DungeonUtility.GetDungeonResistMagicValueById(dungeonID);
	}

	// Token: 0x060173C3 RID: 95171 RVA: 0x007248D4 File Offset: 0x00722CD4
	public static void ResetCamera()
	{
		if (BattleMain.instance == null || BattleMain.instance.GetDungeonManager() == null)
		{
			return;
		}
		GeSceneEx geScene = BattleMain.instance.GetDungeonManager().GetGeScene();
		if (geScene == null)
		{
			return;
		}
		geScene.DestroyMaskCameraEffect();
		GeCamera camera = geScene.GetCamera();
		if (camera == null)
		{
			return;
		}
		GeCameraControllerScroll controller = camera.GetController();
		if (controller != null)
		{
			controller.ResetCamera();
			controller.SetPause(false);
			float off = -1f * controller.GetOffset();
			controller.MoveCamera(off, 0.01f);
			controller.SetXLimitOffset(0f, 0f);
		}
	}

	// Token: 0x060173C4 RID: 95172 RVA: 0x00724970 File Offset: 0x00722D70
	public static PrecBead[] SwitchPrecBead(RacePrecBead[] racePreBead)
	{
		if (racePreBead == null)
		{
			return null;
		}
		PrecBead[] array = new PrecBead[racePreBead.Length];
		for (int i = 0; i < racePreBead.Length; i++)
		{
			if (racePreBead[i] != null)
			{
				array[i] = new PrecBead();
				int preciousBeadId = (int)racePreBead[i].preciousBeadId;
				array[i].preciousBeadId = preciousBeadId;
				array[i].randomBuffId = (int)racePreBead[i].buffId;
			}
		}
		return array;
	}

	// Token: 0x060173C5 RID: 95173 RVA: 0x007249DC File Offset: 0x00722DDC
	public static List<InscriptionHoleData> SwitchInscriptHoleData(uint[] ids)
	{
		List<InscriptionHoleData> list = new List<InscriptionHoleData>();
		for (int i = 0; i < ids.Length; i++)
		{
			list.Add(new InscriptionHoleData
			{
				InscriptionId = (int)ids[i]
			});
		}
		return list;
	}

	// Token: 0x060173C6 RID: 95174 RVA: 0x00724A1C File Offset: 0x00722E1C
	public static string GetAttachModelPath(int jobId)
	{
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(jobId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return null;
		}
		ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.AttachMonsterResID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return null;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x060173C7 RID: 95175 RVA: 0x00724A70 File Offset: 0x00722E70
	public static int GetSkillTopLevelByRoleLevel(int skillid, int RoleLevel)
	{
		SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 0;
		}
		if (RoleLevel < tableItem.LevelLimit)
		{
			return 0;
		}
		if (tableItem.LevelLimitAmend <= 0)
		{
			return 0;
		}
		int num = (RoleLevel - tableItem.LevelLimit) / tableItem.LevelLimitAmend + 1;
		if (num > tableItem.TopLevelLimit)
		{
			num = tableItem.TopLevelLimit;
		}
		return num;
	}

	// Token: 0x060173C8 RID: 95176 RVA: 0x00724AE0 File Offset: 0x00722EE0
	public static Dictionary<int, int> GetPKRobotSkillLevel(Dictionary<int, int> skillInfo, int roleLevle)
	{
		if (skillInfo == null)
		{
			return null;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> keyValuePair in skillInfo)
		{
			int key = keyValuePair.Key;
			Dictionary<int, int>.Enumerator enumerator;
			KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
			int value = keyValuePair2.Value;
			int skillTopLevelByRoleLevel = BeUtility.GetSkillTopLevelByRoleLevel(key, roleLevle);
			if (skillTopLevelByRoleLevel > 0)
			{
				dictionary.Add(key, skillTopLevelByRoleLevel);
			}
			else
			{
				dictionary.Add(key, value);
			}
		}
		return dictionary;
	}

	// Token: 0x060173C9 RID: 95177 RVA: 0x00724B60 File Offset: 0x00722F60
	public static int GetEquipStrModByStrength(int iLevel, EquipStrMod strMod)
	{
		EquipStrModTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipStrModTable>(2, string.Empty, string.Empty);
		if (iLevel < 1 || iLevel > 20)
		{
			return 0;
		}
		int num = 0;
		int result = 0;
		if (strMod != EquipStrMod.WpStrenthMod)
		{
			if (strMod != EquipStrMod.ArmStrenthMod)
			{
				if (strMod == EquipStrMod.JewStrenthMod)
				{
					num = tableItem.JewStrenthMod.Count;
					result = tableItem.JewStrenthMod[iLevel - 1];
				}
			}
			else
			{
				num = tableItem.ArmStrenthMod.Count;
				result = tableItem.ArmStrenthMod[iLevel - 1];
			}
		}
		else
		{
			num = tableItem.WpStrenthMod.Count;
			result = tableItem.WpStrenthMod[iLevel - 1];
		}
		if (iLevel - 1 < 0 || iLevel > num)
		{
			return 0;
		}
		return result;
	}

	// Token: 0x060173CA RID: 95178 RVA: 0x00724C24 File Offset: 0x00723024
	public static int GetEquipStrModByColor(int color, EquipStrMod strMod)
	{
		EquipStrModTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipStrModTable>(2, string.Empty, string.Empty);
		if (color < 1 || color > 6)
		{
			return 0;
		}
		int num = 0;
		int result = 0;
		switch (strMod)
		{
		case EquipStrMod.WpColorQaMod:
			num = tableItem.WpColorQaMod.Count;
			result = tableItem.WpColorQaMod[color - 1];
			break;
		case EquipStrMod.WpColorQbMod:
			num = tableItem.WpColorQbMod.Count;
			result = tableItem.WpColorQbMod[color - 1];
			break;
		case EquipStrMod.ArmColorQaMod:
			num = tableItem.ArmColorQaMod.Count;
			result = tableItem.ArmColorQaMod[color - 1];
			break;
		case EquipStrMod.ArmColorQbMod:
			num = tableItem.ArmColorQbMod.Count;
			result = tableItem.ArmColorQbMod[color - 1];
			break;
		case EquipStrMod.JewColorQaMod:
			num = tableItem.JewColorQaMod.Count;
			result = tableItem.JewColorQaMod[color - 1];
			break;
		case EquipStrMod.JewColorQbMod:
			num = tableItem.JewColorQbMod.Count;
			result = tableItem.JewColorQbMod[color - 1];
			break;
		}
		if (color - 1 < 0 || color > num)
		{
			return 0;
		}
		return result;
	}

	// Token: 0x060173CB RID: 95179 RVA: 0x00724D5B File Offset: 0x0072315B
	public static bool IsJewelry(ItemTable.eSubType eSubType)
	{
		return eSubType == ItemTable.eSubType.RING || eSubType == ItemTable.eSubType.NECKLASE || eSubType == ItemTable.eSubType.BRACELET;
	}

	// Token: 0x060173CC RID: 95180 RVA: 0x00724D7B File Offset: 0x0072317B
	public static bool IsArmy(ItemTable.eSubType eSubType)
	{
		switch (eSubType)
		{
		case ItemTable.eSubType.HEAD:
		case ItemTable.eSubType.CHEST:
		case ItemTable.eSubType.BELT:
		case ItemTable.eSubType.LEG:
		case ItemTable.eSubType.BOOT:
			return true;
		default:
			return false;
		}
	}

	// Token: 0x060173CD RID: 95181 RVA: 0x00724DA1 File Offset: 0x007231A1
	public static bool IsWeapon(ItemTable.eSubType eSubType)
	{
		return eSubType == ItemTable.eSubType.WEAPON;
	}

	// Token: 0x060173CE RID: 95182 RVA: 0x00724DA8 File Offset: 0x007231A8
	public static BeActor GetLocalActor()
	{
		if (BattleMain.instance == null)
		{
			return null;
		}
		if (BattleMain.instance.GetPlayerManager() == null)
		{
			return null;
		}
		if (BattleMain.instance.GetPlayerManager().GetMainPlayer() == null)
		{
			return null;
		}
		return BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
	}

	// Token: 0x060173CF RID: 95183 RVA: 0x00724DFC File Offset: 0x007231FC
	public static string GetDungeonName()
	{
		if (BattleMain.instance == null)
		{
			return null;
		}
		if (BattleMain.instance.GetDungeonManager() == null)
		{
			return null;
		}
		if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
		{
			return null;
		}
		if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table == null)
		{
			return null;
		}
		return BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.Name;
	}

	// Token: 0x060173D0 RID: 95184 RVA: 0x00724E70 File Offset: 0x00723270
	public static void GetAllFriendPlayers(BeActor owner, List<BeActor> list)
	{
		if (owner == null || owner.CurrentBeBattle == null || owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !list.Contains(playerActor) && playerActor.m_iCamp == owner.m_iCamp)
			{
				list.Add(playerActor);
			}
		}
	}

	// Token: 0x060173D1 RID: 95185 RVA: 0x00724F08 File Offset: 0x00723308
	public static void GetAllEnemyPlayers(BeActor owner, List<BeActor> list)
	{
		if (owner == null || owner.CurrentBeBattle == null || owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !list.Contains(playerActor) && playerActor.m_iCamp != owner.m_iCamp)
			{
				list.Add(playerActor);
			}
		}
	}

	// Token: 0x060173D2 RID: 95186 RVA: 0x00724FA0 File Offset: 0x007233A0
	private static bool IsNewFashion(int itemID)
	{
		if (itemID <= 0)
		{
			return false;
		}
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.newFashion)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060173D3 RID: 95187 RVA: 0x00725004 File Offset: 0x00723404
	private static int HasNewHeadWearOrHead(uint[] equipItemIds, EFashionWearSlotType slotType)
	{
		for (int i = 0; i < equipItemIds.Length; i++)
		{
			int num = (int)equipItemIds[i];
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				EFashionWearSlotType efashionWearSlotType = (EFashionWearSlotType)(tableItem.SubType - 10);
				if (efashionWearSlotType == slotType && BeUtility.IsNewFashion(num))
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x060173D4 RID: 95188 RVA: 0x0072506C File Offset: 0x0072346C
	public static void DealWithFashion(uint[] equipItemIds)
	{
		int num = BeUtility.HasNewHeadWearOrHead(equipItemIds, EFashionWearSlotType.Chest);
		int num2 = BeUtility.HasNewHeadWearOrHead(equipItemIds, EFashionWearSlotType.Head);
		if (num != -1 && num2 == -1)
		{
			equipItemIds[num] = 0U;
		}
	}

	// Token: 0x060173D5 RID: 95189 RVA: 0x0072509C File Offset: 0x0072349C
	public static uint[] CopyVector(uint[] equipItemIds)
	{
		if (equipItemIds == null)
		{
			return null;
		}
		uint[] array = new uint[equipItemIds.Length];
		for (int i = 0; i < equipItemIds.Length; i++)
		{
			array[i] = equipItemIds[i];
		}
		return array;
	}

	// Token: 0x060173D6 RID: 95190 RVA: 0x007250D8 File Offset: 0x007234D8
	public static void CancelCurrentSkill(BeActor monster)
	{
		BeSkill currentSkill = monster.GetCurrentSkill();
		if (currentSkill != null)
		{
			monster.CancelSkill(currentSkill.skillID, true);
			monster.Locomote(new BeStateData(0, 0), true);
		}
	}

	// Token: 0x060173D7 RID: 95191 RVA: 0x00725110 File Offset: 0x00723510
	public static void ForceMonsterUseSkill(int monsterid, int skillId, BeActor owner)
	{
		if (owner != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			owner.CurrentBeScene.FindActorById2(list, monsterid, false);
			for (int i = 0; i < list.Count; i++)
			{
				BeSkill skill = list[i].GetSkill(skillId);
				if (skill != null)
				{
					skill.ResetCoolDown();
					list[i].UseSkill(skillId, true);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x060173D8 RID: 95192 RVA: 0x00725180 File Offset: 0x00723580
	public static void DoMonsterDeadById(int monsterid, BeActor owner)
	{
		if (owner != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			owner.CurrentBeScene.FindActorById2(list, monsterid, false);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null && !beActor.IsDead())
				{
					beActor.DoDead(true);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x060173D9 RID: 95193 RVA: 0x007251EC File Offset: 0x007235EC
	public static int GetComboSkillId(BeActor actor, int skillId)
	{
		int num = skillId;
		if (actor == null)
		{
			return num;
		}
		BeSkill skill = actor.GetSkill(num);
		if (skill == null)
		{
			return num;
		}
		if (skill.comboSkillSourceID != 0)
		{
			num = skill.comboSkillSourceID;
		}
		if (skill.skillData.IsAttackCombo == 1)
		{
			num = actor.GetEntityData().normalAttackID;
		}
		return num;
	}

	// Token: 0x060173DA RID: 95194 RVA: 0x00725243 File Offset: 0x00723643
	public static bool IsRaidBattle()
	{
		return BattleMain.instance != null && BattleMain.battleType == BattleType.RaidPVE;
	}

	// Token: 0x060173DB RID: 95195 RVA: 0x0072525C File Offset: 0x0072365C
	public static bool NeedShareBySGSH(int hurtId, BeActor actor)
	{
		if (actor == null || actor.IsDead())
		{
			return true;
		}
		EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(hurtId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return true;
		}
		List<BeMechanism> mechanismList = actor.MechanismList;
		bool flag = false;
		if (mechanismList != null)
		{
			for (int i = 0; i < mechanismList.Count; i++)
			{
				Mechanism2017 mechanism = mechanismList[i] as Mechanism2017;
				if (mechanism != null)
				{
					flag = true;
					break;
				}
			}
		}
		return tableItem.DamageType != EffectTable.eDamageType.PHYSIC || !flag;
	}

	// Token: 0x060173DC RID: 95196 RVA: 0x007252F4 File Offset: 0x007236F4
	public static string Format(string format, object arg0)
	{
		if (format == null)
		{
			Logger.LogErrorFormat("format is ivalid", new object[0]);
			return null;
		}
		BeUtility.CheckCachedStringBuilder();
		BeUtility.s_CachedStringBuilder.Length = 0;
		BeUtility.s_CachedStringBuilder.AppendFormat(format, arg0);
		return BeUtility.s_CachedStringBuilder.ToString();
	}

	// Token: 0x060173DD RID: 95197 RVA: 0x00725340 File Offset: 0x00723740
	public static string Format(string format, object arg0, object arg1)
	{
		if (format == null)
		{
			Logger.LogErrorFormat("format is ivalid", new object[0]);
			return null;
		}
		BeUtility.CheckCachedStringBuilder();
		BeUtility.s_CachedStringBuilder.Length = 0;
		BeUtility.s_CachedStringBuilder.AppendFormat(format, arg0, arg1);
		return BeUtility.s_CachedStringBuilder.ToString();
	}

	// Token: 0x060173DE RID: 95198 RVA: 0x00725390 File Offset: 0x00723790
	public static string Format(string format, params object[] arg0)
	{
		if (format == null)
		{
			Logger.LogErrorFormat("format is ivalid", new object[0]);
			return null;
		}
		BeUtility.CheckCachedStringBuilder();
		BeUtility.s_CachedStringBuilder.Length = 0;
		BeUtility.s_CachedStringBuilder.AppendFormat(format, arg0);
		return BeUtility.s_CachedStringBuilder.ToString();
	}

	// Token: 0x060173DF RID: 95199 RVA: 0x007253DC File Offset: 0x007237DC
	private static void CheckCachedStringBuilder()
	{
		if (BeUtility.s_CachedStringBuilder == null)
		{
			BeUtility.s_CachedStringBuilder = new StringBuilder(1024);
		}
	}

	// Token: 0x060173E0 RID: 95200 RVA: 0x007253F7 File Offset: 0x007237F7
	public static void SaveBattleRecord(BaseBattle battle)
	{
	}

	// Token: 0x060173E1 RID: 95201 RVA: 0x007253FC File Offset: 0x007237FC
	public static void SaveDataToFile(string path, string str)
	{
		FileStream fileStream = null;
		Encoding utf = Encoding.UTF8;
		byte[] bytes = utf.GetBytes(str);
		try
		{
			fileStream = File.OpenWrite(path);
			fileStream.Position = fileStream.Length;
			fileStream.Write(bytes, 0, bytes.Length);
		}
		catch (Exception ex)
		{
			Console.WriteLine("文件打开失败{0}", ex.ToString());
		}
		finally
		{
			fileStream.Close();
		}
	}

	// Token: 0x060173E2 RID: 95202 RVA: 0x0072547C File Offset: 0x0072387C
	public static bool GetKeepDistancePos(BeActor target, BeActor self, int dis, int YRadius, out VInt3 targetPos)
	{
		if (target == null || self == null)
		{
			targetPos = default(VInt3);
			return false;
		}
		targetPos = target.GetPosition();
		if (self.GetPosition().x > target.GetPosition().x)
		{
			targetPos.x += dis * GlobalLogic.VALUE_10000;
		}
		else
		{
			targetPos.x -= dis * GlobalLogic.VALUE_10000;
		}
		if (Mathf.Abs(self.GetPosition().y - target.GetPosition().y) < YRadius)
		{
			targetPos.y = self.GetPosition().y;
		}
		return true;
	}

	// Token: 0x060173E3 RID: 95203 RVA: 0x00725544 File Offset: 0x00723944
	public static bool CheckDungeonIsLimitTimeHell()
	{
		return BattleMain.instance != null && BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().GetDungeonDataManager() != null && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table != null && (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL);
	}

	// Token: 0x060173E4 RID: 95204 RVA: 0x007255DC File Offset: 0x007239DC
	public static bool IsActorUseCanChargeSkill(BeActor actor)
	{
		if (actor != null && actor.IsCastingSkill())
		{
			BDEntityActionInfo skillActionInfo = actor.GetSkillActionInfo(actor.GetCurSkillID());
			if (skillActionInfo != null && skillActionInfo.useCharge)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04010B98 RID: 68504
	private static StringBuilder s_CachedStringBuilder;
}
