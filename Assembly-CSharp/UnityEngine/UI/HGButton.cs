using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x02000FA8 RID: 4008
	[AddComponentMenu("UI/HGButton", 30)]
	public class HGButton : Button, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x1700193D RID: 6461
		// (get) Token: 0x06009A95 RID: 39573 RVA: 0x001DE43D File Offset: 0x001DC83D
		// (set) Token: 0x06009A96 RID: 39574 RVA: 0x001DE445 File Offset: 0x001DC845
		public HGButton.HGButtonDownUpEvent onUpDown
		{
			get
			{
				return this.m_OnUpDown;
			}
			set
			{
				this.m_OnUpDown = value;
			}
		}

		// Token: 0x06009A97 RID: 39575 RVA: 0x001DE44E File Offset: 0x001DC84E
		private void OnUpDown(bool bUp)
		{
			if (!this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			this.m_OnUpDown.Invoke(bUp);
		}

		// Token: 0x06009A98 RID: 39576 RVA: 0x001DE473 File Offset: 0x001DC873
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (eventData.button != null)
			{
				return;
			}
			this.OnUpDown(false);
		}

		// Token: 0x06009A99 RID: 39577 RVA: 0x001DE48F File Offset: 0x001DC88F
		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (eventData.button != null)
			{
				return;
			}
			this.OnUpDown(true);
		}

		// Token: 0x04005031 RID: 20529
		[SerializeField]
		private HGButton.HGButtonDownUpEvent m_OnUpDown = new HGButton.HGButtonDownUpEvent();

		// Token: 0x02000FA9 RID: 4009
		[Serializable]
		public class HGButtonDownUpEvent : UnityEvent<bool>
		{
		}
	}
}
