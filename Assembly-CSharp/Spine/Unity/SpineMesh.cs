using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049FA RID: 18938
	public static class SpineMesh
	{
		// Token: 0x0601B534 RID: 111924 RVA: 0x00868A3C File Offset: 0x00866E3C
		public static Mesh NewSkeletonMesh()
		{
			Mesh mesh = new Mesh();
			mesh.MarkDynamic();
			mesh.name = "Skeleton Mesh";
			mesh.hideFlags = 20;
			return mesh;
		}

		// Token: 0x04013076 RID: 77942
		internal const HideFlags MeshHideflags = 20;
	}
}
