using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A2B RID: 18987
	[RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteInEditMode]
	public abstract class SkeletonUtilityConstraint : MonoBehaviour
	{
		// Token: 0x0601B6E8 RID: 112360 RVA: 0x00872BFC File Offset: 0x00870FFC
		protected virtual void OnEnable()
		{
			this.utilBone = base.GetComponent<SkeletonUtilityBone>();
			this.skeletonUtility = base.transform.GetComponentInParent<SkeletonUtility>();
			this.skeletonUtility.RegisterConstraint(this);
		}

		// Token: 0x0601B6E9 RID: 112361 RVA: 0x00872C27 File Offset: 0x00871027
		protected virtual void OnDisable()
		{
			this.skeletonUtility.UnregisterConstraint(this);
		}

		// Token: 0x0601B6EA RID: 112362
		public abstract void DoUpdate();

		// Token: 0x04013193 RID: 78227
		protected SkeletonUtilityBone utilBone;

		// Token: 0x04013194 RID: 78228
		protected SkeletonUtility skeletonUtility;
	}
}
