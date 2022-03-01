using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E8 RID: 18920
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/Point Follower")]
	public class PointFollower : MonoBehaviour, IHasSkeletonRenderer, IHasSkeletonComponent
	{
		// Token: 0x1700241B RID: 9243
		// (get) Token: 0x0601B4C1 RID: 111809 RVA: 0x00866F2B File Offset: 0x0086532B
		public SkeletonRenderer SkeletonRenderer
		{
			get
			{
				return this.skeletonRenderer;
			}
		}

		// Token: 0x1700241C RID: 9244
		// (get) Token: 0x0601B4C2 RID: 111810 RVA: 0x00866F33 File Offset: 0x00865333
		public ISkeletonComponent SkeletonComponent
		{
			get
			{
				return this.skeletonRenderer;
			}
		}

		// Token: 0x1700241D RID: 9245
		// (get) Token: 0x0601B4C3 RID: 111811 RVA: 0x00866F3B File Offset: 0x0086533B
		public bool IsValid
		{
			get
			{
				return this.valid;
			}
		}

		// Token: 0x0601B4C4 RID: 111812 RVA: 0x00866F43 File Offset: 0x00865343
		public void Initialize()
		{
			this.valid = (this.skeletonRenderer != null && this.skeletonRenderer.valid);
			if (!this.valid)
			{
				return;
			}
			this.UpdateReferences();
		}

		// Token: 0x0601B4C5 RID: 111813 RVA: 0x00866F7C File Offset: 0x0086537C
		private void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer)
		{
			this.Initialize();
		}

		// Token: 0x0601B4C6 RID: 111814 RVA: 0x00866F84 File Offset: 0x00865384
		private void UpdateReferences()
		{
			this.skeletonTransform = this.skeletonRenderer.transform;
			this.skeletonRenderer.OnRebuild -= this.HandleRebuildRenderer;
			this.skeletonRenderer.OnRebuild += this.HandleRebuildRenderer;
			this.skeletonTransformIsParent = object.ReferenceEquals(this.skeletonTransform, base.transform.parent);
			this.bone = null;
			this.point = null;
			if (!string.IsNullOrEmpty(this.pointAttachmentName))
			{
				Skeleton skeleton = this.skeletonRenderer.skeleton;
				int num = skeleton.FindSlotIndex(this.slotName);
				if (num >= 0)
				{
					Slot slot = skeleton.slots.Items[num];
					this.bone = slot.bone;
					this.point = (skeleton.GetAttachment(num, this.pointAttachmentName) as PointAttachment);
				}
			}
		}

		// Token: 0x0601B4C7 RID: 111815 RVA: 0x0086705C File Offset: 0x0086545C
		public void LateUpdate()
		{
			if (this.point == null)
			{
				if (string.IsNullOrEmpty(this.pointAttachmentName))
				{
					return;
				}
				this.UpdateReferences();
				if (this.point == null)
				{
					return;
				}
			}
			Vector2 vector;
			this.point.ComputeWorldPosition(this.bone, out vector.x, out vector.y);
			float num = this.point.ComputeWorldRotation(this.bone);
			Transform transform = base.transform;
			if (this.skeletonTransformIsParent)
			{
				transform.localPosition = new Vector3(vector.x, vector.y, (!this.followSkeletonZPosition) ? transform.localPosition.z : 0f);
				if (this.followRotation)
				{
					float num2 = num * 0.5f * 0.017453292f;
					Quaternion localRotation = default(Quaternion);
					localRotation.z = Mathf.Sin(num2);
					localRotation.w = Mathf.Cos(num2);
					transform.localRotation = localRotation;
				}
			}
			else
			{
				Vector3 vector2 = this.skeletonTransform.TransformPoint(new Vector3(vector.x, vector.y, 0f));
				if (!this.followSkeletonZPosition)
				{
					vector2.z = transform.position.z;
				}
				Transform parent = transform.parent;
				if (parent != null)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					if (localToWorldMatrix.m00 * localToWorldMatrix.m11 - localToWorldMatrix.m01 * localToWorldMatrix.m10 < 0f)
					{
						num = -num;
					}
				}
				if (this.followRotation)
				{
					Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
					transform.SetPositionAndRotation(vector2, Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + num));
				}
				else
				{
					transform.position = vector2;
				}
			}
			if (this.followSkeletonFlip)
			{
				Vector3 localScale = transform.localScale;
				localScale.y = Mathf.Abs(localScale.y) * ((!(this.bone.skeleton.flipX ^ this.bone.skeleton.flipY)) ? 1f : -1f);
				transform.localScale = localScale;
			}
		}

		// Token: 0x04013032 RID: 77874
		[SerializeField]
		public SkeletonRenderer skeletonRenderer;

		// Token: 0x04013033 RID: 77875
		[SpineSlot("", "skeletonRenderer", false, true, false)]
		public string slotName;

		// Token: 0x04013034 RID: 77876
		[SpineAttachment(true, false, false, "slotName", "skeletonRenderer", "", true, true)]
		public string pointAttachmentName;

		// Token: 0x04013035 RID: 77877
		public bool followRotation = true;

		// Token: 0x04013036 RID: 77878
		public bool followSkeletonFlip = true;

		// Token: 0x04013037 RID: 77879
		public bool followSkeletonZPosition;

		// Token: 0x04013038 RID: 77880
		private Transform skeletonTransform;

		// Token: 0x04013039 RID: 77881
		private bool skeletonTransformIsParent;

		// Token: 0x0401303A RID: 77882
		private PointAttachment point;

		// Token: 0x0401303B RID: 77883
		private Bone bone;

		// Token: 0x0401303C RID: 77884
		private bool valid;
	}
}
