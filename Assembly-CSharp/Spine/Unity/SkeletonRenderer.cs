using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity
{
	// Token: 0x020049EF RID: 18927
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	[DisallowMultipleComponent]
	[HelpURL("http://esotericsoftware.com/spine-unity-documentation#Rendering")]
	public class SkeletonRenderer : MonoBehaviour, ISkeletonComponent, IHasSkeletonDataAsset
	{
		// Token: 0x1400007B RID: 123
		// (add) Token: 0x0601B502 RID: 111874 RVA: 0x00867324 File Offset: 0x00865724
		// (remove) Token: 0x0601B503 RID: 111875 RVA: 0x0086735C File Offset: 0x0086575C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SkeletonRenderer.SkeletonRendererDelegate OnRebuild;

		// Token: 0x1400007C RID: 124
		// (add) Token: 0x0601B504 RID: 111876 RVA: 0x00867394 File Offset: 0x00865794
		// (remove) Token: 0x0601B505 RID: 111877 RVA: 0x008673CC File Offset: 0x008657CC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event MeshGeneratorDelegate OnPostProcessVertices;

		// Token: 0x17002422 RID: 9250
		// (get) Token: 0x0601B506 RID: 111878 RVA: 0x00867402 File Offset: 0x00865802
		public SkeletonDataAsset SkeletonDataAsset
		{
			get
			{
				return this.skeletonDataAsset;
			}
		}

		// Token: 0x1400007D RID: 125
		// (add) Token: 0x0601B507 RID: 111879 RVA: 0x0086740C File Offset: 0x0086580C
		// (remove) Token: 0x0601B508 RID: 111880 RVA: 0x00867444 File Offset: 0x00865844
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event SkeletonRenderer.InstructionDelegate generateMeshOverride;

		// Token: 0x1400007E RID: 126
		// (add) Token: 0x0601B509 RID: 111881 RVA: 0x0086747A File Offset: 0x0086587A
		// (remove) Token: 0x0601B50A RID: 111882 RVA: 0x008674AC File Offset: 0x008658AC
		public event SkeletonRenderer.InstructionDelegate GenerateMeshOverride
		{
			add
			{
				this.generateMeshOverride += value;
				if (this.disableRenderingOnOverride && this.generateMeshOverride != null)
				{
					this.Initialize(false);
					this.meshRenderer.enabled = false;
				}
			}
			remove
			{
				this.generateMeshOverride -= value;
				if (this.disableRenderingOnOverride && this.generateMeshOverride == null)
				{
					this.Initialize(false);
					this.meshRenderer.enabled = true;
				}
			}
		}

		// Token: 0x17002423 RID: 9251
		// (get) Token: 0x0601B50B RID: 111883 RVA: 0x008674DE File Offset: 0x008658DE
		public Dictionary<Material, Material> CustomMaterialOverride
		{
			get
			{
				return this.customMaterialOverride;
			}
		}

		// Token: 0x17002424 RID: 9252
		// (get) Token: 0x0601B50C RID: 111884 RVA: 0x008674E6 File Offset: 0x008658E6
		public Dictionary<Slot, Material> CustomSlotMaterials
		{
			get
			{
				return this.customSlotMaterials;
			}
		}

		// Token: 0x17002425 RID: 9253
		// (get) Token: 0x0601B50D RID: 111885 RVA: 0x008674EE File Offset: 0x008658EE
		public Skeleton Skeleton
		{
			get
			{
				this.Initialize(false);
				return this.skeleton;
			}
		}

		// Token: 0x0601B50E RID: 111886 RVA: 0x008674FD File Offset: 0x008658FD
		public static T NewSpineGameObject<T>(SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			return SkeletonRenderer.AddSpineComponent<T>(new GameObject("New Spine GameObject"), skeletonDataAsset);
		}

		// Token: 0x0601B50F RID: 111887 RVA: 0x00867510 File Offset: 0x00865910
		public static T AddSpineComponent<T>(GameObject gameObject, SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			T t = gameObject.AddComponent<T>();
			if (skeletonDataAsset != null)
			{
				t.skeletonDataAsset = skeletonDataAsset;
				t.Initialize(false);
			}
			return t;
		}

		// Token: 0x0601B510 RID: 111888 RVA: 0x0086754C File Offset: 0x0086594C
		public void SetMeshSettings(MeshGenerator.Settings settings)
		{
			this.calculateTangents = settings.calculateTangents;
			this.immutableTriangles = settings.immutableTriangles;
			this.pmaVertexColors = settings.pmaVertexColors;
			this.tintBlack = settings.tintBlack;
			this.useClipping = settings.useClipping;
			this.zSpacing = settings.zSpacing;
			this.meshGenerator.settings = settings;
		}

		// Token: 0x0601B511 RID: 111889 RVA: 0x008675B3 File Offset: 0x008659B3
		public virtual void Awake()
		{
			this.Initialize(false);
		}

		// Token: 0x0601B512 RID: 111890 RVA: 0x008675BC File Offset: 0x008659BC
		private void OnDisable()
		{
			if (this.clearStateOnDisable && this.valid)
			{
				this.ClearState();
			}
		}

		// Token: 0x0601B513 RID: 111891 RVA: 0x008675DA File Offset: 0x008659DA
		private void OnDestroy()
		{
			this.rendererBuffers.Dispose();
			this.valid = false;
		}

		// Token: 0x0601B514 RID: 111892 RVA: 0x008675EE File Offset: 0x008659EE
		public virtual void ClearState()
		{
			this.meshFilter.sharedMesh = null;
			this.currentInstructions.Clear();
			if (this.skeleton != null)
			{
				this.skeleton.SetToSetupPose();
			}
		}

		// Token: 0x0601B515 RID: 111893 RVA: 0x00867620 File Offset: 0x00865A20
		public virtual void Initialize(bool overwrite)
		{
			if (this.valid && !overwrite)
			{
				return;
			}
			if (this.meshFilter != null)
			{
				this.meshFilter.sharedMesh = null;
			}
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			if (this.meshRenderer != null)
			{
				this.meshRenderer.sharedMaterial = null;
			}
			this.currentInstructions.Clear();
			this.rendererBuffers.Clear();
			this.meshGenerator.Begin();
			this.skeleton = null;
			this.valid = false;
			if (!this.skeletonDataAsset)
			{
				if (this.logErrors)
				{
					Debug.LogError("Missing SkeletonData asset.", this);
				}
				return;
			}
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(false);
			if (skeletonData == null)
			{
				return;
			}
			this.valid = true;
			this.meshFilter = base.GetComponent<MeshFilter>();
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			this.rendererBuffers.Initialize();
			this.skeleton = new Skeleton(skeletonData)
			{
				flipX = this.initialFlipX,
				flipY = this.initialFlipY
			};
			if (!string.IsNullOrEmpty(this.initialSkinName) && !string.Equals(this.initialSkinName, "default", StringComparison.Ordinal))
			{
				this.skeleton.SetSkin(this.initialSkinName);
			}
			this.separatorSlots.Clear();
			for (int i = 0; i < this.separatorSlotNames.Length; i++)
			{
				this.separatorSlots.Add(this.skeleton.FindSlot(this.separatorSlotNames[i]));
			}
			this.LateUpdate();
			if (this.OnRebuild != null)
			{
				this.OnRebuild(this);
			}
		}

		// Token: 0x0601B516 RID: 111894 RVA: 0x008677D8 File Offset: 0x00865BD8
		public virtual void LateUpdate()
		{
			if (!this.valid)
			{
				return;
			}
			bool flag = this.generateMeshOverride != null;
			if (!this.meshRenderer.enabled && !flag)
			{
				return;
			}
			SkeletonRendererInstruction skeletonRendererInstruction = this.currentInstructions;
			ExposedList<SubmeshInstruction> submeshInstructions = skeletonRendererInstruction.submeshInstructions;
			MeshRendererBuffers.SmartMesh nextMesh = this.rendererBuffers.GetNextMesh();
			bool flag2;
			if (this.singleSubmesh)
			{
				MeshGenerator.GenerateSingleSubmeshInstruction(skeletonRendererInstruction, this.skeleton, this.skeletonDataAsset.atlasAssets[0].materials[0]);
				if (this.customMaterialOverride.Count > 0)
				{
					MeshGenerator.TryReplaceMaterials(submeshInstructions, this.customMaterialOverride);
				}
				this.meshGenerator.settings = new MeshGenerator.Settings
				{
					pmaVertexColors = this.pmaVertexColors,
					zSpacing = this.zSpacing,
					useClipping = this.useClipping,
					tintBlack = this.tintBlack,
					calculateTangents = this.calculateTangents,
					addNormals = this.addNormals
				};
				this.meshGenerator.Begin();
				flag2 = SkeletonRendererInstruction.GeometryNotEqual(skeletonRendererInstruction, nextMesh.instructionUsed);
				if (skeletonRendererInstruction.hasActiveClipping)
				{
					this.meshGenerator.AddSubmesh(submeshInstructions.Items[0], flag2);
				}
				else
				{
					this.meshGenerator.BuildMeshWithArrays(skeletonRendererInstruction, flag2);
				}
			}
			else
			{
				MeshGenerator.GenerateSkeletonRendererInstruction(skeletonRendererInstruction, this.skeleton, this.customSlotMaterials, this.separatorSlots, flag, this.immutableTriangles);
				if (this.customMaterialOverride.Count > 0)
				{
					MeshGenerator.TryReplaceMaterials(submeshInstructions, this.customMaterialOverride);
				}
				if (flag)
				{
					this.generateMeshOverride(skeletonRendererInstruction);
					if (this.disableRenderingOnOverride)
					{
						return;
					}
				}
				flag2 = SkeletonRendererInstruction.GeometryNotEqual(skeletonRendererInstruction, nextMesh.instructionUsed);
				this.meshGenerator.settings = new MeshGenerator.Settings
				{
					pmaVertexColors = this.pmaVertexColors,
					zSpacing = this.zSpacing,
					useClipping = this.useClipping,
					tintBlack = this.tintBlack,
					calculateTangents = this.calculateTangents,
					addNormals = this.addNormals
				};
				this.meshGenerator.Begin();
				if (skeletonRendererInstruction.hasActiveClipping)
				{
					this.meshGenerator.BuildMesh(skeletonRendererInstruction, flag2);
				}
				else
				{
					this.meshGenerator.BuildMeshWithArrays(skeletonRendererInstruction, flag2);
				}
			}
			if (this.OnPostProcessVertices != null)
			{
				this.OnPostProcessVertices(this.meshGenerator.Buffers);
			}
			Mesh mesh = nextMesh.mesh;
			this.meshGenerator.FillVertexData(mesh);
			this.rendererBuffers.UpdateSharedMaterials(submeshInstructions);
			if (flag2)
			{
				this.meshGenerator.FillTriangles(mesh);
				this.meshRenderer.sharedMaterials = this.rendererBuffers.GetUpdatedSharedMaterialsArray();
			}
			else if (this.rendererBuffers.MaterialsChangedInLastUpdate())
			{
				this.meshRenderer.sharedMaterials = this.rendererBuffers.GetUpdatedSharedMaterialsArray();
			}
			this.meshGenerator.FillLateVertexData(mesh);
			this.meshFilter.sharedMesh = mesh;
			nextMesh.instructionUsed.Set(skeletonRendererInstruction);
		}

		// Token: 0x04013058 RID: 77912
		public SkeletonDataAsset skeletonDataAsset;

		// Token: 0x04013059 RID: 77913
		public string initialSkinName;

		// Token: 0x0401305A RID: 77914
		public bool initialFlipX;

		// Token: 0x0401305B RID: 77915
		public bool initialFlipY;

		// Token: 0x0401305C RID: 77916
		[FormerlySerializedAs("submeshSeparators")]
		[SpineSlot("", "", false, true, false)]
		public string[] separatorSlotNames = new string[0];

		// Token: 0x0401305D RID: 77917
		[NonSerialized]
		public readonly List<Slot> separatorSlots = new List<Slot>();

		// Token: 0x0401305E RID: 77918
		[Range(-0.1f, 0f)]
		public float zSpacing;

		// Token: 0x0401305F RID: 77919
		public bool useClipping = true;

		// Token: 0x04013060 RID: 77920
		public bool immutableTriangles;

		// Token: 0x04013061 RID: 77921
		public bool pmaVertexColors = true;

		// Token: 0x04013062 RID: 77922
		public bool clearStateOnDisable;

		// Token: 0x04013063 RID: 77923
		public bool tintBlack;

		// Token: 0x04013064 RID: 77924
		public bool singleSubmesh;

		// Token: 0x04013065 RID: 77925
		[FormerlySerializedAs("calculateNormals")]
		public bool addNormals;

		// Token: 0x04013066 RID: 77926
		public bool calculateTangents;

		// Token: 0x04013067 RID: 77927
		public bool logErrors;

		// Token: 0x04013068 RID: 77928
		public bool disableRenderingOnOverride = true;

		// Token: 0x0401306A RID: 77930
		[NonSerialized]
		private readonly Dictionary<Material, Material> customMaterialOverride = new Dictionary<Material, Material>();

		// Token: 0x0401306B RID: 77931
		[NonSerialized]
		private readonly Dictionary<Slot, Material> customSlotMaterials = new Dictionary<Slot, Material>();

		// Token: 0x0401306C RID: 77932
		private MeshRenderer meshRenderer;

		// Token: 0x0401306D RID: 77933
		private MeshFilter meshFilter;

		// Token: 0x0401306E RID: 77934
		[NonSerialized]
		public bool valid;

		// Token: 0x0401306F RID: 77935
		[NonSerialized]
		public Skeleton skeleton;

		// Token: 0x04013070 RID: 77936
		[NonSerialized]
		private readonly SkeletonRendererInstruction currentInstructions = new SkeletonRendererInstruction();

		// Token: 0x04013071 RID: 77937
		private readonly MeshGenerator meshGenerator = new MeshGenerator();

		// Token: 0x04013072 RID: 77938
		[NonSerialized]
		private readonly MeshRendererBuffers rendererBuffers = new MeshRendererBuffers();

		// Token: 0x020049F0 RID: 18928
		// (Invoke) Token: 0x0601B518 RID: 111896
		public delegate void SkeletonRendererDelegate(SkeletonRenderer skeletonRenderer);

		// Token: 0x020049F1 RID: 18929
		// (Invoke) Token: 0x0601B51C RID: 111900
		public delegate void InstructionDelegate(SkeletonRendererInstruction instruction);
	}
}
