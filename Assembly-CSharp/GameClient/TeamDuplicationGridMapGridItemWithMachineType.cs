using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001C71 RID: 7281
	public class TeamDuplicationGridMapGridItemWithMachineType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011DFD RID: 73213 RVA: 0x0053BAD0 File Offset: 0x00539ED0
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
			CommonUtility.UpdateGameObjectVisible(this._gridItemDestroyView, false);
			CommonUtility.UpdateImageVisible(this.typeImage, true);
			CommonUtility.UpdateGameObjectVisible(this.middleImage, true);
			base.EnableButton();
		}
	}
}
