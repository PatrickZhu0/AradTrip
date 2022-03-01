using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AF3 RID: 19187
	[AddComponentMenu("UI/Extensions/UI Selectable Extension")]
	[RequireComponent(typeof(Selectable))]
	public class UISelectableExtension : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x0601BE9B RID: 114331 RVA: 0x0088BE18 File Offset: 0x0088A218
		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (this.OnButtonPress != null)
			{
				this.OnButtonPress.Invoke(eventData.button);
			}
			this._pressed = true;
			this._heldEventData = eventData;
		}

		// Token: 0x0601BE9C RID: 114332 RVA: 0x0088BE44 File Offset: 0x0088A244
		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (this.OnButtonRelease != null)
			{
				this.OnButtonRelease.Invoke(eventData.button);
			}
			this._pressed = false;
			this._heldEventData = null;
		}

		// Token: 0x0601BE9D RID: 114333 RVA: 0x0088BE70 File Offset: 0x0088A270
		private void Update()
		{
			if (!this._pressed)
			{
				return;
			}
			if (this.OnButtonHeld != null)
			{
				this.OnButtonHeld.Invoke(this._heldEventData.button);
			}
		}

		// Token: 0x0601BE9E RID: 114334 RVA: 0x0088BE9F File Offset: 0x0088A29F
		public void TestClicked()
		{
		}

		// Token: 0x0601BE9F RID: 114335 RVA: 0x0088BEA1 File Offset: 0x0088A2A1
		public void TestPressed()
		{
		}

		// Token: 0x0601BEA0 RID: 114336 RVA: 0x0088BEA3 File Offset: 0x0088A2A3
		public void TestReleased()
		{
		}

		// Token: 0x0601BEA1 RID: 114337 RVA: 0x0088BEA5 File Offset: 0x0088A2A5
		public void TestHold()
		{
		}

		// Token: 0x04013766 RID: 79718
		[Tooltip("Event that fires when a button is initially pressed down")]
		public UISelectableExtension.UIButtonEvent OnButtonPress;

		// Token: 0x04013767 RID: 79719
		[Tooltip("Event that fires when a button is released")]
		public UISelectableExtension.UIButtonEvent OnButtonRelease;

		// Token: 0x04013768 RID: 79720
		[Tooltip("Event that continually fires while a button is held down")]
		public UISelectableExtension.UIButtonEvent OnButtonHeld;

		// Token: 0x04013769 RID: 79721
		private bool _pressed;

		// Token: 0x0401376A RID: 79722
		private PointerEventData _heldEventData;

		// Token: 0x02004AF4 RID: 19188
		[Serializable]
		public class UIButtonEvent : UnityEvent<PointerEventData.InputButton>
		{
		}
	}
}
