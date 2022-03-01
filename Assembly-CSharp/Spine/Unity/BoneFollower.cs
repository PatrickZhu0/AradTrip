using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity
{
	// Token: 0x020049E7 RID: 18919
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/BoneFollower")]
	public class BoneFollower : MonoBehaviour
	{
		// Token: 0x1700241A RID: 9242
		// (get) Token: 0x0601B4B8 RID: 111800 RVA: 0x00866AA6 File Offset: 0x00864EA6
		// (set) Token: 0x0601B4B9 RID: 111801 RVA: 0x00866AAE File Offset: 0x00864EAE
		public SkeletonRenderer SkeletonRenderer
		{
			get
			{
				return this.skeletonRenderer;
			}
			set
			{
				this.skeletonRenderer = value;
				this.Initialize();
			}
		}

		// Token: 0x0601B4BA RID: 111802 RVA: 0x00866ABD File Offset: 0x00864EBD
		public bool SetBone(string name)
		{
			this.bone = this.skeletonRenderer.skeleton.FindBone(name);
			if (this.bone == null)
			{
				Debug.LogError("Bone not found: " + name, this);
				return false;
			}
			this.boneName = name;
			return true;
		}

		// Token: 0x0601B4BB RID: 111803 RVA: 0x00866AFC File Offset: 0x00864EFC
		public void Awake()
		{
			if (this.initializeOnAwake)
			{
				this.Initialize();
			}
		}

		// Token: 0x0601B4BC RID: 111804 RVA: 0x00866B0F File Offset: 0x00864F0F
		public void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer)
		{
			this.Initialize();
		}

		// Token: 0x0601B4BD RID: 111805 RVA: 0x00866B18 File Offset: 0x00864F18
		public void Initialize()
		{
			this.bone = null;
			this.valid = (this.skeletonRenderer != null && this.skeletonRenderer.valid);
			if (!this.valid)
			{
				return;
			}
			this.skeletonTransform = this.skeletonRenderer.transform;
			this.skeletonRenderer.OnRebuild -= this.HandleRebuildRenderer;
			this.skeletonRenderer.OnRebuild += this.HandleRebuildRenderer;
			this.skeletonTransformIsParent = object.ReferenceEquals(this.skeletonTransform, base.transform.parent);
			if (!string.IsNullOrEmpty(this.boneName))
			{
				this.bone = this.skeletonRenderer.skeleton.FindBone(this.boneName);
			}
		}

		// Token: 0x0601B4BE RID: 111806 RVA: 0x00866BE4 File Offset: 0x00864FE4
		private void OnDestroy()
		{
			if (this.skeletonRenderer != null)
			{
				this.skeletonRenderer.OnRebuild -= this.HandleRebuildRenderer;
			}
		}

		// Token: 0x0601B4BF RID: 111807 RVA: 0x00866C10 File Offset: 0x00865010
		public void LateUpdate()
		{
			if (!this.valid)
			{
				this.Initialize();
				return;
			}
			if (this.bone == null)
			{
				if (string.IsNullOrEmpty(this.boneName))
				{
					return;
				}
				this.bone = this.skeletonRenderer.skeleton.FindBone(this.boneName);
				if (!this.SetBone(this.boneName))
				{
					return;
				}
			}
			Transform transform = base.transform;
			if (this.skeletonTransformIsParent)
			{
				transform.localPosition = new Vector3(this.bone.worldX, this.bone.worldY, (!this.followZPosition) ? transform.localPosition.z : 0f);
				if (this.followBoneRotation)
				{
					float num = Mathf.Atan2(this.bone.c, this.bone.a) * 0.5f;
					if (this.followLocalScale && this.bone.scaleX < 0f)
					{
						num += 1.5707964f;
					}
					Quaternion localRotation = default(Quaternion);
					localRotation.z = Mathf.Sin(num);
					localRotation.w = Mathf.Cos(num);
					transform.localRotation = localRotation;
				}
			}
			else
			{
				Vector3 vector = this.skeletonTransform.TransformPoint(new Vector3(this.bone.worldX, this.bone.worldY, 0f));
				if (!this.followZPosition)
				{
					vector.z = transform.position.z;
				}
				float num2 = this.bone.WorldRotationX;
				Transform parent = transform.parent;
				if (parent != null)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					if (localToWorldMatrix.m00 * localToWorldMatrix.m11 - localToWorldMatrix.m01 * localToWorldMatrix.m10 < 0f)
					{
						num2 = -num2;
					}
				}
				if (this.followBoneRotation)
				{
					Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
					if (this.followLocalScale && this.bone.scaleX < 0f)
					{
						num2 += 180f;
					}
					transform.SetPositionAndRotation(vector, Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + num2));
				}
				else
				{
					transform.position = vector;
				}
			}
			Vector3 localScale = (!this.followLocalScale) ? new Vector3(1f, 1f, 1f) : new Vector3(this.bone.scaleX, this.bone.scaleY, 1f);
			if (this.followSkeletonFlip)
			{
				localScale.y *= ((!(this.bone.skeleton.flipX ^ this.bone.skeleton.flipY)) ? 1f : -1f);
			}
			transform.localScale = localScale;
		}

		// Token: 0x04013027 RID: 77863
		public SkeletonRenderer skeletonRenderer;

		// Token: 0x04013028 RID: 77864
		[SpineBone("", "skeletonRenderer", true, false)]
		[SerializeField]
		public string boneName;

		// Token: 0x04013029 RID: 77865
		public bool followZPosition = true;

		// Token: 0x0401302A RID: 77866
		public bool followBoneRotation = true;

		// Token: 0x0401302B RID: 77867
		[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
		public bool followSkeletonFlip = true;

		// Token: 0x0401302C RID: 77868
		[Tooltip("Follows the target bone's local scale. BoneFollower cannot inherit world/skewed scale because of UnityEngine.Transform property limitations.")]
		public bool followLocalScale;

		// Token: 0x0401302D RID: 77869
		[FormerlySerializedAs("resetOnAwake")]
		public bool initializeOnAwake = true;

		// Token: 0x0401302E RID: 77870
		[NonSerialized]
		public bool valid;

		// Token: 0x0401302F RID: 77871
		[NonSerialized]
		public Bone bone;

		// Token: 0x04013030 RID: 77872
		private Transform skeletonTransform;

		// Token: 0x04013031 RID: 77873
		private bool skeletonTransformIsParent;
	}
}
