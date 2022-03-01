using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A28 RID: 18984
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/SkeletonUtilityBone")]
	public class SkeletonUtilityBone : MonoBehaviour
	{
		// Token: 0x17002459 RID: 9305
		// (get) Token: 0x0601B6DF RID: 112351 RVA: 0x00875C82 File Offset: 0x00874082
		public bool IncompatibleTransformMode
		{
			get
			{
				return this.incompatibleTransformMode;
			}
		}

		// Token: 0x0601B6E0 RID: 112352 RVA: 0x00875C8C File Offset: 0x0087408C
		public void Reset()
		{
			this.bone = null;
			this.cachedTransform = base.transform;
			this.valid = (this.skeletonUtility != null && this.skeletonUtility.skeletonRenderer != null && this.skeletonUtility.skeletonRenderer.valid);
			if (!this.valid)
			{
				return;
			}
			this.skeletonTransform = this.skeletonUtility.transform;
			this.skeletonUtility.OnReset -= this.HandleOnReset;
			this.skeletonUtility.OnReset += this.HandleOnReset;
			this.DoUpdate(SkeletonUtilityBone.UpdatePhase.Local);
		}

		// Token: 0x0601B6E1 RID: 112353 RVA: 0x00875D40 File Offset: 0x00874140
		private void OnEnable()
		{
			this.skeletonUtility = base.transform.GetComponentInParent<SkeletonUtility>();
			if (this.skeletonUtility == null)
			{
				return;
			}
			this.skeletonUtility.RegisterBone(this);
			this.skeletonUtility.OnReset += this.HandleOnReset;
		}

		// Token: 0x0601B6E2 RID: 112354 RVA: 0x00875D93 File Offset: 0x00874193
		private void HandleOnReset()
		{
			this.Reset();
		}

		// Token: 0x0601B6E3 RID: 112355 RVA: 0x00875D9B File Offset: 0x0087419B
		private void OnDisable()
		{
			if (this.skeletonUtility != null)
			{
				this.skeletonUtility.OnReset -= this.HandleOnReset;
				this.skeletonUtility.UnregisterBone(this);
			}
		}

		// Token: 0x0601B6E4 RID: 112356 RVA: 0x00875DD4 File Offset: 0x008741D4
		public void DoUpdate(SkeletonUtilityBone.UpdatePhase phase)
		{
			if (!this.valid)
			{
				this.Reset();
				return;
			}
			Skeleton skeleton = this.skeletonUtility.skeletonRenderer.skeleton;
			if (this.bone == null)
			{
				if (string.IsNullOrEmpty(this.boneName))
				{
					return;
				}
				this.bone = skeleton.FindBone(this.boneName);
				if (this.bone == null)
				{
					Debug.LogError("Bone not found: " + this.boneName, this);
					return;
				}
			}
			Transform transform = this.cachedTransform;
			float num = (!(skeleton.flipX ^ skeleton.flipY)) ? 1f : -1f;
			if (this.mode == SkeletonUtilityBone.Mode.Follow)
			{
				if (phase != SkeletonUtilityBone.UpdatePhase.Local)
				{
					if (phase == SkeletonUtilityBone.UpdatePhase.World || phase == SkeletonUtilityBone.UpdatePhase.Complete)
					{
						if (!this.bone.appliedValid)
						{
							this.bone.UpdateAppliedTransform();
							if (this.position)
							{
								transform.localPosition = new Vector3(this.bone.ax, this.bone.ay, 0f);
							}
							if (this.rotation)
							{
								if (this.bone.data.transformMode.InheritsRotation())
								{
									transform.localRotation = Quaternion.Euler(0f, 0f, this.bone.AppliedRotation);
								}
								else
								{
									Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
									transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + this.bone.WorldRotationX * num);
								}
							}
							if (this.scale)
							{
								transform.localScale = new Vector3(this.bone.ascaleX, this.bone.ascaleY, 1f);
								this.incompatibleTransformMode = SkeletonUtilityBone.BoneTransformModeIncompatible(this.bone);
							}
						}
					}
				}
				else
				{
					if (this.position)
					{
						transform.localPosition = new Vector3(this.bone.x, this.bone.y, 0f);
					}
					if (this.rotation)
					{
						if (this.bone.data.transformMode.InheritsRotation())
						{
							transform.localRotation = Quaternion.Euler(0f, 0f, this.bone.rotation);
						}
						else
						{
							Vector3 eulerAngles2 = this.skeletonTransform.rotation.eulerAngles;
							transform.rotation = Quaternion.Euler(eulerAngles2.x, eulerAngles2.y, eulerAngles2.z + this.bone.WorldRotationX * num);
						}
					}
					if (this.scale)
					{
						transform.localScale = new Vector3(this.bone.scaleX, this.bone.scaleY, 1f);
						this.incompatibleTransformMode = SkeletonUtilityBone.BoneTransformModeIncompatible(this.bone);
					}
				}
			}
			else if (this.mode == SkeletonUtilityBone.Mode.Override)
			{
				if (this.transformLerpComplete)
				{
					return;
				}
				if (this.parentReference == null)
				{
					if (this.position)
					{
						Vector3 localPosition = transform.localPosition;
						this.bone.x = Mathf.Lerp(this.bone.x, localPosition.x, this.overrideAlpha);
						this.bone.y = Mathf.Lerp(this.bone.y, localPosition.y, this.overrideAlpha);
					}
					if (this.rotation)
					{
						float appliedRotation = Mathf.LerpAngle(this.bone.Rotation, transform.localRotation.eulerAngles.z, this.overrideAlpha);
						this.bone.Rotation = appliedRotation;
						this.bone.AppliedRotation = appliedRotation;
					}
					if (this.scale)
					{
						Vector3 localScale = transform.localScale;
						this.bone.scaleX = Mathf.Lerp(this.bone.scaleX, localScale.x, this.overrideAlpha);
						this.bone.scaleY = Mathf.Lerp(this.bone.scaleY, localScale.y, this.overrideAlpha);
					}
				}
				else
				{
					if (this.transformLerpComplete)
					{
						return;
					}
					if (this.position)
					{
						Vector3 vector = this.parentReference.InverseTransformPoint(transform.position);
						this.bone.x = Mathf.Lerp(this.bone.x, vector.x, this.overrideAlpha);
						this.bone.y = Mathf.Lerp(this.bone.y, vector.y, this.overrideAlpha);
					}
					if (this.rotation)
					{
						float appliedRotation2 = Mathf.LerpAngle(this.bone.Rotation, Quaternion.LookRotation(Vector3.forward, this.parentReference.InverseTransformDirection(transform.up)).eulerAngles.z, this.overrideAlpha);
						this.bone.Rotation = appliedRotation2;
						this.bone.AppliedRotation = appliedRotation2;
					}
					if (this.scale)
					{
						Vector3 localScale2 = transform.localScale;
						this.bone.scaleX = Mathf.Lerp(this.bone.scaleX, localScale2.x, this.overrideAlpha);
						this.bone.scaleY = Mathf.Lerp(this.bone.scaleY, localScale2.y, this.overrideAlpha);
					}
					this.incompatibleTransformMode = SkeletonUtilityBone.BoneTransformModeIncompatible(this.bone);
				}
				this.transformLerpComplete = true;
			}
		}

		// Token: 0x0601B6E5 RID: 112357 RVA: 0x00876374 File Offset: 0x00874774
		public static bool BoneTransformModeIncompatible(Bone bone)
		{
			return !bone.data.transformMode.InheritsScale();
		}

		// Token: 0x0601B6E6 RID: 112358 RVA: 0x00876389 File Offset: 0x00874789
		public void AddBoundingBox(string skinName, string slotName, string attachmentName)
		{
			SkeletonUtility.AddBoundingBoxGameObject(this.bone.skeleton, skinName, slotName, attachmentName, base.transform, true);
		}

		// Token: 0x0401317D RID: 78205
		public string boneName;

		// Token: 0x0401317E RID: 78206
		public Transform parentReference;

		// Token: 0x0401317F RID: 78207
		public SkeletonUtilityBone.Mode mode;

		// Token: 0x04013180 RID: 78208
		public bool position;

		// Token: 0x04013181 RID: 78209
		public bool rotation;

		// Token: 0x04013182 RID: 78210
		public bool scale;

		// Token: 0x04013183 RID: 78211
		public bool zPosition = true;

		// Token: 0x04013184 RID: 78212
		[Range(0f, 1f)]
		public float overrideAlpha = 1f;

		// Token: 0x04013185 RID: 78213
		[NonSerialized]
		public SkeletonUtility skeletonUtility;

		// Token: 0x04013186 RID: 78214
		[NonSerialized]
		public Bone bone;

		// Token: 0x04013187 RID: 78215
		[NonSerialized]
		public bool transformLerpComplete;

		// Token: 0x04013188 RID: 78216
		[NonSerialized]
		public bool valid;

		// Token: 0x04013189 RID: 78217
		private Transform cachedTransform;

		// Token: 0x0401318A RID: 78218
		private Transform skeletonTransform;

		// Token: 0x0401318B RID: 78219
		private bool incompatibleTransformMode;

		// Token: 0x02004A29 RID: 18985
		public enum Mode
		{
			// Token: 0x0401318D RID: 78221
			Follow,
			// Token: 0x0401318E RID: 78222
			Override
		}

		// Token: 0x02004A2A RID: 18986
		public enum UpdatePhase
		{
			// Token: 0x04013190 RID: 78224
			Local,
			// Token: 0x04013191 RID: 78225
			World,
			// Token: 0x04013192 RID: 78226
			Complete
		}
	}
}
