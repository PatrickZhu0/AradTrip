using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C79 RID: 7289
	public class TeamDuplicationGridMapGridItemWithTransportDoorType : TeamDuplicationGridMapGridItem
	{
		// Token: 0x06011E18 RID: 73240 RVA: 0x0053BEB5 File Offset: 0x0053A2B5
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._transportDoorEffectPrefab = null;
		}

		// Token: 0x06011E19 RID: 73241 RVA: 0x0053BEC4 File Offset: 0x0053A2C4
		protected override void UpdateGridStatusView()
		{
			if (this._gridFieldStatus == TCGridFieldStatus.TC_GRID_FIELD_STATUS_NO_ACTIVE)
			{
				CommonUtility.UpdateGameObjectVisible(this.root, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.root, true);
			if (this._transportDoorEffectPrefab == null)
			{
				this._transportDoorEffectPrefab = CommonUtility.LoadGameObject(this.effectRoot);
			}
		}

		// Token: 0x06011E1A RID: 73242 RVA: 0x0053BF18 File Offset: 0x0053A318
		protected override bool IsGridItemCanClick()
		{
			return this._gridFieldStatus != TCGridFieldStatus.TC_GRID_FIELD_STATUS_NO_ACTIVE;
		}

		// Token: 0x0400BA55 RID: 47701
		private GameObject _transportDoorEffectPrefab;

		// Token: 0x0400BA56 RID: 47702
		[Space(10f)]
		[Header("EffectRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject effectRoot;
	}
}
