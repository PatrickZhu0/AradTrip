using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048E7 RID: 18663
	[AddComponentMenu("EasyTouch/Quick LongTap")]
	public class QuickLongTap : QuickBase
	{
		// Token: 0x0601ADA9 RID: 109993 RVA: 0x00842928 File Offset: 0x00840D28
		public QuickLongTap()
		{
			this.quickActionName = "QuickLongTap" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601ADAA RID: 109994 RVA: 0x00842960 File Offset: 0x00840D60
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (!this.is2Finger)
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.fingerIndex == -1 && this.IsOverMe(this.currentGesture))
				{
					this.fingerIndex = this.currentGesture.fingerIndex;
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapStart && this.actionTriggering == QuickLongTap.ActionTriggering.Start && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTap && this.actionTriggering == QuickLongTap.ActionTriggering.InProgress && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapEnd && this.actionTriggering == QuickLongTap.ActionTriggering.End && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
					this.fingerIndex = -1;
				}
			}
			else
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapStart2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.Start)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTap2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.InProgress)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapEnd2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.End)
				{
					this.DoAction(this.currentGesture);
				}
			}
		}

		// Token: 0x0601ADAB RID: 109995 RVA: 0x00842B28 File Offset: 0x00840F28
		private void DoAction(Gesture gesture)
		{
			if (this.IsOverMe(gesture))
			{
				this.onLongTap.Invoke(gesture);
			}
		}

		// Token: 0x0601ADAC RID: 109996 RVA: 0x00842B44 File Offset: 0x00840F44
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

		// Token: 0x04012B08 RID: 76552
		[SerializeField]
		public QuickLongTap.OnLongTap onLongTap;

		// Token: 0x04012B09 RID: 76553
		public QuickLongTap.ActionTriggering actionTriggering;

		// Token: 0x04012B0A RID: 76554
		private Gesture currentGesture;

		// Token: 0x020048E8 RID: 18664
		[Serializable]
		public class OnLongTap : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048E9 RID: 18665
		public enum ActionTriggering
		{
			// Token: 0x04012B0C RID: 76556
			Start,
			// Token: 0x04012B0D RID: 76557
			InProgress,
			// Token: 0x04012B0E RID: 76558
			End
		}
	}
}
