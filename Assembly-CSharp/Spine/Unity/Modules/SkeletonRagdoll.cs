using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A0E RID: 18958
	[RequireComponent(typeof(SkeletonRenderer))]
	public class SkeletonRagdoll : MonoBehaviour
	{
		// Token: 0x17002436 RID: 9270
		// (get) Token: 0x0601B5E4 RID: 112100 RVA: 0x0086F779 File Offset: 0x0086DB79
		// (set) Token: 0x0601B5E5 RID: 112101 RVA: 0x0086F781 File Offset: 0x0086DB81
		public Rigidbody RootRigidbody { get; private set; }

		// Token: 0x17002437 RID: 9271
		// (get) Token: 0x0601B5E6 RID: 112102 RVA: 0x0086F78A File Offset: 0x0086DB8A
		// (set) Token: 0x0601B5E7 RID: 112103 RVA: 0x0086F792 File Offset: 0x0086DB92
		public Bone StartingBone { get; private set; }

		// Token: 0x17002438 RID: 9272
		// (get) Token: 0x0601B5E8 RID: 112104 RVA: 0x0086F79B File Offset: 0x0086DB9B
		public Vector3 RootOffset
		{
			get
			{
				return this.rootOffset;
			}
		}

		// Token: 0x17002439 RID: 9273
		// (get) Token: 0x0601B5E9 RID: 112105 RVA: 0x0086F7A3 File Offset: 0x0086DBA3
		public bool IsActive
		{
			get
			{
				return this.isActive;
			}
		}

		// Token: 0x0601B5EA RID: 112106 RVA: 0x0086F7AC File Offset: 0x0086DBAC
		private IEnumerator Start()
		{
			if (SkeletonRagdoll.parentSpaceHelper == null)
			{
				SkeletonRagdoll.parentSpaceHelper = new GameObject("Parent Space Helper").transform;
				SkeletonRagdoll.parentSpaceHelper.hideFlags = 1;
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

		// Token: 0x1700243A RID: 9274
		// (get) Token: 0x0601B5EB RID: 112107 RVA: 0x0086F7C8 File Offset: 0x0086DBC8
		public Rigidbody[] RigidbodyArray
		{
			get
			{
				if (!this.isActive)
				{
					return new Rigidbody[0];
				}
				Rigidbody[] array = new Rigidbody[this.boneTable.Count];
				int num = 0;
				foreach (Transform transform in this.boneTable.Values)
				{
					array[num] = transform.GetComponent<Rigidbody>();
					num++;
				}
				return array;
			}
		}

		// Token: 0x1700243B RID: 9275
		// (get) Token: 0x0601B5EC RID: 112108 RVA: 0x0086F858 File Offset: 0x0086DC58
		public Vector3 EstimatedSkeletonPosition
		{
			get
			{
				return this.RootRigidbody.position - this.rootOffset;
			}
		}

		// Token: 0x0601B5ED RID: 112109 RVA: 0x0086F870 File Offset: 0x0086DC70
		public void Apply()
		{
			this.isActive = true;
			this.mix = 1f;
			this.StartingBone = this.skeleton.FindBone(this.startingBoneName);
			this.RecursivelyCreateBoneProxies(this.StartingBone);
			this.RootRigidbody = this.boneTable[this.StartingBone].GetComponent<Rigidbody>();
			this.RootRigidbody.isKinematic = this.pinStartBone;
			this.RootRigidbody.mass = this.rootMass;
			List<Collider> list = new List<Collider>();
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				list.Add(value.GetComponent<Collider>());
				Transform transform;
				if (key == this.StartingBone)
				{
					this.ragdollRoot = new GameObject("RagdollRoot").transform;
					this.ragdollRoot.SetParent(base.transform, false);
					if (key == this.skeleton.RootBone)
					{
						this.ragdollRoot.localPosition = new Vector3(key.WorldX, key.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll.GetPropagatedRotation(key));
					}
					else
					{
						this.ragdollRoot.localPosition = new Vector3(key.Parent.WorldX, key.Parent.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll.GetPropagatedRotation(key.Parent));
					}
					transform = this.ragdollRoot;
					this.rootOffset = value.position - base.transform.position;
				}
				else
				{
					transform = this.boneTable[key.Parent];
				}
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component != null)
				{
					HingeJoint hingeJoint = value.gameObject.AddComponent<HingeJoint>();
					hingeJoint.connectedBody = component;
					Vector3 connectedAnchor = transform.InverseTransformPoint(value.position);
					connectedAnchor.x *= 1f;
					hingeJoint.connectedAnchor = connectedAnchor;
					hingeJoint.axis = Vector3.forward;
					hingeJoint.GetComponent<Rigidbody>().mass = hingeJoint.connectedBody.mass * this.massFalloffFactor;
					HingeJoint hingeJoint2 = hingeJoint;
					JointLimits limits = default(JointLimits);
					limits.min = -this.rotationLimit;
					limits.max = this.rotationLimit;
					hingeJoint2.limits = limits;
					hingeJoint.useLimits = true;
					hingeJoint.enableCollision = this.enableJointCollision;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (i != j)
					{
						Physics.IgnoreCollision(list[i], list[j]);
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

		// Token: 0x0601B5EE RID: 112110 RVA: 0x0086FDB0 File Offset: 0x0086E1B0
		public Coroutine SmoothMix(float target, float duration)
		{
			return base.StartCoroutine(this.SmoothMixCoroutine(target, duration));
		}

		// Token: 0x0601B5EF RID: 112111 RVA: 0x0086FDC0 File Offset: 0x0086E1C0
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

		// Token: 0x0601B5F0 RID: 112112 RVA: 0x0086FDEC File Offset: 0x0086E1EC
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

		// Token: 0x0601B5F1 RID: 112113 RVA: 0x0086FEA0 File Offset: 0x0086E2A0
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

		// Token: 0x0601B5F2 RID: 112114 RVA: 0x0086FF40 File Offset: 0x0086E340
		public Rigidbody GetRigidbody(string boneName)
		{
			Bone bone = this.skeleton.FindBone(boneName);
			return (bone == null || !this.boneTable.ContainsKey(bone)) ? null : this.boneTable[bone].GetComponent<Rigidbody>();
		}

		// Token: 0x0601B5F3 RID: 112115 RVA: 0x0086FF88 File Offset: 0x0086E388
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
			transform.localScale = new Vector3(b.WorldScaleX, b.WorldScaleY, 1f);
			List<Collider> list = this.AttachBoundingBoxRagdollColliders(b);
			if (list.Count == 0)
			{
				float length = b.Data.Length;
				if (length == 0f)
				{
					SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
					sphereCollider.radius = this.thickness * 0.5f;
				}
				else
				{
					BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
					boxCollider.size = new Vector3(length, this.thickness, this.thickness);
					boxCollider.center = new Vector3(length * 0.5f, 0f);
				}
			}
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.constraints = 8;
			foreach (Bone b2 in b.Children)
			{
				this.RecursivelyCreateBoneProxies(b2);
			}
		}

		// Token: 0x0601B5F4 RID: 112116 RVA: 0x0087012C File Offset: 0x0086E52C
		private void UpdateSpineSkeleton(ISkeletonAnimation skeletonRenderer)
		{
			bool flipX = this.skeleton.flipX;
			bool flipY = this.skeleton.flipY;
			bool flag = flipX ^ flipY;
			bool flag2 = flipX || flipY;
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				bool flag3 = key == this.StartingBone;
				Transform transform = (!flag3) ? this.boneTable[key.Parent] : this.ragdollRoot;
				Vector3 position = transform.position;
				Quaternion rotation = transform.rotation;
				SkeletonRagdoll.parentSpaceHelper.position = position;
				SkeletonRagdoll.parentSpaceHelper.rotation = rotation;
				SkeletonRagdoll.parentSpaceHelper.localScale = transform.localScale;
				Vector3 position2 = value.position;
				Vector3 vector = SkeletonRagdoll.parentSpaceHelper.InverseTransformDirection(value.right);
				Vector3 vector2 = SkeletonRagdoll.parentSpaceHelper.InverseTransformPoint(position2);
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

		// Token: 0x0601B5F5 RID: 112117 RVA: 0x00870368 File Offset: 0x0086E768
		private List<Collider> AttachBoundingBoxRagdollColliders(Bone b)
		{
			List<Collider> list = new List<Collider>();
			Transform transform = this.boneTable[b];
			GameObject gameObject = transform.gameObject;
			Skin skin = this.skeleton.Skin ?? this.skeleton.Data.DefaultSkin;
			List<Attachment> list2 = new List<Attachment>();
			foreach (Slot slot in this.skeleton.Slots)
			{
				if (slot.Bone == b)
				{
					skin.FindAttachmentsForSlot(this.skeleton.Slots.IndexOf(slot), list2);
					foreach (Attachment attachment in list2)
					{
						BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
						if (boundingBoxAttachment != null)
						{
							if (attachment.Name.ToLower().Contains("ragdoll"))
							{
								BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
								Bounds boundingBoxBounds = SkeletonUtility.GetBoundingBoxBounds(boundingBoxAttachment, this.thickness);
								boxCollider.center = boundingBoxBounds.center;
								boxCollider.size = boundingBoxBounds.size;
								list.Add(boxCollider);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0601B5F6 RID: 112118 RVA: 0x008704E0 File Offset: 0x0086E8E0
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

		// Token: 0x040130E1 RID: 78049
		private static Transform parentSpaceHelper;

		// Token: 0x040130E2 RID: 78050
		[Header("Hierarchy")]
		[SpineBone("", "", true, false)]
		public string startingBoneName = string.Empty;

		// Token: 0x040130E3 RID: 78051
		[SpineBone("", "", true, false)]
		public List<string> stopBoneNames = new List<string>();

		// Token: 0x040130E4 RID: 78052
		[Header("Parameters")]
		public bool applyOnStart;

		// Token: 0x040130E5 RID: 78053
		[Tooltip("Warning!  You will have to re-enable and tune mix values manually if attempting to remove the ragdoll system.")]
		public bool disableIK = true;

		// Token: 0x040130E6 RID: 78054
		public bool disableOtherConstraints;

		// Token: 0x040130E7 RID: 78055
		[Space(18f)]
		[Tooltip("Set RootRigidbody IsKinematic to true when Apply is called.")]
		public bool pinStartBone;

		// Token: 0x040130E8 RID: 78056
		[Tooltip("Enable Collision between adjacent ragdoll elements (IE: Neck and Head)")]
		public bool enableJointCollision;

		// Token: 0x040130E9 RID: 78057
		public bool useGravity = true;

		// Token: 0x040130EA RID: 78058
		[Tooltip("If no BoundingBox Attachment is attached to a bone, this becomes the default Width or Radius of a Bone's ragdoll Rigidbody")]
		public float thickness = 0.125f;

		// Token: 0x040130EB RID: 78059
		[Tooltip("Default rotational limit value.  Min is negative this value, Max is this value.")]
		public float rotationLimit = 20f;

		// Token: 0x040130EC RID: 78060
		public float rootMass = 20f;

		// Token: 0x040130ED RID: 78061
		[Tooltip("If your ragdoll seems unstable or uneffected by limits, try lowering this value.")]
		[Range(0.01f, 1f)]
		public float massFalloffFactor = 0.4f;

		// Token: 0x040130EE RID: 78062
		[Tooltip("The layer assigned to all of the rigidbody parts.")]
		public int colliderLayer;

		// Token: 0x040130EF RID: 78063
		[Range(0f, 1f)]
		public float mix = 1f;

		// Token: 0x040130F0 RID: 78064
		private ISkeletonAnimation targetSkeletonComponent;

		// Token: 0x040130F1 RID: 78065
		private Skeleton skeleton;

		// Token: 0x040130F2 RID: 78066
		private Dictionary<Bone, Transform> boneTable = new Dictionary<Bone, Transform>();

		// Token: 0x040130F3 RID: 78067
		private Transform ragdollRoot;

		// Token: 0x040130F6 RID: 78070
		private Vector3 rootOffset;

		// Token: 0x040130F7 RID: 78071
		private bool isActive;

		// Token: 0x02004A0F RID: 18959
		public class LayerFieldAttribute : PropertyAttribute
		{
		}
	}
}
