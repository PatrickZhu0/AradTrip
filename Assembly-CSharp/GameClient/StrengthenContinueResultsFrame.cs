using System;
using System.Collections.Generic;
using ActivityLimitTime;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B90 RID: 7056
	internal class StrengthenContinueResultsFrame : ClientFrame
	{
		// Token: 0x0601151F RID: 70943 RVA: 0x00500FD1 File Offset: 0x004FF3D1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenContinueResultsFrame";
		}

		// Token: 0x06011520 RID: 70944 RVA: 0x00500FD8 File Offset: 0x004FF3D8
		protected override void _OnOpenFrame()
		{
			this.m_kTitle = Utility.FindComponent<Text>(this.frame, "bg/Text/Text", true);
			this.m_goParent = Utility.FindChild(this.frame, "bg/ScrollView/Viewport/Content");
			this.m_goPrefabs = Utility.FindChild(this.m_goParent, "ResultObject");
			this.m_goPrefabs.CustomActive(false);
			this.m_akCachedList.Clear();
			this.m_kData = (this.userData as StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData);
			if (this.m_kData != null && this.m_kData.results.Count > 0)
			{
				this.mEquipItemData = this.m_kData.results[0].EquipData;
			}
			this._SetData(this.m_kData);
		}

		// Token: 0x06011521 RID: 70945 RVA: 0x0050109C File Offset: 0x004FF49C
		private void _SetData(StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData data)
		{
			string text = string.Empty;
			if (data.bStopByHandle)
			{
				if (this.mEquipItemData != null)
				{
					if (this.mEquipItemData.EquipType == EEquipType.ET_COMMON)
					{
						text = string.Format(TR.Value("strengthen_cs_stop_by_handle"), data.results.Count);
					}
					else if (this.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
					{
						text = string.Format(TR.Value("growth_cs_stop_by_handle"), data.results.Count);
					}
				}
				else
				{
					text = string.Format(TR.Value("strengthen_cs_stop_by_handle"), data.results.Count);
				}
			}
			else
			{
				switch (data.eLastOpResult)
				{
				case Utility.StrengthOperateResult.SOR_HAS_NO_ITEM:
					text = string.Format(TR.Value("strengthen_cs_stop_target_missing"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_UNCOLOR:
					text = string.Format(TR.Value("strengthen_cs_stop_uncolor_not_enough"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_COLOR:
					text = string.Format(TR.Value("strengthen_cs_stop_color_not_enough"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_GOLD:
					if (this.mEquipItemData != null)
					{
						if (this.mEquipItemData.EquipType == EEquipType.ET_COMMON)
						{
							text = string.Format(TR.Value("strengthen_cs_stop_gold_not_enough"), data.results.Count);
						}
						else if (this.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
						{
							text = string.Format(TR.Value("growth_cs_stop_gold_not_enough"), data.results.Count);
						}
					}
					else
					{
						text = string.Format(TR.Value("strengthen_cs_stop_gold_not_enough"), data.results.Count);
					}
					break;
				case Utility.StrengthOperateResult.SOR_OK:
					if (this.mEquipItemData != null)
					{
						if (this.mEquipItemData.EquipType == EEquipType.ET_COMMON)
						{
							text = string.Format(TR.Value("strengthen_cs_stop_finished"), this.m_kData.iTarget, data.results.Count);
						}
						else if (this.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
						{
							text = string.Format(TR.Value("growth_cs_stop_finished"), this.m_kData.iTarget, data.results.Count);
						}
					}
					else
					{
						text = string.Format(TR.Value("strengthen_cs_stop_finished"), this.m_kData.iTarget, data.results.Count);
					}
					break;
				case Utility.StrengthOperateResult.SOR_COST_ITEM_NOT_EXIST:
					text = string.Format(TR.Value("strengthen_cs_stop_cost_item_not_enough"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_HAS_NO_PROTECTED:
					text = string.Format(TR.Value("strengthen_cs_stop_has_no_protected"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_Paradoxicalcrystal:
					text = string.Format(TR.Value("growth_cs_stop_Paradoxicalcrystal_not_enough"), data.results.Count);
					break;
				case Utility.StrengthOperateResult.SOR_Strengthen_Implement:
					if (this.mEquipItemData != null)
					{
						if (this.mEquipItemData.EquipType == EEquipType.ET_COMMON)
						{
							text = TR.Value("strengthen_cs_stop_not_strengthenimplement", data.results.Count);
						}
						else if (this.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
						{
							text = TR.Value("strengthen_cs_stop_not_growthimplement", data.results.Count);
						}
					}
					break;
				}
			}
			this.m_kTitle.text = text;
			this.m_akCachedList.RecycleAllObject();
			this.m_kData.results.Reverse();
			for (int i = 0; i < this.m_kData.results.Count; i++)
			{
				this.m_akCachedList.Create(new object[]
				{
					this.m_goParent,
					this.m_goPrefabs,
					this.m_kData.results[i],
					this,
					i
				});
			}
		}

		// Token: 0x06011522 RID: 70946 RVA: 0x005014CC File Offset: 0x004FF8CC
		protected override void _OnCloseFrame()
		{
			Singleton<LimitTimeGiftFrameManager>.GetInstance().WaitToShowLimitTimeGiftFrame();
			this.m_akCachedList.DestroyAllObjects();
			this.mEquipItemData = null;
		}

		// Token: 0x06011523 RID: 70947 RVA: 0x005014EC File Offset: 0x004FF8EC
		[UIEventHandle("bg/ok")]
		private void OnClickOk()
		{
			Utility.StrengthOperateResult eLastOpResult = this.m_kData.eLastOpResult;
			if (eLastOpResult == Utility.StrengthOperateResult.SOR_COLOR || eLastOpResult == Utility.StrengthOperateResult.SOR_GOLD || eLastOpResult == Utility.StrengthOperateResult.SOR_UNCOLOR)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.STRENGEN_NO_RESOURCE, null);
			}
			this.frameMgr.CloseFrame<StrengthenContinueResultsFrame>(this, false);
		}

		// Token: 0x0400B32F RID: 45871
		private Text m_kTitle;

		// Token: 0x0400B330 RID: 45872
		private GameObject m_goParent;

		// Token: 0x0400B331 RID: 45873
		private GameObject m_goPrefabs;

		// Token: 0x0400B332 RID: 45874
		private CachedObjectListManager<StrengthenContinueResultsFrame.CachedItemDescObject> m_akCachedList = new CachedObjectListManager<StrengthenContinueResultsFrame.CachedItemDescObject>();

		// Token: 0x0400B333 RID: 45875
		private StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData m_kData;

		// Token: 0x0400B334 RID: 45876
		private ItemData mEquipItemData;

		// Token: 0x02001B91 RID: 7057
		private class CachedItemDescObject : CachedObject
		{
			// Token: 0x06011525 RID: 70949 RVA: 0x0050154C File Offset: 0x004FF94C
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefabs = (param[1] as GameObject);
				this.data = (param[2] as StrengthenResult);
				this.THIS = (param[3] as StrengthenContinueResultsFrame);
				this.iIndex = (int)param[4];
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefabs);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.goLine = Utility.FindChild(this.goLocal, "Line");
					this.desc = Utility.FindComponent<Text>(this.goLocal, "Desc", true);
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x06011526 RID: 70950 RVA: 0x0050160C File Offset: 0x004FFA0C
			private void _Update()
			{
				this.goLine.CustomActive(this.iIndex > 0);
				string text = string.Empty;
				if (this.data.EquipData.EquipType == EEquipType.ET_COMMON)
				{
					text = ((!this.data.StrengthenSuccess) ? TR.Value(StrengthenContinueResultsFrame.CachedItemDescObject.ms_failed) : TR.Value(StrengthenContinueResultsFrame.CachedItemDescObject.ms_succeed));
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.data.iTableID, 100, 0);
					text += string.Format(TR.Value((!this.data.StrengthenSuccess) ? "tip_strengthen_continue_name_failed" : "tip_strengthen_continue_name_ok"), itemData.GetColorName(string.Empty, false), this.data.iTargetStrengthenLevel);
					StrengthenCost strengthenCost = default(StrengthenCost);
					if (DataManager<StrengthenDataManager>.GetInstance().GetCost(this.data.iStrengthenLevel - 1, itemData.LevelLimit, itemData.Quality, ref strengthenCost))
					{
						if (itemData.SubType == 1)
						{
							float num = 1f;
							SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(21, string.Empty, string.Empty);
							if (tableItem != null)
							{
								num = (float)tableItem.Value / 10f;
							}
							strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num);
							strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num);
							strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num);
						}
						else if (itemData.SubType >= 2 && itemData.SubType <= 6)
						{
							float num2 = 1f;
							SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(22, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								num2 = (float)tableItem2.Value / 10f;
							}
							strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num2);
							strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num2);
							strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num2);
						}
						else if (itemData.SubType >= 7 && itemData.SubType <= 9)
						{
							float num3 = 1f;
							SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(23, string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								num3 = (float)tableItem3.Value / 10f;
							}
							strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num3);
							strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num3);
							strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num3);
						}
						int id = 300000106;
						int id2 = 300000105;
						int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
						List<AwardItemData> list = new List<AwardItemData>();
						if (strengthenCost.UnColorCost > 0)
						{
							list.Add(new AwardItemData
							{
								ID = id,
								Num = strengthenCost.UnColorCost
							});
						}
						if (strengthenCost.ColorCost > 0)
						{
							list.Add(new AwardItemData
							{
								ID = id2,
								Num = strengthenCost.ColorCost
							});
						}
						if (strengthenCost.GoldCost > 0)
						{
							list.Add(new AwardItemData
							{
								ID = moneyIDByType,
								Num = strengthenCost.GoldCost
							});
						}
						if (list.Count > 0)
						{
						}
						List<string> list2 = new List<string>();
						if (this.data.EquipData.IsAssistEquip())
						{
							for (int i = 0; i < this.data.assistEquipStrengthenOrgAttr.Length; i++)
							{
								int num4 = Mathf.FloorToInt((float)(this.data.assistEquipStrengthenCurAttr[i] - this.data.assistEquipStrengthenOrgAttr[i]));
								if (num4 != 0)
								{
									list2.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_strengthen_assist_failed[i] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_strengthen_assist_ok[i], StrengthenResult.ToValue(i, this.data.assistEquipStrengthenOrgAttr[i]), StrengthenResult.ToValue(i, this.data.assistEquipStrengthenCurAttr[i]), (num4 <= 0) ? string.Empty : "+", StrengthenResult.ToValue(i, num4)), new object[0]));
								}
							}
						}
						else
						{
							for (int j = 0; j < this.data.orgAttr.Length; j++)
							{
								int num5 = Mathf.FloorToInt((float)(this.data.curAttr[j] - this.data.orgAttr[j]));
								if (num5 != 0)
								{
									list2.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_failed[j] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_ok[j], StrengthenResult.ToValue(j, this.data.orgAttr[j]), StrengthenResult.ToValue(j, this.data.curAttr[j]), (num5 <= 0) ? string.Empty : "+", StrengthenResult.ToValue(j, num5)), new object[0]));
								}
							}
						}
						int num6 = 0;
						while (list2 != null && num6 < list2.Count)
						{
							text = text + "\n" + list2[num6];
							num6++;
						}
					}
				}
				else if (this.data.EquipData.EquipType == EEquipType.ET_REDMARK)
				{
					text = ((!this.data.StrengthenSuccess) ? TR.Value(StrengthenContinueResultsFrame.CachedItemDescObject.ms_growth_failed) : TR.Value(StrengthenContinueResultsFrame.CachedItemDescObject.ms_growth_succeed));
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(this.data.iTableID, 100, 0);
					text += string.Format(TR.Value((!this.data.StrengthenSuccess) ? "tip_strengthen_continue_name_failed" : "tip_strengthen_continue_name_ok"), itemData2.GetColorName(string.Empty, false), this.data.iTargetStrengthenLevel);
					List<string> list3 = new List<string>();
					if (this.data.EquipData.IsAssistEquip())
					{
						for (int k = 0; k < this.data.assistEquipGrowthOrgAttr.Length; k++)
						{
							int num7 = Mathf.FloorToInt((float)(this.data.assistEquipGrowthCurAttr[k] - this.data.assistEquipGrowthOrgAttr[k]));
							if (num7 != 0)
							{
								if (k == 0)
								{
									list3.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_assist_failed[k] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_assist_ok[k], DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.data.EquipData.GrowthAttrType), this.data.assistEquipGrowthOrgAttr[k], this.data.assistEquipGrowthCurAttr[k], (num7 <= 0) ? string.Empty : "+", num7), new object[0]));
								}
								else
								{
									list3.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_assist_failed[k] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_assist_ok[k], this.data.assistEquipGrowthOrgAttr[k], this.data.assistEquipGrowthCurAttr[k], (num7 <= 0) ? string.Empty : "+", num7), new object[0]));
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < this.data.growthOrgAttr.Length; l++)
						{
							int num8 = Mathf.FloorToInt((float)(this.data.growthCurAttr[l] - this.data.growthOrgAttr[l]));
							if (num8 != 0)
							{
								if (l == 0)
								{
									list3.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_failed[l] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_ok[l], DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(this.data.EquipData.GrowthAttrType), StrengthenResult.GrowthToValue(l, this.data.growthOrgAttr[l]), StrengthenResult.GrowthToValue(l, this.data.growthCurAttr[l]), (num8 <= 0) ? string.Empty : "+", StrengthenResult.GrowthToValue(l, num8)), new object[0]));
								}
								else
								{
									list3.Add(string.Format(TR.Value((!this.data.StrengthenSuccess) ? StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_failed[l] : StrengthenContinueResultsFrame.CachedItemDescObject.ms_tr_values_growth_ok[l], StrengthenResult.GrowthToValue(l, this.data.growthOrgAttr[l]), StrengthenResult.GrowthToValue(l, this.data.growthCurAttr[l]), (num8 <= 0) ? string.Empty : "+", StrengthenResult.GrowthToValue(l, num8)), new object[0]));
								}
							}
						}
					}
					int num9 = 0;
					while (list3 != null && num9 < list3.Count)
					{
						text = text + "\n" + list3[num9];
						num9++;
					}
				}
				this.desc.text = text;
			}

			// Token: 0x06011527 RID: 70951 RVA: 0x00501FC0 File Offset: 0x005003C0
			public override void OnDestroy()
			{
				this.desc = null;
				this.goLocal = null;
				this.goPrefabs = null;
				this.goParent = null;
				this.THIS = null;
			}

			// Token: 0x06011528 RID: 70952 RVA: 0x00501FE5 File Offset: 0x005003E5
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x06011529 RID: 70953 RVA: 0x00501FED File Offset: 0x005003ED
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0601152A RID: 70954 RVA: 0x00501FF6 File Offset: 0x005003F6
			public override void OnRefresh(object[] param)
			{
				if (param.Length > 0)
				{
					this.data = (param[0] as StrengthenResult);
				}
				this._Update();
			}

			// Token: 0x0601152B RID: 70955 RVA: 0x00502015 File Offset: 0x00500415
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0601152C RID: 70956 RVA: 0x00502034 File Offset: 0x00500434
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601152D RID: 70957 RVA: 0x00502053 File Offset: 0x00500453
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0601152E RID: 70958 RVA: 0x00502056 File Offset: 0x00500456
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x0400B335 RID: 45877
			private static string ms_succeed = "tip_strengthen_continue_ok";

			// Token: 0x0400B336 RID: 45878
			private static string ms_failed = "tip_strengthen_continue_failed";

			// Token: 0x0400B337 RID: 45879
			private static string[] ms_tr_values_failed = new string[]
			{
				"tip_attr_ignore_def_physic_attack_diff_failed",
				"tip_attr_ignore_def_magic_attack_diff_failed",
				"tip_attr_ignore_atk_IngoreIndependence_def_diff_failed",
				"tip_attr_ignore_atk_physics_def_diff_failed",
				"tip_attr_ignore_atk_magic_def_diff_failed",
				"tip_attr_ignore_atk_physics_def_rate_diff_failed",
				"tip_attr_ignore_atk_magic_def_rate_diff_failed"
			};

			// Token: 0x0400B338 RID: 45880
			private static string[] ms_tr_values_ok = new string[]
			{
				"tip_attr_ignore_def_physic_attack_diff_ok",
				"tip_attr_ignore_def_magic_attack_diff_ok",
				"tip_attr_ignore_atk_IngoreIndependence_def_diff_ok",
				"tip_attr_ignore_atk_physics_def_diff_ok",
				"tip_attr_ignore_atk_magic_def_diff_ok",
				"tip_attr_ignore_atk_physics_def_rate_diff_ok",
				"tip_attr_ignore_atk_magic_def_rate_diff_ok"
			};

			// Token: 0x0400B339 RID: 45881
			private static string ms_growth_succeed = "tip_growth_continue_ok";

			// Token: 0x0400B33A RID: 45882
			private static string ms_growth_failed = "tip_growth_continue_failed";

			// Token: 0x0400B33B RID: 45883
			private static string[] ms_tr_values_growth_failed = new string[]
			{
				"growth_tip_attr_failed",
				"tip_attr_ignore_def_physic_attack_diff_failed",
				"tip_attr_ignore_def_magic_attack_diff_failed",
				"tip_attr_ignore_atk_IngoreIndependence_def_diff_failed",
				"tip_attr_ignore_atk_physics_def_diff_failed",
				"tip_attr_ignore_atk_magic_def_diff_failed",
				"tip_attr_ignore_atk_physics_def_rate_diff_failed",
				"tip_attr_ignore_atk_magic_def_rate_diff_failed"
			};

			// Token: 0x0400B33C RID: 45884
			private static string[] ms_tr_values_growth_ok = new string[]
			{
				"growth_tip_attr_ok",
				"tip_attr_ignore_def_physic_attack_diff_ok",
				"tip_attr_ignore_def_magic_attack_diff_ok",
				"tip_attr_ignore_atk_IngoreIndependence_def_diff_ok",
				"tip_attr_ignore_atk_physics_def_diff_ok",
				"tip_attr_ignore_atk_magic_def_diff_ok",
				"tip_attr_ignore_atk_physics_def_rate_diff_ok",
				"tip_attr_ignore_atk_magic_def_rate_diff_ok"
			};

			// Token: 0x0400B33D RID: 45885
			private static string[] ms_tr_values_strengthen_assist_failed = new string[]
			{
				"growth_tip_attr_assist_strenth_failed",
				"growth_tip_attr_assist_intellect_failed",
				"growth_tip_attr_assist_spirit_failed",
				"growth_tip_attr_assist_stamina_failed"
			};

			// Token: 0x0400B33E RID: 45886
			private static string[] ms_tr_values_strengthen_assist_ok = new string[]
			{
				"growth_tip_attr_assist_strenth_ok",
				"growth_tip_attr_assist_intellect_ok",
				"growth_tip_attr_assist_spirit_ok",
				"growth_tip_attr_assist_stamina_ok"
			};

			// Token: 0x0400B33F RID: 45887
			private static string[] ms_tr_values_growth_assist_failed = new string[]
			{
				"growth_tip_attr_failed",
				"growth_tip_attr_assist_strenth_failed",
				"growth_tip_attr_assist_intellect_failed",
				"growth_tip_attr_assist_spirit_failed",
				"growth_tip_attr_assist_stamina_failed"
			};

			// Token: 0x0400B340 RID: 45888
			private static string[] ms_tr_values_growth_assist_ok = new string[]
			{
				"growth_tip_attr_ok",
				"growth_tip_attr_assist_strenth_ok",
				"growth_tip_attr_assist_intellect_ok",
				"growth_tip_attr_assist_spirit_ok",
				"growth_tip_attr_assist_stamina_ok"
			};

			// Token: 0x0400B341 RID: 45889
			private GameObject goLocal;

			// Token: 0x0400B342 RID: 45890
			private GameObject goParent;

			// Token: 0x0400B343 RID: 45891
			private GameObject goPrefabs;

			// Token: 0x0400B344 RID: 45892
			private StrengthenContinueResultsFrame THIS;

			// Token: 0x0400B345 RID: 45893
			private StrengthenResult data;

			// Token: 0x0400B346 RID: 45894
			private Text desc;

			// Token: 0x0400B347 RID: 45895
			private GameObject goLine;

			// Token: 0x0400B348 RID: 45896
			private int iIndex;
		}

		// Token: 0x02001B92 RID: 7058
		public class StrengthenContinueResultsFrameData
		{
			// Token: 0x0400B349 RID: 45897
			public bool bStopByHandle;

			// Token: 0x0400B34A RID: 45898
			public Utility.StrengthOperateResult eLastOpResult;

			// Token: 0x0400B34B RID: 45899
			public int iTarget;

			// Token: 0x0400B34C RID: 45900
			public List<StrengthenResult> results;
		}
	}
}
