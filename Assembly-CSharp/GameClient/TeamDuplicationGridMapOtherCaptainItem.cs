using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C64 RID: 7268
	public class TeamDuplicationGridMapOtherCaptainItem : MonoBehaviour
	{
		// Token: 0x06011DB6 RID: 73142 RVA: 0x0053A0B4 File Offset: 0x005384B4
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011DB7 RID: 73143 RVA: 0x0053A0BC File Offset: 0x005384BC
		private void ClearData()
		{
			this._gridOtherCaptainDataModel = null;
			this._gridOtherCaptainPathPosition = null;
		}

		// Token: 0x06011DB8 RID: 73144 RVA: 0x0053A0CC File Offset: 0x005384CC
		public void UpdateCaptainItem(TeamDuplicationGridOtherCaptainDataModel gridOtherCaptainDataModel, TeamDuplicationGridPathPosition gridOtherCaptainPosition, bool isSameTargetGrid = false)
		{
			this._gridOtherCaptainDataModel = gridOtherCaptainDataModel;
			this._gridOtherCaptainPathPosition = gridOtherCaptainPosition;
			this.UpdateCaptainItemView(isSameTargetGrid);
		}

		// Token: 0x06011DB9 RID: 73145 RVA: 0x0053A0E4 File Offset: 0x005384E4
		private void UpdateCaptainItemView(bool isSameTargetGrid = false)
		{
			uint captainId = this._gridOtherCaptainDataModel.CaptainId;
			Vector3 endPointPosition = this._gridOtherCaptainPathPosition.EndPointPosition;
			Vector3 startPointPosition = this._gridOtherCaptainPathPosition.StartPointPosition;
			TCGridSquadStatus captainStatus = (TCGridSquadStatus)this._gridOtherCaptainDataModel.CaptainStatus;
			if (captainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_MOVE)
			{
				if (captainId == 1U)
				{
					CommonUtility.UpdateGameObjectVisible(this.otherCaptainOneFlag, true);
					CommonUtility.UpdateGameObjectVisible(this.otherCaptainTwoFlag, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.otherCaptainOneFlag, false);
					CommonUtility.UpdateGameObjectVisible(this.otherCaptainTwoFlag, true);
				}
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainFlagGo, true);
				if (this.otherCaptainFlagRtf != null)
				{
					this.otherCaptainFlagRtf.localPosition = endPointPosition;
				}
				this.UpdateCaptainFlagPosition(isSameTargetGrid);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainFlagGo, false);
			}
			if (captainId == 1U)
			{
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainOneItem, true);
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainTwoItem, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainOneItem, false);
				CommonUtility.UpdateGameObjectVisible(this.otherCaptainTwoItem, true);
			}
			if (this.otherCaptainItemRtf != null)
			{
				this.otherCaptainItemRtf.localPosition = startPointPosition;
			}
		}

		// Token: 0x06011DBA RID: 73146 RVA: 0x0053A200 File Offset: 0x00538600
		public void UpdateCaptainFlagPosition(bool isSameTargetGrid)
		{
			if (this._gridOtherCaptainDataModel == null)
			{
				return;
			}
			if (!this._gridOtherCaptainDataModel.IsExist)
			{
				return;
			}
			if (this._gridOtherCaptainDataModel.CaptainStatus != 1U)
			{
				return;
			}
			if (this.flagRoot == null)
			{
				return;
			}
			if (this.oneCaptainParentRoot == null)
			{
				return;
			}
			if (this.twoCaptainParentRoot == null)
			{
				return;
			}
			if (isSameTargetGrid)
			{
				this.flagRoot.transform.SetParent(this.twoCaptainParentRoot.transform, false);
			}
			else
			{
				this.flagRoot.transform.SetParent(this.oneCaptainParentRoot.transform, false);
			}
		}

		// Token: 0x0400B9F6 RID: 47606
		private TeamDuplicationGridOtherCaptainDataModel _gridOtherCaptainDataModel;

		// Token: 0x0400B9F7 RID: 47607
		private TeamDuplicationGridPathPosition _gridOtherCaptainPathPosition;

		// Token: 0x0400B9F8 RID: 47608
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private GameObject otherCaptainItemGo;

		// Token: 0x0400B9F9 RID: 47609
		[SerializeField]
		private RectTransform otherCaptainItemRtf;

		// Token: 0x0400B9FA RID: 47610
		[SerializeField]
		private GameObject otherCaptainOneItem;

		// Token: 0x0400B9FB RID: 47611
		[SerializeField]
		private GameObject otherCaptainTwoItem;

		// Token: 0x0400B9FC RID: 47612
		[Space(10f)]
		[Header("Flag")]
		[Space(10f)]
		[SerializeField]
		private GameObject otherCaptainFlagGo;

		// Token: 0x0400B9FD RID: 47613
		[SerializeField]
		private RectTransform otherCaptainFlagRtf;

		// Token: 0x0400B9FE RID: 47614
		[SerializeField]
		private GameObject otherCaptainOneFlag;

		// Token: 0x0400B9FF RID: 47615
		[SerializeField]
		private GameObject otherCaptainTwoFlag;

		// Token: 0x0400BA00 RID: 47616
		[Space(10f)]
		[Header("FlagPositionRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject flagRoot;

		// Token: 0x0400BA01 RID: 47617
		[SerializeField]
		private GameObject oneCaptainParentRoot;

		// Token: 0x0400BA02 RID: 47618
		[SerializeField]
		private GameObject twoCaptainParentRoot;
	}
}
