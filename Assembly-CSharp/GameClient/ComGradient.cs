using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EF1 RID: 3825
	[AddComponentMenu("UI/Effects/Gradient")]
	internal class ComGradient : BaseMeshEffect
	{
		// Token: 0x060095B7 RID: 38327 RVA: 0x001C42DC File Offset: 0x001C26DC
		public override void ModifyMesh(VertexHelper vertexHelper)
		{
			if (!this.IsActive())
			{
				return;
			}
			if (this.topColor.Equals(this.bottomColor))
			{
				UIVertex uivertex = default(UIVertex);
				for (int i = 0; i < vertexHelper.currentVertCount; i++)
				{
					vertexHelper.PopulateUIVertex(ref uivertex, i);
					uivertex.color = this.topColor;
					vertexHelper.SetUIVertex(uivertex, i);
				}
			}
			else if (vertexHelper.currentVertCount > 0)
			{
				UIVertex uivertex2 = default(UIVertex);
				vertexHelper.PopulateUIVertex(ref uivertex2, 0);
				float num = uivertex2.position.y;
				float num2 = uivertex2.position.y;
				for (int j = 1; j < vertexHelper.currentVertCount; j++)
				{
					vertexHelper.PopulateUIVertex(ref uivertex2, j);
					float y = uivertex2.position.y;
					if (y > num2)
					{
						num2 = y;
					}
					else if (y < num)
					{
						num = y;
					}
				}
				float num3 = num2 - num;
				for (int k = 0; k < vertexHelper.currentVertCount; k++)
				{
					vertexHelper.PopulateUIVertex(ref uivertex2, k);
					uivertex2.color = Color32.Lerp(this.bottomColor, this.topColor, (uivertex2.position.y - num) / num3);
					vertexHelper.SetUIVertex(uivertex2, k);
				}
			}
		}

		// Token: 0x04004C9E RID: 19614
		[SerializeField]
		private Color32 topColor = Color.white;

		// Token: 0x04004C9F RID: 19615
		[SerializeField]
		private Color32 bottomColor = Color.black;
	}
}
