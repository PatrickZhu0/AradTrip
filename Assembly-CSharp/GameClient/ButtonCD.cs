using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200013A RID: 314
	[RequireComponent(typeof(Button))]
	public class ButtonCD : MonoBehaviour
	{
		// Token: 0x06000902 RID: 2306 RVA: 0x0002F88D File Offset: 0x0002DC8D
		private void Awake()
		{
			this.interactable = true;
			this.btn = base.gameObject.GetComponent<Button>();
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0002F8A8 File Offset: 0x0002DCA8
		public void SetCallBack(UnityAction callback)
		{
			if (this.btn == null)
			{
				return;
			}
			this.btn.onClick.RemoveAllListeners();
			this.btn.onClick.AddListener(delegate()
			{
				if (!this.interactable)
				{
					return;
				}
				if (callback != null)
				{
					callback.Invoke();
				}
				this.interactable = false;
				InvokeMethod.Invoke(this, this.cd, delegate()
				{
					this.interactable = true;
				});
			});
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0002F907 File Offset: 0x0002DD07
		private void Start()
		{
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0002F909 File Offset: 0x0002DD09
		private void OnDestroy()
		{
			this.interactable = true;
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x040006EF RID: 1775
		[SerializeField]
		private float cd = 1f;

		// Token: 0x040006F0 RID: 1776
		private Button btn;

		// Token: 0x040006F1 RID: 1777
		private bool interactable = true;
	}
}
