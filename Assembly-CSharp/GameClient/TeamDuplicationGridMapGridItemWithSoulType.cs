using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C76 RID: 7286
	public class TeamDuplicationGridMapGridItemWithSoulType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011E0C RID: 73228 RVA: 0x0053BC79 File Offset: 0x0053A079
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._gridItemSealView = null;
		}

		// Token: 0x06011E0D RID: 73229 RVA: 0x0053BC88 File Offset: 0x0053A088
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

		// Token: 0x06011E0E RID: 73230 RVA: 0x0053BD2D File Offset: 0x0053A12D
		public override bool IsGridItemCanStand()
		{
			return this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD;
		}

		// Token: 0x06011E0F RID: 73231 RVA: 0x0053BD3E File Offset: 0x0053A13E
		protected override bool IsGridItemCanClick()
		{
			return true;
		}

		// Token: 0x0400BA51 RID: 47697
		private GameObject _gridItemSealView;

		// Token: 0x0400BA52 RID: 47698
		[Space(10f)]
		[Header("GridItemEffect")]
		[Space(10f)]
		[SerializeField]
		private GameObject gridItemEffectRoot;
	}
}
