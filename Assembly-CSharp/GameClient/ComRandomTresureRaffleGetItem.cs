using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020019C9 RID: 6601
	[Serializable]
	public class ComRandomTresureRaffleGetItem
	{
		// Token: 0x0400A336 RID: 41782
		public GameObject getItemGo;

		// Token: 0x0400A337 RID: 41783
		public RectTransform getItemRect;

		// Token: 0x0400A338 RID: 41784
		public float getItemTweenDuration;

		// Token: 0x0400A339 RID: 41785
		public float getItemTweenDelay;

		// Token: 0x0400A33A RID: 41786
		public Ease getItemPosTweenEase;

		// Token: 0x0400A33B RID: 41787
		public Vector2 getItemTargetPos;

		// Token: 0x0400A33C RID: 41788
		public Vector2 getItemInitPos;

		// Token: 0x0400A33D RID: 41789
		public List<DOTweenAnimation> getItemIconTweens;
	}
}
