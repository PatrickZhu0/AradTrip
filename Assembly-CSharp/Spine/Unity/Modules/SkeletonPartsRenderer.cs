using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A14 RID: 18964
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class SkeletonPartsRenderer : MonoBehaviour
	{
		// Token: 0x1700244B RID: 9291
		// (get) Token: 0x0601B63C RID: 112188 RVA: 0x0087243D File Offset: 0x0087083D
		public MeshGenerator MeshGenerator
		{
			get
			{
				this.LazyIntialize();
				return this.meshGenerator;
			}
		}

		// Token: 0x1700244C RID: 9292
		// (get) Token: 0x0601B63D RID: 112189 RVA: 0x0087244B File Offset: 0x0087084B
		public MeshRenderer MeshRenderer
		{
			get
			{
				this.LazyIntialize();
				return this.meshRenderer;
			}
		}

		// Token: 0x1700244D RID: 9293
		// (get) Token: 0x0601B63E RID: 112190 RVA: 0x00872459 File Offset: 0x00870859
		public MeshFilter MeshFilter
		{
			get
			{
				this.LazyIntialize();
				return this.meshFilter;
			}
		}

		// Token: 0x0601B63F RID: 112191 RVA: 0x00872468 File Offset: 0x00870868
		private void LazyIntialize()
		{
			if (this.buffers == null)
			{
				this.buffers = new MeshRendererBuffers();
				this.buffers.Initialize();
				if (this.meshGenerator != null)
				{
					return;
				}
				this.meshGenerator = new MeshGenerator();
				this.meshFilter = base.GetComponent<MeshFilter>();
				this.meshRenderer = base.GetComponent<MeshRenderer>();
				this.currentInstructions.Clear();
			}
		}

		// Token: 0x0601B640 RID: 112192 RVA: 0x008724D0 File Offset: 0x008708D0
		public void ClearMesh()
		{
			this.LazyIntialize();
			this.meshFilter.sharedMesh = null;
		}

		// Token: 0x0601B641 RID: 112193 RVA: 0x008724E4 File Offset: 0x008708E4
		public void RenderParts(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
		{
			this.LazyIntialize();
			MeshRendererBuffers.SmartMesh nextMesh = this.buffers.GetNextMesh();
			this.currentInstructions.SetWithSubset(instructions, startSubmesh, endSubmesh);
			bool flag = SkeletonRendererInstruction.GeometryNotEqual(this.currentInstructions, nextMesh.instructionUsed);
			SubmeshInstruction[] items = this.currentInstructions.submeshInstructions.Items;
			this.meshGenerator.Begin();
			if (this.currentInstructions.hasActiveClipping)
			{
				for (int i = 0; i < this.currentInstructions.submeshInstructions.Count; i++)
				{
					this.meshGenerator.AddSubmesh(items[i], flag);
				}
			}
			else
			{
				this.meshGenerator.BuildMeshWithArrays(this.currentInstructions, flag);
			}
			this.buffers.UpdateSharedMaterials(this.currentInstructions.submeshInstructions);
			Mesh mesh = nextMesh.mesh;
			if (this.meshGenerator.VertexCount <= 0)
			{
				mesh.Clear();
			}
			else
			{
				this.meshGenerator.FillVertexData(mesh);
				if (flag)
				{
					this.meshGenerator.FillTriangles(mesh);
					this.meshRenderer.sharedMaterials = this.buffers.GetUpdatedSharedMaterialsArray();
				}
				else if (this.buffers.MaterialsChangedInLastUpdate())
				{
					this.meshRenderer.sharedMaterials = this.buffers.GetUpdatedSharedMaterialsArray();
				}
			}
			this.meshGenerator.FillLateVertexData(mesh);
			this.meshFilter.sharedMesh = mesh;
			nextMesh.instructionUsed.Set(this.currentInstructions);
		}

		// Token: 0x0601B642 RID: 112194 RVA: 0x00872668 File Offset: 0x00870A68
		public void SetPropertyBlock(MaterialPropertyBlock block)
		{
			this.LazyIntialize();
			this.meshRenderer.SetPropertyBlock(block);
		}

		// Token: 0x0601B643 RID: 112195 RVA: 0x0087267C File Offset: 0x00870A7C
		public static SkeletonPartsRenderer NewPartsRendererGameObject(Transform parent, string name)
		{
			GameObject gameObject = new GameObject(name, new Type[]
			{
				typeof(MeshFilter),
				typeof(MeshRenderer)
			});
			gameObject.transform.SetParent(parent, false);
			return gameObject.AddComponent<SkeletonPartsRenderer>();
		}

		// Token: 0x04013133 RID: 78131
		private MeshGenerator meshGenerator;

		// Token: 0x04013134 RID: 78132
		private MeshRenderer meshRenderer;

		// Token: 0x04013135 RID: 78133
		private MeshFilter meshFilter;

		// Token: 0x04013136 RID: 78134
		private MeshRendererBuffers buffers;

		// Token: 0x04013137 RID: 78135
		private SkeletonRendererInstruction currentInstructions = new SkeletonRendererInstruction();
	}
}
