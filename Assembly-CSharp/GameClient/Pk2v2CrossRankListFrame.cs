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
	// Token: 0x020019A6 RID: 6566
	public class Pk2v2CrossRankListFrame : GameFrame
	{
		// Token: 0x0600FFD8 RID: 65496 RVA: 0x0046E6EA File Offset: 0x0046CAEA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/Pk2v2CrossRankList";
		}

		// Token: 0x0600FFD9 RID: 65497 RVA: 0x0046E6F4 File Offset: 0x0046CAF4
		protected override void OnOpenFrame()
		{
			this.InitRankList();
			this.UpdateRankList();
			this.InitRankAwardList();
			this.UpdateRankAwardList();
			this.BindUIEvent();
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 251;
			worldSortListReq.start = 0;
			worldSortListReq.num = (ushort)this.GetMaxRank();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
		}

		// Token: 0x0600FFDA RID: 65498 RVA: 0x0046E753 File Offset: 0x0046CB53
		protected override void OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600FFDB RID: 65499 RVA: 0x0046E75C File Offset: 0x0046CB5C
		protected override void _bindExUI()
		{
			this.rankList = this.mBind.GetCom<ComUIListScript>("rankList");
			this.rankAwardList = this.mBind.GetCom<ComUIListScript>("rankAwardList");
			this.testTxt = this.mBind.GetCom<Text>("testTxt");
			this.testBtn = this.mBind.GetCom<Button>("testBtn");
			this.testBtn.SafeSetOnClickListener(delegate
			{
			});
			this.testImg = this.mBind.GetCom<Image>("testImg");
			this.testSlider = this.mBind.GetCom<Slider>("testSlider");
			this.testSlider.SafeSetValueChangeListener(delegate(float value)
			{
			});
			this.testToggle = this.mBind.GetCom<Toggle>("testToggle");
			this.testToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
			});
			this.goMyScoreRank = this.mBind.GetGameObject("goMyScoreRank");
		}

		// Token: 0x0600FFDC RID: 65500 RVA: 0x0046E891 File Offset: 0x0046CC91
		protected override void _unbindExUI()
		{
			this.rankList = null;
			this.rankAwardList = null;
			this.testTxt = null;
			this.testBtn = null;
			this.testImg = null;
			this.testSlider = null;
			this.testToggle = null;
			this.goMyScoreRank = null;
		}

		// Token: 0x0600FFDD RID: 65501 RVA: 0x0046E8CB File Offset: 0x0046CCCB
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600FFDE RID: 65502 RVA: 0x0046E8CE File Offset: 0x0046CCCE
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600FFDF RID: 65503 RVA: 0x0046E8D0 File Offset: 0x0046CCD0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdatePk2v2CrossRankScoreList, new ClientEventSystem.UIEventHandler(this._OnUpdateScoreList));
		}

		// Token: 0x0600FFE0 RID: 65504 RVA: 0x0046E908 File Offset: 0x0046CD08
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdatePk2v2CrossRankScoreList, new ClientEventSystem.UIEventHandler(this._OnUpdateScoreList));
		}

		// Token: 0x0600FFE1 RID: 65505 RVA: 0x0046E940 File Offset: 0x0046CD40
		private int GetMaxRank()
		{
			return 100;
		}

		// Token: 0x0600FFE2 RID: 65506 RVA: 0x0046E944 File Offset: 0x0046CD44
		private void RefreshScoreRank()
		{
			List<Pk2v2CrossDataManager.ScoreListItem> scoreList = DataManager<Pk2v2CrossDataManager>.GetInstance().GetScoreList();
			if (scoreList != null)
			{
				this.rankList.SetElementAmount(scoreList.Count);
			}
			Pk2v2CrossDataManager.ScoreListItem myRankInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().GetMyRankInfo();
			this.UpdateMyScoreListItem((int)myRankInfo.nRank, this.goMyScoreRank, myRankInfo);
		}

		// Token: 0x0600FFE3 RID: 65507 RVA: 0x0046E994 File Offset: 0x0046CD94
		private void OnUpdateScoreListItem(int iIndex, GameObject a_objLine)
		{
			List<Pk2v2CrossDataManager.ScoreListItem> scoreList = DataManager<Pk2v2CrossDataManager>.GetInstance().GetScoreList();
			if (iIndex >= scoreList.Count)
			{
				return;
			}
			Pk2v2CrossDataManager.ScoreListItem a_data = scoreList[iIndex];
			this.UpdateScoreListItem(iIndex, a_objLine, a_data);
		}

		// Token: 0x0600FFE4 RID: 65508 RVA: 0x0046E9CC File Offset: 0x0046CDCC
		private void UpdateScoreListItem(int iIndex, GameObject a_objLine, Pk2v2CrossDataManager.ScoreListItem a_data)
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

		// Token: 0x0600FFE5 RID: 65509 RVA: 0x0046EBF4 File Offset: 0x0046CFF4
		private void UpdateMyScoreListItem(int iIndex, GameObject a_objLine, Pk2v2CrossDataManager.ScoreListItem a_data)
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
			Pk2v2CrossDataManager.My2v2PkInfo pkInfo = DataManager<Pk2v2CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (a_data.nRank == 0 || (int)a_data.nRank >= this.GetMaxRank()))
			{
				StaticUtility.SafeSetText(component, "Score", pkInfo.nScore.ToString());
			}
			if (a_data.nRank == 0 || (int)a_data.nRank > this.GetMaxRank())
			{
				StaticUtility.SafeSetText(component, "Rank", TR.Value("2v2melee_score_war_no_rank"));
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

		// Token: 0x0600FFE6 RID: 65510 RVA: 0x0046EDAC File Offset: 0x0046D1AC
		private void InitRankList()
		{
			if (this.rankList == null)
			{
				return;
			}
			this.rankList.Initialize();
			this.rankList.onBindItem = ((GameObject go) => go);
			this.rankList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.OnUpdateScoreListItem(item.m_index, item.gameObject);
				}
			};
		}

		// Token: 0x0600FFE7 RID: 65511 RVA: 0x0046EE15 File Offset: 0x0046D215
		private void UpdateRankList()
		{
			this.RefreshScoreRank();
		}

		// Token: 0x0600FFE8 RID: 65512 RVA: 0x0046EE20 File Offset: 0x0046D220
		private void InitRankAwardList()
		{
			if (this.rankAwardList == null)
			{
				return;
			}
			this.rankAwardList.Initialize();
			this.rankAwardList.onBindItem = ((GameObject go) => go);
			this.rankAwardList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (this.awardItemDatas != null && item.m_index < this.awardItemDatas.Count)
				{
					this.UpdateRankAwardListItem(item, this.awardItemDatas[item.m_index]);
				}
			};
		}

		// Token: 0x0600FFE9 RID: 65513 RVA: 0x0046EE8C File Offset: 0x0046D28C
		private void CalcRankAwardItemDatas()
		{
			this.awardItemDatas = new List<AwardItemData>();
			if (this.awardItemDatas == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWar2v2RewardTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("TableManager.instance.GetTable<ScoreWarRewardTable>() error!!!", new object[0]);
			}
			else
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ScoreWar2v2RewardTable scoreWar2v2RewardTable = keyValuePair.Value as ScoreWar2v2RewardTable;
					if (scoreWar2v2RewardTable != null && scoreWar2v2RewardTable.RankingBegin == 1 && scoreWar2v2RewardTable.RankingEnd == 10)
					{
						for (int i = 0; i < scoreWar2v2RewardTable.ItemReward.Count; i++)
						{
							string text = scoreWar2v2RewardTable.ItemRewardArray(i);
							string[] array = text.Split(new char[]
							{
								'_'
							});
							if (array.Length >= 2)
							{
								int id = int.Parse(array[0]);
								int num = int.Parse(array[1]);
								this.awardItemDatas.Add(new AwardItemData
								{
									ID = id,
									Num = num
								});
							}
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600FFEA RID: 65514 RVA: 0x0046EFAC File Offset: 0x0046D3AC
		private void UpdateRankAwardListItem(ComUIListElementScript item, AwardItemData awardItemData)
		{
			if (item == null)
			{
				return;
			}
			if (awardItemData == null)
			{
				return;
			}
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			ComItem com = component.GetCom<ComItem>("Item");
			if (com == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			itemData.Count = awardItemData.Num;
			com.Setup(itemData, delegate(GameObject go, ItemData data)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(data, null, 4, true, false, true);
			});
		}

		// Token: 0x0600FFEB RID: 65515 RVA: 0x0046F040 File Offset: 0x0046D440
		private void UpdateRankAwardList()
		{
			if (this.rankAwardList == null)
			{
				return;
			}
			this.CalcRankAwardItemDatas();
			if (this.awardItemDatas == null)
			{
				return;
			}
			this.rankAwardList.SetElementAmount(this.awardItemDatas.Count);
		}

		// Token: 0x0600FFEC RID: 65516 RVA: 0x0046F07C File Offset: 0x0046D47C
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x0600FFED RID: 65517 RVA: 0x0046F07E File Offset: 0x0046D47E
		private void _OnUpdateScoreList(UIEvent uiEvent)
		{
			this.RefreshScoreRank();
		}

		// Token: 0x0400A15B RID: 41307
		private List<AwardItemData> awardItemDatas = new List<AwardItemData>();

		// Token: 0x0400A15C RID: 41308
		private const int maxRank = 100;

		// Token: 0x0400A15D RID: 41309
		private ComUIListScript rankList;

		// Token: 0x0400A15E RID: 41310
		private Text testTxt;

		// Token: 0x0400A15F RID: 41311
		private Button testBtn;

		// Token: 0x0400A160 RID: 41312
		private Image testImg;

		// Token: 0x0400A161 RID: 41313
		private Slider testSlider;

		// Token: 0x0400A162 RID: 41314
		private Toggle testToggle;

		// Token: 0x0400A163 RID: 41315
		private GameObject goMyScoreRank;

		// Token: 0x0400A164 RID: 41316
		private ComUIListScript rankAwardList;
	}
}
