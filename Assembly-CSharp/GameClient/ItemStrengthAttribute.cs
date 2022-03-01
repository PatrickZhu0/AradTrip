using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001B66 RID: 7014
	internal class ItemStrengthAttribute
	{
		// Token: 0x060112E9 RID: 70377 RVA: 0x004F01E3 File Offset: 0x004EE5E3
		private ItemStrengthAttribute(ItemData itemData, EquipAttrTable equipAttr, EquipStrModTable equipStrMode, EquipStrModTable equipStrMode2, EquipStrModIndAtkTable equipStrModeIndependence, bool bPvp)
		{
			this.itemData = itemData;
			this.attrData = equipAttr;
			this.equipStrMode = equipStrMode;
			this.equipStrMode2 = equipStrMode2;
			this.equipStrModeIndependence = equipStrModeIndependence;
			this.bPvp = bPvp;
		}

		// Token: 0x060112EA RID: 70378 RVA: 0x004F0224 File Offset: 0x004EE624
		public static ItemStrengthAttribute Create(int iTableID, bool bPvp = false)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(iTableID, 100, 0);
			if (itemData == null)
			{
				return null;
			}
			EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(tableItem.EquipPropID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return null;
			}
			EquipStrModTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EquipStrModTable>((!bPvp) ? 1 : 2, string.Empty, string.Empty);
			if (tableItem3 == null)
			{
				return null;
			}
			EquipStrModTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<EquipStrModTable>((!bPvp) ? 3 : 4, string.Empty, string.Empty);
			if (tableItem4 == null)
			{
				return null;
			}
			EquipStrModIndAtkTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<EquipStrModIndAtkTable>((!bPvp) ? 1 : 2, string.Empty, string.Empty);
			if (tableItem5 == null)
			{
				return null;
			}
			return new ItemStrengthAttribute(itemData, tableItem2, tableItem3, tableItem4, tableItem5, bPvp);
		}

		// Token: 0x060112EB RID: 70379 RVA: 0x004F0314 File Offset: 0x004EE714
		public void SetStrength(int iStrength, bool bIsSpecialItem = false, int iMaxLevel = 0)
		{
			this.attributes.Clear();
			iStrength = (int)IntMath.Clamp((long)iStrength, 0L, (long)ItemStrengthAttribute.ms_max_level);
			if (bIsSpecialItem)
			{
				iMaxLevel = (int)IntMath.Clamp((long)iMaxLevel, 0L, (long)ItemStrengthAttribute.ms_max_level);
			}
			double num = this._GetWpStrMode(iStrength);
			double num2 = this._GetWpClQaMod();
			double num3 = this._GetWpClQbMod();
			double num4 = this._GetWpPhyMod();
			double num5 = this._GetWpMagMod();
			double num6 = this._GetWpStrModeIndependence(iStrength);
			double num7 = this._GetWpClQaModIndependence();
			double num8 = this._GetWpClQbModIndependence();
			double num9 = this._GetWpPhyModIndependence();
			double num10 = this._GetArmStrMod(iStrength, this.equipStrMode);
			double num11 = this._GetArmClQaMod(this.equipStrMode);
			double num12 = this._GetArmClQbMod();
			double num13 = this._GetJewStrMod(iStrength, this.equipStrMode);
			double num14 = this._GetJewClQaMod(this.equipStrMode);
			double num15 = this._GetJewClQbMod();
			double num16 = this._GetArmStrMod(iStrength, this.equipStrMode2);
			double num17 = this._GetArmClQaMod(this.equipStrMode2);
			double num18 = this._GetJewStrMod(iStrength, this.equipStrMode2);
			double num19 = this._GetJewClQaMod(this.equipStrMode2);
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			double num24 = 0.0;
			double num25 = 0.0;
			if (bIsSpecialItem)
			{
				num20 = this._GetWpStrMode(iMaxLevel);
				num21 = this._GetWpStrModeIndependence(iMaxLevel);
				num22 = this._GetArmStrMod(iMaxLevel, this.equipStrMode);
				num23 = this._GetJewStrMod(iMaxLevel, this.equipStrMode);
				num24 = this._GetArmStrMod(iMaxLevel, this.equipStrMode2);
				num25 = this._GetJewStrMod(iMaxLevel, this.equipStrMode2);
			}
			int num26 = 0;
			int num27 = 0;
			if (this._IsWeapon((ItemTable.eSubType)this.itemData.SubType) && this.attrData.Atk != 0)
			{
				if (!this.bPvp)
				{
					num26 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num * num3 * num4 * 1.1 + 0.5);
					if (num26 < 1)
					{
						num26 = 0;
					}
					if (bIsSpecialItem)
					{
						num27 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num20 * num3 * num4 * 1.1 + 0.5);
						if (num27 < 1)
						{
							num27 = 0;
						}
					}
				}
				else
				{
					num26 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num * num3 * num4 * 1.1 + 0.5);
					if (num26 < 1)
					{
						num26 = 0;
					}
					if (bIsSpecialItem)
					{
						num27 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num20 * num3 * num4 * 1.1 + 0.5);
						if (num27 < 1)
						{
							num27 = 0;
						}
					}
				}
				StrengthenAttributeItemData strengthenAttributeItemData = new StrengthenAttributeItemData();
				strengthenAttributeItemData.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[0]);
				strengthenAttributeItemData.iCurValue = (float)num26;
				strengthenAttributeItemData.valueFormat = "{0}";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData.iMaxValue = (float)num27;
					strengthenAttributeItemData.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData);
			}
			this.itemData.BaseProp.props[39] = num26;
			int num28 = 0;
			int num29 = 0;
			if (this._IsWeapon((ItemTable.eSubType)this.itemData.SubType) && this.attrData.MagicAtk != 0)
			{
				if (!this.bPvp)
				{
					num28 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num * num3 * num5 * 1.1 + 0.5);
					if (num28 < 1)
					{
						num28 = 0;
					}
					if (bIsSpecialItem)
					{
						num29 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num20 * num3 * num5 * 1.1 + 0.5);
						if (num29 < 1)
						{
							num29 = 0;
						}
					}
				}
				else
				{
					num28 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num * num3 * num5 * 1.1 + 0.5);
					if (num28 < 1)
					{
						num28 = 0;
					}
					if (bIsSpecialItem)
					{
						num29 = (int)(((double)this.itemData.LevelLimit + num2) * 0.125 * num20 * num3 * num5 * 1.1 + 0.5);
						if (num29 < 1)
						{
							num29 = 0;
						}
					}
				}
				StrengthenAttributeItemData strengthenAttributeItemData2 = new StrengthenAttributeItemData();
				strengthenAttributeItemData2.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[1]);
				strengthenAttributeItemData2.iCurValue = (float)num28;
				strengthenAttributeItemData2.valueFormat = "{0}";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData2.iMaxValue = (float)num29;
					strengthenAttributeItemData2.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData2);
			}
			this.itemData.BaseProp.props[40] = num28;
			int num30 = 0;
			int num31 = 0;
			if (this._IsWeapon((ItemTable.eSubType)this.itemData.SubType) && this.attrData.Independence != 0)
			{
				num30 = (int)(((double)this.itemData.LevelLimit + num7) * 0.125 * num6 * num8 * num9 * 1.1);
				if (num30 < 1)
				{
					num30 = 0;
				}
				if (bIsSpecialItem)
				{
					num31 = (int)(((double)this.itemData.LevelLimit + num7) * 0.125 * num21 * num8 * num9 * 1.1);
					if (num31 < 1)
					{
						num31 = 0;
					}
				}
				StrengthenAttributeItemData strengthenAttributeItemData3 = new StrengthenAttributeItemData();
				strengthenAttributeItemData3.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[6]);
				strengthenAttributeItemData3.iCurValue = (float)num30;
				strengthenAttributeItemData3.valueFormat = "{0}";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData3.iMaxValue = (float)num31;
					strengthenAttributeItemData3.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData3);
			}
			this.itemData.BaseProp.props[60] = num30;
			int num32 = 0;
			int num33 = 0;
			if (this._IsArmy((ItemTable.eSubType)this.itemData.SubType) && this.attrData.Def != 0)
			{
				if (!this.bPvp)
				{
					num32 = (int)(((double)this.itemData.LevelLimit + num11) * 0.125 * num10 * num12 + 0.5);
					if (num32 < 1)
					{
						num32 = 0;
					}
					if (bIsSpecialItem)
					{
						num33 = (int)(((double)this.itemData.LevelLimit + num11) * 0.125 * num22 * num12 + 0.5);
						if (num33 < 1)
						{
							num33 = 0;
						}
					}
				}
				else
				{
					num32 = (int)(((double)this.itemData.LevelLimit + num11) * 0.125 * num10 * num12 + 0.5);
					if (num32 < 1)
					{
						num32 = 0;
					}
					if (bIsSpecialItem)
					{
						num33 = (int)(((double)this.itemData.LevelLimit + num11) * 0.125 * num22 * num12 + 0.5);
						if (num33 < 1)
						{
							num33 = 0;
						}
					}
				}
				StrengthenAttributeItemData strengthenAttributeItemData4 = new StrengthenAttributeItemData();
				strengthenAttributeItemData4.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[2]);
				strengthenAttributeItemData4.iCurValue = (float)num32;
				strengthenAttributeItemData4.valueFormat = "{0}";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData4.iMaxValue = (float)num33;
					strengthenAttributeItemData4.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData4);
			}
			this.itemData.BaseProp.props[43] = num32;
			int num34 = 0;
			int num35 = 0;
			if (this._IsJewelry((ItemTable.eSubType)this.itemData.SubType) && this.attrData.MagicDef != 0)
			{
				if (!this.bPvp)
				{
					num34 = (int)(((double)this.itemData.LevelLimit + num14) * 0.125 * num13 * num15 + 0.5);
					if (num34 < 1)
					{
						num34 = 0;
					}
					if (bIsSpecialItem)
					{
						num35 = (int)(((double)this.itemData.LevelLimit + num14) * 0.125 * num23 * num15 + 0.5);
						if (num35 < 1)
						{
							num35 = 0;
						}
					}
				}
				else
				{
					num34 = (int)(((double)this.itemData.LevelLimit + num14) * 0.125 * num13 * num15 + 0.5);
					if (num34 < 1)
					{
						num34 = 0;
					}
					if (bIsSpecialItem)
					{
						num35 = (int)(((double)this.itemData.LevelLimit + num14) * 0.125 * num23 * num15 + 0.5);
						if (num35 < 1)
						{
							num35 = 0;
						}
					}
				}
				StrengthenAttributeItemData strengthenAttributeItemData5 = new StrengthenAttributeItemData();
				strengthenAttributeItemData5.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[3]);
				strengthenAttributeItemData5.iCurValue = (float)num34;
				strengthenAttributeItemData5.valueFormat = "{0}";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData5.iMaxValue = (float)num35;
					strengthenAttributeItemData5.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData5);
			}
			this.itemData.BaseProp.props[44] = num34;
			int num36 = 0;
			int num37 = 0;
			if (this._IsArmy((ItemTable.eSubType)this.itemData.SubType))
			{
				num36 = (int)(num16 * num17 * 10000.0 + 0.5);
				if (bIsSpecialItem)
				{
					num37 = (int)(num24 * num17 * 10000.0 + 0.5);
				}
				StrengthenAttributeItemData strengthenAttributeItemData6 = new StrengthenAttributeItemData();
				strengthenAttributeItemData6.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[4]);
				strengthenAttributeItemData6.iCurValue = (float)num36 * 0.01f;
				strengthenAttributeItemData6.valueFormat = "{0:F2}%";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData6.iMaxValue = (float)num37 * 0.01f;
					strengthenAttributeItemData6.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData6);
			}
			this.itemData.BaseProp.props[41] = num36;
			int num38 = 0;
			int num39 = 0;
			if (this._IsJewelry((ItemTable.eSubType)this.itemData.SubType))
			{
				num38 = (int)(num18 * num19 * 10000.0 + 0.5);
				if (bIsSpecialItem)
				{
					num39 = (int)(num25 * num19 * 10000.0 + 0.5);
				}
				StrengthenAttributeItemData strengthenAttributeItemData7 = new StrengthenAttributeItemData();
				strengthenAttributeItemData7.kDesc = TR.Value(ItemStrengthAttribute.ms_strengthen_desc_pre[5]);
				strengthenAttributeItemData7.iCurValue = (float)num38 * 0.01f;
				strengthenAttributeItemData7.valueFormat = "{0:F2}%";
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData7.iMaxValue = (float)num39 * 0.01f;
					strengthenAttributeItemData7.bIsSpecialItem = true;
				}
				this.attributes.Add(strengthenAttributeItemData7);
			}
			this.itemData.BaseProp.props[42] = num38;
			this.itemData.StrengthenLevel = iStrength;
		}

		// Token: 0x17001D9C RID: 7580
		// (get) Token: 0x060112EC RID: 70380 RVA: 0x004F0E5C File Offset: 0x004EF25C
		public List<StrengthenAttributeItemData> Attributes
		{
			get
			{
				return this.attributes;
			}
		}

		// Token: 0x060112ED RID: 70381 RVA: 0x004F0E64 File Offset: 0x004EF264
		public ItemData GetItemData()
		{
			return this.itemData;
		}

		// Token: 0x060112EE RID: 70382 RVA: 0x004F0E6C File Offset: 0x004EF26C
		private bool _IsJewelry(ItemTable.eSubType eSubType)
		{
			return eSubType == ItemTable.eSubType.RING || eSubType == ItemTable.eSubType.NECKLASE || eSubType == ItemTable.eSubType.BRACELET;
		}

		// Token: 0x060112EF RID: 70383 RVA: 0x004F0E8C File Offset: 0x004EF28C
		private bool _IsArmy(ItemTable.eSubType eSubType)
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

		// Token: 0x060112F0 RID: 70384 RVA: 0x004F0EB2 File Offset: 0x004EF2B2
		private bool _IsWeapon(ItemTable.eSubType eSubType)
		{
			return eSubType == ItemTable.eSubType.WEAPON;
		}

		// Token: 0x060112F1 RID: 70385 RVA: 0x004F0EB8 File Offset: 0x004EF2B8
		private double _GetWpStrMode(int iLevel)
		{
			if (iLevel < ItemStrengthAttribute.ms_min_level || iLevel > ItemStrengthAttribute.ms_max_level)
			{
				return 0.0;
			}
			if (iLevel - 1 < 0 || iLevel > this.equipStrMode.WpStrenthMod.Count)
			{
				return 0.0;
			}
			return (double)this.equipStrMode.WpStrenthMod[iLevel - 1] * 0.01;
		}

		// Token: 0x060112F2 RID: 70386 RVA: 0x004F0F2C File Offset: 0x004EF32C
		private double _GetWpClQaMod()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrMode.WpColorQaMod.Count)
			{
				return (double)this.equipStrMode.WpColorQaMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F3 RID: 70387 RVA: 0x004F0FC0 File Offset: 0x004EF3C0
		private double _GetWpClQbMod()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrMode.WpColorQbMod.Count)
			{
				return (double)this.equipStrMode.WpColorQbMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F4 RID: 70388 RVA: 0x004F1054 File Offset: 0x004EF454
		private double _GetWpPhyMod()
		{
			ItemStrengthAttribute.ms_arr_mod[0] = this.equipStrMode.HugeSword;
			ItemStrengthAttribute.ms_arr_mod[1] = this.equipStrMode.Katana;
			ItemStrengthAttribute.ms_arr_mod[2] = this.equipStrMode.ShortSword;
			ItemStrengthAttribute.ms_arr_mod[3] = this.equipStrMode.BeamSword;
			ItemStrengthAttribute.ms_arr_mod[4] = this.equipStrMode.Blunt;
			ItemStrengthAttribute.ms_arr_mod[5] = this.equipStrMode.Revolver;
			ItemStrengthAttribute.ms_arr_mod[6] = this.equipStrMode.CrossBow;
			ItemStrengthAttribute.ms_arr_mod[7] = this.equipStrMode.HandCannon;
			ItemStrengthAttribute.ms_arr_mod[8] = this.equipStrMode.AutoRifle;
			ItemStrengthAttribute.ms_arr_mod[9] = this.equipStrMode.AutoPistal;
			ItemStrengthAttribute.ms_arr_mod[10] = this.equipStrMode.MagicStick;
			ItemStrengthAttribute.ms_arr_mod[11] = this.equipStrMode.Twig;
			ItemStrengthAttribute.ms_arr_mod[12] = this.equipStrMode.Pike;
			ItemStrengthAttribute.ms_arr_mod[13] = this.equipStrMode.Stick;
			ItemStrengthAttribute.ms_arr_mod[14] = this.equipStrMode.Besom;
			ItemStrengthAttribute.ms_arr_mod[15] = this.equipStrMode.Glove;
			ItemStrengthAttribute.ms_arr_mod[16] = this.equipStrMode.Bikai;
			ItemStrengthAttribute.ms_arr_mod[17] = this.equipStrMode.Claw;
			ItemStrengthAttribute.ms_arr_mod[18] = this.equipStrMode.Ofg;
			ItemStrengthAttribute.ms_arr_mod[19] = this.equipStrMode.East_stick;
			ItemStrengthAttribute.ms_arr_mod[20] = this.equipStrMode.SICKLE;
			ItemStrengthAttribute.ms_arr_mod[21] = this.equipStrMode.TOTEM;
			ItemStrengthAttribute.ms_arr_mod[22] = this.equipStrMode.AXE;
			ItemStrengthAttribute.ms_arr_mod[23] = this.equipStrMode.BEADS;
			ItemStrengthAttribute.ms_arr_mod[24] = this.equipStrMode.CROSS;
			if (this.itemData.ThirdType > ItemTable.eThirdType.TT_NONE && this.itemData.ThirdType <= (ItemTable.eThirdType)ItemStrengthAttribute.ms_arr_mod.Length && ItemStrengthAttribute.ms_arr_mod[this.itemData.ThirdType - ItemTable.eThirdType.HUGESWORD].Count > 0)
			{
				return (double)ItemStrengthAttribute.ms_arr_mod[this.itemData.ThirdType - ItemTable.eThirdType.HUGESWORD][0] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F5 RID: 70389 RVA: 0x004F12A8 File Offset: 0x004EF6A8
		private double _GetWpMagMod()
		{
			ItemStrengthAttribute.ms_arr_mod[0] = this.equipStrMode.HugeSword;
			ItemStrengthAttribute.ms_arr_mod[1] = this.equipStrMode.Katana;
			ItemStrengthAttribute.ms_arr_mod[2] = this.equipStrMode.ShortSword;
			ItemStrengthAttribute.ms_arr_mod[3] = this.equipStrMode.BeamSword;
			ItemStrengthAttribute.ms_arr_mod[4] = this.equipStrMode.Blunt;
			ItemStrengthAttribute.ms_arr_mod[5] = this.equipStrMode.Revolver;
			ItemStrengthAttribute.ms_arr_mod[6] = this.equipStrMode.CrossBow;
			ItemStrengthAttribute.ms_arr_mod[7] = this.equipStrMode.HandCannon;
			ItemStrengthAttribute.ms_arr_mod[8] = this.equipStrMode.AutoRifle;
			ItemStrengthAttribute.ms_arr_mod[9] = this.equipStrMode.AutoPistal;
			ItemStrengthAttribute.ms_arr_mod[10] = this.equipStrMode.MagicStick;
			ItemStrengthAttribute.ms_arr_mod[11] = this.equipStrMode.Twig;
			ItemStrengthAttribute.ms_arr_mod[12] = this.equipStrMode.Pike;
			ItemStrengthAttribute.ms_arr_mod[13] = this.equipStrMode.Stick;
			ItemStrengthAttribute.ms_arr_mod[14] = this.equipStrMode.Besom;
			ItemStrengthAttribute.ms_arr_mod[15] = this.equipStrMode.Glove;
			ItemStrengthAttribute.ms_arr_mod[16] = this.equipStrMode.Bikai;
			ItemStrengthAttribute.ms_arr_mod[17] = this.equipStrMode.Claw;
			ItemStrengthAttribute.ms_arr_mod[18] = this.equipStrMode.Ofg;
			ItemStrengthAttribute.ms_arr_mod[19] = this.equipStrMode.East_stick;
			ItemStrengthAttribute.ms_arr_mod[20] = this.equipStrMode.SICKLE;
			ItemStrengthAttribute.ms_arr_mod[21] = this.equipStrMode.TOTEM;
			ItemStrengthAttribute.ms_arr_mod[22] = this.equipStrMode.AXE;
			ItemStrengthAttribute.ms_arr_mod[23] = this.equipStrMode.BEADS;
			ItemStrengthAttribute.ms_arr_mod[24] = this.equipStrMode.CROSS;
			if (this.itemData.ThirdType > ItemTable.eThirdType.TT_NONE && this.itemData.ThirdType <= (ItemTable.eThirdType)ItemStrengthAttribute.ms_arr_mod.Length && ItemStrengthAttribute.ms_arr_mod[this.itemData.ThirdType - ItemTable.eThirdType.HUGESWORD].Count > 1)
			{
				return (double)ItemStrengthAttribute.ms_arr_mod[this.itemData.ThirdType - ItemTable.eThirdType.HUGESWORD][1] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F6 RID: 70390 RVA: 0x004F14FC File Offset: 0x004EF8FC
		private double _GetArmStrMod(int iLevel, EquipStrModTable equipStrMode)
		{
			if (iLevel < ItemStrengthAttribute.ms_min_level || iLevel > ItemStrengthAttribute.ms_max_level)
			{
				return 0.0;
			}
			if (iLevel - 1 < 0 || iLevel > equipStrMode.ArmStrenthMod.Count)
			{
				return 0.0;
			}
			return (double)equipStrMode.ArmStrenthMod[iLevel - 1] * 0.01;
		}

		// Token: 0x060112F7 RID: 70391 RVA: 0x004F1568 File Offset: 0x004EF968
		private double _GetArmClQaMod(EquipStrModTable equipStrMode)
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)equipStrMode.ArmColorQaMod.Count)
			{
				return (double)equipStrMode.ArmColorQaMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F8 RID: 70392 RVA: 0x004F15F0 File Offset: 0x004EF9F0
		private double _GetArmClQbMod()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrMode.ArmColorQbMod.Count)
			{
				return (double)this.equipStrMode.ArmColorQbMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112F9 RID: 70393 RVA: 0x004F1684 File Offset: 0x004EFA84
		private double _GetJewStrMod(int iLevel, EquipStrModTable equipStrMode)
		{
			if (iLevel < ItemStrengthAttribute.ms_min_level || iLevel > ItemStrengthAttribute.ms_max_level)
			{
				return 0.0;
			}
			if (iLevel - 1 < 0 || iLevel > equipStrMode.JewStrenthMod.Count)
			{
				return 0.0;
			}
			return (double)equipStrMode.JewStrenthMod[iLevel - 1] * 0.01;
		}

		// Token: 0x060112FA RID: 70394 RVA: 0x004F16F0 File Offset: 0x004EFAF0
		private double _GetJewClQaMod(EquipStrModTable equipStrMode)
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)equipStrMode.JewColorQaMod.Count)
			{
				return (double)equipStrMode.JewColorQaMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112FB RID: 70395 RVA: 0x004F1778 File Offset: 0x004EFB78
		private double _GetJewClQbMod()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrMode.JewColorQbMod.Count)
			{
				return (double)this.equipStrMode.JewColorQbMod[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112FC RID: 70396 RVA: 0x004F180C File Offset: 0x004EFC0C
		private double _GetWpStrModeIndependence(int iLevel)
		{
			if (iLevel < ItemStrengthAttribute.ms_min_level || iLevel > ItemStrengthAttribute.ms_max_level)
			{
				return 0.0;
			}
			if (iLevel - 1 < 0 || iLevel > this.equipStrModeIndependence.WpStrenthMod_1.Count)
			{
				return 0.0;
			}
			return (double)this.equipStrModeIndependence.WpStrenthMod_1[iLevel - 1] * 0.01;
		}

		// Token: 0x060112FD RID: 70397 RVA: 0x004F1880 File Offset: 0x004EFC80
		private double _GetWpClQaModIndependence()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrModeIndependence.WpColorQaMod_1.Count)
			{
				return (double)this.equipStrModeIndependence.WpColorQaMod_1[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112FE RID: 70398 RVA: 0x004F1914 File Offset: 0x004EFD14
		private double _GetWpClQbModIndependence()
		{
			if (this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= ItemTable.eColor.YELLOW && this.itemData.Quality > ItemTable.eColor.CL_NONE && this.itemData.Quality <= (ItemTable.eColor)this.equipStrModeIndependence.WpColorQbMod_1.Count)
			{
				return (double)this.equipStrModeIndependence.WpColorQbMod_1[this.itemData.Quality - ItemTable.eColor.WHITE] * 0.01;
			}
			return 0.0;
		}

		// Token: 0x060112FF RID: 70399 RVA: 0x004F19A6 File Offset: 0x004EFDA6
		private double _GetWpPhyModIndependence()
		{
			return (double)this.equipStrModeIndependence.EquipMod[0] * 0.01;
		}

		// Token: 0x0400B164 RID: 45412
		private static int ms_min_level = 1;

		// Token: 0x0400B165 RID: 45413
		private static int ms_max_level = 20;

		// Token: 0x0400B166 RID: 45414
		private static IList<int>[] ms_arr_mod = new IList<int>[25];

		// Token: 0x0400B167 RID: 45415
		private static string[] ms_strengthen_desc_pre = new string[]
		{
			"tip_attr_ignore_def_physic_attack_pre",
			"tip_attr_ignore_def_magic_attack_pre",
			"tip_attr_ignore_atk_physics_def_pre",
			"tip_attr_ignore_atk_magic_def_pre",
			"tip_attr_ignore_atk_physics_def_rate_pre",
			"tip_attr_ignore_atk_magic_def_rate_pre",
			"tip_attr_ignore_def_independence_pre"
		};

		// Token: 0x0400B168 RID: 45416
		private List<StrengthenAttributeItemData> attributes = new List<StrengthenAttributeItemData>();

		// Token: 0x0400B169 RID: 45417
		private ItemData itemData;

		// Token: 0x0400B16A RID: 45418
		private EquipStrModTable equipStrMode;

		// Token: 0x0400B16B RID: 45419
		private EquipStrModTable equipStrMode2;

		// Token: 0x0400B16C RID: 45420
		private EquipAttrTable attrData;

		// Token: 0x0400B16D RID: 45421
		private bool bPvp;

		// Token: 0x0400B16E RID: 45422
		private EquipStrModIndAtkTable equipStrModeIndependence;
	}
}
