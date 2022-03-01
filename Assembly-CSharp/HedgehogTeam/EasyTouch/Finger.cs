using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02004930 RID: 18736
	public class Finger : BaseFinger
	{
		// Token: 0x04012C0F RID: 76815
		public float startTimeAction;

		// Token: 0x04012C10 RID: 76816
		public Vector2 oldPosition;

		// Token: 0x04012C11 RID: 76817
		public int tapCount;

		// Token: 0x04012C12 RID: 76818
		public TouchPhase phase;

		// Token: 0x04012C13 RID: 76819
		public EasyTouch.GestureType gesture;

		// Token: 0x04012C14 RID: 76820
		public EasyTouch.SwipeDirection oldSwipeType;
	}
}
