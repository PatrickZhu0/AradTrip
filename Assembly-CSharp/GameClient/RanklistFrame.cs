using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D7 RID: 6615
	internal class RanklistFrame : ClientFrame
	{
		// Token: 0x06010356 RID: 66390 RVA: 0x0048613D File Offset: 0x0048453D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Ranklist/Ranklist";
		}

		// Token: 0x06010357 RID: 66391 RVA: 0x00486144 File Offset: 0x00484544
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.m_currRanklist = (SortListType)this.userData;
			}
			if (this.m_currRanklist == SortListType.SORTLIST_CHIJI_SCORE && this.m_comScrollRect != null)
			{
				this.m_comScrollRect.verticalNormalizedPosition = 0f;
			}
			this._InitRanklists();
			this._RegisterUIEvent();
			this.m_comRankGroup.SetCurrentToggle((int)this.m_currRanklist);
			this.m_objLineSelect.SetActive(false);
			if (this.mToggle250 != null)
			{
				this.mToggle250.CustomActive(DataManager<ChijiDataManager>.GetInstance().MainFrameChijiButtonIsShow());
			}
		}

		// Token: 0x06010358 RID: 66392 RVA: 0x004861ED File Offset: 0x004845ED
		protected override void _OnCloseFrame()
		{
			this.m_arrRanklist.Clear();
			this.m_currRanklist = SortListType.SORTLIST_LEVEL;
			this._UnRegisterUIEvent();
		}

		// Token: 0x06010359 RID: 66393 RVA: 0x00486207 File Offset: 0x00484607
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RanklistUpdated, new ClientEventSystem.UIEventHandler(this._OnRanklistUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinSuccess));
		}

		// Token: 0x0601035A RID: 66394 RVA: 0x0048623F File Offset: 0x0048463F
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RanklistUpdated, new ClientEventSystem.UIEventHandler(this._OnRanklistUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestJoinSuccess, new ClientEventSystem.UIEventHandler(this._OnRequestJoinSuccess));
		}

		// Token: 0x0601035B RID: 66395 RVA: 0x00486278 File Offset: 0x00484678
		private void _InitRanklists()
		{
			this.m_comRankGroup.Initialize();
			if (this.m_comRankGroup.comToggles != null)
			{
				for (int i = 0; i < this.m_comRankGroup.comToggles.Length; i++)
				{
					RanklistFrame.Ranklist ranklist = new RanklistFrame.Ranklist();
					ranklist.arrTypes.Add((SortListType)this.m_comRankGroup.comToggles[i].userData);
					ranklist.data = null;
					ranklist.objRanklistRoot = Utility.FindGameObject(this.frame, string.Format("Content/List{0}", (int)ranklist.arrTypes[0]), true);
					this.m_arrRanklist.Add(ranklist);
				}
			}
			this.m_comRankGroup.onSelectChanged.AddListener(delegate(int a_type, bool a_checked)
			{
				RanklistFrame.Ranklist ranklist2 = this._GetRanklist((SortListType)a_type);
				if (ranklist2 != null)
				{
					if (a_checked)
					{
						if (ranklist2.comToggleGroup == null)
						{
							UIPrefabWrapper component = ranklist2.objRanklistRoot.GetComponent<UIPrefabWrapper>();
							if (component != null)
							{
								ranklist2.objRanklistRoot = component.LoadUIPrefab(ranklist2.objRanklistRoot.transform);
								this._InitRankList(ranklist2);
							}
							ranklist2.objRanklistRoot.SetActive(true);
							if (ranklist2.rankListControl != null)
							{
								ranklist2.rankListControl.SetElementAmount(0);
							}
							if (ranklist2.objMyRank != null)
							{
								ranklist2.objMyRank.SetActive(false);
							}
							this.m_currRanklist = (SortListType)a_type;
							if (this.m_currRanklist == SortListType.SORTLIST_GUILD_LEVEL || this.m_currRanklist == SortListType.SORTLIST_CHIJI_SCORE)
							{
								this._RequestRanklist(a_type, 0, 20);
							}
							else
							{
								this._RequestRanklist(a_type, 0, 100);
							}
						}
						else if (a_type != 3)
						{
							SortListType sortListType = SortListType.SORTLIST_INVALID;
							SortListType sortListType2 = SortListType.SORTLIST_INVALID;
							if (ranklist2.arrTypes != null)
							{
								for (int j = 0; j < ranklist2.arrTypes.Count; j++)
								{
									SortListType sortListType3 = ranklist2.arrTypes[j];
									int num = this.m_dictSortTypeWithJobID[sortListType3];
									if (num == 0)
									{
										sortListType = sortListType3;
									}
									else if (num == DataManager<PlayerBaseData>.GetInstance().JobTableID)
									{
										sortListType2 = sortListType3;
									}
								}
							}
							if (ranklist2.comToggleGroup != null)
							{
								if (sortListType != SortListType.SORTLIST_INVALID)
								{
									ranklist2.comToggleGroup.SetCurrentToggle((int)sortListType);
								}
								else if (sortListType2 != SortListType.SORTLIST_INVALID)
								{
									ranklist2.comToggleGroup.SetCurrentToggle((int)sortListType2);
								}
								else
								{
									ranklist2.comToggleGroup.SetCurrentToggle((int)ranklist2.arrTypes[0]);
								}
							}
						}
						else if (ranklist2.comToggleGroup != null)
						{
							ranklist2.comToggleGroup.SetCurrentToggle(a_type);
						}
					}
					else if (ranklist2.objRanklistRoot != null)
					{
						ranklist2.objRanklistRoot.SetActive(false);
					}
				}
			});
		}

		// Token: 0x0601035C RID: 66396 RVA: 0x00486340 File Offset: 0x00484740
		private void _InitRankList(RanklistFrame.Ranklist ranklist)
		{
			try
			{
				ranklist.objMyRank = Utility.FindGameObject(ranklist.objRanklistRoot, "Content/MyRank", true);
				ranklist.rankListControl = Utility.GetComponetInChild<ComUIListScript>(ranklist.objRanklistRoot, "Content");
				if (ranklist.rankListControl != null)
				{
					ranklist.rankListControl.Initialize();
					ranklist.rankListControl.onItemVisiable = delegate(ComUIListElementScript item)
					{
						if (ranklist.data != null && item.m_index >= 0 && item.m_index < ranklist.data.entries.Count)
						{
							this._SetupOneLine(item.gameObject, this.m_currRanklist, ranklist.data.entries[item.m_index], true, false);
						}
					};
					ranklist.rankListControl.OnItemRecycle = delegate(ComUIListElementScript item)
					{
						if (Utility.FindGameObject(item.gameObject, "Valid/Select", false) && this.m_objLineSelect != null)
						{
							this.m_objLineSelect.transform.SetParent(this.frame.transform, false);
							this.m_objLineSelect.SetActive(false);
						}
						GameObject[] array = new GameObject[]
						{
							Utility.FindGameObject(item.gameObject, string.Format("Effect{0}", 1), false),
							Utility.FindGameObject(item.gameObject, string.Format("Effect{0}", 2), false),
							Utility.FindGameObject(item.gameObject, string.Format("Effect{0}", 3), false)
						};
						for (int j = 0; j < 3; j++)
						{
							if (array[j] != null)
							{
								array[j].SetActive(false);
							}
						}
					};
				}
				ranklist.comToggleGroup = Utility.GetComponetInChild<ComToggleGroup>(ranklist.objRanklistRoot, "Filter/Viewport/Content");
				if (ranklist.comToggleGroup != null)
				{
					ranklist.comToggleGroup.Initialize();
					for (int i = 0; i < ranklist.comToggleGroup.comToggles.Length; i++)
					{
						ComToggle comToggle = ranklist.comToggleGroup.comToggles[i];
						if (comToggle != null)
						{
							SortListType userData = (SortListType)comToggle.userData;
							if (!ranklist.arrTypes.Contains(userData))
							{
								ranklist.arrTypes.Add(userData);
							}
						}
					}
					ranklist.comToggleGroup.onSelectChanged.AddListener(delegate(int a_type, bool a_checked)
					{
						if (a_checked)
						{
							if (ranklist.objRanklistRoot != null)
							{
								ranklist.objRanklistRoot.SetActive(true);
							}
							if (ranklist.rankListControl != null)
							{
								ranklist.rankListControl.SetElementAmount(0);
							}
							if (ranklist.objMyRank != null)
							{
								ranklist.objMyRank.SetActive(false);
							}
							this.m_currRanklist = (SortListType)a_type;
							this._RequestRanklist(a_type, 0, 100);
						}
						else
						{
							ranklist.objRanklistRoot.SetActive(false);
						}
					});
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("_InitRankList:{0}", new object[]
				{
					ex.Message
				});
			}
		}

		// Token: 0x0601035D RID: 66397 RVA: 0x0048651C File Offset: 0x0048491C
		private void _SetupOneLine(GameObject a_objLine, SortListType a_eType, BaseSortListEntry a_data, bool a_bCanSelect, bool a_bFilter)
		{
			RanklistFrame.<_SetupOneLine>c__AnonStorey1 <_SetupOneLine>c__AnonStorey = new RanklistFrame.<_SetupOneLine>c__AnonStorey1();
			<_SetupOneLine>c__AnonStorey.a_eType = a_eType;
			<_SetupOneLine>c__AnonStorey.a_data = a_data;
			<_SetupOneLine>c__AnonStorey.$this = this;
			if (a_objLine == null || <_SetupOneLine>c__AnonStorey.a_data == null)
			{
				return;
			}
			<_SetupOneLine>c__AnonStorey.objValid = Utility.FindGameObject(a_objLine, "Valid", true);
			GameObject gameObject = Utility.FindGameObject(a_objLine, "Invalid", true);
			if (<_SetupOneLine>c__AnonStorey.objValid == null || gameObject == null)
			{
				return;
			}
			if (a_bCanSelect)
			{
				Button componetInChild = Utility.GetComponetInChild<Button>(<_SetupOneLine>c__AnonStorey.objValid, "BtnSelect");
				if (componetInChild == null)
				{
					return;
				}
				componetInChild.onClick.RemoveAllListeners();
				componetInChild.onClick.AddListener(delegate()
				{
					<_SetupOneLine>c__AnonStorey.$this.m_objLineSelect.transform.SetParent(<_SetupOneLine>c__AnonStorey.objValid.transform, false);
					<_SetupOneLine>c__AnonStorey.$this.m_objLineSelect.SetActive(true);
					if (<_SetupOneLine>c__AnonStorey.a_eType != SortListType.SORTLIST_GUILD_LEVEL && <_SetupOneLine>c__AnonStorey.a_eType != SortListType.SORTLIST_ADVENTURE_TEAM_GRADE)
					{
						if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_HANDCANNON || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_HUGESWORD || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_KATANA || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_REVOLVER || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_STAFF || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_WAND || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_SHORT_SWORD || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_OFG || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_GLOVE || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_EAST_STICK || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_CROSSBOW || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_RIFLE || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_BEAMSWORD || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_SICKLE || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_AXE || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_BEADS || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_CROSS || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_SPEAR || <_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON_TT_ITEM_STICK)
						{
							ItemSortListEntry itemSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as ItemSortListEntry;
							if (itemSortListEntry != null)
							{
								DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(itemSortListEntry.ownerId, 0U, 0U);
							}
							else
							{
								Logger.LogErrorFormat("RankListFrame itemSortListEntry is null and data id is {0}", new object[]
								{
									<_SetupOneLine>c__AnonStorey.a_data.id
								});
							}
						}
						else
						{
							DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(<_SetupOneLine>c__AnonStorey.a_data.id, 0U, 0U);
						}
					}
				});
			}
			switch (<_SetupOneLine>c__AnonStorey.a_eType)
			{
			case SortListType.SORTLIST_LEVEL_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_JIANHUN:
			case SortListType.SORTLIST_LEVEL_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_GUIQI:
			case SortListType.SORTLIST_LEVEL_OCCU_AXIULUO:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_LEVEL_OCCU_MANYOU:
			case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI:
			case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_MOFASHI:
			case SortListType.SORTLIST_LEVEL_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_LEVEL_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_LEVEL_OCCU_SANDA:
			case SortListType.SORTLIST_LEVEL_OCCU_JIEBA:
			case SortListType.SORTLIST_LEVEL_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_LEVEL_OCCU_QUMO:
			case SortListType.SORTLIST_LEVEL_OCCU_SHENGQISHI:
				goto IL_62E;
			default:
				if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_LEVEL)
				{
					goto IL_62E;
				}
				if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_WEAPON)
				{
					goto IL_9EF;
				}
				if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_ACHIEVEMENT_SCORE)
				{
					AchievementScoreSortListEntry achievementScoreSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as AchievementScoreSortListEntry;
					if (achievementScoreSortListEntry != null)
					{
						this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)achievementScoreSortListEntry.ranking);
						Text componetInChild2 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name");
						componetInChild2.text = achievementScoreSortListEntry.name;
						RelationData relationData = null;
						DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(achievementScoreSortListEntry.id, ref relationData);
						if (relationData != null && !string.IsNullOrEmpty(relationData.remark))
						{
							componetInChild2.text = relationData.remark;
						}
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Job").text = this._GetJobName((int)achievementScoreSortListEntry.occu);
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Score").text = achievementScoreSortListEntry.score.ToString();
					}
					return;
				}
				if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_ADVENTURE_TEAM_GRADE)
				{
					AdventureTeamGradeSortListEntry adventureTeamGradeSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as AdventureTeamGradeSortListEntry;
					if (adventureTeamGradeSortListEntry != null)
					{
						bool flag = true;
						if (string.IsNullOrEmpty(adventureTeamGradeSortListEntry.adventureTeamName))
						{
							flag = false;
						}
						<_SetupOneLine>c__AnonStorey.objValid.CustomActive(flag);
						gameObject.CustomActive(!flag);
						if (flag)
						{
							this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)adventureTeamGradeSortListEntry.ranking);
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name").text = adventureTeamGradeSortListEntry.adventureTeamName;
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = adventureTeamGradeSortListEntry.adventureTeamLevel.ToString();
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Point").text = adventureTeamGradeSortListEntry.adventureTeamScore.ToString();
							ComAdventureTeamGrade componetInChild3 = Utility.GetComponetInChild<ComAdventureTeamGrade>(<_SetupOneLine>c__AnonStorey.objValid, "Grade");
							if (componetInChild3)
							{
								bool bActive = componetInChild3.SetGradeImg((AdventureTeamGradeTable.eGradeEnum)adventureTeamGradeSortListEntry.adventureTeamGrade);
								componetInChild3.CustomActive(bActive);
							}
							Image componetInChild4 = Utility.GetComponetInChild<Image>(<_SetupOneLine>c__AnonStorey.objValid, "Rank/HeadImg");
							string adventureTeamTitleResPathByRanking = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamTitleResPathByRanking((int)adventureTeamGradeSortListEntry.ranking);
							if (componetInChild4 && !string.IsNullOrEmpty(adventureTeamTitleResPathByRanking))
							{
								ETCImageLoader.LoadSprite(ref componetInChild4, adventureTeamTitleResPathByRanking, true);
								componetInChild4.CustomActive(true);
							}
							else
							{
								componetInChild4.sprite = null;
								componetInChild4.CustomActive(false);
							}
						}
					}
					return;
				}
				if (<_SetupOneLine>c__AnonStorey.a_eType == SortListType.SORTLIST_TOWER_1)
				{
					goto IL_756;
				}
				if (<_SetupOneLine>c__AnonStorey.a_eType != SortListType.SORTLIST_1V1_SEASON)
				{
					if (<_SetupOneLine>c__AnonStorey.a_eType != SortListType.SORTLIST_GUILD_LEVEL)
					{
						return;
					}
					bool flag2 = true;
					if (a_bFilter)
					{
						flag2 = DataManager<GuildDataManager>.GetInstance().HasSelfGuild();
					}
					<_SetupOneLine>c__AnonStorey.objValid.SetActive(flag2);
					gameObject.SetActive(!flag2);
					if (flag2)
					{
						GuildLevelSortListEntry guildLevelSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as GuildLevelSortListEntry;
						if (guildLevelSortListEntry != null)
						{
							this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)guildLevelSortListEntry.ranking);
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name").text = guildLevelSortListEntry.name;
							Text componetInChild5 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Leader");
							componetInChild5.text = guildLevelSortListEntry.leader;
							RelationData relationData2 = null;
							DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(guildLevelSortListEntry.id, ref relationData2);
							if (relationData2 != null && !string.IsNullOrEmpty(relationData2.remark))
							{
								componetInChild5.text = relationData2.remark;
							}
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "MemberCount").text = guildLevelSortListEntry.memberCount.ToString();
							Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = guildLevelSortListEntry.level.ToString();
						}
					}
					return;
				}
				break;
			case SortListType.SORTLIST_WEAPON_TT_ITEM_HUGESWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_KATANA:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_REVOLVER:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_HANDCANNON:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_WAND:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_STAFF:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SHORT_SWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_GLOVE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_OFG:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_EAST_STICK:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSSBOW:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_RIFLE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_BEAMSWORD:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SICKLE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_AXE:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_BEADS:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSS:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_SPEAR:
			case SortListType.SORTLIST_WEAPON_TT_ITEM_STICK:
				goto IL_9EF;
			case SortListType.SORTLIST_TOWER_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_JIANHUN:
			case SortListType.SORTLIST_TOWER_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_GUIQI:
			case SortListType.SORTLIST_TOWER_OCCU_AXIULUO:
			case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_TOWER_OCCU_MANYOU:
			case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI:
			case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_TOWER_OCCU_MOFASHI:
			case SortListType.SORTLIST_TOWER_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_TOWER_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_TOWER_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_TOWER_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_TOWER_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_TOWER_OCCU_SANDA:
			case SortListType.SORTLIST_TOWER_OCCU_JIEBA:
			case SortListType.SORTLIST_TOWER_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_TOWER_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_TOWER_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_TOWER_OCCU_QUMO:
			case SortListType.SORTLIST_TOWER_OCCU_SHENGQISHI:
				goto IL_756;
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIJIANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIANHUN:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_KUANGZHANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIQI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_AXIULUO:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MOFASHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_YUANSUSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHANDOUFASHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHAOHUANSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_GEDOUJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIGONGSHI:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SANDA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIEBA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_ROUDAOJIA:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA_NV:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGZHIZHE:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_QUMO:
			case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGQISHI:
				break;
			case SortListType.SORTLIST_CHIJI_SCORE:
			{
				ChijiScoreSortListEntry chijiScoreSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as ChijiScoreSortListEntry;
				if (chijiScoreSortListEntry != null)
				{
					bool flag3 = true;
					if (chijiScoreSortListEntry.name == null)
					{
						flag3 = false;
					}
					if (flag3 && chijiScoreSortListEntry != null)
					{
						this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)chijiScoreSortListEntry.ranking);
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name").text = chijiScoreSortListEntry.name;
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Job").text = this._GetJobName((int)chijiScoreSortListEntry.occu);
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Score").text = chijiScoreSortListEntry.score.ToString();
					}
				}
				return;
			}
			}
			bool flag4 = true;
			if (a_bFilter)
			{
				int num = this.m_dictSortTypeWithJobID[<_SetupOneLine>c__AnonStorey.a_eType];
				flag4 = (num == 0 || num == DataManager<PlayerBaseData>.GetInstance().JobTableID);
			}
			<_SetupOneLine>c__AnonStorey.objValid.SetActive(flag4);
			gameObject.SetActive(!flag4);
			if (flag4)
			{
				SeasonSortListEntry seasonSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as SeasonSortListEntry;
				if (seasonSortListEntry != null)
				{
					this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)seasonSortListEntry.ranking);
					Text componetInChild6 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name");
					componetInChild6.text = seasonSortListEntry.name;
					RelationData relationData3 = null;
					DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(seasonSortListEntry.id, ref relationData3);
					if (relationData3 != null && !string.IsNullOrEmpty(relationData3.remark))
					{
						componetInChild6.text = relationData3.remark;
					}
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Job").text = this._GetJobName((int)seasonSortListEntry.occu);
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = seasonSortListEntry.level.ToString();
					int seasonLevel = (int)seasonSortListEntry.seasonLevel;
					SeasonLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SeasonLevelTable>(seasonLevel, string.Empty, string.Empty);
					if (tableItem != null)
					{
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "PKScore/Rank").text = DataManager<SeasonDataManager>.GetInstance().GetRankName(seasonLevel, true);
						int num2 = (seasonLevel != DataManager<SeasonDataManager>.GetInstance().GetMaxRankID()) ? tableItem.Star : ((int)seasonSortListEntry.seasonStar);
						Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "PKScore/StarCount").text = string.Format("x{0}", num2);
					}
					else
					{
						Logger.LogErrorFormat("【段位榜】排名：{0} 段位ID:{1}找不到", new object[]
						{
							seasonSortListEntry.ranking,
							seasonLevel
						});
					}
				}
			}
			return;
			IL_62E:
			bool flag5 = true;
			if (a_bFilter)
			{
				int num3 = this.m_dictSortTypeWithJobID[<_SetupOneLine>c__AnonStorey.a_eType];
				flag5 = (num3 == 0 || num3 == DataManager<PlayerBaseData>.GetInstance().JobTableID);
			}
			<_SetupOneLine>c__AnonStorey.objValid.SetActive(flag5);
			gameObject.SetActive(!flag5);
			if (flag5)
			{
				LevelSortListEntry levelSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as LevelSortListEntry;
				if (levelSortListEntry != null)
				{
					this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)levelSortListEntry.ranking);
					Text componetInChild7 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name");
					componetInChild7.text = levelSortListEntry.name;
					RelationData relationData4 = null;
					DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(levelSortListEntry.id, ref relationData4);
					if (relationData4 != null && !string.IsNullOrEmpty(relationData4.remark))
					{
						componetInChild7.text = relationData4.remark;
					}
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Job").text = this._GetJobName((int)levelSortListEntry.occu);
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = levelSortListEntry.level.ToString();
				}
			}
			return;
			IL_756:
			bool flag6 = true;
			if (a_bFilter)
			{
				int num4 = this.m_dictSortTypeWithJobID[<_SetupOneLine>c__AnonStorey.a_eType];
				flag6 = (num4 == 0 || num4 == DataManager<PlayerBaseData>.GetInstance().JobTableID);
			}
			<_SetupOneLine>c__AnonStorey.objValid.SetActive(flag6);
			gameObject.SetActive(!flag6);
			if (flag6)
			{
				DeathTowerSortListEntry deathTowerSortListEntry = <_SetupOneLine>c__AnonStorey.a_data as DeathTowerSortListEntry;
				if (deathTowerSortListEntry != null)
				{
					this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)deathTowerSortListEntry.ranking);
					Text componetInChild8 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name");
					componetInChild8.text = deathTowerSortListEntry.name;
					RelationData relationData5 = null;
					DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(deathTowerSortListEntry.id, ref relationData5);
					if (relationData5 != null && !string.IsNullOrEmpty(relationData5.remark))
					{
						componetInChild8.text = relationData5.remark;
					}
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Job").text = this._GetJobName((int)deathTowerSortListEntry.occu);
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = deathTowerSortListEntry.level.ToString();
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Floor").text = deathTowerSortListEntry.layer.ToString();
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "ClearTime").text = this._GetTimeUsed((int)deathTowerSortListEntry.usedTime);
				}
			}
			return;
			IL_9EF:
			ItemSortListEntry data = <_SetupOneLine>c__AnonStorey.a_data as ItemSortListEntry;
			if (data != null)
			{
				ItemData itemData;
				if (data.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					itemData = DataManager<ItemDataManager>.GetInstance().GetItem(data.id);
				}
				else
				{
					itemData = ItemDataManager.CreateItemDataFromTable((int)data.itemId, 100, 0);
					if (itemData != null)
					{
						itemData.StrengthenLevel = (int)data.strengthen;
						itemData.EquipType = (EEquipType)data.equipType;
						itemData.GrowthAttrType = (EGrowthAttrType)data.growthAttr;
					}
				}
				bool flag7 = itemData != null;
				<_SetupOneLine>c__AnonStorey.objValid.SetActive(flag7);
				gameObject.SetActive(!flag7);
				if (flag7)
				{
					this._SetupRanking(<_SetupOneLine>c__AnonStorey.objValid, (int)data.ranking);
					Utility.FindGameObject(<_SetupOneLine>c__AnonStorey.objValid, "Icon", true).SetActive(true);
					ComItem comItem = <_SetupOneLine>c__AnonStorey.objValid.GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(Utility.FindGameObject(<_SetupOneLine>c__AnonStorey.objValid, "Icon", true));
					}
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						if (data.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						}
						else
						{
							WorldSortListWatchDataReq worldSortListWatchDataReq = new WorldSortListWatchDataReq();
							worldSortListWatchDataReq.type = (byte)<_SetupOneLine>c__AnonStorey.a_eType;
							worldSortListWatchDataReq.id = data.id;
							NetManager.Instance().SendCommand<WorldSortListWatchDataReq>(ServerType.GATE_SERVER, worldSortListWatchDataReq);
							DataManager<WaitNetMessageManager>.GetInstance().Wait(600803U, delegate(MsgDATA msgData)
							{
								int num5 = 0;
								byte b = 0;
								BaseDLL.decode_int8(msgData.bytes, ref num5, ref b);
								if (b == 1)
								{
									List<Item> list = ItemDecoder.Decode(msgData.bytes, ref num5, msgData.bytes.Length, false);
									if (list != null && list.Count > 0)
									{
										ItemData itemData2 = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(list[0]);
										if (itemData2 != null)
										{
											EquipSuitObj selfEquipSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(itemData2.SuitID);
											DataManager<ItemTipManager>.GetInstance().ShowOtherPlayerTip(itemData2, selfEquipSuitObj, null, 4, true);
										}
									}
								}
							}, true, 15f, null);
						}
					});
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Name").text = itemData.Name;
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Slot").text = itemData.GetThirdTypeDesc();
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Level").text = itemData.LevelLimit.ToString();
					Text componetInChild9 = Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Owner");
					componetInChild9.text = data.ownerName;
					RelationData relationData6 = null;
					DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(data.id, ref relationData6);
					if (relationData6 != null && !string.IsNullOrEmpty(relationData6.remark))
					{
						componetInChild9.text = relationData6.remark;
					}
					Utility.GetComponetInChild<Text>(<_SetupOneLine>c__AnonStorey.objValid, "Score").text = data.score.ToString();
				}
			}
		}

		// Token: 0x0601035E RID: 66398 RVA: 0x00487460 File Offset: 0x00485860
		private void _UpdateRanklistData(BaseSortList a_listData)
		{
			RanklistFrame.Ranklist ranklist = this._GetRanklist(a_listData.type);
			if (ranklist != null)
			{
				ranklist.data = a_listData;
				SortListType type = ranklist.data.type;
				switch (type)
				{
				case SortListType.SORTLIST_LEVEL_OCCU_GUIJIANSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_JIANHUN:
				case SortListType.SORTLIST_LEVEL_OCCU_KUANGZHANSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_GUIQI:
				case SortListType.SORTLIST_LEVEL_OCCU_AXIULUO:
				case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU:
				case SortListType.SORTLIST_LEVEL_OCCU_MANYOU:
				case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI:
				case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA:
				case SortListType.SORTLIST_LEVEL_OCCU_MOFASHI:
				case SortListType.SORTLIST_LEVEL_OCCU_YUANSUSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_ZHANDOUFASHI:
				case SortListType.SORTLIST_LEVEL_OCCU_ZHAOHUANSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_GEDOUJIA:
				case SortListType.SORTLIST_LEVEL_OCCU_QIGONGSHI:
				case SortListType.SORTLIST_LEVEL_OCCU_SANDA:
				case SortListType.SORTLIST_LEVEL_OCCU_JIEBA:
				case SortListType.SORTLIST_LEVEL_OCCU_ROUDAOJIA:
				case SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU_NV:
				case SortListType.SORTLIST_LEVEL_OCCU_MANYOU_NV:
				case SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI_NV:
				case SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI_NV:
				case SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA_NV:
				case SortListType.SORTLIST_LEVEL_OCCU_SHENGZHIZHE:
				case SortListType.SORTLIST_LEVEL_OCCU_QUMO:
				case SortListType.SORTLIST_LEVEL_OCCU_SHENGQISHI:
					goto IL_469;
				default:
					if (type == SortListType.SORTLIST_LEVEL)
					{
						goto IL_469;
					}
					if (type == SortListType.SORTLIST_WEAPON)
					{
						goto IL_75B;
					}
					if (type == SortListType.SORTLIST_ACHIEVEMENT_SCORE)
					{
						ushort ranking = 0;
						uint score = (uint)DataManager<PlayerBaseData>.GetInstance().AchievementScore;
						for (int i = 0; i < ranklist.data.entries.Count; i++)
						{
							if (ranklist.data.entries[i].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								ranking = ranklist.data.entries[i].ranking;
								score = (ranklist.data.entries[i] as AchievementScoreSortListEntry).score;
								break;
							}
						}
						AchievementScoreSortListEntry achievementScoreSortListEntry = new AchievementScoreSortListEntry();
						achievementScoreSortListEntry.ranking = ranking;
						achievementScoreSortListEntry.name = DataManager<PlayerBaseData>.GetInstance().Name;
						achievementScoreSortListEntry.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
						achievementScoreSortListEntry.score = score;
						ranklist.data.selfEntry = achievementScoreSortListEntry;
						return;
					}
					if (type == SortListType.SORTLIST_ADVENTURE_TEAM_GRADE)
					{
						ushort ranking2 = 0;
						for (int j = 0; j < ranklist.data.entries.Count; j++)
						{
							if (ranklist.data.entries[j].id == (ulong)ClientApplication.playerinfo.accid)
							{
								ranking2 = ranklist.data.entries[j].ranking;
								break;
							}
						}
						AdventureTeamGradeSortListEntry adventureTeamGradeSortListEntry = new AdventureTeamGradeSortListEntry();
						adventureTeamGradeSortListEntry.ranking = ranking2;
						adventureTeamGradeSortListEntry.adventureTeamLevel = (ushort)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamLevel();
						adventureTeamGradeSortListEntry.adventureTeamName = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamName();
						adventureTeamGradeSortListEntry.adventureTeamGrade = (uint)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamGradeTableId();
						adventureTeamGradeSortListEntry.adventureTeamScore = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamScore();
						ranklist.data.selfEntry = adventureTeamGradeSortListEntry;
						return;
					}
					if (type == SortListType.SORTLIST_TOWER_1)
					{
						goto IL_52B;
					}
					if (type != SortListType.SORTLIST_1V1_SEASON)
					{
						if (type != SortListType.SORTLIST_GUILD_LEVEL)
						{
							return;
						}
						GuildLevelSortListEntry guildLevelSortListEntry = new GuildLevelSortListEntry();
						if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
						{
							ushort ranking3 = 0;
							for (int k = 0; k < ranklist.data.entries.Count; k++)
							{
								if (ranklist.data.entries[k].id == DataManager<GuildDataManager>.GetInstance().myGuild.uGUID)
								{
									ranking3 = ranklist.data.entries[k].ranking;
									break;
								}
							}
							guildLevelSortListEntry.ranking = ranking3;
							guildLevelSortListEntry.name = DataManager<GuildDataManager>.GetInstance().myGuild.strName;
							guildLevelSortListEntry.leader = DataManager<GuildDataManager>.GetInstance().myGuild.leaderData.strName;
							guildLevelSortListEntry.memberCount = (uint)DataManager<GuildDataManager>.GetInstance().myGuild.nMemberCount;
							guildLevelSortListEntry.level = (uint)((ushort)DataManager<GuildDataManager>.GetInstance().myGuild.nLevel);
							ranklist.data.selfEntry = guildLevelSortListEntry;
						}
						else
						{
							guildLevelSortListEntry.ranking = 0;
							guildLevelSortListEntry.name = "-";
							guildLevelSortListEntry.leader = "-";
							guildLevelSortListEntry.memberCount = 0U;
							guildLevelSortListEntry.level = 0U;
							ranklist.data.selfEntry = guildLevelSortListEntry;
						}
						return;
					}
					break;
				case SortListType.SORTLIST_WEAPON_TT_ITEM_HUGESWORD:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_KATANA:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_REVOLVER:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_HANDCANNON:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_WAND:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_STAFF:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_SHORT_SWORD:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_GLOVE:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_OFG:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_EAST_STICK:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSSBOW:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_RIFLE:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_BEAMSWORD:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_SICKLE:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_AXE:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_BEADS:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_CROSS:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_SPEAR:
				case SortListType.SORTLIST_WEAPON_TT_ITEM_STICK:
					goto IL_75B;
				case SortListType.SORTLIST_TOWER_OCCU_GUIJIANSHI:
				case SortListType.SORTLIST_TOWER_OCCU_JIANHUN:
				case SortListType.SORTLIST_TOWER_OCCU_KUANGZHANSHI:
				case SortListType.SORTLIST_TOWER_OCCU_GUIQI:
				case SortListType.SORTLIST_TOWER_OCCU_AXIULUO:
				case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU:
				case SortListType.SORTLIST_TOWER_OCCU_MANYOU:
				case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI:
				case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI:
				case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA:
				case SortListType.SORTLIST_TOWER_OCCU_MOFASHI:
				case SortListType.SORTLIST_TOWER_OCCU_YUANSUSHI:
				case SortListType.SORTLIST_TOWER_OCCU_ZHANDOUFASHI:
				case SortListType.SORTLIST_TOWER_OCCU_ZHAOHUANSHI:
				case SortListType.SORTLIST_TOWER_OCCU_GEDOUJIA:
				case SortListType.SORTLIST_TOWER_OCCU_QIGONGSHI:
				case SortListType.SORTLIST_TOWER_OCCU_SANDA:
				case SortListType.SORTLIST_TOWER_OCCU_JIEBA:
				case SortListType.SORTLIST_TOWER_OCCU_ROUDAOJIA:
				case SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU_NV:
				case SortListType.SORTLIST_TOWER_OCCU_MANYOU_NV:
				case SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI_NV:
				case SortListType.SORTLIST_TOWER_OCCU_JIXIESHI_NV:
				case SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA_NV:
				case SortListType.SORTLIST_TOWER_OCCU_SHENGZHIZHE:
				case SortListType.SORTLIST_TOWER_OCCU_QUMO:
				case SortListType.SORTLIST_TOWER_OCCU_SHENGQISHI:
					goto IL_52B;
				case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIJIANSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_JIANHUN:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_KUANGZHANSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_GUIQI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_AXIULUO:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_MOFASHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_YUANSUSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHANDOUFASHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_ZHAOHUANSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_GEDOUJIA:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_QIGONGSHI:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_SANDA:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_JIEBA:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_ROUDAOJIA:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU_NV:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU_NV:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI_NV:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI_NV:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA_NV:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGZHIZHE:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_QUMO:
				case SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGQISHI:
					break;
				case SortListType.SORTLIST_CHIJI_SCORE:
				{
					ushort ranking4 = 0;
					uint chijiScore = DataManager<PlayerBaseData>.GetInstance().ChijiScore;
					for (int l = 0; l < ranklist.data.entries.Count; l++)
					{
						if (ranklist.data.entries[l].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							ranking4 = ranklist.data.entries[l].ranking;
							break;
						}
					}
					ChijiScoreSortListEntry chijiScoreSortListEntry = new ChijiScoreSortListEntry();
					chijiScoreSortListEntry.ranking = ranking4;
					chijiScoreSortListEntry.name = DataManager<PlayerBaseData>.GetInstance().Name;
					chijiScoreSortListEntry.occu = (uint)((byte)DataManager<PlayerBaseData>.GetInstance().JobTableID);
					chijiScoreSortListEntry.score = chijiScore;
					ranklist.data.selfEntry = chijiScoreSortListEntry;
					return;
				}
				}
				ushort ranking5 = 0;
				for (int m = 0; m < ranklist.data.entries.Count; m++)
				{
					if (ranklist.data.entries[m].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						ranking5 = ranklist.data.entries[m].ranking;
						break;
					}
				}
				SeasonSortListEntry seasonSortListEntry = new SeasonSortListEntry();
				seasonSortListEntry.ranking = ranking5;
				seasonSortListEntry.name = DataManager<PlayerBaseData>.GetInstance().Name;
				seasonSortListEntry.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
				seasonSortListEntry.level = DataManager<PlayerBaseData>.GetInstance().Level;
				seasonSortListEntry.seasonLevel = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel;
				seasonSortListEntry.seasonStar = (uint)DataManager<SeasonDataManager>.GetInstance().seasonStar;
				ranklist.data.selfEntry = seasonSortListEntry;
				return;
				IL_469:
				ushort ranking6 = 0;
				for (int n = 0; n < ranklist.data.entries.Count; n++)
				{
					if (ranklist.data.entries[n].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						ranking6 = ranklist.data.entries[n].ranking;
						break;
					}
				}
				LevelSortListEntry levelSortListEntry = new LevelSortListEntry();
				levelSortListEntry.ranking = ranking6;
				levelSortListEntry.name = DataManager<PlayerBaseData>.GetInstance().Name;
				levelSortListEntry.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
				levelSortListEntry.level = DataManager<PlayerBaseData>.GetInstance().Level;
				ranklist.data.selfEntry = levelSortListEntry;
				return;
				IL_52B:
				ushort ranking7 = 0;
				for (int num = 0; num < ranklist.data.entries.Count; num++)
				{
					if (ranklist.data.entries[num].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						ranking7 = ranklist.data.entries[num].ranking;
						break;
					}
				}
				DeathTowerSortListEntry deathTowerSortListEntry = new DeathTowerSortListEntry();
				deathTowerSortListEntry.ranking = ranking7;
				deathTowerSortListEntry.name = DataManager<PlayerBaseData>.GetInstance().Name;
				deathTowerSortListEntry.occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID;
				deathTowerSortListEntry.level = DataManager<PlayerBaseData>.GetInstance().Level;
				deathTowerSortListEntry.layer = (uint)DataManager<CountDataManager>.GetInstance().GetCount("tower_top_floor_total");
				deathTowerSortListEntry.usedTime = (uint)DataManager<CountDataManager>.GetInstance().GetCount("tower_used_time_total");
				ranklist.data.selfEntry = deathTowerSortListEntry;
				return;
				IL_75B:
				ushort num2 = 0;
				for (int num3 = 0; num3 < ranklist.data.entries.Count; num3++)
				{
					ItemSortListEntry itemSortListEntry = ranklist.data.entries[num3] as ItemSortListEntry;
					if (itemSortListEntry != null && itemSortListEntry.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						num2 = ranklist.data.entries[num3].ranking;
						break;
					}
				}
				if (num2 == 0)
				{
					ranklist.data.selfEntry = this._GetBestItem(this.m_dictSortTypeWithItemType[ranklist.data.type]);
				}
			}
		}

		// Token: 0x0601035F RID: 66399 RVA: 0x00487EFC File Offset: 0x004862FC
		private void _SetupRanking(GameObject a_objLine, int a_nRanking)
		{
			Text componetInChild = Utility.GetComponetInChild<Text>(a_objLine, "Rank/Lab");
			Image componetInChild2 = Utility.GetComponetInChild<Image>(a_objLine, "Rank/Icon");
			if (a_nRanking < 1)
			{
				componetInChild.gameObject.SetActive(true);
				componetInChild2.gameObject.SetActive(false);
				componetInChild.text = TR.Value("ranklist_not_on_the_list");
			}
			else if (a_nRanking >= 1 && a_nRanking <= 3)
			{
				componetInChild.gameObject.SetActive(false);
				componetInChild2.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref componetInChild2, this.m_rankIcons[a_nRanking - 1], true);
				componetInChild2.SetNativeSize();
			}
			else
			{
				componetInChild.gameObject.SetActive(true);
				componetInChild2.gameObject.SetActive(false);
				componetInChild.text = a_nRanking.ToString();
			}
			GameObject[] array = new GameObject[]
			{
				Utility.FindGameObject(a_objLine, string.Format("Effect{0}", 1), false),
				Utility.FindGameObject(a_objLine, string.Format("Effect{0}", 2), false),
				Utility.FindGameObject(a_objLine, string.Format("Effect{0}", 3), false)
			};
			for (int i = 0; i < 3; i++)
			{
				if (array[i] != null)
				{
					array[i].SetActive(false);
				}
			}
			Image componetInChild3 = Utility.GetComponetInChild<Image>(a_objLine, "BG");
			if (componetInChild3 != null)
			{
				componetInChild3.gameObject.SetActive(false);
			}
			if (a_nRanking == 1 || a_nRanking == 2 || a_nRanking == 3)
			{
				if (array[a_nRanking - 1] == null)
				{
					array[a_nRanking - 1] = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(string.Format("Effects/Scene_effects/EffectUI/EffUI_ph0{0}", a_nRanking), true, 0U);
					array[a_nRanking - 1].name = string.Format("Effect{0}", a_nRanking);
					array[a_nRanking - 1].transform.SetParent(a_objLine.transform, false);
				}
				array[a_nRanking - 1].SetActive(true);
				if (componetInChild3 != null)
				{
					componetInChild3.gameObject.SetActive(true);
					ETCImageLoader.LoadSprite(ref componetInChild3, string.Format("UI/Image/Packed/p_UI_List.png:UI_Paihangbang_Tubiao_Di_0{0}", a_nRanking), true);
				}
			}
		}

		// Token: 0x06010360 RID: 66400 RVA: 0x00488120 File Offset: 0x00486520
		private string _GetTimeUsed(int a_time)
		{
			a_time /= 1000;
			int num = 0;
			int num2 = 0;
			int num3 = a_time % 60;
			int num4 = a_time / 60;
			if (num4 > 0)
			{
				num = num4 % 60;
				num2 = num4 / 60;
			}
			return string.Format("{0:D2}:{1:D2}:{2:D2}", num2, num, num3);
		}

		// Token: 0x06010361 RID: 66401 RVA: 0x00488174 File Offset: 0x00486574
		private ItemData _GetCompareItem(ItemData item)
		{
			ItemData result = null;
			if (item != null)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item2 != null && item2.GUID != item.GUID && item2.IsWearSoltEqual(item))
						{
							result = item2;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06010362 RID: 66402 RVA: 0x004881F0 File Offset: 0x004865F0
		private ItemSortListEntry _GetBestItem(ItemTable.eThirdType a_eType)
		{
			ItemData itemData = null;
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Equip, ItemTable.eSubType.WEAPON);
			for (int i = 0; i < itemsByPackageSubType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[i]);
				if (item != null)
				{
					if ((a_eType == ItemTable.eThirdType.TT_NONE || item.ThirdType == a_eType) && (itemData == null || itemData.finalRateScore < item.finalRateScore))
					{
						itemData = item;
					}
				}
			}
			itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.WearEquip, ItemTable.eSubType.WEAPON);
			for (int j = 0; j < itemsByPackageSubType.Count; j++)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[j]);
				if (item2 != null)
				{
					if ((a_eType == ItemTable.eThirdType.TT_NONE || item2.ThirdType == a_eType) && (itemData == null || itemData.finalRateScore < item2.finalRateScore))
					{
						itemData = item2;
					}
				}
			}
			if (itemData != null)
			{
				return new ItemSortListEntry
				{
					ranking = 0,
					ownerName = DataManager<PlayerBaseData>.GetInstance().Name,
					ownerId = DataManager<PlayerBaseData>.GetInstance().RoleID,
					name = itemData.Name,
					id = itemData.GUID,
					itemId = (uint)itemData.TableID,
					level = (ushort)itemData.LevelLimit,
					score = (uint)itemData.finalRateScore,
					strengthen = (uint)itemData.StrengthenLevel,
					equipType = (byte)itemData.EquipType,
					growthAttr = (byte)itemData.GrowthAttrType
				};
			}
			return new ItemSortListEntry
			{
				ranking = 0,
				ownerName = string.Empty,
				ownerId = 0UL,
				name = string.Empty,
				id = 0UL,
				itemId = 0U,
				level = 0,
				score = 0U,
				strengthen = 0U
			};
		}

		// Token: 0x06010363 RID: 66403 RVA: 0x004883E4 File Offset: 0x004867E4
		private string _GetJobName(int a_nJobID)
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(a_nJobID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Name;
			}
			return string.Empty;
		}

		// Token: 0x06010364 RID: 66404 RVA: 0x0048841C File Offset: 0x0048681C
		private RanklistFrame.Ranklist _GetRanklist(SortListType a_eType)
		{
			for (int i = 0; i < this.m_arrRanklist.Count; i++)
			{
				RanklistFrame.Ranklist ranklist = this.m_arrRanklist[i];
				for (int j = 0; j < ranklist.arrTypes.Count; j++)
				{
					if (ranklist.arrTypes[j] == a_eType)
					{
						return ranklist;
					}
				}
			}
			return null;
		}

		// Token: 0x06010365 RID: 66405 RVA: 0x00488484 File Offset: 0x00486884
		private void _OnRanklistUpdate(UIEvent a_event)
		{
			BaseSortList baseSortList = a_event.Param1 as BaseSortList;
			if (baseSortList == null)
			{
				Logger.LogError("baseSortlist is null");
			}
			if (baseSortList.type != this.m_currRanklist)
			{
				return;
			}
			RanklistFrame.Ranklist ranklist = this._GetRanklist(this.m_currRanklist);
			if (ranklist != null)
			{
				this._UpdateRanklistData(baseSortList);
				ranklist.rankListControl.SetElementAmount(ranklist.data.entries.Count);
				if (ranklist.data.entries.Count > 0)
				{
					ranklist.rankListControl.EnsureElementVisable(0);
				}
				ranklist.objMyRank.SetActive(true);
				this._SetupOneLine(ranklist.objMyRank, this.m_currRanklist, ranklist.data.selfEntry, false, true);
			}
		}

		// Token: 0x06010366 RID: 66406 RVA: 0x00488544 File Offset: 0x00486944
		private void _OnRequestJoinSuccess(UIEvent a_event)
		{
			ulong num = (ulong)a_event.Param1;
			RanklistFrame.Ranklist ranklist = this._GetRanklist(SortListType.SORTLIST_GUILD_LEVEL);
			if (ranklist != null)
			{
				for (int i = 0; i < ranklist.data.entries.Count; i++)
				{
					if (ranklist.data.entries[i].id == num)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_request_join_success", ranklist.data.entries[i].name), CommonTipsDesc.eShowMode.SI_UNIQUE);
						break;
					}
				}
			}
		}

		// Token: 0x06010367 RID: 66407 RVA: 0x004885D4 File Offset: 0x004869D4
		private void _RequestRanklist(int a_type, int a_startIndex, int a_count)
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = (byte)a_type;
			worldSortListReq.start = (ushort)a_startIndex;
			worldSortListReq.num = (ushort)a_count;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList param = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RanklistUpdated, param, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x06010368 RID: 66408 RVA: 0x00488642 File Offset: 0x00486A42
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<RanklistFrame>(this, false);
		}

		// Token: 0x06010369 RID: 66409 RVA: 0x00488651 File Offset: 0x00486A51
		protected override void _bindExUI()
		{
			this.mToggle250 = this.mBind.GetGameObject("Toggle250");
		}

		// Token: 0x0601036A RID: 66410 RVA: 0x00488669 File Offset: 0x00486A69
		protected override void _unbindExUI()
		{
			this.mToggle250 = null;
		}

		// Token: 0x0400A3EB RID: 41963
		[UIObject("Select")]
		private GameObject m_objLineSelect;

		// Token: 0x0400A3EC RID: 41964
		[UIControl("Ranks/Viewport/Content", null, 0)]
		private ComToggleGroup m_comRankGroup;

		// Token: 0x0400A3ED RID: 41965
		[UIControl("Ranks", null, 0)]
		private ScrollRect m_comScrollRect;

		// Token: 0x0400A3EE RID: 41966
		private string[] m_rankIcons = new string[]
		{
			"UI/Image/Packed/p_UI_List.png:UI_Paihangbang_Tubiao_01",
			"UI/Image/Packed/p_UI_List.png:UI_Paihangbang_Tubiao_02",
			"UI/Image/Packed/p_UI_List.png:UI_Paihangbang_Tubiao_03"
		};

		// Token: 0x0400A3EF RID: 41967
		private List<RanklistFrame.Ranklist> m_arrRanklist = new List<RanklistFrame.Ranklist>();

		// Token: 0x0400A3F0 RID: 41968
		private SortListType m_currRanklist = SortListType.SORTLIST_LEVEL;

		// Token: 0x0400A3F1 RID: 41969
		private Dictionary<SortListType, ItemTable.eThirdType> m_dictSortTypeWithItemType = new Dictionary<SortListType, ItemTable.eThirdType>
		{
			{
				SortListType.SORTLIST_WEAPON,
				ItemTable.eThirdType.TT_NONE
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_HUGESWORD,
				ItemTable.eThirdType.HUGESWORD
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_KATANA,
				ItemTable.eThirdType.KATANA
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_REVOLVER,
				ItemTable.eThirdType.REVOLVER
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_HANDCANNON,
				ItemTable.eThirdType.HANDCANNON
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_WAND,
				ItemTable.eThirdType.WAND
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_STAFF,
				ItemTable.eThirdType.STAFF
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_SHORT_SWORD,
				ItemTable.eThirdType.SHORTSWORD
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_OFG,
				ItemTable.eThirdType.OFG
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_GLOVE,
				ItemTable.eThirdType.GLOVE
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_EAST_STICK,
				ItemTable.eThirdType.EAST_STICK
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_CROSSBOW,
				ItemTable.eThirdType.CROSSBOW
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_RIFLE,
				ItemTable.eThirdType.RIFLE
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_BEAMSWORD,
				ItemTable.eThirdType.BEAMSWORD
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_SICKLE,
				ItemTable.eThirdType.SICKLE
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_AXE,
				ItemTable.eThirdType.AXE
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_BEADS,
				ItemTable.eThirdType.BEADS
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_CROSS,
				ItemTable.eThirdType.CROSS
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_SPEAR,
				ItemTable.eThirdType.SPEAR
			},
			{
				SortListType.SORTLIST_WEAPON_TT_ITEM_STICK,
				ItemTable.eThirdType.STICK
			}
		};

		// Token: 0x0400A3F2 RID: 41970
		private Dictionary<SortListType, int> m_dictSortTypeWithJobID = new Dictionary<SortListType, int>
		{
			{
				SortListType.SORTLIST_LEVEL,
				0
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_GUIJIANSHI,
				10
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_JIANHUN,
				11
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_KUANGZHANSHI,
				12
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_GUIQI,
				13
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_AXIULUO,
				14
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU,
				20
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_MANYOU,
				21
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI,
				22
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI,
				23
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA,
				24
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_MOFASHI,
				30
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_YUANSUSHI,
				31
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_ZHANDOUFASHI,
				32
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_ZHAOHUANSHI,
				33
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_GEDOUJIA,
				40
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_QIGONGSHI,
				41
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_SANDA,
				42
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_JIEBA,
				43
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_ROUDAOJIA,
				44
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_SHENQIANGSHOU_NV,
				50
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_MANYOU_NV,
				51
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_QIANGPAOSHI_NV,
				52
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_JIXIESHI_NV,
				53
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_DANYAOZHUANJIA_NV,
				54
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_SHENGZHIZHE,
				60
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_QUMO,
				61
			},
			{
				SortListType.SORTLIST_LEVEL_OCCU_SHENGQISHI,
				62
			},
			{
				SortListType.SORTLIST_1V1_SEASON,
				0
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_GUIJIANSHI,
				10
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_JIANHUN,
				11
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_KUANGZHANSHI,
				12
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_GUIQI,
				13
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_AXIULUO,
				14
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU,
				20
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU,
				21
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI,
				22
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI,
				23
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA,
				24
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_MOFASHI,
				30
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_YUANSUSHI,
				31
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_ZHANDOUFASHI,
				32
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_ZHAOHUANSHI,
				33
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_GEDOUJIA,
				40
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_QIGONGSHI,
				41
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_SANDA,
				42
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_JIEBA,
				43
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_ROUDAOJIA,
				44
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_SHENQIANGSHOU_NV,
				50
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_MANYOU_NV,
				51
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_QIANGPAOSHI_NV,
				52
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_JIXIESHI_NV,
				53
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_DANYAOZHUANJIA_NV,
				54
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGZHIZHE,
				60
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_QUMO,
				61
			},
			{
				SortListType.SORTLIST_1V1_SEASON_OCCU_SHENGQISHI,
				62
			},
			{
				SortListType.SORTLIST_TOWER_1,
				0
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_GUIJIANSHI,
				10
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_JIANHUN,
				11
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_KUANGZHANSHI,
				12
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_GUIQI,
				13
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_AXIULUO,
				14
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU,
				20
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_MANYOU,
				21
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI,
				22
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_JIXIESHI,
				23
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA,
				24
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_MOFASHI,
				30
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_YUANSUSHI,
				31
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_ZHANDOUFASHI,
				32
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_ZHAOHUANSHI,
				33
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_GEDOUJIA,
				40
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_QIGONGSHI,
				41
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_SANDA,
				42
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_JIEBA,
				43
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_ROUDAOJIA,
				44
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_SHENQIANGSHOU_NV,
				50
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_MANYOU_NV,
				51
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_QIANGPAOSHI_NV,
				52
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_JIXIESHI_NV,
				53
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_DANYAOZHUANJIA_NV,
				54
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_SHENGZHIZHE,
				60
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_QUMO,
				61
			},
			{
				SortListType.SORTLIST_TOWER_OCCU_SHENGQISHI,
				62
			}
		};

		// Token: 0x0400A3F3 RID: 41971
		private GameObject mToggle250;

		// Token: 0x020019D8 RID: 6616
		private class Ranklist
		{
			// Token: 0x0400A3F5 RID: 41973
			public List<SortListType> arrTypes = new List<SortListType>();

			// Token: 0x0400A3F6 RID: 41974
			public BaseSortList data;

			// Token: 0x0400A3F7 RID: 41975
			public GameObject objRanklistRoot;

			// Token: 0x0400A3F8 RID: 41976
			public ComUIListScript rankListControl;

			// Token: 0x0400A3F9 RID: 41977
			public GameObject objMyRank;

			// Token: 0x0400A3FA RID: 41978
			public ComToggleGroup comToggleGroup;
		}

		// Token: 0x020019D9 RID: 6617
		private class RewardInfo
		{
			// Token: 0x0400A3FB RID: 41979
			public int minScore;

			// Token: 0x0400A3FC RID: 41980
			public int maxScore;

			// Token: 0x0400A3FD RID: 41981
			public List<ItemData> items;
		}
	}
}
