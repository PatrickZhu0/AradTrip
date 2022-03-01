using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012FE RID: 4862
	public class StrengthenTicketMergeDataManager : DataManager<StrengthenTicketMergeDataManager>
	{
		// Token: 0x17001B6B RID: 7019
		// (get) Token: 0x0600BC5D RID: 48221 RVA: 0x002BEC08 File Offset: 0x002BD008
		public bool BFuncOpen
		{
			get
			{
				return this.bFuncOpen;
			}
		}

		// Token: 0x17001B6C RID: 7020
		// (get) Token: 0x0600BC5E RID: 48222 RVA: 0x002BEC10 File Offset: 0x002BD010
		public int FuseLimitLevel_Max
		{
			get
			{
				return this.fuseLimitLevel_Max;
			}
		}

		// Token: 0x17001B6D RID: 7021
		// (get) Token: 0x0600BC5F RID: 48223 RVA: 0x002BEC18 File Offset: 0x002BD018
		public int FuseLimitLevel_Min
		{
			get
			{
				return this.fuseLimitLevel_Min;
			}
		}

		// Token: 0x17001B6E RID: 7022
		// (get) Token: 0x0600BC60 RID: 48224 RVA: 0x002BEC20 File Offset: 0x002BD020
		public int TicketFuseReadyCapacity
		{
			get
			{
				return this.ticketFuseReadyCapacity;
			}
		}

		// Token: 0x17001B6F RID: 7023
		// (get) Token: 0x0600BC61 RID: 48225 RVA: 0x002BEC28 File Offset: 0x002BD028
		public StrengthenTicketMaterialMergeModel CurrSelectMaterialMergeModel
		{
			get
			{
				if (this.currSelectMaterialMergeModel == null)
				{
					return new StrengthenTicketMaterialMergeModel();
				}
				return this.currSelectMaterialMergeModel;
			}
		}

		// Token: 0x17001B70 RID: 7024
		// (get) Token: 0x0600BC62 RID: 48226 RVA: 0x002BEC41 File Offset: 0x002BD041
		public StrengthenTicketMaterialFuseModel TempMaterialFuseModel
		{
			get
			{
				if (this.tempMaterialFuseModel == null)
				{
					return new StrengthenTicketMaterialFuseModel();
				}
				return this.tempMaterialFuseModel;
			}
		}

		// Token: 0x0600BC63 RID: 48227 RVA: 0x002BEC5A File Offset: 0x002BD05A
		public override void Initialize()
		{
			this._BindEvent();
			this._InitLocalTicketMergeData();
			this._InitLocalMaterialMergeIncreaseLevelModels();
			this._InitLocalTicketFuseData();
			this._InitSystemValue();
			this._LoadTR();
		}

		// Token: 0x0600BC64 RID: 48228 RVA: 0x002BEC80 File Offset: 0x002BD080
		public override void Clear()
		{
			this._UnBindEvent();
			this._ClearData();
		}

		// Token: 0x0600BC65 RID: 48229 RVA: 0x002BEC90 File Offset: 0x002BD090
		private void _ClearData()
		{
			if (this.openedBuffPrayActivityDatas != null)
			{
				this.openedBuffPrayActivityDatas.Clear();
			}
			if (this.totalActivityTasks != null)
			{
				this.totalActivityTasks.Clear();
			}
			this.bFuncOpen = false;
			this.PrayActivityIsFinish = true;
			this.BSyntheticFrameTip = false;
			if (this.m_MaterialMergeTicketModels != null)
			{
				this.m_MaterialMergeTicketModels.Clear();
			}
			if (this.m_DisplayMaterialMergeTicketModels != null)
			{
				this.m_DisplayMaterialMergeTicketModels.Clear();
			}
			if (this.currSelectMaterialMergeModel != null)
			{
				this.currSelectMaterialMergeModel.Clear();
			}
			if (this.m_MaterialMergeIncreaseLevelModels != null)
			{
				this.m_MaterialMergeIncreaseLevelModels.Clear();
			}
			if (this.m_FuseMaterialModels != null)
			{
				this.m_FuseMaterialModels.Clear();
			}
			if (this.tempMaterialFuseModel != null)
			{
				this.tempMaterialFuseModel.Clear();
			}
			if (this.m_FuseProbabilityIntervalCorrectValueDic != null)
			{
				this.m_FuseProbabilityIntervalCorrectValueDic.Clear();
			}
			this.tr_notice_fuse_limit_num = string.Empty;
			this.tr_notice_merge_material_not_enough = string.Empty;
			this.tr_notice_dropdown_percent_format = string.Empty;
			this.tr_notice_cost_bind_ticket_tip = string.Empty;
			this.bCostBindTicketNotifyEnable = false;
			this.mStrengthTickActivityData = null;
		}

		// Token: 0x0600BC66 RID: 48230 RVA: 0x002BEDB4 File Offset: 0x002BD1B4
		private void _LoadTR()
		{
			this.tr_notice_fuse_limit_num = TR.Value("strengthen_merge_fuse_limit_num");
			this.tr_notice_merge_material_not_enough = TR.Value("strengthen_merge_material_not_enough");
			this.tr_notice_dropdown_percent_format = TR.Value("strengthen_merge_dropdown_percent_format");
			this.tr_notice_cost_bind_ticket_tip = TR.Value("strengthen_merge_cost_bind_ticket_tip");
		}

		// Token: 0x0600BC67 RID: 48231 RVA: 0x002BEE04 File Offset: 0x002BD204
		private void _BindEvent()
		{
			NetProcess.AddMsgHandler(501145U, new Action<MsgDATA>(this._OnSyncActivities));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncActivityStateChange));
			NetProcess.AddMsgHandler(501147U, new Action<MsgDATA>(this._OnSyncActivityTaskChange));
			NetProcess.AddMsgHandler(501146U, new Action<MsgDATA>(this._OnSyncActivityTasks));
			NetProcess.AddMsgHandler(501032U, new Action<MsgDATA>(this._OnStrengthenTicketMergeRet));
			NetProcess.AddMsgHandler(501038U, new Action<MsgDATA>(this._OnStrengthenTicketFuseRet));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this._OnMallBuyRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_STRENGTHEN_TICKET_MERGE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x0600BC68 RID: 48232 RVA: 0x002BEEC8 File Offset: 0x002BD2C8
		private void _UnBindEvent()
		{
			NetProcess.RemoveMsgHandler(501145U, new Action<MsgDATA>(this._OnSyncActivities));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncActivityStateChange));
			NetProcess.RemoveMsgHandler(501147U, new Action<MsgDATA>(this._OnSyncActivityTaskChange));
			NetProcess.RemoveMsgHandler(501146U, new Action<MsgDATA>(this._OnSyncActivityTasks));
			NetProcess.RemoveMsgHandler(501032U, new Action<MsgDATA>(this._OnStrengthenTicketMergeRet));
			NetProcess.RemoveMsgHandler(501038U, new Action<MsgDATA>(this._OnStrengthenTicketFuseRet));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this._OnMallBuyRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_STRENGTHEN_TICKET_MERGE, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x0600BC69 RID: 48233 RVA: 0x002BEF8C File Offset: 0x002BD38C
		private void _InitLocalTicketMergeData()
		{
			if (this.m_MaterialMergeTicketModels == null)
			{
				this.m_MaterialMergeTicketModels = new List<StrengthenTicketMaterialMergeModel>();
			}
			else
			{
				this.m_MaterialMergeTicketModels.Clear();
			}
			if (this.m_DisplayMaterialMergeTicketModels == null)
			{
				this.m_DisplayMaterialMergeTicketModels = new List<StrengthenTicketMaterialMergeModel>();
			}
			else
			{
				this.m_DisplayMaterialMergeTicketModels.Clear();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<StrengthenTicketSynthesisTable>();
			if (table == null)
			{
				this._DebugDataManagerLoggger("_InitLocalTicketMergeData", "can not find table : StrengthenTicketSynthesisTable");
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				StrengthenTicketSynthesisTable strengthenTicketSynthesisTable = keyValuePair.Value as StrengthenTicketSynthesisTable;
				if (strengthenTicketSynthesisTable != null)
				{
					StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel = new StrengthenTicketMaterialMergeModel();
					strengthenTicketMaterialMergeModel.mergeTableId = strengthenTicketSynthesisTable.ID;
					strengthenTicketMaterialMergeModel.name = strengthenTicketSynthesisTable.Name;
					strengthenTicketMaterialMergeModel.strengthenLevel = strengthenTicketSynthesisTable.StrengthenLv;
					strengthenTicketMaterialMergeModel.isBind = (strengthenTicketSynthesisTable.Binding == 1);
					strengthenTicketMaterialMergeModel.increaseLevel = (int)((double)strengthenTicketSynthesisTable.Amplitude * 0.001);
					strengthenTicketMaterialMergeModel.previewMinPercent = (int)((double)strengthenTicketSynthesisTable.Lower * 0.1);
					strengthenTicketMaterialMergeModel.previewMaxPercent = (int)((double)strengthenTicketSynthesisTable.Upper * 0.1);
					strengthenTicketMaterialMergeModel.displayItemTableId = strengthenTicketSynthesisTable.DisplayItemIndex;
					strengthenTicketMaterialMergeModel.bDisplay = (strengthenTicketSynthesisTable.DisplayItemIndex > 0);
					FlatBufferArray<string> costMaterial = strengthenTicketSynthesisTable.CostMaterial;
					if (costMaterial != null)
					{
						if (strengthenTicketMaterialMergeModel.needMaterialModel == null)
						{
							strengthenTicketMaterialMergeModel.needMaterialModel = new StrengthenTicketMergeMaterial();
						}
						else
						{
							strengthenTicketMaterialMergeModel.needMaterialModel.Clear();
						}
						for (int i = 0; i < costMaterial.Count; i++)
						{
							string text = costMaterial[i];
							if (!string.IsNullOrEmpty(text))
							{
								List<StrengthenTicketMergeItemData> list = strengthenTicketMaterialMergeModel.needMaterialModel.needMaterialDatas;
								if (list == null)
								{
									list = new List<StrengthenTicketMergeItemData>();
								}
								StrengthenTicketMergeItemData strengthenTicketMergeItemData = new StrengthenTicketMergeItemData();
								ItemSimpleData itemSimpleDataFromTableWithIdCount = Utility.GetItemSimpleDataFromTableWithIdCount(text);
								if (itemSimpleDataFromTableWithIdCount == null)
								{
									this._DebugDataManagerLoggger("_InitLocalTicketMergeData", "get item simple data from id and count failed : " + text);
								}
								else
								{
									strengthenTicketMergeItemData.tempItemData = itemSimpleDataFromTableWithIdCount;
									strengthenTicketMergeItemData.rawItemCount = itemSimpleDataFromTableWithIdCount.Count;
									list.Add(strengthenTicketMergeItemData);
								}
							}
						}
						this.m_MaterialMergeTicketModels.Add(strengthenTicketMaterialMergeModel);
						if (strengthenTicketMaterialMergeModel.bDisplay)
						{
							this.m_DisplayMaterialMergeTicketModels.Add(strengthenTicketMaterialMergeModel);
						}
					}
				}
			}
		}

		// Token: 0x0600BC6A RID: 48234 RVA: 0x002BF204 File Offset: 0x002BD604
		private void _InitLocalMaterialMergeIncreaseLevelModels()
		{
			if (this.m_MaterialMergeIncreaseLevelModels == null)
			{
				this.m_MaterialMergeIncreaseLevelModels = new List<StrengthenTicketMaterialMergeIncreaseLevel>();
			}
			else
			{
				this.m_MaterialMergeIncreaseLevelModels.Clear();
			}
			if (this.m_MaterialMergeTicketModels == null || this.m_MaterialMergeTicketModels.Count == 0 || this.m_DisplayMaterialMergeTicketModels == null || this.m_DisplayMaterialMergeTicketModels.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.m_DisplayMaterialMergeTicketModels.Count; i++)
			{
				StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel = this.m_DisplayMaterialMergeTicketModels[i];
				if (strengthenTicketMaterialMergeModel != null && strengthenTicketMaterialMergeModel.bDisplay)
				{
					StrengthenTicketMaterialMergeIncreaseLevel strengthenTicketMaterialMergeIncreaseLevel = new StrengthenTicketMaterialMergeIncreaseLevel();
					strengthenTicketMaterialMergeIncreaseLevel.displayItemTableId = strengthenTicketMaterialMergeModel.displayItemTableId;
					for (int j = 0; j < this.m_MaterialMergeTicketModels.Count; j++)
					{
						StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel2 = this.m_MaterialMergeTicketModels[j];
						if (strengthenTicketMaterialMergeModel2 != null)
						{
							if (strengthenTicketMaterialMergeModel2.strengthenLevel == strengthenTicketMaterialMergeModel.strengthenLevel && strengthenTicketMaterialMergeModel2.isBind == strengthenTicketMaterialMergeModel.isBind)
							{
								strengthenTicketMaterialMergeIncreaseLevel.name = strengthenTicketMaterialMergeModel2.name;
								strengthenTicketMaterialMergeIncreaseLevel.isBind = strengthenTicketMaterialMergeModel2.isBind;
								strengthenTicketMaterialMergeIncreaseLevel.strengthenLevel = strengthenTicketMaterialMergeModel2.strengthenLevel;
								if (strengthenTicketMaterialMergeIncreaseLevel.mergeTableIds == null)
								{
									strengthenTicketMaterialMergeIncreaseLevel.mergeTableIds = new List<int>();
								}
								strengthenTicketMaterialMergeIncreaseLevel.mergeTableIds.Add(strengthenTicketMaterialMergeModel2.mergeTableId);
								if (strengthenTicketMaterialMergeIncreaseLevel.increaseLevels == null)
								{
									strengthenTicketMaterialMergeIncreaseLevel.increaseLevels = new List<int>();
								}
								strengthenTicketMaterialMergeIncreaseLevel.increaseLevels.Add(strengthenTicketMaterialMergeModel2.increaseLevel * 100);
							}
						}
					}
					this.m_MaterialMergeIncreaseLevelModels.Add(strengthenTicketMaterialMergeIncreaseLevel);
				}
			}
		}

		// Token: 0x0600BC6B RID: 48235 RVA: 0x002BF3A0 File Offset: 0x002BD7A0
		private void _RefreshMaterialMergeTicketModelsByNet()
		{
			if (this.openedBuffPrayActivityDatas == null || this.openedBuffPrayActivityDatas.Count == 0)
			{
				return;
			}
			if (this.totalActivityTasks == null || this.totalActivityTasks.Count == 0)
			{
				return;
			}
			foreach (OpActivityData opActivityData in this.openedBuffPrayActivityDatas.Values)
			{
				if (opActivityData != null)
				{
					if (opActivityData.state == 1 && opActivityData.tmpType == 3100U)
					{
						OpActTaskData[] tasks = opActivityData.tasks;
						if (tasks != null)
						{
							foreach (OpActTaskData opActTaskData in tasks)
							{
								if (opActTaskData != null)
								{
									if (this.totalActivityTasks.ContainsKey(opActTaskData.dataid))
									{
										uint[] variables = opActTaskData.variables;
										if (variables != null && variables.Length != 0)
										{
											if (variables[0] == 1U)
											{
												OpActTask opActTask = this.totalActivityTasks[opActTaskData.dataid];
												if (opActTask != null)
												{
													if (opActTask.state == 5)
													{
														this._RefreshLocalMaterialTicketMergeMat(false, 0, 0);
													}
													else if (opActTask.state == 2)
													{
														if (this.IsHaveLeftPrayTimer())
														{
															OpTaskReward[] rewards = opActTaskData.rewards;
															if (rewards != null)
															{
																foreach (OpTaskReward opTaskReward in rewards)
																{
																	if (opTaskReward != null)
																	{
																		this._RefreshLocalMaterialTicketMergeMat(true, (int)opTaskReward.id, (int)opTaskReward.num);
																	}
																}
															}
														}
														else
														{
															this._RefreshLocalMaterialTicketMergeMat(false, 0, 0);
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
				}
			}
		}

		// Token: 0x0600BC6C RID: 48236 RVA: 0x002BF574 File Offset: 0x002BD974
		private void _RefreshLocalMaterialTicketMergeMat(bool bDiscount, int itemId = 0, int discountPercent = 0)
		{
			if (this.m_MaterialMergeTicketModels == null)
			{
				return;
			}
			if (!bDiscount)
			{
				this._ResetLocalMaterialMergeTicketModels();
				return;
			}
			for (int i = 0; i < this.m_MaterialMergeTicketModels.Count; i++)
			{
				StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel = this.m_MaterialMergeTicketModels[i];
				if (strengthenTicketMaterialMergeModel != null)
				{
					StrengthenTicketMergeMaterial needMaterialModel = strengthenTicketMaterialMergeModel.needMaterialModel;
					if (needMaterialModel != null)
					{
						List<StrengthenTicketMergeItemData> needMaterialDatas = needMaterialModel.needMaterialDatas;
						if (needMaterialDatas != null)
						{
							for (int j = 0; j < needMaterialDatas.Count; j++)
							{
								StrengthenTicketMergeItemData strengthenTicketMergeItemData = needMaterialDatas[j];
								if (strengthenTicketMergeItemData != null)
								{
									ItemSimpleData tempItemData = strengthenTicketMergeItemData.tempItemData;
									if (tempItemData != null && tempItemData.ItemID == itemId)
									{
										int rawItemCount = strengthenTicketMergeItemData.rawItemCount;
										tempItemData.Count = rawItemCount * (100 - discountPercent) / 100;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BC6D RID: 48237 RVA: 0x002BF65C File Offset: 0x002BDA5C
		private void _ResetLocalMaterialMergeTicketModels()
		{
			if (this.m_MaterialMergeTicketModels == null)
			{
				this.m_MaterialMergeTicketModels = new List<StrengthenTicketMaterialMergeModel>();
			}
			else
			{
				this.m_MaterialMergeTicketModels.Clear();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<StrengthenTicketSynthesisTable>();
			if (table == null)
			{
				this._DebugDataManagerLoggger("_ResetLocalMaterialMergeModels", "can not find table : StrengthenTicketSynthesisTable");
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				StrengthenTicketSynthesisTable strengthenTicketSynthesisTable = keyValuePair.Value as StrengthenTicketSynthesisTable;
				if (strengthenTicketSynthesisTable != null)
				{
					StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel = new StrengthenTicketMaterialMergeModel();
					strengthenTicketMaterialMergeModel.mergeTableId = strengthenTicketSynthesisTable.ID;
					strengthenTicketMaterialMergeModel.name = strengthenTicketSynthesisTable.Name;
					strengthenTicketMaterialMergeModel.strengthenLevel = strengthenTicketSynthesisTable.StrengthenLv;
					strengthenTicketMaterialMergeModel.isBind = (strengthenTicketSynthesisTable.Binding == 1);
					strengthenTicketMaterialMergeModel.increaseLevel = (int)((double)strengthenTicketSynthesisTable.Amplitude * 0.001);
					strengthenTicketMaterialMergeModel.previewMinPercent = (int)((double)strengthenTicketSynthesisTable.Lower * 0.1);
					strengthenTicketMaterialMergeModel.previewMaxPercent = (int)((double)strengthenTicketSynthesisTable.Upper * 0.1);
					strengthenTicketMaterialMergeModel.displayItemTableId = strengthenTicketSynthesisTable.DisplayItemIndex;
					strengthenTicketMaterialMergeModel.bDisplay = (strengthenTicketSynthesisTable.DisplayItemIndex > 0);
					FlatBufferArray<string> costMaterial = strengthenTicketSynthesisTable.CostMaterial;
					if (costMaterial != null)
					{
						if (strengthenTicketMaterialMergeModel.needMaterialModel == null)
						{
							strengthenTicketMaterialMergeModel.needMaterialModel = new StrengthenTicketMergeMaterial();
						}
						else
						{
							strengthenTicketMaterialMergeModel.needMaterialModel.Clear();
						}
						for (int i = 0; i < costMaterial.Count; i++)
						{
							string text = costMaterial[i];
							if (!string.IsNullOrEmpty(text))
							{
								List<StrengthenTicketMergeItemData> list = strengthenTicketMaterialMergeModel.needMaterialModel.needMaterialDatas;
								if (list == null)
								{
									list = new List<StrengthenTicketMergeItemData>();
								}
								StrengthenTicketMergeItemData strengthenTicketMergeItemData = new StrengthenTicketMergeItemData();
								ItemSimpleData itemSimpleDataFromTableWithIdCount = Utility.GetItemSimpleDataFromTableWithIdCount(text);
								if (itemSimpleDataFromTableWithIdCount == null)
								{
									this._DebugDataManagerLoggger("_InitLocalTicketMergeData", "get item simple data from id and count failed : " + text);
								}
								else
								{
									strengthenTicketMergeItemData.tempItemData = itemSimpleDataFromTableWithIdCount;
									strengthenTicketMergeItemData.rawItemCount = itemSimpleDataFromTableWithIdCount.Count;
									list.Add(strengthenTicketMergeItemData);
								}
							}
						}
						for (int j = 0; j < this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas.Count; j++)
						{
							this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas[j].tempItemData.Count = this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas[j].rawItemCount;
						}
						this.m_MaterialMergeTicketModels.Add(strengthenTicketMaterialMergeModel);
					}
				}
			}
		}

		// Token: 0x0600BC6E RID: 48238 RVA: 0x002BF8FC File Offset: 0x002BDCFC
		private void _InitLocalTicketFuseData()
		{
			if (this.m_FuseMaterialModels == null)
			{
				this.m_FuseMaterialModels = new List<StrengthenTicketFuseSpecialMaterial>();
			}
			else
			{
				this.m_FuseMaterialModels.Clear();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<StrenTicketFuseMaterialTable>();
			if (table == null)
			{
				this._DebugDataManagerLoggger("_InitLocalTicketFuseData", "can not find table : StrenTicketFuseMaterialTable");
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				StrenTicketFuseMaterialTable strenTicketFuseMaterialTable = keyValuePair.Value as StrenTicketFuseMaterialTable;
				if (strenTicketFuseMaterialTable != null)
				{
					StrengthenTicketFuseSpecialMaterial strengthenTicketFuseSpecialMaterial = new StrengthenTicketFuseSpecialMaterial();
					strengthenTicketFuseSpecialMaterial.fuseNeedItemData = Utility.GetItemSimpleDataFromTableWithIdCount(strenTicketFuseMaterialTable.Material);
					string pickCondOfStrenLv = strenTicketFuseMaterialTable.PickCondOfStrenLv;
					if (!string.IsNullOrEmpty(pickCondOfStrenLv))
					{
						string[] array = pickCondOfStrenLv.Split(new char[]
						{
							'_'
						});
						if (array != null && array.Length == 2)
						{
							int limitStrengthenLevelMin;
							if (int.TryParse(array[0], out limitStrengthenLevelMin))
							{
								strengthenTicketFuseSpecialMaterial.limitStrengthenLevelMin = limitStrengthenLevelMin;
							}
							int limitStrengthenLevelMax;
							if (int.TryParse(array[1], out limitStrengthenLevelMax))
							{
								strengthenTicketFuseSpecialMaterial.limitStrengthenLevelMax = limitStrengthenLevelMax;
							}
							this.m_FuseMaterialModels.Add(strengthenTicketFuseSpecialMaterial);
						}
					}
				}
			}
		}

		// Token: 0x0600BC6F RID: 48239 RVA: 0x002BFA24 File Offset: 0x002BDE24
		private void _InitSystemValue()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(466, string.Empty, string.Empty);
			this.fuseLimitLevel_Max = tableItem.Value;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(467, string.Empty, string.Empty);
			this.fuseLimitLevel_Min = tableItem2.Value;
			StrengthenTicketMergeFrame strengthenTicketMergeFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(StrengthenTicketMergeFrame)) as StrengthenTicketMergeFrame;
			if (strengthenTicketMergeFrame != null)
			{
				this.ticketFuseReadyCapacity = strengthenTicketMergeFrame.GetFuseTicketCount();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<StrengthenTicketFuseTable>();
			if (table != null && this.m_FuseProbabilityIntervalCorrectValueDic != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					StrengthenTicketFuseTable strengthenTicketFuseTable = keyValuePair.Value as StrengthenTicketFuseTable;
					if (this.m_FuseProbabilityIntervalCorrectValueDic.ContainsKey(strengthenTicketFuseTable.StrengthenLv))
					{
						this.m_FuseProbabilityIntervalCorrectValueDic[strengthenTicketFuseTable.StrengthenLv] = strengthenTicketFuseTable.FixM;
					}
					else
					{
						this.m_FuseProbabilityIntervalCorrectValueDic.Add(strengthenTicketFuseTable.StrengthenLv, strengthenTicketFuseTable.FixM);
					}
				}
			}
		}

		// Token: 0x0600BC70 RID: 48240 RVA: 0x002BFB44 File Offset: 0x002BDF44
		private void _OnSyncActivities(MsgDATA data)
		{
			SyncOpActivityDatas syncOpActivityDatas = new SyncOpActivityDatas();
			syncOpActivityDatas.decode(data.bytes);
			OpActivityData[] datas = syncOpActivityDatas.datas;
			if (datas == null)
			{
				return;
			}
			for (int i = 0; i < datas.Length; i++)
			{
				if (datas[i].tmpType == 3200U)
				{
					if (datas[i].state == 1)
					{
						this.mStrengthTickActivityData = datas[i];
						this.bFuncOpen = true;
						if (this.bFuncOpen)
						{
							break;
						}
					}
				}
			}
			if (!this.bFuncOpen)
			{
				this.CloseStrengthenTicketMergeFrame();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeStateUpdate, null, null, null, null);
			if (this.openedBuffPrayActivityDatas == null)
			{
				return;
			}
			for (int j = 0; j < datas.Length; j++)
			{
				if (datas[j].tmpType == 3100U)
				{
					if (datas[j].state == 1)
					{
						this.openedBuffPrayActivityDatas[datas[j].dataId] = datas[j];
						this._RefreshMaterialMergeTicketModelsByNet();
					}
					if (this.PrayActivityIsFinish)
					{
						this.PrayActivityIsFinish = (datas[j].state == 0);
					}
				}
			}
		}

		// Token: 0x0600BC71 RID: 48241 RVA: 0x002BFC70 File Offset: 0x002BE070
		private void _OnSyncActivityStateChange(MsgDATA data)
		{
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(data.bytes);
			OpActivityData data2 = syncOpActivityStateChange.data;
			if (data2 == null)
			{
				return;
			}
			if (data2.tmpType == 3200U)
			{
				this.bFuncOpen = (data2.state == 1);
				this.mStrengthTickActivityData = data2;
			}
			else if (data2.tmpType == 3100U)
			{
				this.PrayActivityIsFinish = (data2.state == 0);
			}
			if (!this.bFuncOpen)
			{
				this.CloseStrengthenTicketMergeFrame();
			}
			if (data2.tmpType == 3100U)
			{
				if (data2.state == 0)
				{
					if (this.openedBuffPrayActivityDatas != null && this.openedBuffPrayActivityDatas.ContainsKey(data2.dataId))
					{
						this.openedBuffPrayActivityDatas.Remove(data2.dataId);
					}
					this._RefreshMaterialMergeTicketModelsByNet();
				}
				else if (data2.state == 1)
				{
					if (this.openedBuffPrayActivityDatas != null)
					{
						this.openedBuffPrayActivityDatas[data2.dataId] = data2;
					}
					this._RefreshMaterialMergeTicketModelsByNet();
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeStateUpdate, null, null, null, null);
		}

		// Token: 0x0600BC72 RID: 48242 RVA: 0x002BFDA8 File Offset: 0x002BE1A8
		private void _OnSyncActivityTasks(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityTasks syncOpActivityTasks = new SyncOpActivityTasks();
			syncOpActivityTasks.decode(msg.bytes, ref num);
			OpActTask[] tasks = syncOpActivityTasks.tasks;
			if (tasks == null || tasks.Length == 0)
			{
				return;
			}
			if (this.totalActivityTasks == null)
			{
				return;
			}
			foreach (OpActTask opActTask in tasks)
			{
				if (opActTask != null)
				{
					this.totalActivityTasks[opActTask.dataId] = opActTask;
					if (this.openedBuffPrayActivityDatas != null && this.openedBuffPrayActivityDatas.ContainsKey(opActTask.dataId / 1000U))
					{
						this._RefreshMaterialMergeTicketModelsByNet();
					}
				}
			}
		}

		// Token: 0x0600BC73 RID: 48243 RVA: 0x002BFE54 File Offset: 0x002BE254
		private void _OnSyncActivityTaskChange(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityTaskChange syncOpActivityTaskChange = new SyncOpActivityTaskChange();
			syncOpActivityTaskChange.decode(msg.bytes, ref num);
			if (syncOpActivityTaskChange.tasks == null || syncOpActivityTaskChange.tasks.Length == 0)
			{
				return;
			}
			if (this.totalActivityTasks == null)
			{
				return;
			}
			for (int i = 0; i < syncOpActivityTaskChange.tasks.Length; i++)
			{
				OpActTask opActTask = syncOpActivityTaskChange.tasks[i];
				if (opActTask != null)
				{
					this.totalActivityTasks[opActTask.dataId] = opActTask;
					if (this.openedBuffPrayActivityDatas != null && this.openedBuffPrayActivityDatas.ContainsKey(opActTask.dataId / 1000U))
					{
						this._RefreshMaterialMergeTicketModelsByNet();
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFreshView, null, null, null, null);
		}

		// Token: 0x0600BC74 RID: 48244 RVA: 0x002BFF1C File Offset: 0x002BE31C
		private void _OnStrengthenTicketMergeRet(MsgDATA data)
		{
			SceneStrengthenTicketSynthesisRes sceneStrengthenTicketSynthesisRes = new SceneStrengthenTicketSynthesisRes();
			sceneStrengthenTicketSynthesisRes.decode(data.bytes);
			if (sceneStrengthenTicketSynthesisRes.ret != 0U)
			{
				this._DebugDataManagerLoggger("_OnStrengthenTicketMergeRet", "merge error !!! code :" + sceneStrengthenTicketSynthesisRes.ret);
				SystemNotifyManager.SystemNotify((int)sceneStrengthenTicketSynthesisRes.ret, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeFailed, null, null, null, null);
			}
			else
			{
				this._DebugDataManagerLoggger("_OnStrengthenTicketMergeRet", "merge success !!!");
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BC75 RID: 48245 RVA: 0x002BFFB4 File Offset: 0x002BE3B4
		private void _OnStrengthenTicketFuseRet(MsgDATA data)
		{
			SceneStrengthenTicketFuseRes sceneStrengthenTicketFuseRes = new SceneStrengthenTicketFuseRes();
			sceneStrengthenTicketFuseRes.decode(data.bytes);
			if (sceneStrengthenTicketFuseRes.ret != 0U)
			{
				this._DebugDataManagerLoggger("_OnStrengthenTicketFuseRet", "fuse error !!! code :" + sceneStrengthenTicketFuseRes.ret);
				SystemNotifyManager.SystemNotify((int)sceneStrengthenTicketFuseRes.ret, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseFailed, null, null, null, null);
			}
			else
			{
				this._DebugDataManagerLoggger("_OnStrengthenTicketFuseRet", "fuse success !!!");
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BC76 RID: 48246 RVA: 0x002C004C File Offset: 0x002BE44C
		private void _OnMallBuyRes(MsgDATA data)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(data.bytes);
			if (worldMallBuyRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMallBuyRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMallBuySuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BC77 RID: 48247 RVA: 0x002C009E File Offset: 0x002BE49E
		private void _OnServerSwitchFunc(ServerSceneFuncSwitch funcSwitch)
		{
			this.bFuncOpen = (this.bFuncOpen && funcSwitch.sIsOpen);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketMergeStateUpdate, null, null, null, null);
		}

		// Token: 0x0600BC78 RID: 48248 RVA: 0x002C00CD File Offset: 0x002BE4CD
		private void _DebugDataManagerLoggger(string methodName, string errorLog)
		{
		}

		// Token: 0x0600BC79 RID: 48249 RVA: 0x002C00CF File Offset: 0x002BE4CF
		public List<StrengthenTicketMaterialMergeModel> GetMaterialMergeTicketModels()
		{
			return this.m_MaterialMergeTicketModels;
		}

		// Token: 0x0600BC7A RID: 48250 RVA: 0x002C00D7 File Offset: 0x002BE4D7
		public List<StrengthenTicketMaterialMergeModel> GetDisplayMaterialMergeTicketModels()
		{
			return this.m_DisplayMaterialMergeTicketModels;
		}

		// Token: 0x0600BC7B RID: 48251 RVA: 0x002C00DF File Offset: 0x002BE4DF
		public List<StrengthenTicketMaterialMergeIncreaseLevel> GetMaterialMergeIncreaseLevelModels()
		{
			return this.m_MaterialMergeIncreaseLevelModels;
		}

		// Token: 0x0600BC7C RID: 48252 RVA: 0x002C00E8 File Offset: 0x002BE4E8
		public List<string> GetMaterialMergeIncreaseLevelDescList(StrengthenTicketMaterialMergeModel model)
		{
			if (model == null || this.m_MaterialMergeIncreaseLevelModels == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.m_MaterialMergeIncreaseLevelModels.Count; i++)
			{
				StrengthenTicketMaterialMergeIncreaseLevel strengthenTicketMaterialMergeIncreaseLevel = this.m_MaterialMergeIncreaseLevelModels[i];
				if (strengthenTicketMaterialMergeIncreaseLevel != null)
				{
					if (strengthenTicketMaterialMergeIncreaseLevel.strengthenLevel == model.strengthenLevel && strengthenTicketMaterialMergeIncreaseLevel.isBind == model.isBind)
					{
						List<int> increaseLevels = strengthenTicketMaterialMergeIncreaseLevel.increaseLevels;
						if (increaseLevels != null)
						{
							for (int j = 0; j < increaseLevels.Count; j++)
							{
								list.Add(string.Format(this.tr_notice_dropdown_percent_format, increaseLevels[j].ToString()));
							}
							break;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BC7D RID: 48253 RVA: 0x002C01C0 File Offset: 0x002BE5C0
		public StrengthenTicketMaterialMergeModel GetMaterialMergeStrengthenTicketTableId(StrengthenTicketMaterialMergeModel mergeModel, int index)
		{
			if (this.m_MaterialMergeTicketModels == null || mergeModel == null)
			{
				return null;
			}
			for (int i = 0; i < this.m_MaterialMergeTicketModels.Count; i++)
			{
				StrengthenTicketMaterialMergeModel strengthenTicketMaterialMergeModel = this.m_MaterialMergeTicketModels[i];
				if (strengthenTicketMaterialMergeModel != null)
				{
					if (strengthenTicketMaterialMergeModel.strengthenLevel == mergeModel.strengthenLevel && strengthenTicketMaterialMergeModel.isBind == mergeModel.isBind && strengthenTicketMaterialMergeModel.increaseLevel == index)
					{
						this.currSelectMaterialMergeModel = strengthenTicketMaterialMergeModel;
						return strengthenTicketMaterialMergeModel;
					}
				}
			}
			return null;
		}

		// Token: 0x0600BC7E RID: 48254 RVA: 0x002C024C File Offset: 0x002BE64C
		public void ReqMaterialMergeStrengthenTicket()
		{
			if (this.currSelectMaterialMergeModel == null)
			{
				return;
			}
			if (this.currSelectMaterialMergeModel.mergeTableId == 0)
			{
				this._DebugDataManagerLoggger("ReqMaterialMergeStrengthenTicket", "curr temp model mergeTableId is 0");
				return;
			}
			SceneStrengthenTicketSynthesisReq sceneStrengthenTicketSynthesisReq = new SceneStrengthenTicketSynthesisReq();
			sceneStrengthenTicketSynthesisReq.synthesisPlan = (uint)this.currSelectMaterialMergeModel.mergeTableId;
			NetManager.Instance().SendCommand<SceneStrengthenTicketSynthesisReq>(ServerType.GATE_SERVER, sceneStrengthenTicketSynthesisReq);
		}

		// Token: 0x0600BC7F RID: 48255 RVA: 0x002C02AC File Offset: 0x002BE6AC
		public void ReqFuseStrengthenTicket(ulong aGUID, ulong bGUID)
		{
			SceneStrengthenTicketFuseReq sceneStrengthenTicketFuseReq = new SceneStrengthenTicketFuseReq();
			sceneStrengthenTicketFuseReq.pickTicketA = aGUID;
			sceneStrengthenTicketFuseReq.pickTicketB = bGUID;
			NetManager.Instance().SendCommand<SceneStrengthenTicketFuseReq>(ServerType.GATE_SERVER, sceneStrengthenTicketFuseReq);
		}

		// Token: 0x0600BC80 RID: 48256 RVA: 0x002C02DC File Offset: 0x002BE6DC
		public void ReqFastMallBuy(int itemId)
		{
			WorldGetMallItemByItemIdReq worldGetMallItemByItemIdReq = new WorldGetMallItemByItemIdReq();
			worldGetMallItemByItemIdReq.itemId = (uint)itemId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, worldGetMallItemByItemIdReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(delegate(WorldGetMallItemByItemIdRes msgRet)
			{
				MallItemInfo mallItem = msgRet.mallItem;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItem, string.Empty);
			}, false, 15f, null);
		}

		// Token: 0x0600BC81 RID: 48257 RVA: 0x002C0334 File Offset: 0x002BE734
		public int GetOwnStrengthenTicketCount(int tableId)
		{
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableId, false);
		}

		// Token: 0x0600BC82 RID: 48258 RVA: 0x002C0350 File Offset: 0x002BE750
		public bool HasStrengthenTicket()
		{
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.Coupon);
			return itemsByPackageSubType != null && itemsByPackageSubType.Count > 0;
		}

		// Token: 0x0600BC83 RID: 48259 RVA: 0x002C0380 File Offset: 0x002BE780
		public List<ulong> GetOwnStrengthenTicketItemDataGUIDs()
		{
			return DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.Coupon);
		}

		// Token: 0x0600BC84 RID: 48260 RVA: 0x002C039C File Offset: 0x002BE79C
		public void ClearCurrSelectMaterialMergeModel()
		{
			this.currSelectMaterialMergeModel = new StrengthenTicketMaterialMergeModel();
		}

		// Token: 0x0600BC85 RID: 48261 RVA: 0x002C03AC File Offset: 0x002BE7AC
		public void ClearTempMaterialFuseModel()
		{
			if (this.tempMaterialFuseModel == null)
			{
				return;
			}
			if (this.tempMaterialFuseModel.materialModels != null)
			{
				this.tempMaterialFuseModel.materialModels.Clear();
			}
			if (this.tempMaterialFuseModel.ticketModels != null)
			{
				this.tempMaterialFuseModel.ticketModels.Clear();
			}
		}

		// Token: 0x0600BC86 RID: 48262 RVA: 0x002C0408 File Offset: 0x002BE808
		public List<StrengthenTicketFuseItemData> GetStrengthenTicketFuseItemDatas(bool bReverse = false)
		{
			List<StrengthenTicketFuseItemData> list = new List<StrengthenTicketFuseItemData>();
			List<ulong> ownStrengthenTicketItemDataGUIDs = this.GetOwnStrengthenTicketItemDataGUIDs();
			if (ownStrengthenTicketItemDataGUIDs == null || ownStrengthenTicketItemDataGUIDs.Count == 0)
			{
				return list;
			}
			for (int i = 0; i < ownStrengthenTicketItemDataGUIDs.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(ownStrengthenTicketItemDataGUIDs[i]);
				if (item != null && list != null)
				{
					int tableID = item.TableID;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						int strenTicketDataIndex = tableItem.StrenTicketDataIndex;
						StrengthenTicketTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(strenTicketDataIndex, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							StrengthenTicketFuseItemData strengthenTicketFuseItemData = new StrengthenTicketFuseItemData();
							strengthenTicketFuseItemData.ticketItemData = item;
							strengthenTicketFuseItemData.fuseValue = tableItem2.FuseValue;
							strengthenTicketFuseItemData.canFuse = (tableItem2.Compound == 1 && tableItem2.Level < this.fuseLimitLevel_Max && tableItem2.Level > this.fuseLimitLevel_Min);
							if (strengthenTicketFuseItemData.canFuse)
							{
								strengthenTicketFuseItemData.sProbabilityConvert = (float)tableItem2.Probility * 0.001f;
								strengthenTicketFuseItemData.sLevel = tableItem2.Level;
								strengthenTicketFuseItemData.bNotBindInt = ((item.BindAttr == ItemTable.eOwner.NOTBIND) ? 1 : 0);
								list.Add(strengthenTicketFuseItemData);
							}
						}
					}
				}
			}
			if (bReverse)
			{
				list.Sort((StrengthenTicketFuseItemData x, StrengthenTicketFuseItemData y) => -x.sLevel.CompareTo(y.sLevel) * 100 - x.sProbabilityConvert.CompareTo(y.sProbabilityConvert) * 20 - x.bNotBindInt.CompareTo(y.bNotBindInt));
			}
			else
			{
				list.Sort((StrengthenTicketFuseItemData x, StrengthenTicketFuseItemData y) => x.sLevel.CompareTo(y.sLevel) * 100 + x.sProbabilityConvert.CompareTo(y.sProbabilityConvert) * 20 + x.bNotBindInt.CompareTo(y.bNotBindInt));
			}
			return list;
		}

		// Token: 0x0600BC87 RID: 48263 RVA: 0x002C05C8 File Offset: 0x002BE9C8
		public bool CheckMaterialMergeIsEnough()
		{
			if (this.currSelectMaterialMergeModel == null)
			{
				return false;
			}
			if (this.currSelectMaterialMergeModel.needMaterialModel == null)
			{
				return false;
			}
			if (this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas == null)
			{
				return false;
			}
			for (int i = 0; i < this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas.Count; i++)
			{
				StrengthenTicketMergeItemData strengthenTicketMergeItemData = this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas[i];
				if (strengthenTicketMergeItemData != null && strengthenTicketMergeItemData.tempItemData != null)
				{
					if (!this.CheckItemCountEnough(strengthenTicketMergeItemData.tempItemData.ItemID, strengthenTicketMergeItemData.tempItemData.Count))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600BC88 RID: 48264 RVA: 0x002C0684 File Offset: 0x002BEA84
		public bool CheckIsCoin(int tableId)
		{
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableId);
			return commonItemTableDataByID != null && (commonItemTableDataByID.SubType == 27 || commonItemTableDataByID.SubType == 17);
		}

		// Token: 0x0600BC89 RID: 48265 RVA: 0x002C06C4 File Offset: 0x002BEAC4
		public bool CheckItemCountEnough(int tableId, int needCount)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableId, true);
			return ownedItemCount >= needCount;
		}

		// Token: 0x0600BC8A RID: 48266 RVA: 0x002C06E8 File Offset: 0x002BEAE8
		public int TryGetCoinIdByBindType(bool isBind)
		{
			int moneyIDByType;
			if (isBind)
			{
				moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
			}
			else
			{
				moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
			}
			return moneyIDByType;
		}

		// Token: 0x0600BC8B RID: 48267 RVA: 0x002C0720 File Offset: 0x002BEB20
		public ItemSimpleData TryGetFirstCoinItemDataInMaterials()
		{
			ItemSimpleData itemSimpleData = new ItemSimpleData();
			if (this.currSelectMaterialMergeModel == null || this.currSelectMaterialMergeModel.needMaterialModel == null)
			{
				return itemSimpleData;
			}
			List<StrengthenTicketMergeItemData> needMaterialDatas = this.currSelectMaterialMergeModel.needMaterialModel.needMaterialDatas;
			if (needMaterialDatas == null)
			{
				return itemSimpleData;
			}
			for (int i = 0; i < needMaterialDatas.Count; i++)
			{
				StrengthenTicketMergeItemData strengthenTicketMergeItemData = needMaterialDatas[i];
				if (strengthenTicketMergeItemData != null && strengthenTicketMergeItemData.tempItemData != null)
				{
					bool flag = this.CheckIsCoin(strengthenTicketMergeItemData.tempItemData.ItemID);
					if (flag)
					{
						itemSimpleData.ItemID = strengthenTicketMergeItemData.tempItemData.ItemID;
						itemSimpleData.Count = strengthenTicketMergeItemData.tempItemData.Count;
						break;
					}
				}
			}
			return itemSimpleData;
		}

		// Token: 0x0600BC8C RID: 48268 RVA: 0x002C07E0 File Offset: 0x002BEBE0
		public bool CheckFuseTicketCanAdd(StrengthenTicketFuseItemData fuseItemData)
		{
			if (this.ticketFuseReadyCapacity <= 0)
			{
				this._DebugDataManagerLoggger("CheckFuseTicketCanAdd", "please check merge frame: fuse capacity less zero");
				return false;
			}
			if (fuseItemData == null || fuseItemData.ticketItemData == null)
			{
				return false;
			}
			if (this.tempMaterialFuseModel == null)
			{
				return false;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			if (ticketModels == null || ticketModels.Count >= this.ticketFuseReadyCapacity)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_fuse_limit_num, CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			int tableID = fuseItemData.ticketItemData.TableID;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < ticketModels.Count; i++)
			{
				StrengthenTicketFuseItemData strengthenTicketFuseItemData = ticketModels[i];
				if (strengthenTicketFuseItemData != null && strengthenTicketFuseItemData.ticketItemData != null)
				{
					if (strengthenTicketFuseItemData.ticketItemData.TableID.Equals(tableID))
					{
						num++;
					}
					if (strengthenTicketFuseItemData.ticketItemData.GUID.Equals(fuseItemData.ticketItemData.GUID))
					{
						num2++;
					}
				}
			}
			if (!this.CheckItemCountEnough(tableID, num + 1) || fuseItemData.ticketItemData.Count < num2 + 1)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_notice_merge_material_not_enough, CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			ticketModels.Add(fuseItemData);
			return true;
		}

		// Token: 0x0600BC8D RID: 48269 RVA: 0x002C0928 File Offset: 0x002BED28
		public bool CheckFuseTicketCanRemove(StrengthenTicketFuseItemData fuseItemData)
		{
			if (fuseItemData == null || fuseItemData.ticketItemData == null)
			{
				return false;
			}
			if (this.tempMaterialFuseModel == null)
			{
				return false;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			if (ticketModels == null || ticketModels.Count <= 0)
			{
				return false;
			}
			if (!ticketModels.Contains(fuseItemData))
			{
				return false;
			}
			ticketModels.Remove(fuseItemData);
			return true;
		}

		// Token: 0x0600BC8E RID: 48270 RVA: 0x002C098C File Offset: 0x002BED8C
		public bool CheckFuseTicketOnReady(StrengthenTicketFuseItemData fuseItemData)
		{
			if (fuseItemData == null || fuseItemData.ticketItemData == null)
			{
				return false;
			}
			if (this.tempMaterialFuseModel == null)
			{
				return false;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			return ticketModels != null && ticketModels.Count > 0 && ticketModels.Contains(fuseItemData);
		}

		// Token: 0x0600BC8F RID: 48271 RVA: 0x002C09E8 File Offset: 0x002BEDE8
		public int CheckFuseTicketNumOnReadyByTableId(StrengthenTicketFuseItemData fuseItemData)
		{
			int num = 0;
			if (fuseItemData == null || fuseItemData.ticketItemData == null)
			{
				return num;
			}
			if (this.tempMaterialFuseModel == null)
			{
				return num;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			if (ticketModels == null || ticketModels.Count <= 0)
			{
				return num;
			}
			for (int i = 0; i < ticketModels.Count; i++)
			{
				StrengthenTicketFuseItemData strengthenTicketFuseItemData = ticketModels[i];
				if (strengthenTicketFuseItemData != null && strengthenTicketFuseItemData.ticketItemData != null)
				{
					if (strengthenTicketFuseItemData.ticketItemData.GUID.Equals(fuseItemData.ticketItemData.GUID))
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600BC90 RID: 48272 RVA: 0x002C0A94 File Offset: 0x002BEE94
		public void TryAddFuseMaterialCanUse()
		{
			if (this.m_FuseMaterialModels == null)
			{
				return;
			}
			if (this.tempMaterialFuseModel == null)
			{
				return;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			if (ticketModels == null || ticketModels.Count == 0)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < ticketModels.Count; i++)
			{
				StrengthenTicketFuseItemData strengthenTicketFuseItemData = ticketModels[i];
				if (strengthenTicketFuseItemData != null)
				{
					if (num < strengthenTicketFuseItemData.sLevel)
					{
						num = strengthenTicketFuseItemData.sLevel;
					}
				}
			}
			for (int j = 0; j < this.m_FuseMaterialModels.Count; j++)
			{
				StrengthenTicketFuseSpecialMaterial strengthenTicketFuseSpecialMaterial = this.m_FuseMaterialModels[j];
				if (strengthenTicketFuseSpecialMaterial != null)
				{
					if (strengthenTicketFuseSpecialMaterial.limitStrengthenLevelMin <= num && strengthenTicketFuseSpecialMaterial.limitStrengthenLevelMax >= num)
					{
						if (this.tempMaterialFuseModel.materialModels == null)
						{
							this.tempMaterialFuseModel.materialModels = new List<StrengthenTicketFuseSpecialMaterial>();
						}
						else
						{
							this.tempMaterialFuseModel.materialModels.Clear();
						}
						this.tempMaterialFuseModel.materialModels.Add(strengthenTicketFuseSpecialMaterial);
					}
				}
			}
		}

		// Token: 0x0600BC91 RID: 48273 RVA: 0x002C0BB4 File Offset: 0x002BEFB4
		public bool TryCalculateFuseOutputProbabilityInterval()
		{
			if (this.tempMaterialFuseModel == null)
			{
				return false;
			}
			List<StrengthenTicketFuseItemData> ticketModels = this.tempMaterialFuseModel.ticketModels;
			if (ticketModels == null)
			{
				return false;
			}
			if (ticketModels.Count != this.ticketFuseReadyCapacity)
			{
				return false;
			}
			if (ticketModels.Count != 2)
			{
				return false;
			}
			if (this.m_FuseProbabilityIntervalCorrectValueDic == null)
			{
				this._DebugDataManagerLoggger("TryCalculateFuseOutputProbabilityInterval", "tickets fuse fix value dictionary is null");
				return false;
			}
			StrengthenTicketFuseItemData strengthenTicketFuseItemData = ticketModels[0];
			StrengthenTicketFuseItemData strengthenTicketFuseItemData2 = ticketModels[1];
			if (strengthenTicketFuseItemData == null || strengthenTicketFuseItemData2 == null)
			{
				return false;
			}
			bool flag = false;
			if (strengthenTicketFuseItemData.sLevel > strengthenTicketFuseItemData2.sLevel)
			{
				flag = true;
			}
			else if (strengthenTicketFuseItemData.sLevel == strengthenTicketFuseItemData2.sLevel && strengthenTicketFuseItemData.sProbabilityConvert > strengthenTicketFuseItemData2.sProbabilityConvert)
			{
				flag = true;
			}
			if (flag)
			{
				StrengthenTicketFuseItemData strengthenTicketFuseItemData3 = strengthenTicketFuseItemData2;
				strengthenTicketFuseItemData2 = strengthenTicketFuseItemData;
				strengthenTicketFuseItemData = strengthenTicketFuseItemData3;
			}
			float num = (float)strengthenTicketFuseItemData.sLevel;
			float num2 = (float)strengthenTicketFuseItemData2.sLevel;
			float sProbabilityConvert = strengthenTicketFuseItemData.sProbabilityConvert;
			float sProbabilityConvert2 = strengthenTicketFuseItemData2.sProbabilityConvert;
			float num3 = 1f;
			if (this.m_FuseProbabilityIntervalCorrectValueDic != null && this.m_FuseProbabilityIntervalCorrectValueDic.ContainsKey(strengthenTicketFuseItemData2.sLevel + 1))
			{
				num3 = (float)this.m_FuseProbabilityIntervalCorrectValueDic[strengthenTicketFuseItemData2.sLevel + 1] * 0.1f;
			}
			float num4 = Mathf.Min(sProbabilityConvert / Mathf.Pow(4f, num2 - num) + sProbabilityConvert2, 1f) / num3;
			int perdictMaxPercent = Mathf.CeilToInt(num4 * 100f);
			this.tempMaterialFuseModel.perdictMinPercent = (int)(sProbabilityConvert * 100f);
			this.tempMaterialFuseModel.perdictMaxPercent = perdictMaxPercent;
			this.tempMaterialFuseModel.predictMinLevel = strengthenTicketFuseItemData.sLevel;
			this.tempMaterialFuseModel.predictMaxLevel = strengthenTicketFuseItemData2.sLevel + 1;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthenTicketFuseCalPercent, null, null, null, null);
			return true;
		}

		// Token: 0x0600BC92 RID: 48274 RVA: 0x002C0DA4 File Offset: 0x002BF1A4
		public bool CheckMaterialFuseIsEnough(Action<ulong, ulong> onReqFuseHandle = null, Action onReqCancelHandle = null)
		{
			if (this.tempMaterialFuseModel == null)
			{
				return false;
			}
			if (this.tempMaterialFuseModel.materialModels == null || this.tempMaterialFuseModel.ticketModels == null)
			{
				return false;
			}
			for (int i = 0; i < this.tempMaterialFuseModel.materialModels.Count; i++)
			{
				StrengthenTicketFuseSpecialMaterial strengthenTicketFuseSpecialMaterial = this.tempMaterialFuseModel.materialModels[i];
				if (strengthenTicketFuseSpecialMaterial == null || strengthenTicketFuseSpecialMaterial.fuseNeedItemData == null)
				{
					return false;
				}
				if (!this.CheckItemCountEnough(strengthenTicketFuseSpecialMaterial.fuseNeedItemData.ItemID, strengthenTicketFuseSpecialMaterial.fuseNeedItemData.Count))
				{
					return false;
				}
			}
			if (this.tempMaterialFuseModel.ticketModels.Count != this.ticketFuseReadyCapacity || this.ticketFuseReadyCapacity != 2)
			{
				return false;
			}
			StrengthenTicketFuseItemData aTicketData = this.tempMaterialFuseModel.ticketModels[0];
			StrengthenTicketFuseItemData bTicketData = this.tempMaterialFuseModel.ticketModels[1];
			if (aTicketData == null || aTicketData.ticketItemData == null || bTicketData == null || bTicketData.ticketItemData == null)
			{
				return false;
			}
			if (onReqFuseHandle != null)
			{
				if (!this.bCostBindTicketNotifyEnable)
				{
					if (aTicketData.bNotBindInt != 1 || bTicketData.bNotBindInt != 1)
					{
						this.OpenComCostNotifyFrame(new ComCostNotifyData
						{
							strContent = this.tr_notice_cost_bind_ticket_tip,
							delSetNotify = new Action<bool>(this.SetCostBindTicketNotifyEnable),
							delGetNotify = new Func<bool>(this.GetCostBindTicketNotifyEnable),
							delOnOkCallback = delegate()
							{
								onReqFuseHandle(aTicketData.ticketItemData.GUID, bTicketData.ticketItemData.GUID);
							},
							delOnCancelCallback = delegate()
							{
								if (onReqCancelHandle != null)
								{
									onReqCancelHandle();
								}
							}
						});
					}
					else
					{
						onReqFuseHandle(aTicketData.ticketItemData.GUID, bTicketData.ticketItemData.GUID);
					}
				}
				else
				{
					onReqFuseHandle(aTicketData.ticketItemData.GUID, bTicketData.ticketItemData.GUID);
				}
			}
			return true;
		}

		// Token: 0x0600BC93 RID: 48275 RVA: 0x002C0FE6 File Offset: 0x002BF3E6
		public void OpenStrengthenTicketMergeFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenTicketMergeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenTicketMergeFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenTicketMergeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600BC94 RID: 48276 RVA: 0x002C1016 File Offset: 0x002BF416
		public void CloseStrengthenTicketMergeFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StrengthenTicketMergeFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenTicketMergeFrame>(null, false);
			}
		}

		// Token: 0x0600BC95 RID: 48277 RVA: 0x002C1034 File Offset: 0x002BF434
		public bool GetCostBindTicketNotifyEnable()
		{
			return this.bCostBindTicketNotifyEnable;
		}

		// Token: 0x0600BC96 RID: 48278 RVA: 0x002C103C File Offset: 0x002BF43C
		public void SetCostBindTicketNotifyEnable(bool notify)
		{
			this.bCostBindTicketNotifyEnable = notify;
		}

		// Token: 0x0600BC97 RID: 48279 RVA: 0x002C1045 File Offset: 0x002BF445
		public void OpenComCostNotifyFrame(ComCostNotifyData notifyData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ComCostNotifyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ComCostNotifyFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ComCostNotifyFrame>(FrameLayer.Middle, notifyData, string.Empty);
		}

		// Token: 0x0600BC98 RID: 48280 RVA: 0x002C1078 File Offset: 0x002BF478
		private uint GetHavePrayedTimer()
		{
			uint result = 0U;
			OpActTaskData prayTaskData = this.GetPrayTaskData();
			if (prayTaskData != null)
			{
				OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(prayTaskData.dataid);
				if (limitTimeTaskData != null && limitTimeTaskData.parms != null && limitTimeTaskData.parms.Length > 0)
				{
					for (int i = 0; i < limitTimeTaskData.parms.Length; i++)
					{
						if (limitTimeTaskData.parms[i].key.Equals("times_var"))
						{
							result = limitTimeTaskData.parms[i].value;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600BC99 RID: 48281 RVA: 0x002C1110 File Offset: 0x002BF510
		public uint GetLeftPrayeTimer()
		{
			uint result;
			if (this.GetTotalPrayTimer() <= this.GetHavePrayedTimer())
			{
				result = 0U;
			}
			else
			{
				result = this.GetTotalPrayTimer() - this.GetHavePrayedTimer();
			}
			return result;
		}

		// Token: 0x0600BC9A RID: 48282 RVA: 0x002C1148 File Offset: 0x002BF548
		public uint GetTotalPrayTimer()
		{
			uint result = 0U;
			OpActTaskData prayTaskData = this.GetPrayTaskData();
			if (prayTaskData != null && prayTaskData.variables2 != null && prayTaskData.variables2.Length > 0)
			{
				result = prayTaskData.variables2[0];
			}
			return result;
		}

		// Token: 0x0600BC9B RID: 48283 RVA: 0x002C1187 File Offset: 0x002BF587
		public bool IsHaveLeftPrayTimer()
		{
			return this.GetLeftPrayeTimer() > 0U;
		}

		// Token: 0x0600BC9C RID: 48284 RVA: 0x002C1194 File Offset: 0x002BF594
		private OpActTaskData GetPrayTaskData()
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.BUFF_PRAY_ACTIVITY);
			OpActTaskData result = null;
			if (activeDataFromType == null)
			{
				return null;
			}
			bool flag = false;
			if (activeDataFromType.tasks != null && activeDataFromType.tasks.Length > 0)
			{
				for (int i = 0; i < activeDataFromType.tasks.Length; i++)
				{
					if (activeDataFromType.tasks[i].variables != null && activeDataFromType.tasks[i].variables.Length > 0)
					{
						for (int j = 0; j < activeDataFromType.tasks[i].variables.Length; j++)
						{
							if (activeDataFromType.tasks[i].variables[j] == 1U)
							{
								result = activeDataFromType.tasks[i];
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600BC9D RID: 48285 RVA: 0x002C126C File Offset: 0x002BF66C
		public string GetPrayTaskDes()
		{
			if (this.mStrengthTickActivityData != null)
			{
				return this.mStrengthTickActivityData.ruleDesc + TR.Value("strengthen_merge_left_time");
			}
			return string.Empty;
		}

		// Token: 0x04006A0B RID: 27147
		public const int OP_ACTIVITY_TASKID_TO_ACTID = 1000;

		// Token: 0x04006A0C RID: 27148
		private Dictionary<uint, OpActivityData> openedBuffPrayActivityDatas = new Dictionary<uint, OpActivityData>();

		// Token: 0x04006A0D RID: 27149
		private Dictionary<uint, OpActTask> totalActivityTasks = new Dictionary<uint, OpActTask>();

		// Token: 0x04006A0E RID: 27150
		private bool bFuncOpen;

		// Token: 0x04006A0F RID: 27151
		public bool BSyntheticFrameTip;

		// Token: 0x04006A10 RID: 27152
		public bool PrayActivityIsFinish = true;

		// Token: 0x04006A11 RID: 27153
		private int fuseLimitLevel_Max;

		// Token: 0x04006A12 RID: 27154
		private int fuseLimitLevel_Min;

		// Token: 0x04006A13 RID: 27155
		private int ticketFuseReadyCapacity = 2;

		// Token: 0x04006A14 RID: 27156
		private List<StrengthenTicketMaterialMergeModel> m_MaterialMergeTicketModels = new List<StrengthenTicketMaterialMergeModel>();

		// Token: 0x04006A15 RID: 27157
		private List<StrengthenTicketMaterialMergeModel> m_DisplayMaterialMergeTicketModels = new List<StrengthenTicketMaterialMergeModel>();

		// Token: 0x04006A16 RID: 27158
		private List<StrengthenTicketMaterialMergeIncreaseLevel> m_MaterialMergeIncreaseLevelModels = new List<StrengthenTicketMaterialMergeIncreaseLevel>();

		// Token: 0x04006A17 RID: 27159
		private StrengthenTicketMaterialMergeModel currSelectMaterialMergeModel = new StrengthenTicketMaterialMergeModel();

		// Token: 0x04006A18 RID: 27160
		private List<StrengthenTicketFuseSpecialMaterial> m_FuseMaterialModels = new List<StrengthenTicketFuseSpecialMaterial>();

		// Token: 0x04006A19 RID: 27161
		private StrengthenTicketMaterialFuseModel tempMaterialFuseModel = new StrengthenTicketMaterialFuseModel();

		// Token: 0x04006A1A RID: 27162
		private Dictionary<int, int> m_FuseProbabilityIntervalCorrectValueDic = new Dictionary<int, int>();

		// Token: 0x04006A1B RID: 27163
		private string tr_notice_fuse_limit_num = "准备融合强化券已经足够";

		// Token: 0x04006A1C RID: 27164
		private string tr_notice_merge_material_not_enough = "合成材料不足";

		// Token: 0x04006A1D RID: 27165
		private string tr_notice_dropdown_percent_format = "{0}%";

		// Token: 0x04006A1E RID: 27166
		private string tr_notice_cost_bind_ticket_tip = string.Empty;

		// Token: 0x04006A1F RID: 27167
		private bool bCostBindTicketNotifyEnable;

		// Token: 0x04006A20 RID: 27168
		private OpActivityData mStrengthTickActivityData;
	}
}
