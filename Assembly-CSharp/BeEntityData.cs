using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x0200417A RID: 16762
public class BeEntityData
{
	// Token: 0x06016F8F RID: 94095 RVA: 0x0070BDA4 File Offset: 0x0070A1A4
	public BeEntityData(int level, int battledataid, Dictionary<int, int> info)
	{
		this.level = level;
		this.battleDataID = battledataid;
		if (info == null)
		{
			return;
		}
		this.skillLevelInfo = new Dictionary<int, CrypticInt32>();
		foreach (KeyValuePair<int, int> keyValuePair in info)
		{
			int key = keyValuePair.Key;
			Dictionary<int, int>.Enumerator enumerator;
			KeyValuePair<int, int> keyValuePair2 = enumerator.Current;
			int value = keyValuePair2.Value;
			if (!this.skillLevelInfo.ContainsKey(key))
			{
				this.skillLevelInfo.Add(key, value);
			}
		}
	}

	// Token: 0x17001F63 RID: 8035
	// (get) Token: 0x06016F90 RID: 94096 RVA: 0x0070BE9D File Offset: 0x0070A29D
	private FrameRandomImp FrameRandom
	{
		get
		{
			return this.owner.FrameRandom;
		}
	}

	// Token: 0x17001F64 RID: 8036
	// (get) Token: 0x06016F91 RID: 94097 RVA: 0x0070BEAA File Offset: 0x0070A2AA
	// (set) Token: 0x06016F92 RID: 94098 RVA: 0x0070BEB2 File Offset: 0x0070A2B2
	public VInt weight { get; set; }

	// Token: 0x17001F65 RID: 8037
	// (get) Token: 0x06016F93 RID: 94099 RVA: 0x0070BEBB File Offset: 0x0070A2BB
	// (set) Token: 0x06016F94 RID: 94100 RVA: 0x0070BEC3 File Offset: 0x0070A2C3
	public int type { get; set; }

	// Token: 0x17001F66 RID: 8038
	// (get) Token: 0x06016F95 RID: 94101 RVA: 0x0070BECC File Offset: 0x0070A2CC
	// (set) Token: 0x06016F96 RID: 94102 RVA: 0x0070BED4 File Offset: 0x0070A2D4
	public int exp { get; set; }

	// Token: 0x17001F67 RID: 8039
	// (get) Token: 0x06016F97 RID: 94103 RVA: 0x0070BEDD File Offset: 0x0070A2DD
	// (set) Token: 0x06016F98 RID: 94104 RVA: 0x0070BEE5 File Offset: 0x0070A2E5
	public int normalAttackID { get; set; }

	// Token: 0x17001F68 RID: 8040
	// (get) Token: 0x06016F99 RID: 94105 RVA: 0x0070BEEE File Offset: 0x0070A2EE
	// (set) Token: 0x06016F9A RID: 94106 RVA: 0x0070BEF6 File Offset: 0x0070A2F6
	public int jumpAttackID { get; set; }

	// Token: 0x17001F69 RID: 8041
	// (get) Token: 0x06016F9B RID: 94107 RVA: 0x0070BEFF File Offset: 0x0070A2FF
	// (set) Token: 0x06016F9C RID: 94108 RVA: 0x0070BF07 File Offset: 0x0070A307
	public int runAttackID { get; set; }

	// Token: 0x17001F6A RID: 8042
	// (get) Token: 0x06016F9D RID: 94109 RVA: 0x0070BF10 File Offset: 0x0070A310
	// (set) Token: 0x06016F9E RID: 94110 RVA: 0x0070BF18 File Offset: 0x0070A318
	public int getupIDRand { get; set; }

	// Token: 0x17001F6B RID: 8043
	// (get) Token: 0x06016F9F RID: 94111 RVA: 0x0070BF21 File Offset: 0x0070A321
	// (set) Token: 0x06016FA0 RID: 94112 RVA: 0x0070BF29 File Offset: 0x0070A329
	public int getupID { get; set; }

	// Token: 0x17001F6C RID: 8044
	// (get) Token: 0x06016FA1 RID: 94113 RVA: 0x0070BF32 File Offset: 0x0070A332
	// (set) Token: 0x06016FA2 RID: 94114 RVA: 0x0070BF3A File Offset: 0x0070A33A
	public int hitIDRand { get; set; }

	// Token: 0x17001F6D RID: 8045
	// (get) Token: 0x06016FA3 RID: 94115 RVA: 0x0070BF43 File Offset: 0x0070A343
	// (set) Token: 0x06016FA4 RID: 94116 RVA: 0x0070BF4B File Offset: 0x0070A34B
	public int hitID { get; set; }

	// Token: 0x17001F6E RID: 8046
	// (get) Token: 0x06016FA6 RID: 94118 RVA: 0x0070BF69 File Offset: 0x0070A369
	// (set) Token: 0x06016FA5 RID: 94117 RVA: 0x0070BF54 File Offset: 0x0070A354
	public BeEntity owner
	{
		get
		{
			return this._owner;
		}
		set
		{
			this._owner = value;
			this.battleData.owner = value;
		}
	}

	// Token: 0x06016FA7 RID: 94119 RVA: 0x0070BF71 File Offset: 0x0070A371
	public int GetCrystalNum()
	{
		return this.crystalNum;
	}

	// Token: 0x06016FA8 RID: 94120 RVA: 0x0070BF79 File Offset: 0x0070A379
	public void SetCrystalNum(int num)
	{
		this.crystalNum = num;
	}

	// Token: 0x06016FA9 RID: 94121 RVA: 0x0070BF82 File Offset: 0x0070A382
	public void ModifyCrystalessNum(int num)
	{
		this.crystalNum += num;
		this.crystalNum = Mathf.Max(0, this.crystalNum);
	}

	// Token: 0x06016FAA RID: 94122 RVA: 0x0070BFA4 File Offset: 0x0070A3A4
	public static DisplayAttribute GetMonsterAttributeForDisplay(BeEntityData attribute)
	{
		BattleData battleData = attribute.battleData;
		return new DisplayAttribute
		{
			maxHp = (float)battleData.fMaxHp,
			maxMp = (float)battleData.fMaxMp,
			hpRecover = (float)battleData.fHpRecoer,
			mpRecover = (float)battleData.fMpRecover,
			baseSta = (float)IntMath.Double2Int(battleData._baseSta),
			baseAtk = (float)IntMath.Double2Int(battleData._baseAtk),
			baseInt = (float)IntMath.Double2Int(battleData._baseInt),
			baseSpr = (float)IntMath.Double2Int(battleData._baseSpr),
			baseIndependence = (float)IntMath.Double2Int(battleData._baseIndependence),
			attack = (float)battleData.displayAttack,
			magicAttack = (float)battleData.displayMagicAttack,
			defence = (float)battleData.fDefence,
			magicDefence = (float)battleData.fMagicDefence,
			attackSpeed = (float)battleData.attackSpeed / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			spellSpeed = (float)battleData.spellSpeed / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			moveSpeed = (float)battleData.moveSpeed / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			ciriticalAttack = (float)battleData.ciriticalAttack / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			ciriticalMagicAttack = (float)battleData.ciriticalMagicAttack / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			dex = (float)battleData.dex / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			dodge = (float)battleData.dodge / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			frozen = (float)battleData.frozen,
			hard = (float)battleData.hard
		};
	}

