using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C7D RID: 7293
	public class TeamDuplicationGridMapMonsterItem : MonoBehaviour
	{
		// Token: 0x06011E3B RID: 73275 RVA: 0x0053BF31 File Offset: 0x0053A331
		private void OnDestroy()
		{
			this.ClearData();
			this._nextEffectPrefab = null;
		}

		// Token: 0x06011E3C RID: 73276 RVA: 0x0053BF40 File Offset: 0x0053A340
		private void ClearData()
		{
			this._gridMonsterDataModel = null;
			this._nextEffectGridItem = null;
			this._nextEffectGridId = 0U;
			this._isShowNextGridEffect = false;
			this._monsterStandGridId = 0U;
		}

		// Token: 0x06011E3D RID: 73277 RVA: 0x0053BF65 File Offset: 0x0053A365
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage));
		}

		// Token: 0x06011E3E RID: 73278 RVA: 0x0053BF82 File Offset: 0x0053A382
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage));
		}

		// Token: 0x06011E3F RID: 73279 RVA: 0x0053BFA0 File Offset: 0x0053A3A0
		public void UpdateGridMonster(TeamDuplicationGridObjectDataModel gridMonsterDataModel, TeamDuplicationGridMapGridItem monsterStandGridItem, TeamDuplicationGridMapGridItem nextEffectGridItem = null, uint nextEffectGridId = 0U)
		{
			uint gridId = gridMonsterDataModel.GridId;
			if (this._monsterStandGridId != gridId)
			{
				this.ResetNextEffectGridItem();
			}
			this._gridMonsterDataModel = gridMonsterDataModel;
			this._monsterStandGridId = gridId;
			this._nextEffectGridItem = nextEffectGridItem;
			this._nextEffectGridId = 0U;
			if (this._nextEffectGridItem != null)
			{
				this._nextEffectGridId = this._nextEffectGridItem.GetTileInsId();
			}
			if (this.monsterItemRtf != null)
			{
				Vector3 gridPointPosition = monsterStandGridItem.GetGridPointPosition();
				this.monsterItemRtf.localPosition = gridPointPosition;
			}
			if (this.gridItemProgressBarControl != null)
			{
				uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(this._gridMonsterDataModel, TCGridPropretyType.TC_GRID_PRO_CD_DOWN_TIME);
				uint gridPropertyValue2 = TeamDuplicationUtility.GetGridPropertyValue(this._gridMonsterDataModel, TCGridPropretyType.TC_GRID_PRO_CD_END_STAMP);
				this.gridItemProgressBarControl.UpdateProgressBarControl(gridPropertyValue, gridPropertyValue2, new Action(this.UpdateMonsterNextGridItemAction));
			}
			GameObject upRoot = monsterStandGridItem.GetUpRoot();
			this.SetStandBgGoParentRoot(upRoot);
		}

		// Token: 0x06011E40 RID: 73280 RVA: 0x0053C07C File Offset: 0x0053A47C
		private void UpdateMonsterNextGridItemAction()
		{
			if (this._nextEffectGridItem == null)
			{
				return;
			}
			if (this._nextEffectGridId <= 0U)
			{
				return;
			}
			this._isShowNextGridEffect = true;
			this.UpdateNextEffectView();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage, this._nextEffectGridId, null, null, null);
		}

		// Token: 0x06011E41 RID: 73281 RVA: 0x0053C0D4 File Offset: 0x0053A4D4
		private void UpdateNextEffectView()
		{
			if (!TeamDuplicationUtility.IsNearByGridCanStand(this._nextEffectGridItem, this._nextEffectGridId))
			{
				this.ResetNextEffectGoParentRoot();
				return;
			}
			if (this._nextEffectGridItem == null)
			{
				return;
			}
			GameObject upRoot = this._nextEffectGridItem.GetUpRoot();
			this.SetNextEffectGoParentRoot(upRoot);
		}

		// Token: 0x06011E42 RID: 73282 RVA: 0x0053C128 File Offset: 0x0053A528
		private void SetNextEffectGoParentRoot(GameObject parentRoot)
		{
			if (this.nextEffectGo == null)
			{
				return;
			}
			if (parentRoot == null)
			{
				this.ResetNextEffectGoParentRoot();
				return;
			}
			if (this._nextEffectPrefab == null && this.nextEffectChild != null)
			{
				this._nextEffectPrefab = CommonUtility.LoadGameObject(this.nextEffectChild);
			}
			this.nextEffectGo.transform.SetParent(parentRoot.transform, false);
			CommonUtility.UpdateGameObjectVisible(this.nextEffectGo, true);
		}

		// Token: 0x06011E43 RID: 73283 RVA: 0x0053C1B0 File Offset: 0x0053A5B0
		private void ResetNextEffectGoParentRoot()
		{
			if (this.nextEffectRoot == null)
			{
				return;
			}
			if (this.nextEffectGo == null)
			{
				return;
			}
			this.nextEffectGo.transform.SetParent(this.nextEffectRoot.transform, false);
			CommonUtility.UpdateGameObjectVisible(this.nextEffectGo, false);
		}

		// Token: 0x06011E44 RID: 73284 RVA: 0x0053C209 File Offset: 0x0053A609
		private void ResetNextEffectGridItem()
		{
			this._isShowNextGridEffect = false;
			this.ResetNextEffectGoParentRoot();
		}

		// Token: 0x06011E45 RID: 73285 RVA: 0x0053C218 File Offset: 0x0053A618
		private void SetStandBgGoParentRoot(GameObject parentRoot)
		{
			if (this.standBgGo == null)
			{
				return;
			}
			if (parentRoot == null)
			{
				this.ResetStandBgGoParentRoot();
				return;
			}
			this.standBgGo.transform.SetParent(parentRoot.transform, false);
		}

		// Token: 0x06011E46 RID: 73286 RVA: 0x0053C258 File Offset: 0x0053A658
		private void ResetStandBgGoParentRoot()
		{
			if (this.standBgRoot == null)
			{
				return;
			}
			if (this.standBgGo == null)
			{
				return;
			}
			this.standBgGo.transform.SetParent(this.standBgRoot.transform, false);
		}

		// Token: 0x06011E47 RID: 73287 RVA: 0x0053C2A5 File Offset: 0x0053A6A5
		public void ResetMonsterItem()
		{
			this.ResetNextEffectGridItem();
			this.ResetStandBgGoParentRoot();
			this.ClearData();
		}

		// Token: 0x06011E48 RID: 73288 RVA: 0x0053C2BC File Offset: 0x0053A6BC
		private void OnReceiveTeamDuplicationMonsterNextGridUpdateMessage(UIEvent uiEvent)
		{
			if (!this._isShowNextGridEffect)
			{
				return;
			}
			if (this._gridMonsterDataModel == null)
			{
				return;
			}
			if (this._nextEffectGridItem == null)
			{
				return;
			}
			if (this._nextEffectGridId <= 0U)
			{
				return;
			}
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 != null)
			{
				uint num = (uint)uiEvent.Param1;
				if (num == this._nextEffectGridId)
				{
					this.UpdateNextEffectView();
				}
			}
			if (uiEvent.Param2 != null)
			{
				uint num2 = (uint)uiEvent.Param2;
				if (num2 == this._nextEffectGridId)
				{
					this.UpdateNextEffectView();
				}
			}
		}

		// Token: 0x06011E49 RID: 73289 RVA: 0x0053C359 File Offset: 0x0053A759
		public uint GetNextEffectGridId()
		{
			return this._nextEffectGridId;
		}

		// Token: 0x06011E4A RID: 73290 RVA: 0x0053C361 File Offset: 0x0053A761
		public bool GetIsShowNextEffectFlag()
		{
			return this._isShowNextGridEffect;
		}

		// Token: 0x0400BA6C RID: 47724
		private TeamDuplicationGridObjectDataModel _gridMonsterDataModel;

		// Token: 0x0400BA6D RID: 47725
		private uint _monsterStandGridId;

		// Token: 0x0400BA6E RID: 47726
		private TeamDuplicationGridMapGridItem _nextEffectGridItem;

		// Token: 0x0400BA6F RID: 47727
		private uint _nextEffectGridId;

		// Token: 0x0400BA70 RID: 47728
		private bool _isShowNextGridEffect;

		// Token: 0x0400BA71 RID: 47729
		private GameObject _nextEffectPrefab;

		// Token: 0x0400BA72 RID: 47730
		[Space(10f)]
		[Header("RectTransform")]
		[Space(10f)]
		[SerializeField]
		private RectTransform monsterItemRtf;

		// Token: 0x0400BA73 RID: 47731
		[Space(10f)]
		[Header("StandBgRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject standBgRoot;

		// Token: 0x0400BA74 RID: 47732
		[SerializeField]
		private GameObject standBgGo;

		// Token: 0x0400BA75 RID: 47733
		[Space(10f)]
		[Header("Next")]
		[Space(10f)]
		[SerializeField]
		private GameObject nextEffectRoot;

		// Token: 0x0400BA76 RID: 47734
		[SerializeField]
		private GameObject nextEffectGo;

		// Token: 0x0400BA77 RID: 47735
		[SerializeField]
		private GameObject nextEffectChild;

		// Token: 0x0400BA78 RID: 47736
		[Space(10f)]
		[Header("TimePointControl")]
		[Space(10f)]
		[SerializeField]
		private GridItemProgressBarControl gridItemProgressBarControl;
	}
}
