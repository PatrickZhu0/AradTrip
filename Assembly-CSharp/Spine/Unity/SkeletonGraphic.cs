using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Spine.Unity
{
	// Token: 0x02004A12 RID: 18962
	[ExecuteInEditMode]
	[RequireComponent(typeof(CanvasRenderer), typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Spine/SkeletonGraphic (Unity UI Canvas)")]
	public class SkeletonGraphic : MaskableGraphic, ISkeletonComponent, IAnimationStateComponent, ISkeletonAnimation, IHasSkeletonDataAsset
	{
		// Token: 0x17002443 RID: 9283
		// (get) Token: 0x0601B615 RID: 112149 RVA: 0x00871B7D File Offset: 0x0086FF7D
		public SkeletonDataAsset SkeletonDataAsset
		{
			get
			{
				return this.skeletonDataAsset;
			}
		}

		// Token: 0x0601B616 RID: 112150 RVA: 0x00871B88 File Offset: 0x0086FF88
		public static SkeletonGraphic NewSkeletonGraphicGameObject(SkeletonDataAsset skeletonDataAsset, Transform parent)
		{
			SkeletonGraphic skeletonGraphic = SkeletonGraphic.AddSkeletonGraphicComponent(new GameObject("New Spine GameObject"), skeletonDataAsset);
			if (parent != null)
			{
				skeletonGraphic.transform.SetParent(parent, false);
			}
			return skeletonGraphic;
		}

		// Token: 0x0601B617 RID: 112151 RVA: 0x00871BC0 File Offset: 0x0086FFC0
		public static SkeletonGraphic AddSkeletonGraphicComponent(GameObject gameObject, SkeletonDataAsset skeletonDataAsset)
		{
			SkeletonGraphic skeletonGraphic = gameObject.AddComponent<SkeletonGraphic>();
			if (skeletonDataAsset != null)
			{
				skeletonGraphic.skeletonDataAsset = skeletonDataAsset;
				skeletonGraphic.Initialize(false);
			}
			return skeletonGraphic;
		}

		// Token: 0x17002444 RID: 9284
		// (get) Token: 0x0601B618 RID: 112152 RVA: 0x00871BEF File Offset: 0x0086FFEF
		// (set) Token: 0x0601B619 RID: 112153 RVA: 0x00871BF7 File Offset: 0x0086FFF7
		public Texture OverrideTexture
		{
			get
			{
				return this.overrideTexture;
			}
			set
			{
				this.overrideTexture = value;
				base.canvasRenderer.SetTexture(this.mainTexture);
			}
		}

		// Token: 0x17002445 RID: 9285
		// (get) Token: 0x0601B61A RID: 112154 RVA: 0x00871C14 File Offset: 0x00870014
		public override Texture mainTexture
		{
			get
			{
				if (this.overrideTexture != null)
				{
					return this.overrideTexture;
				}
				return (!(this.skeletonDataAsset == null)) ? this.skeletonDataAsset.atlasAssets[0].materials[0].mainTexture : null;
			}
		}

		// Token: 0x0601B61B RID: 112155 RVA: 0x00871C6C File Offset: 0x0087006C
		public void ReWind()
		{
			if (this.skeleton != null)
			{
				this.skeleton.SetBonesToSetupPose();
			}
			if (this.state != null)
			{
				this.state.ClearTracks();
			}
			if (!string.IsNullOrEmpty(this.startingAnimation))
			{
				this.state.SetAnimation(0, this.startingAnimation, this.startingLoop);
			}
			this.Update(0f);
		}

		// Token: 0x0601B61C RID: 112156 RVA: 0x00871CD9 File Offset: 0x008700D9
		protected override void Awake()
		{
			base.Awake();
			if (!this.IsValid)
			{
				this.Initialize(false);
				this.Rebuild(3);
			}
		}

		// Token: 0x0601B61D RID: 112157 RVA: 0x00871CFA File Offset: 0x008700FA
		public override void Rebuild(CanvasUpdate update)
		{
			base.Rebuild(update);
			if (base.canvasRenderer.cull)
			{
				return;
			}
			if (update == 3)
			{
				this.UpdateMesh();
			}
		}

		// Token: 0x0601B61E RID: 112158 RVA: 0x00871D21 File Offset: 0x00870121
		public virtual void Update()
		{
			if (this.freeze)
			{
				return;
			}
			this.Update((!this.unscaledTime) ? Time.deltaTime : Time.unscaledDeltaTime);
		}

		// Token: 0x0601B61F RID: 112159 RVA: 0x00871D50 File Offset: 0x00870150
		public virtual void Update(float deltaTime)
		{
			if (!this.IsValid)
			{
				return;
			}
			deltaTime *= this.timeScale;
			this.skeleton.Update(deltaTime);
			this.state.Update(deltaTime);
			this.state.Apply(this.skeleton);
			if (this.UpdateLocal != null)
			{
				this.UpdateLocal(this);
			}
			this.skeleton.UpdateWorldTransform();
			if (this.UpdateWorld != null)
			{
				this.UpdateWorld(this);
				this.skeleton.UpdateWorldTransform();
			}
			if (this.UpdateComplete != null)
			{
				this.UpdateComplete(this);
			}
		}

		// Token: 0x0601B620 RID: 112160 RVA: 0x00871DF8 File Offset: 0x008701F8
		public void LateUpdate()
		{
			if (this.freeze)
			{
				return;
			}
			this.UpdateMesh();
		}

		// Token: 0x17002446 RID: 9286
		// (get) Token: 0x0601B621 RID: 112161 RVA: 0x00871E0C File Offset: 0x0087020C
		// (set) Token: 0x0601B622 RID: 112162 RVA: 0x00871E14 File Offset: 0x00870214
		public Skeleton Skeleton
		{
			get
			{
				return this.skeleton;
			}
			internal set
			{
				this.skeleton = value;
			}
		}

		// Token: 0x17002447 RID: 9287
		// (get) Token: 0x0601B623 RID: 112163 RVA: 0x00871E1D File Offset: 0x0087021D
		public SkeletonData SkeletonData
		{
			get
			{
				return (this.skeleton != null) ? this.skeleton.data : null;
			}
		}

		// Token: 0x17002448 RID: 9288
		// (get) Token: 0x0601B624 RID: 112164 RVA: 0x00871E3B File Offset: 0x0087023B
		public bool IsValid
		{
			get
			{
				return this.skeleton != null;
			}
		}

		// Token: 0x17002449 RID: 9289
		// (get) Token: 0x0601B625 RID: 112165 RVA: 0x00871E49 File Offset: 0x00870249
		public AnimationState AnimationState
		{
			get
			{
				return this.state;
			}
		}

		// Token: 0x1700244A RID: 9290
		// (get) Token: 0x0601B626 RID: 112166 RVA: 0x00871E51 File Offset: 0x00870251
		public MeshGenerator MeshGenerator
		{
			get
			{
				return this.meshGenerator;
			}
		}

		// Token: 0x0601B627 RID: 112167 RVA: 0x00871E59 File Offset: 0x00870259
		public Mesh GetLastMesh()
		{
			return this.meshBuffers.GetCurrent().mesh;
		}

		// Token: 0x14000082 RID: 130
		// (add) Token: 0x0601B628 RID: 112168 RVA: 0x00871E6C File Offset: 0x0087026C
		// (remove) Token: 0x0601B629 RID: 112169 RVA: 0x00871EA4 File Offset: 0x008702A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event UpdateBonesDelegate UpdateLocal;

		// Token: 0x14000083 RID: 131
		// (add) Token: 0x0601B62A RID: 112170 RVA: 0x00871EDC File Offset: 0x008702DC
		// (remove) Token: 0x0601B62B RID: 112171 RVA: 0x00871F14 File Offset: 0x00870314
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event UpdateBonesDelegate UpdateWorld;

		// Token: 0x14000084 RID: 132
		// (add) Token: 0x0601B62C RID: 112172 RVA: 0x00871F4C File Offset: 0x0087034C
		// (remove) Token: 0x0601B62D RID: 112173 RVA: 0x00871F84 File Offset: 0x00870384
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event UpdateBonesDelegate UpdateComplete;

		// Token: 0x14000085 RID: 133
		// (add) Token: 0x0601B62E RID: 112174 RVA: 0x00871FBC File Offset: 0x008703BC
		// (remove) Token: 0x0601B62F RID: 112175 RVA: 0x00871FF4 File Offset: 0x008703F4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event MeshGeneratorDelegate OnPostProcessVertices;

		// Token: 0x0601B630 RID: 112176 RVA: 0x0087202A File Offset: 0x0087042A
		public void Clear()
		{
			this.skeleton = null;
			base.canvasRenderer.Clear();
		}

		// Token: 0x0601B631 RID: 112177 RVA: 0x00872040 File Offset: 0x00870440
		public void Initialize(bool overwrite)
		{
			if (this.IsValid && !overwrite)
			{
				return;
			}
			if (this.skeletonDataAsset == null)
			{
				return;
			}
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(false);
			if (skeletonData == null)
			{
				return;
			}
			if (this.skeletonDataAsset.atlasAssets.Length <= 0 || this.skeletonDataAsset.atlasAssets[0].materials.Length <= 0)
			{
				return;
			}
			this.state = new AnimationState(this.skeletonDataAsset.GetAnimationStateData());
			if (this.state == null)
			{
				this.Clear();
				return;
			}
			this.skeleton = new Skeleton(skeletonData)
			{
				flipX = this.initialFlipX,
				flipY = this.initialFlipY
			};
			this.meshBuffers = new DoubleBuffered<MeshRendererBuffers.SmartMesh>();
			base.canvasRenderer.SetTexture(this.mainTexture);
			if (!string.IsNullOrEmpty(this.initialSkinName))
			{
				this.skeleton.SetSkin(this.initialSkinName);
			}
			if (!string.IsNullOrEmpty(this.startingAnimation))
			{
				this.state.SetAnimation(0, this.startingAnimation, this.startingLoop);
				this.Update(0f);
			}
		}

		// Token: 0x0601B632 RID: 112178 RVA: 0x00872174 File Offset: 0x00870574
		public void UpdateMesh()
		{
			if (!this.IsValid)
			{
				return;
			}
			this.skeleton.SetColor(this.color);
			MeshRendererBuffers.SmartMesh next = this.meshBuffers.GetNext();
			SkeletonRendererInstruction skeletonRendererInstruction = this.currentInstructions;
			MeshGenerator.GenerateSingleSubmeshInstruction(skeletonRendererInstruction, this.skeleton, this.material);
			bool flag = SkeletonRendererInstruction.GeometryNotEqual(skeletonRendererInstruction, next.instructionUsed);
			this.meshGenerator.Begin();
			if (skeletonRendererInstruction.hasActiveClipping)
			{
				this.meshGenerator.AddSubmesh(skeletonRendererInstruction.submeshInstructions.Items[0], flag);
			}
			else
			{
				this.meshGenerator.BuildMeshWithArrays(skeletonRendererInstruction, flag);
			}
			if (base.canvas != null)
			{
				this.meshGenerator.ScaleVertexData(base.canvas.referencePixelsPerUnit);
			}
			if (this.OnPostProcessVertices != null)
			{
				this.OnPostProcessVertices(this.meshGenerator.Buffers);
			}
			Mesh mesh = next.mesh;
			this.meshGenerator.FillVertexData(mesh);
			if (flag)
			{
				this.meshGenerator.FillTrianglesSingle(mesh);
			}
			this.meshGenerator.FillLateVertexData(mesh);
			base.canvasRenderer.SetMesh(mesh);
			next.instructionUsed.Set(skeletonRendererInstruction);
		}

		// Token: 0x04013119 RID: 78105
		public SkeletonDataAsset skeletonDataAsset;

		// Token: 0x0401311A RID: 78106
		[SpineSkin("", "skeletonDataAsset", true, false)]
		public string initialSkinName = "default";

		// Token: 0x0401311B RID: 78107
		public bool initialFlipX;

		// Token: 0x0401311C RID: 78108
		public bool initialFlipY;

		// Token: 0x0401311D RID: 78109
		[SpineAnimation("", "skeletonDataAsset", true, false)]
		public string startingAnimation;

		// Token: 0x0401311E RID: 78110
		public bool startingLoop;

		// Token: 0x0401311F RID: 78111
		public float timeScale = 1f;

		// Token: 0x04013120 RID: 78112
		public bool freeze;

		// Token: 0x04013121 RID: 78113
		public bool unscaledTime;

		// Token: 0x04013122 RID: 78114
		private Texture overrideTexture;

		// Token: 0x04013123 RID: 78115
		protected Skeleton skeleton;

		// Token: 0x04013124 RID: 78116
		protected AnimationState state;

		// Token: 0x04013125 RID: 78117
		[SerializeField]
		protected MeshGenerator meshGenerator = new MeshGenerator();

		// Token: 0x04013126 RID: 78118
		private DoubleBuffered<MeshRendererBuffers.SmartMesh> meshBuffers;

		// Token: 0x04013127 RID: 78119
		private SkeletonRendererInstruction currentInstructions = new SkeletonRendererInstruction();
	}
}
