using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A16 RID: 18966
	public class SkeletonUtilityEyeConstraint : SkeletonUtilityConstraint
	{
		// Token: 0x0601B64D RID: 112205 RVA: 0x00872C54 File Offset: 0x00871054
		protected override void OnEnable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			base.OnEnable();
			Bounds bounds;
			bounds..ctor(this.eyes[0].localPosition, Vector3.zero);
			this.origins = new Vector3[this.eyes.Length];
			for (int i = 0; i < this.eyes.Length; i++)
			{
				this.origins[i] = this.eyes[i].localPosition;
				bounds.Encapsulate(this.origins[i]);
			}
			this.centerPoint = bounds.center;
		}

		// Token: 0x0601B64E RID: 112206 RVA: 0x00872CFA File Offset: 0x008710FA
		protected override void OnDisable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			base.OnDisable();
		}

		// Token: 0x0601B64F RID: 112207 RVA: 0x00872D10 File Offset: 0x00871110
		public override void DoUpdate()
		{
			if (this.target != null)
			{
				this.targetPosition = this.target.position;
			}
			Vector3 vector = this.targetPosition;
			Vector3 vector2 = base.transform.TransformPoint(this.centerPoint);
			Vector3 vector3 = vector - vector2;
			if (vector3.magnitude > 1f)
			{
				vector3.Normalize();
			}
			for (int i = 0; i < this.eyes.Length; i++)
			{
				vector2 = base.transform.TransformPoint(this.origins[i]);
				this.eyes[i].position = Vector3.MoveTowards(this.eyes[i].position, vector2 + vector3 * this.radius, this.speed * Time.deltaTime);
			}
		}

		// Token: 0x0401313F RID: 78143
		public Transform[] eyes;

		// Token: 0x04013140 RID: 78144
		public float radius = 0.5f;

		// Token: 0x04013141 RID: 78145
		public Transform target;

		// Token: 0x04013142 RID: 78146
		public Vector3 targetPosition;

		// Token: 0x04013143 RID: 78147
		public float speed = 10f;

		// Token: 0x04013144 RID: 78148
		private Vector3[] origins;

		// Token: 0x04013145 RID: 78149
		private Vector3 centerPoint;
	}
}
