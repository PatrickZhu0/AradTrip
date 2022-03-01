using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020016D0 RID: 5840
	public class ItemData
	{
		// Token: 0x0600E461 RID: 58465 RVA: 0x003B1A7B File Offset: 0x003AFE7B
		public ItemData(int tableId)
		{
			this.mTableData = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableId, string.Empty, string.Empty);
			if (this.mTableData == null)
			{
				return;
			}
			this.Name = this.mTableData.Name;
		}

		// Token: 0x17001C92 RID: 7314
		// (get) Token: 0x0600E462 RID: 58466 RVA: 0x003B1ABB File Offset: 0x003AFEBB
		public int TableID
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.ID;
				}
				return 0;
			}
		}

		// Token: 0x17001C93 RID: 7315
		// (get) Token: 0x0600E463 RID: 58467 RVA: 0x003B1AD5 File Offset: 0x003AFED5
		public string Icon
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.Icon;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C94 RID: 7316
		// (get) Token: 0x0600E464 RID: 58468 RVA: 0x003B1AF3 File Offset: 0x003AFEF3
		public string Description
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.GetDescriptionOrDoubleCheckDesc(this.mTableData.Description);
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C95 RID: 7317
		// (get) Token: 0x0600E465 RID: 58469 RVA: 0x003B1B17 File Offset: 0x003AFF17
		public string SourceDescription
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.ComeDesc;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C96 RID: 7318
		// (get) Token: 0x0600E466 RID: 58470 RVA: 0x003B1B35 File Offset: 0x003AFF35
		public string EffectDescription
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.mTableData.EffectDescription;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001C97 RID: 7319
		// (get) Token: 0x0600E467 RID: 58471 RVA: 0x003B1B53 File Offset: 0x003AFF53
		// (set) Token: 0x0600E468 RID: 58472 RVA: 0x003B1B5B File Offset: 0x003AFF5B
		public int TransferStone { get; set; }

		// Token: 0x17001C98 RID: 7320
		// (get) Token: 0x0600E469 RID: 58473 RVA: 0x003B1B64 File Offset: 0x003AFF64
		public bool HasTransfered
		{
			get
			{
				return this.TransferStone != 0;
			}
		}

		// Token: 0x17001C99 RID: 7321
		// (get) Token: 0x0600E46B RID: 58475 RVA: 0x003B1B7B File Offset: 0x003AFF7B
		// (set) Token: 0x0600E46A RID: 58474 RVA: 0x003B1B72 File Offset: 0x003AFF72
		public bool CanSell
		{
			get
			{
				return this.canSell && !this.isInSidePack && !this.IsItemInUnUsedEquipPlan;
			}
			set
			{
				this.canSell = value;
			}
		}

		// Token: 0x17001C9A RID: 7322
		// (get) Token: 0x0600E46C RID: 58476 RVA: 0x003B1BA5 File Offset: 0x003AFFA5
		// (set) Token: 0x0600E46D RID: 58477 RVA: 0x003B1BAD File Offset: 0x003AFFAD
		public bool IsLease
		{
			get
			{
				return this.isLease;
			}
			set
			{
				this.isLease = value;
			}
		}

		// Token: 0x17001C9B RID: 7323
		// (get) Token: 0x0600E46E RID: 58478 RVA: 0x003B1BB6 File Offset: 0x003AFFB6
		public bool isInSidePack
		{
			get
			{
				return DataManager<SwitchWeaponDataManager>.GetInstance().IsInSidePack(this);
			}
		}

		// Token: 0x17001C9C RID: 7324
		// (get) Token: 0x0600E470 RID: 58480 RVA: 0x003B1BCC File Offset: 0x003AFFCC
		// (set) Token: 0x0600E46F RID: 58479 RVA: 0x003B1BC3 File Offset: 0x003AFFC3
		public bool IsItemInUnUsedEquipPlan
		{
			get
			{
				if (!this._isItemInUnUsedEquipPlan)
				{
					return this._isItemInUnUsedEquipPlan;
				}
				return EquipPlanUtility.IsEquipPlanOpenedByServer() && this._isItemInUnUsedEquipPlan;
			}
			set
			{
				this._isItemInUnUsedEquipPlan = value;
			}
		}

		// Token: 0x17001C9D RID: 7325
		// (get) Token: 0x0600E471 RID: 58481 RVA: 0x003B1BF2 File Offset: 0x003AFFF2
		// (set) Token: 0x0600E472 RID: 58482 RVA: 0x003B1BFC File Offset: 0x003AFFFC
		public int StrengthenLevel
		{
			get
			{
				return this.strengthenLevel;
			}
			set
			{
				this.strengthenLevel = value;
				if (this.SubType == 25)
				{
					this.mPrecEnchantmentCard = new PrecEnchantmentCard
					{
						iEnchantmentCardID = 0,
						iEnchantmentCardLevel = this.strengthenLevel
					};
				}
			}
		}

		// Token: 0x17001C9E RID: 7326
		// (get) Token: 0x0600E473 RID: 58483 RVA: 0x003B1C3D File Offset: 0x003B003D
		// (set) Token: 0x0600E474 RID: 58484 RVA: 0x003B1C45 File Offset: 0x003B0045
		public bool IsTimeLimit
		{
			get
			{
				return this.isTimeLimit;
			}
			set
			{
				this.isTimeLimit = value;
			}
		}

		// Token: 0x17001C9F RID: 7327
		// (get) Token: 0x0600E476 RID: 58486 RVA: 0x003B1C57 File Offset: 0x003B0057
		// (set) Token: 0x0600E475 RID: 58485 RVA: 0x003B1C4E File Offset: 0x003B004E
		public bool CanDecompose
		{
			get
			{
				return this.canDecompse && !this.isInSidePack && !this.IsItemInUnUsedEquipPlan;
			}
			set
			{
				this.canDecompse = value;
			}
		}

		// Token: 0x17001CA0 RID: 7328
		// (get) Token: 0x0600E478 RID: 58488 RVA: 0x003B1C8A File Offset: 0x003B008A
		// (set) Token: 0x0600E477 RID: 58487 RVA: 0x003B1C81 File Offset: 0x003B0081
		public int finalRateScore { get; set; }

		// Token: 0x17001CA1 RID: 7329
		// (get) Token: 0x0600E479 RID: 58489 RVA: 0x003B1C92 File Offset: 0x003B0092
		public string DoubleCheckWindowDesc
		{
			get
			{
				if (this.mTableData != null)
				{
					return this.GetDescriptionOrDoubleCheckDesc(this.mTableData.doubleCheckDesc);
				}
				return null;
			}
		}

		// Token: 0x0600E47A RID: 58490 RVA: 0x003B1CB4 File Offset: 0x003B00B4
		private string GetDescriptionOrDoubleCheckDesc(string sDesc)
		{
			if (this.mTableData.DescriptionLink != 0)
			{
				string result = string.Empty;
				int num = 0;
				LevelAdapterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LevelAdapterTable>(this.mTableData.DescriptionLink, string.Empty, string.Empty);
				if (tableItem != null)
				{
					PropertyInfo property = tableItem.GetType().GetProperty(string.Format("Level{0}", DataManager<PlayerBaseData>.GetInstance().Level), BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						num = (int)property.GetValue(tableItem, null);
					}
					result = string.Format(sDesc, num);
				}
				return result;
			}
			return sDesc;
		}

		// Token: 0x0600E47B RID: 58491 RVA: 0x003B1D4C File Offset: 0x003B014C
		public void RefreshRateScore()
		{
			if (this.SubType == 1)
			{
				this.finalRateScore = this.CalculateRateScore();
			}
			else if (this.GUID == 0UL && this.TableID != 0)
			{
				this.finalRateScore = this.CalculateRateScoreNew();
			}
		}

		// Token: 0x0600E47C RID: 58492 RVA: 0x003B1D9C File Offset: 0x003B019C
		public int CalculateRateScoreNew()
		{
			int result = 0;
			int num = 0;
			ItemTable.eType type = this.Type;
			if (type != ItemTable.eType.EQUIP)
			{
				if (type == ItemTable.eType.FASHION || type == ItemTable.eType.FUCKTITTLE)
				{
					EquipBaseScoreTable equipBaseScoreTable = null;
					Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<EquipBaseScoreTable>();
					if (table != null)
					{
						foreach (KeyValuePair<int, object> keyValuePair in table)
						{
							EquipBaseScoreTable equipBaseScoreTable2 = keyValuePair.Value as EquipBaseScoreTable;
							if (equipBaseScoreTable2 != null)
							{
								if (equipBaseScoreTable2.Type == (int)this.Type)
								{
									if (equipBaseScoreTable2.SubType == this.SubType)
									{
										if (equipBaseScoreTable2.ThirdType == (int)this.ThirdType)
										{
											if (equipBaseScoreTable2.NeedLevel == this.LevelLimit)
											{
												if (equipBaseScoreTable2.Color == (int)this.Quality)
												{
													if (equipBaseScoreTable2.Color2 == this.Quality2)
													{
														if (equipBaseScoreTable2.SuitId == this.SuitID)
														{
															equipBaseScoreTable = equipBaseScoreTable2;
															break;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (equipBaseScoreTable != null)
					{
						num = equipBaseScoreTable.Score;
					}
					if (this.Type == ItemTable.eType.FASHION)
					{
						result = num;
					}
					else if (this.Type == ItemTable.eType.FUCKTITTLE)
					{
						int num2 = 0;
						EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(this.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num2 = tableItem.AttachRateScore;
						}
						int num3 = 0;
						if (this.mPreciousBeadMountHole != null && this.mPreciousBeadMountHole.Length > 0 && this.mPreciousBeadMountHole[0] != null && this.mPreciousBeadMountHole[0].preciousBeadId > 0)
						{
							BeadTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.mPreciousBeadMountHole[0].preciousBeadId, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								num3 = tableItem2.Score;
							}
						}
						result = num + num2 + num3;
					}
				}
			}
			else
			{
				EquipBaseScoreModTable equipBaseScoreModTable = DataManager<ItemDataManager>.GetInstance().GetEquipBaseScoreModTable(this.SubType, (int)this.Quality);
				if (equipBaseScoreModTable == null)
				{
					Logger.LogErrorFormat("calu item score err,EquipBaseScoreModTable not find subtype:{0},quality:{1}", new object[]
					{
						this.SubType,
						this.Quality
					});
					return 0;
				}
				int num4 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.ATTACK);
				int num5 = (int)(((float)(this.LevelLimit * equipBaseScoreModTable.AttrMod2) / 1000f + (float)equipBaseScoreModTable.AttrMod1 / 1000f) * (float)num4 / 1000f);
				int num6 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.POWER);
				int num7 = (int)(((float)equipBaseScoreModTable.PowerMod1 / 1000f + Mathf.Ceil((float)this.LevelLimit / 5f) * (float)equipBaseScoreModTable.PowerMod2 / 1000f + (float)(this.LevelLimit % 5 * equipBaseScoreModTable.PowerMod3) / 1000f) * (float)num6 / 1000f);
				int num8 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.REDUCE);
				int num9 = (int)(((float)this.LevelLimit + (float)equipBaseScoreModTable.DefMod1 / 1000f) * (float)equipBaseScoreModTable.DefMod2 / 1000f * (float)num8 / 1000f);
				int num10 = 0;
				if (this.SubType == 99 && this.strengthenLevel > 0)
				{
					AssistEqStrengFouerDimAddTable assistEqStrengFouerDimAddTable = null;
					Dictionary<int, object> table2 = Singleton<TableManager>.instance.GetTable<AssistEqStrengFouerDimAddTable>();
					if (table2 != null)
					{
						foreach (KeyValuePair<int, object> keyValuePair2 in table2)
						{
							AssistEqStrengFouerDimAddTable assistEqStrengFouerDimAddTable2 = keyValuePair2.Value as AssistEqStrengFouerDimAddTable;
							if (assistEqStrengFouerDimAddTable2 != null)
							{
								if (assistEqStrengFouerDimAddTable2.Strengthen == this.strengthenLevel)
								{
									if (assistEqStrengFouerDimAddTable2.Color == (AssistEqStrengFouerDimAddTable.eColor)this.Quality)
									{
										if (assistEqStrengFouerDimAddTable2.Color2 != this.TableData.Color2)
										{
											if (assistEqStrengFouerDimAddTable2.Lv == this.LevelLimit)
											{
												assistEqStrengFouerDimAddTable = assistEqStrengFouerDimAddTable2;
												break;
											}
										}
									}
								}
							}
						}
						if (assistEqStrengFouerDimAddTable != null)
						{
							num10 = assistEqStrengFouerDimAddTable.EqScore;
						}
					}
				}
				int num11 = 0;
				if (this.EquipType == EEquipType.ET_REDMARK)
				{
					EquipEnhanceAttributeTable equipEnhanceAttributeTable = null;
					Dictionary<int, object> table3 = Singleton<TableManager>.instance.GetTable<EquipEnhanceAttributeTable>();
					if (table3 != null)
					{
						foreach (KeyValuePair<int, object> keyValuePair3 in table3)
						{
							EquipEnhanceAttributeTable equipEnhanceAttributeTable2 = keyValuePair3.Value as EquipEnhanceAttributeTable;
							if (equipEnhanceAttributeTable2 != null)
							{
								if (equipEnhanceAttributeTable2.EnhanceLevel == this.strengthenLevel)
								{
									if (equipEnhanceAttributeTable2.Quality == (int)this.Quality)
									{
										if (equipEnhanceAttributeTable2.Level == this.LevelLimit)
										{
											equipEnhanceAttributeTable = equipEnhanceAttributeTable2;
											break;
										}
									}
								}
							}
						}
						if (equipEnhanceAttributeTable != null)
						{
							num11 = equipEnhanceAttributeTable.eqScore;
						}
					}
				}
				num = num5 + num7 + num9 + num10 + num11;
				int num12;
				if (this.SubQuality == 100)
				{
					num12 = 110;
				}
				else
				{
					num12 = this.SubQuality + 1;
				}
				int num13;
				if (this.SubQuality == 100)
				{
					num13 = num * num12 / 100;
				}
				else
				{
					num13 = num * 20 / 100 * num12 / 100 + num * 80 / 100;
				}
				int num14 = 0;
				int num15 = 0;
				int num16 = 0;
				if (this.IsDefend() || this.IsOrnaments())
				{
					if (this.strengthenLevel < equipBaseScoreModTable.StrengthMod2.Count)
					{
						int num17 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.DISPHYREDUCE);
						num14 = (int)(((float)this.LevelLimit + (float)equipBaseScoreModTable.StrenthQualityMod1 / 1000f) / 8f * ((float)equipBaseScoreModTable.StrengthMod2[this.strengthenLevel] / 1000f) * (float)equipBaseScoreModTable.StrenthQualityMod2 / 1000f * (float)num17 / 1000f);
					}
					if (this.strengthenLevel < equipBaseScoreModTable.StrengthMod3.Count)
					{
						int num18 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.REDUCE);
						num16 = (int)((float)(200 * this.LevelLimit * equipBaseScoreModTable.StrengthMod3[this.strengthenLevel]) / 1000f / (1f - (float)equipBaseScoreModTable.StrengthMod3[this.strengthenLevel] / 1000f) * (float)num18 / 1000f);
					}
				}
				if (this.IsWeapon())
				{
					if (this.strengthenLevel < equipBaseScoreModTable.StrengthMod1.Count)
					{
						int num19 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.DISPHYATTACK);
						num15 = (int)(((float)this.LevelLimit + (float)equipBaseScoreModTable.StrenthQualityMod1 / 1000f) / 8f * ((float)equipBaseScoreModTable.StrengthMod1[this.strengthenLevel] / 1000f) * ((float)equipBaseScoreModTable.StrenthQualityMod2 / 1000f) * (float)num19 / 1000f);
					}
				}
				int num20 = 0;
				EquipAttrTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(this.TableID, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					int num21 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.FUJIA);
					num20 = (int)((float)(tableItem3.AttachRateScore * num21) / 1000f);
				}
				int num22 = 0;
				if (this.precEnchantmentCard != null && this.precEnchantmentCard.iEnchantmentCardID > 0)
				{
					MagicCardTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.precEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						num22 = tableItem4.Score + tableItem4.UpAddScore * this.precEnchantmentCard.iEnchantmentCardLevel;
					}
				}
				int num23 = 0;
				if (this.mPreciousBeadMountHole != null)
				{
					for (int i = 0; i < this.mPreciousBeadMountHole.Length; i++)
					{
						PrecBead precBead = this.mPreciousBeadMountHole[i];
						if (precBead != null)
						{
							if (precBead.preciousBeadId > 0)
							{
								BeadTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.mPreciousBeadMountHole[0].preciousBeadId, string.Empty, string.Empty);
								if (tableItem5 != null)
								{
									num23 += tableItem5.Score;
								}
							}
						}
					}
				}
				int num24 = 0;
				if (this.mInscriptionHoles != null)
				{
					for (int j = 0; j < this.mInscriptionHoles.Count; j++)
					{
						InscriptionHoleData inscriptionHoleData = this.mInscriptionHoles[j];
						if (inscriptionHoleData != null)
						{
							if (inscriptionHoleData.IsOpenHole)
							{
								if (inscriptionHoleData.InscriptionId > 0)
								{
									InscriptionTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(inscriptionHoleData.InscriptionId, string.Empty, string.Empty);
									if (tableItem6 != null)
									{
										num24 += tableItem6.Score;
									}
								}
							}
						}
					}
				}
				result = num13 + num14 + num15 + num16 + num20 + num22 + num23 + num24;
			}
			return result;
		}

		// Token: 0x0600E47D RID: 58493 RVA: 0x003B2684 File Offset: 0x003B0A84
		private bool IsDefend()
		{
			bool result = false;
			if (this.SubType == 2 || this.SubType == 3 || this.SubType == 4 || this.SubType == 5 || this.SubType == 6)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600E47E RID: 58494 RVA: 0x003B26D4 File Offset: 0x003B0AD4
		private bool IsOrnaments()
		{
			bool result = false;
			if (this.SubType == 7 || this.SubType == 8 || this.SubType == 9)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600E47F RID: 58495 RVA: 0x003B270C File Offset: 0x003B0B0C
		private bool IsWeapon()
		{
			bool result = false;
			if (this.SubType == 1)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600E480 RID: 58496 RVA: 0x003B272C File Offset: 0x003B0B2C
		private int CalculateRateScore()
		{
			Dictionary<string, float> equipPropFactors = Global.Settings.equipPropFactors;
			float num = 0f;
			ItemProperty propertyForEquipScore = this.GetPropertyForEquipScore();
			for (int i = 0; i < 41; i++)
			{
				AttributeType attributeType = (AttributeType)i;
				string key = attributeType.ToString();
				if (equipPropFactors.ContainsKey(key))
				{
					int value = propertyForEquipScore.GetValue(attributeType);
					if (value != 0)
					{
						if (Global.equipPropExtra[key] == 10)
						{
							num += equipPropFactors[key] * ((float)value / (float)Global.equipPropExtra[key]) * (float)Mathf.Max(5, this.LevelLimit) / 10f;
						}
						else
						{
							num += equipPropFactors[key] * ((float)value / (float)Global.equipPropExtra[key]);
						}
					}
				}
				else if (attributeType == AttributeType.baseIndependence || attributeType == AttributeType.ingoreIndependence)
				{
					int value2 = propertyForEquipScore.GetValue(attributeType);
					if (value2 != 0)
					{
						int num2 = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.Independent);
						num += (float)num2 / 1000f * ((float)value2 / 1000f);
					}
				}
			}
			EquipScoreTable.eType[] elementTypes = new EquipScoreTable.eType[]
			{
				EquipScoreTable.eType.None,
				EquipScoreTable.eType.Light,
				EquipScoreTable.eType.Fire,
				EquipScoreTable.eType.Ice,
				EquipScoreTable.eType.Dark
			};
			num += this._CalculateLFIDAtkScore(propertyForEquipScore.magicElements, elementTypes);
			EquipScoreTable.eType[] elementTypes2 = new EquipScoreTable.eType[]
			{
				EquipScoreTable.eType.None,
				EquipScoreTable.eType.LightAttack,
				EquipScoreTable.eType.FireAttack,
				EquipScoreTable.eType.IceAttack,
				EquipScoreTable.eType.DarkAttack
			};
			num += this._CalculateLFIDScore(propertyForEquipScore.magicElementsAttack, elementTypes2);
			EquipScoreTable.eType[] elementTypes3 = new EquipScoreTable.eType[]
			{
				EquipScoreTable.eType.None,
				EquipScoreTable.eType.LightDefence,
				EquipScoreTable.eType.FireDefence,
				EquipScoreTable.eType.IceDefence,
				EquipScoreTable.eType.DarkDefence
			};
			num += this._CalculateLFIDScore(propertyForEquipScore.magicElementsDefence, elementTypes3);
			EquipScoreTable.eType[] elementTypes4 = new EquipScoreTable.eType[]
			{
				EquipScoreTable.eType.GDKX,
				EquipScoreTable.eType.CXKX,
				EquipScoreTable.eType.ZSKX,
				EquipScoreTable.eType.ZDKX,
				EquipScoreTable.eType.SMKX,
				EquipScoreTable.eType.XYKX,
				EquipScoreTable.eType.SHKX,
				EquipScoreTable.eType.BDKX,
				EquipScoreTable.eType.SLKX,
				EquipScoreTable.eType.HLKX,
				EquipScoreTable.eType.SFKX,
				EquipScoreTable.eType.JSKX,
				EquipScoreTable.eType.ZZKX
			};
			num += this._CalculateAllabnormalResistsScore(propertyForEquipScore.abnormalResist, propertyForEquipScore.abnormalResists, elementTypes4);
			float num3;
			if (Global.Settings.quipThirdTypeFactors.ContainsKey(this.ThirdType.ToString()))
			{
				num3 = Global.Settings.quipThirdTypeFactors[this.ThirdType.ToString()];
			}
			else
			{
				num3 = this.GetEquipScoreValueByThirdType();
			}
			num *= num3;
			if (this.TableData != null)
			{
				EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(this.TableData.EquipPropID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.AttachRateScore != 0)
				{
					num += (float)tableItem.AttachRateScore;
				}
			}
			if (this.InscriptionHoles != null)
			{
				for (int j = 0; j < this.InscriptionHoles.Count; j++)
				{
					InscriptionHoleData inscriptionHoleData = this.InscriptionHoles[j];
					if (inscriptionHoleData != null)
					{
						if (inscriptionHoleData.InscriptionId > 0)
						{
							InscriptionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(inscriptionHoleData.InscriptionId, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								num += (float)tableItem2.Score;
							}
						}
					}
				}
			}
			return (int)Mathf.Max(1f, num);
		}

		// Token: 0x0600E481 RID: 58497 RVA: 0x003B2A28 File Offset: 0x003B0E28
		private float GetEquipScoreValueByThirdType()
		{
			int num = 1000;
			if (this.ThirdType == ItemTable.eThirdType.OFG)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.OFG);
			}
			if (this.ThirdType == ItemTable.eThirdType.EAST_STICK)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.EAST_STICK);
			}
			if (this.ThirdType == ItemTable.eThirdType.SICKLE)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.SICKLE);
			}
			if (this.ThirdType == ItemTable.eThirdType.TOTEM)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.TOTEM);
			}
			if (this.ThirdType == ItemTable.eThirdType.AXE)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.AXE);
			}
			if (this.ThirdType == ItemTable.eThirdType.BEADS)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.BEADS);
			}
			if (this.ThirdType == ItemTable.eThirdType.CROSS)
			{
				num = DataManager<ItemDataManager>.GetInstance()._GetDataByType(EquipScoreTable.eType.CROSS);
			}
			if (num <= 0)
			{
				return 1f;
			}
			return (float)num / 1000f;
		}

		// Token: 0x0600E482 RID: 58498 RVA: 0x003B2B08 File Offset: 0x003B0F08
		private float _CalculateLFIDAtkScore(int[] elements, EquipScoreTable.eType[] ElementTypes)
		{
			int num = 0;
			float num2 = 0f;
			for (int i = 0; i < elements.Length; i++)
			{
				if (elements[i] > 0)
				{
					float num3 = (float)DataManager<ItemDataManager>.GetInstance()._GetDataByType(ElementTypes[i]);
					if (num3 > num2)
					{
						num2 = num3;
					}
					num++;
				}
			}
			return num2 / 1000f * (1f + (float)(num - 1) * 0.1f);
		}

		// Token: 0x0600E483 RID: 58499 RVA: 0x003B2B80 File Offset: 0x003B0F80
		private float _CalculateLFIDScore(CrypticInt32[] elements, EquipScoreTable.eType[] ElementTypes)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < elements.Length; i++)
			{
				if (elements[i] != 0)
				{
					if (elements[i] > num)
					{
						num = elements[i];
						num2 = i;
					}
					num3++;
				}
			}
			return (float)num * ((float)DataManager<ItemDataManager>.GetInstance()._GetDataByType(ElementTypes[num2]) / 1000f) * (1f + (float)(num3 - 1) * 0.1f);
		}

		// Token: 0x0600E484 RID: 58500 RVA: 0x003B2C2C File Offset: 0x003B102C
		private float _CalculateAllabnormalResistsScore(CrypticInt32 abnormalResist, CrypticInt32[] abnormalResists, EquipScoreTable.eType[] ElementTypes)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < abnormalResists.Length; i++)
			{
				if (abnormalResists[i] != 0)
				{
					if (abnormalResists[i] > num)
					{
						num = abnormalResists[i];
						num2 = i;
					}
					num3++;
				}
			}
			if (abnormalResist > 0)
			{
				num += abnormalResist;
				num3 = ElementTypes.Length;
			}
			return (float)num * ((float)DataManager<ItemDataManager>.GetInstance()._GetDataByType(ElementTypes[num2]) / 1000f) * (1f + (float)(num3 - 1) * 0.1f);
		}

		// Token: 0x17001CA2 RID: 7330
		// (get) Token: 0x0600E485 RID: 58501 RVA: 0x003B2CEE File Offset: 0x003B10EE
		// (set) Token: 0x0600E486 RID: 58502 RVA: 0x003B2CF6 File Offset: 0x003B10F6
		public int FashionFreeTimes
		{
			get
			{
				return this.iFashionFreeTimes;
			}
			set
			{
				this.iFashionFreeTimes = value;
			}
		}

		// Token: 0x17001CA3 RID: 7331
		// (get) Token: 0x0600E487 RID: 58503 RVA: 0x003B2CFF File Offset: 0x003B10FF
		// (set) Token: 0x0600E488 RID: 58504 RVA: 0x003B2D07 File Offset: 0x003B1107
		public int FashionBaseAttributeID
		{
			get
			{
				return this.iFashionBaseAttributeID;
			}
			set
			{
				if (this.Type == ItemTable.eType.FASHION)
				{
					this.iFashionBaseAttributeID = value;
				}
				else
				{
					this.iFashionBaseAttributeID = 0;
				}
			}
		}

		// Token: 0x17001CA4 RID: 7332
		// (get) Token: 0x0600E489 RID: 58505 RVA: 0x003B2D28 File Offset: 0x003B1128
		// (set) Token: 0x0600E48A RID: 58506 RVA: 0x003B2D30 File Offset: 0x003B1130
		public int FashionAttributeID
		{
			get
			{
				return this.iFashionAttributeID;
			}
			set
			{
				if (this.Type == ItemTable.eType.FASHION)
				{
					this.iFashionAttributeID = value;
				}
				else
				{
					this.iFashionAttributeID = 0;
				}
			}
		}

		// Token: 0x17001CA5 RID: 7333
		// (get) Token: 0x0600E48B RID: 58507 RVA: 0x003B2D54 File Offset: 0x003B1154
		public bool HasFashionAttribute
		{
			get
			{
				EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(this.iFashionAttributeID, string.Empty, string.Empty);
				return tableItem != null && this.fashionAttributes != null && this.fashionAttributes.Count > 1;
			}
		}

		// Token: 0x17001CA6 RID: 7334
		// (get) Token: 0x0600E48C RID: 58508 RVA: 0x003B2D9E File Offset: 0x003B119E
		public EquipAttrTable CurFashionAttribute
		{
			get
			{
				return Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(this.iFashionAttributeID, string.Empty, string.Empty);
			}
		}

		// Token: 0x17001CA7 RID: 7335
		// (get) Token: 0x0600E48D RID: 58509 RVA: 0x003B2DBA File Offset: 0x003B11BA
		// (set) Token: 0x0600E48E RID: 58510 RVA: 0x003B2DC4 File Offset: 0x003B11C4
		public PrecBead[] PrecBeadBattle
		{
			get
			{
				return this.mPrecBeadBattle;
			}
			set
			{
				this.mPrecBeadBattle = value;
				if (this.mPrecBeadBattle != null)
				{
					if (this.BeadProp != null)
					{
						this.BeadProp.ResetProperties();
					}
					for (int i = 0; i < this.mPrecBeadBattle.Length; i++)
					{
						PrecBead precBead = this.mPrecBeadBattle[i];
						if (precBead != null)
						{
							BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(precBead.preciousBeadId, string.Empty, string.Empty);
							if (tableItem != null)
							{
								this.ExtraEquipAttributeAdded(EEquipAttributeType.EAT_BEAD, tableItem.PropType, tableItem.PropValue, this.BeadProp, tableItem.BuffInfoIDPve, tableItem.BuffInfoIDPvp, 0);
							}
							int randomBuffId = precBead.randomBuffId;
							if (!this.BeadProp.attachBuffIDs.Contains(randomBuffId))
							{
								this.BeadProp.attachBuffIDs.Add(randomBuffId);
								this.BeadProp.attachPVPBuffIDs.Add(randomBuffId);
							}
						}
					}
				}
			}
		}

		// Token: 0x17001CA8 RID: 7336
		// (get) Token: 0x0600E48F RID: 58511 RVA: 0x003B2EAC File Offset: 0x003B12AC
		// (set) Token: 0x0600E490 RID: 58512 RVA: 0x003B2EB4 File Offset: 0x003B12B4
		public PrecBead[] PreciousBeadMountHole
		{
			get
			{
				return this.mPreciousBeadMountHole;
			}
			set
			{
				this.mPreciousBeadMountHole = value;
				this.bEquipIsInsetBead = false;
				if (this.mPreciousBeadMountHole != null)
				{
					if (this.BeadProp != null)
					{
						this.BeadProp.ResetProperties();
					}
					for (int i = 0; i < this.mPreciousBeadMountHole.Length; i++)
					{
						PrecBead precBead = this.mPreciousBeadMountHole[i];
						if (precBead != null)
						{
							BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(precBead.preciousBeadId, string.Empty, string.Empty);
							if (tableItem != null)
							{
								this.ExtraEquipAttributeAdded(EEquipAttributeType.EAT_BEAD, tableItem.PropType, tableItem.PropValue, this.BeadProp, tableItem.BuffInfoIDPve, tableItem.BuffInfoIDPvp, 0);
								this.bEquipIsInsetBead = true;
							}
							BeadRandomBuff beadRandomBuffData = DataManager<BeadCardManager>.GetInstance().GetBeadRandomBuffData(precBead.randomBuffId);
							if (beadRandomBuffData != null)
							{
								this.ExtraEquipAttributeAdded(EEquipAttributeType.EAT_BEADADDITIVE, beadRandomBuffData.PropType, beadRandomBuffData.PropValue, this.BeadProp, null, null, precBead.randomBuffId);
							}
						}
					}
				}
			}
		}

		// Token: 0x17001CA9 RID: 7337
		// (get) Token: 0x0600E491 RID: 58513 RVA: 0x003B2FA3 File Offset: 0x003B13A3
		// (set) Token: 0x0600E492 RID: 58514 RVA: 0x003B2FAB File Offset: 0x003B13AB
		public int BeadAdditiveAttributeBuffID
		{
			get
			{
				return this.iBeadAdditiveAttributeBuffID;
			}
			set
			{
				this.iBeadAdditiveAttributeBuffID = value;
			}
		}

		// Token: 0x17001CAA RID: 7338
		// (get) Token: 0x0600E493 RID: 58515 RVA: 0x003B2FB4 File Offset: 0x003B13B4
		// (set) Token: 0x0600E494 RID: 58516 RVA: 0x003B2FBC File Offset: 0x003B13BC
		public int BeadPickNumber
		{
			get
			{
				return this.iBeadPickNumber;
			}
			set
			{
				this.iBeadPickNumber = value;
			}
		}

		// Token: 0x17001CAB RID: 7339
		// (get) Token: 0x0600E495 RID: 58517 RVA: 0x003B2FC5 File Offset: 0x003B13C5
		// (set) Token: 0x0600E496 RID: 58518 RVA: 0x003B2FCD File Offset: 0x003B13CD
		public int BeadReplaceNumber
		{
			get
			{
				return this.iBeadReplaceNumber;
			}
			set
			{
				this.iBeadReplaceNumber = value;
			}
		}

		// Token: 0x17001CAC RID: 7340
		// (get) Token: 0x0600E497 RID: 58519 RVA: 0x003B2FD6 File Offset: 0x003B13D6
		// (set) Token: 0x0600E498 RID: 58520 RVA: 0x003B2FDE File Offset: 0x003B13DE
		public bool BEquipIsInsetBead
		{
			get
			{
				return this.bEquipIsInsetBead;
			}
			set
			{
				this.bEquipIsInsetBead = value;
			}
		}

		// Token: 0x17001CAD RID: 7341
		// (get) Token: 0x0600E499 RID: 58521 RVA: 0x003B2FE7 File Offset: 0x003B13E7
		// (set) Token: 0x0600E49A RID: 58522 RVA: 0x003B2FF0 File Offset: 0x003B13F0
		public PrecEnchantmentCard mPrecEnchantmentCard
		{
			get
			{
				return this.precEnchantmentCard;
			}
			set
			{
				this.precEnchantmentCard = value;
				if (this.precEnchantmentCard != null)
				{
					MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.precEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.MagicProp.ResetProperties();
						this.ExtraEquipAttributeAdded(EEquipAttributeType.EAT_ENCHANTMENTCARD, tableItem.PropType, tableItem.PropValue, this.MagicProp, null, null, 0);
					}
				}
			}
		}

		// Token: 0x0600E49B RID: 58523 RVA: 0x003B305C File Offset: 0x003B145C
		private void ExtraEquipAttributeAdded(EEquipAttributeType eEquipAttributeType, IList<int> PropTypeList, IList<int> PropValueList, EquipProp equipProp, IList<int> PveBuffIDList = null, IList<int> PvpBuffIDList = null, int randomBuffID = 0)
		{
			MagicCardTable magicCardTable = null;
			if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD && this.precEnchantmentCard != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.precEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					magicCardTable = tableItem;
				}
			}
			if (PropTypeList.Count == PropValueList.Count)
			{
				for (int i = 0; i < PropTypeList.Count; i++)
				{
					int num = PropTypeList[i];
					int num2 = 0;
					int num3 = 0;
					if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
					{
						if (magicCardTable != null && this.precEnchantmentCard != null)
						{
							int iEnchantmentCardLevel = this.precEnchantmentCard.iEnchantmentCardLevel;
							num2 = magicCardTable.PropValue[i] + iEnchantmentCardLevel * magicCardTable.UpValue[i];
							num3 = magicCardTable.PropValue_PVP[i] + iEnchantmentCardLevel * magicCardTable.UpValue_PVP[i];
						}
					}
					else
					{
						num2 = PropValueList[i];
					}
					if (num > 0 && num <= 17)
					{
						EServerProp enumValue = (EServerProp)num;
						MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (enumAttribute != null)
						{
							if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
							{
								if (!this.isPVP)
								{
									CrypticInt32[] props = equipProp.props;
									EEquipProp prop = enumAttribute.Prop;
									props[(int)prop] = props[(int)prop] + num2;
								}
								else
								{
									CrypticInt32[] props2 = equipProp.props;
									EEquipProp prop2 = enumAttribute.Prop;
									props2[(int)prop2] = props2[(int)prop2] + num3;
								}
							}
							else
							{
								CrypticInt32[] props3 = equipProp.props;
								EEquipProp prop3 = enumAttribute.Prop;
								props3[(int)prop3] = props3[(int)prop3] + num2;
							}
						}
					}
					else if (num >= 18 && num <= 21)
					{
						EEquipProp eequipProp = (EEquipProp)(num - 18);
						if (eequipProp >= EEquipProp.PhysicsAttack && eequipProp <= EEquipProp.MagicDefense)
						{
							if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
							{
								if (!this.isPVP)
								{
									CrypticInt32[] props4 = equipProp.props;
									EEquipProp eequipProp2 = eequipProp;
									props4[(int)eequipProp2] = props4[(int)eequipProp2] + num2;
								}
								else
								{
									CrypticInt32[] props5 = equipProp.props;
									EEquipProp eequipProp3 = eequipProp;
									props5[(int)eequipProp3] = props5[(int)eequipProp3] + num3;
								}
							}
							else
							{
								CrypticInt32[] props6 = equipProp.props;
								EEquipProp eequipProp4 = eequipProp;
								props6[(int)eequipProp4] = props6[(int)eequipProp4] + num2;
							}
						}
					}
					else if (num >= 22 && num <= 25)
					{
						if (eEquipAttributeType != EEquipAttributeType.EAT_BEADADDITIVE)
						{
							if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
							{
								if (magicCardTable != null && magicCardTable.PropValue[i] > 0 && magicCardTable.PropValue[i] < 5)
								{
									equipProp.magicElements[magicCardTable.PropValue[i]] = 1;
								}
							}
							else if (num2 > 0 && num2 < 5)
							{
								equipProp.magicElements[num2] = 1;
							}
						}
					}
					else if (num >= 26 && num <= 29)
					{
						if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
						{
							if (!this.isPVP)
							{
								if (num2 != 0)
								{
									equipProp.magicElementsAttack[num - 26 + 1] += num2;
								}
							}
							else if (num3 != 0)
							{
								equipProp.magicElementsAttack[num - 26 + 1] += num3;
							}
						}
						else if (num2 != 0)
						{
							equipProp.magicElementsAttack[num - 26 + 1] += num2;
						}
					}
					else if (num >= 30 && num <= 33)
					{
						if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
						{
							if (!this.isPVP)
							{
								if (num2 != 0)
								{
									equipProp.magicElementsDefence[num - 30 + 1] += num2;
								}
							}
							else if (num3 != 0)
							{
								equipProp.magicElementsDefence[num - 30 + 1] += num3;
							}
						}
						else if (num2 != 0)
						{
							equipProp.magicElementsDefence[num - 30 + 1] += num2;
						}
					}
					else if (num >= 34 && num <= 46)
					{
						if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
						{
							if (!this.isPVP)
							{
								if (num2 != 0)
								{
									equipProp.abnormalResists[num - 34] += num2;
								}
							}
							else if (num3 != 0)
							{
								equipProp.abnormalResists[num - 34] += num3;
							}
						}
						else if ((eEquipAttributeType == EEquipAttributeType.EAT_BEAD || eEquipAttributeType == EEquipAttributeType.EAT_INSCRIPTION) && num2 != 0)
						{
							equipProp.abnormalResists[num - 34] += num2;
						}
					}
					else if (num == 47)
					{
						if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
						{
							if (!this.isPVP)
							{
								if (num2 != 0)
								{
									CrypticInt32[] props7 = equipProp.props;
									int num4 = 19;
									props7[num4] += num2;
								}
							}
							else if (num3 != 0)
							{
								CrypticInt32[] props8 = equipProp.props;
								int num5 = 19;
								props8[num5] += num3;
							}
						}
						else if ((eEquipAttributeType == EEquipAttributeType.EAT_BEAD || eEquipAttributeType == EEquipAttributeType.EAT_INSCRIPTION) && num2 != 0)
						{
							CrypticInt32[] props9 = equipProp.props;
							int num6 = 19;
							props9[num6] += num2;
						}
					}
					else if (num == 48)
					{
						if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
						{
							if (!this.isPVP)
							{
								if (num2 != 0)
								{
									CrypticInt32[] props10 = equipProp.props;
									int num7 = 59;
									props10[num7] += num2;
								}
							}
							else if (num3 != 0)
							{
								CrypticInt32[] props11 = equipProp.props;
								int num8 = 59;
								props11[num8] += num3;
							}
						}
						else if (num2 != 0)
						{
							CrypticInt32[] props12 = equipProp.props;
							int num9 = 59;
							props12[num9] += num2;
						}
					}
				}
			}
			if (eEquipAttributeType == EEquipAttributeType.EAT_ENCHANTMENTCARD)
			{
				if (this.precEnchantmentCard != null && magicCardTable != null)
				{
					int iEnchantmentCardLevel2 = this.precEnchantmentCard.iEnchantmentCardLevel;
					if (iEnchantmentCardLevel2 > 0 && iEnchantmentCardLevel2 <= magicCardTable.UpBuffID.Count)
					{
						this.AddAttachPveBuffIID(equipProp, magicCardTable.UpBuffID[iEnchantmentCardLevel2 - 1]);
					}
					else
					{
						for (int j = 0; j < magicCardTable.BuffID.Count; j++)
						{
							this.AddAttachPveBuffIID(equipProp, magicCardTable.BuffID[j]);
						}
					}
					if (iEnchantmentCardLevel2 > 0 && iEnchantmentCardLevel2 <= magicCardTable.UpBuffID_PVP.Count)
					{
						this.AddAttachPvpBuffIID(equipProp, magicCardTable.UpBuffID_PVP[iEnchantmentCardLevel2 - 1]);
					}
					else
					{
						for (int k = 0; k < magicCardTable.BuffID_PVP.Count; k++)
						{
							this.AddAttachPvpBuffIID(equipProp, magicCardTable.BuffID_PVP[k]);
						}
					}
				}
			}
			else if (eEquipAttributeType == EEquipAttributeType.EAT_BEAD)
			{
				if (PveBuffIDList != null)
				{
					for (int l = 0; l < PveBuffIDList.Count; l++)
					{
						this.AddAttachPveBuffIID(equipProp, PveBuffIDList[l]);
					}
				}
				if (PvpBuffIDList != null)
				{
					for (int m = 0; m < PvpBuffIDList.Count; m++)
					{
						this.AddAttachPvpBuffIID(equipProp, PvpBuffIDList[m]);
					}
				}
			}
			else if (eEquipAttributeType == EEquipAttributeType.EAT_BEADADDITIVE)
			{
				if (PropTypeList.Count == 0 || PropValueList.Count == 0 || PropTypeList.Count != PropValueList.Count)
				{
					this.AddAttachPveBuffIID(equipProp, randomBuffID);
					this.AddAttachPvpBuffIID(equipProp, randomBuffID);
				}
			}
			else if (eEquipAttributeType == EEquipAttributeType.EAT_INSCRIPTION && PveBuffIDList != null)
			{
				for (int n = 0; n < PveBuffIDList.Count; n++)
				{
					this.AddAttachPveBuffIID(equipProp, PveBuffIDList[n]);
				}
			}
		}

		// Token: 0x0600E49C RID: 58524 RVA: 0x003B384F File Offset: 0x003B1C4F
		private void AddAttachPveBuffIID(EquipProp equipProp, int buffId)
		{
			if (equipProp != null && equipProp.attachBuffIDs != null && !equipProp.attachBuffIDs.Contains(buffId))
			{
				equipProp.attachBuffIDs.Add(buffId);
			}
		}

		// Token: 0x0600E49D RID: 58525 RVA: 0x003B387F File Offset: 0x003B1C7F
		private void AddAttachPvpBuffIID(EquipProp equipProp, int buffId)
		{
			if (equipProp != null && equipProp.attachPVPBuffIDs != null && !equipProp.attachPVPBuffIDs.Contains(buffId))
			{
				equipProp.attachPVPBuffIDs.Add(buffId);
			}
		}

		// Token: 0x0600E49E RID: 58526 RVA: 0x003B38B0 File Offset: 0x003B1CB0
		private void EnchantmentCardAttribute(MagicCardTable magicCardTable, int enchantmentCardLevel, EquipProp magicProp)
		{
			if (magicCardTable.PropType.Count == magicCardTable.PropValue.Count)
			{
				for (int i = 0; i < magicCardTable.PropType.Count; i++)
				{
					int num = magicCardTable.PropType[i];
					int num2 = magicCardTable.PropValue[i] + enchantmentCardLevel * magicCardTable.UpValue[i];
					int num3 = magicCardTable.PropValue_PVP[i] + enchantmentCardLevel * magicCardTable.UpValue_PVP[i];
					if (num > 0 && num <= 17)
					{
						EServerProp enumValue = (EServerProp)num;
						MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (enumAttribute != null)
						{
							if (!this.isPVP)
							{
								magicProp.props[(int)enumAttribute.Prop] = num2;
							}
							else
							{
								magicProp.props[(int)enumAttribute.Prop] = num3;
							}
						}
					}
					else if (num >= 18 && num <= 21)
					{
						EEquipProp eequipProp = (EEquipProp)(num - 18);
						if (eequipProp >= EEquipProp.PhysicsAttack && eequipProp <= EEquipProp.MagicDefense)
						{
							if (!this.isPVP)
							{
								magicProp.props[(int)eequipProp] = num2;
							}
							else
							{
								magicProp.props[(int)eequipProp] = num3;
							}
						}
					}
					else if (num >= 22 && num <= 25)
					{
						if (magicCardTable.PropValue[i] > 0 && magicCardTable.PropValue[i] < 5)
						{
							magicProp.magicElements[magicCardTable.PropValue[i]] = 1;
						}
					}
					else if (num >= 26 && num <= 29)
					{
						if (magicCardTable.PropValue[i] != 0)
						{
							if (!this.isPVP)
							{
								magicProp.magicElementsAttack[num - 26 + 1] = num2;
							}
							else
							{
								magicProp.magicElementsAttack[num - 26 + 1] = num3;
							}
						}
					}
					else if (num >= 30 && num <= 33)
					{
						if (magicCardTable.PropValue[i] != 0)
						{
							if (!this.isPVP)
							{
								magicProp.magicElementsDefence[num - 30 + 1] = num2;
							}
							else
							{
								magicProp.magicElementsDefence[num - 30 + 1] = num3;
							}
						}
					}
					else if (num >= 34 && num <= 46)
					{
						if (magicCardTable.PropValue[i] != 0)
						{
							if (!this.isPVP)
							{
								magicProp.abnormalResists[num - 34] = num2;
							}
							else
							{
								magicProp.abnormalResists[num - 34] = num3;
							}
						}
					}
					else if (num == 47 && magicCardTable.PropValue[i] != 0)
					{
						if (!this.isPVP)
						{
							magicProp.props[19] = num2;
						}
						else
						{
							magicProp.props[19] = num3;
						}
					}
				}
			}
			if (enchantmentCardLevel > 0 && enchantmentCardLevel <= magicCardTable.UpBuffID.Count && enchantmentCardLevel <= magicCardTable.UpBuffID_PVP.Count)
			{
				if (magicCardTable.UpBuffID.Count > 0 && !magicProp.attachBuffIDs.Contains(magicCardTable.UpBuffID[enchantmentCardLevel - 1]))
				{
					magicProp.attachBuffIDs.Add(magicCardTable.UpBuffID[enchantmentCardLevel - 1]);
				}
				if (magicCardTable.UpBuffID_PVP.Count > 0 && !magicProp.attachPVPBuffIDs.Contains(magicCardTable.UpBuffID_PVP[enchantmentCardLevel - 1]))
				{
					magicProp.attachPVPBuffIDs.Add(magicCardTable.UpBuffID_PVP[enchantmentCardLevel - 1]);
				}
			}
			else
			{
				if (magicCardTable.BuffID != null)
				{
					for (int j = 0; j < magicCardTable.BuffID.Count; j++)
					{
						if (!magicProp.attachBuffIDs.Contains(magicCardTable.BuffID[j]))
						{
							magicProp.attachBuffIDs.Add(magicCardTable.BuffID[j]);
						}
					}
				}
				if (magicCardTable.BuffID_PVP != null)
				{
					for (int k = 0; k < magicCardTable.BuffID_PVP.Count; k++)
					{
						if (!magicProp.attachPVPBuffIDs.Contains(magicCardTable.BuffID_PVP[k]))
						{
							magicProp.attachPVPBuffIDs.Add(magicCardTable.BuffID_PVP[k]);
						}
					}
				}
			}
		}

		// Token: 0x0600E49F RID: 58527 RVA: 0x003B3D2C File Offset: 0x003B212C
		private void BeadAdditiveAttribute(IList<int> iPropType, IList<int> iPropValue, int randomBuffID, EquipProp equipProp)
		{
			if (iPropType.Count == iPropValue.Count && iPropType.Count != 0 && iPropValue.Count != 0)
			{
				for (int i = 0; i < iPropType.Count; i++)
				{
					int num = iPropType[i];
					if (num > 0 && num <= 17)
					{
						EServerProp enumValue = (EServerProp)num;
						MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (enumAttribute != null)
						{
							CrypticInt32[] props = equipProp.props;
							EEquipProp prop = enumAttribute.Prop;
							props[(int)prop] = props[(int)prop] + iPropValue[i];
						}
					}
					else if (num >= 18 && num <= 21)
					{
						EEquipProp eequipProp = (EEquipProp)(num - 18);
						if (eequipProp >= EEquipProp.PhysicsAttack && eequipProp <= EEquipProp.MagicDefense)
						{
							CrypticInt32[] props2 = equipProp.props;
							EEquipProp eequipProp2 = eequipProp;
							props2[(int)eequipProp2] = props2[(int)eequipProp2] + iPropValue[i];
						}
					}
					else if (num >= 26 && num <= 29)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.magicElementsAttack[num - 26 + 1] += iPropValue[i];
						}
					}
					else if (num >= 30 && num <= 33 && iPropValue[i] != 0)
					{
						equipProp.magicElementsDefence[num - 30 + 1] += iPropValue[i];
					}
				}
			}
			else
			{
				if (!equipProp.attachBuffIDs.Contains(randomBuffID))
				{
					equipProp.attachBuffIDs.Add(randomBuffID);
				}
				if (!equipProp.attachPVPBuffIDs.Contains(randomBuffID))
				{
					equipProp.attachPVPBuffIDs.Add(randomBuffID);
				}
			}
		}

		// Token: 0x0600E4A0 RID: 58528 RVA: 0x003B3EE4 File Offset: 0x003B22E4
		private void MagicCardIDAndBeadCardID(IList<int> iPropType, IList<int> iPropValue, IList<int> iPveBuffID, IList<int> iPvpBuffID, EquipProp equipProp)
		{
			if (iPropType.Count == iPropValue.Count)
			{
				for (int i = 0; i < iPropType.Count; i++)
				{
					int num = iPropType[i];
					if (num > 0 && num <= 17)
					{
						EServerProp enumValue = (EServerProp)num;
						MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (enumAttribute != null)
						{
							equipProp.props[(int)enumAttribute.Prop] = iPropValue[i];
						}
					}
					else if (num >= 18 && num <= 21)
					{
						EEquipProp eequipProp = (EEquipProp)(num - 18);
						if (eequipProp >= EEquipProp.PhysicsAttack && eequipProp <= EEquipProp.MagicDefense)
						{
							equipProp.props[(int)eequipProp] = iPropValue[i];
						}
					}
					else if (num >= 22 && num <= 25)
					{
						if (iPropValue[i] > 0 && iPropValue[i] < 5)
						{
							equipProp.magicElements[iPropValue[i]] = 1;
						}
					}
					else if (num >= 26 && num <= 29)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.magicElementsAttack[num - 26 + 1] = iPropValue[i];
						}
					}
					else if (num >= 30 && num <= 33)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.magicElementsDefence[num - 30 + 1] = iPropValue[i];
						}
					}
					else if (num >= 34 && num <= 46)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.abnormalResists[num - 34] = iPropValue[i];
						}
					}
					else if (num == 47 && iPropValue[i] != 0)
					{
						equipProp.props[19] = iPropValue[i];
					}
				}
			}
			if (iPveBuffID != null)
			{
				for (int j = 0; j < iPveBuffID.Count; j++)
				{
					equipProp.attachBuffIDs.Add(iPveBuffID[j]);
				}
			}
			if (iPvpBuffID != null)
			{
				for (int k = 0; k < iPvpBuffID.Count; k++)
				{
					equipProp.attachPVPBuffIDs.Add(iPvpBuffID[k]);
				}
			}
		}

		// Token: 0x17001CAE RID: 7342
		// (get) Token: 0x0600E4A1 RID: 58529 RVA: 0x003B4130 File Offset: 0x003B2530
		// (set) Token: 0x0600E4A2 RID: 58530 RVA: 0x003B4138 File Offset: 0x003B2538
		public List<InscriptionHoleData> InscriptionHoles
		{
			get
			{
				return this.mInscriptionHoles;
			}
			set
			{
				this.mInscriptionHoles = value;
				if (this.mInscriptionHoles != null)
				{
					if (this.IncriptionProp != null)
					{
						this.IncriptionProp.ResetProperties();
					}
					for (int i = 0; i < this.mInscriptionHoles.Count; i++)
					{
						if (this.mInscriptionHoles[i] != null)
						{
							int inscriptionId = this.mInscriptionHoles[i].InscriptionId;
							InscriptionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<InscriptionTable>(inscriptionId, string.Empty, string.Empty);
							if (tableItem != null)
							{
								this.ExtraEquipAttributeAdded(EEquipAttributeType.EAT_INSCRIPTION, tableItem.PropType, tableItem.PropValue, this.IncriptionProp, tableItem.BuffID, null, 0);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E4A3 RID: 58531 RVA: 0x003B41F0 File Offset: 0x003B25F0
		private void IncriptionAttrIntoTheBattle(IList<int> iPropType, IList<int> iPropValue, IList<int> iPveBuffID, EquipProp equipProp)
		{
			if (iPropType.Count == iPropValue.Count)
			{
				for (int i = 0; i < iPropType.Count; i++)
				{
					int num = iPropType[i];
					if (num > 0 && num <= 17)
					{
						EServerProp enumValue = (EServerProp)num;
						MapEnum enumAttribute = Utility.GetEnumAttribute<EServerProp, MapEnum>(enumValue);
						if (enumAttribute != null)
						{
							equipProp.props[(int)enumAttribute.Prop] = iPropValue[i];
						}
					}
					else if (num >= 18 && num <= 21)
					{
						EEquipProp eequipProp = (EEquipProp)(num - 18);
						if (eequipProp >= EEquipProp.PhysicsAttack && eequipProp <= EEquipProp.MagicDefense)
						{
							equipProp.props[(int)eequipProp] = iPropValue[i];
						}
					}
					else if (num >= 22 && num <= 25)
					{
						if (iPropValue[i] > 0 && iPropValue[i] < 5)
						{
							equipProp.magicElements[iPropValue[i]] = 1;
						}
					}
					else if (num >= 26 && num <= 29)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.magicElementsAttack[num - 26 + 1] = iPropValue[i];
						}
					}
					else if (num >= 30 && num <= 33)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.magicElementsDefence[num - 30 + 1] = iPropValue[i];
						}
					}
					else if (num >= 34 && num <= 46)
					{
						if (iPropValue[i] != 0)
						{
							equipProp.abnormalResists[num - 34] = iPropValue[i];
						}
					}
					else if (num == 47 && iPropValue[i] != 0)
					{
						equipProp.props[19] = iPropValue[i];
					}
				}
			}
			if (iPveBuffID != null)
			{
				for (int j = 0; j < iPveBuffID.Count; j++)
				{
					equipProp.attachBuffIDs.Add(iPveBuffID[j]);
				}
			}
		}

		// Token: 0x17001CAF RID: 7343
		// (get) Token: 0x0600E4A4 RID: 58532 RVA: 0x003B4404 File Offset: 0x003B2804
		// (set) Token: 0x0600E4A5 RID: 58533 RVA: 0x003B4422 File Offset: 0x003B2822
		public EquipProp BaseProp
		{
			get
			{
				if (this.mBaseProp == null)
				{
					this.mBaseProp = new EquipProp();
				}
				return this.mBaseProp;
			}
			set
			{
				this.mBaseProp = value;
			}
		}

		// Token: 0x17001CB0 RID: 7344
		// (get) Token: 0x0600E4A6 RID: 58534 RVA: 0x003B442C File Offset: 0x003B282C
		// (set) Token: 0x0600E4A7 RID: 58535 RVA: 0x003B44AA File Offset: 0x003B28AA
		public EquipProp RandamProp
		{
			get
			{
				if (this.mRandamProp == null)
				{
					if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FASHION || this.Type == ItemTable.eType.FUCKTITTLE)
					{
						this.mRandamProp = new EquipProp();
					}
					else
					{
						Logger.LogErrorFormat("计算身上穿戴装备的属性错误!穿戴身上的一定应该是装备。这里道具类型错误，正常流程不会出现这种情况。当前道具id：{0}, 道具名称:{1}", new object[]
						{
							this.TableID,
							this.TableData.Name
						});
					}
				}
				return this.mRandamProp;
			}
			set
			{
				this.mRandamProp = value;
			}
		}

		// Token: 0x17001CB1 RID: 7345
		// (get) Token: 0x0600E4A8 RID: 58536 RVA: 0x003B44B4 File Offset: 0x003B28B4
		// (set) Token: 0x0600E4A9 RID: 58537 RVA: 0x003B450D File Offset: 0x003B290D
		public EquipProp MagicProp
		{
			get
			{
				if (this.mMagicProp == null && (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FASHION || this.Type == ItemTable.eType.FUCKTITTLE || this.Type == ItemTable.eType.EXPENDABLE))
				{
					this.mMagicProp = new EquipProp();
				}
				return this.mMagicProp;
			}
			set
			{
				this.mMagicProp = value;
			}
		}

		// Token: 0x17001CB2 RID: 7346
		// (get) Token: 0x0600E4AA RID: 58538 RVA: 0x003B4518 File Offset: 0x003B2918
		// (set) Token: 0x0600E4AB RID: 58539 RVA: 0x003B4571 File Offset: 0x003B2971
		public EquipProp BeadProp
		{
			get
			{
				if (this.mBeadProp == null && (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FASHION || this.Type == ItemTable.eType.FUCKTITTLE || this.Type == ItemTable.eType.EXPENDABLE))
				{
					this.mBeadProp = new EquipProp();
				}
				return this.mBeadProp;
			}
			set
			{
				this.mBeadProp = value;
			}
		}

		// Token: 0x17001CB3 RID: 7347
		// (get) Token: 0x0600E4AC RID: 58540 RVA: 0x003B457C File Offset: 0x003B297C
		// (set) Token: 0x0600E4AD RID: 58541 RVA: 0x003B45D5 File Offset: 0x003B29D5
		public EquipProp IncriptionProp
		{
			get
			{
				if (this.mInscriptionProp == null && (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FASHION || this.Type == ItemTable.eType.FUCKTITTLE || this.Type == ItemTable.eType.EXPENDABLE))
				{
					this.mInscriptionProp = new EquipProp();
				}
				return this.mInscriptionProp;
			}
			set
			{
				this.mInscriptionProp = value;
			}
		}

		// Token: 0x0600E4AE RID: 58542 RVA: 0x003B45E0 File Offset: 0x003B29E0
		public static ItemData.QualityInfo GetQualityInfo(ItemTable.eColor type, bool bGrey = false, bool bRed = false)
		{
			for (int i = 0; i < ItemData.ms_qualityInfos.Length; i++)
			{
				ItemData.QualityInfo qualityInfo = ItemData.ms_qualityInfos[i];
				if (qualityInfo != null)
				{
					if (qualityInfo.Quality == type)
					{
						if (type == ItemTable.eColor.WHITE && bGrey)
						{
							return ItemData.ms_grey_quality;
						}
						if (qualityInfo.Quality == ItemTable.eColor.PINK && bRed)
						{
							return ItemData.ms_rosered_quality;
						}
						return qualityInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x0600E4AF RID: 58543 RVA: 0x003B4654 File Offset: 0x003B2A54
		public static ItemData.QualityInfo GetQualityInfo(ItemTable.eColor type, int color2)
		{
			int i = 0;
			while (i < ItemData.ms_qualityInfos.Length)
			{
				if (ItemData.ms_qualityInfos[i].Quality == type)
				{
					if (type == ItemTable.eColor.WHITE && color2 == 1)
					{
						return ItemData.ms_grey_quality;
					}
					if (type == ItemTable.eColor.PINK && color2 == 3)
					{
						return ItemData.ms_rosered_quality;
					}
					return ItemData.ms_qualityInfos[i];
				}
				else
				{
					i++;
				}
			}
			return null;
		}

		// Token: 0x17001CB4 RID: 7348
		// (get) Token: 0x0600E4B0 RID: 58544 RVA: 0x003B46BC File Offset: 0x003B2ABC
		// (set) Token: 0x0600E4B1 RID: 58545 RVA: 0x003B46C4 File Offset: 0x003B2AC4
		public ItemTable TableData
		{
			get
			{
				return this.mTableData;
			}
			set
			{
				this.mTableData = value;
			}
		}

		// Token: 0x0600E4B2 RID: 58546 RVA: 0x003B46D0 File Offset: 0x003B2AD0
		public bool IsCooling()
		{
			ItemCD itemCD = DataManager<ItemDataManager>.GetInstance().GetItemCD(this.CDGroupID);
			if (itemCD != null)
			{
				double num = itemCD.endtime;
				double num2 = num - DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
				return num2 >= 0.0;
			}
			return false;
		}

		// Token: 0x0600E4B3 RID: 58547 RVA: 0x003B471C File Offset: 0x003B2B1C
		public bool IsEquiped()
		{
			return ((this.Type == ItemTable.eType.FUCKTITTLE || this.Type == ItemTable.eType.EQUIP) && DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip).Contains(this.GUID)) || (this.Type == ItemTable.eType.FASHION && DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion).Contains(this.GUID));
		}

		// Token: 0x0600E4B4 RID: 58548 RVA: 0x003B4788 File Offset: 0x003B2B88
		public bool CheckBetterThanEquip()
		{
			if (this.CanEquip() && this.PackageType != EPackageType.WearEquip && this.PackageType != EPackageType.WearFashion && this.PackageType != EPackageType.Storage && this.PackageType != EPackageType.RoleStorage)
			{
				bool flag = false;
				List<ulong> list = null;
				if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FUCKTITTLE)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				}
				else if (this.Type == ItemTable.eType.FASHION)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				}
				int num = 0;
				while (list != null && num < list.Count)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[num]);
					if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FUCKTITTLE)
					{
						if (item != null && item.EquipWearSlotType == this.EquipWearSlotType)
						{
							flag = true;
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null && tableItem2 != null)
							{
								if (item.EquipWearSlotType >= EEquipWearSlotType.EquipHead && item.EquipWearSlotType <= EEquipWearSlotType.EquipBoot)
								{
									if (DataManager<EquipMasterDataManager>.GetInstance().IsPunish(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.Quality, (int)this.EquipWearSlotType, (int)this.ThirdType))
									{
										return false;
									}
									if (!PlayerBaseData.IsJobChanged())
									{
										return this.finalRateScore > item.finalRateScore;
									}
									if (this.LevelLimit != item.LevelLimit)
									{
										if (DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.ThirdType) && DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType) && this.finalRateScore > item.finalRateScore)
										{
											return true;
										}
										if (!DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.ThirdType) && this.finalRateScore > item.finalRateScore)
										{
											return true;
										}
									}
									else if (this.LevelLimit == item.LevelLimit)
									{
										if (DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.ThirdType) && DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType) && this.finalRateScore > item.finalRateScore)
										{
											return true;
										}
										if (!DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.ThirdType) && DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType) && this.Quality >= item.Quality)
										{
											return true;
										}
										if (!DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.ThirdType) && !DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType) && this.finalRateScore > item.finalRateScore)
										{
											return true;
										}
									}
								}
								else
								{
									if (this.Type != ItemTable.eType.FUCKTITTLE)
									{
										return this.finalRateScore > item.finalRateScore;
									}
									if (this.Quality > item.Quality)
									{
										return true;
									}
								}
							}
						}
					}
					else if (this.Type == ItemTable.eType.FASHION && item != null && item.FashionWearSlotType == this.FashionWearSlotType)
					{
						flag = true;
						ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
						ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem3 != null && tableItem4 != null)
						{
							return this.finalRateScore > item.finalRateScore;
						}
					}
					num++;
				}
				if (!flag)
				{
					return !PlayerBaseData.IsJobChanged() || !DataManager<EquipMasterDataManager>.GetInstance().IsPunish(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.Quality, (int)this.EquipWearSlotType, (int)this.ThirdType);
				}
			}
			return false;
		}

		// Token: 0x0600E4B5 RID: 58549 RVA: 0x003B4BB8 File Offset: 0x003B2FB8
		public bool IsBetterThanEquip()
		{
			if (this.CanEquip() && this.PackageType != EPackageType.WearEquip && this.PackageType != EPackageType.WearFashion && this.PackageType != EPackageType.Storage && this.PackageType != EPackageType.RoleStorage)
			{
				bool flag = false;
				List<ulong> list = null;
				if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FUCKTITTLE)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				}
				else if (this.Type == ItemTable.eType.FASHION)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				}
				int num = 0;
				while (list != null && num < list.Count)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[num]);
					if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FUCKTITTLE)
					{
						if (item != null && item.EquipWearSlotType == this.EquipWearSlotType)
						{
							flag = true;
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null && tableItem2 != null)
							{
								if (item.EquipWearSlotType < EEquipWearSlotType.EquipHead || item.EquipWearSlotType > EEquipWearSlotType.EquipBoot)
								{
									return this.finalRateScore > item.finalRateScore;
								}
								if (DataManager<EquipMasterDataManager>.GetInstance().IsPunish(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.Quality, (int)this.EquipWearSlotType, (int)this.ThirdType))
								{
									return false;
								}
								int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.Quality, (int)this.EquipWearSlotType, (int)this.ThirdType);
								int masterPriority2 = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
								if (masterPriority2 != masterPriority)
								{
									return masterPriority < masterPriority2;
								}
								return this.finalRateScore > item.finalRateScore;
							}
						}
					}
					else if (this.Type == ItemTable.eType.FASHION && item != null && item.FashionWearSlotType == this.FashionWearSlotType)
					{
						flag = true;
						ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
						ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem3 != null && tableItem4 != null)
						{
							return this.finalRateScore > item.finalRateScore;
						}
					}
					num++;
				}
				if (!flag)
				{
					int masterPriority3 = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.Quality, (int)this.EquipWearSlotType, (int)this.ThirdType);
					return this.Type != ItemTable.eType.EQUIP || masterPriority3 != 2;
				}
			}
			return false;
		}

		// Token: 0x0600E4B6 RID: 58550 RVA: 0x003B4E75 File Offset: 0x003B3275
		public bool IsLevelValid()
		{
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.LevelLimit;
		}

		// Token: 0x0600E4B7 RID: 58551 RVA: 0x003B4E8F File Offset: 0x003B328F
		public bool IsLevelFit()
		{
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.LevelLimit;
		}

		// Token: 0x0600E4B8 RID: 58552 RVA: 0x003B4EA9 File Offset: 0x003B32A9
		public bool IsPreLevelFit(int iPreLv)
		{
			return iPreLv > 1 && iPreLv - 1 >= this.LevelLimit;
		}

		// Token: 0x0600E4B9 RID: 58553 RVA: 0x003B4EC4 File Offset: 0x003B32C4
		public bool IsOccupationFit()
		{
			if (this.OccupationLimit.Count > 0)
			{
				bool flag = false;
				for (int i = 0; i < this.OccupationLimit.Count; i++)
				{
					int num = this.OccupationLimit[i];
					if (num > 0)
					{
						if (DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(num))
						{
							flag = true;
						}
					}
					else if (num < 0)
					{
						if (num == -1)
						{
							if (DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Count > 1)
							{
								flag = true;
							}
						}
						else
						{
							JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(-num, string.Empty, string.Empty);
							if (tableItem != null)
							{
								for (int j = 0; j < tableItem.ToJob.Count; j++)
								{
									if (DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(tableItem.ToJob[j]))
									{
										flag = true;
										break;
									}
								}
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600E4BA RID: 58554 RVA: 0x003B4FD4 File Offset: 0x003B33D4
		public bool IsWearSoltEqual(ItemData data)
		{
			return (data.Type == ItemTable.eType.FUCKTITTLE && data.EquipWearSlotType == this.EquipWearSlotType) || (data.Type == ItemTable.eType.EQUIP && this.Type == ItemTable.eType.EQUIP && data.EquipWearSlotType == this.EquipWearSlotType) || (data.Type == ItemTable.eType.FASHION && this.Type == ItemTable.eType.FASHION && data.FashionWearSlotType == this.FashionWearSlotType);
		}

		// Token: 0x0600E4BB RID: 58555 RVA: 0x003B5054 File Offset: 0x003B3454
		public bool IsItemInAuctionPackage()
		{
			return this.PackageType == EPackageType.Equip || this.PackageType == EPackageType.Material || this.PackageType == EPackageType.Consumable || this.PackageType == EPackageType.Task || this.PackageType == EPackageType.Fashion || this.PackageType == EPackageType.Title;
		}

		// Token: 0x0600E4BC RID: 58556 RVA: 0x003B50B7 File Offset: 0x003B34B7
		public bool CanGiftUse()
		{
			return this.SubType == 29 && this.UseType != ItemTable.eCanUse.CanNot && this.IsLevelFit() && this.IsOccupationFit();
		}

		// Token: 0x0600E4BD RID: 58557 RVA: 0x003B50F0 File Offset: 0x003B34F0
		public bool CanTrade()
		{
			return this.BindAttr == ItemTable.eOwner.NOTBIND || this.Packing;
		}

		// Token: 0x0600E4BE RID: 58558 RVA: 0x003B510E File Offset: 0x003B350E
		public bool HasTradePossibility()
		{
			return this.BindAttr == ItemTable.eOwner.NOTBIND || this.Packing || this.RePackTime > 0;
		}

		// Token: 0x0600E4BF RID: 58559 RVA: 0x003B513A File Offset: 0x003B353A
		public bool IsNeedPacking()
		{
			return !this.Packing && this.RePackTime > 0;
		}

		// Token: 0x0600E4C0 RID: 58560 RVA: 0x003B5158 File Offset: 0x003B3558
		public bool CanStore()
		{
			return !this.isInSidePack && (this.BindAttr == ItemTable.eOwner.NOTBIND || this.BindAttr == ItemTable.eOwner.ACCBIND || (this.BindAttr == ItemTable.eOwner.ROLEBIND && (this.Packing || this.HasTransfered)));
		}

		// Token: 0x0600E4C1 RID: 58561 RVA: 0x003B51B4 File Offset: 0x003B35B4
		public bool CanEquip()
		{
			return ((this.Type == ItemTable.eType.FUCKTITTLE && this.EquipWearSlotType > EEquipWearSlotType.EquipInvalid && this.EquipWearSlotType < EEquipWearSlotType.EquipMax) || (this.Type == ItemTable.eType.EQUIP && this.EquipWearSlotType > EEquipWearSlotType.EquipInvalid && this.EquipWearSlotType < EEquipWearSlotType.EquipMax) || (this.Type == ItemTable.eType.FASHION && this.FashionWearSlotType > EFashionWearSlotType.Invalid && this.FashionWearSlotType < EFashionWearSlotType.Max)) && this.IsLevelFit() && this.IsOccupationFit();
		}

		// Token: 0x0600E4C2 RID: 58562 RVA: 0x003B524C File Offset: 0x003B364C
		public bool WillCanEquip()
		{
			return ((this.Type == ItemTable.eType.FUCKTITTLE && this.EquipWearSlotType > EEquipWearSlotType.EquipInvalid && this.EquipWearSlotType < EEquipWearSlotType.EquipMax) || (this.Type == ItemTable.eType.EQUIP && this.EquipWearSlotType > EEquipWearSlotType.EquipInvalid && this.EquipWearSlotType < EEquipWearSlotType.EquipMax) || (this.Type == ItemTable.eType.FASHION && this.FashionWearSlotType > EFashionWearSlotType.Invalid && this.FashionWearSlotType < EFashionWearSlotType.Max)) && this.IsOccupationFit();
		}

		// Token: 0x0600E4C3 RID: 58563 RVA: 0x003B52D8 File Offset: 0x003B36D8
		public CrypticInt32[] GetDiffPropBaseOn(ItemData baseOn)
		{
			EquipProp equipProp = this.GetEquipProp();
			if (baseOn != null)
			{
				equipProp -= baseOn.GetEquipProp();
			}
			return equipProp.props;
		}

		// Token: 0x0600E4C4 RID: 58564 RVA: 0x003B5308 File Offset: 0x003B3708
		public ItemProperty GetBattleProperty(int strengthen = 0)
		{
			EquipProp equipProp = this.GetEquipProp();
			if (equipProp != null)
			{
				return equipProp.ToItemProp(this.StrengthenLevel, (int)this.EquipWearSlotType, this.GrowthAttrType, this.GrowthAttrNum);
			}
			return new ItemProperty();
		}

		// Token: 0x0600E4C5 RID: 58565 RVA: 0x003B5346 File Offset: 0x003B3746
		public ItemProperty GetPropertyForEquipScore()
		{
			return this.GetEquipPropForEquipScore().ToItemProp(this.StrengthenLevel, (int)this.EquipWearSlotType, this.GrowthAttrType, this.GrowthAttrNum);
		}

		// Token: 0x0600E4C6 RID: 58566 RVA: 0x003B536C File Offset: 0x003B376C
		public EquipProp GetEquipProp()
		{
			EquipProp equipProp = this.BaseProp + this.RandamProp + this.MagicProp + this.BeadProp + this.IncriptionProp;
			CrypticInt32[] props = equipProp.props;
			int num = 16;
			props[num] += this.BaseAttackSpeedRate;
			return equipProp;
		}

		// Token: 0x0600E4C7 RID: 58567 RVA: 0x003B53D8 File Offset: 0x003B37D8
		public EquipProp GetEquipPropForEquipScore()
		{
			EquipProp equipProp = this.BaseProp;
			equipProp += this.RandamProp;
			equipProp += this.MagicProp;
			equipProp += this.BeadProp;
			CrypticInt32[] props = equipProp.props;
			int num = 16;
			props[num] += this.BaseAttackSpeedRate;
			return equipProp;
		}

		// Token: 0x0600E4C8 RID: 58568 RVA: 0x003B5440 File Offset: 0x003B3840
		public ItemData.QualityInfo GetQualityInfo()
		{
			for (int i = 0; i < ItemData.ms_qualityInfos.Length; i++)
			{
				ItemData.QualityInfo qualityInfo = ItemData.ms_qualityInfos[i];
				if (qualityInfo.Quality == this.Quality)
				{
					if (qualityInfo.Quality == ItemTable.eColor.WHITE)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
						if (tableItem != null && tableItem.Color2 == 1)
						{
							return ItemData.ms_grey_quality;
						}
					}
					if (qualityInfo.Quality == ItemTable.eColor.PINK)
					{
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.Color2 == 3)
						{
							return ItemData.ms_rosered_quality;
						}
					}
					return qualityInfo;
				}
			}
			return null;
		}

		// Token: 0x0600E4C9 RID: 58569 RVA: 0x003B5500 File Offset: 0x003B3900
		public string GetQualityTipTitleBackGround()
		{
			ItemData.QualityInfo qualityInfo = this.GetQualityInfo();
			if (qualityInfo == null)
			{
				return string.Empty;
			}
			return qualityInfo.TipTitleBackGround;
		}

		// Token: 0x0600E4CA RID: 58570 RVA: 0x003B5528 File Offset: 0x003B3928
		public string GetColorName(string a_strFormat = "", bool a_bWithStrengthLevel = false)
		{
			string text = string.Empty;
			if (a_bWithStrengthLevel && this.StrengthenLevel > 0)
			{
				text = string.Format("+{0}{1}", this.StrengthenLevel, this.Name);
			}
			else
			{
				text = this.Name;
			}
			ItemData.QualityInfo qualityInfo = this.GetQualityInfo();
			if (!string.IsNullOrEmpty(a_strFormat))
			{
				return TR.Value("common_color_text", qualityInfo.ColStr, string.Format(a_strFormat, text));
			}
			return TR.Value("common_color_text", qualityInfo.ColStr, text);
		}

		// Token: 0x0600E4CB RID: 58571 RVA: 0x003B55B0 File Offset: 0x003B39B0
		public string GetColorLevel()
		{
			if (this.LevelLimit > 0)
			{
				ItemData.QualityInfo qualityInfo = this.GetQualityInfo();
				return TR.Value("common_color_text", qualityInfo.ColStr, this.LevelLimit);
			}
			return string.Empty;
		}

		// Token: 0x0600E4CC RID: 58572 RVA: 0x003B55F4 File Offset: 0x003B39F4
		public void GetTimeLeft(out int a_timeLeft, out bool a_bStartCountdown)
		{
			if (this.DeadTimestamp <= 0)
			{
				if (this.CanRenewal())
				{
					a_timeLeft = 0;
				}
				else
				{
					a_timeLeft = this.FixTimeLeft;
				}
				a_bStartCountdown = false;
				if (a_timeLeft > 0)
				{
					a_bStartCountdown = true;
				}
			}
			else
			{
				a_timeLeft = this.DeadTimestamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				a_bStartCountdown = true;
			}
		}

		// Token: 0x0600E4CD RID: 58573 RVA: 0x003B5651 File Offset: 0x003B3A51
		public void GetLimitTimeLeft(out int a_timeLeft, out bool a_bStartCountdown)
		{
			if (this.DeadTimestamp > 0)
			{
				a_timeLeft = this.DeadTimestamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
				a_bStartCountdown = true;
			}
			else
			{
				a_timeLeft = 0;
				a_bStartCountdown = false;
			}
		}

		// Token: 0x0600E4CE RID: 58574 RVA: 0x003B5680 File Offset: 0x003B3A80
		public bool CanRenewal()
		{
			return this.arrRenewals != null && this.arrRenewals.Count > 0;
		}

		// Token: 0x0600E4CF RID: 58575 RVA: 0x003B56A0 File Offset: 0x003B3AA0
		public int GetMaxUseTime()
		{
			int num = 0;
			if (this.useLimitType == ItemTable.eUseLimiteType.NOLIMITE)
			{
				num = ItemData.unlimitedUseTimes;
			}
			else if (this.useLimitType == ItemTable.eUseLimiteType.DAYLIMITE)
			{
				num = this.useLimitValue;
			}
			else if (this.useLimitType == ItemTable.eUseLimiteType.VIPLIMITE)
			{
				num = (int)Utility.GetCurVipLevelPrivilegeData(this.useLimitValue);
			}
			else if (this.useLimitType == ItemTable.eUseLimiteType.TEAMCOPYLIMITE)
			{
				num = this.useLimitValue;
			}
			else if (this.useLimitType == ItemTable.eUseLimiteType.WEEK6LIMITE)
			{
				num = this.useLimitValue;
			}
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E4D0 RID: 58576 RVA: 0x003B5730 File Offset: 0x003B3B30
		public int GetCurrentRemainUseTime()
		{
			int num = this.GetMaxUseTime() - this.GetCurrentUseTime();
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E4D1 RID: 58577 RVA: 0x003B5758 File Offset: 0x003B3B58
		public int GetCurrentWeekRemainUseTime()
		{
			int num = this.GetMaxUseTime() - this.GetCurrentWeekUseTime();
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E4D2 RID: 58578 RVA: 0x003B5780 File Offset: 0x003B3B80
		public int GetCurrentTeamCopyLimiteRemainUseTime()
		{
			int num = this.GetMaxUseTime() - this.GetCurrentTeamCopyLimiteUseTime();
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E4D3 RID: 58579 RVA: 0x003B57A5 File Offset: 0x003B3BA5
		public int GetCurrentWeekUseTime()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", CounterKeys.COUNTER_ITEM_WEEK_PRE, this.TableID));
		}

		// Token: 0x0600E4D4 RID: 58580 RVA: 0x003B57CB File Offset: 0x003B3BCB
		public int GetCurrentTeamCopyLimiteUseTime()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", CounterKeys.COUNTER_ITEM_WEEKUSE_PRE, this.TableID));
		}

		// Token: 0x0600E4D5 RID: 58581 RVA: 0x003B57F1 File Offset: 0x003B3BF1
		public int GetCurrentUseTime()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", CounterKeys.COUNTER_ITEM_DAYUSE_PRE, this.TableID));
		}

		// Token: 0x0600E4D6 RID: 58582 RVA: 0x003B5818 File Offset: 0x003B3C18
		public bool IsAssistEquip()
		{
			return this.TableData != null && (this.TableData.SubType == ItemTable.eSubType.ST_ASSIST_EQUIP || this.TableData.SubType == ItemTable.eSubType.ST_EARRINGS_EQUIP || this.TableData.SubType == ItemTable.eSubType.ST_MAGICSTONE_EQUIP);
		}

		// Token: 0x0600E4D7 RID: 58583 RVA: 0x003B5868 File Offset: 0x003B3C68
		public int GetBaseFourAttrStrengthenAddUpValue(int strengthen)
		{
			if (!this.IsAssistEquip())
			{
				return 0;
			}
			if (this.TableData == null)
			{
				return 0;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<AssistEqStrengFouerDimAddTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AssistEqStrengFouerDimAddTable assistEqStrengFouerDimAddTable = keyValuePair.Value as AssistEqStrengFouerDimAddTable;
					if (assistEqStrengFouerDimAddTable != null)
					{
						if (assistEqStrengFouerDimAddTable.Strengthen == this.strengthenLevel && assistEqStrengFouerDimAddTable.Color == (AssistEqStrengFouerDimAddTable.eColor)this.TableData.Color && assistEqStrengFouerDimAddTable.Color2 == this.TableData.Color2 && assistEqStrengFouerDimAddTable.Lv == this.TableData.NeedLevel)
						{
							return assistEqStrengFouerDimAddTable.StrengNum / 1000;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600E4D8 RID: 58584 RVA: 0x003B593C File Offset: 0x003B3D3C
		public List<GiftTable> GetGifts()
		{
			if (this.PackID > 0)
			{
				GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(this.PackID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					List<GiftTable> list = new List<GiftTable>();
					switch (tableItem.FilterType)
					{
					case GiftPackTable.eFilterType.None:
					case GiftPackTable.eFilterType.Random:
					case GiftPackTable.eFilterType.Custom:
						for (int i = 0; i < tableItem.Items.Count; i++)
						{
							GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(tableItem.Items[i], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								list.Add(tableItem2);
							}
						}
						break;
					case GiftPackTable.eFilterType.Job:
					case GiftPackTable.eFilterType.CustomWithJob:
						for (int j = 0; j < tableItem.Items.Count; j++)
						{
							GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(tableItem.Items[j], string.Empty, string.Empty);
							if (tableItem3 != null && tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
							{
								list.Add(tableItem3);
							}
						}
						break;
					}
					return list;
				}
			}
			return null;
		}

		// Token: 0x0600E4D9 RID: 58585 RVA: 0x003B5A6C File Offset: 0x003B3E6C
		public string GetItemTypeDesc()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.TypeName;
			}
			return string.Empty;
		}

		// Token: 0x0600E4DA RID: 58586 RVA: 0x003B5AA8 File Offset: 0x003B3EA8
		public string GetSubTypeDesc()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.SubTypeName;
			}
			return string.Empty;
		}

		// Token: 0x0600E4DB RID: 58587 RVA: 0x003B5AE4 File Offset: 0x003B3EE4
		public string GetThirdTypeDesc()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.ThirdTypeName;
			}
			return string.Empty;
		}

		// Token: 0x0600E4DC RID: 58588 RVA: 0x003B5B20 File Offset: 0x003B3F20
		public string GetBeadTypeDesc()
		{
			string result = string.Empty;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.BeadType == 2)
				{
					result = TR.Value("bead_colorFul_des");
				}
				else
				{
					result = TR.Value("bead_nomal_des");
				}
			}
			return result;
		}

		// Token: 0x0600E4DD RID: 58589 RVA: 0x003B5B7C File Offset: 0x003B3F7C
		public string GetWearSoltTypeDesc()
		{
			if (this.EquipWearSlotType != EEquipWearSlotType.EquipInvalid)
			{
				return TR.Value(this.EquipWearSlotType.GetDescription(true));
			}
			if (this.FashionWearSlotType != EFashionWearSlotType.Invalid)
			{
				return TR.Value(this.FashionWearSlotType.GetDescription(true));
			}
			return string.Empty;
		}

		// Token: 0x0600E4DE RID: 58590 RVA: 0x003B5BD4 File Offset: 0x003B3FD4
		public string GetEquipTypeDesc()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.Type != ItemTable.eType.EQUIP)
			{
				return string.Empty;
			}
			switch (tableItem.SubType)
			{
			case ItemTable.eSubType.WEAPON:
				return string.Format("{0}\t{1}", this.GetThirdTypeDesc(), this.GetWeaponAttackSpeedDesc());
			case ItemTable.eSubType.HEAD:
			case ItemTable.eSubType.CHEST:
			case ItemTable.eSubType.BELT:
			case ItemTable.eSubType.LEG:
			case ItemTable.eSubType.BOOT:
				return string.Format("{0}\t{1}", this.GetSubTypeDesc(), this.GetThirdTypeDesc());
			case ItemTable.eSubType.RING:
			case ItemTable.eSubType.NECKLASE:
			case ItemTable.eSubType.BRACELET:
				return string.Format("{0}", this.GetSubTypeDesc());
			default:
				return this.GetSubTypeDesc();
			}
		}

		// Token: 0x0600E4DF RID: 58591 RVA: 0x003B5C98 File Offset: 0x003B4098
		public string GetEquipGradeDesc()
		{
			if (!this.CheckEquipMagicstoneIsHasBasPro())
			{
				return string.Empty;
			}
			if (this.SubQuality <= 20)
			{
				return TR.Value("tip_grade_lower_most", this.SubQuality);
			}
			if (this.SubQuality <= 40)
			{
				return TR.Value("tip_grade_lower", this.SubQuality);
			}
			if (this.SubQuality <= 60)
			{
				return TR.Value("tip_grade_middle", this.SubQuality);
			}
			if (this.SubQuality <= 80)
			{
				return TR.Value("tip_grade_high", this.SubQuality);
			}
			if (this.SubQuality < 100)
			{
				return TR.Value("tip_grade_high_most", this.SubQuality);
			}
			return TR.Value("tip_grade_perfect", this.SubQuality);
		}

		// Token: 0x0600E4E0 RID: 58592 RVA: 0x003B5D7C File Offset: 0x003B417C
		public string GetQualityDesc()
		{
			ItemData.QualityInfo qualityInfo = this.GetQualityInfo();
			if (qualityInfo != null)
			{
				return string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, qualityInfo.Desc);
			}
			return string.Empty;
		}

		// Token: 0x0600E4E1 RID: 58593 RVA: 0x003B5DB4 File Offset: 0x003B41B4
		public string GetBindStateDesc()
		{
			string str = string.Empty;
			if (this.BindAttr == ItemTable.eOwner.NOTBIND)
			{
				str = TR.Value("tip_no_bind");
			}
			else if (this.BindAttr == ItemTable.eOwner.ROLEBIND)
			{
				if (this.Packing)
				{
					str = TR.Value("tip_packing");
				}
				else
				{
					str = TR.Value("tip_role_bind");
				}
			}
			else if (this.BindAttr == ItemTable.eOwner.ACCBIND)
			{
				if (this.Packing)
				{
					str = TR.Value("tip_packing");
				}
				else
				{
					str = TR.Value("tip_account_bind");
				}
			}
			if (this.HasTransfered)
			{
				str = TR.Value("tip_color_good", TR.Value("tip_equip_transfer"));
			}
			return str + string.Format(" {0}", this.GetRepackTimeDesc());
		}

		// Token: 0x0600E4E2 RID: 58594 RVA: 0x003B5E84 File Offset: 0x003B4284
		public string GetBindStateOwnerDesc()
		{
			return string.Empty;
		}

		// Token: 0x0600E4E3 RID: 58595 RVA: 0x003B5E8C File Offset: 0x003B428C
		public string GetRepackTimeDesc()
		{
			if (this.Type == ItemTable.eType.EQUIP || this.Type == ItemTable.eType.FUCKTITTLE)
			{
				if (this.RePackTime > 0)
				{
					return TR.Value("tip_repack_time", this.RePackTime);
				}
				if (this.RePackTime == 0)
				{
					return TR.Value("tip_no_repack_time");
				}
			}
			return string.Empty;
		}

		// Token: 0x0600E4E4 RID: 58596 RVA: 0x003B5EEE File Offset: 0x003B42EE
		public string GetMaxStackCountDesc()
		{
			if (this.MaxStackCount > 1)
			{
				return TR.Value("tip_max_stack_count", this.MaxStackCount);
			}
			return string.Empty;
		}

		// Token: 0x0600E4E5 RID: 58597 RVA: 0x003B5F17 File Offset: 0x003B4317
		public string GetUseTimePerDayDesc()
		{
			return string.Empty;
		}

		// Token: 0x0600E4E6 RID: 58598 RVA: 0x003B5F20 File Offset: 0x003B4320
		public string GetLevelLimitDesc()
		{
			string result = string.Empty;
			if (this.LevelLimit > 0)
			{
				string key = (this.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level) ? "tip_color_bad" : "tip_color_good";
				result = TR.Value(key, TR.Value("tip_level_limit", this.LevelLimit));
			}
			return result;
		}

		// Token: 0x0600E4E7 RID: 58599 RVA: 0x003B5F84 File Offset: 0x003B4384
		public string GetExpendableLimitDesc()
		{
			string result = string.Empty;
			if (this.LevelLimit > 0)
			{
				string key = (this.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level) ? "tip_color_bad" : "tip_color_good";
				result = TR.Value(key, TR.Value("equipforge_tip_level_limit", this.LevelLimit));
			}
			return result;
		}

		// Token: 0x0600E4E8 RID: 58600 RVA: 0x003B5FE8 File Offset: 0x003B43E8
		public string GetStoreDesc()
		{
			string result = string.Empty;
			if (this.CanStore())
			{
				result = TR.Value("can_put_storage");
			}
			else
			{
				result = TR.Value("cannot_put_storage");
			}
			return result;
		}

		// Token: 0x0600E4E9 RID: 58601 RVA: 0x003B6024 File Offset: 0x003B4424
		public string GetEquipUpgradeDesc()
		{
			string result = string.Empty;
			bool flag = DataManager<EquipUpgradeDataManager>.GetInstance().FindEquipUpgradeTableID(this.TableID);
			if (flag)
			{
				result = "可升级";
			}
			return result;
		}

		// Token: 0x0600E4EA RID: 58602 RVA: 0x003B6058 File Offset: 0x003B4458
		public string GetExperiencePillLevelLimitDesc()
		{
			string result = string.Empty;
			if (this.LevelLimit > 0)
			{
				string key = (this.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level || (int)DataManager<PlayerBaseData>.GetInstance().Level > this.MaxLevelLimit) ? "tip_color_bad" : "tip_color_good";
				if (this.LevelLimit == this.MaxLevelLimit)
				{
					result = TR.Value(key, TR.Value("tip_level_limit_2", this.LevelLimit));
				}
				else
				{
					result = TR.Value(key, TR.Value("tip_level_limit_maxlimit", this.LevelLimit, this.MaxLevelLimit));
				}
			}
			return result;
		}

		// Token: 0x0600E4EB RID: 58603 RVA: 0x003B610B File Offset: 0x003B450B
		public string GetRateScoreDesc()
		{
			if (this.finalRateScore >= 0)
			{
				return TR.Value("tip_rate_score", this.finalRateScore);
			}
			return string.Empty;
		}

		// Token: 0x0600E4EC RID: 58604 RVA: 0x003B6134 File Offset: 0x003B4534
		public string GetItemAuctionCoolTimeDesc()
		{
			if (this.AuctionCoolTimeStamp <= 0U || this.AuctionCoolTimeStamp <= DataManager<TimeManager>.GetInstance().GetServerTime())
			{
				return string.Empty;
			}
			string coolDownTimeByDayHour = CountDownTimeUtility.GetCoolDownTimeByDayHour(this.AuctionCoolTimeStamp, DataManager<TimeManager>.GetInstance().GetServerTime());
			return string.Format("<color={0}>{1}</color>", TR.Value("Bead_red_color"), TR.Value("auction_new_item_tip_cool_in_cd_time", coolDownTimeByDayHour));
		}

		// Token: 0x0600E4ED RID: 58605 RVA: 0x003B61A0 File Offset: 0x003B45A0
		public string GetTransactionNumberDesc()
		{
			string result = string.Empty;
			bool flag = ItemDataUtility.IsItemTradeLimitBuyNumber(this);
			if (flag)
			{
				result = string.Format("可交易次数:{0}", ItemDataUtility.GetItemTradeLeftTime(this));
			}
			return result;
		}

		// Token: 0x0600E4EE RID: 58606 RVA: 0x003B61D7 File Offset: 0x003B45D7
		public string GetFasionFreeTimesDesc()
		{
			return TR.Value("fashion_free_times_tips", (this.FashionFreeTimes <= 0) ? 1 : 0);
		}

		// Token: 0x0600E4EF RID: 58607 RVA: 0x003B61FC File Offset: 0x003B45FC
		public string GetOccupationLimitDesc()
		{
			string text = string.Empty;
			if (this.OccupationLimit.Count > 0)
			{
				string key = (!this.IsOccupationFit()) ? "tip_color_bad" : "tip_color_good";
				if (this.OccupationLimit.Contains(-1))
				{
					text = TR.Value(key, TR.Value("tip_job_limit_need_any_transfer"));
				}
				else
				{
					for (int i = 0; i < this.OccupationLimit.Count; i++)
					{
						if (this.OccupationLimit[i] < 0)
						{
							JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(-this.OccupationLimit[i], string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (!string.IsNullOrEmpty(text))
								{
									text += "、";
								}
								text += TR.Value("tip_job_limit_need_transfer", tableItem.Name);
							}
						}
						else
						{
							JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>(this.OccupationLimit[i], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (!string.IsNullOrEmpty(text))
								{
									text += "、";
								}
								text += tableItem2.Name;
							}
						}
					}
					text = TR.Value(key, TR.Value("tip_job_limit", text));
				}
			}
			return text;
		}

		// Token: 0x0600E4F0 RID: 58608 RVA: 0x003B634C File Offset: 0x003B474C
		public string GetRemainUseNumberDesc()
		{
			string result = string.Empty;
			if (this.TableData.UseLinmit > 0)
			{
				int count = DataManager<CountDataManager>.GetInstance().GetCount(string.Format("item_fly_hell_gift_{0}", this.TableData.ID));
				int num = this.TableData.UseLinmit - count;
				result = string.Format("剩余使用次数:{0}", num);
			}
			return result;
		}

		// Token: 0x0600E4F1 RID: 58609 RVA: 0x003B63B8 File Offset: 0x003B47B8
		public string GetPriceDesc()
		{
			if (this.CanSell)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.PriceItemID);
				if (commonItemTableDataByID != null)
				{
					return TR.Value("tip_price", this.Price, commonItemTableDataByID.Name);
				}
			}
			return string.Empty;
		}

		// Token: 0x0600E4F2 RID: 58610 RVA: 0x003B6408 File Offset: 0x003B4808
		public string GetUseTimeDesc()
		{
			if (this.GetMaxUseTime() == ItemData.unlimitedUseTimes)
			{
				return string.Empty;
			}
			if (this.useLimitType == ItemTable.eUseLimiteType.TEAMCOPYLIMITE)
			{
				return TR.Value("tip_use_time_week", this.GetCurrentTeamCopyLimiteRemainUseTime(), this.GetMaxUseTime());
			}
			if (this.useLimitType == ItemTable.eUseLimiteType.WEEK6LIMITE)
			{
				return TR.Value("tip_use_time_week", this.GetCurrentWeekRemainUseTime(), this.GetMaxUseTime());
			}
			return TR.Value("tip_use_time", this.GetCurrentRemainUseTime(), this.GetMaxUseTime());
		}

		// Token: 0x0600E4F3 RID: 58611 RVA: 0x003B64A8 File Offset: 0x003B48A8
		public string GetTimeLeftDescByDay()
		{
			int num;
			bool flag;
			this.GetTimeLeft(out num, out flag);
			if (num > 0)
			{
				if (num > 86400)
				{
					int num2 = num / 86400;
					return string.Format("{0}天", num2);
				}
				if (num > 3600)
				{
					int num3 = num / 3600;
					return string.Format("{0}小时", num3);
				}
				if (num > 60)
				{
					int num4 = num / 60;
					return string.Format("{0}分", num4);
				}
				return string.Format("{0}秒", num);
			}
			else
			{
				if (flag)
				{
					return TR.Value("tip_color_bad", TR.Value("tip_time_left_invalid"));
				}
				return string.Empty;
			}
		}

		// Token: 0x0600E4F4 RID: 58612 RVA: 0x003B6560 File Offset: 0x003B4960
		public string GetTimeLeftDesc()
		{
			int num;
			bool flag;
			this.GetTimeLeft(out num, out flag);
			if (num > 0)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = num % 60;
				int num6 = num / 60;
				if (num6 > 0)
				{
					num2 = num6 % 60;
					num6 /= 60;
					if (num6 > 0)
					{
						num3 = num6 % 24;
						num4 = num6 / 24;
					}
				}
				string text = string.Empty;
				if (num4 > 0)
				{
					text += string.Format("{0}天", num4);
				}
				if (num3 > 0)
				{
					text += string.Format("{0}小时", num3);
				}
				if (num2 > 0)
				{
					text += string.Format("{0}分", num2);
				}
				if (num5 > 0)
				{
					text += string.Format("{0}秒", num5);
				}
				string arg = TR.Value("tip_time_left", text);
				string key = (num <= 86400) ? "tip_color_bad" : "tip_color_normal";
				return TR.Value(key, arg);
			}
			if (flag)
			{
				return TR.Value("tip_color_bad", TR.Value("tip_time_left_invalid"));
			}
			return string.Empty;
		}

		// Token: 0x0600E4F5 RID: 58613 RVA: 0x003B66A0 File Offset: 0x003B4AA0
		public string GetDeadTimestampDesc()
		{
			if (this.DeadTimestamp <= 0)
			{
				return string.Empty;
			}
			int num;
			bool flag;
			this.GetTimeLeft(out num, out flag);
			if (flag && num <= 0)
			{
				int num2 = this.DeadTimestamp + Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(231, string.Empty, string.Empty).Value * 86400;
				return TR.Value("tip_color_gray2", TR.Value("tip_item_delete_timestrmp", TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)num2).ToString(TR.Value("tip_timestrmp"))));
			}
			return TR.Value("tip_color_gray2", TR.Value("tip_item_dead_timestrmp", TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)this.DeadTimestamp).ToString(TR.Value("tip_timestrmp"))));
		}

		// Token: 0x0600E4F6 RID: 58614 RVA: 0x003B6798 File Offset: 0x003B4B98
		public string GetCoolTimeDesc()
		{
			if (this.CD > 0)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = this.CD % 60;
				int num5 = this.CD / 60;
				if (num5 > 0)
				{
					num = num5 % 60;
					num5 /= 60;
					if (num5 > 0)
					{
						num2 = num5 % 24;
						num3 = num5 / 24;
					}
				}
				string text = string.Empty;
				if (num3 > 0)
				{
					text += string.Format("{0}天", num3);
				}
				if (num2 > 0)
				{
					text += string.Format("{0}时", num2);
				}
				if (num > 0)
				{
					text += string.Format("{0}分", num);
				}
				if (num4 > 0)
				{
					text += string.Format("{0}秒", num4);
				}
				return TR.Value("tip_cool_time", text);
			}
			return string.Empty;
		}

		// Token: 0x0600E4F7 RID: 58615 RVA: 0x003B6890 File Offset: 0x003B4C90
		public float _GetGetStrengthenDescs(EEquipProp eEEquipProp)
		{
			float num = (float)this.BaseProp.props[(int)eEEquipProp] * 1f / (float)EquipPropRate.propRates[(int)eEEquipProp];
			if (eEEquipProp == EEquipProp.IgnorePhysicsDefenseRate || eEEquipProp == EEquipProp.IgnoreMagicDefenseRate)
			{
				num = num * 100f + 0.5f;
			}
			return num;
		}

		// Token: 0x0600E4F8 RID: 58616 RVA: 0x003B6900 File Offset: 0x003B4D00
		public int ConvertAttrByValue(EEquipProp eEEquipProp, int iValue)
		{
			float num = (float)iValue * 1f / (float)EquipPropRate.propRates[(int)eEEquipProp];
			return Mathf.FloorToInt(num);
		}

		// Token: 0x0600E4F9 RID: 58617 RVA: 0x003B6938 File Offset: 0x003B4D38
		public float ConvertAttrByValue(EEquipProp eEEquipProp, float iValue)
		{
			return iValue / (float)EquipPropRate.propRates[(int)eEEquipProp];
		}

		// Token: 0x0600E4FA RID: 58618 RVA: 0x003B6960 File Offset: 0x003B4D60
		public string GetBaseAttrStrengthenDesc(EEquipProp eEquipProp)
		{
			if (eEquipProp != EEquipProp.Strenth && eEquipProp != EEquipProp.Intellect && eEquipProp != EEquipProp.Spirit && eEquipProp != EEquipProp.Stamina)
			{
				return string.Empty;
			}
			string result = string.Empty;
			int baseFourAttrStrengthenAddUpValue = this.GetBaseFourAttrStrengthenAddUpValue(this.strengthenLevel);
			int nValue = this.BaseProp.props[(int)eEquipProp];
			this.BaseProp.props[(int)eEquipProp] = baseFourAttrStrengthenAddUpValue * EquipPropRate.propRates[(int)eEquipProp];
			string propFormatStr = this.BaseProp.GetPropFormatStr(eEquipProp, -1);
			if (!string.IsNullOrEmpty(propFormatStr))
			{
				if (this.EquipType == EEquipType.ET_REDMARK)
				{
					result = TR.Value("tip_growth_effect", this.StrengthenLevel, propFormatStr);
				}
				else if (this.EquipType == EEquipType.ET_COMMON)
				{
					result = TR.Value("tip_strengthen_effect", this.StrengthenLevel, propFormatStr);
				}
			}
			this.BaseProp.props[(int)eEquipProp] = nValue;
			return result;
		}

		// Token: 0x0600E4FB RID: 58619 RVA: 0x003B6A70 File Offset: 0x003B4E70
		public string GetBreathEquipDesc()
		{
			string result = string.Empty;
			if (this.EquipType == EEquipType.ET_BREATH)
			{
				result = TR.Value("tip_growth_breath_desc");
			}
			return result;
		}

		// Token: 0x0600E4FC RID: 58620 RVA: 0x003B6A9C File Offset: 0x003B4E9C
		public List<string> GetStrengthenDescs()
		{
			List<string> list = new List<string>();
			if (this.StrengthenLevel > 0 || this.EquipType == EEquipType.ET_REDMARK)
			{
				if (this.EquipType == EEquipType.ET_REDMARK && this.StrengthenLevel >= 0)
				{
					string arg = string.Format("{0}+{1}", DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.GrowthAttrType), this.GrowthAttrNum);
					list.Add(TR.Value("growth_tip_effect_decs", this.StrengthenLevel, arg));
				}
				string text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnorePhysicsAttack, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnorePhysicsAttackRate, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnoreMagicAttack, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnoreMagicAttackRate, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IngoreIndependence, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnorePhysicsDefense, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnorePhysicsDefenseRate, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnoreMagicDefense, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				text = this.BaseProp.GetPropFormatStr(EEquipProp.IgnoreMagicDefenseRate, -1);
				if (!string.IsNullOrEmpty(text))
				{
					if (this.EquipType == EEquipType.ET_REDMARK)
					{
						list.Add(TR.Value("tip_growth_effect", this.StrengthenLevel, text));
					}
					else if (this.EquipType == EEquipType.ET_COMMON)
					{
						list.Add(TR.Value("tip_strengthen_effect", this.StrengthenLevel, text));
					}
				}
				if (this.IsAssistEquip() && this.StrengthenLevel > 0)
				{
					text = this.GetBaseAttrStrengthenDesc(EEquipProp.Strenth);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
					text = this.GetBaseAttrStrengthenDesc(EEquipProp.Intellect);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
					text = this.GetBaseAttrStrengthenDesc(EEquipProp.Spirit);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
					text = this.GetBaseAttrStrengthenDesc(EEquipProp.Stamina);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
			return list;
		}

		// Token: 0x0600E4FD RID: 58621 RVA: 0x003B6F80 File Offset: 0x003B5380
		public List<string> GetFourAttrAndResistMagicDescs()
		{
			List<string> fourAttrDescs = this.GetFourAttrDescs();
			string resistMagciDescs = this.GetResistMagciDescs();
			if (!string.IsNullOrEmpty(resistMagciDescs))
			{
				fourAttrDescs.Add(resistMagciDescs);
			}
			return fourAttrDescs;
		}

		// Token: 0x0600E4FE RID: 58622 RVA: 0x003B6FB0 File Offset: 0x003B53B0
		public string GetResistMagciDescs()
		{
			int itemResistMagicValue = DataManager<ItemDataManager>.GetInstance().GetItemResistMagicValue(this.TableID);
			if (itemResistMagicValue <= 0)
			{
				return null;
			}
			return TR.Value("resist_magic_title") + "+" + itemResistMagicValue;
		}

		// Token: 0x0600E4FF RID: 58623 RVA: 0x003B6FF4 File Offset: 0x003B53F4
		public List<string> GetFourAttrDescs()
		{
			List<string> list = new List<string>();
			int nValue = 0;
			int nValue2 = 0;
			int nValue3 = 0;
			int nValue4 = 0;
			if (this.IsAssistEquip() && this.strengthenLevel > 0)
			{
				nValue = this.BaseProp.props[4];
				nValue2 = this.BaseProp.props[5];
				nValue3 = this.BaseProp.props[6];
				nValue4 = this.BaseProp.props[7];
				int baseFourAttrStrengthenAddUpValue = this.GetBaseFourAttrStrengthenAddUpValue(this.strengthenLevel);
				CrypticInt32[] props = this.BaseProp.props;
				int num = 4;
				props[num] -= baseFourAttrStrengthenAddUpValue * EquipPropRate.propRates[4];
				CrypticInt32[] props2 = this.BaseProp.props;
				int num2 = 5;
				props2[num2] -= baseFourAttrStrengthenAddUpValue * EquipPropRate.propRates[5];
				CrypticInt32[] props3 = this.BaseProp.props;
				int num3 = 6;
				props3[num3] -= baseFourAttrStrengthenAddUpValue * EquipPropRate.propRates[6];
				CrypticInt32[] props4 = this.BaseProp.props;
				int num4 = 7;
				props4[num4] -= baseFourAttrStrengthenAddUpValue * EquipPropRate.propRates[7];
			}
			if (this.BaseProp.props[4] > 0)
			{
				string propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.Strenth, -1);
				if (!string.IsNullOrEmpty(propFormatStr))
				{
					list.Add(propFormatStr);
				}
			}
			if (this.BaseProp.props[5] > 0)
			{
				string propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.Intellect, -1);
				if (!string.IsNullOrEmpty(propFormatStr))
				{
					list.Add(propFormatStr);
				}
			}
			if (this.BaseProp.props[6] > 0)
			{
				string propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.Spirit, -1);
				if (!string.IsNullOrEmpty(propFormatStr))
				{
					list.Add(propFormatStr);
				}
			}
			if (this.BaseProp.props[7] > 0)
			{
				string propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.Stamina, -1);
				if (!string.IsNullOrEmpty(propFormatStr))
				{
					list.Add(propFormatStr);
				}
			}
			if (this.IsAssistEquip() && this.strengthenLevel > 0)
			{
				this.BaseProp.props[4] = nValue;
				this.BaseProp.props[5] = nValue2;
				this.BaseProp.props[6] = nValue3;
				this.BaseProp.props[7] = nValue4;
			}
			return list;
		}

		// Token: 0x0600E500 RID: 58624 RVA: 0x003B733C File Offset: 0x003B573C
		public string GetWeaponAttackSpeedDesc()
		{
			string result = string.Empty;
			if (this.EquipWearSlotType == EEquipWearSlotType.EquipWeapon)
			{
				result = TR.Value("tip_atk_speed_format", (float)(1010 + this.BaseAttackSpeedRate) / 1000f);
			}
			return result;
		}

		// Token: 0x0600E501 RID: 58625 RVA: 0x003B7380 File Offset: 0x003B5780
		public List<string> GetSkillMPAndCDDescs()
		{
			List<string> list = new List<string>();
			string propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.PhysicsSkillMPChange, -1);
			if (!string.IsNullOrEmpty(propFormatStr))
			{
				list.Add(propFormatStr);
			}
			propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.PhysicsSkillCDChange, -1);
			if (!string.IsNullOrEmpty(propFormatStr))
			{
				list.Add(propFormatStr);
			}
			propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.MagicSkillMPChange, -1);
			if (!string.IsNullOrEmpty(propFormatStr))
			{
				list.Add(propFormatStr);
			}
			propFormatStr = this.BaseProp.GetPropFormatStr(EEquipProp.MagicSkillCDChange, -1);
			if (!string.IsNullOrEmpty(propFormatStr))
			{
				list.Add(propFormatStr);
			}
			return list;
		}

		// Token: 0x0600E502 RID: 58626 RVA: 0x003B7417 File Offset: 0x003B5817
		public string GetBeadPartDesc()
		{
			if (this.SubType == 54)
			{
				return TR.Value("tip_bead_part", DataManager<BeadCardManager>.GetInstance().GetCondition(this.TableID));
			}
			return string.Empty;
		}

		// Token: 0x0600E503 RID: 58627 RVA: 0x003B7448 File Offset: 0x003B5848
		public string GetBeadDescs()
		{
			string text = string.Empty;
			if (this.PreciousBeadMountHole == null)
			{
				return text;
			}
			for (int i = 0; i < this.PreciousBeadMountHole.Length; i++)
			{
				PrecBead precBead = this.PreciousBeadMountHole[i];
				if (precBead != null)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(precBead.preciousBeadId);
					if (commonItemTableDataByID != null)
					{
						text = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(precBead.preciousBeadId, false) + string.Format("（宝珠：{0}）", commonItemTableDataByID.GetColorName(string.Empty, false));
						if (precBead.randomBuffId > 0)
						{
							text += string.Format("\n附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(precBead.randomBuffId));
						}
						break;
					}
				}
			}
			return text;
		}

		// Token: 0x0600E504 RID: 58628 RVA: 0x003B7514 File Offset: 0x003B5914
		public string GetBeadNextLevelArrtDescs()
		{
			string result = string.Empty;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.NextLevPrecbeadID != string.Empty)
			{
				int num = 0;
				if (int.TryParse(tableItem.NextLevPrecbeadID, out num) && num > 0)
				{
					result = "下一级效果:" + DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(num, false);
				}
			}
			return result;
		}

		// Token: 0x0600E505 RID: 58629 RVA: 0x003B7590 File Offset: 0x003B5990
		public string GetBeadAppendArrtDesce()
		{
			string result = string.Empty;
			if (this.BeadAdditiveAttributeBuffID > 0)
			{
				result = string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.BeadAdditiveAttributeBuffID));
			}
			return result;
		}

		// Token: 0x0600E506 RID: 58630 RVA: 0x003B75CC File Offset: 0x003B59CC
		public string GetEnchantmentCardUpgradeDesce()
		{
			string result = string.Empty;
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.MaxLevel > 0)
				{
					result = string.Format("<color={0}>升级({1}/{2})</color>", TR.Value("Bead_White_color"), this.mPrecEnchantmentCard.iEnchantmentCardLevel, tableItem.MaxLevel);
				}
				else
				{
					result = string.Format("<color={0}>{1}</color>", TR.Value("Bead_red_color"), TR.Value("Bead_DoNot_Upgrade"));
				}
			}
			return result;
		}

		// Token: 0x0600E507 RID: 58631 RVA: 0x003B7664 File Offset: 0x003B5A64
		public string GetBeadUpgradeDesce()
		{
			int num = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.BeadLevel;
			}
			string result = string.Empty;
			BeadTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.TableID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				if (tableItem2.Level == 1 && tableItem2.NextLevPrecbeadID == string.Empty)
				{
					result = string.Format("<color={0}>{1}</color>", TR.Value("Bead_red_color"), TR.Value("Bead_DoNot_Upgrade"));
				}
				else
				{
					result = string.Format("<color={0}>升级({1}/{2})</color>", TR.Value("Bead_Orange_color"), (tableItem2.Level - 1).ToString(), (num - 1).ToString());
				}
			}
			return result;
		}

		// Token: 0x0600E508 RID: 58632 RVA: 0x003B7746 File Offset: 0x003B5B46
		public string GetMagicPartDesc()
		{
			if (this.SubType == 25)
			{
				return TR.Value("tip_magic_part", DataManager<EnchantmentsCardManager>.GetInstance().GetCondition(this.TableID));
			}
			return string.Empty;
		}

		// Token: 0x0600E509 RID: 58633 RVA: 0x003B7778 File Offset: 0x003B5B78
		public string GetMagicDescs()
		{
			if (this.mPrecEnchantmentCard == null)
			{
				return string.Empty;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mPrecEnchantmentCard.iEnchantmentCardID, 100, 0);
			if (itemData == null)
			{
				return string.Empty;
			}
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string text = string.Empty;
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					string arg = string.Empty;
					if (this.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
					{
						arg = string.Format("+{0}", this.mPrecEnchantmentCard.iEnchantmentCardLevel);
					}
					text = TR.Value("tip_magic_attribute_desc", itemData.GetColorName(string.Empty, false), arg, itemData.GetQualityInfo().ColStr);
				}
				StringBuilder stringBuilder = new StringBuilder(128);
				bool flag = true;
				List<string> propsFormatStr = this.MagicProp.GetPropsFormatStr();
				for (int i = 0; i < propsFormatStr.Count; i++)
				{
					if (flag)
					{
						stringBuilder = stringBuilder.AppendFormat("<color={1}>{0}</color>", propsFormatStr[i], TR.Value("enchant_attribute_color"));
						flag = false;
					}
					else
					{
						stringBuilder = stringBuilder.AppendFormat("\n<color={1}>{0}</color>", propsFormatStr[i], TR.Value("enchant_attribute_color"));
					}
				}
				if (tableItem.SkillAttributes.Length > 0)
				{
					string[] array = tableItem.SkillAttributes.Split(new char[]
					{
						'\r',
						'\n'
					});
					for (int j = 0; j < array.Length; j++)
					{
						if (flag)
						{
							stringBuilder = stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), array[j]);
							flag = false;
						}
						else
						{
							stringBuilder = stringBuilder.AppendFormat("\n<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), array[j]);
						}
					}
				}
				if (this.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
				{
					BuffInfoTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(tableItem.UpBuffID[this.mPrecEnchantmentCard.iEnchantmentCardLevel - 1], string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.Description.Count > 0)
					{
						if (flag)
						{
							stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), tableItem3.Description[0]);
						}
						else
						{
							stringBuilder.AppendFormat("\n<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), tableItem3.Description[0]);
						}
					}
				}
				else
				{
					for (int k = 0; k < tableItem.BuffID.Count; k++)
					{
						BuffInfoTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(tableItem.BuffID[k], string.Empty, string.Empty);
						if (tableItem4 != null && tableItem4.Description.Count > 0)
						{
							if (flag)
							{
								stringBuilder.AppendFormat("<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), tableItem4.Description[0]);
								flag = false;
							}
							else
							{
								stringBuilder.AppendFormat("\n<color={0}>{1}</color>", TR.Value("enchant_attribute_color"), tableItem4.Description[0]);
							}
						}
					}
				}
				return stringBuilder.ToString();
			}
			return string.Empty;
		}

		// Token: 0x0600E50A RID: 58634 RVA: 0x003B7AED File Offset: 0x003B5EED
		public string InscriptionMosaicSlot()
		{
			if (this.SubType == 117)
			{
				return TR.Value("tip_inscription_part", DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionSlotDescription(this.TableID));
			}
			return string.Empty;
		}

		// Token: 0x0600E50B RID: 58635 RVA: 0x003B7B1C File Offset: 0x003B5F1C
		public string GetInscriptionApplicableToProfessionalDescription()
		{
			if (this.SubType == 117)
			{
				return DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionApplicableToProfessionalDescription(this.TableID);
			}
			return string.Empty;
		}

		// Token: 0x0600E50C RID: 58636 RVA: 0x003B7B44 File Offset: 0x003B5F44
		public string GetInscriptionAttrDesc()
		{
			string result = string.Empty;
			if (this.SubType == 117)
			{
				result = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionAttributesDesc(this.TableID, true);
			}
			return result;
		}

		// Token: 0x0600E50D RID: 58637 RVA: 0x003B7B77 File Offset: 0x003B5F77
		public List<string> GetRandomAttrDescs()
		{
			if (this.RandamProp == null)
			{
				return null;
			}
			return this.RandamProp.GetPropsFormatStr();
		}

		// Token: 0x0600E50E RID: 58638 RVA: 0x003B7B94 File Offset: 0x003B5F94
		public List<string> GetAttachAttrDescs()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < ItemData.ms_attachAttrIDs.Length; i++)
			{
				if (ItemData.ms_attachAttrIDs[i] == EEquipProp.AbormalResists)
				{
					for (int j = 0; j < 13; j++)
					{
						string propFormatStr = this.BaseProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], j);
						if (!string.IsNullOrEmpty(propFormatStr))
						{
							list.Add(propFormatStr);
						}
					}
				}
				else if (ItemData.ms_attachAttrIDs[i] == EEquipProp.Elements)
				{
					for (int k = 0; k < 4; k++)
					{
						string propFormatStr = this.BaseProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], k);
						if (!string.IsNullOrEmpty(propFormatStr))
						{
							list.Add(propFormatStr);
						}
					}
				}
				else
				{
					string propFormatStr = this.BaseProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], -1);
					if (!string.IsNullOrEmpty(propFormatStr))
					{
						list.Add(propFormatStr);
					}
				}
			}
			return list;
		}

		// Token: 0x0600E50F RID: 58639 RVA: 0x003B7C84 File Offset: 0x003B6084
		public string GetWeaponAttackAttributeDescs()
		{
			string text = "无";
			List<string> list = new List<string>();
			for (int i = 0; i < ItemData.ms_attachAttrIDs.Length; i++)
			{
				if (ItemData.ms_attachAttrIDs[i] == EEquipProp.Elements)
				{
					for (int j = 0; j < 4; j++)
					{
						string propFormatStr = this.BaseProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], j);
						if (!string.IsNullOrEmpty(propFormatStr))
						{
							list.Add(propFormatStr);
						}
						string propFormatStr2 = this.MagicProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], j);
						if (!string.IsNullOrEmpty(propFormatStr2))
						{
							if (!list.Contains(propFormatStr2))
							{
								list.Add(propFormatStr2);
							}
						}
						string propFormatStr3 = this.BeadProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], j);
						if (!string.IsNullOrEmpty(propFormatStr3))
						{
							if (!list.Contains(propFormatStr3))
							{
								list.Add(propFormatStr3);
							}
						}
						string propFormatStr4 = this.IncriptionProp.GetPropFormatStr(ItemData.ms_attachAttrIDs[i], j);
						if (!string.IsNullOrEmpty(propFormatStr4))
						{
							if (!list.Contains(propFormatStr4))
							{
								list.Add(propFormatStr4);
							}
						}
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				string text2 = list[k].Substring(0, 3);
				if (k == 0)
				{
					text = text2;
				}
				else
				{
					text += string.Format("、{0}", text2);
				}
			}
			return text;
		}

		// Token: 0x0600E510 RID: 58640 RVA: 0x003B7E00 File Offset: 0x003B6200
		public List<string> GetComplexAttrDescs()
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(this.EffectDescription))
			{
				list.Add(TR.Value("tip_color_gray1", this.EffectDescription));
			}
			List<EquipProp.BuffSkillInfo> buffSkillInfos = this.BaseProp.GetBuffSkillInfos();
			if (buffSkillInfos != null)
			{
				for (int i = 0; i < buffSkillInfos.Count; i++)
				{
					string text = string.Empty;
					EquipProp.BuffSkillInfo buffSkillInfo = buffSkillInfos[i];
					bool flag = DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(buffSkillInfo.jobID);
					text += TR.Value((!flag) ? "color_grey" : "color_orange", string.Format("[{0}]", buffSkillInfo.jobName));
					for (int j = 0; j < buffSkillInfo.skillDescs.Count; j++)
					{
						string text2 = buffSkillInfo.skillDescs[j];
						if (!string.IsNullOrEmpty(text2))
						{
							text += "\n";
							text += TR.Value((!flag) ? "color_grey" : "color_green", text2);
						}
					}
					if (text.Length > 0)
					{
						list.Add(text);
					}
				}
			}
			List<string> buffCommonDescs = this.BaseProp.GetBuffCommonDescs();
			if (buffCommonDescs != null)
			{
				for (int k = 0; k < buffCommonDescs.Count; k++)
				{
					string text2 = buffCommonDescs[k];
					if (!string.IsNullOrEmpty(text2))
					{
						list.Add(TR.Value("color_green", text2));
					}
				}
			}
			if (!string.IsNullOrEmpty(this.BaseProp.attachBuffDesc))
			{
				list.Add(TR.Value("color_green", this.BaseProp.attachBuffDesc));
			}
			List<string> mechanismDescs = this.BaseProp.GetMechanismDescs();
			if (mechanismDescs != null)
			{
				for (int l = 0; l < mechanismDescs.Count; l++)
				{
					string text2 = mechanismDescs[l];
					if (!string.IsNullOrEmpty(text2))
					{
						list.Add(TR.Value("color_green", text2));
					}
				}
			}
			if (!string.IsNullOrEmpty(this.BaseProp.attachMechanismDesc))
			{
				list.Add(TR.Value("color_green", this.BaseProp.attachMechanismDesc));
			}
			return list;
		}

		// Token: 0x0600E511 RID: 58641 RVA: 0x003B8050 File Offset: 0x003B6450
		public List<string> GetSepcialComplexAtrrDescs()
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(this.EffectDescription))
			{
				list.Add(TR.Value("tip_color_gray1", this.EffectDescription));
			}
			List<string> buffCommonDescs = this.BaseProp.GetBuffCommonDescs();
			if (buffCommonDescs != null)
			{
				for (int i = 0; i < buffCommonDescs.Count; i++)
				{
					string text = buffCommonDescs[i];
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(TR.Value("color_green", text));
					}
				}
			}
			if (!string.IsNullOrEmpty(this.BaseProp.attachBuffDesc))
			{
				list.Add(TR.Value("color_green", this.BaseProp.attachBuffDesc));
			}
			List<string> mechanismDescs = this.BaseProp.GetMechanismDescs();
			if (mechanismDescs != null)
			{
				for (int j = 0; j < mechanismDescs.Count; j++)
				{
					string text = mechanismDescs[j];
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(TR.Value("color_green", text));
					}
				}
			}
			if (!string.IsNullOrEmpty(this.BaseProp.attachMechanismDesc))
			{
				list.Add(TR.Value("color_green", this.BaseProp.attachMechanismDesc));
			}
			return list;
		}

		// Token: 0x0600E512 RID: 58642 RVA: 0x003B8190 File Offset: 0x003B6590
		public List<string> GetMasterAttrDescs(bool needHead = true)
		{
			EquipProp equipMasterProp = DataManager<EquipMasterDataManager>.GetInstance().GetEquipMasterProp(DataManager<PlayerBaseData>.GetInstance().JobTableID, this);
			if (equipMasterProp != null)
			{
				List<string> propsFormatStr = equipMasterProp.GetPropsFormatStr();
				if (needHead)
				{
					if (DataManager<EquipMasterDataManager>.GetInstance().IsMaster(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType))
					{
						string item = TR.Value("color_yellow", string.Format("[{0}]", DataManager<EquipMasterDataManager>.GetInstance().GetJobMasterDesc(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType).title));
						propsFormatStr.Insert(0, item);
					}
					else
					{
						string item2 = TR.Value("color_black_white", string.Format("[{0}]", DataManager<EquipMasterDataManager>.GetInstance().GetJobMasterDesc(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)this.ThirdType).title));
						propsFormatStr.Insert(0, item2);
					}
				}
				return propsFormatStr;
			}
			return new List<string>();
		}

		// Token: 0x0600E513 RID: 58643 RVA: 0x003B8269 File Offset: 0x003B6669
		public string GetDescription()
		{
			if (string.IsNullOrEmpty(this.Description))
			{
				return string.Empty;
			}
			return TR.Value("tip_color_gray2", this.Description);
		}

		// Token: 0x0600E514 RID: 58644 RVA: 0x003B8291 File Offset: 0x003B6691
		public string GetSourceDescription()
		{
			if (string.IsNullOrEmpty(this.SourceDescription))
			{
				return string.Empty;
			}
			return TR.Value("tip_color_gray3", this.SourceDescription);
		}

		// Token: 0x0600E515 RID: 58645 RVA: 0x003B82BC File Offset: 0x003B66BC
		public ItemData SetStrengthenAttr(ItemData itemData)
		{
			ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(itemData.TableID, false);
			itemStrengthAttribute.SetStrength(itemData.StrengthenLevel, false, 0);
			ItemData itemData2 = itemStrengthAttribute.GetItemData();
			itemData.BaseProp.props[39] = itemData2.BaseProp.props[39];
			itemData.BaseProp.props[37] = itemData2.BaseProp.props[37];
			itemData.BaseProp.props[40] = itemData2.BaseProp.props[40];
			itemData.BaseProp.props[38] = itemData2.BaseProp.props[38];
			itemData.BaseProp.props[60] = itemData2.BaseProp.props[60];
			itemData.BaseProp.props[43] = itemData2.BaseProp.props[43];
			itemData.BaseProp.props[41] = itemData2.BaseProp.props[41];
			itemData.BaseProp.props[44] = itemData2.BaseProp.props[44];
			itemData.BaseProp.props[42] = itemData2.BaseProp.props[42];
			return itemData;
		}

		// Token: 0x0600E516 RID: 58646 RVA: 0x003B848C File Offset: 0x003B688C
		public bool CheckEquipmentIsCanPutAccountWarehouse()
		{
			if (this.mInscriptionHoles == null)
			{
				return true;
			}
			bool flag = false;
			for (int i = 0; i < this.mInscriptionHoles.Count; i++)
			{
				InscriptionHoleData inscriptionHoleData = this.mInscriptionHoles[i];
				if (inscriptionHoleData != null)
				{
					if (inscriptionHoleData.InscriptionId > 0)
					{
						flag = true;
						break;
					}
				}
			}
			return !flag;
		}

		// Token: 0x0600E517 RID: 58647 RVA: 0x003B84F8 File Offset: 0x003B68F8
		public bool CheckEquipIsMosaicInscription()
		{
			if (this.InscriptionHoles == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < this.InscriptionHoles.Count; i++)
			{
				InscriptionHoleData inscriptionHoleData = this.InscriptionHoles[i];
				if (inscriptionHoleData != null)
				{
					if (inscriptionHoleData.IsOpenHole)
					{
						if (inscriptionHoleData.InscriptionId > 0)
						{
							result = true;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600E518 RID: 58648 RVA: 0x003B856C File Offset: 0x003B696C
		public List<string> GetBaseMainPropDescs()
		{
			EquipProp baseProp = this.BaseProp;
			if (baseProp == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			EEquipProp[] array = new EEquipProp[]
			{
				EEquipProp.PhysicsAttack,
				EEquipProp.MagicAttack,
				EEquipProp.PhysicsDefense,
				EEquipProp.MagicDefense,
				EEquipProp.Independence
			};
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(637, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			for (int i = 0; i < array.Length; i++)
			{
				string text = baseProp.GetPropFormatStr(array[i], -1);
				if (!string.IsNullOrEmpty(text))
				{
					string str = string.Empty;
					if (array[i] == EEquipProp.Independence)
					{
						str = ((num <= 0) ? TR.Value("tip_independence_pvpdesc") : string.Empty);
					}
					text += str;
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x0600E519 RID: 58649 RVA: 0x003B8640 File Offset: 0x003B6A40
		public bool CheckEquipMagicstoneIsHasBasPro()
		{
			if (this.Type == ItemTable.eType.EQUIP && this.SubType == 100 && ComFunctionAdjust.ms_akProps != null)
			{
				for (int i = 0; i < ComFunctionAdjust.ms_akProps.Length; i++)
				{
					EEquipProp eequipProp = ComFunctionAdjust.ms_akProps[i];
					if (this.BaseProp.props[(int)eequipProp] != 0)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x04008A3C RID: 35388
		public object userData;

		// Token: 0x04008A3D RID: 35389
		public static int unlimitedUseTimes = 99999999;

		// Token: 0x04008A3E RID: 35390
		public bool IsTableDataInited;

		// Token: 0x04008A3F RID: 35391
		public ulong GUID;

		// Token: 0x04008A40 RID: 35392
		public ItemTable.eType Type;

		// Token: 0x04008A41 RID: 35393
		public EPackageType PackageType;

		// Token: 0x04008A42 RID: 35394
		public int GridIndex;

		// Token: 0x04008A43 RID: 35395
		public int SubType;

		// Token: 0x04008A44 RID: 35396
		public ItemTable.eThirdType ThirdType;

		// Token: 0x04008A45 RID: 35397
		public EEquipWearSlotType EquipWearSlotType;

		// Token: 0x04008A46 RID: 35398
		public EFashionWearSlotType FashionWearSlotType;

		// Token: 0x04008A47 RID: 35399
		public int Count;

		// Token: 0x04008A48 RID: 35400
		public int ShowCount;

		// Token: 0x04008A49 RID: 35401
		public int MaxStackCount;

		// Token: 0x04008A4A RID: 35402
		public ItemTable.eColor Quality;

		// Token: 0x04008A4B RID: 35403
		public int Quality2;

		// Token: 0x04008A4C RID: 35404
		public int SubQuality;

		// Token: 0x04008A4D RID: 35405
		public int ItemTradeNumber;

		// Token: 0x04008A4E RID: 35406
		public bool IsTreasure;

		// Token: 0x04008A4F RID: 35407
		public bool IsShowTreasureFlagInTipFrame;

		// Token: 0x04008A50 RID: 35408
		public uint AuctionCoolTimeStamp;

		// Token: 0x04008A51 RID: 35409
		public bool isPVP;

		// Token: 0x04008A52 RID: 35410
		public EEquipType EquipType;

		// Token: 0x04008A53 RID: 35411
		public EGrowthAttrType GrowthAttrType;

		// Token: 0x04008A54 RID: 35412
		public int GrowthAttrNum;

		// Token: 0x04008A55 RID: 35413
		public string Name;

		// Token: 0x04008A56 RID: 35414
		public ItemTable.eOwner BindAttr;

		// Token: 0x04008A57 RID: 35415
		public bool Packing;

		// Token: 0x04008A58 RID: 35416
		public int RePackTime;

		// Token: 0x04008A59 RID: 35417
		public int iPackedTimes;

		// Token: 0x04008A5A RID: 35418
		public int iMaxPackTime;

		// Token: 0x04008A5B RID: 35419
		public int LevelLimit;

		// Token: 0x04008A5C RID: 35420
		public int MaxLevelLimit;

		// Token: 0x04008A5D RID: 35421
		public List<int> OccupationLimit;

		// Token: 0x04008A5E RID: 35422
		public ItemTable.eCanUse UseType;

		// Token: 0x04008A5F RID: 35423
		public int RecoScore;

		// Token: 0x04008A61 RID: 35425
		private bool canSell;

		// Token: 0x04008A62 RID: 35426
		private bool isLease;

		// Token: 0x04008A63 RID: 35427
		private bool _isItemInUnUsedEquipPlan;

		// Token: 0x04008A64 RID: 35428
		public int CDGroupID;

		// Token: 0x04008A65 RID: 35429
		public int CD;

		// Token: 0x04008A66 RID: 35430
		public int FixTimeLeft;

		// Token: 0x04008A67 RID: 35431
		public int DeadTimestamp;

		// Token: 0x04008A68 RID: 35432
		public List<RenewalInfo> arrRenewals;

		// Token: 0x04008A69 RID: 35433
		public int PriceItemID;

		// Token: 0x04008A6A RID: 35434
		public int Price;

		// Token: 0x04008A6B RID: 35435
		private int strengthenLevel;

		// Token: 0x04008A6C RID: 35436
		private bool isTimeLimit;

		// Token: 0x04008A6D RID: 35437
		private bool canDecompse;

		// Token: 0x04008A6E RID: 35438
		public int BaseAttackSpeedRate;

		// Token: 0x04008A6F RID: 35439
		public int SuitID;

		// Token: 0x04008A71 RID: 35441
		public ItemTable.eUseLimiteType useLimitType;

		// Token: 0x04008A72 RID: 35442
		public int useLimitValue;

		// Token: 0x04008A73 RID: 35443
		public int PackID;

		// Token: 0x04008A74 RID: 35444
		public bool bLocked;

		// Token: 0x04008A75 RID: 35445
		public bool bFashionItemLocked;

		// Token: 0x04008A76 RID: 35446
		public bool IsSelected;

		// Token: 0x04008A77 RID: 35447
		private int iFashionFreeTimes;

		// Token: 0x04008A78 RID: 35448
		private int iFashionBaseAttributeID;

		// Token: 0x04008A79 RID: 35449
		private int iFashionAttributeID;

		// Token: 0x04008A7A RID: 35450
		public List<EquipAttrTable> fashionAttributes;

		// Token: 0x04008A7B RID: 35451
		private PrecBead[] mPrecBeadBattle;

		// Token: 0x04008A7C RID: 35452
		private PrecBead[] mPreciousBeadMountHole;

		// Token: 0x04008A7D RID: 35453
		private int iBeadAdditiveAttributeBuffID;

		// Token: 0x04008A7E RID: 35454
		private int iBeadPickNumber;

		// Token: 0x04008A7F RID: 35455
		private int iBeadReplaceNumber;

		// Token: 0x04008A80 RID: 35456
		private bool bEquipIsInsetBead;

		// Token: 0x04008A81 RID: 35457
		private PrecEnchantmentCard precEnchantmentCard;

		// Token: 0x04008A82 RID: 35458
		private List<InscriptionHoleData> mInscriptionHoles;

		// Token: 0x04008A83 RID: 35459
		private EquipProp mBaseProp;

		// Token: 0x04008A84 RID: 35460
		private EquipProp mRandamProp;

		// Token: 0x04008A85 RID: 35461
		private EquipProp mMagicProp;

		// Token: 0x04008A86 RID: 35462
		private EquipProp mBeadProp;

		// Token: 0x04008A87 RID: 35463
		private EquipProp mInscriptionProp;

		// Token: 0x04008A88 RID: 35464
		public bool IsNew;

		// Token: 0x04008A89 RID: 35465
		protected static ItemData.QualityInfo ms_grey_quality = new ItemData.QualityInfo(ItemTable.eColor.WHITE, new Color(0.553f, 0.553f, 0.553f), "#8D8D8Dff", "灰色", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Huise", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lanzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Common_ListItem02", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Huise_Di");

		// Token: 0x04008A8A RID: 35466
		protected static ItemData.QualityInfo ms_rosered_quality = new ItemData.QualityInfo(ItemTable.eColor.PINK, new Color(1f, 0f, 0.35f), "#ff0058ff", "红", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Roseo", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Fenzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Fenzhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Pink_Di");

		// Token: 0x04008A8B RID: 35467
		protected static ItemData.QualityInfo[] ms_qualityInfos = new ItemData.QualityInfo[]
		{
			new ItemData.QualityInfo(ItemTable.eColor.WHITE, new Color(1f, 1f, 1f), "#ffffffff", "白", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_White", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lanzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Common_ListItem02", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Huise_Di"),
			new ItemData.QualityInfo(ItemTable.eColor.BLUE, new Color(0f, 0.75f, 1f), "#68d5edff", "蓝", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Blue", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lanzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lanzhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Blue_Di"),
			new ItemData.QualityInfo(ItemTable.eColor.PURPLE, new Color(0.75f, 0f, 1f), "#b36bffff", "紫", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Purple", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Di_04", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Zizhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Purple_Di"),
			new ItemData.QualityInfo(ItemTable.eColor.PINK, new Color(1f, 0f, 0.75f), "#ff00ffff", "粉", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Pink", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Fenzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Fenzhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Pink_Di"),
			new ItemData.QualityInfo(ItemTable.eColor.YELLOW, new Color(1f, 0.75f, 0f), "#ffb400ff", "橙", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Orange", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Di_03", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Chengzhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Orange_Di"),
			new ItemData.QualityInfo(ItemTable.eColor.GREEN, new Color(0f, 1f, 0f), "#00ff00ff", "绿", "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_Green", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lvzhuang_Di", "UIFlatten/Image/Packed/pck_UI_Common00.png:UI_Tongyong_Lvzhuang01", "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Tubiao_Green_Di")
		};

		// Token: 0x04008A8C RID: 35468
		private static EEquipProp[] ms_attachAttrIDs = new EEquipProp[]
		{
			EEquipProp.HPMax,
			EEquipProp.MPMax,
			EEquipProp.HPRecover,
			EEquipProp.MPRecover,
			EEquipProp.AttackSpeedRate,
			EEquipProp.FireSpeedRate,
			EEquipProp.MoveSpeedRate,
			EEquipProp.AbormalResist,
			EEquipProp.AbormalResists,
			EEquipProp.Elements,
			EEquipProp.LightAttack,
			EEquipProp.FireAttack,
			EEquipProp.IceAttack,
			EEquipProp.DarkAttack,
			EEquipProp.LightDefence,
			EEquipProp.FireDefence,
			EEquipProp.IceDefence,
			EEquipProp.DarkDefence,
			EEquipProp.HitRate,
			EEquipProp.AvoidRate,
			EEquipProp.PhysicCritRate,
			EEquipProp.MagicCritRate,
			EEquipProp.Spasticity,
			EEquipProp.Jump,
			EEquipProp.TownMoveSpeedRate
		};

		// Token: 0x04008A8D RID: 35469
		private ItemTable mTableData;

		// Token: 0x020016D1 RID: 5841
		public enum IncomeType
		{
			// Token: 0x04008A8F RID: 35471
			IT_GOLD = 17,
			// Token: 0x04008A90 RID: 35472
			IT_TICKET,
			// Token: 0x04008A91 RID: 35473
			IT_UNCOLOR = 300000106,
			// Token: 0x04008A92 RID: 35474
			IT_COLOR = 300000105,
			// Token: 0x04008A93 RID: 35475
			IT_PROTECTED = 200000310,
			// Token: 0x04008A94 RID: 35476
			IT_DEATHCOIN = 600000004,
			// Token: 0x04008A95 RID: 35477
			IT_PKCOIN,
			// Token: 0x04008A96 RID: 35478
			IT_GROWTHPROTECTED = 300000207
		}

		// Token: 0x020016D2 RID: 5842
		public class QualityInfo
		{
			// Token: 0x0600E51B RID: 58651 RVA: 0x003B88D0 File Offset: 0x003B6CD0
			public QualityInfo(ItemTable.eColor quality, Color col, string colStr, string desc, string background, string titleBG, string titleBG2, string tipTitleBackGround)
			{
				this.Quality = quality;
				this.Col = col;
				this.ColStr = colStr;
				this.Desc = desc;
				this.Background = background;
				this.TitleBG = titleBG;
				this.TitleBG2 = titleBG2;
				this.TipTitleBackGround = tipTitleBackGround;
			}

			// Token: 0x04008A97 RID: 35479
			public string TipTitleBackGround;

			// Token: 0x04008A98 RID: 35480
			public ItemTable.eColor Quality;

			// Token: 0x04008A99 RID: 35481
			public Color Col;

			// Token: 0x04008A9A RID: 35482
			public string ColStr;

			// Token: 0x04008A9B RID: 35483
			public string Desc;

			// Token: 0x04008A9C RID: 35484
			public string Background;

			// Token: 0x04008A9D RID: 35485
			public string TitleBG;

			// Token: 0x04008A9E RID: 35486
			public string TitleBG2;
		}
	}
}
