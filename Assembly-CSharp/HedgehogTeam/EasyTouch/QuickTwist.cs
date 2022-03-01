using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048F9 RID: 18681
	[AddComponentMenu("EasyTouch/Quick Twist")]
	public class QuickTwist : QuickBase
	{
		// Token: 0x0601ADCF RID: 110031 RVA: 0x008438C8 File Offset: 0x00841CC8
		public QuickTwist()
		{
			this.quickActionName = "QuickTwist" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADD0 RID: 110032 RVA: 0x008438FF File Offset: 0x00841CFF
		public override void OnEnable()
		{
			EasyTouch.On_Twist += this.On_Twist;
			EasyTouch.On_TwistEnd += this.On_TwistEnd;
		}

		// Token: 0x0601ADD1 RID: 110033 RVA: 0x00843923 File Offset: 0x00841D23
		public override void OnDisable()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADD2 RID: 110034 RVA: 0x0084392B File Offset: 0x00841D2B
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADD3 RID: 110035 RVA: 0x00843933 File Offset: 0x00841D33
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Twist -= this.On_Twist;
			EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		}

		// Token: 0x0601ADD4 RID: 110036 RVA: 0x00843957 File Offset: 0x00841D57
		private void On_Twist(Gesture gesture)
		{
			if (this.actionTriggering == QuickTwist.ActionTiggering.InProgress && this.IsRightRotation(gesture))
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADD5 RID: 110037 RVA: 0x00843977 File Offset: 0x00841D77
		private void On_TwistEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickTwist.ActionTiggering.End && this.IsRightRotation(gesture))
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x0601ADD6 RID: 110038 RVA: 0x00843998 File Offset: 0x00841D98
		private bool IsRightRotation(Gesture gesture)
		{
			this.axisActionValue = 0f;
			float num = 1f;
			if (this.inverseAxisValue)
			{
				num = -1f;
			}
			QuickTwist.ActionRotationDirection actionRotationDirection = this.rotationDirection;
			if (actionRotationDirection != QuickTwist.ActionRotationDirection.All)
			{
				if (actionRotationDirection != QuickTwist.ActionRotationDirection.Clockwise)
				{
					if (actionRotationDirection == QuickTwist.ActionRotationDirection.Counterclockwise)
					{
						if (gesture.twistAngle > 0f)
						{
							this.axisActionValue = gesture.twistAngle * this.sensibility * num;
							return true;
						}
					}
				}
				else if (gesture.twistAngle < 0f)
				{
					this.axisActionValue = gesture.twistAngle * this.sensibility * num;
					return true;
				}
				return false;
			}
			this.axisActionValue = gesture.twistAngle * this.sensibility * num;
			return true;
		}

		// Token: 0x0601ADD7 RID: 110039 RVA: 0x00843A58 File Offset: 0x00841E58
		private void DoAction(Gesture gesture)
		{
			if (this.isGestureOnMe)
			{
				if (this.realType == QuickBase.GameObjectType.UI)
				{
					if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
					{
						this.onTwistAction.Invoke(gesture);
						if (this.enableSimpleAction)
						{
							base.DoDirectAction(this.axisActionValue);
						}
					}
				}
				else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.GetCurrentPickedObject(true) == base.gameObject)
				{
					this.onTwistAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						base.DoDirectAction(this.axisActionValue);
					}
				}
			}
			else if ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI)
			{
				this.onTwistAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					base.DoDirectAction(this.axisActionValue);
				}
			}
		}

		// Token: 0x04012B41 RID: 76609
		[SerializeField]
		public QuickTwist.OnTwistAction onTwistAction;

		// Token: 0x04012B42 RID: 76610
		public bool isGestureOnMe;

		// Token: 0x04012B43 RID: 76611
		public QuickTwist.ActionTiggering actionTriggering;

		// Token: 0x04012B44 RID: 76612
		public QuickTwist.ActionRotationDirection rotationDirection;

		// Token: 0x04012B45 RID: 76613
		private float axisActionValue;

		// Token: 0x04012B46 RID: 76614
		public bool enableSimpleAction;

		// Token: 0x020048FA RID: 18682
		[Serializable]
		public class OnTwistAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048FB RID: 18683
		public enum ActionTiggering
		{
			// Token: 0x04012B48 RID: 76616
			InProgress,
			// Token: 0x04012B49 RID: 76617
			End
		}

		// Token: 0x020048FC RID: 18684
		public enum ActionRotationDirection
		{
			// Token: 0x04012B4B RID: 76619
			All,
			// Token: 0x04012B4C RID: 76620
			Clockwise,
			// Token: 0x04012B4D RID: 76621
			Counterclockwise
		}
	}
}
