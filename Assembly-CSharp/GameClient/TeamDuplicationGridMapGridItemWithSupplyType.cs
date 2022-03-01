using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001C77 RID: 7287
	public class TeamDuplicationGridMapGridItemWithSupplyType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011E11 RID: 73233 RVA: 0x0053BD4C File Offset: 0x0053A14C
		protected override void UpdateGridStatusView()
		{
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS)
			{
				if (this._gridItemDestroyView == null)
				{
					this._gridItemDestroyView = CommonUtility.LoadGameObject(this.upRoot);
				}
				CommonUtility.UpdateGameObjectVisible(this._gridItemDestroyView, true);
				base.DisableButton();
				CommonUtility.UpdateImageVisible(this.typeImage, false);
				CommonUtility.UpdateGameObjectVisible(this.middleImage, false);
				return;
			}
			base.EnableButton();
			CommonUtility.UpdateGameObjectVisible(this._gridItemDestroyView, false);
			CommonUtility.UpdateImageVisible(this.typeImage, true);
			CommonUtility.UpdateGameObjectVisible(this.middleImage, true);
		}
	}
}
