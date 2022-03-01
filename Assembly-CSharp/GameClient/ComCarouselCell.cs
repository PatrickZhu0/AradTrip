using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015A3 RID: 5539
	public class ComCarouselCell : MonoBehaviour
	{
		// Token: 0x0600D8A4 RID: 55460 RVA: 0x0036362F File Offset: 0x00361A2F
		public void Init(int index, RectTransform rect, string name)
		{
			this.Index = index;
			this.Rect = rect;
			base.gameObject.name = string.Format("{0}_{1}", name, index.ToString());
		}

		// Token: 0x0600D8A5 RID: 55461 RVA: 0x00363662 File Offset: 0x00361A62
		private void OnDestroy()
		{
			this.BindScript = null;
			this.Index = 0;
			this.Rect = null;
		}

		// Token: 0x04007F41 RID: 32577
		[HideInInspector]
		public object BindScript;

		// Token: 0x04007F42 RID: 32578
		[HideInInspector]
		public int Index;

		// Token: 0x04007F43 RID: 32579
		[HideInInspector]
		public RectTransform Rect;
	}
}
