using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C83 RID: 7299
	public class TeamDuplicationGridItemTipView : MonoBehaviour
	{
		// Token: 0x06011E80 RID: 73344 RVA: 0x0053CBD0 File Offset: 0x0053AFD0
		private void Awake()
		{
			if (this.actionButton != null)
			{
				this.actionButton.onClick.RemoveAllListeners();
				this.actionButton.onClick.AddListener(new UnityAction(this.OnActionButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButton));
			}
		}

		// Token: 0x06011E81 RID: 73345 RVA: 0x0053CC58 File Offset: 0x0053B058
		private void OnDestroy()
		{
			if (this.actionButton != null)
			{
				this.actionButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			this.ClearData();
		}

		// Token: 0x06011E82 RID: 73346 RVA: 0x0053CCB0 File Offset: 0x0053B0B0
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainCdFinishedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCaptainCdFinishedMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridItemDestroyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridItemDestroyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterDestroyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterDestroyMessage));
		}

		// Token: 0x06011E83 RID: 73347 RVA: 0x0053CD10 File Offset: 0x0053B110
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationCaptainCdFinishedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationCaptainCdFinishedMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridItemDestroyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridItemDestroyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridMonsterDestroyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridMonsterDestroyMessage));
		}

		// Token: 0x06011E84 RID: 73348 RVA: 0x0053CD70 File Offset: 0x0053B170
		private void ClearData()
		{
			this._tileInsData = null;
			this._tileResData = null;
			this._monsterId = 0U;
			this._gridId = 0U;
			this._gridObjectId = 0U;
			this._monsterId = 0U;
			this._fieldTable = null;
			this._gridObjectDataModel = null;
			this._isChangeToTransportDoor = false;
			this._transportDoorFieldId = 0;
		}

		// Token: 0x06011E85 RID: 73349 RVA: 0x0053CDC4 File Offset: 0x0053B1C4
		public void Init(TeamDuplicationGridItemTipDataModel gridItemTipDataModel)
		{
			if (gridItemTipDataModel == null)
			{
				return;
			}
			this._tileInsData = gridItemTipDataModel.TileInsData;
			this._tileResData = gridItemTipDataModel.TileResData;
			this._monsterId = gridItemTipDataModel.TargetMonsterId;
			this._gridObjectId = gridItemTipDataModel.GridObjectId;
			this._gridItemTipStatusType = gridItemTipDataModel.GridItemTipStatusType;
			this._isDisableByCaptainCd = gridItemTipDataModel.IsDisableByCaptainCd;
			if (this._tileInsData == null || this._tileResData == null)
			{
				return;
			}
			this._gridId = (uint)this._tileInsData.ID;
			this._gridType = this._tileResData.Type;
			if (this._monsterId > 0U)
			{
				this._fieldId = DataManager<TeamDuplicationDataManager>.GetInstance().GetMonsterFieldId();
			}
			else
			{
				this._fieldId = this._tileInsData.TableID;
			}
			this.DealWithGirdItemWithStatus();
			this._fieldTable = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(this._fieldId, string.Empty, string.Empty);
			if (this._fieldTable == null)
			{
				return;
			}
			this.InitView();
		}

		// Token: 0x06011E86 RID: 73350 RVA: 0x0053CEC4 File Offset: 0x0053B2C4
		private void DealWithGirdItemWithStatus()
		{
			if (this._gridType == ETeamTileType.EnegryStation)
			{
				this._gridObjectDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridObjectDataModelByGridId(this._gridId);
				if (this._gridObjectDataModel != null && this._gridObjectDataModel.GridStatus == 6U)
				{
					this._isChangeToTransportDoor = true;
					this._fieldId = TeamDuplicationUtility.GetTransportDoorFieldIdInGridParamTable(this._tileResData.ID);
				}
			}
			if (this._gridType == ETeamTileType.MonsterStation)
			{
				this._gridObjectDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridObjectDataModelByGridId(this._gridId);
				if (this._gridObjectDataModel != null && this._gridObjectDataModel.GridStatus == 1U && this._gridItemTipStatusType == TeamDuplicationGridItemTipStatusType.DoMoveType)
				{
					this._gridItemTipStatusType = TeamDuplicationGridItemTipStatusType.DisableType;
				}
			}
			if (this._gridType == ETeamTileType.Soul || this._gridType == ETeamTileType.TerribleSoul)
			{
				this._gridObjectDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetGridObjectDataModelByGridId(this._gridId);
				if (this._gridObjectDataModel != null && this._gridObjectDataModel.GridStatus == 3U && this._gridItemTipStatusType == TeamDuplicationGridItemTipStatusType.DoMoveType)
				{
					this._gridItemTipStatusType = TeamDuplicationGridItemTipStatusType.DisableType;
				}
			}
		}

		// Token: 0x06011E87 RID: 73351 RVA: 0x0053CFDC File Offset: 0x0053B3DC
		private void InitView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = this._fieldTable.Name;
			}
			if (this.contentLabel != null)
			{
				this.contentLabel.text = this._fieldTable.StrongholdDesc;
			}
			this.UpdateActionButton();
		}

		// Token: 0x06011E88 RID: 73352 RVA: 0x0053D040 File Offset: 0x0053B440
		private void UpdateActionButton()
		{
			if (this._gridType == ETeamTileType.MainCity)
			{
				CommonUtility.UpdateButtonVisible(this.actionButton, false);
				return;
			}
			if (this._gridItemTipStatusType == TeamDuplicationGridItemTipStatusType.CancelMoveType)
			{
				if (this.actionButtonLabel != null)
				{
					this.actionButtonLabel.text = TR.Value("Team_Duplication_Grid_Item_Cancel_Move_Label");
				}
				CommonUtility.UpdateButtonState(this.actionButton, this.actionButtonGray, true);
			}
			else
			{
				if (this.actionButtonLabel != null)
				{
					if (this._gridType == ETeamTileType.TransportDoor)
					{
						this.actionButtonLabel.text = TR.Value("Team_Duplication_Grid_Item_Transport_Label");
					}
					else if (this._gridType == ETeamTileType.EnegryStation && this._isChangeToTransportDoor)
					{
						this.actionButtonLabel.text = TR.Value("Team_Duplication_Grid_Item_Transport_Label");
					}
					else
					{
						this.actionButtonLabel.text = TR.Value("Team_Duplication_Grid_Item_Fight_Label");
					}
				}
				if (this._gridItemTipStatusType == TeamDuplicationGridItemTipStatusType.DoMoveType)
				{
					CommonUtility.UpdateButtonState(this.actionButton, this.actionButtonGray, true);
				}
				else
				{
					CommonUtility.UpdateButtonState(this.actionButton, this.actionButtonGray, false);
				}
			}
		}

		// Token: 0x06011E89 RID: 73353 RVA: 0x0053D164 File Offset: 0x0053B564
		private void OnActionButtonClick()
		{
			if (this._tileInsData == null || this._tileResData == null)
			{
				return;
			}
			if (this._fieldTable == null)
			{
				return;
			}
			if (this._gridItemTipStatusType == TeamDuplicationGridItemTipStatusType.CancelMoveType)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyGridMoveReq(0U, 0U);
			}
			else if (this._monsterId > 0U)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyGridMoveReq(0U, this._monsterId);
			}
			else
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyGridMoveReq(this._gridId, this._gridObjectId);
			}
			TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
		}

		// Token: 0x06011E8A RID: 73354 RVA: 0x0053D1EE File Offset: 0x0053B5EE
		private void OnCloseButton()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
		}

		// Token: 0x06011E8B RID: 73355 RVA: 0x0053D1F5 File Offset: 0x0053B5F5
		private void OnReceiveTeamDuplicationCaptainCdFinishedMessage(UIEvent uiEvent)
		{
			if (!this._isDisableByCaptainCd)
			{
				return;
			}
			this._gridItemTipStatusType = TeamDuplicationGridItemTipStatusType.DoMoveType;
			this.UpdateActionButton();
		}

		// Token: 0x06011E8C RID: 73356 RVA: 0x0053D210 File Offset: 0x0053B610
		private void OnReceiveTeamDuplicationGridItemDestroyMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num == this._gridId)
			{
				TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
			}
		}

		// Token: 0x06011E8D RID: 73357 RVA: 0x0053D24C File Offset: 0x0053B64C
		private void OnReceiveTeamDuplicationGridMonsterDestroyMessage(UIEvent uiEvent)
		{
			if (this._monsterId <= 0U)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (this._monsterId == num)
			{
				TeamDuplicationUtility.OnCloseTeamDuplicationGridItemTipFrame();
			}
		}

		// Token: 0x0400BA94 RID: 47764
		private TileInsData _tileInsData;

		// Token: 0x0400BA95 RID: 47765
		private TileResData _tileResData;

		// Token: 0x0400BA96 RID: 47766
		private uint _gridObjectId;

		// Token: 0x0400BA97 RID: 47767
		private uint _monsterId;

		// Token: 0x0400BA98 RID: 47768
		private TeamDuplicationGridItemTipStatusType _gridItemTipStatusType;

		// Token: 0x0400BA99 RID: 47769
		private bool _isDisableByCaptainCd;

		// Token: 0x0400BA9A RID: 47770
		private uint _gridId;

		// Token: 0x0400BA9B RID: 47771
		private int _fieldId;

		// Token: 0x0400BA9C RID: 47772
		private TeamCopyFieldTable _fieldTable;

		// Token: 0x0400BA9D RID: 47773
		private ETeamTileType _gridType;

		// Token: 0x0400BA9E RID: 47774
		private TeamDuplicationGridObjectDataModel _gridObjectDataModel;

		// Token: 0x0400BA9F RID: 47775
		private bool _isChangeToTransportDoor;

		// Token: 0x0400BAA0 RID: 47776
		private int _transportDoorFieldId;

		// Token: 0x0400BAA1 RID: 47777
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button actionButton;

		// Token: 0x0400BAA2 RID: 47778
		[SerializeField]
		private Text actionButtonLabel;

		// Token: 0x0400BAA3 RID: 47779
		[SerializeField]
		private UIGray actionButtonGray;

		// Token: 0x0400BAA4 RID: 47780
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400BAA5 RID: 47781
		[SerializeField]
		private Text contentLabel;

		// Token: 0x0400BAA6 RID: 47782
		[Space(10f)]
		[Header("CloseButton")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
