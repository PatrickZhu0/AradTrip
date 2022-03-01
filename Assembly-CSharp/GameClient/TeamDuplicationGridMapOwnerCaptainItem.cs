using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C65 RID: 7269
	public class TeamDuplicationGridMapOwnerCaptainItem : MonoBehaviour
	{
		// Token: 0x06011DBC RID: 73148 RVA: 0x0053A2C8 File Offset: 0x005386C8
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011DBD RID: 73149 RVA: 0x0053A2D0 File Offset: 0x005386D0
		private void ClearData()
		{
			this._gridOwnerCaptainDataModel = null;
			this._gridOwnerCaptainPosition = null;
			if (this._arrowFlagRtfList != null)
			{
				this._arrowFlagRtfList.Clear();
			}
			this._isShowCdView = false;
			this.ResetCdTime();
			this._cdTotalTime = 0f;
			this._captainFlagParentRoot = null;
		}

		// Token: 0x06011DBE RID: 73150 RVA: 0x0053A320 File Offset: 0x00538720
		public void UpdateCaptainItem(TeamDuplicationGridOwnerCaptainDataModel gridOwnerCaptainDataModel, TeamDuplicationGridOwnerCaptainPosition gridOwnerCaptainPosition, TeamDuplicationGridMapGridItem standGridItem, bool isSameTargetGrid = false)
		{
			this._gridOwnerCaptainDataModel = gridOwnerCaptainDataModel;
			this._gridOwnerCaptainPosition = gridOwnerCaptainPosition;
			this._ownerCaptainStatus = (TCGridSquadStatus)this._gridOwnerCaptainDataModel.CaptainStatus;
			this.UpdateCaptainItemView(isSameTargetGrid);
			GameObject standBgGoParentRoot = null;
			if (standGridItem != null)
			{
				standBgGoParentRoot = standGridItem.GetUpRoot();
			}
			this.SetStandBgGoParentRoot(standBgGoParentRoot);
		}

		// Token: 0x06011DBF RID: 73151 RVA: 0x0053A370 File Offset: 0x00538770
		public void UpdateCaptainNearByGridItemList(List<TeamDuplicationGridMapGridItem> nearByGridItemList)
		{
			if (this.ownerCaptainNearByControl == null)
			{
				return;
			}
			this.ownerCaptainNearByControl.UpdateOwnerCaptainNearByControl(nearByGridItemList);
		}

		// Token: 0x06011DC0 RID: 73152 RVA: 0x0053A390 File Offset: 0x00538790
		public void UpdateCaptainNearByOneGridItem(TeamDuplicationGridMapGridItem gridItem, int nearByIndex, bool isShow)
		{
			if (this.ownerCaptainNearByControl == null)
			{
				return;
			}
			this.ownerCaptainNearByControl.UpdateOwnerCaptainNearByOneGridItem(gridItem, nearByIndex, isShow);
		}

		// Token: 0x06011DC1 RID: 73153 RVA: 0x0053A3B4 File Offset: 0x005387B4
		private void UpdateCaptainItemView(bool isSameTargetGrid = false)
		{
			uint captainId = this._gridOwnerCaptainDataModel.CaptainId;
			Vector3 startPointPosition = this._gridOwnerCaptainPosition.StartPointPosition;
			Vector3 endPointPosition = this._gridOwnerCaptainPosition.EndPointPosition;
			this.UpdateCaptainItemFlag(captainId, startPointPosition);
			if (this._ownerCaptainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_MOVE)
			{
				this.UpdateCaptainFlagView(captainId, endPointPosition);
				this.UpdateCaptainFlagPosition(isSameTargetGrid);
				this.UpdateCaptainPathView();
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.captainPathRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainFlagGo, false);
			}
			this.UpdateCaptainCdTime();
		}

		// Token: 0x06011DC2 RID: 73154 RVA: 0x0053A434 File Offset: 0x00538834
		private void UpdateCaptainItemFlag(uint captainId, Vector3 captainItemPosition)
		{
			if (captainId == 1U)
			{
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainOneItem, true);
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainTwoItem, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainOneItem, false);
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainTwoItem, true);
			}
			if (this.ownerCaptainItemRtf != null)
			{
				this.ownerCaptainItemRtf.localPosition = captainItemPosition;
			}
		}

		// Token: 0x06011DC3 RID: 73155 RVA: 0x0053A49C File Offset: 0x0053889C
		private void UpdateCaptainFlagView(uint captainId, Vector3 captainFlagPosition)
		{
			CommonUtility.UpdateGameObjectVisible(this.ownerCaptainFlagGo, true);
			if (captainId == 1U)
			{
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainOneFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainTwoFlag, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainOneFlag, false);
				CommonUtility.UpdateGameObjectVisible(this.ownerCaptainTwoFlag, true);
			}
			if (this.ownerCaptainFlagRtf != null)
			{
				this.ownerCaptainFlagRtf.localPosition = captainFlagPosition;
			}
		}

		// Token: 0x06011DC4 RID: 73156 RVA: 0x0053A510 File Offset: 0x00538910
		private void UpdateCaptainPathView()
		{
			if (this.captainPathRoot == null)
			{
				return;
			}
			if (this.arrowFlagPrefab == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.captainPathRoot, true);
			if (this._arrowFlagRtfList.Count > 0)
			{
				for (int i = 0; i < this._arrowFlagRtfList.Count; i++)
				{
					RectTransform rectTransform = this._arrowFlagRtfList[i];
					if (rectTransform != null)
					{
						CommonUtility.UpdateGameObjectVisible(rectTransform.gameObject, false);
					}
				}
			}
			int count = this._arrowFlagRtfList.Count;
			List<TeamDuplicationGridPathPosition> gridPathPositionList = this._gridOwnerCaptainPosition.GridPathPositionList;
			int count2 = gridPathPositionList.Count;
			if (count2 <= 0)
			{
				return;
			}
			if (count2 > count)
			{
				int num = count2 - count;
				for (int j = 0; j < num; j++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.arrowFlagPrefab);
					if (!(gameObject == null))
					{
						gameObject.transform.SetParent(this.captainPathRoot.transform, false);
						RectTransform component = gameObject.GetComponent<RectTransform>();
						if (component != null)
						{
							CommonUtility.UpdateGameObjectVisible(component.gameObject, false);
						}
						this._arrowFlagRtfList.Add(component);
					}
				}
			}
			for (int k = 0; k < count2; k++)
			{
				TeamDuplicationGridPathPosition teamDuplicationGridPathPosition = gridPathPositionList[k];
				if (teamDuplicationGridPathPosition != null)
				{
					if (k < this._arrowFlagRtfList.Count)
					{
						RectTransform rectTransform2 = this._arrowFlagRtfList[k];
						if (!(rectTransform2 == null))
						{
							CommonUtility.UpdateGameObjectVisible(rectTransform2.gameObject, true);
							Vector3 middlePosition = CommonUtility.GetMiddlePosition(teamDuplicationGridPathPosition.StartPointPosition, teamDuplicationGridPathPosition.EndPointPosition);
							float zaxisRotationNumber = TeamDuplicationUtility.GetZAxisRotationNumber(teamDuplicationGridPathPosition.StartTilePos, teamDuplicationGridPathPosition.EndTilePos);
							rectTransform2.localPosition = middlePosition;
							Quaternion rotation = Quaternion.Euler(0f, 0f, zaxisRotationNumber);
							rectTransform2.rotation = rotation;
						}
					}
				}
			}
		}

		// Token: 0x06011DC5 RID: 73157 RVA: 0x0053A718 File Offset: 0x00538B18
		private void UpdateCaptainCdTime()
		{
			if (this._cdEndTimeStamp == this._gridOwnerCaptainDataModel.CaptainCdEndTimeStamp && this._cdTotalTimeInterval == this._gridOwnerCaptainDataModel.CaptainCdTotalTimeInterval)
			{
				return;
			}
			this._cdEndTimeStamp = this._gridOwnerCaptainDataModel.CaptainCdEndTimeStamp;
			this._cdTotalTimeInterval = this._gridOwnerCaptainDataModel.CaptainCdTotalTimeInterval;
			this._cdTotalTime = this._cdTotalTimeInterval;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this._cdLeftTime = 0f;
			if (this._cdEndTimeStamp > serverTime)
			{
				this._cdLeftTime = this._cdEndTimeStamp - serverTime;
			}
			if (this._cdLeftTime > this._cdTotalTime)
			{
				this._cdLeftTime = this._cdTotalTime;
			}
			if (this._cdTotalTime > 0f && this._cdLeftTime > 0f)
			{
				this._isShowCdView = true;
				CommonUtility.UpdateGameObjectVisible(this.countDownTimeRoot, true);
				this.UpdateCdTimeView();
			}
			else
			{
				this.ResetCdTimeRoot();
			}
		}

		// Token: 0x06011DC6 RID: 73158 RVA: 0x0053A818 File Offset: 0x00538C18
		private void Update()
		{
			if (!this._isShowCdView)
			{
				return;
			}
			this._cdLeftTime -= Time.deltaTime;
			if (this._cdLeftTime <= 0f)
			{
				this.ResetCdTimeRoot();
				if (this._ownerCaptainStatus == TCGridSquadStatus.TC_GRID_SQUAD_STATUS_NORMAL)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationCaptainCdFinishedMessage, null, null, null, null);
				}
			}
			else
			{
				this.UpdateCdTimeView();
			}
		}

		// Token: 0x06011DC7 RID: 73159 RVA: 0x0053A882 File Offset: 0x00538C82
		private void ResetCdTimeRoot()
		{
			this._isShowCdView = false;
			CommonUtility.UpdateGameObjectVisible(this.countDownTimeRoot, false);
			this.ResetCdTime();
		}

		// Token: 0x06011DC8 RID: 73160 RVA: 0x0053A8A0 File Offset: 0x00538CA0
		private void UpdateCdTimeView()
		{
			if (this.cdCoverImage == null)
			{
				return;
			}
			float fillAmount = 0f;
			if (this._cdTotalTime > 0f)
			{
				fillAmount = this._cdLeftTime / this._cdTotalTime;
			}
			this.cdCoverImage.fillAmount = fillAmount;
		}

		// Token: 0x06011DC9 RID: 73161 RVA: 0x0053A8EF File Offset: 0x00538CEF
		private void ResetCdTime()
		{
			this._cdEndTimeStamp = 0U;
			this._cdTotalTimeInterval = 0U;
		}

		// Token: 0x06011DCA RID: 73162 RVA: 0x0053A900 File Offset: 0x00538D00
		public void UpdateCaptainFlagPosition(bool isSameTargetGrid)
		{
			if (this._gridOwnerCaptainDataModel == null)
			{
				return;
			}
			if (this._gridOwnerCaptainDataModel.CaptainStatus != 1U)
			{
				return;
			}
			if (this.flagImageRoot == null)
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
				this.flagImageRoot.transform.SetParent(this.twoCaptainParentRoot.transform, false);
			}
			else
			{
				this.flagImageRoot.transform.SetParent(this.oneCaptainParentRoot.transform, false);
			}
		}

		// Token: 0x06011DCB RID: 73163 RVA: 0x0053A9A4 File Offset: 0x00538DA4
		public void SetCaptainFlagParentRoot(GameObject captainFlagParentRoot)
		{
			if (this.ownerCaptainFlagGo == null)
			{
				return;
			}
			if (captainFlagParentRoot == null)
			{
				return;
			}
			this._captainFlagParentRoot = captainFlagParentRoot;
			this.ownerCaptainFlagGo.transform.SetParent(this._captainFlagParentRoot.transform, false);
		}

		// Token: 0x06011DCC RID: 73164 RVA: 0x0053A9F4 File Offset: 0x00538DF4
		public void ResetCaptainFlagParentRoot()
		{
			if (this.ownerCaptainFlagGo == null)
			{
				return;
			}
			if (this.ownerCaptainFlagRoot == null)
			{
				return;
			}
			this.ownerCaptainFlagGo.transform.SetParent(this.ownerCaptainFlagRoot.transform, false);
		}

		// Token: 0x06011DCD RID: 73165 RVA: 0x0053AA41 File Offset: 0x00538E41
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

		// Token: 0x06011DCE RID: 73166 RVA: 0x0053AA80 File Offset: 0x00538E80
		public void ResetStandBgGoParentRoot()
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

		// Token: 0x0400BA03 RID: 47619
		private bool _isShowCdView;

		// Token: 0x0400BA04 RID: 47620
		private TeamDuplicationGridOwnerCaptainDataModel _gridOwnerCaptainDataModel;

		// Token: 0x0400BA05 RID: 47621
		private TeamDuplicationGridOwnerCaptainPosition _gridOwnerCaptainPosition;

		// Token: 0x0400BA06 RID: 47622
		private TCGridSquadStatus _ownerCaptainStatus;

		// Token: 0x0400BA07 RID: 47623
		private List<RectTransform> _arrowFlagRtfList = new List<RectTransform>();

		// Token: 0x0400BA08 RID: 47624
		private uint _cdEndTimeStamp;

		// Token: 0x0400BA09 RID: 47625
		private uint _cdTotalTimeInterval;

		// Token: 0x0400BA0A RID: 47626
		private float _cdTotalTime;

		// Token: 0x0400BA0B RID: 47627
		private float _cdLeftTime;

		// Token: 0x0400BA0C RID: 47628
		private GameObject _captainFlagParentRoot;

		// Token: 0x0400BA0D RID: 47629
		[Space(10f)]
		[Header("Captain")]
		[Space(10f)]
		[SerializeField]
		private GameObject ownerCaptainItemGo;

		// Token: 0x0400BA0E RID: 47630
		[SerializeField]
		private RectTransform ownerCaptainItemRtf;

		// Token: 0x0400BA0F RID: 47631
		[SerializeField]
		private GameObject ownerCaptainOneItem;

		// Token: 0x0400BA10 RID: 47632
		[SerializeField]
		private GameObject ownerCaptainTwoItem;

		// Token: 0x0400BA11 RID: 47633
		[Space(10f)]
		[Header("StandBgRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject standBgRoot;

		// Token: 0x0400BA12 RID: 47634
		[SerializeField]
		private GameObject standBgGo;

		// Token: 0x0400BA13 RID: 47635
		[Space(10f)]
		[Header("Path")]
		[Space(10f)]
		[SerializeField]
		private GameObject captainPathRoot;

		// Token: 0x0400BA14 RID: 47636
		[SerializeField]
		private GameObject arrowFlagPrefab;

		// Token: 0x0400BA15 RID: 47637
		[Space(10f)]
		[Header("Flag")]
		[Space(10f)]
		[SerializeField]
		private GameObject ownerCaptainFlagRoot;

		// Token: 0x0400BA16 RID: 47638
		[SerializeField]
		private GameObject ownerCaptainFlagGo;

		// Token: 0x0400BA17 RID: 47639
		[SerializeField]
		private RectTransform ownerCaptainFlagRtf;

		// Token: 0x0400BA18 RID: 47640
		[SerializeField]
		private GameObject ownerCaptainOneFlag;

		// Token: 0x0400BA19 RID: 47641
		[SerializeField]
		private GameObject ownerCaptainTwoFlag;

		// Token: 0x0400BA1A RID: 47642
		[Space(10f)]
		[Header("FlagPositionRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject flagImageRoot;

		// Token: 0x0400BA1B RID: 47643
		[SerializeField]
		private GameObject oneCaptainParentRoot;

		// Token: 0x0400BA1C RID: 47644
		[SerializeField]
		private GameObject twoCaptainParentRoot;

		// Token: 0x0400BA1D RID: 47645
		[Space(10f)]
		[Header("CdRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject countDownTimeRoot;

		// Token: 0x0400BA1E RID: 47646
		[SerializeField]
		private Image cdCoverImage;

		// Token: 0x0400BA1F RID: 47647
		[Space(10f)]
		[Header("NearByControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapOwnerCaptainNearByControl ownerCaptainNearByControl;
	}
}
