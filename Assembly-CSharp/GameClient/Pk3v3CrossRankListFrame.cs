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
	// Token: 0x020019B9 RID: 6585
	internal class Pk3v3CrossRankListFrame : ClientFrame
	{
		// Token: 0x0601014D RID: 65869 RVA: 0x00478136 File Offset: 0x00476536
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossRankList";
		}

		// Token: 0x0601014E RID: 65870 RVA: 0x0047813D File Offset: 0x0047653D
		public static void OnOpenLinkFrame(string argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossRankListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601014F RID: 65871 RVA: 0x00478154 File Offset: 0x00476554
		protected override void _OnOpenFrame()
		{
			this.m_arrAwardItems = new List<AwardRankItem>();
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
							AwardRankItem awardRankItem = new AwardRankItem();
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
					this.RefreshScoreRank();
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
			this.RefreshScoreRank();
			this.BindUIEvent();
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 6;
			worldSortListReq.start = 0;
			worldSortListReq.num = (ushort)this.GetMaxRank();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
		}

		// Token: 0x06010150 RID: 65872 RVA: 0x00478426 File Offset: 0x00476826
		protected override void _OnCloseFrame()
		{
			this.m_arrAwardItems = null;
			this.UnBindUIEvent();
		}

		// Token: 0x06010151 RID: 65873 RVA: 0x00478435 File Offset: 0x00476835
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdatePk3v3CrossRankScoreList, new ClientEventSystem.UIEventHandler(this._OnUpdateScoreList));
		}

		// Token: 0x06010152 RID: 65874 RVA: 0x00478452 File Offset: 0x00476852
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdatePk3v3CrossRankScoreList, new ClientEventSystem.UIEventHandler(this._OnUpdateScoreList));
		}

		// Token: 0x06010153 RID: 65875 RVA: 0x0047846F File Offset: 0x0047686F
		private void _OnUpdateScoreList(UIEvent uiEvent)
		{
			this.RefreshScoreRank();
		}

		// Token: 0x06010154 RID: 65876 RVA: 0x00478477 File Offset: 0x00476877
		[UIEventHandle("Close")]
		private void OnCloseBtnClicked()
		{
			this.frameMgr.CloseFrame<Pk3v3CrossRankListFrame>(this, false);
		}

		// Token: 0x06010155 RID: 65877 RVA: 0x00478488 File Offset: 0x00476888
		private void RefreshScoreRank()
		{
			if (this.goScoreList == null)
			{
				return;
			}
			List<Pk3v3CrossDataManager.ScoreListItem> scoreList = DataManager<Pk3v3CrossDataManager>.GetInstance().GetScoreList();
			if (scoreList != null)
			{
				this.m_comScoreList.SetElementAmount(scoreList.Count);
			}
			Pk3v3CrossDataManager.ScoreListItem myRankInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyRankInfo();
			this.UpdateMyScoreListItem((int)myRankInfo.nRank, this.goMyScoreRank, myRankInfo);
		}

		// Token: 0x06010156 RID: 65878 RVA: 0x004784E7 File Offset: 0x004768E7
		private void RrefeshRankAward()
		{
			if (this.goAwardList == null)
			{
				return;
			}
			this.m_comAwardList.SetElementAmount(this.m_arrAwardItems.Count);
		}

		// Token: 0x06010157 RID: 65879 RVA: 0x00478514 File Offset: 0x00476914
		private void OnUpdateScoreListItem(int iIndex, GameObject a_objLine)
		{
			List<Pk3v3CrossDataManager.ScoreListItem> scoreList = DataManager<Pk3v3CrossDataManager>.GetInstance().GetScoreList();
			if (iIndex >= scoreList.Count)
			{
				return;
			}
			Pk3v3CrossDataManager.ScoreListItem a_data = scoreList[iIndex];
			this.UpdateScoreListItem(iIndex, a_objLine, a_data);
		}

		// Token: 0x06010158 RID: 65880 RVA: 0x0047854C File Offset: 0x0047694C
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

		// Token: 0x06010159 RID: 65881 RVA: 0x004785E4 File Offset: 0x004769E4
		private void UpdateMyScoreListItem(int iIndex, GameObject a_objLine, Pk3v3CrossDataManager.ScoreListItem a_data)
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
			StaticUtility.SafeSetText(component, "Score", a_data.nPlayerScore.ToString());
			StaticUtility.SafeSetText(component, "Server", a_data.strServerName);
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (a_data.nRank == 0 || (int)a_data.nRank >= this.GetMaxRank()))
			{
				StaticUtility.SafeSetText(component, "Score", pkInfo.nScore.ToString());
			}
			if (a_data.nRank == 0 || (int)a_data.nRank > this.GetMaxRank())
			{
				StaticUtility.SafeSetText(component, "Rank", "未上榜");
			}
			if (string.IsNullOrEmpty(a_data.strPlayerName))
			{
				StaticUtility.SafeSetText(component, "Player", DataManager<PlayerBaseData>.GetInstance().Name);
			}
			if (string.IsNullOrEmpty(a_data.strServerName))
			{
				StaticUtility.SafeSetText(component, "Server", ClientApplication.adminServer.name);
			}
		}

		// Token: 0x0601015A RID: 65882 RVA: 0x00478798 File Offset: 0x00476B98
		private void UpdateScoreListItem(int iIndex, GameObject a_objLine, Pk3v3CrossDataManager.ScoreListItem a_data)
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
				StaticUtility.SafeSetText(component, "Score", a_data.nPlayerScore.ToString());
				StaticUtility.SafeSetText(component, "Server", a_data.strServerName);
			}
			else
			{
				StaticUtility.SafeSetText(component, "Rank(1)", a_data.nRank.ToString());
				StaticUtility.SafeSetText(component, "Player(1)", a_data.strPlayerName);
				StaticUtility.SafeSetText(component, "Score(1)", a_data.nPlayerScore.ToString());
				StaticUtility.SafeSetText(component, "Server(1)", a_data.strServerName);
			}
		}

		// Token: 0x0601015B RID: 65883 RVA: 0x004789C0 File Offset: 0x00476DC0
		private void UpdateAwardListItem(int iIndex, GameObject a_objLine, AwardRankItem a_data)
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

		// Token: 0x0400A255 RID: 41557
		[UIControl("Tab/Func1", typeof(Toggle), 0)]
		private Toggle toggleScoreRank;

		// Token: 0x0400A256 RID: 41558
		[UIControl("Tab/Func2", typeof(Toggle), 0)]
		private Toggle toggleRankAward;

		// Token: 0x0400A257 RID: 41559
		[UIObject("ScoreList")]
		private GameObject goScoreList;

		// Token: 0x0400A258 RID: 41560
		[UIObject("AwardList")]
		private GameObject goAwardList;

		// Token: 0x0400A259 RID: 41561
		[UIControl("ScoreList/Content", null, 0)]
		private ComUIListScript m_comScoreList;

		// Token: 0x0400A25A RID: 41562
		[UIControl("AwardList/Content", null, 0)]
		private ComUIListScript m_comAwardList;

		// Token: 0x0400A25B RID: 41563
		[UIObject("ScoreList/Content/MyRank")]
		private GameObject goMyScoreRank;

		// Token: 0x0400A25C RID: 41564
		private List<AwardRankItem> m_arrAwardItems;
	}
}
