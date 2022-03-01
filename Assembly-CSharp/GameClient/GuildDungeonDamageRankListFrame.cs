using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001618 RID: 5656
	internal class GuildDungeonDamageRankListFrame : ClientFrame
	{
		// Token: 0x0600DDEA RID: 56810 RVA: 0x00385A54 File Offset: 0x00383E54
		protected override void _bindExUI()
		{
			this.txtTotalDamage = this.mBind.GetCom<Text>("txtTotalDamage");
			this.mScrollUIList = this.mBind.GetCom<ComUIListScript>("ScrollUIList");
			this.mScrollUIList2 = this.mBind.GetCom<ComUIListScript>("ScrollUIList2");
			this.mScrollUIList3 = this.mBind.GetCom<ComUIListScript>("ScrollUIList3");
			this.showItems = this.mBind.GetCom<GuildDungeonAwardsShowItem>("showItems");
		}

		// Token: 0x0600DDEB RID: 56811 RVA: 0x00385ACF File Offset: 0x00383ECF
		protected override void _unbindExUI()
		{
			this.txtTotalDamage = null;
			this.mScrollUIList = null;
			this.mScrollUIList2 = null;
			this.mScrollUIList3 = null;
			this.showItems = null;
		}

		// Token: 0x0600DDEC RID: 56812 RVA: 0x00385AF4 File Offset: 0x00383EF4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonDamageRankList";
		}

		// Token: 0x0600DDED RID: 56813 RVA: 0x00385AFB File Offset: 0x00383EFB
		public static void OnOpenLinkFrame(string argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonDamageRankListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DDEE RID: 56814 RVA: 0x00385B10 File Offset: 0x00383F10
		protected override void _OnOpenFrame()
		{
			this.m_arrAwardItems = new List<GuildDungeonDamageRankListFrame.AwardRankItem>();
			if (this.m_arrAwardItems == null)
			{
				Logger.LogErrorFormat("new List<AwardRankItem>() error!!!", new object[0]);
			}
			else
			{
				Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWarRewardTable>();
				if (table == null)
				{
					Logger.LogErrorFormat("TableManager.instance.GetTable<ScoreWarRewardTable>() error!!!", new object[0]);
				}
				else
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						ScoreWarRewardTable scoreWarRewardTable = keyValuePair.Value as ScoreWarRewardTable;
						if (scoreWarRewardTable != null && scoreWarRewardTable.RankingBegin > 0 && scoreWarRewardTable.RankingEnd > 0)
						{
							GuildDungeonDamageRankListFrame.AwardRankItem awardRankItem = new GuildDungeonDamageRankListFrame.AwardRankItem();
							awardRankItem.iRankMin = scoreWarRewardTable.RankingBegin;
							awardRankItem.iRankMax = scoreWarRewardTable.RankingEnd;
							for (int i = 0; i < scoreWarRewardTable.ItemReward.Count; i++)
							{
								string text = scoreWarRewardTable.ItemRewardArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									int tableId = int.Parse(array[0]);
									int count = int.Parse(array[1]);
									ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
									if (itemData != null)
									{
										itemData.Count = count;
										awardRankItem.arrItems.Add(itemData);
									}
								}
							}
							this.m_arrAwardItems.Add(awardRankItem);
						}
					}
				}
			}
			this.awardType2ItemDatas = new Dictionary<GuildDungeonAwardsShowItem.AwardType, List<AwardItemData>>();
			if (this.awardType2ItemDatas != null)
			{
				this.awardType2ItemDatas.Add(GuildDungeonAwardsShowItem.AwardType.Kill3ShiTu, this.GetKill3ShiTuAwardList());
				this.awardType2ItemDatas.Add(GuildDungeonAwardsShowItem.AwardType.NotKillBigBoss, this.GetNotKillBossAwardList());
			}
			if (this.toggleScoreRank != null)
			{
				this.toggleScoreRank.onValueChanged.AddListener(delegate(bool bValue)
				{
					if (this.goScoreList != null)
					{
						this.goScoreList.CustomActive(true);
					}
					if (this.goAwardList != null)
					{
						this.goAwardList.CustomActive(false);
					}
					this.RefreshRankList();
				});
			}
			if (this.toggleRankAward != null)
			{
				this.toggleRankAward.onValueChanged.AddListener(delegate(bool bValue)
				{
					if (this.goScoreList != null)
					{
						this.goScoreList.CustomActive(false);
					}
					if (this.goAwardList != null)
					{
						this.goAwardList.CustomActive(true);
					}
					this.RrefeshRankAward();
				});
			}
			if (this.goScoreList != null)
			{
				this.goScoreList.CustomActive(true);
			}
			if (this.goAwardList != null)
			{
				this.goAwardList.CustomActive(false);
			}
			if (this.m_comScoreList != null)
			{
				this.m_comScoreList.Initialize();
				this.m_comScoreList.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (item.m_index >= 0)
					{
						this.OnUpdateScoreListItem(item.m_index, item.gameObject);
					}
				};
			}
			if (this.m_comAwardList != null)
			{
				this.m_comAwardList.Initialize();
				this.m_comAwardList.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (item.m_index < 0 || item.m_index >= this.m_arrAwardItems.Count || this.m_arrAwardItems != null)
					{
					}
				};
			}
			for (int j = 0; j < this.m_arrAwardItems.Count; j++)
			{
				this.UpdateAwardListItem(j, null, this.m_arrAwardItems[j]);
			}
			DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonDamageRankReq();
			this.RefreshRankList();
			this.BindUIEvent();
			this.UpdatePayRewardItems(0);
		}

		// Token: 0x0600DDEF RID: 56815 RVA: 0x00385DF6 File Offset: 0x003841F6
		protected override void _OnCloseFrame()
		{
			this.m_arrAwardItems = null;
			this.awardType2ItemDatas = null;
			this.UnBindUIEvent();
			this.ClearData(true);
		}

		// Token: 0x0600DDF0 RID: 56816 RVA: 0x00385E13 File Offset: 0x00384213
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonDamageRank, new ClientEventSystem.UIEventHandler(this._OnUpdateRankList));
		}

		// Token: 0x0600DDF1 RID: 56817 RVA: 0x00385E30 File Offset: 0x00384230
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonDamageRank, new ClientEventSystem.UIEventHandler(this._OnUpdateRankList));
		}

		// Token: 0x0600DDF2 RID: 56818 RVA: 0x00385E4D File Offset: 0x0038424D
		private void _OnUpdateRankList(UIEvent uiEvent)
		{
			this.RefreshRankList();
		}

		// Token: 0x0600DDF3 RID: 56819 RVA: 0x00385E55 File Offset: 0x00384255
		[UIEventHandle("Close")]
		private void OnCloseBtnClicked()
		{
			this.frameMgr.CloseFrame<GuildDungeonDamageRankListFrame>(this, false);
		}

		// Token: 0x0600DDF4 RID: 56820 RVA: 0x00385E64 File Offset: 0x00384264
		private void RefreshRankList()
		{
			if (this.goScoreList == null)
			{
				return;
			}
			List<GuildDataManager.DungeonDamageRankInfo> dungeonRankInfoList = DataManager<GuildDataManager>.GetInstance().GetDungeonRankInfoList();
			if (dungeonRankInfoList != null)
			{
				this.m_comScoreList.SetElementAmount(dungeonRankInfoList.Count);
			}
			GuildDataManager.DungeonDamageRankInfo myDungeonDamageRankInfo = DataManager<GuildDataManager>.GetInstance().GetMyDungeonDamageRankInfo();
			this.UpdateMyScoreListItem(myDungeonDamageRankInfo.nRank, this.goMyScoreRank, myDungeonDamageRankInfo);
		}

		// Token: 0x0600DDF5 RID: 56821 RVA: 0x00385EC3 File Offset: 0x003842C3
		private void RrefeshRankAward()
		{
			if (this.goAwardList == null)
			{
				return;
			}
			this.m_comAwardList.SetElementAmount(this.m_arrAwardItems.Count);
		}

		// Token: 0x0600DDF6 RID: 56822 RVA: 0x00385EF0 File Offset: 0x003842F0
		private void OnUpdateScoreListItem(int iIndex, GameObject a_objLine)
		{
			List<GuildDataManager.DungeonDamageRankInfo> dungeonRankInfoList = DataManager<GuildDataManager>.GetInstance().GetDungeonRankInfoList();
			if (iIndex >= dungeonRankInfoList.Count)
			{
				return;
			}
			GuildDataManager.DungeonDamageRankInfo a_data = dungeonRankInfoList[iIndex];
			this.UpdateScoreListItem(iIndex, a_objLine, a_data);
		}

		// Token: 0x0600DDF7 RID: 56823 RVA: 0x00385F28 File Offset: 0x00384328
		private int GetMaxRank()
		{
			int num = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWarRewardTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("TableManager.instance.GetTable<ScoreWarRewardTable>() error!!!", new object[0]);
			}
			else
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ScoreWarRewardTable scoreWarRewardTable = keyValuePair.Value as ScoreWarRewardTable;
					if (scoreWarRewardTable != null && scoreWarRewardTable.RankingBegin > 0 && scoreWarRewardTable.RankingEnd > 0 && scoreWarRewardTable.RankingEnd >= num)
					{
						num = scoreWarRewardTable.RankingEnd;
					}
				}
			}
			return num;
		}

		// Token: 0x0600DDF8 RID: 56824 RVA: 0x00385FC0 File Offset: 0x003843C0
		private List<AwardItemData> GetKillBossAwardList()
		{
			List<AwardItemData> list = new List<AwardItemData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 11)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									list.Add(awardItemData);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600DDF9 RID: 56825 RVA: 0x003860A4 File Offset: 0x003844A4
		private Vector2 GetAwardItemSize(GuildDungeonAwardsShowItem.AwardType awardType)
		{
			Vector2 result = default(Vector2);
			if (this.awardType2ItemDatas == null)
			{
				return result;
			}
			if (this.awardType2ItemDatas.ContainsKey(awardType) && this.showItems != null)
			{
				return this.showItems.GetContentSize(this.awardType2ItemDatas[awardType]);
			}
			return result;
		}

		// Token: 0x0600DDFA RID: 56826 RVA: 0x00386104 File Offset: 0x00384504
		private List<AwardItemData> GetNotKillBossAwardList()
		{
			List<AwardItemData> list = new List<AwardItemData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 12)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									list.Add(awardItemData);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600DDFB RID: 56827 RVA: 0x003861E8 File Offset: 0x003845E8
		private List<AwardItemData> GetKill3ShiTuAwardList()
		{
			List<AwardItemData> list = new List<AwardItemData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 13)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									list.Add(awardItemData);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600DDFC RID: 56828 RVA: 0x003862CC File Offset: 0x003846CC
		private void UpdatePayRewardItems(int selectPayActId)
		{
			if (this.awardItemDataList == null)
			{
				Logger.LogError("ItemdataList data is null");
			}
			if (this.mScrollUIList == null)
			{
				Logger.LogError("mScrollUIList obj is null");
				return;
			}
			if (!this.mScrollUIList.IsInitialised())
			{
				this.mScrollUIList.Initialize();
				this.mScrollUIList.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mScrollUIList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && index < this.awardItemDataList.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
			this.awardItemDataList = this.GetKillBossAwardList();
			this.mScrollUIList.SetElementAmount(this.awardItemDataList.Count);
			if (!this.mScrollUIList2.IsInitialised())
			{
				this.mScrollUIList2.Initialize();
				this.mScrollUIList2.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mScrollUIList2.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && index < this.awardItemDataList2.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList2[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList2[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList2[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
			this.awardItemDataList2 = this.GetNotKillBossAwardList();
			this.mScrollUIList2.SetElementAmount(this.awardItemDataList2.Count);
			if (!this.mScrollUIList3.IsInitialised())
			{
				this.mScrollUIList3.Initialize();
				this.mScrollUIList3.onBindItem = delegate(GameObject go)
				{
					GuildDungeonAwardsShowItem result = null;
					if (go)
					{
						result = go.GetComponent<GuildDungeonAwardsShowItem>();
					}
					return result;
				};
			}
			this.mScrollUIList3.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (this.awardType2ItemDatas != null && index >= 0 && index < this.awardType2ItemDatas.Count)
				{
					GuildDungeonAwardsShowItem guildDungeonAwardsShowItem = var1.gameObjectBindScript as GuildDungeonAwardsShowItem;
					if (guildDungeonAwardsShowItem != null)
					{
						GuildDungeonAwardsShowItem.AwardType awardType = (GuildDungeonAwardsShowItem.AwardType)index;
						if (this.awardType2ItemDatas.ContainsKey(awardType))
						{
							guildDungeonAwardsShowItem.SetUp(this, awardType, this.awardType2ItemDatas[awardType]);
						}
					}
				}
			};
			if (this.awardType2ItemDatas != null)
			{
				List<Vector2> list = new List<Vector2>();
				list.Add(this.GetAwardItemSize(GuildDungeonAwardsShowItem.AwardType.Kill3ShiTu));
				list.Add(this.GetAwardItemSize(GuildDungeonAwardsShowItem.AwardType.NotKillBigBoss));
				this.mScrollUIList3.SetElementAmount(this.awardType2ItemDatas.Count, list);
			}
		}

		// Token: 0x0600DDFD RID: 56829 RVA: 0x003864A0 File Offset: 0x003848A0
		private void ClearData(bool isClearWithTabs = true)
		{
			if (this.awardItemDataList != null)
			{
				this.awardItemDataList.Clear();
			}
			if (this.awardItemDataList2 != null)
			{
				this.awardItemDataList2.Clear();
			}
			if (this.mScrollUIList != null)
			{
				this.mScrollUIList.SetElementAmount(0);
			}
			if (this.mScrollUIList2 != null)
			{
				this.mScrollUIList2.SetElementAmount(0);
			}
			if (this.mScrollUIList3 != null)
			{
				this.mScrollUIList3.SetElementAmount(0);
			}
		}

		// Token: 0x0600DDFE RID: 56830 RVA: 0x00386530 File Offset: 0x00384930
		private void UpdateMyScoreListItem(uint iIndex, GameObject a_objLine, GuildDataManager.DungeonDamageRankInfo a_data)
		{
			if (a_objLine == null || a_data == null)
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(a_objLine, "Valid", true);
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Button com = component.GetCom<Button>("BtnSelect");
			if (com == null)
			{
				return;
			}
			com.onClick.RemoveAllListeners();
			com.onClick.AddListener(delegate()
			{
			});
			StaticUtility.SafeSetText(component, "Rank", a_data.nRank.ToString());
			StaticUtility.SafeSetText(component, "Player", a_data.strPlayerName);
			StaticUtility.SafeSetText(component, "Score", a_data.nDamage.ToString());
			if (string.IsNullOrEmpty(a_data.strPlayerName))
			{
				StaticUtility.SafeSetText(component, "Player", DataManager<PlayerBaseData>.GetInstance().Name);
			}
		}

		// Token: 0x0600DDFF RID: 56831 RVA: 0x00386638 File Offset: 0x00384A38
		private void UpdateScoreListItem(int iIndex, GameObject a_objLine, GuildDataManager.DungeonDamageRankInfo a_data)
		{
			if (a_objLine == null || a_data == null)
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(a_objLine, "Valid", true);
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Button com = component.GetCom<Button>("BtnSelect");
			if (com == null)
			{
				return;
			}
			com.onClick.RemoveAllListeners();
			com.onClick.AddListener(delegate()
			{
			});
			StaticUtility.SafeSetText(component, "Rank", string.Empty);
			StaticUtility.SafeSetText(component, "Player", string.Empty);
			StaticUtility.SafeSetText(component, "Score", string.Empty);
			StaticUtility.SafeSetText(component, "Server", string.Empty);
			StaticUtility.SafeSetVisible<Image>(component, "BG", false);
			StaticUtility.SafeSetText(component, "Rank(1)", string.Empty);
			StaticUtility.SafeSetText(component, "Player(1)", string.Empty);
			StaticUtility.SafeSetText(component, "Score(1)", string.Empty);
			StaticUtility.SafeSetText(component, "Server(1)", string.Empty);
			StaticUtility.SafeSetVisible<Image>(component, "BG(1)", false);
			if (iIndex % 2 == 0)
			{
				StaticUtility.SafeSetVisible<Image>(component, "BG", true);
			}
			else
			{
				StaticUtility.SafeSetVisible<Image>(component, "BG(1)", true);
			}
			if (a_data.nPlayerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				StaticUtility.SafeSetText(component, "Rank", a_data.nRank.ToString());
				StaticUtility.SafeSetText(component, "Player", a_data.strPlayerName);
				StaticUtility.SafeSetText(component, "Score", a_data.nDamage.ToString());
			}
			else
			{
				StaticUtility.SafeSetText(component, "Rank(1)", a_data.nRank.ToString());
				StaticUtility.SafeSetText(component, "Player(1)", a_data.strPlayerName);
				StaticUtility.SafeSetText(component, "Score(1)", a_data.nDamage.ToString());
			}
		}

		// Token: 0x0600DE00 RID: 56832 RVA: 0x0038683C File Offset: 0x00384C3C
		private void UpdateAwardListItem(int iIndex, GameObject a_objLine, GuildDungeonDamageRankListFrame.AwardRankItem a_data)
		{
			Text com = this.mBind.GetCom<Text>(string.Format("txtRank{0}", iIndex));
			if (com != null)
			{
				com.text = string.Format("排名{0}-{1}奖励", a_data.iRankMin, a_data.iRankMax);
			}
			Button com2 = this.mBind.GetCom<Button>(string.Format("btnChest{0}", iIndex));
			if (com2 != null)
			{
				com2.onClick.RemoveAllListeners();
				com2.onClick.AddListener(delegate()
				{
					if (a_data.arrItems.Count > 0)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(a_data.arrItems[0], null, 4, true, false, true);
					}
				});
			}
		}

		// Token: 0x0400836D RID: 33645
		[UIControl("Tab/Func1", typeof(Toggle), 0)]
		private Toggle toggleScoreRank;

		// Token: 0x0400836E RID: 33646
		[UIControl("Tab/Func2", typeof(Toggle), 0)]
		private Toggle toggleRankAward;

		// Token: 0x0400836F RID: 33647
		[UIObject("ScoreList")]
		private GameObject goScoreList;

		// Token: 0x04008370 RID: 33648
		[UIObject("AwardList")]
		private GameObject goAwardList;

		// Token: 0x04008371 RID: 33649
		[UIControl("ScoreList/Content", null, 0)]
		private ComUIListScript m_comScoreList;

		// Token: 0x04008372 RID: 33650
		[UIControl("AwardList/Content", null, 0)]
		private ComUIListScript m_comAwardList;

		// Token: 0x04008373 RID: 33651
		[UIObject("ScoreList/Content/MyRank")]
		private GameObject goMyScoreRank;

		// Token: 0x04008374 RID: 33652
		private ComUIListScript mScrollUIList;

		// Token: 0x04008375 RID: 33653
		private ComUIListScript mScrollUIList2;

		// Token: 0x04008376 RID: 33654
		private ComUIListScript mScrollUIList3;

		// Token: 0x04008377 RID: 33655
		private GuildDungeonAwardsShowItem showItems;

		// Token: 0x04008378 RID: 33656
		private List<GuildDungeonDamageRankListFrame.AwardRankItem> m_arrAwardItems;

		// Token: 0x04008379 RID: 33657
		private List<AwardItemData> awardItemDataList = new List<AwardItemData>();

		// Token: 0x0400837A RID: 33658
		private List<AwardItemData> awardItemDataList2 = new List<AwardItemData>();

		// Token: 0x0400837B RID: 33659
		private Text txtTotalDamage;

		// Token: 0x0400837C RID: 33660
		private Dictionary<GuildDungeonAwardsShowItem.AwardType, List<AwardItemData>> awardType2ItemDatas;

		// Token: 0x02001619 RID: 5657
		private class AwardRankItem
		{
			// Token: 0x04008382 RID: 33666
			public int iRankMin;

			// Token: 0x04008383 RID: 33667
			public int iRankMax;

			// Token: 0x04008384 RID: 33668
			public List<ItemData> arrItems = new List<ItemData>();
		}
	}
}
