using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FD7 RID: 4055
internal class UnderLineGraphic : MaskableGraphic
{
	// Token: 0x06009B20 RID: 39712 RVA: 0x001E033B File Offset: 0x001DE73B
	protected override void OnEnable()
	{
		this._Clear();
		base.OnEnable();
	}

	// Token: 0x06009B21 RID: 39713 RVA: 0x001E0349 File Offset: 0x001DE749
	private void _Clear()
	{
		this.m_iCount = 0;
		this.m_akVertexs.Clear();
		this.m_akColors.Clear();
		this.m_akUIVertexs.Clear();
		this.m_aiIndexs.Clear();
	}

	// Token: 0x06009B22 RID: 39714 RVA: 0x001E037E File Offset: 0x001DE77E
	public void BeginDraw()
	{
		this._Clear();
	}

	// Token: 0x06009B23 RID: 39715 RVA: 0x001E0388 File Offset: 0x001DE788
	public void DrawRect(float fX, float fY, float fW, float fH, Color color)
	{
		this.m_akVertexs.Clear();
		this.m_akVertexs.Add(new Vector3(fX, fY, 0f));
		this.m_akVertexs.Add(new Vector3(fX + fW, fY + fH, 0f));
		this.m_akVertexs.Add(new Vector3(fX + fW, fY, 0f));
		this.m_akVertexs.Add(new Vector3(fX, fY + fH, 0f));
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
		for (int i = 0; i < 4; i++)
		{
			UIVertex uivertex = default(UIVertex);
			uivertex.color = this.m_akColors[i];
			uivertex.normal = Vector3.back;
			uivertex.position = this.m_akVertexs[i];
			uivertex.tangent = new Vector4(0f, 1f, 0f, 1f);
			uivertex.uv0 = this.m_akUVTemps[i];
			uivertex.uv1 = this.m_akUVTemps[i];
			UIVertex item = uivertex;
			this.m_akUIVertexs.Add(item);
		}
	}

	// Token: 0x06009B24 RID: 39716 RVA: 0x001E0580 File Offset: 0x001DE980
	public void EndDraw()
	{
	}

	// Token: 0x06009B25 RID: 39717 RVA: 0x001E0582 File Offset: 0x001DE982
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		toFill.Clear();
		if (this.m_akUIVertexs.Count > 0)
		{
			toFill.AddUIVertexStream(this.m_akUIVertexs, this.m_aiIndexs);
		}
	}

	// Token: 0x06009B26 RID: 39718 RVA: 0x001E05AD File Offset: 0x001DE9AD
	protected override void OnDestroy()
	{
		this.m_akUVTemps = null;
		this.m_akVertexs = null;
		this.m_akColors = null;
		this.m_akUIVertexs = null;
		this.m_aiIndexs = null;
		base.OnDestroy();
	}

	// Token: 0x040054AE RID: 21678
	private Vector2[] m_akUVTemps = new Vector2[]
	{
		new Vector2(0f, 0f),
		new Vector2(1f, 1f),
		new Vector2(1f, 0f),
		new Vector2(0f, 1f)
	};

	// Token: 0x040054AF RID: 21679
	private List<Vector3> m_akVertexs = new List<Vector3>();

	// Token: 0x040054B0 RID: 21680
	private List<Color> m_akColors = new List<Color>();

	// Token: 0x040054B1 RID: 21681
	private List<UIVertex> m_akUIVertexs = new List<UIVertex>();

	// Token: 0x040054B2 RID: 21682
	private List<int> m_aiIndexs = new List<int>();

	// Token: 0x040054B3 RID: 21683
	private int m_iCount;
}
