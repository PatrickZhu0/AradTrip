using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C6C RID: 7276
	public class GridItemTransportDoorControl : MonoBehaviour
	{
		// Token: 0x06011DF0 RID: 73200 RVA: 0x0053B59A File Offset: 0x0053999A
		private void OnDestroy()
		{
			this._transportDoorEffect = null;
		}

		// Token: 0x06011DF1 RID: 73201 RVA: 0x0053B5A3 File Offset: 0x005399A3
		public void LoadTransportDoorEffect()
		{
			if (this._transportDoorEffect != null)
			{
				return;
			}
			this._transportDoorEffect = CommonUtility.LoadGameObject(this.transportDoorRoot);
		}

		// Token: 0x0400BA45 RID: 47685
		private GameObject _transportDoorEffect;

		// Token: 0x0400BA46 RID: 47686
		[SerializeField]
		private GameObject transportDoorRoot;
	}
}
