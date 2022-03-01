using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200013C RID: 316
	[RequireComponent(typeof(Button))]
	public class CloseFrameButton : MonoBehaviour
	{
		// Token: 0x06000925 RID: 2341 RVA: 0x0002FDAF File Offset: 0x0002E1AF
		private void Start()
		{
			this.btn = base.gameObject.GetComponent<Button>();
			this.btn.SafeAddOnClickListener(new UnityAction(this.OnClickClose));
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0002FDD9 File Offset: 0x0002E1D9
		private void OnClickClose()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame(this.frameName);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0002FDEB File Offset: 0x0002E1EB
		private void OnDestroy()
		{
			this.btn.SafeRemoveOnClickListener(new UnityAction(this.OnClickClose));
		}

		// Token: 0x040006FD RID: 1789
		public string frameName = string.Empty;

		// Token: 0x040006FE RID: 1790
		private Button btn;
	}
}
