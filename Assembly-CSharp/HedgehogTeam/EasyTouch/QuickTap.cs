using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048F2 RID: 18674
	[AddComponentMenu("EasyTouch/Quick Tap")]
	public class QuickTap : QuickBase
	{
		// Token: 0x0601ADC5 RID: 110021 RVA: 0x008433E8 File Offset: 0x008417E8
		public QuickTap()
		{
			this.quickActionName = "QuickTap" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADC6 RID: 110022 RVA: 0x00843420 File Offset: 0x00841820
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (!this.is2Finger)
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_DoubleTap && this.actionTriggering == QuickTap.ActionTriggering.Double_Tap)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_SimpleTap && this.actionTriggering == QuickTap.ActionTriggering.Simple_Tap)
				{
					this.DoAction(this.currentGesture);
				}
			}
			else
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_DoubleTap2Fingers && this.actionTriggering == QuickTap.ActionTriggering.Double_Tap)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_SimpleTap2Fingers && this.actionTriggering == QuickTap.ActionTriggering.Simple_Tap)
				{
					this.DoAction(this.currentGesture);
				}
			}
		}

		// Token: 0x0601ADC7 RID: 110023 RVA: 0x008434EC File Offset: 0x008418EC
		private void DoAction(Gesture gesture)
		{
			if (this.realType == QuickBase.GameObjectType.UI)
			{
				if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
				{
					this.onTap.Invoke(gesture);
				}
			}
			else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && EasyTouch.GetGameObjectAt(gesture.position, this.is2Finger) == base.gameObject)
			{
				this.onTap.Invoke(gesture);
			}
		}

		// Token: 0x04012B33 RID: 76595
		[SerializeField]
		public QuickTap.OnTap onTap;

		// Token: 0x04012B34 RID: 76596
		public QuickTap.ActionTriggering actionTriggering;

		// Token: 0x04012B35 RID: 76597
		private Gesture currentGesture;

		// Token: 0x020048F3 RID: 18675
		[Serializable]
		public class OnTap : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048F4 RID: 18676
		public enum ActionTriggering
		{
			// Token: 0x04012B37 RID: 76599
			Simple_Tap,
			// Token: 0x04012B38 RID: 76600
			Double_Tap
		}
	}
}
