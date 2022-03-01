using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000050 RID: 80
	internal class ComRecoveryRole : MonoBehaviour
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x000102AC File Offset: 0x0000E6AC
		private void Start()
		{
			base.CancelInvoke("_Tick");
			base.InvokeRepeating("_Tick", 0f, 1f);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000102CE File Offset: 0x0000E6CE
		private void OnDestroy()
		{
			base.CancelInvoke("_Tick");
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000102DB File Offset: 0x0000E6DB
		private void _Tick()
		{
			if (this.onTick != null)
			{
				this.onTick();
			}
		}

		// Token: 0x040001D1 RID: 465
		public Image headIcon;

		// Token: 0x040001D2 RID: 466
		public Text LvInfo;

		// Token: 0x040001D3 RID: 467
		public Text JobName;

		// Token: 0x040001D4 RID: 468
		public Text RoleName;

		// Token: 0x040001D5 RID: 469
		public Text LifeTime;

		// Token: 0x040001D6 RID: 470
		public Button button;

		// Token: 0x040001D7 RID: 471
		public UIGray grayRecovery;

		// Token: 0x040001D8 RID: 472
		public ComRecoveryRole.OnTick onTick;

		// Token: 0x02000051 RID: 81
		// (Invoke) Token: 0x060001DD RID: 477
		public delegate void OnTick();
	}
}
