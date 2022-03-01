using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D4 RID: 6612
	public class RandomTreasureMap
	{
		// Token: 0x06010323 RID: 66339 RVA: 0x004845D8 File Offset: 0x004829D8
		private void _ClearData()
		{
			this.mRootFrame = null;
			this.mBind = null;
			this.mParentGo = null;
			this.mParentGo = null;
			this.bShowed = false;
			this.mMapBgImg = null;
			this.mPlayerInfo = null;
			this.mName = null;
			if (this.mRandomTreasureMapSiteDic != null)
			{
				this.mRandomTreasureMapSiteDic.Clear();
				this.mRandomTreasureMapSiteDic = null;
			}
			this.mCurrentMapSite = null;
			this.mData = null;
			this.tr_map_player_num = string.Empty;
			if (this.waitToInitComMapSites != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToInitComMapSites);
				this.waitToInitComMapSites = null;
			}
		}

		// Token: 0x06010324 RID: 66340 RVA: 0x00484678 File Offset: 0x00482A78
		private void _InitFrame()
		{
			this.tr_map_player_num = TR.Value("random_treasure_map_player_num");
			if (this.mMapBgImg)
			{
				this.mMapBgImg.CustomActive(false);
			}
			if (this.waitToInitComMapSites != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToInitComMapSites);
			}
			this.waitToInitComMapSites = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToInitComMapSites());
		}

		// Token: 0x06010325 RID: 66341 RVA: 0x004846E4 File Offset: 0x00482AE4
		private IEnumerator _WaitToInitComMapSites()
		{
			if (this.mRandomTreasureMapSiteDic == null)
			{
				this.mRandomTreasureMapSiteDic = new Dictionary<int, ComRandomTreasureMapSite>();
			}
			else
			{
				this.mRandomTreasureMapSiteDic.Clear();
			}
			List<RandomTreasureMapModel> totalMapModelList = DataManager<RandomTreasureDataManager>.GetInstance().GetTotalMapModelList();
			if (totalMapModelList == null)
			{
				yield break;
			}
			for (int i = 0; i < totalMapModelList.Count; i++)
			{
				RandomTreasureMapModel mapModel = totalMapModelList[i];
				if (mapModel != null)
				{
					int mapId = mapModel.mapId;
					if (mapModel.localMapData != null)
					{
						string localRoutePath = mapModel.localMapData.MapRouteResPath;
						if (this.mThisGo)
						{
							ComRandomTreasureMapSite componetInChild = Utility.GetComponetInChild<ComRandomTreasureMapSite>(this.mThisGo, localRoutePath);
							if (componetInChild == null)
							{
								goto IL_199;
							}
							if (this.mRandomTreasureMapSiteDic.ContainsKey(mapId))
							{
								this.mRandomTreasureMapSiteDic[mapId] = componetInChild;
							}
							else
							{
								this.mRandomTreasureMapSiteDic.Add(mapId, componetInChild);
							}
							componetInChild.InitView();
						}
						yield return new WaitForEndOfFrame();
					}
				}
				IL_199:;
			}
			yield return null;
			yield break;
		}

		// Token: 0x06010326 RID: 66342 RVA: 0x00484700 File Offset: 0x00482B00
		private void SetMapBackground()
		{
			if (this.mData == null)
			{
				return;
			}
			DigMapTable localMapData = this.mData.localMapData;
			if (localMapData != null)
			{
				string mapResPath = localMapData.MapResPath;
				if (!string.IsNullOrEmpty(mapResPath))
				{
					ETCImageLoader.LoadSprite(ref this.mMapBgImg, mapResPath, true);
					if (this.mMapBgImg)
					{
						this.mMapBgImg.CustomActive(true);
					}
				}
				else if (this.mMapBgImg)
				{
					this.mMapBgImg.CustomActive(false);
				}
			}
		}

		// Token: 0x06010327 RID: 66343 RVA: 0x00484788 File Offset: 0x00482B88
		private void SetPlayerInfo()
		{
			if (this.mData == null)
			{
				return;
			}
			if (this.mPlayerInfo != null)
			{
				this.mPlayerInfo.SetInfoContent(string.Format(this.tr_map_player_num, this.mData.beInPlayerNum.ToString()));
			}
		}

		// Token: 0x06010328 RID: 66344 RVA: 0x004847E0 File Offset: 0x00482BE0
		private void SetTitleName()
		{
			if (this.mData == null)
			{
				return;
			}
			DigMapTable localMapData = this.mData.localMapData;
			if (localMapData != null && this.mName)
			{
				this.mName.text = localMapData.Name;
			}
		}

		// Token: 0x06010329 RID: 66345 RVA: 0x0048482C File Offset: 0x00482C2C
		private void SetAllMapRoutesInActive()
		{
			if (this.mRandomTreasureMapSiteDic == null)
			{
				Logger.LogError("[RandomTreasureMap] - SetAllMapRoutesInActive mRandomTreasureMapSiteDic is null");
				return;
			}
			foreach (KeyValuePair<int, ComRandomTreasureMapSite> keyValuePair in this.mRandomTreasureMapSiteDic)
			{
				ComRandomTreasureMapSite value = keyValuePair.Value;
				if (value != null)
				{
					value.CustomActive(false);
				}
			}
		}

		// Token: 0x0601032A RID: 66346 RVA: 0x00484890 File Offset: 0x00482C90
		public void Create(GameObject parent, RandomTreasureFrame frame)
		{
			this.mParentGo = parent;
			this.mRootFrame = frame;
			if (this.mThisGo == null)
			{
				this.mThisGo = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureMap", true, 0U);
			}
			if (this.mThisGo)
			{
				this.mBind = this.mThisGo.GetComponent<ComCommonBind>();
			}
			if (this.mBind != null)
			{
				this.mMapBgImg = this.mBind.GetCom<Image>("MapBgImg");
				this.mPlayerInfo = this.mBind.GetCom<RandomTreasureInfo>("PlayerInfo");
				this.mName = this.mBind.GetCom<Text>("Name");
			}
			Utility.AttachTo(this.mThisGo, this.mParentGo, false);
			if (this.mThisGo)
			{
				this.mThisGo.CustomActive(false);
			}
			this._InitFrame();
		}

		// Token: 0x0601032B RID: 66347 RVA: 0x0048497B File Offset: 0x00482D7B
		public void Destroy()
		{
			this._ClearData();
		}

		// Token: 0x0601032C RID: 66348 RVA: 0x00484984 File Offset: 0x00482D84
		public void ChangeCurrTreasureMapPlayerNum(RandomTreasureMapModel mapModel)
		{
			if (this.mData == null || mapModel == null)
			{
				return;
			}
			if (this.mData.mapId == mapModel.mapId)
			{
				this.mData.beInPlayerNum = mapModel.beInPlayerNum;
				this.SetPlayerInfo();
			}
		}

		// Token: 0x0601032D RID: 66349 RVA: 0x004849D0 File Offset: 0x00482DD0
		public void ResetCurrTreasureMapDig(RandomTreasureMapModel mapModel)
		{
			if (this.mData == null || mapModel == null)
			{
				return;
			}
			if (this.mData.mapId == mapModel.mapId)
			{
				this.RefreshData(mapModel);
			}
		}

		// Token: 0x0601032E RID: 66350 RVA: 0x00484A04 File Offset: 0x00482E04
		public void RefreshData(RandomTreasureMapModel mapModel)
		{
			if (mapModel == null)
			{
				Logger.LogError("[RandomTreasureMap] - RefreshData out data is null");
				return;
			}
			if (this.mRandomTreasureMapSiteDic == null)
			{
				Logger.LogError("[RandomTreasureMap] - RefreshData mRandomTreasureMapSiteDic is null");
				return;
			}
			this.mData = mapModel;
			this.SetAllMapRoutesInActive();
			if (this.mRandomTreasureMapSiteDic.ContainsKey(mapModel.mapId))
			{
				ComRandomTreasureMapSite comRandomTreasureMapSite = this.mRandomTreasureMapSiteDic[mapModel.mapId];
				if (comRandomTreasureMapSite != null)
				{
					comRandomTreasureMapSite.CustomActive(true);
					if (this.mRootFrame != null && !this.mRootFrame.BRefreshDigInfoDelay)
					{
						comRandomTreasureMapSite.RefreshMapSite(mapModel);
					}
					this.mCurrentMapSite = comRandomTreasureMapSite;
				}
			}
			this.SetMapBackground();
			this.SetPlayerInfo();
			this.SetTitleName();
		}

		// Token: 0x0601032F RID: 66351 RVA: 0x00484ABB File Offset: 0x00482EBB
		public void TryChangeTreasureMap(RandomTreasureMapModel mapModel)
		{
			if (mapModel == null)
			{
				return;
			}
			if (this.mData != null)
			{
				DataManager<RandomTreasureDataManager>.GetInstance().ReqCloseTreasureMap(this.mData);
			}
			if (mapModel != null)
			{
				DataManager<RandomTreasureDataManager>.GetInstance().ReqOpenTreasureMap(mapModel);
			}
		}

		// Token: 0x06010330 RID: 66352 RVA: 0x00484AF0 File Offset: 0x00482EF0
		public RandomTreasureMapModel GetCurrentMapModel()
		{
			return this.mData;
		}

		// Token: 0x06010331 RID: 66353 RVA: 0x00484AF8 File Offset: 0x00482EF8
		public void ChangedCurrTreasureDigSite(RandomTreasureMapDigSiteModel mapSiteModel)
		{
			if (this.mData == null || mapSiteModel == null)
			{
				return;
			}
			List<RandomTreasureMapDigSiteModel> mapTotalDigSites = this.mData.mapTotalDigSites;
			if (mapTotalDigSites == null)
			{
				Logger.LogError("[RandomTreasureMap] - _OnTreasureDigSiteChanged mData.mapTotalDigSites is null");
				return;
			}
			for (int i = 0; i < mapTotalDigSites.Count; i++)
			{
				if (mapTotalDigSites[i].mapId == mapSiteModel.mapId && mapTotalDigSites[i].index == mapSiteModel.index)
				{
					if (this.mCurrentMapSite != null)
					{
						if (this.mRootFrame != null && this.mRootFrame.BRefreshDigInfoDelay)
						{
							return;
						}
						this.mCurrentMapSite.RefreshMapSite(mapSiteModel);
					}
					break;
				}
			}
		}

		// Token: 0x06010332 RID: 66354 RVA: 0x00484BB8 File Offset: 0x00482FB8
		public void RefreshDigSiteView(RandomTreasureMapDigSiteModel digSiteModel)
		{
			if (digSiteModel == null)
			{
				Logger.LogError("[RandomTreasureMap] - RefreshDigSiteView out data is null");
				return;
			}
			if (this.mCurrentMapSite == null)
			{
				Logger.LogError("[RandomTreasureMap] - RefreshDigSiteView mCurrentMapSite is null");
				return;
			}
			if (this.mRootFrame != null && this.mRootFrame.BRefreshDigInfoDelay)
			{
				return;
			}
			this.mCurrentMapSite.RefreshMapSite(digSiteModel);
		}

		// Token: 0x06010333 RID: 66355 RVA: 0x00484C1C File Offset: 0x0048301C
		public void RefreshDigSiteView()
		{
			if (this.mData == null)
			{
				return;
			}
			if (this.mCurrentMapSite == null)
			{
				return;
			}
			if (this.mRootFrame != null && this.mRootFrame.BRefreshDigInfoDelay)
			{
				return;
			}
			this.mCurrentMapSite.RefreshMapSite(this.mData);
		}

		// Token: 0x06010334 RID: 66356 RVA: 0x00484C74 File Offset: 0x00483074
		public void Show()
		{
			if (this.mThisGo)
			{
				this.mThisGo.CustomActive(true);
			}
			this.bShowed = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureDigMapOpen, this.mData, null, null, null);
		}

		// Token: 0x06010335 RID: 66357 RVA: 0x00484CB1 File Offset: 0x004830B1
		public void Hide()
		{
			if (this.mThisGo)
			{
				this.mThisGo.CustomActive(false);
			}
			this.bShowed = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTreasureDigMapClose, this.mData, null, null, null);
		}

		// Token: 0x06010336 RID: 66358 RVA: 0x00484CEE File Offset: 0x004830EE
		public bool IsShowed()
		{
			return this.bShowed;
		}

		// Token: 0x0400A3C3 RID: 41923
		public const string MAP_FRAME_PATH = "UIFlatten/Prefabs/RandomTreasureFrame/RandomTreasureMap";

		// Token: 0x0400A3C4 RID: 41924
		private RandomTreasureMapModel mData;

		// Token: 0x0400A3C5 RID: 41925
		private RandomTreasureFrame mRootFrame;

		// Token: 0x0400A3C6 RID: 41926
		private string tr_map_player_num = "{0}人";

		// Token: 0x0400A3C7 RID: 41927
		private ComCommonBind mBind;

		// Token: 0x0400A3C8 RID: 41928
		private GameObject mParentGo;

		// Token: 0x0400A3C9 RID: 41929
		private GameObject mThisGo;

		// Token: 0x0400A3CA RID: 41930
		private bool bShowed;

		// Token: 0x0400A3CB RID: 41931
		private Image mMapBgImg;

		// Token: 0x0400A3CC RID: 41932
		private RandomTreasureInfo mPlayerInfo;

		// Token: 0x0400A3CD RID: 41933
		private Text mName;

		// Token: 0x0400A3CE RID: 41934
		private Dictionary<int, ComRandomTreasureMapSite> mRandomTreasureMapSiteDic = new Dictionary<int, ComRandomTreasureMapSite>();

		// Token: 0x0400A3CF RID: 41935
		private ComRandomTreasureMapSite mCurrentMapSite;

		// Token: 0x0400A3D0 RID: 41936
		private Coroutine waitToInitComMapSites;
	}
}