	// Token: 0x06016FAB RID: 94123 RVA: 0x0070C188 File Offset: 0x0070A588
	public static DisplayAttribute GetActorAttributeForDisplay(BeEntityData attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		int num = attribute.professtion;
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("找不到职业ID为{0}的职业", new object[]
			{
				num
			});
			return null;
		}
		FightPackageTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FightPackageTable>(tableItem.FightID, string.Empty, string.Empty);
		BattleData battleData = attribute.battleData;
		DisplayAttribute displayAttribute = new DisplayAttribute
		{
			maxHp = (float)attribute.GetMaxHP(),
			maxMp = (float)attribute.GetMaxMP(),
			hpRecover = (float)battleData.fHpRecoer,
			mpRecover = (float)battleData.fMpRecover,
			baseSta = (float)((int)battleData._baseSta),
			baseAtk = (float)((int)battleData._baseAtk),
			baseInt = (float)((int)battleData._baseInt),
			baseSpr = (float)((int)battleData._baseSpr),
			baseIndependence = (float)((int)battleData._baseIndependence),
			attack = (float)battleData.displayAttack,
			magicAttack = (float)battleData.displayMagicAttack,
			defence = (float)battleData.fDefence,
			magicDefence = (float)battleData.fMagicDefence,
			attackSpeed = (float)(battleData.attackSpeed - tableItem2.AttackSpeed) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			spellSpeed = (float)(battleData.spellSpeed - tableItem2.SpellSpeed) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			moveSpeed = (float)(battleData.moveSpeed - tableItem2.MoveSpeed) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			ciriticalAttack = (float)(battleData.ciriticalAttack - tableItem2.PhysicalCritical) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			ciriticalMagicAttack = (float)(battleData.ciriticalMagicAttack - tableItem2.MagicCritical) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			dex = (float)(battleData.dex - tableItem2.HitRate) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			dodge = (float)(battleData.dodge - tableItem2.MissRate) / (float)GlobalLogic.VALUE_1000 * (float)GlobalLogic.VALUE_100,
			frozen = (float)battleData.frozen,
			hard = (float)battleData.hard,
			resistMagic = (float)battleData.resistMagic,
			lightAttack = (float)battleData.magicElementsAttack[1],
			fireAttack = (float)battleData.magicElementsAttack[2],
			iceAttack = (float)battleData.magicElementsAttack[3],
			darkAttack = (float)battleData.magicElementsAttack[4],
			lightDefence = (float)battleData.magicElementsDefence[1],
			fireDefence = (float)battleData.magicElementsDefence[2],
			iceDefence = (float)battleData.magicElementsDefence[3],
			darkDefence = (float)battleData.magicElementsDefence[4]
		};
		BeEntityData beEntityData = new BeEntityData(attribute.GetLevel(), attribute.battleDataID, null);
		beEntityData.InitBattleData();
		beEntityData.CalculateLevelGrow(attribute.GetLevel());
		beEntityData.PostInit(null);
		for (int i = 0; i < 41; i++)
		{
			AttributeType attributeType = (AttributeType)i;
			int value = attribute.battleData.GetValue(attributeType);
			int value2 = beEntityData.battleData.GetValue(attributeType);
			string attributeString = Global.GetAttributeString(attributeType);
			if (displayAttribute.attachValue.ContainsKey(attributeString))
			{
				displayAttribute.attachValue[attributeString] = value - value2;
			}
		}
		return displayAttribute;
	}

	// Token: 0x06016FAC RID: 94124 RVA: 0x0070C5A0 File Offset: 0x0070A9A0
	public static BeEntityData GetActorAttribute(int level, int fightID, List<ItemProperty> equip, Dictionary<int, int> skillLevelInfo, List<int> passiveBuffIDs = null, List<ItemProperty> sideEquips = null, BeEntity owner = null)
	{
		BeEntityData beEntityData = new BeEntityData(level, fightID, skillLevelInfo);
		beEntityData.InitBattleData();
		beEntityData.CalculateLevelGrow(level);
		beEntityData.CalculatePassiveBuffIDs(passiveBuffIDs);
		beEntityData.CalculateEquipmentAdd(equip, sideEquips);
		beEntityData.PostInit(owner);
		return beEntityData;
	}

	// Token: 0x06016FAD RID: 94125 RVA: 0x0070C5E0 File Offset: 0x0070A9E0
	public void InitBattleData()
	{
		if (this.battleDataID <= 0)
		{
			return;
		}
		FightPackageTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FightPackageTable>(this.battleDataID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.battleData._maxHp = tableItem.HP;
			this.battleData._maxMp = tableItem.MP;
			this.battleData._hpRecover = tableItem.HPRecover;
			this.battleData._mpRecover = tableItem.MPRecover;
			this.battleData.attack = tableItem.PhysicAttack;
			this.battleData.magicAttack = tableItem.MagicAttack;
			this.battleData.defence = tableItem.PhysicDefence;
			this.battleData.magicDefence = tableItem.MagicDefence;
			this.battleData.ciriticalAttack = tableItem.PhysicalCritical;
			this.battleData.ciriticalMagicAttack = tableItem.MagicCritical;
			this.battleData.frozen = tableItem.StarkValue;
			this.battleData.hard = tableItem.HardValue;
			this.battleData.moveSpeed = tableItem.MoveSpeed;
			this.battleData.dex = tableItem.HitRate;
			this.battleData.dodge = tableItem.MissRate;
			this.battleData.attackSpeed = tableItem.AttackSpeed;
			this.battleData.spellSpeed = tableItem.SpellSpeed;
			this.battleData.baseAtk = tableItem.Power;
			this.battleData.baseInt = tableItem.Intellect;
			this.battleData.baseSpr = tableItem.Spirit;
			this.battleData.baseSta = tableItem.Streangth;
			this.battleData.hpGrow = tableItem.HPLevel;
			this.battleData.mpGrow = tableItem.MPLevel;
			this.battleData.atkGrow = tableItem.PowerLevel;
			this.battleData.intGrow = tableItem.IntellectLevel;
			this.battleData.sprGrow = tableItem.SpiritLevel;
			this.battleData.staGrow = tableItem.StrengthLevel;
			this.battleData.mpRecoverGrow = tableItem.MPRecoverLevel;
			this.battleData.magicElementsAttack[1] = tableItem.LightAttack;
			this.battleData.magicElementsAttack[2] = tableItem.FireAttack;
			this.battleData.magicElementsAttack[3] = tableItem.IceAttack;
			this.battleData.magicElementsAttack[4] = tableItem.DarkAttack;
			this.battleData.magicElementsDefence[1] = tableItem.LightDefence;
			this.battleData.magicElementsDefence[2] = tableItem.FireDefence;
			this.battleData.magicElementsDefence[3] = tableItem.IceDefence;
			this.battleData.magicElementsDefence[4] = tableItem.DarkDefence;
			this.battleData.abnormalResist = tableItem.AbormalResist;
			this.SetAbnormalResists(BeUtility.ParseAbnormalResistString(tableItem.AbormalResists), false);
		}
	}

	// Token: 0x06016FAE RID: 94126 RVA: 0x0070C9B3 File Offset: 0x0070ADB3
	public int GetAttributeValue(AttributeType at)
	{
		return this.battleData.GetValue(at);
	}

	// Token: 0x06016FAF RID: 94127 RVA: 0x0070C9C1 File Offset: 0x0070ADC1
	public void SetAttributeValue(AttributeType at, int value, bool add = false)
	{
		this.battleData.SetValue(at, value, add);
	}

	// Token: 0x06016FB0 RID: 94128 RVA: 0x0070C9D4 File Offset: 0x0070ADD4
	public void PostInit(BeEntity entity = null)
	{
		if (entity != null)
		{
			this.owner = entity;
		}
		this.battleData.maxHp = this.battleData.fMaxHp;
		this.battleData.maxMp = this.battleData.fMaxMp;
		this.battleData.hp = this.battleData.maxHp;
		this.battleData.mp = this.battleData.maxMp;
		this.battleData.hpRecover = this.battleData.fHpRecoer;
		this.battleData.mpRecover = this.battleData.fMpRecover;
		this.ChangeMaxHpByResist();
	}

	// Token: 0x06016FB1 RID: 94129 RVA: 0x0070CA94 File Offset: 0x0070AE94
	public void CalculateLevelGrow(int level)
	{
		if (level > GlobalLogic.VALUE_1)
		{
			BattleData battleData = this.battleData;
			battleData._maxHp += (level - GlobalLogic.VALUE_1) * this.battleData.hpGrow;
			BattleData battleData2 = this.battleData;
			battleData2._maxMp += (level - GlobalLogic.VALUE_1) * this.battleData.mpGrow;
			BattleData battleData3 = this.battleData;
			battleData3.baseAtk += (level - GlobalLogic.VALUE_1) * this.battleData.atkGrow;
			BattleData battleData4 = this.battleData;
			battleData4.baseInt += (level - GlobalLogic.VALUE_1) * this.battleData.intGrow;
			BattleData battleData5 = this.battleData;
			battleData5.baseSpr += (level - GlobalLogic.VALUE_1) * this.battleData.sprGrow;
			BattleData battleData6 = this.battleData;
			battleData6.baseSta += (level - GlobalLogic.VALUE_1) * this.battleData.staGrow;
			BattleData battleData7 = this.battleData;
			battleData7.hard += (level - GlobalLogic.VALUE_1) * this.battleData.hardGrow;
			BattleData battleData8 = this.battleData;
			battleData8._mpRecover += (level - GlobalLogic.VALUE_1) * this.battleData.mpRecoverGrow;
		}
	}

	// Token: 0x06016FB2 RID: 94130 RVA: 0x0070CC4C File Offset: 0x0070B04C
	public void CalculatePassiveBuffIDs(List<int> passiveBuffIDs)
	{
		if (passiveBuffIDs == null)
		{
			return;
		}
		for (int i = 0; i < passiveBuffIDs.Count; i++)
		{
			if (passiveBuffIDs[i] != 0)
			{
				BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(passiveBuffIDs[i], string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				BattleData battleData = this.battleData;
				battleData._maxHp += TableManager.GetValueFromUnionCell(tableItem.maxHp, 1, true);
				BattleData battleData2 = this.battleData;
				battleData2._maxMp += TableManager.GetValueFromUnionCell(tableItem.maxMp, 1, true);
				BattleData battleData3 = this.battleData;
				battleData3.baseAtk += TableManager.GetValueFromUnionCell(tableItem.baseAtk, 1, true);
				BattleData battleData4 = this.battleData;
				battleData4.baseInt += TableManager.GetValueFromUnionCell(tableItem.baseInt, 1, true);
				BattleData battleData5 = this.battleData;
				battleData5.baseSpr += TableManager.GetValueFromUnionCell(tableItem.spr, 1, true);
				BattleData battleData6 = this.battleData;
				battleData6.baseSta += TableManager.GetValueFromUnionCell(tableItem.sta, 1, true);
			}
		}
	}

	// Token: 0x06016FB3 RID: 94131 RVA: 0x0070CDA4 File Offset: 0x0070B1A4
	private void CalculateEquipmentAdd(List<ItemProperty> equipmentsProperty, List<ItemProperty> sideEquipsProperty)
	{
		this.itemProperties = equipmentsProperty;
		if (equipmentsProperty == null)
		{
			return;
		}
		for (int i = 0; i < equipmentsProperty.Count; i++)
		{
			CrypticInt32 itemID = equipmentsProperty[i].itemID;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				EEquipWearSlotType subType = (EEquipWearSlotType)tableItem.SubType;
				if (subType == EEquipWearSlotType.EquipWeapon)
				{
					this.currentWeapon = equipmentsProperty[i];
				}
			}
			this.AddEquipment(equipmentsProperty[i]);
		}
		if (sideEquipsProperty == null)
		{
			return;
		}
		for (int j = 0; j < sideEquipsProperty.Count; j++)
		{
			this.backupWeapons.Add(sideEquipsProperty[j]);
		}
		if (Global.Settings.isDebug && Global.Settings.isGiveEquips && Utility.IsStringValid(Global.Settings.switchEquipList))
		{
			string[] array = Global.Settings.switchEquipList.Split(new char[]
			{
				','
			});
			List<int> list = new List<int>();
			for (int k = 0; k < array.Length; k++)
			{
				int num = Convert.ToInt32(array[k]);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
				ItemProperty battleProperty = itemData.GetBattleProperty(0);
				battleProperty.itemID = num;
				this.backupWeapons.Add(battleProperty);
			}
		}
	}

	// Token: 0x06016FB4 RID: 94132 RVA: 0x0070CF0C File Offset: 0x0070B30C
	public void AddEquipment(ItemProperty property)
	{
		this._DealEquipment(property, true);
	}

	// Token: 0x06016FB5 RID: 94133 RVA: 0x0070CF16 File Offset: 0x0070B316
	public void RemoveEquipment(ItemProperty property)
	{
		this._DealEquipment(property, false);
	}

	// Token: 0x06016FB6 RID: 94134 RVA: 0x0070CF20 File Offset: 0x0070B320
	private void _DealEquipment(ItemProperty property, bool add = true)
	{
		for (int i = 0; i < 41; i++)
		{
			AttributeType attributeType = (AttributeType)i;
			int value = property.GetValue(attributeType);
			if (value != 0)
			{
				if (add)
				{
					this.SetAttributeValue(attributeType, value, true);
				}
				else
				{
					this.SetAttributeValue(attributeType, -value, true);
				}
			}
		}
		for (int j = 1; j < 5; j++)
		{
			if (property.magicElements != null)
			{
				if (property.magicElements[j] > 0)
				{
					if (add)
					{
						this.battleData.magicELements[j] += property.magicElements[j];
					}
					else
					{
						this.battleData.magicELements[j] -= property.magicElements[j];
					}
				}
			}
		}
		for (int k = 1; k < 5; k++)
		{
			if (property.magicElementsAttack[k] != 0)
			{
				if (add)
				{
					CrypticInt32[] magicElementsAttack = this.battleData.magicElementsAttack;
					int num = k;
					magicElementsAttack[num] += property.magicElementsAttack[k];
				}
				else
				{
					CrypticInt32[] magicElementsAttack2 = this.battleData.magicElementsAttack;
					int num2 = k;
					magicElementsAttack2[num2] -= property.magicElementsAttack[k];
				}
			}
		}
		for (int l = 1; l < 5; l++)
		{
			if (property.magicElementsDefence[l] != 0)
			{
				if (add)
				{
					CrypticInt32[] magicElementsDefence = this.battleData.magicElementsDefence;
					int num3 = l;
					magicElementsDefence[num3] += property.magicElementsDefence[l];
				}
				else
				{
					CrypticInt32[] magicElementsDefence2 = this.battleData.magicElementsDefence;
					int num4 = l;
					magicElementsDefence2[num4] -= property.magicElementsDefence[l];
				}
			}
		}
		for (int m = 0; m < 13; m++)
		{
			if (property.abnormalResists[m] != 0)
			{
				if (add)
				{
					CrypticInt32[] abnormalResists = this.battleData.abnormalResists;
					int num5 = m;
					abnormalResists[num5] += property.abnormalResists[m];
				}
				else
				{
					CrypticInt32[] abnormalResists2 = this.battleData.abnormalResists;
					int num6 = m;
					abnormalResists2[num6] -= property.abnormalResists[m];
				}
			}
		}
		if (property.resistMagic != 0)
		{
			if (add)
			{
				BattleData battleData = this.battleData;
				battleData.resistMagic += property.resistMagic;
			}
			else
			{
				BattleData battleData2 = this.battleData;
				battleData2.resistMagic -= property.resistMagic;
			}
		}
	}

	// Token: 0x06016FB7 RID: 94135 RVA: 0x0070D27E File Offset: 0x0070B67E
	private bool _isAvoidDamage(EffectTable.eAvoidDamageType type, BeEntity target)
	{
		return type == EffectTable.eAvoidDamageType.AV_FACINGAWAY && this.owner.IsFacingAway(target);
	}

	// Token: 0x06016FB8 RID: 94136 RVA: 0x0070D29C File Offset: 0x0070B69C
	public AttackResult GetAttackResult(BeEntityData targetData, EffectTable.eDamageType type, int hurtid)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		VRate b = this.battleData.dex - targetData.battleData.dodge;
		VRate vrate = (type != EffectTable.eDamageType.PHYSIC) ? this.battleData.ciriticalMagicAttack : this.battleData.ciriticalAttack;
		int skillLevel = this.GetSkillLevel(tableItem.SkillID);
		VRate b2 = TableManager.GetValueFromUnionCell(tableItem.AttachCritical, skillLevel, true);
		vrate += b2;
		BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
		beEventParam.m_Int = hurtid;
		beEventParam.m_Rate = vrate;
		this.owner.TriggerEventNew(BeEventType.onReplaceHurtTableCiriticalData, beEventParam);
		vrate = beEventParam.m_Rate;
		DataStructPool.EventParamPool.Release(beEventParam);
		this.DealAttachHitRate(ref b, ref vrate, tableItem.SkillID);
		if (!tableItem.IsCanMiss)
		{
			b = VRate.one;
		}
		if (tableItem != null && this._isAvoidDamage(tableItem.AvoidDamageType, targetData.owner))
		{
			b = 0;
		}
		if (!((int)this.FrameRandom.Range1000() <= b))
		{
			return AttackResult.MISS;
		}
		if ((int)this.FrameRandom.Range1000() <= vrate)
		{
			return AttackResult.CRITICAL;
		}
		return AttackResult.NORMAL;
	}

	// Token: 0x06016FB9 RID: 94137 RVA: 0x0070D3F8 File Offset: 0x0070B7F8
	public int GetHurtFrozenTime(BeEntityData targetData, int hurtid)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		int num = 0;
		if (tableItem != null)
		{
			num = TableManager.GetValueFromUnionCell(tableItem.HardValue, this.GetSkillLevel(tableItem.SkillID), true);
			int[] array = new int[]
			{
				num
			};
			this.owner.TriggerEvent(BeEventType.onChangeHardValue, new object[]
			{
				hurtid,
				array
			});
			num = array[0];
		}
		this.DealAttachFroze(ref num, tableItem.SkillID);
		VFactor f = new VFactor((long)Singleton<TableManager>.instance.gst.frozenPercent, (long)GlobalLogic.VALUE_10000);
		int num2 = (this.battleData.frozen - targetData.battleData.hard + num) * f;
		return Mathf.Max(0, num2);
	}

	// Token: 0x06016FBA RID: 94138 RVA: 0x0070D4D0 File Offset: 0x0070B8D0
	public VInt GetFrozenDisMax(int hurtid)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		int frozenDistanceMax = tableItem.FrozenDistanceMax;
		return VInt.NewVInt(frozenDistanceMax, GlobalLogic.VALUE_1000);
	}

	// Token: 0x06016FBB RID: 94139 RVA: 0x0070D508 File Offset: 0x0070B908
	public MagicElementType GetAttackElementType(int hurtID)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return MagicElementType.NONE;
		}
		int[] array = new int[]
		{
			tableItem.MagicElementType,
			hurtID
		};
		this.owner.TriggerEvent(BeEventType.onChangeMagicElement, new object[]
		{
			array
		});
		MagicElementType magicElementType = (MagicElementType)array[0];
		if (magicElementType == MagicElementType.NONE && tableItem.MagicElementISuse)
		{
			magicElementType = this.GetOwnAttackElement();
		}
		else if (magicElementType == MagicElementType.MAX)
		{
			return MagicElementType.NONE;
		}
		return magicElementType;
	}

	// Token: 0x06016FBC RID: 94140 RVA: 0x0070D58C File Offset: 0x0070B98C
	public int GetDamage(BeEntityData targetData, int hurtID, AttackResult damageType)
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 0;
		}
		int skillLevel = this.GetSkillLevel(tableItem.SkillID);
		EffectTable.eDamageType damageType2 = tableItem.DamageType;
		bool flag = BattleMain.IsModePvP(this.owner.battleType);
		int num = 0;
		VPercent vpercent = VPercent.zero;
		if (BattleMain.IsChijiNeedReplaceHurtId(hurtID, this.owner.battleType))
		{
			ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(hurtID, string.Empty, string.Empty);
			num = TableManager.GetValueFromUnionCell(tableItem2.DamageFixedValuePVP, skillLevel, true);
			vpercent = TableManager.GetValueFromUnionCell(tableItem2.DamageRatePVP, skillLevel, true);
		}
		else
		{
			num = TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageFixedValue : tableItem.DamageFixedValuePVP, skillLevel, true);
			vpercent = TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageRate : tableItem.DamageRatePVP, skillLevel, true);
		}
		BeEvent.BeEventParam beEventParam = DataStructPool.EventParamPool.Get();
		beEventParam.m_Int = hurtID;
		beEventParam.m_Int2 = num;
		beEventParam.m_Percent = vpercent;
		beEventParam.m_Obj = targetData.owner;
		this.owner.TriggerEventNew(BeEventType.onReplaceHurtTableDamageData, beEventParam);
		num = beEventParam.m_Int2;
		vpercent = beEventParam.m_Percent;
		DataStructPool.EventParamPool.Release(beEventParam);
		if (this.isSpecialAPC)
		{
			num = 0;
			vpercent = TableManager.GetValueFromUnionCell(tableItem.DamageRateAPC, skillLevel, true);
		}
		MagicElementType attackElementType = this.GetAttackElementType(hurtID);
		this.DealAttachDamage(ref num, ref vpercent, tableItem.SkillID);
		int num2 = this.GetSkillDamage(damageType2, targetData, vpercent, attackElementType);
		int num3 = this.GetSkillFixDamage(damageType2, targetData, num, attackElementType);
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000,
			GlobalLogic.VALUE_1000
		};
		this.owner.TriggerEvent(BeEventType.onChangeDamage, new object[]
		{
			hurtID,
			array
		});
		if (targetData != null && targetData.owner != null)
		{
			targetData.owner.TriggerEvent(BeEventType.onBeHitChangeDamage, new object[]
			{
				hurtID,
				array,
				tableItem
			});
		}
		num2 *= VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
		num3 *= VFactor.NewVFactor(array[1], GlobalLogic.VALUE_1000);
		int num4 = num2 + num3;
		if (damageType == AttackResult.CRITICAL)
		{
			this.m_CriticalPercentNew[0] = this.battleData.criticalPercent;
			int[] criticalPercentNew = this.m_CriticalPercentNew;
			this.owner.TriggerEvent(BeEventType.onChangeSummonMonsterAddCritiDamage, new object[]
			{
				criticalPercentNew
			});
			num4 *= (this.criticalDamageFactor + criticalPercentNew[0]).factor;
		}
		if (this.adjustBalance)
		{
			if (this.level < targetData.level)
			{
				double num5 = Math.Pow((double)(Math.Min(targetData.level, GlobalLogic.VALUE_50) / Math.Min(this.level, GlobalLogic.VALUE_50)), (double)Global.Settings.pkDamageAdjustFactor);
				num4 = IntMath.Double2Int((double)num4 * num5);
			}
			PkHPLevelAdjustTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<PkHPLevelAdjustTable>(this.level, string.Empty, string.Empty);
			if (this.owner != null && this.owner.CurrentBeBattle != null && this.owner.CurrentBeBattle.PkRaceType == 8)
			{
				num4 *= VRate.Factor(tableItem3.Attackfactor_chiji);
			}
			else
			{
				num4 *= VRate.Factor(tableItem3.Attackfactor);
			}
			PkHPProfessionAdjustTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<PkHPProfessionAdjustTable>(this.professtion, string.Empty, string.Empty);
			if (tableItem4 != null)
			{
				if (this.owner != null && this.owner.CurrentBeBattle != null)
				{
					if (this.owner.CurrentBeBattle.PkRaceType == 6)
					{
						num4 *= VRate.Factor(tableItem4.DamageFactor_3v3);
					}
					else if (this.owner.CurrentBeBattle.PkRaceType == 8)
					{
						num4 *= VRate.Factor(tableItem4.DamageFactor_chiji);
					}
				}
				else
				{
					num4 *= VRate.Factor(tableItem4.DamageFactor);
				}
			}
		}
		return Mathf.Max(GlobalLogic.VALUE_1, num4);
	}

	// Token: 0x06016FBD RID: 94141 RVA: 0x0070D9FC File Offset: 0x0070BDFC
	public void DealAttachDamage(ref int fixDamage, ref VPercent hurtRate, int skillID)
	{
		if (this.owner != null && this.owner is BeActor)
		{
			BeActor beActor = this.owner as BeActor;
			BeSkill skill = beActor.GetSkill(skillID);
			if (skill != null)
			{
				fixDamage = (fixDamage + skill.attackAddFix) * (VRate.one + skill.attackAddRate).factor;
				hurtRate = (hurtRate.i + VPercent.interPercent2VPercent(skill.attackAdd)) * (VRate.one + skill.attackAddRate).factor;
			}
		}
	}

	// Token: 0x06016FBE RID: 94142 RVA: 0x0070DAAC File Offset: 0x0070BEAC
	public void DealAttachHitRate(ref VRate hitRate, ref VRate criticalHitRate, int skillID)
	{
		if (this.owner != null && this.owner is BeActor)
		{
			BeActor beActor = this.owner as BeActor;
			BeSkill skill = beActor.GetSkill(skillID);
			if (skill != null)
			{
				hitRate += skill.hitRateAdd;
				criticalHitRate += skill.criticalHitRateAdd;
			}
		}
	}

	// Token: 0x06016FBF RID: 94143 RVA: 0x0070DB1C File Offset: 0x0070BF1C
	public void DealAttachFroze(ref int froze, int skillID)
	{
		if (this.owner != null && this.owner is BeActor)
		{
			BeActor beActor = this.owner as BeActor;
			BeSkill skill = beActor.GetSkill(skillID);
			if (skill != null)
			{
				froze *= (VRate.one + skill.hardAddRate).factor;
			}
		}
	}

	// Token: 0x06016FC0 RID: 94144 RVA: 0x0070DB80 File Offset: 0x0070BF80
	private bool CanApplyDamageModify(AddDamageInfo damageInfo, EffectTable.eDamageType damageType, EffectTable.eDamageDistanceType damageDistanceType)
	{
		if (damageInfo.attackType == AttackType.NONE)
		{
			return true;
		}
		switch (damageInfo.attackType)
		{
		case AttackType.PHYSIC:
			return damageType == EffectTable.eDamageType.PHYSIC;
		case AttackType.MAGIC:
			return damageType == EffectTable.eDamageType.MAGIC;
		case AttackType.NEAR:
			return damageDistanceType == EffectTable.eDamageDistanceType.NEAR;
		case AttackType.FAR:
			return damageDistanceType == EffectTable.eDamageDistanceType.FAR;
		default:
			return false;
		}
	}

	// Token: 0x06016FC1 RID: 94145 RVA: 0x0070DBD8 File Offset: 0x0070BFD8
	public int GetAttachDamages(BeEntity target, int damage, EffectTable.eDamageType damageType, EffectTable.eDamageDistanceType damageDistanceType, ref int damage2, List<int> attachValues)
	{
		this.ResetAddDamageArr(2);
		this.ResetAddDamageArr(3);
		List<AddDamageInfo> list = this.m_AddDamageList[2];
		List<AddDamageInfo> list2 = this.m_AddDamageList[3];
		list.AddRange(this.battleData.addDamageFix);
		list2.AddRange(this.battleData.addDamagePercent);
		this.owner.TriggerEvent(BeEventType.onChangeSummonMonsterAddDamage, new object[]
		{
			list,
			list2
		});
		int num = 0;
		if (damageType == EffectTable.eDamageType.MAGIC)
		{
			for (int i = 0; i < this.battleData.skillAddMagicDamagePercent.Count; i++)
			{
				int num2 = IntMath.Double2Int((double)damage * ((double)this.battleData.skillAddMagicDamagePercent[i].value / (double)GlobalLogic.VALUE_1000));
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		else if (damageType == EffectTable.eDamageType.PHYSIC)
		{
			for (int j = 0; j < this.battleData.skillAddDamagePercent.Count; j++)
			{
				int num3 = IntMath.Double2Int((double)damage * ((double)this.battleData.skillAddDamagePercent[j].value / (double)GlobalLogic.VALUE_1000));
				if (num3 > num)
				{
					num = num3;
				}
			}
		}
		int num4 = 0;
		for (int k = 0; k < list.Count; k++)
		{
			if (list[k].value > num4)
			{
				num4 = list[k].value;
			}
		}
		for (int l = 0; l < list2.Count; l++)
		{
			int num5 = IntMath.Double2Int((double)damage * ((double)list2[l].value / (double)GlobalLogic.VALUE_1000));
			if (num5 > num4)
			{
				num4 = num5;
			}
		}
		int num6 = damage + (num4 + num);
		if (num4 > 0)
		{
		}
		if (target.GetEntityData() != null)
		{
			BeEntityData entityData = target.GetEntityData();
			int num7 = 0;
			for (int m = 0; m < entityData.battleData.reduceDamageFix.Count; m++)
			{
				AddDamageInfo damageInfo = entityData.battleData.reduceDamageFix[m];
				if (this.CanApplyDamageModify(damageInfo, damageType, damageDistanceType))
				{
					num7 += damageInfo.value;
				}
			}
			int num8 = 0;
			int num9 = 0;
			for (int n = 0; n < entityData.battleData.reduceDamagePercent.Count; n++)
			{
				AddDamageInfo damageInfo2 = entityData.battleData.reduceDamagePercent[n];
				if (this.CanApplyDamageModify(damageInfo2, damageType, damageDistanceType))
				{
					if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.GeDangNewAlgorithms))
					{
						num8 += damageInfo2.value;
					}
					else if (damageInfo2.value >= 400)
					{
						num9 = Mathf.Max(damageInfo2.value, num9);
					}
					else
					{
						num8 += damageInfo2.value;
					}
				}
			}
			int num10 = 0;
			for (int num11 = 0; num11 < entityData.battleData.reduceExtraDamagePercent.Count; num11++)
			{
				AddDamageInfo damageInfo3 = entityData.battleData.reduceExtraDamagePercent[num11];
				if (this.CanApplyDamageModify(damageInfo3, damageType, damageDistanceType))
				{
					num10 += damageInfo3.value;
				}
			}
			int num12 = 0;
			for (int num13 = 0; num13 < entityData.battleData.reduceMeiyingDamagePercent.Count; num13++)
			{
				AddDamageInfo damageInfo4 = entityData.battleData.reduceMeiyingDamagePercent[num13];
				if (this.CanApplyDamageModify(damageInfo4, damageType, damageDistanceType))
				{
					num12 += damageInfo4.value;
				}
			}
			int num14 = 0;
			if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.GeDangNewAlgorithms))
			{
				for (int num15 = 0; num15 < entityData.battleData.reduceGeDangDamagePercent.Count; num15++)
				{
					AddDamageInfo damageInfo5 = entityData.battleData.reduceGeDangDamagePercent[num15];
					if (this.CanApplyDamageModify(damageInfo5, damageType, damageDistanceType))
					{
						num14 = Mathf.Max(damageInfo5.value, num14);
					}
				}
			}
			num8 = Mathf.Clamp(num8 + num9, 0, 990);
			int num16 = IntMath.Double2Int((double)num8 / (double)GlobalLogic.VALUE_1000 * (double)damage);
			num7 += num16;
			num6 -= num7;
			num16 = damage - num16;
			num10 = Mathf.Clamp(num10, 0, 990);
			int num17 = IntMath.Double2Int((double)num10 / (double)GlobalLogic.VALUE_1000 * (double)num16);
			num6 -= num17;
			num16 -= num17;
			num12 = Mathf.Clamp(num12, 0, 990);
			int num18 = IntMath.Double2Int((double)num12 / (double)GlobalLogic.VALUE_1000 * (double)num16);
			num6 -= num18;
			num16 -= num18;
			num14 = Mathf.Clamp(num14, 0, 990);
			int num19 = IntMath.Double2Int((double)num14 / (double)GlobalLogic.VALUE_1000 * (double)num16);
			num6 -= num19;
			num6 = Mathf.Max(num6, 0);
			if (num7 > 0)
			{
			}
		}
		damage2 = num6;
		this.ResetAddDamageArr(0);
		this.ResetAddDamageArr(1);
		List<AddDamageInfo> list3 = this.m_AddDamageList[0];
		List<AddDamageInfo> list4 = this.m_AddDamageList[1];
		list3.AddRange(this.battleData.attachAddDamageFix);
		list4.AddRange(this.battleData.attachAddDamagePercent);
		this.owner.TriggerEvent(BeEventType.onChangeSummonMonsterAttach, new object[]
		{
			list3,
			list4
		});
		for (int num20 = 0; num20 < list3.Count; num20++)
		{
			AddDamageInfo damageInfo6 = list3[num20];
			if (this.CanApplyDamageModify(damageInfo6, damageType, damageDistanceType))
			{
				num6 += damageInfo6.value;
				attachValues.Add(list3[num20].value);
			}
		}
		for (int num21 = 0; num21 < list4.Count; num21++)
		{
			AddDamageInfo damageInfo7 = list4[num21];
			if (this.CanApplyDamageModify(damageInfo7, damageType, damageDistanceType))
			{
				int num22 = IntMath.Double2Int((double)damage * ((double)damageInfo7.value / (double)GlobalLogic.VALUE_1000));
				attachValues.Add(num22);
				num6 += num22;
			}
		}
		if (attachValues.Count > 0)
		{
			string arg = string.Empty;
			for (int num23 = 0; num23 < attachValues.Count; num23++)
			{
				arg = arg + attachValues[num23] + ",";
			}
		}
		return num6 * (this.GetResistMagicRate() + 1L);
	}

	// Token: 0x06016FC2 RID: 94146 RVA: 0x0070E288 File Offset: 0x0070C688
	public int GetReflectDamages(int damage)
	{
		int num = 0;
		for (int i = 0; i < this.battleData.reflectDamageFix.Count; i++)
		{
			num += this.battleData.reflectDamageFix[i].value;
		}
		for (int j = 0; j < this.battleData.reflectDamagePercent.Count; j++)
		{
			num += IntMath.Double2Int((double)(this.battleData.reflectDamagePercent[j].value * damage) / (double)GlobalLogic.VALUE_1000);
		}
		return num;
	}

	// Token: 0x06016FC3 RID: 94147 RVA: 0x0070E32C File Offset: 0x0070C72C
	public int GetAttachDamage(int damage)
	{
		return Math.Max(0, IntMath.Double2Int((double)(damage * this.battleData.attachHurtRate) / (double)GlobalLogic.VALUE_1000) + this.battleData.attachHurtFix);
	}

	// Token: 0x06016FC4 RID: 94148 RVA: 0x0070E364 File Offset: 0x0070C764
	public int GetSkillDamage(EffectTable.eDamageType attackType, BeEntityData targetData, VPercent skillPercent, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double d = 0.0;
		if (attackType == EffectTable.eDamageType.PHYSIC)
		{
			d = this.CalculateDamage(targetData, attackElementType);
		}
		else if (attackType == EffectTable.eDamageType.MAGIC)
		{
			d = this.CalculateMagicDamage(targetData, attackElementType);
		}
		int num = IntMath.Double2Int(d);
		num *= skillPercent.precent;
		return Math.Max(0, num);
	}

	// Token: 0x06016FC5 RID: 94149 RVA: 0x0070E3C0 File Offset: 0x0070C7C0
	public int GetSkillFixDamage(EffectTable.eDamageType type, BeEntityData targetData, int fixDamage, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double d = 0.0;
		if (type == EffectTable.eDamageType.PHYSIC)
		{
			d = this.CalculateFixDamage(targetData, fixDamage, attackElementType);
		}
		else if (type == EffectTable.eDamageType.MAGIC)
		{
			d = this.CalculateFixMagicDamage(targetData, fixDamage, attackElementType);
		}
		return Math.Max(0, IntMath.Double2Int(d));
	}

	// Token: 0x06016FC6 RID: 94150 RVA: 0x0070E40C File Offset: 0x0070C80C
	private double GetElementFactor(BeEntityData targetData, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double result = (double)GlobalLogic.VALUE_1;
		if (attackElementType != MagicElementType.NONE)
		{
			int num = targetData.GetMagicElementDefence(attackElementType);
			int[] array = new int[]
			{
				num
			};
			if (this.owner != null)
			{
				this.owner.TriggerEvent(BeEventType.OnChangeAttributeDefence, new object[]
				{
					array
				});
				num = array[0];
			}
			result = (double)GlobalLogic.VALUE_1 + (double)(this.GetMagicElementAttack(attackElementType) - num) / 220.0;
		}
		return result;
	}

	// Token: 0x06016FC7 RID: 94151 RVA: 0x0070E47C File Offset: 0x0070C87C
	private double CalculateDamage(BeEntityData targetData, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double num = (double)GlobalLogic.VALUE_1 - targetData.GetAttackReduce(this.level, this.battleData);
		double val = this.battleData.fAttack * num * this.GetElementFactor(targetData, attackElementType) + (double)this.battleData.ignoreDefAttackAdd * ((double)GlobalLogic.VALUE_1 - (double)targetData.battleData.attackReduceRate / (double)GlobalLogic.VALUE_10000) - (double)targetData.battleData.attackReduceFix;
		return Math.Max(0.0, val);
	}

	// Token: 0x06016FC8 RID: 94152 RVA: 0x0070E514 File Offset: 0x0070C914
	private double CalculateMagicDamage(BeEntityData targetData, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double num = (double)GlobalLogic.VALUE_1 - targetData.GetMagicAttackReduce(this.level, this.battleData);
		double val = this.battleData.fMagicAttack * num * this.GetElementFactor(targetData, attackElementType) + (double)this.battleData.ignoreDefMagicAttackAdd * ((double)GlobalLogic.VALUE_1 - (double)targetData.battleData.magicAttackAddRate / (double)GlobalLogic.VALUE_10000) - (double)targetData.battleData.magicAttackReduceFix;
		return Math.Max(0.0, val);
	}

	// Token: 0x06016FC9 RID: 94153 RVA: 0x0070E5AC File Offset: 0x0070C9AC
	private double CalculateFixDamage(BeEntityData targetData, int fixDamage, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double val = (double)fixDamage * ((double)GlobalLogic.VALUE_1 + this.battleData._baseAtk / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + this.battleData._baseIndependence / (double)GlobalLogic.VALUE_1500) * ((double)GlobalLogic.VALUE_1 - targetData.GetAttackReduce(this.level, this.battleData)) * this.GetElementFactor(targetData, attackElementType);
		return Math.Max(0.0, val);
	}

	// Token: 0x06016FCA RID: 94154 RVA: 0x0070E62C File Offset: 0x0070CA2C
	private double CalculateFixMagicDamage(BeEntityData targetData, int fixDamage, MagicElementType attackElementType = MagicElementType.NONE)
	{
		double val = (double)fixDamage * ((double)GlobalLogic.VALUE_1 + this.battleData._baseInt / (double)GlobalLogic.VALUE_250) * ((double)GlobalLogic.VALUE_1 + this.battleData._baseIndependence / (double)GlobalLogic.VALUE_1500) * ((double)GlobalLogic.VALUE_1 - targetData.GetMagicAttackReduce(this.level, this.battleData)) * this.GetElementFactor(targetData, attackElementType);
		return Math.Max(0.0, val);
	}

	// Token: 0x06016FCB RID: 94155 RVA: 0x0070E6AC File Offset: 0x0070CAAC
	public double GetAttackReduce(int attackerLevel, BattleData attackerAttr)
	{
		if (BattleMain.IsModePvP(this.owner.battleType))
		{
			attackerLevel = this.level;
		}
		double num = (double)attackerAttr.ingoreDefRate / (double)GlobalLogic.VALUE_1000;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		double num2 = (double)GlobalLogic.VALUE_1 - num;
		double num3 = (double)GlobalLogic.VALUE_1 - ((double)GlobalLogic.VALUE_1 - (double)this.battleData.fDefence * num2 / ((double)(attackerLevel * GlobalLogic.VALUE_200) + (double)this.battleData.fDefence * num2)) * ((double)GlobalLogic.VALUE_1 - (double)this.battleData.attackReduceRate / (double)GlobalLogic.VALUE_10000);
		if (num3 < 0.0)
		{
			num3 = 0.0;
		}
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		return num3;
	}

	// Token: 0x06016FCC RID: 94156 RVA: 0x0070E7B4 File Offset: 0x0070CBB4
	public double GetMagicAttackReduce(int attackerlevel, BattleData attackerAttr)
	{
		if (BattleMain.IsModePvP(this.owner.battleType))
		{
			attackerlevel = this.level;
		}
		double num = (double)attackerAttr.ingoreMagicDefRate / (double)GlobalLogic.VALUE_1000;
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		double num2 = (double)GlobalLogic.VALUE_1 - num;
		double num3 = (double)GlobalLogic.VALUE_1 - ((double)GlobalLogic.VALUE_1 - (double)this.battleData.fMagicDefence * num2 / ((double)(attackerlevel * GlobalLogic.VALUE_200) + (double)this.battleData.fMagicDefence * num2)) * ((double)GlobalLogic.VALUE_1 - (double)this.battleData.magicAttackAddRate / (double)GlobalLogic.VALUE_10000);
		if (num3 < 0.0)
		{
			num3 = 0.0;
		}
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		return num3;
	}

	// Token: 0x06016FCD RID: 94157 RVA: 0x0070E8BB File Offset: 0x0070CCBB
	public int GetAbnormalValue(BuffType type)
	{
		return this.battleData.abnormalResists[type - BuffType.FLASH] + this.battleData.abnormalResist;
	}

	// Token: 0x06016FCE RID: 94158 RVA: 0x0070E8EB File Offset: 0x0070CCEB
	public void SetResistMagic(int resistMagic)
	{
		if (this.isMonster && this.camp != 0)
		{
			return;
		}
		this.battleData.resistMagic = resistMagic;
	}

	// Token: 0x06016FCF RID: 94159 RVA: 0x0070E915 File Offset: 0x0070CD15
	public int GetResistMagic()
	{
		return this.battleData.resistMagic;
	}

	// Token: 0x06016FD0 RID: 94160 RVA: 0x0070E928 File Offset: 0x0070CD28
	public VFactor GetResistMagicRate()
	{
		if (this.isMonster && this.camp != 0)
		{
			return VFactor.zero;
		}
		int dungeonMagicValue = BeUtility.GetDungeonMagicValue(this.owner);
		if (dungeonMagicValue == 0)
		{
			return VFactor.zero;
		}
		VFactor vfactor = new VFactor((long)this.battleData.resistMagic, (long)dungeonMagicValue) - VFactor.one;
		VFactor vfactor2 = new VFactor(-700L, (long)GlobalLogic.VALUE_1000);
		VFactor vfactor3 = new VFactor(200L, (long)GlobalLogic.VALUE_1000);
		if (vfactor <= vfactor2)
		{
			return vfactor2;
		}
		if (vfactor >= vfactor3)
		{
			return vfactor3;
		}
		return vfactor;
	}

	// Token: 0x06016FD1 RID: 94161 RVA: 0x0070E9D0 File Offset: 0x0070CDD0
	public void SetAIRobotData(ItemProperty item)
	{
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(item.itemID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		this.SetAIRobotIgnoreDefAttackAdd(item, tableItem);
		this.SetAIRobotAttackReduceFix(item, tableItem);
		this.SetAIRobotMagicAttackReduceFix(item, tableItem);
	}

	// Token: 0x06016FD2 RID: 94162 RVA: 0x0070EA1C File Offset: 0x0070CE1C
	private void SetAIRobotIgnoreDefAttackAdd(ItemProperty item, ItemTable itemTable)
	{
		if (!BeUtility.IsWeapon(itemTable.SubType))
		{
			return;
		}
		int equipStrModByStrength = BeUtility.GetEquipStrModByStrength(item.strengthen, EquipStrMod.WpStrenthMod);
		int equipStrModByColor = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.WpColorQaMod);
		int equipStrModByColor2 = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.WpColorQbMod);
		VFactor a = VFactor.NewVFactor(itemTable.NeedLevel * GlobalLogic.VALUE_100 + equipStrModByColor, GlobalLogic.VALUE_100);
		VFactor a2 = a * VFactor.NewVFactor(125, GlobalLogic.VALUE_1000);
		VFactor a3 = a2 * VFactor.NewVFactor(equipStrModByStrength, GlobalLogic.VALUE_100);
		VFactor a4 = a3 * VFactor.NewVFactor(equipStrModByColor2, GlobalLogic.VALUE_100);
		int integer = (a4 * VFactor.NewVFactor(1100, GlobalLogic.VALUE_1000)).integer;
		BattleData battleData = this.battleData;
		battleData.ignoreDefAttackAdd += integer;
		BattleData battleData2 = this.battleData;
		battleData2.ignoreDefMagicAttackAdd += integer;
	}

	// Token: 0x06016FD3 RID: 94163 RVA: 0x0070EB14 File Offset: 0x0070CF14
	private void SetAIRobotAttackReduceFix(ItemProperty item, ItemTable itemTable)
	{
		if (!BeUtility.IsArmy(itemTable.SubType))
		{
			return;
		}
		int equipStrModByStrength = BeUtility.GetEquipStrModByStrength(item.strengthen, EquipStrMod.ArmStrenthMod);
		int equipStrModByColor = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.ArmColorQaMod);
		int equipStrModByColor2 = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.ArmColorQbMod);
		VFactor a = VFactor.NewVFactor(itemTable.NeedLevel * GlobalLogic.VALUE_100 + equipStrModByColor, GlobalLogic.VALUE_100);
		VFactor a2 = a * VFactor.NewVFactor(125, GlobalLogic.VALUE_1000);
		VFactor a3 = a2 * VFactor.NewVFactor(equipStrModByStrength, GlobalLogic.VALUE_100);
		int integer = (a3 * VFactor.NewVFactor(equipStrModByColor2, GlobalLogic.VALUE_100)).integer;
		BattleData battleData = this.battleData;
		battleData.attackReduceFix += integer;
	}

	// Token: 0x06016FD4 RID: 94164 RVA: 0x0070EBD8 File Offset: 0x0070CFD8
	private void SetAIRobotMagicAttackReduceFix(ItemProperty item, ItemTable itemTable)
	{
		if (!BeUtility.IsJewelry(itemTable.SubType))
		{
			return;
		}
		int equipStrModByStrength = BeUtility.GetEquipStrModByStrength(item.strengthen, EquipStrMod.JewStrenthMod);
		int equipStrModByColor = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.JewColorQaMod);
		int equipStrModByColor2 = BeUtility.GetEquipStrModByColor((int)itemTable.Color, EquipStrMod.JewColorQbMod);
		VFactor a = VFactor.NewVFactor(itemTable.NeedLevel * GlobalLogic.VALUE_100 + equipStrModByColor, GlobalLogic.VALUE_100);
		VFactor a2 = a * VFactor.NewVFactor(125, GlobalLogic.VALUE_1000);
		VFactor a3 = a2 * VFactor.NewVFactor(equipStrModByStrength, GlobalLogic.VALUE_100);
		int integer = (a3 * VFactor.NewVFactor(equipStrModByColor2, GlobalLogic.VALUE_100)).integer;
		BattleData battleData = this.battleData;
		battleData.magicAttackReduceFix += integer;
	}

	// Token: 0x06016FD5 RID: 94165 RVA: 0x0070EC9C File Offset: 0x0070D09C
	public bool CanAddAbnormalState(VRate abnormalRate, int abnormalLevel, BuffType buffType)
	{
		double num = (double)this.GetAbnormalValue(buffType) / 1.2 / (double)GlobalLogic.VALUE_100;
		double num2 = (double)GlobalLogic.VALUE_1 - num;
		num2 = Math.Max(0.0, num2);
		int num3;
		if (abnormalLevel <= this.level)
		{
			num3 = IntMath.Double2Int((double)abnormalRate.i * ((double)GlobalLogic.VALUE_1 + (double)(abnormalLevel - this.level) * 0.05) * num2);
		}
		else
		{
			num3 = IntMath.Double2Int((double)abnormalRate.i * num2);
		}
		int num4 = (int)this.FrameRandom.Range1000();
		return num4 < num3;
	}

	// Token: 0x06016FD6 RID: 94166 RVA: 0x0070ED44 File Offset: 0x0070D144
	public int GetAbnormalDamage(int abnormalAttack, int attackCount = 0, BeActor attacker = null)
	{
		double num7;
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.NewAbnormalDamage))
		{
			double num = (double)this.battleData.fDefence;
			double num2 = (double)this.battleData.fMagicDefence;
			if (attacker != null && attacker.GetEntityData() != null)
			{
				double num3 = (double)attacker.GetEntityData().battleData.ingoreDefRate / (double)GlobalLogic.VALUE_1000;
				if (num3 < 0.0)
				{
					num3 = 0.0;
				}
				if (num3 > 1.0)
				{
					num3 = 1.0;
				}
				double num4 = (double)GlobalLogic.VALUE_1 - num3;
				num *= num4;
				double num5 = (double)attacker.GetEntityData().battleData.ingoreMagicDefRate / (double)GlobalLogic.VALUE_1000;
				double num6 = (double)GlobalLogic.VALUE_1 - num5;
				if (num6 < 0.0)
				{
					num6 = 0.0;
				}
				if (num6 > 1.0)
				{
					num6 = 1.0;
				}
				num2 *= num6;
			}
			num7 = (double)GlobalLogic.VALUE_1 - (num + num2) / (num + num2 + (double)(800 * this.level));
		}
		else
		{
			num7 = (double)GlobalLogic.VALUE_1 - (double)(this.battleData.fDefence + this.battleData.fMagicDefence) / (double)(this.battleData.fDefence + this.battleData.fMagicDefence + 800 * this.level);
		}
		double num8 = 0.0;
		if (attacker != null && attacker.GetEntityData() != null)
		{
			num8 = (attacker.GetEntityData().battleData._baseAtk + attacker.GetEntityData().battleData._baseInt) / (double)GlobalLogic.VALUE_500;
		}
		double d;
		if (attackCount == 0)
		{
			d = (double)abnormalAttack * ((double)GlobalLogic.VALUE_1 + num8) * num7;
		}
		else
		{
			d = (double)abnormalAttack * ((double)GlobalLogic.VALUE_1 + num8) * num7 / (double)attackCount;
		}
		int num9 = IntMath.Double2Int(d);
		if (attacker != null && attacker.attribute != null)
		{
			num9 *= attacker.attribute.GetResistMagicRate() + 1L;
		}
		return Mathf.Max(0, num9);
	}

	// Token: 0x06016FD7 RID: 94167 RVA: 0x0070EF88 File Offset: 0x0070D388
	public int GetSkillLevel(int skillID)
	{
		int result = GlobalLogic.VALUE_1;
		if (this.skillLevelInfo.ContainsKey(skillID))
		{
			result = this.skillLevelInfo[skillID];
		}
		return result;
	}

	// Token: 0x06016FD8 RID: 94168 RVA: 0x0070EFC0 File Offset: 0x0070D3C0
	public void OnHPChange(int value)
	{
		if (value < 0 && this.owner != null && this.owner.stateController != null && !this.owner.stateController.CanHurt())
		{
			return;
		}
		this.battleData.hp += value;
		this.battleData.hp = Mathf.Clamp(this.battleData.hp, 0, this.battleData.maxHp);
		if (this.owner != null)
		{
			this.owner.TriggerEvent(BeEventType.onHPChange, new object[]
			{
				value
			});
			this.owner.JudgeDead();
		}
	}

	// Token: 0x06016FD9 RID: 94169 RVA: 0x0070F078 File Offset: 0x0070D478
	public void OnMPChange(int value)
	{
		BattleData battleData = this.battleData;
		battleData.mp += value;
		this.battleData.mp = Mathf.Clamp(this.battleData.mp, 0, this.battleData.maxMp);
	}

	// Token: 0x06016FDA RID: 94170 RVA: 0x0070F0D8 File Offset: 0x0070D4D8
	public VRate GetCDReduce(SkillMaigcType type)
	{
		int num;
		if (type == SkillMaigcType.MAGIC)
		{
			num = this.battleData.cdReduceRateMagic;
		}
		else if (type == SkillMaigcType.PHYSIC)
		{
			num = this.battleData.cdReduceRate;
		}
		else
		{
			num = ((this.jobAttribute != 0) ? this.battleData.cdReduceRateMagic : this.battleData.cdReduceRate);
		}
		return -num;
	}

	// Token: 0x06016FDB RID: 94171 RVA: 0x0070F154 File Offset: 0x0070D554
	public VRate GetMPCostReduce(SkillMaigcType type)
	{
		int num;
		if (type == SkillMaigcType.MAGIC)
		{
			num = this.battleData.mpCostReduceRateMagic;
		}
		else if (type == SkillMaigcType.PHYSIC)
		{
			num = this.battleData.mpCostReduceRate;
		}
		else
		{
			num = ((this.jobAttribute != 0) ? this.battleData.mpCostReduceRateMagic : this.battleData.mpCostReduceRate);
		}
		return -num;
	}

	// Token: 0x06016FDC RID: 94172 RVA: 0x0070F1D0 File Offset: 0x0070D5D0
	public int GetLevel()
	{
		return this.level;
	}

	// Token: 0x06016FDD RID: 94173 RVA: 0x0070F1DD File Offset: 0x0070D5DD
	public int GetMP()
	{
		return this.battleData.mp;
	}

	// Token: 0x06016FDE RID: 94174 RVA: 0x0070F1EF File Offset: 0x0070D5EF
	public int GetHP()
	{
		return this.battleData.hp;
	}

	// Token: 0x06016FDF RID: 94175 RVA: 0x0070F1FC File Offset: 0x0070D5FC
	public int GetMaxHP()
	{
		return this.battleData.maxHp;
	}

	// Token: 0x06016FE0 RID: 94176 RVA: 0x0070F20E File Offset: 0x0070D60E
	public int GetMaxMP()
	{
		return this.battleData.maxMp;
	}

	// Token: 0x06016FE1 RID: 94177 RVA: 0x0070F220 File Offset: 0x0070D620
	public VFactor GetMPRate()
	{
		return new VFactor((long)this.battleData.mp, (long)this.battleData.maxMp);
	}

	// Token: 0x06016FE2 RID: 94178 RVA: 0x0070F249 File Offset: 0x0070D649
	public VFactor GetHPRate()
	{
		return new VFactor((long)this.battleData.hp, (long)this.battleData.maxHp);
	}

	// Token: 0x06016FE3 RID: 94179 RVA: 0x0070F270 File Offset: 0x0070D670
	public void ChangeHPReduce(int value)
	{
		BattleData battleData = this.battleData;
		battleData.hpReduce += value;
		this.battleData.hpReduce = Mathf.Max(this.battleData.hpReduce, 0);
	}

	// Token: 0x06016FE4 RID: 94180 RVA: 0x0070F2C0 File Offset: 0x0070D6C0
	public void ChangeMPReduce(int value)
	{
		BattleData battleData = this.battleData;
		battleData.mpReduce += value;
		this.battleData.mpReduce = Mathf.Max(this.battleData.mpReduce, 0);
	}

	// Token: 0x06016FE5 RID: 94181 RVA: 0x0070F310 File Offset: 0x0070D710
	public int GetAttackSpeed()
	{
		return this.battleData.attackSpeed;
	}

	// Token: 0x06016FE6 RID: 94182 RVA: 0x0070F322 File Offset: 0x0070D722
	public int GetMoveSpeed()
	{
		return this.battleData.moveSpeed;
	}

	// Token: 0x06016FE7 RID: 94183 RVA: 0x0070F334 File Offset: 0x0070D734
	public int GetSpellSpeed()
	{
		return this.battleData.spellSpeed;
	}

	// Token: 0x06016FE8 RID: 94184 RVA: 0x0070F346 File Offset: 0x0070D746
	public void UpdateLevel(int skillId, int level)
	{
		if (this.skillLevelInfo.ContainsKey(skillId))
		{
			this.skillLevelInfo[skillId] = level;
		}
	}

	// Token: 0x06016FE9 RID: 94185 RVA: 0x0070F36C File Offset: 0x0070D76C
	public void AdjustHPForPvP(int ourLevel, int targetLevel, int ourPro, int targetPro, int pkRaceType = 0)
	{
		double num = 1.0;
		int id = (!Global.Settings.pkUseMaxLevel) ? ourLevel : Math.Max(ourLevel, targetLevel);
		PkHPLevelAdjustTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkHPLevelAdjustTable>(id, string.Empty, string.Empty);
		if (tableItem != null)
		{
			if (pkRaceType == 8)
			{
				num = (double)tableItem.factor_chiji / (double)GlobalLogic.VALUE_1000;
			}
			else
			{
				num = (double)tableItem.factor / (double)GlobalLogic.VALUE_1000;
			}
		}
		double num2 = (double)Singleton<TableManager>.GetInstance().GetPKHPAdjustFactor(ourPro, pkRaceType);
		num *= num2;
		if (ourLevel < targetLevel)
		{
			num *= (double)Mathf.Pow((float)(Math.Min(targetLevel, GlobalLogic.VALUE_50) / Math.Min(ourLevel, GlobalLogic.VALUE_50)), Global.Settings.pkHPAdjustFactor);
		}
		this.hpScale = num;
		this.AdjustHPForPvP(num);
	}

	// Token: 0x06016FEA RID: 94186 RVA: 0x0070F43C File Offset: 0x0070D83C
	public void AdjustHPForScufflePVP(int ourLevel, int ourPro)
	{
		double num = 1.0;
		PkHPLevelAdjustTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkHPLevelAdjustTable>(ourLevel, string.Empty, string.Empty);
		if (tableItem != null)
		{
			num = (double)tableItem.factor / (double)GlobalLogic.VALUE_1000;
		}
		double num2 = (double)Singleton<TableManager>.GetInstance().GetPKHPAdjustFactor(ourPro, 0);
		num *= num2;
		this.hpScale = num;
		this.AdjustHPForPvP(num);
	}

	// Token: 0x06016FEB RID: 94187 RVA: 0x0070F4A0 File Offset: 0x0070D8A0
	public void AdjustHPForPvP(double hpScale)
	{
		this.battleData.hpScale = IntMath.Double2Int(hpScale * (double)GlobalLogic.VALUE_1000);
		double d = (double)this.battleData.maxHp * hpScale;
		this.SetMaxHP(IntMath.Double2Int(d));
		this.SetHP(this.GetMaxHP());
	}

	// Token: 0x06016FEC RID: 94188 RVA: 0x0070F4F6 File Offset: 0x0070D8F6
	public bool MonsterIDEqual(int mid)
	{
		return BeUtility.IsMonsterIDEqual(mid, this.monsterID);
	}

	// Token: 0x06016FED RID: 94189 RVA: 0x0070F504 File Offset: 0x0070D904
	public void SetHP(int value)
	{
		this.battleData.hp = value;
	}

	// Token: 0x06016FEE RID: 94190 RVA: 0x0070F512 File Offset: 0x0070D912
	public void SetMP(int value)
	{
		this.battleData.mp = value;
	}

	// Token: 0x06016FEF RID: 94191 RVA: 0x0070F525 File Offset: 0x0070D925
	public void SetMaxHP(int value)
	{
		this.battleData.maxHp = value;
	}

	// Token: 0x06016FF0 RID: 94192 RVA: 0x0070F538 File Offset: 0x0070D938
	public void ChangeMaxHp(int value)
	{
		this.battleData.ChangeMaxHP(value);
		this.ChangeMaxHpByResist();
	}

	// Token: 0x06016FF1 RID: 94193 RVA: 0x0070F54C File Offset: 0x0070D94C
	public void ChangeMaxHpByResist()
	{
		if (this.owner == null)
		{
			return;
		}
		if (this.battleData.hp == 0)
		{
			return;
		}
		VFactor resistMagicRate = this.GetResistMagicRate();
		double num = (double)this.battleData.hp / (double)((float)this.battleData.maxHp);
		if (this.battleData.hp == this.battleData.maxHp)
		{
			num = 1.0;
		}
		this.battleData.maxHp = this.battleData.fMaxHp * (resistMagicRate + 1L);
		this.battleData.hp = IntMath.Double2Int(num * (double)this.battleData.maxHp);
	}

	// Token: 0x06016FF2 RID: 94194 RVA: 0x0070F611 File Offset: 0x0070DA11
	private void ResetAddDamageArr(int index)
	{
		if (this.m_AddDamageList[index] == null)
		{
			this.m_AddDamageList[index] = new List<AddDamageInfo>();
		}
		else
		{
			this.m_AddDamageList[index].Clear();
		}
	}

	// Token: 0x06016FF3 RID: 94195 RVA: 0x0070F640 File Offset: 0x0070DA40
	public void SetAbnormalResists(int[] inData, bool add = false)
	{
		for (int i = 0; i < 13; i++)
		{
			if (inData[i] != 0)
			{
				if (add)
				{
					CrypticInt32[] abnormalResists = this.battleData.abnormalResists;
					int num = i;
					abnormalResists[num] += inData[i];
				}
				else
				{
					this.battleData.abnormalResists[i] = inData[i];
				}
			}
		}
	}

	// Token: 0x06016FF4 RID: 94196 RVA: 0x0070F6C0 File Offset: 0x0070DAC0
	public void SetMagicElementTypes(IList<int> arr, bool isAdd = true)
	{
		int count = arr.Count;
		if (count < 1)
		{
			return;
		}
		int[] magicELements = this.battleData.magicELements;
		int num = (!isAdd) ? -1 : 1;
		int num2 = 5;
		for (int i = 0; i < count; i++)
		{
			int num3 = arr[i];
			if (num3 > 0 && num3 < num2)
			{
				magicELements[num3] += num;
			}
		}
	}

	// Token: 0x06016FF5 RID: 94197 RVA: 0x0070F735 File Offset: 0x0070DB35
	public bool HasMagicElementType(int curType)
	{
		return curType > 0 && curType < 5 && this.battleData.magicELements[curType] > 0;
	}

	// Token: 0x06016FF6 RID: 94198 RVA: 0x0070F757 File Offset: 0x0070DB57
	public int GetMagicElementAttack(MagicElementType type)
	{
		if (type > MagicElementType.NONE && type < MagicElementType.MAX)
		{
			return this.battleData.magicElementsAttack[(int)type];
		}
		return 0;
	}

	// Token: 0x06016FF7 RID: 94199 RVA: 0x0070F784 File Offset: 0x0070DB84
	public int GetMagicElementDefence(MagicElementType type)
	{
		if (type > MagicElementType.NONE && type < MagicElementType.MAX)
		{
			return this.battleData.magicElementsDefence[(int)type];
		}
		return 0;
	}

	// Token: 0x06016FF8 RID: 94200 RVA: 0x0070F7B4 File Offset: 0x0070DBB4
	public MagicElementType GetOwnAttackElement()
	{
		MagicElementType result = MagicElementType.NONE;
		int num = -1;
		for (int i = 1; i < 5; i++)
		{
			int num2 = this.battleData.magicELements[i];
			int num3 = this.battleData.magicElementsAttack[i];
			if (num2 > 0 && num3 > num)
			{
				num = num3;
				result = (MagicElementType)i;
			}
		}
		return result;
	}

	// Token: 0x06016FF9 RID: 94201 RVA: 0x0070F818 File Offset: 0x0070DC18
	public void GetOwnerEquipElement(List<int> magicElementTypeList)
	{
		for (int i = 1; i < 5; i++)
		{
			int num = this.battleData.magicELements[i];
			if (num > 0)
			{
				magicElementTypeList.Add(i);
			}
		}
	}

	// Token: 0x06016FFA RID: 94202 RVA: 0x0070F854 File Offset: 0x0070DC54
	public int GetWeaponTagImp(int itemID)
	{
		int result = 0;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			EEquipWearSlotType subType = (EEquipWearSlotType)tableItem.SubType;
			if (subType == EEquipWearSlotType.EquipWeapon)
			{
				result = tableItem.Tag;
			}
		}
		return result;
	}

	// Token: 0x06016FFB RID: 94203 RVA: 0x0070F898 File Offset: 0x0070DC98
	public int GetWeaponTypeImp(int itemID)
	{
		int result = 0;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			EEquipWearSlotType subType = (EEquipWearSlotType)tableItem.SubType;
			if (subType == EEquipWearSlotType.EquipWeapon)
			{
				result = (int)tableItem.ThirdType;
			}
		}
		return result;
	}

	// Token: 0x06016FFC RID: 94204 RVA: 0x0070F8DC File Offset: 0x0070DCDC
	public int GetWeaponType()
	{
		int result = 0;
		if (this.currentWeapon == null)
		{
			return result;
		}
		CrypticInt32 itemID = this.currentWeapon.itemID;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			EEquipWearSlotType subType = (EEquipWearSlotType)tableItem.SubType;
			if (subType == EEquipWearSlotType.EquipWeapon)
			{
				result = (int)tableItem.ThirdType;
			}
		}
		return result;
	}

	// Token: 0x06016FFD RID: 94205 RVA: 0x0070F93C File Offset: 0x0070DD3C
	public int GetWeaponTag()
	{
		int result = 0;
		if (this.currentWeapon == null)
		{
			return result;
		}
		CrypticInt32 itemID = this.currentWeapon.itemID;
		return this.GetWeaponTagImp(itemID);
	}

	// Token: 0x06016FFE RID: 94206 RVA: 0x0070F974 File Offset: 0x0070DD74
	public int GetWeaponItemID()
	{
		int result = 0;
		if (this.currentWeapon == null)
		{
			return result;
		}
		return this.currentWeapon.itemID;
	}

	// Token: 0x06016FFF RID: 94207 RVA: 0x0070F9A0 File Offset: 0x0070DDA0
	public bool CanChangeWeapon()
	{
		return this.GetWeaponItemID() != 0 && this.backupWeapons.Count > 0;
	}

	// Token: 0x06017000 RID: 94208 RVA: 0x0070F9C0 File Offset: 0x0070DDC0
	public int GetBackupEquipItemID()
	{
		int result = 0;
		if (this.backupWeapons.Count > 0)
		{
			result = this.backupWeapons[0].itemID;
		}
		return result;
	}

	// Token: 0x06017001 RID: 94209 RVA: 0x0070F9F8 File Offset: 0x0070DDF8
	public void ChangeWeapon(int index)
	{
		if (this.currentWeapon == null)
		{
			return;
		}
		ItemProperty itemProperty = this.backupWeapons[index];
		this.backupWeapons.RemoveAt(index);
		this.backupWeapons.Add(this.currentWeapon);
		if (this.itemProperties != null)
		{
			this.itemProperties.Remove(this.currentWeapon);
		}
		this.RemoveEquipment(this.currentWeapon);
		this.currentWeapon = itemProperty;
		if (this.itemProperties != null)
		{
			this.itemProperties.Insert(0, this.currentWeapon);
		}
		this.AddEquipment(this.currentWeapon);
		this.ChangeMaxHpByResist();
	}

	// Token: 0x06017002 RID: 94210 RVA: 0x0070FA9C File Offset: 0x0070DE9C
	public List<int> GetBackupWeaponTags()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.backupWeapons.Count; i++)
		{
			int weaponTagImp = this.GetWeaponTagImp(this.backupWeapons[i].itemID);
			list.Add(weaponTagImp);
		}
		return list;
	}

	// Token: 0x06017003 RID: 94211 RVA: 0x0070FAF0 File Offset: 0x0070DEF0
	public List<int> GetBackupWeaponTypes()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.backupWeapons.Count; i++)
		{
			int weaponTypeImp = this.GetWeaponTypeImp(this.backupWeapons[i].itemID);
			list.Add(weaponTypeImp);
		}
		return list;
	}

	// Token: 0x06017004 RID: 94212 RVA: 0x0070FB44 File Offset: 0x0070DF44
	public void GetWeaponTagAndWeaponType(ref int tag, ref int weaponType)
	{
		weaponType = 0;
		tag = 0;
		if (this.currentWeapon == null)
		{
			return;
		}
		CrypticInt32 itemID = this.currentWeapon.itemID;
		this.GetWeaponTagAndWeaponTypImp(itemID, ref tag, ref weaponType);
	}

	// Token: 0x06017005 RID: 94213 RVA: 0x0070FB80 File Offset: 0x0070DF80
	public void GetWeaponTagAndWeaponTypImp(int itemID, ref int tag, ref int weaponType)
	{
		weaponType = 0;
		tag = 0;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			EEquipWearSlotType subType = (EEquipWearSlotType)tableItem.SubType;
			if (subType == EEquipWearSlotType.EquipWeapon)
			{
				tag = tableItem.Tag;
				weaponType = (int)tableItem.ThirdType;
			}
		}
	}

	// Token: 0x06017006 RID: 94214 RVA: 0x0070FBD0 File Offset: 0x0070DFD0
	public void GetBackupWeaponTypesAndTags(List<int> weaponTypes, List<int> tags)
	{
		weaponTypes.Clear();
		tags.Clear();
		for (int i = 0; i < this.backupWeapons.Count; i++)
		{
			int item = 0;
			int item2 = 0;
			this.GetWeaponTagAndWeaponTypImp(this.backupWeapons[i].itemID, ref item, ref item2);
			tags.Add(item);
			weaponTypes.Add(item2);
		}
	}

	// Token: 0x06017007 RID: 94215 RVA: 0x0070FC37 File Offset: 0x0070E037
	public void AddEquip(ItemProperty item)
	{
		this.itemProperties.Add(item);
	}

	// Token: 0x06017008 RID: 94216 RVA: 0x0070FC45 File Offset: 0x0070E045
	public void RemoveEquip(ItemProperty item)
	{
		if (item == null)
		{
			return;
		}
		this.itemProperties.Remove(item);
	}

	// Token: 0x06017009 RID: 94217 RVA: 0x0070FC5C File Offset: 0x0070E05C
	public ItemProperty GetWearEquipByGUID(ulong guid)
	{
		for (int i = 0; i < this.itemProperties.Count; i++)
		{
			if (this.itemProperties[i].guid == guid)
			{
				return this.itemProperties[i];
			}
		}
		return null;
	}

	// Token: 0x040107C1 RID: 67521
	public string name;

	// Token: 0x040107C2 RID: 67522
	public CrypticInt32 level;

	// Token: 0x040107C3 RID: 67523
	public int professtion;

	// Token: 0x040107C4 RID: 67524
	public int battleDataID;

	// Token: 0x040107C5 RID: 67525
	public int jobAttribute;

	// Token: 0x040107C7 RID: 67527
	public VInt backupWeight;

	// Token: 0x040107C9 RID: 67529
	public Dictionary<int, CrypticInt32> skillLevelInfo;

	// Token: 0x040107CA RID: 67530
	public bool skillMonsterCanBeAttack;

	// Token: 0x040107CB RID: 67531
	public bool autoFightNeedAttackFirst;

	// Token: 0x040107CD RID: 67533
	public double hpScale = (double)GlobalLogic.VALUE_1;

	// Token: 0x040107CE RID: 67534
	public int camp;

	// Token: 0x040107CF RID: 67535
	public BattleData battleData = new BattleData();

	// Token: 0x040107D0 RID: 67536
	public int enhancedRadius;

	// Token: 0x040107D1 RID: 67537
	public int crystalNum = int.MaxValue;

	// Token: 0x040107D9 RID: 67545
	public int jumpAttackCount;

	// Token: 0x040107DA RID: 67546
	public int deafaultWeaponTag;

	// Token: 0x040107DB RID: 67547
	public CrypticInt32 criticalDamageFactor = GlobalLogic.VALUE_1500;

	// Token: 0x040107DC RID: 67548
	public BeEntity _owner;

	// Token: 0x040107DD RID: 67549
	public List<ItemProperty> itemProperties;

	// Token: 0x040107DE RID: 67550
	public List<ItemProperty> backupWeapons = new List<ItemProperty>();

	// Token: 0x040107DF RID: 67551
	public ItemProperty currentWeapon;

	// Token: 0x040107E0 RID: 67552
	public bool isMonster;

	// Token: 0x040107E1 RID: 67553
	public bool isSummonMonster;

	// Token: 0x040107E2 RID: 67554
	public bool isPet;

	// Token: 0x040107E3 RID: 67555
	public bool isSpecialAPC;

	// Token: 0x040107E4 RID: 67556
	public bool isShowSkillSpeech;

	// Token: 0x040107E5 RID: 67557
	public CrypticInt32 walkAnimationSpeedPercent = GlobalLogic.VALUE_100;

	// Token: 0x040107E6 RID: 67558
	public int monsterID;

	// Token: 0x040107E7 RID: 67559
	public float overHeadHeight;

	// Token: 0x040107E8 RID: 67560
	public float buffOriginHeight;

	// Token: 0x040107E9 RID: 67561
	public UnitTable monsterData;

	// Token: 0x040107EA RID: 67562
	public int simpleMonsterID;

	// Token: 0x040107EB RID: 67563
	public MonsterIDData monsterIDData;

	// Token: 0x040107EC RID: 67564
	public bool adjustBalance;

	// Token: 0x040107ED RID: 67565
	public int height;

	// Token: 0x040107EE RID: 67566
	private int[] m_CriticalPercentNew = new int[1];

	// Token: 0x040107EF RID: 67567
	private List<AddDamageInfo>[] m_AddDamageList = new List<AddDamageInfo>[4];
}
