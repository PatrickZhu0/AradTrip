using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02004932 RID: 18738
	public class TwoFingerGesture
	{
		// Token: 0x0601AF37 RID: 110391 RVA: 0x00849771 File Offset: 0x00847B71
		public void ClearPickedObjectData()
		{
			this.pickedObject = null;
			this.oldPickedObject = null;
			this.pickedCamera = null;
			this.isGuiCamera = false;
		}

		// Token: 0x0601AF38 RID: 110392 RVA: 0x0084978F File Offset: 0x00847B8F
		public void ClearPickedUIData()
		{
			this.isOverGui = false;
			this.pickedUIElement = null;
		}

		// Token: 0x04012C1C RID: 76828
		public EasyTouch.GestureType currentGesture = EasyTouch.GestureType.None;

		// Token: 0x04012C1D RID: 76829
		public EasyTouch.GestureType oldGesture = EasyTouch.GestureType.None;

		// Token: 0x04012C1E RID: 76830
		public int finger0;

		// Token: 0x04012C1F RID: 76831
		public int finger1;

		// Token: 0x04012C20 RID: 76832
		public float startTimeAction;

		// Token: 0x04012C21 RID: 76833
		public float timeSinceStartAction;

		// Token: 0x04012C22 RID: 76834
		public Vector2 startPosition;

		// Token: 0x04012C23 RID: 76835
		public Vector2 position;

		// Token: 0x04012C24 RID: 76836
		public Vector2 deltaPosition;

		// Token: 0x04012C25 RID: 76837
		public Vector2 oldStartPosition;

		// Token: 0x04012C26 RID: 76838
		public float startDistance;

		// Token: 0x04012C27 RID: 76839
		public float fingerDistance;

		// Token: 0x04012C28 RID: 76840
		public float oldFingerDistance;

		// Token: 0x04012C29 RID: 76841
		public bool lockPinch;

		// Token: 0x04012C2A RID: 76842
		public bool lockTwist = true;

		// Token: 0x04012C2B RID: 76843
		public float lastPinch;

		// Token: 0x04012C2C RID: 76844
		public float lastTwistAngle;

		// Token: 0x04012C2D RID: 76845
		public GameObject pickedObject;

		// Token: 0x04012C2E RID: 76846
		public GameObject oldPickedObject;

		// Token: 0x04012C2F RID: 76847
		public Camera pickedCamera;

		// Token: 0x04012C30 RID: 76848
		public bool isGuiCamera;

		// Token: 0x04012C31 RID: 76849
		public bool isOverGui;

		// Token: 0x04012C32 RID: 76850
		public GameObject pickedUIElement;

		// Token: 0x04012C33 RID: 76851
		public bool dragStart;

		// Token: 0x04012C34 RID: 76852
		public bool swipeStart;

		// Token: 0x04012C35 RID: 76853
		public bool inSingleDoubleTaps;

		// Token: 0x04012C36 RID: 76854
		public float tapCurentTime;
	}
}
