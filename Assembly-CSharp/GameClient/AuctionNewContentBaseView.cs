using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200145F RID: 5215
	public class AuctionNewContentBaseView : MonoBehaviour
	{
		// Token: 0x0600CA48 RID: 51784 RVA: 0x0031830F File Offset: 0x0031670F
		public virtual void InitView(AuctionNewMainTabType mainTabType, AuctionNewUserData userData = null)
		{
		}

		// Token: 0x0600CA49 RID: 51785 RVA: 0x00318311 File Offset: 0x00316711
		public virtual void OnEnableView(AuctionNewMainTabType mainTabType)
		{
		}

		// Token: 0x0600CA4A RID: 51786 RVA: 0x00318313 File Offset: 0x00316713
		public virtual void ResetViewType()
		{
		}
	}
}
