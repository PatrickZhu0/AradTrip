using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C63 RID: 7267
	public class TeamDuplicationGridMapMonsterControl : MonoBehaviour
	{
		// Token: 0x06011DB0 RID: 73136 RVA: 0x00539D50 File Offset: 0x00538150
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011DB1 RID: 73137 RVA: 0x00539D58 File Offset: 0x00538158
		private void ClearData()
		{
			this._gridMonsterItemTemplate = null;
			if (this._gridMonsterItemDictionary != null)
			{
				this._gridMonsterItemDictionary.Clear();
			}
		}

		// Token: 0x06011DB2 RID: 73138 RVA: 0x00539D78 File Offset: 0x00538178
		public void UpdateGridMonsterControl(List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList, Dictionary<uint, TeamDuplicationGridMapGridItem> monsterGridItemDictionary, Dictionary<uint, TeamDuplicationGridMapGridItem> monsterNextGridItemDictionary)
		{
			if (this.monsterItemRoot == null)
			{
				return;
			}
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return;
			}
			if (monsterGridItemDictionary == null || monsterGridItemDictionary.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					uint gridObjectId = teamDuplicationGridObjectDataModel.GridObjectId;
					uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(teamDuplicationGridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_MONSTER_PRO_ID);
					TeamDuplicationGridMapMonsterItem teamDuplicationGridMapMonsterItem = null;
					if (this._gridMonsterItemDictionary.ContainsKey(gridObjectId))
					{
						teamDuplicationGridMapMonsterItem = this._gridMonsterItemDictionary[gridObjectId];
					}
					else
					{
						TeamDuplicationGridMapMonsterItem teamDuplicationGridMapMonsterItem2 = null;
						if (this._gridMonsterItemTemplate == null)
						{
							this._gridMonsterItemTemplate = CommonUtility.LoadGameObjectWithType<TeamDuplicationGridMapMonsterItem>(this.monsterItemRoot);
							if (this._gridMonsterItemTemplate != null)
							{
								CommonUtility.UpdateGameObjectVisible(this._gridMonsterItemTemplate.gameObject, false);
							}
						}
						if (this._gridMonsterItemTemplate != null)
						{
							GameObject gameObject = Object.Instantiate<GameObject>(this._gridMonsterItemTemplate.gameObject);
							if (gameObject != null)
							{
								gameObject.transform.SetParent(this.monsterItemRoot.transform, false);
								teamDuplicationGridMapMonsterItem2 = gameObject.GetComponent<TeamDuplicationGridMapMonsterItem>();
							}
						}
						if (teamDuplicationGridMapMonsterItem2 != null)
						{
							this._gridMonsterItemDictionary[gridObjectId] = teamDuplicationGridMapMonsterItem2;
							teamDuplicationGridMapMonsterItem = teamDuplicationGridMapMonsterItem2;
						}
					}
					if (!(teamDuplicationGridMapMonsterItem == null))
					{
						TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = null;
						if (monsterGridItemDictionary.ContainsKey(gridObjectId))
						{
							teamDuplicationGridMapGridItem = monsterGridItemDictionary[gridObjectId];
						}
						if (!(teamDuplicationGridMapGridItem == null))
						{
							TeamDuplicationGridMapGridItem nextEffectGridItem = null;
							if (monsterNextGridItemDictionary != null && monsterNextGridItemDictionary.ContainsKey(gridObjectId))
							{
								nextEffectGridItem = monsterNextGridItemDictionary[gridObjectId];
							}
							CommonUtility.UpdateGameObjectVisible(teamDuplicationGridMapMonsterItem.gameObject, true);
							teamDuplicationGridMapMonsterItem.UpdateGridMonster(teamDuplicationGridObjectDataModel, teamDuplicationGridMapGridItem, nextEffectGridItem, 0U);
						}
					}
				}
			}
		}

		// Token: 0x06011DB3 RID: 73139 RVA: 0x00539F48 File Offset: 0x00538348
		public void RemoveGridMonsterByMonsterId(uint monsterId)
		{
			if (this._gridMonsterItemDictionary == null || this._gridMonsterItemDictionary.Count <= 0)
			{
				return;
			}
			if (!this._gridMonsterItemDictionary.ContainsKey(monsterId))
			{
				return;
			}
			TeamDuplicationGridMapMonsterItem teamDuplicationGridMapMonsterItem = this._gridMonsterItemDictionary[monsterId];
			if (teamDuplicationGridMapMonsterItem == null)
			{
				return;
			}
			if (teamDuplicationGridMapMonsterItem.GetIsShowNextEffectFlag())
			{
				uint nextEffectGridId = teamDuplicationGridMapMonsterItem.GetNextEffectGridId();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage, nextEffectGridId, null, null, null);
			}
			teamDuplicationGridMapMonsterItem.ResetMonsterItem();
			CommonUtility.UpdateGameObjectVisible(teamDuplicationGridMapMonsterItem.gameObject, false);
		}

		// Token: 0x06011DB4 RID: 73140 RVA: 0x00539FDC File Offset: 0x005383DC
		public bool IsGridBeStandByMonsterNextEffect(uint gridId)
		{
			if (this._gridMonsterItemDictionary == null || this._gridMonsterItemDictionary.Count <= 0)
			{
				return false;
			}
			List<TeamDuplicationGridObjectDataModel> gridMonsterDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GridMonsterDataModelList;
			if (gridMonsterDataModelList == null || gridMonsterDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < gridMonsterDataModelList.Count; i++)
			{
				TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = gridMonsterDataModelList[i];
				if (teamDuplicationGridObjectDataModel != null)
				{
					uint gridObjectId = teamDuplicationGridObjectDataModel.GridObjectId;
					TeamDuplicationGridMapMonsterItem teamDuplicationGridMapMonsterItem = null;
					if (this._gridMonsterItemDictionary.ContainsKey(gridObjectId))
					{
						teamDuplicationGridMapMonsterItem = this._gridMonsterItemDictionary[gridObjectId];
					}
					if (!(teamDuplicationGridMapMonsterItem == null))
					{
						if (teamDuplicationGridMapMonsterItem.GetNextEffectGridId() == gridId)
						{
							if (teamDuplicationGridMapMonsterItem.GetIsShowNextEffectFlag())
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0400B9F3 RID: 47603
		private Dictionary<uint, TeamDuplicationGridMapMonsterItem> _gridMonsterItemDictionary = new Dictionary<uint, TeamDuplicationGridMapMonsterItem>();

		// Token: 0x0400B9F4 RID: 47604
		private TeamDuplicationGridMapMonsterItem _gridMonsterItemTemplate;

		// Token: 0x0400B9F5 RID: 47605
		[Space(10f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject monsterItemRoot;
	}
}
