using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001C75 RID: 7285
	public class TeamDuplicationGridMapGridItemWithPreStationType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011E08 RID: 73224 RVA: 0x0053BC1E File Offset: 0x0053A01E
		protected override void UpdateGridStatusView()
		{
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD)
			{
				CommonUtility.UpdateImageVisible(this.typeImage, false);
				CommonUtility.UpdateGameObjectVisible(this.middleImage, false);
				return;
			}
			CommonUtility.UpdateImageVisible(this.typeImage, true);
			CommonUtility.UpdateGameObjectVisible(this.middleImage, true);
		}

		// Token: 0x06011E09 RID: 73225 RVA: 0x0053BC5D File Offset: 0x0053A05D
		public override bool IsGridItemCanStand()
		{
			return this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD;
		}

		// Token: 0x06011E0A RID: 73226 RVA: 0x0053BC6E File Offset: 0x0053A06E
		protected override bool IsGridItemCanClick()
		{
			return true;
		}
	}
}
