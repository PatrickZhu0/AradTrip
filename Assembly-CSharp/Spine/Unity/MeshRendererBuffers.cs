using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A00 RID: 18944
	public class MeshRendererBuffers : IDisposable
	{
		// Token: 0x0601B554 RID: 111956 RVA: 0x0086B628 File Offset: 0x00869A28
		public void Initialize()
		{
			if (this.doubleBufferedMesh != null)
			{
				this.doubleBufferedMesh.GetNext().Clear();
				this.doubleBufferedMesh.GetNext().Clear();
				this.submeshMaterials.Clear(true);
			}
			else
			{
				this.doubleBufferedMesh = new DoubleBuffered<MeshRendererBuffers.SmartMesh>();
			}
		}

		// Token: 0x0601B555 RID: 111957 RVA: 0x0086B67C File Offset: 0x00869A7C
		public Material[] GetUpdatedSharedMaterialsArray()
		{
			if (this.submeshMaterials.Count == this.sharedMaterials.Length)
			{
				this.submeshMaterials.CopyTo(this.sharedMaterials);
			}
			else
			{
				this.sharedMaterials = this.submeshMaterials.ToArray();
			}
			return this.sharedMaterials;
		}

		// Token: 0x0601B556 RID: 111958 RVA: 0x0086B6D0 File Offset: 0x00869AD0
		public bool MaterialsChangedInLastUpdate()
		{
			int count = this.submeshMaterials.Count;
			Material[] array = this.sharedMaterials;
			if (count != array.Length)
			{
				return true;
			}
			Material[] items = this.submeshMaterials.Items;
			for (int i = 0; i < count; i++)
			{
				if (!object.ReferenceEquals(items[i], array[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601B557 RID: 111959 RVA: 0x0086B72C File Offset: 0x00869B2C
		public void UpdateSharedMaterials(ExposedList<SubmeshInstruction> instructions)
		{
			int count = instructions.Count;
			if (count > this.submeshMaterials.Items.Length)
			{
				Array.Resize<Material>(ref this.submeshMaterials.Items, count);
			}
			this.submeshMaterials.Count = count;
			Material[] items = this.submeshMaterials.Items;
			SubmeshInstruction[] items2 = instructions.Items;
			for (int i = 0; i < count; i++)
			{
				items[i] = items2[i].material;
			}
		}

		// Token: 0x0601B558 RID: 111960 RVA: 0x0086B7A4 File Offset: 0x00869BA4
		public MeshRendererBuffers.SmartMesh GetNextMesh()
		{
			return this.doubleBufferedMesh.GetNext();
		}

		// Token: 0x0601B559 RID: 111961 RVA: 0x0086B7B1 File Offset: 0x00869BB1
		public void Clear()
		{
			this.sharedMaterials = new Material[0];
			this.submeshMaterials.Clear(true);
		}

		// Token: 0x0601B55A RID: 111962 RVA: 0x0086B7CB File Offset: 0x00869BCB
		public void Dispose()
		{
			if (this.doubleBufferedMesh == null)
			{
				return;
			}
			this.doubleBufferedMesh.GetNext().Dispose();
			this.doubleBufferedMesh.GetNext().Dispose();
			this.doubleBufferedMesh = null;
		}

		// Token: 0x040130A4 RID: 77988
		private DoubleBuffered<MeshRendererBuffers.SmartMesh> doubleBufferedMesh;

		// Token: 0x040130A5 RID: 77989
		internal readonly ExposedList<Material> submeshMaterials = new ExposedList<Material>();

		// Token: 0x040130A6 RID: 77990
		internal Material[] sharedMaterials = new Material[0];

		// Token: 0x02004A01 RID: 18945
		public class SmartMesh : IDisposable
		{
			// Token: 0x0601B55C RID: 111964 RVA: 0x0086B81E File Offset: 0x00869C1E
			public void Clear()
			{
				this.mesh.Clear();
				this.instructionUsed.Clear();
			}

			// Token: 0x0601B55D RID: 111965 RVA: 0x0086B836 File Offset: 0x00869C36
			public void Dispose()
			{
				if (this.mesh != null)
				{
					Object.Destroy(this.mesh);
				}
				this.mesh = null;
			}

			// Token: 0x040130A7 RID: 77991
			public Mesh mesh = SpineMesh.NewSkeletonMesh();

			// Token: 0x040130A8 RID: 77992
			public SkeletonRendererInstruction instructionUsed = new SkeletonRendererInstruction();
		}
	}
}
