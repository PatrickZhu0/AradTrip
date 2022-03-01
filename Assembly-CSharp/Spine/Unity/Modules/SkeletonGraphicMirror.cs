using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A13 RID: 18963
	public class SkeletonGraphicMirror : MonoBehaviour
	{
		// Token: 0x0601B634 RID: 112180 RVA: 0x008722C1 File Offset: 0x008706C1
		private void Awake()
		{
			this.skeletonGraphic = base.GetComponent<SkeletonGraphic>();
		}

		// Token: 0x0601B635 RID: 112181 RVA: 0x008722CF File Offset: 0x008706CF
		private void Start()
		{
			if (this.mirrorOnStart)
			{
				this.StartMirroring();
			}
		}

		// Token: 0x0601B636 RID: 112182 RVA: 0x008722E2 File Offset: 0x008706E2
		private void LateUpdate()
		{
			this.skeletonGraphic.UpdateMesh();
		}

		// Token: 0x0601B637 RID: 112183 RVA: 0x008722EF File Offset: 0x008706EF
		private void OnDisable()
		{
			if (this.restoreOnDisable)
			{
				this.RestoreIndependentSkeleton();
			}
		}

		// Token: 0x0601B638 RID: 112184 RVA: 0x00872304 File Offset: 0x00870704
		public void StartMirroring()
		{
			if (this.source == null)
			{
				return;
			}
			if (this.skeletonGraphic == null)
			{
				return;
			}
			this.skeletonGraphic.startingAnimation = string.Empty;
			if (this.originalSkeleton == null)
			{
				this.originalSkeleton = this.skeletonGraphic.Skeleton;
				this.originalFreeze = this.skeletonGraphic.freeze;
			}
			this.skeletonGraphic.Skeleton = this.source.skeleton;
			this.skeletonGraphic.freeze = true;
			if (this.overrideTexture != null)
			{
				this.skeletonGraphic.OverrideTexture = this.overrideTexture;
			}
		}

		// Token: 0x0601B639 RID: 112185 RVA: 0x008723B6 File Offset: 0x008707B6
		public void UpdateTexture(Texture2D newOverrideTexture)
		{
			this.overrideTexture = newOverrideTexture;
			if (newOverrideTexture != null)
			{
				this.skeletonGraphic.OverrideTexture = this.overrideTexture;
			}
		}

		// Token: 0x0601B63A RID: 112186 RVA: 0x008723DC File Offset: 0x008707DC
		public void RestoreIndependentSkeleton()
		{
			if (this.originalSkeleton == null)
			{
				return;
			}
			this.skeletonGraphic.Skeleton = this.originalSkeleton;
			this.skeletonGraphic.freeze = this.originalFreeze;
			this.skeletonGraphic.OverrideTexture = null;
			this.originalSkeleton = null;
		}

		// Token: 0x0401312C RID: 78124
		public SkeletonRenderer source;

		// Token: 0x0401312D RID: 78125
		public bool mirrorOnStart = true;

		// Token: 0x0401312E RID: 78126
		public bool restoreOnDisable = true;

		// Token: 0x0401312F RID: 78127
		private SkeletonGraphic skeletonGraphic;

		// Token: 0x04013130 RID: 78128
		private Skeleton originalSkeleton;

		// Token: 0x04013131 RID: 78129
		private bool originalFreeze;

		// Token: 0x04013132 RID: 78130
		private Texture2D overrideTexture;
	}
}
