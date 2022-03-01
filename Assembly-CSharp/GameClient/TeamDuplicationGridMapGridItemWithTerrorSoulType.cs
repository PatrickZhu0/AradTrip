using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C78 RID: 7288
	public class TeamDuplicationGridMapGridItemWithTerrorSoulType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011E13 RID: 73235 RVA: 0x0053BDE4 File Offset: 0x0053A1E4
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._gridItemSealView = null;
		}

		// Token: 0x06011E14 RID: 73236 RVA: 0x0053BDF4 File Offset: 0x0053A1F4
		protected override void UpdateGridStatusView()
		{
			CommonUtility.UpdateGameObjectVisible(this.middleImage, true);
			CommonUtility.UpdateImageVisible(this.typeImage, true);
			CommonUtility.UpdateGameObjectVisible(this.gridItemEffectRoot, true);
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_SEAL)
			{
				if (this._gridItemSealView == null)
				{
					this._gridItemSealView = CommonUtility.LoadGameObject(this.gridItemEffectRoot);
				}
			}
			else if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD)
			{
				CommonUtility.UpdateImageVisible(this.typeImage, false);
				CommonUtility.UpdateGameObjectVisible(this.gridItemEffectRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.middleImage, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.gridItemEffectRoot, false);
			}
		}

		// Token: 0x06011E15 RID: 73237 RVA: 0x0053BE99 File Offset: 0x0053A299
		public override bool IsGridItemCanStand()
		{
			return this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD;
		}

		// Token: 0x06011E16 RID: 73238 RVA: 0x0053BEAA File Offset: 0x0053A2AA
		protected override bool IsGridItemCanClick()
		{
			return true;
		}

		// Token: 0x0400BA53 RID: 47699
		private GameObject _gridItemSealView;

		// Token: 0x0400BA54 RID: 47700
		[Space(10f)]
		[Header("GridItemEffect")]
		[Space(10f)]
		[SerializeField]
		private GameObject gridItemEffectRoot;
	}
}
