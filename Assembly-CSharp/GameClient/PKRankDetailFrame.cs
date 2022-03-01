using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200198C RID: 6540
	internal class PKRankDetailFrame : ClientFrame
	{
		// Token: 0x0600FE7A RID: 65146 RVA: 0x00466233 File Offset: 0x00464633
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKRankDetail";
		}

		// Token: 0x0600FE7B RID: 65147 RVA: 0x0046623A File Offset: 0x0046463A
		protected override void _OnOpenFrame()
		{
			this._InitSeasonName();
			this._InitPKRank();
			this._InitPromotion();
			this._InitAttrDesc();
			this._InitRewardsGroup();
			this._BindGameEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FE7C RID: 65148 RVA: 0x00466273 File Offset: 0x00464673
		protected override void _OnCloseFrame()
		{
			this._ClearSeasonName();
			this._ClearPKRank();
			this._ClearPromotion();
			this._ClearAttrDesc();
			this._ClearRewardsGroup();
			this._UnBindGameEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600FE7D RID: 65149 RVA: 0x004662AC File Offset: 0x004646AC
		private void _BindGameEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKSelfLevelUpdated, new ClientEventSystem.UIEventHandler(this._OnPKRankUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonDataUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SeasonStarted, new ClientEventSystem.UIEventHandler(this._OnSeasonStarted));
		}

		// Token: 0x0600FE7E RID: 65150 RVA: 0x00466340 File Offset: 0x00464740
		private void _UnBindGameEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKSelfLevelUpdated, new ClientEventSystem.UIEventHandler(this._OnPKRankUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonDataUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SeasonStarted, new ClientEventSystem.UIEventHandler(this._OnSeasonStarted));
		}

		// Token: 0x0600FE7F RID: 65151 RVA: 0x004663D4 File Offset: 0x004647D4
		private void _InitSeasonName()
		{
			for (int i = 0; i < this.m_objDigitRoot.transform.childCount; i++)
			{
				this.m_objDigitRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
			int num = 0;
			int j = DataManager<SeasonDataManager>.GetInstance().seasonID;
			while (j > 0)
			{
				int num2 = j % 10;
				GameObject gameObject;
				if (num < this.m_objDigitRoot.transform.childCount)
				{
					gameObject = this.m_objDigitRoot.transform.GetChild(num).gameObject;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objDigitTemplate);
					gameObject.transform.SetParent(this.m_objDigitRoot.transform, false);
					gameObject.transform.SetAsFirstSibling();
				}
				gameObject.SetActive(true);
				Image component = gameObject.GetComponent<Image>();
				ETCImageLoader.LoadSprite(ref component, string.Format(this.m_strDigitPath, num2), true);
				j /= 10;
				num++;
			}
		}

		// Token: 0x0600FE80 RID: 65152 RVA: 0x004664D7 File Offset: 0x004648D7
		private void _ClearSeasonName()
		{
		}

		// Token: 0x0600FE81 RID: 65153 RVA: 0x004664D9 File Offset: 0x004648D9
		private void _InitPKRank()
		{
			this.m_comPKRank = ComPKRank.Create(this.m_objRankRoot);
			this._UpdatePKRank();
		}

		// Token: 0x0600FE82 RID: 65154 RVA: 0x004664F2 File Offset: 0x004648F2
		private void _UpdatePKRank()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonExp);
			}
		}

		// Token: 0x0600FE83 RID: 65155 RVA: 0x00466524 File Offset: 0x00464924
		private void _ClearPKRank()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Clear();
				this.m_comPKRank = null;
			}
		}

		// Token: 0x0600FE84 RID: 65156 RVA: 0x0046654C File Offset: 0x0046494C
		private void _InitPromotion()
		{
			PromotionInfo promotionInfo = DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo(DataManager<SeasonDataManager>.GetInstance().seasonLevel, PKResult.INVALID);
			if (promotionInfo.eState == EPromotionState.Promoting)
			{
				this.m_objPromotionRoot.SetActive(true);
				this._SetChildrenEnable(this.m_objRecordRoot, false);
				for (int i = 0; i < promotionInfo.nTotalCount; i++)
				{
					GameObject gameObject;
					if (i < this.m_objRecordRoot.transform.childCount)
					{
						gameObject = this.m_objRecordRoot.transform.GetChild(i).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
						gameObject.transform.SetParent(this.m_objRecordRoot.transform, false);
					}
					gameObject.SetActive(true);
					this._SetChildrenEnable(gameObject, false);
				}
				List<byte> seasonUplevelRecords = DataManager<SeasonDataManager>.GetInstance().seasonUplevelRecords;
				if (seasonUplevelRecords != null && seasonUplevelRecords.Count <= this.m_objRecordRoot.transform.childCount)
				{
					for (int j = 0; j < seasonUplevelRecords.Count; j++)
					{
						GameObject gameObject2 = this.m_objRecordRoot.transform.GetChild(j).gameObject;
						if (seasonUplevelRecords[j] == 1)
						{
							Utility.FindGameObject(gameObject2, "Win", true).SetActive(true);
						}
						else
						{
							Utility.FindGameObject(gameObject2, "Lose", true).SetActive(true);
						}
					}
				}
				this.m_labPromotionDesc.text = TR.Value("pk_rank_detail_promotion_rule", promotionInfo.nTotalCount, promotionInfo.nTargetWinCount, DataManager<SeasonDataManager>.GetInstance().GetRankName(promotionInfo.nNextSeasonLevel, true));
			}
			else
			{
				this.m_objPromotionRoot.SetActive(false);
			}
		}

		// Token: 0x0600FE85 RID: 65157 RVA: 0x004666F7 File Offset: 0x00464AF7
		private void _ClearPromotion()
		{
		}

		// Token: 0x0600FE86 RID: 65158 RVA: 0x004666FC File Offset: 0x00464AFC
		private void _InitAttrDesc()
		{
			SeasonAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonAttrTable>(DataManager<SeasonDataManager>.GetInstance().seasonAttrID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_labAttrDesc.text = string.Empty;
				for (int i = 0; i < tableItem.Descs.Count; i++)
				{
					Text labAttrDesc = this.m_labAttrDesc;
					labAttrDesc.text += tableItem.Descs[i];
					Text labAttrDesc2 = this.m_labAttrDesc;
					labAttrDesc2.text += '\n';
				}
			}
			else
			{
				this.m_labAttrDesc.text = string.Empty;
				Logger.LogErrorFormat("赛季属性表找不到ID:{0}", new object[]
				{
					DataManager<SeasonDataManager>.GetInstance().seasonAttrID
				});
			}
			if (DataManager<SeasonDataManager>.GetInstance().IsBattleFailReduceRank(DataManager<SeasonDataManager>.GetInstance().seasonLevel))
			{
				this.m_labFailLevelReduceRule.text = TR.Value("pk_rank_detail_fail_reduce_rank");
			}
			else
			{
				this.m_labFailLevelReduceRule.text = TR.Value("pk_rank_detail_fail_not_reduce_rank");
			}
		}

		// Token: 0x0600FE87 RID: 65159 RVA: 0x00466818 File Offset: 0x00464C18
		private void _ClearAttrDesc()
		{
		}

		// Token: 0x0600FE88 RID: 65160 RVA: 0x0046681C File Offset: 0x00464C1C
		private void _InitRewardsGroup()
		{
			this.m_repeatCallSeasonTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				this.m_labSeasonTimeLeft.text = TR.Value("pk_rank_detail_time_left", DataManager<SeasonDataManager>.GetInstance().seasonID, this._GetSeasonTimeLeftDesc());
			}, 9999999, true);
			int count = DataManager<CountDataManager>.GetInstance().GetCount("season_max_level");
			SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(count, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_labMatchRewardDesc.text = TR.Value("pk_rank_detail_season_reward_desc", DataManager<SeasonDataManager>.GetInstance().GetRankName(count, true));
				for (int i = 0; i < tableItem.SeasonRewards.Count; i++)
				{
					string[] array = tableItem.SeasonRewards[i].Split(new char[]
					{
						','
					});
					if (array.Length == 2)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
						if (itemData != null)
						{
							itemData.Count = int.Parse(array[1]);
							GameObject gameObject;
							if (i < this.m_objMatchRewardRoot.transform.childCount)
							{
								gameObject = this.m_objMatchRewardRoot.transform.GetChild(i).gameObject;
							}
							else
							{
								gameObject = Object.Instantiate<GameObject>(this.m_objMatchRewardTemplate);
								gameObject.transform.SetParent(this.m_objMatchRewardRoot.transform, false);
							}
							gameObject.SetActive(true);
							ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
							if (comItem == null)
							{
								comItem = base.CreateComItem(gameObject);
							}
							comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
							});
						}
					}
				}
			}
			else
			{
				Logger.LogErrorFormat("赛季{0} 最高段位{1} 找不到表数据！", new object[]
				{
					DataManager<SeasonDataManager>.GetInstance().seasonID,
					count
				});
			}
			this._SetupDailyRewards();
			this._SetupBattleInfo();
		}

		// Token: 0x0600FE89 RID: 65161 RVA: 0x004669F1 File Offset: 0x00464DF1
		private void _ClearRewardsGroup()
		{
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallSeasonTime);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.DailyProve);
		}

		// Token: 0x0600FE8A RID: 65162 RVA: 0x00466A18 File Offset: 0x00464E18
		private void _SetupDailyRewards()
		{
			int num = 1;
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				uint nTaskID = list[i].taskID;
				if (Utility.IsDailyProve(nTaskID))
				{
					MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)nTaskID, string.Empty, string.Empty);
					Utility.DailyProveTaskConfig dailyProveTaskConfig = Utility.GetDailyProveTaskConfig((int)nTaskID);
					GameObject gameObject = Utility.FindGameObject(this.frame, string.Format("Right/RewardsGroup/TabGroup/Content0/Daily{0}", num), true);
					Utility.GetComponetInChild<Text>(gameObject, "Description").text = DataManager<MissionManager>.GetInstance().GetMissionName(nTaskID);
					Utility.GetComponetInChild<Text>(gameObject, "ProgressBar/Text").text = string.Format("{0}/{1}", dailyProveTaskConfig.iPreValue, dailyProveTaskConfig.iAftValue);
					string[] array = tableItem.Award.Split(new char[]
					{
						','
					});
					if (array.Length > 0)
					{
						string[] array2 = array[0].Split(new char[]
						{
							'_'
						});
						if (array2.Length == 2)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
							if (itemData != null)
							{
								itemData.Count = int.Parse(array2[1]);
								GameObject gameObject2 = Utility.FindGameObject(gameObject, "award", true);
								ComItem comItem = gameObject2.GetComponentInChildren<ComItem>();
								if (comItem == null)
								{
									comItem = base.CreateComItem(gameObject2);
								}
								comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
								});
							}
						}
					}
					ComButtonEnbale componetInChild = Utility.GetComponetInChild<ComButtonEnbale>(gameObject, "btReceive");
					Text componetInChild2 = Utility.GetComponetInChild<Text>(gameObject, "btReceive/Text");
					if (list[i].status >= 5)
					{
						componetInChild.SetEnable(false);
						componetInChild2.text = TR.Value("pk_rank_detail_reward_complete");
					}
					else
					{
						componetInChild2.text = TR.Value("pk_rank_detail_reward_get");
						if (list[i].status == 2)
						{
							componetInChild.SetEnable(true);
						}
						else
						{
							componetInChild.SetEnable(false);
						}
					}
					Button componetInChild3 = Utility.GetComponetInChild<Button>(gameObject, "btReceive");
					componetInChild3.onClick.RemoveAllListeners();
					componetInChild3.onClick.AddListener(delegate()
					{
						DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(nTaskID, TaskSubmitType.TASK_SUBMIT_UI, 0U);
					});
					num++;
					if (num > 2)
					{
						break;
					}
				}
			}
		}

		// Token: 0x0600FE8B RID: 65163 RVA: 0x00466CA4 File Offset: 0x004650A4
		private void _SetupBattleInfo()
		{
			PkStatistic pkStatisticDataByPkType = DataManager<PlayerBaseData>.GetInstance().GetPkStatisticDataByPkType(PkType.Pk_Season_1v1);
			if (pkStatisticDataByPkType != null)
			{
				float num = 0f;
				if (pkStatisticDataByPkType.totalNum > 0U)
				{
					num = pkStatisticDataByPkType.totalWinNum / pkStatisticDataByPkType.totalNum * 100f;
				}
				this.m_labRaceCount.text = TR.Value("pk_rank_detail_race_count", pkStatisticDataByPkType.totalNum);
				this.m_labWinRate.text = TR.Value("pk_rank_detail_race_win_rate", num.ToString("f2"));
			}
			else
			{
				this.m_labRaceCount.text = TR.Value("pk_rank_detail_race_count", 0);
				this.m_labWinRate.text = TR.Value("pk_rank_detail_race_win_rate", "0.00");
			}
			this.m_labRank.text = TR.Value("pk_rank_detail_rank_asking");
			DataManager<SeasonDataManager>.GetInstance().RequestSelfPKRank();
		}

		// Token: 0x0600FE8C RID: 65164 RVA: 0x00466D88 File Offset: 0x00465188
		private string _GetSeasonTimeLeftDesc()
		{
			int num = DataManager<SeasonDataManager>.GetInstance().seasonEndTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
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
				string str = string.Empty;
				str += string.Format("{0}天", num4);
				str += string.Format("{0:D2}小时", num3);
				str += string.Format("{0:D2}分", num2);
				return str + string.Format("{0:D2}秒", num5);
			}
			return string.Empty;
		}

		// Token: 0x0600FE8D RID: 65165 RVA: 0x00466E64 File Offset: 0x00465264
		private void _SetChildrenEnable(GameObject a_obj, bool a_bEnable)
		{
			for (int i = 0; i < a_obj.transform.childCount; i++)
			{
				a_obj.transform.GetChild(i).gameObject.SetActive(a_bEnable);
			}
		}

		// Token: 0x0600FE8E RID: 65166 RVA: 0x00466EA4 File Offset: 0x004652A4
		private void _OnPKRankUpdated(UIEvent a_event)
		{
			uint num = (uint)a_event.Param1;
			if (num > 0U)
			{
				this.m_labRank.text = TR.Value("pk_rank_detail_rank", (uint)a_event.Param1);
			}
			else
			{
				this.m_labRank.text = TR.Value("pk_rank_detail_rank_invalid");
			}
		}

		// Token: 0x0600FE8F RID: 65167 RVA: 0x00466F03 File Offset: 0x00465303
		private void _OnPkRankChanged(UIEvent a_event)
		{
			this._UpdatePKRank();
		}

		// Token: 0x0600FE90 RID: 65168 RVA: 0x00466F0B File Offset: 0x0046530B
		private void _OnMissionUpdated(UIEvent a_event)
		{
			if (!Utility.IsDailyProve((uint)a_event.Param1))
			{
				return;
			}
			this._SetupDailyRewards();
		}

		// Token: 0x0600FE91 RID: 65169 RVA: 0x00466F29 File Offset: 0x00465329
		private void _OnSeasonDataUpdated(UIEvent a_event)
		{
			this._InitAttrDesc();
		}

		// Token: 0x0600FE92 RID: 65170 RVA: 0x00466F31 File Offset: 0x00465331
		private void _OnSeasonStarted(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<PKRankDetailFrame>(this, false);
		}

		// Token: 0x0600FE93 RID: 65171 RVA: 0x00466F40 File Offset: 0x00465340
		[UIEventHandle("Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<PKRankDetailFrame>(this, false);
		}

		// Token: 0x0400A07C RID: 41084
		[UIObject("Left/RankRoot")]
		private GameObject m_objRankRoot;

		// Token: 0x0400A07D RID: 41085
		[UIControl("Left/FailLevelReduceRule", null, 0)]
		private Text m_labFailLevelReduceRule;

		// Token: 0x0400A07E RID: 41086
		[UIObject("Left/Promotion")]
		private GameObject m_objPromotionRoot;

		// Token: 0x0400A07F RID: 41087
		[UIObject("Left/Promotion/Records/Viewport/Content")]
		private GameObject m_objRecordRoot;

		// Token: 0x0400A080 RID: 41088
		[UIObject("Left/Promotion/Records/Viewport/Content/Template")]
		private GameObject m_objRecordTemplate;

		// Token: 0x0400A081 RID: 41089
		[UIControl("Left/Promotion/Desc", null, 0)]
		private Text m_labPromotionDesc;

		// Token: 0x0400A082 RID: 41090
		[UIControl("Left/AttrDesc/Content", null, 0)]
		private Text m_labAttrDesc;

		// Token: 0x0400A083 RID: 41091
		[UIControl("Right/SeasonTimeLeft", null, 0)]
		private Text m_labSeasonTimeLeft;

		// Token: 0x0400A084 RID: 41092
		[UIObject("Right/TitleGroup/Name/Numbers")]
		private GameObject m_objDigitRoot;

		// Token: 0x0400A085 RID: 41093
		[UIObject("Right/TitleGroup/Name/Numbers/Number")]
		private GameObject m_objDigitTemplate;

		// Token: 0x0400A086 RID: 41094
		[UIControl("Right/RewardsGroup/MatchGroup/Desc", null, 0)]
		private Text m_labMatchRewardDesc;

		// Token: 0x0400A087 RID: 41095
		[UIObject("Right/RewardsGroup/MatchGroup/Items/Viewport/Content")]
		private GameObject m_objMatchRewardRoot;

		// Token: 0x0400A088 RID: 41096
		[UIObject("Right/RewardsGroup/MatchGroup/Items/Viewport/Content/Item")]
		private GameObject m_objMatchRewardTemplate;

		// Token: 0x0400A089 RID: 41097
		[UIControl("Right/RewardsGroup/TabGroup/Content1/RaceCount", null, 0)]
		private Text m_labRaceCount;

		// Token: 0x0400A08A RID: 41098
		[UIControl("Right/RewardsGroup/TabGroup/Content1/WinRate", null, 0)]
		private Text m_labWinRate;

		// Token: 0x0400A08B RID: 41099
		[UIControl("Right/RewardsGroup/TabGroup/Content1/Rank", null, 0)]
		private Text m_labRank;

		// Token: 0x0400A08C RID: 41100
		[UIControl("Right/RewardsGroup/TabGroup/Content1/HonorMedal", null, 0)]
		private Text m_labHonorMedal;

		// Token: 0x0400A08D RID: 41101
		private string m_strDigitPath = "UI/Image/Packed/p_UI_SeasonNumber.png:UI_Season_Number_0{0}";

		// Token: 0x0400A08E RID: 41102
		private ComPKRank m_comPKRank;

		// Token: 0x0400A08F RID: 41103
		private DelayCallUnitHandle m_repeatCallSeasonTime;
	}
}
