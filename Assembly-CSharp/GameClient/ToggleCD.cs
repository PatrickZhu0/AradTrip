using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000162 RID: 354
	[RequireComponent(typeof(Toggle))]
	public class ToggleCD : MonoBehaviour
	{
		// Token: 0x06000A31 RID: 2609 RVA: 0x00035815 File Offset: 0x00033C15
		private void Awake()
		{
			this.interactable = true;
			this.toggle = base.gameObject.GetComponent<Toggle>();
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00035830 File Offset: 0x00033C30
		public void SetCallBack(UnityAction<bool> callBack)
		{
			if (this.toggle == null)
			{
				return;
			}
			this.toggle.onValueChanged.RemoveAllListeners();
			this.toggle.onValueChanged.AddListener(delegate(bool val)
			{
				if (val)
				{
					if (!this.interactable)
					{
						return;
					}
					if (callBack != null)
					{
						callBack.Invoke(val);
					}
					this.interactable = false;
					InvokeMethod.Invoke(this, this.cd, delegate()
					{
						this.interactable = true;
					});
				}
				else
				{
					this.interactable = true;
					if (callBack != null)
					{
						callBack.Invoke(val);
					}
				}
			});
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0003588F File Offset: 0x00033C8F
		private void Start()
		{
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00035891 File Offset: 0x00033C91
		private void OnDestroy()
		{
			this.interactable = true;
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x04000796 RID: 1942
		[SerializeField]
		private float cd = 1f;

		// Token: 0x04000797 RID: 1943
		private Toggle toggle;

		// Token: 0x04000798 RID: 1944
		private bool interactable = true;
	}
}
