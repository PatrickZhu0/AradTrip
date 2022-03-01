using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A17 RID: 18967
	[RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteInEditMode]
	public class SkeletonUtilityGroundConstraint : SkeletonUtilityConstraint
	{
		// Token: 0x0601B651 RID: 112209 RVA: 0x00872E3C File Offset: 0x0087123C
		protected override void OnEnable()
		{
			base.OnEnable();
			this.lastHitY = base.transform.position.y;
		}

		// Token: 0x0601B652 RID: 112210 RVA: 0x00872E68 File Offset: 0x00871268
		public override void DoUpdate()
		{
			this.rayOrigin = base.transform.position + new Vector3(this.castOffset, this.castDistance, 0f);
			this.hitY = float.MinValue;
			if (this.use2D)
			{
				RaycastHit2D raycastHit2D;
				if (this.useRadius)
				{
					raycastHit2D = Physics2D.CircleCast(this.rayOrigin, this.castRadius, this.rayDir, this.castDistance + this.groundOffset, this.groundMask);
				}
				else
				{
					raycastHit2D = Physics2D.Raycast(this.rayOrigin, this.rayDir, this.castDistance + this.groundOffset, this.groundMask);
				}
				if (raycastHit2D.collider != null)
				{
					this.hitY = raycastHit2D.point.y + this.groundOffset;
					if (Application.isPlaying)
					{
						this.hitY = Mathf.MoveTowards(this.lastHitY, this.hitY, this.adjustSpeed * Time.deltaTime);
					}
				}
				else if (Application.isPlaying)
				{
					this.hitY = Mathf.MoveTowards(this.lastHitY, base.transform.position.y, this.adjustSpeed * Time.deltaTime);
				}
			}
			else
			{
				RaycastHit raycastHit;
				bool flag;
				if (this.useRadius)
				{
					flag = Physics.SphereCast(this.rayOrigin, this.castRadius, this.rayDir, ref raycastHit, this.castDistance + this.groundOffset, this.groundMask);
				}
				else
				{
					flag = Physics.Raycast(this.rayOrigin, this.rayDir, ref raycastHit, this.castDistance + this.groundOffset, this.groundMask);
				}
				if (flag)
				{
					this.hitY = raycastHit.point.y + this.groundOffset;
					if (Application.isPlaying)
					{
						this.hitY = Mathf.MoveTowards(this.lastHitY, this.hitY, this.adjustSpeed * Time.deltaTime);
					}
				}
				else if (Application.isPlaying)
				{
					this.hitY = Mathf.MoveTowards(this.lastHitY, base.transform.position.y, this.adjustSpeed * Time.deltaTime);
				}
			}
			Vector3 position = base.transform.position;
			position.y = Mathf.Clamp(position.y, Mathf.Min(this.lastHitY, this.hitY), float.MaxValue);
			base.transform.position = position;
			this.utilBone.bone.X = base.transform.localPosition.x;
			this.utilBone.bone.Y = base.transform.localPosition.y;
			this.lastHitY = this.hitY;
		}

		// Token: 0x0601B653 RID: 112211 RVA: 0x00873170 File Offset: 0x00871570
		private void OnDrawGizmos()
		{
			Vector3 vector = this.rayOrigin + this.rayDir * Mathf.Min(this.castDistance, this.rayOrigin.y - this.hitY);
			Vector3 vector2 = this.rayOrigin + this.rayDir * this.castDistance;
			Gizmos.DrawLine(this.rayOrigin, vector);
			if (this.useRadius)
			{
				Gizmos.DrawLine(new Vector3(vector.x - this.castRadius, vector.y - this.groundOffset, vector.z), new Vector3(vector.x + this.castRadius, vector.y - this.groundOffset, vector.z));
				Gizmos.DrawLine(new Vector3(vector2.x - this.castRadius, vector2.y, vector2.z), new Vector3(vector2.x + this.castRadius, vector2.y, vector2.z));
			}
			Gizmos.color = Color.red;
			Gizmos.DrawLine(vector, vector2);
		}

		// Token: 0x04013146 RID: 78150
		[Tooltip("LayerMask for what objects to raycast against")]
		public LayerMask groundMask;

		// Token: 0x04013147 RID: 78151
		[Tooltip("Use 2D")]
		public bool use2D;

		// Token: 0x04013148 RID: 78152
		[Tooltip("Uses SphereCast for 3D mode and CircleCast for 2D mode")]
		public bool useRadius;

		// Token: 0x04013149 RID: 78153
		[Tooltip("The Radius")]
		public float castRadius = 0.1f;

		// Token: 0x0401314A RID: 78154
		[Tooltip("How high above the target bone to begin casting from")]
		public float castDistance = 5f;

		// Token: 0x0401314B RID: 78155
		[Tooltip("X-Axis adjustment")]
		public float castOffset;

		// Token: 0x0401314C RID: 78156
		[Tooltip("Y-Axis adjustment")]
		public float groundOffset;

		// Token: 0x0401314D RID: 78157
		[Tooltip("How fast the target IK position adjusts to the ground.  Use smaller values to prevent snapping")]
		public float adjustSpeed = 5f;

		// Token: 0x0401314E RID: 78158
		private Vector3 rayOrigin;

		// Token: 0x0401314F RID: 78159
		private Vector3 rayDir = new Vector3(0f, -1f, 0f);

		// Token: 0x04013150 RID: 78160
		private float hitY;

		// Token: 0x04013151 RID: 78161
		private float lastHitY;
	}
}
