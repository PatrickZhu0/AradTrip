using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A10 RID: 18960
	[RequireComponent(typeof(SkeletonRenderer))]
	public class SkeletonRagdoll2D : MonoBehaviour
	{
		// Token: 0x1700243C RID: 9276
		// (get) Token: 0x0601B5F9 RID: 112121 RVA: 0x008707B1 File Offset: 0x0086EBB1
		// (set) Token: 0x0601B5FA RID: 112122 RVA: 0x008707B9 File Offset: 0x0086EBB9
		public Rigidbody2D RootRigidbody { get; private set; }

		// Token: 0x1700243D RID: 9277
		// (get) Token: 0x0601B5FB RID: 112123 RVA: 0x008707C2 File Offset: 0x0086EBC2
		// (set) Token: 0x0601B5FC RID: 112124 RVA: 0x008707CA File Offset: 0x0086EBCA
		public Bone StartingBone { get; private set; }

		// Token: 0x1700243E RID: 9278
		// (get) Token: 0x0601B5FD RID: 112125 RVA: 0x008707D3 File Offset: 0x0086EBD3
		public Vector3 RootOffset
		{
			get
			{
				return this.rootOffset;
			}
		}

		// Token: 0x1700243F RID: 9279
		// (get) Token: 0x0601B5FE RID: 112126 RVA: 0x008707E0 File Offset: 0x0086EBE0
		public bool IsActive
		{
			get
			{
				return this.isActive;
			}
		}

		// Token: 0x0601B5FF RID: 112127 RVA: 0x008707E8 File Offset: 0x0086EBE8
		private IEnumerator Start()
		{
			if (SkeletonRagdoll2D.parentSpaceHelper == null)
			{
				SkeletonRagdoll2D.parentSpaceHelper = new GameObject("Parent Space Helper").transform;
			}
			this.targetSkeletonComponent = (base.GetComponent<SkeletonRenderer>() as ISkeletonAnimation);
			if (this.targetSkeletonComponent == null)
			{
				Debug.LogError("Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.");
			}
			this.skeleton = this.targetSkeletonComponent.Skeleton;
			if (this.applyOnStart)
			{
				yield return null;
				this.Apply();
			}
			yield break;
		}

		// Token: 0x17002440 RID: 9280
		// (get) Token: 0x0601B600 RID: 112128 RVA: 0x00870804 File Offset: 0x0086EC04
		public Rigidbody2D[] RigidbodyArray
		{
			get
			{
				if (!this.isActive)
				{
					return new Rigidbody2D[0];
				}
				Rigidbody2D[] array = new Rigidbody2D[this.boneTable.Count];
				int num = 0;
				foreach (Transform transform in this.boneTable.Values)
				{
					array[num] = transform.GetComponent<Rigidbody2D>();
					num++;
				}
				return array;
			}
		}

		// Token: 0x17002441 RID: 9281
		// (get) Token: 0x0601B601 RID: 112129 RVA: 0x00870894 File Offset: 0x0086EC94
		public Vector3 EstimatedSkeletonPosition
		{
			get
			{
				return this.RootRigidbody.position - this.rootOffset;
			}
		}

		// Token: 0x0601B602 RID: 112130 RVA: 0x008708B4 File Offset: 0x0086ECB4
		public void Apply()
		{
			this.isActive = true;
			this.mix = 1f;
			Bone bone = this.skeleton.FindBone(this.startingBoneName);
			this.StartingBone = bone;
			Bone bone2 = bone;
			this.RecursivelyCreateBoneProxies(bone2);
			this.RootRigidbody = this.boneTable[bone2].GetComponent<Rigidbody2D>();
			this.RootRigidbody.isKinematic = this.pinStartBone;
			this.RootRigidbody.mass = this.rootMass;
			List<Collider2D> list = new List<Collider2D>();
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				list.Add(value.GetComponent<Collider2D>());
				Transform transform;
				if (key == bone2)
				{
					this.ragdollRoot = new GameObject("RagdollRoot").transform;
					this.ragdollRoot.SetParent(base.transform, false);
					if (key == this.skeleton.RootBone)
					{
						this.ragdollRoot.localPosition = new Vector3(key.WorldX, key.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll2D.GetPropagatedRotation(key));
					}
					else
					{
						this.ragdollRoot.localPosition = new Vector3(key.Parent.WorldX, key.Parent.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll2D.GetPropagatedRotation(key.Parent));
					}
					transform = this.ragdollRoot;
					this.rootOffset = value.position - base.transform.position;
				}
				else
				{
					transform = this.boneTable[key.Parent];
				}
				Rigidbody2D component = transform.GetComponent<Rigidbody2D>();
				if (component != null)
				{
					HingeJoint2D hingeJoint2D = value.gameObject.AddComponent<HingeJoint2D>();
					hingeJoint2D.connectedBody = component;
					Vector3 vector = transform.InverseTransformPoint(value.position);
					hingeJoint2D.connectedAnchor = vector;
					hingeJoint2D.GetComponent<Rigidbody2D>().mass = hingeJoint2D.connectedBody.mass * this.massFalloffFactor;
					HingeJoint2D hingeJoint2D2 = hingeJoint2D;
					JointAngleLimits2D limits = default(JointAngleLimits2D);
					limits.min = -this.rotationLimit;
					limits.max = this.rotationLimit;
					hingeJoint2D2.limits = limits;
					hingeJoint2D.useLimits = true;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (i != j)
					{
						Physics2D.IgnoreCollision(list[i], list[j]);
					}
				}
			}
			SkeletonUtilityBone[] componentsInChildren = base.GetComponentsInChildren<SkeletonUtilityBone>();
			if (componentsInChildren.Length > 0)
			{
				List<string> list2 = new List<string>();
				foreach (SkeletonUtilityBone skeletonUtilityBone in componentsInChildren)
				{
					if (skeletonUtilityBone.mode == SkeletonUtilityBone.Mode.Override)
					{
						list2.Add(skeletonUtilityBone.gameObject.name);
						Object.Destroy(skeletonUtilityBone.gameObject);
					}
				}
				if (list2.Count > 0)
				{
					string text = "Destroyed Utility Bones: ";
					for (int l = 0; l < list2.Count; l++)
					{
						text += list2[l];
						if (l != list2.Count - 1)
						{
							text += ",";
						}
					}
					Debug.LogWarning(text);
				}
			}
			if (this.disableIK)
			{
				ExposedList<IkConstraint> ikConstraints = this.skeleton.IkConstraints;
				int m = 0;
				int count = ikConstraints.Count;
				while (m < count)
				{
					ikConstraints.Items[m].mix = 0f;
					m++;
				}
			}
			if (this.disableOtherConstraints)
			{
				ExposedList<TransformConstraint> transformConstraints = this.skeleton.transformConstraints;
				int n = 0;
				int count2 = transformConstraints.Count;
				while (n < count2)
				{
					transformConstraints.Items[n].rotateMix = 0f;
					transformConstraints.Items[n].scaleMix = 0f;
					transformConstraints.Items[n].shearMix = 0f;
					transformConstraints.Items[n].translateMix = 0f;
					n++;
				}
				ExposedList<PathConstraint> pathConstraints = this.skeleton.pathConstraints;
				int num = 0;
				int count3 = pathConstraints.Count;
				while (num < count3)
				{
					pathConstraints.Items[num].rotateMix = 0f;
					pathConstraints.Items[num].translateMix = 0f;
					num++;
				}
			}
			this.targetSkeletonComponent.UpdateWorld += this.UpdateSpineSkeleton;
		}

		// Token: 0x0601B603 RID: 112131 RVA: 0x00870DD0 File Offset: 0x0086F1D0
		public Coroutine SmoothMix(float target, float duration)
		{
			return base.StartCoroutine(this.SmoothMixCoroutine(target, duration));
		}

		// Token: 0x0601B604 RID: 112132 RVA: 0x00870DE0 File Offset: 0x0086F1E0
		private IEnumerator SmoothMixCoroutine(float target, float duration)
		{
			float startTime = Time.time;
			float startMix = this.mix;
			while (this.mix > 0f)
			{
				this.skeleton.SetBonesToSetupPose();
				this.mix = Mathf.SmoothStep(startMix, target, (Time.time - startTime) / duration);
				yield return null;
			}
			yield break;
		}

		// Token: 0x0601B605 RID: 112133 RVA: 0x00870E0C File Offset: 0x0086F20C
		public void SetSkeletonPosition(Vector3 worldPosition)
		{
			if (!this.isActive)
			{
				Debug.LogWarning("Can't call SetSkeletonPosition while Ragdoll is not active!");
				return;
			}
			Vector3 vector = worldPosition - base.transform.position;
			base.transform.position = worldPosition;
			foreach (Transform transform in this.boneTable.Values)
			{
				transform.position -= vector;
			}
			this.UpdateSpineSkeleton(null);
			this.skeleton.UpdateWorldTransform();
		}

		// Token: 0x0601B606 RID: 112134 RVA: 0x00870EC0 File Offset: 0x0086F2C0
		public void Remove()
		{
			this.isActive = false;
			foreach (Transform transform in this.boneTable.Values)
			{
				Object.Destroy(transform.gameObject);
			}
			Object.Destroy(this.ragdollRoot.gameObject);
			this.boneTable.Clear();
			this.targetSkeletonComponent.UpdateWorld -= this.UpdateSpineSkeleton;
		}

		// Token: 0x0601B607 RID: 112135 RVA: 0x00870F60 File Offset: 0x0086F360
		public Rigidbody2D GetRigidbody(string boneName)
		{
			Bone bone = this.skeleton.FindBone(boneName);
			return (bone == null || !this.boneTable.ContainsKey(bone)) ? null : this.boneTable[bone].GetComponent<Rigidbody2D>();
		}

		// Token: 0x0601B608 RID: 112136 RVA: 0x00870FA8 File Offset: 0x0086F3A8
		private void RecursivelyCreateBoneProxies(Bone b)
		{
			string name = b.data.name;
			if (this.stopBoneNames.Contains(name))
			{
				return;
			}
			GameObject gameObject = new GameObject(name);
			gameObject.layer = this.colliderLayer;
			Transform transform = gameObject.transform;
			this.boneTable.Add(b, transform);
			transform.parent = base.transform;
			transform.localPosition = new Vector3(b.WorldX, b.WorldY, 0f);
			transform.localRotation = Quaternion.Euler(0f, 0f, b.WorldRotationX - b.shearX);
			transform.localScale = new Vector3(b.WorldScaleX, b.WorldScaleY, 0f);
			List<Collider2D> list = SkeletonRagdoll2D.AttachBoundingBoxRagdollColliders(b, gameObject, this.skeleton, this.gravityScale);
			if (list.Count == 0)
			{
				float length = b.data.length;
				if (length == 0f)
				{
					CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
					circleCollider2D.radius = this.thickness * 0.5f;
				}
				else
				{
					BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
					boxCollider2D.size = new Vector2(length, this.thickness);
					boxCollider2D.offset = new Vector2(length * 0.5f, 0f);
				}
			}
			Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
			if (rigidbody2D == null)
			{
				rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
			}
			rigidbody2D.gravityScale = this.gravityScale;
			foreach (Bone b2 in b.Children)
			{
				this.RecursivelyCreateBoneProxies(b2);
			}
		}

		// Token: 0x0601B609 RID: 112137 RVA: 0x0087116C File Offset: 0x0086F56C
		private void UpdateSpineSkeleton(ISkeletonAnimation animatedSkeleton)
		{
			bool flipX = this.skeleton.flipX;
			bool flipY = this.skeleton.flipY;
			bool flag = flipX ^ flipY;
			bool flag2 = flipX || flipY;
			Bone startingBone = this.StartingBone;
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				bool flag3 = key == startingBone;
				Transform transform = (!flag3) ? this.boneTable[key.Parent] : this.ragdollRoot;
				Vector3 position = transform.position;
				Quaternion rotation = transform.rotation;
				SkeletonRagdoll2D.parentSpaceHelper.position = position;
				SkeletonRagdoll2D.parentSpaceHelper.rotation = rotation;
				SkeletonRagdoll2D.parentSpaceHelper.localScale = transform.localScale;
				Vector3 position2 = value.position;
				Vector3 vector = SkeletonRagdoll2D.parentSpaceHelper.InverseTransformDirection(value.right);
				Vector3 vector2 = SkeletonRagdoll2D.parentSpaceHelper.InverseTransformPoint(position2);
				float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
				if (flag2)
				{
					if (flag3)
					{
						if (flipX)
						{
							vector2.x *= -1f;
						}
						if (flipY)
						{
							vector2.y *= -1f;
						}
						num *= ((!flag) ? 1f : -1f);
						if (flipX)
						{
							num += 180f;
						}
					}
					else if (flag)
					{
						num *= -1f;
						vector2.y *= -1f;
					}
				}
				key.x = Mathf.Lerp(key.x, vector2.x, this.mix);
				key.y = Mathf.Lerp(key.y, vector2.y, this.mix);
				key.rotation = Mathf.Lerp(key.rotation, num, this.mix);
			}
		}

		// Token: 0x0601B60A RID: 112138 RVA: 0x008713AC File Offset: 0x0086F7AC
		private static List<Collider2D> AttachBoundingBoxRagdollColliders(Bone b, GameObject go, Skeleton skeleton, float gravityScale)
		{
			List<Collider2D> list = new List<Collider2D>();
			Skin skin = skeleton.Skin ?? skeleton.Data.DefaultSkin;
			List<Attachment> list2 = new List<Attachment>();
			foreach (Slot slot in skeleton.Slots)
			{
				if (slot.bone == b)
				{
					skin.FindAttachmentsForSlot(skeleton.Slots.IndexOf(slot), list2);
					foreach (Attachment attachment in list2)
					{
						BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
						if (boundingBoxAttachment != null)
						{
							if (attachment.Name.ToLower().Contains("ragdoll"))
							{
								PolygonCollider2D item = SkeletonUtility.AddBoundingBoxAsComponent(boundingBoxAttachment, slot, go, false, false, gravityScale);
								list.Add(item);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0601B60B RID: 112139 RVA: 0x008714D0 File Offset: 0x0086F8D0
		private static float GetPropagatedRotation(Bone b)
		{
			Bone parent = b.Parent;
			float num = b.AppliedRotation;
			while (parent != null)
			{
				num += parent.AppliedRotation;
				parent = parent.parent;
			}
			return num;
		}

		// Token: 0x0601B60C RID: 112140 RVA: 0x00871507 File Offset: 0x0086F907
		private static Vector3 FlipScale(bool flipX, bool flipY)
		{
			return new Vector3((!flipX) ? 1f : -1f, (!flipY) ? 1f : -1f, 1f);
		}

		// Token: 0x040130F8 RID: 78072
		private static Transform parentSpaceHelper;

		// Token: 0x040130F9 RID: 78073
		[Header("Hierarchy")]
		[SpineBone("", "", true, false)]
		public string startingBoneName = string.Empty;

		// Token: 0x040130FA RID: 78074
		[SpineBone("", "", true, false)]
		public List<string> stopBoneNames = new List<string>();

		// Token: 0x040130FB RID: 78075
		[Header("Parameters")]
		public bool applyOnStart;

		// Token: 0x040130FC RID: 78076
		[Tooltip("Warning!  You will have to re-enable and tune mix values manually if attempting to remove the ragdoll system.")]
		public bool disableIK = true;

		// Token: 0x040130FD RID: 78077
		public bool disableOtherConstraints;

		// Token: 0x040130FE RID: 78078
		[Space]
		[Tooltip("Set RootRigidbody IsKinematic to true when Apply is called.")]
		public bool pinStartBone;

		// Token: 0x040130FF RID: 78079
		public float gravityScale = 1f;

		// Token: 0x04013100 RID: 78080
		[Tooltip("If no BoundingBox Attachment is attached to a bone, this becomes the default Width or Radius of a Bone's ragdoll Rigidbody")]
		public float thickness = 0.125f;

		// Token: 0x04013101 RID: 78081
		[Tooltip("Default rotational limit value.  Min is negative this value, Max is this value.")]
		public float rotationLimit = 20f;

		// Token: 0x04013102 RID: 78082
		public float rootMass = 20f;

		// Token: 0x04013103 RID: 78083
		[Tooltip("If your ragdoll seems unstable or uneffected by limits, try lowering this value.")]
		[Range(0.01f, 1f)]
		public float massFalloffFactor = 0.4f;

		// Token: 0x04013104 RID: 78084
		[Tooltip("The layer assigned to all of the rigidbody parts.")]
		[SkeletonRagdoll.LayerFieldAttribute]
		public int colliderLayer;

		// Token: 0x04013105 RID: 78085
		[Range(0f, 1f)]
		public float mix = 1f;

		// Token: 0x04013106 RID: 78086
		private ISkeletonAnimation targetSkeletonComponent;

		// Token: 0x04013107 RID: 78087
		private Skeleton skeleton;

		// Token: 0x04013108 RID: 78088
		private Dictionary<Bone, Transform> boneTable = new Dictionary<Bone, Transform>();

		// Token: 0x04013109 RID: 78089
		private Transform ragdollRoot;

		// Token: 0x0401310C RID: 78092
		private Vector2 rootOffset;

		// Token: 0x0401310D RID: 78093
		private bool isActive;
	}
}
