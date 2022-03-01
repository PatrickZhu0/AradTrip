using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048FD RID: 18685
	public class BaseFinger
	{
		// Token: 0x0601ADDA RID: 110042 RVA: 0x00843BA0 File Offset: 0x00841FA0
		public Gesture GetGesture()
		{
			return new Gesture
			{
				fingerIndex = this.fingerIndex,
				touchCount = this.touchCount,
				startPosition = this.startPosition,
				position = this.position,
				deltaPosition = this.deltaPosition,
				actionTime = this.actionTime,
				deltaTime = this.deltaTime,
				isOverGui = this.isOverGui,
				pickedCamera = this.pickedCamera,
				pickedObject = this.pickedObject,
				isGuiCamera = this.isGuiCamera,
				pickedUIElement = this.pickedUIElement
			};
		}

		// Token: 0x04012B4E RID: 76622
		public int fingerIndex;

		// Token: 0x04012B4F RID: 76623
		public int touchCount;

		// Token: 0x04012B50 RID: 76624
		public Vector2 startPosition;

		// Token: 0x04012B51 RID: 76625
		public Vector2 position;

		// Token: 0x04012B52 RID: 76626
		public Vector2 deltaPosition;

		// Token: 0x04012B53 RID: 76627
		public float actionTime;

		// Token: 0x04012B54 RID: 76628
		public float deltaTime;

		// Token: 0x04012B55 RID: 76629
		public Camera pickedCamera;

		// Token: 0x04012B56 RID: 76630
		public GameObject pickedObject;

		// Token: 0x04012B57 RID: 76631
		public bool isGuiCamera;

		// Token: 0x04012B58 RID: 76632
		public bool isOverGui;

		// Token: 0x04012B59 RID: 76633
		public GameObject pickedUIElement;
	}
}
