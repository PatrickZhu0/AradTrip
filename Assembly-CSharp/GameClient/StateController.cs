using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02004745 RID: 18245
	[ExecuteInEditMode]
	public class StateController : MonoBehaviour
	{
		// Token: 0x0601A37A RID: 107386 RVA: 0x008250E2 File Offset: 0x008234E2
		private void Start()
		{
			this._ChangeStatus();
			this.bDirty = false;
		}

		// Token: 0x0601A37B RID: 107387 RVA: 0x008250F4 File Offset: 0x008234F4
		public void _ChangeStatus()
		{
			int num = 0;
			while (num < this.elements.Count && num < this.count)
			{
				if (!string.IsNullOrEmpty(this.defKey) && this.defKey == this.elements[num].key)
				{
					if (this.elements[num].instanceVisible != null)
					{
						this.elements[num].instanceVisible.Apply();
					}
					if (this.elements[num].onEvent != null)
					{
						this.elements[num].onEvent.Invoke();
					}
				}
				num++;
			}
		}

		// Token: 0x17002257 RID: 8791
		// (get) Token: 0x0601A37C RID: 107388 RVA: 0x008251B2 File Offset: 0x008235B2
		// (set) Token: 0x0601A37D RID: 107389 RVA: 0x008251BA File Offset: 0x008235BA
		public string Key
		{
			get
			{
				return this.defKey;
			}
			set
			{
				this.defKey = value;
				this.bDirty = true;
			}
		}

		// Token: 0x0601A37E RID: 107390 RVA: 0x008251CA File Offset: 0x008235CA
		private void Update()
		{
			if (this.bDirty)
			{
				this._ChangeStatus();
				this.bDirty = false;
			}
		}

		// Token: 0x040126A0 RID: 75424
		public List<StateController.State> elements = new List<StateController.State>();

		// Token: 0x040126A1 RID: 75425
		public int count;

		// Token: 0x040126A2 RID: 75426
		public bool expand;

		// Token: 0x040126A3 RID: 75427
		public string defKey;

		// Token: 0x040126A4 RID: 75428
		private bool bDirty;

		// Token: 0x02004746 RID: 18246
		[Serializable]
		public class VisibleData
		{
			// Token: 0x0601A380 RID: 107392 RVA: 0x008251EC File Offset: 0x008235EC
			public void Apply()
			{
				if (null != this.gameObject)
				{
					this.gameObject.CustomActive(this.bVisible);
				}
			}

			// Token: 0x040126A5 RID: 75429
			public bool bVisible;

			// Token: 0x040126A6 RID: 75430
			public GameObject gameObject;
		}

		// Token: 0x02004747 RID: 18247
		[Serializable]
		public class StateVisible
		{
			// Token: 0x0601A382 RID: 107394 RVA: 0x00825224 File Offset: 0x00823624
			public void Apply()
			{
				int num = 0;
				while (num < this.count && num < this.elements.Count)
				{
					this.elements[num].Apply();
					num++;
				}
			}

			// Token: 0x040126A7 RID: 75431
			public List<StateController.VisibleData> elements = new List<StateController.VisibleData>();

			// Token: 0x040126A8 RID: 75432
			public int count;

			// Token: 0x040126A9 RID: 75433
			public bool expand;
		}

		// Token: 0x02004748 RID: 18248
		[Serializable]
		public class State
		{
			// Token: 0x040126AA RID: 75434
			public StateController.StateVisible instanceVisible = new StateController.StateVisible();

			// Token: 0x040126AB RID: 75435
			public UnityEvent onEvent;

			// Token: 0x040126AC RID: 75436
			public string key;

			// Token: 0x040126AD RID: 75437
			public string desc;

			// Token: 0x040126AE RID: 75438
			public bool showInEditor = true;
		}
	}
}
