using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C70 RID: 7280
	public class TeamDuplicationGridMapGridItemWithLabType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011DFB RID: 73211 RVA: 0x0053B9BC File Offset: 0x00539DBC
		protected override void UpdateGridStatusView()
		{
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_REVIVE)
			{
				CommonUtility.UpdateGameObjectVisible(this.makeMonsterRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.rebornRoot, true);
				CommonUtility.UpdateUIGrayVisible(this.rebornUiGray, true);
				if (this._gridItemLabRebornControl == null)
				{
					this._gridItemLabRebornControl = CommonUtility.LoadGameObjectWithType<GridItemLabRebornControl>(this.rebornRoot);
				}
				uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(this._gridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_REVIVE_CD_STAMP);
				if (this._gridItemLabRebornControl != null)
				{
					this._gridItemLabRebornControl.UpdateLabRebornControl(gridPropertyValue);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.rebornRoot, false);
				CommonUtility.UpdateUIGrayVisible(this.rebornUiGray, false);
				CommonUtility.UpdateGameObjectVisible(this.makeMonsterRoot, true);
				if (this._gridItemLabMonsterControl == null)
				{
					this._gridItemLabMonsterControl = CommonUtility.LoadGameObjectWithType<GridItemLabMonsterControl>(this.makeMonsterRoot);
				}
				uint gridPropertyValue2 = TeamDuplicationUtility.GetGridPropertyValue(this._gridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_CD_DOWN_TIME);
				uint gridPropertyValue3 = TeamDuplicationUtility.GetGridPropertyValue(this._gridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_CD_END_STAMP);
				if (this._gridItemLabMonsterControl != null)
				{
					this._gridItemLabMonsterControl.UpdateLabMonsterControl(gridPropertyValue2, gridPropertyValue3);
				}
			}
		}

		// Token: 0x0400BA4B RID: 47691
		private GridItemLabRebornControl _gridItemLabRebornControl;

		// Token: 0x0400BA4C RID: 47692
		private GridItemLabMonsterControl _gridItemLabMonsterControl;

		// Token: 0x0400BA4D RID: 47693
		[SerializeField]
		private UIGray rebornUiGray;

		// Token: 0x0400BA4E RID: 47694
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private GameObject rebornRoot;

		// Token: 0x0400BA4F RID: 47695
		[SerializeField]
		private GameObject makeMonsterRoot;
	}
}
