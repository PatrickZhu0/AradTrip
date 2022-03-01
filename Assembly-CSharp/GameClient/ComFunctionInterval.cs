using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000030 RID: 48
	public class ComFunctionInterval : MonoBehaviour
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000CCCE File Offset: 0x0000B0CE
		private void OnTickEnd()
		{
			this.EnableFunction();
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000CCD6 File Offset: 0x0000B0D6
		private void OnDestroy()
		{
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000CCE0 File Offset: 0x0000B0E0
		public void EnableFunction()
		{
			bool flag = true;
			if (this.gray != null)
			{
				this.gray.enabled = !flag;
			}
			if (this.button != null)
			{
				this.button.enabled = flag;
			}
			if (this.Express != null)
			{
				this.Express.enabled = !flag;
			}
			if (this.goDisabled != null)
			{
				for (int i = 0; i < this.goDisabled.Count; i++)
				{
					this.goDisabled[i].CustomActive(flag);
				}
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000CD88 File Offset: 0x0000B188
		public void DisableFunction()
		{
			bool flag = false;
			if (this.gray != null)
			{
				this.gray.enabled = !flag;
			}
			if (this.button != null)
			{
				this.button.enabled = flag;
			}
			if (this.Express != null)
			{
				this.Express.enabled = !flag;
			}
			if (this.goDisabled != null)
			{
				for (int i = 0; i < this.goDisabled.Count; i++)
				{
					this.goDisabled[i].CustomActive(flag);
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000CE2D File Offset: 0x0000B22D
		public void BeginInvoke(float fLastTime)
		{
			this.fTickTime = fLastTime;
			this.UpdateText();
			InvokeMethod.RemoveInvokeCall(this);
			InvokeMethod.Invoke(this, fLastTime, new UnityAction(this.OnTickEnd));
			InvokeMethod.Invoke(this, this.fInterval, new UnityAction(this.FunctionRepeating));
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000CE70 File Offset: 0x0000B270
		private void FunctionRepeating()
		{
			this.fTickTime -= this.fInterval;
			this.fTickTime = Mathf.Max(0f, this.fTickTime);
			this.UpdateText();
			if (this.fTickTime > 0f)
			{
				InvokeMethod.Invoke(this, this.fInterval, new UnityAction(this.FunctionRepeating));
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000CED4 File Offset: 0x0000B2D4
		private void UpdateText()
		{
			if (this.Express != null)
			{
				this.Express.text = string.Format(this.formatString, this.fTickTime);
			}
		}

		// Token: 0x04000122 RID: 290
		public Button button;

		// Token: 0x04000123 RID: 291
		public UIGray gray;

		// Token: 0x04000124 RID: 292
		public Text Express;

		// Token: 0x04000125 RID: 293
		public string formatString;

		// Token: 0x04000126 RID: 294
		public float fInterval = 1f;

		// Token: 0x04000127 RID: 295
		public List<GameObject> goDisabled;

		// Token: 0x04000128 RID: 296
		private float fTickTime = 5f;
	}
}
