using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048F5 RID: 18677
	[AddComponentMenu("EasyTouch/Quick Touch")]
	public class QuickTouch : QuickBase
	{
		// Token: 0x0601ADC9 RID: 110025 RVA: 0x008435B0 File Offset: 0x008419B0
		public QuickTouch()
		{
			this.quickActionName = "QuickTouch" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADCA RID: 110026 RVA: 0x008435E8 File Offset: 0x008419E8
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (!this.is2Finger)
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.fingerIndex == -1 && this.IsOverMe(this.currentGesture))
				{
					this.fingerIndex = this.currentGesture.fingerIndex;
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.actionTriggering == QuickTouch.ActionTriggering.Start && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchDown && this.actionTriggering == QuickTouch.ActionTriggering.Down && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchUp)
				{
					if (this.actionTriggering == QuickTouch.ActionTriggering.Up && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
					{
						if (this.IsOverMe(this.currentGesture))
						{
							this.onTouch.Invoke(this.currentGesture);
						}
						else
						{
							this.onTouchNotOverMe.Invoke(this.currentGesture);
						}
					}
					if (this.currentGesture.fingerIndex == this.fingerIndex)
					{
						this.fingerIndex = -1;
					}
				}
			}
			else
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Start)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchDown2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Down)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchUp2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Up)
				{
					this.DoAction(this.currentGesture);
				}
			}
		}

		// Token: 0x0601ADCB RID: 110027 RVA: 0x008437F2 File Offset: 0x00841BF2
		private void DoAction(Gesture gesture)
		{
			if (this.IsOverMe(gesture))
			{
				this.onTouch.Invoke(gesture);
			}
		}

		// Token: 0x0601ADCC RID: 110028 RVA: 0x0084380C File Offset: 0x00841C0C
		private bool IsOverMe(Gesture gesture)
		{
			bool result = false;
			if (this.realType == QuickBase.GameObjectType.UI)
			{
				if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
				{
					result = true;
				}
			}
			else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && EasyTouch.GetGameObjectAt(gesture.position, this.is2Finger) == base.gameObject)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x04012B39 RID: 76601
		[SerializeField]
		public QuickTouch.OnTouch onTouch;

		// Token: 0x04012B3A RID: 76602
		public QuickTouch.OnTouchNotOverMe onTouchNotOverMe;

		// Token: 0x04012B3B RID: 76603
		public QuickTouch.ActionTriggering actionTriggering;

		// Token: 0x04012B3C RID: 76604
		private Gesture currentGesture;

		// Token: 0x020048F6 RID: 18678
		[Serializable]
		public class OnTouch : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048F7 RID: 18679
		[Serializable]
		public class OnTouchNotOverMe : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048F8 RID: 18680
		public enum ActionTriggering
		{
			// Token: 0x04012B3E RID: 76606
			Start,
			// Token: 0x04012B3F RID: 76607
			Down,
			// Token: 0x04012B40 RID: 76608
			Up
		}
	}
}
