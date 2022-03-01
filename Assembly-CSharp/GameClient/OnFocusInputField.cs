using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200154D RID: 5453
	internal class OnFocusInputField : InputField
	{
		// Token: 0x0600D531 RID: 54577 RVA: 0x00354F3E File Offset: 0x0035333E
		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			if (this.onClick != null)
			{
				this.onClick();
			}
		}

		// Token: 0x04007D34 RID: 32052
		public OnFocusInputField.OnClick onClick;

		// Token: 0x0200154E RID: 5454
		// (Invoke) Token: 0x0600D533 RID: 54579
		public delegate void OnClick();
	}
}
