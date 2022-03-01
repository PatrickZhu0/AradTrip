using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048EE RID: 18670
	[AddComponentMenu("EasyTouch/Quick Swipe")]
	public class QuickSwipe : QuickBase
	{
		// Token: 0x0601ADB9 RID: 110009 RVA: 0x00842EB8 File Offset: 0x008412B8
		public QuickSwipe()
		{
			this.quickActionName = "QuickSwipe" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADBA RID: 110010 RVA: 0x00842F00 File Offset: 0x00841300
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_Drag += this.On_Drag;
			EasyTouch.On_Swipe += this.On_Swipe;
			EasyTouch.On_DragEnd += this.On_DragEnd;
			EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
		}

		// Token: 0x0601ADBB RID: 110011 RVA: 0x00842F57 File Offset: 0x00841357
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADBC RID: 110012 RVA: 0x00842F65 File Offset: 0x00841365
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADBD RID: 110013 RVA: 0x00842F6D File Offset: 0x0084136D
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Swipe -= this.On_Swipe;
			EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
		}

		// Token: 0x0601ADBE RID: 110014 RVA: 0x00842F94 File Offset: 0x00841394
		private void On_Swipe(Gesture gesture)
		{
			if (gesture.touchCount == 1 && ((gesture.pickedObject != base.gameObject && !this.allowSwipeStartOverMe) || this.allowSwipeStartOverMe))
			{
				this.fingerIndex = gesture.fingerIndex;
				if (this.actionTriggering == QuickSwipe.ActionTriggering.InProgress && this.isRightDirection(gesture))
				{
					this.onSwipeAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						this.DoAction(gesture);
					}
				}
			}
		}

		// Token: 0x0601ADBF RID: 110015 RVA: 0x0084301C File Offset: 0x0084141C
		private void On_SwipeEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickSwipe.ActionTriggering.End && this.isRightDirection(gesture))
			{
				this.onSwipeAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					this.DoAction(gesture);
				}
			}
			if (this.fingerIndex == gesture.fingerIndex)
			{
				this.fingerIndex = -1;
			}
		}

		// Token: 0x0601ADC0 RID: 110016 RVA: 0x00843077 File Offset: 0x00841477
		private void On_DragEnd(Gesture gesture)
		{
			if (gesture.pickedObject == base.gameObject && this.allowSwipeStartOverMe)
			{
				this.On_SwipeEnd(gesture);
			}
		}

		// Token: 0x0601ADC1 RID: 110017 RVA: 0x008430A1 File Offset: 0x008414A1
		private void On_Drag(Gesture gesture)
		{
			if (gesture.pickedObject == base.gameObject && this.allowSwipeStartOverMe)
			{
				this.On_Swipe(gesture);
			}
		}

		// Token: 0x0601ADC2 RID: 110018 RVA: 0x008430CC File Offset: 0x008414CC
		private bool isRightDirection(Gesture gesture)
		{
			float num = -1f;
			if (this.inverseAxisValue)
			{
				num = 1f;
			}
			this.axisActionValue = 0f;
			switch (this.swipeDirection)
			{
			case QuickSwipe.SwipeDirection.Vertical:
				if (gesture.swipe == EasyTouch.SwipeDirection.Up || gesture.swipe == EasyTouch.SwipeDirection.Down)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Horizontal:
				if (gesture.swipe == EasyTouch.SwipeDirection.Left || gesture.swipe == EasyTouch.SwipeDirection.Right)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DiagonalRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpRight || gesture.swipe == EasyTouch.SwipeDirection.DownLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DiagonalLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpLeft || gesture.swipe == EasyTouch.SwipeDirection.DownRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Up:
				if (gesture.swipe == EasyTouch.SwipeDirection.Up)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.UpRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Right:
				if (gesture.swipe == EasyTouch.SwipeDirection.Right)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DownRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.DownRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Down:
				if (gesture.swipe == EasyTouch.SwipeDirection.Down)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DownLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.DownLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Left:
				if (gesture.swipe == EasyTouch.SwipeDirection.Left)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.UpLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.All:
				this.axisActionValue = gesture.deltaPosition.magnitude * num;
				return true;
			}
			this.axisActionValue = 0f;
			return false;
		}

		// Token: 0x0601ADC3 RID: 110019 RVA: 0x0084335C File Offset: 0x0084175C
		private void DoAction(Gesture gesture)
		{
			switch (this.directAction)
			{
			case QuickBase.DirectAction.Rotate:
			case QuickBase.DirectAction.RotateLocal:
				this.axisActionValue *= this.sensibility;
				break;
			case QuickBase.DirectAction.Translate:
			case QuickBase.DirectAction.TranslateLocal:
			case QuickBase.DirectAction.Scale:
				this.axisActionValue /= Screen.dpi;
				this.axisActionValue *= this.sensibility;
				break;
			}
			base.DoDirectAction(this.axisActionValue);
		}

		// Token: 0x04012B1C RID: 76572
		[SerializeField]
		public QuickSwipe.OnSwipeAction onSwipeAction;

		// Token: 0x04012B1D RID: 76573
		public bool allowSwipeStartOverMe = true;

		// Token: 0x04012B1E RID: 76574
		public QuickSwipe.ActionTriggering actionTriggering;

		// Token: 0x04012B1F RID: 76575
		public QuickSwipe.SwipeDirection swipeDirection = QuickSwipe.SwipeDirection.All;

		// Token: 0x04012B20 RID: 76576
		private float axisActionValue;

		// Token: 0x04012B21 RID: 76577
		public bool enableSimpleAction;

		// Token: 0x020048EF RID: 18671
		[Serializable]
		public class OnSwipeAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048F0 RID: 18672
		public enum ActionTriggering
		{
			// Token: 0x04012B23 RID: 76579
			InProgress,
			// Token: 0x04012B24 RID: 76580
			End
		}

		// Token: 0x020048F1 RID: 18673
		public enum SwipeDirection
		{
			// Token: 0x04012B26 RID: 76582
			Vertical,
			// Token: 0x04012B27 RID: 76583
			Horizontal,
			// Token: 0x04012B28 RID: 76584
			DiagonalRight,
			// Token: 0x04012B29 RID: 76585
			DiagonalLeft,
			// Token: 0x04012B2A RID: 76586
			Up,
			// Token: 0x04012B2B RID: 76587
			UpRight,
			// Token: 0x04012B2C RID: 76588
			Right,
			// Token: 0x04012B2D RID: 76589
			DownRight,
			// Token: 0x04012B2E RID: 76590
			Down,
			// Token: 0x04012B2F RID: 76591
			DownLeft,
			// Token: 0x04012B30 RID: 76592
			Left,
			// Token: 0x04012B31 RID: 76593
			UpLeft,
			// Token: 0x04012B32 RID: 76594
			All
		}
	}
}
