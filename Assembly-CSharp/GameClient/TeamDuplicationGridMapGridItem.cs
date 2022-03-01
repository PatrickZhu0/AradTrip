using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C7C RID: 7292
	public class TeamDuplicationGridMapGridItem : MonoBehaviour
	{
		// Token: 0x06011E24 RID: 73252 RVA: 0x0053B5D0 File Offset: 0x005399D0
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011E25 RID: 73253 RVA: 0x0053B5D8 File Offset: 0x005399D8
		protected virtual void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011E26 RID: 73254 RVA: 0x0053B5E6 File Offset: 0x005399E6
		private void BindUiEvents()
		{
			if (this.gridButton != null)
			{
				this.gridButton.onClick.RemoveAllListeners();
				this.gridButton.onClick.AddListener(new UnityAction(this.OnGridButtonClick));
			}
		}

		// Token: 0x06011E27 RID: 73255 RVA: 0x0053B625 File Offset: 0x00539A25
		private void UnBindUiEvents()
		{
			if (this.gridButton != null)
			{
				this.gridButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011E28 RID: 73256 RVA: 0x0053B648 File Offset: 0x00539A48
		private void ClearData()
		{
			this._gridId = 0U;
			this._resId = 0U;
			this._isObstacle = false;
			this._tileResData = null;
			this._tileInsData = null;
			this._gridObjectDataModel = null;
			this._onGridItemClick = null;
			this._gridItemDestroyView = null;
		}

		// Token: 0x06011E29 RID: 73257 RVA: 0x0053B684 File Offset: 0x00539A84
		public void Init(TileInsData tileInsData, TileResData tileResData, Vector3 gridPointPosition, TeamDuplicationGridObjectDataModel gridObjectDataModel = null, OnGridItemClick onGridItemClick = null)
		{
			this._tileInsData = tileInsData;
			this._tileResData = tileResData;
			this._gridPointPosition = gridPointPosition;
			this._gridObjectDataModel = gridObjectDataModel;
			this._onGridItemClick = onGridItemClick;
			if (tileInsData == null || this._tileResData == null)
			{
				return;
			}
			this._gridId = (uint)tileInsData.ID;
			this._resId = (uint)tileInsData.ResID;
			this._tilePos = this._tileInsData.Position;
			int type = (int)this._tileResData.Type;
			this._gridObjectType = (TCGridObjType)type;
			this._isObstacle = (this._tileResData.Link != ETileLinkedType.None);
			this._gridFieldStatus = TCGridFieldStatus.TC_GRID_FIELD_STATUS_NORMAL;
			if (this._gridObjectDataModel != null)
			{
				this._gridFieldStatus = (TCGridFieldStatus)this._gridObjectDataModel.GridStatus;
			}
			this.UpdateGridObstacleButtonState();
			this.UpdateGridStatusView();
		}

		// Token: 0x06011E2A RID: 73258 RVA: 0x0053B74A File Offset: 0x00539B4A
		private void UpdateGridObstacleButtonState()
		{
			if (this._gridObjectType == TCGridObjType.TC_GRID_OBJ_NULL && this._isObstacle)
			{
				this.DisableButton();
			}
		}

		// Token: 0x06011E2B RID: 73259 RVA: 0x0053B768 File Offset: 0x00539B68
		public void UpdateGrid(TeamDuplicationGridObjectDataModel gridObjectDataModel)
		{
			if (this._tileInsData == null || this._tileResData == null)
			{
				return;
			}
			this._gridObjectDataModel = gridObjectDataModel;
			if (this._gridObjectDataModel != null)
			{
				this._gridFieldStatus = (TCGridFieldStatus)this._gridObjectDataModel.GridStatus;
			}
			this.UpdateGridStatusView();
		}

		// Token: 0x06011E2C RID: 73260 RVA: 0x0053B7B5 File Offset: 0x00539BB5
		public uint GetTileInsId()
		{
			return this._gridId;
		}

		// Token: 0x06011E2D RID: 73261 RVA: 0x0053B7BD File Offset: 0x00539BBD
		public TileInsData GetTileInsData()
		{
			return this._tileInsData;
		}

		// Token: 0x06011E2E RID: 73262 RVA: 0x0053B7C5 File Offset: 0x00539BC5
		public TileResData GetTileResData()
		{
			return this._tileResData;
		}

		// Token: 0x06011E2F RID: 73263 RVA: 0x0053B7CD File Offset: 0x00539BCD
		public TCGridFieldStatus GetGridFieldStatus()
		{
			return this._gridFieldStatus;
		}

		// Token: 0x06011E30 RID: 73264 RVA: 0x0053B7D5 File Offset: 0x00539BD5
		public TilePos GetTileInsTilePos()
		{
			return this._tilePos;
		}

		// Token: 0x06011E31 RID: 73265 RVA: 0x0053B7DD File Offset: 0x00539BDD
		public Vector3 GetGridPointPosition()
		{
			return this._gridPointPosition;
		}

		// Token: 0x06011E32 RID: 73266 RVA: 0x0053B7E5 File Offset: 0x00539BE5
		public uint GetGridObjectId()
		{
			if (this._gridObjectDataModel == null)
			{
				return 0U;
			}
			return this._gridObjectDataModel.GridObjectId;
		}

		// Token: 0x06011E33 RID: 73267 RVA: 0x0053B800 File Offset: 0x00539C00
		private void OnGridButtonClick()
		{
			if (this._tileInsData == null)
			{
				return;
			}
			if (this._tileResData == null)
			{
				return;
			}
			if (!this.IsGridItemCanClick())
			{
				return;
			}
			if (this._onGridItemClick != null)
			{
				this._onGridItemClick(this._tileInsData, this._tileResData);
			}
		}

		// Token: 0x06011E34 RID: 73268 RVA: 0x0053B855 File Offset: 0x00539C55
		public virtual bool IsGridItemCanStand()
		{
			return false;
		}

		// Token: 0x06011E35 RID: 73269 RVA: 0x0053B858 File Offset: 0x00539C58
		protected virtual bool IsGridItemCanClick()
		{
			return this._gridFieldStatus != TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS;
		}

		// Token: 0x06011E36 RID: 73270 RVA: 0x0053B869 File Offset: 0x00539C69
		protected virtual void UpdateGridStatusView()
		{
		}

		// Token: 0x06011E37 RID: 73271 RVA: 0x0053B86B File Offset: 0x00539C6B
		protected void DisableButton()
		{
			CommonUtility.UpdateButtonState(this.gridButton, null, false);
		}

		// Token: 0x06011E38 RID: 73272 RVA: 0x0053B87A File Offset: 0x00539C7A
		protected void EnableButton()
		{
			CommonUtility.UpdateButtonState(this.gridButton, null, true);
		}

		// Token: 0x06011E39 RID: 73273 RVA: 0x0053B889 File Offset: 0x00539C89
		public GameObject GetUpRoot()
		{
			return this.upRoot;
		}

		// Token: 0x0400BA57 RID: 47703
		private uint _gridId;

		// Token: 0x0400BA58 RID: 47704
		protected uint _resId;

		// Token: 0x0400BA59 RID: 47705
		protected TCGridObjType _gridObjectType;

		// Token: 0x0400BA5A RID: 47706
		protected bool _isObstacle;

		// Token: 0x0400BA5B RID: 47707
		protected TCGridFieldStatus _gridFieldStatus;

		// Token: 0x0400BA5C RID: 47708
		protected TeamDuplicationGridObjectDataModel _gridObjectDataModel;

		// Token: 0x0400BA5D RID: 47709
		protected TilePos _tilePos;

		// Token: 0x0400BA5E RID: 47710
		protected Vector3 _gridPointPosition;

		// Token: 0x0400BA5F RID: 47711
		protected TileInsData _tileInsData;

		// Token: 0x0400BA60 RID: 47712
		protected TileResData _tileResData;

		// Token: 0x0400BA61 RID: 47713
		protected OnGridItemClick _onGridItemClick;

		// Token: 0x0400BA62 RID: 47714
		protected GameObject _gridItemDestroyView;

		// Token: 0x0400BA63 RID: 47715
		protected GameObject _captainStandView;

		// Token: 0x0400BA64 RID: 47716
		protected GameObject _monsterStandView;

		// Token: 0x0400BA65 RID: 47717
		[Space(10f)]
		[Header("TotalRoot")]
		[Space(10f)]
		[SerializeField]
		protected GameObject root;

		// Token: 0x0400BA66 RID: 47718
		[Space(10f)]
		[Header("BottomRoot")]
		[Space(10f)]
		[SerializeField]
		protected GameObject bottomRoot;

		// Token: 0x0400BA67 RID: 47719
		[Space(10f)]
		[Header("MiddleRoot")]
		[Space(10f)]
		[SerializeField]
		protected GameObject middleRoot;

		// Token: 0x0400BA68 RID: 47720
		[SerializeField]
		protected GameObject middleImage;

		// Token: 0x0400BA69 RID: 47721
		[Space(10f)]
		[Header("UpRoot")]
		[Space(10f)]
		[SerializeField]
		protected GameObject upRoot;

		// Token: 0x0400BA6A RID: 47722
		[SerializeField]
		protected Image typeImage;

		// Token: 0x0400BA6B RID: 47723
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button gridButton;
	}
}
