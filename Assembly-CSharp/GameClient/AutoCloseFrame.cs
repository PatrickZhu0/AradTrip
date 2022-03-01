using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000139 RID: 313
	public class AutoCloseFrame : MonoBehaviour
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x0002F80E File Offset: 0x0002DC0E
		private void Start()
		{
			base.Invoke("CloseSelf", this.CloseTime);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0002F821 File Offset: 0x0002DC21
		private void OnDestroy()
		{
			base.CancelInvoke("CloseSelf");
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0002F830 File Offset: 0x0002DC30
		private void CloseSelf()
		{
			ComClientFrame component = base.gameObject.GetComponent<ComClientFrame>();
			if (component != null)
			{
				Type type = Type.GetType(component.mCurrentFrameName);
				if (type != null)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame(type, false);
				}
			}
		}

		// Token: 0x040006EE RID: 1774
		public float CloseTime = 2f;
	}
}
