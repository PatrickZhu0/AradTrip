using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A18 RID: 18968
	public class SkeletonUtilityKinematicShadow : MonoBehaviour
	{
		// Token: 0x0601B655 RID: 112213 RVA: 0x008732B4 File Offset: 0x008716B4
		private void Start()
		{
			this.shadowRoot = Object.Instantiate<GameObject>(base.gameObject);
			Object.Destroy(this.shadowRoot.GetComponent<SkeletonUtilityKinematicShadow>());
			Transform transform = this.shadowRoot.transform;
			transform.position = base.transform.position;
			transform.rotation = base.transform.rotation;
			Vector3 vector = base.transform.TransformPoint(Vector3.right);
			float num = Vector3.Distance(base.transform.position, vector);
			transform.localScale = Vector3.one;
			if (!this.detachedShadow)
			{
				if (this.parent == null)
				{
					transform.parent = base.transform.root;
				}
				else
				{
					transform.parent = this.parent;
				}
			}
			if (this.hideShadow)
			{
				this.shadowRoot.hideFlags = 1;
			}
			Joint[] componentsInChildren = this.shadowRoot.GetComponentsInChildren<Joint>();
			foreach (Joint joint in componentsInChildren)
			{
				joint.connectedAnchor *= num;
			}
			SkeletonUtilityBone[] componentsInChildren2 = base.GetComponentsInChildren<SkeletonUtilityBone>();
			SkeletonUtilityBone[] componentsInChildren3 = this.shadowRoot.GetComponentsInChildren<SkeletonUtilityBone>();
			foreach (SkeletonUtilityBone skeletonUtilityBone in componentsInChildren2)
			{
				if (!(skeletonUtilityBone.gameObject == base.gameObject))
				{
					Type type = (this.physicsSystem != SkeletonUtilityKinematicShadow.PhysicsSystem.Physics2D) ? typeof(Rigidbody) : typeof(Rigidbody2D);
					foreach (SkeletonUtilityBone skeletonUtilityBone2 in componentsInChildren3)
					{
						if (skeletonUtilityBone2.GetComponent(type) != null && skeletonUtilityBone2.boneName == skeletonUtilityBone.boneName)
						{
							this.shadowTable.Add(new SkeletonUtilityKinematicShadow.TransformPair
							{
								dest = skeletonUtilityBone.transform,
								src = skeletonUtilityBone2.transform
							});
							break;
						}
					}
				}
			}
			SkeletonUtilityKinematicShadow.DestroyComponents(componentsInChildren3);
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Joint>());
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Rigidbody>());
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Collider>());
		}

		// Token: 0x0601B656 RID: 112214 RVA: 0x00873500 File Offset: 0x00871900
		private static void DestroyComponents(Component[] components)
		{
			int i = 0;
			int num = components.Length;
			while (i < num)
			{
				Object.Destroy(components[i]);
				i++;
			}
		}

		// Token: 0x0601B657 RID: 112215 RVA: 0x0087352C File Offset: 0x0087192C
		private void FixedUpdate()
		{
			if (this.physicsSystem == SkeletonUtilityKinematicShadow.PhysicsSystem.Physics2D)
			{
				Rigidbody2D component = this.shadowRoot.GetComponent<Rigidbody2D>();
				component.MovePosition(base.transform.position);
				component.MoveRotation(base.transform.rotation.eulerAngles.z);
			}
			else
			{
				Rigidbody component2 = this.shadowRoot.GetComponent<Rigidbody>();
				component2.MovePosition(base.transform.position);
				component2.MoveRotation(base.transform.rotation);
			}
			int i = 0;
			int count = this.shadowTable.Count;
			while (i < count)
			{
				SkeletonUtilityKinematicShadow.TransformPair transformPair = this.shadowTable[i];
				transformPair.dest.localPosition = transformPair.src.localPosition;
				transformPair.dest.localRotation = transformPair.src.localRotation;
				i++;
			}
		}

		// Token: 0x04013152 RID: 78162
		[Tooltip("If checked, the hinge chain can inherit your root transform's velocity or position/rotation changes.")]
		public bool detachedShadow;

		// Token: 0x04013153 RID: 78163
		public Transform parent;

		// Token: 0x04013154 RID: 78164
		public bool hideShadow = true;

		// Token: 0x04013155 RID: 78165
		public SkeletonUtilityKinematicShadow.PhysicsSystem physicsSystem = SkeletonUtilityKinematicShadow.PhysicsSystem.Physics3D;

		// Token: 0x04013156 RID: 78166
		private GameObject shadowRoot;

		// Token: 0x04013157 RID: 78167
		private readonly List<SkeletonUtilityKinematicShadow.TransformPair> shadowTable = new List<SkeletonUtilityKinematicShadow.TransformPair>();

		// Token: 0x02004A19 RID: 18969
		private struct TransformPair
		{
			// Token: 0x04013158 RID: 78168
			public Transform dest;

			// Token: 0x04013159 RID: 78169
			public Transform src;
		}

		// Token: 0x02004A1A RID: 18970
		public enum PhysicsSystem
		{
			// Token: 0x0401315B RID: 78171
			Physics2D,
			// Token: 0x0401315C RID: 78172
			Physics3D
		}
	}
}
