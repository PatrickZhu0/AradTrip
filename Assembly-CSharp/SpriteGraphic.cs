using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E55 RID: 3669
internal class SpriteGraphic : MaskableGraphic
{
	// Token: 0x170018F1 RID: 6385
	// (get) Token: 0x060091D9 RID: 37337 RVA: 0x001B03C3 File Offset: 0x001AE7C3
	public override Texture mainTexture
	{
		get
		{
			if (this.m_spriteAsset == null)
			{
				return Graphic.s_WhiteTexture;
			}
			if (this.m_spriteAsset.texSource == null)
			{
				return Graphic.s_WhiteTexture;
			}
			return this.m_spriteAsset.texSource;
		}
	}

	// Token: 0x060091DA RID: 37338 RVA: 0x001B0403 File Offset: 0x001AE803
	public void LoadDefault()
	{
		if (null == this.m_spriteAsset)
		{
			this.m_spriteAsset = (Singleton<AssetLoader>.instance.LoadRes("UI/Image/Emotion/emotion", typeof(SpriteAsset), true, 0U).obj as SpriteAsset);
		}
	}

	// Token: 0x060091DB RID: 37339 RVA: 0x001B0441 File Offset: 0x001AE841
	protected override void OnEnable()
	{
		base.OnEnable();
	}

	// Token: 0x060091DC RID: 37340 RVA: 0x001B0449 File Offset: 0x001AE849
	private void _Clear()
	{
		this.m_iCount = 0;
		this.m_akVertexs.Clear();
		this.m_akColors.Clear();
		this.m_akUVs.Clear();
		this.m_akUIVertexs.Clear();
		this.m_aiIndexs.Clear();
	}

	// Token: 0x060091DD RID: 37341 RVA: 0x001B0489 File Offset: 0x001AE889
	public void BeginDraw()
	{
		this._Clear();
		InvokeMethod.RemoveInvokeCall(this);
		InvokeMethod.Invoke(this, 0.2f, delegate()
		{
			this.SetVerticesDirty();
			this.SetLayoutDirty();
		});
	}

	// Token: 0x060091DE RID: 37342 RVA: 0x001B04B0 File Offset: 0x001AE8B0
	public void DrawSprite(int iEmotionID, float fX, float fY, float fW, float fH, Color color)
	{
		if (this.m_spriteAsset == null || this.m_spriteAsset.listSpriteAssetInfor == null || this.m_spriteAsset.listSpriteAssetInfor.Count <= 0)
		{
			return;
		}
		bool flag = false;
		Rect rect = this.m_spriteAsset.listSpriteAssetInfor[0].rect;
		for (int i = 0; i < this.m_spriteAsset.listSpriteAssetInfor.Count; i++)
		{
			if (this.m_spriteAsset.listSpriteAssetInfor[i].ID == iEmotionID)
			{
				rect = this.m_spriteAsset.listSpriteAssetInfor[i].rect;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		Vector2 vector;
		vector..ctor((float)this.m_spriteAsset.texSource.width, (float)this.m_spriteAsset.texSource.height);
		int count = this.m_akUIVertexs.Count;
		this.m_akVertexs.Clear();
		this.m_akVertexs.Add(new Vector3(fX, fY, 0f));
		this.m_akVertexs.Add(new Vector3(fX + fW, fY + fH, 0f));
		this.m_akVertexs.Add(new Vector3(fX + fW, fY, 0f));
		this.m_akVertexs.Add(new Vector3(fX, fY + fH, 0f));
		this.m_akUVs.Clear();
		this.m_akUVs.Add(new Vector2(rect.x / vector.x, rect.y / vector.y));
		this.m_akUVs.Add(new Vector2((rect.x + rect.width) / vector.x, (rect.y + rect.height) / vector.y));
		this.m_akUVs.Add(new Vector2((rect.x + rect.width) / vector.x, rect.y / vector.y));
		this.m_akUVs.Add(new Vector2(rect.x / vector.x, (rect.y + rect.height) / vector.y));
		this.m_akColors.Clear();
		this.m_akColors.Add(color);
		this.m_akColors.Add(color);
		this.m_akColors.Add(color);
		this.m_akColors.Add(color);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count + 1);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count + 2);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count + 1);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count);
		this.m_aiIndexs.Add(this.m_akUIVertexs.Count + 3);
		for (int j = 0; j < 4; j++)
		{
			UIVertex uivertex = default(UIVertex);
			uivertex.color = this.m_akColors[j];
			uivertex.normal = Vector3.back;
			uivertex.position = this.m_akVertexs[j];
			uivertex.tangent = new Vector4(0f, 1f, 0f, 1f);
			uivertex.uv0 = this.m_akUVs[j];
			uivertex.uv1 = this.m_akUVs[j];
			UIVertex item = uivertex;
			this.m_akUIVertexs.Add(item);
		}
	}

	// Token: 0x060091DF RID: 37343 RVA: 0x001B0877 File Offset: 0x001AEC77
	public void EndDraw()
	{
	}

	// Token: 0x060091E0 RID: 37344 RVA: 0x001B0879 File Offset: 0x001AEC79
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		toFill.Clear();
		if (this.m_akUIVertexs.Count > 0)
		{
			toFill.AddUIVertexStream(this.m_akUIVertexs, this.m_aiIndexs);
		}
	}

	// Token: 0x060091E1 RID: 37345 RVA: 0x001B08A4 File Offset: 0x001AECA4
	protected override void OnDestroy()
	{
		this.m_akUVs = null;
		this.m_akVertexs = null;
		this.m_akColors = null;
		this.m_akUIVertexs = null;
		this.m_aiIndexs = null;
		this.m_spriteAsset = null;
		InvokeMethod.RemoveInvokeCall(this);
		base.OnDestroy();
	}

	// Token: 0x04004908 RID: 18696
	public SpriteAsset m_spriteAsset;

	// Token: 0x04004909 RID: 18697
	private List<Vector3> m_akVertexs = new List<Vector3>();

	// Token: 0x0400490A RID: 18698
	private List<Color> m_akColors = new List<Color>();

	// Token: 0x0400490B RID: 18699
	private List<Vector2> m_akUVs = new List<Vector2>();

	// Token: 0x0400490C RID: 18700
	private List<UIVertex> m_akUIVertexs = new List<UIVertex>();

	// Token: 0x0400490D RID: 18701
	private List<int> m_aiIndexs = new List<int>();

	// Token: 0x0400490E RID: 18702
	private int m_iCount;
}
