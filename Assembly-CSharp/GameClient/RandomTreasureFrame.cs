using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D0 RID: 6608
	public class RandomTreasureFrame : ClientFrame
	{
		// Token: 0x17001D2F RID: 7471
		// (get) Token: 0x060102EB RID: 66283 RVA: 0x004832B9 File Offset: 0x004816B9
		public bool BRefreshDigInfoDelay
		{
			get
			{
				return this.bRefreshDigInfoDelay;
			}
		}

		// Token: 0x060102EC RID: 66284 RVA: 0x004832C1 File Offset: 0x004816C1
		protected override void _OnOpenFrame()
		{
			this._BindNetEvent();
			this._BindUIEvent();
			this._InitFrame();
		}

		// Token: 0x060102ED RID: 66285 RVA: 0x004832D5 File Offset: 0x004816D5
		protected override void _OnCloseFrame()
		{
			this._CloaseAllAttachFrame();
			this._ClearFrame();
			this._UnBindUIEvent();
			this._UnBindNetEvent();
		}

		// Token: 0x060102EE RID: 66286 RVA: 0x004832EF File Offset: 0x004816EF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureFrame";
		}

		// Token: 0x060102EF RID: 66287 RVA: 0x004832F8 File Offset: 0x004816F8
		private void _InitFrame()
		{
			this.tr_record_info_format = TR.Value("random_treasure_record_format");
			this.tr_gold_treasure_desc = TR.Value("random_treasure_gold_box");
			this.tr_silver_treasure_desc = TR.Value("random_treasure_silver_box");
			this.tr_player_name_format = TR.Value("random_treasure_player_name_format");
			this.tr_change_map_btn_cd = TR.Value("random_treasure_change_map_btn_cd");
			if (this.mComMiniMap != null)
			{
				this.mComMiniMap.BindFuncBtnEvent(delegate
				{
					this._OpenRandomTreasureAtlas();
				});
			}
			if (this.mNocache)
			{
				this.mNocache.CustomActive(true);
			}
			if (this.mMapFrameObj == null)
			{
				this.mMapFrameObj = new RandomTreasureMap();
				this.mMapFrameObj.Create(this.mMapRoot, this);
			}
			DataManager<RandomTreasureDataManager>.GetInstance().ReqOpenFirstTreasureMap();
			DataManager<RandomTreasureDataManager>.GetInstance().ReqMapRecordInfo();
			DataManager<RandomTreasureDataManager>.GetInstance().ReqTotalAtlasInfo();
		}

		// Token: 0x060102F0 RID: 66288 RVA: 0x004833E0 File Offset: 0x004817E0
		private void _RefreshFrame()
		{
			RandomTreasureFrame.ChildFrameType childFrameType = this.mSelectedFrameType;
			if (childFrameType != RandomTreasureFrame.ChildFrameType.Map)
			{
				if (childFrameType != RandomTreasureFrame.ChildFrameType.Atlas)
				{
					if (childFrameType != RandomTreasureFrame.ChildFrameType.Raffle)
					{
					}
				}
			}
		}

		// Token: 0x060102F1 RID: 66289 RVA: 0x0048341C File Offset: 0x0048181C
		private void _CloaseAllAttachFrame()
		{
			this._CloseSelectedRandomTreasureMap();
			this._CloseRandomTreasureAtlas();
			this._CloseRandomTreasureRaffle();
		}

		// Token: 0x060102F2 RID: 66290 RVA: 0x00483430 File Offset: 0x00481830
		private void _ClearFrame()
		{
			this.mSelectedFrameType = RandomTreasureFrame.ChildFrameType.Map;
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.Destroy();
				this.mMapFrameObj = null;
			}
			this.tr_record_info_format = string.Empty;
			this.tr_gold_treasure_desc = string.Empty;
			this.tr_silver_treasure_desc = string.Empty;
			this.tr_player_name_format = string.Empty;
			this.tr_change_map_btn_cd = string.Empty;
			this.canCloseFrame = true;
			this.bRefreshRecordInfoDelay = false;
			this.bRefreshItemCountDelay = false;
			this.bRefreshDigInfoDelay = false;
			if (this.mRecordScrollList != null)
			{
				this.mRecordScrollList.SetElementAmount(0);
			}
		}

		// Token: 0x060102F3 RID: 66291 RVA: 0x004834D4 File Offset: 0x004818D4
		private void _OpenSelectedRandomTreasureMap(RandomTreasureMapModel mapModel)
		{
			if (this.mMapRoot == null)
			{
				Logger.LogErrorFormat("[RandomTreasureFrame] - _OpenSelectedRandomTreasureMap mMapRoot is null", new object[0]);
				return;
			}
			if (mapModel == null)
			{
				return;
			}
			this.mMapFrameObj.RefreshData(mapModel);
			this.mMapFrameObj.Show();
		}

		// Token: 0x060102F4 RID: 66292 RVA: 0x00483521 File Offset: 0x00481921
		private void _CloseSelectedRandomTreasureMap()
		{
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.Hide();
			}
		}

		// Token: 0x060102F5 RID: 66293 RVA: 0x0048353C File Offset: 0x0048193C
		private void _OpenRandomTreasureAtlas()
		{
			RandomTreasureMapModel userData = null;
			if (this.mMapFrameObj != null)
			{
				userData = this.mMapFrameObj.GetCurrentMapModel();
			}
			RandomTreasureAtlas randomTreasureAtlas;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RandomTreasureAtlas>(null))
			{
				randomTreasureAtlas = (Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(RandomTreasureAtlas)) as RandomTreasureAtlas);
			}
			else
			{
				randomTreasureAtlas = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<RandomTreasureAtlas>(FrameLayer.Middle, userData, string.Empty) as RandomTreasureAtlas);
			}
			if (randomTreasureAtlas != null)
			{
				DataManager<RandomTreasureDataManager>.GetInstance().ReqTotalAtlasInfo();
			}
		}

		// Token: 0x060102F6 RID: 66294 RVA: 0x004835BA File Offset: 0x004819BA
		private void _CloseRandomTreasureAtlas()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RandomTreasureAtlas>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RandomTreasureAtlas>(null, false);
			}
		}

		// Token: 0x060102F7 RID: 66295 RVA: 0x004835D8 File Offset: 0x004819D8
		private void _OpenRandomTreasureRaffle(RandomTreasureMapDigSiteModel digSiteModel)
		{
			RandomTreasureRaffle randomTreasureRaffle;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RandomTreasureRaffle>(null))
			{
				randomTreasureRaffle = (Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(RandomTreasureRaffle)) as RandomTreasureRaffle);
			}
			else
			{
				randomTreasureRaffle = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<RandomTreasureRaffle>(FrameLayer.Middle, digSiteModel, string.Empty) as RandomTreasureRaffle);
			}
			if (randomTreasureRaffle != null && digSiteModel != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnWatchRefreshDigSite, digSiteModel, null, null, null);
			}
		}

		// Token: 0x060102F8 RID: 66296 RVA: 0x0048364C File Offset: 0x00481A4C
		private void _CloseRandomTreasureRaffle()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RandomTreasureRaffle>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RandomTreasureRaffle>(null, false);
			}
		}

		// Token: 0x060102F9 RID: 66297 RVA: 0x0048366A File Offset: 0x00481A6A
		private void _BindNetEvent()
		{
			DataManager<RandomTreasureDataManager>.GetInstance().AddNetEventListener();
		}

		// Token: 0x060102FA RID: 66298 RVA: 0x00483676 File Offset: 0x00481A76
		private void _UnBindNetEvent()
		{
			DataManager<RandomTreasureDataManager>.GetInstance().RemoveNetEventListener();
		}

		// Token: 0x060102FB RID: 66299 RVA: 0x00483682 File Offset: 0x00481A82
		private void _RefreshGoldAndSilverKeyNum()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTresureItemCountChanged, null, null, null, null);
		}

		// Token: 0x060102FC RID: 66300 RVA: 0x00483698 File Offset: 0x00481A98
		private void _RefreshRecordView()
		{
			List<RandomTreasureMapRecordModel> recordModel = DataManager<RandomTreasureDataManager>.GetInstance().GetMapRecordInfoList();
			if (recordModel == null)
			{
				return;
			}
			if (this.mRecordScrollList == null)
			{
				return;
			}
			if (!this.mRecordScrollList.IsInitialised())
			{
				this.mRecordScrollList.Initialize();
				this.mRecordScrollList.onBindItem = ((GameObject go) => go.GetComponent<LinkParse>());
			}
			this.mRecordScrollList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < recordModel.Count)
				{
					LinkParse linkParse = var.gameObjectBindScript as LinkParse;
					if (linkParse == null)
					{
						return;
					}
					int index2 = recordModel.Count - 1 - index;
					RandomTreasureMapRecordModel randomTreasureMapRecordModel = recordModel[index2];
					if (randomTreasureMapRecordModel == null)
					{
						return;
					}
					if (linkParse.m_kTarget == null)
					{
						return;
					}
					string empty = string.Empty;
					if (randomTreasureMapRecordModel.digType == DigType.DIG_GLOD)
					{
						empty = this.tr_gold_treasure_desc;
					}
					else if (randomTreasureMapRecordModel.digType == DigType.DIG_SILVER)
					{
						empty = this.tr_silver_treasure_desc;
					}
					string text = string.Format(this.tr_player_name_format, randomTreasureMapRecordModel.playerName);
					if (randomTreasureMapRecordModel.itemSData == null)
					{
						return;
					}
					string text2 = string.Format("{{I 0 {0} 0}} * {1}", randomTreasureMapRecordModel.itemSData.ItemID, randomTreasureMapRecordModel.itemSData.Count);
					linkParse.SetText(string.Format(this.tr_record_info_format, new object[]
					{
						text,
						randomTreasureMapRecordModel.mapName,
						empty,
						text2
					}), true);
				}
			};
			this.mRecordScrollList.SetElementAmount(recordModel.Count);
			if (recordModel.Count > 0)
			{
				this.mRecordScrollList.EnsureElementVisable(0);
			}
		}

		// Token: 0x060102FD RID: 66301 RVA: 0x00483770 File Offset: 0x00481B70
		private void _TryChangeSuitableTreasureMap()
		{
			if (this.mMapFrameObj == null)
			{
				return;
			}
			RandomTreasureMapModel currentMapModel = this.mMapFrameObj.GetCurrentMapModel();
			if (currentMapModel == null)
			{
				Logger.LogError("[RandomTreasureFrame] - _TryChangeSuitableTreasureMap currMapModel is null !!! ");
				return;
			}
			List<RandomTreasureMapModel> treasureTypeMapModelList = DataManager<RandomTreasureDataManager>.GetInstance().GetTreasureTypeMapModelList(DigType.DIG_GLOD, true, currentMapModel);
			List<RandomTreasureMapModel> treasureTypeMapModelList2 = DataManager<RandomTreasureDataManager>.GetInstance().GetTreasureTypeMapModelList(DigType.DIG_SILVER, true, currentMapModel);
			if (treasureTypeMapModelList == null || treasureTypeMapModelList2 == null)
			{
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = null;
			if (treasureTypeMapModelList.Count > 0)
			{
				int index = Random.Range(0, treasureTypeMapModelList.Count - 1);
				randomTreasureMapModel = treasureTypeMapModelList[index];
			}
			else if (treasureTypeMapModelList.Count == 0 && treasureTypeMapModelList2.Count > 0)
			{
				int index = Random.Range(0, treasureTypeMapModelList2.Count - 1);
				randomTreasureMapModel = treasureTypeMapModelList2[index];
			}
			else if (treasureTypeMapModelList.Count == 0 && treasureTypeMapModelList2.Count == 0)
			{
				List<RandomTreasureMapModel> filterMapModelList = DataManager<RandomTreasureDataManager>.GetInstance().GetFilterMapModelList(currentMapModel);
				if (filterMapModelList == null || filterMapModelList.Count <= 0)
				{
					return;
				}
				int index = Random.Range(0, filterMapModelList.Count - 1);
				randomTreasureMapModel = filterMapModelList[index];
			}
			if (randomTreasureMapModel != null)
			{
				this.mMapFrameObj.TryChangeTreasureMap(randomTreasureMapModel);
			}
		}

		// Token: 0x060102FE RID: 66302 RVA: 0x00483898 File Offset: 0x00481C98
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnOpenTreasureDigMap, new ClientEventSystem.UIEventHandler(this._OnOpenTreasureDigMap));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureDigMapOpen, new ClientEventSystem.UIEventHandler(this._OnTreasureDigMapOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureDigMapClose, new ClientEventSystem.UIEventHandler(this._OnTreasureDigMapClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnChangeTreasureDigMap, new ClientEventSystem.UIEventHandler(this._OnChangeTreasureDigMap));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureMapPlayerNumSync, new ClientEventSystem.UIEventHandler(this._OnTreasureMapPlayerNumChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureMapDigReset, new ClientEventSystem.UIEventHandler(this._OnTreasureMapDigReset));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureDigSiteChanged, new ClientEventSystem.UIEventHandler(this._OnTreasureDigSiteChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnWatchTreasureDigSite, new ClientEventSystem.UIEventHandler(this._OnWatchTreasureDigSite));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRaffleStart, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRaffleEnd, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRecordInfoSync, new ClientEventSystem.UIEventHandler(this._OnTreasureRecordInfoSync));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureRecordInfoChanged, new ClientEventSystem.UIEventHandler(this._OnTreasureRecordInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureAtlasOpen, new ClientEventSystem.UIEventHandler(this._OnTreasureAtlasOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureAtlasClose, new ClientEventSystem.UIEventHandler(this._OnTreasureAtlasClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureItemBuyRes, new ClientEventSystem.UIEventHandler(this._OnSyncWorldMallBuySucceed));
		}

		// Token: 0x060102FF RID: 66303 RVA: 0x00483A3C File Offset: 0x00481E3C
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnOpenTreasureDigMap, new ClientEventSystem.UIEventHandler(this._OnOpenTreasureDigMap));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureDigMapOpen, new ClientEventSystem.UIEventHandler(this._OnTreasureDigMapOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureDigMapClose, new ClientEventSystem.UIEventHandler(this._OnTreasureDigMapClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnChangeTreasureDigMap, new ClientEventSystem.UIEventHandler(this._OnChangeTreasureDigMap));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureMapPlayerNumSync, new ClientEventSystem.UIEventHandler(this._OnTreasureMapPlayerNumChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureMapDigReset, new ClientEventSystem.UIEventHandler(this._OnTreasureMapDigReset));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureDigSiteChanged, new ClientEventSystem.UIEventHandler(this._OnTreasureDigSiteChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnWatchTreasureDigSite, new ClientEventSystem.UIEventHandler(this._OnWatchTreasureDigSite));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRaffleStart, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRaffleEnd, new ClientEventSystem.UIEventHandler(this._OnTreasureRaffleEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRecordInfoSync, new ClientEventSystem.UIEventHandler(this._OnTreasureRecordInfoSync));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureRecordInfoChanged, new ClientEventSystem.UIEventHandler(this._OnTreasureRecordInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureAtlasOpen, new ClientEventSystem.UIEventHandler(this._OnTreasureAtlasOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureAtlasClose, new ClientEventSystem.UIEventHandler(this._OnTreasureAtlasClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureItemBuyRes, new ClientEventSystem.UIEventHandler(this._OnSyncWorldMallBuySucceed));
		}

		// Token: 0x06010300 RID: 66304 RVA: 0x00483BE0 File Offset: 0x00481FE0
		private void _OnOpenTreasureDigMap(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel mapModel = uiEvent.Param1 as RandomTreasureMapModel;
			this._OpenSelectedRandomTreasureMap(mapModel);
			this._CloseRandomTreasureAtlas();
			if (this.mNocache)
			{
				this.mNocache.CustomActive(false);
			}
		}

		// Token: 0x06010301 RID: 66305 RVA: 0x00483C2C File Offset: 0x0048202C
		private void _OnTreasureDigMapOpen(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = uiEvent.Param1 as RandomTreasureMapModel;
			if (randomTreasureMapModel != null && this.mComMiniMap != null)
			{
				this.mComMiniMap.RefreshView(randomTreasureMapModel.mapId);
			}
		}

		// Token: 0x06010302 RID: 66306 RVA: 0x00483C74 File Offset: 0x00482074
		private void _OnTreasureDigMapClose(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = uiEvent.Param1 as RandomTreasureMapModel;
			if (randomTreasureMapModel != null)
			{
				DataManager<RandomTreasureDataManager>.GetInstance().ReqCloseTreasureMap(randomTreasureMapModel);
			}
		}

		// Token: 0x06010303 RID: 66307 RVA: 0x00483CA8 File Offset: 0x004820A8
		private void _OnChangeTreasureDigMap(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel randomTreasureMapModel = uiEvent.Param1 as RandomTreasureMapModel;
			if (randomTreasureMapModel == null)
			{
				return;
			}
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.TryChangeTreasureMap(randomTreasureMapModel);
			}
		}

		// Token: 0x06010304 RID: 66308 RVA: 0x00483CE8 File Offset: 0x004820E8
		private void _OnTreasureMapPlayerNumChanged(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel mapModel = uiEvent.Param1 as RandomTreasureMapModel;
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.ChangeCurrTreasureMapPlayerNum(mapModel);
			}
		}

		// Token: 0x06010305 RID: 66309 RVA: 0x00483D20 File Offset: 0x00482120
		private void _OnTreasureMapDigReset(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapModel mapModel = uiEvent.Param1 as RandomTreasureMapModel;
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.ResetCurrTreasureMapDig(mapModel);
			}
		}

		// Token: 0x06010306 RID: 66310 RVA: 0x00483D58 File Offset: 0x00482158
		private void _OnTreasureDigSiteChanged(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			RandomTreasureMapDigSiteModel mapSiteModel = uiEvent.Param1 as RandomTreasureMapDigSiteModel;
			if (this.mMapFrameObj != null)
			{
				this.mMapFrameObj.ChangedCurrTreasureDigSite(mapSiteModel);
			}
		}

		// Token: 0x06010307 RID: 66311 RVA: 0x00483D90 File Offset: 0x00482190
		private void _OnWatchTreasureDigSite(UIEvent uiEvent)
		{
			RandomTreasureMapDigSiteModel randomTreasureMapDigSiteModel = uiEvent.Param1 as RandomTreasureMapDigSiteModel;
			if (randomTreasureMapDigSiteModel == null)
			{
				return;
			}
			this._OpenRandomTreasureRaffle(randomTreasureMapDigSiteModel);
		}

		// Token: 0x06010308 RID: 66312 RVA: 0x00483DB7 File Offset: 0x004821B7
		private void _OnTreasureRaffleStart(UIEvent uiEvent)
		{
			this.bRefreshDigInfoDelay = true;
			this.bRefreshRecordInfoDelay = true;
			this.bRefreshItemCountDelay = true;
			this.canCloseFrame = false;
		}

		// Token: 0x06010309 RID: 66313 RVA: 0x00483DD8 File Offset: 0x004821D8
		private void _OnTreasureRaffleEnd(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				Logger.LogError("[RandomTreasureFrame] - _OnTreasureRaffleEnd UIEvent is null");
				return;
			}
			bool flag = false;
			if (uiEvent.Param1 != null)
			{
				flag = (bool)uiEvent.Param1;
			}
			bool flag2 = false;
			if (uiEvent.Param2 != null)
			{
				flag2 = (bool)uiEvent.Param2;
			}
			if (flag && this.mMapFrameObj != null)
			{
				this.bRefreshDigInfoDelay = false;
				this.mMapFrameObj.RefreshDigSiteView();
			}
			if (flag2)
			{
				this._RefreshRecordView();
			}
			this._RefreshGoldAndSilverKeyNum();
			this.canCloseFrame = true;
		}

		// Token: 0x0601030A RID: 66314 RVA: 0x00483E64 File Offset: 0x00482264
		private void _OnTreasureRecordInfoChanged(UIEvent uiEvent)
		{
			if (this.bRefreshRecordInfoDelay)
			{
				this.bRefreshRecordInfoDelay = false;
				return;
			}
			this._RefreshRecordView();
		}

		// Token: 0x0601030B RID: 66315 RVA: 0x00483E7F File Offset: 0x0048227F
		private void _OnTreasureRecordInfoSync(UIEvent uiEvent)
		{
			this._RefreshRecordView();
		}

		// Token: 0x0601030C RID: 66316 RVA: 0x00483E87 File Offset: 0x00482287
		private void _OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			this._RefreshGoldAndSilverKeyNum();
		}

		// Token: 0x0601030D RID: 66317 RVA: 0x00483E8F File Offset: 0x0048228F
		private void _OnTreasureAtlasOpen(UIEvent uiEvent)
		{
			if (this.mComMiniMap != null)
			{
				this.mComMiniMap.CustomActive(false);
			}
		}

		// Token: 0x0601030E RID: 66318 RVA: 0x00483EAE File Offset: 0x004822AE
		private void _OnTreasureAtlasClose(UIEvent uiEvent)
		{
			if (this.mComMiniMap != null)
			{
				this.mComMiniMap.CustomActive(true);
			}
		}

		// Token: 0x0601030F RID: 66319 RVA: 0x00483ED0 File Offset: 0x004822D0
		protected override void _bindExUI()
		{
			this.mCloseBtn = this.mBind.GetCom<Button>("CloseBtn");
			if (null != this.mCloseBtn)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this._onCloseBtnButtonClick));
			}
			this.mComMiniMap = this.mBind.GetCom<RandomTreasureMiniMap>("ComMiniMap");
			this.mRecordRoot = this.mBind.GetGameObject("RecordRoot");
			this.mMapRoot = this.mBind.GetGameObject("MapRoot");
			this.mAtlasRoot = this.mBind.GetGameObject("AtlasRoot");
			this.mRaffleRoot = this.mBind.GetGameObject("RaffleRoot");
			this.mRecordScrollList = this.mBind.GetCom<ComUIListScript>("RecordScrollList");
			this.mGoldenInfo = this.mBind.GetCom<RandomTreasureInfo>("goldenInfo");
			this.mSilverInfo = this.mBind.GetCom<RandomTreasureInfo>("silverInfo");
			this.mAccquireBtn_Golden = this.mBind.GetCom<Button>("accquireBtn_Golden");
			if (null != this.mAccquireBtn_Golden)
			{
				this.mAccquireBtn_Golden.onClick.AddListener(new UnityAction(this._onAccquireBtn_GoldenButtonClick));
			}
			this.mAccquireBtn_Silver = this.mBind.GetCom<Button>("accquireBtn_Silver");
			if (null != this.mAccquireBtn_Silver)
			{
				this.mAccquireBtn_Silver.onClick.AddListener(new UnityAction(this._onAccquireBtn_SilverButtonClick));
			}
			this.mNocache = this.mBind.GetGameObject("nocache");
			this.mMapSelectBtn = this.mBind.GetCom<Button>("MapSelectBtn");
			if (null != this.mMapSelectBtn)
			{
				this.mMapSelectBtn.onClick.AddListener(new UnityAction(this._onMapSelectBtnButtonClick));
			}
			this.mMapSelectBtnGray = this.mBind.GetCom<UIGray>("MapSelectBtnGray");
			this.mMapSelectBtnCD = this.mBind.GetCom<SetComButtonCD>("MapSelectBtnCD");
		}

		// Token: 0x06010310 RID: 66320 RVA: 0x004840DC File Offset: 0x004824DC
		protected override void _unbindExUI()
		{
			if (null != this.mCloseBtn)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this._onCloseBtnButtonClick));
			}
			this.mCloseBtn = null;
			this.mComMiniMap = null;
			this.mRecordRoot = null;
			this.mMapRoot = null;
			this.mAtlasRoot = null;
			this.mRaffleRoot = null;
			this.mRecordScrollList = null;
			this.mGoldenInfo = null;
			this.mSilverInfo = null;
			if (null != this.mAccquireBtn_Golden)
			{
				this.mAccquireBtn_Golden.onClick.RemoveListener(new UnityAction(this._onAccquireBtn_GoldenButtonClick));
			}
			this.mAccquireBtn_Golden = null;
			if (null != this.mAccquireBtn_Silver)
			{
				this.mAccquireBtn_Silver.onClick.RemoveListener(new UnityAction(this._onAccquireBtn_SilverButtonClick));
			}
			this.mAccquireBtn_Silver = null;
			this.mNocache = null;
			if (null != this.mMapSelectBtn)
			{
				this.mMapSelectBtn.onClick.RemoveListener(new UnityAction(this._onMapSelectBtnButtonClick));
			}
			this.mMapSelectBtn = null;
			this.mMapSelectBtnGray = null;
			this.mMapSelectBtnCD = null;
		}

		// Token: 0x06010311 RID: 66321 RVA: 0x00484206 File Offset: 0x00482606
		private void _onCloseBtnButtonClick()
		{
			if (!this.canCloseFrame)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("randrom_treasure_raffle_anim_playing"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			base.Close(false);
		}

		// Token: 0x06010312 RID: 66322 RVA: 0x0048422C File Offset: 0x0048262C
		private void _onAccquireBtn_GoldenButtonClick()
		{
			ItemComeLink.OnLink(DataManager<RandomTreasureDataManager>.GetInstance().Gold_Treasure_Item_Id, 0, false, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010313 RID: 66323 RVA: 0x00484254 File Offset: 0x00482654
		private void _onAccquireBtn_SilverButtonClick()
		{
			ItemComeLink.OnLink(DataManager<RandomTreasureDataManager>.GetInstance().Silver_Treasure_Item_Id, 0, false, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010314 RID: 66324 RVA: 0x0048427C File Offset: 0x0048267C
		private void _onMapSelectBtnButtonClick()
		{
			if (this.mMapSelectBtnCD != null && !this.mMapSelectBtnCD.IsBtnWork())
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_change_map_btn_cd, CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mMapSelectBtnCD != null)
			{
				this.mMapSelectBtnCD.StartBtCD();
			}
			this._TryChangeSuitableTreasureMap();
		}

		// Token: 0x0400A39E RID: 41886
		private RandomTreasureFrame.ChildFrameType mSelectedFrameType;

		// Token: 0x0400A39F RID: 41887
		private RandomTreasureMap mMapFrameObj;

		// Token: 0x0400A3A0 RID: 41888
		private string tr_record_info_format = string.Empty;

		// Token: 0x0400A3A1 RID: 41889
		private string tr_gold_treasure_desc = string.Empty;

		// Token: 0x0400A3A2 RID: 41890
		private string tr_silver_treasure_desc = string.Empty;

		// Token: 0x0400A3A3 RID: 41891
		private string tr_player_name_format = string.Empty;

		// Token: 0x0400A3A4 RID: 41892
		private string tr_change_map_btn_cd = string.Empty;

		// Token: 0x0400A3A5 RID: 41893
		private bool canCloseFrame = true;

		// Token: 0x0400A3A6 RID: 41894
		private bool bRefreshRecordInfoDelay;

		// Token: 0x0400A3A7 RID: 41895
		private bool bRefreshItemCountDelay;

		// Token: 0x0400A3A8 RID: 41896
		private bool bRefreshDigInfoDelay;

		// Token: 0x0400A3A9 RID: 41897
		private Button mCloseBtn;

		// Token: 0x0400A3AA RID: 41898
		private RandomTreasureMiniMap mComMiniMap;

		// Token: 0x0400A3AB RID: 41899
		private GameObject mRecordRoot;

		// Token: 0x0400A3AC RID: 41900
		private GameObject mMapRoot;

		// Token: 0x0400A3AD RID: 41901
		private GameObject mAtlasRoot;

		// Token: 0x0400A3AE RID: 41902
		private GameObject mRaffleRoot;

		// Token: 0x0400A3AF RID: 41903
		private ComUIListScript mRecordScrollList;

		// Token: 0x0400A3B0 RID: 41904
		private RandomTreasureInfo mGoldenInfo;

		// Token: 0x0400A3B1 RID: 41905
		private RandomTreasureInfo mSilverInfo;

		// Token: 0x0400A3B2 RID: 41906
		private Button mAccquireBtn_Golden;

		// Token: 0x0400A3B3 RID: 41907
		private Button mAccquireBtn_Silver;

		// Token: 0x0400A3B4 RID: 41908
		private GameObject mNocache;

		// Token: 0x0400A3B5 RID: 41909
		private Button mMapSelectBtn;

		// Token: 0x0400A3B6 RID: 41910
		private UIGray mMapSelectBtnGray;

		// Token: 0x0400A3B7 RID: 41911
		private SetComButtonCD mMapSelectBtnCD;

		// Token: 0x020019D1 RID: 6609
		public enum ChildFrameType
		{
			// Token: 0x0400A3BA RID: 41914
			Map,
			// Token: 0x0400A3BB RID: 41915
			Atlas,
			// Token: 0x0400A3BC RID: 41916
			Raffle
		}
	}
}
