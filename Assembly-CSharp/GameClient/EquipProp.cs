using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016A9 RID: 5801
	public class EquipProp
	{
		// Token: 0x17001C8E RID: 7310
		// (get) Token: 0x0600E3BF RID: 58303 RVA: 0x003AB56D File Offset: 0x003A996D
		public string attachBuffDesc
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.AttachBuffDesc;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C8F RID: 7311
		// (get) Token: 0x0600E3C0 RID: 58304 RVA: 0x003AB58B File Offset: 0x003A998B
		public string attachMechanismDesc
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.AttachMechanismDesc;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C90 RID: 7312
		// (set) Token: 0x0600E3C1 RID: 58305 RVA: 0x003AB5A9 File Offset: 0x003A99A9
		public EquipAttrTable TableData
		{
			set
			{
				this.mTableData = value;
			}
		}

		// Token: 0x0600E3C2 RID: 58306 RVA: 0x003AB5B4 File Offset: 0x003A99B4
		public static EquipProp CreateFromTable(int propID)
		{
			EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(propID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				EquipProp equipProp = new EquipProp();
				equipProp.TableData = tableItem;
				equipProp.props[0] = new CrypticInt32(tableItem.Atk);
				equipProp.props[1] = new CrypticInt32(tableItem.MagicAtk);
				equipProp.props[2] = new CrypticInt32(tableItem.Def);
				equipProp.props[3] = new CrypticInt32(tableItem.MagicDef);
				equipProp.props[4] = new CrypticInt32(tableItem.Strenth);
				equipProp.props[5] = new CrypticInt32(tableItem.Intellect);
				equipProp.props[6] = new CrypticInt32(tableItem.Spirit);
				equipProp.props[7] = new CrypticInt32(tableItem.Stamina);
				equipProp.props[8] = new CrypticInt32(tableItem.PhySkillMp);
				equipProp.props[9] = new CrypticInt32(tableItem.PhySkillCd);
				equipProp.props[10] = new CrypticInt32(tableItem.MagSkillMp);
				equipProp.props[11] = new CrypticInt32(tableItem.MagSkillCd);
				equipProp.props[12] = new CrypticInt32(tableItem.HPMax);
				equipProp.props[13] = new CrypticInt32(tableItem.MPMax);
				equipProp.props[14] = new CrypticInt32(tableItem.HPRecover);
				equipProp.props[15] = new CrypticInt32(tableItem.MPRecover);
				equipProp.props[16] = new CrypticInt32(tableItem.AttackSpeedRate);
				equipProp.props[17] = new CrypticInt32(tableItem.FireSpeedRate);
				equipProp.props[18] = new CrypticInt32(tableItem.MoveSpeedRate);
				equipProp.props[30] = new CrypticInt32(tableItem.HitRate);
				equipProp.props[31] = new CrypticInt32(tableItem.AvoidRate);
				equipProp.props[32] = new CrypticInt32(tableItem.PhysicCrit);
				equipProp.props[33] = new CrypticInt32(tableItem.MagicCrit);
				equipProp.props[34] = new CrypticInt32(tableItem.Spasticity);
				equipProp.props[35] = new CrypticInt32(tableItem.Jump);
				equipProp.props[36] = new CrypticInt32(tableItem.TownMoveSpeedRate);
				equipProp.props[37] = new CrypticInt32(0);
				equipProp.props[38] = new CrypticInt32(0);
				equipProp.props[39] = new CrypticInt32(0);
				equipProp.props[40] = new CrypticInt32(0);
				equipProp.props[60] = new CrypticInt32(0);
				equipProp.props[41] = new CrypticInt32(0);
				equipProp.props[42] = new CrypticInt32(0);
				equipProp.props[43] = new CrypticInt32(0);
				equipProp.props[44] = new CrypticInt32(0);
				equipProp.props[58] = tableItem.ResistMagic;
				equipProp.props[59] = new CrypticInt32(tableItem.Independence);
				equipProp.attachBuffIDs = new List<int>(tableItem.AttachBuffInfoIDs);
				equipProp.attachMechanismIDs = new List<int>(tableItem.AttachMechanismIDs);
				equipProp.attachPVPBuffIDs = new List<int>(tableItem.PVPAttachBuffInfoIDs);
				equipProp.attachPVPMechanismIDs = new List<int>(tableItem.PVPAttachMechanismIDs);
				for (int i = 0; i < tableItem.Elements.Count; i++)
				{
					if (tableItem.Elements[i] > 0 && tableItem.Elements[i] < 5)
					{
						equipProp.magicElements[tableItem.Elements[i]] = 1;
					}
				}
				int[] array = new int[]
				{
					tableItem.LightAttack,
					tableItem.FireAttack,
					tableItem.IceAttack,
					tableItem.DarkAttack
				};
				int[] array2 = new int[]
				{
					tableItem.LightDefence,
					tableItem.FireDefence,
					tableItem.IceDefence,
					tableItem.DarkDefence
				};
				for (int j = 1; j < 5; j++)
				{
					equipProp.magicElementsAttack[j] = array[j - 1];
					equipProp.magicElementsDefence[j] = array2[j - 1];
				}
				equipProp.props[19] = tableItem.AbormalResist;
				int[] array3 = new int[]
				{
					tableItem.abnormalResist1,
					tableItem.abnormalResist2,
					tableItem.abnormalResist3,
					tableItem.abnormalResist4,
					tableItem.abnormalResist5,
					tableItem.abnormalResist6,
					tableItem.abnormalResist7,
					tableItem.abnormalResist8,
					tableItem.abnormalResist9,
					tableItem.abnormalResist10,
					tableItem.abnormalResist11,
					tableItem.abnormalResist12,
					tableItem.abnormalResist13
				};
				for (int k = 0; k < array3.Length; k++)
				{
					equipProp.abnormalResists[k] = array3[k];
				}
				return equipProp;
			}
			return null;
		}

		// Token: 0x0600E3C3 RID: 58307 RVA: 0x003ABBD4 File Offset: 0x003A9FD4
		public void ResetProperties()
		{
			for (int i = 0; i < this.props.Length; i++)
			{
				this.props[i] = new CrypticInt32(0);
			}
			for (int j = 0; j < this.magicElements.Length; j++)
			{
				this.magicElements[j] = 0;
			}
			for (int k = 0; k < this.magicElementsAttack.Length; k++)
			{
				this.magicElementsAttack[k] = 0;
			}
			for (int l = 0; l < this.magicElementsDefence.Length; l++)
			{
				this.magicElementsDefence[l] = 0;
			}
			for (int m = 0; m < this.abnormalResists.Length; m++)
			{
				this.abnormalResists[m] = 0;
			}
			this.attachBuffIDs.Clear();
			this.attachPVPBuffIDs.Clear();
			this.attachMechanismIDs.Clear();
			this.attachPVPMechanismIDs.Clear();
		}

		// Token: 0x0600E3C4 RID: 58308 RVA: 0x003ABCCA File Offset: 0x003AA0CA
		public string GetPropFormatStr(EEquipProp a_prop, int iProIndex = -1)
		{
			if (a_prop > EEquipProp.Invalid && a_prop < EEquipProp.Count)
			{
				return EquipProp.ms_propFormats[(int)a_prop].GetFinalStr(this, iProIndex);
			}
			return string.Empty;
		}

		// Token: 0x0600E3C5 RID: 58309 RVA: 0x003ABCF0 File Offset: 0x003AA0F0
		public List<string> GetPropsFormatStr()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < EquipProp.ms_propFormats.Length; i++)
			{
				string text = null;
				if (i == 20)
				{
					for (int j = 0; j < 13; j++)
					{
						string finalStr = EquipProp.ms_propFormats[i].GetFinalStr(this, j);
						if (!string.IsNullOrEmpty(finalStr) && !list.Contains(finalStr))
						{
							list.Add(finalStr);
						}
					}
				}
				else if (i == 21)
				{
					for (int k = 0; k < 4; k++)
					{
						string finalStr2 = EquipProp.ms_propFormats[i].GetFinalStr(this, k);
						if (!string.IsNullOrEmpty(finalStr2) && !list.Contains(finalStr2))
						{
							list.Add(finalStr2);
						}
					}
				}
				else
				{
					text = EquipProp.ms_propFormats[i].GetFinalStr(this, -1);
				}
				if (!string.IsNullOrEmpty(text) && !list.Contains(text))
				{
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x0600E3C6 RID: 58310 RVA: 0x003ABDF4 File Offset: 0x003AA1F4
		public List<EquipProp.BuffSkillInfo> GetBuffSkillInfos()
		{
			List<EquipProp.BuffSkillInfo> list = new List<EquipProp.BuffSkillInfo>();
			for (int i = 0; i < this.attachBuffIDs.Count; i++)
			{
				int item = this.attachBuffIDs[i];
				if (this.attachPVPBuffIDs.Contains(item))
				{
					BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.attachBuffIDs[i], string.Empty, string.Empty);
					if (tableItem != null && tableItem.DescType == BuffInfoTable.eDescType.SkillLevel)
					{
						int baseJobID = this._GetBaseJobID(tableItem);
						EquipProp.BuffSkillInfo buffSkillInfo = list.Find((EquipProp.BuffSkillInfo data) => data.jobID == baseJobID);
						if (buffSkillInfo == null)
						{
							buffSkillInfo = new EquipProp.BuffSkillInfo();
							buffSkillInfo.jobID = baseJobID;
							JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(baseJobID, string.Empty, string.Empty);
							buffSkillInfo.jobName = ((tableItem2 != null) ? tableItem2.Name : string.Empty);
							buffSkillInfo.skillDescs = new List<string>(tableItem.Description);
							list.Add(buffSkillInfo);
						}
						else
						{
							buffSkillInfo.skillDescs.AddRange(tableItem.Description);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600E3C7 RID: 58311 RVA: 0x003ABF30 File Offset: 0x003AA330
		public List<string> GetBuffCommonDescs()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < this.attachBuffIDs.Count; i++)
			{
				int num = this.attachBuffIDs[i];
				if (this.attachPVPBuffIDs.Contains(num))
				{
					BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(num, string.Empty, string.Empty);
					if (tableItem != null && tableItem.DescType == BuffInfoTable.eDescType.Common)
					{
						list.AddRange(tableItem.Description);
					}
				}
			}
			return list;
		}

		// Token: 0x0600E3C8 RID: 58312 RVA: 0x003ABFB8 File Offset: 0x003AA3B8
		public List<string> GetMechanismDescs()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < this.attachMechanismIDs.Count; i++)
			{
				int num = this.attachMechanismIDs[i];
				if (this.attachPVPMechanismIDs.Contains(num))
				{
					MechanismTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MechanismTable>(num, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(tableItem.Description);
					}
				}
			}
			return list;
		}

		// Token: 0x0600E3C9 RID: 58313 RVA: 0x003AC034 File Offset: 0x003AA434
		public ItemProperty ToItemProp(int strengthen = 0, int grid = 0, EGrowthAttrType growthAttrType = EGrowthAttrType.GAT_NONE, int growthAttrNum = 0)
		{
			ItemProperty itemProperty = new ItemProperty();
			itemProperty.strengthen = strengthen;
			itemProperty.grid = grid;
			itemProperty.maxHp = this.props[12];
			itemProperty.maxMp = this.props[13];
			itemProperty.hpRecover = this.props[14];
			itemProperty.mpRecover = this.props[15];
			itemProperty.baseSta = this.props[7];
			itemProperty.baseAtk = this.props[4];
			itemProperty.baseInt = this.props[5];
			itemProperty.baseSpr = this.props[6];
			itemProperty.attack = this.props[0];
			itemProperty.magicAttack = this.props[1];
			itemProperty.defence = this.props[2];
			itemProperty.magicDefence = this.props[3];
			itemProperty.attackSpeed = this.props[16];
			itemProperty.spellSpeed = this.props[17];
			itemProperty.moveSpeed = this.props[18];
			itemProperty.ciriticalAttack = this.props[32];
			itemProperty.ciriticalMagicAttack = this.props[33];
			itemProperty.dex = this.props[30];
			itemProperty.dodge = this.props[31];
			itemProperty.hard = this.props[34];
			itemProperty.abnormalResist = this.props[19];
			itemProperty.jumpForce = this.props[35];
			itemProperty.mpCostReduceRate = this.props[8];
			itemProperty.mpCostReduceRateMagic = this.props[10];
			itemProperty.cdReduceRate = this.props[9];
			itemProperty.cdReduceRateMagic = this.props[11];
			itemProperty.attackAddRate = this.props[37];
			itemProperty.magicAttackAddRate = this.props[38];
			itemProperty.ignoreDefAttackAdd = this.props[39];
			itemProperty.ignoreDefMagicAttackAdd = this.props[40];
			itemProperty.ingoreIndependence = this.props[60];
			itemProperty.attackReduceRate = this.props[41];
			itemProperty.magicAttackReduceRate = this.props[42];
			itemProperty.attackReduceFix = this.props[43];
			itemProperty.magicAttackReduceFix = this.props[44];
			itemProperty.independence = this.props[59];
			itemProperty.attachBuffIDs = this.attachBuffIDs;
			itemProperty.attachMechanismIDs = this.attachMechanismIDs;
			itemProperty.attachPVPBuffIDs = this.attachPVPBuffIDs;
			itemProperty.attachPVPMechanismIDs = this.attachPVPMechanismIDs;
			itemProperty.magicElements = this.magicElements;
			for (int i = 0; i < this.magicElementsAttack.Length; i++)
			{
				itemProperty.magicElementsAttack[i] = this.magicElementsAttack[i];
			}
			for (int j = 0; j < this.magicElementsDefence.Length; j++)
			{
				itemProperty.magicElementsDefence[j] = this.magicElementsDefence[j];
			}
			for (int k = 0; k < this.abnormalResists.Length; k++)
			{
				itemProperty.abnormalResists[k] = this.abnormalResists[k];
			}
			itemProperty.resistMagic = this.props[58];
			switch (growthAttrType)
			{
			case EGrowthAttrType.GAT_STRENGTH:
			{
				ItemProperty itemProperty2 = itemProperty;
				itemProperty2.baseAtk += growthAttrNum * GlobalLogic.VALUE_1000;
				break;
			}
			case EGrowthAttrType.GAT_INTELLIGENCE:
			{
				ItemProperty itemProperty3 = itemProperty;
				itemProperty3.baseInt += growthAttrNum * GlobalLogic.VALUE_1000;
				break;
			}
			case EGrowthAttrType.GAT_STAMINA:
			{
				ItemProperty itemProperty4 = itemProperty;
				itemProperty4.baseSta += growthAttrNum * GlobalLogic.VALUE_1000;
				break;
			}
			case EGrowthAttrType.GAT_SPIRIT:
			{
				ItemProperty itemProperty5 = itemProperty;
				itemProperty5.baseSpr += growthAttrNum * GlobalLogic.VALUE_1000;
				break;
			}
			}
			return itemProperty;
		}

		// Token: 0x0600E3CA RID: 58314 RVA: 0x003AC55C File Offset: 0x003AA95C
		public static EquipProp operator +(EquipProp lhs, EquipProp rhs)
		{
			EquipProp equipProp = new EquipProp();
			for (int i = 0; i < 61; i++)
			{
				equipProp.props[i] = lhs.props[i] + rhs.props[i];
			}
			for (int j = 1; j < 5; j++)
			{
				equipProp.magicElements[j] = lhs.magicElements[j] + rhs.magicElements[j];
				equipProp.magicElementsAttack[j] = lhs.magicElementsAttack[j] + rhs.magicElementsAttack[j];
				equipProp.magicElementsDefence[j] = lhs.magicElementsDefence[j] + rhs.magicElementsDefence[j];
			}
			for (int k = 0; k < 13; k++)
			{
				equipProp.abnormalResists[k] = lhs.abnormalResists[k] + rhs.abnormalResists[k];
			}
			if (lhs.attachBuffIDs.Count > 0)
			{
				equipProp.attachBuffIDs.InsertRange(equipProp.attachBuffIDs.Count, lhs.attachBuffIDs);
			}
			if (rhs.attachBuffIDs.Count > 0)
			{
				equipProp.attachBuffIDs.InsertRange(equipProp.attachBuffIDs.Count, rhs.attachBuffIDs);
			}
			if (lhs.attachMechanismIDs.Count > 0)
			{
				equipProp.attachMechanismIDs.InsertRange(equipProp.attachMechanismIDs.Count, lhs.attachMechanismIDs);
			}
			if (rhs.attachMechanismIDs.Count > 0)
			{
				equipProp.attachMechanismIDs.InsertRange(equipProp.attachMechanismIDs.Count, rhs.attachMechanismIDs);
			}
			if (lhs.attachPVPBuffIDs.Count > 0)
			{
				equipProp.attachPVPBuffIDs.InsertRange(equipProp.attachPVPBuffIDs.Count, lhs.attachPVPBuffIDs);
			}
			if (rhs.attachPVPBuffIDs.Count > 0)
			{
				equipProp.attachPVPBuffIDs.InsertRange(equipProp.attachPVPBuffIDs.Count, rhs.attachPVPBuffIDs);
			}
			if (lhs.attachPVPMechanismIDs.Count > 0)
			{
				equipProp.attachPVPMechanismIDs.InsertRange(equipProp.attachPVPMechanismIDs.Count, lhs.attachPVPMechanismIDs);
			}
			if (rhs.attachPVPMechanismIDs.Count > 0)
			{
				equipProp.attachPVPMechanismIDs.InsertRange(equipProp.attachPVPMechanismIDs.Count, rhs.attachPVPMechanismIDs);
			}
			return equipProp;
		}

		// Token: 0x0600E3CB RID: 58315 RVA: 0x003AC7B8 File Offset: 0x003AABB8
		public static EquipProp operator -(EquipProp lhs, EquipProp rhs)
		{
			EquipProp equipProp = new EquipProp();
			for (int i = 0; i < 61; i++)
			{
				equipProp.props[i] = lhs.props[i] - rhs.props[i];
			}
			return equipProp;
		}

		// Token: 0x0600E3CC RID: 58316 RVA: 0x003AC824 File Offset: 0x003AAC24
		private int _GetBaseJobID(BuffInfoTable a_buffInfoTable)
		{
			int num = 0;
			for (int i = 0; i < a_buffInfoTable.SkillID.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(a_buffInfoTable.SkillID[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int j = 0; j < tableItem.JobID.Count; j++)
					{
						int num2 = tableItem.JobID[j];
						JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num2, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.prejob != 0)
						{
							num2 = tableItem2.prejob;
							tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num2, string.Empty, string.Empty);
						}
						if (num == 0)
						{
							num = num2;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x040088B0 RID: 34992
		private static EquipProp.PropFormats[] ms_propFormats = new EquipProp.PropFormats[]
		{
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_physic_atk", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.PhysicsAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_magic_atk", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MagicAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_physic_def", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.PhysicsDefense, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_magic_def", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MagicDefense, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_strenth", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Strenth, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_intellect", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Intellect, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_spirit", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Spirit, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_stamina", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Stamina, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_physic_skill_change", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.PhysicsSkillMPChange, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_physic_skill_change_cd", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.PhysicsSkillCDChange, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_magic_skill_change", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MagicSkillMPChange, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_magic_skill_change_cd", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MagicSkillCDChange, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_hp_max", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.HPMax, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_mp_max", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MPMax, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_hp_recover", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.HPRecover, EquipProp.ESign.Positive, true, false)
				}),
				new EquipProp.PropFormat("tip_attr_hp_cost", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.HPRecover, EquipProp.ESign.Negative, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_mp_recover", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MPRecover, EquipProp.ESign.Positive, true, false)
				}),
				new EquipProp.PropFormat("tip_attr_mp_cost", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MPRecover, EquipProp.ESign.Negative, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_atk_speed_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.AttackSpeedRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_fire_speed_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.FireSpeedRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_move_speed_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MoveSpeedRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abormalResist", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.AbormalResist, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abormalResists", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.AbormalResists, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_elements", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Elements, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_lightAttack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.LightAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_fireAttack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.FireAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_iceAttack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IceAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_darkAttack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.DarkAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_lightDefence", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.LightDefence, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_fireDefence", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.FireDefence, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_iceDefence", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IceDefence, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_darkDefence", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.DarkDefence, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_hit_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.HitRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_avoid_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.AvoidRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_physic_crit", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.PhysicCritRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_magic_crit", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.MagicCritRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_spasticity", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Spasticity, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_jump", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Jump, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_town_move_speed_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.TownMoveSpeedRate, EquipProp.ESign.Both, false, true)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_def_physic_attack_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnorePhysicsAttackRate, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_def_magic_attack_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnoreMagicAttackRate, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_def_physic_attack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnorePhysicsAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_def_magic_attack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnoreMagicAttack, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_atk_physics_def_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnorePhysicsDefenseRate, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_atk_magic_def_rate", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnoreMagicDefenseRate, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_atk_physics_def", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnorePhysicsDefense, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_atk_magic_def", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IgnoreMagicDefense, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_1", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist1, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_2", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist2, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_3", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist3, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_4", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist4, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_5", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist5, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_6", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist6, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_7", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist7, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_8", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist8, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_9", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist9, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_10", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist10, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_11", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist11, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_12", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist12, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_abnormalResist_13", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.abnormalResist13, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_resist_magic_value", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.resistMagic, EquipProp.ESign.Both, false, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_independence_attack", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.Independence, EquipProp.ESign.Both, true, false)
				})
			}),
			new EquipProp.PropFormats(new EquipProp.PropFormat[]
			{
				new EquipProp.PropFormat("tip_attr_ignore_def_independence", new EquipProp.PropValue[]
				{
					new EquipProp.PropValue(EEquipProp.IngoreIndependence, EquipProp.ESign.Both, true, false)
				})
			})
		};

		// Token: 0x040088B1 RID: 34993
		public CrypticInt32[] props = new CrypticInt32[61];

		// Token: 0x040088B2 RID: 34994
		public List<int> attachBuffIDs = new List<int>();

		// Token: 0x040088B3 RID: 34995
		public List<int> attachMechanismIDs = new List<int>();

		// Token: 0x040088B4 RID: 34996
		public List<int> attachPVPBuffIDs = new List<int>();

		// Token: 0x040088B5 RID: 34997
		public List<int> attachPVPMechanismIDs = new List<int>();

		// Token: 0x040088B6 RID: 34998
		private EquipAttrTable mTableData;

		// Token: 0x040088B7 RID: 34999
		public int[] magicElements = new int[5];

		// Token: 0x040088B8 RID: 35000
		public int[] magicElementsAttack = new int[5];

		// Token: 0x040088B9 RID: 35001
		public int[] magicElementsDefence = new int[5];

		// Token: 0x040088BA RID: 35002
		public int[] abnormalResists = new int[13];

		// Token: 0x040088BB RID: 35003
		private FieldInfo[] propFieldInfos;

		// Token: 0x040088BC RID: 35004
		private int[] propFiledIDs;

		// Token: 0x020016AA RID: 5802
		public class BuffSkillInfo
		{
			// Token: 0x040088BD RID: 35005
			public int jobID;

			// Token: 0x040088BE RID: 35006
			public string jobName;

			// Token: 0x040088BF RID: 35007
			public List<string> skillDescs;
		}

		// Token: 0x020016AB RID: 5803
		private enum ESign
		{
			// Token: 0x040088C1 RID: 35009
			Positive,
			// Token: 0x040088C2 RID: 35010
			Negative,
			// Token: 0x040088C3 RID: 35011
			Both
		}

		// Token: 0x020016AC RID: 5804
		private class PropValue
		{
			// Token: 0x0600E3CF RID: 58319 RVA: 0x003AD47A File Offset: 0x003AB87A
			public PropValue(EEquipProp a_prop, EquipProp.ESign a_sign, bool a_isInteger = true, bool isFloatConvert = false)
			{
				this.prop = a_prop;
				this.sign = a_sign;
				this.isInteger = a_isInteger;
				this.mIsFloatConvert = isFloatConvert;
			}

			// Token: 0x17001C91 RID: 7313
			// (get) Token: 0x0600E3D0 RID: 58320 RVA: 0x003AD49F File Offset: 0x003AB89F
			public bool isFloatConvert
			{
				get
				{
					return this.mIsFloatConvert && !this.isInteger;
				}
			}

			// Token: 0x040088C4 RID: 35012
			public EEquipProp prop;

			// Token: 0x040088C5 RID: 35013
			public EquipProp.ESign sign;

			// Token: 0x040088C6 RID: 35014
			public bool isInteger;

			// Token: 0x040088C7 RID: 35015
			private bool mIsFloatConvert;
		}

		// Token: 0x020016AD RID: 5805
		private class PropFormat
		{
			// Token: 0x0600E3D1 RID: 58321 RVA: 0x003AD4B8 File Offset: 0x003AB8B8
			public PropFormat(string a_format, params EquipProp.PropValue[] a_values)
			{
				this.format = a_format;
				this.values = a_values;
			}

			// Token: 0x040088C8 RID: 35016
			public string format;

			// Token: 0x040088C9 RID: 35017
			public EquipProp.PropValue[] values;
		}

		// Token: 0x020016AE RID: 5806
		private class PropFormats
		{
			// Token: 0x0600E3D2 RID: 58322 RVA: 0x003AD4CE File Offset: 0x003AB8CE
			public PropFormats(params EquipProp.PropFormat[] a_formats)
			{
				this.formats = a_formats;
			}

			// Token: 0x0600E3D3 RID: 58323 RVA: 0x003AD4E0 File Offset: 0x003AB8E0
			public string GetFinalStr(EquipProp a_equipProp, int iProIndex = -1)
			{
				if (this.formats == null)
				{
					return string.Empty;
				}
				for (int i = 0; i < this.formats.Length; i++)
				{
					if (this._CheckFormatSuitable(this.formats[i], a_equipProp, iProIndex))
					{
						EquipProp.PropValue[] values = this.formats[i].values;
						List<object> list = new List<object>();
						foreach (EquipProp.PropValue propValue in values)
						{
							float num = 1f * (float)a_equipProp.props[(int)propValue.prop] / (float)EquipPropRate.propRates[(int)propValue.prop];
							int enumValue = -1;
							if (propValue.prop == EEquipProp.Elements && iProIndex >= 0 && iProIndex < a_equipProp.abnormalResists.Length && a_equipProp.magicElements[iProIndex + 1] > 0)
							{
								num = (float)a_equipProp.magicElements[iProIndex + 1];
								enumValue = iProIndex + 1;
							}
							if (propValue.prop >= EEquipProp.LightAttack && propValue.prop <= EEquipProp.DarkAttack)
							{
								if (propValue.prop - EEquipProp.LightAttack + 1 < a_equipProp.magicElementsAttack.Length)
								{
									num = (float)a_equipProp.magicElementsAttack[propValue.prop - EEquipProp.LightAttack + 1];
								}
							}
							else if (propValue.prop >= EEquipProp.LightDefence && propValue.prop <= EEquipProp.DarkDefence)
							{
								if (propValue.prop - EEquipProp.LightDefence + 1 < a_equipProp.magicElementsDefence.Length)
								{
									num = (float)a_equipProp.magicElementsDefence[propValue.prop - EEquipProp.LightDefence + 1];
								}
							}
							else if (propValue.prop >= EEquipProp.abnormalResist1 && propValue.prop <= EEquipProp.abnormalResist13)
							{
								num = (float)a_equipProp.abnormalResists[propValue.prop - EEquipProp.abnormalResist1];
							}
							else if (propValue.prop == EEquipProp.AbormalResists && iProIndex >= 0 && iProIndex < a_equipProp.abnormalResists.Length)
							{
								num = (float)a_equipProp.abnormalResists[iProIndex];
							}
							int num2 = (int)num;
							if (propValue.sign == EquipProp.ESign.Both)
							{
								if (propValue.prop == EEquipProp.Elements)
								{
									list.Add(Utility.GetEnumDescription<MagicElementType>((MagicElementType)enumValue));
								}
								else if (propValue.prop >= EEquipProp.abnormalResist1 && propValue.prop <= EEquipProp.abnormalResist13)
								{
									list.Add(Utility.GetEnumDescription<BuffType>(BuffType.FLASH + (int)propValue.prop - 45));
								}
								else if (propValue.prop == EEquipProp.AbormalResists)
								{
									list.Add(Utility.GetEnumDescription<BuffType>(BuffType.FLASH + iProIndex));
								}
								if (propValue.prop != EEquipProp.Elements)
								{
									if (num > 0f)
									{
										list.Add("+");
									}
									else
									{
										list.Add(string.Empty);
									}
									if (propValue.isInteger)
									{
										list.Add(num2);
									}
									else if (propValue.isFloatConvert)
									{
										list.Add(this._getTheString(num));
									}
									else
									{
										list.Add(num.ToString("F1"));
									}
								}
							}
							else if (propValue.sign == EquipProp.ESign.Positive || propValue.sign == EquipProp.ESign.Negative)
							{
								if (propValue.isInteger)
								{
									list.Add(Mathf.Abs(num2).ToString());
								}
								else if (propValue.isFloatConvert)
								{
									list.Add(this._getTheString(Mathf.Abs(num)));
								}
								else
								{
									list.Add(Mathf.Abs(num).ToString("F1"));
								}
							}
						}
						return TR.Value(this.formats[i].format, list.ToArray());
					}
				}
				return string.Empty;
			}

			// Token: 0x0600E3D4 RID: 58324 RVA: 0x003AD898 File Offset: 0x003ABC98
			private string _getTheString(float v)
			{
				if (v >= 0f)
				{
					return TR.Value("tip_rate_2_level_format_up", Utility.ConvertItemDataRateValue2IntLevel(v), v);
				}
				return TR.Value("tip_rate_2_level_format_down", Utility.ConvertItemDataRateValue2IntLevel(v), v);
			}

			// Token: 0x0600E3D5 RID: 58325 RVA: 0x003AD8E8 File Offset: 0x003ABCE8
			private bool _CheckFormatSuitable(EquipProp.PropFormat a_propFormat, EquipProp a_equipProp, int iProIndex = -1)
			{
				EquipProp.PropValue[] values = a_propFormat.values;
				if (values != null)
				{
					int num = 0;
					foreach (EquipProp.PropValue propValue in values)
					{
						int num2 = a_equipProp.props[(int)propValue.prop];
						if (propValue.prop == EEquipProp.Elements)
						{
							if (iProIndex >= 0 && iProIndex < a_equipProp.magicElements.Length)
							{
								num2 = a_equipProp.magicElements[iProIndex + 1];
							}
						}
						else if (propValue.prop >= EEquipProp.LightAttack && propValue.prop <= EEquipProp.DarkAttack)
						{
							if (propValue.prop - EEquipProp.LightAttack + 1 < a_equipProp.magicElementsAttack.Length)
							{
								num2 = a_equipProp.magicElementsAttack[propValue.prop - EEquipProp.LightAttack + 1];
							}
						}
						else if (propValue.prop >= EEquipProp.LightDefence && propValue.prop <= EEquipProp.DarkDefence)
						{
							if (propValue.prop - EEquipProp.LightDefence + 1 < a_equipProp.magicElementsDefence.Length)
							{
								num2 = a_equipProp.magicElementsDefence[propValue.prop - EEquipProp.LightDefence + 1];
							}
						}
						else if (propValue.prop >= EEquipProp.abnormalResist1 && propValue.prop <= EEquipProp.abnormalResist13)
						{
							num2 = a_equipProp.abnormalResists[propValue.prop - EEquipProp.abnormalResist1];
						}
						else if (propValue.prop == EEquipProp.AbormalResists && iProIndex >= 0 && iProIndex < a_equipProp.abnormalResists.Length)
						{
							num2 = a_equipProp.abnormalResists[iProIndex];
						}
						if (num2 == 0 || (num2 > 0 && propValue.sign == EquipProp.ESign.Negative) || (num2 < 0 && propValue.sign == EquipProp.ESign.Positive))
						{
							num++;
						}
						else
						{
							num--;
						}
					}
					return num <= 0;
				}
				return false;
			}

			// Token: 0x040088CA RID: 35018
			public EquipProp.PropFormat[] formats;
		}
	}
}
