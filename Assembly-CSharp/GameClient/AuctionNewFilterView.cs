using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001474 RID: 5236
	public class AuctionNewFilterView : MonoBehaviour
	{
		// Token: 0x0600CB1C RID: 51996 RVA: 0x0031C53C File Offset: 0x0031A93C
		public void InitAuctionNewFilterView(AuctionNewFilterData firstFilterData, OnAuctionNewFilterElementItemButtonClick firstFilterElementItemButtonClick, AuctionNewFilterData secondFilterData, OnAuctionNewFilterElementItemButtonClick secondFilterElementItemButtonClick, AuctionNewFilterData thirdFilterData = null, OnAuctionNewFilterElementItemButtonClick thirdFilterElementItemButtonClick = null)
		{
			if (this.positionControl != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.positionControl.gameObject, false);
			}
			this.InitAuctionNewFilterControl(this.firstFilterControl, firstFilterData, firstFilterElementItemButtonClick);
			this.InitAuctionNewFilterControl(this.secondFilterControl, secondFilterData, secondFilterElementItemButtonClick);
			this.InitAuctionNewFilterControl(this.thirdFilterControl, thirdFilterData, thirdFilterElementItemButtonClick);
		}

		// Token: 0x0600CB1D RID: 51997 RVA: 0x0031C598 File Offset: 0x0031A998
		private void InitAuctionNewFilterControl(AuctionNewFilterControl filterControl, AuctionNewFilterData filterData, OnAuctionNewFilterElementItemButtonClick filterElementItemButtonClick)
		{
			if (filterData != null && filterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_NONE && filterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_MAX)
			{
				if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_POSITION)
				{
					this.DisableFilterControl(filterControl);
					this.UpdatePositionControl(filterData, filterElementItemButtonClick);
				}
				else if (filterControl != null)
				{
					CommonUtility.UpdateGameObjectVisible(filterControl.gameObject, true);
					filterControl.InitFilterControl(filterData, filterElementItemButtonClick, new Action(this.OnResetFilterListInFilterView));
				}
			}
			else
			{
				this.DisableFilterControl(filterControl);
			}
		}

		// Token: 0x0600CB1E RID: 51998 RVA: 0x0031C61C File Offset: 0x0031AA1C
		private void OnResetFilterListInFilterView()
		{
			if (this.firstFilterControl != null)
			{
				this.firstFilterControl.ResetFilterList();
			}
			if (this.secondFilterControl != null)
			{
				this.secondFilterControl.ResetFilterList();
			}
			if (this.thirdFilterControl != null)
			{
				this.thirdFilterControl.ResetFilterList();
			}
		}

		// Token: 0x0600CB1F RID: 51999 RVA: 0x0031C67D File Offset: 0x0031AA7D
		private void DisableFilterControl(AuctionNewFilterControl filterControl)
		{
			if (filterControl == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(filterControl.gameObject, false);
		}

		// Token: 0x0600CB20 RID: 52000 RVA: 0x0031C698 File Offset: 0x0031AA98
		private void UpdatePositionControl(AuctionNewFilterData filterData, OnAuctionNewFilterElementItemButtonClick filterElementItemButtonClick)
		{
			if (this.positionControl == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.positionControl.gameObject, true);
			this.positionControl.InitFilterControl(filterData, filterElementItemButtonClick);
		}

		// Token: 0x04007601 RID: 30209
		[SerializeField]
		private AuctionNewFilterControl firstFilterControl;

		// Token: 0x04007602 RID: 30210
		[SerializeField]
		private AuctionNewFilterControl secondFilterControl;

		// Token: 0x04007603 RID: 30211
		[SerializeField]
		private AuctionNewFilterControl thirdFilterControl;

		// Token: 0x04007604 RID: 30212
		[Space(10f)]
		[Header("PositionControl")]
		[Space(10f)]
		[SerializeField]
		private AuctionNewPositionControl positionControl;
	}
}
