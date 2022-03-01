using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C5F RID: 7263
	public class TeamDuplicationGridMapCaptainControl : MonoBehaviour
	{
		// Token: 0x06011D6D RID: 73069 RVA: 0x0053839E File Offset: 0x0053679E
		private void Awake()
		{
		}

		// Token: 0x06011D6E RID: 73070 RVA: 0x005383A0 File Offset: 0x005367A0
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011D6F RID: 73071 RVA: 0x005383A8 File Offset: 0x005367A8
		private void ClearData()
		{
			this._ownerCaptainTargetGridId = 0U;
			this._otherCaptainTargetGridId = 0U;
			this._gridMapOwnerCaptainItem = null;
			this._gridMapOtherCaptainItem = null;
		}

		// Token: 0x06011D70 RID: 73072 RVA: 0x005383C8 File Offset: 0x005367C8
		public void UpdateOwnerCaptainItem(TeamDuplicationGridOwnerCaptainDataModel gridOwnerCaptainDataModel, TeamDuplicationGridOwnerCaptainPosition gridOwnerCaptainPosition, TeamDuplicationGridMapGridItem standGridItem = null)
		{
			this._ownerCaptainTargetGridId = 0U;
			if (gridOwnerCaptainDataModel != null)
			{
				this._ownerCaptainTargetGridId = gridOwnerCaptainDataModel.GetTargetGridId();
			}
			bool flag = this.IsSameTargetGridId();
			this.UpdateOtherCaptainFlagPosition(flag);
			if (gridOwnerCaptainDataModel == null)
			{
				if (this._gridMapOwnerCaptainItem != null)
				{
					this._gridMapOwnerCaptainItem.ResetStandBgGoParentRoot();
					this._gridMapOwnerCaptainItem.ResetCaptainFlagParentRoot();
					CommonUtility.UpdateGameObjectVisible(this._gridMapOwnerCaptainItem.gameObject, false);
				}
				return;
			}
			if (this._gridMapOwnerCaptainItem == null)
			{
				this._gridMapOwnerCaptainItem = CommonUtility.LoadGameObjectWithType<TeamDuplicationGridMapOwnerCaptainItem>(this.ownerCaptainRoot);
				if (this._gridMapOwnerCaptainItem != null)
				{
					this._gridMapOwnerCaptainItem.SetCaptainFlagParentRoot(this.captainFlagParentRoot);
				}
			}
			if (this._gridMapOwnerCaptainItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this._gridMapOwnerCaptainItem.gameObject, true);
				this._gridMapOwnerCaptainItem.UpdateCaptainItem(gridOwnerCaptainDataModel, gridOwnerCaptainPosition, standGridItem, flag);
			}
		}

		// Token: 0x06011D71 RID: 73073 RVA: 0x005384B0 File Offset: 0x005368B0
		public void UpdateOwnerCaptainNearByGridItemList(List<TeamDuplicationGridMapGridItem> ownerCaptainNearByGridItemList)
		{
			if (this._gridMapOwnerCaptainItem == null)
			{
				return;
			}
			this._gridMapOwnerCaptainItem.UpdateCaptainNearByGridItemList(ownerCaptainNearByGridItemList);
		}

		// Token: 0x06011D72 RID: 73074 RVA: 0x005384D0 File Offset: 0x005368D0
		public void UpdateOwnerCaptainNearByOneGridItem(TeamDuplicationGridMapGridItem gridItem, int index, bool isShow)
		{
			if (this._gridMapOwnerCaptainItem == null)
			{
				return;
			}
			this._gridMapOwnerCaptainItem.UpdateCaptainNearByOneGridItem(gridItem, index, isShow);
		}

		// Token: 0x06011D73 RID: 73075 RVA: 0x005384F4 File Offset: 0x005368F4
		public void UpdateOtherCaptainItem(TeamDuplicationGridOtherCaptainDataModel gridOtherCaptainDataModel, TeamDuplicationGridPathPosition gridPathPosition)
		{
			this._otherCaptainTargetGridId = 0U;
			if (gridOtherCaptainDataModel != null)
			{
				this._otherCaptainTargetGridId = gridOtherCaptainDataModel.GetTargetGridId();
			}
			bool flag = this.IsSameTargetGridId();
			this.UpdateOwnerCaptainFlagPosition(flag);
			if (gridOtherCaptainDataModel == null || !gridOtherCaptainDataModel.IsExist)
			{
				if (this._gridMapOtherCaptainItem != null)
				{
					CommonUtility.UpdateGameObjectVisible(this._gridMapOtherCaptainItem.gameObject, false);
				}
				return;
			}
			if (this._gridMapOtherCaptainItem == null)
			{
				this._gridMapOtherCaptainItem = CommonUtility.LoadGameObjectWithType<TeamDuplicationGridMapOtherCaptainItem>(this.otherCaptainRoot);
			}
			if (this._gridMapOtherCaptainItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this._gridMapOtherCaptainItem.gameObject, true);
				this._gridMapOtherCaptainItem.UpdateCaptainItem(gridOtherCaptainDataModel, gridPathPosition, flag);
			}
		}

		// Token: 0x06011D74 RID: 73076 RVA: 0x005385AE File Offset: 0x005369AE
		private bool IsSameTargetGridId()
		{
			return this._ownerCaptainTargetGridId != 0U && this._otherCaptainTargetGridId != 0U && this._ownerCaptainTargetGridId == this._otherCaptainTargetGridId;
		}

		// Token: 0x06011D75 RID: 73077 RVA: 0x005385DE File Offset: 0x005369DE
		private void UpdateOwnerCaptainFlagPosition(bool isSameTargetGridId)
		{
			if (this._gridMapOwnerCaptainItem == null)
			{
				return;
			}
			this._gridMapOwnerCaptainItem.UpdateCaptainFlagPosition(isSameTargetGridId);
		}

		// Token: 0x06011D76 RID: 73078 RVA: 0x005385FE File Offset: 0x005369FE
		private void UpdateOtherCaptainFlagPosition(bool isSameTargetGridId)
		{
			if (this._gridMapOtherCaptainItem == null)
			{
				return;
			}
			this._gridMapOtherCaptainItem.UpdateCaptainFlagPosition(isSameTargetGridId);
		}

		// Token: 0x0400B9CC RID: 47564
		private uint _ownerCaptainTargetGridId;

		// Token: 0x0400B9CD RID: 47565
		private uint _otherCaptainTargetGridId;

		// Token: 0x0400B9CE RID: 47566
		private TeamDuplicationGridMapOwnerCaptainItem _gridMapOwnerCaptainItem;

		// Token: 0x0400B9CF RID: 47567
		private TeamDuplicationGridMapOtherCaptainItem _gridMapOtherCaptainItem;

		// Token: 0x0400B9D0 RID: 47568
		[Space(10f)]
		[Header("CaptainFlagRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject captainFlagParentRoot;

		// Token: 0x0400B9D1 RID: 47569
		[Space(10f)]
		[Header("OwnerCaptain")]
		[Space(10f)]
		[SerializeField]
		private GameObject ownerCaptainRoot;

		// Token: 0x0400B9D2 RID: 47570
		[SerializeField]
		private GameObject otherCaptainRoot;
	}
}
