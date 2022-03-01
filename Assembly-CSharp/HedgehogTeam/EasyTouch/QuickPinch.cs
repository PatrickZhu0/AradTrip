using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048EA RID: 18666
	[AddComponentMenu("EasyTouch/Quick Pinch")]
	public class QuickPinch : QuickBase
	{
		// Token: 0x0601ADAE RID: 109998 RVA: 0x00842BF8 File Offset: 0x00840FF8
		public QuickPinch()
		{
			this.quickActionName = "QuickPinch" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADAF RID: 109999 RVA: 0x00842C30 File Offset: 0x00841030
		public override void OnEnable()
		{
			EasyTouch.On_Pinch += this.On_Pinch;
			EasyTouch.On_PinchIn += this.On_PinchIn;
			EasyTouch.On_PinchOut += this.On_PinchOut;
			EasyTouch.On_PinchEnd += this.On_PichEnd;
		}

		// Token: 0x0601ADB0 RID: 110000 RVA: 0x00842C81 File Offset: 0x00841081
		public override void OnDisable()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADB1 RID: 110001 RVA: 0x00842C89 File Offset: 0x00841089
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADB2 RID: 110002 RVA: 0x00842C94 File Offset: 0x00841094
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Pinch -= this.On_Pinch;
			EasyTouch.On_PinchIn -= this.On_PinchIn;
			EasyTouch.On_PinchOut -= this.On_PinchOut;
			EasyTouch.On_PinchEnd -= this.On_PichEnd;
		}

		// Token: 0x0601ADB3 RID: 110003 RVA: 0x00842CE5 File Offset: 0x008410E5
		private void On_Pinch(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress && this.pinchDirection == QuickPinch.ActionPinchDirection.All)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADB4 RID: 110004 RVA: 0x00842D04 File Offset: 0x00841104
		private void On_PinchIn(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress & this.pinchDirection == QuickPinch.ActionPinchDirection.PinchIn)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADB5 RID: 110005 RVA: 0x00842D25 File Offset: 0x00841125
		private void On_PinchOut(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress & this.pinchDirection == QuickPinch.ActionPinchDirection.PinchOut)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADB6 RID: 110006 RVA: 0x00842D46 File Offset: 0x00841146
		private void On_PichEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.End)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADB7 RID: 110007 RVA: 0x00842D5C File Offset: 0x0084115C
		private void DoAction(Gesture gesture)
		{
			this.axisActionValue = gesture.deltaPinch * this.sensibility * Time.deltaTime;
			if (this.isGestureOnMe)
			{
				if (this.realType == QuickBase.GameObjectType.UI)
				{
					if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
					{
						this.onPinchAction.Invoke(gesture);
						if (this.enableSimpleAction)
						{
							base.DoDirectAction(this.axisActionValue);
						}
					}
				}
				else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.GetCurrentPickedObject(true) == base.gameObject)
				{
					this.onPinchAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						base.DoDirectAction(this.axisActionValue);
					}
				}
			}
			else if ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI)
			{
				this.onPinchAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					base.DoDirectAction(this.axisActionValue);
				}
			}
		}

		// Token: 0x04012B0F RID: 76559
		[SerializeField]
		public QuickPinch.OnPinchAction onPinchAction;

		// Token: 0x04012B10 RID: 76560
		public bool isGestureOnMe;

		// Token: 0x04012B11 RID: 76561
		public QuickPinch.ActionTiggering actionTriggering;

		// Token: 0x04012B12 RID: 76562
		public QuickPinch.ActionPinchDirection pinchDirection;

		// Token: 0x04012B13 RID: 76563
		private float axisActionValue;

		// Token: 0x04012B14 RID: 76564
		public bool enableSimpleAction;

		// Token: 0x020048EB RID: 18667
		[Serializable]
		public class OnPinchAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048EC RID: 18668
		public enum ActionTiggering
		{
			// Token: 0x04012B16 RID: 76566
			InProgress,
			// Token: 0x04012B17 RID: 76567
			End
		}

		// Token: 0x020048ED RID: 18669
		public enum ActionPinchDirection
		{
			// Token: 0x04012B19 RID: 76569
			All,
			// Token: 0x04012B1A RID: 76570
			PinchIn,
			// Token: 0x04012B1B RID: 76571
			PinchOut
		}
	}
}
