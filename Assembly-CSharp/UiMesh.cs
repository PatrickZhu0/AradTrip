using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Token: 0x02000D57 RID: 3415
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class UiMesh : MaskableGraphic
{
	// Token: 0x1700186C RID: 6252
	// (get) Token: 0x06008AAF RID: 35503 RVA: 0x00197991 File Offset: 0x00195D91
	public override Texture mainTexture
	{
		get
		{
			if (this.material != null && this.material.mainTexture != null)
			{
				return this.material.mainTexture;
			}
			return Graphic.s_WhiteTexture;
		}
	}

	// Token: 0x06008AB0 RID: 35504 RVA: 0x001979CC File Offset: 0x00195DCC
	protected override void Start()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		this.m_MeshRenderer = base.GetComponent<MeshRenderer>();
		SortingGroup component = base.GetComponent<SortingGroup>();
		if (component != null)
		{
			Object.DestroyImmediate(component);
		}
		MeshFilter component2 = base.GetComponent<MeshFilter>();
		if (component2)
		{
			Mesh sharedMesh = base.GetComponent<MeshFilter>().sharedMesh;
			this.m_Vertex = new List<Vector3>(sharedMesh.vertexCount);
			this.m_UV = new List<Vector2>(sharedMesh.vertexCount);
			this.m_Colors = new List<Color>(sharedMesh.vertexCount);
			sharedMesh.GetVertices(this.m_Vertex);
			sharedMesh.GetUVs(0, this.m_UV);
			sharedMesh.GetColors(this.m_Colors);
			this.m_Triangles = sharedMesh.GetTriangles(0);
		}
		if (this.m_MeshRenderer != null)
		{
			if (this.m_MaterialAnimationNames.Length > 0)
			{
				this.m_Material = this.m_MeshRenderer.material;
				this.m_MatBlock = new MaterialPropertyBlock();
			}
			else
			{
				this.m_Material = this.m_MeshRenderer.sharedMaterial;
			}
		}
		if (this.m_MeshRenderer != null && this.m_MeshRenderer.enabled)
		{
			this.m_MeshRenderer.enabled = false;
		}
		this.raycastTarget = false;
		this.SetAllDirty();
	}

	// Token: 0x06008AB1 RID: 35505 RVA: 0x00197B17 File Offset: 0x00195F17
	protected override void OnDestroy()
	{
		if (this.m_MeshRenderer != null && this.m_MaterialAnimationNames.Length > 0)
		{
			Object.DestroyImmediate(this.m_Material);
			this.m_Material = null;
		}
	}

	// Token: 0x06008AB2 RID: 35506 RVA: 0x00197B4A File Offset: 0x00195F4A
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (this.m_Vertex == null)
		{
			toFill.Clear();
			return;
		}
		this.GenerateMeshUI(toFill);
	}

	// Token: 0x06008AB3 RID: 35507 RVA: 0x00197B68 File Offset: 0x00195F68
	protected virtual void Update()
	{
		if (this.m_MatBlock != null && this.m_MeshRenderer != null)
		{
			this.m_MeshRenderer.GetPropertyBlock(this.m_MatBlock);
			for (int i = 0; i < this.m_MaterialAnimationNames.Length; i++)
			{
				Vector4 vector = this.m_MatBlock.GetVector(this.m_MaterialAnimationNames[i]);
				this.m_Material.SetVector(this.m_MaterialAnimationNames[i], vector);
			}
		}
	}

	// Token: 0x06008AB4 RID: 35508 RVA: 0x00197BE4 File Offset: 0x00195FE4
	private void GenerateMeshUI(VertexHelper vh)
	{
		vh.Clear();
		Color color = this.color;
		if (this.m_Colors.Count >= this.m_Vertex.Count)
		{
			for (int i = 0; i < this.m_Vertex.Count; i++)
			{
				vh.AddVert(this.m_Vertex[i], color * this.m_Colors[i], this.m_UV[i]);
			}
		}
		else
		{
			for (int j = 0; j < this.m_Vertex.Count; j++)
			{
				vh.AddVert(this.m_Vertex[j], color, this.m_UV[j]);
			}
		}
		int num = this.m_Triangles.Length / 3;
		for (int k = 0; k < num; k++)
		{
			vh.AddTriangle(this.m_Triangles[k * 3], this.m_Triangles[k * 3 + 1], this.m_Triangles[k * 3 + 2]);
		}
	}

	// Token: 0x04004499 RID: 17561
	[FormerlySerializedAs("m_MaterialAnimationNames")]
	[SerializeField]
	private string[] m_MaterialAnimationNames;

	// Token: 0x0400449A RID: 17562
	private List<Vector3> m_Vertex;

	// Token: 0x0400449B RID: 17563
	private List<Vector2> m_UV;

	// Token: 0x0400449C RID: 17564
	private List<Color> m_Colors;

	// Token: 0x0400449D RID: 17565
	private int[] m_Triangles;

	// Token: 0x0400449E RID: 17566
	private MeshRenderer m_MeshRenderer;

	// Token: 0x0400449F RID: 17567
	private MaterialPropertyBlock m_MatBlock;
}
