using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C6F RID: 7279
	public class TeamDuplicationGridMapGridItemWithEnergyType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011DF7 RID: 73207 RVA: 0x0053B8AE File Offset: 0x00539CAE
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._transportDoorControl = null;
			this._gridItemEffect = null;
		}

		// Token: 0x06011DF8 RID: 73208 RVA: 0x0053B8C4 File Offset: 0x00539CC4
		protected override void UpdateGridStatusView()
		{
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD)
			{
				CommonUtility.UpdateGameObjectVisible(this.transportDoorRoot, true);
				if (this._transportDoorControl == null)
				{
					this._transportDoorControl = CommonUtility.LoadGameObjectWithType<GridItemTransportDoorControl>(this.transportDoorRoot);
				}
				if (this._transportDoorControl != null)
				{
					this._transportDoorControl.LoadTransportDoorEffect();
					CommonUtility.UpdateGameObjectVisible(this._transportDoorControl.gameObject, true);
				}
				CommonUtility.UpdateGameObjectVisible(this.gridItemEffectRoot, false);
				CommonUtility.UpdateImageVisible(this.typeImage, false);
				CommonUtility.UpdateGameObjectVisible(this.middleImage, false);
				return;
			}
			CommonUtility.UpdateImageVisible(this.typeImage, true);
			CommonUtility.UpdateGameObjectVisible(this.middleImage, true);
			CommonUtility.UpdateGameObjectVisible(this.gridItemEffectRoot, true);
			if (this._gridItemEffect == null)
			{
				this._gridItemEffect = CommonUtility.LoadGameObject(this.gridItemEffectRoot);
			}
			CommonUtility.UpdateGameObjectVisible(this.transportDoorRoot, false);
		}

		// Token: 0x06011DF9 RID: 73209 RVA: 0x0053B9AF File Offset: 0x00539DAF
		protected override bool IsGridItemCanClick()
		{
			return true;
		}

		// Token: 0x0400BA47 RID: 47687
		private GridItemTransportDoorControl _transportDoorControl;

		// Token: 0x0400BA48 RID: 47688
		private GameObject _gridItemEffect;

		// Token: 0x0400BA49 RID: 47689
		[Space(10f)]
		[Header("Effect")]
		[Space(10f)]
		[SerializeField]
		private GameObject transportDoorRoot;

		// Token: 0x0400BA4A RID: 47690
		[SerializeField]
		private GameObject gridItemEffectRoot;
	}
}
