using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A11 RID: 18961
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("Spine/UI/BoneFollowerGraphic")]
	public class BoneFollowerGraphic : MonoBehaviour
	{
		// Token: 0x17002442 RID: 9282
		// (get) Token: 0x0601B60E RID: 112142 RVA: 0x0087176F File Offset: 0x0086FB6F
		// (set) Token: 0x0601B60F RID: 112143 RVA: 0x00871777 File Offset: 0x0086FB77
		public SkeletonGraphic SkeletonGraphic
		{
			get
			{
				return this.skeletonGraphic;
			}
			set
			{
				this.skeletonGraphic = value;
				this.Initialize();
			}
		}

		// Token: 0x0601B610 RID: 112144 RVA: 0x00871786 File Offset: 0x0086FB86
		public bool SetBone(string name)
		{
			this.bone = this.skeletonGraphic.Skeleton.FindBone(name);
			if (this.bone == null)
			{
				Debug.LogError("Bone not found: " + name, this);
				return false;
			}
			this.boneName = name;
			return true;
		}

		// Token: 0x0601B611 RID: 112145 RVA: 0x008717C5 File Offset: 0x0086FBC5
		public void Awake()
		{
			if (this.initializeOnAwake)
			{
				this.Initialize();
			}
		}

		// Token: 0x0601B612 RID: 112146 RVA: 0x008717D8 File Offset: 0x0086FBD8
		public void Initialize()
		{
			this.bone = null;
			this.valid = (this.skeletonGraphic != null && this.skeletonGraphic.IsValid);
			if (!this.valid)
			{
				return;
			}
			this.skeletonTransform = this.skeletonGraphic.transform;
			this.skeletonTransformIsParent = object.ReferenceEquals(this.skeletonTransform, base.transform.parent);
			if (!string.IsNullOrEmpty(this.boneName))
			{
				this.bone = this.skeletonGraphic.Skeleton.FindBone(this.boneName);
			}
		}

		// Token: 0x0601B613 RID: 112147 RVA: 0x00871878 File Offset: 0x0086FC78
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
				this.bone = this.skeletonGraphic.Skeleton.FindBone(this.boneName);
				if (!this.SetBone(this.boneName))
				{
					return;
				}
			}
			RectTransform rectTransform = base.transform as RectTransform;
			if (rectTransform == null)
			{
				return;
			}
			Canvas canvas = this.skeletonGraphic.canvas;
			if (canvas == null)
			{
				canvas = this.skeletonGraphic.GetComponentInParent<Canvas>();
			}
			float referencePixelsPerUnit = canvas.referencePixelsPerUnit;
			if (this.skeletonTransformIsParent)
			{
				rectTransform.localPosition = new Vector3(this.bone.worldX * referencePixelsPerUnit, this.bone.worldY * referencePixelsPerUnit, (!this.followZPosition) ? rectTransform.localPosition.z : 0f);
				if (this.followBoneRotation)
				{
					rectTransform.localRotation = this.bone.GetQuaternion();
				}
			}
			else
			{
				Vector3 vector = this.skeletonTransform.TransformPoint(new Vector3(this.bone.worldX * referencePixelsPerUnit, this.bone.worldY * referencePixelsPerUnit, 0f));
				if (!this.followZPosition)
				{
					vector.z = rectTransform.position.z;
				}
				float num = this.bone.WorldRotationX;
				Transform parent = rectTransform.parent;
				if (parent != null)
				{
					Matrix4x4 localToWorldMatrix = parent.localToWorldMatrix;
					if (localToWorldMatrix.m00 * localToWorldMatrix.m11 - localToWorldMatrix.m01 * localToWorldMatrix.m10 < 0f)
					{
						num = -num;
					}
				}
				if (this.followBoneRotation)
				{
					Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
					rectTransform.SetPositionAndRotation(vector, Quaternion.Euler(eulerAngles.x, eulerAngles.y, this.skeletonTransform.rotation.eulerAngles.z + num));
				}
				else
				{
					rectTransform.position = vector;
				}
			}
			Vector3 localScale = (!this.followLocalScale) ? new Vector3(1f, 1f, 1f) : new Vector3(this.bone.scaleX, this.bone.scaleY, 1f);
			if (this.followSkeletonFlip)
			{
				localScale.y *= ((!(this.bone.skeleton.flipX ^ this.bone.skeleton.flipY)) ? 1f : -1f);
			}
			rectTransform.localScale = localScale;
		}

		// Token: 0x0401310E RID: 78094
		public SkeletonGraphic skeletonGraphic;

		// Token: 0x0401310F RID: 78095
		public bool initializeOnAwake = true;

		// Token: 0x04013110 RID: 78096
		[SpineBone("", "skeletonGraphic", true, false)]
		[SerializeField]
		public string boneName;

		// Token: 0x04013111 RID: 78097
		public bool followBoneRotation = true;

		// Token: 0x04013112 RID: 78098
		[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
		public bool followSkeletonFlip = true;

		// Token: 0x04013113 RID: 78099
		[Tooltip("Follows the target bone's local scale. BoneFollower cannot inherit world/skewed scale because of UnityEngine.Transform property limitations.")]
		public bool followLocalScale;

		// Token: 0x04013114 RID: 78100
		public bool followZPosition = true;

		// Token: 0x04013115 RID: 78101
		[NonSerialized]
		public Bone bone;

		// Token: 0x04013116 RID: 78102
		private Transform skeletonTransform;

		// Token: 0x04013117 RID: 78103
		private bool skeletonTransformIsParent;

		// Token: 0x04013118 RID: 78104
		[NonSerialized]
		public bool valid;
	}
}
