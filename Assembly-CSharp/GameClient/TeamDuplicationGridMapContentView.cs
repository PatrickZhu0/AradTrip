using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C62 RID: 7266
	public class TeamDuplicationGridMapContentView : MonoBehaviour
	{
		// Token: 0x06011D84 RID: 73092 RVA: 0x005387EA File Offset: 0x00536BEA
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011D85 RID: 73093 RVA: 0x005387F2 File Offset: 0x00536BF2
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011D86 RID: 73094 RVA: 0x00538800 File Offset: 0x00536C00
		private void ClearData()
		{
			this._gridCreateProcessType = GridCreateProcessType.NoStart;
			this._resArrayLength = 0;
			this._totalGridNumber = 0;
			this._resPrefabArray = null;
			this._resDataArray = null;
			this._insDataArray = null;
			this._baseIndexX = 0;
			this._baseIndexY = 0;
			this._gridItemArray = null;
			this._gridItemDictionary.Clear();
			this._tempGridVisitDic.Clear();
			this._ownerCaptainStandGridId = 0U;
			this._ownerCaptainNearByGridIdList.Clear();
			this._ownerCaptainNearByGridItemList.Clear();
		}

		// Token: 0x06011D87 RID: 73095 RVA: 0x0053887F File Offset: 0x00536C7F
		private void BindUiEvents()
		{
		}

		// Token: 0x06011D88 RID: 73096 RVA: 0x00538881 File Offset: 0x00536C81
		private void UnBindUiEvents()
		{
		}

		// Token: 0x06011D89 RID: 73097 RVA: 0x00538884 File Offset: 0x00536C84
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridFieldNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridFieldNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationNearByGridUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMapCaptainMoveMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMapCaptainMoveMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterRemoveMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterRemoveMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridSquadBattleNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridSquadBattleNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011D8A RID: 73098 RVA: 0x005389A0 File Offset: 0x00536DA0
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridFieldNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridFieldNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationNearByGridUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMapCaptainMoveMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMapCaptainMoveMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterRemoveMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterRemoveMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridSquadBattleNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridSquadBattleNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011D8B RID: 73099 RVA: 0x00538ABB File Offset: 0x00536EBB
		public void InitContentView()
		{
			this._isCaptain = TeamDuplicationUtility.IsSelfPlayerIsCaptainInTeamDuplication();
			this.InitData();
		}

		// Token: 0x06011D8C RID: 73100 RVA: 0x00538AD0 File Offset: 0x00536ED0
		public void InitData()
		{
			if (this.gridRoot == null)
			{
				return;
			}
			string path = "Data/TileData/Res.asset";
			AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, typeof(TileRes), true, 0U);
			TileRes tileRes = null;
			if (assetInst != null)
			{
				tileRes = (assetInst.obj as TileRes);
			}
			if (tileRes == null)
			{
				return;
			}
			this._resDataArray = tileRes.ResDatas;
			if (this._resDataArray == null)
			{
				return;
			}
			this._resArrayLength = this._resDataArray.Length;
			if (this._resArrayLength <= 0)
			{
				return;
			}
			this._resPrefabArray = new GameObject[this._resArrayLength];
			string path2 = "Data/TileData/Map.asset";
			AssetInst assetInst2 = Singleton<AssetLoader>.instance.LoadRes(path2, typeof(TileMap), true, 0U);
			TileMap tileMap = null;
			if (assetInst2 != null)
			{
				tileMap = (assetInst2.obj as TileMap);
			}
			if (tileMap == null)
			{
				return;
			}
			this._insDataArray = tileMap.InsDatas;
			if (this._insDataArray == null)
			{
				return;
			}
			this._totalGridNumber = this._insDataArray.Length;
			if (this._totalGridNumber <= 0)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().SetGridInsDataDictionary(this._insDataArray);
			this.CreateGridCacheArray();
			this._gridCreateProcessType = GridCreateProcessType.Start;
			this._createGridIndex = 0;
			this._curCreateGridInterval = this.CreateGridInterval;
		}

		// Token: 0x06011D8D RID: 73101 RVA: 0x00538C1B File Offset: 0x0053701B
		private void Update()
		{
			this.UpdateCreateGridView();
		}

		// Token: 0x06011D8E RID: 73102 RVA: 0x00538C24 File Offset: 0x00537024
		private void UpdateCreateGridView()
		{
			if (this._gridCreateProcessType == GridCreateProcessType.NoStart || this._gridCreateProcessType == GridCreateProcessType.End)
			{
				return;
			}
			if (this._curCreateGridInterval > 0)
			{
				this._curCreateGridInterval--;
			}
			else
			{
				this._curCreateGridInterval = this.CreateGridInterval;
				if (this._createGridIndex >= this._totalGridNumber)
				{
					this._gridCreateProcessType = GridCreateProcessType.End;
					this.UpdateMapOtherView();
					return;
				}
				int createGridIndex = this._createGridIndex;
				int num = this._createGridIndex + this.CreateGridNumberPerTime;
				if (num >= this._totalGridNumber)
				{
					num = this._totalGridNumber;
				}
				for (int i = createGridIndex; i < num; i++)
				{
					TileInsData curInsData = this._insDataArray[i];
					this.CreateOneGridItem(curInsData);
				}
				this._createGridIndex = num;
			}
		}

		// Token: 0x06011D8F RID: 73103 RVA: 0x00538CE4 File Offset: 0x005370E4
		private void CreateOneGridItem(TileInsData curInsData)
		{
			if (curInsData == null)
			{
				return;
			}
			int id = curInsData.ID;
			int resID = curInsData.ResID;
			int num = resID - 1;
			if (num < 0 || num >= this._resArrayLength)
			{
				return;
			}
			TileResData tileResData = this._resDataArray[num];
			if (tileResData == null)
			{
				return;
			}
			GameObject gameObject = this.CreateGridPrefab(num, tileResData);
			if (gameObject == null)
			{
				return;
			}
			RectTransform component = gameObject.GetComponent<RectTransform>();
			if (component == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.gridRoot, false);
			TilePos position = curInsData.Position;
			Vector3 vector = TileMapConstant.TilePos2UIPos(position);
			component.localPosition = vector;
			TeamDuplicationGridMapGridItem component2 = gameObject.GetComponent<TeamDuplicationGridMapGridItem>();
			if (component2 == null)
			{
				return;
			}
			TeamDuplicationGridObjectDataModel gridObjectDataModel = null;
			if (tileResData.Type != ETeamTileType.None)
			{
				gridObjectDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridObjectDataModelByGridId((uint)id);
			}
			component2.Init(curInsData, tileResData, vector, gridObjectDataModel, new OnGridItemClick(this.OnGridItemClick));
			this._gridItemDictionary[(uint)id] = component2;
			int num2 = curInsData.Position.X - this._baseIndexX;
			int num3 = curInsData.Position.Y - this._baseIndexY;
			this._gridItemArray[num2, num3] = component2;
		}

		// Token: 0x06011D90 RID: 73104 RVA: 0x00538E18 File Offset: 0x00537218
		private GameObject CreateGridPrefab(int resIndex, TileResData tileResData)
		{
			GameObject gameObject = null;
			GameObject gameObject2 = this._resPrefabArray[resIndex];
			if (gameObject2 == null)
			{
				if (tileResData != null)
				{
					string prefabPath = tileResData.PrefabPath;
					if (!string.IsNullOrEmpty(prefabPath))
					{
						gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
						if (gameObject != null)
						{
							this._resPrefabArray[resIndex] = gameObject;
						}
					}
				}
			}
			else
			{
				gameObject = Object.Instantiate<GameObject>(gameObject2);
			}
			return gameObject;
		}

		// Token: 0x06011D91 RID: 73105 RVA: 0x00538E88 File Offset: 0x00537288
		private void CreateGridCacheArray()
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < this._totalGridNumber; i++)
			{
				TileInsData tileInsData = this._insDataArray[i];
				if (tileInsData != null)
				{
					if (!flag)
					{
						num = tileInsData.Position.X;
						num2 = tileInsData.Position.X;
						num3 = tileInsData.Position.Y;
						num4 = tileInsData.Position.Y;
						flag = true;
					}
					else
					{
						if (tileInsData.Position.X >= num2)
						{
							num2 = tileInsData.Position.X;
						}
						if (tileInsData.Position.X <= num)
						{
							num = tileInsData.Position.X;
						}
						if (tileInsData.Position.Y >= num4)
						{
							num4 = tileInsData.Position.Y;
						}
						if (tileInsData.Position.Y <= num3)
						{
							num3 = tileInsData.Position.Y;
						}
					}
				}
			}
			this._xNumber = num2 - num + 1;
			this._yNumber = num4 - num3 + 1;
			this._baseIndexX = num;
			this._baseIndexY = num3;
			this._gridItemArray = new TeamDuplicationGridMapGridItem[this._xNumber, this._yNumber];
		}

		// Token: 0x06011D92 RID: 73106 RVA: 0x00538FD0 File Offset: 0x005373D0
		private TilePos CovertLogicPosToArrayPosWithPos(TilePos localPos)
		{
			return new TilePos(0, 0)
			{
				X = localPos.X - this._baseIndexX,
				Y = localPos.Y - this._baseIndexY
			};
		}

		// Token: 0x06011D93 RID: 73107 RVA: 0x00539014 File Offset: 0x00537414
		private TeamDuplicationGridMapGridItem GetGridItemByLogicPos(TilePos tilePos)
		{
			if (this._gridItemArray == null)
			{
				return null;
			}
			TilePos tilePos2 = this.CovertLogicPosToArrayPosWithPos(tilePos);
			if (tilePos2.X < 0 || tilePos2.X >= this._xNumber)
			{
				return null;
			}
			if (tilePos2.Y < 0 || tilePos2.Y >= this._yNumber)
			{
				return null;
			}
			return this._gridItemArray[tilePos2.X, tilePos2.Y];
		}

		// Token: 0x06011D94 RID: 73108 RVA: 0x00539093 File Offset: 0x00537493
		private void UpdateMapOtherView()
		{
			this.UpdateCaptainView();
			this.InitGridMonsterView();
			this.UpdateGridBattleView();
		}

		// Token: 0x06011D95 RID: 73109 RVA: 0x005390A7 File Offset: 0x005374A7
		private void UpdateCaptainView()
		{
			this.UpdateOwnerCaptainView();
			this.UpdateOtherCaptainView();
		}

		// Token: 0x06011D96 RID: 73110 RVA: 0x005390B8 File Offset: 0x005374B8
		private void UpdateOwnerCaptainView()
		{
			if (this.captainControl == null)
			{
				return;
			}
			TeamDuplicationGridOwnerCaptainDataModel ownerGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OwnerGridCaptainDataModel;
			TeamDuplicationGridOwnerCaptainPosition gridOwnerCaptainPosition = TeamDuplicationUtility.CreateGridOwnerCaptainPosition(ownerGridCaptainDataModel, this._gridItemDictionary);
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = null;
			if (ownerGridCaptainDataModel != null)
			{
				uint gridId = ownerGridCaptainDataModel.GridId;
				if (this._gridItemDictionary != null && this._gridItemDictionary.ContainsKey(gridId))
				{
					teamDuplicationGridMapGridItem = this._gridItemDictionary[gridId];
				}
			}
			this.captainControl.UpdateOwnerCaptainItem(ownerGridCaptainDataModel, gridOwnerCaptainPosition, teamDuplicationGridMapGridItem);
			if (teamDuplicationGridMapGridItem != null && teamDuplicationGridMapGridItem.GetTileInsId() != this._ownerCaptainStandGridId)
			{
				this.SetOwnerCaptainNearByGridView(teamDuplicationGridMapGridItem);
				this._ownerCaptainStandGridId = teamDuplicationGridMapGridItem.GetTileInsId();
			}
		}

		// Token: 0x06011D97 RID: 73111 RVA: 0x00539168 File Offset: 0x00537568
		private void SetOwnerCaptainNearByGridView(TeamDuplicationGridMapGridItem standGridItem)
		{
			this._ownerCaptainNearByGridIdList.Clear();
			this._ownerCaptainNearByGridItemList.Clear();
			if (!this._isCaptain)
			{
				int adjacentGridNumber = TeamDuplicationUtility.GetAdjacentGridNumber();
				this.ResetOwnerCaptainNearByGridData(adjacentGridNumber);
				this.captainControl.UpdateOwnerCaptainNearByGridItemList(this._ownerCaptainNearByGridItemList);
			}
			else
			{
				TilePos tileInsTilePos = standGridItem.GetTileInsTilePos();
				this.UpdateOwnerCaptainNearByGridData(tileInsTilePos);
				this.captainControl.UpdateOwnerCaptainNearByGridItemList(this._ownerCaptainNearByGridItemList);
			}
		}

		// Token: 0x06011D98 RID: 73112 RVA: 0x005391D8 File Offset: 0x005375D8
		private void ResetOwnerCaptainNearByGridData(int number)
		{
			for (int i = 0; i < number; i++)
			{
				this._ownerCaptainNearByGridIdList.Add(0U);
				this._ownerCaptainNearByGridItemList.Add(null);
			}
		}

		// Token: 0x06011D99 RID: 73113 RVA: 0x00539210 File Offset: 0x00537610
		private void UpdateOwnerCaptainNearByGridData(TilePos standTilePos)
		{
			List<TilePos> adjacentTilePosList = TeamDuplicationUtility.GetAdjacentTilePosList(standTilePos);
			if (adjacentTilePosList != null && adjacentTilePosList.Count > 0)
			{
				int count = adjacentTilePosList.Count;
				this.ResetOwnerCaptainNearByGridData(count);
				for (int i = 0; i < count; i++)
				{
					TilePos tilePos = adjacentTilePosList[i];
					TeamDuplicationGridMapGridItem gridItemByLogicPos = this.GetGridItemByLogicPos(tilePos);
					if (!(gridItemByLogicPos == null))
					{
						uint tileInsId = gridItemByLogicPos.GetTileInsId();
						if (tileInsId != 0U)
						{
							this._ownerCaptainNearByGridIdList[i] = tileInsId;
							if (this.IsNearByGridCanStand(gridItemByLogicPos, tileInsId))
							{
								this._ownerCaptainNearByGridItemList[i] = gridItemByLogicPos;
							}
						}
					}
				}
			}
		}

		// Token: 0x06011D9A RID: 73114 RVA: 0x005392C4 File Offset: 0x005376C4
		private void OnNearByGridUpdate(uint nearByGridId)
		{
			if (this._ownerCaptainNearByGridIdList == null || this._ownerCaptainNearByGridIdList.Count <= 0)
			{
				return;
			}
			if (this._gridItemDictionary == null || this._gridItemDictionary.Count <= 0)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			for (int i = 0; i < this._ownerCaptainNearByGridIdList.Count; i++)
			{
				uint num2 = this._ownerCaptainNearByGridIdList[i];
				if (nearByGridId == num2)
				{
					num = i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			if (!this._gridItemDictionary.ContainsKey(nearByGridId))
			{
				return;
			}
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = this._gridItemDictionary[nearByGridId];
			if (teamDuplicationGridMapGridItem == null)
			{
				return;
			}
			bool flag2 = this.IsNearByGridCanStand(teamDuplicationGridMapGridItem, nearByGridId);
			if (this._ownerCaptainNearByGridItemList != null && this._ownerCaptainNearByGridItemList.Count > 0 && num < this._ownerCaptainNearByGridItemList.Count)
			{
				if (flag2)
				{
					this._ownerCaptainNearByGridItemList[num] = teamDuplicationGridMapGridItem;
				}
				else
				{
					this._ownerCaptainNearByGridItemList[num] = null;
				}
			}
			if (this.captainControl != null)
			{
				this.captainControl.UpdateOwnerCaptainNearByOneGridItem(teamDuplicationGridMapGridItem, num, flag2);
			}
		}

		// Token: 0x06011D9B RID: 73115 RVA: 0x00539400 File Offset: 0x00537800
		private bool IsNearByGridCanStand(TeamDuplicationGridMapGridItem gridItem, uint gridId)
		{
			return TeamDuplicationUtility.IsNearByGridCanStand(gridItem, gridId) && (!(this.monsterControl != null) || !this.monsterControl.IsGridBeStandByMonsterNextEffect(gridId));
		}

		// Token: 0x06011D9C RID: 73116 RVA: 0x00539444 File Offset: 0x00537844
		private void UpdateOtherCaptainView()
		{
			if (this.captainControl == null)
			{
				return;
			}
			TeamDuplicationGridOtherCaptainDataModel otherGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OtherGridCaptainDataModel;
			TeamDuplicationGridPathPosition gridPathPosition = TeamDuplicationUtility.CreateGridOtherCaptainPosition(otherGridCaptainDataModel, this._gridItemDictionary);
			this.captainControl.UpdateOtherCaptainItem(otherGridCaptainDataModel, gridPathPosition);
		}

		// Token: 0x06011D9D RID: 73117 RVA: 0x00539488 File Offset: 0x00537888
		private void UpdateGridBattleView()
		{
			if (this.battleControl == null)
			{
				return;
			}
			this.UpdateCaptainGridBattleView(1U);
			this.UpdateCaptainGridBattleView(2U);
		}

		// Token: 0x06011D9E RID: 73118 RVA: 0x005394AC File Offset: 0x005378AC
		private void UpdateCaptainGridBattleView(uint captainId)
		{
			TeamDuplicationGridBattleDataModel gridBattleDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().CaptainOneBattleDataModel;
			if (captainId == 2U)
			{
				gridBattleDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().CaptainTwoBattleDataModel;
			}
			TeamDuplicationGridPathPosition gridPathPosition = TeamDuplicationUtility.CreateGridBattlePosition(gridBattleDataModel, this._gridItemDictionary);
			this.battleControl.UpdateBattleControl(gridBattleDataModel, gridPathPosition, captainId);
		}

		// Token: 0x06011D9F RID: 73119 RVA: 0x005394F4 File Offset: 0x005378F4
		private void InitGridMonsterView()
		{
			List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GridMonsterDataModelList;
			this.UpdateGridMonsterView(gridMonsterDataModelList);
		}

		// Token: 0x06011DA0 RID: 73120 RVA: 0x00539514 File Offset: 0x00537914
		private void UpdateGridMonsterView(List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList)
		{
			if (this.monsterControl == null)
			{
				return;
			}
			Dictionary<uint, TeamDuplicationGridMapGridItem> monsterGridItemDictionary = TeamDuplicationUtility.CreateGridItemDictionary(gridMonsterDataModelList, this._gridItemDictionary);
			Dictionary<uint, TeamDuplicationGridMapGridItem> monsterNextGridItemDictionary = TeamDuplicationUtility.CreateNextGridItemDictionary(gridMonsterDataModelList, this._gridItemDictionary);
			this.monsterControl.UpdateGridMonsterControl(gridMonsterDataModelList, monsterGridItemDictionary, monsterNextGridItemDictionary);
		}

		// Token: 0x06011DA1 RID: 73121 RVA: 0x0053955B File Offset: 0x0053795B
		private void RemoveGridMonsterByMonsterId(uint monsterId)
		{
			if (this.monsterControl == null)
			{
				return;
			}
			this.monsterControl.RemoveGridMonsterByMonsterId(monsterId);
		}

		// Token: 0x06011DA2 RID: 73122 RVA: 0x0053957C File Offset: 0x0053797C
		private void OnReceiveTeamDuplicationGridFieldNotifyMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			TeamDuplicationGridUpdateDataModel teamDuplicationGridUpdateDataModel = uiEvent.Param1 as TeamDuplicationGridUpdateDataModel;
			if (teamDuplicationGridUpdateDataModel == null)
			{
				return;
			}
			List<uint> gridUpdateList = teamDuplicationGridUpdateDataModel.GridUpdateList;
			if (gridUpdateList == null || gridUpdateList.Count <= 0)
			{
				return;
			}
			if (this._gridItemDictionary == null)
			{
				return;
			}
			for (int i = 0; i < gridUpdateList.Count; i++)
			{
				uint num = gridUpdateList[i];
				if (this._gridItemDictionary.ContainsKey(num))
				{
					TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = this._gridItemDictionary[num];
					if (!(teamDuplicationGridMapGridItem == null))
					{
						TeamDuplicationGridObjectDataModel gridObjectDataModelByGridId = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridObjectDataModelByGridId(num);
						teamDuplicationGridMapGridItem.UpdateGrid(gridObjectDataModelByGridId);
					}
				}
			}
		}

		// Token: 0x06011DA3 RID: 73123 RVA: 0x0053963F File Offset: 0x00537A3F
		private void OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			this.UpdateOwnerCaptainView();
		}

		// Token: 0x06011DA4 RID: 73124 RVA: 0x00539654 File Offset: 0x00537A54
		private void OnReceiveTeamDuplicationGridMapCaptainMoveMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			this.UpdateOwnerCaptainView();
		}

		// Token: 0x06011DA5 RID: 73125 RVA: 0x0053966C File Offset: 0x00537A6C
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				this._isCaptain = TeamDuplicationUtility.IsSelfPlayerIsCaptainInTeamDuplication();
				return;
			}
			bool flag = TeamDuplicationUtility.IsSelfPlayerIsCaptainInTeamDuplication();
			if (this._isCaptain == flag)
			{
				return;
			}
			this._isCaptain = flag;
			TeamDuplicationGridOwnerCaptainDataModel ownerGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OwnerGridCaptainDataModel;
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = null;
			if (ownerGridCaptainDataModel != null)
			{
				uint gridId = ownerGridCaptainDataModel.GridId;
				if (this._gridItemDictionary != null && this._gridItemDictionary.ContainsKey(gridId))
				{
					teamDuplicationGridMapGridItem = this._gridItemDictionary[gridId];
				}
			}
			if (teamDuplicationGridMapGridItem != null)
			{
				this.SetOwnerCaptainNearByGridView(teamDuplicationGridMapGridItem);
			}
		}

		// Token: 0x06011DA6 RID: 73126 RVA: 0x00539704 File Offset: 0x00537B04
		private void OnReceiveTeamDuplicationNearByGridUpdateMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 != null)
			{
				uint nearByGridId = (uint)uiEvent.Param1;
				this.OnNearByGridUpdate(nearByGridId);
			}
			if (uiEvent.Param2 != null)
			{
				uint nearByGridId2 = (uint)uiEvent.Param2;
				this.OnNearByGridUpdate(nearByGridId2);
			}
			TeamDuplicationGridUpdateDataModel teamDuplicationGridUpdateDataModel = uiEvent.Param3 as TeamDuplicationGridUpdateDataModel;
			if (teamDuplicationGridUpdateDataModel != null && teamDuplicationGridUpdateDataModel.GridUpdateList.Count > 0)
			{
				for (int i = 0; i < teamDuplicationGridUpdateDataModel.GridUpdateList.Count; i++)
				{
					uint nearByGridId3 = teamDuplicationGridUpdateDataModel.GridUpdateList[i];
					this.OnNearByGridUpdate(nearByGridId3);
				}
			}
		}

		// Token: 0x06011DA7 RID: 73127 RVA: 0x005397B8 File Offset: 0x00537BB8
		private void OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			uint nearByGridId = (uint)uiEvent.Param1;
			this.OnNearByGridUpdate(nearByGridId);
		}

		// Token: 0x06011DA8 RID: 73128 RVA: 0x005397F8 File Offset: 0x00537BF8
		private void OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			this.UpdateOtherCaptainView();
		}

		// Token: 0x06011DA9 RID: 73129 RVA: 0x00539810 File Offset: 0x00537C10
		private void OnReceiveTeamDuplicationGridSquadBattleNotifyMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint captainId = (uint)uiEvent.Param1;
			this.UpdateCaptainGridBattleView(captainId);
		}

		// Token: 0x06011DAA RID: 73130 RVA: 0x00539850 File Offset: 0x00537C50
		private void OnReceiveTeamDuplicationGridMonsterNotifyMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			TeamDuplicationGridMonsterUpdateDataModel teamDuplicationGridMonsterUpdateDataModel = uiEvent.Param1 as TeamDuplicationGridMonsterUpdateDataModel;
			if (teamDuplicationGridMonsterUpdateDataModel == null)
			{
				return;
			}
			List<TeamDuplicationGridObjectDataModel> monsterUpdateDataModelList = teamDuplicationGridMonsterUpdateDataModel.MonsterUpdateDataModelList;
			if (monsterUpdateDataModelList == null || monsterUpdateDataModelList.Count <= 0)
			{
				return;
			}
			this.UpdateGridMonsterView(monsterUpdateDataModelList);
		}

		// Token: 0x06011DAB RID: 73131 RVA: 0x005398B0 File Offset: 0x00537CB0
		private void OnReceiveTeamDuplicationGridMonsterRemoveMessage(UIEvent uiEvent)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint monsterId = (uint)uiEvent.Param1;
			this.RemoveGridMonsterByMonsterId(monsterId);
		}

		// Token: 0x06011DAC RID: 73132 RVA: 0x005398F0 File Offset: 0x00537CF0
		private void OnGridItemClick(TileInsData tileInsData, TileResData tileResData)
		{
			if (this._gridCreateProcessType != GridCreateProcessType.End)
			{
				return;
			}
			uint id = (uint)tileInsData.ID;
			TilePos position = tileInsData.Position;
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = null;
			if (this._gridItemDictionary.ContainsKey(id))
			{
				teamDuplicationGridMapGridItem = this._gridItemDictionary[id];
			}
			if (teamDuplicationGridMapGridItem == null)
			{
				return;
			}
			uint gridObjectId = teamDuplicationGridMapGridItem.GetGridObjectId();
			bool flag = TeamDuplicationUtility.IsSelfPlayerIsCaptainInTeamDuplication();
			uint num = 0U;
			bool flag2 = TeamDuplicationUtility.IsGridItemBeStandByMonster(id, ref num);
			bool flag3 = teamDuplicationGridMapGridItem.IsGridItemCanStand();
			TeamDuplicationGridStandType teamDuplicationGridStandType = TeamDuplicationGridStandType.NormalType;
			if (flag3)
			{
				if (flag2)
				{
					teamDuplicationGridStandType = TeamDuplicationGridStandType.NormalTypeWithStandMonster;
				}
			}
			else
			{
				teamDuplicationGridStandType = TeamDuplicationGridStandType.GridType;
			}
			if (!flag)
			{
				if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalType)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Team_Duplication_Grid_Not_Move_By_UnLeader"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalTypeWithStandMonster)
				{
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, 0U, num, false);
				}
				else
				{
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, gridObjectId, 0U, false);
				}
				return;
			}
			TeamDuplicationGridOwnerCaptainDataModel ownerGridCaptainDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OwnerGridCaptainDataModel;
			if (ownerGridCaptainDataModel == null)
			{
				return;
			}
			uint gridId = ownerGridCaptainDataModel.GridId;
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem2 = null;
			if (this._gridItemDictionary.ContainsKey(gridId))
			{
				teamDuplicationGridMapGridItem2 = this._gridItemDictionary[gridId];
			}
			if (teamDuplicationGridMapGridItem2 == null)
			{
				return;
			}
			TilePos tileInsTilePos = teamDuplicationGridMapGridItem2.GetTileInsTilePos();
			if (id == gridId)
			{
				return;
			}
			TCGridSquadStatus captainStatus = (TCGridSquadStatus)ownerGridCaptainDataModel.CaptainStatus;
			if (captainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_BATTLE)
			{
				if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalType)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Team_Duplication_Grid_Map_Not_Move_In_Battle_Status"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalTypeWithStandMonster)
				{
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, 0U, num, false);
				}
				else
				{
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, gridObjectId, 0U, false);
				}
				return;
			}
			if (captainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_MOVE)
			{
				if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalType)
				{
					DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyGridMoveReq(0U, 0U);
				}
				else if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalTypeWithStandMonster)
				{
					bool flag4 = this.IsExistOnePathBetweenTwoGrid(gridId, id);
					bool flag5 = num == ownerGridCaptainDataModel.TargetMonsterId;
					TeamDuplicationGridItemTipStatusType tipStatusType = TeamDuplicationGridItemTipStatusType.DisableType;
					if (flag4)
					{
						if (flag5)
						{
							tipStatusType = TeamDuplicationGridItemTipStatusType.CancelMoveType;
						}
						else
						{
							tipStatusType = TeamDuplicationGridItemTipStatusType.DoMoveType;
						}
					}
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(tipStatusType, tileInsData, tileResData, 0U, num, false);
				}
				else
				{
					bool flag6 = this.IsExistOnePathBetweenTwoGrid(gridId, id);
					bool flag7 = id == ownerGridCaptainDataModel.TargetGridId;
					TeamDuplicationGridItemTipStatusType tipStatusType2 = TeamDuplicationGridItemTipStatusType.DisableType;
					if (flag6)
					{
						if (flag7)
						{
							tipStatusType2 = TeamDuplicationGridItemTipStatusType.CancelMoveType;
						}
						else
						{
							tipStatusType2 = TeamDuplicationGridItemTipStatusType.DoMoveType;
						}
					}
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(tipStatusType2, tileInsData, tileResData, gridObjectId, 0U, false);
				}
				return;
			}
			bool flag8 = TeamDuplicationUtility.IsGridItemBeStandByOtherCaptain(id);
			if (flag8)
			{
				string msgContent = TR.Value("Team_Duplication_Grid_Is_Stand_By_Other_Captain");
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (captainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_NORMAL)
			{
				bool flag9 = ownerGridCaptainDataModel.IsInCdStatusWithOutMove();
				if (flag9)
				{
					bool flag10 = TeamDuplicationUtility.IsTwoGridPositionAdjacent(position, tileInsTilePos);
					if (flag10)
					{
						if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalType)
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Team_Duplication_Grid_Map_Not_Move_In_Cd_Time"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
						else if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalTypeWithStandMonster)
						{
							TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, 0U, num, true);
						}
						else
						{
							TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(TeamDuplicationGridItemTipStatusType.DisableType, tileInsData, tileResData, gridObjectId, 0U, true);
						}
						return;
					}
				}
				bool flag11 = this.IsExistOnePathBetweenTwoGrid(gridId, id);
				if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalType)
				{
					if (!flag11)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Team_Duplication_Grid_Map_Not_Reach"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyGridMoveReq(id, 0U);
					}
				}
				else if (teamDuplicationGridStandType == TeamDuplicationGridStandType.NormalTypeWithStandMonster)
				{
					TeamDuplicationGridItemTipStatusType tipStatusType3 = TeamDuplicationGridItemTipStatusType.DisableType;
					if (flag11)
					{
						tipStatusType3 = TeamDuplicationGridItemTipStatusType.DoMoveType;
					}
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(tipStatusType3, tileInsData, tileResData, 0U, num, false);
				}
				else
				{
					TeamDuplicationGridItemTipStatusType tipStatusType4 = TeamDuplicationGridItemTipStatusType.DisableType;
					if (flag11)
					{
						tipStatusType4 = TeamDuplicationGridItemTipStatusType.DoMoveType;
					}
					TeamDuplicationUtility.ShowTeamDuplicationGridItemTipFrame(tipStatusType4, tileInsData, tileResData, gridObjectId, 0U, false);
				}
				return;
			}
		}

		// Token: 0x06011DAD RID: 73133 RVA: 0x00539C3F File Offset: 0x0053803F
		private bool IsExistOnePathBetweenTwoGrid(uint srcGridId, uint destGridId)
		{
			this._tempGridVisitDic.Clear();
			return this.IsExistOnePathBetweenTwoGridByDfs(srcGridId, destGridId);
		}

		// Token: 0x06011DAE RID: 73134 RVA: 0x00539C54 File Offset: 0x00538054
		private bool IsExistOnePathBetweenTwoGridByDfs(uint srcGridId, uint destGridId)
		{
			this._tempGridVisitDic[srcGridId] = true;
			if (srcGridId == destGridId)
			{
				return true;
			}
			if (!this._gridItemDictionary.ContainsKey(srcGridId))
			{
				return false;
			}
			TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = this._gridItemDictionary[srcGridId];
			if (teamDuplicationGridMapGridItem == null)
			{
				return false;
			}
			if (!teamDuplicationGridMapGridItem.IsGridItemCanStand())
			{
				return false;
			}
			TilePos tileInsTilePos = teamDuplicationGridMapGridItem.GetTileInsTilePos();
			List<TilePos> adjacentTilePosList = TeamDuplicationUtility.GetAdjacentTilePosList(tileInsTilePos);
			for (int i = 0; i < adjacentTilePosList.Count; i++)
			{
				TilePos tilePos = adjacentTilePosList[i];
				TeamDuplicationGridMapGridItem gridItemByLogicPos = this.GetGridItemByLogicPos(tilePos);
				if (!(gridItemByLogicPos == null))
				{
					uint tileInsId = gridItemByLogicPos.GetTileInsId();
					if (tileInsId != 0U)
					{
						if (!this._tempGridVisitDic.ContainsKey(tileInsId))
						{
							bool flag = this.IsExistOnePathBetweenTwoGridByDfs(tileInsId, destGridId);
							if (flag)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0400B9DA RID: 47578
		private bool _isCaptain;

		// Token: 0x0400B9DB RID: 47579
		private GridCreateProcessType _gridCreateProcessType;

		// Token: 0x0400B9DC RID: 47580
		private int _curCreateGridInterval;

		// Token: 0x0400B9DD RID: 47581
		private int _createGridIndex;

		// Token: 0x0400B9DE RID: 47582
		private int _baseIndexX;

		// Token: 0x0400B9DF RID: 47583
		private int _baseIndexY;

		// Token: 0x0400B9E0 RID: 47584
		private int _xNumber;

		// Token: 0x0400B9E1 RID: 47585
		private int _yNumber;

		// Token: 0x0400B9E2 RID: 47586
		private TeamDuplicationGridMapGridItem[,] _gridItemArray;

		// Token: 0x0400B9E3 RID: 47587
		private Dictionary<uint, TeamDuplicationGridMapGridItem> _gridItemDictionary = new Dictionary<uint, TeamDuplicationGridMapGridItem>();

		// Token: 0x0400B9E4 RID: 47588
		private int _resArrayLength;

		// Token: 0x0400B9E5 RID: 47589
		private TileResData[] _resDataArray;

		// Token: 0x0400B9E6 RID: 47590
		private GameObject[] _resPrefabArray;

		// Token: 0x0400B9E7 RID: 47591
		private int _totalGridNumber;

		// Token: 0x0400B9E8 RID: 47592
		private TileInsData[] _insDataArray;

		// Token: 0x0400B9E9 RID: 47593
		private Dictionary<uint, bool> _tempGridVisitDic = new Dictionary<uint, bool>();

		// Token: 0x0400B9EA RID: 47594
		private uint _ownerCaptainStandGridId;

		// Token: 0x0400B9EB RID: 47595
		private List<uint> _ownerCaptainNearByGridIdList = new List<uint>();

		// Token: 0x0400B9EC RID: 47596
		private List<TeamDuplicationGridMapGridItem> _ownerCaptainNearByGridItemList = new List<TeamDuplicationGridMapGridItem>();

		// Token: 0x0400B9ED RID: 47597
		[Space(10f)]
		[Header("GridRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject gridRoot;

		// Token: 0x0400B9EE RID: 47598
		[SerializeField]
		private int CreateGridInterval = 1;

		// Token: 0x0400B9EF RID: 47599
		[SerializeField]
		private int CreateGridNumberPerTime = 30;

		// Token: 0x0400B9F0 RID: 47600
		[Space(10f)]
		[Header("CaptainControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapCaptainControl captainControl;

		// Token: 0x0400B9F1 RID: 47601
		[Space(10f)]
		[Header("MonsterControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapMonsterControl monsterControl;

		// Token: 0x0400B9F2 RID: 47602
		[Space(10f)]
		[Header("BattleControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapBattleControl battleControl;
	}
}
