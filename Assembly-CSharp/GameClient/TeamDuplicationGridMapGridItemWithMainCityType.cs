using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001C72 RID: 7282
	public class TeamDuplicationGridMapGridItemWithMainCityType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011DFF RID: 73215 RVA: 0x0053BB68 File Offset: 0x00539F68
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._gridItemMainCityBloodControl = null;
		}

		// Token: 0x06011E00 RID: 73216 RVA: 0x0053BB78 File Offset: 0x00539F78
		protected override void UpdateGridStatusView()
		{
			uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(this._gridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_ODD_BLOOD);
			if (this._gridItemMainCityBloodControl == null)
			{
				this._gridItemMainCityBloodControl = CommonUtility.LoadGameObjectWithType<GridItemMainCityBloodControl>(this.upRoot);
				if (this._gridItemMainCityBloodControl != null)
				{
					int mainCityTotalBloodNumber = TeamDuplicationUtility.GetMainCityTotalBloodNumber((int)this._resId);
					this._gridItemMainCityBloodControl.InitTotalBloodNumber(mainCityTotalBloodNumber);
				}
			}
			if (this._gridItemMainCityBloodControl != null)
			{
				this._gridItemMainCityBloodControl.UpdateBloodControl(gridPropertyValue);
			}
		}

		// Token: 0x0400BA50 RID: 47696
		private GridItemMainCityBloodControl _gridItemMainCityBloodControl;
	}
}
