using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020045EA RID: 17898
public sealed class InlieText : Text
{
	// Token: 0x060192BE RID: 103102 RVA: 0x007F5470 File Offset: 0x007F3870
	protected override void OnEnable()
	{
		base.OnEnable();
		if (this.m_spriteGraphic == null)
		{
			this.m_spriteGraphic = base.GetComponentInChildren<SpriteGraphic>();
		}
		if (this.m_spriteCanvasRenderer == null)
		{
			this.m_spriteCanvasRenderer = this.m_spriteGraphic.GetComponentInChildren<CanvasRenderer>();
		}
		this.m_spriteAsset = this.m_spriteGraphic.m_spriteAsset;
	}

	// Token: 0x060192BF RID: 103103 RVA: 0x007F54D4 File Offset: 0x007F38D4
	public override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		this.listTagInfor = new List<SpriteTagInfor>();
		IEnumerator enumerator = InlieText.m_spriteTagRegex.Matches(this.text).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Match match = (Match)obj;
				SpriteTagInfor item = new SpriteTagInfor
				{
					name = match.Groups[1].Value,
					index = match.Index,
					size = new Vector2(float.Parse(match.Groups[2].Value) * float.Parse(match.Groups[3].Value), float.Parse(match.Groups[2].Value))
				};
				this.listTagInfor.Add(item);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x060192C0 RID: 103104 RVA: 0x007F55D4 File Offset: 0x007F39D4
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);
		List<UIVertex> list = new List<UIVertex>();
		toFill.GetUIVertexStream(list);
		this.listSprite = new List<InlineSpriteInfor>();
		for (int i = 0; i < this.listTagInfor.Count; i++)
		{
			for (int j = this.listTagInfor[i].index * 6; j < this.listTagInfor[i].index * 6 + 6; j++)
			{
				UIVertex value = list[j];
				value.uv0 = Vector2.zero;
				list[j] = value;
			}
			InlineSpriteInfor inlineSpriteInfor = new InlineSpriteInfor();
			if (this.listTagInfor[i].index == 0)
			{
				Vector2 textAnchorPivot = Text.GetTextAnchorPivot(base.alignment);
				Vector2 sizeDelta = base.rectTransform.sizeDelta;
				inlineSpriteInfor.textpos = -sizeDelta / 2f + new Vector2(sizeDelta.x * textAnchorPivot.x, sizeDelta.y * textAnchorPivot.y - this.listTagInfor[i].size.y);
			}
			else
			{
				inlineSpriteInfor.textpos = list[this.listTagInfor[i].index * 6 - 4].position;
			}
			inlineSpriteInfor.vertices = new Vector3[4];
			inlineSpriteInfor.vertices[0] = new Vector3(0f, 0f, 0f) + inlineSpriteInfor.textpos;
			inlineSpriteInfor.vertices[1] = new Vector3(this.listTagInfor[i].size.x, this.listTagInfor[i].size.y, 0f) + inlineSpriteInfor.textpos;
			inlineSpriteInfor.vertices[2] = new Vector3(this.listTagInfor[i].size.x, 0f, 0f) + inlineSpriteInfor.textpos;
			inlineSpriteInfor.vertices[3] = new Vector3(0f, this.listTagInfor[i].size.y, 0f) + inlineSpriteInfor.textpos;
			Rect rect = this.m_spriteAsset.listSpriteAssetInfor[0].rect;
			for (int k = 0; k < this.m_spriteAsset.listSpriteAssetInfor.Count; k++)
			{
				if (this.listTagInfor[i].name == this.m_spriteAsset.listSpriteAssetInfor[k].name)
				{
					rect = this.m_spriteAsset.listSpriteAssetInfor[k].rect;
				}
			}
			Vector2 vector;
			vector..ctor((float)this.m_spriteAsset.texSource.width, (float)this.m_spriteAsset.texSource.height);
			inlineSpriteInfor.uv = new Vector2[4];
			inlineSpriteInfor.uv[0] = new Vector2(rect.x / vector.x, rect.y / vector.y);
			inlineSpriteInfor.uv[1] = new Vector2((rect.x + rect.width) / vector.x, (rect.y + rect.height) / vector.y);
			inlineSpriteInfor.uv[2] = new Vector2((rect.x + rect.width) / vector.x, rect.y / vector.y);
			inlineSpriteInfor.uv[3] = new Vector2(rect.x / vector.x, (rect.y + rect.height) / vector.y);
			inlineSpriteInfor.triangles = new int[6];
			this.listSprite.Add(inlineSpriteInfor);
		}
		toFill.Clear();
		toFill.AddUIVertexTriangleStream(list);
		this.DrawSprite();
	}

	// Token: 0x060192C1 RID: 103105 RVA: 0x007F5A2C File Offset: 0x007F3E2C
	private void DrawSprite()
	{
		Mesh mesh = new Mesh();
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = new List<Vector2>();
		List<int> list3 = new List<int>();
		for (int i = 0; i < this.listSprite.Count; i++)
		{
			for (int j = 0; j < this.listSprite[i].vertices.Length; j++)
			{
				list.Add(this.listSprite[i].vertices[j]);
			}
			for (int k = 0; k < this.listSprite[i].uv.Length; k++)
			{
				list2.Add(this.listSprite[i].uv[k]);
			}
			for (int l = 0; l < this.listSprite[i].triangles.Length; l++)
			{
				list3.Add(this.listSprite[i].triangles[l]);
			}
		}
		for (int m = 0; m < list3.Count; m++)
		{
			if (m % 6 == 0)
			{
				int num = m / 6;
				list3[m] = 4 * num;
				list3[m + 1] = 1 + 4 * num;
				list3[m + 2] = 2 + 4 * num;
				list3[m + 3] = 1 + 4 * num;
				list3[m + 4] = 4 * num;
				list3[m + 5] = 3 + 4 * num;
			}
		}
		mesh.vertices = list.ToArray();
		mesh.uv = list2.ToArray();
		mesh.triangles = list3.ToArray();
		if (mesh == null)
		{
			return;
		}
		this.m_spriteCanvasRenderer.SetMesh(mesh);
	}

	// Token: 0x0401207F RID: 73855
	private static readonly Regex m_spriteTagRegex = new Regex("<quad name=(.+?) size=(\\d*\\.?\\d+%?) width=(\\d*\\.?\\d+%?) />", RegexOptions.Singleline);

	// Token: 0x04012080 RID: 73856
	private List<InlineSpriteInfor> listSprite;

	// Token: 0x04012081 RID: 73857
	private SpriteAsset m_spriteAsset;

	// Token: 0x04012082 RID: 73858
	private List<SpriteTagInfor> listTagInfor;

	// Token: 0x04012083 RID: 73859
	private SpriteGraphic m_spriteGraphic;

	// Token: 0x04012084 RID: 73860
	private CanvasRenderer m_spriteCanvasRenderer;
}
