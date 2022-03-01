using System;
using System.Collections.Generic;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048D7 RID: 18647
	[AddComponentMenu("EasyTouch/Trigger")]
	[Serializable]
	public class EasyTouchTrigger : MonoBehaviour
	{
		// Token: 0x0601AD51 RID: 109905 RVA: 0x00840CB5 File Offset: 0x0083F0B5
		private void Start()
		{
			EasyTouch.SetEnableAutoSelect(true);
		}

		// Token: 0x0601AD52 RID: 109906 RVA: 0x00840CBD File Offset: 0x0083F0BD
		private void OnEnable()
		{
			this.SubscribeEasyTouchEvent();
		}

		// Token: 0x0601AD53 RID: 109907 RVA: 0x00840CC5 File Offset: 0x0083F0C5
		private void OnDisable()
		{
			this.UnsubscribeEasyTouchEvent();
		}

		// Token: 0x0601AD54 RID: 109908 RVA: 0x00840CCD File Offset: 0x0083F0CD
		private void OnDestroy()
		{
			this.UnsubscribeEasyTouchEvent();
		}

		// Token: 0x0601AD55 RID: 109909 RVA: 0x00840CD8 File Offset: 0x0083F0D8
		private void SubscribeEasyTouchEvent()
		{
			if (this.IsRecevier4(EasyTouch.EvtType.On_Cancel))
			{
				EasyTouch.On_Cancel += this.On_Cancel;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchStart))
			{
				EasyTouch.On_TouchStart += this.On_TouchStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchDown))
			{
				EasyTouch.On_TouchDown += this.On_TouchDown;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchUp))
			{
				EasyTouch.On_TouchUp += this.On_TouchUp;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SimpleTap))
			{
				EasyTouch.On_SimpleTap += this.On_SimpleTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapStart))
			{
				EasyTouch.On_LongTapStart += this.On_LongTapStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTap))
			{
				EasyTouch.On_LongTap += this.On_LongTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapEnd))
			{
				EasyTouch.On_LongTapEnd += this.On_LongTapEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DoubleTap))
			{
				EasyTouch.On_DoubleTap += this.On_DoubleTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragStart))
			{
				EasyTouch.On_DragStart += this.On_DragStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Drag))
			{
				EasyTouch.On_Drag += this.On_Drag;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragEnd))
			{
				EasyTouch.On_DragEnd += this.On_DragEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeStart))
			{
				EasyTouch.On_SwipeStart += this.On_SwipeStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Swipe))
			{
				EasyTouch.On_Swipe += this.On_Swipe;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeEnd))
			{
				EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchStart2Fingers))
			{
				EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchDown2Fingers))
			{
				EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchUp2Fingers))
			{
				EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SimpleTap2Fingers))
			{
				EasyTouch.On_SimpleTap2Fingers += this.On_SimpleTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapStart2Fingers))
			{
				EasyTouch.On_LongTapStart2Fingers += this.On_LongTapStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTap2Fingers))
			{
				EasyTouch.On_LongTap2Fingers += this.On_LongTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapEnd2Fingers))
			{
				EasyTouch.On_LongTapEnd2Fingers += this.On_LongTapEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DoubleTap2Fingers))
			{
				EasyTouch.On_DoubleTap2Fingers += this.On_DoubleTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeStart2Fingers))
			{
				EasyTouch.On_SwipeStart2Fingers += this.On_SwipeStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Swipe2Fingers))
			{
				EasyTouch.On_Swipe2Fingers += this.On_Swipe2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeEnd2Fingers))
			{
				EasyTouch.On_SwipeEnd2Fingers += this.On_SwipeEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragStart2Fingers))
			{
				EasyTouch.On_DragStart2Fingers += this.On_DragStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Drag2Fingers))
			{
				EasyTouch.On_Drag2Fingers += this.On_Drag2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragEnd2Fingers))
			{
				EasyTouch.On_DragEnd2Fingers += this.On_DragEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Pinch))
			{
				EasyTouch.On_Pinch += this.On_Pinch;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchIn))
			{
				EasyTouch.On_PinchIn += this.On_PinchIn;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchOut))
			{
				EasyTouch.On_PinchOut += this.On_PinchOut;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchEnd))
			{
				EasyTouch.On_PinchEnd += this.On_PinchEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Twist))
			{
				EasyTouch.On_Twist += this.On_Twist;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TwistEnd))
			{
				EasyTouch.On_TwistEnd += this.On_TwistEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_OverUIElement))
			{
				EasyTouch.On_OverUIElement += this.On_OverUIElement;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_UIElementTouchUp))
			{
				EasyTouch.On_UIElementTouchUp += this.On_UIElementTouchUp;
			}
		}

		// Token: 0x0601AD56 RID: 109910 RVA: 0x00841134 File Offset: 0x0083F534
		private void UnsubscribeEasyTouchEvent()
		{
			EasyTouch.On_Cancel -= this.On_Cancel;
			EasyTouch.On_TouchStart -= this.On_TouchStart;
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
			EasyTouch.On_SimpleTap -= this.On_SimpleTap;
			EasyTouch.On_LongTapStart -= this.On_LongTapStart;
			EasyTouch.On_LongTap -= this.On_LongTap;
			EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
			EasyTouch.On_DoubleTap -= this.On_DoubleTap;
			EasyTouch.On_DragStart -= this.On_DragStart;
			EasyTouch.On_Drag -= this.On_Drag;
			EasyTouch.On_DragEnd -= this.On_DragEnd;
			EasyTouch.On_SwipeStart -= this.On_SwipeStart;
			EasyTouch.On_Swipe -= this.On_Swipe;
			EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
			EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
			EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
			EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
			EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
			EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
			EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
			EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
			EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
			EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
			EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
			EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
			EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
			EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
			EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
			EasyTouch.On_Pinch -= this.On_Pinch;
			EasyTouch.On_PinchIn -= this.On_PinchIn;
			EasyTouch.On_PinchOut -= this.On_PinchOut;
			EasyTouch.On_PinchEnd -= this.On_PinchEnd;
			EasyTouch.On_Twist -= this.On_Twist;
			EasyTouch.On_TwistEnd -= this.On_TwistEnd;
			EasyTouch.On_OverUIElement += this.On_OverUIElement;
			EasyTouch.On_UIElementTouchUp += this.On_UIElementTouchUp;
		}

		// Token: 0x0601AD57 RID: 109911 RVA: 0x008413B6 File Offset: 0x0083F7B6
		private void On_TouchStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchStart, gesture);
		}

		// Token: 0x0601AD58 RID: 109912 RVA: 0x008413C0 File Offset: 0x0083F7C0
		private void On_TouchDown(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchDown, gesture);
		}

		// Token: 0x0601AD59 RID: 109913 RVA: 0x008413CA File Offset: 0x0083F7CA
		private void On_TouchUp(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchUp, gesture);
		}

		// Token: 0x0601AD5A RID: 109914 RVA: 0x008413D4 File Offset: 0x0083F7D4
		private void On_SimpleTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SimpleTap, gesture);
		}

		// Token: 0x0601AD5B RID: 109915 RVA: 0x008413DE File Offset: 0x0083F7DE
		private void On_DoubleTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DoubleTap, gesture);
		}

		// Token: 0x0601AD5C RID: 109916 RVA: 0x008413E8 File Offset: 0x0083F7E8
		private void On_LongTapStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapStart, gesture);
		}

		// Token: 0x0601AD5D RID: 109917 RVA: 0x008413F2 File Offset: 0x0083F7F2
		private void On_LongTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTap, gesture);
		}

		// Token: 0x0601AD5E RID: 109918 RVA: 0x008413FC File Offset: 0x0083F7FC
		private void On_LongTapEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapEnd, gesture);
		}

		// Token: 0x0601AD5F RID: 109919 RVA: 0x00841406 File Offset: 0x0083F806
		private void On_SwipeStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeStart, gesture);
		}

		// Token: 0x0601AD60 RID: 109920 RVA: 0x00841411 File Offset: 0x0083F811
		private void On_Swipe(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Swipe, gesture);
		}

		// Token: 0x0601AD61 RID: 109921 RVA: 0x0084141C File Offset: 0x0083F81C
		private void On_SwipeEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeEnd, gesture);
		}

		// Token: 0x0601AD62 RID: 109922 RVA: 0x00841427 File Offset: 0x0083F827
		private void On_DragStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragStart, gesture);
		}

		// Token: 0x0601AD63 RID: 109923 RVA: 0x00841432 File Offset: 0x0083F832
		private void On_Drag(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Drag, gesture);
		}

		// Token: 0x0601AD64 RID: 109924 RVA: 0x0084143D File Offset: 0x0083F83D
		private void On_DragEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragEnd, gesture);
		}

		// Token: 0x0601AD65 RID: 109925 RVA: 0x00841448 File Offset: 0x0083F848
		private void On_Cancel(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Cancel, gesture);
		}

		// Token: 0x0601AD66 RID: 109926 RVA: 0x00841453 File Offset: 0x0083F853
		private void On_TouchStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchStart2Fingers, gesture);
		}

		// Token: 0x0601AD67 RID: 109927 RVA: 0x0084145E File Offset: 0x0083F85E
		private void On_TouchDown2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchDown2Fingers, gesture);
		}

		// Token: 0x0601AD68 RID: 109928 RVA: 0x00841469 File Offset: 0x0083F869
		private void On_TouchUp2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchUp2Fingers, gesture);
		}

		// Token: 0x0601AD69 RID: 109929 RVA: 0x00841474 File Offset: 0x0083F874
		private void On_LongTapStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapStart2Fingers, gesture);
		}

		// Token: 0x0601AD6A RID: 109930 RVA: 0x0084147F File Offset: 0x0083F87F
		private void On_LongTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTap2Fingers, gesture);
		}

		// Token: 0x0601AD6B RID: 109931 RVA: 0x0084148A File Offset: 0x0083F88A
		private void On_LongTapEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapEnd2Fingers, gesture);
		}

		// Token: 0x0601AD6C RID: 109932 RVA: 0x00841495 File Offset: 0x0083F895
		private void On_DragStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragStart2Fingers, gesture);
		}

		// Token: 0x0601AD6D RID: 109933 RVA: 0x008414A0 File Offset: 0x0083F8A0
		private void On_Drag2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Drag2Fingers, gesture);
		}

		// Token: 0x0601AD6E RID: 109934 RVA: 0x008414AB File Offset: 0x0083F8AB
		private void On_DragEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragEnd2Fingers, gesture);
		}

		// Token: 0x0601AD6F RID: 109935 RVA: 0x008414B6 File Offset: 0x0083F8B6
		private void On_SwipeStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeStart2Fingers, gesture);
		}

		// Token: 0x0601AD70 RID: 109936 RVA: 0x008414C1 File Offset: 0x0083F8C1
		private void On_Swipe2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Swipe2Fingers, gesture);
		}

		// Token: 0x0601AD71 RID: 109937 RVA: 0x008414CC File Offset: 0x0083F8CC
		private void On_SwipeEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeEnd2Fingers, gesture);
		}

		// Token: 0x0601AD72 RID: 109938 RVA: 0x008414D7 File Offset: 0x0083F8D7
		private void On_Twist(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Twist, gesture);
		}

		// Token: 0x0601AD73 RID: 109939 RVA: 0x008414E2 File Offset: 0x0083F8E2
		private void On_TwistEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TwistEnd, gesture);
		}

		// Token: 0x0601AD74 RID: 109940 RVA: 0x008414ED File Offset: 0x0083F8ED
		private void On_Pinch(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Pinch, gesture);
		}

		// Token: 0x0601AD75 RID: 109941 RVA: 0x008414F8 File Offset: 0x0083F8F8
		private void On_PinchOut(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchOut, gesture);
		}

		// Token: 0x0601AD76 RID: 109942 RVA: 0x00841503 File Offset: 0x0083F903
		private void On_PinchIn(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchIn, gesture);
		}

		// Token: 0x0601AD77 RID: 109943 RVA: 0x0084150E File Offset: 0x0083F90E
		private void On_PinchEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchEnd, gesture);
		}

		// Token: 0x0601AD78 RID: 109944 RVA: 0x00841519 File Offset: 0x0083F919
		private void On_SimpleTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SimpleTap2Fingers, gesture);
		}

		// Token: 0x0601AD79 RID: 109945 RVA: 0x00841524 File Offset: 0x0083F924
		private void On_DoubleTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DoubleTap2Fingers, gesture);
		}

		// Token: 0x0601AD7A RID: 109946 RVA: 0x0084152F File Offset: 0x0083F92F
		private void On_UIElementTouchUp(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
		}

		// Token: 0x0601AD7B RID: 109947 RVA: 0x0084153A File Offset: 0x0083F93A
		private void On_OverUIElement(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_OverUIElement, gesture);
		}

		// Token: 0x0601AD7C RID: 109948 RVA: 0x00841548 File Offset: 0x0083F948
		public void AddTrigger(EasyTouch.EvtType ev)
		{
			EasyTouchTrigger.EasyTouchReceiver easyTouchReceiver = new EasyTouchTrigger.EasyTouchReceiver();
			easyTouchReceiver.enable = true;
			easyTouchReceiver.restricted = true;
			easyTouchReceiver.eventName = ev;
			easyTouchReceiver.gameObject = null;
			easyTouchReceiver.otherReceiver = false;
			easyTouchReceiver.name = "New trigger";
			this.receivers.Add(easyTouchReceiver);
			if (Application.isPlaying)
			{
				this.UnsubscribeEasyTouchEvent();
				this.SubscribeEasyTouchEvent();
			}
		}

		// Token: 0x0601AD7D RID: 109949 RVA: 0x008415AC File Offset: 0x0083F9AC
		public bool SetTriggerEnable(string triggerName, bool value)
		{
			EasyTouchTrigger.EasyTouchReceiver trigger = this.GetTrigger(triggerName);
			if (trigger != null)
			{
				trigger.enable = value;
				return true;
			}
			return false;
		}

		// Token: 0x0601AD7E RID: 109950 RVA: 0x008415D4 File Offset: 0x0083F9D4
		public bool GetTriggerEnable(string triggerName)
		{
			EasyTouchTrigger.EasyTouchReceiver trigger = this.GetTrigger(triggerName);
			return trigger != null && trigger.enable;
		}

		// Token: 0x0601AD7F RID: 109951 RVA: 0x008415F8 File Offset: 0x0083F9F8
		private void TriggerScheduler(EasyTouch.EvtType evnt, Gesture gesture)
		{
			foreach (EasyTouchTrigger.EasyTouchReceiver easyTouchReceiver in this.receivers)
			{
				if (easyTouchReceiver.enable && easyTouchReceiver.eventName == evnt && ((easyTouchReceiver.restricted && ((gesture.pickedObject == base.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.Object3D) || (gesture.pickedUIElement == base.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.UI))) || (!easyTouchReceiver.restricted && (easyTouchReceiver.gameObject == null || (easyTouchReceiver.gameObject == gesture.pickedObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.Object3D) || (gesture.pickedUIElement == easyTouchReceiver.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.UI)))))
				{
					GameObject gameObject = base.gameObject;
					if (easyTouchReceiver.otherReceiver && easyTouchReceiver.gameObjectReceiver != null)
					{
						gameObject = easyTouchReceiver.gameObjectReceiver;
					}
					switch (easyTouchReceiver.parameter)
					{
					case EasyTouchTrigger.ETTParameter.None:
						gameObject.SendMessage(easyTouchReceiver.methodName, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Gesture:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Finger_Id:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.fingerIndex, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Touch_Count:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.touchCount, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Start_Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.startPosition, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.position, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Delta_Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaPosition, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Type:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipe, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Length:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipeLength, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Vector:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipeVector, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Delta_Pinch:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaPinch, 1);
						break;
					case EasyTouchTrigger.ETTParameter.Twist_Anlge:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.twistAngle, 1);
						break;
					case EasyTouchTrigger.ETTParameter.ActionTime:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.actionTime, 1);
						break;
					case EasyTouchTrigger.ETTParameter.DeltaTime:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaTime, 1);
						break;
					case EasyTouchTrigger.ETTParameter.PickedObject:
						if (gesture.pickedObject != null)
						{
							gameObject.SendMessage(easyTouchReceiver.methodName, gesture.pickedObject, 1);
						}
						break;
					case EasyTouchTrigger.ETTParameter.PickedUIElement:
						if (gesture.pickedUIElement != null)
						{
							gameObject.SendMessage(easyTouchReceiver.methodName, gesture.pickedObject, 1);
						}
						break;
					}
				}
			}
		}

		// Token: 0x0601AD80 RID: 109952 RVA: 0x0084196C File Offset: 0x0083FD6C
		private bool IsRecevier4(EasyTouch.EvtType evnt)
		{
			int num = this.receivers.FindIndex((EasyTouchTrigger.EasyTouchReceiver e) => e.eventName == evnt);
			return num > -1;
		}

		// Token: 0x0601AD81 RID: 109953 RVA: 0x008419A8 File Offset: 0x0083FDA8
		private EasyTouchTrigger.EasyTouchReceiver GetTrigger(string triggerName)
		{
			return this.receivers.Find((EasyTouchTrigger.EasyTouchReceiver n) => n.name == triggerName);
		}

		// Token: 0x04012AB9 RID: 76473
		[SerializeField]
		public List<EasyTouchTrigger.EasyTouchReceiver> receivers = new List<EasyTouchTrigger.EasyTouchReceiver>();

		// Token: 0x020048D8 RID: 18648
		public enum ETTParameter
		{
			// Token: 0x04012ABB RID: 76475
			None,
			// Token: 0x04012ABC RID: 76476
			Gesture,
			// Token: 0x04012ABD RID: 76477
			Finger_Id,
			// Token: 0x04012ABE RID: 76478
			Touch_Count,
			// Token: 0x04012ABF RID: 76479
			Start_Position,
			// Token: 0x04012AC0 RID: 76480
			Position,
			// Token: 0x04012AC1 RID: 76481
			Delta_Position,
			// Token: 0x04012AC2 RID: 76482
			Swipe_Type,
			// Token: 0x04012AC3 RID: 76483
			Swipe_Length,
			// Token: 0x04012AC4 RID: 76484
			Swipe_Vector,
			// Token: 0x04012AC5 RID: 76485
			Delta_Pinch,
			// Token: 0x04012AC6 RID: 76486
			Twist_Anlge,
			// Token: 0x04012AC7 RID: 76487
			ActionTime,
			// Token: 0x04012AC8 RID: 76488
			DeltaTime,
			// Token: 0x04012AC9 RID: 76489
			PickedObject,
			// Token: 0x04012ACA RID: 76490
			PickedUIElement
		}

		// Token: 0x020048D9 RID: 18649
		public enum ETTType
		{
			// Token: 0x04012ACC RID: 76492
			Object3D,
			// Token: 0x04012ACD RID: 76493
			UI
		}

		// Token: 0x020048DA RID: 18650
		[Serializable]
		public class EasyTouchReceiver
		{
			// Token: 0x04012ACE RID: 76494
			public bool enable;

			// Token: 0x04012ACF RID: 76495
			public EasyTouchTrigger.ETTType triggerType;

			// Token: 0x04012AD0 RID: 76496
			public string name;

			// Token: 0x04012AD1 RID: 76497
			public bool restricted;

			// Token: 0x04012AD2 RID: 76498
			public GameObject gameObject;

			// Token: 0x04012AD3 RID: 76499
			public bool otherReceiver;

			// Token: 0x04012AD4 RID: 76500
			public GameObject gameObjectReceiver;

			// Token: 0x04012AD5 RID: 76501
			public EasyTouch.EvtType eventName;

			// Token: 0x04012AD6 RID: 76502
			public string methodName;

			// Token: 0x04012AD7 RID: 76503
			public EasyTouchTrigger.ETTParameter parameter;
		}
	}
}
