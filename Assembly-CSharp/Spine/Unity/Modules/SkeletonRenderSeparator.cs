using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A15 RID: 18965
	[ExecuteInEditMode]
	[HelpURL("https://github.com/pharan/spine-unity-docs/blob/master/SkeletonRenderSeparator.md")]
	public class SkeletonRenderSeparator : MonoBehaviour
	{
		// Token: 0x1700244E RID: 9294
		// (get) Token: 0x0601B645 RID: 112197 RVA: 0x008726E6 File Offset: 0x00870AE6
		// (set) Token: 0x0601B646 RID: 112198 RVA: 0x008726EE File Offset: 0x00870AEE
		public SkeletonRenderer SkeletonRenderer
		{
			get
			{
				return this.skeletonRenderer;
			}
			set
			{
				if (this.skeletonRenderer != null)
				{
					this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
				}
				this.skeletonRenderer = value;
				base.enabled = false;
			}
		}

		// Token: 0x0601B647 RID: 112199 RVA: 0x00872728 File Offset: 0x00870B28
		public static SkeletonRenderSeparator AddToSkeletonRenderer(SkeletonRenderer skeletonRenderer, int sortingLayerID = 0, int extraPartsRenderers = 0, int sortingOrderIncrement = 5, int baseSortingOrder = 0, bool addMinimumPartsRenderers = true)
		{
			if (skeletonRenderer == null)
			{
				Debug.Log("Tried to add SkeletonRenderSeparator to a null SkeletonRenderer reference.");
				return null;
			}
			SkeletonRenderSeparator skeletonRenderSeparator = skeletonRenderer.gameObject.AddComponent<SkeletonRenderSeparator>();
			skeletonRenderSeparator.skeletonRenderer = skeletonRenderer;
			skeletonRenderer.Initialize(false);
			int num = extraPartsRenderers;
			if (addMinimumPartsRenderers)
			{
				num = extraPartsRenderers + skeletonRenderer.separatorSlots.Count + 1;
			}
			Transform transform = skeletonRenderer.transform;
			List<SkeletonPartsRenderer> list = skeletonRenderSeparator.partsRenderers;
			for (int i = 0; i < num; i++)
			{
				SkeletonPartsRenderer skeletonPartsRenderer = SkeletonPartsRenderer.NewPartsRendererGameObject(transform, i.ToString());
				MeshRenderer meshRenderer = skeletonPartsRenderer.MeshRenderer;
				meshRenderer.sortingLayerID = sortingLayerID;
				meshRenderer.sortingOrder = baseSortingOrder + i * sortingOrderIncrement;
				list.Add(skeletonPartsRenderer);
			}
			return skeletonRenderSeparator;
		}

		// Token: 0x0601B648 RID: 112200 RVA: 0x008727E4 File Offset: 0x00870BE4
		public void AddPartsRenderer(int sortingOrderIncrement = 5)
		{
			int sortingLayerID = 0;
			int sortingOrder = 0;
			if (this.partsRenderers.Count > 0)
			{
				SkeletonPartsRenderer skeletonPartsRenderer = this.partsRenderers[this.partsRenderers.Count - 1];
				MeshRenderer meshRenderer = skeletonPartsRenderer.MeshRenderer;
				sortingLayerID = meshRenderer.sortingLayerID;
				sortingOrder = meshRenderer.sortingOrder + sortingOrderIncrement;
			}
			SkeletonPartsRenderer skeletonPartsRenderer2 = SkeletonPartsRenderer.NewPartsRendererGameObject(this.skeletonRenderer.transform, this.partsRenderers.Count.ToString());
			this.partsRenderers.Add(skeletonPartsRenderer2);
			MeshRenderer meshRenderer2 = skeletonPartsRenderer2.MeshRenderer;
			meshRenderer2.sortingLayerID = sortingLayerID;
			meshRenderer2.sortingOrder = sortingOrder;
		}

		// Token: 0x0601B649 RID: 112201 RVA: 0x00872888 File Offset: 0x00870C88
		private void OnEnable()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			if (this.copiedBlock == null)
			{
				this.copiedBlock = new MaterialPropertyBlock();
			}
			this.mainMeshRenderer = this.skeletonRenderer.GetComponent<MeshRenderer>();
			this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
			this.skeletonRenderer.GenerateMeshOverride += this.HandleRender;
			if (this.copyMeshRendererFlags)
			{
				LightProbeUsage lightProbeUsage = this.mainMeshRenderer.lightProbeUsage;
				bool receiveShadows = this.mainMeshRenderer.receiveShadows;
				ReflectionProbeUsage reflectionProbeUsage = this.mainMeshRenderer.reflectionProbeUsage;
				ShadowCastingMode shadowCastingMode = this.mainMeshRenderer.shadowCastingMode;
				MotionVectorGenerationMode motionVectorGenerationMode = this.mainMeshRenderer.motionVectorGenerationMode;
				Transform probeAnchor = this.mainMeshRenderer.probeAnchor;
				for (int i = 0; i < this.partsRenderers.Count; i++)
				{
					SkeletonPartsRenderer skeletonPartsRenderer = this.partsRenderers[i];
					if (!(skeletonPartsRenderer == null))
					{
						MeshRenderer meshRenderer = skeletonPartsRenderer.MeshRenderer;
						meshRenderer.lightProbeUsage = lightProbeUsage;
						meshRenderer.receiveShadows = receiveShadows;
						meshRenderer.reflectionProbeUsage = reflectionProbeUsage;
						meshRenderer.shadowCastingMode = shadowCastingMode;
						meshRenderer.motionVectorGenerationMode = motionVectorGenerationMode;
						meshRenderer.probeAnchor = probeAnchor;
					}
				}
			}
		}

		// Token: 0x0601B64A RID: 112202 RVA: 0x008729D0 File Offset: 0x00870DD0
		private void OnDisable()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
			foreach (SkeletonPartsRenderer skeletonPartsRenderer in this.partsRenderers)
			{
				skeletonPartsRenderer.ClearMesh();
			}
		}

		// Token: 0x0601B64B RID: 112203 RVA: 0x00872A54 File Offset: 0x00870E54
		private void HandleRender(SkeletonRendererInstruction instruction)
		{
			int count = this.partsRenderers.Count;
			if (count <= 0)
			{
				return;
			}
			if (this.copyPropertyBlock)
			{
				this.mainMeshRenderer.GetPropertyBlock(this.copiedBlock);
			}
			MeshGenerator.Settings settings = new MeshGenerator.Settings
			{
				addNormals = this.skeletonRenderer.addNormals,
				calculateTangents = this.skeletonRenderer.calculateTangents,
				immutableTriangles = false,
				pmaVertexColors = this.skeletonRenderer.pmaVertexColors,
				tintBlack = this.skeletonRenderer.tintBlack,
				useClipping = true,
				zSpacing = this.skeletonRenderer.zSpacing
			};
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			SubmeshInstruction[] items = submeshInstructions.Items;
			int num = submeshInstructions.Count - 1;
			int i = 0;
			SkeletonPartsRenderer skeletonPartsRenderer = this.partsRenderers[i];
			int j = 0;
			int startSubmesh = 0;
			while (j <= num)
			{
				if (items[j].forceSeparate || j == num)
				{
					MeshGenerator meshGenerator = skeletonPartsRenderer.MeshGenerator;
					meshGenerator.settings = settings;
					if (this.copyPropertyBlock)
					{
						skeletonPartsRenderer.SetPropertyBlock(this.copiedBlock);
					}
					skeletonPartsRenderer.RenderParts(instruction.submeshInstructions, startSubmesh, j + 1);
					startSubmesh = j + 1;
					i++;
					if (i >= count)
					{
						break;
					}
					skeletonPartsRenderer = this.partsRenderers[i];
				}
				j++;
			}
			while (i < count)
			{
				this.partsRenderers[i].ClearMesh();
				i++;
			}
		}

		// Token: 0x04013138 RID: 78136
		public const int DefaultSortingOrderIncrement = 5;

		// Token: 0x04013139 RID: 78137
		[SerializeField]
		protected SkeletonRenderer skeletonRenderer;

		// Token: 0x0401313A RID: 78138
		private MeshRenderer mainMeshRenderer;

		// Token: 0x0401313B RID: 78139
		public bool copyPropertyBlock = true;

		// Token: 0x0401313C RID: 78140
		[Tooltip("Copies MeshRenderer flags into each parts renderer")]
		public bool copyMeshRendererFlags = true;

		// Token: 0x0401313D RID: 78141
		public List<SkeletonPartsRenderer> partsRenderers = new List<SkeletonPartsRenderer>();

		// Token: 0x0401313E RID: 78142
		private MaterialPropertyBlock copiedBlock;
	}
}
