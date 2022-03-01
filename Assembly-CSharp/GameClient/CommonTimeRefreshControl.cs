using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E57 RID: 3671
	public class CommonTimeRefreshControl : MonoBehaviour
	{
		// Token: 0x060091E6 RID: 37350 RVA: 0x001B092D File Offset: 0x001AED2D
		public void SetInvokeAction(Action invokeAction)
		{
			this._invokeAction = invokeAction;
			this._tempTime = 0f;
		}

		// Token: 0x060091E7 RID: 37351 RVA: 0x001B0941 File Offset: 0x001AED41
		public void ResetInvokeAction()
		{
			this._invokeAction = null;
			this._tempTime = 0f;
		}

		// Token: 0x060091E8 RID: 37352 RVA: 0x001B0958 File Offset: 0x001AED58
		private void Update()
		{
			if (this._invokeAction == null)
			{
				return;
			}
			if (this.intervalTime <= 0f)
			{
				return;
			}
			this._tempTime += Time.deltaTime;
			if (this._tempTime >= this.intervalTime)
			{
				this._tempTime = 0f;
				if (this._invokeAction != null)
				{
					this._invokeAction();
				}
			}
		}

		// Token: 0x0400490F RID: 18703
		[SerializeField]
		private float intervalTime;

		// Token: 0x04004910 RID: 18704
		private Action _invokeAction;

		// Token: 0x04004911 RID: 18705
		private float _tempTime;
	}
}
