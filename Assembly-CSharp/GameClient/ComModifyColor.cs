using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F08 RID: 3848
	public class ComModifyColor : BaseMeshEffect
	{
		// Token: 0x1700191A RID: 6426
		// (get) Token: 0x06009654 RID: 38484 RVA: 0x001C7346 File Offset: 0x001C5746
		// (set) Token: 0x06009655 RID: 38485 RVA: 0x001C734E File Offset: 0x001C574E
		public Color colAddColor
		{
			get
			{
				return this.m_colAddColor;
			}
			set
			{
				this.m_colAddColor = value;
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x06009656 RID: 38486 RVA: 0x001C7364 File Offset: 0x001C5764
		public override void ModifyMesh(VertexHelper vertexHelper)
		{
			if (!this.IsActive())
			{
				return;
			}
			UIVertex uivertex = default(UIVertex);
			for (int i = 0; i < vertexHelper.currentVertCount; i++)
			{
				try
				{
					vertexHelper.PopulateUIVertex(ref uivertex, i);
					uivertex.color *= this.colAddColor;
					vertexHelper.SetUIVertex(uivertex, i);
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x04004D2A RID: 19754
		private Color m_colAddColor = Color.white;
	}
}
